using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.Sparkline;
using DevExpress.XtraCharts;

namespace SafeControl.MComponent
{
    [ToolboxItem(true)]
    /// <summary>
    /// Khởi tạo Component
    /// CreateBy: truongnm 05.11.2018
    /// </summary>
    public partial class MChartControl : ChartControl
    {
        public MChartControl()
        {
            InitializeComponent();
            //
            InitComponent();
            //
        }

        public MChartControl(IContainer container)
        {
            container.Add(this);
            //
            InitializeComponent();
            
        }
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Declare
        public string sColumnName { set; get; } // Thêm cột sColumnName EditBy: truongnm 05.11.2018
        //
        public Series sSeries = null;
        //
        public double AxisXRangeSpan; // Range trục ox
        public double AxisYRangeSpan; // Range trục oy
        //
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm khởi tạo
        /// CreateBy: truongnm 05.11.2018
        /// </summary>
        public void InitComponent()
        {
            sSeries = new Series("seriesBar", ViewType.Bar); this.Series.Add(sSeries);
            this.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False; // seriesBar - names
            //
            ((XYDiagram)this.Diagram).EnableAxisXScrolling = true;
            ((XYDiagram)this.Diagram).EnableAxisYScrolling = true;
            ((XYDiagram)this.Diagram).EnableAxisXZooming = true;
            ((XYDiagram)this.Diagram).EnableAxisYZooming = true;
            //
        }
        /// <summary>
        /// Hàm GetValue
        /// CreateBy: truongnm 05.11.2018
        /// </summary>
        public object GetValue()
        {
            return this.Text;
        }
        /// <summary>
        /// Hàm SetValue
        /// CreateBy: truongnm 05.11.2018
        /// </summary>
        public void SetValue(object value)
        {
            this.Text = value.ToString();
        }
        /// <summary>
        /// Hàm ReadOnly
        /// CreateBy: truongnm 07.05.2019
        /// </summary>
        public void SetReadOnly(bool value)
        {
            
        }
        /// <summary>
        /// Hàm vẽ dữ liệu khi có 1 trục (trục kia lấy tự động tăng theo thứ tự từ 1)
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        public void PlotData(double[] data)
        {
            this.Series[0].Points.Clear();
            //
            SeriesPoint[] SeriesPoint = new SeriesPoint[data.Length];
            //
            for (int i = 0; i < data.Length; i++)
                SeriesPoint[i] = new SeriesPoint(i + 1, data[i]);
            //
            this.Series[0].Points.AddRange(SeriesPoint);
            //
        }
        /// <summary>
        /// Hàm vẽ dữ liệu khi có 2 trục
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        public void PlotData(double[] dox, double[] doy)
        {
            this.Series[0].Points.BeginUpdate();
            this.Series[0].Points.Clear();
            this.Series[0].ArgumentScaleType = ScaleType.Auto;
            //
            SeriesPoint[] SeriesPoint = new SeriesPoint[dox.Length];
            //
            for (int i = 0; i < dox.Length; i++)
                SeriesPoint[i] = new SeriesPoint(dox[i], doy[i]);
            //
            this.Series[0].Points.AddRange(SeriesPoint);
            //
            this.Series[0].Points.EndUpdate();
        }
        /// <summary>
        /// Hàm vẽ dữ liệu khi có 2 trục
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        public void PlotData(DateTime[] dox, double[] doy)
        {
            this.Series[0].Points.BeginUpdate();
            this.Series[0].Points.Clear();
            this.Series[0].ArgumentScaleType = ScaleType.Auto;
            //
            for (int i = 0; i < dox.Length; i++)
                this.Series[0].Points.Add(new SeriesPoint(dox[i], doy[i]));
            //
            this.Series[0].Points.EndUpdate();
        }
        /// <summary>
        /// Hàm RestoreView
        /// CreateBy: truongnm 14.08.2019
        /// </summary>
        public void RestoreView()
        {
            CaculatorRangeView();
            //
            if (((XYDiagram)this.Diagram) != null)
            {
                ((XYDiagram)this.Diagram).AxisX.VisualRange.MinValue = ((XYDiagram)this.Diagram).AxisX.WholeRange.MinValue;
                ((XYDiagram)this.Diagram).AxisX.VisualRange.MaxValue = (double)((XYDiagram)this.Diagram).AxisX.WholeRange.MinValue + AxisXRangeSpan;
                ((XYDiagram)this.Diagram).AxisY.VisualRange.MinValue = ((XYDiagram)this.Diagram).AxisY.WholeRange.MinValue;
                ((XYDiagram)this.Diagram).AxisY.VisualRange.MaxValue = (double)((XYDiagram)this.Diagram).AxisY.WholeRange.MinValue + AxisYRangeSpan;
            }
        }
        /// <summary>
        /// Hàm tính các Range trục OX, OY
        /// CreateBy: truongnm 14.08.2019
        /// </summary>
        public void CaculatorRangeView()
        {
            AxisXRangeSpan = (double)((XYDiagram)this.Diagram).AxisX.WholeRange.MaxValue - (double)((XYDiagram)this.Diagram).AxisX.WholeRange.MinValue;
            AxisYRangeSpan = (double)((XYDiagram)this.Diagram).AxisY.WholeRange.MaxValue - (double)((XYDiagram)this.Diagram).AxisY.WholeRange.MinValue;    
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Override
        
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Event
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
    }
}
