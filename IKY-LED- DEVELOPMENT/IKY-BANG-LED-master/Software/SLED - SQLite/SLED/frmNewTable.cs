using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLED
{
    public partial class frmNewTable : Form
    {
        public string s_NewID = "";
        public frmNewTable()
        {
            InitializeComponent();            
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            this.s_NewID = numID.Value.ToString();
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewTable_Load(object sender, EventArgs e)
        {
            
        }

        private void frmNewTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((Keys)e.KeyChar == Keys.Enter)
            {
                btnDongY_Click(null, null);
            }
        }
    }
}
