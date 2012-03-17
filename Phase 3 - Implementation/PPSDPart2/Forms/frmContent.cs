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

        public frmContent(Database programDatabase)
        {
            InitializeComponent();
            this.programDatabase = programDatabase;
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

        private void frmContent_Load(object sender, EventArgs e)
        {
            MessageBox.Show(this, CurrentUser.AccessLevel.ToString());
        }
    }
}
