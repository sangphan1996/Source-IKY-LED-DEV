using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TienIch;
using System.Timers;
using DevExpress.XtraEditors;
using IKYDatabase;

namespace IKY.Display
{
    public partial class frmMain_v1 : Form
    {
        string[] sThuTrongTuan = new string[] { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };
        private SqlConnection SqlConn = null;
        private static System.Timers.Timer aTimer;        
        int i_IndexThongBaoTraXe = 0;
        int i_IndexThongBao = 0;
        string s_Header = "";
        string s_Footer = "";

        DataTable dt_ThongBaoLayXe = null;
        DataTable dt_ThongBao = null;
        DataTable dt_BanNang = null;
        DataTable dt_KhachHang = null;
        DataTable dt_TraXe = null;

        int iTocDoHieuUngThongBaoTraXe = 10; 
        Int32 iDsKhachHangIndex = 0;
        Int32 iDsBanNangIndex = 0;
        Int32 iDsTraXeIndex = 0;
        Int32 iThoiGianHienThiDuLieu = 0;
        int i_SoDongHienThi = 0;

        bool bHienThiDuLieuMoi = true;

        int tmrHeaderEffect_Counter = 0;
        public frmMain_v1()
        {
            InitializeComponent();
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    TopMost = true;
                    break;
                case Keys.Escape:
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    TopMost = false;
                    break;
                default:
                    break;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {        
            //Double click
            panelHeader.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDoubleClick);
            panelFooter.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDoubleClick);
            grdBanNang.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDoubleClick);
            grdKhachHang.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDoubleClick);
            //
            if (SqlConn == null || SqlConn.State != ConnectionState.Open)
            {
                Database.Open(ref this.SqlConn);
            }
            CapNhatDuLieuGridView();
            
            if (SqlConn.State == ConnectionState.Open)
            {
                TienIch.tshienthi ts = new tshienthi();
                ts.LoadAll(SqlConn);
                s_Header = ts.Header;
                s_Footer = ts.Footer;
                i_SoDongHienThi = ts.SoDongHienThi;
                iThoiGianHienThiDuLieu = ts.TGHienThi;

                TienIch.DsTraXe ds = new DsTraXe();
                DataTable dt_TraXe = ds.LoadDsHienThiThongBao(SqlConn);
            }                      
            iTocDoHieuUngThongBaoTraXe = Database.TocDoHieuUngThongBaoTraXe;
            //view
            lblTenCty.Text = s_Header;
            lblThongBaoTraXe.Text = s_Footer; 

            grvBanNangCol_BanNang.Caption = String.Format("{0}" + Environment.NewLine + "{1}", "BÀN", "NÂNG");
            grvBanNangCol_TGConLai.Caption = String.Format("{0}" + Environment.NewLine + "{1}", "TG", "BẮT ĐẦU");
            grvBanNangCol_TGSuaChua.Caption = String.Format("{0}" + Environment.NewLine + "{1}", "TG", "SỬA");
            grvBanNangCol_TGConLai.Caption = String.Format("{0}" + Environment.NewLine + "{1}", "TG", "CÒN LẠI");
            //            
            lblThongBaoTraXe.ForeColor = Database.MauChuThongBaoTraXe;
            //
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            //
            SetTimer();
        }


        void CapNhatDuLieuGridView()
        {
            int i_TGConLai = 0;
            if (SqlConn == null || SqlConn.State != ConnectionState.Open)
            {
                Database.Open(ref this.SqlConn);
            }
            if (SqlConn.State == ConnectionState.Open)
            {
                try
                {
                    //Cập nhật thông số
                    TienIch.tshienthi ts = new tshienthi();
                    ts.LoadAll(SqlConn);
                    s_Header = ts.Header;
                    s_Footer = ts.Footer;
                    i_SoDongHienThi = ts.SoDongHienThi;
                    iThoiGianHienThiDuLieu = ts.TGHienThi;
                    //
                    TienIch.DsKhachHang dskhachhang = new DsKhachHang();
                    dt_KhachHang = dskhachhang.LoadDSKHChoSuaChua(SqlConn);
                    if (bHienThiDuLieuMoi) //định kỳ 5s hiển thị dữ liệu
                    {
                        if (dt_KhachHang != null && dt_KhachHang.Rows.Count > 0)
                        {
                            DataTable dt_dsKH = new DataTable();
                            if (dt_KhachHang.Rows.Count < i_SoDongHienThi)
                            {
                                dt_dsKH = dt_KhachHang.Copy();
                                iDsKhachHangIndex = 0;
                            }
                            else
                            {
                                dt_dsKH = dt_KhachHang.Clone();
                                if (iDsKhachHangIndex >= dt_KhachHang.Rows.Count)
                                {
                                    iDsKhachHangIndex = 0;
                                }
                                for (int i = 0; i < i_SoDongHienThi; i++)
                                {
                                    if ((iDsKhachHangIndex + i) < dt_KhachHang.Rows.Count)
                                    {
                                        dt_dsKH.ImportRow(dt_KhachHang.Rows[iDsKhachHangIndex + i]);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                iDsKhachHangIndex += i_SoDongHienThi;
                                if (iDsKhachHangIndex >= dt_KhachHang.Rows.Count)
                                {
                                    iDsKhachHangIndex = 0;
                                }
                            }
                            grdKhachHang.DataSource = dt_dsKH;
                        }
                        else
                        {
                            grdKhachHang.DataSource = dt_KhachHang;
                            iDsKhachHangIndex = 0;
                        }
                    }
                    ///////////////////////////////////////////////
                    TienIch.DsBanNang dsbannang = new DsBanNang();
                    dt_BanNang = dsbannang.LoadAll(SqlConn);
                    try
                    {
                        if (dt_BanNang != null && dt_BanNang.Rows.Count > 0)
                        {
                            dt_BanNang.Columns.Add("thoigianconlai", typeof(decimal)).DefaultValue = 0;
                            dt_BanNang.Columns.Add("trangthaibn", typeof(string)).DefaultValue = "";
                            foreach (DataRow r in dt_BanNang.Rows)
                            {
                                TrangThai.TrangThaiBanNang TT_TrangThai = (TrangThai.TrangThaiBanNang)Convert.ToInt16(r["trangthai"].ToString());
                                r["trangthaibn"] = TienIch.TrangThai.TrangThaiBanNang2String((TrangThai.TrangThaiBanNang)Convert.ToInt16(r["trangthai"].ToString()));
                                DateTime TGCapNhat = r["thoigianbd"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(r["thoigianbd"]);
                                TimeSpan diff = DateTime.Now.Subtract(TGCapNhat);
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
                            }
                        }                        
                    }
                    catch
                    {

                    }
                    if (bHienThiDuLieuMoi) //định kỳ 5s hiển thị dữ liệu
                    {
                        if (dt_BanNang != null && dt_BanNang.Rows.Count > 0)
                        {
                            DataTable dt_HienThi = new DataTable();
                            if (dt_BanNang.Rows.Count < i_SoDongHienThi)
                            {
                                dt_HienThi = dt_BanNang.Copy();
                                iDsBanNangIndex = 0;
                            }
                            else
                            {
                                dt_HienThi = dt_BanNang.Clone();
                                if (iDsBanNangIndex >= dt_BanNang.Rows.Count)
                                {
                                    iDsBanNangIndex = 0;
                                }
                                for (int i = 0; i < i_SoDongHienThi; i++)
                                {
                                    if ((iDsBanNangIndex + i) < dt_BanNang.Rows.Count)
                                    {
                                        dt_HienThi.ImportRow(dt_BanNang.Rows[iDsBanNangIndex + i]);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                iDsBanNangIndex += i_SoDongHienThi;
                                if (iDsBanNangIndex >= dt_BanNang.Rows.Count)
                                {
                                    iDsBanNangIndex = 0;
                                }
                            }
                            grdBanNang.DataSource = dt_HienThi;
                        }
                        else
                        {
                            grdBanNang.DataSource = dt_BanNang;
                            iDsBanNangIndex = 0;
                        }
                    }
                    //////////////////////////////////////////////////////////////////////////////////////
                    DsTraXe ds_TraXe = new DsTraXe();
                    // Hiển thị lên grid                    
                    dt_TraXe = ds_TraXe.LoadDsChuaLayXe(SqlConn);                    
                    if (bHienThiDuLieuMoi) //định kỳ 5s hiển thị dữ liệu
                    {
                        if (dt_TraXe != null && dt_TraXe.Rows.Count > 0)
                        {
                            DataTable dt_HienThi = new DataTable();
                            if (dt_TraXe.Rows.Count < i_SoDongHienThi)
                            {
                                dt_HienThi = dt_TraXe.Copy();
                                iDsTraXeIndex = 0;
                            }
                            else
                            {
                                dt_HienThi = dt_TraXe.Clone();
                                if (iDsTraXeIndex >= dt_TraXe.Rows.Count)
                                {
                                    iDsTraXeIndex = 0;
                                }
                                for (int i = 0; i < i_SoDongHienThi; i++)
                                {
                                    if ((iDsTraXeIndex + i) < dt_TraXe.Rows.Count)
                                    {
                                        dt_HienThi.ImportRow(dt_TraXe.Rows[iDsTraXeIndex + i]);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                iDsTraXeIndex += i_SoDongHienThi;
                                if (iDsTraXeIndex >= dt_TraXe.Rows.Count)
                                {
                                    iDsTraXeIndex = 0;
                                }
                            }
                            grdTraXe.DataSource = dt_HienThi;
                        }
                        else
                        {
                            grdTraXe.DataSource = dt_TraXe;
                            iDsTraXeIndex = 0;
                        }
                    }
                    // Chạy chữ footer
                    DataTable dt_KQTraXe = ds_TraXe.LoadDsHienThiThongBao(SqlConn);

                    if (dt_KQTraXe != null && dt_KQTraXe.Rows.Count > 0)
                    {
                        if (dt_ThongBaoLayXe == null)
                        {
                            dt_ThongBaoLayXe = dt_KQTraXe.Clone();// Clone() only clones the table structure. It does not also clone the data.
                        }
                        for (int i = 0; i < dt_KQTraXe.Rows.Count; i++)
                        {
                            bool isDupe = false;
                            for (int j = 0; j < dt_ThongBaoLayXe.Rows.Count; j++)
                            {
                                if (dt_KQTraXe.Rows[i][0].ToString() == dt_ThongBaoLayXe.Rows[j][0].ToString())                                                                        
                                {                                    
                                    isDupe = true;
                                    break;
                                }
                            }

                            if (!isDupe)
                            {
                                dt_ThongBaoLayXe.ImportRow(dt_KQTraXe.Rows[i]);
                            }
                        }
                    }
                }
                catch
                {

                }
            }            
        }

        private void grvBanNang_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == grvBanNangCol_STT)
            {
                e.DisplayText = e.RowHandle < 0 ? "0" : (e.RowHandle + 1).ToString();
            }
            if (e.Column == grvBanNangCol_TGConLai)
            {
                if (Convert.ToInt32(e.Value) < 0)
                    e.DisplayText = "";
            }
            if (e.Column == grvBanNangCol_TGSuaChua)
            {
                if (Convert.ToInt32(e.Value) < 0)
                    e.DisplayText = "";
            }
            if (e.Column == grvBanNangCol_TGBatDau)
            {
                if (Convert.ToDateTime(e.Value) == DateTime.MinValue)
                    e.DisplayText = "";
            }
        }

        private void SetTimer()
        {
            if (iThoiGianHienThiDuLieu <= 0) iThoiGianHienThiDuLieu = 15;
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(iThoiGianHienThiDuLieu * 1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            bHienThiDuLieuMoi = true;
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    CapNhatDuLieuGridView();
                }
                catch { }
            });            
        }

        private void grvKhachHang_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == grvKhachHangCol_STT)
            {
                e.DisplayText = e.RowHandle < 0 ? "0" : (e.RowHandle + 1).ToString();
            }
        }

        private void tmrLabelEffect_Tick(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (lblThongBaoTraXe.Text.Trim() != "")
                {
                    if (lblThongBaoTraXe.Left < (0 - lblThongBaoTraXe.Width))
                    {
                        lblThongBaoTraXe.Left = this.Width;

                        if (dt_ThongBaoLayXe != null && dt_ThongBaoLayXe.Rows.Count > 0 && Database.SoLanHienThiThongBaoTraXe > 0)
                        {
                            DataRow r = dt_ThongBaoLayXe.Rows[i_IndexThongBaoTraXe];
                            string s_ThongBao = "Mời quý khách " + "<color=" + ColorTranslator.ToHtml(Database.MauChuThongTinTraXe) + ">" + r["hoten"].ToString() + "</color>" + "- Biển số xe (" + "<color=" + ColorTranslator.ToHtml(Database.MauChuThongTinTraXe) + ">" + r["biensoxe"] + "</color>" + ") vui lòng đến nhận xe";
                            lblThongBaoTraXe.Text = s_ThongBao.ToUpper(); //Hiển thị thông báo
                            int iSoLanHienThi = r["solanhienthi"] == null ? 0 : Convert.ToInt32(r["solanhienthi"].ToString());
                            if (iSoLanHienThi <= 1)
                            {
                                dt_ThongBaoLayXe.Rows[i_IndexThongBaoTraXe].Delete();
                                dt_ThongBaoLayXe.AcceptChanges();
                            }
                            else
                            {
                                iSoLanHienThi = iSoLanHienThi - 1;
                                dt_ThongBaoLayXe.Rows[i_IndexThongBaoTraXe][1] = iSoLanHienThi;
                                i_IndexThongBaoTraXe++;
                            }
                            if (i_IndexThongBaoTraXe > (dt_ThongBaoLayXe.Rows.Count - 1))
                            {
                                i_IndexThongBaoTraXe = 0;
                            }
                        }
                        else
                        {
                            i_IndexThongBaoTraXe = 0;
                            lblThongBaoTraXe.Text = s_Footer;
                        }
                    }
                    else
                    {
                        lblThongBaoTraXe.Left -= iTocDoHieuUngThongBaoTraXe;
                    }
                }                
                DateTime d = DateTime.Now;
                lblTime.Text = d.ToString("HH:mm:ss");
                int i = (int)d.DayOfWeek;
                lblDate.Text = sThuTrongTuan[i] + " " + d.ToString("dd/MM/yy");
            });
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            aTimer.Stop();
            aTimer.Dispose();
            System.Windows.Forms.Application.Exit();
        }

        private void grvKhachHang_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.RowHandle % 2 == 0)
                {
                    e.Appearance.BackColor = System.Drawing.Color.Black;
                }
                else
                {
                    e.Appearance.BackColor = System.Drawing.Color.Navy;
                }
            }
        }

        private void grvBanNang_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.RowHandle % 2 == 0)
                {
                    e.Appearance.BackColor = System.Drawing.Color.Black;
                }
                else
                {
                    e.Appearance.BackColor = System.Drawing.Color.Navy;
                }
            }
        }
        private void grvTraXe_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.RowHandle % 2 == 0)
                {
                    e.Appearance.BackColor = System.Drawing.Color.Black;
                }
                else
                {
                    e.Appearance.BackColor = System.Drawing.Color.Navy;
                }
            }
        }
        private void frmMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (TopMost == false)
            {
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                TopMost = true;
            }
            else
            {
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void tmrHeaderEffect_Tick(object sender, EventArgs e)
        {
            tmrHeaderEffect_Counter++;
            if (tmrHeaderEffect_Counter > 10)
            {
                DsThongBao ds_Thongbao = new DsThongBao();
                dt_ThongBao = ds_Thongbao.LoadDsHienThiThongBao(SqlConn);
                
                tmrHeaderEffect_Counter = 0;
            }
            this.Invoke((MethodInvoker)delegate
            {
                if (dt_ThongBao != null && dt_ThongBao.Rows.Count > 0)
                {
                    if (dt_ThongBao != null && dt_ThongBao.Rows.Count > 0 && Database.SoLanHienThiThongBaoTraXe > 0)
                    {
                        i_IndexThongBao = 0;
                      
                        DataRow r = dt_ThongBao.Rows[i_IndexThongBao];
                        string s_ThongBao = r["noidung"].ToString();
                        lblTenCty.Text = s_ThongBao.ToUpper(); //Hiển thị thông báo 
                        if (lblTenCty.Left < (0 - lblTenCty.Width))
                        {
                            lblTenCty.Left = this.Width - grpDateTime.Width;
                        }
                        else
                        {
                            lblTenCty.Left -= iTocDoHieuUngThongBaoTraXe;
                        }
                    }
                    else
                    {
                        i_IndexThongBao = 0;
                        lblTenCty.Text = s_Header;
                        lblTenCty.Left = 0;
                    }                    
                }
                else
                {
                    i_IndexThongBao = 0;
                    lblTenCty.Text = s_Header;
                    lblTenCty.Left = 0;
                }
            });
        }

        
    }
}
