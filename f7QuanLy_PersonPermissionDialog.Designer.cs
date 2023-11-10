namespace SafeControl
{
    partial class f7QuanLy_PersonPermissionDialog
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
            this.mgc_PersonHistoryLog = new SafeControl.MComponent.MGridControl();
            this.mscDataContext = new SafeControl.MComponent.MSplitContainer(this.components);
            this.mbtnThem = new SafeControl.MComponent.MButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).BeginInit();
            this.msc_Context.Panel2.SuspendLayout();
            this.msc_Context.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mscDataContext)).BeginInit();
            this.mscDataContext.Panel1.SuspendLayout();
            this.mscDataContext.Panel2.SuspendLayout();
            this.mscDataContext.SuspendLayout();
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
            this.msc_Context.Panel2.Controls.Add(this.mscDataContext);
            this.msc_Context.Size = new System.Drawing.Size(669, 395);
            // 
            // mgc_PersonHistoryLog
            // 
            this.mgc_PersonHistoryLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mgc_PersonHistoryLog.Location = new System.Drawing.Point(0, 0);
            this.mgc_PersonHistoryLog.Name = "mgc_PersonHistoryLog";
            this.mgc_PersonHistoryLog.Size = new System.Drawing.Size(669, 312);
            this.mgc_PersonHistoryLog.TabIndex = 0;
            // 
            // mscDataContext
            // 
            this.mscDataContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mscDataContext.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mscDataContext.Location = new System.Drawing.Point(0, 0);
            this.mscDataContext.Name = "mscDataContext";
            this.mscDataContext.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mscDataContext.Panel1
            // 
            this.mscDataContext.Panel1.Controls.Add(this.mbtnThem);
            // 
            // mscDataContext.Panel2
            // 
            this.mscDataContext.Panel2.Controls.Add(this.mgc_PersonHistoryLog);
            this.mscDataContext.sColumnName = null;
            this.mscDataContext.Size = new System.Drawing.Size(669, 345);
            this.mscDataContext.SplitterDistance = 29;
            this.mscDataContext.TabIndex = 1;
            // 
            // mbtnThem
            // 
            this.mbtnThem.Location = new System.Drawing.Point(591, 3);
            this.mbtnThem.Name = "mbtnThem";
            this.mbtnThem.sColumnName = null;
            this.mbtnThem.Size = new System.Drawing.Size(75, 23);
            this.mbtnThem.TabIndex = 0;
            this.mbtnThem.Text = "Thêm";
            this.mbtnThem.UseVisualStyleBackColor = true;
            // 
            // f7QuanLy_PersonPermissionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 423);
            this.Name = "f7QuanLy_PersonPermissionDialog";
            this.Text = "PersonPermission";
            this.msc_Context.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).EndInit();
            this.msc_Context.ResumeLayout(false);
            this.mscDataContext.Panel1.ResumeLayout(false);
            this.mscDataContext.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mscDataContext)).EndInit();
            this.mscDataContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MComponent.MGridControl mgc_PersonHistoryLog;
        private MComponent.MSplitContainer mscDataContext;
        private MComponent.MButton mbtnThem;


    }
}