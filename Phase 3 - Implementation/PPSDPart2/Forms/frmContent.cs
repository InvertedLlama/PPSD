using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using MySql.Data.MySqlClient;

namespace PPSDPart2
{
    public partial class frmContent : Form
    {
        private User crntUser;
        private Database programDatabase;
        private DataBinding dbiStaff, dbiProduct, dbiRental, dbiSupplier;

        public frmContent(Database programDatabase, User currentUser)
        {            
            InitializeComponent();
            crntUser = currentUser;
            this.programDatabase = programDatabase;                        
                       
            dbiStaff = programDatabase.selectDataBinding("SELECT * FROM Staff");                        
            dbiProduct = programDatabase.selectDataBinding("SELECT * FROM Product");
            dbiRental = programDatabase.selectDataBinding("SELECT * FROM Rental");
            dbiSupplier = programDatabase.selectDataBinding("SELECT * FROM Supplier");

            dbiStaff.Adapater.InsertCommand.CommandText += "; SELECT staffID FROM Staff WHERE staffID = LAST_INSERT_ID();";
            

            //Password shouldn't be visible to anybody regardless of access level so hide it
            dgvStaff.AutoGenerateColumns = true;            
            dgvStaff.DataSource = dbiStaff.Data;
            dgvStaff.Columns["password"].Visible = false;

            dgvRental.AutoGenerateColumns = true;
            dgvRental.DataSource = dbiRental.Data;

            dgvProduct.AutoGenerateColumns = true;
            dgvProduct.DataSource = dbiProduct.Data;

            dgvSupplier.AutoGenerateColumns = true;
            dgvSupplier.DataSource = dbiSupplier.Data;
        }

        private DataTable getCurrentData()
        {
            if (tabContent.SelectedTab == tbProduct)
                return dbiProduct.Data;
            else if (tabContent.SelectedTab == tbRental)
                return dbiRental.Data;
            else if (tabContent.SelectedTab == tbStaff)
                return dbiStaff.Data;
            else if (tabContent.SelectedTab == tbSupplier)
                return dbiSupplier.Data;

            return null;
        }

        private void populateSearchFields()
        {
            DataTable temp = getCurrentData();
            if (temp == null)
            {
                MessageBox.Show(this, "Error: Invalid Tab Selection", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cmbField.Items.Clear();
            foreach(DataColumn c in temp.Columns)
            {
                cmbField.Items.Add(c.ColumnName);
            }
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
                frmAddStaff frmAddStaff = new frmAddStaff(programDatabase, dbiStaff);
                frmAddStaff.ShowDialog();
            }
        }

        private void frmContentLoad(object sender, EventArgs e)
        {
            //Populate the search field combo box for the first time
            populateSearchFields();
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

        private void tabContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateSearchFields();
        }
    }
}
