using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IKY.Control
{
    public partial class frmThongSo : frmBase
    {
        SqlConnection conn = null;
        public frmThongSo()
        {
            InitializeComponent();
        }

        public frmThongSo(SqlConnection _conn)
            :this()
        {
            this.conn = _conn;
        }

        private void frmThongSo_KeyPress(object sender, KeyPressEventArgs e)
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
            string s_ComPort = txtCongCOM.Text.Trim();
            string s_TenCTY = txtTenCTY.Text;
            string s_CauChao = txtCauChao.Text;
            int i_ThoiGian = Convert.ToInt32(txtThoiGianTBTX.Text);

            TienIch.tshethong ts = new TienIch.tshethong();
            ts.Update(conn, s_ComPort, s_TenCTY, s_CauChao, i_ThoiGian);
            this.Close();
        }

        private void frmThongSo_Load(object sender, EventArgs e)
        {
            btnDongY.LinkClicked += btnDongY_LinkClicked;
            if (conn != null && conn.State == ConnectionState.Open)
            {
                TienIch.tshethong ts = new TienIch.tshethong();
                DataTable dt = ts.LoadAll(conn);
                if(dt != null && dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    txtCongCOM.Text = r["congcom"].ToString();
                    txtTenCTY.Text = r["tencty"].ToString();
                    txtCauChao.Text = r["thongbaomacdinh"].ToString();
                }
            }

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

            if (txtTenCTY.Text == "")
                txtTenCTY.Text = "Công ty Cổ phần Công nghệ Tiện ích Thông minh";
            if (txtCauChao.Text == "")
                txtCauChao.Text = "Kính chào quý khách";
        }

        private void frmThongSo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyCode == Keys.Enter)
            {
                //if (txtCongCOM.Text != null)
                //{
                //    btnDongY_Click(null, null);
                //}
            }
            else if ((Keys)e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnDongY_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnDongY_Click(null, null);
        }
    }
}
