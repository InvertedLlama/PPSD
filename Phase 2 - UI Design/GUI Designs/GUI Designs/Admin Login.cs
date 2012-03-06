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
    public partial class frm_adminLogin : Form
    {
        public frm_adminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_configuration f = new frm_configuration();
            f.Show();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_launch f = new frm_launch();
            f.Show();
        }
    }
}
