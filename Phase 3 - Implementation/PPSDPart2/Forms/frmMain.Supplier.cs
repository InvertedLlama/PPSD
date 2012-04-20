using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace PPSDPart2
{
    public partial class frmMain
    {        
        BindingSource bisSupplierListBinding;
        DataRow supplierData;

        private void initialiseSupplierData()
        {
            bisSupplierListBinding = new BindingSource();
            bisSupplierListBinding.DataSource = dtbSupplier;

            lstSuppliers.DataSource = bisSupplierListBinding;

            lstSuppliers.ValueMember = dtbSupplier.Columns[0].ColumnName;
            lstSuppliers.DisplayMember = "name";

            lstSuppliers.ClearSelected();


            //register the event handler method for a new list item being selected manually.
            //if this is done in the designer it doesn't apply the Value and Display member settings early enough and it causes issues
            lstSuppliers.SelectedValueChanged += lstSuppliers_SelectedValueChanged;
            txtSupplierFilter.TextChanged += txtSupplierFilter_TextChanged;
            trvSupplierProducts.NodeMouseDoubleClick += trvSupplierProducts_NodeMouseDoubleClick;
        }

        private void fillSupplierDataFields()
        {
            try
            {
                //Get the data. IDs are unique so unless something has gone horribly wrong there should only be one row
                supplierData = dtbSupplier.Select("supplierID + '' = '" + lstSuppliers.SelectedValue + "'")[0];

                txtSupplierID.Text = supplierData["supplierID"].ToString();
                txtSupplierEmail.Text = supplierData["email"].ToString();
                txtSupplierName.Text = supplierData["name"].ToString();
                txtSupplierTel.Text = supplierData["phoneNumber"].ToString();                
                txtSupplierAddress.Text = supplierData["address"].ToString();

                trvSupplierProducts.Nodes.Clear();

                DataRow[] supplierProducts = dtbProduct.Select("supplierID = " + supplierData["supplierID"]);
                foreach (DataRow supplierProduct in supplierProducts)
                {
                    trvSupplierProducts.Nodes.Add(new ValueTreeNode(string.Format("Name: {0} Cost: {1}", supplierProduct["name"], supplierProduct["cost"]),
                                                                    supplierProduct["productID"])
                                                 );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message);
            }

        }

        private void lstSuppliers_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox sndr = (ListBox)sender;
            if (sndr.SelectedValue != null)
            {
                fillSupplierDataFields();
                btnSupplierApply.Enabled = true;
                btnSupplierCancel.Enabled = true;
            }
            else
            {
                txtSupplierID.Text = string.Empty;
                txtSupplierEmail.Text = string.Empty;
                txtSupplierName.Text = string.Empty;
                txtSupplierTel.Text = string.Empty;
                txtSupplierAddress.Text = string.Empty;
                trvSupplierProducts.Nodes.Clear();
                btnSupplierApply.Enabled = false;
                btnSupplierCancel.Enabled = false;
            }
        }

        private void txtSupplierFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox sndr = (TextBox)sender;
            bisSupplierListBinding.Filter = "name + '' LIKE '%" + sndr.Text + "%'";
        }

        private void trvSupplierProducts_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.GetType() == typeof(ValueTreeNode))
            {
                tbcContent.SelectedTab = tpgProduct;
                lstProducts.SelectedValue = ((ValueTreeNode)e.Node).Value;
            }
        }

        private void btnSupplierApply_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if(txtSupplierName.Text != supplierData["name"].ToString())
                if (!DataValidation.validateInformation(txtSupplierName.Text, RegexPattern.NameString))
                    message += "* Name\n";

            if (txtSupplierEmail.Text != supplierData["email"].ToString() && txtSupplierEmail.Text != string.Empty)
                if (!DataValidation.validateInformation(txtSupplierEmail.Text, RegexPattern.EmailString))
                    message += "* Email\n";

            if (txtSupplierTel.Text != supplierData["phoneNumber"].ToString())
                if (!DataValidation.validateInformation(txtSupplierTel.Text, RegexPattern.PhoneString))
                    message += "* Phone\n";

            if(txtSupplierAddress.Text == string.Empty)
                message += "* Address\n";

            if(message != string.Empty)
                MessageBox.Show(this, "Please verify the following:\n" + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (MessageBox.Show(this, "Are you sure you want to apply these changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //No errors so push the data to the database
                
                //Store the current listbox value for restoring after data refresh
                int selectedValue = (int)lstSuppliers.SelectedValue;

                string selectQuery = string.Format(
                    "UPDATE Supplier\n" +
                    "SET name=\"{0}\", address=\"{1}\", email=\"{2}\", phoneNumber=\"{3}\"\n" +
                    "WHERE supplierID = {4}", txtSupplierName.Text, txtSupplierAddress.Text, txtSupplierEmail.Text,
                    txtSupplierTel.Text, supplierData["supplierID"]);

                if(mDatabase.runCommandQuery(selectQuery))
                {
                    mDatabase.selectData("SELECT * FROM Supplier", ref dtbSupplier);
                    lstSuppliers.SelectedValue = selectedValue;

                    MessageBox.Show(this,"Changes applied successfully");
                }
                else
                    MessageBox.Show(this,"Failed to apply changes");

            }
            
        }

        private void btnSupplierCancel_Click(object sender, EventArgs e)
        {
            fillSupplierDataFields();
        }
    }
}
