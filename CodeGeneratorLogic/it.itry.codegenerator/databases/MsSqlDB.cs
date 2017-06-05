using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace it.itry.codegenerator.databases
{
    public class MsSqlDB : it.itry.codegenerator.classes.baseclass.Database
    {
        #region CONSTRUCTORS
        public MsSqlDB():base() {}
        #endregion

        //#region it.itry.codegenerator.classes.baseclasses.Database members

        //public override string[] getColumns(string tableName)
        //{
        //    DataTable dt=getValuesFromSchema("Columns", tableName);
        //    return getValues(dt);
        //}

        
        //#endregion

        

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
            
        //}

        //public override string[] getTables(string dataBase)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
