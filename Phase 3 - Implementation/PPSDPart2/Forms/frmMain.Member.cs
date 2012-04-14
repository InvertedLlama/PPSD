using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace PPSDPart2
{
    //Partial section of frmMain for dealing with the Member tab
    public partial class frmMain
    {
        DataTable dtbMember;
        BindingSource bisMemberListBinding;

        private void initialiseMemberData()
        {
            bisMemberListBinding = new BindingSource();

            dtbMember = mDatabase.selectData("SELECT * FROM Member");
            bisMemberListBinding.DataSource = dtbMember;

            lstMembers.DataSource = bisMemberListBinding;
                        
            lstMembers.ValueMember = dtbMember.Columns[0].ColumnName;
            lstMembers.DisplayMember = dtbMember.Columns[0].ColumnName;

            lstMembers.ClearSelected();


            //register the event handler method for a new list item being selected manually.
            //if this is done in the designer it doesn't apply the Value and Display member settings early enough and it causes issues
            lstMembers.SelectedValueChanged += lstMembers_SelectedValueChanged;
        }

        private void fillMemberDataFields()
        {
            try
            {
                //Get the data. MemberIDs are unique so unless something has gone horribly wrong there should only be one row
                DataRow memberData = dtbMember.Select("memberID + '' = '" + lstMembers.SelectedValue + "'")[0];
                                
                txtMemberID.Text = memberData["memberID"].ToString();
                txtMemberEmail.Text = memberData["email"].ToString();
                txtMemberName.Text = memberData["name"].ToString();
                txtMemberTel.Text = memberData["phoneNumber"].ToString();
                txtMemberMob.Text = memberData["mobileNumber"].ToString();
                txtMemberAddress.Text = memberData["address"].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message);
            }
            
        }

        private void lstMembers_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox sndr = (ListBox)sender;
            if(sndr.SelectedValue != null)
                fillMemberDataFields();
        }

        private void txtMembersFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox sndr = (TextBox)sender;
            bisMemberListBinding.Filter = "memberID + '' LIKE '%" + sndr.Text + "%'";    
        }
        
    }

    
}
