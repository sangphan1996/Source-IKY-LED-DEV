using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IKY.ChamCong
{
    public partial class frmMain : Form
    {
        string s_SerialPort = "";
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            string[] biensoxeSource = ports.ToArray();
            if (biensoxeSource != null && biensoxeSource.Length > 0)
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                collection.AddRange(biensoxeSource);

                txtCongCOM.MaskBox.AutoCompleteCustomSource = collection;
                txtCongCOM.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCongCOM.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            if (s_SerialPort != "")
            {
                TienIch.ComPort.serialPort_Open(s_SerialPort);
                TienIch.ComPort.Callback_ReceivedData += new TienIch.ComPort.CallbackEventHandler_ReceivedData(LoadThongTinThe);
            }
            this.SetControl(false);
        }
        void LoadThongTinThe(string sData)
        {
        }

        void SetControl(bool bEnable)
        {
            txtCongCOM.Enabled = bEnable;
            chkRun.Enabled = bEnable;
            txtCongCOM.Focus();
        }

        private void btnSua_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }
    }
}
