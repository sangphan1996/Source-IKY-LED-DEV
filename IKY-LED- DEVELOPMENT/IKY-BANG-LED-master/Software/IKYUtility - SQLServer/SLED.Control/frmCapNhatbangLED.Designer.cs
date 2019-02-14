namespace IKY.Control
{
    partial class frmCapNhatbangLED
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapNhatbangLED));
            this.txtNDHienThi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtKyThuatVien = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).BeginInit();
            this.groupControlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNDHienThi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKyThuatVien.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControlBase.Controls.Add(this.txtNDHienThi);
            this.groupControlBase.Controls.Add(this.labelControl2);
            this.groupControlBase.Controls.Add(this.txtKyThuatVien);
            this.groupControlBase.Controls.Add(this.labelControl1);
            this.groupControlBase.Size = new System.Drawing.Size(274, 105);
            // 
            // txtNDHienThi
            // 
            this.txtNDHienThi.Location = new System.Drawing.Point(93, 29);
            this.txtNDHienThi.Name = "txtNDHienThi";
            this.txtNDHienThi.Properties.ReadOnly = true;
            this.txtNDHienThi.Size = new System.Drawing.Size(176, 20);
            this.txtNDHienThi.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ND hiển thị";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Kỹ thuật viên";
            // 
            // txtKyThuatVien
            // 
            this.txtKyThuatVien.EnterMoveNextControl = true;
            this.txtKyThuatVien.Location = new System.Drawing.Point(93, 55);
            this.txtKyThuatVien.Name = "txtKyThuatVien";
            this.txtKyThuatVien.Properties.ReadOnly = true;
            this.txtKyThuatVien.Size = new System.Drawing.Size(176, 20);
            this.txtKyThuatVien.TabIndex = 3;
            // 
            // frmCapNhatbangLED
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 105);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCapNhatbangLED";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật bảng LED";
            this.Load += new System.EventHandler(this.frmCapNhatbangLED_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCapNhatbangLED_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).EndInit();
            this.groupControlBase.ResumeLayout(false);
            this.groupControlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNDHienThi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKyThuatVien.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNDHienThi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtKyThuatVien;
    }
}