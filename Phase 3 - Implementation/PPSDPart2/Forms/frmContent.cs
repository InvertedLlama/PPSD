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
        private DatabaseTable dtbSupplier, dtbStaff, dtbProduct, dtbRental, dtbSelected;

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
            
            //Initialise the database table objects
            dtbSupplier = new DatabaseTable();
            dtbStaff = new DatabaseTable();
            dtbProduct = new DatabaseTable();
            dtbRental = new DatabaseTable();

            //Register this forms event handling methods with the database table objects
            dtbSupplier.DataChanged += updateSupplier;
            dtbStaff.DataChanged += updateStaff;
            dtbProduct.DataChanged += updateProduct;
            dtbRental.DataChanged += updateRental;
            

            //Do the initial data pull (may consider doing this with multiple threads)
            while(blnMsgBoxOpt){
                try
                  {                    
                    programDatabase.runDataSelectQuery("SELECT * FROM Supplier", ref dtbSupplier);
                    dtbSupplier.TableName = "Supplier";
                    programDatabase.runDataSelectQuery("SELECT staffid, branchid, name, role, address, phonenumber, email, username  FROM Staff", ref dtbStaff);
                    dtbStaff.TableName = "Staff";
                    programDatabase.runDataSelectQuery("SELECT * FROM Product", ref dtbProduct);
                    dtbProduct.TableName = "Product";
                    programDatabase.runDataSelectQuery("SELECT * FROM Rental", ref dtbRental);
                    dtbRental.TableName = "Rental";
                    //Data retrieval was successful, break the loop and continue
                    break;
                  }
                  catch (Exception e)
                  {
                    switch((MessageBox.Show("Critical Error: " + e.Message, "ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error)))
                    {
                        //If the user wants to ignore the error and continue then allow it
                        case System.Windows.Forms.DialogResult.Ignore:
                            blnMsgBoxOpt = false;
                            break;
                        //If the user wants to abort then close the program
                        case System.Windows.Forms.DialogResult.Abort:
                            blnMsgBoxOpt = false;
                            Close();
                            break;
                        case System.Windows.Forms.DialogResult.Retry:
                            blnMsgBoxOpt = true;
                            break;
                        //Should never be reached
                        default:
                            blnMsgBoxOpt = false;
                            break;                        
                    }

                  }
            }
            
            //Populate the search field combobox for the first time. After this it's handled by the tab control selected event            
            switch ((string)tabContent.SelectedTab.Tag)
            {
                case "SUPPLIER_TAB":
                    dtbSelected = dtbSupplier;
                    break;
                case "STAFF_TAB":
                    dtbSelected = dtbStaff;
                    break;
                case "PRODUCT_TAB":
                    dtbSelected = dtbProduct;
                    break;
                case "RENTAL_TAB":
                    dtbSelected = dtbRental;
                    break;
                default:
                    MessageBox.Show("Fatal Error: Unexpected Tab Selection", "Fatal Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    break;
            }
            populateSearchFieldList();
        }

        private void populateSearchFieldList()
        {
            //Select the database table object referring to whichever tab the form is currently on            


            //Populate the list
            cmbField.Items.Clear();
            cmbField.Text = "";
            cmbField.SelectedIndex = -1;
            foreach (string s in dtbSelected.FieldNames)
            {
                cmbField.Items.Add(s);
            }
        }

        /// <summary>
        /// Handles the click event of the search button
        /// When this method is run it will create a query based upon the state of the form
        /// and repopulate the selected tabs dataview with filtered data
        /// </summary>
        /// <param name="sender">object that dispatched the event</param>
        /// <param name="e">event arguments</param>
        private void search(object sender, EventArgs e)
        {
            string searchquery = "";
            string searchstring = txtSearch.Text;

            //Make sure a valid field has been selected
            if (cmbField.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Please select a search field", "Information: Search Field not Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //If the search string is blank then query to select everything from the table
            if (searchstring.Length < 1)
            {
                searchquery = String.Format("SELECT {0} FROM {1}", dtbSelected.FieldsList, dtbSelected.TableName);
                programDatabase.runDataSelectQuery(searchquery, ref dtbSelected);
                return;
            }

            //Disable the controls so the user can't change anything
            txtSearch.Enabled = false;
            btnSearch.Enabled = false;
            cmbField.Enabled = false;

            //Disallow qoutation marks to avoid any issues with string escape characters
            Regex regex = new Regex("['\"]");

            if (regex.IsMatch(searchstring))
            {
                MessageBox.Show(this, "Qoutation marks ('\") are disallowed in the search field", "Warning: Unacceptable Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
                                  
            //If the search field type is a string then use like instead of equals
            if (dtbSelected.Fields[cmbField.SelectedIndex].type.Equals(typeof(string)))
            {
                searchquery =
                    String.Format("SELECT {0} FROM {1} WHERE UPPER({2}) LIKE UPPER(\'%{3}%\')", dtbSelected.FieldsList, dtbSelected.TableName, cmbField.SelectedItem.ToString(), searchstring);
            }
            else
            {
                //Otherwise build the query with mathematical equals
                searchquery =
                    String.Format("SELECT {0} FROM {1} WHERE {2} = {3}", dtbSelected.FieldsList, dtbSelected.TableName, cmbField.SelectedItem.ToString(), searchstring);
            }


            //Run the query and update the table
            programDatabase.runDataSelectQuery(searchquery, ref dtbSelected);



            //Re-enable the controls
            txtSearch.Enabled = true;
            btnSearch.Enabled = true;
            cmbField.Enabled = true;
            
        }

        /// <summary>
        /// Called to populate the supplier datagrid view with data when the supplier table is updated
        /// </summary>
        /// <param name="sender">object that dispatched the event</param>
        /// <param name="e">event arguments</param>
        private void updateSupplier(object sender, EventArgs e)
        {
            updateTable(ref dgvSupplier, ref dtbSupplier);
        }

        /// <summary>
        /// Called to populate the product datagrid view with data when the product table is updated
        /// </summary>
        /// <param name="sender">object that dispatched the event</param>
        /// <param name="e">event arguments</param>
        private void updateProduct(object sender, EventArgs e)
        {
            updateTable(ref dgvProduct, ref dtbProduct);
        }

        /// <summary>
        /// Called to populate the rental datagrid view with data when the rental table is updated
        /// </summary>
        /// <param name="sender">object that dispatched the event</param>
        /// <param name="e">event arguments</param>
        private void updateRental(object sender, EventArgs e)
        {
            updateTable(ref dgvRental, ref dtbRental);
        }

        /// <summary>
        /// Called to populate the staff datagrid view with data when the staff data table is updated
        /// </summary>
        /// <param name="sender">object that instigated the event</param>
        /// <param name="e">event arguments</param>                    
        private void updateStaff(object sender, EventArgs e)
        {
            updateTable(ref dgvStaff, ref dtbStaff);
        }

        private void updateTable(ref DataGridView dgvView, ref DatabaseTable dtbTable)
        {
            //Clear the existing columns
            dgvView.Columns.Clear();

            DataGridViewColumn c;
            //Add the new columns
            foreach (DatabaseTable.Field f in dtbTable.Fields)
            {
                c = new DataGridViewColumn();
                c.Resizable = DataGridViewTriState.True;
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                c.HeaderText = f.name;
                c.ValueType = typeof(string);
                c.Visible = true;
                c.CellTemplate = new DataGridViewTextBoxCell();

                dgvView.Columns.Add(c);
            }

            //Clear existing rows
            dgvView.Rows.Clear();

            DataGridViewRow r;

            //Add the new rows
            for (int i = 0; i < dtbTable.RowCount; i++)
            {
                r = new DataGridViewRow();
                r.Resizable = DataGridViewTriState.True;
                r.CreateCells(dgvView);

                for (int j = 0; j < dtbTable.FieldCount; j++)
                {
                    r.Cells[j].Value = dtbTable.Data[dtbTable.FieldNames[j]][i];
                    r.Cells[j].ReadOnly = true;
                }
                dgvView.Rows.Add(r);
            }
        }


        /// <summary>
        /// Handles the tab selected event (last event in the tab switch chain)
        /// </summary>
        /// <param name="sender">object that dispatched the event</param>
        /// <param name="e">TabControl specialised event arguments</param>
        private void tabSelected(object sender, TabControlEventArgs e)
        {
            switch ((string)tabContent.SelectedTab.Tag)
            {
                case "SUPPLIER_TAB":
                    dtbSelected = dtbSupplier;
                    break;
                case "STAFF_TAB":
                    dtbSelected = dtbStaff;
                    break;
                case "PRODUCT_TAB":
                    dtbSelected = dtbProduct;
                    break;
                case "RENTAL_TAB":
                    dtbSelected = dtbRental;
                    break;
                default:
                    MessageBox.Show("Fatal Error: Unexpected Tab Selection", "Fatal Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    break;
            }
            populateSearchFieldList();
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

    }
}
