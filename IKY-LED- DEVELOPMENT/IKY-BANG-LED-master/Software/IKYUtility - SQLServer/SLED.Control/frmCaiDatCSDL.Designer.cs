namespace IKY.Control
{
    partial class frmCaiDatCSDL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaiDatCSDL));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDatabase = new DevExpress.XtraEditors.TextEdit();
            this.txtHost = new DevExpress.XtraEditors.TextEdit();
            this.txtUserLogin = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtSchema = new DevExpress.XtraEditors.TextEdit();
            this.txtPort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDatasource = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).BeginInit();
            this.groupControlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchema.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatasource.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControlBase.Controls.Add(this.txtPort);
            this.groupControlBase.Controls.Add(this.txtDatasource);
            this.groupControlBase.Controls.Add(this.labelControl1);
            this.groupControlBase.Controls.Add(this.labelControl2);
            this.groupControlBase.Controls.Add(this.txtSchema);
            this.groupControlBase.Controls.Add(this.labelControl3);
            this.groupControlBase.Controls.Add(this.txtPassword);
            this.groupControlBase.Controls.Add(this.labelControl4);
            this.groupControlBase.Controls.Add(this.txtUserLogin);
            this.groupControlBase.Controls.Add(this.labelControl5);
            this.groupControlBase.Controls.Add(this.txtHost);
            this.groupControlBase.Controls.Add(this.labelControl6);
            this.groupControlBase.Controls.Add(this.txtDatabase);
            this.groupControlBase.Controls.Add(this.labelControl7);
            this.groupControlBase.Size = new System.Drawing.Size(299, 218);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 109);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Database:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(132, 106);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(155, 20);
            this.txtDatabase.TabIndex = 3;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(132, 26);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(155, 20);
            this.txtHost.TabIndex = 0;
            // 
            // txtUserLogin
            // 
            this.txtUserLogin.Location = new System.Drawing.Point(132, 132);
            this.txtUserLogin.Name = "txtUserLogin";
            this.txtUserLogin.Size = new System.Drawing.Size(155, 20);
            this.txtUserLogin.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(132, 158);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(155, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // txtSchema
            // 
            this.txtSchema.Location = new System.Drawing.Point(132, 184);
            this.txtSchema.Name = "txtSchema";
            this.txtSchema.Size = new System.Drawing.Size(155, 20);
            this.txtSchema.TabIndex = 6;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(132, 52);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(155, 20);
            this.txtPort.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Host:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 132);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "User name:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 161);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 13);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Password:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(15, 187);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(41, 13);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "Schema:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(15, 59);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(24, 13);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Port:";
            // 
            // txtDatasource
            // 
            this.txtDatasource.Location = new System.Drawing.Point(132, 78);
            this.txtDatasource.Name = "txtDatasource";
            this.txtDatasource.Size = new System.Drawing.Size(155, 20);
            this.txtDatasource.TabIndex = 2;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(15, 81);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(105, 13);
            this.labelControl7.TabIndex = 9;
            this.labelControl7.Text = "Datasource(Instance)";
            // 
            // frmCaiDatCSDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 218);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCaiDatCSDL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cài đặt cơ sở dữ liệu";
            this.Load += new System.EventHandler(this.frmCaiDatCSDL_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCaiDatCSDL_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).EndInit();
            this.groupControlBase.ResumeLayout(false);
            this.groupControlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchema.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatasource.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtDatabase;
        private DevExpress.XtraEditors.TextEdit txtHost;
        private DevExpress.XtraEditors.TextEdit txtUserLogin;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtSchema;
        private DevExpress.XtraEditors.TextEdit txtPort;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtDatasource;
        private DevExpress.XtraEditors.LabelControl labelControl7;

    }
}