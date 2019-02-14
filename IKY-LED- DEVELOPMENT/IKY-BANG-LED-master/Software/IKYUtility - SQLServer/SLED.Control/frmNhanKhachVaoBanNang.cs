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
    public partial class frmNhanKhachVaoBanNang : frmBase
    {
        SqlConnection conn = null;
        string s_MaQL = "";
        string s_HoTen = "";
        string s_BienSoXe = "";
        string s_SerialPort = "";
        public frmNhanKhachVaoBanNang()
        {
            InitializeComponent();
        }

        public frmNhanKhachVaoBanNang(SqlConnection _conn, string _maql, string s__SerialPort)
        {
            InitializeComponent();
            this.conn = _conn;
            this.s_MaQL = _maql;
            if (conn.State == ConnectionState.Open)
            {
                try
                {
                    DsBanNang ds = new DsBanNang();
                    DataTable dt = ds.LoadDsTheoTrangThai(conn, TrangThai.TrangThaiBanNang.ChoNhanXe);
                    cbbDsBanNang.Properties.DataSource = dt;
                    DsKhachHang dsKH = new DsKhachHang();
                    DataTable dtKH = dsKH.LoadTheoMaQL(conn, s_MaQL);
                    if (dtKH != null && dtKH.Rows.Count > 0)
                    {
                        DataRow r = dtKH.Rows[0];
                        s_HoTen = r["hoten"].ToString();
                        s_BienSoXe = r["biensoxe"].ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("Xử lý lỗi !", "Lỗi");
                }
            }
            this.s_SerialPort = s__SerialPort;
        }        

        private void frmNhanKhachVaoBanNang_Load(object sender, EventArgs e)
        {
            btnDongY.LinkClicked += btnDongY_LinkClicked;
            cbbDsBanNang.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            if (s_SerialPort != "")
            {
                TienIch.ComPort.serialPort_Open(s_SerialPort, false);
            }
        }

        private void frmNhanKhachVaoBanNang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
            else if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnDongY_LinkClicked(null, null);
            }
        }

        void btnDongY_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (txtGio.Text != "" && txtPhut.Text != "" && cbbDsBanNang.EditValue.ToString() != "")
            {
                Int32 i_TG = Convert.ToInt16(txtGio.Text) * 60 + Convert.ToInt16(txtPhut.Text);
                string s_ID = cbbDsBanNang.EditValue.ToString();
                DsBanNang dsBN = new DsBanNang();
                dsBN.UpdateTrangThai(conn, s_ID, TrangThai.TrangThaiBanNang.DangSuaChua);
                dsBN.UpdateThongTinKH(conn, s_ID, s_MaQL, (short)i_TG);
                DsKhachHang dsKH = new DsKhachHang();
                dsKH.UpdateTrangThai(conn, s_MaQL, TrangThai.TrangThaiKhachHang.DangSuaChua);
                if (i_TG > 0)
                {
                    string s_ThoiGian = Convert.ToDecimal(txtGio.Text == "" ? "0" : txtGio.Text).ToString("00") + ":" + Convert.ToDecimal(txtPhut.Text == "" ? "0" : txtPhut.Text).ToString("00");
                    string str = "#LED," + s_ID + "," + TienIch.Access.convertToUnSign3(s_HoTen).ToUpper() + "," + s_BienSoXe + "," + s_ThoiGian + "*";
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
                    TienIch.ComPort.serialPort_Send(data, 0, data.Length);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
            }
        }
    }
}
