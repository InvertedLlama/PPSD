using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PPSDPart2
{
    public partial class frmLogin : Form
    {
        frmContent contentForm;
        Database programDatabase;

        public frmLogin(Database programDatabase)
        {
            InitializeComponent();
            this.programDatabase = programDatabase;

            //Set for debug purposes, quicker login:
            txtUsername.Text = "admin01";
            txtPassword.Text = "password";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Run the login fuction
            login(txtUsername.Text, txtPassword.Text);
            txtUsername.Clear();
            txtPassword.Clear();
        }

        /// <summary>
        /// Checks username and password against the database and either
        /// sends the user to the cotent form or shows an error message
        /// </summary>
        private void login(string username, string password)
        {
            string strQuery = string.Format("SELECT * FROM Staff WHERE username = \'{0}\' AND password = \'{1}';",
                                                username,
                                                password);            

            DataTable userInfo = programDatabase.selectData(strQuery);

            if (userInfo.Rows.Count > 0)
            {
                DataRow dtrRow = userInfo.Rows[0];

                UserAccessLevel accessLvl = UserAccessLevel.None;
                switch ((string)dtrRow["role"])
                {
                    case "Admin":
                        accessLvl = UserAccessLevel.Admin;
                        break;
                    case "Instructor":
                        accessLvl = UserAccessLevel.Instructor;
                        break;
                    case "CounterStaff":
                        accessLvl = UserAccessLevel.CounterStaff;
                        break;
                    case "Owner":
                        accessLvl = UserAccessLevel.Owner;
                        break;
                    default:
                        MessageBox.Show(this, "Database error.\n Unexpected value in Staff.Role. Notify an administrator.",
                                            "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                        break;
                }

                contentForm = new frmContent(programDatabase, new User((string)dtrRow["name"], (string)dtrRow["username"], (string)dtrRow["password"], accessLvl));

                this.Hide();
                contentForm.Show(this);                
            }
            else
            {
                MessageBox.Show(this, "Invalid Login Information. Please try again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Run the login fuction
                login(txtUsername.Text, txtPassword.Text);
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }
    }
}
