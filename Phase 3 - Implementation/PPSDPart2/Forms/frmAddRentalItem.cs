using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPSDPart2.Forms
{
    public partial class frmAddRentalItem : Form
    {
        DataTable dtbProduct, dtbBranch, dtbStock;

        public frmAddRentalItem(ref DataTable product, ref DataTable branch, ref DataTable stock)
        {
            InitializeComponent();
            dtbProduct = product;
            dtbBranch = branch;
            dtbStock = stock;
        }
    }
}
