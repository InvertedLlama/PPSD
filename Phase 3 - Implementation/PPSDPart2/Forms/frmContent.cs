using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PPSDPart2.Objects;

namespace PPSDPart2
{
    public partial class frmContent : Form
    {
        private User crntUser;
        private Database programDatabase;

        public User CurrentUser
        {
            get { return crntUser; }
            set { crntUser = value; }
        }

        public frmContent(Database programDatabase)
        {
            InitializeComponent();
            this.programDatabase = programDatabase;
        }

        public void formClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tabContent.SelectedTab == tbStaff)
            {
                frmAddStaff frmAddStaff = new frmAddStaff(programDatabase);
                frmAddStaff.ShowDialog();
            }
        }
    }
}
