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
using System.Text.Json;
using static PixelWonders.DesignLoader;
namespace PixelWonders
{
    public partial class jigsaw : Form
    {
        public jigsaw()
        {
            InitializeComponent();
        }

        private void eraserButton_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void jigsaw_Load(object sender, EventArgs e)
        {

            int designId = 4;
            int gridWidth = 20;  // <- replace with your actual design width
            int gridHeight = 20; // <- replace with your actual design height

          


            DesignLoader.LoadAndRenderDesign(designId, gridWidth, gridHeight, pictureBox1, Program.dbManager);

        }

        private void gridContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu2 menu = new Menu2();
            menu.Show(this);
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
