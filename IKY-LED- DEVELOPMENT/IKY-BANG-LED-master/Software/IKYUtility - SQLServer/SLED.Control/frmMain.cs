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
using TienIch;
using IKYDatabase;
using DevExpress.XtraEditors;
using System.Reflection;

namespace IKY.Control
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private SqlConnection SqlConn = null;
        string s_SerialPort = "";
        string s_NhacNhoTraXe = "";
        // - Cấu hình bàn nâng
        // - Trả xe
        // - Điều chỉnh thời gian sửa chữa
        // - Tiếp nhận xe
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (this.SqlConn == null || this.SqlConn.State != ConnectionState.Open)            
            {
                Database.Open(ref this.SqlConn);                
            }
            
            if (SqlConn.State == ConnectionState.Open)
            {
                CapNhatDuLieuGridView();
                tshethong ts = new tshethong();
                ts.LoadAll(SqlConn);
                s_SerialPort = ts.CongCom;
                txtCongCom.Caption = s_SerialPort;
            }
            else
            {
                MessageBox.Show("Openning connection to database error!");
            }
            if(s_SerialPort!="")
            {
                TienIch.ComPort.serialPort_Open(s_SerialPort);
            }
            lblPhienBan.Caption = "Phiên bản: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void btnTaoBanNang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTaoBanNang frm = new frmTaoBanNang();
            frm.ShowDialog();
            if (frm.s_NewID != "")
            {
                if (SqlConn == null || SqlConn.State != ConnectionState.Open)
                {
                    Database.Open(ref this.SqlConn);
                }
                if (SqlConn.State == ConnectionState.Open)
                {
                    try
                    {
                        DsBanNang ds = new DsBanNang();
                        ds.Insert(SqlConn,frm.s_NewID,frm.s_KyThuatVien,frm.s_NoiDungHienThi);
                    }
                    catch
                    {
                        MessageBox.Show("Xử lý lỗi !", "Lỗi");
                    }
                    finally
                    {
                        CapNhatDuLieuGridView();
                    }
                }
            }
        }

        private void btnXoaBanNang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            DialogResult dialogResult = XtraMessageBox.Show("Bạn muốn xóa thông tin bàn nâng ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (SqlConn == null || SqlConn.State != ConnectionState.Open)
                {
                    Database.Open(ref this.SqlConn);
                }
                if (SqlConn.State == ConnectionState.Open)
                {
                    try
                    {
                        string s_ID = grvBanNang.GetRowCellValue(grvBanNang.FocusedRowHandle, "maql").ToString();
                        DsBanNang ds = new DsBanNang();
                        ds.UpdateTrangThaiKichHoat(SqlConn, s_ID,TrangThai.TrangThaiKichHoatBanNang.KhongHoatDong);
                    }
                    catch
                    {

                    }
                    finally
                    {
                        CapNhatDuLieuGridView();
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {            
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                if (SqlConn == null || SqlConn.State != ConnectionState.Open)
                {
                    Database.Open(ref this.SqlConn);
                }
                CapNhatDuLieuGridView();
            }
        }

        private void grvKhachHang_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == grvKhachHang_STT)
            {
                e.DisplayText = e.RowHandle < 0 ? "0" : (e.RowHandle + 1).ToString();
            }
        }

        private void btnTiepNhanKhach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTiepNhanKhach frm = new frmTiepNhanKhach(this.SqlConn, s_SerialPort);
            frm.ShowDialog();
            if (frm.s_HoTen != "" && frm.s_BienSoXe != "")
            {
                if (SqlConn == null || SqlConn.State != ConnectionState.Open)
                {
                    Database.Open(ref this.SqlConn);
                }
                if (SqlConn.State == ConnectionState.Open)
                {
                    try
                    {
                        DsKhachHang ds = new DsKhachHang();
                        ds.Insert(SqlConn, frm.s_HoTen, frm.s_BienSoXe,frm.s_GhiChu);
                    }
                    catch
                    {
                        MessageBox.Show("Xử lý lỗi !", "Lỗi");
                    }
                    finally
                    {
                        CapNhatDuLieuGridView();
                    }
                }
            }
        }

        private void btnNhan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string s_MaQL = grvKhachHang.GetRowCellValue(grvKhachHang.FocusedRowHandle, "maql").ToString();
                frmNhanKhachVaoBanNang frm = new frmNhanKhachVaoBanNang(SqlConn, s_MaQL, this.s_SerialPort);
                frm.ShowDialog();
            }catch{ }
            finally
            {
                CapNhatDuLieuGridView();
            }
        }

        private void btnTra_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DialogResult dialogResult = XtraMessageBox.Show("Bạn muốn xóa thông tin khách hàng khỏi danh sách ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (SqlConn == null || SqlConn.State != ConnectionState.Open)
                {
                    Database.Open(ref this.SqlConn);
                }
                if (SqlConn.State == ConnectionState.Open)
                {
                    try
                    {
                        string s_MaQL = grvKhachHang.GetRowCellValue(grvKhachHang.FocusedRowHandle, "maql").ToString();
                        DsKhachHang ds = new DsKhachHang();
                        ds.UpdateTrangThai(SqlConn, s_MaQL,TrangThai.TrangThaiKhachHang.KetThucSuaChua);
                    }
                    catch
                    {

                    }
                    finally
                    {
                        CapNhatDuLieuGridView();
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void grvBanNang_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == grvBanNangCol_STT)
            {
                e.DisplayText = e.RowHandle < 0 ? "0" : (e.RowHandle + 1).ToString();
            }
            if(e.Column == grvBanNangCol_TGConLai)
            {
                if (Convert.ToInt32(e.Value) < 0)
                    e.DisplayText = "";
            }
            if (e.Column == grvBanNangCol_TGSuaChua)
            {
                if (Convert.ToInt32(e.Value) < 0)
                    e.DisplayText = "";
            }
        }

        private void btnTiepNhanXe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string s_IDBanNang = grvBanNang.GetRowCellValue(grvBanNang.FocusedRowHandle, "maql").ToString();
                frmTiepNhanXe frm = new frmTiepNhanXe(SqlConn, s_SerialPort, s_IDBanNang);
                frm.ShowDialog();
            }
            catch
            {

            }
            finally
            {
                CapNhatDuLieuGridView();
            }
        }

        void CapNhatDuLieuGridView()
        {
            int i_TongBanNang = 0;
            int i_BanNangBan = 0;
            int i_TGConLai = 0;
            int i_BanNang_SelectIndex = 0;
            int i_KhachHang_SelectIndex = 0;
            int i_TraXe_SelectIndex = 0;
            string s_BanNangSuaChuaXong = "";
            if (SqlConn == null || SqlConn.State != ConnectionState.Open)
            {
                Database.Open(ref this.SqlConn);
            }
            if (SqlConn.State == ConnectionState.Open)
            {
                try
                {
                    i_BanNang_SelectIndex =grvBanNang.FocusedRowHandle;
                    i_KhachHang_SelectIndex = grvKhachHang.FocusedRowHandle;
                    i_TraXe_SelectIndex = grvTraXe.FocusedRowHandle;

                    TienIch.DsKhachHang dskhachhang = new DsKhachHang();
                    DataTable dt_DsKH = dskhachhang.LoadDSKHChoSuaChua(SqlConn);
                    grdKhachHang.DataSource = dt_DsKH;

                    TienIch.DsBanNang dsbannang = new DsBanNang();
                    DataTable dt_DsBN = dsbannang.LoadTheoTrangThaiKichHoat(SqlConn,TrangThai.TrangThaiKichHoatBanNang.HoatDong);

                    TienIch.DsTraXe ds_TraXe = new DsTraXe();
                    DataTable dt_TraXe = ds_TraXe.LoadDsChuaLayXe(SqlConn);
                    grdTraXe.DataSource = dt_TraXe;

                    try
                    {
                        if (dt_DsBN != null && dt_DsBN.Rows.Count > 0)
                        {
                            dt_DsBN.Columns.Add("thoigianconlai", typeof(decimal)).DefaultValue = 0;
                            dt_DsBN.Columns.Add("trangthaibn", typeof(string)).DefaultValue = "";
                            i_TongBanNang = dt_DsBN.Rows.Count;
                            foreach (DataRow r in dt_DsBN.Rows)
                            {
                                TrangThai.TrangThaiBanNang TT_TrangThai = (TrangThai.TrangThaiBanNang)Convert.ToInt16(r["trangthai"].ToString());
                                r["trangthaibn"] = TienIch.TrangThai.TrangThaiBanNang2String((TrangThai.TrangThaiBanNang)Convert.ToInt16(r["trangthai"].ToString()));
                                DateTime TGCapNhat = r["thoigianbd"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(r["thoigianbd"]);
                                TimeSpan diff = DateTime.Now.Subtract(TGCapNhat);
                                //double minutes = diff.TotalMinutes;
                                Int32 minutes = Convert.ToInt32(Math.Ceiling(diff.TotalMinutes)); //Làm tròn lên để hiển thị khớp với bảng LED
                                if (r["tongthoigian"] == DBNull.Value) r["tongthoigian"] = 0;
                                i_TGConLai = Convert.ToInt32(minutes) >= Convert.ToInt32(r["tongthoigian"]) ? 0 : Convert.ToInt32(r["tongthoigian"]) - Convert.ToInt32(minutes);
                                r["thoigianconlai"] = i_TGConLai;
                                if (TT_TrangThai != TrangThai.TrangThaiBanNang.DangSuaChua)
                                {
                                    r["hoten"] = "";
                                    r["thoigianbd"] = DateTime.MinValue;
                                    r["biensoxe"] = "";
                                    r["thoigianconlai"] = -1;
                                    r["tongthoigian"] = -1;
                                }
                                if (i_TGConLai <= 0 && TT_TrangThai == TrangThai.TrangThaiBanNang.DangSuaChua)
                                {
                                    s_BanNangSuaChuaXong += String.Format("[{0}]", r["maql"].ToString());
                                }
                            }
                        }
                        lblSLBanNang.Caption = String.Format("Hoạt động: {0}/{1}", i_BanNangBan, i_TongBanNang);
                        grdBanNang.DataSource = dt_DsBN;

                        grvBanNang.FocusedRowHandle = i_BanNang_SelectIndex;
                        grvKhachHang.FocusedRowHandle = i_KhachHang_SelectIndex;
                        grvTraXe.FocusedRowHandle = i_TraXe_SelectIndex;
                    }
                    catch
                    {

                    }
                }
                catch
                {

                }
                finally
                {
                    if (s_BanNangSuaChuaXong != s_NhacNhoTraXe)
                    {
                        s_NhacNhoTraXe = s_BanNangSuaChuaXong;
                        if (s_NhacNhoTraXe != "")
                        {
                            ntfNhacNho.Visible = true;
                            ntfNhacNho.Icon = SystemIcons.Exclamation;
                            ntfNhacNho.BalloonTipTitle = "IKY-LED";
                            ntfNhacNho.BalloonTipText = "Bàn nâng " + s_NhacNhoTraXe + " đã sửa chữa xong";
                            ntfNhacNho.BalloonTipIcon = ToolTipIcon.Warning;
                            ntfNhacNho.ShowBalloonTip(10000);
                        }
                    }
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnTraXe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string s_IDBanNang = grvBanNang.GetRowCellValue(grvBanNang.FocusedRowHandle, "maql").ToString();
                DsBanNang dsBN = new DsBanNang();
                TrangThai.TrangThaiBanNang ttBN = dsBN.LoadTrangThaiBanNang(SqlConn, s_IDBanNang);
                if (ttBN == TrangThai.TrangThaiBanNang.DangSuaChua)
                {
                    frmTraXe frm = new frmTraXe(SqlConn, s_IDBanNang,s_SerialPort);
                    frm.ShowDialog();
                }
            }
            catch { }
            finally
            {
                CapNhatDuLieuGridView();
            }
        }

        private void btnXuatBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBaoCao frm = new frmBaoCao(SqlConn);
            frm.ShowDialog();
        }

        private void btnGiamThoiGian_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string s_IDBanNang = grvBanNang.GetRowCellValue(grvBanNang.FocusedRowHandle, "maql").ToString();
                frmChinhThoiGian frm = new frmChinhThoiGian(SqlConn, s_SerialPort, s_IDBanNang, false);
                frm.ShowDialog();
            }
            catch 
            { 
            }
            finally
            {
                CapNhatDuLieuGridView();
            }
        }

        private void btnCauHinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThongSo frm = new frmThongSo(SqlConn);
            frm.ShowDialog();
        }

        private void grdBanNang_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaBanNang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string s_IDBanNang = "";
            try
            {
                s_IDBanNang = grvBanNang.GetRowCellValue(grvBanNang.FocusedRowHandle, "maql").ToString();

                frmTaoBanNang frm = new frmTaoBanNang(s_SerialPort, SqlConn, true, s_IDBanNang);
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Xử lý lỗi !", "Lỗi");
            }
            finally
            {
                CapNhatDuLieuGridView();
            }
        }

        private void btnCapNhatBangLED_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string s_IDBanNang = grvBanNang.GetRowCellValue(grvBanNang.FocusedRowHandle, "maql").ToString();
                string s_NDThongBao = grvBanNang.GetRowCellValue(grvBanNang.FocusedRowHandle, "ndhienthi").ToString();
                string s_KyThuatVien = grvBanNang.GetRowCellValue(grvBanNang.FocusedRowHandle, "kythuatvien").ToString();
                frmCapNhatbangLED frm = new frmCapNhatbangLED(s_SerialPort, s_IDBanNang, s_NDThongBao, s_KyThuatVien);
                frm.ShowDialog();
            }
            catch { }
            finally { }
        }

        private void btnCaiDatCSDL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCaiDatCSDL frm = new frmCaiDatCSDL();
            frm.ShowDialog();
        }

        private void btnTaoCauTrucDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTaoCauTrucDuLieu frm = new frmTaoCauTrucDuLieu();
            frm.ShowDialog();
        }

        private void tmrLamMoiDuLieu_Tick(object sender, EventArgs e)
        {

            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    CapNhatDuLieuGridView();
                }
                catch { }
            });
        }

        private void btnTraKhach_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            btnTra_ButtonClick(sender, e);
        }

        private void btnNhanKhach_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            btnNhan_ButtonClick(sender, e);
        }

        private void btnKHNhanXe_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DialogResult dialogResult = XtraMessageBox.Show("Khách đã nhận xe, xe sẽ được xóa khỏi danh sách ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (SqlConn == null || SqlConn.State != ConnectionState.Open)
                {
                    Database.Open(ref this.SqlConn);
                }
                if (SqlConn.State == ConnectionState.Open)
                {
                    try
                    {
                        string s_MaQL = grvTraXe.GetRowCellValue(grvTraXe.FocusedRowHandle, "maql").ToString();
                        DsTraXe ds = new DsTraXe();
                        ds.UpdateTrangThai(SqlConn, s_MaQL);
                    }
                    catch
                    {

                    }
                    finally
                    {
                        CapNhatDuLieuGridView();
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void btnThongBao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThongBao frm = new frmThongBao(this.SqlConn);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnTatThongBao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = XtraMessageBox.Show("Bạn muốn tắt thông báo ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (SqlConn == null || SqlConn.State != ConnectionState.Open)
                {
                    Database.Open(ref this.SqlConn);
                }
                if (SqlConn.State == ConnectionState.Open)
                {
                    try
                    {
                        DsThongBao ds = new DsThongBao();
                        ds.UpdateTrangThai(SqlConn);
                    }
                    catch
                    {

                    }
                    finally
                    {
                        CapNhatDuLieuGridView();
                    }
                }
            }
        }

        private void btnKhaiBaoThe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (s_SerialPort != "")
            {
                TienIch.ComPort.serialPort_Open(s_SerialPort, false);
            }
            QuanLyThe.frmKhaiBaoThe frm = new QuanLyThe.frmKhaiBaoThe(this.SqlConn);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnTrangChu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("http://iky.vn");
        }

        private void btnGoi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            if (SqlConn == null || SqlConn.State != ConnectionState.Open)
            {
                Database.Open(ref this.SqlConn);
            }
            if (SqlConn.State == ConnectionState.Open)
            {
                try
                {
                    string s_MaQL = grvTraXe.GetRowCellValue(grvTraXe.FocusedRowHandle, "maql").ToString();
                    DsTraXe ds = new DsTraXe();
                    ds.UpdateTrangThaiGoiLayXe(SqlConn, s_MaQL,TrangThai.TraiThaiGoiLayXe.DangGoi);
                }
                catch
                {

                }
                finally
                {
                    CapNhatDuLieuGridView();
                }
            }
        }

        private void btnSuaThongTinKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string s_IDBanNang = grvBanNang.GetRowCellValue(grvBanNang.FocusedRowHandle, "maql").ToString();
                frmSuaThongTinKH frm = new frmSuaThongTinKH(this.SqlConn, this.s_SerialPort, s_IDBanNang);
                frm.ShowDialog();
                frm.Dispose();
            }
            catch { }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnTangThoiGian_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string s_IDBanNang = grvBanNang.GetRowCellValue(grvBanNang.FocusedRowHandle, "maql").ToString();
                frmChinhThoiGian frm = new frmChinhThoiGian(SqlConn, s_SerialPort, s_IDBanNang, true);
                frm.ShowDialog();
            }
            catch
            {
            }
            finally
            {
                CapNhatDuLieuGridView();
            }
        }
    }
}
