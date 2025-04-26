using System.Drawing.Drawing2D;

namespace PixelWonders
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.FormClosing += Home_FormClosing;
        }
        private void RoundButton(Button btn)
        {
            int radius = 60; // Adjust for roundness
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            btn.Region = new Region(path);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RoundButton(button2);
            RoundButton(button3);
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            Login loginPage = new Login();

            // Show the Login form
            loginPage.Show();

            // Close 
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Program.dbManager?.Dispose();
            Application.Exit();
            Environment.Exit(0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
