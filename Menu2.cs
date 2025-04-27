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
            Nonogram nonogram = new Nonogram();
            nonogram.Show();
            this.Close();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Menu1)
                {
                    form.Show();
                    this.Hide();
                    return;
                }
            }

            // If Home is not open, create a new instance
            Menu1 menu1 = new Menu1();
            menu1.Show();
            this.Close();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            Menu1 menu1 = new Menu1();
            menu1.Show();
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            jigsaw puzzle = new jigsaw();
            puzzle.Show();
            this.Close();


        }

        private void Menu2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Color_by_number color_By_Number = new Color_by_number();
            color_By_Number.Show();
            this.Close();

        }
    }
}
