using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace it.itry.codegenerator.databases
{
    public class MySqlDB : it.itry.codegenerator.classes.baseclass.Database
    {
        public MySqlDB() : base() { }

        //public override string[] getTables()
        //{
        //    throw new NotImplementedException();
        //}

        //public override System.Data.DataTable getColumns(string tableName)
        //{
        //    throw new NotImplementedException();
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
    }
}
