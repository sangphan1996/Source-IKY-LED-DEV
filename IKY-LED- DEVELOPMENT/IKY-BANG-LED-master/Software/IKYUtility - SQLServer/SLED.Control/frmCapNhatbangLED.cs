using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IKY.Control
{
    public partial class frmCapNhatbangLED : frmBase
    {
        string s_SerialPort = "";
        string s_IDBanNang = "";
        string s_NDHienThi = "";
        string s_KTV = "";
        public frmCapNhatbangLED()
        {
            InitializeComponent();
        }

        public frmCapNhatbangLED(string s_COM,string s_ID,string s__NDHienThi,string s__KTV)
            :this()
        { 
            this.s_SerialPort = s_COM;
            this.s_IDBanNang = s_ID;
            this.s_NDHienThi = s__NDHienThi;
            this.s_KTV = s__KTV;
        }

        private void frmCapNhatbangLED_Load(object sender, EventArgs e)
        {
            btnDongY.LinkClicked += btnDongY_LinkClicked;
            if (s_SerialPort != "")
            {
                TienIch.ComPort.serialPort_Open(s_SerialPort, false);
            }
            txtNDHienThi.Text = s_NDHienThi;
            txtKyThuatVien.Text = s_KTV;
        }

        void btnDongY_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            string s_ID = this.s_IDBanNang;
            if (this.s_IDBanNang.Length < 2) s_ID = "0" + this.s_IDBanNang;
            string s_CauChao = txtNDHienThi.Text == "" ? " " : TienIch.Access.convertToUnSign3(txtNDHienThi.Text).ToUpper();
            string str = "#CFG," + s_ID + "," + s_CauChao + ",*";

            byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
            TienIch.ComPort.serialPort_Send(data, 0, data.Length);
            this.Close();
        }

        private void frmCapNhatbangLED_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
