using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using it.itry.codegenerator.enums;
using it.itry.codegenerator.exceptions;

namespace DLL.classes
{
    public class CodeGeneratord
    {
        #region OLD MA IN ESECUZIONE (DA SISTEMARE)
        private IDbConnection m_dbConn = null;
        //private string m_owner = "dbo";
        //private string m_customNamespace = "it.aquest";
        //private string m_metaTableName = null; 
        //private string m_metaColumnName = null; 
        //private string m_metaDataTypeName = null;
        //private string m_metaIndexesName = null;

        private static CodeGeneratord instance = null;
        private CodeGeneratord() { }
        public static CodeGeneratord getInstance()
        {
            if (instance == null) instance = new CodeGeneratord();
            return instance;
        }

        //public void setInitParam(string dbAddress, string dbName, string userName, string password, string owner, string customNamespace, DLL.enums.enTipoProvider tipoProvider)
        //{
        //    if (tipoProvider == enTipoProvider.MSSQL)
        //    {
        //        m_dbConn = new SqlConnection();
        //        m_dbConn.ConnectionString = "Data Source=" + dbAddress + ";Initial Catalog=" + dbName + ";User Id=" + userName + ";Password=" + password + ";";
        //        m_metaTableName = "TABLE_NAME";
        //        m_metaColumnName = "COLUMN_NAME";
        //        m_metaDataTypeName = "DATA_TYPE";
        //    }
        //    else if (tipoProvider == enTipoProvider.OLEDB)
        //    {
        //        m_dbConn = new OleDbConnection();
        //        m_dbConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+dbAddress+";Uid="+userName+"PWD="+password;
        //        m_metaTableName = "TABLE_NAME";
        //        m_metaColumnName = "COLUMN_NAME";
        //        m_metaDataTypeName = "DATA_TYPE";
        //    }
        //    else if (tipoProvider == enTipoProvider.ODBC)
        //    {
        //        m_dbConn = new OdbcConnection();
        //        //m_dbConn.ConnectionString = "Driver={PostgreSQL ANSI};Server=" + dbAddress + ";Port=5432;Database="+dbName+";Uid=" + userName + ";Pwd=" + password + ";";
        //        m_dbConn.ConnectionString = "Driver={Microsoft Access Driver (*.mdb)};Dbq=" + dbAddress + ";Uid=" + userName + ";Pwd=" + password + ";";
        //        m_metaTableName = "TABLE_NAME";
        //        m_metaColumnName = "COLUMN_NAME";
        //        m_metaDataTypeName = "TYPE_NAME";
        //    }
            
        //    m_owner = owner;
        //    m_customNamespace = customNamespace;
        //}

        //public string[] GetDBTables(string metadata, string tabellaDaMappare)
        //{
        //    if (m_dbConn.ConnectionString == null || m_dbConn.ConnectionString.Equals("")) throw new DLL.exceptions.CodeGeneratorException("connection string non impostata.");
        //    DataTable dtTabella = GetDataTableSchema(metadata,tabellaDaMappare);
        //    string nomeTabella = "";
        //    ArrayList arrListNomiTabelle = new ArrayList();
        //    foreach (DataRow row in dtTabella.Rows)
        //    {
        //        if (row["TABLE_NAME"].ToString().StartsWith("MSys")) continue;
        //        nomeTabella = row["TABLE_NAME"].ToString();
        //        arrListNomiTabelle.Add(nomeTabella);
        //    }
        //    return (string[])arrListNomiTabelle.ToArray(typeof(string));
            
        //}

        //private DataTable GetDataTableSchema(string metadata, string tabellaDaMappare)
        //{
            
        //    try
        //    {
        //        m_dbConn.Open();
        //        string[] restrictions = new string[] { m_dbConn.Database, m_owner, tabellaDaMappare, null };
        //        DataTable dt = _getSchema(metadata, restrictions);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        m_dbConn.Close();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (m_dbConn != null && m_dbConn.State == ConnectionState.Open) m_dbConn.Close();
        //    }
        //}

        private DataTable _getSchema(string metadata, string[] restrictions)
        {
            if (m_dbConn is SqlConnection)
            {
                if (restrictions == null)
                {
                    return ((SqlConnection)m_dbConn).GetSchema(metadata);
                }
                else
                {
                    return ((SqlConnection)m_dbConn).GetSchema(metadata, restrictions);
                }
            }
            else if (m_dbConn is OleDbConnection)
            {
                if (restrictions == null)
                {
                    return ((OleDbConnection)m_dbConn).GetSchema(metadata);
                }
                else
                {
                    return ((OleDbConnection)m_dbConn).GetSchema(metadata, restrictions);
                }
            }
            else if (m_dbConn is OdbcConnection)
            {
                if (restrictions == null)
                {
                    return ((OdbcConnection)m_dbConn).GetSchema(metadata);
                }
                else
                {
                    Array.Resize<string>(ref restrictions, restrictions.Length-1);
                    //return ((OdbcConnection)m_dbConn).GetSchema(metadata, restrictions);
                    return ((OdbcConnection)m_dbConn).GetSchema(metadata);
                }   
            }
            return null;
        }

        public void CreateSourceCode(string tabellaDaMappare, string destinationPath, bool isCSharp, System.Windows.Forms.ListBox lstBox)
        {

            try
            {
                DataTable dt = GetDataTableSchema("Columns",tabellaDaMappare);
                if (dt.Rows.Count <= 0) throw new CodeGeneratorException("Nessuna riga presente per la richiesta metadata COLUMNS tabella da mappare " + tabellaDaMappare);
                string nomeTabella = "";
                string estensione = ".cs";
                if (!isCSharp) estensione = ".vb";
                bool isHeaderScritto = false;
                StreamWriter sw = null;

                foreach (DataRow row in dt.Rows)
                {
                    if (nomeTabella != row[m_metaTableName].ToString())
                    {
                        nomeTabella = row[m_metaTableName].ToString();
                        if (sw != null)
                        {
                            sw.WriteLine("\t}");
                            sw.WriteLine("}");
                            sw.Flush();
                            sw.Close();
                            isHeaderScritto = false;
                        }
                        sw = File.CreateText(destinationPath + "\\" + SetPropertyName(nomeTabella) + estensione);
                        lstBox.Items.Add("file " + SetPropertyName(nomeTabella) + estensione + " creato con successo");
                        if (!isHeaderScritto)
                        {

                            if (isCSharp)
                            {
                                sw.WriteLine("/*");
                                sw.WriteLine("codice generato automaticamente");
                                sw.WriteLine("da CodeGenerator v.1.0 by Federico Torioli");
                                sw.WriteLine("in data " + DateTime.Now.ToString());
                                sw.WriteLine("*/");
                                sw.WriteLine();
                                sw.WriteLine("using System;");
                                sw.WriteLine("using System.Reflection;");
                                sw.WriteLine("using it.itryframework.attributes;");
                                sw.WriteLine();
                                sw.WriteLine("namespace " + m_customNamespace);
                                sw.WriteLine("{");
                                sw.WriteLine("\tpublic class " + SetPropertyName(nomeTabella));
                                sw.WriteLine("\t{");
                                sw.WriteLine("\t\tpublic " + SetPropertyName(nomeTabella) + "()");
                                sw.WriteLine("\t\t{");
                                sw.WriteLine("\t\t}");
                                sw.WriteLine();
                            }
                            else
                            {
                                sw.WriteLine("'");
                                sw.WriteLine("'codice generato automaticamente");
                                sw.WriteLine("'da CodeGenerator v.1.0 by Federico Torioli");
                                sw.WriteLine("'in data " + DateTime.Now.ToString());
                                sw.WriteLine("'");
                                sw.WriteLine();
                                sw.WriteLine("Imports System");
                                sw.WriteLine("Imports System.Reflection");
                                sw.WriteLine("Imports it.itryframework.attributes");
                                sw.WriteLine();
                                sw.WriteLine("Namespace " + m_customNamespace);
                                sw.WriteLine();
                                sw.WriteLine("\tPublic Class " + SetPropertyName(nomeTabella));
                                sw.WriteLine("\t\tPublic " + SetPropertyName(nomeTabella) + "()");
                                sw.WriteLine();
                            }
                            isHeaderScritto = true;
                        }
                    }


                    if (isCSharp)
                    {
                        sw.WriteLine("\t\t///<summary>");
                        sw.WriteLine("\t\t///Ottiene o imposta la proprietà " + SetPropertyName(row[m_metaColumnName].ToString()) + ".");
                        sw.WriteLine("\t\t///</summary>");
                        //bool isKeyField = checkIsKeyField(row["TABLE_CATALOG"].ToString(), row["TABLE_NAME"].ToString(), row["TABLE_SCHEMA"].ToString(), row["COLUMN_NAME"].ToString());
                        //string strIsKeyField = ",IsKeyField=\"true\"";
                        string dbAttributes = "[DBAttributes(DbColumnName=\"" + row[m_metaColumnName].ToString();
                        //if (isKeyField) dbAttributes += strIsKeyField;
                        dbAttributes += "\")]";
                        sw.WriteLine("\t\tprivate " + ConvertToValue(row[m_metaDataTypeName].ToString(), isCSharp) + " " + SetPropertyNameForClass(row[m_metaColumnName].ToString()) + ";");
                        sw.WriteLine("\t\t" + dbAttributes );
                        sw.WriteLine("\t\tpublic " + ConvertToValue(row[m_metaDataTypeName].ToString(), isCSharp) + " " + SetPropertyName(row[m_metaColumnName].ToString()));
                        sw.WriteLine("\t\t{");
                        sw.WriteLine("\t\t\tget { return " + SetPropertyNameForClass(row[m_metaColumnName].ToString()) + "; }");
                        sw.WriteLine("\t\t\tset { " + SetPropertyNameForClass(row[m_metaColumnName].ToString()) + " = value; }");
                        sw.WriteLine("\t\t}");
                        sw.WriteLine();
                    }
                    else
                    {
                        //bool isKeyField = checkIsKeyField(row["TABLE_CATALOG"].ToString(), row["TABLE_NAME"].ToString(), row["TABLE_SCHEMA"].ToString(), row["COLUMN_NAME"].ToString());
                        //string strIsKeyField = ",IsKeyField=\"true\"";
                        string dbAttributes = "<DBAttributes(DbColumnName:=\"" + row[m_metaColumnName].ToString();
                        //if (isKeyField) dbAttributes += strIsKeyField;
                        dbAttributes += "\")> _";
                        sw.WriteLine("\t\tPrivate " + SetPropertyNameForClass(row[m_metaColumnName].ToString()) + " As " + ConvertToValue(row[m_metaDataTypeName].ToString(), isCSharp));
                        sw.WriteLine("\t\t" + dbAttributes);
                        sw.WriteLine("\t\tPublic Property " + SetPropertyName(row[m_metaColumnName].ToString()) + "() As " + ConvertToValue(row[m_metaDataTypeName].ToString(), isCSharp));
                        sw.WriteLine("\t\t\tGet");
                        sw.WriteLine("\t\t\t\tReturn " + SetPropertyNameForClass(row[m_metaColumnName].ToString()));
                        sw.WriteLine("\t\t\tEnd Get");
                        sw.WriteLine("\t\t\tSet (ByVal value As " + ConvertToValue(row[m_metaDataTypeName].ToString(), isCSharp) + ")");
                        sw.WriteLine("\t\t\t\t" + SetPropertyNameForClass(row[m_metaColumnName].ToString()) + " = value");
                        sw.WriteLine("\t\t\tEnd Set");
                        sw.WriteLine("\t\tEnd Property");
                        sw.WriteLine();
                    }

                }

                if (sw != null)
                {
                    if (isCSharp)
                    {
                        sw.WriteLine("\t}");
                        sw.WriteLine("}");
                        sw.Flush();
                    }
                    else
                    {
                        sw.WriteLine("\tEnd Class");
                        sw.WriteLine("End Namespace");
                        sw.Flush();
                    }

                    
                    sw.Close();
                }

                //creo file DBAttributes
                //createDBAttributesFile(sw, destinationPath);


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool checkIsKeyField(string tableCatalog, string tableName, string tableSchema, string columnName)
        {
            return false;
            //m_dbConn.Open();
            //DataTable _dt = _getSchema(m_metaIndexesName, new string[] { tableCatalog, tableSchema, tableName, columnName, null });
            //m_dbConn.Close();
            //if (_dt.Rows.Count == 0) return false;
            //return true;
        }

        /// <summary>
        /// 10/04/2008 - codice non utilizzato
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="destinationPath"></param>
        private void createDBAttributesFile(StreamWriter sw, string destinationPath)
        {
            sw = File.CreateText(destinationPath + "\\DBAttributes.cs");
            Console.WriteLine("file DBAttributes.cs creato con successo");            
            sw.WriteLine("/*");
            sw.WriteLine("codice generato automaticamente");
            sw.WriteLine("da CodeGenerator v.1.0 by Federico Torioli");
            sw.WriteLine("in data " + DateTime.Now.ToString());
            sw.WriteLine("*/");
            sw.WriteLine();
            sw.WriteLine("using System;");
            sw.WriteLine("using System.Reflection;");
            sw.WriteLine();
            sw.WriteLine("namespace it.codice_utile");
            sw.WriteLine("{"); //apertura namespace
            sw.WriteLine("\t[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]");
            sw.WriteLine("\tclass DBAttributes : Attribute");
            sw.WriteLine("\t{");  //apertura classe
            sw.WriteLine("\t\tprivate string m_dbColumnName");
            sw.WriteLine("\t\tpublic string DbColumnName");
            sw.WriteLine("\t\t{");
            sw.WriteLine("\t\t\t\tget { return m_dbColumnName; }");
            sw.WriteLine("\t\t\t\tset { m_dbColumnName = value; }");
            sw.WriteLine("\t\t}");
            sw.WriteLine("\t}");    //chiusura classe
            sw.WriteLine("}");    //chiususra namespace
            sw.WriteLine();
            sw.Flush();
            sw.Close();
        }

        private string ConvertToValue(string valueName, bool isCSharp)
        {
            if (!string.IsNullOrEmpty(valueName)) valueName = valueName.ToLower();
            if (valueName.StartsWith("int",StringComparison.CurrentCultureIgnoreCase) || valueName == "tinyint")
            {
                return (isCSharp) ? "int" : "Integer";
            }
            if (valueName == "bigint")
            {
                return (isCSharp) ? "long" : "Long";
            }
            else if (valueName == "bit" || valueName == "boolean" || valueName == "bool")
            {
                return (isCSharp) ? "bool" : "Boolean";
            }
            else if (valueName == "varchar" || valueName == "nchar" || valueName == "char" || valueName == "nvarchar" || valueName == "varying" || valueName == "text")
            {
                return (isCSharp) ? "string" : "String";
            }
            else if (valueName == "smalldatetime" || valueName == "datetime" || valueName == "timestamp" || valueName == "date" || valueName == "time")
            {
                return "DateTime";
            }
            else if (valueName == "numeric" || valueName == "money")
            {
                return (isCSharp) ? "decimal" : "Decimal";
            }
            else if (valueName == "float")
            {
                return (isCSharp) ? "double" : "Double";
            }
            else if (valueName == "uniqueidentifier")
            {
                return (isCSharp) ? "string" : "String";
            }
            return "";
        }

        private string SetPropertyName(string name)
        {
            if (name.IndexOf("_") < 0)
            {
                return name.Substring(0, 1).ToUpper() + name.Substring(1);
            }
            else
            {
                string[] parts = name.Split(new char[] { '_' });
                string nuovoNome = "";
                foreach (string str in parts)
                {
                    nuovoNome += str.Substring(0, 1).ToUpper() + str.Substring(1);
                }
                return nuovoNome;
            }
        }

        private string SetPropertyNameForClass(string name)
        {


            if (name.IndexOf("_") < 0)
            {
                return "m_" + name.Substring(0, 1).ToLower() + name.Substring(1);
            }
            else
            {
                string[] parts = name.Split(new char[] { '_' });
                string nuovoNome = "";
                int i = 0;
                foreach (string str in parts)
                {
                    if (i == 0)
                        nuovoNome += str.Substring(0, 1).ToLower() + str.Substring(1);
                    else
                        nuovoNome += str.Substring(0, 1).ToUpper() + str.Substring(1);
                    i++;
                }
                return "m_" + nuovoNome;
            }
        }
        #endregion
    }
}

