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
    public partial class frm_makeTest : Form
    {
        public frm_makeTest()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void frm_makeTest_Load(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_makeTest f = new frm_makeTest();
            f.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_setTest f = new frm_setTest();
            f.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_testResults f = new frm_testResults();
            f.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_configuration f = new frm_configuration();
            f.Show();
        }
    }
}
