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
using IKYDatabase;

namespace IKY.Control
{
    public partial class frmTiepNhanKhach : Form
    {
        public string s_HoTen = "";
        public string s_BienSoXe = "";
        public string s_GhiChu = "";
        SqlConnection conn = null;
        string sSerialData = "";
        string sIDThe = "";
        string sCom = "";
        DataTable dt_HoTen = null;
        DataTable dt_BienSoXe = null;
        public frmTiepNhanKhach()
        {
            InitializeComponent();
        }

        public frmTiepNhanKhach(SqlConnection _conn,string s_Com)
            :this()
        {
            this.conn = _conn;
            this.sCom = s_Com;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            s_HoTen = txtHoTen.Text;
            s_BienSoXe = txtBienSoXe.Text;
            s_GhiChu = txtGhiChu.Text;            
            this.Close();
        }

        private void frmTiepNhanKhach_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmTiepNhanKhach_Load(object sender, EventArgs e)
        {
            if (this.conn == null || this.conn.State != ConnectionState.Open)
            {
                Database.Open(ref this.conn);
            }
            if (this.conn.State == ConnectionState.Open)
            {
                TienIch.DsKhachHang ds = new TienIch.DsKhachHang();
                dt_HoTen = ds.LoadHoTen(this.conn);
                dt_BienSoXe = ds.LoadBienSoXe(this.conn);
            }

            if (dt_HoTen != null && dt_HoTen.Rows.Count > 0)
            {
                string[] hotenSource = dt_HoTen
                                    .AsEnumerable()
                                    .Select<System.Data.DataRow, String>(x => x.Field<String>("hoten"))
                                    .ToArray();

                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                collection.AddRange(hotenSource);

                txtHoTen.MaskBox.AutoCompleteCustomSource = collection;
                txtHoTen.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtHoTen.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }

            if (dt_BienSoXe != null && dt_BienSoXe.Rows.Count > 0)
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

            TienIch.ComPort.Callback_ReceivedData += new TienIch.ComPort.CallbackEventHandler_ReceivedData(LoadThongTinThe);
        }

        private void frmTiepNhanKhach_FormClosing(object sender, FormClosingEventArgs e)
        {
            TienIch.ComPort.Callback_ReceivedData -= LoadThongTinThe;
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
                    txtHoTen.Text = ds.sHoTen;
                    txtBienSoXe.Text = ds.sBienSoXe;
                });
            }
        }

        private void frmTiepNhanKhach_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyCode == Keys.Enter)
            {
                if(txtHoTen.Text != "" && txtBienSoXe.Text != "")
                {
                    btnDongY_Click(null, null);
                }
            }
            else if ((Keys)e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnBoQua_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.Close();
        }

        private void btnDongY_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnDongY_Click(null, null);
        }

        
    }
}
