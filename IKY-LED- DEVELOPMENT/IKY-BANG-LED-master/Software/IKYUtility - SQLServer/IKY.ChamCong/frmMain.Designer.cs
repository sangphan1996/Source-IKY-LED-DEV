namespace IKY.ChamCong
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
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnSua = new DevExpress.XtraNavBar.NavBarItem();
            this.btnLuu = new DevExpress.XtraNavBar.NavBarItem();
            this.btnChayLai = new DevExpress.XtraNavBar.NavBarItem();
            this.chkRun = new DevExpress.XtraEditors.CheckEdit();
            this.txtCongCOM = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCongCOM.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnSua,
            this.btnLuu,
            this.btnChayLai});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 101;
            this.navBarControl1.Size = new System.Drawing.Size(101, 232);
            this.navBarControl1.TabIndex = 2;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Tùy chỉnh";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnSua),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnLuu),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnChayLai)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSua.LargeImage")));
            this.btnSua.Name = "btnSua";
            this.btnSua.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnSua_LinkClicked);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLuu.LargeImage")));
            this.btnLuu.Name = "btnLuu";
            // 
            // btnChayLai
            // 
            this.btnChayLai.Caption = "Chạy lại";
            this.btnChayLai.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChayLai.LargeImage")));
            this.btnChayLai.Name = "btnChayLai";
            // 
            // chkRun
            // 
            this.chkRun.Location = new System.Drawing.Point(114, 35);
            this.chkRun.Name = "chkRun";
            this.chkRun.Properties.Caption = "Khởi động cùng Windows";
            this.chkRun.Size = new System.Drawing.Size(174, 19);
            this.chkRun.TabIndex = 3;
            // 
            // txtCongCOM
            // 
            this.txtCongCOM.Location = new System.Drawing.Point(116, 9);
            this.txtCongCOM.Name = "txtCongCOM";
            this.txtCongCOM.Properties.NullText = "Cổng COM";
            this.txtCongCOM.Size = new System.Drawing.Size(172, 20);
            this.txtCongCOM.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 232);
            this.Controls.Add(this.txtCongCOM);
            this.Controls.Add(this.chkRun);
            this.Controls.Add(this.navBarControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hiển thị";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCongCOM.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem btnLuu;
        private DevExpress.XtraNavBar.NavBarItem btnSua;
        private DevExpress.XtraNavBar.NavBarItem btnChayLai;
        private DevExpress.XtraEditors.CheckEdit chkRun;
        private DevExpress.XtraEditors.TextEdit txtCongCOM;
    }
}

