using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PixelWonders.jigsaw;
using static PixelWonders.DesignLoader;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;

namespace PixelWonders
{
    public partial class Gallery : Form
    {
        List<int> designIds;
        public Gallery()
        {
            InitializeComponent();
            //designIds = Program.dbManager.GetAllGridIds();

            //printMatrix(designIds);
            //if (designIds.Count == 0)
            //{
            //    MessageBox.Show("No designs found in the database.");
            //    this.Close();

            //}
            // Always load default designs 1, 2, 3
            List<int> defaultDesignIds = new List<int> { 1, 2, 3 };

            // Fetch the logged-in user's designs
            string currentUsername = Program.username; // Assuming you have the current username stored somewhere
            List<int> userDesignIds = Program.dbManager.GetDesignIdsByUsername(currentUsername);

            // Merge both lists
            designIds = defaultDesignIds.Concat(userDesignIds).Distinct().ToList();

            printMatrix(designIds);

            if (designIds.Count == 0)
            {
                MessageBox.Show("No designs found in the database.");
                this.Close();
            }
            populateGallery();

        }
        public void printMatrix(List<int> matrix)
        {

            for (int j = 0; j < matrix.Count; j++)
            {
                System.Diagnostics.Debug.Write(matrix[j] + " ");
            }
            System.Diagnostics.Debug.WriteLine("");

        }


        string Titleize(string input)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }

        private void populateGallery()
        {
            designsContainer.Controls.Clear(); // Clear any existing controls if needed

            int width = 20;  // Set according to your design size
            int height = 20; // Set according to your design size
            int i = 0;
            foreach (int designId in designIds)
            {
                Panel Container = new Panel();
                Container.Width = 250;
                Container.Height = 300;

                PictureBox pb = new PictureBox();
                pb.Width = 250;
                pb.Height = 250;
                pb.Margin = new Padding(15, 10, 15, 0);
                pb.Cursor = Cursors.Hand;

                // 🌟 Attach the designId to PictureBox.Tag
                pb.Tag = designId;

                // 🌟 Add Click event handler
                pb.Click += PictureBox_Click;

                LoadAndRenderDesign(designId, width, height, pb, Program.dbManager);

                Container.Controls.Add(pb);

                Label designName = new Label();
                designName.Text = Titleize(Program.dbManager.GetGridNameFromId(designId));
                designName.Location = new Point(10, 260);
                designName.Font = new Font("Pixelify Sans", 12F, FontStyle.Bold);
                designName.TextAlign = ContentAlignment.MiddleCenter;

                Container.Controls.Add(designName);

                Container.Location = new Point((i % 3) * (Container.Width + 10), (i / 3) * (Container.Height + 10));
                designsContainer.Controls.Add(Container);

                i++;
            }
        }
        // 🌟 Static class to hold selected design
        public static class SelectedDesignHolder
        {
            public static int SelectedDesignId { get; set; }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            if (clickedPictureBox != null && clickedPictureBox.Tag != null)
            {
                int selectedDesignId = (int)clickedPictureBox.Tag;
                SelectedDesignHolder.SelectedDesignId = selectedDesignId;


                 
                Menu2 jigsaw = new Menu2();
                jigsaw.Show();
                this.Close();
            }
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Menu1 menu1 = Application.OpenForms["menu1"] as Menu1;
            if (menu1 != null)
                menu1.Show();


            this.Close();
        }

        private void close_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Menu1 menu = new Menu1();
            menu.Show();
            this.Close();
        }
    }
}
