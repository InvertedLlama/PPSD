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
        BindingSource bisStaffListBinding, bisStaffBranchBinding;
        DataRow staffData;

        frmAddStaff addStaffDialogue;

        private void initialiseStaffData()
        {
            bisStaffListBinding = new BindingSource();
            bisStaffBranchBinding = new BindingSource();

            bisStaffListBinding.DataSource = dtbStaff;

            lstStaff.DataSource = bisStaffListBinding;

            lstStaff.ValueMember = dtbStaff.Columns[0].ColumnName;
            lstStaff.DisplayMember = "name";

            bisStaffBranchBinding.DataSource = dtbBranch;
            cboStaffBranch.DataSource = bisStaffBranchBinding;
            cboStaffBranch.DisplayMember = "branchID";
            cboStaffBranch.ValueMember = "branchID";

            //register the event handler method for a new list item being selected manually.
            //if this is done in the designer it doesn't apply the Value and Display member settings early enough and it causes issues
            lstStaff.SelectedValueChanged += lstStaff_SelectedValueChanged;
            txtStaffFilter.TextChanged += txtStaffFilter_TextChanged;
            btnNewStaff.Click += btnNewStaff_Click;

            lstStaff.ClearSelected();
        }

        private void fillStaffDataFields()
        {
            try
            {
                //Get the data. IDs are unique so unless something has gone horribly wrong there should only be one row
                staffData = dtbStaff.Select("staffID + '' = '" + lstStaff.SelectedValue + "'")[0];

                txtStaffID.Text = staffData["staffID"].ToString();
                txtStaffEmail.Text = staffData["email"].ToString();
                txtStaffName.Text = staffData["name"].ToString();
                txtStaffTel.Text = staffData["phoneNumber"].ToString();                
                txtStaffAddress.Text = staffData["address"].ToString();
                txtStaffUsername.Text = staffData["username"].ToString();
                cboStaffBranch.SelectedValue = staffData["branchID"];
                
                foreach(string s in cboStaffRole.Items)
                {
                    if (s == staffData["role"].ToString())
                        cboStaffRole.SelectedIndex = cboStaffRole.Items.IndexOf(s);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message);
            }

        }

        private void btnNewStaff_Click(object sender, EventArgs e)
        {
            if (muser.canCreate)
            {
                addStaffDialogue = new frmAddStaff(mDatabase, dtbStaff, dtbBranch);
                addStaffDialogue.RecordAdded += addStaffDialogue_RecordAdded;
                addStaffDialogue.ShowDialog(this);
            }
            else
                MessageBox.Show(this, "Insufficient User Permissions", "Permissions", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void addStaffDialogue_RecordAdded(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Staff member added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            mDatabase.selectData("SELECT * FROM Staff", ref dtbStaff);
            addStaffDialogue.Close();
        }

        private void lstStaff_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox sndr = (ListBox)sender;
            if (sndr.SelectedValue != null)
            {
                fillStaffDataFields();

                //Enable controls that may of been disabled
                btnStaffApply.Enabled = true;
                btnStaffCancel.Enabled = true;
                btnStaffPasswordSet.Enabled = true;
                cboStaffBranch.Enabled = true;
                cboStaffRole.Enabled = true;
            }
            else
            {
                txtStaffID.Text = string.Empty;
                txtStaffName.Text = string.Empty;
                txtStaffAddress.Text = string.Empty;
                txtStaffEmail.Text = string.Empty;
                txtStaffPassword.Text = string.Empty;
                txtStaffTel.Text = string.Empty;
                txtStaffUsername.Text = string.Empty;
                cboStaffBranch.SelectedIndex = -1;
                cboStaffRole.SelectedIndex = -1;

                //Disable any controls that the user shouldn't interact with when no item is selected
                btnStaffApply.Enabled = false;
                btnStaffCancel.Enabled = false;
                btnStaffPasswordSet.Enabled = false;
                cboStaffRole.Enabled = false;
                cboStaffBranch.Enabled = false;
            }
        }

        private void txtStaffFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox sndr = (TextBox)sender;
            sndr.Text = sndr.Text.Replace("'", "");
            bisStaffListBinding.Filter = "name + '' LIKE '%" + sndr.Text + "%'";
        }

        private void btnStaffApply_Click(object sender, EventArgs e)
        {
            if (!muser.canModify)
            {
                MessageBox.Show(this, "Insufficient User Permissions", "Permissions", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string message = string.Empty;
            
            if (!DataValidation.validateInformation(txtStaffName.Text, RegexPattern.NameString))
                    message += "* Name\n";
                        
            if (!DataValidation.validateInformation(txtStaffEmail.Text, RegexPattern.EmailString) && txtStaffEmail.Text != string.Empty)
                    message += "* Email\n";
                        
            if (!DataValidation.validateInformation(txtStaffTel.Text, RegexPattern.PhoneString))
                    message += "* Phone Number\n";

            if (txtStaffAddress.Text == string.Empty)
                message += "* Address\n";

            if (txtStaffUsername.Text == string.Empty)
                message += "* Username\n";

            if (message != string.Empty)
                MessageBox.Show(this, "Please verify the following:\n" + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (MessageBox.Show(this, "Are you sure you want to apply these changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int selectedValue = (int)staffData["staffID"];

                //No errors, push the data to the database
                string insertQuery = string.Format(
                    "UPDATE Staff\n" +
                    "SET name=\"{0}\", address=\"{1}\", phoneNumber=\"{2}\", email=\"{3}\", branchID={4}, role=\"{5}\", username=\"{6}\"\n" +
                    "WHERE staffID = {7}", txtStaffName.Text, txtStaffAddress.Text, txtStaffTel.Text, txtStaffEmail.Text,
                    cboStaffBranch.SelectedValue, cboStaffRole.SelectedItem, txtStaffUsername.Text, staffData["staffID"]);

                if (mDatabase.runCommandQuery(insertQuery))
                {
                    dtbStaff = mDatabase.selectData("SELECT * FROM Staff");
                    bisStaffListBinding.DataSource = dtbStaff;

                    //Restore previous item selection
                    lstStaff.SelectedValue = selectedValue;

                    MessageBox.Show(this, "Changes applied successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(this, "Failed to apply changes", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
                
        }

        private void btnStaffCancel_Click(object sender, EventArgs e)
        {
            fillStaffDataFields();
        }

        private void btnStaffPasswordSet_Click(object sender, EventArgs e)
        {
            if (!txtStaffPassword.Text.Equals(txtStaffRepeatPassword.Text))
            {
                MessageBox.Show(this, "Passwords do not match", "Password mismatch", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtStaffPassword.Text = "";
                txtStaffRepeatPassword.Text = "";
                return;
            }
            if (!muser.canModify)
            {
                MessageBox.Show(this, "Insufficient User Permissions", "Permissions", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show(this, "Are you sure you want to change this users password?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int selectedValue = (int)lstStaff.SelectedValue;

                string insertQuery = String.Format(
                    "UPDATE Staff\n" +
                    "SET password=\"{0}\"\n" +
                    "WHERE staffID = {1}",
                    txtStaffPassword.Text, staffData["staffID"]);
                txtStaffPassword.Text = "";
                txtStaffRepeatPassword.Text = "";
                if (mDatabase.runCommandQuery(insertQuery))
                {
                    mDatabase.selectData("SELECT * FROM Staff", ref dtbStaff);
                    lstStaff.SelectedValue = selectedValue;

                    MessageBox.Show(this, "Changes applied Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(this, "Failed to apply changes", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
    }
}
