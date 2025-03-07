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
using static PixelWonders.Palette;

namespace PixelWonders
{

    public partial class PaletteForm : Form
    {
        public PaletteForm()
        {
            InitializeComponent();
            LoadPalettes();
        }
        private void LoadPalettes()
        {
            flowLayoutPanel1.Controls.Clear(); // Clear old palettes

            foreach (var palette in ColorPalettes.Palettes)
            {
                Panel palettePanel = new Panel
                {
                    Width = 100,
                    Height = 150,
                    BorderStyle = BorderStyle.None,
                    Margin = new Padding(15, 5, 15, 5), //Padding wider side margins
                    //Padding a wider left margin
                    //Padding = new Padding(10),

                    Tag = palette.Key
                };

                // Attach Click Event
                palettePanel.Click += PalettePanel_Click;

                // Create color preview boxes inside the panel
                int colorWidth = palettePanel.Width;
                int colorHeight = palettePanel.Height / palette.Value.Count;
                for (int i = 0; i < palette.Value.Count; i++)
                {
                    Panel colorBox = new Panel
                    {
                        Width = colorWidth,
                        Height = colorHeight,
                        BackColor = ColorTranslator.FromHtml(palette.Value[i]),
                        Top = i * colorHeight
                    };
                    palettePanel.Controls.Add(colorBox);
                    colorBox.Click += (sender, e) => PalettePanel_Click(palettePanel, e);
                }

                // Click event to select the palette
                palettePanel.Click += PalettePanel_Click;

                Label nameLabel = new Label
                {
                    Text = palette.Key,
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Bottom,
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent,
                    Font = new Font("Pixelify Sans", 10, FontStyle.Bold),
                    Height = 25
                    //MaximumSize = new Size(100, 0), // Prevent overflow
                };
                Panel containerPanel = new Panel
                {
                    Width = 100,
                    Height = 175, // Increased height to accommodate the label
                    Margin = new Padding(15, 5, 15, 5),
                };


                //nameLabel.MaximumSize = new Size(containerPanel.Width, 0); // Allow wrapping
                nameLabel.AutoEllipsis = true; // Adds "..." if the text is still too long
                // Add palettePanel and nameLabel to the container panel
                containerPanel.Controls.Add(palettePanel);
                containerPanel.Controls.Add(nameLabel);
                // Add to the flow layout
                flowLayoutPanel1.Controls.Add(containerPanel);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void PalettePanel_Click(object sender, EventArgs e)
        {
            if (sender is Panel clickedPanel && clickedPanel.Tag is string paletteName)
            {
                // Get the selected palette colors
                List<string> colors = ColorPalettes.GetPalette(paletteName);

                // Clear the previous preview
                //panel1.Controls.Clear();
                panel3.Controls.Clear();
                //panel4.Controls.Clear();


                // Calculate width for each color block
                int colorWidth = panel3.Width / colors.Count;
                int colorHeight = panel3.Height;

                // Display colors inside the preview panel
                for (int i = 0; i < colors.Count; i++)
                {
                    Panel colorBox = new Panel
                    {
                        Width = colorWidth,
                        Height = colorHeight,
                        BackColor = ColorTranslator.FromHtml(colors[i]),
                        Left = i * colorWidth
                    };

                    panel3.Controls.Add(colorBox);

                }

                //add the labels to panel 4: palette name and preview heading
                Label nameLabel = new Label
                {
                    Text = paletteName,
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Bottom,
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent,
                    Font = new Font("Pixelify Sans", 10, FontStyle.Bold),
                    Height = panel4.Height / 2
                };
                Label previewHeading = new Label
                {
                    Text = "Preview:",
                    AutoSize = false,
                    TextAlign = ContentAlignment.TopLeft,
                    Dock = DockStyle.Bottom,
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent,
                    Font = new Font("Pixelify Sans", 14, FontStyle.Bold),
                    Height = panel1.Height,
                    Padding = new Padding(5, 5, 5, 5)
                };
                panel1.Controls.Add(previewHeading);
                panel4.Controls.Clear();
                panel4.Controls.Add(nameLabel);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}




