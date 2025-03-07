using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            Menu1 menuPage = new Menu1();

            // Show the Menu1 form
            menuPage.Show();

            // Close the Signup form
            this.Hide();
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
    }
}
