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
        DataRow branchData;
        BindingSource bisBranchListBinding;

        frmAddBranch addBranchDialogue;
        frmAddStock addStockDialogue;

        private void initialiseBranchData()
        {
            bisBranchListBinding = new BindingSource();

            bisBranchListBinding.DataSource = dtbBranch;

            lstBranches.DataSource = bisBranchListBinding;

            lstBranches.ValueMember = dtbBranch.Columns[0].ColumnName;
            lstBranches.DisplayMember = dtbBranch.Columns[0].ColumnName;

            //register the event handler method for a new list item being selected manually.
            //if this is done in the designer it doesn't apply the Value and Display member settings early enough and it causes issues
            lstBranches.SelectedValueChanged += lstBranches_SelectedValueChanged;
            txtBranchFilter.TextChanged += txtBranchFilter_TextChanged;
            trvBranchProducts.NodeMouseDoubleClick += trvBranchProducts_NodeMouseDoubleClick;

            lstBranches.ClearSelected();
        }

        private void fillBranchDataFields()
        {
            try
            {
                //Get the data. IDs are unique so unless something has gone horribly wrong there should only be one row
                branchData = dtbBranch.Select("branchID + '' = '" + lstBranches.SelectedValue + "'")[0];               
                txtBranchID.Text = branchData["branchID"].ToString();
                txtBranchAddress.Text = branchData["address"] as string;
                txtBranchTel.Text = branchData["phoneNumber"] as string;
                txtBranchEmail.Text = branchData["email"] as string;

                trvBranchProducts.Nodes.Clear();

                DataRow[] branchStock = dtbStock.Select("branchID = " + branchData["branchID"]);
                DataRow productInformation;                
                foreach (DataRow stockItem in branchStock)
                {
                    productInformation = dtbProduct.Select("productID = " + stockItem["productID"])[0];
                    trvBranchProducts.Nodes.Add(new ValueTreeNode(string.Format("Product: {0}, Amount: {1} | Available: {2}", productInformation["name"], stockItem["amount"], stockItem["available"]),
                                                                (int)productInformation["productID"]));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message);
            }

        }

        private void btnNewBranch_Click(object sender, EventArgs e)
        {
            if (muser.canCreate)
            {
                addBranchDialogue = new frmAddBranch(mDatabase);
                addBranchDialogue.RecordAdded += addBranchDialogue_RecordAdded;
                addBranchDialogue.ShowDialog(this);
            }
            else
                MessageBox.Show(this, "Insufficient User Permissions", "Permissions", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void addBranchDialogue_RecordAdded(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Branch added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            mDatabase.selectData("SELECT * FROM Branch", ref dtbBranch);
            addBranchDialogue.Close();
        }

        private void lstBranches_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox sndr = (ListBox)sender;
            if (sndr.SelectedValue != null)
            {
                fillBranchDataFields();
                btnBranchApply.Enabled = true;
                btnBranchCancel.Enabled = true;
                btnAddStock.Enabled = true;
            }
            else
            {
                txtBranchID.Text = string.Empty;
                txtBranchAddress.Text = string.Empty;
                txtBranchTel.Text = string.Empty;
                txtBranchEmail.Text = string.Empty;
                trvBranchProducts.Nodes.Clear();

                btnBranchApply.Enabled = false;
                btnBranchCancel.Enabled = false;
                btnAddStock.Enabled = false;
            }
        }

        private void txtBranchFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox sndr = (TextBox)sender;
            sndr.Text=sndr.Text.Replace("'", "");
            bisBranchListBinding.Filter = "branchID + '' LIKE '%" + sndr.Text + "%'";
        }

        private void btnBranchApply_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if (!muser.canModify)
            {
                MessageBox.Show(this, "Insufficient User Permissions", "Permissions", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
                        
            if (!DataValidation.validateInformation(txtBranchEmail.Text, RegexPattern.EmailString) && txtBranchEmail.Text != string.Empty)
                    message += "* Email\n";            
                        
            if (!DataValidation.validateInformation(txtBranchTel.Text, RegexPattern.PhoneString))
                    message += "* Telephone Number\n";

            if (txtBranchAddress.Text == string.Empty)
                message += "* Address\n";

            if (message != string.Empty)
                MessageBox.Show("Please verify the following:\n" + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (MessageBox.Show(this, "Are you sure you want to apply these changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int selectedValue = (int)lstBranches.SelectedValue;

                string insertQuery = String.Format(
                    "UPDATE Branch\n"+
                    "SET address=\"{0}\", email=\"{1}\", phoneNumber=\"{2}\""+
                    "WHERE branchID=\"{3}\"", txtBranchAddress.Text, txtBranchEmail.Text, txtBranchTel.Text, txtBranchID.Text);

                if (mDatabase.runCommandQuery(insertQuery))
                {
                    //changes applied! Reload data in GUI:
                    mDatabase.selectData("SELECT * FROM Branch", ref dtbBranch);

                    lstBranches.SelectedValue = selectedValue;
                    MessageBox.Show(this,"Changes applied successfully");
                }
                else
                    MessageBox.Show(this,"Failed to apply changes");
            }
        }

        private void btnBranchCancel_Click(object sender, EventArgs e)
        {
            fillBranchDataFields();
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            if (muser.canCreate)
            {
                addStockDialogue = new frmAddStock(mDatabase, dtbStock, dtbProduct, (int)lstBranches.SelectedValue);
                addStockDialogue.RecordAdded += addStockDialogue_RecordAdded;
                addStockDialogue.ShowDialog(this);
            }
            else
                MessageBox.Show(this, "Insufficient User Permissions", "Permissions", MessageBoxButtons.OK, MessageBoxIcon.Stop);            
        }

        private void addStockDialogue_RecordAdded(object sender, EventArgs e)
        {
            mDatabase.selectData("SELECT * FROM Stock", ref dtbStock);
            MessageBox.Show(this, "Stock added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            addStockDialogue.Close();

            fillBranchDataFields();
        }

        private void trvBranchProducts_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.GetType() == typeof(ValueTreeNode))
            {
                tbcContent.SelectedTab = tpgProduct;
                lstProducts.SelectedValue = ((ValueTreeNode)e.Node).Value;
            }
        }
    }
}
