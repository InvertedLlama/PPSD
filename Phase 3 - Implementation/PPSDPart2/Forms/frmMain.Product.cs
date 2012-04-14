﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace PPSDPart2
{
    public partial class frmMain
    {
        DataTable dtbProduct, dtbCategory;
        BindingSource bisProductListBinding, bisCategoryBoxBinding;

        public void initaliseProductData()
        {
            bisProductListBinding = new BindingSource();
            bisCategoryBoxBinding = new BindingSource();

            dtbProduct = mDatabase.selectData("SELECT * FROM Product");
            bisProductListBinding.DataSource = dtbProduct;


            lstProducts.DataSource = bisProductListBinding;
            lstProducts.ValueMember = dtbProduct.Columns[0].ColumnName;
            lstProducts.DisplayMember = dtbProduct.Columns[0].ColumnName;

            lstProducts.ClearSelected();

            lstProducts.SelectedValueChanged += lstProducts_SelectedValueChanged;
            txtProductFilter.TextChanged += txtProductsFilter_TextChanged;


            dtbCategory = mDatabase.selectData("SELECT * FROM Category");
            bisCategoryBoxBinding.DataSource = dtbCategory;
            cboCategory.DataSource = bisCategoryBoxBinding;
            cboCategory.DisplayMember = "name";
            cboCategory.ValueMember = "categoryID";
        }

        private void lstProducts_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox sndr = (ListBox)sender;
            if (sndr.SelectedValue != null)
                fillProductDataFields();
        }

        private void fillProductDataFields()
        {
            //Get the data. MemberIDs are unique so unless something has gone horribly wrong there should only be one row
            DataRow productData = dtbProduct.Select("productID + '' = '" + lstProducts.SelectedValue + "'")[0];

            txtProductID.Text = productData["productID"].ToString();

            for (int i = 0; i < cboCategory.Items.Count; i++)
            {
                DataRowView r = (DataRowView)cboCategory.Items[i];

                if (r["categoryID"].ToString() == productData["categoryID"].ToString())
                {
                    cboCategory.SelectedIndex = i;
                }
            }

            txtProductName.Text = productData["name"].ToString();
            txtProductRentalFee.Text = productData["rentalFee"].ToString();
        }

        private void txtProductsFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox sndr = (TextBox)sender;
            bisProductListBinding.Filter = "productID + '' LIKE '%" + sndr.Text + "%'";
        }
    }
}
