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
    public partial class frmMain : Form
    {
        Database mDatabase;
        User muser;
        DataTable dtbMember, dtbRental, dtbRentalItem, dtbBranch, dtbProduct, dtbCategory, dtbStaff, dtbSupplier, dtbStock;

        public frmMain(Database programDatabase, User currentuser)
        {
            InitializeComponent();
            this.mDatabase = programDatabase;
            this.muser = currentuser;

            pullData();

            //Prepare the tabs
            initialiseMemberData();
            initialiseProductData();
            initialiseStaffData();
            initialiseBranchData();
            initialiseSupplierData();
        }

        private void pullData()
        {
            dtbMember = mDatabase.selectData("SELECT * FROM Member");
            dtbRental = mDatabase.selectData("SELECT * FROM Rental");
            dtbRentalItem = mDatabase.selectData("SELECT * FROM RentalItem");
            dtbBranch = mDatabase.selectData("SELECT * FROM Branch");
            dtbProduct = mDatabase.selectData("SELECT * FROM Product");
            dtbCategory = mDatabase.selectData("SELECT * FROM Category");
            dtbStaff = mDatabase.selectData("SELECT * FROM Staff");
            dtbSupplier = mDatabase.selectData("SELECT * FROM Supplier");
            dtbStock = mDatabase.selectData("SELECT * FROM Stock");
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();

            //Sometimes the controls weren't drawing when the login form came back up
            //this should fix it            
            Owner.Refresh();
        }
    }
}
