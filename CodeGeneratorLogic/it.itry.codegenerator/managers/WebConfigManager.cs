using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Xml;

namespace it.itry.codegenerator.manager
{
    public class WebConfigManager
    {

        it.itry.codegenerator.classes.baseclass.Database m_db;
        public it.itry.codegenerator.classes.baseclass.Database Db { get { return m_db; } set { m_db = value; } }

        private WebConfigParameter m_parameter;

        public class WebConfigParameter
        {
            string m_dbUrl;
            public string DbUrl { get { return m_dbUrl; } set { m_dbUrl = value; } }

            string m_dbName;
            public string DbName { get { return m_dbName; } set { m_dbName = value; } }

            string m_userId;
            public string UserId { get { return m_userId; } set { m_userId = value; } }

            string m_password;
            public string Password { get { return m_password; } set { m_password = value; } }

            string m_smtp;
            public string SMTP { get { return m_smtp; } set { m_smtp = value; } }

            string m_mailFrom;
            public string MailFrom { get { return m_mailFrom; } set { m_mailFrom = value; } }

            string m_mailTo;
            public string MailTo { get { return m_mailTo; } set { m_mailTo = value; } }

            string m_mailBcc;
            public string MailBcc { get { return m_mailBcc; } set { m_mailBcc = value; } }

            string m_errorManager;
            public string ErrorManager { get { return m_errorManager; } set { m_errorManager = value; } }

            bool m_encryptPassword;
            public bool EncryptPassword { get { return m_encryptPassword; } set { m_encryptPassword = value; } }

            string m_sourcesPath;
            public string SourcesPath { get { return m_sourcesPath; } set { m_sourcesPath = value; } }

            string m_tipoDb;
            public string TipoDb { get { return m_tipoDb; } set { m_tipoDb = value; } }

            string m_tipoProvider;
            public string TipoProvider { get { return m_tipoProvider; } set { m_tipoProvider = value; } }

            string m_versioneDll;
            public string VersioneDll { get { return m_versioneDll; } set { m_versioneDll = value; } }


        }

        private WebConfigManager() { }
        public WebConfigManager(WebConfigParameter parameter, it.itry.codegenerator.classes.baseclass.Database db)
        {
            this.m_parameter = parameter;
            this.m_db = db;
        }

        public bool doCreateWebConfig()
        {
            // sw = null;

            using (StreamWriter sw = File.CreateText(m_parameter.SourcesPath + "\\web.config"))
            {
                sw.WriteLine("<?xml version=\"1.0\"?>");

                sw.WriteLine("<configuration>");
                
                sw.WriteLine("\t<configSections>");
                sw.WriteLine("\t\t<section name=\"ITryFrameworkDALConfig\" type=\"it.itryframework.config.DALConfigurationSection\" />");
                sw.WriteLine("\t\t<section name=\"ITryFrameworkMailConfig\" type=\"it.itryframework.config.MailConfigurationSection\" />");
                sw.WriteLine("\t\t<section name=\"ITryFrameworkErrorConfig\" type=\"it.itryframework.config.ErrorConfigurationSection\" />");
                sw.WriteLine("\t</configSections>");

                sw.Write("\t<ITryFrameworkDALConfig "+(m_parameter.EncryptPassword ? "decryptpwd=\""+m_parameter.EncryptPassword+"\"" : ""));

                if (m_parameter.VersioneDll.Equals(Utils.DLL_VERSIONE_2))
                {
                    sw.Write(" provider=\"(-->typeof(provider).AssemblyQualifiedName)\"");
                }
                else
                {
                    sw.Write("tipodb=\"" + getRightTipoDb(m_parameter.TipoDb)+"\"");
                }

                string pwd = m_parameter.Password;
                if (m_parameter.EncryptPassword)
                {
                    it.itryframework.managers.encryption.CryptoManager cryptoMng = new it.itryframework.managers.encryption.CryptoManager();
                    try
                    {
                        pwd = cryptoMng.setEncrypt(pwd);
                        m_parameter.Password = pwd;
                    }
                    catch (Exception ex)
                    {
                        pwd = m_parameter.Password;
                    }
                }

                string[] tokens = m_db.ConnectionString.Split(new char[] {';'},StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tokens.Length; i++)
                {
                    string token = tokens[i];
                    if (!token.StartsWith("pwd", StringComparison.InvariantCultureIgnoreCase)
                        && !token.StartsWith("password", StringComparison.InvariantCultureIgnoreCase)) continue;

                    string _pwd = token.Substring(token.IndexOf("=")+1);
                    m_db.ConnectionString = m_db.ConnectionString.Replace(_pwd, pwd);
                    break;
                    
                }

                sw.WriteLine(" connstring=\"" + m_db.ConnectionString + "\"/>");
                

                sw.WriteLine("\t<ITryFrameworkErrorConfig managerClassName=\"" + m_parameter.ErrorManager + "\" enable=\"True\" mailFrom=\"" + m_parameter.MailFrom + "\" mailTo=\"" + m_parameter.MailTo + "\" " + (!string.IsNullOrEmpty(m_parameter.MailBcc) ? " mailBcc=\"" + m_parameter.MailBcc + "\"" : "") + " smtp=\"" + m_parameter.SMTP + "\"/>");
                sw.WriteLine("\t<ITryFrameworkMailConfig smtp=\"" + m_parameter.SMTP + "\"/>");
                
                sw.WriteLine("</configuration>");

                sw.Close();
            }
            return true;
        }

        //private string _getConnectionString(WebConfigParameter param)
        //{
        //    if (param.TipoProvider.Equals(classes.baseclass.Database.PROVIDER_SQLCLIENT.ToLower()))
        //    {
        //        return " connstring=\"Data Source=" + param.DbUrl + ";Initial Catalog=" + param.DbName + ";Persist Security Info=True;User ID=" + param.UserId + ";Password=" + param.Password + "\"/>";
        //    }
        //    else if (param.TipoProvider.Equals(classes.baseclass.Database.PROVIDER_OLEDB.ToLower()))
        //    {
        //        return " tipo driver OLEDB, codice non ancora sviluppato";
        //    }
        //    else if (param.TipoProvider.Equals(classes.baseclass.Database.PROVIDER_ODBC.ToLower()))
        //    {
        //        return " tipo driver ODBC, codice non ancora sviluppato";
        //    }
        //    else if (param.TipoProvider.Equals(classes.baseclass.Database.PROVIDER_POSTGRES.ToLower()))
        //    {
        //        return " tipo driver POSTGRES, codice non ancora sviluppato";
        //    }
        //    else if (param.TipoProvider.Equals(classes.baseclass.Database.PROVIDER_MYSQLCONNECTORNET.ToLower()))
        //    {
        //        return " tipo driver MYSQL CONNECTOR NET, codice non ancora sviluppato";
        //    }
        //    else if (param.TipoProvider.Equals(classes.baseclass.Database.PROVIDER_MYSQLCONNECTORODBC.ToLower()))
        //    {
        //        return " tipo driver MYSQL CONNECTOR ODBC, codice non ancora sviluppato";
        //    }
        //    throw new Exception("provider non gestito");
        //}
        private string getRightTipoDb(string tipoDB)
        {
            if (tipoDB.ToLower().Equals(it.itry.codegenerator.classes.baseclass.Database.TIPO_DB_MSSQL.ToLower())) return "sql_server";
            else if (tipoDB.ToLower().Equals(it.itry.codegenerator.classes.baseclass.Database.TIPO_DB_MSACCESS.ToLower())) return "access";
            else if (tipoDB.ToLower().Equals(it.itry.codegenerator.classes.baseclass.Database.TIPO_DB_MYSQL.ToLower())) return "mysql";
            else if (tipoDB.ToLower().Equals(it.itry.codegenerator.classes.baseclass.Database.TIPO_DB_POSTGRES.ToLower())) return "postgres";
            else return String.Empty;
        }
    }
}
