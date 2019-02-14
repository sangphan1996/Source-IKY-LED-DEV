namespace SLED
{
    partial class frmTTCauHinhBN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTTCauHinhBN));
            this.txtCauChao = new DevExpress.XtraEditors.TextEdit();
            this.txtKTV = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnDongY = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtCauChao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKTV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCauChao
            // 
            this.txtCauChao.Location = new System.Drawing.Point(88, 12);
            this.txtCauChao.Name = "txtCauChao";
            this.txtCauChao.Size = new System.Drawing.Size(184, 20);
            this.txtCauChao.TabIndex = 0;
            // 
            // txtKTV
            // 
            this.txtKTV.Location = new System.Drawing.Point(89, 38);
            this.txtKTV.Name = "txtKTV";
            this.txtKTV.Size = new System.Drawing.Size(184, 20);
            this.txtKTV.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Câu chào";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Kỹ thuật viên";
            // 
            // btnDongY
            // 
            this.btnDongY.Image = ((System.Drawing.Image)(resources.GetObject("btnDongY.Image")));
            this.btnDongY.Location = new System.Drawing.Point(198, 64);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 23);
            this.btnDongY.TabIndex = 2;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // frmTTCauHinhBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 93);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.txtKTV);
            this.Controls.Add(this.txtCauChao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmTTCauHinhBN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin mặc định";
            this.Load += new System.EventHandler(this.frmTTCauHinhBN_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmTTCauHinhBN_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.txtCauChao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKTV.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtCauChao;
        private DevExpress.XtraEditors.TextEdit txtKTV;
        private DevExpress.XtraEditors.SimpleButton btnDongY;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;

    }
}