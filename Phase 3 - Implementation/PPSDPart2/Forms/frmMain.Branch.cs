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
        DataTable dtbBranch;
        BindingSource bisBranchListBinding;

        private void initialiseBranchData()
        {
            bisBranchListBinding = new BindingSource();

            dtbBranch = mDatabase.selectData("SELECT * FROM Branch");
            bisBranchListBinding.DataSource = dtbBranch;

            lstBranches.DataSource = bisBranchListBinding;

            lstBranches.ValueMember = dtbBranch.Columns[0].ColumnName;
            lstBranches.DisplayMember = dtbBranch.Columns[0].ColumnName;

            //register the event handler method for a new list item being selected manually.
            //if this is done in the designer it doesn't apply the Value and Display member settings early enough and it causes issues
            lstBranches.SelectedValueChanged += lstBranches_SelectedValueChanged;
            txtBranchFilter.TextChanged += txtBranchFilter_TextChanged;

            lstBranches.ClearSelected();
        }

        private void fillBranchDataFields()
        {
            try
            {
                //Get the data. IDs are unique so unless something has gone horribly wrong there should only be one row
                DataRow branchData = dtbBranch.Select("branchID + '' = '" + lstBranches.SelectedValue + "'")[0];                               
                

                txtBranchID.Text = branchData["branchID"].ToString();
                txtBranchAddress.Text = branchData["address"] as string;
                txtBranchTel.Text = branchData["phoneNumber"] as string;
                txtBranchEmail.Text = branchData["email"] as string;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message);
            }

        }

        private void lstBranches_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox sndr = (ListBox)sender;
            if (sndr.SelectedValue != null)
                fillBranchDataFields();
            else
            {
                txtBranchID.Text = string.Empty;
                txtBranchAddress.Text = string.Empty;
                txtBranchTel.Text = string.Empty;
                txtBranchEmail.Text = string.Empty;
            }
        }

        private void txtBranchFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox sndr = (TextBox)sender;
            bisBranchListBinding.Filter = "branchID + '' LIKE '%" + sndr.Text + "%'";
        }
    }
}
