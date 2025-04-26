using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PixelWonders.Properties;
using static PixelWonders.Animation;
//using PixelWonders.DatabaseManager;
namespace PixelWonders
{
    public partial class Nonogram : Form
    {

        private static readonly Random _random = new Random();
        private static string animal = GetRandomAnimalKey();
        private List<Image> animalPics = GetImages(animal);
        int[,] orginalGrid;
        int[,] croppedGrid;
        int minRow = 0;
        int maxRow = 0;
        int minCol = 0;
        int maxCol = 0;
        int gridWidth = 0;
        int gridHeight = 0;

        int direction = 1;
        int numberOfLives = 5;

        public Nonogram()
        {
            InitializeComponent();
            animalPanel.Hide();
            populateLives();
            InitializeGrid();
            DrawGrid();
            drawClues();
        }

        public void InitializeGrid()
        {
            // first get a list of all ids of the grid
            List<int> gridIds = Program.dbManager.GetAllGridIds();
            //if ()
            // pick a random one
            int randomIndex = _random.Next(gridIds.Count);
            // make a binary matrix copy by getting rid of all the 0s and converting the rest to 1s
            orginalGrid = Program.dbManager.LoadGridAsIntMatrix(gridIds[randomIndex], 20, 20);
            // for debugging

            // printMatrix(orginalGrid);
            //System.Diagnostics.Debug.WriteLine("Original Grid: ");
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
            // crop the matrix by getting rid of all empty cells at the boundaries  
            // for debugging
            //System.Diagnostics.Debug.WriteLine("Binary Grid: ");

            // printMatrix(binaryMatrix);
            croppedGrid = CropMatrix(binaryMatrix);
            // for debugging
            //System.Diagnostics.Debug.WriteLine("Cropped Grid: ");
            // printMatrix(croppedGrid);
            //croppedGrid = binaryMatrix;
        }
        public void DrawGrid()
        {
            gridHeight = croppedGrid.GetLength(0); // rows (Y)
            gridWidth = croppedGrid.GetLength(1);  // columns (X)

            int pixelWidth = ((int)Math.Floor((double)gridContainer.Width - (gridWidth)) / gridWidth);
            int pixelHeight = ((int)Math.Floor((double)gridContainer.Height - (gridHeight)) / gridHeight);


            for (int row = 0; row < gridHeight; row++)
            {
                for (int col = 0; col < gridWidth; col++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Width = pixelWidth;
                    pb.Height = pixelHeight;
                    pb.Margin = new Padding(1, 1, 0, 0);
                    pb.Location = new Point(col * pb.Width, row * pb.Height);

                    if (croppedGrid[row, col] == 1)
                    {
                        pb.BackColor = ColorTranslator.FromHtml("#b38fbd");
                    }
                    else
                    {
                        pb.BackColor = ColorTranslator.FromHtml("#F0f0f0");
                    }

                    gridContainer.Controls.Add(pb);
                }
            }

        }

        public void drawClues()
        {
            gridContainer.Margin = new Padding(0, 0, 0, 0);
            gridContainer.Padding = new Padding(0, 0, 0, 0);
            // Clear any previous clues
            rowCluesPanel.Controls.Clear();
            colCluesPanel.Controls.Clear();

            gridHeight = croppedGrid.GetLength(0); // number of rows
            gridWidth = croppedGrid.GetLength(1);  // number of columns

            int pixelWidth = ((int)Math.Floor((double)gridContainer.Width - (gridWidth)) / gridWidth);
            int pixelHeight = ((int)Math.Floor((double)gridContainer.Height - (gridHeight)) / gridHeight);

            rowCluesPanel.Margin = new Padding(0, 0, 0, 0);
            rowCluesPanel.Padding = new Padding(0, 0, 0, 0);

            // Draw Row Clues (left of the grid)
            for (int row = 0; row < gridHeight; row++)
            {
                Panel dividor = new Panel();
                dividor.BackColor = Color.FromArgb(83, 54, 89);
                dividor.Height = 1;
                dividor.Width = rowCluesPanel.Width;
                dividor.Margin = new Padding(0, 0, 0, 0);
                rowCluesPanel.Controls.Add(dividor);

                List<int> clues = new List<int>();
                int count = 0;

                for (int col = 0; col < gridWidth; col++)
                {
                    if (croppedGrid[row, col] == 1)
                    {
                        count++;
                    }
                    else if (count > 0)
                    {
                        clues.Add(count);
                        count = 0;
                    }
                }
                if (count > 0)
                    clues.Add(count);

                // Now, create a label or multiple labels to display the clues
                Label clueLabel = new Label();
                //clueLabel.AutoSize = true;
                clueLabel.Width = rowCluesPanel.Width;
                clueLabel.Height = pixelHeight;
                clueLabel.Padding = new Padding(0, pixelWidth / 4, 0, 0);
                clueLabel.Margin = new Padding(0, 0, 0, 0);
                clueLabel.Text = (clues.Count > 0) ? string.Join(" ", clues) : "0";
                clueLabel.Font = new Font("Arial", 10, FontStyle.Bold);
                clueLabel.Location = new Point(0, row * pixelHeight);
                rowCluesPanel.Controls.Add(clueLabel);
            }



            // Draw Column Clues (above the grid)
            for (int col = 0; col < gridWidth; col++)
            {
                Panel dividor = new Panel();
                dividor.BackColor = Color.FromArgb(83, 54, 89);
                dividor.Width = 1;
                dividor.Height = colCluesPanel.Height;
                dividor.Margin = new Padding(0, 0, 0, 0);
                colCluesPanel.Controls.Add(dividor);

                List<int> clues = new List<int>();
                int count = 0;

                for (int row = 0; row < gridHeight; row++)
                {
                    if (croppedGrid[row, col] == 1)
                    {
                        count++;
                    }
                    else if (count > 0)
                    {
                        clues.Add(count);
                        count = 0;
                    }
                }
                if (count > 0)
                    clues.Add(count);

                Label clueLabel = new Label();
                clueLabel.AutoSize = false;
                clueLabel.Height = colCluesPanel.Height;
                clueLabel.Width = pixelWidth;
                clueLabel.Padding = new Padding(0, 0, 0, 0);
                clueLabel.Margin = new Padding(0, 0, 0, 0);
                clueLabel.Text = (clues.Count > 0) ? string.Join("\n", clues) : "0"; // vertical text
                clueLabel.Font = new Font(label1.Font.FontFamily, 10, FontStyle.Bold);
                clueLabel.Location = new Point(col * pixelWidth + 1, 0);
                colCluesPanel.Controls.Add(clueLabel);
            }
        }


        public void printMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    System.Diagnostics.Debug.Write(matrix[i, j] + " ");
                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }

        public int[,] CropMatrix(int[,] grid)
        {

            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            minRow = rows;
            maxRow = -1;
            minCol = cols;
            maxCol = -1;

            // Step 1: Find bounds
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] == 1)
                    {
                        if (i < minRow) minRow = i;
                        if (i > maxRow) maxRow = i;
                        if (j < minCol) minCol = j;
                        if (j > maxCol) maxCol = j;
                    }
                }
            }
            // Edge case: all zero
            if (maxRow == -1) return new int[0, 0];

            int newRows = maxRow - minRow + 1;
            int newCols = maxCol - minCol + 1;

            int[,] cropped = new int[newRows, newCols];

            // Step 2: Copy cropped region
            for (int i = 0; i < newRows; i++)
            {
                for (int j = 0; j < newCols; j++)
                {
                    cropped[i, j] = grid[minRow + i, minCol + j];
                }
            }

            return cropped;
        }

        public void populateLives()
        {
            int spacing = 10;
            int heartWidth = 45; // size used in pictureBox.Size 

            livesPanel.Padding = new Padding(spacing, 3, 3, 3);

            for (int i = 0; i < numberOfLives; i++)
            {

                PictureBox pictureBox = new PictureBox();
                pictureBox.Margin = new Padding(0); // remove margin
                pictureBox.Image = Resources.heart_1_;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Size = new Size(heartWidth + 2, heartWidth); // square image
                pictureBox.Location = new Point(i * (heartWidth + spacing), 0);
                pictureBox.BackColor = Color.Transparent; // optional: keep if needed

                livesPanel.Controls.Add(pictureBox);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Menu2 menu2 = Application.OpenForms["menu2"] as Menu2;
            if (menu2 != null)
                menu2.Show();

            this.Close();
        }




        //-------------------------------------------------------------------------------------------------------------------------
        // animation related code--------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------

        private void animalPanel_Click(object sender, EventArgs e)
        {
            animal = GetRandomAnimalKey();
            animalPics = GetImages(animal);
            animalPanel.Image = animalPics[0];
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

                int begin = 765 + 15;
                int end = begin + 274 - 70;

                int step = 3;

                if (animalPanel.Location.X == end)
                {
                    direction = -1;
                }
                else if (animalPanel.Location.X == begin)
                {
                    direction = 1;
                }
                else { }
                animalPanel.Location = new Point(animalPanel.Location.X + (step * direction), animalPanel.Location.Y);

            }
        }


        private void gridContainer_Paint(object sender, PaintEventArgs e) { }
        private void close_Paint(object sender, PaintEventArgs e) { }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Nonogram_Load(object sender, EventArgs e)
        {

        }
    }
}
