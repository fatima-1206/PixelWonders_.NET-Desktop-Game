using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text.Json;
using static PixelWonders.DesignLoader;

namespace PixelWonders
{
    public partial class jigsaw : Form
    {

        PictureBox draggedPiece = null;
        Point originalLocation;

        public jigsaw()
        {
            InitializeComponent();
        }

        private void eraserButton_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void jigsaw_Load(object sender, EventArgs e)
        {
            // Setup panels to allow dropping
            panel1.AllowDrop = true;
            jigsaw_panel.AllowDrop = true;

            // Now attach the event handlers for drag & drop
            panel1.DragEnter += Panel_DragEnter;
            jigsaw_panel.DragEnter += Panel_DragEnter;
            panel1.DragDrop += Panel_DragDrop;
            jigsaw_panel.DragDrop += Panel_DragDrop;

            // Load your design normally
            int designId = 4;
            int gridWidth = 20;
            int gridHeight = 20;

            DesignLoader.LoadAndRenderDesign(designId, gridWidth, gridHeight, pictureBox1, Program.dbManager);
           
            int splitRows = 3;
            int splitCols = 3;

            Bitmap original = (Bitmap)pictureBox1.Image;

            // Split and add pieces to panelPieces
            var pieces = DesignLoader.SplitAndReturnPieces(original, splitRows, splitCols, panel1);
            
            foreach (var pb in pieces)
            {
                pb.MouseDown += PuzzlePiece_MouseDown;
                panel1.Controls.Add(pb);
            }
            DesignLoader.ShufflePieces(panel1);
        }
        private void PuzzlePiece_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pb = sender as PictureBox;
                if (pb != null)
                {
                    pb.DoDragDrop(pb, DragDropEffects.Move);
                }
            }
        }
        private void Panel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                PictureBox pb = (PictureBox)e.Data.GetData(typeof(PictureBox));
                Panel targetPanel = sender as Panel;

                if (targetPanel != null && pb != null)
                {
                    // Move to target panel
                    Point clientPoint = targetPanel.PointToClient(new Point(e.X, e.Y));
                    pb.Parent = targetPanel;

                    // 🧩 SNAP TO GRID
                    int pieceWidth = targetPanel.Width / 3;   // assuming 3x3 grid
                    int pieceHeight = targetPanel.Height / 3;

                    int snappedX = (clientPoint.X / pieceWidth) * pieceWidth;
                    int snappedY = (clientPoint.Y / pieceHeight) * pieceHeight;

                    pb.Location = new Point(snappedX, snappedY);
                    pb.BringToFront();
                }
                CheckIfPuzzleSolved();
            }
        }


        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        

        private void PuzzlePiece_MouseUp(object sender, MouseEventArgs e)
        {
            if (draggedPiece == null) return;

            // Snap to nearest other piece, or swap
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is PictureBox target && target != draggedPiece)
                {
                    Rectangle dropZone = new Rectangle(target.Left, target.Top, target.Width, target.Height);
                    if (dropZone.Contains(draggedPiece.Location))
                    {
                        // Swap positions
                        var temp = new Point(target.Left, target.Top);
                        target.Location = originalLocation;
                        draggedPiece.Location = temp;
                        break;
                    }
                }
            }

            draggedPiece = null;
        }




        private void gridContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu2 menu = new Menu2();
            menu.Show(this);
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void jigsaw_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DesignLoader.ShufflePieces(panel1);
        }
        private void CheckIfPuzzleSolved()
        {
            bool allCorrect = true;

            foreach (Control ctrl in jigsaw_panel.Controls)
            {
                if (ctrl is PictureBox pb)
                {
                    Point correctPos = (Point)pb.Tag;

                    int pieceWidth = jigsaw_panel.Width / 3;
                    int pieceHeight = jigsaw_panel.Height / 3;

                    int currentCol = pb.Left / pieceWidth;
                    int currentRow = pb.Top / pieceHeight;

                    if (currentCol != correctPos.X || currentRow != correctPos.Y)
                    {
                        allCorrect = false;
                        break;
                    }
                }
            }

            if (allCorrect && jigsaw_panel.Controls.Count == 9) // 3x3 = 9 pieces
            {
                MessageBox.Show("🏆 Puzzle Solved! Congratulations!", "Victory");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Menu2 back = Application.OpenForms["Menu2"] as Menu2;
            if (back != null)
                back.Show();

            this.Close();
        }
    }
}
