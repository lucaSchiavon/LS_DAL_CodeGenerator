using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace it.itry.codegenerator
{
    public class Utils
    {
        public static string DLL_VERSIONE_1 = "ITryFramework versione 1";
        public static string DLL_VERSIONE_2 = "ITryFramework versione 2";

        private Utils() { }

        #region getDotNetType
        public static string getDotNetType(DataRow row, bool isCSharp)
        {
            int intType;
            if (!int.TryParse(row["DATA_TYPE"].ToString(), out intType))
            {
                string sType = row["DATA_TYPE"].ToString().ToLower();
                if (sType.Equals("varchar") || sType.Equals("nvarchar") || sType.Equals("ntext") || sType.Equals("char")) return (isCSharp) ? "string" : "String";
                else if (sType.Equals("int") || sType.Equals("smallint")) return (isCSharp) ? "int" : "Integer";
                else if (sType.Equals("bigint")) return (isCSharp) ? "long" : "Long";
                else if (sType.Equals("numeric")) return (isCSharp) ? "decimal" : "Decimal";
                else if (sType.Equals("bit")) return (isCSharp) ? "bool" : "Boolean";
                else if (sType.Equals("datetime") || sType.Equals("smalldatetime")) return "DateTime";

                return sType;
            }

            object dbType = (System.Data.DbType)Enum.ToObject(typeof(System.Data.DbType), intType);
            switch ((System.Data.DbType)Enum.ToObject(typeof(System.Data.DbType), row["DATA_TYPE"]))
            {
                case DbType.AnsiString:
                    break;
                case DbType.AnsiStringFixedLength:
                    break;
                case DbType.Binary:
                    break;
                case DbType.Boolean:
                    return "bool";
                case DbType.Byte:
                    break;
                case DbType.Decimal:
                case DbType.Currency:
                    return "decimal";
                case DbType.Date:
                case DbType.DateTime:
                    return "DateTime";
                case DbType.Double:
                    return "double";
                case DbType.Guid:
                    break;
                case DbType.Int16:
                case DbType.Int32:
                    return "int";
                case DbType.Int64:
                    return "long";
                case DbType.Object:
                    break;
                case DbType.SByte:
                    break;
                case DbType.Single:
                    break;
                case DbType.String:
                    return "string";
                case DbType.StringFixedLength:
                    break;
                case DbType.Time:
                    break;
                case DbType.UInt16:
                case DbType.UInt32:
                    return "uint";
                case DbType.UInt64:
                    return "ulong";
                case DbType.VarNumeric:
                    break;
                case DbType.Xml:
                    break;
                default:
                    break;
            }
            return "";
        } 
        #endregion

        #region getSupportedDatabases
        public static string[] getSupportedDatabases()
        {
            return new string[] { "MsSql" }; //TODO da supportare in futuro "MsAccess","MySql","PostGres"
        } 
        #endregion

        #region getCodeGeneratorDirName
        public static string getCodeGeneratorDirName()
        {
            return "codegenerator";
        } 
        #endregion

        #region getProvidersByTipoDb
        public static List<string> getProvidersByTipoDb(string tipoDb)
        {
            List<string> list = new List<string>();
            //list.Add("Odbc");
            tipoDb = tipoDb.ToLower();
            if (tipoDb.Equals("MsSql".ToLower()))
            {
                list.Add("SqlClient");
            }

            /*
             * 
             * TODO da supportare in futuro, per ora non sono perfettamente funzionanti
            else if (tipoDb.Equals("MsAccess".ToLower()))
            {
                list.Add("Oledb");
            }
            else if (tipoDb.Equals("PostGres".ToLower()))
            {
                list.Add("Postgres");
            }
            else if (tipoDb.Equals("MySql".ToLower()))
            {
                list.Add("Connector Odbc");
                list.Add("Connector .NET");
            }
            */
            return list;
        } 
        #endregion

        #region getVersioniDll
        /// <summary>
        /// Ritorna l'elenco delle versioni della libreria supportate
        /// </summary>
        /// <returns></returns>
        public static string[] getVersioniDll()
        {
            return new string[] { DLL_VERSIONE_1, DLL_VERSIONE_2 };
        }
        #endregion
        
    }
}
