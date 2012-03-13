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
    public partial class frmContent : Form
    {
        private User crntUser;
        
        public frmContent()
        {
            InitializeComponent();            
        }

        public User CurrentUser
        {
            get { return crntUser; }
            set { crntUser = value; }
        }

        private void frmContent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rentalSystemDataSet1.Staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.rentalSystemDataSet1.Staff);
            // TODO: This line of code loads data into the 'rentalSystemDataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.rentalSystemDataSet.Supplier);

        }

    }
}
