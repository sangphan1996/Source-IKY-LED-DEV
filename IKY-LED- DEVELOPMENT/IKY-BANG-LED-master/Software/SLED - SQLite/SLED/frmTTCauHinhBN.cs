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
    public partial class frmTTCauHinhBN : Form
    {
        private string s_BanNang = "";
        private string s_SerialPort = "";
        private string s_LoiChao = "";
        private string s_KyThuatVien = "";
        
        private SQLiteConnection SQLiteCon = null;
        public frmTTCauHinhBN()
        {
            InitializeComponent();
        }

        public frmTTCauHinhBN(SQLiteConnection _SQLiteCon, string _s_SerialPort,string _s_BanNang,string _s_LoiChao,string _s_KyThuatVien)
        {
            InitializeComponent();
            SQLiteCon = _SQLiteCon;
            s_SerialPort = _s_SerialPort;
            s_BanNang = _s_BanNang;            
            s_LoiChao = _s_LoiChao;
            s_KyThuatVien = _s_KyThuatVien;
        }

        private void frmTTCauHinhBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            string s_ID = s_BanNang;
            if (s_BanNang.Length < 2) s_ID = "0" + s_BanNang;
            string s_CauChao = txtCauChao.Text == "" ? " " : txtCauChao.Text;
            string str = "#CFG," + s_ID + "," + s_CauChao + ",*";

            byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
            ThuVienSerialPort.serialPort_Send(data, 0, data.Length);
            if (SQLiteCon.State == ConnectionState.Open)
            {
                try
                {
                    string sql = "UPDATE bannang SET greetings = '" + txtCauChao.Text + "', ktv = '" + txtKTV.Text + "' WHERE ID = " + s_BanNang + " ";
                    SQLiteCommand command = new SQLiteCommand(sql, SQLiteCon);
                    command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Xử lý lỗi\rVui lòng kiểm tra lại!", "Cảnh báo");
                }
            }
            this.Close();
        }

        private void frmTTCauHinhBN_Load(object sender, EventArgs e)
        {
            if (s_SerialPort != "")
            {
                ThuVienSerialPort.serialPort_Open(s_SerialPort, false);
            }
            txtCauChao.Text = s_LoiChao;
            txtKTV.Text = s_KyThuatVien;
        }
    }
}
