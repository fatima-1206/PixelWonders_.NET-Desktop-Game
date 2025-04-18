using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixelWonders
{
    public partial class Nonogram : Form
    {
        public Nonogram()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        { 
            PaletteForm paletteForm = Application.OpenForms["paletteForm"] as PaletteForm;
            if (paletteForm != null)
                paletteForm.Show();

            this.Close();
        }


    }
}
