using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PixelWonders.Properties;
using static PixelWonders.Animation;

namespace PixelWonders
{
    public partial class Color_by_number : Form
    {
        private static readonly Random _random = new Random();
        private static string animal = GetRandomAnimalKey();
        private List<Image> animalPics = GetImages(animal);
        int direction = 1;
        int[,] orginalGrid;
        int[,] croppedGrid;
        int minRow = 0;
        int maxRow = 0;
        int minCol = 0;
        int maxCol = 0;
        int gridWidth = 0;
        int gridHeight = 0;
        private Color selectedColor = Color.Transparent; // this is initially "nothing"
        private int selectedNumber;
        private List<string> paletteColors;


        public Color_by_number()
        {
            InitializeComponent();
            animalPanel.Hide();
            InitializeGrid();

        }
        public void InitializeGrid()
        {
            

            // first getting ids of the grid
            List<int> gridIds = Program.dbManager.GetAllGridIds();

            //random design
            int randomIndex = _random.Next(gridIds.Count);
            int selectedGridId = gridIds[randomIndex];

            // loading matrix
            orginalGrid = Program.dbManager.LoadGridAsIntMatrix(selectedGridId, 20, 20);

            // fetch the palette for the selected design
            int paletteId = Program.dbManager.GetPaletteIdForDesign(selectedGridId);
            paletteColors = Program.dbManager.GetPaletteHexColors(paletteId);

            // make a binary matrix copy (optional, based on your use)
            int[,] binaryMatrix = new int[orginalGrid.GetLength(0), orginalGrid.GetLength(1)];
            for (int i = 0; i < orginalGrid.GetLength(0); i++)
            {
                for (int j = 0; j < orginalGrid.GetLength(1); j++)
                {
                    if (orginalGrid[i, j] == -1)
                    {
                        binaryMatrix[i, j] = 0;
                    }
                    else
                    {
                        binaryMatrix[i, j] = 1;
                    }
                }
            }



           // int pixelWidth = 20;
            //int pixelHeight = 20;
            // int pixelWidth = (gridContainer.Width - (gridWidth + 1)) / gridWidth;
            //int pixelHeight = (gridContainer.Height - (gridHeight + 1)) / gridHeight;

            gridHeight = orginalGrid.GetLength(0);
            gridWidth = orginalGrid.GetLength(1);
    

            int pixelWidth = ((int)Math.Floor((double)gridContainer.Width) / gridWidth);
            int pixelHeight = ((int)Math.Floor((double)gridContainer.Height) / gridHeight);
            pixelWidth += 1;    // Make button a little wider
            pixelHeight += 1;
            //gridContainer.Width = 420;
            //gridContainer.Height = 420;
            //gridContainer.Location = new Point(59, 50);
            gridContainer.Padding = new Padding(0);

            /* int margin = 30; // space around the grid
             gridContainer.Width = panel2.Width - margin * 2;
             gridContainer.Height = panel2.Height - margin * 2;
             gridContainer.Location = new Point(margin, margin);*/
            int margin = 30;
            gridContainer.Width = gridWidth * pixelWidth + 1;   
            gridContainer.Height = gridHeight * pixelHeight + 1;
            gridContainer.Location = new Point(margin, margin);



            gridContainer.Controls.Clear(); // clear old controls if any
            Font pixelFont = new Font("Pixelify Sans", 6, FontStyle.Bold);
            for (int row = 0; row < gridHeight; row++)
            {
                for (int col = 0; col < gridWidth; col++)
                {
                    Button btn = new Button();
                    btn.Padding = new Padding(0);  // Remove internal padding

                    // Remove border by setting FlatStyle and BorderSize
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Width = pixelWidth;
                    btn.Height = pixelHeight;
                    btn.Margin = new Padding(0);
                    btn.ForeColor = Color.FromArgb(83, 54, 89);
                    btn.Location = new Point(col * btn.Width, row * btn.Height);
                    //  btn.Location = new Point(col * pixelWidth, row * pixelHeight);
                    btn.Font = pixelFont;

                    int gridValue = orginalGrid[minRow + row, minCol + col];

                    if (gridValue == -1)
                    {
                        btn.Text = "0";          // show 0
                        btn.BackColor = Color.White; // white color
                        btn.Enabled = false;      // cannot click (optional)
                    }
                    else
                    {
                        btn.Text = gridValue.ToString();  // real number
                        btn.Tag = gridValue;              // save number inside tag
                        btn.BackColor = Color.White;       // still white initially
                        btn.Click += Button_Click;         // allow click to color
                    }

                    gridContainer.Controls.Add(btn);
                }
            }

            //int startX = 190;
            //int startY = 10 + 20 * 30 + 20; // below the grid
            int gridBottom = panel2.Bottom; // Get the bottom position of the grid

          
            int spaceBelowGrid = 40; // Space between grid and palette buttons

            // Position(just below the grid)
            int startY = gridBottom + spaceBelowGrid;

            // Starting X position for palette buttons
            int startX = 145;
            Font pixelFont2 = new Font("Pixelify Sans", 8, FontStyle.Bold);
            for (int i = 0; i < paletteColors.Count; i++)
            {
                Button paletteButton = new Button();
                paletteButton.Size = new Size(40, 40);
                paletteButton.Location = new Point(startX + i * 40, startY);
                paletteButton.BackColor = ColorTranslator.FromHtml(paletteColors[i]);

                paletteButton.Text = (i + 1).ToString(); 

                paletteButton.Tag = i + 1; // saving the number for matching
                paletteButton.Font = pixelFont2;

                paletteButton.Click += PaletteButton_Click;
                this.Controls.Add(paletteButton);
            }

        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int requiredNumber = (int)clickedButton.Tag;

            if (requiredNumber == selectedNumber)
            {
                clickedButton.BackColor = selectedColor;
                clickedButton.Text = ""; 
            }
            else
            {
             
                MessageBox.Show("Wrong color! Please select the correct palette color.");
            }
            if (CheckIfGameWon())
            {
                MessageBox.Show("Congratulations! You completed the Color by number game!", "You Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();  // Close the application
            }
        }

        private void PaletteButton_Click(object sender, EventArgs e)
        {
            Button paletteButton = sender as Button;
            selectedNumber = (int)paletteButton.Tag;
            selectedColor = ColorTranslator.FromHtml(paletteColors[selectedNumber - 1]);
        }

        private bool CheckIfGameWon()
        {
            foreach (Button btn in gridContainer.Controls)
            {
                // Only check the buttons that are enabled and should be colored
                if (btn.Enabled && btn.BackColor != selectedColor)
                {
                    return false;  // Not all cells are correctly filled
                }
            }
            return true;  // All cells are correctly filled
        }


        private void Color_by_number_Load(object sender, EventArgs e)
        {

        }

        private void animalPanel_Click(object sender, EventArgs e)
        {
            animal = GetRandomAnimalKey();
            animalPics = GetImages(animal);
            animalPanel.Image = animalPics[0];
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void animalPanel_MouseHover(object sender, EventArgs e)
        {
            int index = _random.Next(animalPics.Count);
            animalPanel.Image = animalPics[index];

        }
        private void imageChangeTimer_Tick(object sender, EventArgs e)
        {
            if (animalPanel.Visible == false)
                animalPanel.Show();
            int index = _random.Next(animalPics.Count);
            animalPanel.Image = animalPics[index];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (WalkAnimations.Contains(animalPanel.Image))
            {
                int begin = 626;
                int end = begin + 240 - animalPanel.Width;
                int step = 3;
                int yLine = 361 - animalPanel.Height;

                if (animalPanel.Location.X >= end)
                {
                    // Jump back to start
                    animalPanel.Location = new Point(begin, yLine);
                }
                else
                {
                    // Keep moving to the right
                    animalPanel.Location = new Point(animalPanel.Location.X + step, yLine);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
