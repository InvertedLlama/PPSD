using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PPSDPart2
{
    public partial class frmAddStaff : Form
    {
        Database programDatabase;
        DataBinding dataBinding;

        public frmAddStaff(Database database, DataBinding binding)
        {
            InitializeComponent();
            programDatabase = database;
            dataBinding = binding;

            setBranchData();
        }

        /// <summary>
        /// Loads the Branch Combobox with data from the database:
        /// </summary>
        private void setBranchData()
        {
            cboBranch.Items.Clear();
                        
            foreach(DataRow r in programDatabase.selectData("SELECT branchID FROM Branch").Rows)
            {
                //There should only be one column so this is correct
                cboBranch.Items.Add(r.ItemArray[0]);
            }
        }

        /// <summary>
        /// Event handler for Submit button, sends the data to the DB
        /// </summary>
        private void btnAddStaffMember_Click(object sender, EventArgs e)
        {
            if (validateInformation())
            {               
                //We really shouldn't be writing to the database each and every time we do this but for now it gets us around the issues with auto-increments
                                
                //This is the insert query for a new staff member. Not fun to write.     
              /*  string insertQuery = String.Format(
                    "INSERT INTO Staff (branchID, name, role, address, phoneNumber, email, username, password)\n" +
                    "VALUES ({0}, \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\")",                    
                        cboBranch.SelectedItem,
                        txtName.Text,
                        (string)cboRole.SelectedItem,
                        txtAddress.Text,
                        txtTelephone.Text,
                        txtEmail.Text,
                        txtUsername.Text,
                        txtPassword.Text);

                programDatabase.runCommandQuery(insertQuery);
                dataBinding.update();
                */

                DataRow nr = dataBinding.Data.NewRow();
                nr["branchID"] = cboBranch.SelectedItem;
                nr["name"] = txtName.Text;
                nr["role"] = cboRole.SelectedItem;
                nr["address"] = txtAddress.Text;
                nr["phoneNumber"] = txtTelephone.Text;
                nr["email"] = txtEmail.Text;
                nr["password"] = txtPassword.Text;
                nr["username"] = txtUsername.Text;

                dataBinding.Data.Rows.Add(nr);

                dataBinding.update();


                Close();
               
            }
        }

        /// <summary>
        /// Validates the information given on the form to the DB constraints
        /// and warns the user (via GUI) should any fields fail
        /// </summary>
        private bool validateInformation()
        {
            Regex regex;
            string message = string.Empty;

            string username_pattern = "^[A-Za-z0-9]+$";
            string alpha_pattern = "^[A-Za-z -]+$";
            string numeric_pattern = "^[0-9]+$";
            string email_pattern = "^[0-9A-Za-z]+[@][0-9A-Za-z]+[.][A-Za-z.]+$";

            //Check a Branch has been selected, will be triggered if no Branches exist:
            if (cboBranch.SelectedItem == string.Empty)
                message += "* No Branch selected\n";

            //Check a Role has been selected (you forgot this one matt :p
            if (cboRole.SelectedItem == null)
                message += "* No Role Selected\n";

            regex = new Regex(username_pattern);

            if(!regex.IsMatch(txtUsername.Text))
                message += "* Username\n";


            regex = new Regex(alpha_pattern);

            if (!regex.IsMatch(txtName.Text))
                message += "* Name\n";


            regex = new Regex(numeric_pattern);

            if (!regex.IsMatch(txtTelephone.Text))
                message += "* Telephone\n";


            regex = new Regex(email_pattern);

            if (!regex.IsMatch(txtEmail.Text) && txtEmail.Text != string.Empty)
                message += "* Email Address\n";

            if (message != string.Empty)
            {
                string mb_message = "Please verify the following fields:\n" + message;
                MessageBox.Show(mb_message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }
    }
}
