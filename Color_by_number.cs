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
    public partial class Color_by_number : Form
    {
        private static readonly Random _random = new Random();
        private static string animal = GetRandomAnimalKey();
        private List<Image> animalPics = GetImages(animal);
        int direction = 1;
        public Color_by_number()
        {
            InitializeComponent();
            animalPanel.Hide();
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


    }
}
