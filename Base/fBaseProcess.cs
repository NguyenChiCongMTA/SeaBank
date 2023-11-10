using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using SafeControl.Dictionary;

namespace SafeControl
{
    public partial class fBaseProcess : fBase
    {
        public fBaseProcess()
        {
            InitializeComponent();
            //
            oStopwatch = new Stopwatch();
            //
            mbw_Main.WorkerSupportsCancellation = true;
            mbw_Main.WorkerReportsProgress = true;
            //
            // Đăng ký Event ở đây
            // CreateBy: truongnm 06.02.2021
            //
            mbw_Main.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mbw_Main_RunWorkerCompleted);
            mbw_Main.DoWork += new DoWorkEventHandler(mbw_Main_DoWork);
            mbw_Main.ProgressChanged += new ProgressChangedEventHandler(mbw_Main_ProgressChanged);
        }
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Declare
        public Stopwatch oStopwatch;
        #endregion
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Xử lý bất đồng bộ
        /// CreateBy: truongnm 24-05-2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Command_DoWork(object sender, DoWorkEventArgs e)
        {
            // Add code here:
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;// Capture the BackgroundWorker that fired the event
            object[] arrObjects = (object[])e.Argument;// Collect the array of objects the we recived from the main thread
            //
            if (sendingWorker.CancellationPending)// At each iteration of the loop, check if there is a cancellation request pending 
            {
                e.Cancel = true;// If a cancellation request is pending,assgine this flag a value of true
                return;
            }
            //
            oStopwatch.Reset();
            oStopwatch.Start();
            this.mcpMainProcess.Invoke((Action)(() => this.mcpMainProcess.Visible = true));
            this.mlblSumTime.Invoke((Action)(() => this.mlblSumTime.Visible = true));
            //
        }
        /// <summary>
        /// Xử lý khi chạy xong
        /// CreateBy: truongnm 24-05-2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Command_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Add code here:
            if (!e.Cancelled && e.Error == null)//Check if the worker has been cancelled or if an error occured
            {
                MMessageBox.Information("Đã xong");
            }
            else if (e.Cancelled)
            {
                MMessageBox.Warning("Đã dừng");
            }
            else
            {
                MMessageBox.Error(e.Error.Message);
            }
            oStopwatch.Stop();
            MMessageBox.Information(oStopwatch.ElapsedMilliseconds.ToString());
            //
        }
        /// <summary>
        /// Xử lý báo cáo khi đang chạy
        /// CreateBy: truongnm 24-05-2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Command_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Add code here:

        }
        /// <summary>
        /// Cancel xử lý
        /// CreateBy: truongnm 19-01-2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void CancelDoWork()
        {
            if (mbw_Main.IsBusy)
                mbw_Main.CancelAsync();
            //
            while (mbw_Main.IsBusy)
                Application.DoEvents();
            mbw_Main.CancelAsync();
        }
        /// <summary>
        /// Run xử lý bất đồng bộ
        /// CreateBy: truongnm 19-01-2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void RunDoWork()
        {
            CancelDoWork();
            //
            this.mbw_Main.RunWorkerAsync();
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Override
        /// <summary>
        /// Hàm InitForm
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public override void InitForm()
        {
            base.InitForm();
        }
        /// <summary>
        /// Hàm InitData
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public override void InitData()
        {
            base.InitData();
        }
        /// <summary>
        /// Hàm LoadData
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public override void LoadData()
        {
            base.LoadData();
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Event
        /// <summary>
        /// Sự kiện Xử lý bất đồng bộ
        /// CreateBy: truongnm 19-01-2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbw_Main_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Command_DoWork(sender, e);
        }
        /// <summary>
        /// Sự kiện Xử lý bất đồng bộ
        /// CreateBy: truongnm 19-01-2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbw_Main_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Command_ProgressChanged(sender, e);
        }
        /// <summary>
        /// Sự kiện khi hoàn thành
        /// CreateBy: truongnm 24.05.2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbw_Main_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Command_RunWorkerCompleted(sender, e);
        }
        #endregion
    }
}