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

namespace PixelWonders
{
    public partial class Gallery : Form
    {
        List<int> designIds;
        public Gallery()
        {
            InitializeComponent();
            designIds = Program.dbManager.GetAllGridIds();

            printMatrix(designIds);
            if (designIds.Count == 0)
            {
                MessageBox.Show("No designs found in the database.");
                //this.Close();

            }

            populateGallery();
        }
        public void printMatrix(List<int> matrix)
        {

            for (int j = 0; j < matrix.Count(); j++)
            {
                System.Diagnostics.Debug.Write(matrix[j] + " ");
            }
            System.Diagnostics.Debug.WriteLine("");

        }

        private void populateGallery()
        {
            designsContainer.Controls.Clear(); // Clear any existing controls if needed

            int width = 20;  // Set according to your design size
            int height = 20; // Set according to your design size

            foreach (int designId in designIds)
            {
                PictureBox pb = new PictureBox();
                pb.Width = 20; // or any size you prefer
                pb.Height = 20;
                pb.Margin = new Padding(10);
                pb.Cursor = Cursors.Hand;

                // Load and render the design into this picturebox
                LoadAndRenderDesign(designId, width, height, pb, Program.dbManager);

                

                // Add the PictureBox to the panel
                designsContainer.Controls.Add(pb);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void close_Paint(object sender, PaintEventArgs e)
        {
            // look fof hidden menu1 instance and show it
            foreach (Form form in Application.OpenForms)
            {
                if (form is Menu1)
                {
                    form.Show();
                    this.Hide();
                    return;
                }
            }

            this.Close();
        }
    }
}
