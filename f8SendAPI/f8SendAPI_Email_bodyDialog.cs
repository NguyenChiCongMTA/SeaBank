using SafeControl.Base;
using SafeControl.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafeControl
{
    /// <summary>
    /// Khởi tạo form 
    /// CreateBy: truongnm 17.03.2022
    /// </summary>
    public partial class f8SendAPI_Email_bodyDialog : fBaseDialog
    {
        /// <summary>
        /// Khởi tạo form 
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public f8SendAPI_Email_bodyDialog()
        {
            InitializeComponent();
            //
            // Đăng ký event ở đây
            // CreateBy: truongnm 17.03.2022
            //
            mllChon.LinkClicked += mllChon_LinkClicked;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Declare
        public int iOption = 0; // 1: Run
        string sTempFileName = string.Empty;
        string sTempFileBase64 = string.Empty;
        public f8SendAPI_Email_body f8SendAPI_Email_body { set; get; }
        public EventHandler CallBackUI { set; get; }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm Command_Run
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_Run()
        {
            // Conver file 2 Base64
            sTempFileBase64 = MFileBase64.ToBase64String(sTempFileName);
        }
        /// <summary>
        /// Hàm Command_Run_Finish
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_Run_Finish()
        {
            file_name.Text = Path.GetFileName(sTempFileName);
            file_byte64.Text = sTempFileBase64;
            //
            f8SendAPI_Email_body.sfile_name = file_name.Text;
            f8SendAPI_Email_body.sfile_byte64 = file_byte64.Text;
        }
        /// <summary>
        /// Hàm Command_Reset_Text
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_Reset_Text() 
        {
            //
            sTempFileName = string.Empty;
            sTempFileBase64 = string.Empty;
            //
            f8SendAPI_Email_body.sfile_name = string.Empty;
            f8SendAPI_Email_body.sfile_byte64 = string.Empty;
            //
            file_name.Text = string.Empty;
            file_byte64.Text = string.Empty;
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Override
        /// <summary>
        /// Hàm Command_ChapNhan
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public override void Command_ChapNhan()
        {
            // Add code here:
            base.Command_ChapNhan();
            //
            if (CallBackUI != null)
                CallBackUI(null, null);
            //
            Command_Reset_Text();
        }
        /// <summary>
        /// Khởi tạo InitForm
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public override void InitForm()
        {
            // Add code here:
            base.InitForm();
            //
            mlb_TieuDe.Text = "Chèn " + this.Text;
            //
            file_name.ReadOnly = true;
            file_byte64.ReadOnly = true;
        }
        /// <summary>
        /// Khởi tạo InitData
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public override void InitData()
        {
            // Add code here:
            base.InitData();
        }
        /// <summary>
        /// Khởi tạo LoadData
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public override void LoadData()
        {
            // Add code here:
            base.LoadData();
        }
        /// <summary>
        /// Xử lý bất đồng bộ
        /// CreateBy: truongnm 24-05-2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Command_DoWork(object sender, DoWorkEventArgs e)
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
            switch (iOption)
            {
                case 1:
                    Command_Run();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Xử lý khi chạy xong
        /// CreateBy: truongnm 24-05-2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Command_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Add code here:
            if (!e.Cancelled && e.Error == null)//Check if the worker has been cancelled or if an error occured
            {
                switch (iOption)
                {
                    case 1:
                        Command_Run_Finish();
                        break;
                    default:
                        break;
                }
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
            mlblSumTime.Text = string.Format(@"ms: {0:#,##0}", oStopwatch.ElapsedMilliseconds);
            this.mcpMainProcess.Visible = false;
        }
        /// <summary>
        /// Xử lý báo cáo khi đang chạy
        /// CreateBy: truongnm 24-05-2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Command_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Add code here:

        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Event
        /// <summary>
        /// Hàm mllChon_LinkClicked
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        private void mllChon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //
            Command_Reset_Text();
            //
            sTempFileName = Command_OpenFile();
            if (sTempFileName == "" || sTempFileName == string.Empty) { MMessageBox.Error("Hãy chọn file!"); file_name.Text = ""; file_byte64.Text = ""; return; }
            //
            iOption = 1;
            this.RunDoWork();
        }
        #endregion
    }
}
