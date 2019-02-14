namespace IKY.Control
{
    partial class frmChinhThoiGian
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChinhThoiGian));            
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtThoiGianThayDoi = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).BeginInit();
            this.groupControlBase.SuspendLayout();            
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGianThayDoi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlBase
            // 
            this.groupControlBase.Controls.Add(this.txtThoiGianThayDoi);
            this.groupControlBase.Controls.Add(this.labelControl1);
            this.groupControlBase.Size = new System.Drawing.Size(170, 100);            
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 52);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(77, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Thời gian(Phút):";
            // 
            // txtThoiGianThayDoi
            // 
            this.txtThoiGianThayDoi.Location = new System.Drawing.Point(94, 49);
            this.txtThoiGianThayDoi.Name = "txtThoiGianThayDoi";
            this.txtThoiGianThayDoi.Properties.Appearance.Options.UseTextOptions = true;
            this.txtThoiGianThayDoi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtThoiGianThayDoi.Properties.Mask.EditMask = "d";
            this.txtThoiGianThayDoi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtThoiGianThayDoi.Properties.NullText = "0";
            this.txtThoiGianThayDoi.Size = new System.Drawing.Size(66, 20);
            this.txtThoiGianThayDoi.TabIndex = 3;
            // 
            // frmChinhThoiGian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 100);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChinhThoiGian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chỉnh thời gian";
            this.Load += new System.EventHandler(this.frmChinhThoiGian_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmChinhThoiGian_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).EndInit();
            this.groupControlBase.ResumeLayout(false);
            this.groupControlBase.PerformLayout();            
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGianThayDoi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtThoiGianThayDoi;
    }
}