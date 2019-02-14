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
    public partial class frmTraXe : frmBase
    {
        SqlConnection conn = null;
        string s_SerialPort = "";
        string s_MaBN = "";
        DataRow r_BN = null;
        int i_TGConLai = 0;
        int i_TongTG = 0;
        public frmTraXe()
        {
            InitializeComponent();
        }

        public frmTraXe(SqlConnection _conn,string _s_MaBN)
            :this()
        {            
            this.conn = _conn;
            this.s_MaBN = _s_MaBN;
        }

        public frmTraXe(SqlConnection _conn, string _s_MaBN, string _s_SerialPort)
            : this(_conn, _s_MaBN)
        {
            this.s_SerialPort = _s_SerialPort;
        }

        private void frmTraXe_KeyPress(object sender, KeyPressEventArgs e)
        {            
            switch ((Keys)e.KeyChar)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Enter:
                    btnDongY_LinkClicked(null, null);
                    break;
                default:
                    break;
            }
        }

        private void frmTraXe_Load(object sender, EventArgs e)
        {
            btnDongY.LinkClicked += btnDongY_LinkClicked;            
            if (s_SerialPort != "")
            {
                TienIch.ComPort.serialPort_Open(s_SerialPort, false);
            }
            if (conn == null || conn.State != ConnectionState.Open)
            {
                Database.Open(ref this.conn);
            }
            if (conn.State == ConnectionState.Open)
            {
                TienIch.DsBanNang ds = new TienIch.DsBanNang();
                DataTable dt = ds.LoadDsTheoID(conn, this.s_MaBN);
                if (dt != null && dt.Rows.Count > 0)
                {
                    r_BN = dt.Rows[0];
                    TrangThai.TrangThaiBanNang TT_trangthai = (TrangThai.TrangThaiBanNang)Convert.ToInt16(r_BN["trangthai"].ToString());
                    if (TT_trangthai == TrangThai.TrangThaiBanNang.DangSuaChua)                    
                    {
                        i_TongTG = Convert.ToInt32(r_BN["tongthoigian"].ToString());                        
                        DateTime TGCapNhat = r_BN["thoigianbd"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(r_BN["thoigianbd"]);
                        TimeSpan diff = DateTime.Now.Subtract(TGCapNhat);
                        double minutes = diff.TotalMinutes;
                        i_TGConLai = Convert.ToInt32(minutes) >= Convert.ToInt32(r_BN["tongthoigian"]) ? 0 : Convert.ToInt32(r_BN["tongthoigian"]) - Convert.ToInt32(minutes);
                        i_TGConLai += 1;
                    }
                }
            }
        }

        private void GiamThoiGian()
        {
            string s_ID = this.s_MaBN;
            if (this.s_MaBN.Length < 2) s_ID = "0" + this.s_MaBN;            
            string s_ModeTangGiam = "0"; //Giảm
            string str = "#TIME," + s_ID + "," + s_ModeTangGiam + "," + i_TGConLai.ToString() + ",*";
            if (i_TGConLai > 0)
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
                TienIch.ComPort.serialPort_Send(data, 0, data.Length);

                i_TongTG -= i_TGConLai;
                if (i_TongTG < 0) i_TongTG = 0;               
                DsBanNang ds = new DsBanNang();
                ds.UpdateThoiGianSuaChua(this.conn, this.s_MaBN, Convert.ToInt16(i_TongTG));
            }
        }

        private void btnDongY_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            string s_MaKH = "";
            int i_TG = 0;
            string s_ID = this.s_MaBN;
            if (this.s_MaBN.Length < 2) s_ID = "0" + this.s_MaBN;
            string s_NDLayXe = txtThongBao.Text;
            string str = "#CTR," + s_ID + "," + TienIch.Access.convertToUnSign3(s_NDLayXe).ToUpper() + ",*";
            if (s_NDLayXe != "")
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
                if (s_SerialPort != "")
                {
                    TienIch.ComPort.serialPort_Send(data, 0, data.Length);
                }
            }
            else
            {
                GiamThoiGian();
            }
            TienIch.DsBanNang ds = new TienIch.DsBanNang();
            ds.UpdateTrangThai(conn, s_MaBN, TienIch.TrangThai.TrangThaiBanNang.ChoNhanXe);
            DataTable dt_BN = ds.LoadDsTheoID(conn, s_MaBN);

            if (dt_BN != null && dt_BN.Rows.Count > 0)
            {
                DataRow r = dt_BN.Rows[0];
                s_MaKH = r["makhachhang"].ToString();
                i_TG = Convert.ToInt32(r["tongthoigian"].ToString());
            }

            TienIch.QLBanNang qlBN = new TienIch.QLBanNang();
            qlBN.Insert(conn, s_MaBN, s_MaKH, i_TG);
            TienIch.DsTraXe dsTraXe = new TienIch.DsTraXe();
            dsTraXe.Insert(conn, s_MaKH);
            this.Close();            
        }
    }
}
