namespace PPSDPart2
{
    partial class frmAddProduct
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
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.lblRentalFee = new System.Windows.Forms.Label();
            this.txtRentalFee = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(22, 12);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(53, 17);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category:";
            this.lblCategory.UseCompatibleTextRendering = true;
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(80, 9);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(155, 21);
            this.cboCategory.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(372, 85);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseCompatibleTextRendering = true;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(155, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(36, 36);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(238, 9);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(49, 17);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Supplier:";
            this.lblSupplier.UseCompatibleTextRendering = true;
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(292, 6);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(155, 21);
            this.cboSupplier.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(291, 85);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseCompatibleTextRendering = true;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(250, 36);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(31, 17);
            this.lblCost.TabIndex = 0;
            this.lblCost.Text = "Cost:";
            this.lblCost.UseCompatibleTextRendering = true;
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(291, 33);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(155, 20);
            this.txtCost.TabIndex = 3;
            // 
            // lblRentalFee
            // 
            this.lblRentalFee.AutoSize = true;
            this.lblRentalFee.Location = new System.Drawing.Point(12, 63);
            this.lblRentalFee.Name = "lblRentalFee";
            this.lblRentalFee.Size = new System.Drawing.Size(63, 17);
            this.lblRentalFee.TabIndex = 0;
            this.lblRentalFee.Text = "Rental Fee:";
            this.lblRentalFee.UseCompatibleTextRendering = true;
            // 
            // txtRentalFee
            // 
            this.txtRentalFee.Location = new System.Drawing.Point(80, 60);
            this.txtRentalFee.Name = "txtRentalFee";
            this.txtRentalFee.Size = new System.Drawing.Size(155, 20);
            this.txtRentalFee.TabIndex = 3;
            // 
            // frmAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 116);
            this.ControlBox = false;
            this.Controls.Add(this.txtRentalFee);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.lblRentalFee);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label lblRentalFee;
        private System.Windows.Forms.TextBox txtRentalFee;
    }
}