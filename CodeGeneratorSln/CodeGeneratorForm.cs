using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using it.itry.codegenerator.enums;

namespace CodeGenerator
{
    public partial class CodeGeneratorForm : BaseForm 
    {

        it.itry.codegenerator.classes.baseclass.Database m_database = null;
        ConfigFrm m_configFrm = null;
        it.itry.codegenerator.manager.WebConfigManager.WebConfigParameter m_webParameters = null;

        public CodeGeneratorForm()
        {
            InitializeComponent();
            m_configFrm = new ConfigFrm();
            m_configFrm.OnSettedConfiParamsEventArgs += new OnSettedConfiParamsHandler(configFrm_OnSettedConfiParamsEventArgs);
            Application.EnableVisualStyles();
            _setSupportedDatabase();
        }
        void CodeGeneratorForm_Load(object sender, System.EventArgs e)
        {
            //btnGenera.Enabled = false;
        }

        #region METHODS
        #region reload
        private void reload()
        {
            //txtDataSource.Text = String.Empty;
            cmbDbTables.Items.Clear();
            //txtDbOwner.Text = String.Empty;
            //txtNamespace.Text = String.Empty;
            //txtPassword.Text = String.Empty;
            //txtUsername.Text = String.Empty;
            lstMessaggi.Items.Clear();
            gv.Rows.Clear();
            cmbTipoDb.SelectedIndex = 0;
            cmbProviders.Items.Clear();
            ckListManagerPatterns.SelectedIndex = 0;
        } 
        #endregion

        #region setDatabase
		private void setDatabase()
        {
            m_database = it.itry.codegenerator.factory.DatabaseFactory.getDatabase((string)cmbTipoDb.SelectedItem);
            m_database.setParam((string)cmbTipoDb.SelectedItem,(string)cmbProviders.SelectedItem, txtDataSource.Text, (cmbDbTables.SelectedItem == null ? String.Empty : cmbDbTables.SelectedItem.ToString()), txtUsername.Text, txtPassword.Text);
        } 
	    #endregion

        #region CONTROLLI DATI UTENTE
        private bool isOk()
        {
            if (cmbProviders.SelectedIndex==0)
            {
                showError("Controllare d'aver inserito tutti i campi", true);
                return false;
            }
            if (txtDestinationPath.Text == "")
            {
                showError("Inserire la destinazione", true);
                return false;
            }
            return true;
        }
        private void showError(string message, bool isError)
        {
            this.Cursor = Cursors.Default;
            if (isError) { MessageBox.Show(message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else { }
        }
        #endregion
        #endregion

        #region EVENTS
        
        private void nuovoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            reload();
        }
        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region SCELTA DI GENERARE IL WEB.CONFIG
        private void ckbWebConfig_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbWebConfig.Checked)
            {
                DialogResult result = m_configFrm.ShowDialog();
            }
        } 
        #endregion

        #region genera codice
        private void btnGenera_Click(object sender, EventArgs e)
        {
            if (!isOk()) return;
            it.itry.codegenerator.classes.baseclass.GenericFile gFile=null;
            gFile = it.itry.codegenerator.factory.CodeFileFactory.getCodeFile((rbTipoCodiceCs.Checked) ? enTipoFile.CSHARP : enTipoFile.VB, m_database);
            gFile.CustomNamespace = txtNamespace.Text;
            gFile.Path = txtDestinationPath.Text;

            #region creazione classi in base alle tabelle selezionate dall'elenco tabelle
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                bool isChecked = Convert.ToBoolean(gv[1, i].Value);  //la checkbox
                if (!isChecked) continue;
                string originalTblName = gv[0, i].Value.ToString();   //nome originale della tabella
                string customTblName = Convert.ToString(gv[2, i].Value);   //nome custom per la tabella
                if (string.IsNullOrEmpty(customTblName)) customTblName = originalTblName;

                System.Collections.Specialized.StringCollection msgList = new System.Collections.Specialized.StringCollection();

                DataTable dt = null;
                try { dt = m_database.getColumns(cmbDbTables.SelectedItem.ToString(), originalTblName); }
                catch (Exception ex) { showError(ex.Message, true); return; };


                try
                {
                    gFile.doCreateFile(dt, customTblName, msgList);
                    string itemUseSingleton = null;
                    if (ckListManagerPatterns.SelectedItems.Count > 0)
                    {
                        itemUseSingleton = Convert.ToString(ckListManagerPatterns.SelectedItems[0]);
                    }
                    gFile.doCreateManager(msgList, !string.IsNullOrEmpty(itemUseSingleton));
                }
                catch (Exception ex)
                {
                    base.setError(ex.Message + Environment.NewLine + ex.Source + ex.StackTrace);
                    return;
                }

                for (int idx = 0; idx < msgList.Count; idx++)
                {
                    lstMessaggi.Items.Add(msgList[idx]);
                }
            }
            #endregion
            
            if (m_webParameters != null)
            {
                m_webParameters.TipoProvider = (string)cmbProviders.SelectedItem;
                m_webParameters.TipoDb = (string)cmbTipoDb.SelectedItem;
                if (cmbDbTables.Enabled) m_webParameters.DbName = cmbDbTables.SelectedItem.ToString();
                m_webParameters.DbUrl = txtDataSource.Text;
                m_webParameters.Password = txtPassword.Text;
                m_webParameters.UserId = txtUsername.Text;
                m_webParameters.SourcesPath = txtDestinationPath.Text + "\\" + it.itry.codegenerator.Utils.getCodeGeneratorDirName();
                it.itry.codegenerator.manager.WebConfigManager mng = new it.itry.codegenerator.manager.WebConfigManager(m_webParameters, m_database);
                try
                {
                    mng.doCreateWebConfig();
                    lstMessaggi.Items.Add("web.config creato con successo.");
                }
                catch (Exception ex)
                {
                    lstMessaggi.Items.Add("Impossibile generare web.config." + Environment.NewLine + "Errore: " + ex.Message);
                }
            }
        }


        #endregion

        #region carica le tabelle del db scelto
        private void btnCaricaTabelle_Click(object sender, EventArgs e)
        {
            if (!isOk()) return;
            gv.Rows.Clear();
            gv.Columns.Clear();
            setDatabase();

            gv.AllowUserToAddRows = false;
            gv.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(gv_ColumnHeaderMouseClick);

            DataTable dtTables = null;
            try
            {
                dtTables = m_database.getTables(cmbDbTables.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                base.setError(ex.Message + Environment.NewLine + ex.Source);
                return;
            }
            gv.Columns.Add("colTableName", "Name");
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.HeaderText = "Click to select all";
            gv.Columns.Add(col);
            
            DataGridViewTextBoxColumn tCol = new DataGridViewTextBoxColumn();
            tCol.HeaderText = "Custom name";
            gv.Columns.Add(tCol);

            foreach (DataRow row in dtTables.Rows)
            {
                gv.Rows.Add(new object[] { row["TABLE_NAME"].ToString() });
            }

        }

        void gv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                gv.Columns[1].HeaderText = "Click to deselect all";
                //checkbox column
                for (int i = 0; i < gv.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell cell=(DataGridViewCheckBoxCell)gv.Rows[i].Cells[1];
                    cell.Value= (Convert.ToInt32(cell.Value) == 1 ? 0 : 1);
                }
            }
        } 
        #endregion

        #endregion

        #region CHECKBOXES EVENTS
        private void rbSqlConnection_CheckedChanged(object sender, EventArgs e)
        {
            lblDataSouce.Text = "Data source";
            cmbDbTables.Enabled = true;
            btnBrowe0.Visible = false;
        }

        private void rbOleDbConnection_CheckedChanged(object sender, EventArgs e)
        {
            lblDataSouce.Text = "Data source";
            cmbDbTables.Enabled = false;
            btnBrowe0.Visible = true;
        }

        private void rbOdbcConnection_CheckedChanged(object sender, EventArgs e)
        {
            lblDataSouce.Text = "Database path";
            cmbDbTables.Enabled = false;
            btnBrowe0.Visible = true;
        }
        #endregion

        #region BROWSE EVENTS
        private void btnBrowe0_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDataSource.Text = openFileDialog1.FileName;
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDestinationPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        #endregion

        #region SCELTA DEL TIPO DI PROVIDER
        //private void cmbProviders_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbProviders.SelectedItem == null) return;
        //    if (cmbProviders.SelectedItem.ToString().Equals("seleziona")) return;

        //    m_tipoDriver=(enTipoDriver)Enum.Parse(typeof(it.itry.codegenerator.enums.enTipoDriver), cmbProviders.SelectedItem.ToString());
        //    switch (m_tipoDriver)
        //    {
        //        case enTipoDriver.SqlClient:
        //            rbSqlConnection.Visible = rbOdbcConnection.Visible=rbOleDbConnection.Visible=true;
        //            break;
        //        case enTipoDriver.OleDb:
        //            rbSqlConnection.Visible = rbOdbcConnection.Visible = false;
        //            rbOleDbConnection.Visible = true;
        //            break;
        //        case enTipoDriver.Odbc:
        //            rbSqlConnection.Visible = rbOleDbConnection.Visible = false;
        //            rbOdbcConnection.Visible = true;
        //            break;
        //        default:
        //            break;
        //    }
        //}
        #endregion

        #region caricamento e scelta di un tipo di database
        private void _setSupportedDatabase()
        {
            cmbTipoDb.Items.Insert(0, "seleziona");
            string[] arr = it.itry.codegenerator.Utils.getSupportedDatabases(); 
            for (int i = 0; i < arr.Length; i++)
            {
                cmbTipoDb.Items.Insert(i+1,arr[i]);
            }
            cmbTipoDb.SelectedIndex = 0;
        } 
        private void cmbTipoDb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbProviders.Items.Clear();
            List<string> listProviders = it.itry.codegenerator.Utils.getProvidersByTipoDb(Convert.ToString(cmbTipoDb.SelectedItem));
            cmbProviders.Items.Insert(0, "seleziona");
            int idx = 1;
            foreach (string provider in listProviders)
            {
                cmbProviders.Items.Insert(idx, provider);
                idx++;
            }
            cmbProviders.SelectedIndex = 0;

            if (Convert.ToString(cmbTipoDb.SelectedItem).ToLower().Equals(
                it.itry.codegenerator.classes.baseclass.Database.TIPO_DB_MSACCESS.ToLower())
                )
            {
                btnBrowe0.Visible = true;
                cmbDbTables.Enabled = false;
            }
        }
        #endregion

        #region scelta delle tabelle presenti nel db selezionato
        private void cmbDbTables_Enter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //carica le tabella del db scelto
            if (cmbProviders.SelectedItem == null) return;
            if (cmbProviders.SelectedItem.ToString().Equals("seleziona")) return;
            cmbDbTables.Items.Clear();
            setDatabase();
            DataTable dt = null;
            try { dt = m_database.getDatabases(); }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                base.setError(ex.Message);
                return;
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    cmbDbTables.Items.Add(row[0].ToString());
                }
            }
            else
            {

            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        void configFrm_OnSettedConfiParamsEventArgs(object sender, OnSettedConfiParamsEventArgs e)
        {
            m_webParameters = new it.itry.codegenerator.manager.WebConfigManager.WebConfigParameter();
            m_webParameters.EncryptPassword = e.CryptPassword;
            m_webParameters.MailFrom = e.MailFrom;
            m_webParameters.MailTo = e.MailTo;
            m_webParameters.MailBcc = e.MailBcc;
            m_webParameters.SMTP = e.Smtp;
            m_webParameters.VersioneDll = e.VersioneDll;
            m_webParameters.ErrorManager = e.ErrorManager;
        }
    }
}