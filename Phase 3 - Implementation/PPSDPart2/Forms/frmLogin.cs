using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PPSDPart2.Objects;

namespace PPSDPart2
{
    public partial class frmLogin : Form
    {
        frmContent contentForm;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Run the login fuction
            login(txtUsername.Text, txtPassword.Text);
        }

        //Checks username and password against the database and either sends the user to the cotent form
        //or shows an error message
        private void login(string username, string password)
        {
            contentForm = new frmContent();
            //Database foo


            //TEMP Show the content form
            contentForm.CurrentUser = new User("TestName", "TestUser", "TestPassword", UserAccessLevel.Admin);
            contentForm.Show(this);

        }
    }
}
