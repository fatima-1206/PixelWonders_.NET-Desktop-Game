using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PixelWonders.Palette;

namespace PixelWonders
{
    public partial class CreateDesign : Form
    {
        Grid grid;
        int selectedColor = -1;
        public CreateDesign(string paletteName = "")
        {
            InitializeComponent();
            LoadPage("Earthy");
        }

        private void LoadPage(string paletteName)
        {
            List<string> colors = ColorPalettes.GetPalette(paletteName);
            // initialize the grid with the selected palette

            grid = new Grid(ColorPalettes.GetPalette(paletteName), paletteName);
            // create the grid view
            int pixelHeight =( (int)Math.Floor((double)gridContainer.Height - (grid.height)) / grid.height);
            int pixelWidth = ((int)Math.Floor((double)gridContainer.Width - (grid.width)) / grid.width);


            for (int i = 0; i < grid.width; i++)
            {
                for (int j = 0; j < grid.height; j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Width = pixelWidth;
                    pb.Height = pixelHeight;
                    pb.Padding = new Padding(0, 0, 0, 0);
                    pb.Margin = new Padding(1,1,0,0);
                    pb.Location = new Point(i * pb.Width , j * pb.Height);
                    pb.BackColor = ColorTranslator.FromHtml("#F0f0f0");

                    int row = i;
                    int col = j;
                  
                    pb.Click += (sender, e) => PixelClicked(sender, row, col);

                    gridContainer.Controls.Add(pb);

                }
            }

            //return;


            int cWidth = palettePanel.Width;
            int cHeight = palettePanel.Height / grid.selectedPalette.Count;
            // load the colors into the palettePanel
            int colornum = 0;
            foreach (string color in grid.selectedPalette)
            {

                Panel colorPanel = new Panel();

                int colorIndex = colornum;
                colorPanel.Width = cWidth;
                colorPanel.Height = cHeight;
                colorPanel.Margin = new Padding(0, 0, 0, 0);
                colorPanel.Padding = new Padding(0, 0, 0, 0);
                colorPanel.Location = new Point(0, colornum * cHeight);
                colorPanel.BackColor = ColorTranslator.FromHtml(color);
                palettePanel.Controls.Add(colorPanel);

                colorPanel.Click += (sender, e) => ColorClicked(sender, colorIndex);
                colornum++;

            }
        }

        private void ColorClicked(object sender, int index)
        {
            selectedColor = index;
        }
        private void PixelClicked(object sender, int row, int col)
        {
            if (selectedColor == -1) return;
            grid.UpdatePixel(row, col, selectedColor);
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = ColorTranslator.FromHtml(grid.selectedPalette[selectedColor]);
            
        }

        private void CreateDesign_Load(object sender, EventArgs e)
        {

        }

        private void close_Paint(object sender, PaintEventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void gridContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Eraser_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
