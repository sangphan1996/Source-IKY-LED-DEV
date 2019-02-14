using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKYDatabase;
using System.Data.SqlClient;
using System.Data;

namespace TienIch
{
    public class DsTheBH
    {
        private string sTable = "dsthebh";
        public string sIDThe = "";
        public string sSoThe = "";
        public string sHoTen = "";
        public string sBienSoXe = "";
        public string sSDT = "";
        public string sDiaChi = "";

        public bool Insert(SqlConnection conn)
        {
            try
            {
                string s_MaQL = DateTime.Now.ToString("yymmddhhmmssfff");

                string s_SQL = "Insert into " + Database.Schema + "." + this.sTable + " (maql, idthe, sothe,hoten,biensoxe,sdt,diachi) "
                                                 + " values (@maql, @idthe,@sothe,@hoten,@biensoxe,@sdt,@diachi) ";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@maql", SqlDbType.NVarChar).Value = s_MaQL;
                cmd.Parameters.Add("@idthe", SqlDbType.NVarChar).Value = this.sIDThe;
                cmd.Parameters.Add("@sothe", SqlDbType.NVarChar).Value = this.sSoThe;
                cmd.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = this.sHoTen;
                cmd.Parameters.Add("@biensoxe", SqlDbType.NVarChar).Value = this.sBienSoXe;
                cmd.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = this.sSDT;
                cmd.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = this.sDiaChi;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(SqlConnection conn)
        {
            try
            {
                string s_SQL = "update " + Database.Schema + "." + this.sTable + " set sothe = @sothe,hoten=@hoten,biensoxe=@biensoxe,sdt=@sdt,diachi=@diachi where idthe = @idthe ";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@idthe", SqlDbType.NVarChar).Value = this.sIDThe;
                cmd.Parameters.Add("@sothe", SqlDbType.NVarChar).Value = this.sSoThe;
                cmd.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = this.sHoTen;
                cmd.Parameters.Add("@biensoxe", SqlDbType.NVarChar).Value = this.sBienSoXe;
                cmd.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = this.sSDT;
                cmd.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = this.sDiaChi;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable LoadThongTin(SqlConnection conn)
        {
            try
            {
                string s_SQL = "select idthe,sothe,hoten,sdt,biensoxe,diachi from " + Database.Schema + "." + this.sTable
                    + " where idthe = '" + this.sIDThe + "' ";
                DataTable dt = new DataTable();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = s_SQL;

                SqlDataAdapter sqlAdt = new SqlDataAdapter(s_SQL, conn);
                sqlAdt.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    this.sSoThe = r["sothe"].ToString();
                    this.sHoTen = r["hoten"].ToString();
                    this.sDiaChi = r["diachi"].ToString();
                    this.sBienSoXe = r["biensoxe"].ToString();
                    this.sSDT = r["sdt"].ToString();
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

    }
}
