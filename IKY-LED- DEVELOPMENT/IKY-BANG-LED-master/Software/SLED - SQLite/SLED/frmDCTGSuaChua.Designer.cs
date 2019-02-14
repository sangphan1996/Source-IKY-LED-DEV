namespace SLED
{
    partial class frmDCTGSuaChua
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDCTGSuaChua));
            this.numPhut = new System.Windows.Forms.NumericUpDown();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnGiam = new DevExpress.XtraEditors.SimpleButton();
            this.btnTang = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.numPhut)).BeginInit();
            this.SuspendLayout();
            // 
            // numPhut
            // 
            this.numPhut.Location = new System.Drawing.Point(70, 10);
            this.numPhut.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numPhut.Name = "numPhut";
            this.numPhut.Size = new System.Drawing.Size(116, 20);
            this.numPhut.TabIndex = 0;
            this.numPhut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Thời gian";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(192, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Phút";
            // 
            // btnGiam
            // 
            this.btnGiam.Enabled = false;
            this.btnGiam.Image = ((System.Drawing.Image)(resources.GetObject("btnGiam.Image")));
            this.btnGiam.Location = new System.Drawing.Point(150, 45);
            this.btnGiam.Name = "btnGiam";
            this.btnGiam.Size = new System.Drawing.Size(75, 23);
            this.btnGiam.TabIndex = 2;
            this.btnGiam.Text = "Giảm";
            this.btnGiam.Click += new System.EventHandler(this.btnGiam_Click);
            // 
            // btnTang
            // 
            this.btnTang.Image = ((System.Drawing.Image)(resources.GetObject("btnTang.Image")));
            this.btnTang.Location = new System.Drawing.Point(60, 45);
            this.btnTang.Name = "btnTang";
            this.btnTang.Size = new System.Drawing.Size(75, 23);
            this.btnTang.TabIndex = 1;
            this.btnTang.Text = "Tăng";
            this.btnTang.Click += new System.EventHandler(this.btnTang_Click);
            // 
            // frmDCTGSuaChua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 78);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnGiam);
            this.Controls.Add(this.btnTang);
            this.Controls.Add(this.numPhut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDCTGSuaChua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chỉnh thời gian [Bàn nâng {0}]";
            this.Load += new System.EventHandler(this.frmDCTGSuaChua_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmDCTGSuaChua_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.numPhut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numPhut;
        private DevExpress.XtraEditors.SimpleButton btnTang;
        private DevExpress.XtraEditors.SimpleButton btnGiam;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}