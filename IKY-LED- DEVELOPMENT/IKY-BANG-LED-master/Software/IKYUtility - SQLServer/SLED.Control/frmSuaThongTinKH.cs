using IKYDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TienIch;

namespace IKY.Control
{
    public partial class frmSuaThongTinKH : frmBase
    {
        SqlConnection conn = null;
        string s_SerialPort = "";
        string s_IDBanNang = "";
        int i_TongTG = 0;
        int i_TGConLai_TinhTheoPhut = 0;
        int i_TGConLai_TinhTheoGiay = 0;
        string s_HoTen = "";
        string s_BienSoXe = "";
        string s_MaKH = "";
        TrangThai.TrangThaiBanNang TT_trangthai = TrangThai.TrangThaiBanNang.KhongXacDinh;
        public frmSuaThongTinKH()
        {
            InitializeComponent();
        }

        public frmSuaThongTinKH(SqlConnection _conn,string s_Com, string _s_IDBanNang)
            :this()
        {
            this.conn = _conn;
            this.s_SerialPort = s_Com;
            this.s_IDBanNang = _s_IDBanNang;
        }

        private void frmSuaThongTinKH_Load(object sender, EventArgs e)
        {
            btnDongY.LinkClicked += btnDongY_LinkClicked; 
            if (conn == null || conn.State != ConnectionState.Open)
            {
                Database.Open(ref this.conn);
            }
            if (s_SerialPort != "")
            {
                TienIch.ComPort.serialPort_Open(s_SerialPort, false);
            }
            if (conn.State == ConnectionState.Open)
            {
                TienIch.DsBanNang ds = new TienIch.DsBanNang();
                DataTable dt = ds.LoadDsTheoID(conn, s_IDBanNang);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow r_BN = dt.Rows[0];
                    this.s_MaKH = r_BN["makhachhang"].ToString();
                    this.s_HoTen = r_BN["hoten"].ToString();
                    this.s_BienSoXe = r_BN["biensoxe"].ToString();
                    TT_trangthai = (TrangThai.TrangThaiBanNang)Convert.ToInt16(r_BN["trangthai"].ToString());
                    i_TongTG = Convert.ToInt32(r_BN["tongthoigian"].ToString());
                    DateTime TGCapNhat = r_BN["thoigianbd"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(r_BN["thoigianbd"]);
                    TimeSpan diff = DateTime.Now.Subtract(TGCapNhat);
                    double minutes = diff.TotalMinutes;
                    double seconds = diff.TotalSeconds;
                    //Int32 minutes = Convert.ToInt32(Math.Ceiling(diff.TotalMinutes)); //Làm tròn lên để hiển thị khớp với bảng LED
                    i_TGConLai_TinhTheoGiay = Convert.ToInt32(seconds) >= (Convert.ToInt32(r_BN["tongthoigian"]) * 60) ? 0 : ((Convert.ToInt32(r_BN["tongthoigian"]) * 60) - Convert.ToInt32(seconds));
                    i_TGConLai_TinhTheoPhut = Convert.ToInt32(minutes) >= Convert.ToInt32(r_BN["tongthoigian"]) ? 0 : Convert.ToInt32(r_BN["tongthoigian"]) - Convert.ToInt32(minutes);
                }
            }
            if (TT_trangthai == TrangThai.TrangThaiBanNang.ChoNhanXe)
            {
                txtHoTen.Enabled = false; ;
                txtBienSoXe.Enabled = false;
            }
            txtBanNang.Text = s_IDBanNang;
            txtHoTen.Text = s_HoTen;
            txtBienSoXe.Text = s_BienSoXe;
            txtThoiGian.Text = i_TGConLai_TinhTheoPhut.ToString() + " Phút";
        }

        private void frmSuaThongTinKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnDongY_LinkClicked(null, null);
            }
        }

        private void btnDongY_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (TT_trangthai == TrangThai.TrangThaiBanNang.ChoNhanXe)
            {
                string str = "#LED," + this.s_IDBanNang.PadLeft(2, '0') + "," + TienIch.Access.convertToUnSign3(this.s_HoTen).ToUpper() + "," + this.s_BienSoXe + "," + "00:00" + "*";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
                TienIch.ComPort.serialPort_Send(data, 0, data.Length);
            }
            else if (TT_trangthai == TrangThai.TrangThaiBanNang.DangSuaChua)
            {
                Int32 iGio = i_TGConLai_TinhTheoPhut / 60;
                Int32 iPhut = i_TGConLai_TinhTheoPhut % 60;

                string s_ThoiGian = iGio.ToString("00") + ":" + iPhut.ToString("00");

                string str = "#LED," + this.s_IDBanNang.PadLeft(2, '0') + "," + TienIch.Access.convertToUnSign3(txtHoTen.Text).ToUpper() + "," + this.txtBienSoXe.Text.ToUpper() + "," + s_ThoiGian + "*";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
                TienIch.ComPort.serialPort_Send(data, 0, data.Length);
            }
            if (this.txtHoTen.Text != this.s_HoTen || this.txtBienSoXe.Text != this.s_BienSoXe)
            {
                DsKhachHang ds = new DsKhachHang();
                ds.UpdateThongTin(this.conn, this.s_MaKH, this.txtHoTen.Text, this.txtBienSoXe.Text);
            }
            this.Close();
        }
    }
}
