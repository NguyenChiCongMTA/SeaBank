namespace SafeControl
{
    partial class f8SendAPI_HistoryDialog
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
            this.mgc_PersonHistoryLog = new SafeControl.MComponent.MGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).BeginInit();
            this.msc_Context.Panel2.SuspendLayout();
            this.msc_Context.SuspendLayout();
            this.SuspendLayout();
            // 
            // mpBottom
            // 
            this.mpBottom.Location = new System.Drawing.Point(0, 395);
            this.mpBottom.Size = new System.Drawing.Size(669, 28);
            // 
            // msc_Context
            // 
            // 
            // msc_Context.Panel2
            // 
            this.msc_Context.Panel2.Controls.Add(this.mgc_PersonHistoryLog);
            this.msc_Context.Size = new System.Drawing.Size(669, 395);
            // 
            // mgc_PersonHistoryLog
            // 
            this.mgc_PersonHistoryLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mgc_PersonHistoryLog.Location = new System.Drawing.Point(0, 0);
            this.mgc_PersonHistoryLog.Name = "mgc_PersonHistoryLog";
            this.mgc_PersonHistoryLog.Size = new System.Drawing.Size(669, 345);
            this.mgc_PersonHistoryLog.TabIndex = 0;
            // 
            // f8SendAPI_HistoryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 423);
            this.Name = "f8SendAPI_HistoryDialog";
            this.Text = "History";
            this.msc_Context.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).EndInit();
            this.msc_Context.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MComponent.MGridControl mgc_PersonHistoryLog;


    }
}