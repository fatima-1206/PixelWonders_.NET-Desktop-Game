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
using System.Drawing.Drawing2D;
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
            string username = txtUsername.Text.Trim();

            string password = passwordTextBox.Text.Trim();
            string hashedPassword = SecurityHelper.HashPassword(password);

            bool isValidUser = Program.dbManager.ValidateUser(username, hashedPassword);

            if (isValidUser)
            {
                Console.WriteLine("Login Successful!");
                UserSession.CurrentUsername = username;
                Menu1 menuPage = new Menu1();
                menuPage.Show();
                this.Close();
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
            this.Close();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Home)
                {
                    form.Show();
                    this.Close();
                    return;
                }
            }

            // If Home is not open, create a new instance
            Home homePage = new Home();
            homePage.Show();
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Home)
                {
                    form.Show();
                    this.Close();
                    return;
                }
            }

            // If Home is not open, create a new instance
            Home homePage = new Home();
            homePage.Show();
            this.Close();
        }

        public string getUser()
        {
            return txtUsername.Text.Trim();
        }

        private void eyePicBox_Click(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !passwordTextBox.UseSystemPasswordChar;
            if (passwordTextBox.UseSystemPasswordChar)
            {
                eyePicBox.Image = Properties.Resources.closeEye;
            }
            else eyePicBox.Image = Properties.Resources.opneEye;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
    public static class UserSession
    {
        public static string CurrentUsername { get; set; }
    }
}
