namespace PPSDPart2
{
    partial class frmAddSupplier
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(53, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(138, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(322, 84);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseCompatibleTextRendering = true;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(53, 32);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(138, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 35);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(36, 17);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email:";
            this.lblEmail.UseCompatibleTextRendering = true;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(53, 58);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(138, 20);
            this.txtTel.TabIndex = 2;
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(22, 61);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(23, 17);
            this.lblTel.TabIndex = 1;
            this.lblTel.Text = "Tel:";
            this.lblTel.UseCompatibleTextRendering = true;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(259, 6);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(138, 72);
            this.txtAddress.TabIndex = 3;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(205, 9);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(49, 17);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Address:";
            this.lblAddress.UseCompatibleTextRendering = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(241, 84);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseCompatibleTextRendering = true;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 112);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAddSupplier";
            this.Text = "Add Supplier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Button btnCancel;
    }
}