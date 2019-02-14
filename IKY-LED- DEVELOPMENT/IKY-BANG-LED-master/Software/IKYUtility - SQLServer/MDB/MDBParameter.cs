using System;
using System.Data;

namespace MDB
{
    public class MDBParameter
    {
        internal IDbDataParameter para;

        internal MDBParameter(IDbDataParameter p)
        {
            this.para = p;
        }

        public ParameterDirection Direction
        {
            get
            {
                return this.para.Direction;
            }
            set
            {
                this.para.Direction = value;
            }
        }

        public DataRowVersion SourceVersion
        {
            get
            {
                return this.para.SourceVersion;
            }
            set
            {
                this.para.SourceVersion = value;
            }
        }

        public object Value
        {
            get
            {
                return this.para.Value;
            }
            set
            {
                this.para.Value = value;
            }
        }
    }
}
