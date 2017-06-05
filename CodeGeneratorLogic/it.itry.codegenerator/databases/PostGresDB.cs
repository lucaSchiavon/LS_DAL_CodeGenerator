using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace it.itry.codegenerator.databases
{
    public class PostGresDB : it.itry.codegenerator.classes.baseclass.Database
    {
        public PostGresDB() : base() { }

        //public PostGresDB() : base() { }
        //#region it.itry.codegenerator.classes.baseclasses.Database members
        //public override string[] getTables()
        //{
        //    string[] vals = null;
        //    DataTable dt= getValues(null);
        //    if (dt.Rows.Count == 0) return null;
        //    vals = new string[dt.Rows.Count];
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        DataRow row = dt.Rows[i];
        //        vals[i] = row["TABLE_NAME"] as string;
        //    }
        //    return vals;
        //}

        //public override DataTable getColumns(string tableName)
        //{
        //    return getValues(tableName);
        //}

        
        //#endregion

        //private DataTable getValues(string tableName)
        //{
        //    string[] restrictions = null;
        //    string schema = null;
        //    DataTable dt = null;
        //    if (string.IsNullOrEmpty(tableName))
        //    {
        //        schema = "Tables";
        //    }
        //    else
        //    {
        //        restrictions = new string[4];
        //        restrictions[2] = tableName;
        //        schema = "Columns";
        //    }
        //    base.DbConnection.ConnectionString = "Driver={PostgreSQL ANSI};Server=localhost;Port=5432;Database=test;Uid=testuser;Pwd=password;";//base.ConnectionString;
        //    dt = getSchema(schema, restrictions);
        //    return dt;
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

        //public override string[] getDatabases()
        //{
        //    throw new NotImplementedException();
        //}

        //public override string[] getTables(string dataBase)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
