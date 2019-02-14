namespace SLED
{
    partial class frmBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao));
            this.grdDuLieu = new DevExpress.XtraGrid.GridControl();
            this.grvDuLieu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDenNgay = new DevExpress.XtraEditors.TextEdit();
            this.txtTuNgay = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDuLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDuLieu)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDuLieu
            // 
            this.grdDuLieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDuLieu.Location = new System.Drawing.Point(12, 64);
            this.grdDuLieu.MainView = this.grvDuLieu;
            this.grdDuLieu.Name = "grdDuLieu";
            this.grdDuLieu.Size = new System.Drawing.Size(732, 299);
            this.grdDuLieu.TabIndex = 0;
            this.grdDuLieu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDuLieu});
            // 
            // grvDuLieu
            // 
            this.grvDuLieu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.grvDuLieu.GridControl = this.grdDuLieu;
            this.grvDuLieu.Name = "grvDuLieu";
            this.grvDuLieu.OptionsBehavior.ReadOnly = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Bàn nâng";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 74;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Kỹ thuật viên";
            this.gridColumn6.FieldName = "ktv";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 165;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Thời gian";
            this.gridColumn2.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "time";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 131;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Khách hàng";
            this.gridColumn3.FieldName = "khachhang";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 179;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Biển số xe";
            this.gridColumn4.FieldName = "biensoxe";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 73;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "TG sửa chữa";
            this.gridColumn5.FieldName = "thoigian";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 74;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Location = new System.Drawing.Point(337, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 46);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.Location = new System.Drawing.Point(6, 16);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(96, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Xuất báo cáo";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Location = new System.Drawing.Point(108, 16);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(96, 23);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Controls.Add(this.labelControl1);
            this.groupBox2.Controls.Add(this.txtDenNgay);
            this.groupBox2.Controls.Add(this.txtTuNgay);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 46);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thời gian";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Từ ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(158, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Đến ngày";
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.Location = new System.Drawing.Point(211, 18);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDenNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtDenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDenNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtDenNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.txtDenNgay.Size = new System.Drawing.Size(100, 20);
            this.txtDenNgay.TabIndex = 1;
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.Location = new System.Drawing.Point(52, 18);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTuNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTuNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtTuNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.txtTuNgay.Size = new System.Drawing.Size(100, 20);
            this.txtTuNgay.TabIndex = 0;
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 375);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdDuLieu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBaoCao_FormClosing);
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDuLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDuLieu)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdDuLieu;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDuLieu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtDenNgay;
        private DevExpress.XtraEditors.TextEdit txtTuNgay;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
    }
}