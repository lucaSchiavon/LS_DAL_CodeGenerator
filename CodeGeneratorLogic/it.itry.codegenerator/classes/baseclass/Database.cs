using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace it.itry.codegenerator.classes.baseclass
{
    public abstract class Database
    {
        #region costanti
        public const string TIPO_DB_MSSQL = "MsSql";
        public const string TIPO_DB_MSACCESS = "MsAccess";
        public const string TIPO_DB_MYSQL = "MySql";
        public const string TIPO_DB_POSTGRES = "PostGres";

        public const string PROVIDER_SQLCLIENT = "SqlClient";
        public const string PROVIDER_OLEDB = "OleDb";
        public const string PROVIDER_ODBC = "Odbc";
        public const string PROVIDER_POSTGRES = "Postgres";
        public const string PROVIDER_MYSQLCONNECTORODBC = "MySqlConnectorOdbc";
        public const string PROVIDER_MYSQLCONNECTORNET = "MySqlConnectorNet";

        protected const string SC_DATABASES = "Databases";
        protected const string SC_TABLES = "Tables";
        protected const string SC_COLUMNS = "Columns";
        #endregion

        #region PROPERTIES
        private string m_connectionString;
        public string ConnectionString
        {
            get { return m_connectionString; }
            set { m_connectionString = value; }
        }
        private System.Data.Common.DbConnection m_dbConnection;
        protected System.Data.Common.DbConnection DbConnection
        {
            get { return m_dbConnection; }
            set { m_dbConnection = value; }
        }
        private string m_tipoDb;
        protected string TipoDb
        {
            get { return m_tipoDb; }
            set { m_tipoDb = value; }
        }
        private string m_provider;
        protected string Provider
        {
            get { return m_provider; }
            set { m_provider = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Database() 
        {
        }
        #endregion

        #region PUBLIC METHODS
        #region setParam
        /// <summary>
        /// Setta i parametri necessari per la connessione al database.
        /// </summary>
        /// <param name="tipoDb"></param>
        /// <param name="provider">provider da utilizzare</param>
        /// <param name="dataSource">datasource</param>
        /// <param name="dbName">nome del db o percorso completo al db con nome db</param>
        /// <param name="userId">user id</param>
        /// <param name="password">password</param>
        public void setParam(string tipoDb, string provider, string dataSource, string dbName, string userId, string password)
        {
            m_provider = provider;
            m_tipoDb = tipoDb;

            if (m_tipoDb.ToLower().Equals(TIPO_DB_MSSQL.ToLower()))
            {
                //vari provider
                if (provider.ToLower().Equals(PROVIDER_SQLCLIENT.ToLower()))
                {
                    m_connectionString = "Data Source=" + dataSource + ";Initial Catalog=" + dbName + ";User Id=" + userId + ";Password="+password;
                    DbConnection = new System.Data.SqlClient.SqlConnection();
                }
            }
            else if (m_tipoDb.ToLower().Equals(TIPO_DB_MSACCESS.ToLower()))
            {
                if (provider.Equals(PROVIDER_OLEDB,StringComparison.InvariantCultureIgnoreCase))
                {
                    m_connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dataSource + ";Uid=" + userId + ";Pwd=" + password;
                    DbConnection = new System.Data.OleDb.OleDbConnection();
                }
                else if (provider.Equals(PROVIDER_ODBC,StringComparison.InvariantCultureIgnoreCase))
                {
                    m_connectionString = "Driver={Microsoft Access Driver (*.mdb)};Dbq=" + dataSource + ";Uid=" + userId + ";Pwd=" + password+";";
                    DbConnection = new System.Data.Odbc.OdbcConnection();
                }
            }
            else if (m_tipoDb.Equals(TIPO_DB_MYSQL,StringComparison.InvariantCultureIgnoreCase))
            {
                if (provider.Equals(PROVIDER_MYSQLCONNECTORODBC, StringComparison.InvariantCultureIgnoreCase))
                {
                    m_connectionString = "Driver={MySQL ODBC 5.1 Driver};Server=" + dataSource + ";Port=5432;Database=" + dbName + ";Uid=" + userId + ";Pwd="+password+";";
                    DbConnection = new System.Data.Odbc.OdbcConnection();
                }
                else if (provider.Equals(PROVIDER_MYSQLCONNECTORNET, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new NotSupportedException();
                }
            }
            else if (m_tipoDb.Equals(TIPO_DB_POSTGRES, StringComparison.InvariantCultureIgnoreCase))
            {
                //test
                m_connectionString = "Driver={PostgreSQL ANSI};Server=localhost;Port=5432;Database=test;Uid=postgres;Pwd=postgres;";
                DbConnection = new System.Data.Odbc.OdbcConnection();
            }
        } 
        #endregion

        #region getPrimaryKey
        public virtual List<string> getPrimaryKey(string tableName)
        {
            return _getKeys(tableName, true);
        }
        #endregion

        #region getForeignKeys
        public List<string> getForeignKeys(string tableName)
        {
            return _getKeys(tableName, false);
        }
        #endregion
        #endregion

        #region protected methods
        #region setOpenConnection
        /// <summary>
        /// Apre una connessione a database.
        /// </summary>
        /// <exception cref="Exception"></exception>
        protected void setOpenConnection()
        {
            try
            {
                DbConnection.ConnectionString = ConnectionString;
                DbConnection.Open();
            }
            catch (Exception ex)
            {
                if (DbConnection != null) DbConnection.Close();
                throw ex;
            }
        }
        #endregion
        //protected string[] getValues(DataTable dt)
        //{
        //    if (dt.Rows.Count == 0) return null;
        //    List<string> list = new List<string>();
        //    dt.DefaultView.Sort = dt.Columns[0].ColumnName;

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        DataRow row = dt.Rows[i];
        //        list.Add(Convert.ToString(row[0]));
        //    }
        //    list.Sort();
        //    return list.ToArray();
        //}
        //protected DataTable getValuesFromSchema(string schema, string tableName)
        //{
        //    string[] restrictions = null;
        //    DataTable dt = null;
        //    if (schema.ToLower().Equals("columns"))
        //    {

        //    }
        //    else if (schema.ToLower().Equals("columns"))
        //    {

        //    }
        //    else if (schema.ToLower().Equals("columns"))
        //    {
        //        restrictions = new string[4];
        //        restrictions[2] = tableName;
        //    }
        //    dt = getSchema(schema, restrictions);
        //    return dt;
        //}

        /// <summary>
        /// ...
        /// </summary> 
        /// <exception cref="Exception"></exception>
        protected DataTable getSchema(string schema, string[] restrictions)
        {
            DataTable dt;
            setOpenConnection();
            using (DbConnection)
            {
                try
                {
                    dt = DbConnection.GetSchema(schema, restrictions);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (DbConnection != null) DbConnection.Close();
                }
            }
            return dt;
        }

        /// <summary>
        /// ...
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public virtual DataTable getDatabases()
        {
            DataTable dt = getSchema(SC_DATABASES, null);
            dt.DefaultView.Sort = "database_name";
            return dt;
        }
        public virtual DataTable getTables(string dbName)
        {
            DataTable dt = getSchema(SC_TABLES, new string[4] { dbName, null, null, "BASE TABLE" });
            dt.DefaultView.Sort = "TABLE_NAME";
            return dt;
        }
        public virtual DataTable getColumns(string dbName,string tableName)
        {
            return getSchema(SC_COLUMNS, new string[4] { dbName, null, tableName, null });
        }
        #endregion

        #region private methods
        private List<string> _getKeys(string tableName, bool getPrimaryKey)
        {
            setOpenConnection();
            System.Data.Common.DbCommand cmd = DbConnection.CreateCommand();
            System.Text.StringBuilder s = new StringBuilder("SELECT c.column_name");
            s.Append(" FROM information_schema.table_constraints pk ,information_schema.key_column_usage c");
            s.Append(" WHERE c.table_name=pk.table_name");
            s.Append(" AND c.constraint_name = pk.constraint_name");
            s.Append(" AND (pk.constraint_type = '" + (getPrimaryKey ? "PRIMARY KEY" : "FOREIGN KEY") + "')");
            s.Append(" AND pk.TABLE_NAME ='" + tableName + "'");

            cmd.CommandText = s.ToString();

            System.Data.IDataReader reader = null;
            try { reader = cmd.ExecuteReader(); }
            catch (Exception ex)
            { 
                DbConnection.Close();
                throw ex;
            }
            List<string> list = new List<string>();
            using (reader)
            {
                while (reader.Read())
                {
                    list.Add(reader[0].ToString());           
                }
                reader.Close();
                DbConnection.Close();
            }
            return list;
        }
        #endregion

    }
}
