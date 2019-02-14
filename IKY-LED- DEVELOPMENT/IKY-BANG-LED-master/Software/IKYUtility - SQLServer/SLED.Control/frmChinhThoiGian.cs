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
    public partial class frmChinhThoiGian : frmBase
    {
        string s_SerialPort = "";
        string s_IDBanNang = "";
        DataRow r_BN = null;
        SqlConnection conn = null;
        int i_TongTG = 0;
        bool b_Mode = true; //True: Tăng - False: Giảm
        public frmChinhThoiGian()
        {
            InitializeComponent();
        }

        public frmChinhThoiGian(SqlConnection _conn, string _s_SerialPort, string _s_IDBanNang)
            :this()
        {
            this.conn = _conn;
            this.s_IDBanNang = _s_IDBanNang;
            this.s_SerialPort = _s_SerialPort;
        }

        public frmChinhThoiGian(SqlConnection _conn, string _s_SerialPort, string _s_IDBanNang,bool _b_Mode)
            : this(_conn, _s_SerialPort, _s_IDBanNang)
        {
            this.b_Mode = _b_Mode;
        }

        private void frmChinhThoiGian_Load(object sender, EventArgs e)
        {
            btnDongY.LinkClicked += btnDongY_LinkClicked;
            if (conn.State == ConnectionState.Open)
            {
                TienIch.DsBanNang ds = new TienIch.DsBanNang();
                DataTable dt = ds.LoadDsTheoID(conn, s_IDBanNang);
                if (dt != null && dt.Rows.Count > 0)
                {
                    r_BN = dt.Rows[0];
                    TrangThai.TrangThaiBanNang TT_trangthai = (TrangThai.TrangThaiBanNang)Convert.ToInt16(r_BN["trangthai"].ToString());
                    if (TT_trangthai != TrangThai.TrangThaiBanNang.DangSuaChua)
                    {
                        ControlEnable(false);
                    }
                    else
                    {
                        i_TongTG = Convert.ToInt32(r_BN["tongthoigian"].ToString());                        
                        DateTime TGCapNhat = r_BN["thoigianbd"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(r_BN["thoigianbd"]);
                        TimeSpan diff = DateTime.Now.Subtract(TGCapNhat);
                        double minutes = diff.TotalMinutes;
                        int i_TGConLai = Convert.ToInt32(minutes) >= Convert.ToInt32(r_BN["tongthoigian"]) ? 0 : Convert.ToInt32(r_BN["tongthoigian"]) - Convert.ToInt32(minutes);                        
                    }
                }
                else
                {
                    ControlEnable(false);
                }
            }
            else
            {
                ControlEnable(false);
            }
            if(s_SerialPort != "")
            {
                TienIch.ComPort.serialPort_Open(s_SerialPort, false);
            }
        }

        void btnDongY_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ChinhThoiGian(b_Mode);
            this.Close();
        }

        private void frmChinhThoiGian_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ChinhThoiGian(bool b_Tang)
        {
            string s_ID = s_IDBanNang;
            if (s_IDBanNang.Length < 2) s_ID = "0" + s_IDBanNang;
            int i_TGPhatSinh = Convert.ToInt32(txtThoiGianThayDoi.Text.ToString());
            string s_TGPhatSinh = i_TGPhatSinh.ToString();
            string s_ModeTangGiam = b_Tang == true ? "1" : "0";
            string str = "#TIME," + s_ID + "," + s_ModeTangGiam + "," + s_TGPhatSinh + ",*";
            if (i_TGPhatSinh > 0)
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
                TienIch.ComPort.serialPort_Send(data, 0, data.Length);
                if (b_Tang)
                {
                    i_TongTG += i_TGPhatSinh;
                }
                else
                {
                    i_TongTG -= i_TGPhatSinh;
                    if (i_TongTG < 0) i_TongTG = 0;
                }
                DsBanNang ds = new DsBanNang();
                ds.UpdateThoiGianSuaChua(this.conn, this.s_IDBanNang, Convert.ToInt16(i_TongTG));
            }
        }

        void ControlEnable(bool b_Enable)
        {
            txtThoiGianThayDoi.Enabled = b_Enable;
            btnDongY.Enabled = b_Enable;            
        }
    }
}
