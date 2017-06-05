using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace it.itry.codegenerator.classes
{
    public class CSharpFile : it.itry.codegenerator.classes.baseclass.GenericFile
    {
        private string m_className = String.Empty;
        
        public override void doCreateFile(DataTable dtSchema, string customTableName,System.Collections.Specialized.StringCollection list)
        {
            if (dtSchema.Rows.Count <= 0) throw new it.itry.codegenerator.exceptions.CodeGeneratorException("Nessuna riga presente per la richiesta metadata COLUMNS");
            bool isHeaderScritto = false;
            bool isInterfaceImplemented = false;
            StreamWriter sw = null;
            string tableName = String.Empty;
            if (string.IsNullOrEmpty(customTableName)) customTableName = tableName;
            base.doCreateMainDirectory();

            string path = base.getDirClasses();
            if (!System.IO.Directory.Exists(path))
            {
                try { System.IO.Directory.CreateDirectory(path); }
                catch (Exception ioex)
                {
                    throw new exceptions.CodeGeneratorException("Impossibile creare la directory in "+path,ioex);
                }
            }

            List<string> pKeyName = new List<string>();
            List<string> foreignKeys = new List<string>();
            //try
            //{
            for (int i = 0; i < dtSchema.Rows.Count; i++)
            {
                    DataRow row = dtSchema.Rows[i];
                    if (i == 0)
                    {
                        try
                        {
                            pKeyName = base.DataBase.getPrimaryKey(row["TABLE_NAME"].ToString());
                        }
                        catch {
                            list.Add("impossibile recuperare la chiave primaria per la tabella " + row["TABLE_NAME"].ToString());
                        }
                    }
                    string rawColName = row["COLUMN_NAME"].ToString();
                    string formattedColName = base.setUpperCamelCase(row["COLUMN_NAME"].ToString(),false);
                    string formattedColNameWithPrefix = base.setUpperCamelCase(row["COLUMN_NAME"].ToString(), true);
                    string dbType = it.itry.codegenerator.Utils.getDotNetType(row,true);
                    
                    #region SCRIVI INTESTAZIONE
                    if (tableName.ToLower() != row["TABLE_NAME"].ToString().ToLower())
                    {
                        tableName = row["TABLE_NAME"] as string;
                        try { foreignKeys = base.DataBase.getForeignKeys(dtSchema.Rows[0]["TABLE_NAME"].ToString()); }
                        catch {
                            list.Add("impossibile recuperare le chiavi esterne per la tabella " + tableName);
                        }
                        //scrivi header
                       
                        //scrivi interfaccia
                        if (sw != null)
                        {
                            sw.WriteLine("\t}");
                            sw.WriteLine("}");
                            sw.Flush();
                            sw.Close();
                            isHeaderScritto = false;
                        }
                        m_className = base.setUpperCamelCase(customTableName, false);
                        sw = File.CreateText(path + "\\" + m_className + ".cs");
                        if (!isHeaderScritto)
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
                                sw.WriteLine("namespace " + base.CustomNamespace+".classes");
                                sw.WriteLine("{");
                                sw.WriteLine("\tpublic class " + m_className + " : it.itryframework.interfaces.IGenericObject");
                                sw.WriteLine("\t{");
                                sw.WriteLine("\t\tpublic " + m_className + "()");
                                sw.WriteLine("\t\t{");
                                sw.WriteLine("\t\t}");
                                sw.WriteLine();
                        }
                    }
                    #endregion

                    #region SCRIVI CORPO
                    try
                    {
                        //scrivi corpo
                        sw.WriteLine("\t\t///<summary>");
                        sw.WriteLine("\t\t///Ottiene o imposta la proprietà " + formattedColName + ".");
                        sw.WriteLine("\t\t///</summary>");
                        //bool isKeyField = checkIsKeyField(row["TABLE_CATALOG"].ToString(), row["TABLE_NAME"].ToString(), row["TABLE_SCHEMA"].ToString(), row["COLUMN_NAME"].ToString());
                        //string strIsKeyField = ",IsKeyField=\"true\"";
                        string dbAttributes = "[DBAttributes(DbColumnName=\"" + rawColName + "\"";
                        //if (!string.IsNullOrEmpty(row["CHARACTER_MAXIMUM_LENGTH"].ToString())) dbAttributes += ",DataSize=" + row["CHARACTER_MAXIMUM_LENGTH"].ToString()+"";
                        dbAttributes += ")]";
                        sw.WriteLine("\t\tprivate " + dbType + " " + formattedColNameWithPrefix + ";");
                        sw.WriteLine("\t\t" + dbAttributes);
                        sw.WriteLine("\t\tpublic " + dbType + " " + formattedColName);
                        sw.WriteLine("\t\t{");
                        sw.WriteLine("\t\t\tget { return " + formattedColNameWithPrefix + "; }");
                        sw.WriteLine("\t\t\tset { " + formattedColNameWithPrefix + " = value; }");
                        sw.WriteLine("\t\t}");
                        sw.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        if (sw != null) sw.Close();
                        sw.Dispose();
                        throw;
                    }
                    #endregion

                    #region SCRIVI INTERFACCIA
                    if (i == dtSchema.Rows.Count - 1 && !isInterfaceImplemented)
                    {
                        sw.WriteLine("\t\t#region Membri di IGenericObject");
                        //sw.WriteLine("\t\t/*");
                        //sw.WriteLine("\t\t TODO modificare questo parametro se il campo chiave della tabella non si chiama id");
                        //sw.WriteLine("\t\t*/");
                        sw.WriteLine("\t\tstring it.itryframework.interfaces.IGenericObject.PrimaryKey");
                        sw.WriteLine("\t\t{");
                        sw.WriteLine("\t\t\tget { return \""+ (pKeyName.Count == 0 ? String.Empty : pKeyName[0]) +"\"; }");
                        sw.WriteLine("\t\t}");
                        sw.WriteLine("\t\tstring it.itryframework.interfaces.IGenericObject.TableName");
                        sw.WriteLine("\t\t{");
                        sw.WriteLine("\t\t\tget { return \"" + tableName + "\"; }");
                        sw.WriteLine("\t\t}");
                        sw.WriteLine("\t\t#endregion");
                        sw.WriteLine();
                        isInterfaceImplemented = true;
                    }
                    #endregion

             }

                if (sw != null)
                {
                        sw.WriteLine("\t}");
                        sw.WriteLine("}");
                        sw.Flush();
                    sw.Close();
                    list.Add("file " + m_className + " creato con successo");
                }

                //creo file DBAttributes
                //createDBAttributesFile(sw, destinationPath);


            //}
            //catch (Exception ex)
            //{
            //    throw new exceptions.CodeGeneratorException("", ex);
            //}            
        }

        public override void doCreateManager(System.Collections.Specialized.StringCollection list, bool useSingleTonPattern)
        {
            string managerNS = base.CustomNamespace+".managers";
            string managerName = m_className + "Manager";
            string path = base.getDirManagers();
            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
            StreamWriter sw = null;
            try
            {
                sw = File.CreateText(path + "\\" + managerName + ".cs");
            }
            catch(Exception ex)
            {
                list.Add(managerName+".cs non creato a causa del seguente errore: "+ex.Message);
                if (sw != null) { sw.Close(); sw.Dispose(); }
                return;
            }
                sw.WriteLine("/*");
                sw.WriteLine("codice generato automaticamente");
                sw.WriteLine("da CodeGenerator v.1.0 by Federico Torioli");
                sw.WriteLine("in data " + DateTime.Now.ToString());
                sw.WriteLine("*/");
                sw.WriteLine();
                sw.WriteLine("using System;");
                sw.WriteLine("using System.Web;");
                sw.WriteLine("using System.Reflection;");
                sw.WriteLine();
                sw.WriteLine("namespace " + managerNS);
                sw.WriteLine("{");
                sw.WriteLine("\tpublic class " + managerName + " : it.itryframework.managers.DefaultManager<" + base.CustomNamespace + ".classes." + m_className + ">");
                sw.WriteLine("\t{");
                if (useSingleTonPattern)
                {
                    sw.WriteLine("\t\tstatic " + managerName + " instance = null;");
                    sw.WriteLine("\t\tprivate " + managerName + "(){}");
                    sw.WriteLine("\t\tpublic static " + managerName + " getInstance()");
                    sw.WriteLine("\t\t{");
                    sw.WriteLine("\t\t\tif (instance == null) instance = new "+managerName+"();");
                    sw.WriteLine("\t\t\treturn instance;");
                    sw.WriteLine("\t\t}");
                }else{
                    sw.WriteLine("\t\tpublic " + managerName + "(){}");
                }
                sw.WriteLine("\t}");
                sw.WriteLine("}");
                sw.WriteLine();
                sw.Flush();
                sw.Close();
            list.Add("file " + managerName + ".cs creato con successo.");
        }

    }
}
