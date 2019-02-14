using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKYDatabase;

namespace TienIch
{
    public class tshienthi
    {
        string sTable = "tshienthi";

        string s_Header = "";
        string s_Footer = "";

        int i_SoDongHienThi = 0;
        int i_TGHienThi = 0;

        public string Header
        {
            get { return s_Header; }
            set
            {
                s_Header = value;
            }
        }

        public string Footer
        {
            get { return s_Footer; }
            set
            {
                s_Footer = value;
            }
        }

        

        public int SoDongHienThi
        {
            get { return i_SoDongHienThi; }
            set
            {
                i_SoDongHienThi = value;
            }
        }

        public int TGHienThi
        {
            get { return i_TGHienThi; }
            set
            {
                i_TGHienThi = value;
            }
        }

        public bool Check(SqlConnection conn)
        {
            try
            {
                string s_SQL = "select * from " + Database.Schema + "." + this.sTable;
                DataTable dt = new DataTable();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = s_SQL;

                SqlDataAdapter sqlAdt = new SqlDataAdapter(s_SQL, conn);
                sqlAdt.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        } 

        public DataTable LoadAll(SqlConnection conn)
        {
            try
            {
                string s_SQL = "select * from " + Database.Schema + "." + this.sTable;
                DataTable dt = new DataTable();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = s_SQL;

                SqlDataAdapter sqlAdt = new SqlDataAdapter(s_SQL, conn);
                sqlAdt.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    this.s_Header = r["header"].ToString().Trim();
                    this.s_Footer = r["footer"].ToString().Trim();
                    this.i_SoDongHienThi = Convert.ToInt16(r["sodonghienthi"]);
                    this.i_TGHienThi = Convert.ToInt16(r["tghienthi"]);
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public bool Update(SqlConnection conn)
        {
            try
            {                
                if (Check(conn))
                {                   
                    string s_SQL = "Update " + Database.Schema + "." + this.sTable + " set header = @header, footer = @footer,sodonghienthi = @sodonghienthi,tghienthi = @tghienthi,ngayud = @p_ngayud";
                    
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = s_SQL;

                    cmd.Parameters.Add("@header", SqlDbType.NVarChar).Value = this.Header;
                    cmd.Parameters.Add("@footer", SqlDbType.NVarChar).Value = this.Footer;
                    cmd.Parameters.Add("@sodonghienthi", SqlDbType.NVarChar).Value = this.SoDongHienThi;
                    cmd.Parameters.Add("@tghienthi", SqlDbType.Int).Value = this.TGHienThi;
                    cmd.Parameters.Add("@p_ngayud", SqlDbType.DateTime).Value = DateTime.Now;

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string s_MaQL = DateTime.Now.ToString("yymmddhhmmssfff");
                    string s_SQL = "Insert into " + Database.Schema + "." + this.sTable + " (maql, header, footer, sodonghienthi,tghienthi) "
                                                     + " values (@p_maql, @header, @footer,@sodonghienthi,@tghienthi) ";

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = s_SQL;

                    cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = s_MaQL;
                    cmd.Parameters.Add("@header", SqlDbType.NVarChar).Value = this.Header;
                    cmd.Parameters.Add("@footer", SqlDbType.NVarChar).Value = this.Footer;
                    cmd.Parameters.Add("@sodonghienthi", SqlDbType.Int).Value = this.SoDongHienThi;
                    cmd.Parameters.Add("@tghienthi", SqlDbType.Int).Value = this.TGHienThi;
                    
                    cmd.ExecuteNonQuery();
                }                                
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
