using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace it.itry.codegenerator.databases
{
    public class MsAccessDB : it.itry.codegenerator.classes.baseclass.Database
    {
        public MsAccessDB() : base() { }

        //#region it.itry.codegenerator.classes.baseclasses.Database members
        //public override string[] getDatabases()
        //{
        //    return getValues("Databases", null);
        //}
        //public override string[] getTables(string database)
        //{
            
        //}
        //public override string[] getColumns(string tableName)
        //{
        //    return getValues("Columns",tableName);
        //}
        //public override DataTable getSchema(string schema, string[] restrictions)
        //{
        //    DataTable dt;
        //    base.setOpenConnection();
        //    using (DbConnection)
        //    {
        //        try
        //        {
        //            dt = DbConnection.GetSchema(schema, restrictions);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            if (DbConnection != null) DbConnection.Close();
        //        }
        //    }
        //    return dt;
        //}

        //#endregion

        //private string[] getValues(string schema, string tableName)
        //{
        //    string[] restrictions = null;
        //    DataTable dt = null;
        //    if (schema.Equals("databases",StringComparison.InvariantCultureIgnoreCase))
        //    {
        //    }
        //    else if (schema.Equals("tables", StringComparison.InvariantCultureIgnoreCase))
        //    {

        //    }
        //    else if (schema.Equals("Columns", StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        restrictions = new string[4];
        //        restrictions[2] = tableName;
        //    }

        //    dt = getSchema(schema, restrictions);

        //    List<string> list = new List<string>();
        //    if (dt.Rows.Count == 0) return null;
        //    dt.DefaultView.Sort = dt.Columns[0].ColumnName;

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        DataRow row = dt.Rows[i];
        //        list.Add(Convert.ToString(row[0]));
        //    }
        //    return list.ToArray();
            
        //}

        


    }
}
