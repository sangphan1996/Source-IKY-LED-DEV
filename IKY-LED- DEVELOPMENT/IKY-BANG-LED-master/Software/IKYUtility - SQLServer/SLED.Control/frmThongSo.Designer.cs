namespace IKY.Control
{
    partial class frmThongSo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongSo));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCongCOM = new DevExpress.XtraEditors.TextEdit();
            this.txtTenCTY = new DevExpress.XtraEditors.TextEdit();
            this.txtCauChao = new DevExpress.XtraEditors.TextEdit();
            this.txtThoiGianTBTX = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).BeginInit();
            this.groupControlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCongCOM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenCTY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCauChao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGianTBTX.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControlBase.Controls.Add(this.txtCongCOM);
            this.groupControlBase.Controls.Add(this.txtThoiGianTBTX);
            this.groupControlBase.Controls.Add(this.labelControl1);
            this.groupControlBase.Controls.Add(this.txtCauChao);
            this.groupControlBase.Controls.Add(this.labelControl2);
            this.groupControlBase.Controls.Add(this.txtTenCTY);
            this.groupControlBase.Controls.Add(this.labelControl3);
            this.groupControlBase.Controls.Add(this.labelControl4);
            this.groupControlBase.Size = new System.Drawing.Size(393, 135);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Cổng COM";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Tên CTY";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 79);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Câu chào";
            // 
            // txtCongCOM
            // 
            this.txtCongCOM.Location = new System.Drawing.Point(97, 24);
            this.txtCongCOM.Name = "txtCongCOM";
            this.txtCongCOM.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCongCOM.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtCongCOM.Properties.MaxLength = 10;
            this.txtCongCOM.Size = new System.Drawing.Size(291, 20);
            this.txtCongCOM.TabIndex = 0;
            // 
            // txtTenCTY
            // 
            this.txtTenCTY.Location = new System.Drawing.Point(97, 50);
            this.txtTenCTY.Name = "txtTenCTY";
            this.txtTenCTY.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTenCTY.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtTenCTY.Size = new System.Drawing.Size(291, 20);
            this.txtTenCTY.TabIndex = 1;
            // 
            // txtCauChao
            // 
            this.txtCauChao.Location = new System.Drawing.Point(97, 76);
            this.txtCauChao.Name = "txtCauChao";
            this.txtCauChao.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCauChao.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtCauChao.Size = new System.Drawing.Size(291, 20);
            this.txtCauChao.TabIndex = 2;
            // 
            // txtThoiGianTBTX
            // 
            this.txtThoiGianTBTX.Location = new System.Drawing.Point(97, 102);
            this.txtThoiGianTBTX.Name = "txtThoiGianTBTX";
            this.txtThoiGianTBTX.Properties.Appearance.Options.UseTextOptions = true;
            this.txtThoiGianTBTX.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtThoiGianTBTX.Properties.Mask.EditMask = "d";
            this.txtThoiGianTBTX.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtThoiGianTBTX.Properties.NullText = "30";
            this.txtThoiGianTBTX.Size = new System.Drawing.Size(291, 20);
            this.txtThoiGianTBTX.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 105);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Thời gian TBTX";
            // 
            // frmThongSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 135);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cài đặt thông số";
            this.Load += new System.EventHandler(this.frmThongSo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThongSo_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmThongSo_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).EndInit();
            this.groupControlBase.ResumeLayout(false);
            this.groupControlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCongCOM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenCTY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCauChao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGianTBTX.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCongCOM;
        private DevExpress.XtraEditors.TextEdit txtTenCTY;
        private DevExpress.XtraEditors.TextEdit txtCauChao;
        private DevExpress.XtraEditors.TextEdit txtThoiGianTBTX;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}