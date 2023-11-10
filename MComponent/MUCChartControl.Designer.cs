namespace SafeControl.MComponent
{
    partial class MUCChartControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            this.mChartControl = new SafeControl.MComponent.MChartControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            this.SuspendLayout();
            // 
            // mChartControl
            // 
            this.mChartControl.sColumnName = null;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.EnableAxisXScrolling = true;
            xyDiagram1.EnableAxisXZooming = true;
            xyDiagram1.EnableAxisYScrolling = true;
            xyDiagram1.EnableAxisYZooming = true;
            this.mChartControl.Diagram = xyDiagram1;
            this.mChartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mChartControl.Legend.Name = "Default Legend";
            this.mChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.mChartControl.Location = new System.Drawing.Point(0, 0);
            this.mChartControl.Name = "mChartControl";
            series1.Name = "seriesBar";
            this.mChartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.mChartControl.Size = new System.Drawing.Size(150, 150);
            this.mChartControl.TabIndex = 0;
            // 
            // MUCChartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mChartControl);
            this.Name = "MUCChartControl";
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mChartControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public MChartControl mChartControl;



    }
}
