namespace SLED
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grdDuLieu = new DevExpress.XtraGrid.GridControl();
            this.grvDuLieu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdCol_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdCol_KyThuatVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdCol_QuangCao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdCol_TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdCol_ThoiGian = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdCol_KhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdCol_BSX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnTaoBanNang = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoaBanNang = new DevExpress.XtraBars.BarButtonItem();
            this.btnTTBanNang = new DevExpress.XtraBars.BarButtonItem();
            this.btnGioiThieu = new DevExpress.XtraBars.BarButtonItem();
            this.btnTrangChu = new DevExpress.XtraBars.BarButtonItem();
            this.btnLamMoiDuLieu = new DevExpress.XtraBars.BarButtonItem();
            this.btnTTKhachHang = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoSoCoDuLieu = new DevExpress.XtraBars.BarButtonItem();
            this.btnXemBaoCao = new DevExpress.XtraBars.BarButtonItem();
            this.btnCongGiaoTiep = new DevExpress.XtraBars.BarButtonItem();
            this.btnChinhThoiGian = new DevExpress.XtraBars.BarButtonItem();
            this.btnTraXe = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.txtTTCongGiaoTiep = new DevExpress.XtraBars.BarStaticItem();
            this.txtTrangThaiBanNang = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.taskbarAssistant1 = new DevExpress.Utils.Taskbar.TaskbarAssistant();
            this.thumbnailButton1 = new DevExpress.Utils.Taskbar.ThumbnailButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdDuLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDuLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDuLieu
            // 
            this.grdDuLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDuLieu.Location = new System.Drawing.Point(0, 144);
            this.grdDuLieu.MainView = this.grvDuLieu;
            this.grdDuLieu.Name = "grdDuLieu";
            this.grdDuLieu.Size = new System.Drawing.Size(875, 330);
            this.grdDuLieu.TabIndex = 4;
            this.grdDuLieu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDuLieu});
            // 
            // grvDuLieu
            // 
            this.grvDuLieu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdCol_STT,
            this.grdCol_KyThuatVien,
            this.grdCol_QuangCao,
            this.grdCol_TrangThai,
            this.grdCol_ThoiGian,
            this.grdCol_KhachHang,
            this.grdCol_BSX,
            this.gridColumn1});
            this.grvDuLieu.GridControl = this.grdDuLieu;
            this.grvDuLieu.Name = "grvDuLieu";
            this.grvDuLieu.OptionsBehavior.Editable = false;
            this.grvDuLieu.Click += new System.EventHandler(this.grvDuLieu_Click);
            this.grvDuLieu.DoubleClick += new System.EventHandler(this.grvDuLieu_DoubleClick);
            // 
            // grdCol_STT
            // 
            this.grdCol_STT.AppearanceCell.Options.UseTextOptions = true;
            this.grdCol_STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdCol_STT.AppearanceHeader.Options.UseTextOptions = true;
            this.grdCol_STT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdCol_STT.Caption = "Bàn nâng";
            this.grdCol_STT.FieldName = "id";
            this.grdCol_STT.Name = "grdCol_STT";
            this.grdCol_STT.Visible = true;
            this.grdCol_STT.VisibleIndex = 0;
            this.grdCol_STT.Width = 57;
            // 
            // grdCol_KyThuatVien
            // 
            this.grdCol_KyThuatVien.AppearanceHeader.Options.UseTextOptions = true;
            this.grdCol_KyThuatVien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdCol_KyThuatVien.Caption = "Kỹ thuật viên";
            this.grdCol_KyThuatVien.FieldName = "ktv";
            this.grdCol_KyThuatVien.Name = "grdCol_KyThuatVien";
            this.grdCol_KyThuatVien.Visible = true;
            this.grdCol_KyThuatVien.VisibleIndex = 1;
            this.grdCol_KyThuatVien.Width = 104;
            // 
            // grdCol_QuangCao
            // 
            this.grdCol_QuangCao.AppearanceHeader.Options.UseTextOptions = true;
            this.grdCol_QuangCao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdCol_QuangCao.Caption = "Câu chào";
            this.grdCol_QuangCao.FieldName = "greetings";
            this.grdCol_QuangCao.Name = "grdCol_QuangCao";
            this.grdCol_QuangCao.Visible = true;
            this.grdCol_QuangCao.VisibleIndex = 2;
            this.grdCol_QuangCao.Width = 163;
            // 
            // grdCol_TrangThai
            // 
            this.grdCol_TrangThai.AppearanceHeader.Options.UseTextOptions = true;
            this.grdCol_TrangThai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdCol_TrangThai.Caption = "Trạng thái";
            this.grdCol_TrangThai.FieldName = "trangthai";
            this.grdCol_TrangThai.Name = "grdCol_TrangThai";
            this.grdCol_TrangThai.Visible = true;
            this.grdCol_TrangThai.VisibleIndex = 3;
            this.grdCol_TrangThai.Width = 68;
            // 
            // grdCol_ThoiGian
            // 
            this.grdCol_ThoiGian.AppearanceCell.Options.UseTextOptions = true;
            this.grdCol_ThoiGian.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdCol_ThoiGian.AppearanceHeader.Options.UseTextOptions = true;
            this.grdCol_ThoiGian.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdCol_ThoiGian.Caption = "Tổng thời gian";
            this.grdCol_ThoiGian.FieldName = "counter";
            this.grdCol_ThoiGian.Name = "grdCol_ThoiGian";
            this.grdCol_ThoiGian.Visible = true;
            this.grdCol_ThoiGian.VisibleIndex = 6;
            this.grdCol_ThoiGian.Width = 68;
            // 
            // grdCol_KhachHang
            // 
            this.grdCol_KhachHang.AppearanceHeader.Options.UseTextOptions = true;
            this.grdCol_KhachHang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdCol_KhachHang.Caption = "Khách hàng";
            this.grdCol_KhachHang.FieldName = "khachhang";
            this.grdCol_KhachHang.Name = "grdCol_KhachHang";
            this.grdCol_KhachHang.Visible = true;
            this.grdCol_KhachHang.VisibleIndex = 4;
            this.grdCol_KhachHang.Width = 117;
            // 
            // grdCol_BSX
            // 
            this.grdCol_BSX.AppearanceHeader.Options.UseTextOptions = true;
            this.grdCol_BSX.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdCol_BSX.Caption = "Biển số xe";
            this.grdCol_BSX.FieldName = "biensoxe";
            this.grdCol_BSX.Name = "grdCol_BSX";
            this.grdCol_BSX.Visible = true;
            this.grdCol_BSX.VisibleIndex = 5;
            this.grdCol_BSX.Width = 54;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Thời gian còn lại";
            this.gridColumn1.FieldName = "thoigianconlai";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 65;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "delete.png");
            this.imageList1.Images.SetKeyName(1, "arrow-refresh.png");
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbonControl1.ApplicationIcon")));
            this.ribbonControl1.BackColor = System.Drawing.Color.White;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Images = this.imageList1;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnTaoBanNang,
            this.btnXoaBanNang,
            this.btnTTBanNang,
            this.btnGioiThieu,
            this.btnTrangChu,
            this.btnLamMoiDuLieu,
            this.btnTTKhachHang,
            this.btnTaoSoCoDuLieu,
            this.btnXemBaoCao,
            this.btnCongGiaoTiep,
            this.btnChinhThoiGian,
            this.btnTraXe,
            this.barButtonItem1,
            this.barButtonItem2,
            this.txtTTCongGiaoTiep,
            this.txtTrangThaiBanNang});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 9;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(875, 144);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnTaoBanNang
            // 
            this.btnTaoBanNang.Caption = "Tạo bàn nâng";
            this.btnTaoBanNang.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTaoBanNang.Glyph")));
            this.btnTaoBanNang.Id = 1;
            this.btnTaoBanNang.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTaoBanNang.LargeGlyph")));
            this.btnTaoBanNang.Name = "btnTaoBanNang";
            this.btnTaoBanNang.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnTaoBanNang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoBanNang_ItemClick);
            // 
            // btnXoaBanNang
            // 
            this.btnXoaBanNang.Caption = "Xóa bàn nâng";
            this.btnXoaBanNang.Glyph = ((System.Drawing.Image)(resources.GetObject("btnXoaBanNang.Glyph")));
            this.btnXoaBanNang.Id = 2;
            this.btnXoaBanNang.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnXoaBanNang.LargeGlyph")));
            this.btnXoaBanNang.Name = "btnXoaBanNang";
            this.btnXoaBanNang.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnXoaBanNang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoaBanNang_ItemClick);
            // 
            // btnTTBanNang
            // 
            this.btnTTBanNang.Caption = "Thông tin bàn nâng";
            this.btnTTBanNang.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTTBanNang.Glyph")));
            this.btnTTBanNang.Id = 3;
            this.btnTTBanNang.Name = "btnTTBanNang";
            this.btnTTBanNang.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnTTBanNang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTTBanNang_ItemClick);
            // 
            // btnGioiThieu
            // 
            this.btnGioiThieu.Caption = "Giới thiệu";
            this.btnGioiThieu.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGioiThieu.Glyph")));
            this.btnGioiThieu.Id = 4;
            this.btnGioiThieu.Name = "btnGioiThieu";
            this.btnGioiThieu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnGioiThieu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGioiThieu_ItemClick);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Caption = "Trang chủ";
            this.btnTrangChu.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTrangChu.Glyph")));
            this.btnTrangChu.Id = 5;
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnTrangChu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTrangChu_ItemClick);
            // 
            // btnLamMoiDuLieu
            // 
            this.btnLamMoiDuLieu.Caption = "Làm mới dữ liệu";
            this.btnLamMoiDuLieu.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLamMoiDuLieu.Glyph")));
            this.btnLamMoiDuLieu.Id = 6;
            this.btnLamMoiDuLieu.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLamMoiDuLieu.LargeGlyph")));
            this.btnLamMoiDuLieu.Name = "btnLamMoiDuLieu";
            this.btnLamMoiDuLieu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnLamMoiDuLieu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLamMoiDuLieu_ItemClick);
            // 
            // btnTTKhachHang
            // 
            this.btnTTKhachHang.Caption = "TT khách hàng";
            this.btnTTKhachHang.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTTKhachHang.Glyph")));
            this.btnTTKhachHang.Id = 7;
            this.btnTTKhachHang.Name = "btnTTKhachHang";
            this.btnTTKhachHang.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnTTKhachHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTTKhachHang_ItemClick);
            // 
            // btnTaoSoCoDuLieu
            // 
            this.btnTaoSoCoDuLieu.Caption = "Tạo cơ sở dữ liệu";
            this.btnTaoSoCoDuLieu.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTaoSoCoDuLieu.Glyph")));
            this.btnTaoSoCoDuLieu.Id = 8;
            this.btnTaoSoCoDuLieu.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTaoSoCoDuLieu.LargeGlyph")));
            this.btnTaoSoCoDuLieu.Name = "btnTaoSoCoDuLieu";
            this.btnTaoSoCoDuLieu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnTaoSoCoDuLieu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoSoCoDuLieu_ItemClick);
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.Caption = "Xem báo cáo";
            this.btnXemBaoCao.Glyph = ((System.Drawing.Image)(resources.GetObject("btnXemBaoCao.Glyph")));
            this.btnXemBaoCao.Id = 9;
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnXemBaoCao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemBaoCao_ItemClick);
            // 
            // btnCongGiaoTiep
            // 
            this.btnCongGiaoTiep.Caption = "Cổng giao tiếp";
            this.btnCongGiaoTiep.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCongGiaoTiep.Glyph")));
            this.btnCongGiaoTiep.Id = 10;
            this.btnCongGiaoTiep.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCongGiaoTiep.LargeGlyph")));
            this.btnCongGiaoTiep.Name = "btnCongGiaoTiep";
            this.btnCongGiaoTiep.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnCongGiaoTiep.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCongGiaoTiep_ItemClick);
            // 
            // btnChinhThoiGian
            // 
            this.btnChinhThoiGian.Caption = "Chỉnh thời gian";
            this.btnChinhThoiGian.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChinhThoiGian.Glyph")));
            this.btnChinhThoiGian.Id = 1;
            this.btnChinhThoiGian.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChinhThoiGian.LargeGlyph")));
            this.btnChinhThoiGian.Name = "btnChinhThoiGian";
            this.btnChinhThoiGian.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnChinhThoiGian.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChinhThoiGian_ItemClick);
            // 
            // btnTraXe
            // 
            this.btnTraXe.Caption = "Trả xe";
            this.btnTraXe.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTraXe.Glyph")));
            this.btnTraXe.Id = 2;
            this.btnTraXe.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTraXe.LargeGlyph")));
            this.btnTraXe.Name = "btnTraXe";
            this.btnTraXe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTraXe_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Khởi động lại";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Thoát";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 4;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // txtTTCongGiaoTiep
            // 
            this.txtTTCongGiaoTiep.Caption = "COM ?";
            this.txtTTCongGiaoTiep.Glyph = ((System.Drawing.Image)(resources.GetObject("txtTTCongGiaoTiep.Glyph")));
            this.txtTTCongGiaoTiep.Id = 6;
            this.txtTTCongGiaoTiep.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("txtTTCongGiaoTiep.LargeGlyph")));
            this.txtTTCongGiaoTiep.Name = "txtTTCongGiaoTiep";
            this.txtTTCongGiaoTiep.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // txtTrangThaiBanNang
            // 
            this.txtTrangThaiBanNang.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.txtTrangThaiBanNang.Caption = "Hoạt động: ?/?";
            this.txtTrangThaiBanNang.Id = 8;
            this.txtTrangThaiBanNang.Name = "txtTrangThaiBanNang";
            this.txtTrangThaiBanNang.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup5,
            this.ribbonPageGroup4,
            this.ribbonPageGroup6});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Trang chính";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnTaoBanNang);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnXoaBanNang);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnTTBanNang);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Bàn nâng";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnLamMoiDuLieu);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnTTKhachHang);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnChinhThoiGian);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnTraXe);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Khách hàng";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnXemBaoCao);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Báo cáo";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnTaoSoCoDuLieu);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Cơ sở dữ liệu";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnCongGiaoTiep);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Cấu hình";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Trợ giúp";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnGioiThieu);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnTrangChu);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Trợ giúp";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.txtTTCongGiaoTiep);
            this.ribbonStatusBar1.ItemLinks.Add(this.txtTrangThaiBanNang);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 442);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(875, 32);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // taskbarAssistant1
            // 
            this.taskbarAssistant1.OverlayIcon = ((System.Drawing.Image)(resources.GetObject("taskbarAssistant1.OverlayIcon")));
            this.taskbarAssistant1.ParentControl = this;
            this.taskbarAssistant1.ThumbnailButtons.Add(this.thumbnailButton1);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 474);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.grdDuLieu);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "IKY-Bảng điều khiển LED";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMain_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.grdDuLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDuLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private DevExpress.XtraGrid.GridControl grdDuLieu;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDuLieu;
        private DevExpress.XtraGrid.Columns.GridColumn grdCol_STT;
        private DevExpress.XtraGrid.Columns.GridColumn grdCol_TrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn grdCol_ThoiGian;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraGrid.Columns.GridColumn grdCol_QuangCao;
        private DevExpress.XtraGrid.Columns.GridColumn grdCol_KyThuatVien;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnTaoBanNang;
        private DevExpress.XtraBars.BarButtonItem btnXoaBanNang;
        private DevExpress.XtraBars.BarButtonItem btnTTBanNang;
        private DevExpress.XtraBars.BarButtonItem btnGioiThieu;
        private DevExpress.XtraBars.BarButtonItem btnTrangChu;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnLamMoiDuLieu;
        private DevExpress.XtraBars.BarButtonItem btnTTKhachHang;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnTaoSoCoDuLieu;
        private DevExpress.XtraBars.BarButtonItem btnXemBaoCao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnCongGiaoTiep;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarButtonItem btnChinhThoiGian;
        private DevExpress.XtraBars.BarButtonItem btnTraXe;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarStaticItem txtTTCongGiaoTiep;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarStaticItem txtTrangThaiBanNang;
        private DevExpress.XtraGrid.Columns.GridColumn grdCol_KhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn grdCol_BSX;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private DevExpress.Utils.Taskbar.TaskbarAssistant taskbarAssistant1;
        private DevExpress.Utils.Taskbar.ThumbnailButton thumbnailButton1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}



