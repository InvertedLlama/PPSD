using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace PPSDPart2
{
    public partial class frmMain
    {
        DataRow productData;
        BindingSource bisProductListBinding, bisCategoryBoxBinding, bisSupplierBoxBinding;

        frmAddProduct addProductDialogue;

        public void initialiseProductData()
        {      
            bisProductListBinding = new BindingSource();
            bisCategoryBoxBinding = new BindingSource();
            bisSupplierBoxBinding = new BindingSource();

            bisProductListBinding.DataSource = dtbProduct;

            lstProducts.DataSource = bisProductListBinding;
            lstProducts.ValueMember = dtbProduct.Columns[0].ColumnName;
            lstProducts.DisplayMember = "name";

            lstProducts.ClearSelected();

            bisCategoryBoxBinding.DataSource = dtbCategory;
            cboCategory.DataSource = bisCategoryBoxBinding;
            cboCategory.DisplayMember = "name";
            cboCategory.ValueMember = "categoryID";

            bisSupplierBoxBinding.DataSource = dtbSupplier;
            cboSupplier.DataSource = bisSupplierBoxBinding;
            cboSupplier.DisplayMember = "name";
            cboSupplier.ValueMember = "supplierID";

            //Register event handlers
            lstProducts.SelectedValueChanged += lstProducts_SelectedValueChanged;
            txtProductFilter.TextChanged += txtProductsFilter_TextChanged;
            lblSupplierLink.Click += lblSupplierLink_Click;
            trvProductStock.NodeMouseDoubleClick += trvProductStock_NodeMouseDoubleClick;
        }

        private void lstProducts_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox sndr = (ListBox)sender;
            if (sndr.SelectedValue != null)
            {
                fillProductDataFields();
                btnProductApply.Enabled = true;
                btnProductCancel.Enabled = true;
                cboCategory.Enabled = true;
                cboSupplier.Enabled = true;
            }
            else
            {
                txtProductID.Text = string.Empty;
                txtProductName.Text = string.Empty;
                txtProductRentalFee.Text = string.Empty;
                txtProductCost.Text = string.Empty;

                cboCategory.SelectedIndex = -1;
                cboSupplier.SelectedIndex = -1;
                trvProductStock.Nodes.Clear();

                btnProductApply.Enabled = false;
                btnProductCancel.Enabled = false;
                cboCategory.Enabled = false;
                cboSupplier.Enabled = false;
            }
        }

        private void fillProductDataFields()
        {
            //Get the data. IDs are unique so unless something has gone horribly wrong there should only be one row
            productData = dtbProduct.Select("productID + '' = '" + lstProducts.SelectedValue + "'")[0];

            txtProductID.Text = productData["productID"].ToString();
            txtProductName.Text = productData["name"].ToString();
            txtProductRentalFee.Text = productData["rentalFee"].ToString();
            txtProductCost.Text = productData["cost"].ToString();

            cboSupplier.SelectedValue = productData["supplierID"];
            cboCategory.SelectedValue = productData["categoryID"];

            //Clear the treeview
            trvProductStock.Nodes.Clear();

            //Fill the treeview
            DataRow[] stockData = dtbStock.Select("productID = " + productData["productID"]);
            foreach (DataRow stockRow in stockData)
            {
                trvProductStock.Nodes.Add(new ValueTreeNode(
                                                string.Format("Branch: {0} Amount: {1}", stockRow["branchID"], stockRow["amount"]),
                                                (int)stockRow["branchID"]));
            }

        }

        private void txtProductsFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox sndr = (TextBox)sender;
            sndr.Text = sndr.Text.Replace("'", "");
            bisProductListBinding.Filter = "name + '' LIKE '%" + sndr.Text + "%'";
        }

        private void lblSupplierLink_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedValue != null)
            {
                tbcContent.SelectTab(tpgSupplier);
                lstSuppliers.SelectedValue = cboSupplier.SelectedValue;
            }
        }

        private void trvProductStock_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.GetType() == typeof(ValueTreeNode))
            {
                tbcContent.SelectTab(tpgBranch);
                lstBranches.SelectedValue = ((ValueTreeNode)e.Node).Value;
            }
        }

        private void btnProductApply_Click(object sender, EventArgs e)
        {
            if (!muser.canModify)
            {
                MessageBox.Show(this, "Insufficient User Permissions", "Permissions", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string message = string.Empty;
                                    
            if (!DataValidation.validateInformation(txtProductName.Text, RegexPattern.NameString))
                    message += "* Product Name\n";
                        
            if (!DataValidation.validateInformation(txtProductRentalFee.Text, RegexPattern.PriceString))
                    message += "* Rental Fee\n";
                                   
            if (!DataValidation.validateInformation(txtProductCost.Text, RegexPattern.PriceString))
                    message += "* Cost\n";
            

            if (message != string.Empty)
                MessageBox.Show("Please verify the following fields:\n" + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (MessageBox.Show(this, "Are you sure you want to apply these changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int selectedValue = (int)lstProducts.SelectedValue;
                string insertQuery = String.Format(
                    "UPDATE Product\n" +
                    "SET supplierID=\"{0}\", categoryID=\"{1}\", name=\"{2}\", rentalFee=\"{3}\", cost=\"{4}\"" +
                    "WHERE productID=\"{5}\"", cboSupplier.SelectedValue, cboCategory.SelectedValue,
                    txtProductName.Text, txtProductRentalFee.Text,txtProductCost.Text, txtProductID.Text);

                if (mDatabase.runCommandQuery(insertQuery))
                {
                    //changes applied! Reload data in GUI:
                    mDatabase.selectData("SELECT * FROM Product", ref dtbProduct);
                    
                    lstProducts.SelectedValue = selectedValue;                       
                    
                    MessageBox.Show("Changes applied successfully");
                }
                else
                    MessageBox.Show("Failed to apply changes");
            }
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            if (muser.canCreate)
            {
                addProductDialogue = new frmAddProduct(mDatabase, ref dtbCategory, ref dtbSupplier);
                addProductDialogue.RecordAdded += addProductDialogue_RecordAdded;
                addProductDialogue.Show();
            }
            else
                MessageBox.Show(this, "Insufficient User Permissions", "Permissions", MessageBoxButtons.OK, MessageBoxIcon.Stop);            
        }

        private void addProductDialogue_RecordAdded(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Record added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            mDatabase.selectData("SELECT * FROM Product", ref dtbProduct);
            addProductDialogue.Close();
        }

        private void btnProductCancel_Click(object sender, EventArgs e)
        {
            fillProductDataFields();
        }
    }
}