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
    public partial class frmMain : Form
    {
        Database mDatabase;
        User muser;

        public frmMain(Database programDatabase, User currentuser)
        {
            InitializeComponent();
            this.mDatabase = programDatabase;
            this.muser = currentuser;

            //Prepare the tabs
            initialiseMemberData();
            initaliseProductData();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();

            //Sometimes the controls weren't drawing when the login form came back up
            //this should fix it            
            Owner.Refresh();
        }

    }
}
