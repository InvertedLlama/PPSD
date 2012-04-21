using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPSDPart2
{
    public partial class frmAddStaff : Form
    {
        Database mDatabase;
        DataTable dtbStaff;

        public event RecordAddedHandler RecordAdded;
        public delegate void RecordAddedHandler(object sender, EventArgs e);

        public frmAddStaff(Database database, DataTable staffTable)
        {
            InitializeComponent();
            mDatabase = database;
            dtbStaff = staffTable;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSumbit_Click(object sender, EventArgs e)
        {
            //Validate data
            string message = string.Empty;

            if (!DataValidation.validateInformation(txtName.Text, RegexPattern.NameString))
                message += " * Name\n";

            if (!DataValidation.validateInformation(txtTel.Text, RegexPattern.PhoneString))
                message += " * Telephone Number\n";

            if (!DataValidation.validateInformation(txtEmail.Text, RegexPattern.EmailString) && txtEmail.Text != string.Empty)
                message += " * Email\n";

            if (txtAddress.Text == string.Empty)
                message += " * Address\n";

            if (txtUsername.Text == string.Empty)
                message += " * Username\n";

            //There's no way of stopping two or more people from attempting to add exactly the same username if they try to do so at exactly the same time.
            //however the database constraints will stop it from breaking the database and by checking for existing usernames here we can keep this occurence to a minimum
            if ((dtbStaff.Select("username = \'" + txtUsername.Text + "\'")).Count() > 0)
                message += " * Username already in use";

            if (txtPassword.Text == string.Empty)
                message += " * Password\n";

            if (cboRole.SelectedIndex < 0)
                message += " * Role\n";

            if (message != string.Empty)
                MessageBox.Show(this, "Please verify the following fields:\n " + message, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                //Data is valid, push it to the database
                string insertQuery = string.Format(
                    "INSERT INTO Staff (name, phoneNumber, email, address, role, username, password)\n" +
                    "VALUES (\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\")",
                    txtName.Text, txtTel.Text, txtEmail.Text, txtAddress.Text, cboRole.Text, txtUsername.Text, txtPassword.Text
                    );

                if (mDatabase.runCommandQuery(insertQuery))
                {
                    if (RecordAdded != null)
                        RecordAdded(this, EventArgs.Empty);
                }
                else
                    MessageBox.Show(this, "Failed to add record to database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }
        }

    }
}
