namespace SafeControl
{
    partial class fBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBase));
            this.mpMainContext = new SafeControl.MComponent.MPanel(this.components);
            this.mpMainBot = new SafeControl.MComponent.MPanel(this.components);
            this.mflpAddress = new SafeControl.MComponent.MFlowLayoutPanel(this.components);
            this.mLabel1 = new SafeControl.MComponent.MLabel(this.components);
            this.mlblSumTime = new SafeControl.MComponent.MLabel(this.components);
            this.mcpMainProcess = new SafeControl.MComponent.MCircularProgress(this.components);
            this.mpMainTop = new SafeControl.MComponent.MPanel(this.components);
            this.mflpDataBaseInfo = new SafeControl.MComponent.MFlowLayoutPanel(this.components);
            this.mllRefreshDataBase = new SafeControl.MComponent.MLinkLabel(this.components);
            this.mlblDataBaseInfor = new SafeControl.MComponent.MLabel(this.components);
            this.mllPhienBan = new SafeControl.MComponent.MLinkLabel(this.components);
            this.mpMainBot.SuspendLayout();
            this.mflpAddress.SuspendLayout();
            this.mpMainTop.SuspendLayout();
            this.mflpDataBaseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // mpMainContext
            // 
            this.mpMainContext.BackColor = System.Drawing.Color.White;
            this.mpMainContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mpMainContext.Location = new System.Drawing.Point(0, 40);
            this.mpMainContext.Margin = new System.Windows.Forms.Padding(2);
            this.mpMainContext.Name = "mpMainContext";
            this.mpMainContext.sColumnName = null;
            this.mpMainContext.Size = new System.Drawing.Size(516, 222);
            this.mpMainContext.TabIndex = 2;
            // 
            // mpMainBot
            // 
            this.mpMainBot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mpMainBot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mpMainBot.BackgroundImage")));
            this.mpMainBot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mpMainBot.Controls.Add(this.mflpAddress);
            this.mpMainBot.Controls.Add(this.mlblSumTime);
            this.mpMainBot.Controls.Add(this.mcpMainProcess);
            this.mpMainBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mpMainBot.Location = new System.Drawing.Point(0, 262);
            this.mpMainBot.Margin = new System.Windows.Forms.Padding(2);
            this.mpMainBot.Name = "mpMainBot";
            this.mpMainBot.sColumnName = null;
            this.mpMainBot.Size = new System.Drawing.Size(516, 40);
            this.mpMainBot.TabIndex = 1;
            // 
            // mflpAddress
            // 
            this.mflpAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mflpAddress.BackColor = System.Drawing.Color.Transparent;
            this.mflpAddress.Controls.Add(this.mLabel1);
            this.mflpAddress.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.mflpAddress.Location = new System.Drawing.Point(131, 18);
            this.mflpAddress.Name = "mflpAddress";
            this.mflpAddress.sColumnName = null;
            this.mflpAddress.Size = new System.Drawing.Size(380, 20);
            this.mflpAddress.TabIndex = 0;
            // 
            // mLabel1
            // 
            this.mLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mLabel1.AutoSize = true;
            this.mLabel1.BackColor = System.Drawing.Color.Transparent;
            this.mLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.mLabel1.ForeColor = System.Drawing.Color.Blue;
            this.mLabel1.Location = new System.Drawing.Point(16, 0);
            this.mLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.sColumnName = null;
            this.mLabel1.Size = new System.Drawing.Size(362, 13);
            this.mLabel1.TabIndex = 3;
            this.mLabel1.Text = "Address: 198 Trần Quang Khải, P. Lý Thái Tổ, Q. Hoàn Kiếm, Tp. Hà Nội";
            this.mLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mlblSumTime
            // 
            this.mlblSumTime.BackColor = System.Drawing.Color.Transparent;
            this.mlblSumTime.Location = new System.Drawing.Point(33, 14);
            this.mlblSumTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mlblSumTime.Name = "mlblSumTime";
            this.mlblSumTime.sColumnName = null;
            this.mlblSumTime.Size = new System.Drawing.Size(80, 13);
            this.mlblSumTime.TabIndex = 2;
            this.mlblSumTime.Text = "ms";
            this.mlblSumTime.Visible = false;
            // 
            // mcpMainProcess
            // 
            this.mcpMainProcess.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.mcpMainProcess.BackgroundStyle.Class = "";
            this.mcpMainProcess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.mcpMainProcess.IsRunning = true;
            this.mcpMainProcess.Location = new System.Drawing.Point(8, 12);
            this.mcpMainProcess.Margin = new System.Windows.Forms.Padding(2);
            this.mcpMainProcess.Name = "mcpMainProcess";
            this.mcpMainProcess.sColumnName = null;
            this.mcpMainProcess.Size = new System.Drawing.Size(20, 17);
            this.mcpMainProcess.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.mcpMainProcess.TabIndex = 1;
            this.mcpMainProcess.Visible = false;
            // 
            // mpMainTop
            // 
            this.mpMainTop.BackColor = System.Drawing.Color.Transparent;
            this.mpMainTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mpMainTop.BackgroundImage")));
            this.mpMainTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mpMainTop.Controls.Add(this.mflpDataBaseInfo);
            this.mpMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.mpMainTop.Location = new System.Drawing.Point(0, 0);
            this.mpMainTop.Margin = new System.Windows.Forms.Padding(2);
            this.mpMainTop.Name = "mpMainTop";
            this.mpMainTop.sColumnName = null;
            this.mpMainTop.Size = new System.Drawing.Size(516, 40);
            this.mpMainTop.TabIndex = 0;
            // 
            // mflpDataBaseInfo
            // 
            this.mflpDataBaseInfo.Controls.Add(this.mllRefreshDataBase);
            this.mflpDataBaseInfo.Controls.Add(this.mlblDataBaseInfor);
            this.mflpDataBaseInfo.Controls.Add(this.mllPhienBan);
            this.mflpDataBaseInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mflpDataBaseInfo.Location = new System.Drawing.Point(0, 12);
            this.mflpDataBaseInfo.Name = "mflpDataBaseInfo";
            this.mflpDataBaseInfo.sColumnName = null;
            this.mflpDataBaseInfo.Size = new System.Drawing.Size(516, 28);
            this.mflpDataBaseInfo.TabIndex = 0;
            // 
            // mllRefreshDataBase
            // 
            this.mllRefreshDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mllRefreshDataBase.AutoSize = true;
            this.mllRefreshDataBase.Location = new System.Drawing.Point(3, 0);
            this.mllRefreshDataBase.Name = "mllRefreshDataBase";
            this.mllRefreshDataBase.sColumnName = null;
            this.mllRefreshDataBase.Size = new System.Drawing.Size(43, 13);
            this.mllRefreshDataBase.TabIndex = 5;
            this.mllRefreshDataBase.TabStop = true;
            this.mllRefreshDataBase.Text = "refresh";
            this.mllRefreshDataBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mllRefreshDataBase.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mllRefreshDataBase_LinkClicked_1);
            // 
            // mlblDataBaseInfor
            // 
            this.mlblDataBaseInfor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mlblDataBaseInfor.AutoSize = true;
            this.mlblDataBaseInfor.BackColor = System.Drawing.Color.Transparent;
            this.mlblDataBaseInfor.ForeColor = System.Drawing.Color.Gray;
            this.mlblDataBaseInfor.Location = new System.Drawing.Point(51, 0);
            this.mlblDataBaseInfor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mlblDataBaseInfor.Name = "mlblDataBaseInfor";
            this.mlblDataBaseInfor.sColumnName = null;
            this.mlblDataBaseInfor.Size = new System.Drawing.Size(85, 13);
            this.mlblDataBaseInfor.TabIndex = 4;
            this.mlblDataBaseInfor.Text = "[DataBaseInfor]";
            this.mlblDataBaseInfor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mllPhienBan
            // 
            this.mllPhienBan.ActiveLinkColor = System.Drawing.Color.Red;
            this.mllPhienBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mllPhienBan.AutoSize = true;
            this.mllPhienBan.LinkColor = System.Drawing.Color.Red;
            this.mllPhienBan.Location = new System.Drawing.Point(141, 0);
            this.mllPhienBan.Name = "mllPhienBan";
            this.mllPhienBan.sColumnName = null;
            this.mllPhienBan.Size = new System.Drawing.Size(61, 13);
            this.mllPhienBan.TabIndex = 7;
            this.mllPhienBan.TabStop = true;
            this.mllPhienBan.Text = "[PhienBan]";
            this.mllPhienBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 302);
            this.Controls.Add(this.mpMainContext);
            this.Controls.Add(this.mpMainBot);
            this.Controls.Add(this.mpMainTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fBase";
            this.Text = "fBase";
            this.mpMainBot.ResumeLayout(false);
            this.mflpAddress.ResumeLayout(false);
            this.mflpAddress.PerformLayout();
            this.mpMainTop.ResumeLayout(false);
            this.mflpDataBaseInfo.ResumeLayout(false);
            this.mflpDataBaseInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal MComponent.MPanel mpMainTop;
        public MComponent.MPanel mpMainContext;
        internal MComponent.MLabel mlblSumTime;
        internal MComponent.MCircularProgress mcpMainProcess;
        internal MComponent.MPanel mpMainBot;
        internal MComponent.MLabel mLabel1;
        internal MComponent.MLabel mlblDataBaseInfor;
        internal MComponent.MLinkLabel mllRefreshDataBase;
        private MComponent.MFlowLayoutPanel mflpDataBaseInfo;
        private MComponent.MFlowLayoutPanel mflpAddress;
        internal MComponent.MLinkLabel mllPhienBan;

    }
}