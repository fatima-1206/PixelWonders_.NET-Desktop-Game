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
namespace PixelWonders
{
    public partial class Nonogram : Form
    {

        private static readonly Random _random = new Random();
        private static string animal = GetRandomAnimalKey();
        private List<Image> animalPics = GetImages(animal);
        int direction = 1;
        int numberOfLives = 5;

        public Nonogram()
        {
            InitializeComponent();
            animalPanel.Hide();
            populateLives();
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
                pictureBox.Size = new Size(heartWidth+2, heartWidth); // square image
                pictureBox.Location = new Point(i * (heartWidth + spacing), 0);
                pictureBox.BackColor = Color.Transparent; // optional: keep if needed

                livesPanel.Controls.Add(pictureBox);
            }
        }


        private void close_Click(object sender, EventArgs e)
        {
            PaletteForm paletteForm = Application.OpenForms["paletteForm"] as PaletteForm;
            if (paletteForm != null)
                paletteForm.Show();

            this.Close();
        }

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
            if (WalkAnimations.Contains(animalPanel.Image)) {
                
                int begin = 765+15;
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
    }
}
