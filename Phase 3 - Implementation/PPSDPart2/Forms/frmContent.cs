using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace PPSDPart2
{
    public partial class frmContent : Form
    {
        private User crntUser;
        private Database programDatabase;

        public frmContent(Database programDatabase)
        {
            InitializeComponent();
            this.programDatabase = programDatabase;

            dgvStaff.AutoGenerateColumns = true;
            dgvStaff.DataSource = programDatabase.selectDataBinding("SELECT * FROM Staff").bind();
        }     

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!crntUser.canCreate)
            {
                MessageBox.Show("Insufficient Permissions to add a new record", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (tabContent.SelectedTab == tbStaff)
            {
                frmAddStaff frmAddStaff = new frmAddStaff(programDatabase);
                frmAddStaff.ShowDialog();
            }
        }

        public void formClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        public User CurrentUser
        {
            get { return crntUser; }
            set { crntUser = value; }
        }

    }
}
