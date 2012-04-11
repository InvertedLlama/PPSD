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
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.dgcStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBranchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabContent.SuspendLayout();
            this.tbStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
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
            this.tbStaff.AutoScroll = true;
            this.tbStaff.Controls.Add(this.dgvStaff);
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
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            // dgvStaff
            // 
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcStaffID,
            this.dgcBranchID,
            this.dgcName,
            this.dgcRole,
            this.dgcAddress,
            this.dgcPhoneNumber,
            this.dgcEmail,
            this.dgcUsername,
            this.dgcPassword});
            this.dgvStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStaff.Location = new System.Drawing.Point(3, 3);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.Size = new System.Drawing.Size(662, 433);
            this.dgvStaff.TabIndex = 0;
            // 
            // dgcStaffID
            // 
            this.dgcStaffID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgcStaffID.HeaderText = "StaffID";
            this.dgcStaffID.MinimumWidth = 50;
            this.dgcStaffID.Name = "dgcStaffID";
            this.dgcStaffID.Width = 65;
            // 
            // dgcBranchID
            // 
            this.dgcBranchID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgcBranchID.HeaderText = "BranchID";
            this.dgcBranchID.Name = "dgcBranchID";
            this.dgcBranchID.Width = 77;
            // 
            // dgcName
            // 
            this.dgcName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgcName.HeaderText = "Name";
            this.dgcName.Name = "dgcName";
            this.dgcName.Width = 60;
            // 
            // dgcRole
            // 
            this.dgcRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgcRole.HeaderText = "Role";
            this.dgcRole.Name = "dgcRole";
            this.dgcRole.Width = 54;
            // 
            // dgcAddress
            // 
            this.dgcAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgcAddress.HeaderText = "Address";
            this.dgcAddress.Name = "dgcAddress";
            this.dgcAddress.Width = 70;
            // 
            // dgcPhoneNumber
            // 
            this.dgcPhoneNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgcPhoneNumber.HeaderText = "Phone Number";
            this.dgcPhoneNumber.Name = "dgcPhoneNumber";
            this.dgcPhoneNumber.Width = 95;
            // 
            // dgcEmail
            // 
            this.dgcEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgcEmail.HeaderText = "Email";
            this.dgcEmail.Name = "dgcEmail";
            this.dgcEmail.Width = 57;
            // 
            // dgcUsername
            // 
            this.dgcUsername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgcUsername.HeaderText = "Username";
            this.dgcUsername.Name = "dgcUsername";
            this.dgcUsername.Width = 80;
            // 
            // dgcPassword
            // 
            this.dgcPassword.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgcPassword.HeaderText = "Password";
            this.dgcPassword.Name = "dgcPassword";
            this.dgcPassword.Width = 78;
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
            this.tbStaff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcStaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBranchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPassword;
    }
}