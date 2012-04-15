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
        BindingSource bisMemberListBinding;

        private void initialiseMemberData()
        {
            bisMemberListBinding = new BindingSource();

            bisMemberListBinding.DataSource = dtbMember;

            lstMembers.DataSource = bisMemberListBinding;
                        
            lstMembers.ValueMember = dtbMember.Columns[0].ColumnName;
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
                DataRow memberData = dtbMember.Select("memberID + '' = '" + lstMembers.SelectedValue + "'")[0];
                                
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
                    crntNode = new TreeNode(string.Format("Rental: {0}, Cost: £{1}", rental["rentalID"], rental["totalCost"]));
                    rentalItems = dtbRentalItem.Select("rentalID = " + rental["rentalID"]);

                    foreach (DataRow rentalItem in rentalItems)
                    {
                        productInfo = dtbProduct.Select("productID = " + rentalItem["productID"])[0];
                        crntNode.Nodes.Add(new ValueTreeNode(string.Format("Item: {0}, Cost: £{1}", productInfo["name"], rentalItem["cost"]), 
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

        private void lstMember_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox sndr = (ListBox)sender;
            if (sndr.SelectedValue != null)
                fillMemberDataFields();
            else
            {
                txtMemberID.Text = string.Empty;
                txtMemberEmail.Text = string.Empty;
                txtMemberName.Text = string.Empty;
                txtMemberTel.Text = string.Empty;
                txtMemberMob.Text = string.Empty;
                txtMemberAddress.Text = string.Empty;
                trvMemberRentals.Nodes.Clear();
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

        /* APPLY BUTTON */
        private void btnMemberApply_Click(object sender, EventArgs e)
        {
            //Check all fields for diff changes against the DB
            //If any fields are changed, validate
            //If valid, commit

            string message = string.Empty;
            DataTable memberData = mDatabase.selectData("SELECT * FROM Member WHERE memberID = " + txtMemberID.Text);

            if (txtMemberName.Text != (string)memberData.Rows[0]["name"])
            {
                if (!validateInformation(txtMemberName.Text, "^[A-Za-z -]+$"))
                    message += "* Name\n";
            }

            if (txtMemberEmail.Text != (string)memberData.Rows[0]["email"])
            {
                if (!validateInformation(txtMemberEmail.Text, "^[0-9A-Za-z]+[@][0-9A-Za-z]+[.][A-Za-z.]+$"))
                    message += "* Email\n";
            }

            if (txtMemberTel.Text != (string)memberData.Rows[0]["phoneNumber"])
            {
                if (!validateInformation(txtMemberTel.Text, "^[0-9]+$"))
                    message += "* Telephone Number\n";
            }

            if (txtMemberMob.Text != (string)memberData.Rows[0]["mobileNumber"].ToString()) //Null attribute, cast to string
            {
                if (!validateInformation(txtMemberMob.Text, "^[0-9]+$"))
                    message += "* Mobile Number\n";
            }

            if (message != string.Empty)
                MessageBox.Show("Please verify the following:\n" + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string insertQuery = String.Format(
                    "UPDATE Member\n" +
                    "SET name=\"{0}\", address=\"{1}\", phoneNumber=\"{2}\", mobileNumber=\"{3}\", email=\"{4}\"" +
                    "WHERE memberID ={5}", txtMemberName.Text, txtMemberAddress.Text, txtMemberTel.Text,
                    txtMemberMob.Text, txtMemberEmail.Text, txtMemberID.Text);

                if (mDatabase.runCommandQuery(insertQuery))
                {
                    dtbMember = mDatabase.selectData("SELECT * FROM Member");
                    initialiseMemberData();
                    if (lstMembers.Items.Count > 0) //set selected item to first entry:
                    {
                        lstMembers.SelectedItem = lstMembers.Items[0];
                        fillMemberDataFields();
                    }


                    MessageBox.Show("Changes applied successfully");
                }
                else
                    MessageBox.Show("Failed to apply changes");
            }

        }
        
    }

    
}
