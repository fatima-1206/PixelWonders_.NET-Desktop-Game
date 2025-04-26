using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.Json;
using System.Data.SQLite;
using System.Drawing.Drawing2D;

namespace PixelWonders
{
    internal class DesignLoader
    {
        public void RoundButton(Button btn)
        {
            int radius = 60; 
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            btn.Region = new Region(path);
        }
        public static void LoadAndRenderDesign(int designId, int width, int height, PictureBox targetPictureBox, DatabaseManager db)
        {
            try
            {
                // Load int grid
                int[,] intGrid = Program.dbManager.LoadGridAsIntMatrix(designId, width, height);
                if (intGrid == null)
                {
                    throw new Exception("Design not found or failed to deserialize.");
                }

                // Get paletteId for the design
                int paletteId = Program.dbManager.GetPaletteIdForDesign(designId);
                List<string> palette = Program.dbManager.GetPaletteHexColors(paletteId);

                // Convert to hex grid
                string[,] hexGrid = Program.dbManager.MapGridToHexColors(intGrid, palette);

                // Convert to bitmap
                Bitmap bmp = CreateBitmapFromHexGrid(hexGrid);

                // Set picture box
                targetPictureBox.Image = bmp;
                targetPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error loading design: " + ex.Message);
            }
        }

        private static Bitmap CreateBitmapFromHexGrid(string[,] hexGrid, int scale = 20)
        {
            int rows = hexGrid.GetLength(0);
            int cols = hexGrid.GetLength(1);

            int bmpWidth = cols * scale;
            int bmpHeight = rows * scale;

            Bitmap bmp = new Bitmap(bmpWidth, bmpHeight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        using (Brush brush = new SolidBrush(ColorTranslator.FromHtml(hexGrid[y, x])))
                        {
                            g.FillRectangle(brush, x * scale, y * scale, scale, scale);
                        }
                    }
                }
            }

            return bmp;
        }

        public static void LoadDesignAsPixelGrid(int designId,int width,int height,Panel containerPanel,DatabaseManager db,int pixelSize = 20)
        {
            try
            {
                // Step 1: Load int grid
                int[,] intGrid = db.LoadGridAsIntMatrix(designId, width, height);
                if (intGrid == null)
                {
                    MessageBox.Show("❌ Failed to load design grid from database.");
                    return;
                }

                // Step 2: Get palette used for design
                int paletteId = db.GetPaletteIdForDesign(designId);
                List<string> palette = db.GetPaletteHexColors(paletteId);

                // Step 3: Convert to hex grid
                string[,] hexGrid = db.MapGridToHexColors(intGrid, palette);

               

                // Step 5: Create pixel grid as PictureBoxes
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {

                        PictureBox pixelBox = new PictureBox
                        {
                            Width = pixelSize,
                            Height = pixelSize,
                            BackColor = ColorTranslator.FromHtml(hexGrid[i, j]),
                            BorderStyle = BorderStyle.None,
                            Location = new Point(j * pixelSize, i * pixelSize),
                            Tag = new Point(i, j) // Store position if needed
                        };

                        // Optional: Add click event if you want interaction
                        pixelBox.Click += (s, e) =>
                        {
                            var clicked = s as PictureBox;
                            MessageBox.Show($"Clicked cell at {clicked?.Tag}");
                        };

                        containerPanel.Controls.Add(pixelBox);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("💥 Error rendering pixel grid:\n" + ex.Message);
            }
        }

        public static List<Bitmap> SplitImage(Bitmap original, int rows, int cols)
        {
            List<Bitmap> pieces = new List<Bitmap>();

            int pieceWidth = original.Width / cols;
            int pieceHeight = original.Height / rows;

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    Rectangle srcRect = new Rectangle(x * pieceWidth, y * pieceHeight, pieceWidth, pieceHeight);
                    Bitmap piece = original.Clone(srcRect, original.PixelFormat);
                    pieces.Add(piece);
                }
            }

            return pieces;
        }

        public static void SplitAndDisplay(Bitmap original, int rows, int cols, Panel targetPanel)
        {
            targetPanel.Controls.Clear(); // Clear previous pieces

            int panelWidth = targetPanel.Width;
            int panelHeight = targetPanel.Height;

            int pieceWidth = panelWidth / cols;
            int pieceHeight = panelHeight / rows;

            // Scale the original image to fit the panel perfectly
            Bitmap scaledOriginal = new Bitmap(panelWidth, panelHeight);
            using (Graphics g = Graphics.FromImage(scaledOriginal))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, 0, 0, panelWidth, panelHeight);
            }

            // ➡️ Now place manually (no auto layout)
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Rectangle srcRect = new Rectangle(col * pieceWidth, row * pieceHeight, pieceWidth, pieceHeight);
                    Bitmap piece = scaledOriginal.Clone(srcRect, scaledOriginal.PixelFormat);

                    PictureBox pb = new PictureBox
                    {
                        Width = pieceWidth,
                        Height = pieceHeight,
                        Left = col * pieceWidth,    
                        Top = row * pieceHeight,    
                        Image = piece,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = new Point(col, row)    // Store position for later
                    };

                    targetPanel.Controls.Add(pb);
                }
            }
        }
        public static List<PictureBox> SplitAndReturnPieces(Bitmap original, int rows, int cols, Panel targetPanel)
        {
            targetPanel.Controls.Clear();

            List<PictureBox> pieces = new List<PictureBox>();

            int panelWidth = targetPanel.Width;
            int panelHeight = targetPanel.Height;
            int pieceWidth = panelWidth / cols;
            int pieceHeight = panelHeight / rows;

            Bitmap scaledOriginal = new Bitmap(panelWidth, panelHeight);
            using (Graphics g = Graphics.FromImage(scaledOriginal))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, 0, 0, panelWidth, panelHeight);
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Rectangle srcRect = new Rectangle(col * pieceWidth, row * pieceHeight, pieceWidth, pieceHeight);
                    Bitmap piece = scaledOriginal.Clone(srcRect, scaledOriginal.PixelFormat);

                    PictureBox pb = new PictureBox
                    {
                        Width = pieceWidth,
                        Height = pieceHeight,
                        Left = col * pieceWidth,
                        Top = row * pieceHeight,
                        Image = piece,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = new Point(col, row)
                    };

                    pieces.Add(pb);
                }
            }

            return pieces;
        }
        public static void ShufflePieces(Panel puzzlePanel)
        {
            var rnd = new Random();
            var pieces = puzzlePanel.Controls.OfType<PictureBox>().ToList();

            // Shuffle the PictureBox positions
            var positions = pieces.Select(pb => new Point(pb.Left, pb.Top)).ToList();
            var shuffledPositions = positions.OrderBy(_ => rnd.Next()).ToList();

            for (int i = 0; i < pieces.Count; i++)
            {
                pieces[i].Left = shuffledPositions[i].X;
                pieces[i].Top = shuffledPositions[i].Y;
            }
        }




    }

}
