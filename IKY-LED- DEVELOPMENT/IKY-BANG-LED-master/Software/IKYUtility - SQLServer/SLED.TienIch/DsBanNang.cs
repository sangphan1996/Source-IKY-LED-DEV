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
    public class DsBanNang
    {
        string sTable = "dsbannang";

        public DataTable LoadAll(SqlConnection conn)
        {
            try
            {
                string s_SQL = "select a.maql,rtrim(a.kythuatvien) as kythuatvien,a.ndhienthi,a.trangthai,a.thoigianbd,a.tongthoigian, b.hoten,b.biensoxe from " + Database.Schema + "." + this.sTable + " a "
                    + "left join " + Database.Schema + ".dskhachhang b on a.makhachhang = b.maql";
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

        public DataTable LoadTheoTrangThaiKichHoat(SqlConnection conn,TrangThai.TrangThaiKichHoatBanNang TT_Trangthai)
        {
            try
            {
                string s_SQL = "select a.maql,rtrim(a.kythuatvien) as kythuatvien,a.ndhienthi,a.trangthai,a.thoigianbd,a.tongthoigian, b.hoten,b.biensoxe from " + Database.Schema + "." + this.sTable + " a "
                    + "left join " + Database.Schema + ".dskhachhang b on a.makhachhang = b.maql where a.kichhoat = " + (int)TT_Trangthai;
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

        public DataTable LoadDsTheoID(SqlConnection conn, string s_MaQL)
        {
            try
            {
                string s_SQL = "select a.maql,a.makhachhang,a.tongthoigian,rtrim(a.kythuatvien) as kythuatvien,a.trangthai,a.thoigianbd,a.ndhienthi,b.hoten,b.biensoxe from " + Database.Schema + "." + this.sTable + " a"
                    + " left join " + Database.Schema + ".dskhachhang b on a.makhachhang = b.maql where a.maql = " + s_MaQL + " ";
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

        public TrangThai.TrangThaiBanNang LoadTrangThaiBanNang(SqlConnection conn, string s_MaQL)
        {
            try
            {
                string s_SQL = "select trangthai from " + Database.Schema + "." + this.sTable + " where maql =" + s_MaQL + " ";
                DataTable dt = new DataTable();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = s_SQL;

                SqlDataAdapter sqlAdt = new SqlDataAdapter(s_SQL, conn);
                sqlAdt.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    return (TrangThai.TrangThaiBanNang)Convert.ToInt16(r["trangthai"]);
                }
                else
                {
                    return TrangThai.TrangThaiBanNang.KhongHoatDong;
                }
            }
            catch
            {
                return TrangThai.TrangThaiBanNang.KhongHoatDong;
            }
        }

        public DataTable LoadDsTheoTrangThai(SqlConnection conn, TrangThai.TrangThaiBanNang TT_BanNang)
        {
            try
            {
                string s_SQL = "select maql as id,rtrim(kythuatvien) as kythuatvien from " + Database.Schema + "." + this.sTable + " where trangthai =" + (int)TT_BanNang + " and kichhoat = " + (int)TrangThai.TrangThaiKichHoatBanNang.HoatDong;
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

        public bool Insert(SqlConnection conn, string s_MaQL, string s_KTV, string s_NDHienThi)
        {
            string s_SQL = "";
            DataTable dt = LoadDsTheoID(conn, s_MaQL);
            if(dt != null && dt.Rows.Count > 0)
            {
                s_SQL = "update " + Database.Schema + "." + this.sTable + " set kythuatvien = @p_kythuatvien,ngayud = @p_ngayud,ndhienthi = @p_ndhienthi,trangthai = @p_trangthai, kichhoat = " + (int)TrangThai.TrangThaiKichHoatBanNang.HoatDong + " "
                                                 + " where maql = @p_maql";
            }
            else
            {
                s_SQL = "Insert into " + Database.Schema + "." + this.sTable + " (maql, kythuatvien,ngayud,ndhienthi,trangthai,kichhoat) "
                                                 + " values (@p_maql,@p_kythuatvien,@p_ngayud,@p_ndhienthi,@p_trangthai," + (int)TrangThai.TrangThaiKichHoatBanNang.HoatDong + ") ";
            }
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = s_MaQL;                
                cmd.Parameters.Add("@p_kythuatvien", SqlDbType.NVarChar).Value = s_KTV;
                cmd.Parameters.Add("@p_ngayud", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@p_ndhienthi", SqlDbType.NVarChar).Value = s_NDHienThi;
                cmd.Parameters.Add("@p_trangthai", SqlDbType.Int).Value = (int)TrangThai.TrangThaiBanNang.ChoNhanXe;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(SqlConnection conn, string s_MaQL)
        {
            try
            {
                string sql = "Delete from " + Database.Schema + "." + this.sTable + " where id = @p_maql ";

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = sql;

                cmd.Parameters.Add("@p_maql", SqlDbType.Int).Value = Convert.ToInt16(s_MaQL);

                // Thực thi Command (Dùng cho delete, insert, update).
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTrangThai(SqlConnection conn, string s_MaQL, TrangThai.TrangThaiBanNang TT_TrangThai)
        {
            try
            {
                string s_SQL = "Update " + Database.Schema + "." + this.sTable + " set trangthai = @p_trangthai where maql = @p_maql";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = Convert.ToInt16(s_MaQL);
                cmd.Parameters.Add("@p_trangthai", SqlDbType.Int).Value = TT_TrangThai;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTrangThaiKichHoat(SqlConnection conn, string s_MaQL, TrangThai.TrangThaiKichHoatBanNang TT_TrangThai)
        {
            try
            {
                string s_SQL = "Update " + Database.Schema + "." + this.sTable + " set kichhoat = @p_kichhoat where maql = @p_maql";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = Convert.ToInt16(s_MaQL);
                cmd.Parameters.Add("@p_kichhoat", SqlDbType.Int).Value = (int)TT_TrangThai;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateThongTinKH(SqlConnection conn, string s_MaBN, string s_MaKH, Int16 i_ThoiGian)
        {
            try
            {
                string s_SQL = "Update " + Database.Schema + "." + this.sTable + " set makhachhang = @p_makhachhang,thoigianbd = @p_thoigianbd,tongthoigian = @p_tongthoigian where maql = @p_maql";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = Convert.ToInt16(s_MaBN);
                cmd.Parameters.Add("@p_makhachhang", SqlDbType.NVarChar).Value = s_MaKH;
                cmd.Parameters.Add("@p_tongthoigian", SqlDbType.Int).Value = i_ThoiGian;
                cmd.Parameters.Add("@p_thoigianbd", SqlDbType.DateTime).Value = DateTime.Now;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateThoiGianSuaChua(SqlConnection conn, string s_MaQL, Int16 i_ThoiGian)
        {
            try
            {
                string s_SQL = "Update " + Database.Schema + "." + this.sTable + " set tongthoigian = @p_tongthoigian where maql = @p_maql";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = Convert.ToInt16(s_MaQL);
                cmd.Parameters.Add("@p_tongthoigian", SqlDbType.Int).Value = i_ThoiGian;

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
