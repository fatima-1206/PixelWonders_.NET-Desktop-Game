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
using System.Text.Json;
using static PixelWonders.Palette;

namespace PixelWonders
{
    public partial class CreateDesign : Form
    {
        Grid grid;
        int selectedColor = -1;
        bool eraserSelected = false;
        bool hoverLock = false;
        public CreateDesign(string paletteName = "Earthy")
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            LoadPage(paletteName);
            loadPalette();
        }

        private void LoadPage(string paletteName)
        {
            List<string> colors = ColorPalettes.GetPalette(paletteName);
            // initialize the grid with the selected palette

            grid = new Grid(ColorPalettes.GetPalette(paletteName), paletteName);
            // create the grid view
            int pixelHeight = ((int)Math.Floor((double)gridContainer.Height - (grid.height)) / grid.height);
            int pixelWidth = ((int)Math.Floor((double)gridContainer.Width - (grid.width)) / grid.width);


            for (int i = 0; i < grid.width; i++)
            {
                for (int j = 0; j < grid.height; j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Width = pixelWidth;
                    pb.Height = pixelHeight;
                    pb.Padding = new Padding(0, 0, 0, 0);
                    pb.Margin = new Padding(1, 1, 0, 0);
                    pb.Location = new Point(i * pb.Width, j * pb.Height);
                    pb.BackColor = ColorTranslator.FromHtml("#F0f0f0");

                    int row = i;
                    int col = j;

                    pb.Click += (sender, e) => PixelClicked(sender, row, col);
                    pb.MouseHover += (sender, e) => PixelHover(sender, row, col);

                    gridContainer.Controls.Add(pb);

                }
            }

            //return;


        }


        private void loadPalette()
        {

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
                if (colorIndex == selectedColor)
                {
                    colorPanel.Width += 10;

                }

                palettePanel.Controls.Add(colorPanel);



                colorPanel.Click += (sender, e) => ColorClicked(sender, colorIndex);
                colornum++;

            }
        }
        private void ColorClicked(object sender, int index)
        {
            selectedColor = index;
            loadPalette();

        }
        private void PixelHover(object sender, int row, int col)
        {
            if (selectedColor == -1) return;
            if (hoverLock)
            {
                PictureBox pb = (PictureBox)sender;
                if (selectedColor == -1) return;
                int currentPixelColor = grid.GetPixelColor(row, col);
                if (eraserSelected && currentPixelColor != -1)
                {
                    grid.UpdatePixel(row, col, -1);
                    pb.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                    grid.printGrid();
                    return;
                }
                if (eraserSelected) return;

                if (currentPixelColor == selectedColor) return; // Skip if same color

                grid.UpdatePixel(row, col, selectedColor);

                pb.BackColor = ColorTranslator.FromHtml(grid.selectedPalette[selectedColor]);
                grid.printGrid();
            }

        }
        private void PixelClicked(object sender, int row, int col)
        {
            PictureBox pb = (PictureBox)sender;
            if (selectedColor == -1) return;
            if (eraserSelected)
            {
                grid.UpdatePixel(row, col, -1);
                pb.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                grid.printGrid();
                return;
            }
            grid.UpdatePixel(row, col, selectedColor);

            pb.BackColor = ColorTranslator.FromHtml(grid.selectedPalette[selectedColor]);
            grid.printGrid();
        }

        private void CreateDesign_Load(object sender, EventArgs e)
        {

        }

        private void close_Paint(object sender, PaintEventArgs e)
        {
        }

        private void close_Click(object sender, EventArgs e)
        {
            PaletteForm paletteForm = Application.OpenForms["paletteForm"] as PaletteForm;
            if (paletteForm != null)
                paletteForm.Show();

            this.Close();

        }
        private void Eraser_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Eraser_Click(object sender, EventArgs e)
        {
            eraserSelected = !eraserSelected;
            if (eraserSelected)
                eraserButton.BackColor = Color.FromArgb(222, 183, 219);
            else eraserButton.BackColor = Color.FromArgb(241, 217, 231);
        }
        private void palettePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lockPic_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Assuming you have a design name and username available



            // Step 1: Retrieve design name from the TextBox
            string designName = designN.Text;
            string username = UserSession.CurrentUsername;
            string paletteName = grid.selectedPaletteName;

            // Validate input
            if (string.IsNullOrWhiteSpace(designName))
            {
                MessageBox.Show("Please enter a design name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("User not logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Serialize grid as flat list of color indices
            List<int> serializedGrid = new List<int>();
            for (int row = 0; row < grid.height; row++)
            {
                for (int col = 0; col < grid.width; col++)
                {
                    int colorIndex = grid.GetPixelColor(row, col);
                    serializedGrid.Add(colorIndex); // could be -1 if no color
                }
            }

            // 2. Convert to JSON string
            string jsonMatrix = JsonSerializer.Serialize(serializedGrid);

            // 3. Get palette ID from palette name
            int paletteId = Program.dbManager.GetPaletteIdFromName(paletteName);
            if (paletteId == -1)
            {
                MessageBox.Show("Invalid palette selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Insert into PixelGrid table
            bool success = Program.dbManager.SavePixelGrid(designName, jsonMatrix, paletteId, username);

            if (success)
            {
                MessageBox.Show("Design saved successfully!");
            }
            else
            {
                MessageBox.Show("Failed to save design.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LockButton_Click(object sender, EventArgs e)
        {
            hoverLock = !hoverLock;
            if (hoverLock)
            {
                LockButton.Image = Properties.Resources.locked;
                LockButton.BackColor = Color.FromArgb(222, 183, 219);
            }
            else
            {
                LockButton.Image = Properties.Resources.unlocked;
                LockButton.BackColor = Color.FromArgb(241, 217, 231);
            }
        }

        private void gridContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void headerContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
