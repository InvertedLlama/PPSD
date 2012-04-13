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
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tbRental = new System.Windows.Forms.TabPage();
            this.dgvRental = new System.Windows.Forms.DataGridView();
            this.tbProduct = new System.Windows.Forms.TabPage();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.tbStaff = new System.Windows.Forms.TabPage();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.tbSupplier = new System.Windows.Forms.TabPage();
            this.dgvSupplier = new System.Windows.Forms.DataGridView();
            this.tabContent = new System.Windows.Forms.TabControl();
            this.lblSearchMsg = new System.Windows.Forms.Label();
            this.tbRental.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRental)).BeginInit();
            this.tbProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.tbStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.tbSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).BeginInit();
            this.tabContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(25, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(464, 20);
            this.txtSearch.TabIndex = 2;
            // 
            // cmbField
            // 
            this.cmbField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(495, 7);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(105, 21);
            this.cmbField.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(97, 505);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(178, 505);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // tbRental
            // 
            this.tbRental.Controls.Add(this.dgvRental);
            this.tbRental.Location = new System.Drawing.Point(4, 22);
            this.tbRental.Name = "tbRental";
            this.tbRental.Padding = new System.Windows.Forms.Padding(3);
            this.tbRental.Size = new System.Drawing.Size(668, 439);
            this.tbRental.TabIndex = 3;
            this.tbRental.Tag = "RENTAL_TAB";
            this.tbRental.Text = "Rental";
            this.tbRental.UseVisualStyleBackColor = true;
            // 
            // dgvRental
            // 
            this.dgvRental.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRental.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRental.Location = new System.Drawing.Point(3, 3);
            this.dgvRental.Name = "dgvRental";
            this.dgvRental.Size = new System.Drawing.Size(662, 433);
            this.dgvRental.TabIndex = 0;
            // 
            // tbProduct
            // 
            this.tbProduct.Controls.Add(this.dgvProduct);
            this.tbProduct.Location = new System.Drawing.Point(4, 22);
            this.tbProduct.Name = "tbProduct";
            this.tbProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tbProduct.Size = new System.Drawing.Size(668, 439);
            this.tbProduct.TabIndex = 2;
            this.tbProduct.Tag = "PRODUCT_TAB";
            this.tbProduct.Text = "Product";
            this.tbProduct.UseVisualStyleBackColor = true;
            // 
            // dgvProduct
            // 
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduct.Location = new System.Drawing.Point(3, 3);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.Size = new System.Drawing.Size(662, 433);
            this.dgvProduct.TabIndex = 0;
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
            this.tbStaff.Tag = "STAFF_TAB";
            this.tbStaff.Text = "Staff";
            this.tbStaff.UseVisualStyleBackColor = true;
            // 
            // dgvStaff
            // 
            this.dgvStaff.AllowUserToAddRows = false;
            this.dgvStaff.AllowUserToDeleteRows = false;
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStaff.Location = new System.Drawing.Point(3, 3);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.Size = new System.Drawing.Size(662, 433);
            this.dgvStaff.TabIndex = 0;
            // 
            // tbSupplier
            // 
            this.tbSupplier.Controls.Add(this.dgvSupplier);
            this.tbSupplier.Location = new System.Drawing.Point(4, 22);
            this.tbSupplier.Name = "tbSupplier";
            this.tbSupplier.Padding = new System.Windows.Forms.Padding(3);
            this.tbSupplier.Size = new System.Drawing.Size(668, 439);
            this.tbSupplier.TabIndex = 0;
            this.tbSupplier.Tag = "SUPPLIER_TAB";
            this.tbSupplier.Text = "Supplier";
            this.tbSupplier.UseVisualStyleBackColor = true;
            // 
            // dgvSupplier
            // 
            this.dgvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupplier.Location = new System.Drawing.Point(3, 3);
            this.dgvSupplier.Name = "dgvSupplier";
            this.dgvSupplier.Size = new System.Drawing.Size(662, 433);
            this.dgvSupplier.TabIndex = 0;
            // 
            // tabContent
            // 
            this.tabContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabContent.Controls.Add(this.tbSupplier);
            this.tabContent.Controls.Add(this.tbStaff);
            this.tabContent.Controls.Add(this.tbProduct);
            this.tabContent.Controls.Add(this.tbRental);
            this.tabContent.Location = new System.Drawing.Point(12, 34);
            this.tabContent.Name = "tabContent";
            this.tabContent.SelectedIndex = 0;
            this.tabContent.Size = new System.Drawing.Size(676, 465);
            this.tabContent.TabIndex = 0;
            this.tabContent.SelectedIndexChanged += new System.EventHandler(this.tabContent_SelectedIndexChanged);
            // 
            // lblSearchMsg
            // 
            this.lblSearchMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchMsg.AutoSize = true;
            this.lblSearchMsg.BackColor = System.Drawing.SystemColors.Info;
            this.lblSearchMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchMsg.Location = new System.Drawing.Point(261, 510);
            this.lblSearchMsg.Name = "lblSearchMsg";
            this.lblSearchMsg.Size = new System.Drawing.Size(427, 13);
            this.lblSearchMsg.TabIndex = 1;
            this.lblSearchMsg.Text = "Data is currently being filtered. Search with an empty search field to return to " +
    "normal view.";
            this.lblSearchMsg.Visible = false;
            // 
            // frmContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 533);
            this.Controls.Add(this.lblSearchMsg);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.tabContent);
            this.Controls.Add(this.cmbField);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAdd);
            this.MinimumSize = new System.Drawing.Size(716, 571);
            this.Name = "frmContent";
            this.Text = "Rental System - Content";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            this.Load += new System.EventHandler(this.frmContentLoad);
            this.tbRental.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRental)).EndInit();
            this.tbProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.tbStaff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.tbSupplier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).EndInit();
            this.tabContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TabPage tbRental;
        private System.Windows.Forms.DataGridView dgvRental;
        private System.Windows.Forms.TabPage tbProduct;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.TabPage tbStaff;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.TabPage tbSupplier;
        private System.Windows.Forms.DataGridView dgvSupplier;
        private System.Windows.Forms.TabControl tabContent;
        private System.Windows.Forms.Label lblSearchMsg;
    }
}