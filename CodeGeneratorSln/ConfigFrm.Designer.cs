namespace CodeGenerator
{
    partial class ConfigFrm
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
            this.txtErrMailFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtErrMailTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtErrMailBcc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSmtp = new System.Windows.Forms.TextBox();
            this.ckbCriptPwd = new System.Windows.Forms.CheckBox();
            this.btnSalva = new System.Windows.Forms.Button();
            this.cmbErrorManagers = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbVersioneDll = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtErrMailFrom
            // 
            this.txtErrMailFrom.Location = new System.Drawing.Point(12, 70);
            this.txtErrMailFrom.Name = "txtErrMailFrom";
            this.txtErrMailFrom.Size = new System.Drawing.Size(194, 20);
            this.txtErrMailFrom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Error notification mail from *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Error notification mail to *";
            // 
            // txtErrMailTo
            // 
            this.txtErrMailTo.Location = new System.Drawing.Point(13, 109);
            this.txtErrMailTo.Name = "txtErrMailTo";
            this.txtErrMailTo.Size = new System.Drawing.Size(193, 20);
            this.txtErrMailTo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Error notification mail bcc";
            // 
            // txtErrMailBcc
            // 
            this.txtErrMailBcc.Location = new System.Drawing.Point(13, 148);
            this.txtErrMailBcc.Name = "txtErrMailBcc";
            this.txtErrMailBcc.Size = new System.Drawing.Size(193, 20);
            this.txtErrMailBcc.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Notification SMTP *";
            // 
            // txtSmtp
            // 
            this.txtSmtp.Location = new System.Drawing.Point(12, 187);
            this.txtSmtp.Name = "txtSmtp";
            this.txtSmtp.Size = new System.Drawing.Size(194, 20);
            this.txtSmtp.TabIndex = 7;
            // 
            // ckbCriptPwd
            // 
            this.ckbCriptPwd.AutoSize = true;
            this.ckbCriptPwd.Location = new System.Drawing.Point(13, 277);
            this.ckbCriptPwd.Name = "ckbCriptPwd";
            this.ckbCriptPwd.Size = new System.Drawing.Size(97, 17);
            this.ckbCriptPwd.TabIndex = 8;
            this.ckbCriptPwd.Text = "crypt password";
            this.ckbCriptPwd.UseVisualStyleBackColor = true;
            // 
            // btnSalva
            // 
            this.btnSalva.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalva.Location = new System.Drawing.Point(58, 300);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(99, 23);
            this.btnSalva.TabIndex = 9;
            this.btnSalva.Text = "Salva e chiudi";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // cmbErrorManagers
            // 
            this.cmbErrorManagers.FormattingEnabled = true;
            this.cmbErrorManagers.Location = new System.Drawing.Point(12, 28);
            this.cmbErrorManagers.Name = "cmbErrorManagers";
            this.cmbErrorManagers.Size = new System.Drawing.Size(194, 21);
            this.cmbErrorManagers.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Error provider *";
            // 
            // cmbVersioneDll
            // 
            this.cmbVersioneDll.FormattingEnabled = true;
            this.cmbVersioneDll.Location = new System.Drawing.Point(12, 235);
            this.cmbVersioneDll.Name = "cmbVersioneDll";
            this.cmbVersioneDll.Size = new System.Drawing.Size(194, 21);
            this.cmbVersioneDll.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Versione libreria";
            // 
            // ConfigFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 343);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbVersioneDll);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbErrorManagers);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.ckbCriptPwd);
            this.Controls.Add(this.txtSmtp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtErrMailBcc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtErrMailTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtErrMailFrom);
            this.MaximizeBox = false;
            this.Name = "ConfigFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfigFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtErrMailFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtErrMailTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtErrMailBcc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSmtp;
        private System.Windows.Forms.CheckBox ckbCriptPwd;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.ComboBox cmbErrorManagers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbVersioneDll;
        private System.Windows.Forms.Label label6;
    }
}