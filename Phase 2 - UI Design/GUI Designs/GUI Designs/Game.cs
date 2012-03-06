using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI_Designs
{
    public partial class frm_game : Form
    {
        public frm_game()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_game_Load(object sender, EventArgs e)
        {

        }

        private void btn_takeTest_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_test f = new frm_test();
            f.Show();
        }
    }
}
