using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SLED
{
    public partial class frmTiepNhanXe : Form
    {
        private SQLiteConnection SQLiteCon = null;
        private Decimal d_ThoiGian = 0;
        private string s_Maql = "";
        private bool b_TaoMoi = false;
        private string s_BanNang = "";
        private string s_SerialPort = "";
        private string s_KhachHang = "";
        private string s_BienSoXe = "";
        private string s_KyThuatVien = "";
        public frmTiepNhanXe()
        {
            InitializeComponent();
        }

        public frmTiepNhanXe(SQLiteConnection _SQLiteCon, string _s_SerialPort, string _s_BanNang, bool _b_TaoMoi, string _s_MaQL, string _s_KhachHang, string _s_BienSoXe, string _s_KyThuatVien, Decimal _d_ThoiGian)
        {
            InitializeComponent();
            SQLiteCon = _SQLiteCon;
            s_SerialPort = _s_SerialPort;
            s_BanNang = _s_BanNang;
            b_TaoMoi = _b_TaoMoi;
            s_Maql = _s_MaQL;
            s_KhachHang = _s_KhachHang;
            s_BienSoXe = _s_BienSoXe;
            s_KyThuatVien = _s_KyThuatVien;
            d_ThoiGian = _d_ThoiGian;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {          
            string sql = "";
            string s_ID = s_BanNang;
            if (s_BanNang.Length < 2) s_ID = "0" + s_BanNang;
            string s_Name = txtKhachHang.Text == "" ? " " : txtKhachHang.Text;
            string s_BienSoXe = txtBienSoXe.Text == "" ? " " : txtBienSoXe.Text;
            string s_ThoiGian = Convert.ToDecimal(txtGio.Text == "" ? "0" : txtGio.Text).ToString("00") + ":" + Convert.ToDecimal(txtPhut.Text == "" ? "0" : txtPhut.Text).ToString("00");
            d_ThoiGian = Convert.ToDecimal(txtGio.Text == "" ? "0" : txtGio.Text) * 60 + Convert.ToDecimal(txtPhut.Text == "" ? "0" : txtPhut.Text);
            if (d_ThoiGian > 0)
            {
                string str = "#LED," + s_ID + "," + s_Name + "," + s_BienSoXe + "," + s_ThoiGian + "*";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
                ThuVienSerialPort.serialPort_Send(data, 0, data.Length);
                if (SQLiteCon.State == ConnectionState.Open && b_TaoMoi == true && d_ThoiGian > 0)
                {
                    sql = "UPDATE bannang SET maql = '" + s_Maql + "' WHERE id = " + s_BanNang;
                    try
                    {
                        SQLiteCommand command = new SQLiteCommand(sql, SQLiteCon);
                        command.ExecuteNonQuery();
                    }
                    catch { }
                }
                if (SQLiteCon.State == ConnectionState.Open)
                {
                    try
                    {
                        sql = "UPDATE bannang SET counter = '" + d_ThoiGian.ToString() + "',khachhang = '" + txtKhachHang.Text + "',biensoxe='" + txtBienSoXe.Text + "',ktv='" + txtKTV.Text + "',time = (datetime('now','localtime')) WHERE id = " + s_BanNang;
                        SQLiteCommand command = new SQLiteCommand(sql, SQLiteCon);
                        command.ExecuteNonQuery();
                    }
                    catch { }
                }
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ\rVui lòng kiểm tra lại!", "Cảnh báo");
            }
            this.Close();
        }

        private void frmTiepNhanXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27)
            {
                this.Close();
            }                
        }

        private void frmTiepNhanXe_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("Tiếp nhận xe [Bàn nâng {0}]", s_BanNang);
            this.txtGio.Properties.Mask.EditMask = "\\d+";
            this.txtGio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPhut.Properties.Mask.EditMask = "\\d+";
            this.txtPhut.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            ThuVienSerialPort.serialPort_Open(s_SerialPort, false);
            txtKTV.Text = s_KyThuatVien;
            if (b_TaoMoi == false)
            {
                txtKTV.Enabled = false;
                txtGio.Enabled = false;
                txtPhut.Enabled = false;
                txtKhachHang.Enabled = false;
                txtBienSoXe.Enabled = false;
                txtKhachHang.Text = s_KhachHang;
                txtBienSoXe.Text = s_BienSoXe;
                txtGio.Text = Convert.ToInt32(d_ThoiGian / 60).ToString();
                txtPhut.Text = (d_ThoiGian % 60).ToString();
                btnDongY.Enabled = false;
            }
        }
    }
}
