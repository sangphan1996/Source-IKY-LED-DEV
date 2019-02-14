using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using IKYDatabase;

namespace TienIch
{
    public class DsKhachHang
    {
        string sTable = Database.Schema + "." + "dskhachhang";

        public DataTable LoadHoTen(SqlConnection conn)
        {
            try
            {
                string s_SQL = "select distinct rtrim(hoten) as hoten from " + this.sTable + " ";
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

        public DataTable LoadBienSoXe(SqlConnection conn)
        {
            try
            {
                string s_SQL = "select distinct rtrim(biensoxe) as biensoxe from " + this.sTable + " ";
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

        public DataTable Load(SqlConnection conn)
        {
            try
            {
                string s_SQL = "select maql,rtrim(hoten) as hoten,rtrim(biensoxe) as biensoxe from " + this.sTable + " ";
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

        public DataTable LoadTheoMaQL(SqlConnection conn,string sMaQl)
        {
            try
            {
                string s_SQL = "select maql,rtrim(hoten) as hoten,rtrim(biensoxe) as biensoxe from " + this.sTable + " where maql=" + sMaQl + "";
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


        public DataTable LoadDSKHChoSuaChua(SqlConnection conn)
        {
            try
            {
                string s_SQL = "select maql,rtrim(hoten) as hoten,rtrim(biensoxe) as biensoxe,ngayud from " + this.sTable + " where trangthai=" + (int)TrangThai.TrangThaiKhachHang.DangChoSuaChua;
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

        public bool Insert(SqlConnection conn, string s_HoTen, string s_BienSoXe)
        {
            try
            {
                string s_MaQL = DateTime.Now.ToString("yymmddhhmmssfff");

                string s_SQL = "Insert into " + this.sTable + " (maql, hoten, biensoxe,ngayud,trangthai) "
                                                 + " values (@p_maql, @p_hoten, @p_biensoxe,@p_ngayud,@p_trangthai) ";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = s_MaQL;
                cmd.Parameters.Add("@p_hoten", SqlDbType.NVarChar).Value = s_HoTen;
                cmd.Parameters.Add("@p_biensoxe", SqlDbType.NVarChar).Value = s_BienSoXe;
                cmd.Parameters.Add("@p_ngayud", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@p_trangthai", SqlDbType.Int).Value = TienIch.TrangThai.TrangThaiKhachHang.DangChoSuaChua;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Insert(SqlConnection conn, string s_HoTen, string s_BienSoXe, string s_GhiChu)
        {
            try
            {
                string s_MaQL = DateTime.Now.ToString("yymmddhhmmssfff");

                string s_SQL = "Insert into " + this.sTable + " (maql, hoten, biensoxe,ngayud,trangthai,ghichu) "
                                                 + " values (@p_maql, @p_hoten, @p_biensoxe,@p_ngayud,@p_trangthai,@ghichu) ";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = s_MaQL;
                cmd.Parameters.Add("@p_hoten", SqlDbType.NVarChar).Value = s_HoTen;
                cmd.Parameters.Add("@p_biensoxe", SqlDbType.NVarChar).Value = s_BienSoXe;
                cmd.Parameters.Add("@p_ngayud", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@p_trangthai", SqlDbType.Int).Value = TienIch.TrangThai.TrangThaiKhachHang.DangChoSuaChua;
                cmd.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = s_GhiChu;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string Insert_ReturnMaQL(SqlConnection conn, string s_HoTen, string s_BienSoXe)
        {
            try
            {
                string s_MaQL = DateTime.Now.ToString("yymmddhhmmssfff");

                string s_SQL = "Insert into " + this.sTable + " (maql, hoten, biensoxe,ngayud,trangthai) "
                                                 + " values (@p_maql, @p_hoten, @p_biensoxe,@p_ngayud,@p_trangthai) ";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = s_MaQL;
                cmd.Parameters.Add("@p_hoten", SqlDbType.NVarChar).Value = s_HoTen;
                cmd.Parameters.Add("@p_biensoxe", SqlDbType.NVarChar).Value = s_BienSoXe;
                cmd.Parameters.Add("@p_ngayud", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@p_trangthai", SqlDbType.Int).Value = TienIch.TrangThai.TrangThaiKhachHang.DangSuaChua;

                cmd.ExecuteNonQuery();
                return s_MaQL;
            }
            catch
            {
                return null;
            }
        }

        public string Insert_ReturnMaQL(SqlConnection conn, string s_HoTen, string s_BienSoXe, string s_GhiChu)
        {
            try
            {
                string s_MaQL = DateTime.Now.ToString("yymmddhhmmssfff");

                string s_SQL = "Insert into " + this.sTable + " (maql, hoten, biensoxe,ngayud,trangthai,ghichu) "
                                                 + " values (@p_maql, @p_hoten, @p_biensoxe,@p_ngayud,@p_trangthai,@ghichu) ";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = s_MaQL;
                cmd.Parameters.Add("@p_hoten", SqlDbType.NVarChar).Value = s_HoTen;
                cmd.Parameters.Add("@p_biensoxe", SqlDbType.NVarChar).Value = s_BienSoXe;
                cmd.Parameters.Add("@p_ngayud", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@p_trangthai", SqlDbType.Int).Value = TienIch.TrangThai.TrangThaiKhachHang.DangSuaChua;
                cmd.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = s_GhiChu;

                cmd.ExecuteNonQuery();
                return s_MaQL;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateTrangThai(SqlConnection conn, string s_MaQL, TrangThai.TrangThaiKhachHang TT_TrangThai)
        {
            try
            {                
                string s_SQL = "Update " + this.sTable + " set trangthai = @p_trangthai where maql = @p_maql";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = s_MaQL;
                cmd.Parameters.Add("@p_trangthai", SqlDbType.Int).Value = TT_TrangThai;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateThongTin(SqlConnection conn, string s_MaQL, string s_HoTen, string s_BienSoXe)
        {
            try
            {
                string s_SQL = "Update " + this.sTable + " set hoten=@hoten,biensoxe=@biensoxe where maql = @maql";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@maql", SqlDbType.NVarChar).Value = s_MaQL;
                cmd.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = s_HoTen;
                cmd.Parameters.Add("@biensoxe", SqlDbType.NVarChar).Value = s_BienSoXe;

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
