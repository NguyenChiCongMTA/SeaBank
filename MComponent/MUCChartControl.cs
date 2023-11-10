using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraCharts;

namespace SafeControl.MComponent
{
    public partial class MUCChartControl : MUCBase
    {
        /// <summary>
        /// Khởi tạo usercontrol
        /// CreateBy: truongnm 16.08.2019
        /// </summary>
        public MUCChartControl()
        {
            InitializeComponent();
            //
            // Đăng ký event ở đây
            //
            mChartControl.ObjectHotTracked += new HotTrackEventHandler(OnChartControlObjectHotTracked);
            mChartControl.ObjectSelected += new HotTrackEventHandler(OnChartControlObjectSelected);
        }
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        #region Declare
        public Series seriesSelected = null;
        public SeriesPoint pointSelected = null;
        protected object selectedAnotherObject = null;
        //
        protected bool SeriesSelection { get { return true; } }
        //
        public EventHandler CallBackUI { set; get; }
        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm xử lý update các thông tin từ Chart sang UI
        /// CreateBy: truongnm 15.08.2019
        /// </summary>
        public void UpdateControls()
        {
            // Add code here:
            if (seriesSelected != null && CallBackUI != null)
                CallBackUI(null, null);
            //
        }
        /// <summary>
        /// Hàm vẽ dữ liệu khi có 1 trục (trục kia lấy tự động tăng theo thứ tự từ 1)
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        public void PlotData(double[] data)
        {
            mChartControl.PlotData(data);
        }
        /// <summary>
        /// Hàm vẽ dữ liệu khi có 2 trục
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        public void PlotData(double[] dox, double[] doy)
        {
            mChartControl.PlotData(dox,doy);
        }
        /// <summary>
        /// Hàm vẽ dữ liệu khi có 2 trục
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        public void PlotData(DateTime[] dox, double[] doy)
        {
            mChartControl.PlotData(dox, doy);
        }
        /// <summary>
        /// Hàm RestoreView
        /// CreateBy: truongnm 14.08.2019
        /// </summary>
        public void RestoreView()
        {
            mChartControl.RestoreView();
        }
        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        #region Override
        /// <summary>
        /// Hàm load form
        /// CreateBy: truongnm 16.08.2019
        /// </summary>
        public override void Command_LoadForm()
        {
            base.Command_LoadForm();
        }
        /// <summary>
        /// Hàm khởi tạo form
        /// CreateBy: truongnm 16.08.2019
        /// </summary>
        protected override void InitForm()
        {
            base.InitForm();
        }
        /// <summary>
        /// Hàm khởi tạo dữ liệu form
        /// CreateBy: truongnm 16.08.2019
        /// </summary>
        protected override void InitData()
        {
            base.InitData();
        }
        /// <summary>
        /// Hàm load dữ liệu form
        /// CreateBy: truongnm 16.08.2019
        /// </summary>
        protected override void LoadData()
        {
            base.LoadData();
        }
        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        #region Event
        private bool AllowSelectAnotherObject(object obj)
        {
            return false;
        }
        private void OnChartControlObjectHotTracked(object sender, HotTrackEventArgs e)
        {
            if (e.Object is Series)
                e.Cancel = !SeriesSelection;
            else
                e.Cancel = !AllowSelectAnotherObject(e.Object);
        }
        private void OnChartControlObjectSelected(object sender, HotTrackEventArgs e)
        {
            if (e.Object is Series)
            {
                e.Cancel = !SeriesSelection;
                if (SeriesSelection)
                {
                    this.seriesSelected = (Series)e.Object;
                    this.pointSelected = e.AdditionalObject as SeriesPoint;
                }
            }
            else
            {
                if (AllowSelectAnotherObject(e.Object))
                {
                    this.selectedAnotherObject = e.Object;
                    e.Cancel = false;
                }
                else
                {
                    this.selectedAnotherObject = null;
                    e.Cancel = true;
                    mChartControl.ClearSelection(false);
                }
                if (SeriesSelection)
                {
                    this.seriesSelected = null;
                    this.pointSelected = null;
                }
            }
            UpdateControls();
        }
        
        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
    }
}
