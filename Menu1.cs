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
    public partial class Menu1 : Form
    {
        public Menu1()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Menu2)
                {
                    form.Show();
                    this.Hide();
                    return;
                }
            }

            // If Home is not open, create a new instance
            Menu2 menu2 = new Menu2();
            menu2.Show();
            this.Hide();

        }

        private void Label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
