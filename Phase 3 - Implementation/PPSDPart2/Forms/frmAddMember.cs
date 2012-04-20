using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPSDPart2
{
    public partial class frmAddMember : Form
    {
        public frmAddMember()
        {
            InitializeComponent();
        }

        private void btnSumbit_Click(object sender, EventArgs e)
        {

        }

        private void frmAddMember_VisibleChanged(object sender, EventArgs e)
        {
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtName.Text = string.Empty;
            txtTel.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
