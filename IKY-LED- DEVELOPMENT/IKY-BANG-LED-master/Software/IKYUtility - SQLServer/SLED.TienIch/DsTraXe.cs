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
    public class DsTraXe
    {
        string sTable = Database.Schema + "." + "dstraxe";        
        public DataTable LoadAll(SqlConnection conn)
        {
            string s_SQL = "select * from " + this.sTable;
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = s_SQL;

            SqlDataAdapter sqlAdt = new SqlDataAdapter(s_SQL, conn);
            sqlAdt.Fill(dt);
            return dt;
        }

        public DataTable LoadDsChuaLayXe(SqlConnection conn)
        {
            try
            {
                string s_TuNgay = DateTime.Today.ToString("yyyy-MM-dd") + " 00:00";
                string s_DenNgay = DateTime.Today.ToString("yyyy-MM-dd") + " 23:59";
                
                string s_SQL = "select a.maql,b.hoten,b.biensoxe,a.ngayud from " + this.sTable + " a "
                    + " inner join " + Database.Schema + ".dskhachhang b on a.makhachhang = b.maql"
                    + " where a.trangthai = 0 "
                    + " and a.ngayud between '" + s_TuNgay + "' and '" + s_DenNgay + "'";
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

        public DataTable LoadDsGoiLayXe(SqlConnection conn)
        {
            try
            {
                string s_SQL = "select a.maql,b.hoten,b.biensoxe,a.ngayud from " + this.sTable + " a "
                    + " inner join " + Database.Schema + ".dskhachhang b on a.makhachhang = b.maql"
                    + " where a.trangthai = 0 and a.goi = 1";
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

        public DataTable LoadDsHienThiThongBao(SqlConnection conn)
        {
            try
            {
                DateTime dti_TuNgay = DateTime.Now.AddMinutes(-1);
                DateTime dti_DenNgay = DateTime.Now;

                string s_TuNgay = dti_TuNgay.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string s_DenNgay = dti_DenNgay.ToString("yyyy-MM-dd HH:mm:ss.fff");

                string s_SQL = "select a.maql, " + Database.SoLanHienThiThongBaoTraXe + " as solanhienthi,a.ngayud,b.hoten,b.biensoxe from " + this.sTable + " a"
                    + " inner join " + Database.Schema + ".dskhachhang b on a.makhachhang = b.maql"
                    + " where a.ngayud between '" + s_TuNgay + "' and '" + s_DenNgay + "'";
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

        public bool Insert(SqlConnection conn,string s_MaKH)
        {
            try
            {
                string s_MaQL = DateTime.Now.ToString("yymmddhhmmssfff");

                string s_SQL = "Insert into " + this.sTable + " (maql, makhachhang, ngayud) "
                                                 + " values (@p_maql, @p_makhachhang,@p_ngayud) ";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = s_MaQL;
                cmd.Parameters.Add("@p_makhachhang", SqlDbType.NVarChar).Value = s_MaKH;
                cmd.Parameters.Add("@p_ngayud", SqlDbType.DateTime).Value = DateTime.Now;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTrangThai(SqlConnection conn, string s_MaQL)
        {
            try
            {
                string s_SQL = "update " + this.sTable + " set trangthai = 1 where maql = @p_maql ";                

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = s_MaQL;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTrangThaiGoiLayXe(SqlConnection conn, string s_MaQL, TrangThai.TraiThaiGoiLayXe TT)
        {
            try
            {
                string s_SQL = "update " + this.sTable + " set goi = @goi where maql = @p_maql ";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = s_MaQL;
                cmd.Parameters.Add("@goi", SqlDbType.Int).Value = (int)TT;

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
