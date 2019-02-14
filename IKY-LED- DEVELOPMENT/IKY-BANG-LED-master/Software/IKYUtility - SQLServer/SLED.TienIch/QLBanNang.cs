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
    public class QLBanNang
    {
        string sTable = Database.Schema + "." + "qlbannang";
        public DataTable LoadDsBanNangHoatDong(SqlConnection conn)
        {
            string s_SQL = "select id,rtrim(kythuatvien) as kythuatvien from dsbannang";
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = s_SQL;

            SqlDataAdapter sqlAdt = new SqlDataAdapter(s_SQL, conn);
            sqlAdt.Fill(dt);
            return dt;
        }

        public DataTable LoadBaoCaoTheoNgay(SqlConnection conn, DateTime dti_TuNgay, DateTime dti_DenNgay)
        {
            if (dti_TuNgay == Convert.ToDateTime(null)) { dti_TuNgay = DateTime.Today; }
            if (dti_DenNgay == Convert.ToDateTime(null)) { dti_DenNgay = dti_TuNgay; }
            if (dti_TuNgay == Convert.ToDateTime(null) || dti_DenNgay == Convert.ToDateTime(null)) { return null; }
            string s_TuNgay = dti_TuNgay.ToString("yyyy-MM-dd") + " 00:00";
            string s_DenNgay = dti_DenNgay.ToString("yyyy-MM-dd") + " 23:59";

            string s_SQL = "select a.mabannang,a.ngayud,a.thoigian,b.kythuatvien,c.hoten,c.biensoxe,c.ghichu from " + Database.Schema + ".qlbannang a "
                + "inner join " + Database.Schema + ".dsbannang b on b.maql = a.mabannang "
                + "inner join " + Database.Schema + ".dskhachhang c on c.maql = a.makhachhang "
                + "where a.ngayud between '" + s_TuNgay + "' and '" + s_DenNgay + "'";

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = s_SQL;

            SqlDataAdapter sqlAdt = new SqlDataAdapter(s_SQL, conn);
            sqlAdt.Fill(dt);
            return dt;
        }

        public DataTable LoadDsTheoTrangThai(SqlConnection conn, TrangThai.TrangThaiBanNang TT_BanNang)
        {
            try
            {
                string s_SQL = "select id,rtrim(kythuatvien) as kythuatvien from " + Database.Schema + ".dsbannang a left join " + Database.Schema + ".qlbannag b where b.trangthai =" + (int)TT_BanNang + " ";
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

        public bool Insert(SqlConnection conn, string s_MaBN, string s_MaKH, int i_TG)
        {
            try
            {
                string s_MaQL = DateTime.Now.ToString("yymmddhhmmssfff");

                string s_SQL = "Insert into " + this.sTable + " (maql, mabannang, makhachhang,thoigian,ngayud) "
                                                 + " values (@p_maql, @p_mabannang, @p_makhachhang,@p_thoigian,@p_ngayud) ";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s_SQL;

                cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = s_MaQL;
                cmd.Parameters.Add("@p_mabannang", SqlDbType.NVarChar).Value = s_MaBN;
                cmd.Parameters.Add("@p_makhachhang", SqlDbType.NVarChar).Value = s_MaKH;
                cmd.Parameters.Add("@p_thoigian", SqlDbType.Int).Value = i_TG;
                cmd.Parameters.Add("@p_ngayud", SqlDbType.DateTime).Value = DateTime.Now;

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
