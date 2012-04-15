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
        BindingSource bisProductListBinding, bisCategoryBoxBinding, bisSupplierBoxBinding;

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
                fillProductDataFields();
            else
            {
                txtProductID.Text = string.Empty;
                txtProductName.Text = string.Empty;
                txtProductRentalFee.Text = string.Empty;
                txtProductCost.Text = string.Empty;

                cboCategory.SelectedIndex = -1;
                cboSupplier.SelectedIndex = -1;

                trvProductStock.Nodes.Clear();
            }
        }

        private void fillProductDataFields()
        {
            //Get the data. IDs are unique so unless something has gone horribly wrong there should only be one row
            DataRow productData = dtbProduct.Select("productID + '' = '" + lstProducts.SelectedValue + "'")[0];

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
                                                stockRow["branchID"]));
            }

        }

        private void txtProductsFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox sndr = (TextBox)sender;
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

    }
}
