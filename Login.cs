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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }



        private void Button3_Click(object sender, EventArgs e)
        {
            Menu1 menuPage = new Menu1();

            // Show the Menu1 form
            menuPage.Show();

            // Close 
            this.Hide();
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
    }
}
