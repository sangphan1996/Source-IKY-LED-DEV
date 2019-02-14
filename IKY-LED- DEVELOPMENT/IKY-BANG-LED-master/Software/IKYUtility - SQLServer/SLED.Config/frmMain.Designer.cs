namespace SLED.Config
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
            this.wchConfig = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wchTrangSled = new DevExpress.XtraWizard.WizardPage();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtDatabase = new DevExpress.XtraEditors.TextEdit();
            this.txtDatasource = new DevExpress.XtraEditors.TextEdit();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            ((System.ComponentModel.ISupportInitialize)(this.wchConfig)).BeginInit();
            this.wchConfig.SuspendLayout();
            this.wchTrangSled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatasource.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // wchConfig
            // 
            this.wchConfig.CancelText = "Bỏ qua";
            this.wchConfig.Controls.Add(this.welcomeWizardPage1);
            this.wchConfig.Controls.Add(this.wchTrangSled);
            this.wchConfig.Controls.Add(this.completionWizardPage1);
            this.wchConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wchConfig.FinishText = "&Hoàn tất";
            this.wchConfig.Location = new System.Drawing.Point(0, 0);
            this.wchConfig.Name = "wchConfig";
            this.wchConfig.NextText = "&Tiếp tục >";
            this.wchConfig.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wchTrangSled,
            this.completionWizardPage1});
            this.wchConfig.PreviousText = "< &Quay lại";
            this.wchConfig.Size = new System.Drawing.Size(448, 262);
            this.wchConfig.CancelClick += new System.ComponentModel.CancelEventHandler(this.wchConfig_CancelClick);
            this.wchConfig.FinishClick += new System.ComponentModel.CancelEventHandler(this.wchConfig_FinishClick);
            this.wchConfig.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wchConfig_NextClick);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.IntroductionText = "Chức năng này sẽ hướng dẫn bạn cấu hình thông số hệ thống kết nối đến cơ sở dữ li" +
    "ệu";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "Để sang màn hình mới, vui lòng nhấn nút Tiếp tục";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(231, 83);
            this.welcomeWizardPage1.Text = "Chào mừng đến với chương trình hướng dẫn cấu hình hệ thống";
            // 
            // wchTrangSled
            // 
            this.wchTrangSled.Controls.Add(this.labelControl4);
            this.wchTrangSled.Controls.Add(this.labelControl3);
            this.wchTrangSled.Controls.Add(this.labelControl2);
            this.wchTrangSled.Controls.Add(this.labelControl1);
            this.wchTrangSled.Controls.Add(this.txtPassword);
            this.wchTrangSled.Controls.Add(this.txtUsername);
            this.wchTrangSled.Controls.Add(this.txtDatabase);
            this.wchTrangSled.Controls.Add(this.txtDatasource);
            this.wchTrangSled.DescriptionText = "Màn hình thiết lập thông số để kết nối đến cơ sở dữ liệu của Sled";
            this.wchTrangSled.Name = "wchTrangSled";
            this.wchTrangSled.Size = new System.Drawing.Size(416, 117);
            this.wchTrangSled.Text = "Hệ thống bảng Sled";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(3, 93);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Password:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(3, 67);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Username:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Database:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Data source:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(93, 90);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(320, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(93, 64);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(320, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(93, 38);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(320, 20);
            this.txtDatabase.TabIndex = 1;
            // 
            // txtDatasource
            // 
            this.txtDatasource.Location = new System.Drawing.Point(93, 12);
            this.txtDatasource.Name = "txtDatasource";
            this.txtDatasource.Size = new System.Drawing.Size(320, 20);
            this.txtDatasource.TabIndex = 0;
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.FinishText = "Bạn đã cấu hình thành công thông số";
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "Để lưu lại và thoát khỏi màn hình, nhấn nút Hoàn tất. Muốn trở về màn hình trước," +
    " nhấn nút Quay lại. Nhẫn nút Bỏ qua sẽ không lưu lại các thông số bạn đã thiết l" +
    "ập.";
            this.completionWizardPage1.Size = new System.Drawing.Size(231, 129);
            this.completionWizardPage1.Text = "Hoàn tất cấu hình";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 262);
            this.Controls.Add(this.wchConfig);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SLED-Cấu hình";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wchConfig)).EndInit();
            this.wchConfig.ResumeLayout(false);
            this.wchTrangSled.ResumeLayout(false);
            this.wchTrangSled.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatasource.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wchConfig;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wchTrangSled;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.TextEdit txtDatasource;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtDatabase;
    }
}

