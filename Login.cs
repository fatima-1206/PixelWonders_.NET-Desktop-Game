using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace PixelWonders
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // Get entered username and password from textboxes
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Debugging: Print entered values
            Console.WriteLine("Entered Username: " + username);
            Console.WriteLine("Entered Password: " + password);

            // Call database function to validate user
            bool isValidUser = Program.dbManager.ValidateUser(username, password);

            if (isValidUser)
            {
                Console.WriteLine("Login Successful!");

                // Proceed to the next form
                Menu1 menuPage = new Menu1();
                menuPage.Show();
                this.Hide();
            }
            else
            {
                Console.WriteLine("Invalid Username or Password!");
                MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Signup signupPage = new Signup();

            // Show the Signup form
            signupPage.Show();

            // Close or Hide the Login form
            this.Hide();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        
    }
}
