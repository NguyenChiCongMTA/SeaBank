namespace SafeControl
{
    partial class f0HomeLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f0HomeLogin));
            this.mLabel1 = new SafeControl.MComponent.MLabel(this.components);
            this.mtbTaiKhoan = new SafeControl.MComponent.MTextBox(this.components);
            this.mtbMatKhau = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel2 = new SafeControl.MComponent.MLabel(this.components);
            this.mPictureBox1 = new SafeControl.MComponent.MPictureBox(this.components);
            this.mbtDangNhap = new SafeControl.MComponent.MButton(this.components);
            this.mcbNhoMatKhau = new SafeControl.MComponent.MCheckBox(this.components);
            this.mLabel3 = new SafeControl.MComponent.MLabel(this.components);
            this.mtbMaNganHang = new SafeControl.MComponent.MTextBox(this.components);
            this.mpMainContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mpMainContext
            // 
            this.mpMainContext.Controls.Add(this.mcbNhoMatKhau);
            this.mpMainContext.Controls.Add(this.mbtDangNhap);
            this.mpMainContext.Controls.Add(this.mPictureBox1);
            this.mpMainContext.Controls.Add(this.mtbMatKhau);
            this.mpMainContext.Controls.Add(this.mLabel2);
            this.mpMainContext.Controls.Add(this.mtbMaNganHang);
            this.mpMainContext.Controls.Add(this.mLabel3);
            this.mpMainContext.Controls.Add(this.mtbTaiKhoan);
            this.mpMainContext.Controls.Add(this.mLabel1);
            this.mpMainContext.Margin = new System.Windows.Forms.Padding(1);
            this.mpMainContext.Size = new System.Drawing.Size(472, 207);
            this.mpMainContext.TabIndex = 0;
            // 
            // mLabel1
            // 
            this.mLabel1.AutoSize = true;
            this.mLabel1.Location = new System.Drawing.Point(29, 71);
            this.mLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.sColumnName = null;
            this.mLabel1.Size = new System.Drawing.Size(57, 13);
            this.mLabel1.TabIndex = 6;
            this.mLabel1.Text = "Tài khoản";
            // 
            // mtbTaiKhoan
            // 
            this.mtbTaiKhoan.Location = new System.Drawing.Point(124, 68);
            this.mtbTaiKhoan.Margin = new System.Windows.Forms.Padding(2);
            this.mtbTaiKhoan.Name = "mtbTaiKhoan";
            this.mtbTaiKhoan.sColumnName = null;
            this.mtbTaiKhoan.Size = new System.Drawing.Size(123, 22);
            this.mtbTaiKhoan.TabIndex = 1;
            // 
            // mtbMatKhau
            // 
            this.mtbMatKhau.Location = new System.Drawing.Point(124, 97);
            this.mtbMatKhau.Margin = new System.Windows.Forms.Padding(2);
            this.mtbMatKhau.Name = "mtbMatKhau";
            this.mtbMatKhau.sColumnName = null;
            this.mtbMatKhau.Size = new System.Drawing.Size(123, 22);
            this.mtbMatKhau.TabIndex = 2;
            this.mtbMatKhau.UseSystemPasswordChar = true;
            // 
            // mLabel2
            // 
            this.mLabel2.AutoSize = true;
            this.mLabel2.Location = new System.Drawing.Point(29, 103);
            this.mLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.sColumnName = null;
            this.mLabel2.Size = new System.Drawing.Size(56, 13);
            this.mLabel2.TabIndex = 7;
            this.mLabel2.Text = "Mật khẩu";
            // 
            // mPictureBox1
            // 
            this.mPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("mPictureBox1.Image")));
            this.mPictureBox1.Location = new System.Drawing.Point(281, 4);
            this.mPictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.mPictureBox1.Name = "mPictureBox1";
            this.mPictureBox1.sColumnName = null;
            this.mPictureBox1.Size = new System.Drawing.Size(185, 199);
            this.mPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mPictureBox1.TabIndex = 4;
            this.mPictureBox1.TabStop = false;
            // 
            // mbtDangNhap
            // 
            this.mbtDangNhap.Location = new System.Drawing.Point(134, 147);
            this.mbtDangNhap.Margin = new System.Windows.Forms.Padding(2);
            this.mbtDangNhap.Name = "mbtDangNhap";
            this.mbtDangNhap.sColumnName = null;
            this.mbtDangNhap.Size = new System.Drawing.Size(75, 20);
            this.mbtDangNhap.TabIndex = 4;
            this.mbtDangNhap.Text = "Đăng nhập";
            this.mbtDangNhap.UseVisualStyleBackColor = true;
            this.mbtDangNhap.Click += new System.EventHandler(this.mbtDangNhap_Click);
            // 
            // mcbNhoMatKhau
            // 
            this.mcbNhoMatKhau.AutoSize = true;
            this.mcbNhoMatKhau.Checked = true;
            this.mcbNhoMatKhau.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mcbNhoMatKhau.Location = new System.Drawing.Point(148, 124);
            this.mcbNhoMatKhau.Name = "mcbNhoMatKhau";
            this.mcbNhoMatKhau.sColumnName = null;
            this.mcbNhoMatKhau.Size = new System.Drawing.Size(99, 17);
            this.mcbNhoMatKhau.TabIndex = 3;
            this.mcbNhoMatKhau.Text = "Nhớ mật khẩu";
            this.mcbNhoMatKhau.UseVisualStyleBackColor = true;
            // 
            // mLabel3
            // 
            this.mLabel3.AutoSize = true;
            this.mLabel3.Location = new System.Drawing.Point(28, 42);
            this.mLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.sColumnName = null;
            this.mLabel3.Size = new System.Drawing.Size(83, 13);
            this.mLabel3.TabIndex = 5;
            this.mLabel3.Text = "Mã ngân hàng";
            // 
            // mtbMaNganHang
            // 
            this.mtbMaNganHang.Location = new System.Drawing.Point(124, 39);
            this.mtbMaNganHang.Margin = new System.Windows.Forms.Padding(2);
            this.mtbMaNganHang.Name = "mtbMaNganHang";
            this.mtbMaNganHang.sColumnName = null;
            this.mtbMaNganHang.Size = new System.Drawing.Size(123, 22);
            this.mtbMaNganHang.TabIndex = 0;
            // 
            // f0HomeLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 287);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.Name = "f0HomeLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fHomeLogin_FormClosed);
            this.Load += new System.EventHandler(this.fHomeLogin_Load);
            this.mpMainContext.ResumeLayout(false);
            this.mpMainContext.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SafeControl.MComponent.MTextBox mtbMatKhau;
        private SafeControl.MComponent.MLabel mLabel2;
        private SafeControl.MComponent.MTextBox mtbTaiKhoan;
        private SafeControl.MComponent.MLabel mLabel1;
        private MComponent.MButton mbtDangNhap;
        private MComponent.MPictureBox mPictureBox1;
        private MComponent.MCheckBox mcbNhoMatKhau;
        private MComponent.MTextBox mtbMaNganHang;
        private MComponent.MLabel mLabel3;
    }
}