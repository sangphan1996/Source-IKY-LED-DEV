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
    public partial class frmTiepNhanXe : Form
    {
        string s_IDBanNang = "";
        SqlConnection conn = null;
        string s_SerialPort = "";
        string sSerialData = "";
        string sIDThe ="";
        DataTable dt_HoTen = null;
        DataTable dt_BienSoXe = null;
        public frmTiepNhanXe()
        {
            InitializeComponent();
        }

        public frmTiepNhanXe(SqlConnection _conn,string s_ID)
        {
            InitializeComponent();
            this.s_IDBanNang = s_ID;
            this.conn = _conn;
        }

        public frmTiepNhanXe(SqlConnection _conn, string s_ComPortName,string s_MaQL)
        {
            InitializeComponent();
            this.s_IDBanNang = s_MaQL;
            this.conn = _conn;
            this.s_SerialPort = s_ComPortName;
        }

        private void frmTiepNhanXe_Load(object sender, EventArgs e)
        {
            if (this.conn == null || this.conn.State != ConnectionState.Open)
            {
                Database.Open(ref this.conn);
            }

            if (conn.State == ConnectionState.Open)
            {
                try
                {
                    DsBanNang ds = new DsBanNang();
                    DataTable dt = ds.LoadDsTheoID(conn, this.s_IDBanNang);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[dt.Rows.Count - 1];
                        txtBanNang.Text = r["maql"].ToString();
                        txtKyThuatVien.Text = r["kythuatvien"].ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("Xử lý lỗi !", "Lỗi");
                }
                TienIch.DsKhachHang dsKH = new TienIch.DsKhachHang();
                dt_HoTen = dsKH.LoadHoTen(this.conn);
                dt_BienSoXe = dsKH.LoadBienSoXe(this.conn);
            }

            if (dt_HoTen != null && dt_HoTen.Rows.Count > 0) //Thêm gợi ý
            {
                string[] hotenSource = dt_HoTen
                                    .AsEnumerable()
                                    .Select<System.Data.DataRow, String>(x => x.Field<String>("hoten"))
                                    .ToArray();

                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                collection.AddRange(hotenSource);

                txtKhachHang.MaskBox.AutoCompleteCustomSource = collection;
                txtKhachHang.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtKhachHang.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }

            if (dt_BienSoXe != null && dt_BienSoXe.Rows.Count > 0) //Thêm gợi ý
            {
                string[] biensoxeSource = dt_BienSoXe
                                    .AsEnumerable()
                                    .Select<System.Data.DataRow, String>(x => x.Field<String>("biensoxe"))
                                    .ToArray();

                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                collection.AddRange(biensoxeSource);

                txtBienSoXe.MaskBox.AutoCompleteCustomSource = collection;
                txtBienSoXe.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBienSoXe.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }

            TienIch.ComPort.serialPort_Open(s_SerialPort, false);
            TienIch.ComPort.Callback_ReceivedData += new TienIch.ComPort.CallbackEventHandler_ReceivedData(LoadThongTinThe);
        }

        private void frmTiepNhanXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnDongY_Click(null, null);
            }
            else if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            string s_ID = s_IDBanNang;
            if (s_IDBanNang.Length < 2) s_ID = "0" + s_IDBanNang;
            string s_Name = txtKhachHang.Text == "" ? " " : txtKhachHang.Text;
            string s_BienSoXe = txtBienSoXe.Text == "" ? " " : txtBienSoXe.Text;
            string s_ThoiGian = Convert.ToDecimal(txtGio.Text == "" ? "0" : txtGio.Text).ToString("00") + ":" + Convert.ToDecimal(txtPhut.Text == "" ? "0" : txtPhut.Text).ToString("00");
            Int32 d_ThoiGian = Convert.ToInt16(txtGio.Text == "" ? "0" : txtGio.Text) * 60 + Convert.ToInt16(txtPhut.Text == "" ? "0" : txtPhut.Text);
            if (d_ThoiGian > 0)
            {
                string str = "#LED," + s_ID + "," + TienIch.Access.convertToUnSign3(s_Name).ToUpper() + "," + s_BienSoXe.ToUpper() + "," + s_ThoiGian + "*";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
                Console.WriteLine(str);
                TienIch.ComPort.serialPort_Send(data, 0, data.Length);
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    DsKhachHang ds_KH = new DsKhachHang();
                    string s_MaKH = ds_KH.Insert_ReturnMaQL(conn, s_Name, s_BienSoXe,txtGhiChu.Text.ToString().Trim());
                    DsBanNang ds_BN = new DsBanNang();
                    ds_BN.UpdateTrangThai(conn, s_IDBanNang, TrangThai.TrangThaiBanNang.DangSuaChua);
                    ds_BN.UpdateThongTinKH(conn, s_IDBanNang, s_MaKH, Convert.ToInt16(d_ThoiGian));
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ\rVui lòng kiểm tra lại!", "Cảnh báo");
            }
            
        }

        void LoadThongTinThe(string sData)
        {
            sSerialData += sData;
            if (TienIch.SerialProtocolParser.Check(sSerialData))
            {
                sIDThe = TienIch.SerialProtocolParser.Parser(sSerialData);
                sSerialData = "";
                this.Invoke((MethodInvoker)delegate
                {
                    TienIch.DsTheBH ds = new TienIch.DsTheBH();
                    ds.sIDThe = sIDThe;
                    ds.LoadThongTin(this.conn);
                    txtKhachHang.Text = ds.sHoTen;
                    txtBienSoXe.Text = ds.sBienSoXe;
                });
            }
        }

        private void frmTiepNhanXe_FormClosing(object sender, FormClosingEventArgs e)
        {
            TienIch.ComPort.Callback_ReceivedData -= LoadThongTinThe;
        }

        private void frmTiepNhanXe_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnBoQua_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.Close();
        }

        private void btnLuu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnDongY_Click(null, null);
        }
    }
}
