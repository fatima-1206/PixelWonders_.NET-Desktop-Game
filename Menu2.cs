namespace PixelWonders
{
    public partial class Menu2 : Form
    {
        public Menu2()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Menu1 newForm = new Menu1();  // Create an instance of Form2
            newForm.Show();
            this.Close();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
