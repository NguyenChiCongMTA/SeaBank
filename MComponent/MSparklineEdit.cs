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

namespace SafeControl.MComponent
{
    [ToolboxItem(true)]
    /// <summary>
    /// Khởi tạo Component
    /// CreateBy: truongnm 05.11.2018
    /// </summary>
    public partial class MSparklineEdit : SparklineEdit
    {
        public MSparklineEdit()
        {
            InitializeComponent();
            //
            InitComponent();
            //
        }

        public MSparklineEdit(IContainer container)
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
            //
            // Đăng ký event ở đây
            //
            this.MouseMove -= mSparklineEdit_MouseMove; this.MouseMove += mSparklineEdit_MouseMove;
            this.MouseClick -= mSparklineEdit_MouseClick; this.MouseClick += mSparklineEdit_MouseClick;
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
        public void PlotData(double[] dox)
        {
            this.Data = dox;
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
            
        }
        /// <summary>
        /// Hàm click chuột xuống biểu đồ
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        protected virtual void Command_MouseClick(object sender, MouseEventArgs e)
        {
            // Add code here:
            
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Event
        /// <summary>
        /// Hàm đưa chuột qua biểu đồ
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        private void mSparklineEdit_MouseMove(object sender, MouseEventArgs e)
        {
            Command_MouseMove(sender, e);
        }
        /// <summary>
        /// Hàm click chuột xuống biểu đồ
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        private void mSparklineEdit_MouseClick(object sender, MouseEventArgs e)
        {
            Command_MouseClick(sender, e);
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
    }
}
