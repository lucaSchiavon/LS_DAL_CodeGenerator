namespace CodeGenerator
{
    partial class CodeGeneratorForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDbTables = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ckListManagerPatterns = new System.Windows.Forms.CheckedListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnBrowe0 = new System.Windows.Forms.Button();
            this.txtDbOwner = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.lblDataSouce = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbTipoCodiceVb = new System.Windows.Forms.RadioButton();
            this.rbTipoCodiceCs = new System.Windows.Forms.RadioButton();
            this.gv = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbTipoDb = new System.Windows.Forms.ComboBox();
            this.cmbProviders = new System.Windows.Forms.ComboBox();
            this.lstMessaggi = new System.Windows.Forms.ListBox();
            this.btnCaricaTabelle = new System.Windows.Forms.Button();
            this.btnGenera = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuovoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ckbWebConfig = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDbTables);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.btnBrowe0);
            this.groupBox1.Controls.Add(this.txtDbOwner);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNamespace);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDataSource);
            this.groupBox1.Controls.Add(this.lblDataSouce);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtDestinationPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 427);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // cmbDbTables
            // 
            this.cmbDbTables.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbDbTables.FormattingEnabled = true;
            this.cmbDbTables.Location = new System.Drawing.Point(10, 147);
            this.cmbDbTables.Name = "cmbDbTables";
            this.cmbDbTables.Size = new System.Drawing.Size(216, 24);
            this.cmbDbTables.TabIndex = 19;
            this.cmbDbTables.Enter += new System.EventHandler(this.cmbDbTables_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Location = new System.Drawing.Point(10, 255);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(431, 100);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Design patterns";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ckListManagerPatterns);
            this.groupBox6.Location = new System.Drawing.Point(222, 23);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(199, 71);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Manager";
            // 
            // ckListManagerPatterns
            // 
            this.ckListManagerPatterns.FormattingEnabled = true;
            this.ckListManagerPatterns.Items.AddRange(new object[] {
            "Singleton"});
            this.ckListManagerPatterns.Location = new System.Drawing.Point(7, 23);
            this.ckListManagerPatterns.Name = "ckListManagerPatterns";
            this.ckListManagerPatterns.Size = new System.Drawing.Size(180, 40);
            this.ckListManagerPatterns.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(7, 23);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(209, 71);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Class";
            // 
            // btnBrowe0
            // 
            this.btnBrowe0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowe0.Location = new System.Drawing.Point(420, 49);
            this.btnBrowe0.Name = "btnBrowe0";
            this.btnBrowe0.Size = new System.Drawing.Size(27, 25);
            this.btnBrowe0.TabIndex = 17;
            this.btnBrowe0.Text = "....";
            this.btnBrowe0.UseVisualStyleBackColor = true;
            this.btnBrowe0.Visible = false;
            this.btnBrowe0.Click += new System.EventHandler(this.btnBrowe0_Click);
            // 
            // txtDbOwner
            // 
            this.txtDbOwner.Location = new System.Drawing.Point(232, 147);
            this.txtDbOwner.Name = "txtDbOwner";
            this.txtDbOwner.Size = new System.Drawing.Size(215, 23);
            this.txtDbOwner.TabIndex = 8;
            this.txtDbOwner.Text = "dbo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(229, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "DbOwner";
            // 
            // txtNamespace
            // 
            this.txtNamespace.AcceptsReturn = true;
            this.txtNamespace.Location = new System.Drawing.Point(10, 216);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(437, 23);
            this.txtNamespace.TabIndex = 9;
            this.txtNamespace.TabStop = false;
            this.txtNamespace.Text = "it.aquest";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Namespace";
            // 
            // txtPassword
            // 
            this.txtPassword.AcceptsReturn = true;
            this.txtPassword.Location = new System.Drawing.Point(232, 101);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(215, 23);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.Text = "d5fg!Op34";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "DB name";
            // 
            // txtDataSource
            // 
            this.txtDataSource.Location = new System.Drawing.Point(10, 49);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(409, 23);
            this.txtDataSource.TabIndex = 4;
            this.txtDataSource.Text = "212.35.214.45\\MSSQL02,3837";
            // 
            // lblDataSouce
            // 
            this.lblDataSouce.AutoSize = true;
            this.lblDataSouce.Location = new System.Drawing.Point(7, 29);
            this.lblDataSouce.Name = "lblDataSouce";
            this.lblDataSouce.Size = new System.Drawing.Size(85, 17);
            this.lblDataSouce.TabIndex = 8;
            this.lblDataSouce.Text = "Data source";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.Location = new System.Drawing.Point(420, 392);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(27, 25);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "....";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDestinationPath
            // 
            this.txtDestinationPath.Enabled = false;
            this.txtDestinationPath.Location = new System.Drawing.Point(10, 392);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.Size = new System.Drawing.Size(409, 23);
            this.txtDestinationPath.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destination Path";
            // 
            // txtUsername
            // 
            this.txtUsername.AcceptsReturn = true;
            this.txtUsername.Location = new System.Drawing.Point(10, 101);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(216, 23);
            this.txtUsername.TabIndex = 6;
            this.txtUsername.Text = "federico";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // rbTipoCodiceVb
            // 
            this.rbTipoCodiceVb.AutoSize = true;
            this.rbTipoCodiceVb.Location = new System.Drawing.Point(57, 19);
            this.rbTipoCodiceVb.Name = "rbTipoCodiceVb";
            this.rbTipoCodiceVb.Size = new System.Drawing.Size(70, 21);
            this.rbTipoCodiceVb.TabIndex = 13;
            this.rbTipoCodiceVb.Text = "VB.Net";
            this.rbTipoCodiceVb.UseVisualStyleBackColor = true;
            // 
            // rbTipoCodiceCs
            // 
            this.rbTipoCodiceCs.AutoSize = true;
            this.rbTipoCodiceCs.Checked = true;
            this.rbTipoCodiceCs.Location = new System.Drawing.Point(12, 18);
            this.rbTipoCodiceCs.Name = "rbTipoCodiceCs";
            this.rbTipoCodiceCs.Size = new System.Drawing.Size(43, 21);
            this.rbTipoCodiceCs.TabIndex = 12;
            this.rbTipoCodiceCs.TabStop = true;
            this.rbTipoCodiceCs.Text = "C#";
            this.rbTipoCodiceCs.UseVisualStyleBackColor = true;
            // 
            // gv
            // 
            this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv.Location = new System.Drawing.Point(12, 51);
            this.gv.Name = "gv";
            this.gv.Size = new System.Drawing.Size(538, 272);
            this.gv.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbTipoDb);
            this.groupBox2.Controls.Add(this.cmbProviders);
            this.groupBox2.Location = new System.Drawing.Point(319, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 89);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Db and providers";
            // 
            // cmbTipoDb
            // 
            this.cmbTipoDb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDb.FormattingEnabled = true;
            this.cmbTipoDb.Location = new System.Drawing.Point(5, 22);
            this.cmbTipoDb.Name = "cmbTipoDb";
            this.cmbTipoDb.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoDb.TabIndex = 11;
            this.cmbTipoDb.SelectionChangeCommitted += new System.EventHandler(this.cmbTipoDb_SelectionChangeCommitted);
            // 
            // cmbProviders
            // 
            this.cmbProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProviders.FormattingEnabled = true;
            this.cmbProviders.Location = new System.Drawing.Point(5, 50);
            this.cmbProviders.Name = "cmbProviders";
            this.cmbProviders.Size = new System.Drawing.Size(121, 21);
            this.cmbProviders.TabIndex = 10;
            // 
            // lstMessaggi
            // 
            this.lstMessaggi.FormattingEnabled = true;
            this.lstMessaggi.Location = new System.Drawing.Point(477, 456);
            this.lstMessaggi.Name = "lstMessaggi";
            this.lstMessaggi.Size = new System.Drawing.Size(561, 95);
            this.lstMessaggi.TabIndex = 16;
            // 
            // btnCaricaTabelle
            // 
            this.btnCaricaTabelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaricaTabelle.Location = new System.Drawing.Point(11, 19);
            this.btnCaricaTabelle.Name = "btnCaricaTabelle";
            this.btnCaricaTabelle.Size = new System.Drawing.Size(112, 26);
            this.btnCaricaTabelle.TabIndex = 14;
            this.btnCaricaTabelle.Text = "Carica tabelle";
            this.btnCaricaTabelle.UseVisualStyleBackColor = true;
            this.btnCaricaTabelle.Click += new System.EventHandler(this.btnCaricaTabelle_Click);
            // 
            // btnGenera
            // 
            this.btnGenera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenera.Location = new System.Drawing.Point(12, 45);
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.Size = new System.Drawing.Size(87, 27);
            this.btnGenera.TabIndex = 15;
            this.btnGenera.Text = "Genera";
            this.btnGenera.UseVisualStyleBackColor = true;
            this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1048, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoToolStripMenuItem,
            this.esciToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // nuovoToolStripMenuItem
            // 
            this.nuovoToolStripMenuItem.Name = "nuovoToolStripMenuItem";
            this.nuovoToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.nuovoToolStripMenuItem.Text = "Nuovo";
            this.nuovoToolStripMenuItem.Click += new System.EventHandler(this.nuovoToolStripMenuItem_Click_1);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.esciToolStripMenuItem.Text = "Esci";
            this.esciToolStripMenuItem.Click += new System.EventHandler(this.esciToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gv);
            this.groupBox3.Controls.Add(this.btnCaricaTabelle);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(475, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(563, 341);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Generator";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "File mdb|*.mdb";
            // 
            // ckbWebConfig
            // 
            this.ckbWebConfig.AutoSize = true;
            this.ckbWebConfig.Location = new System.Drawing.Point(146, 18);
            this.ckbWebConfig.Name = "ckbWebConfig";
            this.ckbWebConfig.Size = new System.Drawing.Size(149, 21);
            this.ckbWebConfig.TabIndex = 22;
            this.ckbWebConfig.Text = "genera Web.Config";
            this.ckbWebConfig.UseVisualStyleBackColor = true;
            this.ckbWebConfig.CheckedChanged += new System.EventHandler(this.ckbWebConfig_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ckbWebConfig);
            this.groupBox7.Controls.Add(this.btnGenera);
            this.groupBox7.Controls.Add(this.rbTipoCodiceCs);
            this.groupBox7.Controls.Add(this.rbTipoCodiceVb);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(475, 374);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(563, 74);
            this.groupBox7.TabIndex = 23;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Opzioni";
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(12, 28);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(296, 89);
            this.groupBox8.TabIndex = 24;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "(per sviluppi futuri)";
            // 
            // CodeGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 556);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lstMessaggi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "CodeGeneratorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeGeneratorForm";
            this.Load += new System.EventHandler(this.CodeGeneratorForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenera;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnCaricaTabelle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.Label lblDataSouce;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.ListBox lstMessaggi;
        private System.Windows.Forms.TextBox txtDbOwner;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbTipoCodiceVb;
        private System.Windows.Forms.RadioButton rbTipoCodiceCs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuovoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBrowe0;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbProviders;
        private System.Windows.Forms.CheckBox ckbWebConfig;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckedListBox ckListManagerPatterns;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.ComboBox cmbDbTables;
        private System.Windows.Forms.ComboBox cmbTipoDb;
        private System.Windows.Forms.GroupBox groupBox8;
    }
}