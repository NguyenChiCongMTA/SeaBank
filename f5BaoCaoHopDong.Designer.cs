namespace SafeControl
{
    partial class f5BaoCaoHopDong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mlb_NguoiLap = new SafeControl.MComponent.MLabel(this.components);
            this.mlb_NguoiKiemSoat = new SafeControl.MComponent.MLabel(this.components);
            this.mlNhanVien = new SafeControl.MComponent.MLabel(this.components);
            this.mlbNgayBatDau = new SafeControl.MComponent.MLabel(this.components);
            this.mbtn_Thoat = new SafeControl.MComponent.MButton(this.components);
            this.mlb_NgayKetThuc = new SafeControl.MComponent.MLabel(this.components);
            this.mbtn_InBaoCao = new SafeControl.MComponent.MButton(this.components);
            this.mtbNguoiLapBieu = new SafeControl.MComponent.MTextBox(this.components);
            this.mbtn_ThongKe = new SafeControl.MComponent.MButton(this.components);
            this.mtbNguoiPheDuyet = new SafeControl.MComponent.MTextBox(this.components);
            this.mlb_BaoCaoTinhHinh = new SafeControl.MComponent.MLabel(this.components);
            this.mde_NgayBatDau = new SafeControl.MComponent.MDateEdit(this.components);
            this.mde_NgayKetthuc = new SafeControl.MComponent.MDateEdit(this.components);
            this.mPanel1 = new SafeControl.MComponent.MPanel(this.components);
            this.mcb_LoaiHopDong = new SafeControl.MComponent.MComboBox(this.components);
            this.mcb_LoaiBox = new SafeControl.MComponent.MComboBox(this.components);
            this.mlb_LoaiHopDong = new SafeControl.MComponent.MLabel(this.components);
            this.mlb_LoaiBox = new SafeControl.MComponent.MLabel(this.components);
            this.mdgv_BaoCaoTinhHinhSuDungHopDong = new SafeControl.MComponent.MDataGridView(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mpMainContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayBatDau.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayBatDau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayKetthuc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayKetthuc.Properties)).BeginInit();
            this.mPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdgv_BaoCaoTinhHinhSuDungHopDong)).BeginInit();
            this.SuspendLayout();
            // 
            // mpMainContext
            // 
            this.mpMainContext.Controls.Add(this.mdgv_BaoCaoTinhHinhSuDungHopDong);
            this.mpMainContext.Controls.Add(this.mPanel1);
            this.mpMainContext.Size = new System.Drawing.Size(884, 481);
            // 
            // mlb_NguoiLap
            // 
            this.mlb_NguoiLap.Location = new System.Drawing.Point(81, 134);
            this.mlb_NguoiLap.Name = "mlb_NguoiLap";
            this.mlb_NguoiLap.sColumnName = null;
            this.mlb_NguoiLap.Size = new System.Drawing.Size(100, 20);
            this.mlb_NguoiLap.TabIndex = 10;
            this.mlb_NguoiLap.Text = "Người lập";
            this.mlb_NguoiLap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mlb_NguoiKiemSoat
            // 
            this.mlb_NguoiKiemSoat.Location = new System.Drawing.Point(503, 136);
            this.mlb_NguoiKiemSoat.Name = "mlb_NguoiKiemSoat";
            this.mlb_NguoiKiemSoat.sColumnName = null;
            this.mlb_NguoiKiemSoat.Size = new System.Drawing.Size(100, 20);
            this.mlb_NguoiKiemSoat.TabIndex = 14;
            this.mlb_NguoiKiemSoat.Text = "Người kiểm soát";
            this.mlb_NguoiKiemSoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mlNhanVien
            // 
            this.mlNhanVien.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.mlNhanVien.Location = new System.Drawing.Point(1, 1);
            this.mlNhanVien.Name = "mlNhanVien";
            this.mlNhanVien.sColumnName = null;
            this.mlNhanVien.Size = new System.Drawing.Size(300, 25);
            this.mlNhanVien.TabIndex = 16;
            this.mlNhanVien.Text = "Nhân viên:";
            // 
            // mlbNgayBatDau
            // 
            this.mlbNgayBatDau.Location = new System.Drawing.Point(81, 80);
            this.mlbNgayBatDau.Name = "mlbNgayBatDau";
            this.mlbNgayBatDau.sColumnName = null;
            this.mlbNgayBatDau.Size = new System.Drawing.Size(100, 20);
            this.mlbNgayBatDau.TabIndex = 9;
            this.mlbNgayBatDau.Text = "Ngày bắt đầu";
            this.mlbNgayBatDau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mbtn_Thoat
            // 
            this.mbtn_Thoat.Location = new System.Drawing.Point(489, 172);
            this.mbtn_Thoat.Name = "mbtn_Thoat";
            this.mbtn_Thoat.sColumnName = null;
            this.mbtn_Thoat.Size = new System.Drawing.Size(75, 20);
            this.mbtn_Thoat.TabIndex = 8;
            this.mbtn_Thoat.Text = "Thoát";
            this.mbtn_Thoat.UseVisualStyleBackColor = true;
            this.mbtn_Thoat.Click += new System.EventHandler(this.mbtn_Thoat_Click);
            // 
            // mlb_NgayKetThuc
            // 
            this.mlb_NgayKetThuc.Location = new System.Drawing.Point(503, 80);
            this.mlb_NgayKetThuc.Name = "mlb_NgayKetThuc";
            this.mlb_NgayKetThuc.sColumnName = null;
            this.mlb_NgayKetThuc.Size = new System.Drawing.Size(100, 20);
            this.mlb_NgayKetThuc.TabIndex = 12;
            this.mlb_NgayKetThuc.Text = "Ngày kết thúc";
            this.mlb_NgayKetThuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mbtn_InBaoCao
            // 
            this.mbtn_InBaoCao.Location = new System.Drawing.Point(405, 172);
            this.mbtn_InBaoCao.Name = "mbtn_InBaoCao";
            this.mbtn_InBaoCao.sColumnName = null;
            this.mbtn_InBaoCao.Size = new System.Drawing.Size(75, 20);
            this.mbtn_InBaoCao.TabIndex = 7;
            this.mbtn_InBaoCao.Text = "In báo cáo";
            this.mbtn_InBaoCao.UseVisualStyleBackColor = true;
            this.mbtn_InBaoCao.Click += new System.EventHandler(this.mbtn_InBaoCao_Click);
            // 
            // mtbNguoiLapBieu
            // 
            this.mtbNguoiLapBieu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbNguoiLapBieu.Location = new System.Drawing.Point(181, 135);
            this.mtbNguoiLapBieu.Name = "mtbNguoiLapBieu";
            this.mtbNguoiLapBieu.sColumnName = null;
            this.mtbNguoiLapBieu.Size = new System.Drawing.Size(200, 22);
            this.mtbNguoiLapBieu.TabIndex = 4;
            // 
            // mbtn_ThongKe
            // 
            this.mbtn_ThongKe.Location = new System.Drawing.Point(321, 172);
            this.mbtn_ThongKe.Name = "mbtn_ThongKe";
            this.mbtn_ThongKe.sColumnName = null;
            this.mbtn_ThongKe.Size = new System.Drawing.Size(75, 20);
            this.mbtn_ThongKe.TabIndex = 6;
            this.mbtn_ThongKe.Text = "Thống kê";
            this.mbtn_ThongKe.UseVisualStyleBackColor = true;
            this.mbtn_ThongKe.Click += new System.EventHandler(this.mbtn_ThongKe_Click);
            // 
            // mtbNguoiPheDuyet
            // 
            this.mtbNguoiPheDuyet.Location = new System.Drawing.Point(603, 135);
            this.mtbNguoiPheDuyet.Name = "mtbNguoiPheDuyet";
            this.mtbNguoiPheDuyet.sColumnName = null;
            this.mtbNguoiPheDuyet.Size = new System.Drawing.Size(200, 22);
            this.mtbNguoiPheDuyet.TabIndex = 5;
            this.mtbNguoiPheDuyet.Text = "Tran Van A";
            // 
            // mlb_BaoCaoTinhHinh
            // 
            this.mlb_BaoCaoTinhHinh.AutoSize = true;
            this.mlb_BaoCaoTinhHinh.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mlb_BaoCaoTinhHinh.Location = new System.Drawing.Point(218, 35);
            this.mlb_BaoCaoTinhHinh.Name = "mlb_BaoCaoTinhHinh";
            this.mlb_BaoCaoTinhHinh.sColumnName = null;
            this.mlb_BaoCaoTinhHinh.Size = new System.Drawing.Size(449, 30);
            this.mlb_BaoCaoTinhHinh.TabIndex = 15;
            this.mlb_BaoCaoTinhHinh.Text = "BÁO CÁO TÌNH HÌNH SỬ DỤNG HỢP ĐỒNG";
            // 
            // mde_NgayBatDau
            // 
            this.mde_NgayBatDau.EditValue = new System.DateTime(2022, 3, 15, 16, 50, 6, 16);
            this.mde_NgayBatDau.Location = new System.Drawing.Point(181, 80);
            this.mde_NgayBatDau.Name = "mde_NgayBatDau";
            this.mde_NgayBatDau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mde_NgayBatDau.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mde_NgayBatDau.sColumnName = null;
            this.mde_NgayBatDau.Size = new System.Drawing.Size(200, 20);
            this.mde_NgayBatDau.TabIndex = 0;
            // 
            // mde_NgayKetthuc
            // 
            this.mde_NgayKetthuc.EditValue = new System.DateTime(2022, 3, 11, 11, 1, 22, 0);
            this.mde_NgayKetthuc.Location = new System.Drawing.Point(603, 80);
            this.mde_NgayKetthuc.Name = "mde_NgayKetthuc";
            this.mde_NgayKetthuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mde_NgayKetthuc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mde_NgayKetthuc.sColumnName = null;
            this.mde_NgayKetthuc.Size = new System.Drawing.Size(200, 20);
            this.mde_NgayKetthuc.TabIndex = 1;
            // 
            // mPanel1
            // 
            this.mPanel1.Controls.Add(this.mcb_LoaiHopDong);
            this.mPanel1.Controls.Add(this.mcb_LoaiBox);
            this.mPanel1.Controls.Add(this.mde_NgayKetthuc);
            this.mPanel1.Controls.Add(this.mde_NgayBatDau);
            this.mPanel1.Controls.Add(this.mlb_BaoCaoTinhHinh);
            this.mPanel1.Controls.Add(this.mtbNguoiPheDuyet);
            this.mPanel1.Controls.Add(this.mbtn_ThongKe);
            this.mPanel1.Controls.Add(this.mtbNguoiLapBieu);
            this.mPanel1.Controls.Add(this.mbtn_InBaoCao);
            this.mPanel1.Controls.Add(this.mlb_LoaiHopDong);
            this.mPanel1.Controls.Add(this.mlb_LoaiBox);
            this.mPanel1.Controls.Add(this.mlb_NgayKetThuc);
            this.mPanel1.Controls.Add(this.mbtn_Thoat);
            this.mPanel1.Controls.Add(this.mlbNgayBatDau);
            this.mPanel1.Controls.Add(this.mlNhanVien);
            this.mPanel1.Controls.Add(this.mlb_NguoiKiemSoat);
            this.mPanel1.Controls.Add(this.mlb_NguoiLap);
            this.mPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mPanel1.Location = new System.Drawing.Point(0, 0);
            this.mPanel1.Name = "mPanel1";
            this.mPanel1.sColumnName = null;
            this.mPanel1.Size = new System.Drawing.Size(884, 212);
            this.mPanel1.TabIndex = 1;
            // 
            // mcb_LoaiHopDong
            // 
            this.mcb_LoaiHopDong.FormattingEnabled = true;
            this.mcb_LoaiHopDong.Items.AddRange(new object[] {
            "Tất cả",
            "Hợp đồng active",
            "Hợp đồng inactive"});
            this.mcb_LoaiHopDong.Location = new System.Drawing.Point(603, 108);
            this.mcb_LoaiHopDong.Name = "mcb_LoaiHopDong";
            this.mcb_LoaiHopDong.sColumnName = null;
            this.mcb_LoaiHopDong.Size = new System.Drawing.Size(200, 21);
            this.mcb_LoaiHopDong.TabIndex = 3;
            this.mcb_LoaiHopDong.Text = "Tất cả";
            // 
            // mcb_LoaiBox
            // 
            this.mcb_LoaiBox.FormattingEnabled = true;
            this.mcb_LoaiBox.Items.AddRange(new object[] {
            "Tất cả",
            "50x300x400",
            "100x300x400",
            "200x300x400"});
            this.mcb_LoaiBox.Location = new System.Drawing.Point(181, 108);
            this.mcb_LoaiBox.Name = "mcb_LoaiBox";
            this.mcb_LoaiBox.sColumnName = null;
            this.mcb_LoaiBox.Size = new System.Drawing.Size(200, 21);
            this.mcb_LoaiBox.TabIndex = 2;
            this.mcb_LoaiBox.Text = "Tất cả";
            // 
            // mlb_LoaiHopDong
            // 
            this.mlb_LoaiHopDong.Location = new System.Drawing.Point(503, 108);
            this.mlb_LoaiHopDong.Name = "mlb_LoaiHopDong";
            this.mlb_LoaiHopDong.sColumnName = null;
            this.mlb_LoaiHopDong.Size = new System.Drawing.Size(100, 20);
            this.mlb_LoaiHopDong.TabIndex = 13;
            this.mlb_LoaiHopDong.Text = "Loại hợp đồng";
            this.mlb_LoaiHopDong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mlb_LoaiBox
            // 
            this.mlb_LoaiBox.Location = new System.Drawing.Point(81, 107);
            this.mlb_LoaiBox.Name = "mlb_LoaiBox";
            this.mlb_LoaiBox.sColumnName = null;
            this.mlb_LoaiBox.Size = new System.Drawing.Size(100, 20);
            this.mlb_LoaiBox.TabIndex = 11;
            this.mlb_LoaiBox.Text = "Loại box";
            this.mlb_LoaiBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mdgv_BaoCaoTinhHinhSuDungHopDong
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mdgv_BaoCaoTinhHinhSuDungHopDong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.mdgv_BaoCaoTinhHinhSuDungHopDong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mdgv_BaoCaoTinhHinhSuDungHopDong.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.mdgv_BaoCaoTinhHinhSuDungHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mdgv_BaoCaoTinhHinhSuDungHopDong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.mdgv_BaoCaoTinhHinhSuDungHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdgv_BaoCaoTinhHinhSuDungHopDong.Location = new System.Drawing.Point(0, 212);
            this.mdgv_BaoCaoTinhHinhSuDungHopDong.Name = "mdgv_BaoCaoTinhHinhSuDungHopDong";
            this.mdgv_BaoCaoTinhHinhSuDungHopDong.ReadOnly = true;
            this.mdgv_BaoCaoTinhHinhSuDungHopDong.RowHeadersWidth = 20;
            this.mdgv_BaoCaoTinhHinhSuDungHopDong.sColumnName = null;
            this.mdgv_BaoCaoTinhHinhSuDungHopDong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mdgv_BaoCaoTinhHinhSuDungHopDong.Size = new System.Drawing.Size(884, 269);
            this.mdgv_BaoCaoTinhHinhSuDungHopDong.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Mã hợp đồng";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 271;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Ngày bắt đầu";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 271;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "Ngày kết thúc";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 270;
            // 
            // f5BaoCaoHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "f5BaoCaoHopDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo tình hình sử dụng hợp đồng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.f5BaoCaoHopDong_FormClosed);
            this.Load += new System.EventHandler(this.f5BaoCaoHopDong_Load);
            this.mpMainContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayBatDau.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayBatDau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayKetthuc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mde_NgayKetthuc.Properties)).EndInit();
            this.mPanel1.ResumeLayout(false);
            this.mPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdgv_BaoCaoTinhHinhSuDungHopDong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MComponent.MPanel mPanel1;
        private MComponent.MDateEdit mde_NgayKetthuc;
        private MComponent.MDateEdit mde_NgayBatDau;
        private MComponent.MLabel mlb_BaoCaoTinhHinh;
        private MComponent.MTextBox mtbNguoiPheDuyet;
        private MComponent.MButton mbtn_ThongKe;
        private MComponent.MTextBox mtbNguoiLapBieu;
        private MComponent.MButton mbtn_InBaoCao;
        private MComponent.MLabel mlb_NgayKetThuc;
        private MComponent.MButton mbtn_Thoat;
        private MComponent.MLabel mlbNgayBatDau;
        private MComponent.MLabel mlNhanVien;
        private MComponent.MLabel mlb_NguoiKiemSoat;
        private MComponent.MLabel mlb_NguoiLap;
        private MComponent.MDataGridView mdgv_BaoCaoTinhHinhSuDungHopDong;
        private MComponent.MComboBox mcb_LoaiHopDong;
        private MComponent.MComboBox mcb_LoaiBox;
        private MComponent.MLabel mlb_LoaiHopDong;
        private MComponent.MLabel mlb_LoaiBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;

    }
}