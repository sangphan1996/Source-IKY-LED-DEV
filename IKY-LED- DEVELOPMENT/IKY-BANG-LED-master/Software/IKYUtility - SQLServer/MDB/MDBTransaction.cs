using System;
using System.Data;
#if POSTGRESQL
using Npgsql;
#elif ORACLE
using Oracle.DataAccess.Client;
#elif SQLSERVER
using System.Data.SqlClient;
#endif

namespace MDB
{
    public class MDBTransaction
    {
#if POSTGRESQL
        internal NpgsqlTransaction trans;
#else
        internal OracleTransaction trans;
#endif

        #if POSTGRESQL
        internal MDBTransaction(NpgsqlTransaction trans)
#else
        internal MDBTransaction(OracleTransaction trans)
#endif
        {
            this.trans = trans;
        }

        public void Commit()
        {
            try
            {
                this.trans.Commit();
            }
            catch (Exception exception)
            {
                throw new MDBException(exception, exception.Message);
            }
        }

        public void Rollback()
        {
            try
            {
                this.trans.Rollback();
            }
            catch (Exception exception)
            {
                throw new MDBException(exception, exception.Message);
            }
        }
    }
}
