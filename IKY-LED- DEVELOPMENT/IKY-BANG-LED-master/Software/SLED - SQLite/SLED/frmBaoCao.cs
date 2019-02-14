using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
namespace SLED
{
    public partial class frmBaoCao : Form
    {
        private SQLiteConnection sqlConn = null;
        private DataTable dt_BaoCao = null;
        public frmBaoCao()
        {
            InitializeComponent();
        }

        public frmBaoCao(SQLiteConnection _sqlConn)
        {
            InitializeComponent();
            sqlConn = _sqlConn;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dt_BaoCao != null && dt_BaoCao.Rows.Count > 0)
            {
                XoaDuLieuBaoCao_ThangTruoc();
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
                            int i_SoCot = dt_BaoCao.Columns.Count;
                            int i_SoDong = dt_BaoCao.Rows.Count;
                            Excel.Workbook owb = oxl.Workbooks.Open(s_FilePath, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                            Excel._Worksheet osheet = (Excel._Worksheet)owb.ActiveSheet;
                            oxl.ActiveWindow.DisplayGridlines = true;
                            int i_SoDongTieuDe = 5;
                            for (int i_Dong = 0; i_Dong < i_SoDongTieuDe; i_Dong++)//insert các dòng tiêu đề
                            {
                                osheet.get_Range(ThuVien.ColumnExcel(i_Dong) + "1", ThuVien.ColumnExcel(i_Dong) + "1").EntireRow.Insert(Missing.Value);
                            }
                            oxl.ActiveWindow.DisplayZeros = false;

                            //Định dạng phần header.
                            //Thiết lập vùng điền dữ liệu. 
                            int rowStart_h = 1;
                            int columnStart_h = 1;
                            int rowEnd_h = rowStart_h + i_SoDongTieuDe + 1;
                            int columnEnd_h = dt_BaoCao.Columns.Count + 2;
                            // Ô bắt đầu điền dữ liệu
                            Excel.Range c1 = (Excel.Range)osheet.Cells[rowStart_h, columnStart_h];
                            // Ô kết thúc điền dữ liệu
                            Excel.Range c2 = (Excel.Range)osheet.Cells[rowEnd_h, columnEnd_h];
                            //Căn giữa vùng dữ liệu
                            osheet.get_Range(c1, c2).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            osheet.get_Range(c1, c2).Font.Bold = true;
                            //Định dạng phần footer.
                            int rowStart_f = i_SoDongTieuDe + i_SoDong + 4;
                            int rowEnd_f = i_SoDongTieuDe + i_SoDong + 6;
                            Excel.Range c3 = (Excel.Range)osheet.Cells[rowStart_f, columnStart_h];
                            Excel.Range c4 = (Excel.Range)osheet.Cells[rowEnd_f, columnEnd_h];
                            osheet.get_Range(c3, c4).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            //set font chữ từ đầu dòng đến cuối dòng dữ liệu
                            Excel.Range orange = osheet.get_Range("A1", ThuVien.ColumnExcel(i_SoCot + 1) + (i_SoDongTieuDe + 1).ToString());
                            orange.Font.Bold = true;
                            orange = osheet.get_Range("A1", ThuVien.ColumnExcel(i_SoCot) + (i_SoDongTieuDe + i_SoDong + 6).ToString());
                            orange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            orange.WrapText = false;
                            orange.RowHeight = 180;
                            orange.Cells.Interior.Color = System.Drawing.Color.White;
                            orange.EntireRow.AutoFit();
                            orange = osheet.get_Range("A" + (i_SoDongTieuDe + 2).ToString(), ThuVien.ColumnExcel(i_SoCot - 3) + (i_SoDongTieuDe + i_SoDong + 2).ToString());
                            orange.Cells.BorderAround(4, Excel.XlBorderWeight.xlHairline, Excel.XlColorIndex.xlColorIndexAutomatic, 0);
                            for (int i = i_SoDongTieuDe + 2; i <= i_SoDongTieuDe + i_SoDong + 2; i++)
                            {
                                orange = osheet.get_Range("A" + i.ToString(), ThuVien.ColumnExcel(i_SoCot - 1) + i.ToString());
                                orange.Cells.BorderAround(4, Excel.XlBorderWeight.xlHairline, Excel.XlColorIndex.xlColorIndexAutomatic, 0);

                            }
                            osheet.PageSetup.LeftMargin = 20;
                            osheet.PageSetup.RightMargin = 20;
                            osheet.PageSetup.TopMargin = 30;
                            osheet.PageSetup.CenterFooter = "Trang : &P/&N";
                            oxl.Visible = true;

                            orange = osheet.get_Range("A1", ThuVien.ColumnExcel(i_SoCot) + (i_SoDongTieuDe + i_SoDong + 6).ToString());
                            orange.Cells.Font.Size = 11;
                            orange.EntireColumn.AutoFit();
                            osheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                            osheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;

                            osheet.Cells[3, 3] = "BÁO CÁO HOẠT ĐỘNG BÀN NÂNG";
                            osheet.Cells[3, 3].Font.Bold = true;
                            osheet.Cells[3, 3].Font.Size = 16;

                            osheet.Cells[i_SoDongTieuDe + i_SoDong + 5, 4] = "Người lập biểu";
                            osheet.Cells[i_SoDongTieuDe + i_SoDong + 6, 4] = "(Ký tên, đóng dấu)";
                            string s_NgayIn = "Ngày " + DateTime.Today.Day + " tháng " + DateTime.Today.Month + " năm " + DateTime.Today.Year;
                            osheet.Cells[i_SoDongTieuDe + i_SoDong + 4, 4] = s_NgayIn;
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

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            //string sTuNgay = DateTime.Today.ToString("yyyy-MM-dd") + " 00:00";
            //string sDenNgay = DateTime.Today.ToString("yyyy-MM-dd") + " 23:59"; 

            //dt_BaoCao = new DataTable();
            //string sql = "select * from baocao where time between '" + sTuNgay + "' and '" + sDenNgay + "'";
            //dt_BaoCao = ThuVien.SQLiteLoad(sqlConn, sql);
            //grdDuLieu.DataSource = dt_BaoCao;
            //if (dt_BaoCao != null && dt_BaoCao.Rows.Count > 0)
            //{
            //    grvDuLieu.FocusedRowHandle = 0;

            //}
            txtTuNgay.EditValue = DateTime.Today;
            txtDenNgay.EditValue = DateTime.Today;
        }

        private void frmBaoCao_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }


        private void XoaDuLieuBaoCao_ThangTruoc()
        {
            if (sqlConn.State == ConnectionState.Open)
            {
                try
                {
                    DateTime date = DateTime.Now;
                    var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                    var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                    string sTuNgay = firstDayOfMonth.ToString("yyyy-MM-dd") + " 00:00";
                    string sDenNgay = lastDayOfMonth.ToString("yyyy-MM-dd") + " 23:59";
                    string sql = "DELETE FROM baocao  where time not between '" + sTuNgay + "' and '" + sDenNgay + "'";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlConn);
                    command.ExecuteNonQuery();
                }
                catch
                {

                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DateTime dti_TuNgay = Convert.ToDateTime(txtTuNgay.EditValue);
            DateTime dti_DenNgay = Convert.ToDateTime(txtDenNgay.EditValue);
            if (dti_TuNgay == Convert.ToDateTime(null)) { dti_TuNgay = DateTime.Today; }
            if (dti_DenNgay == Convert.ToDateTime(null)) { dti_DenNgay = dti_TuNgay; }
            if (dti_TuNgay == Convert.ToDateTime(null) || dti_DenNgay == Convert.ToDateTime(null)) { return; }
            string s_TuNgay = dti_TuNgay.ToString("yyyy-MM-dd") + " 00:00";
            string s_DenNgay = dti_DenNgay.ToString("yyyy-MM-dd") + " 23:59";

            dt_BaoCao = new DataTable();
            string sql = "select * from baocao where time between '" + s_TuNgay + "' and '" + s_DenNgay + "'";
            dt_BaoCao = ThuVien.SQLiteLoad(sqlConn, sql);
            grdDuLieu.DataSource = dt_BaoCao;
            if (dt_BaoCao != null && dt_BaoCao.Rows.Count > 0)
            {
                grvDuLieu.FocusedRowHandle = 0;
            }
        }
    }
}
