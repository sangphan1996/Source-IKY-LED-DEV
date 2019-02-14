namespace IKY.Control
{
    partial class frmTaoBanNang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaoBanNang));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtKyThuatVien = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtNoiDungHT = new DevExpress.XtraEditors.TextEdit();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).BeginInit();
            this.groupControlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKyThuatVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDungHT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlBase
            // 
            this.groupControlBase.Controls.Add(this.txtKyThuatVien);
            this.groupControlBase.Controls.Add(this.txtNoiDungHT);
            this.groupControlBase.Controls.Add(this.labelControl1);
            this.groupControlBase.Controls.Add(this.txtID);
            this.groupControlBase.Controls.Add(this.labelControl2);
            this.groupControlBase.Controls.Add(this.labelControl3);
            this.groupControlBase.Size = new System.Drawing.Size(313, 115);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Bàn nâng";
            // 
            // txtKyThuatVien
            // 
            this.txtKyThuatVien.Location = new System.Drawing.Point(104, 53);
            this.txtKyThuatVien.Name = "txtKyThuatVien";
            this.txtKyThuatVien.Properties.Appearance.Options.UseTextOptions = true;
            this.txtKyThuatVien.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtKyThuatVien.Size = new System.Drawing.Size(197, 20);
            this.txtKyThuatVien.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Kỹ thuật viên";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 82);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Nội dung hiển thị";
            // 
            // txtNoiDungHT
            // 
            this.txtNoiDungHT.Location = new System.Drawing.Point(104, 79);
            this.txtNoiDungHT.Name = "txtNoiDungHT";
            this.txtNoiDungHT.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNoiDungHT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtNoiDungHT.Size = new System.Drawing.Size(197, 20);
            this.txtNoiDungHT.TabIndex = 2;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(104, 29);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Appearance.Options.UseTextOptions = true;
            this.txtID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtID.Properties.Mask.EditMask = "d";
            this.txtID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtID.Properties.MaxLength = 2;
            this.txtID.Size = new System.Drawing.Size(197, 20);
            this.txtID.TabIndex = 0;
            // 
            // frmTaoBanNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 115);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaoBanNang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo bàn nâng";
            this.Load += new System.EventHandler(this.frmTaoBanNang_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmTaoBanNang_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).EndInit();
            this.groupControlBase.ResumeLayout(false);
            this.groupControlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKyThuatVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDungHT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtKyThuatVien;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtNoiDungHT;
        private DevExpress.XtraEditors.TextEdit txtID;
    }
}