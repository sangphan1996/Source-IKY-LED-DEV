namespace IKY.Control
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdDuLieu = new DevExpress.XtraGrid.GridControl();
            this.grvDuLieu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvDuLieuCol_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.txtDenNgay = new DevExpress.XtraEditors.TextEdit();
            this.txtTuNgay = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDuLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDuLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grdDuLieu, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.17021F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.82979F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 564);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grdDuLieu
            // 
            this.grdDuLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDuLieu.Location = new System.Drawing.Point(3, 65);
            this.grdDuLieu.MainView = this.grvDuLieu;
            this.grdDuLieu.Name = "grdDuLieu";
            this.grdDuLieu.Size = new System.Drawing.Size(1000, 496);
            this.grdDuLieu.TabIndex = 0;
            this.grdDuLieu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDuLieu});
            // 
            // grvDuLieu
            // 
            this.grvDuLieu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grvDuLieuCol_STT,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn7,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn1});
            this.grvDuLieu.GridControl = this.grdDuLieu;
            this.grvDuLieu.Name = "grvDuLieu";
            this.grvDuLieu.OptionsBehavior.ReadOnly = true;
            this.grvDuLieu.OptionsView.ShowGroupPanel = false;
            this.grvDuLieu.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.grvDuLieu_CustomColumnDisplayText);
            // 
            // grvDuLieuCol_STT
            // 
            this.grvDuLieuCol_STT.Caption = "STT";
            this.grvDuLieuCol_STT.Name = "grvDuLieuCol_STT";
            this.grvDuLieuCol_STT.Visible = true;
            this.grvDuLieuCol_STT.VisibleIndex = 0;
            this.grvDuLieuCol_STT.Width = 29;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn2.Caption = "Bàn nâng";
            this.gridColumn2.FieldName = "mabannang";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 57;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Kỹ thuật viên";
            this.gridColumn3.FieldName = "kythuatvien";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 100;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Thời gian";
            this.gridColumn7.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn7.FieldName = "ngayud";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 78;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Khách hàng";
            this.gridColumn4.FieldName = "hoten";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 108;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Biển số xe";
            this.gridColumn5.FieldName = "biensoxe";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 76;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn6.Caption = "TG sửa chữa(Phút)";
            this.gridColumn6.FieldName = "thoigian";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 99;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnIn);
            this.groupControl1.Controls.Add(this.btnXem);
            this.groupControl1.Controls.Add(this.txtDenNgay);
            this.groupControl1.Controls.Add(this.txtTuNgay);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1000, 56);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Thời gian";
            // 
            // btnIn
            // 
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.Location = new System.Drawing.Point(438, 27);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 2;
            this.btnIn.Text = "In";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnXem
            // 
            this.btnXem.Image = ((System.Drawing.Image)(resources.GetObject("btnXem.Image")));
            this.btnXem.Location = new System.Drawing.Point(341, 27);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 2;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.Location = new System.Drawing.Point(213, 30);
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
            this.txtTuNgay.Location = new System.Drawing.Point(55, 30);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTuNgay.Properties.EditFormat.FormatString = "d";
            this.txtTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTuNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtTuNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.txtTuNgay.Size = new System.Drawing.Size(100, 20);
            this.txtTuNgay.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(160, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ ngày";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nội dung sửa chữa";
            this.gridColumn1.FieldName = "ghichu";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 149;
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 564);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmBaoCao_KeyPress);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDuLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDuLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdDuLieu;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDuLieu;
        private DevExpress.XtraGrid.Columns.GridColumn grvDuLieuCol_STT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtDenNgay;
        private DevExpress.XtraEditors.TextEdit txtTuNgay;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}