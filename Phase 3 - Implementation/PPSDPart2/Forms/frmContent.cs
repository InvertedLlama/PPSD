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
            
            dgvStaff.AutoGenerateColumns = true;            
            dgvStaff.DataSource = dbiStaff.Data;
            //Password shouldn't be visible to anybody regardless of access level so hide it
            dgvStaff.Columns["password"].Visible = false;

            //Set column names
            dgvStaff.Columns["staffID"].HeaderText = "Staff ID";
            dgvStaff.Columns["branchID"].HeaderText = "Branch ID";
            dgvStaff.Columns["role"].HeaderText = "Role";
            dgvStaff.Columns["name"].HeaderText = "Name";
            dgvStaff.Columns["username"].HeaderText = "Username";
            dgvStaff.Columns["address"].HeaderText = "Address";
            dgvStaff.Columns["phoneNumber"].HeaderText = "Tel.";
            dgvStaff.Columns["email"].HeaderText = "E-Mail";


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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbField.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a search field", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataBinding dbiCurrent = null;
            DataGridView dgvCurrent = null;
            string searchQuery = string.Empty;
            string tableName = string.Empty;

            if (tabContent.SelectedTab == tbProduct)
            {
                dgvCurrent = dgvProduct;
                dbiCurrent = dbiProduct;
                tableName = "Product";
            }
            else if (tabContent.SelectedTab == tbRental)
            {
                dgvCurrent = dgvRental;
                dbiCurrent = dbiRental;
                tableName = "Rental";
            }
            else if (tabContent.SelectedTab == tbStaff)
            {
                dgvCurrent = dgvStaff;
                dbiCurrent = dbiStaff;
                tableName = "Staff";
            }
            else if (tabContent.SelectedTab == tbSupplier)
            {
                dgvCurrent = dgvSupplier;
                dbiCurrent = dbiSupplier;
                tableName = "Supplier";
            }
            else
            {
                MessageBox.Show(this, "Programatical error: frmContent.Search.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //If there's no search string then revert to using the full databinding
            if (txtSearch.Text == string.Empty)
            {
                lblSearchMsg.Hide();
                dgvCurrent.DataSource = dbiCurrent.Data;
                return;
            }

            //Select data from the underlying Database that matches the entered text with the search field
            //*WARNING* Don't edit the databinding or you'll delete unselected records.
            if (dgvCurrent.Columns[cmbField.SelectedItem.ToString()].ValueType == typeof(string))                
                searchQuery = string.Format("SELECT * FROM {0} WHERE UPPER({1}) LIKE UPPER(\'%{2}%\')", tableName, cmbField.SelectedItem.ToString(), txtSearch.Text);
            else
                searchQuery = string.Format("SELECT * FROM {0} WHERE {1} = {2}", tableName, cmbField.SelectedItem.ToString(), txtSearch.Text);

            lblSearchMsg.Show();
            dgvCurrent.DataSource = programDatabase.selectData(searchQuery);
        }
    }
}
