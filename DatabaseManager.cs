using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using static PixelWonders.Palette;
using PixelWonders;

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
            ExecuteQuery(conn, "PRAGMA foreign_keys = ON;", "Foreign key support");

            // Create tables only if they don’t exist
            if (!TableExists(conn, "User"))
            {
                ExecuteQuery(conn, @"
                    CREATE TABLE User (
                        username TEXT PRIMARY KEY, 
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

            if (!TableExists(conn, "Design"))
            {
                ExecuteQuery(conn, @"
                    CREATE TABLE Design (
                        DesignId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        UserId INTEGER NOT NULL,
                        PaletteId INTEGER NOT NULL,
                        GridWidth INTEGER NOT NULL,
                        GridHeight INTEGER NOT NULL,
                        CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY (UserId) REFERENCES User(username),
                        FOREIGN KEY (PaletteId) REFERENCES Palette(PaletteId)
                    );", "Design table");
            }

            if (!TableExists(conn, "Pixel"))
            {
                ExecuteQuery(conn, @"
                    CREATE TABLE Pixel (
                        PixelId INTEGER PRIMARY KEY AUTOINCREMENT,
                        DesignId INTEGER NOT NULL,
                        X INTEGER NOT NULL,
                        Y INTEGER NOT NULL,
                        HexCode TEXT NOT NULL,
                        FOREIGN KEY (DesignId) REFERENCES Design(DesignId)
                    );", "Pixel table");
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
            conn.Close();
        }
    }

    // Method to create a design
    public void CreateDesign(string designName, string username, string paletteName, int gridWidth, int gridHeight)
    {
        using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
        {
            conn.Open();

            // Get userId for the username
            string userQuery = "SELECT username FROM User WHERE username = @username";
            using (SQLiteCommand userCmd = new SQLiteCommand(userQuery, conn))
            {
                userCmd.Parameters.AddWithValue("@username", username);
                var userId = userCmd.ExecuteScalar();

                // Get paletteId for the paletteName
                string paletteQuery = "SELECT PaletteId FROM Palette WHERE Name = @paletteName";
                using (SQLiteCommand paletteCmd = new SQLiteCommand(paletteQuery, conn))
                {
                    paletteCmd.Parameters.AddWithValue("@paletteName", paletteName);
                    var paletteId = paletteCmd.ExecuteScalar();

                    // Insert the design into the Design table
                    string designQuery = "INSERT INTO Design (Name, UserId, PaletteId, GridWidth, GridHeight) VALUES (@Name, @UserId, @PaletteId, @GridWidth, @GridHeight)";
                    using (SQLiteCommand designCmd = new SQLiteCommand(designQuery, conn))
                    {
                        designCmd.Parameters.AddWithValue("@Name", designName);
                        designCmd.Parameters.AddWithValue("@UserId", userId);
                        designCmd.Parameters.AddWithValue("@PaletteId", paletteId);
                        designCmd.Parameters.AddWithValue("@GridWidth", gridWidth);
                        designCmd.Parameters.AddWithValue("@GridHeight", gridHeight);
                        designCmd.ExecuteNonQuery();
                    }
                }
            }
            conn.Close();
        }
    }
    public int GetDesignIdFromDatabase(string designName)
    {
        int designId = -1;

        using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
        {
            conn.Open();
            string query = "SELECT DesignId FROM Design WHERE Name = @designName";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@designName", designName);
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    designId = Convert.ToInt32(result);
                }
            }
            conn.Close();
        }

        return designId;
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

            conn.Close();
        }
    }



}

