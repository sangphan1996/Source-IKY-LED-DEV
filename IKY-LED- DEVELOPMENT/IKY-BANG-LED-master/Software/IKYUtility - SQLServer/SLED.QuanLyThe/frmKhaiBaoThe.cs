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
using IKY.NgonNgu;

namespace IKY.QuanLyThe
{
    public partial class frmKhaiBaoThe : frmBase
    {
        internal string sSerialData = "";
        internal string sIDThe = "";
        internal bool bThemMoi = false;
        SqlConnection mdbCon = null;
        public frmKhaiBaoThe()
        {
            InitializeComponent();
        }

        public frmKhaiBaoThe(SqlConnection _mdbCon)
            :this()
        {
            this.mdbCon = _mdbCon;
        }

        private void frmKhaiBaoThe_Load(object sender, EventArgs e)
        {
            TienIch.ComPort.Callback_ReceivedData += new TienIch.ComPort.CallbackEventHandler_ReceivedData(LoadThongTinThe);
            this.bThemMoi = true;
            this.SetControl(true);
            lblStatus.Text = "Server: " + Database.Host + ":" + Database.Port;
        }

        void LoadThongTinThe(string sData)
        {
            sSerialData += sData;
            if(TienIch.SerialProtocolParser.Check(sSerialData))
            {
                sIDThe = TienIch.SerialProtocolParser.Parser(sSerialData);
                sSerialData = "";
                this.Invoke((MethodInvoker)delegate
                {
                    txtIDThe.Text = sIDThe;
                    TienIch.DsTheBH ds = new TienIch.DsTheBH();
                    ds.sIDThe = sIDThe;
                    ds.LoadThongTin(this.mdbCon);
                    txtSoThe.Text = ds.sSoThe;
                    txtHoTen.Text = ds.sHoTen;
                    txtBienSoXe.Text = ds.sBienSoXe;
                    txtDienThoai.Text = ds.sSDT;
                    txtDiaChi.Text = ds.sDiaChi;
                });
            }
        }

        void SetControl(bool bEnable)
        {
            butThemMoi.Enabled = !bEnable;
            butSuaThongTin.Enabled = !bEnable;
            butBoQua.Enabled = bEnable;
            butLuu.Enabled = bEnable;
            txtSoThe.Focus();
        }
        private void ClearText()
        {
            this.txtIDThe.Text = "";
            this.txtSoThe.Text = "";
            this.txtHoTen.Text = "";
            this.txtDienThoai.Text = "";
            this.txtDiaChi.Text = "";
            this.txtBienSoXe.Text = "";
        }
        private void butThemMoi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.bThemMoi = true;
            this.SetControl(true);
            this.ClearText();
        }

        private void butBoQua_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.bThemMoi = false;
            this.SetControl(false);
        }

        private void butSuaThongTin_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.bThemMoi = false;
            this.SetControl(true);
        }

        private void butLuu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.Check())
                {
                    if (this.Save())
                    {
                        this.SetControl(false);
                    }
                    else
                    {
                        Messages.Show(TienIch.Access.KeyMessage.UpdateError);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool Check()
        {
            if (txtIDThe.Text.Trim() == "")
            {
                txtIDThe.Focus();
                Messages.Show(TienIch.Access.KeyMessage.IDTheBHKhongHopLe);
                return false;
            }
            if (txtSoThe.Text.Replace("-", "").Trim() == "")
            {
                txtSoThe.Focus();
                Messages.Show(TienIch.Access.KeyMessage.SoTheBHKhongHopLe);
                return false;
            }
            return true;
        }

        private bool Save()
        {
            bool b_Val = false;
            TienIch.DsTheBH lib = new TienIch.DsTheBH();
            if (this.mdbCon == null || this.mdbCon.State != ConnectionState.Open) { Database.Open(ref this.mdbCon); }
            if (this.mdbCon.State == ConnectionState.Open)
            {
                lib.sIDThe = txtIDThe.Text;
                lib.sSoThe = txtSoThe.Text.Replace("-", "").Trim();
                lib.sHoTen = txtHoTen.Text;
                lib.sBienSoXe = txtBienSoXe.Text;
                lib.sDiaChi = txtDiaChi.Text;
                lib.sSDT = txtDienThoai.Text;                
                
                if (this.bThemMoi)
                {
                    b_Val = lib.Insert(mdbCon);
                }
                else
                {
                    b_Val = lib.Update(mdbCon);
                }
                if (b_Val)
                {
                    this.bThemMoi = false;
                }
            }
            return b_Val;
        }

        private void frmKhaiBaoThe_FormClosing(object sender, FormClosingEventArgs e)
        {            
            TienIch.ComPort.Callback_ReceivedData -= LoadThongTinThe;
        }


    }
}
