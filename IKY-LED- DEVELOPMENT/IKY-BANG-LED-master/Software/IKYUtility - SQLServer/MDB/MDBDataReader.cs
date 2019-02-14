using System;
using System.Data;

namespace MDB
{
    public class MDBDataReader
    {
        internal IDataReader reader;

        internal MDBDataReader(IDataReader rd)
        {
            this.reader = rd;
        }

        public void Close()
        {
            try
            {
                this.reader.Close();
            }
            catch (Exception exception)
            {
                throw new MDBException(exception, exception.Message);
            }
        }

        public bool GetBoolean(int ord)
        {
            bool flag=false;
            try
            {
                if (this.reader.GetInt16(ord) == 1)
                {
                    return true;
                }
                flag = false;
            }
            catch (Exception exception)
            {
                throw new MDBException(exception, exception.Message);
            }
            return flag;
        }

        public bool GetBoolean(string columnName)
        {
            try
            {
                return (Convert.ToInt16(this.reader[columnName]) == 1);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetDataTypeName(int index)
        {
            return this.reader.GetDataTypeName(index);
        }

        public DateTime GetDate(int ord)
        {
            DateTime dateTime=DateTime.Now;
            try
            {
                dateTime = this.reader.GetDateTime(ord);
            }
            catch (Exception exception)
            {
                throw new MDBException(exception, exception.Message);
            }
            return dateTime;
        }

        public DateTime GetDate(string columnName)
        {
            try
            {
                return Convert.ToDateTime(this.reader[columnName]);
            }
            catch //(Exception exception)
            {
                //throw new MDBException(exception, exception.Message);
            }
            return DateTime.Today;
        }

        public decimal GetDecimal(int ord)
        {
            decimal @decimal=0;
            try
            {
                @decimal = this.reader.GetDecimal(ord);
            }
            catch (Exception exception)
            {
                throw new MDBException(exception, exception.Message);
            }
            return @decimal;
        }

        public decimal GetDecimal(string columnName)
        {
            try
            {
                object obj2 = this.reader[columnName];
                return Convert.ToDecimal(obj2);
            }
            catch //(Exception exception)
            {
               // throw new MDBException(exception, exception.Message);
            }
            return 0M;
        }

        public int GetFieldCount()
        {
            return this.reader.FieldCount;
        }

        public int GetInt(int ord)
        {
            int num;
            try
            {
                num = this.reader.GetInt32(ord);
            }
            catch (MDBException exception)
            {
                throw new MDBException(exception, exception.Message);
            }
            return num;
        }

        public int GetInt(string columnName)
        {
            int num;
            try
            {
                num = Convert.ToInt32(this.reader[columnName]);
            }
            catch (Exception exception)
            {
                throw new MDBException(exception, exception.Message);
            }
            return num;
        }

        public decimal GetLong(int ord)
        {
            decimal @decimal;
            try
            {
                @decimal = this.reader.GetDecimal(ord);
            }
            catch (Exception exception)
            {
                throw new MDBException(exception, exception.Message);
            }
            return @decimal;
        }

        public decimal GetLong(string columnName)
        {
            try
            {
                return Convert.ToDecimal(this.reader[columnName]);
            }
            catch //(Exception exception)
            {
               // throw new MDBException(exception, exception.Message);
            }
            return 0M;
        }

        public string GetName(int index)
        {
            return this.reader.GetName(index);
        }

        public DataTable GetSchemaTable()
        {
            return this.reader.GetSchemaTable();
        }

        public string GetString(int ord)
        {
            string str;
            try
            {
                str = this.reader.GetString(ord);
            }
            catch (Exception exception)
            {
                throw new MDBException(exception, exception.Message);
            }
            return str;
        }

        public string GetString(string columnName)
        {
            string str;
            try
            {
                str = this.reader[columnName].ToString().Trim();
            }
            catch (Exception exception)
            {
                throw new MDBException(exception, exception.Message);
            }
            return str;
        }

        public bool Read()
        {
            bool flag;
            try
            {
                flag = this.reader.Read();
            }
            catch (Exception exception)
            {
                throw new MDBException(exception, exception.Message);
            }
            return flag;
        }

        public bool IsClosed
        {
            get
            {
                return this.reader.IsClosed;
            }
        }
    }
}
