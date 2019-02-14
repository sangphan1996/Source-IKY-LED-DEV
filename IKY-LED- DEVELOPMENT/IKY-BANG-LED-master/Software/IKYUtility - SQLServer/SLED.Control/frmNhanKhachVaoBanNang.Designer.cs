namespace IKY.Control
{
    partial class frmNhanKhachVaoBanNang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanKhachVaoBanNang));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cbbDsBanNang = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtGio = new DevExpress.XtraEditors.TextEdit();
            this.txtPhut = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).BeginInit();
            this.groupControlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbDsBanNang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhut.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControlBase.Controls.Add(this.cbbDsBanNang);
            this.groupControlBase.Controls.Add(this.labelControl4);
            this.groupControlBase.Controls.Add(this.labelControl1);
            this.groupControlBase.Controls.Add(this.labelControl3);
            this.groupControlBase.Controls.Add(this.labelControl2);
            this.groupControlBase.Controls.Add(this.txtPhut);
            this.groupControlBase.Controls.Add(this.txtGio);
            this.groupControlBase.Size = new System.Drawing.Size(236, 96);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Bàn nâng";
            // 
            // cbbDsBanNang
            // 
            this.cbbDsBanNang.EditValue = "";
            this.cbbDsBanNang.Location = new System.Drawing.Point(62, 24);
            this.cbbDsBanNang.Name = "cbbDsBanNang";
            this.cbbDsBanNang.Properties.Appearance.Options.UseTextOptions = true;
            this.cbbDsBanNang.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cbbDsBanNang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbDsBanNang.Properties.DisplayMember = "kythuatvien";
            this.cbbDsBanNang.Properties.NullText = "Chọn bàn nâng";
            this.cbbDsBanNang.Properties.ValueMember = "id";
            this.cbbDsBanNang.Properties.View = this.gridLookUpEdit1View;
            this.cbbDsBanNang.Size = new System.Drawing.Size(164, 20);
            this.cbbDsBanNang.TabIndex = 0;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Kỹ thuật viên";
            this.gridColumn2.FieldName = "kythuatvien";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Thời gian dự kiến";
            // 
            // txtGio
            // 
            this.txtGio.Location = new System.Drawing.Point(98, 50);
            this.txtGio.Name = "txtGio";
            this.txtGio.Properties.Appearance.Options.UseTextOptions = true;
            this.txtGio.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtGio.Properties.Mask.EditMask = "d";
            this.txtGio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGio.Properties.MaxLength = 2;
            this.txtGio.Properties.NullText = "0";
            this.txtGio.Size = new System.Drawing.Size(34, 20);
            this.txtGio.TabIndex = 1;
            // 
            // txtPhut
            // 
            this.txtPhut.Location = new System.Drawing.Point(159, 50);
            this.txtPhut.Name = "txtPhut";
            this.txtPhut.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPhut.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtPhut.Properties.Mask.EditMask = "d";
            this.txtPhut.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPhut.Properties.MaxLength = 2;
            this.txtPhut.Properties.NullText = "0";
            this.txtPhut.Size = new System.Drawing.Size(34, 20);
            this.txtPhut.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(138, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(15, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Giờ";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(199, 53);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(22, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Phút";
            // 
            // frmNhanKhachVaoBanNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 96);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhanKhachVaoBanNang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhận khách vào bàn nâng";
            this.Load += new System.EventHandler(this.frmNhanKhachVaoBanNang_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmNhanKhachVaoBanNang_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).EndInit();
            this.groupControlBase.ResumeLayout(false);
            this.groupControlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbDsBanNang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhut.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GridLookUpEdit cbbDsBanNang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtGio;
        private DevExpress.XtraEditors.TextEdit txtPhut;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}