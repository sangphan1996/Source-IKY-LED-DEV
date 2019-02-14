using System;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace MDB
{
    public class MDBException : Exception
    {
        private string message;
        //private ResourceManager rm;
        private Exception systemException;
        public int ErrorCode;
        public int RowPos;
        public string Extra;
        public string FieldName;
        public decimal ParentKey;

        public MDBException(Exception e, string msg)
        {
            this.ErrorCode = 1;
            if (e.Message.Contains("duplicate key value violates unique constraint"))
            {
                ErrorCode = 23505;
            }
            else if (e.Message.Contains("closed by the remote host.") || e.Message.Contains("The Connection is broken.")
                || e.Message.Contains("Failed to establish a connection") || e.Message.Contains("the database system is starting up")
                     || e.Message.Contains(" the database system is starting up"))
            {
                ErrorCode = 999;
            }
            this.systemException = e;
            this.message = msg;
            LogError();
            this.FieldName = "";
            this.RowPos = -1;
            this.ParentKey = -1M;
        }

        public MDBException(Exception e, string msg, int errorcode)
        {
            this.ErrorCode = errorcode;
            if (e.Message.Contains("duplicate key value violates unique constraint"))
            {
                ErrorCode = 23505;
            }
            else if (e.Message.Contains("closed by the remote host.") || e.Message.Contains("The Connection is broken.")
                || e.Message.Contains("Failed to establish a connection") || e.Message.Contains("the database system is starting up")
                     || e.Message.Contains(" the database system is shut"))
            {
                ErrorCode = 999;
            }
            this.systemException = e;
            this.message = msg;
            LogError();
            this.RowPos = -1;
            this.ParentKey = -1M;
        }

        public MDBException(Exception e, string msg, string fieldname)
        {
            this.ErrorCode = 1;
            if (e.Message.Contains("duplicate key value violates unique constraint"))
            {
                ErrorCode = 23505;
            }
            else if (e.Message.Contains("closed by the remote host.") || e.Message.Contains("The Connection is broken.")
                || e.Message.Contains("Failed to establish a connection") || e.Message.Contains("the database system is starting up")
                     || e.Message.Contains(" the database system is shut"))
            {
                ErrorCode = 999;
            }
            //this.rm = null;
            this.systemException = e;
            this.message = msg;
            this.FieldName = fieldname;
            this.RowPos = -1;
            this.ParentKey = -1M;
        }

        public MDBException(Exception e, string msg, string fieldname, int pos)
        {
            this.ErrorCode = 1; 
            if (e.Message.Contains("duplicate key value violates unique constraint"))
            {
                ErrorCode = 23505;
            }
            else if (e.Message.Contains("closed by the remote host.") || e.Message.Contains("The Connection is broken.")
                || e.Message.Contains("Failed to establish a connection") || e.Message.Contains("the database system is starting up")
                     || e.Message.Contains(" the database system is shut"))
            {
                ErrorCode = 999;
            }
            this.systemException = e;
            this.message = msg;
            this.FieldName = fieldname;
            this.RowPos = pos;
            this.ParentKey = -1M;
        }

        public MDBException(Exception e, string msg, string fieldname, string extra)
        {
            this.ErrorCode = 1;
            if (e.Message.Contains("duplicate key value violates unique constraint"))
            {
                ErrorCode = 23505;
            }
            else if (e.Message.Contains("closed by the remote host.") || e.Message.Contains("The Connection is broken.")
                || e.Message.Contains("Failed to establish a connection") || e.Message.Contains("the database system is starting up")
                     || e.Message.Contains(" the database system is shut"))
            {
                ErrorCode = 999;
            }
            this.systemException = e;
            this.message = msg;
            this.FieldName = fieldname;
            this.Extra = extra;
            this.RowPos = -1;
            this.ParentKey = -1M;
        }

        public MDBException(Exception e, string msg, string fieldname, int pos, decimal key)
        {
            this.ErrorCode = 1;
            if (e.Message.Contains("duplicate key value violates unique constraint"))
            {
                ErrorCode = 23505;
            }
            else if (e.Message.Contains("closed by the remote host.") || e.Message.Contains("The Connection is broken.")
                || e.Message.Contains("Failed to establish a connection") || e.Message.Contains("the database system is starting up")
                     || e.Message.Contains(" the database system is shut"))
            {
                ErrorCode = 999;
            }
            this.systemException = e;
            this.message = msg;
            this.FieldName = fieldname;
            this.RowPos = pos;
            this.ParentKey = key;
        }

        private string GetStringResource(string resID)
        {
        //    string str = this.rm.GetString(resID);
        //    if (str == null)
        //    {
        //        return resID;
        //    }
            return resID;
        }

        public void LogError()
        {
            string str = "";
            str = "Log"+DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + ".txt";
            FileStream stream = new FileStream(str, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.BaseStream.Seek(0L, SeekOrigin.End);
            writer.WriteLine("");
            writer.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Today.ToLongDateString());
            if (this.systemException != null)
            {
                writer.WriteLine(this.MDBMessage + this.systemException.Message);
                writer.WriteLine(this.systemException.Source);
                writer.WriteLine(this.systemException.StackTrace);
            }
            else
            {
                writer.WriteLine(this.MDBMessage);
            }
            writer.Flush();
            stream.Close();
        }

        public void LogError(string s_SQL,string s_Funtion)
        {
            string str = "";
            str = "Log" + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + ".txt";
            FileStream stream = new FileStream(str, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.BaseStream.Seek(0L, SeekOrigin.End);
            writer.WriteLine("");
            writer.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Today.ToLongDateString());
            if (this.systemException != null)
            {
                writer.WriteLine(s_SQL);
                writer.WriteLine(s_Funtion);
                writer.WriteLine(this.MDBMessage + this.systemException.Message);
                writer.WriteLine(this.systemException.Source);
                writer.WriteLine(this.systemException.StackTrace);
            }
            else
            {
                writer.WriteLine(this.MDBMessage);
            }
            writer.Flush();
            stream.Close();
        }

        public void ShowMessage(Form frmParent, bool logged, bool debug)
        {
            //this.LogError();
            //if (this.message != "")
            //{
            //    if ((this.systemException != null) && debug)
            //    {
            //        MDBMessageBox.ShowErrorMessage(this.message + this.systemException.Message + this.systemException.StackTrace);
            //    }
            //    else
            //    {
            //        MDBMessageBox.ShowErrorMessage(this.message);
            //    }
            //}
        }

        public string MDBMessage
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }
        public enum Error
        {
            Config_Host=1,
            Config_Port = 2,
            Config_Database = 3,
            Config_Password = 4,
            Config_User = 5,
            Config_Schema = 6,
        }
    }
}
