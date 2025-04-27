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
            designIds = Program.dbManager.GetAllGridIds();

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
                System.Diagnostics.Debug.WriteLine(designId);

                Panel Container = new Panel();
                Container.Width = 250;
                Container.Height = 300;
                PictureBox pb = new PictureBox();
                pb.Width = 250;
                pb.Height = 250;
                pb.Margin = new Padding(15, 10, 15, 0);
                pb.Cursor = Cursors.Hand;

                // Load and render the design into this picturebox
                LoadAndRenderDesign(designId, width, height, pb, Program.dbManager);
                // add the picturebox to the container
                Container.Controls.Add(pb);
                //now add the name of the design as label to the container
                Label designName = new Label();
                designName.Text = Titleize(Program.dbManager.GetGridNameFromId(designId));
                //designName.AutoSize = true;
                designName.Location = new Point(10, 260); // Adjust the position as needed
                //designName.BackColor = Color.FromArgb(168, 136, 181);
                //designName.ForeColor = Color.FromArgb(239, 182, 200);
                designName.Font = new Font("Pixelify Sans", 12F, FontStyle.Bold);
                designName.TextAlign = ContentAlignment.MiddleCenter;
                Container.Controls.Add(designName);
                // Set the background color of the container
                //Container.BackColor = Color.FromArgb(239, 182, 200);



                Container.Location = new Point((i % 3) * (Container.Width + 10), (i / 3) * (Container.Height + 10)); // Adjust the position based on index
                designsContainer.Controls.Add(Container);

                i++;
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
