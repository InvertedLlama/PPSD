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
        DataTable dtbStaff;
        BindingSource bisStaffListBinding;

        private void initialiseStaffData()
        {
            bisStaffListBinding = new BindingSource();

            dtbStaff = mDatabase.selectData("SELECT * FROM Staff");
            bisStaffListBinding.DataSource = dtbStaff;

            lstStaff.DataSource = bisStaffListBinding;

            lstStaff.ValueMember = dtbStaff.Columns[0].ColumnName;
            lstStaff.DisplayMember = dtbStaff.Columns[0].ColumnName;

            //register the event handler method for a new list item being selected manually.
            //if this is done in the designer it doesn't apply the Value and Display member settings early enough and it causes issues
            lstStaff.SelectedValueChanged += lstStaff_SelectedValueChanged;

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
        }

        private void txtStaffFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox sndr = (TextBox)sender;
            bisStaffListBinding.Filter = "staffID + '' LIKE '%" + sndr.Text + "%'";
        }
    }
}
