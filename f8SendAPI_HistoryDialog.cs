using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using SafeControl.Base;
using SafeControl.Bussiness;
using SafeControl.Dictionary;
using SafeControl.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
namespace SafeControl
{
    /// <summary>
    /// Khởi tạo form 
    /// CreateBy: truongnm 25.03.2022
    /// </summary>
    public partial class f8SendAPI_HistoryDialog : fBaseDialog
    {
        /// <summary>
        /// Khởi tạo form 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public f8SendAPI_HistoryDialog()
        {
            InitializeComponent();
            //
            // Đăng ký event tại đây
            // CreateBy: truongnm 25.03.2022
            //
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Declare
        public int iOption = 0; // 1: Run
        //
        public f8SendAPI f8SendAPI { set; get; }
        //
        public string IPERSONID { set; get; }
        PersonHistory oPersonHistory = null;
        //
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm Command_Run
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void Command_Run()
        {
            //
            
        }
        /// <summary>
        /// Hàm Command_Run_Finish
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void Command_Run_Finish()
        {
            
        }
        /// <summary>
        /// Hàm Command_Reset_Text
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void Command_Reset_Text() 
        {
            //
            
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Override
        /// <summary>
        /// Hàm Command_ChapNhan
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public override void Command_ChapNhan()
        {
            // Add code here:
            base.Command_ChapNhan();
            //
            iOption = 1;
            this.RunDoWork();
        }
        /// <summary>
        /// Khởi tạo InitForm
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public override void InitForm()
        {
            // Add code here:
            base.InitForm();
            //
            mlb_TieuDe.Text = "Quản lý : " + this.Text;
            //
            int indexCol = 0;
            ///////////////////////////////////////////////////////////////////////
            // Khởi tạo mgcData
            ///////////////////////////////////////////////////////////////////////
            //
            this.mgc_PersonHistoryLog.gridView1.Columns.Clear();
            this.mgc_PersonHistoryLog.gridView1.OptionsView.ColumnAutoWidth = true;
            this.mgc_PersonHistoryLog.AddColumn(FieldName: "dCreate", Caption: "Time", Width: 120, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Near, AllowEdit: false, FormatType: FormatType.DateTime, FormatString: "dd/MM/yyyy HH:mm:ss");
            this.mgc_PersonHistoryLog.AddColumn(FieldName: "sUserWrite", Caption: "UserWrite", Width: 120, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Center, AllowEdit: false);
            this.mgc_PersonHistoryLog.AddColumn(FieldName: "sType", Caption: "Type", Width: 40, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Center, AllowEdit: false);// VORNAME + NAME
            //
            RepositoryItemMemoEdit oRepositoryItemMemoEdit = new RepositoryItemMemoEdit();
            this.mgc_PersonHistoryLog.AddColumn(FieldName: "sContext", Caption: "Context", Width: 200, VisibleIndex: indexCol++,ColumnEdit:oRepositoryItemMemoEdit, AllowEdit: false); // VORNAME + NAME
            ////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////
            //
            this.mgc_PersonHistoryLog.SetFilter();
            ///////////////////////////////////////////////////////////////////////
            this.mb_ChapNhan.Visible = false;
        }
        /// <summary>
        /// Khởi tạo InitData
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public override void InitData()
        {
            // Add code here:
            base.InitData();
            //
            oPersonHistory = new PersonHistory(IPERSONID);
        }
        /// <summary>
        /// Khởi tạo LoadData
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public override void LoadData()
        {
            // Add code here:
            base.LoadData();
            //
            this.mgc_PersonHistoryLog.gridControl1.DataSource = oPersonHistory.ReadPersonHistory().ToDataTablePersionHistoryLog();
            this.mgc_PersonHistoryLog.SetFilter();
            //
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
