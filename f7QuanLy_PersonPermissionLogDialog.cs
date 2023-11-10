using SafeControl.Base;
using SafeControl.Dictionary;
using SafeControl.Enum;
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
    public partial class f7QuanLy_PersonPermissionLogDialog : fBaseDialog
    {
        /// <summary>
        /// Khởi tạo form 
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public f7QuanLy_PersonPermissionLogDialog()
        {
            InitializeComponent();
            //
            // Đăng ký event ở đây
            // CreateBy: truongnm 17.03.2022
            //
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Declare
        public int iOption = 0; // 1: Run
        public string sControlName { set; get; }
        public string sPersonPermission { set; get; }
        public string sNote { set; get; }
        public f7QuanLy_PersonPermissionDialog f7QuanLy_PersonPermissionDialog { set; get; }
        public iOptionSelect iOptionSelect { set; get; }
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
            //

        }
        /// <summary>
        /// Hàm Command_Run_Finish
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_Run_Finish()
        {
            
        }
        /// <summary>
        /// Hàm Command_Reset_Text
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_Reset_Text() 
        {
            //
            mtb_sControlName.Text = string.Empty;
            mtb_sPersonPermission.Text = string.Empty;
            mtb_sNote.Text = string.Empty;
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
            switch (iOptionSelect)
            {
                case iOptionSelect.Insert:
                case iOptionSelect.CopyPaste:
                case iOptionSelect.Delete:
                    f7QuanLy_PersonPermissionDialog.sControlName = mtb_sControlName.Text.Trim();
                    f7QuanLy_PersonPermissionDialog.sPersonPermission = mtb_sPersonPermission.Text.Trim();
                    f7QuanLy_PersonPermissionDialog.sNote = mtb_sNote.Text.Trim();
                    break;
                case iOptionSelect.Update:
                    f7QuanLy_PersonPermissionDialog.sControlName = this.sControlName.Trim();
                    f7QuanLy_PersonPermissionDialog.sPersonPermission = this.sPersonPermission.Trim();
                    f7QuanLy_PersonPermissionDialog.sNote = this.sNote.Trim();
                    //
                    f7QuanLy_PersonPermissionDialog.sControlNameNew = mtb_sControlName.Text.Trim();
                    f7QuanLy_PersonPermissionDialog.sPersonPermissionNew = mtb_sPersonPermission.Text.Trim();
                    f7QuanLy_PersonPermissionDialog.sNoteNew = mtb_sNote.Text.Trim();
                    break;
            }
            f7QuanLy_PersonPermissionDialog.iOptionSelect = iOptionSelect;
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
            switch (iOptionSelect)
            {
                case iOptionSelect.Insert:
                    mlb_TieuDe.Text = "Thêm " + this.Text;
                    break;
                case iOptionSelect.Update:
                    mlb_TieuDe.Text = "Sửa " + this.Text;
                    break;
                case iOptionSelect.CopyPaste:
                    mlb_TieuDe.Text = "Copy " + this.Text;
                    break;
                case iOptionSelect.Delete:
                    mlb_TieuDe.Text = "Xóa " + this.Text;
                    break;
                default:
                    break;
            }
            
            //
        }
        /// <summary>
        /// Khởi tạo InitData
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public override void InitData()
        {
            // Add code here:
            base.InitData();
            //
            mtb_sControlName.Text = sControlName;
            mtb_sPersonPermission.Text = sPersonPermission;
            mtb_sNote.Text = sNote;
            //
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
        
        #endregion
    }
}
