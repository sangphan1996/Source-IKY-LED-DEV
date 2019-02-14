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
    public class tshethong
    {
        string sTable = "tshethong";
        string s_CongCom = "COM9";
        string s_TenCty = "TIEN ICH THONG MINH JOINT STOCK COMPANY (iKY)";
        string s_ThongBaoMacDinh = "TIEN ICH THONG MINH JOINT STOCK COMPANY (iKY)";
        int i_TGThongBaoTraXe = 1;

        public string CongCom
        {
            get { return s_CongCom; }
            set
            {
                s_CongCom = value;
            }
        }

        public string TenCty
        {
            get { return s_TenCty; }
            set
            {
                s_TenCty = value;
            }
        }

        public string ThongBaoMacDinh
        {
            get { return s_ThongBaoMacDinh; }
            set
            {
                s_ThongBaoMacDinh = value;
            }
        }

        public int TGThongBaoTraXe
        {
            get { return i_TGThongBaoTraXe; }
            set
            {
                i_TGThongBaoTraXe = value;
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
                    this.s_CongCom = r["congcom"].ToString().Trim();
                    this.TenCty = r["tencty"].ToString().Trim();
                    this.s_ThongBaoMacDinh = r["thongbaomacdinh"].ToString().Trim();
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public bool Update(SqlConnection conn, string congcom, string tencty, string thongbaomacdinh, int thoigiantraxe)
        {
            try
            {
                DataTable dt = LoadAll(conn);
                if(dt != null && dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    string s_MaQL = r["maql"].ToString();
                    string s_SQL = "Update " + Database.Schema + "." + this.sTable + " set congcom = @p_congcom, tencty = @p_tencty,thongbaomacdinh = @p_thongbaomacdinh,thoigiantraxe = @p_thoigiantraxe,ngayud = @p_ngayud where maql = @p_maql";
                    
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = s_SQL;

                    cmd.Parameters.Add("@p_congcom", SqlDbType.NVarChar).Value = congcom == "" ? r["congcom"].ToString() : congcom;
                    cmd.Parameters.Add("@p_tencty", SqlDbType.NVarChar).Value = tencty == "" ? r["tencty"].ToString() : tencty;
                    cmd.Parameters.Add("@p_thongbaomacdinh", SqlDbType.NVarChar).Value = thongbaomacdinh == "" ? r["thongbaomacdinh"].ToString() : thongbaomacdinh;
                    cmd.Parameters.Add("@p_thoigiantraxe", SqlDbType.Int).Value = thoigiantraxe;
                    cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = s_MaQL;
                    cmd.Parameters.Add("@p_ngayud", SqlDbType.DateTime).Value = DateTime.Now;

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string s_MaQL = DateTime.Now.ToString("yymmddhhmmssfff");
                    string s_SQL = "Insert into " + Database.Schema + "." + this.sTable + " (maql, congcom, tencty,thongbaomacdinh,thoigiantraxe,ngayud) "
                                                     + " values (@p_maql, @p_congcom, @p_tencty,@p_thongbaomacdinh,@p_thoigiantraxe,@p_ngayud) ";

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = s_SQL;

                    cmd.Parameters.Add("@p_congcom", SqlDbType.NVarChar).Value = congcom == "" ? "COM1" : congcom;
                    cmd.Parameters.Add("@p_tencty", SqlDbType.NVarChar).Value = tencty == "" ? "Công ty Cổ phần Công nghệ Tiện ích Thông minh" : tencty;
                    cmd.Parameters.Add("@p_thongbaomacdinh", SqlDbType.NVarChar).Value = thongbaomacdinh == "" ? "Kính chào quý khách" : thongbaomacdinh;
                    cmd.Parameters.Add("@p_thoigiantraxe", SqlDbType.Int).Value = thoigiantraxe;
                    cmd.Parameters.Add("@p_maql", SqlDbType.NVarChar).Value = s_MaQL;
                    cmd.Parameters.Add("@p_ngayud", SqlDbType.DateTime).Value = DateTime.Now;

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
