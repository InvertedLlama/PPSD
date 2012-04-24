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
    public partial class frmAddStock : Form
    {
        Database mDatabase;
        DataTable dtbStock, dtbProduct;

        public event RecordAddedHandler RecordAdded;
        public delegate void RecordAddedHandler(object sender, EventArgs e);

        int branchID;

        public frmAddStock(Database database, DataTable stock, DataTable product, int branchID)
        {
            InitializeComponent();
            mDatabase = database;
            dtbProduct = product;
            dtbStock = stock;

            this.branchID = branchID;

            cboProduct.DataSource = dtbProduct;
            cboProduct.ValueMember = "productID";
            cboProduct.DisplayMember = "name";

            cboProduct.SelectedIndexChanged += cboProduct_SelectedIndexChanged;
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex < 0)
                btnSubmit.Enabled = false;
        }

        private void numAmount_ValueChanged(object sender, EventArgs e)
        {
            if (numAmount.Value < 1)
                btnSubmit.Enabled = false;
            else
                btnSubmit.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {            
            //Verify data
            string message = string.Empty;
            if ((int)cboProduct.SelectedValue < 1)
                message += " * Product\n";

            if (numAmount.Value < 1)
                message += " * Amount\n";

            if (message != string.Empty)
                MessageBox.Show(this, "please verify the following fields:\n" + message, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {

                //First check to see if this branch already has a stock of this product
                string selectQuery = string.Format("productID = {0} AND branchID = {1}",
                    cboProduct.SelectedValue, branchID
                    );

                string updateAmountQuery = string.Empty;
                string updateAvailableQuery = string.Empty;
                if (dtbStock.Select(selectQuery).Count() > 0)
                {
                    updateAmountQuery = string.Format("UPDATE Stock SET amount = amount + {0} WHERE productID = {1} AND branchID = {2}",
                        numAmount.Value, cboProduct.SelectedValue, branchID
                        );
                    updateAvailableQuery = string.Format("UPDATE Stock SET available = available + {0} WHERE productID = {1} AND branchID = {2}",
                        numAmount.Value, cboProduct.SelectedValue, branchID
                        );
                }
                else
                    updateAmountQuery = string.Format("INSERT INTO Stock (productID, branchID, amount, available)\n" +
                        "VALUES ({0}, {1}, {2}, {3})", cboProduct.SelectedValue, branchID, numAmount.Value, numAmount.Value
                        );



                if (!mDatabase.runCommandQuery(updateAmountQuery))
                    MessageBox.Show(this, "Failed to update stock in database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (!mDatabase.runCommandQuery(updateAvailableQuery))
                        MessageBox.Show(this, "Failed to update stock in database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    //Data was updated successfully. Notify the event listeners
                    if (RecordAdded != null)
                        RecordAdded(this, EventArgs.Empty);
                }
                
            }
        }
    }
}
