namespace IKY.CallServer
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.chkRun = new DevExpress.XtraEditors.CheckEdit();
            this.chkGoiTenKH = new DevExpress.XtraEditors.CheckEdit();
            this.chkGoiKH = new DevExpress.XtraEditors.CheckEdit();
            this.notifyIconApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.tmrThongBao = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGoiTenKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGoiKH.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.btnLuu);
            this.groupControl1.Controls.Add(this.chkRun);
            this.groupControl1.Controls.Add(this.chkGoiTenKH);
            this.groupControl1.Controls.Add(this.chkGoiKH);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(212, 133);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Cấu hình";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(111, 105);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Thoát";
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Location = new System.Drawing.Point(30, 105);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // chkRun
            // 
            this.chkRun.Location = new System.Drawing.Point(5, 74);
            this.chkRun.Name = "chkRun";
            this.chkRun.Properties.Caption = "Khởi động cùng Windows";
            this.chkRun.Size = new System.Drawing.Size(181, 19);
            this.chkRun.TabIndex = 1;
            // 
            // chkGoiTenKH
            // 
            this.chkGoiTenKH.Enabled = false;
            this.chkGoiTenKH.Location = new System.Drawing.Point(5, 49);
            this.chkGoiTenKH.Name = "chkGoiTenKH";
            this.chkGoiTenKH.Properties.Caption = "Gọi tên đầy đủ";
            this.chkGoiTenKH.Size = new System.Drawing.Size(121, 19);
            this.chkGoiTenKH.TabIndex = 0;
            // 
            // chkGoiKH
            // 
            this.chkGoiKH.EditValue = true;
            this.chkGoiKH.Location = new System.Drawing.Point(5, 24);
            this.chkGoiKH.Name = "chkGoiKH";
            this.chkGoiKH.Properties.Caption = "Cho phép gọi KH";
            this.chkGoiKH.Size = new System.Drawing.Size(121, 19);
            this.chkGoiKH.TabIndex = 0;
            this.chkGoiKH.CheckedChanged += new System.EventHandler(this.chkGoiKH_CheckedChanged);
            // 
            // notifyIconApp
            // 
            this.notifyIconApp.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconApp.BalloonTipTitle = "IKY CallServer";
            this.notifyIconApp.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconApp.Icon")));
            this.notifyIconApp.Text = "IKY.CallServer";
            this.notifyIconApp.DoubleClick += new System.EventHandler(this.notifyIconApp_DoubleClick);
            // 
            // tmrThongBao
            // 
            this.tmrThongBao.Enabled = true;
            this.tmrThongBao.Interval = 1000;
            this.tmrThongBao.Tick += new System.EventHandler(this.tmrThongBao_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 133);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IKY.CallServer";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkRun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGoiTenKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGoiKH.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit chkGoiKH;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.CheckEdit chkRun;
        private System.Windows.Forms.NotifyIcon notifyIconApp;
        private DevExpress.XtraEditors.CheckEdit chkGoiTenKH;
        private System.Windows.Forms.Timer tmrThongBao;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}

