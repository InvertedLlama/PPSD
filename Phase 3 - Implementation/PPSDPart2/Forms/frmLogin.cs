﻿using System;
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
            DatabaseTable userInfo = null;

            try
            {
                userInfo = programDatabase.runDataSelectQuery("SELECT role, name FROM Staff WHERE username = '" + username + "' AND password = '" + password + "'");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(this, "Login attempt failed: " + e.Message, "Login Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (userInfo.RowCount < 1)
            {
                MessageBox.Show(this, "Incorrect login information", "Login Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                        
            //TEMP Show the content form            
            contentForm = new frmContent(programDatabase);

            if (contentForm.IsDisposed)
                return;

            UserAccessLevel accessLevel;

            switch(userInfo.Data["role"][0])
            {
                case "Admin":
                    accessLevel = UserAccessLevel.Admin;
                    break;
                case "CounterStaff":
                    accessLevel = UserAccessLevel.CounterStaff;
                    break;
                case "Owner":
                    accessLevel = UserAccessLevel.Owner;
                    break;
                case "Instructor":
                    accessLevel = UserAccessLevel.Instructor;
                    break;
                default:
                    MessageBox.Show(this, "ERROR: Invalid Data", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            contentForm.CurrentUser = new User(userInfo.Data["name"][0], username, password, accessLevel);

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
