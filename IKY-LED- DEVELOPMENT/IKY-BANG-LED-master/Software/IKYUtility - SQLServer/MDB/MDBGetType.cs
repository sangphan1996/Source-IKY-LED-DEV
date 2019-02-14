using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
#if POSTGRESQL
using NpgsqlTypes;
#else
using Oracle.DataAccess.Client;
#endif

namespace MDB
{
    public class MDBGetType
    {
        /// <summary>
        /// Bool = 1,
        /// Date = 2,
        /// Decimal = 3,
        /// Int = 4,
        /// NVarChar = 5,
        /// VarChar = 6
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
#if POSTGRESQL
        public static NpgsqlDbType GetType(MDBType type)
        {
            switch (((int)type))
            {
                case 1:
                    return NpgsqlDbType.Boolean;

                case 2:
                    return NpgsqlDbType.Date;

                case 3:
                    return NpgsqlDbType.Numeric;

                case 4:
                    return NpgsqlDbType.Integer;

                case 5:
                    return NpgsqlDbType.Text;

                case 6:
                    return NpgsqlDbType.Varchar;

                case 7:
                    return NpgsqlDbType.Bytea;
                
                case 8:
                    return NpgsqlDbType.Text;
            }
            throw new Exception();
        }
        #elif SQLSERVER
        public static SqlDbType GetSqlType(MDBType type)
        {
            switch (((int)type))
            {
                case 1:
                    return SqlDbType.Int;

                case 2:
                    return SqlDbType.DateTime;

                case 3:
                    return SqlDbType.Decimal;

                case 4:
                    return SqlDbType.Int;

                case 5:
                    return SqlDbType.NVarChar;

                case 6:
                    return SqlDbType.VarChar;
                
                case 7:
                    return SqlDbType.Blob;

                case 8:
                    return SqlDbType.NClob;
            }
            throw new Exception();
        }
#else
        public static OracleDbType GetType(MDBType type)
        {
            switch (((int)type))
            {
                case 1:
                    return OracleDbType.Int16;

                case 2:
                    return OracleDbType.Date;

                case 3:
                    return OracleDbType.Decimal;

                case 4:
                    return OracleDbType.Int64;

                case 5:
                    return OracleDbType.NVarchar2;

                case 6:
                    return OracleDbType.Varchar2;

                case 7:
                    return OracleDbType.Blob;

                case 8:
                    return OracleDbType.NClob;
            }
            throw new Exception();
        }
        #endif
    }
}
