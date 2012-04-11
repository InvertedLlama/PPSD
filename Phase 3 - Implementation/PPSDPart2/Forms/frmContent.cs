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
        private DatabaseTable dtbSupplier, dtbStaff, dtbProduct, dtbRental;

        public User CurrentUser
        {
            get { return crntUser; }
            set { crntUser = value; }
        }

        public frmContent(Database programDatabase)
        {
            bool blnMsgBoxOpt = true;

            InitializeComponent();
            this.programDatabase = programDatabase;
            
            //Do the initial data pull (may consider doing this with multiple threads)
            while(blnMsgBoxOpt){
                try
                {
                    dtbSupplier = programDatabase.runDataSelectQuery("SELECT * FROM Supplier");
                    dtbStaff = programDatabase.runDataSelectQuery("SELECT * FROM Staff");
                    dtbProduct = programDatabase.runDataSelectQuery("SELECT * FROM Product");
                    dtbRental = programDatabase.runDataSelectQuery("SELECT * FROM Rental");
                    //Data retrieval was successful, break the loop and continue
                    break;
                }
                catch
                {
                    switch((MessageBox.Show("Critical Error: Failed to get data from database", "ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error)))
                    {
                        //If the user wants to ignore the error and continue then allow it
                        case System.Windows.Forms.DialogResult.Ignore:
                            blnMsgBoxOpt = false;
                            break;
                        //If the user wants to abort then close the program
                        case System.Windows.Forms.DialogResult.Abort:
                            Application.Exit();
                            break;

                        //Only other possible option is retry. So just let the loop continue
                    }
                }
            }
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

    }
}
