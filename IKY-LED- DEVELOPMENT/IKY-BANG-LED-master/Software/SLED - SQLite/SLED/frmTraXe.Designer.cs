namespace SLED
{
    partial class frmTraXe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraXe));
            this.txtNoiDung = new DevExpress.XtraEditors.TextEdit();
            this.txtKhachHang = new DevExpress.XtraEditors.TextEdit();
            this.txtBSX = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnDongY = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKhachHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBSX.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(12, 62);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Properties.MaxLength = 30;
            this.txtNoiDung.Size = new System.Drawing.Size(234, 20);
            this.txtNoiDung.TabIndex = 2;
            // 
            // txtKhachHang
            // 
            this.txtKhachHang.Enabled = false;
            this.txtKhachHang.Location = new System.Drawing.Point(12, 29);
            this.txtKhachHang.Name = "txtKhachHang";
            this.txtKhachHang.Size = new System.Drawing.Size(234, 20);
            this.txtKhachHang.TabIndex = 4;
            // 
            // txtBSX
            // 
            this.txtBSX.Enabled = false;
            this.txtBSX.Location = new System.Drawing.Point(255, 29);
            this.txtBSX.Name = "txtBSX";
            this.txtBSX.Size = new System.Drawing.Size(75, 20);
            this.txtBSX.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Khách hàng";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(255, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Biển số xe";
            // 
            // btnDongY
            // 
            this.btnDongY.Image = ((System.Drawing.Image)(resources.GetObject("btnDongY.Image")));
            this.btnDongY.Location = new System.Drawing.Point(255, 60);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 23);
            this.btnDongY.TabIndex = 3;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // frmTraXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 91);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtBSX);
            this.Controls.Add(this.txtKhachHang);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.txtNoiDung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTraXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin trả xe";
            this.Load += new System.EventHandler(this.frmTraXe_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmTraXe_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKhachHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBSX.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNoiDung;
        private DevExpress.XtraEditors.SimpleButton btnDongY;
        private DevExpress.XtraEditors.TextEdit txtKhachHang;
        private DevExpress.XtraEditors.TextEdit txtBSX;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;

    }
}