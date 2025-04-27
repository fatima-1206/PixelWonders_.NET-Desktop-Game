using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PixelWonders.Palette;

namespace PixelWonders
{
    public partial class Menu1 : Form
    {
        public Menu1()
        {
            InitializeComponent();
            this.Name = "menuPage";
        }
        private void RoundButton(Button btn)
        {
            int radius = 60; // Adjust for roundness
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            btn.Region = new Region(path);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            RoundButton(button1);
            RoundButton(button2);

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PaletteForm paletteForm = new PaletteForm();
            paletteForm.Show();

            this.Hide();


        }

        private void Label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            Login loginPage = new Login();
            loginPage.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
   
}
