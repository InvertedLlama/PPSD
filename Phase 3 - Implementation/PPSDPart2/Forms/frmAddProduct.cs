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
    public partial class frmAddProduct : Form
    {
        Database mDatabase;
        DataTable dtbCategory, dtbSupplier;

        public event RecordAddedHandler RecordAdded;
        public delegate void RecordAddedHandler(object sender, EventArgs e);

        public frmAddProduct(Database database, ref DataTable categoryTable, ref DataTable supplierTable)
        {
            InitializeComponent();
            mDatabase = database;
            dtbCategory = categoryTable;
            dtbSupplier = supplierTable;

            cboCategory.DataSource = dtbCategory;
            cboCategory.DisplayMember = "name";
            cboCategory.ValueMember = "categoryID";

            cboSupplier.DataSource = dtbSupplier;
            cboSupplier.DisplayMember = "name";
            cboSupplier.ValueMember = "supplierID";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Validate data
            string message = string.Empty;
            if(!DataValidation.validateInformation(txtName.Text, RegexPattern.NameString))
                message += " * Name \n";

            if(!DataValidation.validateInformation(txtCost.Text, RegexPattern.PriceString))
                message += " * Cost \n";

            if(!DataValidation.validateInformation(txtRentalFee.Text, RegexPattern.PriceString))
                message += " * Rental Fee \n";

            if (cboCategory.SelectedIndex < 0 && cboCategory.Text == string.Empty)
                message += " * Category \n";

            if (message != string.Empty)
                MessageBox.Show(this, "Please validate the following fields:\n" + message, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                string insertQuery = string.Empty;
                int categoryID = -1;
                string categoryText = cboCategory.Text;
                
                //If the user has entered a new category instead of selecting an existing one then update the category table
                if (cboCategory.SelectedIndex < 0)
                {
                    insertQuery = string.Format(
                        "INSERT INTO Category (name)\n" +
                        "VALUES (\"{0}\")",
                        cboCategory.Text
                        );

                    if (!mDatabase.runCommandQuery(insertQuery))
                    {
                        MessageBox.Show(this, "Failed to add new category to database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    mDatabase.selectData("SELECT * FROM Category", ref dtbCategory);
                    categoryID = (int)mDatabase.selectData("SELECT categoryID FROM Category WHERE name = \"" + categoryText + "\"").Rows[0][0];
                }
                else
                {
                    categoryID = (int)cboCategory.SelectedValue;
                }

                insertQuery = string.Format(
                    "INSERT INTO Product (categoryID, supplierID, name, cost, rentalFee)\n" +
                    "VALUES ({0}, {1}, \"{2}\", {3}, {4})",
                    categoryID, cboSupplier.SelectedValue, txtName.Text, txtCost.Text, txtRentalFee.Text
                    );

                if (mDatabase.runCommandQuery(insertQuery))
                {
                    if (RecordAdded != null)
                        RecordAdded(this, EventArgs.Empty);
                }
                else
                    MessageBox.Show(this, "Failed to add record to database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
