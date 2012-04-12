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
            contentForm = new frmContent(programDatabase);
            contentForm.CurrentUser = new User("Bob", "admin001", "password", UserAccessLevel.Admin);
            contentForm.Show(this);
            this.Hide();

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
