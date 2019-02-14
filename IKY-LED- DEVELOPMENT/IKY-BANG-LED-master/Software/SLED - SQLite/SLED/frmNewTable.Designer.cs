namespace SLED
{
    partial class frmNewTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewTable));
            this.numID = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDongY = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).BeginInit();
            this.SuspendLayout();
            // 
            // numID
            // 
            this.numID.Location = new System.Drawing.Point(77, 12);
            this.numID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numID.Name = "numID";
            this.numID.Size = new System.Drawing.Size(83, 20);
            this.numID.TabIndex = 0;
            this.numID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bàn nâng ";
            // 
            // btnDongY
            // 
            this.btnDongY.Image = ((System.Drawing.Image)(resources.GetObject("btnDongY.Image")));
            this.btnDongY.Location = new System.Drawing.Point(169, 10);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 23);
            this.btnDongY.TabIndex = 4;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // frmNewTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 39);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tại bàn nâng mới";
            this.Load += new System.EventHandler(this.frmNewTable_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmNewTable_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.numID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numID;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnDongY;
    }
}