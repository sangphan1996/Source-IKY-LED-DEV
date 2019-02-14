namespace IKY.Control
{
    partial class frmSuaThongTinKH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuaThongTinKH));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtBanNang = new DevExpress.XtraEditors.TextEdit();
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.txtBienSoXe = new DevExpress.XtraEditors.TextEdit();
            this.txtThoiGian = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).BeginInit();
            this.groupControlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBanNang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBienSoXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGian.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControlBase.Controls.Add(this.labelControl1);
            this.groupControlBase.Controls.Add(this.labelControl2);
            this.groupControlBase.Controls.Add(this.labelControl3);
            this.groupControlBase.Controls.Add(this.labelControl4);
            this.groupControlBase.Controls.Add(this.txtBanNang);
            this.groupControlBase.Controls.Add(this.txtHoTen);
            this.groupControlBase.Controls.Add(this.txtBienSoXe);
            this.groupControlBase.Controls.Add(this.txtThoiGian);
            this.groupControlBase.Size = new System.Drawing.Size(252, 131);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Bàn nâng";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Họ tên";
            // 
            // txtBanNang
            // 
            this.txtBanNang.Location = new System.Drawing.Point(81, 24);
            this.txtBanNang.Name = "txtBanNang";
            this.txtBanNang.Properties.ReadOnly = true;
            this.txtBanNang.Size = new System.Drawing.Size(150, 20);
            this.txtBanNang.TabIndex = 0;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(81, 50);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(150, 20);
            this.txtHoTen.TabIndex = 1;
            // 
            // txtBienSoXe
            // 
            this.txtBienSoXe.Location = new System.Drawing.Point(81, 76);
            this.txtBienSoXe.Name = "txtBienSoXe";
            this.txtBienSoXe.Size = new System.Drawing.Size(150, 20);
            this.txtBienSoXe.TabIndex = 2;
            // 
            // txtThoiGian
            // 
            this.txtThoiGian.Location = new System.Drawing.Point(81, 102);
            this.txtThoiGian.Name = "txtThoiGian";
            this.txtThoiGian.Properties.ReadOnly = true;
            this.txtThoiGian.Size = new System.Drawing.Size(150, 20);
            this.txtThoiGian.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 79);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Biển số xe";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 105);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Thời gian";
            // 
            // frmSuaThongTinKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 131);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSuaThongTinKH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sửa thông tin KH";
            this.Load += new System.EventHandler(this.frmSuaThongTinKH_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSuaThongTinKH_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).EndInit();
            this.groupControlBase.ResumeLayout(false);
            this.groupControlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBanNang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBienSoXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGian.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtBanNang;
        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraEditors.TextEdit txtBienSoXe;
        private DevExpress.XtraEditors.TextEdit txtThoiGian;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}