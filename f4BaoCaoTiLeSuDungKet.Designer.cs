namespace SafeControl
{
    partial class f4BaoCaoTiLeSuDungKet
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
            this.mdtgv_TinhHinhSuDungKet = new SafeControl.MComponent.MDataGridView(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mlNhanVien = new SafeControl.MComponent.MLabel(this.components);
            this.mlb_BaoCaoTinhHinh = new SafeControl.MComponent.MLabel(this.components);
            this.mlb_NguoiLap = new SafeControl.MComponent.MLabel(this.components);
            this.mlb_NguoiKiemSoat = new SafeControl.MComponent.MLabel(this.components);
            this.mtbNguoiLapBieu = new SafeControl.MComponent.MTextBox(this.components);
            this.mtbNguoiPheDuyet = new SafeControl.MComponent.MTextBox(this.components);
            this.mbtn_Thoat = new SafeControl.MComponent.MButton(this.components);
            this.mbtn_InBaoCao = new SafeControl.MComponent.MButton(this.components);
            this.mbtn_ThongKe = new SafeControl.MComponent.MButton(this.components);
            this.mPanel2 = new SafeControl.MComponent.MPanel(this.components);
            this.mde_NgayKetthuc = new SafeControl.MComponent.MDateEdit(this.components);
            this.mde_NgayBatDau = new SafeControl.MComponent.MDateEdit(this.components);
            this.mlb_NgayKetThuc = new SafeControl.MComponent.MLabel(this.components);
            this.mlbNgayBatDau = new SafeControl.MComponent.MLabel(this.components);
            this.mpMainContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdtgv_TinhHinhSuDungKet)).BeginInit();
            this.mPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayKetthuc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayKetthuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayBatDau.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayBatDau.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mpMainContext
            // 
            this.mpMainContext.Controls.Add(this.mdtgv_TinhHinhSuDungKet);
            this.mpMainContext.Controls.Add(this.mPanel2);
            this.mpMainContext.Size = new System.Drawing.Size(884, 481);
            // 
            // mdtgv_TinhHinhSuDungKet
            // 
            this.mdtgv_TinhHinhSuDungKet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mdtgv_TinhHinhSuDungKet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.mdtgv_TinhHinhSuDungKet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mdtgv_TinhHinhSuDungKet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.mdtgv_TinhHinhSuDungKet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdtgv_TinhHinhSuDungKet.Location = new System.Drawing.Point(0, 177);
            this.mdtgv_TinhHinhSuDungKet.Name = "mdtgv_TinhHinhSuDungKet";
            this.mdtgv_TinhHinhSuDungKet.RowHeadersWidth = 20;
            this.mdtgv_TinhHinhSuDungKet.sColumnName = null;
            this.mdtgv_TinhHinhSuDungKet.Size = new System.Drawing.Size(884, 304);
            this.mdtgv_TinhHinhSuDungKet.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Loại két";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Két đã sử dụng";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Két trống";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Két đặt trước";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tổng";
            this.Column5.Name = "Column5";
            // 
            // mlNhanVien
            // 
            this.mlNhanVien.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.mlNhanVien.Location = new System.Drawing.Point(4, 0);
            this.mlNhanVien.Name = "mlNhanVien";
            this.mlNhanVien.sColumnName = null;
            this.mlNhanVien.Size = new System.Drawing.Size(426, 23);
            this.mlNhanVien.TabIndex = 12;
            this.mlNhanVien.Text = "Nhân viên:";
            this.mlNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mlb_BaoCaoTinhHinh
            // 
            this.mlb_BaoCaoTinhHinh.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mlb_BaoCaoTinhHinh.Location = new System.Drawing.Point(230, 35);
            this.mlb_BaoCaoTinhHinh.Name = "mlb_BaoCaoTinhHinh";
            this.mlb_BaoCaoTinhHinh.sColumnName = null;
            this.mlb_BaoCaoTinhHinh.Size = new System.Drawing.Size(424, 31);
            this.mlb_BaoCaoTinhHinh.TabIndex = 11;
            this.mlb_BaoCaoTinhHinh.Text = "BÁO CÁO TÌNH HÌNH SỬ DỤNG KÉT";
            this.mlb_BaoCaoTinhHinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mlb_NguoiLap
            // 
            this.mlb_NguoiLap.Location = new System.Drawing.Point(114, 100);
            this.mlb_NguoiLap.Name = "mlb_NguoiLap";
            this.mlb_NguoiLap.sColumnName = null;
            this.mlb_NguoiLap.Size = new System.Drawing.Size(100, 20);
            this.mlb_NguoiLap.TabIndex = 8;
            this.mlb_NguoiLap.Text = "Người lập";
            this.mlb_NguoiLap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mlb_NguoiKiemSoat
            // 
            this.mlb_NguoiKiemSoat.Location = new System.Drawing.Point(470, 106);
            this.mlb_NguoiKiemSoat.Name = "mlb_NguoiKiemSoat";
            this.mlb_NguoiKiemSoat.sColumnName = null;
            this.mlb_NguoiKiemSoat.Size = new System.Drawing.Size(100, 20);
            this.mlb_NguoiKiemSoat.TabIndex = 10;
            this.mlb_NguoiKiemSoat.Text = "Người kiểm soát";
            this.mlb_NguoiKiemSoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mtbNguoiLapBieu
            // 
            this.mtbNguoiLapBieu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbNguoiLapBieu.Location = new System.Drawing.Point(214, 103);
            this.mtbNguoiLapBieu.Name = "mtbNguoiLapBieu";
            this.mtbNguoiLapBieu.sColumnName = null;
            this.mtbNguoiLapBieu.Size = new System.Drawing.Size(200, 22);
            this.mtbNguoiLapBieu.TabIndex = 1;
            // 
            // mtbNguoiPheDuyet
            // 
            this.mtbNguoiPheDuyet.Location = new System.Drawing.Point(570, 106);
            this.mtbNguoiPheDuyet.Name = "mtbNguoiPheDuyet";
            this.mtbNguoiPheDuyet.sColumnName = null;
            this.mtbNguoiPheDuyet.Size = new System.Drawing.Size(200, 22);
            this.mtbNguoiPheDuyet.TabIndex = 2;
            this.mtbNguoiPheDuyet.Text = "Tran Van A";
            // 
            // mbtn_Thoat
            // 
            this.mbtn_Thoat.Location = new System.Drawing.Point(505, 143);
            this.mbtn_Thoat.Name = "mbtn_Thoat";
            this.mbtn_Thoat.sColumnName = null;
            this.mbtn_Thoat.Size = new System.Drawing.Size(75, 20);
            this.mbtn_Thoat.TabIndex = 5;
            this.mbtn_Thoat.Text = "Thoát";
            this.mbtn_Thoat.UseVisualStyleBackColor = true;
            this.mbtn_Thoat.Click += new System.EventHandler(this.mbtn_Thoat_Click_1);
            // 
            // mbtn_InBaoCao
            // 
            this.mbtn_InBaoCao.Location = new System.Drawing.Point(405, 143);
            this.mbtn_InBaoCao.Name = "mbtn_InBaoCao";
            this.mbtn_InBaoCao.sColumnName = null;
            this.mbtn_InBaoCao.Size = new System.Drawing.Size(75, 20);
            this.mbtn_InBaoCao.TabIndex = 4;
            this.mbtn_InBaoCao.Text = "In báo cáo";
            this.mbtn_InBaoCao.UseVisualStyleBackColor = true;
            this.mbtn_InBaoCao.Click += new System.EventHandler(this.mbtn_InBaoCao_Click_1);
            // 
            // mbtn_ThongKe
            // 
            this.mbtn_ThongKe.Location = new System.Drawing.Point(305, 143);
            this.mbtn_ThongKe.Name = "mbtn_ThongKe";
            this.mbtn_ThongKe.sColumnName = null;
            this.mbtn_ThongKe.Size = new System.Drawing.Size(75, 20);
            this.mbtn_ThongKe.TabIndex = 3;
            this.mbtn_ThongKe.Text = "Thống kê";
            this.mbtn_ThongKe.UseVisualStyleBackColor = true;
            this.mbtn_ThongKe.Click += new System.EventHandler(this.mbtn_ThongKe_Click_1);
            // 
            // mPanel2
            // 
            this.mPanel2.Controls.Add(this.mde_NgayKetthuc);
            this.mPanel2.Controls.Add(this.mde_NgayBatDau);
            this.mPanel2.Controls.Add(this.mlb_NgayKetThuc);
            this.mPanel2.Controls.Add(this.mlbNgayBatDau);
            this.mPanel2.Controls.Add(this.mbtn_ThongKe);
            this.mPanel2.Controls.Add(this.mbtn_InBaoCao);
            this.mPanel2.Controls.Add(this.mbtn_Thoat);
            this.mPanel2.Controls.Add(this.mtbNguoiPheDuyet);
            this.mPanel2.Controls.Add(this.mtbNguoiLapBieu);
            this.mPanel2.Controls.Add(this.mlb_NguoiKiemSoat);
            this.mPanel2.Controls.Add(this.mlb_NguoiLap);
            this.mPanel2.Controls.Add(this.mlb_BaoCaoTinhHinh);
            this.mPanel2.Controls.Add(this.mlNhanVien);
            this.mPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.mPanel2.Location = new System.Drawing.Point(0, 0);
            this.mPanel2.Name = "mPanel2";
            this.mPanel2.sColumnName = null;
            this.mPanel2.Size = new System.Drawing.Size(884, 177);
            this.mPanel2.TabIndex = 0;
            // 
            // mde_NgayKetthuc
            // 
            this.mde_NgayKetthuc.EditValue = new System.DateTime(2022, 3, 11, 11, 1, 22, 0);
            this.mde_NgayKetthuc.Location = new System.Drawing.Point(570, 80);
            this.mde_NgayKetthuc.Name = "mde_NgayKetthuc";
            this.mde_NgayKetthuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mde_NgayKetthuc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mde_NgayKetthuc.sColumnName = null;
            this.mde_NgayKetthuc.Size = new System.Drawing.Size(200, 20);
            this.mde_NgayKetthuc.TabIndex = 1;
            this.mde_NgayKetthuc.Visible = false;
            // 
            // mde_NgayBatDau
            // 
            this.mde_NgayBatDau.EditValue = new System.DateTime(2022, 3, 15, 16, 50, 6, 16);
            this.mde_NgayBatDau.Location = new System.Drawing.Point(214, 80);
            this.mde_NgayBatDau.Name = "mde_NgayBatDau";
            this.mde_NgayBatDau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mde_NgayBatDau.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mde_NgayBatDau.sColumnName = null;
            this.mde_NgayBatDau.Size = new System.Drawing.Size(200, 20);
            this.mde_NgayBatDau.TabIndex = 0;
            // 
            // mlb_NgayKetThuc
            // 
            this.mlb_NgayKetThuc.Location = new System.Drawing.Point(470, 80);
            this.mlb_NgayKetThuc.Name = "mlb_NgayKetThuc";
            this.mlb_NgayKetThuc.sColumnName = null;
            this.mlb_NgayKetThuc.Size = new System.Drawing.Size(100, 20);
            this.mlb_NgayKetThuc.TabIndex = 9;
            this.mlb_NgayKetThuc.Text = "Ngày kết thúc";
            this.mlb_NgayKetThuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mlb_NgayKetThuc.Visible = false;
            // 
            // mlbNgayBatDau
            // 
            this.mlbNgayBatDau.Location = new System.Drawing.Point(114, 80);
            this.mlbNgayBatDau.Name = "mlbNgayBatDau";
            this.mlbNgayBatDau.sColumnName = null;
            this.mlbNgayBatDau.Size = new System.Drawing.Size(100, 20);
            this.mlbNgayBatDau.TabIndex = 7;
            this.mlbNgayBatDau.Text = "Ngày thống kê";
            this.mlbNgayBatDau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // f4BaoCaoTiLeSuDungKet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "f4BaoCaoTiLeSuDungKet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo tỉ lệ sử dụng két";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.f4BaoCaoTiLeSuDungKet_FormClosed);
            this.Load += new System.EventHandler(this.f4BaoCaoTiLeSuDungKet_Load);
            this.mpMainContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mdtgv_TinhHinhSuDungKet)).EndInit();
            this.mPanel2.ResumeLayout(false);
            this.mPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayKetthuc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayKetthuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayBatDau.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayBatDau.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MComponent.MDataGridView mdtgv_TinhHinhSuDungKet;
        private MComponent.MPanel mPanel2;
        private MComponent.MButton mbtn_ThongKe;
        private MComponent.MButton mbtn_InBaoCao;
        private MComponent.MButton mbtn_Thoat;
        private MComponent.MTextBox mtbNguoiPheDuyet;
        private MComponent.MTextBox mtbNguoiLapBieu;
        private MComponent.MLabel mlb_NguoiKiemSoat;
        private MComponent.MLabel mlb_NguoiLap;
        private MComponent.MLabel mlb_BaoCaoTinhHinh;
        private MComponent.MLabel mlNhanVien;
        private MComponent.MDateEdit mde_NgayKetthuc;
        private MComponent.MDateEdit mde_NgayBatDau;
        private MComponent.MLabel mlb_NgayKetThuc;
        private MComponent.MLabel mlbNgayBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;

    }
}