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
        BindingSource bisStaffListBinding;

        private void initialiseStaffData()
        {
            bisStaffListBinding = new BindingSource();

            bisStaffListBinding.DataSource = dtbStaff;

            lstStaff.DataSource = bisStaffListBinding;

            lstStaff.ValueMember = dtbStaff.Columns[0].ColumnName;
            lstStaff.DisplayMember = "name";

            //register the event handler method for a new list item being selected manually.
            //if this is done in the designer it doesn't apply the Value and Display member settings early enough and it causes issues
            lstStaff.SelectedValueChanged += lstStaff_SelectedValueChanged;
            txtStaffFilter.TextChanged += txtStaffFilter_TextChanged;

            lstStaff.ClearSelected();
        }

        private void fillStaffDataFields()
        {
            try
            {
                //Get the data. IDs are unique so unless something has gone horribly wrong there should only be one row
                DataRow staffData = dtbStaff.Select("staffID + '' = '" + lstStaff.SelectedValue + "'")[0];

                txtStaffID.Text = staffData["staffID"].ToString();
                txtStaffEmail.Text = staffData["email"].ToString();
                txtStaffName.Text = staffData["name"].ToString();
                txtStaffTel.Text = staffData["phoneNumber"].ToString();                
                txtStaffAddress.Text = staffData["address"].ToString();
                txtStaffUsername.Text = staffData["username"].ToString();
                
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

        private void lstStaff_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox sndr = (ListBox)sender;
            if (sndr.SelectedValue != null)
                fillStaffDataFields();
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
            }
        }

        private void txtStaffFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox sndr = (TextBox)sender;
            bisStaffListBinding.Filter = "name + '' LIKE '%" + sndr.Text + "%'";
        }
    }
}
