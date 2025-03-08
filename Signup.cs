using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixelWonders
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text.Trim();
            string password = textBox3.Text.Trim();
            string firstName = textBox2.Text.Trim();
            string lastName = textBox4.Text.Trim();

            if (username == "" || password == "" || firstName == "" || lastName == "")
            {
                MessageBox.Show("All fields are required!");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=PixelWonders.db;Version=3;"))
            {
                conn.Open();

                // Check if username already exists
                string checkQuery = "SELECT COUNT(*) FROM User WHERE username = @username";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@username", username);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Username already exists. Choose another one.");
                        return;
                    }
                }

                // Insert new user (password stored as plain text)
                string insertQuery = "INSERT INTO User (username, password, f_name, l_name) VALUES (@username, @password, @fname, @lname)";
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password); // Storing password directly
                    cmd.Parameters.AddWithValue("@fname", firstName);
                    cmd.Parameters.AddWithValue("@lname", lastName);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("User registered successfully!");
                        Login loginPage = new Login();
                        loginPage.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error in registration. Try again.");
                    }
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Login loginPage = new Login();

            // Show the Login form
            loginPage.Show();

            // Close the Signup form (or Hide it)
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Login loginPage = new Login();

            // Show the Login form
            loginPage.Show();

            // Close the Signup form (or Hide it)
            this.Hide();
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
