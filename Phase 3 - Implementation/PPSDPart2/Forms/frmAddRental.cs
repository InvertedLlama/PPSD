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
    public partial class frmAddRental : Form
    {
        Database mDatabase;
        DataTable dtbProduct, dtbStock, dtbBranch;

        frmAddRentalItem addItemDialogue;

        List<RentalItem> items;

        float total = 0.0f;
        int memberID = -1;

        public event RecordAddedHandler RecordAdded;
        public delegate void RecordAddedHandler(object sender, EventArgs e);

        public frmAddRental(Database database, DataTable product, DataTable stock, DataTable branch, int memberID)
        {
            InitializeComponent();
            mDatabase = database;
            dtbProduct = product;
            dtbBranch = branch;
            dtbStock = stock;
            this.memberID = memberID;

            items = new List<RentalItem>();
            dtpReturnDate.Value = DateTime.Today.AddDays(1);

            txtTotal.Text = "£0.00";
                        
            cboBranch.DataSource = dtbBranch;
            cboBranch.DisplayMember = "branchID";
            cboBranch.ValueMember = "branchID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addItemDialogue = new frmAddRentalItem(mDatabase, dtbStock, dtbProduct, (int)cboBranch.SelectedValue);
            addItemDialogue.ItemAdded += addItemDialogue_ItemAdded;
            addItemDialogue.ShowDialog(this);
        }

        private void addItemDialogue_ItemAdded(object sender, RentalEventArgs e)
        {
            items.Add(e.Item);
            total += e.Item.cost;
            txtTotal.Text = total.ToString("C");

            lstItems.Items.Add(string.Format("Item: {0}, Cost: {1}",
                e.Item.name, e.Item.cost.ToString("C")
                ));

            btnSubmit.Enabled = true;
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedIndex < 0)
            {
                btnRemove.Enabled = false;
            }
            else
            {
                btnRemove.Enabled = true;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index = lstItems.SelectedIndex;

            lstItems.Items.RemoveAt(index);

            total -= items[index].cost;
            txtTotal.Text = total.ToString("C");

            items.RemoveAt(index);

            if (items.Count < 1)
                btnSubmit.Enabled = false;
        }

        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpReturnDate.Value < DateTime.Today.AddDays(1))
            {
                MessageBox.Show(this, "Return date must be in the future", "Invalid Return Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpReturnDate.Value = DateTime.Today.AddDays(1);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Validate the data
            string message = string.Empty;
            
            if (items.Count < 1)
                message += " * No items have been added to this rental\n";

            if (dtpReturnDate.Value < DateTime.Today.AddDays(1))
                message += " * Return date may not be in the past";

            if (message != string.Empty)
                MessageBox.Show(this, "Please verify the following fields:\n" + message, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                //Data is valid push it to the database

                //First add the rental
                string insertQuery = string.Format("INSERT INTO Rental (memberID, branchID, rentalDate, returnDate, totalCost)\n" +
                    "VALUES ({0}, {1}, \"{2}\", \"{3}\", {4})",
                    memberID, cboBranch.SelectedValue, DateTime.Today.ToString("yyyy-MM-dd"), dtpReturnDate.Value.ToString("yyyy-MM-dd"), total
                    );

                int rentalID = mDatabase.insertRecord(insertQuery);

                if (rentalID < 0)                
                    MessageBox.Show(this, "Failed to add rental to database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                else
                {
                    //Add the items
                    insertQuery = "INSERT INTO RentalItem (rentalID, stockID, cost)\n VALUES";

                    //Keep track of the amount of each item being rented for decrementing from the available stock later
                    Dictionary<int, int> amounts = new Dictionary<int,int>();
                    foreach (RentalItem item in items)
                    {
                        if (amounts.ContainsKey(item.stockID))
                            amounts[item.stockID]++;
                        else
                            amounts.Add(item.stockID, 1);
                            

                        insertQuery += string.Format("({0}, {1}, {2}),\n", rentalID, item.stockID, item.cost); 
                    }
                    
                    //Trim the line break and comma from the end of the last item
                    insertQuery = insertQuery.Substring(0, insertQuery.Length - 2);

                    if (mDatabase.runCommandQuery(insertQuery))
                    {                        
                        //Decrement the available stock
                        insertQuery = string.Empty;
                        foreach (KeyValuePair<int, int> i in amounts)
                        {
                            insertQuery += string.Format("UPDATE Stock SET available=available-{0} WHERE stockID = {1};",
                                i.Value, i.Key
                                );                            
                        }
                        mDatabase.runCommandQuery(insertQuery);

                        if (RecordAdded != null)
                            RecordAdded(this, EventArgs.Empty);                                                
                    }
                    else
                        MessageBox.Show(this, "Failed to add rental items to database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }

        private void cboBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBranch.SelectedIndex < 0)
            {
                btnSubmit.Enabled = false;
                btnAdd.Enabled = false;
            }
            else
                btnAdd.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
