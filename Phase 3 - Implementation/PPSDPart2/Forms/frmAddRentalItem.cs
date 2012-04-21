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
    public partial class frmAddRentalItem : Form
    {
        Database mDatabase;
        DataTable dtbStock, dtbProduct;

        int branchID = -1;

        public event ItemAddedHandler ItemAdded;
        public delegate void ItemAddedHandler(object sender, RentalEventArgs e);

        public frmAddRentalItem(Database database, DataTable stock, DataTable product, int branchID)
        {
            InitializeComponent();

            mDatabase = database;

            dtbStock = stock;
            dtbProduct = product;

            numAmount.Enabled = false;
            btnSubmit.Enabled = false;

            cboProduct.DataSource = mDatabase.selectData("SELECT * FROM Product WHERE productID IN (SELECT productID FROM Stock Where branchID = " + branchID + ")");
            cboProduct.ValueMember = "productID";
            cboProduct.DisplayMember = "name";

            this.branchID = branchID;

            cboProduct.SelectedIndexChanged += cboProduct_SelectedIndexChanged;
            cboProduct.SelectedIndex = -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Validate fields
            string message = string.Empty;
            
            if ((int)cboProduct.SelectedValue < 0)
                message += " * Product\n";

            if (numAmount.Value < 1)
                message += " * Amount\n";

            if (message != string.Empty)
            {
                MessageBox.Show(this, "Please verify the following fields:\n" + message, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //Data is valid, notify the event listeners
                if (ItemAdded != null)
                {
                    string selectString = string.Format("productID = {0} AND branchID = {1}",
                        cboProduct.SelectedValue, branchID
                        );
                    int stockID = (int)(dtbStock.Select(selectString)[0]["stockID"]);

                    DataRow productInfo = dtbProduct.Select("productID = " + cboProduct.SelectedValue)[0];
                    for (int i = 0; i < numAmount.Value; i++)
                    {                                                
                        ItemAdded(this, new RentalEventArgs(new RentalItem((int)cboProduct.SelectedValue, stockID, (float)(decimal)productInfo["rentalFee"], productInfo["name"].ToString()))); 
                    }
                    Close();
                }
            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex < 0)
            {
                btnSubmit.Enabled = false;
                numAmount.Enabled = false;
                numAmount.Value = 0;
            }
            else
            {                
                string selectString = string.Format("productID = {0} AND branchID = {1}",
                    cboProduct.SelectedValue, branchID
                    );

                int available = -1;
                try
                {
                    available = (int)dtbStock.Select(selectString)[0]["available"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Failed to find stock item:\n" + ex.Message, "DataTable Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (available > 0)
                {
                    numAmount.Maximum = available;
                    numAmount.Enabled = true;
                }
                else
                    MessageBox.Show(this, "This item is out of stock", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
        }

        private void numAmount_ValueChanged(object sender, EventArgs e)
        {
            if (numAmount.Value > 0)
                btnSubmit.Enabled = true;
            else
                btnSubmit.Enabled = false;
        }




    }
}
