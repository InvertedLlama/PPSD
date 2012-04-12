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
    public partial class frmAddSupplier : Form
    {
        Database programDatabase;

        public frmAddSupplier(Database database)
        {
            InitializeComponent();
            this.programDatabase = database;            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {            
            if (validateInformation())
            {
                string insertQuery = String.Format(
                    "INSERT INTO Supplier (name, address, phoneNumber, email)\n" +
                    "VALUES (\"{0}\", \"{1}\", \"{2}\", \"{3}\");",
                    txtName.Text,
                    txtAddress.Text,
                    txtTelephone.Text,
                    txtEmail.Text);

                if (programDatabase.runCommandQuery(insertQuery))
                {
                    MessageBox.Show("Supplier Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Error adding supplier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool validateInformation()
        {
            Regex regex, disallowedRegex;
            string message = string.Empty;

            //All characters are allowed except quotation marks as they can cause
            //issues with the query string having open qoutes
            string disallowedCharacters = "^['\"]";

            string emailPattern = "^[0-9A-Za-z]+[@][0-9A-Za-z]+[.][A-Za-z.]+$";

            //Phone pattern should match any standard european number with most ways of placing spaces and region codes
            //it will also work for American and Canadian phone numbers provided they are written with the standard european formatting
            //and not with the traditional dash format
            string phonePattern = "[+]??[0-9]{5,6}[ ]??[0-9]{3}[ ]??[0-9]{3}";

            string alphapattern = "^[A-Za-z -]+$";

            disallowedRegex = new Regex(disallowedCharacters);
            regex = new Regex(alphapattern);
            if(!regex.IsMatch(txtName.Text))            
                message += "* Name\n";                
            
            
            regex = new Regex(phonePattern);
            if (!regex.IsMatch(txtTelephone.Text))            
                message += "* Telephone\n";                
            

            regex = new Regex(emailPattern);
            if (!regex.IsMatch(txtEmail.Text) && txtEmail.Text != string.Empty)            
                message += "* Email Address\n";

            if (txtAddress.Text == string.Empty || disallowedRegex.IsMatch(txtName.Text))
                message += "* Address\n";

            

            if (message != string.Empty)
            {
                string mb_message = "Please verify the following fields:\n" + message;
                MessageBox.Show(this, mb_message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        
    }
}
