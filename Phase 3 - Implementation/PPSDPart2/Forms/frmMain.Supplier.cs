using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace PPSDPart2
{
    public partial class frmMain
    {
        DataTable dtbSupplier;
        BindingSource bisSupplierListBinding;

        private void initialiseSupplierData()
        {
            bisSupplierListBinding = new BindingSource();

            dtbSupplier = mDatabase.selectData("SELECT * FROM Supplier");
            bisSupplierListBinding.DataSource = dtbSupplier;

            lstSuppliers.DataSource = bisSupplierListBinding;

            lstSuppliers.ValueMember = dtbSupplier.Columns[0].ColumnName;
            lstSuppliers.DisplayMember = "name";

            lstSuppliers.ClearSelected();


            //register the event handler method for a new list item being selected manually.
            //if this is done in the designer it doesn't apply the Value and Display member settings early enough and it causes issues
            lstSuppliers.SelectedValueChanged += lstSuppliers_SelectedValueChanged;
            txtSupplierFilter.TextChanged += txtSupplierFilter_TextChanged;
        }

        private void fillSupplierDataFields()
        {
            try
            {
                //Get the data. IDs are unique so unless something has gone horribly wrong there should only be one row
                DataRow supplierData = dtbSupplier.Select("supplierID + '' = '" + lstSuppliers.SelectedValue + "'")[0];

                txtSupplierID.Text = supplierData["supplierID"].ToString();
                txtSupplierEmail.Text = supplierData["email"].ToString();
                txtSupplierName.Text = supplierData["name"].ToString();
                txtSupplierTel.Text = supplierData["phoneNumber"].ToString();                
                txtSupplierAddress.Text = supplierData["address"].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message);
            }

        }

        private void lstSuppliers_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox sndr = (ListBox)sender;
            if (sndr.SelectedValue != null)
                fillSupplierDataFields();
            else
            {
                txtSupplierID.Text = string.Empty;
                txtSupplierEmail.Text = string.Empty;
                txtSupplierName.Text = string.Empty;
                txtSupplierTel.Text = string.Empty;
                txtSupplierAddress.Text = string.Empty;
            }
        }

        private void txtSupplierFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox sndr = (TextBox)sender;
            bisSupplierListBinding.Filter = "name + '' LIKE '%" + sndr.Text + "%'";
        }
    }
}
