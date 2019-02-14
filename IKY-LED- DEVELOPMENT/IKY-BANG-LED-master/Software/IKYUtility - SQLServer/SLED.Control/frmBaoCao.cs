using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace IKY.Control
{
    public partial class frmBaoCao : Form
    {
        SqlConnection conn = null;
        private DataTable dt_BaoCao = null;
        public frmBaoCao()
        {
            InitializeComponent();
        }

        public frmBaoCao(SqlConnection _conn)
        {
            InitializeComponent();
            this.conn = _conn;
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            txtTuNgay.EditValue = DateTime.Today;
            txtDenNgay.EditValue = DateTime.Today;
        }

        private void frmBaoCao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DateTime dti_TuNgay = Convert.ToDateTime(txtTuNgay.EditValue);
            DateTime dti_DenNgay = Convert.ToDateTime(txtDenNgay.EditValue);
            if (dti_TuNgay == Convert.ToDateTime(null)) { dti_TuNgay = DateTime.Today; }
            if (dti_DenNgay == Convert.ToDateTime(null)) { dti_DenNgay = dti_TuNgay; }
            if (dti_TuNgay == Convert.ToDateTime(null) || dti_DenNgay == Convert.ToDateTime(null)) { return; }

            TienIch.QLBanNang qlBN = new TienIch.QLBanNang();
            dt_BaoCao = qlBN.LoadBaoCaoTheoNgay(conn, dti_TuNgay, dti_DenNgay);
            grdDuLieu.DataSource = dt_BaoCao;
        }

        private void grvDuLieu_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == grvDuLieuCol_STT)
            {
                e.DisplayText = e.RowHandle < 0 ? "0" : (e.RowHandle + 1).ToString();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            int i_SoDongFooter = 8;
            int i_SoDongTieuDe = 5;
            if (dt_BaoCao != null && dt_BaoCao.Rows.Count > 0)
            {                
                try
                {
                    SaveFileDialog objSaveFileDialog = new SaveFileDialog();
                    objSaveFileDialog.Filter = "Excel2003 Excel|*.xls|Excel2007 Excel|*.xlsx";
                    objSaveFileDialog.ShowDialog();


                    if (!string.IsNullOrEmpty(objSaveFileDialog.FileName.Trim()))
                    {
                        string[] strList = objSaveFileDialog.FileName.Split('.');
                        if (strList.Length > 0)
                        {
                            string s_FilePath = objSaveFileDialog.FileName;
                            switch (strList[strList.Length - 1].ToString().Trim())
                            {
                                case "xls":
                                    grdDuLieu.ExportToXls(objSaveFileDialog.FileName);
                                    break;
                                case "xlsx":
                                    grdDuLieu.ExportToXlsx(objSaveFileDialog.FileName);
                                    break;
                            }
                            Excel.Application oxl = new Excel.Application();
                            int i_SoCot = dt_BaoCao.Columns.Count + 1; //1: cột số thứ tự
                            int i_SoDong = dt_BaoCao.Rows.Count;
                            Excel.Workbook owb = oxl.Workbooks.Open(s_FilePath, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                            Excel._Worksheet osheet = (Excel._Worksheet)owb.ActiveSheet;
                            oxl.ActiveWindow.DisplayGridlines = true;

                            //oxl.Visible = true;

                            for (int i_Dong = 0; i_Dong < i_SoDongTieuDe; i_Dong++)//insert các dòng tiêu đề
                            {
                                osheet.get_Range(TienIch.XuatExcel.ColumnExcel(i_Dong) + "1", TienIch.XuatExcel.ColumnExcel(i_Dong) + "1").EntireRow.Insert(Missing.Value);
                            }
                            oxl.ActiveWindow.DisplayZeros = false;

                            //Định dạng phần header.
                            //Thiết lập vùng điền dữ liệu. 
                            int rowStart_h = 1;
                            int columnStart_h = 1;
                            int rowEnd_h = rowStart_h + i_SoDongTieuDe - 1;
                            int columnEnd_h = i_SoCot;
                            // Ô bắt đầu điền dữ liệu
                            Excel.Range c1 = (Excel.Range)osheet.Cells[rowStart_h, columnStart_h];
                            // Ô kết thúc điền dữ liệu
                            Excel.Range c2 = (Excel.Range)osheet.Cells[rowEnd_h, columnEnd_h];
                            //Căn giữa vùng dữ liệu
                            osheet.get_Range(c1, c2).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            osheet.get_Range(c1, c2).Font.Bold = true;

                            //oxl.Visible = true;

                            //Định dạng phần footer.
                            int rowStart_f = i_SoDongTieuDe + i_SoDong + 1 + 1; //1: dòng tiêu đề của grid, 1: định dạng dòng mới
                            int rowEnd_f = i_SoDongTieuDe + i_SoDong + i_SoDongFooter;
                            Excel.Range c3 = (Excel.Range)osheet.Cells[rowStart_f, columnStart_h];
                            Excel.Range c4 = (Excel.Range)osheet.Cells[rowEnd_f, columnEnd_h];
                            osheet.get_Range(c3, c4).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            //oxl.Visible = true;

                            //set font chữ từ đầu dòng đến cuối dòng dữ liệu
                            Excel.Range orange = osheet.get_Range("A1", TienIch.XuatExcel.ColumnExcel(i_SoCot + 1) + (i_SoDongTieuDe).ToString());
                            orange.Font.Bold = true;

                            orange = osheet.get_Range("A1", TienIch.XuatExcel.ColumnExcel(i_SoCot) + (i_SoDongTieuDe + i_SoDong + i_SoDongFooter).ToString());
                            orange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            orange.WrapText = false;
                            orange.RowHeight = 180;
                            orange.Cells.Interior.Color = System.Drawing.Color.White;
                            orange.EntireRow.AutoFit();

                            osheet.PageSetup.LeftMargin = 20;
                            osheet.PageSetup.RightMargin = 20;
                            osheet.PageSetup.TopMargin = 30;
                            osheet.PageSetup.CenterFooter = "Trang : &P/&N";

                            //oxl.Visible = true;

                            orange = osheet.get_Range("A1", TienIch.XuatExcel.ColumnExcel(i_SoCot) + (i_SoDongTieuDe + i_SoDong + i_SoDongFooter).ToString());
                            orange.Cells.Font.Size = 11;
                            orange.EntireColumn.AutoFit();
                            osheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                            osheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;

                            osheet.Cells[3, 4] = "BÁO CÁO HOẠT ĐỘNG BÀN NÂNG";
                            osheet.Cells[3, 4].Font.Bold = true;
                            osheet.Cells[3, 4].Font.Size = 16;

                            string s_NgayIn = "Ngày " + DateTime.Today.Day + " tháng " + DateTime.Today.Month + " năm " + DateTime.Today.Year;
                            osheet.Cells[i_SoDongTieuDe + i_SoDong + 4, 4] = s_NgayIn;
                            osheet.Cells[i_SoDongTieuDe + i_SoDong + 5, 4] = "Người lập biểu";
                            osheet.Cells[i_SoDongTieuDe + i_SoDong + 8, 4] = "(Ký tên, đóng dấu)";

                            oxl.Visible = true;
                        }
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu báo cáo!", "Thông báo");
            }
        }
    }
}
