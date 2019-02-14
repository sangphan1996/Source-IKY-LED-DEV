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
    public partial class frmTraXe : Form
    {
        private string s_BanNang = "";
        private string s_SerialPort = "";
        private SQLiteConnection SQLiteCon = null;
        private Decimal d_ThoiGian = 0;
        private string s_MaQL = "";
        private string s_TTKhachHang = "";
        private string s_KyThuatVien = "";
        private string s_BienSoXe = "";
        private bool b_TaoMoi = false;
        public frmTraXe()
        {
            InitializeComponent();
        }

        public frmTraXe(SQLiteConnection _SQLiteCon, string _s_SerialPort, string _s_BanNang, string _s_MaQL, string _s_KhachHang, string _s_BienSoXe, string _s_KyThuatVien, Decimal _d_TongTG,bool _b_TaoMoi)
        {
            InitializeComponent();
            SQLiteCon = _SQLiteCon;
            s_SerialPort = _s_SerialPort;
            s_BanNang = _s_BanNang;
            s_MaQL = _s_MaQL;
            s_TTKhachHang = _s_KhachHang;
            s_BienSoXe = _s_BienSoXe;
            s_KyThuatVien = _s_KyThuatVien;
            d_ThoiGian = _d_TongTG;
            b_TaoMoi = _b_TaoMoi;
            
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            string s_ID = s_BanNang;
            if (s_BanNang.Length < 2) s_ID = "0" + s_BanNang;
            string s_NDLayXe = txtNoiDung.Text;
            string str = "#CTR," + s_ID + "," + s_NDLayXe + ",*";
            if (s_NDLayXe != "")
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
                if (s_SerialPort != "")
                {
                    ThuVienSerialPort.serialPort_Send(data, 0, data.Length);
                }
            }
            if (SQLiteCon.State == ConnectionState.Open && b_TaoMoi == false)
            {
                try
                {
                    string sql = "UPDATE bannang SET maql = '0',counter = 0 WHERE ID = " + s_BanNang;
                    SQLiteCommand command = new SQLiteCommand(sql, SQLiteCon);
                    command.ExecuteNonQuery();

                    sql = "insert into  baocao (maql,id,khachhang,biensoxe,thoigian,ktv) values ('" + s_MaQL + "','" + s_BanNang + "','" + s_TTKhachHang + "','" + s_BienSoXe + "'," + d_ThoiGian.ToString() + ",'" + s_KyThuatVien + "')";
                    command = new SQLiteCommand(sql, SQLiteCon);
                    command.ExecuteNonQuery();
                }
                catch { }
            }
            this.Close();
        }

        private void frmTraXe_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("Thông tin trả xe [Bàn nâng {0}]", s_BanNang);
            if (s_SerialPort != "")
            {
                ThuVienSerialPort.serialPort_Open(s_SerialPort, false);
            }
            txtKhachHang.Text = s_TTKhachHang;
            txtBSX.Text = s_BienSoXe;
        }

        private void frmTraXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
            else if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnDongY_Click(null, null);
            }
        }

    }
}
