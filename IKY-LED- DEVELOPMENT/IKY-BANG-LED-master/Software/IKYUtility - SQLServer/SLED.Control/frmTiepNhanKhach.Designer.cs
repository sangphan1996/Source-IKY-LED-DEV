namespace IKY.Control
{
    partial class frmTiepNhanKhach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTiepNhanKhach));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.txtBienSoXe = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtGhiChu = new System.Windows.Forms.RichTextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnBoQua = new DevExpress.XtraNavBar.NavBarItem();
            this.btnDongY = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBienSoXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Họ tên";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Biển số xe";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(102, 30);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Properties.Appearance.Options.UseTextOptions = true;
            this.txtHoTen.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtHoTen.Size = new System.Drawing.Size(159, 20);
            this.txtHoTen.TabIndex = 1;
            // 
            // txtBienSoXe
            // 
            this.txtBienSoXe.Location = new System.Drawing.Point(102, 56);
            this.txtBienSoXe.Name = "txtBienSoXe";
            this.txtBienSoXe.Properties.Appearance.Options.UseTextOptions = true;
            this.txtBienSoXe.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtBienSoXe.Size = new System.Drawing.Size(159, 20);
            this.txtBienSoXe.TabIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtGhiChu);
            this.groupControl1.Controls.Add(this.txtBienSoXe);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtHoTen);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(140, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(273, 186);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Thông tin khách hàng";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(102, 82);
            this.txtGhiChu.MaxLength = 500;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(159, 96);
            this.txtGhiChu.TabIndex = 6;
            this.txtGhiChu.Text = "";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 85);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(90, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Nội dung sửa chữa";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnBoQua,
            this.btnDongY});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 140;
            this.navBarControl1.Size = new System.Drawing.Size(140, 186);
            this.navBarControl1.TabIndex = 7;
            this.navBarControl1.Text = "navBarControl1";
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
            // frmTiepNhanKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 186);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.navBarControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTiepNhanKhach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tiếp nhận khách";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTiepNhanKhach_FormClosing);
            this.Load += new System.EventHandler(this.frmTiepNhanKhach_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTiepNhanKhach_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmTiepNhanKhach_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBienSoXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraEditors.TextEdit txtBienSoXe;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem btnBoQua;
        private DevExpress.XtraNavBar.NavBarItem btnDongY;
        private System.Windows.Forms.RichTextBox txtGhiChu;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}