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
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!TienIch.Access.IsLoadForm("frmThemMoi", this))
            {
                frmKhaiBaoThe f = new frmKhaiBaoThe();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}
