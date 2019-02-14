using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKYDatabase;
using System.Data;
using System.Data.SqlClient;

namespace TienIch
{
    public class DsThongBao
    {
        string sTable = "dsthongbao";
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
                return dt;
            }
            catch
            {
                return null;
            }
        }


        public bool Insert(SqlConnection conn, string s_NoiDung)
        {
            try
            {
                string s_MaQL = DateTime.Now.ToString("yymmddhhmmssfff");

                string s_SQL = "Insert into " + Database.Schema + "." + this.sTable + " (maql, noidung, ngayud) "
                                                 + " values (@p_maql, @p_noidung,@p_ngayud) ";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = s_MaQL;
                cmd.Parameters.Add("@p_noidung", SqlDbType.NVarChar).Value = s_NoiDung;
                cmd.Parameters.Add("@p_ngayud", SqlDbType.DateTime).Value = DateTime.Now;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable LoadDsHienThiThongBao(SqlConnection conn)
        {
            try
            {
                string s_SQL = "select maql, " + Database.SoLanHienThiThongBaoTraXe + " as solanhienthi,ngayud,noidung from " + Database.Schema + "." + this.sTable
                    + " where trangthai = 0 ";
                DataTable dt = new DataTable();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = s_SQL;

                SqlDataAdapter sqlAdt = new SqlDataAdapter(s_SQL, conn);
                sqlAdt.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateTrangThai(SqlConnection conn)
        {
            try
            {
                string s_SQL = "update " + Database.Schema + "." + this.sTable + " set trangthai = 1 ";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;
                
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
