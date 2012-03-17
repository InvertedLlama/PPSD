namespace PPSDPart2
{
    partial class frmContent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabContent = new System.Windows.Forms.TabControl();
            this.tbSupplier = new System.Windows.Forms.TabPage();
            this.tbStaff = new System.Windows.Forms.TabPage();
            this.tbProduct = new System.Windows.Forms.TabPage();
            this.tbRental = new System.Windows.Forms.TabPage();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tabContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabContent
            // 
            this.tabContent.Controls.Add(this.tbSupplier);
            this.tabContent.Controls.Add(this.tbStaff);
            this.tabContent.Controls.Add(this.tbProduct);
            this.tabContent.Controls.Add(this.tbRental);
            this.tabContent.Location = new System.Drawing.Point(12, 34);
            this.tabContent.Name = "tabContent";
            this.tabContent.SelectedIndex = 0;
            this.tabContent.Size = new System.Drawing.Size(676, 465);
            this.tabContent.TabIndex = 0;
            // 
            // tbSupplier
            // 
            this.tbSupplier.Location = new System.Drawing.Point(4, 22);
            this.tbSupplier.Name = "tbSupplier";
            this.tbSupplier.Padding = new System.Windows.Forms.Padding(3);
            this.tbSupplier.Size = new System.Drawing.Size(668, 439);
            this.tbSupplier.TabIndex = 0;
            this.tbSupplier.Text = "Supplier";
            this.tbSupplier.UseVisualStyleBackColor = true;
            // 
            // tbStaff
            // 
            this.tbStaff.Location = new System.Drawing.Point(4, 22);
            this.tbStaff.Name = "tbStaff";
            this.tbStaff.Padding = new System.Windows.Forms.Padding(3);
            this.tbStaff.Size = new System.Drawing.Size(668, 439);
            this.tbStaff.TabIndex = 1;
            this.tbStaff.Text = "Staff";
            this.tbStaff.UseVisualStyleBackColor = true;
            // 
            // tbProduct
            // 
            this.tbProduct.Location = new System.Drawing.Point(4, 22);
            this.tbProduct.Name = "tbProduct";
            this.tbProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tbProduct.Size = new System.Drawing.Size(668, 439);
            this.tbProduct.TabIndex = 2;
            this.tbProduct.Text = "Product";
            this.tbProduct.UseVisualStyleBackColor = true;
            // 
            // tbRental
            // 
            this.tbRental.Location = new System.Drawing.Point(4, 22);
            this.tbRental.Name = "tbRental";
            this.tbRental.Padding = new System.Windows.Forms.Padding(3);
            this.tbRental.Size = new System.Drawing.Size(668, 439);
            this.tbRental.TabIndex = 3;
            this.tbRental.Text = "Rental";
            this.tbRental.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(16, 505);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(25, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(464, 20);
            this.txtSearch.TabIndex = 2;
            // 
            // cmbField
            // 
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(495, 7);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(105, 21);
            this.cmbField.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(606, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(97, 505);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(178, 505);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // frmContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 533);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.tabContent);
            this.Controls.Add(this.cmbField);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmContent";
            this.Text = "Rental System - Content";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            this.tabContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabContent;
        private System.Windows.Forms.TabPage tbSupplier;
        private System.Windows.Forms.TabPage tbStaff;
        private System.Windows.Forms.TabPage tbProduct;
        private System.Windows.Forms.TabPage tbRental;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
    }
}