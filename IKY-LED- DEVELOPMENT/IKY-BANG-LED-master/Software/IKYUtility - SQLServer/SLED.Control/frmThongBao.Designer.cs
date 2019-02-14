namespace IKY.Control
{
    partial class frmThongBao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongBao));
            this.txtNoiDung = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).BeginInit();
            this.groupControlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControlBase.Controls.Add(this.labelControl1);
            this.groupControlBase.Controls.Add(this.txtNoiDung);
            this.groupControlBase.Size = new System.Drawing.Size(421, 112);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(6, 44);
            this.txtNoiDung.Margin = new System.Windows.Forms.Padding(4);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Properties.MaxLength = 100;
            this.txtNoiDung.Properties.NullText = "Nhập nội dung thông báo";
            this.txtNoiDung.Size = new System.Drawing.Size(393, 20);
            this.txtNoiDung.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(121, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Nhập nội dung thông báo";
            // 
            // frmThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 112);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongBao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông báo";
            this.Load += new System.EventHandler(this.frmThongBao_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmThongBao_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).EndInit();
            this.groupControlBase.ResumeLayout(false);
            this.groupControlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNoiDung;
        private DevExpress.XtraEditors.LabelControl labelControl1;

    }
}