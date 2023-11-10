namespace SafeControl
{
    partial class f9LietKeGiaoDich
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
            this.mscMain = new SafeControl.MComponent.MSplitContainer(this.components);
            this.mgcData = new SafeControl.MComponent.MGridControl();
            this.mpControlData = new SafeControl.MComponent.MPanel(this.components);
            this.mLabel4 = new SafeControl.MComponent.MLabel(this.components);
            this.mdeDenNgay = new SafeControl.MComponent.MDateEdit(this.components);
            this.mLabel3 = new SafeControl.MComponent.MLabel(this.components);
            this.mdeTuNgay = new SafeControl.MComponent.MDateEdit(this.components);
            this.mbtnIn = new SafeControl.MComponent.MButton(this.components);
            this.mLabel2 = new SafeControl.MComponent.MLabel(this.components);
            this.mbtnTim = new SafeControl.MComponent.MButton(this.components);
            this.mlbTuNgay = new SafeControl.MComponent.MLabel(this.components);
            this.mLabel1 = new SafeControl.MComponent.MLabel(this.components);
            this.mpMainContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mscMain)).BeginInit();
            this.mscMain.Panel2.SuspendLayout();
            this.mscMain.SuspendLayout();
            this.mpControlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdeDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdeDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdeTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdeTuNgay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mpMainContext
            // 
            this.mpMainContext.Controls.Add(this.mscMain);
            this.mpMainContext.Margin = new System.Windows.Forms.Padding(1);
            this.mpMainContext.Size = new System.Drawing.Size(806, 462);
            // 
            // mscMain
            // 
            this.mscMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mscMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mscMain.Location = new System.Drawing.Point(0, 0);
            this.mscMain.Margin = new System.Windows.Forms.Padding(2);
            this.mscMain.Name = "mscMain";
            this.mscMain.Panel1Collapsed = true;
            // 
            // mscMain.Panel2
            // 
            this.mscMain.Panel2.Controls.Add(this.mgcData);
            this.mscMain.Panel2.Controls.Add(this.mpControlData);
            this.mscMain.sColumnName = null;
            this.mscMain.Size = new System.Drawing.Size(806, 462);
            this.mscMain.SplitterDistance = 25;
            this.mscMain.SplitterWidth = 3;
            this.mscMain.TabIndex = 0;
            // 
            // mgcData
            // 
            this.mgcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mgcData.Location = new System.Drawing.Point(0, 36);
            this.mgcData.Name = "mgcData";
            this.mgcData.Size = new System.Drawing.Size(806, 426);
            this.mgcData.TabIndex = 2;
            // 
            // mpControlData
            // 
            this.mpControlData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mpControlData.Controls.Add(this.mLabel4);
            this.mpControlData.Controls.Add(this.mdeDenNgay);
            this.mpControlData.Controls.Add(this.mLabel3);
            this.mpControlData.Controls.Add(this.mdeTuNgay);
            this.mpControlData.Controls.Add(this.mbtnIn);
            this.mpControlData.Controls.Add(this.mLabel2);
            this.mpControlData.Controls.Add(this.mbtnTim);
            this.mpControlData.Controls.Add(this.mlbTuNgay);
            this.mpControlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.mpControlData.Location = new System.Drawing.Point(0, 0);
            this.mpControlData.Margin = new System.Windows.Forms.Padding(2);
            this.mpControlData.Name = "mpControlData";
            this.mpControlData.sColumnName = null;
            this.mpControlData.Size = new System.Drawing.Size(806, 36);
            this.mpControlData.TabIndex = 1;
            // 
            // mLabel4
            // 
            this.mLabel4.Location = new System.Drawing.Point(167, 6);
            this.mLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.sColumnName = null;
            this.mLabel4.Size = new System.Drawing.Size(60, 20);
            this.mLabel4.TabIndex = 22;
            this.mLabel4.Text = "Từ ngày";
            this.mLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mdeDenNgay
            // 
            this.mdeDenNgay.EditValue = null;
            this.mdeDenNgay.Location = new System.Drawing.Point(400, 6);
            this.mdeDenNgay.Name = "mdeDenNgay";
            this.mdeDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mdeDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mdeDenNgay.sColumnName = null;
            this.mdeDenNgay.Size = new System.Drawing.Size(100, 20);
            this.mdeDenNgay.TabIndex = 21;
            // 
            // mLabel3
            // 
            this.mLabel3.Location = new System.Drawing.Point(335, 6);
            this.mLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.sColumnName = null;
            this.mLabel3.Size = new System.Drawing.Size(60, 20);
            this.mLabel3.TabIndex = 20;
            this.mLabel3.Text = "Đến ngày";
            this.mLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mdeTuNgay
            // 
            this.mdeTuNgay.EditValue = null;
            this.mdeTuNgay.Location = new System.Drawing.Point(232, 6);
            this.mdeTuNgay.Name = "mdeTuNgay";
            this.mdeTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mdeTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mdeTuNgay.sColumnName = null;
            this.mdeTuNgay.Size = new System.Drawing.Size(100, 20);
            this.mdeTuNgay.TabIndex = 19;
            // 
            // mbtnIn
            // 
            this.mbtnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mbtnIn.Location = new System.Drawing.Point(722, 6);
            this.mbtnIn.Name = "mbtnIn";
            this.mbtnIn.sColumnName = null;
            this.mbtnIn.Size = new System.Drawing.Size(75, 23);
            this.mbtnIn.TabIndex = 16;
            this.mbtnIn.Text = "In";
            this.mbtnIn.UseVisualStyleBackColor = true;
            this.mbtnIn.Click += new System.EventHandler(this.mbtnIn_Click);
            // 
            // mLabel2
            // 
            this.mLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mLabel2.Location = new System.Drawing.Point(640, 7);
            this.mLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.sColumnName = null;
            this.mLabel2.Size = new System.Drawing.Size(79, 20);
            this.mLabel2.TabIndex = 15;
            this.mLabel2.Text = "(Enter để tìm)";
            this.mLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mbtnTim
            // 
            this.mbtnTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mbtnTim.Location = new System.Drawing.Point(561, 6);
            this.mbtnTim.Name = "mbtnTim";
            this.mbtnTim.sColumnName = null;
            this.mbtnTim.Size = new System.Drawing.Size(75, 23);
            this.mbtnTim.TabIndex = 9;
            this.mbtnTim.Text = "Tìm";
            this.mbtnTim.UseVisualStyleBackColor = true;
            this.mbtnTim.Click += new System.EventHandler(this.mbtnTim_Click);
            // 
            // mlbTuNgay
            // 
            this.mlbTuNgay.Location = new System.Drawing.Point(3, 6);
            this.mlbTuNgay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mlbTuNgay.Name = "mlbTuNgay";
            this.mlbTuNgay.sColumnName = null;
            this.mlbTuNgay.Size = new System.Drawing.Size(153, 20);
            this.mlbTuNgay.TabIndex = 5;
            this.mlbTuNgay.Text = "Liệt kê giao dịch trong ngày";
            this.mlbTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mLabel1
            // 
            this.mLabel1.Location = new System.Drawing.Point(266, 6);
            this.mLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.sColumnName = null;
            this.mLabel1.Size = new System.Drawing.Size(60, 20);
            this.mLabel1.TabIndex = 18;
            this.mLabel1.Text = "/ Từ ngày";
            this.mLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // f9LietKeGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 542);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "f9LietKeGiaoDich";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LIỆT KÊ GIAO DỊCH TRONG NGÀY";
            this.mpMainContext.ResumeLayout(false);
            this.mscMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mscMain)).EndInit();
            this.mscMain.ResumeLayout(false);
            this.mpControlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mdeDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdeDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdeTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdeTuNgay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MComponent.MSplitContainer mscMain;
        private MComponent.MPanel mpControlData;
        private MComponent.MLabel mlbTuNgay;
        private MComponent.MButton mbtnTim;
        private MComponent.MLabel mLabel2;
        private MComponent.MButton mbtnIn;
        private MComponent.MGridControl mgcData;
        private MComponent.MDateEdit mdeDenNgay;
        private MComponent.MLabel mLabel3;
        private MComponent.MDateEdit mdeTuNgay;
        private MComponent.MLabel mLabel1;
        private MComponent.MLabel mLabel4;
    }
}