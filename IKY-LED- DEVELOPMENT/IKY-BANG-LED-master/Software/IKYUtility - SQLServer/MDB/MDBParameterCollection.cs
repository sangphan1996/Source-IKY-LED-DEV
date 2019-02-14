using System;
using System.Collections;
using System.Data;
using System.Reflection;
#if POSTGRESQL
using Npgsql;
#else
using Oracle.DataAccess.Client;
#endif

namespace MDB
{
    public class MDBParameterCollection : IDataParameterCollection, IList, ICollection, IEnumerable
    {
        internal IDataParameterCollection paramCols;

        internal MDBParameterCollection(IDataParameterCollection paramCols)
        {
            this.paramCols = paramCols;
        }

        public int Add(object value)
        {
            int num=0;
            try
            {
                num = this.paramCols.Add(value);
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
            return num;
        }

        public MDBParameter Add(string paraName, MDBType MdbType, int size)
        {
            MDBParameter parameter = null;
            try
            {
                #if POSTGRESQL
                parameter = new MDBParameter(((NpgsqlParameterCollection)this.paramCols).Add(paraName, MDBGetType.GetType(MdbType), size));
#else
                parameter = new MDBParameter(((OracleParameterCollection)this.paramCols).Add(paraName, MDBGetType.GetType(MdbType), size));
                #endif
            }
            catch (Exception exception)
            {
                parameter = null;
#if POSTGRESQL
                throw new MDBException(exception, exception.Message);
#else
                OracleException ex = (OracleException)exception;
                throw new MDBException(exception, exception.Message, ex.Number);
#endif
            }
            return parameter;
        }

        public MDBParameter Add(string paraName, MDBType MdbType, int size, string sourceColumn)
        {
            MDBParameter parameter = null;
            try
            {
                #if POSTGRESQL
                parameter = new MDBParameter(((NpgsqlParameterCollection)this.paramCols).Add(paraName, MDBGetType.GetType(MdbType), size, sourceColumn));
                #else
                parameter = new MDBParameter(((OracleParameterCollection)this.paramCols).Add(paraName, MDBGetType.GetType(MdbType), size, sourceColumn));
                #endif
            }
            catch (Exception exception)
            {
                parameter = null;
#if POSTGRESQL
                throw new MDBException(exception, exception.Message);
#else
                OracleException ex = (OracleException)exception;
                throw new MDBException(exception, exception.Message, ex.Number);
#endif
            }
            return parameter;
        }

        public void Clear()
        {
            try
            {
                this.paramCols.Clear();
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

        public bool Contains(object value)
        {
            return this.paramCols.Contains(value);
        }

        public bool Contains(string value)
        {
            return this.paramCols.Contains(value);
        }

        public void CopyTo(Array array, int index)
        {
            this.paramCols.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return this.paramCols.GetEnumerator();
        }

        public int IndexOf(object value)
        {
            return this.paramCols.IndexOf(value);
        }

        public int IndexOf(string value)
        {
            return this.paramCols.IndexOf(value);
        }

        public void Insert(int i, object value)
        {
            try
            {
                this.paramCols.Insert(i, value);
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

        public void Remove(object value)
        {
            try
            {
                this.paramCols.Remove(value);
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

        public void RemoveAt(int i)
        {
            try
            {
                this.paramCols.RemoveAt(i);
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

        public void RemoveAt(string i)
        {
            try
            {
                this.paramCols.RemoveAt(i);
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

        public int Count
        {
            get
            {
                return this.paramCols.Count;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return true;
            }
        }

        public object this[int i]
        {
            get
            {
                object obj2=null;
                try
                {
                    obj2 = new MDBParameter((IDbDataParameter)this.paramCols[i]);
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
                return obj2;
            }
            set
            {
                this.paramCols[i] = ((MDBParameter)value).para;
            }
        }

        public object this[string i]
        {
            get
            {
                object obj2=null;
                try
                {
                    obj2 = new MDBParameter((IDbDataParameter)this.paramCols[i]);
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
                return obj2;
            }
            set
            {
                this.paramCols[i] = ((MDBParameter)value).para;
            }
        }

        public object SyncRoot
        {
            get
            {
                return null;
            }
        }
    }
}
