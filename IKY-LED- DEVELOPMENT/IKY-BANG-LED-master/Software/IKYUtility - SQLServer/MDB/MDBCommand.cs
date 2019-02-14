using System;
using System.Data;
using System.Threading;
#if POSTGRESQL
using Npgsql;
#elif ORACLE 
using Oracle.DataAccess.Client;
#elif SQLSERVER
using System.Data.SqlClient;
#endif

namespace MDB
{
    public class MDBCommand : IDisposable
    {
#if POSTGRESQL
        internal NpgsqlCommand cmd;
        public NpgsqlConnection cnn;
#elif ORACLE
        internal OracleCommand cmd;
        public OracleConnection cnn;
#elif SQLSERVER
        internal SqlCommand cmd;
        public SqlConnection cnn;
#endif
        private string commandText;

#if POSTGRESQL
        internal MDBCommand(NpgsqlCommand cmd)
#elif ORACLE
        internal MDBCommand(OracleCommand cmd)
#elif SQLSERVER
        internal MDBCommand(SqlCommand cmd)
#endif
        {
            try
            {
                this.cmd = cmd;
                this.commandText = this.cmd.CommandText;
#if POSTGRESQL
                this.cnn = new NpgsqlConnection(this.cmd.Connection.ConnectionString);
#elif ORACLE
                this.cnn = new OracleConnection(this.cmd.Connection.ConnectionString);
#elif SQLSERVER
                this.cnn = new SqlConnection(this.cmd.Connection.ConnectionString);
#endif
            }
            catch (Exception exception)
            {
#if POSTGRESQL
                throw new MDBException(exception, exception.Message);
#elif ORACLE
                OracleException ex = exception as OracleException;
                throw new MDBException(exception, this.commandText , ex.Number);
#elif SQLSERVER
                throw new MDBException(exception, exception.Message);
#endif
            }
        }

        public MDBCommand(string cmdText, MDBConnection m_mdbCnn)
        {
            try
            {

#if POSTGRESQL
                cmdText = cmdText.Replace("to_date", "to_timestamp");
                this.commandText = cmdText;
                this.cnn = m_mdbCnn.con;
                this.cmd = new NpgsqlCommand(this.commandText, m_mdbCnn.con);
                this.cmd.CommandType = CommandType.Text;
                this.cmd.CommandTimeout = 30;
#elif ORACLE
                string s_Text = cmdText.Trim().Trim(';');
                s_Text = s_Text.Trim('\n');
                s_Text = s_Text.Trim('\r');
                s_Text = s_Text.Trim('\n');
                s_Text = s_Text.Trim(';');
                string[] sText = s_Text.Split(';');
                if (sText.Length > 1)
                {
                    cmdText = "begin\n" + s_Text + ";\n" + "end;\n";
                }
                else { cmdText = s_Text; }
                this.commandText = cmdText;
                this.cnn = m_mdbCnn.con;
                this.cmd = new OracleCommand(this.commandText, m_mdbCnn.con);
                this.cmd.CommandType = CommandType.Text;
                this.cmd.CommandTimeout = 30;
#elif SQLSERVER                
                this.commandText = cmdText;
                this.cnn = m_mdbCnn.con;
                this.cmd = new SqlCommand(this.commandText, m_mdbCnn.con);
                this.cmd.CommandType = CommandType.Text;
                this.cmd.CommandTimeout = 30;
#endif
            }
            catch (Exception exception)
            {
#if POSTGRESQL
                throw new MDBException(exception, exception.Message);
#elif ORACLE
                OracleException ex = exception as OracleException;
                throw new MDBException(exception, this.commandText , ex.Number);
#elif SQLSERVER
                throw new MDBException(exception, exception.Message);
#endif
            }
        }

        public void Dispose()
        {
            this.cnn = null;
            this.commandText = null;
            if (this.cmd != null)
            {
                this.cmd.Dispose();
                this.cmd = null;
            }
        }

        public int ExecuteNonQuery()
        {
            int i_Val = 0;
            try
            {
                i_Val = this.cmd.ExecuteNonQuery();
            }
#if POSTGRESQL
            catch (Exception e)
            {
                if (e.Message.Contains("An existing connection was forcibly closed by the remote host.") || e.Message.Contains("The Connection is broken.")
                 || e.Message.Contains("Failed to establish a connection") || e.Message.Contains("the database system is starting up")
                      || e.Message.Contains(" the database system is starting up"))
                {
                    i_Val = 999;
                }
                else { i_Val = -1; }
                throw new MDBException(e, e.Message, i_Val);
            }
#elif ORACLE
            catch(OracleException e)
            {
                OracleException ex = e as OracleException;
                i_Val = ex.Number;
                throw new MDBException(e, this.commandText , ex.Number);
            }
#elif SQLSERVER
            catch (Exception e)
            {
                if (e.Message.Contains("An existing connection was forcibly closed by the remote host.") || e.Message.Contains("The Connection is broken.")
                 || e.Message.Contains("Failed to establish a connection") || e.Message.Contains("the database system is starting up")
                      || e.Message.Contains(" the database system is starting up"))
                {
                    i_Val = 999;
                }
                else { i_Val = -1; }
                throw new MDBException(e, e.Message, i_Val);
            }
#endif
            finally { }
            return i_Val;
        }

        public MDBDataReader ExecuteReader()
        {
            MDBDataReader reader = null;
            try
            {
                reader = new MDBDataReader(this.cmd.ExecuteReader());
            }
            catch (Exception exception)
            {
#if POSTGRESQL
                throw new MDBException(exception, exception.Message);
#elif ORACLE
                OracleException ex = exception as OracleException;
                throw new MDBException(exception, this.commandText , ex.Number);
#elif SQLSERVER
                throw new MDBException(exception, exception.Message);
#endif
            }
            return reader;
        }

        public object ExecuteScalar()
        {

            object obj2 = null;
            try
            {
                obj2 = this.cmd.ExecuteScalar();
            }
            catch (Exception exception)
            {
#if POSTGRESQL
                throw new MDBException(exception, exception.Message);
#elif ORACLE
                OracleException ex = exception as OracleException;
                throw new MDBException(exception, this.commandText , ex.Number);
#elif SQLSERVER
                throw new MDBException(exception, exception.Message);
#endif
            }
            return obj2;
        }

        public string CommandText
        {
            get { return this.cmd.CommandText; }
            set
            {
                this.cmd.CommandText = value;
            }
        }

        public int CommandTimeout
        {
            get
            {
                return this.cmd.CommandTimeout;
            }
            set
            {
                this.cmd.CommandTimeout = value;
            }
        }

        public System.Data.CommandType CommandType
        {
            get
            {
                return this.cmd.CommandType;
            }
            set
            {
                this.cmd.CommandType = value;
            }
        }
#if POSTGRESQL
        public NpgsqlConnection Connection
#elif ORACLE
        public OracleConnection Connection
#elif SQLSERVER
        public SqlConnection Connection
#endif
        {
            set
            {
                this.cmd.Connection = value;
            }
        }

        public MDBParameterCollection Parameters
        {
            get
            {
                MDBParameterCollection parameters;
                try
                {
                    parameters = new MDBParameterCollection(this.cmd.Parameters);
                }
                catch (Exception exception)
                {
#if POSTGRESQL
                    throw new MDBException(exception, exception.Message);
#elif ORACLE
                    OracleException ex = (OracleException)exception;
                    throw new MDBException(exception, this.commandText, ex.Number);
#elif SQLSERVER
                    throw new MDBException(exception, exception.Message);
#endif
                }
                return parameters;
            }
        }

        public MDBTransaction Transaction
        {
            get
            {
                MDBTransaction transaction = null;
                try
                {
                    transaction = new MDBTransaction(this.cmd.Transaction);
                }
                catch (Exception exception)
                {
#if POSTGRESQL
                    throw new MDBException(exception, this.commandText + "\n" + exception.Message);
#else
                    OracleException ex = exception as OracleException;
                    throw new MDBException(exception, this.commandText , ex.Number);
#endif
                }
                return transaction;
            }
            set
            {
                this.cmd.Transaction = value.trans;
            }
        }
    }
}
