using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using static PixelWonders.Palette;
using PixelWonders;
using System.Text.Json;

class DatabaseManager
{
    public readonly string connectionString;

    public DatabaseManager(string dbFileName)
    {
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dbFileName);
        connectionString = $"Data Source={dbPath};Version=3;";
    }
    public string ConnectionString
    {
        get { return connectionString; }
    }
    public void InitializeDatabase()
    {
        using (SQLiteConnection conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            ExecuteQuery(conn, "PRAGMA journal_mode=WAL;", "Enable WAL mode");
            ;

            // Create tables only if they don’t exist
            if (!TableExists(conn, "User"))
            {
                ExecuteQuery(conn, @"
                    CREATE TABLE User (
                        username TEXT PRIMARY KEY CHECK(length(username) <= 30), 
                        f_name TEXT NOT NULL, 
                        l_name TEXT NOT NULL, 
                        password TEXT NOT NULL
                    );", "User table");
            }

            if (!TableExists(conn, "Palette"))
            {
                ExecuteQuery(conn, @"
                    CREATE TABLE Palette (
                        PaletteId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL UNIQUE
                    );", "Palette table");
            }

            if (!TableExists(conn, "PaletteColor"))
            {
                ExecuteQuery(conn, @"
                    CREATE TABLE PaletteColor (
                        ColorId INTEGER PRIMARY KEY AUTOINCREMENT,
                        PaletteId INTEGER NOT NULL,
                        HexCode TEXT NOT NULL,
                        FOREIGN KEY (PaletteId) REFERENCES Palette(PaletteId)
                    );", "PaletteColor table");
            }


            if (!TableExists(conn, "PixelGrid"))
            {
                ExecuteQuery(conn, @"
                CREATE TABLE PixelGrid (
                    G_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    G_name TEXT NOT NULL,
                    G_matrix TEXT NOT NULL, -- JSON string
                    palette_ID INTEGER NOT NULL,
                    username TEXT NOT NULL,
                    FOREIGN KEY (palette_ID) REFERENCES Palette(PaletteId),
                    FOREIGN KEY (username) REFERENCES User(username)
                );", "PixelGrid table");
            }


            conn.Close();
        }
    }

    private bool TableExists(SQLiteConnection conn, string tableName)
    {
        string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';";
        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
        {
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                return reader.HasRows;
            }
        }
    }

    private void ExecuteQuery(SQLiteConnection conn, string query, string description)
    {
        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
        {
            cmd.ExecuteNonQuery();
        }
    }

    public bool ValidateUser(string username, string password)
    {
        using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
        {
            conn.Open();
            string query = "SELECT password FROM User WHERE LOWER(username) = LOWER(@username)";

            using (SQLiteCommand cmd = new SQLiteCommand("SELECT password FROM User WHERE username = @username", conn))
            {
                cmd.Parameters.AddWithValue("@username", username.Trim()); // Trim username

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) // No user found
                    {
                        //MessageBox.Show("No user found with username: " + username);
                        return false;
                    }

                    if (reader.Read()) // User exists
                    {
                        string storedPassword = reader["password"] as string ?? string.Empty;
                        storedPassword = storedPassword.Trim();

                        //MessageBox.Show("Entered: " + password + "\nStored: " + storedPassword);

                        if (password == storedPassword)
                        {
                            return true; // Login successful
                        }
                    }
                }
            }
        }
        return false; // Login failed
    }

    // Method to add a palette
    public void AddPalette(string paletteName, List<string> hexCodes)
    {
        using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
        {
            conn.Open();
            string query = "INSERT INTO Palette (Name) VALUES (@Name)";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Name", paletteName);
                cmd.ExecuteNonQuery();

                long paletteId = conn.LastInsertRowId;

                // Insert colors for the palette
                foreach (var hexCode in hexCodes)
                {
                    string insertColorQuery = "INSERT INTO PaletteColor (PaletteId, HexCode) VALUES (@PaletteId, @HexCode)";
                    using (SQLiteCommand colorCmd = new SQLiteCommand(insertColorQuery, conn))
                    {
                        colorCmd.Parameters.AddWithValue("@PaletteId", paletteId);
                        colorCmd.Parameters.AddWithValue("@HexCode", hexCode);
                        colorCmd.ExecuteNonQuery();
                    }
                }
            }
            
        }
    }

    public bool SavePixelGrid(string designName, string jsonMatrix, int paletteId, string username)
    {
        using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
        {
            conn.Open();

            string query = "INSERT INTO PixelGrid (G_name, G_matrix, palette_ID, username) " +
                           "VALUES (@G_name, @G_matrix, @palette_ID, @username)";

            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@G_name", designName);
                cmd.Parameters.AddWithValue("@G_matrix", jsonMatrix);
                cmd.Parameters.AddWithValue("@palette_ID", paletteId);
                cmd.Parameters.AddWithValue("@username", username);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("❌ Error saving design:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
              
            }
            
        }
    }

    public int GetPaletteIdFromName(string paletteName)
    {
        int paletteId = -1;

        using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
        {
            conn.Open();
            string query = "SELECT PaletteId FROM Palette WHERE Name = @paletteName";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@paletteName", paletteName);
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    paletteId = Convert.ToInt32(result);
                }
            }
            
        }

        return paletteId;
    }


    // Method to add pixels to a design
    public void AddPixelsToDesign(int designId, List<(int x, int y, string hexCode)> pixels)
    {
        using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
        {
            conn.Open();
            foreach (var pixel in pixels)
            {
                string query = "INSERT INTO Pixel (DesignId, X, Y, HexCode) VALUES (@DesignId, @X, @Y, @HexCode)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DesignId", designId);
                    cmd.Parameters.AddWithValue("@X", pixel.x);
                    cmd.Parameters.AddWithValue("@Y", pixel.y);
                    cmd.Parameters.AddWithValue("@HexCode", pixel.hexCode);
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
        }
    }

    public void AddPredefinedPalettesToDatabase()
    {
        using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
        {
            conn.Open();

            // Iterate over each predefined palette in ColorPalettes
            foreach (var palette in Palette.ColorPalettes.Palettes)
            {
                string paletteName = palette.Key;
                List<string> colors = palette.Value;

                // Check if the palette already exists in the database
                string checkPaletteQuery = "SELECT COUNT(*) FROM Palette WHERE Name = @Name";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkPaletteQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Name", paletteName);
                    var count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    // Only insert the palette if it does not already exist
                    if (count == 0)
                    {
                        // Insert the palette name into the Palette table
                        string insertPaletteQuery = "INSERT INTO Palette (Name) VALUES (@Name)";
                        using (SQLiteCommand insertCmd = new SQLiteCommand(insertPaletteQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@Name", paletteName);
                            insertCmd.ExecuteNonQuery();

                            // Get the PaletteId for the recently inserted palette
                            long paletteId = conn.LastInsertRowId;

                            // Insert each color in PaletteColor table
                            foreach (var hexCode in colors)
                            {
                                string insertColorQuery = "INSERT INTO PaletteColor (PaletteId, HexCode) VALUES (@PaletteId, @HexCode)";
                                using (SQLiteCommand colorCmd = new SQLiteCommand(insertColorQuery, conn))
                                {
                                    colorCmd.Parameters.AddWithValue("@PaletteId", paletteId);
                                    colorCmd.Parameters.AddWithValue("@HexCode", hexCode);
                                    colorCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }

           
        }
    }
    public int GetPaletteIdForDesign(int designId)
    {
        using (var conn = new SQLiteConnection(ConnectionString))
        {
            conn.Open();
            string query = "SELECT palette_ID FROM PixelGrid WHERE G_ID = @id";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", designId);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
           
        }
        
    }
    public List<string> GetPaletteHexColors(int paletteId)
    {
        var colors = new List<string>();

        using var conn = new SQLiteConnection(ConnectionString);
        conn.Open();

        string query = "SELECT HexCode FROM PaletteColor WHERE PaletteId = @id ORDER BY ColorId ASC";
        using var cmd = new SQLiteCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", paletteId);

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            colors.Add(reader.GetString(0));
        }
        conn.Close();
        return colors;
    }

    public void PrintAllDesigns()
    {
        using (var conn = new SQLiteConnection(ConnectionString))
        {
            conn.Open();
            string query = "SELECT G_ID, G_name FROM PixelGrid";

            using (var cmd = new SQLiteCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    MessageBox.Show($"ID: {id}, Name: {name}", "Design Found");
                }
            }
           
        }
    }
    public List<int> GetAllGridIds()
    {
        List<int> gridIds = new List<int>();

        using (var conn = new SQLiteConnection(ConnectionString))
        {
            conn.Open();
            string query = "SELECT G_ID FROM PixelGrid";

            using (var cmd = new SQLiteCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    gridIds.Add(id);
                }
            }
        }

        return gridIds;
    }

    public int[,] LoadGridAsIntMatrix(int designId, int width, int height)
    {
        using var conn = new SQLiteConnection(ConnectionString);
        conn.Open();

        string query = "SELECT G_matrix FROM PixelGrid WHERE G_ID = @designId";
        using var cmd = new SQLiteCommand(query, conn);
        cmd.Parameters.AddWithValue("@designId", designId);

        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            string json = reader.GetString(0);
            int[] flat = JsonSerializer.Deserialize<int[]>(json);
            //if (flat.Length != width * height)
            //{
            //    throw new Exception("Grid size mismatch!");
            //}

            int[,] matrix = new int[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    matrix[i, j] = flat[i * width + j];
            conn.Close();
            return matrix;
        }
        conn.Close();
        return null;
    }

    public string[,] MapGridToHexColors(int[,] indexGrid, List<string> paletteColors)
    {
        int rows = indexGrid.GetLength(0);
        int cols = indexGrid.GetLength(1);
        string[,] hexGrid = new string[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
            {
                int index = indexGrid[i, j];
                if (index >= 0 && index < paletteColors.Count)
                    hexGrid[i, j] = paletteColors[index];
                else
                    hexGrid[i, j] = "#FFFFFF"; // fallback color for -1 or invalid
            }

        return hexGrid;
    }
}

