namespace IKY.Display
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdBanNang = new DevExpress.XtraGrid.GridControl();
            this.grvBanNang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvBanNangCol_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvBanNangCol_BanNang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvBanNangCol_TGBatDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvBanNangCol_TGSuaChua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvBanNangCol_TGConLai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdKhachHang = new DevExpress.XtraGrid.GridControl();
            this.grvKhachHang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvKhachHangCol_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvKhachHangCol_ThoiGian = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblThongBaoTraXe1 = new System.Windows.Forms.Label();
            this.tmrLabelEffect = new System.Windows.Forms.Timer();
            this.lblTenCty = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblThongBaoTraXe = new DevExpress.XtraEditors.LabelControl();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBanNang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBanNang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKhachHang)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.grdBanNang, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grdKhachHang, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 434F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1271, 434);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grdBanNang
            // 
            this.grdBanNang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grdBanNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBanNang.Location = new System.Drawing.Point(0, 0);
            this.grdBanNang.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.grdBanNang.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdBanNang.MainView = this.grvBanNang;
            this.grdBanNang.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.grdBanNang.Name = "grdBanNang";
            this.grdBanNang.Size = new System.Drawing.Size(816, 434);
            this.grdBanNang.TabIndex = 0;
            this.grdBanNang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBanNang});
            // 
            // grvBanNang
            // 
            this.grvBanNang.Appearance.Empty.BackColor = System.Drawing.SystemColors.InfoText;
            this.grvBanNang.Appearance.Empty.Options.UseBackColor = true;
            this.grvBanNang.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.InfoText;
            this.grvBanNang.Appearance.FocusedCell.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grvBanNang.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBanNang.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBanNang.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.InfoText;
            this.grvBanNang.Appearance.FocusedRow.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grvBanNang.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBanNang.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBanNang.Appearance.GroupPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBanNang.Appearance.GroupPanel.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold);
            this.grvBanNang.Appearance.GroupPanel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grvBanNang.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBanNang.Appearance.GroupPanel.Options.UseFont = true;
            this.grvBanNang.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvBanNang.Appearance.HeaderPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBanNang.Appearance.HeaderPanel.BackColor2 = System.Drawing.SystemColors.Highlight;
            this.grvBanNang.Appearance.HeaderPanel.BorderColor = System.Drawing.SystemColors.Highlight;
            this.grvBanNang.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 21F, System.Drawing.FontStyle.Bold);
            this.grvBanNang.Appearance.HeaderPanel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grvBanNang.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBanNang.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBanNang.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBanNang.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvBanNang.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvBanNang.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvBanNang.Appearance.Row.BackColor = System.Drawing.Color.Navy;
            this.grvBanNang.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 27.75F);
            this.grvBanNang.Appearance.Row.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grvBanNang.Appearance.Row.Options.UseBackColor = true;
            this.grvBanNang.Appearance.Row.Options.UseFont = true;
            this.grvBanNang.Appearance.Row.Options.UseForeColor = true;
            this.grvBanNang.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.grvBanNang.ColumnPanelRowHeight = 2;
            this.grvBanNang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grvBanNangCol_STT,
            this.grvBanNangCol_BanNang,
            this.gridColumn7,
            this.gridColumn13,
            this.grvBanNangCol_TGBatDau,
            this.gridColumn8,
            this.gridColumn9,
            this.grvBanNangCol_TGSuaChua,
            this.grvBanNangCol_TGConLai});
            this.grvBanNang.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBanNang.GridControl = this.grdBanNang;
            this.grvBanNang.GroupPanelText = "DANH SÁCH BÀN NÂNG ĐANG HOẠT ĐỘNG";
            this.grvBanNang.Name = "grvBanNang";
            this.grvBanNang.OptionsBehavior.Editable = false;
            this.grvBanNang.OptionsBehavior.ReadOnly = true;
            this.grvBanNang.OptionsCustomization.AllowFilter = false;
            this.grvBanNang.OptionsCustomization.AllowGroup = false;
            this.grvBanNang.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvBanNang.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvBanNang.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grvBanNang.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvBanNang.OptionsView.ShowIndicator = false;
            this.grvBanNang.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvBanNang.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvBanNang_RowStyle);
            this.grvBanNang.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.grvBanNang_CustomColumnDisplayText);
            // 
            // grvBanNangCol_STT
            // 
            this.grvBanNangCol_STT.Caption = "STT";
            this.grvBanNangCol_STT.Name = "grvBanNangCol_STT";
            this.grvBanNangCol_STT.Width = 34;
            // 
            // grvBanNangCol_BanNang
            // 
            this.grvBanNangCol_BanNang.AppearanceCell.Options.UseTextOptions = true;
            this.grvBanNangCol_BanNang.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvBanNangCol_BanNang.AppearanceHeader.Options.UseTextOptions = true;
            this.grvBanNangCol_BanNang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvBanNangCol_BanNang.Caption = "BÀN NÂNG";
            this.grvBanNangCol_BanNang.FieldName = "maql";
            this.grvBanNangCol_BanNang.Name = "grvBanNangCol_BanNang";
            this.grvBanNangCol_BanNang.Visible = true;
            this.grvBanNangCol_BanNang.VisibleIndex = 0;
            this.grvBanNangCol_BanNang.Width = 182;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn7.Caption = "KỸ THUẬT VIÊN";
            this.gridColumn7.FieldName = "kythuatvien";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 342;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.ForeColor = System.Drawing.Color.Lime;
            this.gridColumn13.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn13.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn13.Caption = "TRẠNG THÁI";
            this.gridColumn13.FieldName = "trangthaibn";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            this.gridColumn13.Width = 239;
            // 
            // grvBanNangCol_TGBatDau
            // 
            this.grvBanNangCol_TGBatDau.AppearanceCell.Options.UseTextOptions = true;
            this.grvBanNangCol_TGBatDau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvBanNangCol_TGBatDau.AppearanceHeader.Options.UseTextOptions = true;
            this.grvBanNangCol_TGBatDau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvBanNangCol_TGBatDau.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvBanNangCol_TGBatDau.Caption = "TG BẮT ĐẦU";
            this.grvBanNangCol_TGBatDau.DisplayFormat.FormatString = "HH:MM";
            this.grvBanNangCol_TGBatDau.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grvBanNangCol_TGBatDau.FieldName = "thoigianbd";
            this.grvBanNangCol_TGBatDau.Name = "grvBanNangCol_TGBatDau";
            this.grvBanNangCol_TGBatDau.Visible = true;
            this.grvBanNangCol_TGBatDau.VisibleIndex = 3;
            this.grvBanNangCol_TGBatDau.Width = 216;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "KHÁCH HÀNG";
            this.gridColumn8.FieldName = "hoten";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 254;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.ForeColor = System.Drawing.Color.Yellow;
            this.gridColumn9.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "BIỂN SỐ XE";
            this.gridColumn9.FieldName = "biensoxe";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 272;
            // 
            // grvBanNangCol_TGSuaChua
            // 
            this.grvBanNangCol_TGSuaChua.AppearanceCell.Options.UseTextOptions = true;
            this.grvBanNangCol_TGSuaChua.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvBanNangCol_TGSuaChua.AppearanceHeader.Options.UseTextOptions = true;
            this.grvBanNangCol_TGSuaChua.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvBanNangCol_TGSuaChua.Caption = "TG SỬA";
            this.grvBanNangCol_TGSuaChua.FieldName = "tongthoigian";
            this.grvBanNangCol_TGSuaChua.Name = "grvBanNangCol_TGSuaChua";
            this.grvBanNangCol_TGSuaChua.Visible = true;
            this.grvBanNangCol_TGSuaChua.VisibleIndex = 5;
            this.grvBanNangCol_TGSuaChua.Width = 180;
            // 
            // grvBanNangCol_TGConLai
            // 
            this.grvBanNangCol_TGConLai.AppearanceCell.ForeColor = System.Drawing.Color.Lime;
            this.grvBanNangCol_TGConLai.AppearanceCell.Options.UseForeColor = true;
            this.grvBanNangCol_TGConLai.AppearanceCell.Options.UseTextOptions = true;
            this.grvBanNangCol_TGConLai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvBanNangCol_TGConLai.AppearanceHeader.Options.UseTextOptions = true;
            this.grvBanNangCol_TGConLai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvBanNangCol_TGConLai.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvBanNangCol_TGConLai.Caption = "TG CÒN LẠI";
            this.grvBanNangCol_TGConLai.FieldName = "thoigianconlai";
            this.grvBanNangCol_TGConLai.Name = "grvBanNangCol_TGConLai";
            this.grvBanNangCol_TGConLai.Visible = true;
            this.grvBanNangCol_TGConLai.VisibleIndex = 6;
            this.grvBanNangCol_TGConLai.Width = 181;
            // 
            // grdKhachHang
            // 
            this.grdKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKhachHang.Location = new System.Drawing.Point(836, 0);
            this.grdKhachHang.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.grdKhachHang.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdKhachHang.MainView = this.grvKhachHang;
            this.grdKhachHang.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.grdKhachHang.Name = "grdKhachHang";
            this.grdKhachHang.Size = new System.Drawing.Size(435, 434);
            this.grdKhachHang.TabIndex = 1;
            this.grdKhachHang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKhachHang});
            // 
            // grvKhachHang
            // 
            this.grvKhachHang.Appearance.Empty.BackColor = System.Drawing.SystemColors.InfoText;
            this.grvKhachHang.Appearance.Empty.Options.UseBackColor = true;
            this.grvKhachHang.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.InfoText;
            this.grvKhachHang.Appearance.FocusedCell.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grvKhachHang.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKhachHang.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKhachHang.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.InfoText;
            this.grvKhachHang.Appearance.FocusedRow.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grvKhachHang.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKhachHang.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKhachHang.Appearance.GroupPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKhachHang.Appearance.GroupPanel.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold);
            this.grvKhachHang.Appearance.GroupPanel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grvKhachHang.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKhachHang.Appearance.GroupPanel.Options.UseFont = true;
            this.grvKhachHang.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvKhachHang.Appearance.HeaderPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKhachHang.Appearance.HeaderPanel.BackColor2 = System.Drawing.SystemColors.Highlight;
            this.grvKhachHang.Appearance.HeaderPanel.BorderColor = System.Drawing.SystemColors.Highlight;
            this.grvKhachHang.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 24F);
            this.grvKhachHang.Appearance.HeaderPanel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grvKhachHang.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKhachHang.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKhachHang.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKhachHang.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvKhachHang.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvKhachHang.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvKhachHang.Appearance.Row.BackColor = System.Drawing.SystemColors.InfoText;
            this.grvKhachHang.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 27.75F);
            this.grvKhachHang.Appearance.Row.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grvKhachHang.Appearance.Row.Options.UseBackColor = true;
            this.grvKhachHang.Appearance.Row.Options.UseFont = true;
            this.grvKhachHang.Appearance.Row.Options.UseForeColor = true;
            this.grvKhachHang.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.grvKhachHang.ColumnPanelRowHeight = 2;
            this.grvKhachHang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grvKhachHangCol_STT,
            this.gridColumn2,
            this.gridColumn3,
            this.grvKhachHangCol_ThoiGian});
            this.grvKhachHang.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKhachHang.GridControl = this.grdKhachHang;
            this.grvKhachHang.GroupPanelText = "DANH SÁCH KH ĐÃ TIẾP NHẬN";
            this.grvKhachHang.Name = "grvKhachHang";
            this.grvKhachHang.OptionsBehavior.Editable = false;
            this.grvKhachHang.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvKhachHang.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvKhachHang.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grvKhachHang.OptionsSelection.UseIndicatorForSelection = false;
            this.grvKhachHang.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvKhachHang.OptionsView.ShowIndicator = false;
            this.grvKhachHang.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvKhachHang_RowStyle);
            // 
            // grvKhachHangCol_STT
            // 
            this.grvKhachHangCol_STT.Caption = "gridColumn1";
            this.grvKhachHangCol_STT.Name = "grvKhachHangCol_STT";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "KHÁCH HÀNG";
            this.gridColumn2.FieldName = "hoten";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 699;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.ForeColor = System.Drawing.Color.Yellow;
            this.gridColumn3.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "BIỂN SỐ XE";
            this.gridColumn3.FieldName = "biensoxe";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 627;
            // 
            // grvKhachHangCol_ThoiGian
            // 
            this.grvKhachHangCol_ThoiGian.AppearanceCell.Options.UseTextOptions = true;
            this.grvKhachHangCol_ThoiGian.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvKhachHangCol_ThoiGian.AppearanceHeader.Options.UseTextOptions = true;
            this.grvKhachHangCol_ThoiGian.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvKhachHangCol_ThoiGian.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvKhachHangCol_ThoiGian.Caption = "THỜI GIAN";
            this.grvKhachHangCol_ThoiGian.DisplayFormat.FormatString = "HH:MM";
            this.grvKhachHangCol_ThoiGian.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grvKhachHangCol_ThoiGian.FieldName = "ngayud";
            this.grvKhachHangCol_ThoiGian.Name = "grvKhachHangCol_ThoiGian";
            this.grvKhachHangCol_ThoiGian.Visible = true;
            this.grvKhachHangCol_ThoiGian.VisibleIndex = 2;
            this.grvKhachHangCol_ThoiGian.Width = 286;
            // 
            // lblThongBaoTraXe1
            // 
            this.lblThongBaoTraXe1.AutoSize = true;
            this.lblThongBaoTraXe1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBaoTraXe1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblThongBaoTraXe1.Location = new System.Drawing.Point(836, 14);
            this.lblThongBaoTraXe1.Name = "lblThongBaoTraXe1";
            this.lblThongBaoTraXe1.Size = new System.Drawing.Size(126, 36);
            this.lblThongBaoTraXe1.TabIndex = 2;
            this.lblThongBaoTraXe1.Text = "IKY.VN";
            this.lblThongBaoTraXe1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblThongBaoTraXe1.Visible = false;
            // 
            // tmrLabelEffect
            // 
            this.tmrLabelEffect.Enabled = true;
            this.tmrLabelEffect.Tick += new System.EventHandler(this.tmrLabelEffect_Tick);
            // 
            // lblTenCty
            // 
            this.lblTenCty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTenCty.AutoSize = true;
            this.lblTenCty.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenCty.ForeColor = System.Drawing.Color.Red;
            this.lblTenCty.Location = new System.Drawing.Point(3, 23);
            this.lblTenCty.Name = "lblTenCty";
            this.lblTenCty.Size = new System.Drawing.Size(1307, 55);
            this.lblTenCty.TabIndex = 4;
            this.lblTenCty.Text = "TIEN ICH THONG MINH JOINT STOCK COMPANY (iKY)";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Green;
            this.lblDate.Location = new System.Drawing.Point(1016, 56);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(247, 31);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Chủ nhật dd/mm/yy";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Blue;
            this.lblTime.Location = new System.Drawing.Point(1068, 20);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(151, 36);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "hh:mm:ss";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.lblThongBaoTraXe);
            this.panelFooter.Controls.Add(this.lblThongBaoTraXe1);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 536);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(0);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1271, 65);
            this.panelFooter.TabIndex = 6;
            // 
            // lblThongBaoTraXe
            // 
            this.lblThongBaoTraXe.AllowHtmlString = true;
            this.lblThongBaoTraXe.Appearance.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBaoTraXe.Appearance.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblThongBaoTraXe.Location = new System.Drawing.Point(957, 14);
            this.lblThongBaoTraXe.Name = "lblThongBaoTraXe";
            this.lblThongBaoTraXe.Size = new System.Drawing.Size(60, 36);
            this.lblThongBaoTraXe.TabIndex = 3;
            this.lblThongBaoTraXe.Text = "IKY";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblTime);
            this.panelHeader.Controls.Add(this.lblTenCty);
            this.panelHeader.Controls.Add(this.lblDate);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1271, 102);
            this.panelHeader.TabIndex = 7;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1271, 601);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelFooter);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng hiển thị thông tin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMain_KeyPress);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDoubleClick);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBanNang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBanNang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKhachHang)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdBanNang;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBanNang;
        private DevExpress.XtraGrid.Columns.GridColumn grvBanNangCol_STT;
        private DevExpress.XtraGrid.Columns.GridColumn grvBanNangCol_BanNang;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn grvBanNangCol_TGBatDau;
        private DevExpress.XtraGrid.Columns.GridColumn grvBanNangCol_TGSuaChua;
        private DevExpress.XtraGrid.Columns.GridColumn grvBanNangCol_TGConLai;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private System.Windows.Forms.Label lblThongBaoTraXe1;
        private System.Windows.Forms.Timer tmrLabelEffect;
        private System.Windows.Forms.Label lblTenCty;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraGrid.GridControl grdKhachHang;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn grvKhachHangCol_STT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn grvKhachHangCol_ThoiGian;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelHeader;
        private DevExpress.XtraEditors.LabelControl lblThongBaoTraXe;
    }
}

