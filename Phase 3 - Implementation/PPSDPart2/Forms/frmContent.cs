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
            
            //Initialise the database table objects
            dtbSupplier = new DatabaseTable();
            dtbStaff = new DatabaseTable();
            dtbProduct = new DatabaseTable();
            dtbRental = new DatabaseTable();

            //Register this forms event handling methods with the database tables objects
            dtbSupplier.DataChanged += updateSupplier;
            dtbStaff.DataChanged += updateStaff;
            dtbProduct.DataChanged += updateProduct;
            dtbRental.DataChanged += updateRental;
            

            //Do the initial data pull (may consider doing this with multiple threads)
            while(blnMsgBoxOpt){
                try
                  {                    
                    programDatabase.runDataSelectQuery("SELECT * FROM Supplier", ref dtbSupplier);
                    programDatabase.runDataSelectQuery("SELECT staffid, branchid, name, role, address, phonenumber, email, username  FROM Staff", ref dtbStaff);
                    programDatabase.runDataSelectQuery("SELECT * FROM Product", ref dtbProduct);
                    programDatabase.runDataSelectQuery("SELECT * FROM Rental", ref dtbRental);
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
                r.CreateCells(dgvStaff);

                for (int j = 0; j < dtbTable.FieldCount; j++)
                {
                    r.Cells[j].Value = dtbTable.Data[dtbTable.FieldNames[j]][i];
                    r.Cells[j].ReadOnly = true;
                }
                dgvView.Rows.Add(r);
            }
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

        public void formClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

    }
}
