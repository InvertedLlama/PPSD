namespace PPSDPart2
{
    partial class frmAddMember
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(160, 227);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseCompatibleTextRendering = true;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSumbit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(63, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseCompatibleTextRendering = true;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(63, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(172, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 17);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(63, 38);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(172, 20);
            this.txtTel.TabIndex = 2;
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(28, 41);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(23, 17);
            this.lblTel.TabIndex = 2;
            this.lblTel.Text = "Tel:";
            this.lblTel.UseCompatibleTextRendering = true;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(63, 64);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(172, 20);
            this.txtMobile.TabIndex = 3;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(16, 67);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(41, 17);
            this.lblMobile.TabIndex = 2;
            this.lblMobile.Text = "Mobile:";
            this.lblMobile.UseCompatibleTextRendering = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(63, 90);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(172, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(22, 96);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(36, 17);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";
            this.lblEmail.UseCompatibleTextRendering = true;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(63, 116);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(172, 105);
            this.txtAddress.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(9, 119);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(49, 17);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address:";
            this.lblAddress.UseCompatibleTextRendering = true;
            // 
            // frmAddMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(243, 262);
            this.ControlBox = false;
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAddMember";
            this.Text = "Add Member";
            this.VisibleChanged += new System.EventHandler(this.frmAddMember_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
    }
}