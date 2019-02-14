using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectSQLServer
{
    public class DBSQLServerUtils
    {
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            // Data Source=USER02-PC\SQLEXPRESSHAIDV;Initial Catalog=sled;User ID=haidv;Password=***********
            //
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }

        public static SqlConnection GetDBConnection(string connString)
        {
            //
            // Data Source=USER02-PC\SQLEXPRESSHAIDV;Initial Catalog=sled;User ID=haidv;Password=***********
            //

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}
