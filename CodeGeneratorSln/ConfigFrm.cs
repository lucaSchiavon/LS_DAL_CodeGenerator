using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeGenerator
{
    
    public partial class ConfigFrm : Form
    {
        public event OnSettedConfiParamsHandler OnSettedConfiParamsEventArgs;

        public ConfigFrm()
        {
            InitializeComponent();
            _setLoadDdlErrorProviders();
            _setCmbVersioniDll();
        }

        private void _setLoadDdlErrorProviders()
        {
            Type tipo=typeof(it.itryframework.managers.log.MailLogManager);
            cmbErrorManagers.Items.Add(tipo.FullName);
            cmbErrorManagers.SelectedIndex = 0;
        }

        #region caricamento versioni libreria
        private void _setCmbVersioniDll()
        {
            string[] arr = it.itry.codegenerator.Utils.getVersioniDll();
            for (int i = 0; i < arr.Length; i++)
            {
                cmbVersioneDll.Items.Insert(i, arr[i]);
            }
            cmbVersioneDll.SelectedIndex = 0;
        }
        #endregion

        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (OnSettedConfiParamsEventArgs != null) OnSettedConfiParamsEventArgs(this, 
                                                        new OnSettedConfiParamsEventArgs(cmbErrorManagers.SelectedItem.ToString()
                                                                                         ,txtErrMailFrom.Text
                                                                                         ,txtErrMailTo.Text
                                                                                         ,txtErrMailBcc.Text
                                                                                         ,txtSmtp.Text
                                                                                         ,cmbVersioneDll.SelectedItem.ToString()
                                                                                         ,ckbCriptPwd.Checked));
        }

        

        
    }

    public delegate void OnSettedConfiParamsHandler(object sender, OnSettedConfiParamsEventArgs e);

    public class OnSettedConfiParamsEventArgs : EventArgs
    {
        string m_errorManager;
        public string ErrorManager { get { return m_errorManager; } set { m_errorManager = value; } }
        string m_mailFrom;
        public string MailFrom { get { return m_mailFrom; } set { m_mailFrom = value; } }
        string m_mailTo;
        public string MailTo { get { return m_mailTo; } set { m_mailTo = value; } }
        string m_mailBcc;
        public string MailBcc { get { return m_mailBcc; } set { m_mailBcc = value; } }
        string m_smtp;
        public string Smtp { get { return m_smtp; } set { m_smtp = value; } }
        string m_versioneDll;
        public string VersioneDll { get { return m_versioneDll; } set { m_versioneDll = value; } }
        bool m_cryptPwd;
        public bool CryptPassword { get { return m_cryptPwd; } set { m_cryptPwd = value; } }

        public OnSettedConfiParamsEventArgs(string errorManager, string mailFrom, string mailTo, string mailBcc, string smtp, string versioneDll, bool cryptPassword)
        {
            this.m_errorManager = errorManager;
            this.m_mailFrom = mailFrom;
            this.m_mailTo = mailTo;
            this.m_mailBcc = mailBcc;
            this.m_smtp = smtp;
            this.m_versioneDll = versioneDll;
            this.m_cryptPwd = cryptPassword;
        }
    }
}
