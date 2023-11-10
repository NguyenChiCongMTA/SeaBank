using SafeControl.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafeControl.Base
{
    public partial class fBaseDialog : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Khởi tạo đối tượng
        /// CreateBy: truongnm 06.02.2021
        /// </summary>
        public fBaseDialog()
        {
            InitializeComponent();
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            // Giao diện và dạng font
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = MGlobal.sSkinName;
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = MGlobal.fDefaultFont;
            //
            oStopwatch = new Stopwatch();
            //
            mbw_Main.WorkerSupportsCancellation = true;
            mbw_Main.WorkerReportsProgress = true;
            //
            // Đăng ký Event ở đây
            // CreateBy: truongnm 06.02.2021
            mb_ChapNhan.Click += mb_ChapNhan_Click;
            mb_Thoat.Click += mb_Thoat_Click;
            this.Load += this.fBaseDialog_Load;
            mbw_Main.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mbw_Main_RunWorkerCompleted);
            mbw_Main.DoWork += new DoWorkEventHandler(mbw_Main_DoWork);
            mbw_Main.ProgressChanged += new ProgressChangedEventHandler(mbw_Main_ProgressChanged);
        }
        /////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////
        #region Declare
        public Stopwatch oStopwatch;
        public string sTenNhanVien { set; get; }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm GetMaChiNhanh
        /// Hàm này là hàm đặc thù của Project - SafeControl -
        /// CreateBy: truongnm 19.03.2022
        /// </summary>
        public virtual string GetMaChiNhanh()
        {
            MFile oMFile = new MFile();
            string sResult = string.Empty;
            //
            string sTemp = oMFile.OpenTextFile(Application.StartupPath + Constants.FilePathConstant.DATABASE_USER);
            sResult = sTemp.Trim().Split('\n')[2].Trim();
            //
            return sResult;
        }
        /// <summary>
        /// Hàm GetTenChiNhanh
        /// Hàm này là hàm đặc thù của Project - SafeControl -
        /// CreateBy: truongnm 19.03.2022
        /// </summary>
        public virtual string GetTenChiNhanh(string sMaChiNhanh)
        {
            string sResult = string.Empty;
            //
            app_object.Obj_ChiNhanh CN = new app_object.Obj_ChiNhanh();
            Base.Connect connect = new Base.Connect();
            connect.InitSqlConnection();
            string sql = "";
            //
            sql = @"select d.name,d.plz,d.strasse, d.ort, d.telefon, d.fax, d.ansprechpartner, d.email
                    from dmf_firma as d , dmf_offices
                    where dmf_offices.name = '{0}'  and dmf_offices.dmf_firma_id = d.id";
            sql = string.Format(sql, sMaChiNhanh);
            DataTable dt = connect.GetSqlDataSet(sql).Tables[0];
            CN.TenChiNhanh = dt.Rows[0][0].ToString();
            CN.DiaChi = dt.Rows[0][1].ToString() + dt.Rows[0][2].ToString() + ", " + dt.Rows[0][3].ToString();
            CN.DienThoai = dt.Rows[0][4].ToString();
            CN.Fax = dt.Rows[0][5].ToString();
            CN.DaiDien = dt.Rows[0][6].ToString();
            CN.Email = dt.Rows[0][7].ToString();
            //
            sResult = CN.TenChiNhanh;
            //
            return sResult;
        }
        /// <summary>
        /// Hàm GetTenChiNhanh
        /// Hàm này là hàm đặc thù của Project - SafeControl -
        /// CreateBy: truongnm 19.03.2022
        /// </summary>
        public virtual string GetTenChiNhanh()
        {
            string sResult = string.Empty;
            //
            using (StreamReader sRead = new StreamReader(Application.StartupPath + Constants.FilePathConstant.DATABASE_INFO_BANK))
            {
                string StrRead = sRead.ReadToEnd().Trim();
                sRead.Close();
                if (StrRead.Trim() != "")
                {
                    string[] tempRead = StrRead.Split('\n');
                    switch (tempRead.Length)
                    {
                        case 0:
                        case 1:
                            break;
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            sResult = tempRead[1].Trim();
                            break;
                    }
                }

            }
            //
            return sResult;
        }
        /// <summary>
        /// Hàm GetNgayPhatHanhVaKetThucBox
        /// Hàm này là hàm đặc thù của Project - SafeControl -
        /// CreateBy: truongnm 23.03.2022
        /// </summary>
        public virtual void GetNgayPhatHanhVaKetThucBox(string fachid, ref DateTime dNgayPhatHanh, ref DateTime dNgayKetThuc)
        {
            //
            Base.Connect connect = new Base.Connect();
            string sSql = @"
select distinct
fach.vermietungsdatum,
fach.laufzeit
from fach
where 1 = 1
and fach.id = {0}
";
            //
            sSql = string.Format(sSql, fachid);
            connect.InitSqlConnection();
            DataTable dTableData = connect.GetSqlDataSet(sSql).Tables[0];
            //
            if (dTableData.Rows.Count <= 0) return;
            dNgayPhatHanh = Convert.ToDateTime(dTableData.Rows[0][0]);
            dNgayKetThuc = Convert.ToDateTime(dTableData.Rows[0][1]);
        }
        /// <summary>
        /// Lệnh GetCountNameProcess
        /// CreateBy: truongnm: 28-06-2019
        public virtual int GetCountNameProcess(string sNamePro)
        {
            int iResult = 0;
            foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName(sNamePro))
                iResult++;
            return iResult;
        }
        /// <summary>
        /// Xử lý thao tác mở folder
        /// CreateBy: truongnm 31.01.2020
        /// </summary>
        public virtual string Command_OpenFolder()
        {
            string sResult = string.Empty;
            //
            folderBrowserDialogBase = new FolderBrowserDialog();
            folderBrowserDialogBase.SelectedPath = File.ReadAllText(Application.StartupPath + Constants.FilePathConstant.FOLDER_BROWSER_DIALOG_BASE);
            if (folderBrowserDialogBase.ShowDialog(this) == DialogResult.OK)
            {
                File.WriteAllText(Application.StartupPath + Constants.FilePathConstant.FOLDER_BROWSER_DIALOG_BASE, folderBrowserDialogBase.SelectedPath, Encoding.Unicode);
                //
                sResult = folderBrowserDialogBase.SelectedPath.Replace(@"\", @"/");
            }
            //
            return sResult;
        }
        /// <summary>
        /// Xử lý thao tác mở file
        /// CreateBy: truongnm 31.01.2020
        /// </summary>
        public virtual string Command_OpenFile()
        {
            string sResult = string.Empty;
            //
            openFileDialogBase = new OpenFileDialog();
            openFileDialogBase.Title = "Mở file";
            openFileDialogBase.Filter = "All Files (*.*)|*.*";
            openFileDialogBase.RestoreDirectory = true;
            if (openFileDialogBase.ShowDialog(this) == DialogResult.OK)
            {
                sResult = openFileDialogBase.FileName.Replace(@"\", @"/");
            }
            openFileDialogBase.Dispose();
            //
            return sResult;
        }
        /// <summary>
        /// Xử lý thao tác lưu file
        /// CreateBy: truongnm 31.01.2020
        /// </summary>
        public virtual string Command_SaveFile()
        {
            string sResult = string.Empty;
            //
            saveFileDialogBase = new SaveFileDialog();
            saveFileDialogBase.Filter = "All Files (*.*)|*.*";
            saveFileDialogBase.Title = "Lưu file";
            saveFileDialogBase.RestoreDirectory = true;
            //
            if (saveFileDialogBase.ShowDialog() == DialogResult.OK)
            {
                sResult = saveFileDialogBase.FileName.Replace(@"\", @"/");
            }
            //
            return sResult;
        }
        /// <summary>
        /// Hàm Command_ChapNhan
        /// CreateBy: truongnm 06.02.2021
        /// </summary>
        public virtual void Command_ChapNhan()
        {
            //MMessageBox.Information("Chấp nhận!");
        }
        /// <summary>
        /// Hàm Command_Thoat
        /// CreateBy: truongnm 06.02.2021
        /// </summary>
        public virtual void Command_Thoat()
        {
            //MMessageBox.Information("Thoát!");
            this.Dispose();
        }

        /// <summary>
        /// Khởi tạo InitForm
        /// CreateBy: truongnm 06.02.2021
        /// </summary>
        public virtual void InitForm()
        {
            // Add code here:
            mcpMainProcess.Visible = false;
        }
        /// <summary>
        /// Khởi tạo InitData
        /// CreateBy: truongnm 06.02.2021
        /// </summary>
        public virtual void InitData()
        {
            // Add code here:
            lblPhienBan.Text = MGlobal.sPhienBan;
        }
        /// <summary>
        /// Khởi tạo LoadData
        /// CreateBy: truongnm 06.02.2021
        /// </summary>
        public virtual void LoadData()
        {
            // Add code here:
        }
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
        /////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////
        #region Override
        
        #endregion
        /////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////
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
        /// <summary>
        /// Sự kiện mb_ChapNhan_Click
        /// CreateBy: truongnm 06.02.2021
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mb_ChapNhan_Click(object sender, EventArgs e)
        {
            Command_ChapNhan();
        }
        /// <summary>
        /// Sự kiện mb_Thoat_Click
        /// CreateBy: truongnm 06.02.2021
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mb_Thoat_Click(object sender, EventArgs e)
        {
            Command_Thoat();
        }
        /// <summary>
        /// Sự kiện load form
        /// </summary>
        private void fBaseDialog_Load(object sender, EventArgs e)
        {
            InitForm();
            //
            InitData();
            //
            LoadData();
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////
    }
}
