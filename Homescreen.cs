namespace PixelWonders
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            this.Close();
        }
    }
}
