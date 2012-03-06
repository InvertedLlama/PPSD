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
    public partial class frm_configuration : Form
    {
        public frm_configuration()
        {
            InitializeComponent();
        }

        private void btn_takeTest_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_game f = new frm_game();
            f.Show();
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
