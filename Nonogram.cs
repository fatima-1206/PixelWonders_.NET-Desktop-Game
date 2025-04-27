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
        int[,] orginalGrid, croppedGrid;
        int[,] userPlays; // 0 = empty, 1 = filled, 2 = crossed, -1 = wrong
        int minRow = 0, maxRow = 0, minCol = 0, maxCol = 0;
        int gridWidth = 0, gridHeight = 0;
        int designID;
        int direction = 1, numberOfLives = 5;
        bool fillSelected = true;
        int[] solvedRows, solvedCols; // holds index of solved rows and columns
        public Nonogram()
        {
            InitializeComponent();
            animalPanel.Hide();
            populateLives();
            InitializeGrid();
            DrawGrid();
            drawClues();
            updateSolvedRowCols();
            drawClues();
            //DrawGrid();

        }

        public void InitializeGrid()
        {
            // first get a list of all ids of the grid
            List<int> gridIds = Program.dbManager.GetAllGridIds();
            int randomIndex = _random.Next(gridIds.Count);
            orginalGrid = Program.dbManager.LoadGridAsIntMatrix(gridIds[randomIndex], 20, 20);
            designID = gridIds[randomIndex];
            int[,] binaryMatrix = new int[orginalGrid.GetLength(0), orginalGrid.GetLength(1)];
            for (int i = 0; i < orginalGrid.GetLength(0); i++)
            {
                for (int j = 0; j < orginalGrid.GetLength(1); j++)
                {
                    binaryMatrix[i, j] = orginalGrid[i, j] == -1 ? 0 : 1;

                }
            }
            croppedGrid = CropMatrix(binaryMatrix);
            solvedRows = new int[croppedGrid.GetLength(0)];
            solvedCols = new int[croppedGrid.GetLength(1)];
            userPlays = new int[croppedGrid.GetLength(0), croppedGrid.GetLength(1)];
            // initialize userPlays with 0
            for (int i = 0; i < userPlays.GetLength(0); i++)
            {
                solvedRows[i] = 0;
                for (int j = 0; j < userPlays.GetLength(1); j++)
                {
                    userPlays[i, j] = 0;
                }

            }
            for (int i = 0;i <croppedGrid.GetLength(1); i++)
                solvedCols[i] = 0;
            updateSolvedRowCols();
        }
        public void DrawGrid()
        {
            gridContainer.Controls.Clear();
            gridHeight = croppedGrid.GetLength(0); // rows (Y)
            gridWidth = croppedGrid.GetLength(1);  // columns (X)
            int divisor = gridHeight > gridWidth ? gridHeight : gridWidth;

            int pixelWidth = ((int)Math.Floor((double)gridContainer.Width - (divisor)) / divisor);
            int pixelHeight = ((int)Math.Floor((double)gridContainer.Height - (divisor)) / divisor);
            //gridContainer.BackColor = Color.FromArgb(241, 217, 231); 

            for (int row = 0; row < gridHeight; row++)
            {
                for (int col = 0; col < gridWidth; col++)
                {
                    Color glowCross = Color.FromArgb(240, 230, 236);
                    Color glowFill = Color.FromArgb(215, 157, 224);
                    PictureBox pb = new PictureBox();
                    pb.Width = pixelWidth;
                    pb.Height = pixelHeight;
                    pb.Margin = new Padding(1, 1, 0, 0);
                    pb.Location = new Point(col * pb.Width, row * pb.Height);
                    int i = row;
                    int j = col;

                    pb.Click += (sender, e) => PixelClicked(sender, i, j);
                    pb.Tag = new Point(i, j);  

                    //pb.MouseHover += (sender, e) => PixelHover(sender, row, col);

                    if (croppedGrid[row, col] == 1 && userPlays[row, col] == 1)
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

        private void PixelClicked(object sender, int row, int col)
        {
            // it was filled but the user tried to cross it
            Color wrongedFilled = Color.FromArgb(153, 57, 113); // wrong color

            Image wrongdCrossed = Resources.crossed_wrong1;

            Color filledColor = fillOption.BackColor;
            // for crossed, use the picture for crossed
            Image crossedImage = crossOption.BackgroundImage;


            // the user clicked on a filled pixel
            if (userPlays[row, col] != 0) return;
            PictureBox pb = sender as PictureBox;
            pb.BackgroundImageLayout = ImageLayout.Zoom;
            // the two valid cases
            if (fillSelected && croppedGrid[row, col] == 1)
            {
                pb.BackColor = filledColor; // filled color
                userPlays[row, col] = 1; // filled
            }
            else if (!fillSelected && croppedGrid[row, col] == 0)
            {
                pb.BackgroundImage = crossedImage; // crossed image
                userPlays[row, col] = 2; // crossed
            }

            else if (fillSelected && croppedGrid[row, col] == 0)
            {
                pb.BackgroundImage = wrongdCrossed; // wrong image
                userPlays[row, col] = -1; // wrong
                numberOfLives--;
                populateLives();

            }
            else if (!fillSelected && croppedGrid[row, col] == 1)
            {
                pb.BackColor = wrongedFilled; // wrong color
                userPlays[row, col] = -1; // wrong
                numberOfLives--;
                populateLives();

            }
            checkGameStatus();
            // update solved rows and columns
            updateSolvedRowCols();
            //DrawGrid();
            drawClues();
        }

        private void updateSolvedRowCols() {
            // first rows
            for (int i = 0; i < gridHeight; i++)
            {
                // skip this row if it is in solvedRows
                if (solvedRows[i] == 1) continue;
                solvedRows[i] = 1;
                for (int j = 0; j < gridWidth; j++)
                {
                    if (userPlays[i, j] == -1 || userPlays[i, j] == 2) continue;
                    if (userPlays[i, j] != 1 && croppedGrid[i,j] == 1) 
                        solvedRows[i] = 0;
                }
                // if the row just got solved, update the row panels 
                if (solvedRows[i] == 1)
                    solvedRow(i);
            }
            System.Diagnostics.Debug.WriteLine("solved rows:");

            printMatrix(solvedRows);
            // now columns
            for(int i = 0; i < gridWidth; i++)
            {
                // skip this row if it is in solvedRows
                if (solvedCols[i] == 1) continue;
                solvedCols[i] = 1;
                for (int j = 0; j < gridHeight; j++)
                {
                    if (userPlays[j, i] == -1 || userPlays[j, i] == 2) continue;
                    if (userPlays[j, i] != 1 && croppedGrid[j, i] == 1)
                        solvedCols[i] = 0;
                }
                // if the row just got solved, update the row panels 
                if (solvedCols[i] == 1)
                    solvedColumn(i);
            }
            System.Diagnostics.Debug.WriteLine("solved cols:");
            printMatrix(solvedCols);

        }

       
        private void solvedColumn(int col)
        {
            List<PictureBox> pictureBoxes = GetAllPictureBoxes(gridContainer);

            foreach (var pb in pictureBoxes)
            {
                if (pb.Tag is Point point)
                {
                    if (point.Y == col)
                    {
                        if (croppedGrid[point.X, point.Y] == 1)
                            pb.BackColor = Color.FromArgb(242, 225, 234);
                        else
                        {
                            pb.BackColor = Color.FromArgb(242, 225, 234);
                            if (pb.BackgroundImage == null && croppedGrid[point.X, point.Y] == 0)
                            {
                                userPlays[point.X, point.Y] = 2; // crossed
                                pb.BackgroundImage = crossOption.BackgroundImage;
                                pb.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                    }
                }
            }
        }



        private void solvedRow(int row)
        {
            List<PictureBox> pictureBoxes = GetAllPictureBoxes(gridContainer);

            foreach (var pb in pictureBoxes)
            {
                if (pb.Tag is Point point)
                {
                    if (point.X == row)
                    {
                        if (croppedGrid[point.X, point.Y] == 1)
                            pb.BackColor = Color.FromArgb(242, 225, 234);
                        else
                        {
                            pb.BackColor = Color.FromArgb(242, 225, 234);
                            if (pb.BackgroundImage == null && croppedGrid[point.X, point.Y] == 0)
                            {
                                userPlays[point.X, point.Y] = 2; // crossed
                                pb.BackgroundImage = crossOption.BackgroundImage;
                                pb.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                    }
                }
            }
        }
        public List<PictureBox> GetAllPictureBoxes(Panel panel)
        {
            return panel.Controls.OfType<PictureBox>().ToList();
        }

        private bool GameWon()
        {
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridHeight; j++)
                {

                    if (userPlays[i, j] == -1) continue;
                    // some pixel is not filled
                    if (userPlays[i, j] == 0 && croppedGrid[i, j] == 1) return false;
                }

            }
            return true;
        }
        private void revealOriginalGrid() {
            gridContainer.Controls.Clear();
            gridHeight = croppedGrid.GetLength(0); // rows (Y)
            gridWidth = croppedGrid.GetLength(1);  // columns (X)
            int divisor = gridHeight > gridWidth ? gridHeight : gridWidth;

            int pixelWidth = ((int)Math.Floor((double)gridContainer.Width - (divisor)) / divisor);
            int pixelHeight = ((int)Math.Floor((double)gridContainer.Height - (divisor)) / divisor);
            //gridContainer.BackColor = Color.FromArgb(241, 217, 231); 

            // get the palette associate with the grid
            int paletteID = Program.dbManager.GetPaletteIdForDesign(designID);

            List<string> palette = Program.dbManager.GetPaletteHexColors(paletteID);


            for (int row = 0; row < gridHeight; row++)
            {
                for (int col = 0; col < gridWidth; col++)
                {
                    Color glowCross = Color.FromArgb(240, 230, 236);
                    Color glowFill = Color.FromArgb(215, 157, 224);
                    PictureBox pb = new PictureBox();
                    pb.Width = pixelWidth;
                    pb.Height = pixelHeight;
                    pb.Margin = new Padding(1, 1, 0, 0);
                    pb.Location = new Point(col * pb.Width, row * pb.Height);

                    // set the background color based on the original grid
                    int indexColor = orginalGrid[minRow+row, minCol+col];
                    if (indexColor == -1)
                    {
                        pb.BackColor = ColorTranslator.FromHtml("#F0f0f0");
                    }
                    else
                    {
                        pb.BackColor = ColorTranslator.FromHtml(palette[indexColor]);
                    }

                    gridContainer.Controls.Add(pb);
                }
            }
        }
        public void checkGameStatus()
        {
            if (GameWon())
            {
                revealOriginalGrid();
                MessageBox.Show("Congratulations! You solved the Nonogram!");
                this.Close();
            }
            if (numberOfLives <= 0)
            {
                MessageBox.Show("Game Over! You have no lives left.");
                this.Close();
            }
        }
        public void drawClues()
        {

            Color glow = Color.FromArgb(242, 225, 234);
            gridContainer.Margin = new Padding(0, 0, 0, 0);
            gridContainer.Padding = new Padding(0, 0, 0, 0);
            // Clear any previous clues
            rowCluesPanel.Controls.Clear();
            colCluesPanel.Controls.Clear();

            gridHeight = croppedGrid.GetLength(0); // number of rows
            gridWidth = croppedGrid.GetLength(1);  // number of columns
            int divisor = gridHeight > gridWidth ? gridHeight : gridWidth;

            int pixelWidth = ((int)Math.Floor((double)gridContainer.Width - (divisor)) / divisor);
            int pixelHeight = ((int)Math.Floor((double)gridContainer.Height - (divisor)) / divisor);

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
                if (solvedRows[row] == 1)
                    clueLabel.BackColor = glow;

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

                if (solvedCols[col] == 1)
                    clueLabel.BackColor = glow;
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
        public void printMatrix(int[] matrix)
        {
            
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    System.Diagnostics.Debug.Write(matrix[j] + " ");
                }
                System.Diagnostics.Debug.WriteLine("");
            
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

            // Edge case: all zeros
            if (maxRow == -1) return new int[0, 0];

            int height = maxRow - minRow + 1;
            int width = maxCol - minCol + 1;
            int side = Math.Max(height, width);

            // Step 2: Expand to square
            int extraRows = side - height;
            int extraCols = side - width;

            // Try to expand equally on both sides
            minRow = Math.Max(0, minRow - extraRows / 2);
            maxRow = Math.Min(rows - 1, minRow + side - 1);

            minCol = Math.Max(0, minCol - extraCols / 2);
            maxCol = Math.Min(cols - 1, minCol + side - 1);

            // In case adjusting minRow/minCol caused side to shrink, readjust
            // (e.g., when minRow was already 0 and we couldn't expand upward)
            if (maxRow - minRow + 1 < side && maxRow < rows - 1)
                maxRow = Math.Min(rows - 1, minRow + side - 1);
            if (maxCol - minCol + 1 < side && maxCol < cols - 1)
                maxCol = Math.Min(cols - 1, minCol + side - 1);

            int[,] cropped = new int[side, side];

            // Step 3: Copy cropped square
            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    cropped[i, j] = grid[minRow + i, minCol + j];
                }
            }

            return cropped;
        }

        public void populateLives()
        {
            int spacing = 10;
            int heartWidth = livesPanel.Height - 3; // size used in pictureBox.Size 

            livesPanel.Controls.Clear(); // Clear previous lives
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
            {
                animalPanel.Show();
                imageChangeTimer.Interval = 10000;
            }
            int index = _random.Next(animalPics.Count);
            animalPanel.Image = animalPics[index];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (WalkAnimations.Contains(animalPanel.Image))
            {

                int begin = platform.Location.X + animalPanel.Width / 2;
                int end = begin + platform.Width - animalPanel.Width;

                int step = 3;

                if (animalPanel.Location.X >= end)
                {
                    if (direction == -1) return;
                    Image img = animalPanel.Image;
                    img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    animalPanel.Image = img;
                    direction = -1;
                }
                else if (animalPanel.Location.X <= begin)
                {
                    if (direction == 1) return;
                    Image img = animalPanel.Image;
                    img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    animalPanel.Image = img;
                    direction = 1;
                }
                else { }

                animalPanel.Location = new Point(animalPanel.Location.X + (step * direction), animalPanel.Location.Y);

            }
        }


        private void gridContainer_Paint(object sender, PaintEventArgs e) { }
        private void close_Paint(object sender, PaintEventArgs e) { }


        private void fillOption_Click(object sender, EventArgs e)
        {
            fillSelected = true;
            fillOptionContainer.BackColor = Color.FromArgb(240, 230, 236);
            crossOptionContainer.BackColor = Color.FromArgb(241, 217, 231);
        }
        private void crossOption_Click(object sender, EventArgs e)
        {
            fillSelected = false;
            crossOptionContainer.BackColor = Color.FromArgb(240, 230, 236);
            fillOptionContainer.BackColor = Color.FromArgb(241, 217, 231);
        }

        private void fillOptionContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Nonogram_Load(object sender, EventArgs e)
        {

        }
    }
}
