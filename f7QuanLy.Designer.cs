namespace SafeControl
{
    partial class f7QuanLy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mlb_BaoCaoTinhHinh = new SafeControl.MComponent.MLabel(this.components);
            this.mbt_Them = new SafeControl.MComponent.MButton(this.components);
            this.mlNhanVien = new SafeControl.MComponent.MLabel(this.components);
            this.mdgv_QuanLyTK = new SafeControl.MComponent.MDataGridView(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mPanel1 = new SafeControl.MComponent.MPanel(this.components);
            this.mtb_name = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel3 = new SafeControl.MComponent.MLabel(this.components);
            this.mtb_pass = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel2 = new SafeControl.MComponent.MLabel(this.components);
            this.mtb_user = new SafeControl.MComponent.MTextBox(this.components);
            this.mlb_NguoiLap = new SafeControl.MComponent.MLabel(this.components);
            this.mbt_Xoa = new SafeControl.MComponent.MButton(this.components);
            this.mtb_Huy = new SafeControl.MComponent.MButton(this.components);
            this.mbt_Luu = new SafeControl.MComponent.MButton(this.components);
            this.mbtnPersonPermission = new SafeControl.MComponent.MButton(this.components);
            this.mpMainContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdgv_QuanLyTK)).BeginInit();
            this.mPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mpMainContext
            // 
            this.mpMainContext.Controls.Add(this.mdgv_QuanLyTK);
            this.mpMainContext.Controls.Add(this.mPanel1);
            this.mpMainContext.Size = new System.Drawing.Size(889, 424);
            // 
            // mlb_BaoCaoTinhHinh
            // 
            this.mlb_BaoCaoTinhHinh.AutoSize = true;
            this.mlb_BaoCaoTinhHinh.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mlb_BaoCaoTinhHinh.Location = new System.Drawing.Point(352, 27);
            this.mlb_BaoCaoTinhHinh.Name = "mlb_BaoCaoTinhHinh";
            this.mlb_BaoCaoTinhHinh.sColumnName = null;
            this.mlb_BaoCaoTinhHinh.Size = new System.Drawing.Size(188, 30);
            this.mlb_BaoCaoTinhHinh.TabIndex = 15;
            this.mlb_BaoCaoTinhHinh.Text = "Quản lý tài khoản";
            // 
            // mbt_Them
            // 
            this.mbt_Them.Location = new System.Drawing.Point(223, 195);
            this.mbt_Them.Name = "mbt_Them";
            this.mbt_Them.sColumnName = null;
            this.mbt_Them.Size = new System.Drawing.Size(75, 20);
            this.mbt_Them.TabIndex = 3;
            this.mbt_Them.Text = "Thêm";
            this.mbt_Them.UseVisualStyleBackColor = true;
            this.mbt_Them.Click += new System.EventHandler(this.mbt_Them_Click);
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
            // mdgv_QuanLyTK
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mdgv_QuanLyTK.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.mdgv_QuanLyTK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mdgv_QuanLyTK.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mdgv_QuanLyTK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.mdgv_QuanLyTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mdgv_QuanLyTK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.mdgv_QuanLyTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdgv_QuanLyTK.Location = new System.Drawing.Point(0, 243);
            this.mdgv_QuanLyTK.MultiSelect = false;
            this.mdgv_QuanLyTK.Name = "mdgv_QuanLyTK";
            this.mdgv_QuanLyTK.ReadOnly = true;
            this.mdgv_QuanLyTK.RowHeadersWidth = 20;
            this.mdgv_QuanLyTK.sColumnName = null;
            this.mdgv_QuanLyTK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mdgv_QuanLyTK.Size = new System.Drawing.Size(889, 181);
            this.mdgv_QuanLyTK.TabIndex = 2;
            this.mdgv_QuanLyTK.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mdgv_QuanLyTK_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.HeaderText = "User";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column3.HeaderText = "Password";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column4.HeaderText = "Tên người dùng";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // mPanel1
            // 
            this.mPanel1.Controls.Add(this.mbtnPersonPermission);
            this.mPanel1.Controls.Add(this.mtb_name);
            this.mPanel1.Controls.Add(this.mLabel3);
            this.mPanel1.Controls.Add(this.mtb_pass);
            this.mPanel1.Controls.Add(this.mLabel2);
            this.mPanel1.Controls.Add(this.mtb_user);
            this.mPanel1.Controls.Add(this.mlb_NguoiLap);
            this.mPanel1.Controls.Add(this.mlb_BaoCaoTinhHinh);
            this.mPanel1.Controls.Add(this.mbt_Xoa);
            this.mPanel1.Controls.Add(this.mtb_Huy);
            this.mPanel1.Controls.Add(this.mbt_Luu);
            this.mPanel1.Controls.Add(this.mbt_Them);
            this.mPanel1.Controls.Add(this.mlNhanVien);
            this.mPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mPanel1.Location = new System.Drawing.Point(0, 0);
            this.mPanel1.Name = "mPanel1";
            this.mPanel1.sColumnName = null;
            this.mPanel1.Size = new System.Drawing.Size(889, 243);
            this.mPanel1.TabIndex = 3;
            // 
            // mtb_name
            // 
            this.mtb_name.Enabled = false;
            this.mtb_name.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtb_name.Location = new System.Drawing.Point(394, 137);
            this.mtb_name.Name = "mtb_name";
            this.mtb_name.sColumnName = null;
            this.mtb_name.Size = new System.Drawing.Size(200, 22);
            this.mtb_name.TabIndex = 2;
            // 
            // mLabel3
            // 
            this.mLabel3.Location = new System.Drawing.Point(294, 134);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.sColumnName = null;
            this.mLabel3.Size = new System.Drawing.Size(100, 20);
            this.mLabel3.TabIndex = 18;
            this.mLabel3.Text = "Tên người dùng";
            this.mLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mtb_pass
            // 
            this.mtb_pass.Enabled = false;
            this.mtb_pass.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtb_pass.Location = new System.Drawing.Point(394, 109);
            this.mtb_pass.Name = "mtb_pass";
            this.mtb_pass.sColumnName = null;
            this.mtb_pass.Size = new System.Drawing.Size(200, 22);
            this.mtb_pass.TabIndex = 1;
            this.mtb_pass.UseSystemPasswordChar = true;
            // 
            // mLabel2
            // 
            this.mLabel2.Location = new System.Drawing.Point(294, 106);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.sColumnName = null;
            this.mLabel2.Size = new System.Drawing.Size(100, 20);
            this.mLabel2.TabIndex = 18;
            this.mLabel2.Text = "Password";
            this.mLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mtb_user
            // 
            this.mtb_user.Enabled = false;
            this.mtb_user.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtb_user.Location = new System.Drawing.Point(394, 81);
            this.mtb_user.Name = "mtb_user";
            this.mtb_user.sColumnName = null;
            this.mtb_user.Size = new System.Drawing.Size(200, 22);
            this.mtb_user.TabIndex = 0;
            // 
            // mlb_NguoiLap
            // 
            this.mlb_NguoiLap.Location = new System.Drawing.Point(294, 78);
            this.mlb_NguoiLap.Name = "mlb_NguoiLap";
            this.mlb_NguoiLap.sColumnName = null;
            this.mlb_NguoiLap.Size = new System.Drawing.Size(100, 20);
            this.mlb_NguoiLap.TabIndex = 18;
            this.mlb_NguoiLap.Text = "User";
            this.mlb_NguoiLap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mbt_Xoa
            // 
            this.mbt_Xoa.Location = new System.Drawing.Point(499, 195);
            this.mbt_Xoa.Name = "mbt_Xoa";
            this.mbt_Xoa.sColumnName = null;
            this.mbt_Xoa.Size = new System.Drawing.Size(75, 20);
            this.mbt_Xoa.TabIndex = 5;
            this.mbt_Xoa.Text = "Xóa";
            this.mbt_Xoa.UseVisualStyleBackColor = true;
            this.mbt_Xoa.Click += new System.EventHandler(this.mbt_Xoa_Click);
            // 
            // mtb_Huy
            // 
            this.mtb_Huy.Location = new System.Drawing.Point(407, 195);
            this.mtb_Huy.Name = "mtb_Huy";
            this.mtb_Huy.sColumnName = null;
            this.mtb_Huy.Size = new System.Drawing.Size(75, 20);
            this.mtb_Huy.TabIndex = 4;
            this.mtb_Huy.Text = "Hủy";
            this.mtb_Huy.UseVisualStyleBackColor = true;
            this.mtb_Huy.Click += new System.EventHandler(this.mtb_Huy_Click);
            // 
            // mbt_Luu
            // 
            this.mbt_Luu.Location = new System.Drawing.Point(315, 195);
            this.mbt_Luu.Name = "mbt_Luu";
            this.mbt_Luu.sColumnName = null;
            this.mbt_Luu.Size = new System.Drawing.Size(75, 20);
            this.mbt_Luu.TabIndex = 4;
            this.mbt_Luu.Text = "Sửa";
            this.mbt_Luu.UseVisualStyleBackColor = true;
            this.mbt_Luu.Click += new System.EventHandler(this.mbt_Luu_Click);
            // 
            // mbtnPersonPermission
            // 
            this.mbtnPersonPermission.Location = new System.Drawing.Point(590, 195);
            this.mbtnPersonPermission.Name = "mbtnPersonPermission";
            this.mbtnPersonPermission.sColumnName = null;
            this.mbtnPersonPermission.Size = new System.Drawing.Size(84, 20);
            this.mbtnPersonPermission.TabIndex = 19;
            this.mbtnPersonPermission.Text = "Phân quyền";
            this.mbtnPersonPermission.UseVisualStyleBackColor = true;
            this.mbtnPersonPermission.Click += new System.EventHandler(this.mbtnPersonPermission_Click);
            // 
            // f7QuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 504);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "f7QuanLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ TÀI KHOẢN";
            this.Load += new System.EventHandler(this.f7QuanLy_Load);
            this.mpMainContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mdgv_QuanLyTK)).EndInit();
            this.mPanel1.ResumeLayout(false);
            this.mPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MComponent.MDataGridView mdgv_QuanLyTK;
        private MComponent.MPanel mPanel1;
        private MComponent.MLabel mlb_BaoCaoTinhHinh;
        private MComponent.MButton mbt_Xoa;
        private MComponent.MButton mbt_Them;
        private MComponent.MLabel mlNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private MComponent.MButton mbt_Luu;
        private MComponent.MTextBox mtb_name;
        private MComponent.MLabel mLabel3;
        private MComponent.MTextBox mtb_pass;
        private MComponent.MLabel mLabel2;
        private MComponent.MTextBox mtb_user;
        private MComponent.MLabel mlb_NguoiLap;
        private MComponent.MButton mtb_Huy;
        private MComponent.MButton mbtnPersonPermission;
    }
}