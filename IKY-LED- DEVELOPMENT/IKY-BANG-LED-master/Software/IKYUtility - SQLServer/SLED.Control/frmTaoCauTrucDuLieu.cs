using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IKYDatabase;
using System.Data.SqlClient;

namespace IKY.Control
{
    public partial class frmTaoCauTrucDuLieu : frmBase
    {
        SqlConnection sqlCon = null;
        public frmTaoCauTrucDuLieu()
        {
            InitializeComponent();
        }
        
        private void frmTaoCauTrucDuLieu_Load(object sender, EventArgs e)
        {
            btnDongY.LinkClicked += btnDongY_LinkClicked;
        }

        void btnDongY_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Database.Open(ref this.sqlCon);

            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                Database db = new Database("vn");
                db.CreateDatabase(sqlCon);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
