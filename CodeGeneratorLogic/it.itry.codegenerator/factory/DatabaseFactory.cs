using System;
using System.Collections.Generic;
using System.Text;

namespace it.itry.codegenerator.factory
{
    public class DatabaseFactory
    {
        private DatabaseFactory() { }
        public static it.itry.codegenerator.classes.baseclass.Database getDatabase(string tipoDB)
        {

            tipoDB = tipoDB.ToLower();
            if (tipoDB.Equals(classes.baseclass.Database.TIPO_DB_MSSQL.ToLower()))
            {
                return new it.itry.codegenerator.databases.MsSqlDB();
            }
            else if (tipoDB.Equals(classes.baseclass.Database.TIPO_DB_MSACCESS.ToLower()))
            {
                return new it.itry.codegenerator.databases.MsAccessDB();
            }
            else if (tipoDB.Equals(classes.baseclass.Database.TIPO_DB_MYSQL.ToLower()))
            {
                return new it.itry.codegenerator.databases.MySqlDB();
            }
            else if (tipoDB.Equals(classes.baseclass.Database.TIPO_DB_POSTGRES.ToLower()))
            {
                return new it.itry.codegenerator.databases.PostGresDB();
            }
            return null;
        }
    }
}
