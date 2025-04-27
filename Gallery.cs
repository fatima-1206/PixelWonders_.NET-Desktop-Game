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

    int width = 250;  // Set according to your design size
    int height = 300; // Set according to your design size
    int i = 0;
    int lastX = 0;
    int lastY = 0;

    foreach (int designId in designIds)
    {
        System.Diagnostics.Debug.WriteLine(designId);

        Panel Container = new Panel();
        Container.Width = width;
        Container.Height = height;
        PictureBox pb = new PictureBox();
        pb.Width = width;
        pb.Height = 250;
        pb.Margin = new Padding(15, 10, 15, 0);
        pb.Cursor = Cursors.Hand;

        LoadAndRenderDesign(designId, 20, 20, pb, Program.dbManager);
        pb.Tag = new DesignInfo { DesignId = designId, IsPreMade = false };
        pb.Click += DesignPictureBox_Click;

        Container.Controls.Add(pb);

        Label designName = new Label();
        designName.Text = Titleize(Program.dbManager.GetGridNameFromId(designId));
        designName.Location = new Point(10, 260);

        designName.Font = new Font("Pixelify Sans", 12F, FontStyle.Bold);
        designName.TextAlign = ContentAlignment.MiddleCenter;
        Container.Controls.Add(designName);

        // Set the position of the current user design
        Container.Location = new Point(lastX, lastY);

        // Add the user design container to the parent panel
        designsContainer.Controls.Add(Container);

        // Update the position for the next user design
        lastX += width + 10; // 10 is the gap between designs horizontally

        // Check if the current row is full (i.e., we exceed the panel width)
        if (lastX + width > designsContainer.Width)
        {
            lastX = 0;
            lastY += height + 10; // Move to the next row
        }

        i++;
    }

    // Now populate the pre-made designs
    populatePreMadeDesigns(lastX, lastY, width, height);
}

private void populatePreMadeDesigns(int startX, int startY, int width, int height)
{
    string preMadePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "PreMadeDesigns");

    if (!Directory.Exists(preMadePath))
    {
        MessageBox.Show("Pre-Made Designs folder not found!");
        return;
    }

    string[] preMadeImages = Directory.GetFiles(preMadePath, "*.jpeg"); // or *.jpg

    if (preMadeImages.Length == 0)
    {
        MessageBox.Show("No pre-made designs found!");
        return;
    }

    int xPos = startX;
    int yPos = startY;

    foreach (var imgPath in preMadeImages)
    {
        Panel Container = new Panel();
        Container.Width = width;
        Container.Height = height;

        PictureBox pb = new PictureBox();
        pb.Width = width;
        pb.Height = 250;
        pb.Margin = new Padding(15, 10, 15, 0);
        pb.Cursor = Cursors.Hand;
        pb.Image = Image.FromFile(imgPath);
        pb.SizeMode = PictureBoxSizeMode.StretchImage;
        pb.Tag = new DesignInfo { PreMadePath = imgPath, IsPreMade = true };
        pb.Click += DesignPictureBox_Click;
        Container.Controls.Add(pb);

        // Label for Pre-Made Design
        Label designName = new Label();
        string nameWithoutExtension = Path.GetFileNameWithoutExtension(imgPath);
        designName.Text = Titleize(nameWithoutExtension);
        designName.Location = new Point(10, 260);
        designName.Font = new Font("Pixelify Sans", 12F, FontStyle.Bold);
        designName.TextAlign = ContentAlignment.MiddleCenter;
        Container.Controls.Add(designName);

        // Set the position of the pre-made design container
        Container.Location = new Point(xPos, yPos);

        // Add the container to the parent panel
        designsContainer.Controls.Add(Container);

        // Update xPos and yPos for the next pre-made design
        xPos += width + 10; // 10 is the gap between designs horizontally

        // Check if the current row is full (i.e., we exceed the panel width)
        if (xPos + width > designsContainer.Width)
        {
            xPos = startX;
            yPos += height + 10; // Move to the next row
        }
    }
}
        private void DesignPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;

            if (clickedPictureBox != null && clickedPictureBox.Tag is DesignInfo info)
            {
                SelectedDesign.Current = info; // Save the clicked design globally

                jigsaw puzzle = new jigsaw();
                puzzle.Show();
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

        private void close_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Menu1 menu1 = Application.OpenForms["Menu1"] as Menu1;
            if (menu1 != null)
                menu1.Show();


            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class DesignInfo
    {
        public int DesignId { get; set; }          // For user-created designs
        public string PreMadePath { get; set; }     // For pre-made images
        public bool IsPreMade { get; set; }         // true = pre-made, false = user design
    }
}
