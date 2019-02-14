using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLED
{
    public partial class frmDCTGSuaChua : Form
    {
        private SQLiteConnection SQLiteCon = null;
        private string s_SerialPort = "";
        private string s_BanNang = "";
        private Decimal d_ThoiGian = 0;

        public frmDCTGSuaChua()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        public frmDCTGSuaChua(SQLiteConnection _SQLiteCon, string _s_SerialPort, string _s_BanNang, Decimal _d_ThoiGian)
        {
            InitializeComponent();
            this.KeyPreview = true;
            SQLiteCon = _SQLiteCon;
            s_SerialPort = _s_SerialPort;
            s_BanNang = _s_BanNang;
            d_ThoiGian = _d_ThoiGian;
        }

        private void frmDCTGSuaChua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }   
        }

        private void frmDCTGSuaChua_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("Chỉnh thời gian [Bàn nâng {0}]", s_BanNang);
            if(s_SerialPort != null)
            {
                ThuVienSerialPort.serialPort_Open(s_SerialPort, false);
            }
            if (d_ThoiGian == 0)
            {
                numPhut.Enabled = false;
                btnGiam.Enabled = false;
                btnTang.Enabled = false;
            }
            else
            {
                numPhut.Enabled = true;
                btnGiam.Enabled = true;
                btnTang.Enabled = true;
            }
        }

        private void DKTGPhatSinh(string s_Mode)
        {
            string s_ID = s_BanNang;
            if (s_BanNang.Length < 2) s_ID = "0" + s_BanNang;
            string s_TGPhatSinh = numPhut.Value.ToString();            
            string str = "#TIME," + s_ID + "," + s_Mode + "," + s_TGPhatSinh + ",*";
            if (numPhut.Value != 0)
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
                ThuVienSerialPort.serialPort_Send(data, 0, data.Length);
                if (s_Mode == "1")
                {
                    d_ThoiGian += numPhut.Value;
                }
                else
                {
                    d_ThoiGian -= numPhut.Value;
                    if (d_ThoiGian < 0) d_ThoiGian = 0;
                }
                if (SQLiteCon.State == ConnectionState.Open)
                {
                    try
                    {
                        string sql = "UPDATE bannang SET counter = '" + d_ThoiGian.ToString() + "' WHERE id = " + s_ID + " ";
                        SQLiteCommand command = new SQLiteCommand(sql, SQLiteCon);
                        command.ExecuteNonQuery();
                    }
                    catch { }
                }
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ!", "Cảnh báo");
            }
        }

        private void btnTang_Click(object sender, EventArgs e)
        {
            DKTGPhatSinh("1");
            this.Close();
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {
            DKTGPhatSinh("0");
            this.Close();
        }
    }
}
