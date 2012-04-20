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
    public partial class frmAddMember : Form
    {
        Database mDatabase;

        public event RecordAddedHandler RecordAdded;
        public delegate void RecordAddedHandler(object sender, EventArgs e);


        public frmAddMember(Database database)
        {
            InitializeComponent();
            mDatabase = database;
        }

        private void btnSumbit_Click(object sender, EventArgs e)
        {
            //Validate new member information
            string message = string.Empty;

            if (txtAddress.Text == string.Empty)
                message += "* Address\n";

            if (txtEmail.Text != string.Empty && !DataValidation.validateInformation(txtEmail.Text, RegexPattern.EmailString))
                message += "* Email\n";

            if (txtMobile.Text != string.Empty && !DataValidation.validateInformation(txtMobile.Text, RegexPattern.PhoneString))
                message += "* Mobile Number\n";

            if (!(DataValidation.validateInformation(txtName.Text, RegexPattern.NameString)))
                message += "* Name\n";

            if (!(DataValidation.validateInformation(txtTel.Text, RegexPattern.PhoneString)))
                message += "* Phone Number\n";

            if (message != string.Empty)
                MessageBox.Show(this, "Please validate the following fields:\n" + message, "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                //Data is ok so insert a new record in the data table
                addRecord();
            }
                
        }

        private void addRecord()
        {
            //While it is possible to update the local DataTable object and then push changes to the database
            //this approach is less error prone and easier to keep in sync with the database
            string insertQuery = string.Format(
                "INSERT INTO Member (name, address, phoneNumber, email, mobileNumber)\n" +
                "VALUES (\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\");",
                txtName.Text, txtAddress.Text, txtTel.Text, txtEmail.Text, txtMobile.Text
                );

            if (mDatabase.runCommandQuery(insertQuery))
            {
                //Notify objects watching this event that a record has been added
                //Parent form will handle hiding this form and notifying the user of the data being successfully added
                if(RecordAdded != null)
                    RecordAdded(this, EventArgs.Empty);                
            }
            else
            {
                MessageBox.Show(this, "Failed to add record to database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddMember_VisibleChanged(object sender, EventArgs e)
        {
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtName.Text = string.Empty;
            txtTel.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
