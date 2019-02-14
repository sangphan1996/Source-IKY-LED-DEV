namespace IKY.Control
{
    partial class frmBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBase));
            this.groupControlBase = new DevExpress.XtraEditors.GroupControl();
            this.navBarControlBase = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnBoQua = new DevExpress.XtraNavBar.NavBarItem();
            this.btnDongY = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlBase)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlBase
            // 
            this.groupControlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlBase.Location = new System.Drawing.Point(117, 0);
            this.groupControlBase.Name = "groupControlBase";
            this.groupControlBase.Size = new System.Drawing.Size(220, 180);
            this.groupControlBase.TabIndex = 0;
            this.groupControlBase.Text = "Thông tin";
            // 
            // navBarControlBase
            // 
            this.navBarControlBase.ActiveGroup = this.navBarGroup1;
            this.navBarControlBase.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControlBase.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControlBase.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnBoQua,
            this.btnDongY});
            this.navBarControlBase.Location = new System.Drawing.Point(0, 0);
            this.navBarControlBase.Name = "navBarControlBase";
            this.navBarControlBase.OptionsNavPane.ExpandedWidth = 117;
            this.navBarControlBase.Size = new System.Drawing.Size(117, 180);
            this.navBarControlBase.TabIndex = 1;
            this.navBarControlBase.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Chức năng";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnBoQua),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnDongY)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // btnBoQua
            // 
            this.btnBoQua.Caption = "Bỏ qua";
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnBoQua.SmallImage")));
            this.btnBoQua.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnBoQua_LinkClicked);
            // 
            // btnDongY
            // 
            this.btnDongY.Caption = "Đồng ý";
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDongY.SmallImage")));
            this.btnDongY.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnDongY_LinkClicked);
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 180);
            this.Controls.Add(this.groupControlBase);
            this.Controls.Add(this.navBarControlBase);
            this.KeyPreview = true;
            this.Name = "frmBase";
            this.Text = "frmBase";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBase_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmBase_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.GroupControl groupControlBase;
        public DevExpress.XtraNavBar.NavBarControl navBarControlBase;
        public DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        public DevExpress.XtraNavBar.NavBarItem btnBoQua;
        public DevExpress.XtraNavBar.NavBarItem btnDongY;
    }
}