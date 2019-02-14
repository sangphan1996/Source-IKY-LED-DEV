using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TienIch;

namespace IKY.Control
{
    public partial class frmTaoBanNang : frmBase
    {
        string s_SerialPort = "";
        public string s_NewID = "";
        public string s_KyThuatVien = "";
        public string s_NoiDungHienThi = "";
        bool b_Sua = false;
        SqlConnection conn = null;
        public frmTaoBanNang()
        {
            InitializeComponent();
        }

        public frmTaoBanNang(string s_ID,bool b__Sua)
            :this()
        {
            this.b_Sua = b__Sua;
            this.s_NewID = s_ID;
        }

        public frmTaoBanNang(string s_COM, SqlConnection _conn, bool b__Sua, string s_ID)
            : this()
        {
            this.conn = _conn;
            this.b_Sua = b__Sua;
            s_SerialPort = s_COM;
            this.s_NewID = s_ID;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            this.s_NewID = txtID.Text.ToString().Trim();
            this.s_KyThuatVien = txtKyThuatVien.Text;
            this.s_NoiDungHienThi = txtNoiDungHT.Text;

            if (b_Sua == true)
            {
                if (conn.State == ConnectionState.Open)
                {
                    DsBanNang ds = new DsBanNang();
                    ds.Insert(conn, this.s_NewID, this.s_KyThuatVien, this.s_NoiDungHienThi);
                }
            }

            //Gửi dữ liệu tới bảng LED
            string s_ID = this.s_NewID;
            if (this.s_NewID.Length < 2)
            {
                s_ID = "0" + this.s_NewID;
            }
            string s_CauChao = txtNoiDungHT.Text == "" ? " " : TienIch.Access.convertToUnSign3(txtNoiDungHT.Text).ToUpper();
            string str = "#CFG," + s_ID + "," + s_CauChao + ",*";

            byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
            TienIch.ComPort.serialPort_Send(data, 0, data.Length);


            this.Close();
        }

        private void frmTaoBanNang_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmTaoBanNang_Load(object sender, EventArgs e)
        {
            btnDongY.LinkClicked += btnDongY_LinkClicked;
            if(b_Sua == true)
            {
                txtID.Enabled = false;
                txtID.Text = s_NewID;
                //
                TienIch.DsBanNang ds = new TienIch.DsBanNang();
                DataTable dt = ds.LoadDsTheoID(conn, s_NewID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    s_KyThuatVien = r["kythuatvien"].ToString();
                    s_NoiDungHienThi = r["ndhienthi"].ToString();
                }
                //
                txtKyThuatVien.Text = s_KyThuatVien;
                txtNoiDungHT.Text = s_NoiDungHienThi;
                this.Text = "Sửa bàn nâng";
            }
            if (s_SerialPort != "")
            {
                TienIch.ComPort.serialPort_Open(s_SerialPort, false);
            }
        }

        void btnDongY_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnDongY_Click(null, null);
        }
    }
}
