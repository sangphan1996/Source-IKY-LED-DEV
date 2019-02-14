using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace IKY.Control
{
    public partial class frmThongBao : frmBase
    {
        SqlConnection conn = null;
        public frmThongBao()
        {
            InitializeComponent();
        }

         public frmThongBao(SqlConnection _conn)
             :this()
        {
            this.conn = _conn;
        }

         private void frmThongBao_KeyPress(object sender, KeyPressEventArgs e)
         {
             //if ((Keys)e.KeyChar == Keys.Enter)
             //{
             //    if(txtNoiDung.EditValue.ToString() != "")
             //    {
             //        TienIch.DsThongBao ds = new TienIch.DsThongBao();
             //        ds.UpdateTrangThai(this.conn);
             //        ds.Insert(this.conn, txtNoiDung.EditValue.ToString());
             //    }
             //    this.Close();
             //}
         }         
         private void frmThongBao_Load(object sender, EventArgs e)
         {
             btnDongY.LinkClicked += btnDongY_LinkClicked;       
             if (this.conn.State == ConnectionState.Open)
             {
                 TienIch.DsThongBao ds = new TienIch.DsThongBao();
                 DataTable dt_ThongBao = ds.LoadAll(this.conn);


                 if (dt_ThongBao != null && dt_ThongBao.Rows.Count > 0)
                 {
                     string[] hotenSource = dt_ThongBao
                                         .AsEnumerable()
                                         .Select<System.Data.DataRow, String>(x => x.Field<String>("noidung"))
                                         .ToArray();

                     AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                     collection.AddRange(hotenSource);

                     txtNoiDung.MaskBox.AutoCompleteCustomSource = collection;
                     txtNoiDung.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                     txtNoiDung.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                 }
             }
         }

         void btnDongY_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {
             if (txtNoiDung.EditValue != null && txtNoiDung.EditValue.ToString() != "")
             {
                 TienIch.DsThongBao ds = new TienIch.DsThongBao();
                 ds.UpdateTrangThai(this.conn);
                 ds.Insert(this.conn, txtNoiDung.EditValue.ToString());
             }
             this.Close(); 
         }


    }
}
