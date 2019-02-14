using System;
using System.Data;
#if POSTGRESQL
using Npgsql;
#else
using Oracle.DataAccess.Client;
#endif

namespace MDB
{
    public class MDBConnection
    {
#if POSTGRESQL
        internal NpgsqlConnection con;
#else
        internal OracleConnection con;
#endif
        public string connstring;

        #if POSTGRESQL
        internal MDBConnection(NpgsqlConnection con)
#else
        internal MDBConnection(OracleConnection con)
#endif
        {
            try
            {
                this.con = con;
            }
            catch (Exception exception)
            {
#if POSTGRESQL
                throw new MDBException(exception, exception.Message);
#else
                OracleException ex = (OracleException)exception;
                throw new MDBException(exception, exception.Message, ex.Number);
#endif
            }
        }

        public MDBConnection(string connectionString)
        {
            try
            {
                this.connstring = connectionString;
                #if POSTGRESQL
                this.con = new NpgsqlConnection(connectionString);
                #else
                this.con = new OracleConnection(connectionString);
                #endif
            }
            catch (Exception exception)
            {
#if POSTGRESQL
                throw new MDBException(exception, exception.Message);
#else
                OracleException ex = (OracleException)exception;
                throw new MDBException(exception, exception.Message,ex.Number);
#endif
            }
        }

        public MDBTransaction BeginTransaction()
        {
            MDBTransaction transaction=null;
            try
            {
                transaction = new MDBTransaction(this.con.BeginTransaction());
            }
            catch (Exception exception)
            {
#if POSTGRESQL
                throw new MDBException(exception, exception.Message);
#else
                OracleException ex = (OracleException)exception;
                throw new MDBException(exception, exception.Message,ex.Number);
#endif
            }
            return transaction;
        }

        public void Close()
        {
            try
            {
                if (con !=null && con.State == ConnectionState.Open)//thuy 9/4/2014
                {
                    this.con.Close();
                }
                this.Dispose();
            }
            catch (Exception exception)
            {
#if POSTGRESQL
                throw new MDBException(exception, exception.Message);
#else
                OracleException ex = (OracleException)exception;
                throw new MDBException(exception, exception.Message, ex.Number);
#endif
            }
        }

        public void Dispose()
        {
            try
            {
                if (con != null)
                {
                    this.con.Dispose();
                }
                GC.Collect();
                GC.SuppressFinalize(this);
            }
            catch 
            {
            }
        }

        public void Open()
        {
            try
            {
                this.con.Open();
            }
            catch (Exception exception)
            {
#if POSTGRESQL
               throw new MDBException(exception, exception.Message);
#else
                OracleException ex = (OracleException)exception;
                throw new MDBException(exception, exception.Message, ex.Number);
#endif
            }
        }

        public ConnectionState State
        {
            get {
                if (this.con == null) { return ConnectionState.Broken; }
                return this.con.State; }
        }

        public override string ToString()
        {
            return this.connstring;
        }
    }
}
