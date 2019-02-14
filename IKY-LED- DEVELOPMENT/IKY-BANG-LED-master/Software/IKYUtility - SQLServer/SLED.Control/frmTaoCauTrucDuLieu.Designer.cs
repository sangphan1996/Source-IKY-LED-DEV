namespace IKY.Control
{
    partial class frmTaoCauTrucDuLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaoCauTrucDuLieu));
            this.chkTaoMoi = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).BeginInit();
            this.groupControlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkTaoMoi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControlBase.Controls.Add(this.chkTaoMoi);
            this.groupControlBase.Size = new System.Drawing.Size(198, 120);
            // 
            // chkTaoMoi
            // 
            this.chkTaoMoi.Location = new System.Drawing.Point(6, 24);
            this.chkTaoMoi.Name = "chkTaoMoi";
            this.chkTaoMoi.Properties.Caption = "Tạo mới";
            this.chkTaoMoi.Size = new System.Drawing.Size(75, 19);
            this.chkTaoMoi.TabIndex = 3;
            // 
            // frmTaoCauTrucDuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 120);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaoCauTrucDuLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo cấu trúc dữ liệu";
            this.Load += new System.EventHandler(this.frmTaoCauTrucDuLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).EndInit();
            this.groupControlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkTaoMoi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private DevExpress.XtraEditors.CheckEdit chkTaoMoi;
    }
}