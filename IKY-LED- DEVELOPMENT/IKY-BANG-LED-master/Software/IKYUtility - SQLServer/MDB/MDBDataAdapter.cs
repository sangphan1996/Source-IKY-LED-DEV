using System;
using System.Data;
using System.Data.Common;
using System.Threading;
#if POSTGRESQL
using Npgsql;
#else
using Oracle.DataAccess.Client;
#endif

namespace MDB
{
    public class MDBDataAdapter : IDisposable
    {
#if POSTGRESQL
        internal NpgsqlDataAdapter adapter;
        internal NpgsqlConnection mdbCon;
#else
        internal OracleDataAdapter adapter;
        internal OracleConnection mdbCon;
#endif

        public MDBDataAdapter(MDBCommand mdbCmd)
        {
            try
            {
                mdbCon = mdbCmd.cnn;
#if POSTGRESQL
                NpgsqlCommand Cmd = new NpgsqlCommand(mdbCmd.CommandText, mdbCon);
                Cmd.CommandType = Cmd.CommandType;
                foreach (NpgsqlParameter par in mdbCmd.Parameters)
                {
                    Cmd.Parameters.Add(par.ParameterName, par.NpgsqlDbType, par.Size).Value = par.Value;
                }
                this.adapter = new NpgsqlDataAdapter(Cmd);
#else
                OracleCommand Cmd = new OracleCommand(mdbCmd.CommandText, mdbCon);
                Cmd.CommandType = mdbCmd.CommandType;
                foreach (OracleParameter par in mdbCmd.Parameters)
                {
                    Cmd.Parameters.Add(par.ParameterName, par.OracleDbType, par.Size).Value = par.Value;
                }
                this.adapter = new OracleDataAdapter(Cmd);
#endif
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
        public MDBDataAdapter(string cmdText, MDBConnection m_mdbCon)
        {
            this.mdbCon = m_mdbCon.con;
            try
            {
#if POSTGRESQL
                this.adapter = new NpgsqlDataAdapter(cmdText, this.mdbCon);
#else
                this.adapter = new OracleDataAdapter(cmdText, this.mdbCon);
#endif
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
            this.adapter = null;
            this.mdbCon = null;
        }

        public void Fill(DataTable dt)
        {
            try
            {

                try
                {
                    this.adapter.Fill(dt);
                }
                catch (Exception exception)
                {
#if POSTGRESQL
                    throw new MDBException(exception, exception.Message + "\n" + adapter.SelectCommand.CommandText);
#else
                    throw new MDBException(exception, exception.Message);
#endif
                }
            }
            finally
            {
            }
        }

        void DoEvent()
        {
            System.Windows.Forms.Application.DoEvents();
        }

        public void Fill(DataSet ds, string tableName)
        {
            try
            {
                this.adapter.Fill(ds, tableName);
            }
            catch (Exception exception)
            {
                throw new MDBException(exception, exception.Message);
            }
        }

        public void Update(DataTable tbl)
        {
            try
            {
                this.adapter.Update(tbl);
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

        public void Update(DataSet ds, string tableName)
        {
            try
            {
                this.adapter.Update(ds, tableName);
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

        public MDBCommand DeleteCommand
        {
#if POSTGRESQL
            get
            {
                if ((this.adapter).DeleteCommand != null)
                {
                    return new MDBCommand((this.adapter).DeleteCommand);
                }
                return null;
            }
            set
            {
                (this.adapter).DeleteCommand = value.cmd;
            }
#else
            get
            {
                if ((this.adapter).DeleteCommand != null)
                {
                    return new MDBCommand((this.adapter).DeleteCommand);
                }
                return null;
            }
            set
            {
                (this.adapter).DeleteCommand = value.cmd;
            }
#endif
        }

        public MDBCommand InsertCommand
        {
#if POSTGRESQL
            get
            {
                if ((this.adapter).InsertCommand != null)
                {
                    return new MDBCommand((this.adapter).InsertCommand);
                }
                return null;
            }
            set
            {
                (this.adapter).InsertCommand = value.cmd;
            }
#else
            get
            {
                if ((this.adapter).InsertCommand != null)
                {
                    return new MDBCommand((this.adapter).InsertCommand);
                }
                return null;
            }
            set
            {
                (this.adapter).InsertCommand = value.cmd;
            }
#endif
        }

        public MDBCommand SelectCommand
        {
#if POSTGRESQL
            get
            {
                if ((this.adapter).SelectCommand != null)
                {
                    return new MDBCommand((this.adapter).SelectCommand);
                }
                return null;
            }
            set
            {
                (this.adapter).SelectCommand = value.cmd;
            }
#else
            get
            {
                if ((this.adapter).SelectCommand != null)
                {
                    return new MDBCommand((this.adapter).SelectCommand);
                }
                return null;
            }
            set
            {
                (this.adapter).SelectCommand = value.cmd;
            }
#endif
        }

        public MDBCommand UpdateCommand
        {
#if POSTGRESQL
            get
            {
                if ((this.adapter).UpdateCommand != null)
                {
                    return new MDBCommand((this.adapter).UpdateCommand);
                }
                return null;
            }
            set
            {
                (this.adapter).UpdateCommand = value.cmd;
            }
#else
            get
            {
                if ((this.adapter).UpdateCommand != null)
                {
                    return new MDBCommand((this.adapter).UpdateCommand);
                }
                return null;
            }
            set
            {
                (this.adapter).UpdateCommand = value.cmd;
            }
#endif
        }
    }
}
