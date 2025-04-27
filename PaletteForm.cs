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
using System.Xml.Linq;
using Microsoft.VisualBasic;
using static PixelWonders.Palette;
namespace PixelWonders
{

    public partial class PaletteForm : Form
    {
        public CreateDesign designForm;

        public string selectedPaletteName;
        int colorWidth =100;
        int colorHeight = 15;


        public PaletteForm()
        {
            InitializeComponent();
            LoadPalettes();
            DisableDonePanel();
            //label1.VerticalAign
        }
        private void DisableDonePanel()

        {
            done.Visible = false;
            foreach (Control c in done.Controls)
            {
                c.Enabled = false; // Disable all child controls
            }
        }

        private void EnableDonePanel()

        {
            done.Visible = true;
            foreach (Control c in done.Controls)
            {
                c.Enabled = true; // Disable all child controls
            }
        }

        private void reloadFromDB() {
            // clear ColorPalettes.Palettes and reload from the database
            ColorPalettes.Palettes.Clear();
            List<int> ids = Program.dbManager.GetAllPaletteIds();
            foreach (int id in ids)
            {
                string name = Program.dbManager.GetPaletteNameFromID(id);
                List<string> colors = Program.dbManager.GetPaletteHexColors(id);
                ColorPalettes.Palettes.Add(name, colors);
            }

        }

        private void LoadPalettes()
        {

            reloadFromDB();
            //label1align
            flowLayoutPanel1.Controls.Clear(); // Clear old palettes
           
            foreach (var palette in ColorPalettes.Palettes)
            {
                Panel palettePanel = new Panel
                {
                    Width = colorWidth,
                    Height = palette.Value.Count * colorHeight,
                    BorderStyle = BorderStyle.None,
                    Margin = new Padding(15, 5, 15, 5), //Padding wider side margins
                    //Padding a wider left margin
                    //Padding = new Padding(10),

                    Tag = palette.Key
                };

                // Attach Click Event
                palettePanel.Click += PalettePanel_Click;

                // Create color preview boxes inside the panel
                
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
                    Width = colorWidth,
                    Height = palettePanel.Height + nameLabel.Height, // Increased height to accommodate the label
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
                selectedPaletteName = paletteName;
                // Get the selected palette colors
                List<string> colors = ColorPalettes.GetPalette(paletteName);

                // Clear the previous preview
                //panel1.Controls.Clear();
                panel3.Controls.Clear();
                panel4.Controls.Clear();


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
                        Left = i * colorWidth,
                        Margin = new Padding(0, 0, 0, 0),
                        Padding = new Padding(0, 0, 0, 0)
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
                    Font = new Font("Pixelify Sans", 12, FontStyle.Bold),
                    Height = panel4.Height
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
            EnableDonePanel();
        }



        private void panel5_Click(object sender, EventArgs e)
        {
            // look for the hidden menu1 form
            Menu1 menuPage = Application.OpenForms["menuPage"] as Menu1;
            if (menuPage != null)
                menuPage.Show();

            this.Close();

        }

        private void DonePanel_Click(object sender, EventArgs e)
        {
            // send the selected palette name and a list of colors to the grid form
            if (designForm == null)
                designForm = new CreateDesign(selectedPaletteName);
            //CreateDesign designForm = new CreateDesign();
            designForm.Show();
            this.Hide();
        }


        private bool PaletteExists(string name)
        {
            // Check if the palette name already exists in the ColorPalettes dictionary
            return ColorPalettes.Palettes.ContainsKey(name);
        }

        private string askPaletteName() {
            //string name = "";
            // Repeat until a unique, non-empty name is entered
            while (true)
            {
                selectedPaletteName = Interaction.InputBox("Enter a name for your palette:", "Palette Name", "");

                if (string.IsNullOrWhiteSpace(selectedPaletteName))
                {
                    MessageBox.Show("Palette name cannot be empty. Please enter a valid name.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                if (PaletteExists(selectedPaletteName)) // <-- You need a function that checks existing palettes
                {
                    MessageBox.Show("Palette name already exists. Please choose a different name.", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                break; // Valid name entered, exit the loop
            }
            return selectedPaletteName;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            string name = askPaletteName();

            Form customColorForm = new Form();
            customColorForm.Text = "Pick Your 10 Colors";
            customColorForm.StartPosition = FormStartPosition.CenterScreen;
            customColorForm.Size = new Size(colorWidth * 3, 20 * colorHeight + colorHeight * 4 + 50);
            customColorForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            customColorForm.BackColor = Color.FromArgb(239, 182, 200);
            customColorForm.FormBorderStyle = FormBorderStyle.None;

            List<Panel> colorPanels = new List<Panel>();

            for (int i = 0; i < 10; i++)
            {
                Panel panel = new Panel();
                panel.Size = new Size(colorWidth + 10, colorHeight + 10);
                panel.Location = new Point(colorWidth + 15, 30 + i * colorHeight * 2);
                panel.BackColor = Color.White;

                Label label = new Label();
                label.Text = $"Color {i + 1}";
                label.Font = new Font("Pixelify Sans", 10, FontStyle.Regular);
                label.Location = new Point(panel.Location.X - colorWidth, panel.Location.Y);
                label.AutoSize = true;
                label.BackColor = Color.Transparent;

                customColorForm.Controls.Add(label);

                panel.Click += (s, e) =>
                {
                    ColorDialog colorDialog = new ColorDialog();
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        panel.BackColor = colorDialog.Color;
                    }
                };

                colorPanels.Add(panel);
                customColorForm.Controls.Add(panel);
            }

            Button saveButton = new Button();
            saveButton.Text = "Save Palette";
            saveButton.Font = new Font("Pixelify Sans", 10, FontStyle.Bold);
            saveButton.Size = new Size(120, 40);
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.BackColor = Color.FromArgb(239, 182, 200);
            saveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(219, 162, 180); // Slight hover effect
            saveButton.Location = new Point(colorWidth + 15, 30 + 10 * colorHeight * 2);

            saveButton.Click += (s, e) =>
            {
                // Count how many panels are not white
                int coloredPanels = colorPanels.Count(p => p.BackColor != Color.White);

                if (coloredPanels == 0)
                {
                    MessageBox.Show("No colors selected. Palette not created.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customColorForm.Close(); // Close the form
    
                    return;
                }

                List<string> colors = new List<string>();
                foreach (Panel p in colorPanels)
                {
                    if (p.BackColor != Color.White)
                        colors.Add(ColorTranslator.ToHtml(p.BackColor));
                }

                // Fill up to 10 colors with white
                while (colors.Count < 10)
                {
                    colors.Add(ColorTranslator.ToHtml(Color.White));
                }

                addPalette(name, colors);
                customColorForm.Close(); // Close the form after saving
            };
            customColorForm.Controls.Add(saveButton);

            customColorForm.ShowDialog();
        }





        private void addPalette(string name, List<string> colors)
        {

            // add the palette to the class and the db and reload the palettes
            ColorPalettes.addPalette(name, colors);
            // Save the palette to the database
            Program.dbManager.AddPalette(name, colors);

            LoadPalettes();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}




