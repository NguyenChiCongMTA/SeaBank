namespace SafeControl
{
    partial class fConnect
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
            this.mtbDatabase = new SafeControl.MComponent.MTextBox(this.components);
            this.mtbServer = new SafeControl.MComponent.MTextBox(this.components);
            this.mtbPassword = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel1 = new SafeControl.MComponent.MLabel(this.components);
            this.mLabel2 = new SafeControl.MComponent.MLabel(this.components);
            this.mLabel3 = new SafeControl.MComponent.MLabel(this.components);
            this.mbtTestConnect = new SafeControl.MComponent.MButton(this.components);
            this.mbtLuuKetNoi = new SafeControl.MComponent.MButton(this.components);
            this.mlbTrangThaiKetNoi = new SafeControl.MComponent.MLabel(this.components);
            this.mpMainContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // mpMainContext
            // 
            this.mpMainContext.Controls.Add(this.mlbTrangThaiKetNoi);
            this.mpMainContext.Controls.Add(this.mbtLuuKetNoi);
            this.mpMainContext.Controls.Add(this.mbtTestConnect);
            this.mpMainContext.Controls.Add(this.mLabel3);
            this.mpMainContext.Controls.Add(this.mLabel2);
            this.mpMainContext.Controls.Add(this.mLabel1);
            this.mpMainContext.Controls.Add(this.mtbPassword);
            this.mpMainContext.Controls.Add(this.mtbServer);
            this.mpMainContext.Controls.Add(this.mtbDatabase);
            // 
            // mtbDatabase
            // 
            this.mtbDatabase.Location = new System.Drawing.Point(156, 22);
            this.mtbDatabase.Name = "mtbDatabase";
            this.mtbDatabase.sColumnName = null;
            this.mtbDatabase.Size = new System.Drawing.Size(328, 22);
            this.mtbDatabase.TabIndex = 0;
            this.mtbDatabase.Text = "D:\\database\\safecontrol.FDB";
            // 
            // mtbServer
            // 
            this.mtbServer.Location = new System.Drawing.Point(156, 60);
            this.mtbServer.Name = "mtbServer";
            this.mtbServer.sColumnName = null;
            this.mtbServer.Size = new System.Drawing.Size(328, 22);
            this.mtbServer.TabIndex = 0;
            this.mtbServer.Text = "BELA";
            // 
            // mtbPassword
            // 
            this.mtbPassword.Location = new System.Drawing.Point(156, 98);
            this.mtbPassword.Name = "mtbPassword";
            this.mtbPassword.sColumnName = null;
            this.mtbPassword.Size = new System.Drawing.Size(328, 22);
            this.mtbPassword.TabIndex = 0;
            this.mtbPassword.Text = "123";
            // 
            // mLabel1
            // 
            this.mLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mLabel1.Location = new System.Drawing.Point(50, 25);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.sColumnName = null;
            this.mLabel1.Size = new System.Drawing.Size(100, 23);
            this.mLabel1.TabIndex = 1;
            this.mLabel1.Text = "Database";
            // 
            // mLabel2
            // 
            this.mLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mLabel2.Location = new System.Drawing.Point(50, 63);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.sColumnName = null;
            this.mLabel2.Size = new System.Drawing.Size(100, 23);
            this.mLabel2.TabIndex = 1;
            this.mLabel2.Text = "Server";
            // 
            // mLabel3
            // 
            this.mLabel3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mLabel3.Location = new System.Drawing.Point(50, 101);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.sColumnName = null;
            this.mLabel3.Size = new System.Drawing.Size(100, 23);
            this.mLabel3.TabIndex = 1;
            this.mLabel3.Text = "Pass";
            // 
            // mbtTestConnect
            // 
            this.mbtTestConnect.Location = new System.Drawing.Point(123, 172);
            this.mbtTestConnect.Name = "mbtTestConnect";
            this.mbtTestConnect.sColumnName = null;
            this.mbtTestConnect.Size = new System.Drawing.Size(95, 23);
            this.mbtTestConnect.TabIndex = 2;
            this.mbtTestConnect.Text = "Test connect";
            this.mbtTestConnect.UseVisualStyleBackColor = true;
            this.mbtTestConnect.Click += new System.EventHandler(this.mbtTestConnect_Click);
            // 
            // mbtLuuKetNoi
            // 
            this.mbtLuuKetNoi.Location = new System.Drawing.Point(273, 172);
            this.mbtLuuKetNoi.Name = "mbtLuuKetNoi";
            this.mbtLuuKetNoi.sColumnName = null;
            this.mbtLuuKetNoi.Size = new System.Drawing.Size(107, 23);
            this.mbtLuuKetNoi.TabIndex = 2;
            this.mbtLuuKetNoi.Text = "Lưu kết nối";
            this.mbtLuuKetNoi.UseVisualStyleBackColor = true;
            this.mbtLuuKetNoi.Click += new System.EventHandler(this.mbtLuuKetNoi_Click);
            // 
            // mlbTrangThaiKetNoi
            // 
            this.mlbTrangThaiKetNoi.Location = new System.Drawing.Point(212, 135);
            this.mlbTrangThaiKetNoi.Name = "mlbTrangThaiKetNoi";
            this.mlbTrangThaiKetNoi.sColumnName = null;
            this.mlbTrangThaiKetNoi.Size = new System.Drawing.Size(272, 23);
            this.mlbTrangThaiKetNoi.TabIndex = 3;
            this.mlbTrangThaiKetNoi.Text = "Trạng thái:";
            // 
            // fConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 302);
            this.Name = "fConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm tra kết nối cơ sở dữ liệu";
            this.mpMainContext.ResumeLayout(false);
            this.mpMainContext.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MComponent.MTextBox mtbDatabase;
        private MComponent.MButton mbtLuuKetNoi;
        private MComponent.MButton mbtTestConnect;
        private MComponent.MLabel mLabel3;
        private MComponent.MLabel mLabel2;
        private MComponent.MLabel mLabel1;
        private MComponent.MTextBox mtbPassword;
        private MComponent.MTextBox mtbServer;
        private MComponent.MLabel mlbTrangThaiKetNoi;
    }
}