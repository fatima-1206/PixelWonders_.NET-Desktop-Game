using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

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

            if (!TableExists(conn, "ColorPalette"))
            {
                ExecuteQuery(conn, @"
                    CREATE TABLE ColorPalette (
                        palette_ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                        Palette_name TEXT NOT NULL, 
                        Colors TEXT NOT NULL, 
                        username TEXT NOT NULL, 
                        FOREIGN KEY (username) REFERENCES User(username) ON DELETE CASCADE
                    );", "ColorPalette table");
            }

            if (!TableExists(conn, "PixelGrid"))
            {
                ExecuteQuery(conn, @"
                    CREATE TABLE PixelGrid (
                        G_ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                        G_name TEXT NOT NULL, 
                        G_matrix TEXT NOT NULL,  
                        palette_ID INTEGER NOT NULL, 
                        username TEXT NOT NULL, 
                        FOREIGN KEY (palette_ID) REFERENCES ColorPalette(palette_ID) ON DELETE CASCADE,
                        FOREIGN KEY (username) REFERENCES User(username) ON DELETE CASCADE
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


}
