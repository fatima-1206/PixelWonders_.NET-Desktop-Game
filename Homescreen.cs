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

        private void Form1_Load(object sender, EventArgs e)
        {
            DesignLoader d = new DesignLoader();
            d.RoundButton(button2);
            d.RoundButton(button3);
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            //Login loginPage = new Login();

            // Show the Login form
            //loginPage.Show();


            Menu1 menuPage = new Menu1();
            menuPage.Show();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
