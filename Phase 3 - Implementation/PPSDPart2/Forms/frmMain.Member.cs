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
        DataTable dtbMembers;
        BindingSource bisMemberListBinding;

        private void initialiseMemberData()
        {
            bisMemberListBinding = new BindingSource();

            dtbMembers = mDatabase.selectData("SELECT * FROM Member");
            bisMemberListBinding.DataSource = dtbMembers;

            lstMembers.DataSource = bisMemberListBinding;
                        
            lstMembers.ValueMember = dtbMembers.Columns[0].ColumnName;
            lstMembers.DisplayMember = dtbMembers.Columns[0].ColumnName;

            lstMembers.ClearSelected();


            //register the event handler method for a new list item being selected manually.
            //if this is done in the designer it doesn't apply the Value and Display member settings early enough and it causes issues
            lstMembers.SelectedIndexChanged += lstMembers_SelectedIndexChanged;
        }

        private void fillMemberDataFields()
        {
            try
            {
                string temp = "memberID + '' = '" + lstMembers.SelectedValue + "'";
                //Get the data. MemberIDs are unique so unless something has gone horribly wrong there should only be one row
                DataRow memberData = dtbMembers.Select(temp)[0];
                                
                txtMemberID.Text = memberData["memberID"] + "";
                txtMemberEmail.Text = memberData["email"] + "";
                txtMemberName.Text = memberData["name"] + "";
                txtMemberTel.Text = memberData["phoneNumber"] + "";
                txtMemberMob.Text = memberData["mobileNumber"] + "";
                txtMemberAddress.Text = memberData["address"] + "";
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message);
            }
            
        }

        private void lstMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstMembers.SelectedIndex > -1)
                fillMemberDataFields();
        }

        private void txtMembersFilter_TextChanged(object sender, EventArgs e)
        {
            bisMemberListBinding.Filter = "memberID + '' LIKE '%" + txtMembersFilter.Text + "%'";    
        }
        
    }

    
}
