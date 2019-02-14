namespace SLED
{
    partial class frmPortSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPortSettings));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cbbSerialPorts = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnDongY = new DevExpress.XtraEditors.SimpleButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cbbSerialPorts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(20, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Port";
            // 
            // cbbSerialPorts
            // 
            this.cbbSerialPorts.Location = new System.Drawing.Point(41, 16);
            this.cbbSerialPorts.Name = "cbbSerialPorts";
            this.cbbSerialPorts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbSerialPorts.Size = new System.Drawing.Size(130, 20);
            this.cbbSerialPorts.TabIndex = 7;
            // 
            // btnDongY
            // 
            this.btnDongY.Image = ((System.Drawing.Image)(resources.GetObject("btnDongY.Image")));
            this.btnDongY.Location = new System.Drawing.Point(187, 14);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 23);
            this.btnDongY.TabIndex = 2;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // frmPortSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 47);
            this.Controls.Add(this.cbbSerialPorts);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnDongY);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPortSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cấu hình";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPortSettings_FormClosed);
            this.Load += new System.EventHandler(this.frmPortSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbbSerialPorts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.IO.Ports.SerialPort serialPort1;
        private DevExpress.XtraEditors.SimpleButton btnDongY;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cbbSerialPorts;
    }
}