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
    public partial class frmAddSupplier : Form
    {
        Database mDatabase;

        public event RecordAddedHandler RecordAdded;
        public delegate void RecordAddedHandler(object sender, EventArgs e);

        public frmAddSupplier(Database database)
        {
            InitializeComponent();
            mDatabase = database;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Validate data
            string message = string.Empty;

            if (!(DataValidation.validateInformation(txtName.Text, RegexPattern.NameString)))
                message += " * Name\n";

            if (!(DataValidation.validateInformation(txtTel.Text, RegexPattern.PhoneString)))
                message += " * Telephone Number\n";

            if (txtAddress.Text == string.Empty)
                message += " * Address\n";

            if (txtEmail.Text != string.Empty && !(DataValidation.validateInformation(txtEmail.Text, RegexPattern.EmailString)))
                message += " * Email\n";

            if (message != string.Empty)
                MessageBox.Show(this, "Please verify the following fields:\n" + message, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                //Data is valid so push it to the database
                string insertString = string.Format(
                    "INSERT INTO Supplier (name, phoneNumber, address, email)\n" +
                    "VALUES (\"{0}\", \"{1}\", \"{2}\", \"{3}\")",
                    txtName.Text, txtTel.Text, txtAddress.Text, txtEmail.Text
                    );

                if (!mDatabase.runCommandQuery(insertString))
                    MessageBox.Show(this, "Failed to add record to database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    if (RecordAdded != null)
                        RecordAdded(this, EventArgs.Empty);
            }
            
        }
    }
}
