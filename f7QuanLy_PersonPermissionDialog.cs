using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class f7QuanLy_PersonPermissionDialog : fBaseDialog
    {
        /// <summary>
        /// Khởi tạo form 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public f7QuanLy_PersonPermissionDialog()
        {
            InitializeComponent();
            //
            // Đăng ký event tại đây
            // CreateBy: truongnm 25.03.2022
            //
            mbtnThem.Click += mbtnThem_Click;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Declare
        public int iOption = 0; // 1: Run
        //
        public f7QuanLy f7QuanLy { set; get; }
        //
        public PersonPermission oPersonPermission { set; get; }
        public string sControlName { set; get; }
        public string sPersonPermission { set; get; }
        public string sNote { set; get; }
        public string sControlNameNew { set; get; }
        public string sPersonPermissionNew { set; get; }
        public string sNoteNew { set; get; }
        public iOptionSelect iOptionSelect { set; get; }
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
            this.mgc_PersonHistoryLog.AddColumn(FieldName: "sControlName", Caption: "ControlName", Width: 120, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Near, AllowEdit: false);
            this.mgc_PersonHistoryLog.AddColumn(FieldName: "sPersonPermission", Caption: "PersonPermission", Width: 120, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Center, AllowEdit: false);
            //
            RepositoryItemMemoEdit oRepositoryItemMemoEdit = new RepositoryItemMemoEdit();
            this.mgc_PersonHistoryLog.AddColumn(FieldName: "sNote", Caption: "Note", Width: 200, VisibleIndex: indexCol++, ColumnEdit: oRepositoryItemMemoEdit, AllowEdit: false);
            ////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////
            
            ////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////
            // Cột tiếp theo là button Sua
            RepositoryItemButtonEdit btnSua = new RepositoryItemButtonEdit();
            btnSua.AutoHeight = true;
            btnSua.Name = "btnSua";
            btnSua.LookAndFeel.UseDefaultLookAndFeel = true;
            btnSua.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //
            EditorButton editButton = new EditorButton(
                DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
                , "Sửa", -1, true, true, false
                , DevExpress.Utils.HorzAlignment.Near
                , null
            );
            btnSua.Buttons.Clear();
            btnSua.Buttons.Add(editButton);
            //
            this.mgc_PersonHistoryLog.AddColumn(FieldName: "#", Caption: "#", Width: 70, VisibleIndex: indexCol++, ColumnEdit: btnSua, FixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            // Event btnSua_ButtonClick
            btnSua.ButtonClick += btnSua_ButtonClick;
            ////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////
            // Cột tiếp theo là button Xoa
            RepositoryItemButtonEdit btnXoa = new RepositoryItemButtonEdit();
            btnXoa.AutoHeight = true;
            btnXoa.Name = "btnXoa";
            btnXoa.LookAndFeel.UseDefaultLookAndFeel = true;
            btnXoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //
            editButton = new EditorButton(
                DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
                , "Xóa", -1, true, true, false
                , DevExpress.Utils.HorzAlignment.Near
                , null
            );
            btnXoa.Buttons.Clear();
            btnXoa.Buttons.Add(editButton);
            //
            this.mgc_PersonHistoryLog.AddColumn(FieldName: "#", Caption: "#", Width: 70, VisibleIndex: indexCol++, ColumnEdit: btnXoa, FixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            // Event btnXoa_ButtonClick
            btnXoa.ButtonClick += btnXoa_ButtonClick;
            ////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////
            //
            this.mgc_PersonHistoryLog.SetFilter();
            ///////////////////////////////////////////////////////////////////////
            this.mb_ChapNhan.Visible = false;
        }
        /// <summary>
        /// Sự kiện mbtnThem_Click
        /// CreateBy: truongnm 25.03.2022
        private void mbtnThem_Click(object sender, EventArgs e)
        {
            Command_mbtnThem_Click();
        }

        /// <summary>
        /// Hàm Command_btnHistory_ButtonClick
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        private void Command_mbtnThem_Click()
        {
            //
            f7QuanLy_PersonPermissionLogDialog f = new f7QuanLy_PersonPermissionLogDialog();
            f.f7QuanLy_PersonPermissionDialog = this;
            f.CallBackUI += CallBackUI_f7QuanLy_PersonPermissionDialog;
            f.iOptionSelect = iOptionSelect.Insert;
            f.sControlName = "";
            f.sPersonPermission = "";
            f.sNote = "";
            f.ShowDialog();
        }
        /// <summary>
        /// Sự kiện btnSua_ButtonClick
        /// CreateBy: truongnm 25.03.2022
        private void btnSua_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Command_btnSua_ButtonClick();
        }

        /// <summary>
        /// Hàm Command_btnHistory_ButtonClick
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        private void Command_btnSua_ButtonClick()
        {
            //
            f7QuanLy_PersonPermissionLogDialog f = new f7QuanLy_PersonPermissionLogDialog();
            f.f7QuanLy_PersonPermissionDialog = this;
            f.CallBackUI += CallBackUI_f7QuanLy_PersonPermissionDialog;
            f.iOptionSelect = iOptionSelect.Update;
            f.sControlName = mgc_PersonHistoryLog.gridView1.GetFocusedDataRow()["sControlName"].ToString();
            f.sPersonPermission = mgc_PersonHistoryLog.gridView1.GetFocusedDataRow()["sPersonPermission"].ToString();
            f.sNote = mgc_PersonHistoryLog.gridView1.GetFocusedDataRow()["sNote"].ToString();
            f.ShowDialog();
        }
        /// <summary>
        /// Sự kiện btnXoa_ButtonClick
        /// CreateBy: truongnm 25.03.2022
        private void btnXoa_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Command_btnXoa_ButtonClick();
        }

        /// <summary>
        /// Hàm Command_btnHistory_ButtonClick
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        private void Command_btnXoa_ButtonClick()
        {
            //
            string sControlName = mgc_PersonHistoryLog.gridView1.GetFocusedDataRow()["sControlName"].ToString();
            string sPersonPermission = mgc_PersonHistoryLog.gridView1.GetFocusedDataRow()["sPersonPermission"].ToString();
            string sNote = mgc_PersonHistoryLog.gridView1.GetFocusedDataRow()["sNote"].ToString();
            //
            oPersonPermission.DeletePersonPermissionLog(sControlName, sPersonPermission, sNote);
            //
            LoadData();
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
            oPersonPermission = new PersonPermission();
            oPersonPermission = oPersonPermission.ReadPersonPermission();
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
            this.mgc_PersonHistoryLog.gridControl1.DataSource = oPersonPermission.ReadPersonPermission().ToDataTablePersionPermissionLog();
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
        /// <summary>
        /// Hàm CallBackUI_f7QuanLy_PersonPermissionDialog
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        private void CallBackUI_f7QuanLy_PersonPermissionDialog(object sender, EventArgs e)
        {
            Command_CallBackUI_f7QuanLy_PersonPermissionDialog();
        }
        /// <summary>
        /// Hàm Command_CallBackUI_f7QuanLy_PersonPermissionDialog
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void Command_CallBackUI_f7QuanLy_PersonPermissionDialog()
        {
            //
            if (iOptionSelect == null || sControlName == "") return;
            //
            switch (iOptionSelect)
            {
                case iOptionSelect.Insert:
                    oPersonPermission.AddPersonPermissionLog(sControlName, sPersonPermission, sNote);
                    break;
                case iOptionSelect.Update:
                    oPersonPermission.EditPersonPermissionLog(sControlName, sPersonPermission, sNote, sControlNameNew, sPersonPermissionNew, sNoteNew);
                    break;
                case iOptionSelect.CopyPaste:
                    break;
                case iOptionSelect.Delete:
                    oPersonPermission.DeletePersonPermissionLog(sControlName, sPersonPermission, sNote);
                    break;
                default:
                    break;
            }
            LoadData();
        }
        #endregion
    }
}
