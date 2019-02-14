namespace IKY.CauHinh
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
            this.wchConfig = new DevExpress.XtraWizard.WizardControl();
            this.wchPageWelcome = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wchPageDatabase = new DevExpress.XtraWizard.WizardPage();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.chkTaoMoi = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblHost = new DevExpress.XtraEditors.LabelControl();
            this.txtSchema = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.txtDatabase = new DevExpress.XtraEditors.TextEdit();
            this.txtDatasource = new DevExpress.XtraEditors.TextEdit();
            this.txtPort = new DevExpress.XtraEditors.TextEdit();
            this.txtHost = new DevExpress.XtraEditors.TextEdit();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wchPageDisplay = new DevExpress.XtraWizard.WizardPage();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtSoLanThongBao = new DevExpress.XtraEditors.TextEdit();
            this.txtTocDoThongBao = new DevExpress.XtraEditors.TextEdit();
            this.txtThoiGianHienThiDuLieu = new DevExpress.XtraEditors.TextEdit();
            this.txtFooter = new DevExpress.XtraEditors.TextEdit();
            this.txtHeader = new DevExpress.XtraEditors.TextEdit();
            this.txtSoDongHienThiDuLieu = new DevExpress.XtraEditors.TextEdit();
            this.colorThongTin = new DevExpress.XtraEditors.ColorEdit();
            this.colorThongBao = new DevExpress.XtraEditors.ColorEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.lblSoLan = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lblTocDo = new DevExpress.XtraEditors.LabelControl();
            this.chkAutoRun = new DevExpress.XtraEditors.CheckEdit();
            this.wchPageSetupSQL = new DevExpress.XtraWizard.WizardPage();
            this.radioGroupOS = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.wchConfig)).BeginInit();
            this.wchConfig.SuspendLayout();
            this.wchPageDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkTaoMoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchema.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatasource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).BeginInit();
            this.wchPageDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLanThongBao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTocDoThongBao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGianHienThiDuLieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFooter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeader.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDongHienThiDuLieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorThongTin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorThongBao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoRun.Properties)).BeginInit();
            this.wchPageSetupSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupOS.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // wchConfig
            // 
            this.wchConfig.CancelText = "Bỏ qua";
            this.wchConfig.Controls.Add(this.wchPageWelcome);
            this.wchConfig.Controls.Add(this.wchPageDatabase);
            this.wchConfig.Controls.Add(this.completionWizardPage1);
            this.wchConfig.Controls.Add(this.wchPageDisplay);
            this.wchConfig.Controls.Add(this.wchPageSetupSQL);
            this.wchConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wchConfig.FinishText = "&Hoàn thành";
            this.wchConfig.HelpText = "&Trợ giúp";
            this.wchConfig.Image = global::IKY.CauHinh.Properties.Resources.config;
            this.wchConfig.ImageWidth = 200;
            this.wchConfig.Location = new System.Drawing.Point(0, 0);
            this.wchConfig.Name = "wchConfig";
            this.wchConfig.NextText = "&Tiếp tục >";
            this.wchConfig.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.wchPageWelcome,
            this.wchPageSetupSQL,
            this.wchPageDatabase,
            this.wchPageDisplay,
            this.completionWizardPage1});
            this.wchConfig.PreviousText = "< &Quay Lại";
            this.wchConfig.Size = new System.Drawing.Size(455, 395);
            this.wchConfig.Text = "Cấu hình";
            this.wchConfig.CancelClick += new System.ComponentModel.CancelEventHandler(this.wchConfig_CancelClick);
            this.wchConfig.FinishClick += new System.ComponentModel.CancelEventHandler(this.wchConfig_FinishClick);
            this.wchConfig.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wchConfig_NextClick);
            // 
            // wchPageWelcome
            // 
            this.wchPageWelcome.IntroductionText = "Đậy là giao diện hướng dẫn cấu hình hệ thống đơn giản";
            this.wchPageWelcome.Name = "wchPageWelcome";
            this.wchPageWelcome.ProceedText = "Chọn Tiếp tục để sang bước tiếp theo";
            this.wchPageWelcome.Size = new System.Drawing.Size(223, 239);
            this.wchPageWelcome.Text = "Chào mừng đến với trình hướng dẫn";
            // 
            // wchPageDatabase
            // 
            this.wchPageDatabase.Controls.Add(this.labelControl13);
            this.wchPageDatabase.Controls.Add(this.chkTaoMoi);
            this.wchPageDatabase.Controls.Add(this.labelControl1);
            this.wchPageDatabase.Controls.Add(this.labelControl5);
            this.wchPageDatabase.Controls.Add(this.labelControl4);
            this.wchPageDatabase.Controls.Add(this.labelControl3);
            this.wchPageDatabase.Controls.Add(this.labelControl2);
            this.wchPageDatabase.Controls.Add(this.labelControl6);
            this.wchPageDatabase.Controls.Add(this.lblHost);
            this.wchPageDatabase.Controls.Add(this.txtSchema);
            this.wchPageDatabase.Controls.Add(this.txtPassword);
            this.wchPageDatabase.Controls.Add(this.txtUser);
            this.wchPageDatabase.Controls.Add(this.txtDatabase);
            this.wchPageDatabase.Controls.Add(this.txtDatasource);
            this.wchPageDatabase.Controls.Add(this.txtPort);
            this.wchPageDatabase.Controls.Add(this.txtHost);
            this.wchPageDatabase.DescriptionText = "Vui lòng điền đầy đủ thông tin cơ sở dữ liệu sử dụng trong hệ thống";
            this.wchPageDatabase.Name = "wchPageDatabase";
            this.wchPageDatabase.Size = new System.Drawing.Size(423, 250);
            this.wchPageDatabase.Text = "Cấu hình cơ sở dữ liệu";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(30, 188);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(41, 13);
            this.labelControl13.TabIndex = 3;
            this.labelControl13.Text = "Tạo mới:";
            // 
            // chkTaoMoi
            // 
            this.chkTaoMoi.EditValue = true;
            this.chkTaoMoi.Location = new System.Drawing.Point(110, 185);
            this.chkTaoMoi.Name = "chkTaoMoi";
            this.chkTaoMoi.Properties.Caption = "";
            this.chkTaoMoi.Size = new System.Drawing.Size(27, 19);
            this.chkTaoMoi.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 162);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Schema:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(30, 136);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(50, 13);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "Password:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(30, 110);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(26, 13);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "User:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 84);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Database:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(30, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Datasource:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(30, 32);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(24, 13);
            this.labelControl6.TabIndex = 1;
            this.labelControl6.Text = "Port:";
            // 
            // lblHost
            // 
            this.lblHost.Location = new System.Drawing.Point(30, 10);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(26, 13);
            this.lblHost.TabIndex = 1;
            this.lblHost.Text = "Host:";
            // 
            // txtSchema
            // 
            this.txtSchema.Location = new System.Drawing.Point(112, 159);
            this.txtSchema.Name = "txtSchema";
            this.txtSchema.Size = new System.Drawing.Size(214, 20);
            this.txtSchema.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(112, 133);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(214, 20);
            this.txtPassword.TabIndex = 0;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(112, 107);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(214, 20);
            this.txtUser.TabIndex = 0;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(112, 81);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(214, 20);
            this.txtDatabase.TabIndex = 0;
            // 
            // txtDatasource
            // 
            this.txtDatasource.Location = new System.Drawing.Point(112, 55);
            this.txtDatasource.Name = "txtDatasource";
            this.txtDatasource.Size = new System.Drawing.Size(214, 20);
            this.txtDatasource.TabIndex = 0;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(112, 29);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(214, 20);
            this.txtPort.TabIndex = 0;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(112, 3);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(214, 20);
            this.txtHost.TabIndex = 0;
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.FinishText = "Bạn đã cấu hình thành công";
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "Để kết thúc, chọn Hoàn thành";
            this.completionWizardPage1.Size = new System.Drawing.Size(223, 262);
            this.completionWizardPage1.Text = "Hoàn thành";
            // 
            // wchPageDisplay
            // 
            this.wchPageDisplay.Controls.Add(this.labelControl12);
            this.wchPageDisplay.Controls.Add(this.txtSoLanThongBao);
            this.wchPageDisplay.Controls.Add(this.txtTocDoThongBao);
            this.wchPageDisplay.Controls.Add(this.txtThoiGianHienThiDuLieu);
            this.wchPageDisplay.Controls.Add(this.txtFooter);
            this.wchPageDisplay.Controls.Add(this.txtHeader);
            this.wchPageDisplay.Controls.Add(this.txtSoDongHienThiDuLieu);
            this.wchPageDisplay.Controls.Add(this.colorThongTin);
            this.wchPageDisplay.Controls.Add(this.colorThongBao);
            this.wchPageDisplay.Controls.Add(this.labelControl10);
            this.wchPageDisplay.Controls.Add(this.labelControl9);
            this.wchPageDisplay.Controls.Add(this.lblSoLan);
            this.wchPageDisplay.Controls.Add(this.labelControl8);
            this.wchPageDisplay.Controls.Add(this.labelControl11);
            this.wchPageDisplay.Controls.Add(this.labelControl7);
            this.wchPageDisplay.Controls.Add(this.lblTocDo);
            this.wchPageDisplay.Controls.Add(this.chkAutoRun);
            this.wchPageDisplay.DescriptionText = "Thông số cơ bản";
            this.wchPageDisplay.Name = "wchPageDisplay";
            this.wchPageDisplay.Size = new System.Drawing.Size(423, 250);
            this.wchPageDisplay.Text = "Cài đặt chương trình IKY.Display";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(17, 38);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(36, 13);
            this.labelControl12.TabIndex = 5;
            this.labelControl12.Text = "Footer:";
            // 
            // txtSoLanThongBao
            // 
            this.txtSoLanThongBao.EditValue = "3";
            this.txtSoLanThongBao.Location = new System.Drawing.Point(166, 139);
            this.txtSoLanThongBao.Name = "txtSoLanThongBao";
            this.txtSoLanThongBao.Properties.Mask.EditMask = "d";
            this.txtSoLanThongBao.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSoLanThongBao.Properties.NullText = "0";
            this.txtSoLanThongBao.Size = new System.Drawing.Size(254, 20);
            this.txtSoLanThongBao.TabIndex = 4;
            // 
            // txtTocDoThongBao
            // 
            this.txtTocDoThongBao.EditValue = "10";
            this.txtTocDoThongBao.Location = new System.Drawing.Point(166, 113);
            this.txtTocDoThongBao.Name = "txtTocDoThongBao";
            this.txtTocDoThongBao.Properties.Mask.EditMask = "d";
            this.txtTocDoThongBao.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTocDoThongBao.Properties.NullText = "0";
            this.txtTocDoThongBao.Size = new System.Drawing.Size(254, 20);
            this.txtTocDoThongBao.TabIndex = 4;
            // 
            // txtThoiGianHienThiDuLieu
            // 
            this.txtThoiGianHienThiDuLieu.EditValue = "15";
            this.txtThoiGianHienThiDuLieu.Location = new System.Drawing.Point(166, 87);
            this.txtThoiGianHienThiDuLieu.Name = "txtThoiGianHienThiDuLieu";
            this.txtThoiGianHienThiDuLieu.Properties.Mask.EditMask = "d";
            this.txtThoiGianHienThiDuLieu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtThoiGianHienThiDuLieu.Properties.NullText = "0";
            this.txtThoiGianHienThiDuLieu.Size = new System.Drawing.Size(254, 20);
            this.txtThoiGianHienThiDuLieu.TabIndex = 4;
            // 
            // txtFooter
            // 
            this.txtFooter.EditValue = "Công ty Cổ phần Công nghệ Tiện ích Thông minh";
            this.txtFooter.Location = new System.Drawing.Point(166, 35);
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.Properties.MaxLength = 45;
            this.txtFooter.Properties.NullText = "Tiêu đề";
            this.txtFooter.Size = new System.Drawing.Size(254, 20);
            this.txtFooter.TabIndex = 4;
            // 
            // txtHeader
            // 
            this.txtHeader.EditValue = "Công ty Cổ phần Công nghệ Tiện ích Thông minh";
            this.txtHeader.Location = new System.Drawing.Point(166, 9);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Properties.MaxLength = 45;
            this.txtHeader.Properties.NullText = "Tiêu đề";
            this.txtHeader.Size = new System.Drawing.Size(254, 20);
            this.txtHeader.TabIndex = 4;
            // 
            // txtSoDongHienThiDuLieu
            // 
            this.txtSoDongHienThiDuLieu.EditValue = "15";
            this.txtSoDongHienThiDuLieu.Location = new System.Drawing.Point(166, 61);
            this.txtSoDongHienThiDuLieu.Name = "txtSoDongHienThiDuLieu";
            this.txtSoDongHienThiDuLieu.Properties.Mask.EditMask = "d";
            this.txtSoDongHienThiDuLieu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSoDongHienThiDuLieu.Properties.NullText = "0";
            this.txtSoDongHienThiDuLieu.Size = new System.Drawing.Size(254, 20);
            this.txtSoDongHienThiDuLieu.TabIndex = 4;
            // 
            // colorThongTin
            // 
            this.colorThongTin.EditValue = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colorThongTin.Location = new System.Drawing.Point(166, 197);
            this.colorThongTin.Name = "colorThongTin";
            this.colorThongTin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorThongTin.Size = new System.Drawing.Size(254, 20);
            this.colorThongTin.TabIndex = 3;
            // 
            // colorThongBao
            // 
            this.colorThongBao.EditValue = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colorThongBao.Location = new System.Drawing.Point(166, 167);
            this.colorThongBao.Name = "colorThongBao";
            this.colorThongBao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorThongBao.Size = new System.Drawing.Size(254, 20);
            this.colorThongBao.TabIndex = 3;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(15, 200);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(149, 13);
            this.labelControl10.TabIndex = 2;
            this.labelControl10.Text = "Màu chữ thông tin khách hàng:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(17, 170);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(135, 13);
            this.labelControl9.TabIndex = 2;
            this.labelControl9.Text = "Màu chữ hiển thị thông báo:";
            // 
            // lblSoLan
            // 
            this.lblSoLan.Location = new System.Drawing.Point(17, 142);
            this.lblSoLan.Name = "lblSoLan";
            this.lblSoLan.Size = new System.Drawing.Size(123, 13);
            this.lblSoLan.TabIndex = 2;
            this.lblSoLan.Text = "Số lần hiển thị thông báo:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(17, 90);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(85, 13);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "Thời gian hiển thị:";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(17, 12);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(42, 13);
            this.labelControl11.TabIndex = 2;
            this.labelControl11.Text = "Header: ";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(17, 64);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(116, 13);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Số dòng hiển thị dữ liệu:";
            // 
            // lblTocDo
            // 
            this.lblTocDo.Location = new System.Drawing.Point(17, 116);
            this.lblTocDo.Name = "lblTocDo";
            this.lblTocDo.Size = new System.Drawing.Size(133, 13);
            this.lblTocDo.TabIndex = 2;
            this.lblTocDo.Text = "Tốc độ hiệu ứng thông báo:";
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.Location = new System.Drawing.Point(15, 223);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Properties.Caption = "Khởi động cùng hệ thống";
            this.chkAutoRun.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chkAutoRun.Size = new System.Drawing.Size(168, 19);
            this.chkAutoRun.TabIndex = 0;
            this.chkAutoRun.CheckedChanged += new System.EventHandler(this.chkAutoRun_CheckedChanged);
            // 
            // wchPageSetupSQL
            // 
            this.wchPageSetupSQL.Controls.Add(this.radioGroupOS);
            this.wchPageSetupSQL.DescriptionText = "Cài đặt cơ sở dữ liệu chỉ dành cho máy chủ";
            this.wchPageSetupSQL.Name = "wchPageSetupSQL";
            this.wchPageSetupSQL.Size = new System.Drawing.Size(423, 250);
            this.wchPageSetupSQL.Text = "Cài đặt SQL Server";
            this.wchPageSetupSQL.Visible = false;
            // 
            // radioGroupOS
            // 
            this.radioGroupOS.Location = new System.Drawing.Point(3, 3);
            this.radioGroupOS.Name = "radioGroupOS";
            this.radioGroupOS.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Hệ điều hành 64-bit"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Hệ điều hành 32-bit"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Bỏ qua")});
            this.radioGroupOS.Size = new System.Drawing.Size(417, 117);
            this.radioGroupOS.TabIndex = 1;
            this.radioGroupOS.SelectedIndexChanged += new System.EventHandler(this.radioGroupOS_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 395);
            this.Controls.Add(this.wchConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wchConfig)).EndInit();
            this.wchConfig.ResumeLayout(false);
            this.wchPageDatabase.ResumeLayout(false);
            this.wchPageDatabase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkTaoMoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchema.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatasource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).EndInit();
            this.wchPageDisplay.ResumeLayout(false);
            this.wchPageDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLanThongBao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTocDoThongBao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGianHienThiDuLieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFooter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeader.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDongHienThiDuLieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorThongTin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorThongBao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoRun.Properties)).EndInit();
            this.wchPageSetupSQL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupOS.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wchConfig;
        private DevExpress.XtraWizard.WelcomeWizardPage wchPageWelcome;
        private DevExpress.XtraWizard.WizardPage wchPageDatabase;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.TextEdit txtHost;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblHost;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.TextEdit txtDatabase;
        private DevExpress.XtraEditors.TextEdit txtDatasource;
        private DevExpress.XtraEditors.TextEdit txtPort;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSchema;
        private DevExpress.XtraWizard.WizardPage wchPageDisplay;
        private DevExpress.XtraEditors.CheckEdit chkAutoRun;
        private DevExpress.XtraEditors.LabelControl lblSoLan;
        private DevExpress.XtraEditors.LabelControl lblTocDo;
        private DevExpress.XtraEditors.ColorEdit colorThongBao;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ColorEdit colorThongTin;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtSoLanThongBao;
        private DevExpress.XtraEditors.TextEdit txtTocDoThongBao;
        private DevExpress.XtraEditors.TextEdit txtSoDongHienThiDuLieu;
        private DevExpress.XtraEditors.TextEdit txtThoiGianHienThiDuLieu;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtHeader;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtFooter;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.CheckEdit chkTaoMoi;
        private DevExpress.XtraWizard.WizardPage wchPageSetupSQL;
        private DevExpress.XtraEditors.RadioGroup radioGroupOS;
    }
}

