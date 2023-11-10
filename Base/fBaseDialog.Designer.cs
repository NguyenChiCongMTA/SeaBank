namespace SafeControl.Base
{
    partial class fBaseDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBaseDialog));
            this.msc_Context = new SafeControl.MComponent.MSplitContainer(this.components);
            this.mlb_TieuDe = new SafeControl.MComponent.MLabel(this.components);
            this.mpBottom = new SafeControl.MComponent.MPanel(this.components);
            this.mlblSumTime = new SafeControl.MComponent.MLabel(this.components);
            this.mcpMainProcess = new SafeControl.MComponent.MCircularProgress(this.components);
            this.mb_Thoat = new SafeControl.MComponent.MButton(this.components);
            this.mb_ChapNhan = new SafeControl.MComponent.MButton(this.components);
            this.mbw_Main = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialogBase = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogBase = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogBase = new System.Windows.Forms.SaveFileDialog();
            this.lblPhienBan = new SafeControl.MComponent.MLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).BeginInit();
            this.msc_Context.Panel1.SuspendLayout();
            this.msc_Context.SuspendLayout();
            this.mpBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // msc_Context
            // 
            this.msc_Context.BackColor = System.Drawing.SystemColors.Control;
            this.msc_Context.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msc_Context.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.msc_Context.Location = new System.Drawing.Point(0, 0);
            this.msc_Context.Name = "msc_Context";
            this.msc_Context.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // msc_Context.Panel1
            // 
            this.msc_Context.Panel1.Controls.Add(this.mlb_TieuDe);
            // 
            // msc_Context.Panel2
            // 
            this.msc_Context.Panel2.AutoScroll = true;
            this.msc_Context.sColumnName = null;
            this.msc_Context.Size = new System.Drawing.Size(430, 263);
            this.msc_Context.SplitterDistance = 46;
            this.msc_Context.TabIndex = 1;
            // 
            // mlb_TieuDe
            // 
            this.mlb_TieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlb_TieuDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mlb_TieuDe.Location = new System.Drawing.Point(0, 0);
            this.mlb_TieuDe.Name = "mlb_TieuDe";
            this.mlb_TieuDe.sColumnName = null;
            this.mlb_TieuDe.Size = new System.Drawing.Size(430, 46);
            this.mlb_TieuDe.TabIndex = 2;
            this.mlb_TieuDe.Text = "Tiêu đề";
            this.mlb_TieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mpBottom
            // 
            this.mpBottom.BackColor = System.Drawing.SystemColors.Control;
            this.mpBottom.Controls.Add(this.lblPhienBan);
            this.mpBottom.Controls.Add(this.mlblSumTime);
            this.mpBottom.Controls.Add(this.mcpMainProcess);
            this.mpBottom.Controls.Add(this.mb_Thoat);
            this.mpBottom.Controls.Add(this.mb_ChapNhan);
            this.mpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mpBottom.Location = new System.Drawing.Point(0, 263);
            this.mpBottom.Name = "mpBottom";
            this.mpBottom.sColumnName = null;
            this.mpBottom.Size = new System.Drawing.Size(430, 28);
            this.mpBottom.TabIndex = 0;
            // 
            // mlblSumTime
            // 
            this.mlblSumTime.BackColor = System.Drawing.Color.Transparent;
            this.mlblSumTime.Location = new System.Drawing.Point(31, 4);
            this.mlblSumTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mlblSumTime.Name = "mlblSumTime";
            this.mlblSumTime.sColumnName = null;
            this.mlblSumTime.Size = new System.Drawing.Size(64, 20);
            this.mlblSumTime.TabIndex = 3;
            this.mlblSumTime.Text = "ms";
            this.mlblSumTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mlblSumTime.Visible = false;
            // 
            // mcpMainProcess
            // 
            // 
            // 
            // 
            this.mcpMainProcess.BackgroundStyle.Class = "";
            this.mcpMainProcess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.mcpMainProcess.IsRunning = true;
            this.mcpMainProcess.Location = new System.Drawing.Point(3, 4);
            this.mcpMainProcess.Name = "mcpMainProcess";
            this.mcpMainProcess.sColumnName = null;
            this.mcpMainProcess.Size = new System.Drawing.Size(20, 20);
            this.mcpMainProcess.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.mcpMainProcess.TabIndex = 2;
            // 
            // mb_Thoat
            // 
            this.mb_Thoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mb_Thoat.Location = new System.Drawing.Point(350, 3);
            this.mb_Thoat.Name = "mb_Thoat";
            this.mb_Thoat.sColumnName = null;
            this.mb_Thoat.Size = new System.Drawing.Size(74, 23);
            this.mb_Thoat.TabIndex = 1;
            this.mb_Thoat.Text = "Thoát";
            this.mb_Thoat.UseVisualStyleBackColor = true;
            // 
            // mb_ChapNhan
            // 
            this.mb_ChapNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mb_ChapNhan.Location = new System.Drawing.Point(276, 3);
            this.mb_ChapNhan.Name = "mb_ChapNhan";
            this.mb_ChapNhan.sColumnName = null;
            this.mb_ChapNhan.Size = new System.Drawing.Size(74, 23);
            this.mb_ChapNhan.TabIndex = 0;
            this.mb_ChapNhan.Text = "Chấp nhận";
            this.mb_ChapNhan.UseVisualStyleBackColor = true;
            // 
            // openFileDialogBase
            // 
            this.openFileDialogBase.FileName = "openFileDialog1";
            // 
            // lblPhienBan
            // 
            this.lblPhienBan.AutoSize = true;
            this.lblPhienBan.ForeColor = System.Drawing.Color.Red;
            this.lblPhienBan.Location = new System.Drawing.Point(209, 8);
            this.lblPhienBan.Name = "lblPhienBan";
            this.lblPhienBan.sColumnName = null;
            this.lblPhienBan.Size = new System.Drawing.Size(61, 13);
            this.lblPhienBan.TabIndex = 7;
            this.lblPhienBan.Text = "[PhienBan]";
            // 
            // fBaseDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(430, 291);
            this.Controls.Add(this.msc_Context);
            this.Controls.Add(this.mpBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fBaseDialog";
            this.Text = "fBaseDialog";
            this.msc_Context.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).EndInit();
            this.msc_Context.ResumeLayout(false);
            this.mpBottom.ResumeLayout(false);
            this.mpBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public SafeControl.MComponent.MPanel mpBottom;
        public SafeControl.MComponent.MSplitContainer msc_Context;
        internal SafeControl.MComponent.MCircularProgress mcpMainProcess;
        internal SafeControl.MComponent.MButton mb_Thoat;
        internal SafeControl.MComponent.MButton mb_ChapNhan;
        internal MComponent.MLabel mlb_TieuDe;
        internal System.ComponentModel.BackgroundWorker mbw_Main;
        internal MComponent.MLabel mlblSumTime;
        internal System.Windows.Forms.FolderBrowserDialog folderBrowserDialogBase;
        internal System.Windows.Forms.OpenFileDialog openFileDialogBase;
        internal System.Windows.Forms.SaveFileDialog saveFileDialogBase;
        internal MComponent.MLabel lblPhienBan;
    }
}