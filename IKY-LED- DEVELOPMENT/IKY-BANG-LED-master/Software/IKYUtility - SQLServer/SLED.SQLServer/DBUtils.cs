using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectSQLServer
{
    public class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            //Data Source=USER02-PC\SQLEXPRESSHAIDV;Initial Catalog=sled;User ID=haidv;Password=***********
            string datasource = @"localhost\SQLEXPRESSHAIDV";

            string database = "sled";
            string username = "haidv";
            string password = "vanhai@a";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
