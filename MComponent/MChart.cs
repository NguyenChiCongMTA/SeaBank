using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace SafeControl.MComponent
{
    [ToolboxItem(true)]
    /// <summary>
    /// Khởi tạo Component
    /// CreateBy: truongnm 05.11.2018
    /// </summary>
    public partial class MChart : Chart
    {
        public MChart()
        {
            InitializeComponent();
            //
            InitComponent();
            //
        }

        public MChart(IContainer container)
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
        private Point? clickPosition = null;
        private Point? prevPosition = null;
        //
        private int numberOfZoom = 0;
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
            this.Palette = ChartColorPalette.Grayscale;
            //
            // Đăng ký event ở đây
            //
            this.MouseMove -= mChart_MouseMove; this.MouseMove += mChart_MouseMove;
            this.MouseClick -= mChart_MouseClick; this.MouseClick += mChart_MouseClick;
            this.MouseWheel -= mChart_MouseWheel; this.MouseWheel += mChart_MouseWheel; 
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
        /// Hàm vẽ dữ liệu
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        public void PlotData(string sSeriesName, double[] dox, double[] doy)
        {
            this.Series[sSeriesName].Points.DataBindXY(dox, doy);
        }
        /// <summary>
        /// Hàm vẽ dữ liệu
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        public void PlotData(string sSeriesName, float[] dox, float[] doy)
        {
            this.Series[sSeriesName].Points.DataBindXY(dox, doy);
        }
        /// <summary>
        /// Hàm Edit hệ trục tọa độ
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        public void EditCoordinateAxes(string sSeriesName, string sChartAreasName, 
            string sTitleX, double dDauX, double dCuoiX, double dIntervalX, 
            string sTitleY, double dDauY, double dCuoiY, double dIntervalY)
        {
            this.ChartAreas[sChartAreasName].AxisX.Minimum = dDauX;
            this.ChartAreas[sChartAreasName].AxisX.Maximum = dCuoiX;
            this.ChartAreas[sChartAreasName].AxisY.Minimum = dDauY;
            this.ChartAreas[sChartAreasName].AxisY.Maximum = dCuoiY;
            this.ChartAreas[sChartAreasName].AxisX.Title = sTitleX;
            this.ChartAreas[sChartAreasName].AxisY.Title = sTitleY;
            this.ChartAreas[sChartAreasName].AxisX.Interval = dIntervalX;
            this.ChartAreas[sChartAreasName].AxisY.Interval = dIntervalY;
            // ---------------------------
            this.Series[sSeriesName].ChartType = SeriesChartType.Column;
            this.Series[sSeriesName].IsVisibleInLegend = false;
            this.Series[sSeriesName].IsXValueIndexed = false;
            // Bỏ Grid
            this.ChartAreas[sChartAreasName].AxisX.MajorGrid.Enabled = false;
            this.ChartAreas[sChartAreasName].AxisY.MajorGrid.Enabled = false;
            // Bỏ đánh dấu chia khoảng
            this.ChartAreas[sChartAreasName].AxisX.MajorTickMark.Enabled = false;
            this.ChartAreas[sChartAreasName].AxisY.MajorTickMark.Enabled = false;
            // Bỏ label 2 trục X,Y
            this.ChartAreas[sChartAreasName].AxisX.Enabled = AxisEnabled.False;
            this.ChartAreas[sChartAreasName].AxisY.Enabled = AxisEnabled.False;
            //
            this.ChartAreas[sChartAreasName].AxisX.LineColor = Color.Black;
            this.ChartAreas[sChartAreasName].AxisY.LineColor = Color.Black;
            this.ChartAreas[sChartAreasName].AxisX.LabelStyle.ForeColor = Color.Black;
            this.ChartAreas[sChartAreasName].AxisY.LabelStyle.ForeColor = Color.Black;
            this.ChartAreas[sChartAreasName].AxisX.LabelStyle.Enabled = true;
            this.ChartAreas[sChartAreasName].AxisY.LabelStyle.Enabled = true;
            this.ChartAreas[sChartAreasName].AxisX.LabelStyle.IsEndLabelVisible = true;
            this.ChartAreas[sChartAreasName].AxisX.TitleForeColor = Color.Black;
            this.ChartAreas[sChartAreasName].AxisY.TitleForeColor = Color.Black;
            // Zoom
            this.ChartAreas[sChartAreasName].AxisX.ScaleView.Zoomable = true;
            this.ChartAreas[sChartAreasName].AxisY.ScaleView.Zoomable = true;
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Override
        /// <summary>
        /// Hàm đưa chuột qua biểu đồ
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        protected virtual void Command_MouseMove(object sender, MouseEventArgs e)
        { 
            // Add code here:
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            //
            prevPosition = pos;
            var results = this.HitTest(pos.X, pos.Y, false,
                                         ChartElementType.PlottingArea);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.PlottingArea)
                {
                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    //
                    //MessageBox.Show("x: " + xVal.ToString("F4") + "; y: " + yVal.ToString("F4"));
                }
            }
        }
        /// <summary>
        /// Hàm click chuột xuống biểu đồ
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        protected virtual void Command_MouseClick(object sender, MouseEventArgs e)
        {
            // Add code here:
            var pos = e.Location;
            clickPosition = pos;
            var results = this.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.PlottingArea);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.PlottingArea)
                {
                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    //
                    MessageBox.Show("x: " + xVal.ToString("F4") + "; y: " + yVal.ToString("F4"));
                }
            }
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Event
        /// <summary>
        /// Hàm đưa chuột qua biểu đồ
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        private void mChart_MouseMove(object sender, MouseEventArgs e)
        {
            Command_MouseMove(sender, e);
        }
        /// <summary>
        /// Hàm click chuột xuống biểu đồ
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        private void mChart_MouseClick(object sender, MouseEventArgs e)
        {
            Command_MouseClick(sender, e);
        }
        /// <summary>
        /// Hàm zoom in - zoom out bieu do
        /// CreateBy: truongnm 14.08.2019
        /// </summary>
        private void mChart_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                var chart = (Chart)sender;
                var xAxis = chart.ChartAreas[0].AxisX;
                var yAxis = chart.ChartAreas[0].AxisY;
                //
                var xMin = xAxis.ScaleView.ViewMinimum;
                var xMax = xAxis.ScaleView.ViewMaximum;
                var yMin = yAxis.ScaleView.ViewMinimum;
                var yMax = yAxis.ScaleView.ViewMaximum;
                //
                int IntervalX = 3;
                int IntervalY = 3;
                //
                if (e.Delta < 0 && numberOfZoom > 0) // Scrolled down.
                {
                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - IntervalX * 2 / Math.Pow(2, numberOfZoom);
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + IntervalX * 2 / Math.Pow(2, numberOfZoom);
                    //
                    var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - IntervalY * 2 / Math.Pow(2, numberOfZoom);
                    var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + IntervalY * 2 / Math.Pow(2, numberOfZoom);
                    //
                    if (posXStart < 0) posXStart = 0;
                    if (posYStart < 0) posYStart = 0;
                    //
                    if (posXFinish > xAxis.Maximum) posXFinish = xAxis.Maximum;
                    if (posYFinish > yAxis.Maximum) posYFinish = yAxis.Maximum;
                    //
                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);
                    //
                    numberOfZoom--;
                }
                else if (e.Delta < 0 && numberOfZoom == 0) // Last Scrolled down.
                {
                    xAxis.ScaleView.ZoomReset();
                    yAxis.ScaleView.ZoomReset();
                }
                else if (e.Delta > 0) // Scrolled up.
                {
                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - IntervalX * 2 / Math.Pow(2, numberOfZoom);
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + IntervalX * 2 / Math.Pow(2, numberOfZoom);
                    //
                    var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - IntervalY * 2 / Math.Pow(2, numberOfZoom);
                    var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + IntervalY * 2 / Math.Pow(2, numberOfZoom);
                    //
                    if (posXStart < 0) posXStart = 0;
                    if (posYStart < 0) posYStart = 0;
                    if (posXFinish > xAxis.Maximum) posXFinish = xAxis.Maximum;
                    if (posYFinish > yAxis.Maximum) posYFinish = yAxis.Maximum;
                    //
                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);
                    //
                    numberOfZoom++;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
    }
}
