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
        DataRow memberData;
        BindingSource bisMemberListBinding;
        frmAddMember addMemberDialogue;

        private void initialiseMemberData()
        {            
            bisMemberListBinding = new BindingSource();

            bisMemberListBinding.DataSource = dtbMember;

            lstMembers.DataSource = bisMemberListBinding;

            lstMembers.ValueMember = "memberID";
            lstMembers.DisplayMember = "name";

            lstMembers.ClearSelected();

            //register the event handler method for a new list item being selected manually.
            //if this is done in the designer it doesn't apply the Value and Display member settings early enough and it causes issues
            lstMembers.SelectedValueChanged += lstMember_SelectedValueChanged;
            txtMembersFilter.TextChanged += txtMembersFilter_TextChanged;
            trvMemberRentals.NodeMouseDoubleClick += trvMemberRentals_NodeMouseDoubleClick;
        }

        private void fillMemberDataFields()
        {
            try
            {
                //Get the data. MemberIDs are unique so unless something has gone horribly wrong there should only be one row
                memberData = dtbMember.Select("memberID + '' = '" + lstMembers.SelectedValue + "'")[0];
                                
                txtMemberID.Text = memberData["memberID"].ToString();
                txtMemberEmail.Text = memberData["email"].ToString();
                txtMemberName.Text = memberData["name"].ToString();
                txtMemberTel.Text = memberData["phoneNumber"].ToString();
                txtMemberMob.Text = memberData["mobileNumber"].ToString();
                txtMemberAddress.Text = memberData["address"].ToString();

                DataRow[] memberRentals = dtbRental.Select("memberID = " + memberData["memberID"]);
                DataRow[] rentalItems;
                DataRow productInfo;
                TreeNode crntNode;

                //Clear out the tree view before adding new values
                trvMemberRentals.Nodes.Clear();

                foreach (DataRow rental in memberRentals)
                {                    
                    crntNode = new TreeNode(string.Format("Rental: {0}, Cost: £{1}, Return: {2}", rental["rentalID"], rental["totalCost"], ((bool)rental["returned"] ? "Complete" : ((DateTime)rental["returnDate"]).ToShortDateString())));
                    rentalItems = dtbRentalItem.Select("rentalID = " + rental["rentalID"]);

                    foreach (DataRow rentalItem in rentalItems)
                    {
                        productInfo = dtbProduct.Select("productID = " + rentalItem["productID"])[0];
                        crntNode.Nodes.Add(new ValueTreeNode(string.Format("Item: {0}, Cost: £{1}",
                            productInfo["name"], rentalItem["cost"]),
                            productInfo["productID"]));
                    }

                    trvMemberRentals.Nodes.Add(crntNode);
                }  
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message);
            }
            
        }

        private void addMemberDialogue_RecordAdded(object sender, EventArgs e)
        {
            addMemberDialogue.Close();
            mDatabase.selectData("SELECT * FROM Member", ref dtbMember);            
            MessageBox.Show(this, "Record added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lstMember_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox sndr = (ListBox)sender;
            if (sndr.SelectedValue != null)
            {
                fillMemberDataFields();
                btnMemberApply.Enabled = true;
                btnMemberCancel.Enabled = true;
            }
            else
            {
                txtMemberID.Text = string.Empty;
                txtMemberEmail.Text = string.Empty;
                txtMemberName.Text = string.Empty;
                txtMemberTel.Text = string.Empty;
                txtMemberMob.Text = string.Empty;
                txtMemberAddress.Text = string.Empty;
                trvMemberRentals.Nodes.Clear();
                btnMemberApply.Enabled = false;
                btnMemberCancel.Enabled = false;
            }
        }

        private void txtMembersFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox sndr = (TextBox)sender;
            bisMemberListBinding.Filter = "name + '' LIKE '%" + sndr.Text + "%'";    
        }

        private void trvMemberRentals_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.GetType() == typeof(ValueTreeNode))
            {
                tbcContent.SelectTab(tpgProduct);
                
                lstProducts.SelectedValue = ((ValueTreeNode)e.Node).Value;
            }
        }


        private void btnMemberApply_Click(object sender, EventArgs e)
        {
            //Check all fields for diff changes against the DB
            //If any fields are changed, validate
            //If valid, commit

            string message = string.Empty;

            if (txtMemberName.Text != memberData["name"].ToString())            
                if (!DataValidation.validateInformation(txtMemberName.Text, RegexPattern.NameString))
                    message += "* Name\n";
            

            if (txtMemberEmail.Text != memberData["email"].ToString() && txtMemberEmail.Text != string.Empty)            
                if (!DataValidation.validateInformation(txtMemberEmail.Text, RegexPattern.EmailString))
                    message += "* Email\n";
            

            if (txtMemberTel.Text != memberData["phoneNumber"].ToString())            
                if (!DataValidation.validateInformation(txtMemberTel.Text, RegexPattern.PhoneString))
                    message += "* Telephone Number\n";
            

            if (txtMemberMob.Text != memberData["mobileNumber"].ToString())            
                if (!DataValidation.validateInformation(txtMemberMob.Text, RegexPattern.NumericalString))
                    message += "* Mobile Number\n";

            if (txtMemberAddress.Text == string.Empty)
                message += "* Address\n";

            if (message != string.Empty)
                MessageBox.Show("Please verify the following:\n" + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (MessageBox.Show(this, "Are you sure you want to apply these changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int selectedValue = (int)memberData["memberID"];
                //No errors, apply changes:
                string insertQuery = String.Format(
                    "UPDATE Member\n" +
                    "SET name=\"{0}\", address=\"{1}\", phoneNumber=\"{2}\", mobileNumber=\"{3}\", email=\"{4}\"" +
                    "WHERE memberID ={5}", txtMemberName.Text, txtMemberAddress.Text, txtMemberTel.Text,
                    txtMemberMob.Text, txtMemberEmail.Text, txtMemberID.Text);

                if (mDatabase.runCommandQuery(insertQuery))
                {
                    //changes applied! Reload data in GUI:
                    mDatabase.selectData("SELECT * FROM Member", ref dtbMember);

                    //Restore previous item selection
                    lstMembers.SelectedValue = selectedValue;

                    MessageBox.Show(this,"Changes applied successfully");
                }
                else
                    MessageBox.Show(this,"Failed to apply changes");
            }

        }

        private void btnNewMember_Click(object sender, EventArgs e)
        {            
            addMemberDialogue = new frmAddMember(mDatabase);
            addMemberDialogue.RecordAdded += addMemberDialogue_RecordAdded;
            addMemberDialogue.ShowDialog(this);
        }

        private void btnMemberCancel_Click(object sender, EventArgs e)
        {
            //User cancelled changes, reload current record from last DB pull:
            fillMemberDataFields();
        }

    }
}
