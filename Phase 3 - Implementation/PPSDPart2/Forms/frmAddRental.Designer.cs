namespace PPSDPart2
{
    partial class frmAddRental
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
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.Location = new System.Drawing.Point(80, 148);
            this.dtpReturnDate.MinDate = new System.DateTime(2012, 4, 21, 0, 0, 0, 0);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(189, 20);
            this.dtpReturnDate.TabIndex = 0;
            this.dtpReturnDate.Value = new System.DateTime(2012, 4, 21, 14, 30, 5, 0);
            this.dtpReturnDate.ValueChanged += new System.EventHandler(this.dtpReturnDate_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstItems);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Items";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // lstItems
            // 
            this.lstItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(3, 16);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(254, 81);
            this.lstItems.TabIndex = 0;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(278, 55);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "+";
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(278, 113);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(23, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "-";
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Location = new System.Drawing.Point(9, 151);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(68, 17);
            this.lblReturnDate.TabIndex = 4;
            this.lblReturnDate.Text = "Return Date:";
            this.lblReturnDate.UseCompatibleTextRendering = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(223, 219);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseCompatibleTextRendering = true;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(142, 219);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseCompatibleTextRendering = true;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(132, 182);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(33, 17);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total:";
            this.lblTotal.UseCompatibleTextRendering = true;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotal.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtTotal.Location = new System.Drawing.Point(172, 179);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 7;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(12, 9);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(43, 17);
            this.lblBranch.TabIndex = 9;
            this.lblBranch.Text = "Branch:";
            this.lblBranch.UseCompatibleTextRendering = true;
            // 
            // cboBranch
            // 
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(61, 6);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(121, 21);
            this.cboBranch.TabIndex = 8;
            this.cboBranch.SelectedIndexChanged += new System.EventHandler(this.cboBranch_SelectedIndexChanged);
            // 
            // frmAddRental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 254);
            this.ControlBox = false;
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblReturnDate);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpReturnDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAddRental";
            this.Text = "Add Rental";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cboBranch;
    }
}