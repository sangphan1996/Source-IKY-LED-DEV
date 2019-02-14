using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IKY.QuanLyThe
{
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
        }

        private void frmBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
