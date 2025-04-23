using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.Json;
using System.Data.SQLite;

namespace PixelWonders
{
    internal class DesignLoader
    {
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

                // Step 4: Clear previous controls and set up panel
                //containerPanel.Controls.Clear();
                //containerPanel.AutoScroll = true;
                //containerPanel.Width = width * pixelSize;
                //containerPanel.Height = height * pixelSize;

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

    }

}
