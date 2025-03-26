using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelWonders
{
        public class Grid
        {
            public List<string> selectedPalette; // Store the selected palette
            public string selectedPaletteName; // Store the name of the selected palette

            public int width = 20; // Width (in "pixels") of the grid
            public int height = 20; // Height (in "pixels") of the grid
            public int[,] pixelGrid; // 2D array to store the color of each "pixel" in the grid

            public Grid(List<string> palette, string paletteName)
            {
                selectedPalette = palette;
                selectedPaletteName = paletteName;
                pixelGrid = new int[width, height];

                // Initialize all pixels to -1 (empty state)
                for (int row = 0; row < height; row++)
                {
                    for (int col = 0; col < width; col++)
                    {
                        pixelGrid[row, col] = -1;
                    }
                }
            }

            // Update a pixel with a color index
            public void UpdatePixel(int row, int col, int color)
            {
                if (IsValidPosition(row, col))
                {
                    pixelGrid[row, col] = color;
                }
            }

            // Erase a pixel by resetting to -1
            public void ErasePixel(int row, int col)
            {
                if (IsValidPosition(row, col))
                {
                    pixelGrid[row, col] = -1;
                }
            }

            // Get the color index of a pixel
            public int GetPixel(int row, int col)
            {
                if (IsValidPosition(row, col))
                {
                    return pixelGrid[row, col];
                }
                return -1; // Invalid position
            }

            // Helper function to check bounds
            private bool IsValidPosition(int row, int col)
            {
                return row >= 0 && row < height && col >= 0 && col < width;
            }

            // Save the design (to be implemented)
            public void SaveDesign()
            {
                // TODO: Implement database saving logic
            }
        }
}





