using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace it.itry.codegenerator.classes
{
    public class VBFile : it.itry.codegenerator.classes.baseclass.GenericFile
    {
        private string m_className = String.Empty;

        public override void doCreateFile(System.Data.DataTable dtSchema, string customTableName, System.Collections.Specialized.StringCollection list)
        {
            if (dtSchema.Rows.Count <= 0) throw new it.itry.codegenerator.exceptions.CodeGeneratorException("Nessuna riga presente per la richiesta metadata COLUMNS");
            bool isHeaderScritto = false;
            bool isInterfaceImplemented = false;
            StreamWriter sw = null;
            string tableName = String.Empty;
            if (string.IsNullOrEmpty(customTableName)) customTableName = tableName;

            base.doCreateMainDirectory();

            string path = base.getDirClasses();
            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
            try
            {
                for (int i = 0; i < dtSchema.Rows.Count; i++)
                {
                    DataRow row = dtSchema.Rows[i];
                    string rawColName = row["COLUMN_NAME"].ToString();
                    string formattedColName = base.setUpperCamelCase(row["COLUMN_NAME"].ToString(), false);
                    string formattedColNameWithPrefix = base.setUpperCamelCase(row["COLUMN_NAME"].ToString(), true);
                    string dbType = it.itry.codegenerator.Utils.getDotNetType(row,false);

                    #region SCRIVI INTESTAZIONE
                    if (tableName.ToLower() != row["TABLE_NAME"].ToString().ToLower())
                    {
                        tableName = row["TABLE_NAME"] as string;
                        //scrivi header

                        //scrivi interfaccia
                        if (sw != null)
                        {
                            sw.WriteLine("\t");
                            sw.Flush();
                            sw.Close();
                            isHeaderScritto = false;
                        }
                        m_className = base.setUpperCamelCase(tableName, false);
                        sw = File.CreateText(path + "\\" + m_className + ".vb");
                        if (!isHeaderScritto)
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
                            sw.WriteLine("Namespace " + base.CustomNamespace + ".classes");
                            sw.WriteLine("\tPublic Class " + m_className);
                            sw.WriteLine("\t\tImplements it.itryframework.interfaces.IGenericObject");
                            sw.WriteLine();
                            sw.WriteLine("\tPublic Sub New()");
                            sw.WriteLine("\tEnd Sub");
                        }
                    }
                    #endregion

                    #region SCRIVI CORPO
                    //scrivi corpo
                    sw.WriteLine("\t\t'''<summary>");
                    sw.WriteLine("\t\t'''Ottiene o imposta la proprietà " + formattedColName + ".");
                    sw.WriteLine("\t\t'''</summary>");
                    string dbAttributes = "<DBAttributes(DbColumnName:=\"" + rawColName + "\")> _";
                    sw.WriteLine("\t\tPrivate " + formattedColNameWithPrefix + " As " + dbType);
                    sw.WriteLine("\t\t" + dbAttributes);
                    sw.WriteLine("\t\tPublic Property " + formattedColName + "() As " + dbType);
                    sw.WriteLine("\t\t\tGet");
                    sw.WriteLine("\t\t\t\tReturn " + formattedColNameWithPrefix);
                    sw.WriteLine("\t\t\tEnd Get");
                    sw.WriteLine("\t\t\tSet (ByVal value As " + dbType + ")");
                    sw.WriteLine("\t\t\t\t" + formattedColNameWithPrefix + " = value");
                    sw.WriteLine("\t\t\tEnd Set");
                    sw.WriteLine("\t\t\tEnd Property");
                    sw.WriteLine();
                    #endregion

                    #region SCRIVI INTERFACCIA
                    if (i == dtSchema.Rows.Count - 1 && !isInterfaceImplemented)
                    {
                        sw.WriteLine("\t#Region \"Membri di IGenericObject\"");
                        sw.WriteLine("\t\t'");
                        sw.WriteLine("\t\t'TODO modificare questo parametro se il campo chiave della tabella non si chiama id");
                        sw.WriteLine("\t\t'");
                        sw.WriteLine("\t\tPublic ReadOnly Property PrimaryKey() As String Implements it.itryframework.interfaces.IGenericObject.PrimaryKey");
                        sw.WriteLine("\t\t\tGet");
                        sw.WriteLine("\t\t\t\tReturn \"id\"");
                        sw.WriteLine("\t\t\tEnd Get");
                        sw.WriteLine("\t\tEnd Property");
                        sw.WriteLine("\t\tPublic ReadOnly Property TableName() As String Implements it.itryframework.interfaces.IGenericObject.TableName");
                        sw.WriteLine("\t\t\tGet");
                        sw.WriteLine("\t\t\t\tReturn \"" + tableName + "\"");
                        sw.WriteLine("\t\t\tEnd Get");
                        sw.WriteLine("\t\tEnd Property");
                        sw.WriteLine("\t#End Region");
                        sw.WriteLine();
                        isInterfaceImplemented = true;
                    }
                    #endregion

                }

                if (sw != null)
                {
                    sw.WriteLine("\tEnd Class");
                    sw.WriteLine("\tEnd Namespace");
                    sw.Flush();
                    sw.Close();
                    list.Add("file " + m_className + " creato con successo");
                }

                //creo file DBAttributes
                //createDBAttributesFile(sw, destinationPath);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void doCreateManager(System.Collections.Specialized.StringCollection list, bool useSingleTonPattern)
        {
            string managerNS = base.CustomNamespace + ".managers";
            string managerName = m_className + "Manager";
            string path = base.getDirManagers();
            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
            StreamWriter sw = null;
            try
            {
                sw = File.CreateText(path + "\\" + managerName + ".vb");
            }
            catch (Exception ex)
            {
                list.Add(managerName + ".vb non creato a causa del seguente errore: " + ex.Message);
                if (sw != null) { sw.Close(); sw.Dispose(); }
                return;
            }
            sw.WriteLine("'");
            sw.WriteLine("'codice generato automaticamente");
            sw.WriteLine("'da CodeGenerator v.1.0 by Federico Torioli");
            sw.WriteLine("'in data " + DateTime.Now.ToString());
            sw.WriteLine("'");
            sw.WriteLine();
            sw.WriteLine("Imports System");
            sw.WriteLine("Imports System.Web");
            sw.WriteLine("Imports System.Reflection");
            sw.WriteLine();
            sw.WriteLine("Namespace " + managerNS);
            sw.WriteLine("\tPublic Class " + managerName);
            sw.WriteLine("\t\tInherits it.itryframework.managers.DefaultManager(Of " + base.CustomNamespace + ".classes." + m_className + ")");
            if (useSingleTonPattern)
            {
                sw.WriteLine("\t\tStatic instance As " + managerName + " = Nothing");
                sw.WriteLine("\t\tPrivate Sub New()");
                sw.WriteLine("\t\tEnd Sub");
                sw.WriteLine("\t\tPublic Static Function getInstance() As " + managerName);
                sw.WriteLine("\t\t\tIf instance == null Then Instance = new " + managerName + "()");
                sw.WriteLine("\t\t\treturn instance;");
                sw.WriteLine("\t\tEnd Function");
            }
            else
            {
                sw.WriteLine("\t\tPublic Sub New()");
                sw.WriteLine("\t\tEnd Sub");
            }
            sw.WriteLine("\tEnd Class");
            sw.WriteLine("End Namespace");
            sw.Flush();
            sw.Close();
            list.Add("file " + managerName + ".vb creato con successo.");
        }
        }
}
