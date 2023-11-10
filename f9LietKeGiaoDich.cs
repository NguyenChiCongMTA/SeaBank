using SafeControl.Bussiness;
using SafeControl.Dictionary;
using SafeControl.Enum;
using SafeControl.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using DevExpress.Utils.Drawing;
using DevExpress.XtraTreeList;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using System.Reflection;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace SafeControl
{
    /// <summary>
    /// Khởi tạo form 
    /// CreateBy: truongnm 09.03.2022
    /// </summary>
    public partial class f9LietKeGiaoDich : fBaseProcess
    {
        /// <summary>
        /// Khởi tạo form 
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public f9LietKeGiaoDich()
        {
            InitializeComponent();
            //
            oMProcess = new MProcess();
            dTableData = new DataTable();
            connect = new Base.Connect();
            //
            // Đăng ký sự kiện ở đây
            // CreateBy: truongnm 10.03.2022
        } 
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Declare
        public f1MainMenu formMainMenu { set; get; }
        private MProcess oMProcess = null;
        //
        DataTable dTableData = null;
        Base.Connect connect = null;
        //
        #endregion
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm Command_Run
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_Run()
        {
            this.CancelDoWork();
            //
            
        }
        /// <summary>
        /// Hàm Command_GenSendAPI_Email
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        public void Command_TimKiem()
        {
            string sSql = @"
select distinct
fach.mandat_id as mahopdong,
--fach.vermietungsdatum,
--fach.laufzeit,
kundfach.id as giaodichid,
(person.name || ' ' || person.vorname) as sten,
kundfach.fachid as ketid,
case
    when
        (fach.mandat_id <> '')
        and
        (fach.vermietungsdatum is not null)
        and
        (fach.laufzeit is null)
    then 'HD-DAT-TRUOC'
    --
    when
        (fach.mandat_id <> '')
        and
        (fach.vermietungsdatum is not null)
        and
        (fach.laufzeit is not null)
    then 'HD-MOI'
    --
    when
        (fach.mandat_id = '')
        and
        (fach.vermietungsdatum is null)
        and
        (fach.laufzeit is null)
    then 'CON-TRONG'
end as trangthai,
kundfach.anlegedatum as ngayphatsinh,
hinweis.hinweis as diengiai,
'' as donvi
from kundfach, person, fach, hinweis
where 1 = 1
and kundfach.fachid = fach.id
and kundfach.personid = person.id
and hinweis.id = person.hinweisid
and fach.mandat_id <> ''
and kundfach.loeschdatum is null
and
(
    ('{0}'='')
    or
    ('{1}'='')
    or
    (
        (kundfach.anlegedatum >= cast('{0:yyyy-MM-dd}' as date))
        and
        (kundfach.anlegedatum <= cast('{1:yyyy-MM-dd}' as date))
    )
)
";
            //
            sSql = string.Format(sSql, mdeTuNgay.EditValue, mdeDenNgay.EditValue);
            connect.InitSqlConnection();
            dTableData = connect.GetSqlDataSet(sSql).Tables[0];
        }
        /// <summary>
        /// Hàm Command_GenSendAPI_Email
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        public void Command_TimKiemFinish()
        {
            //
            this.mgcData.gridControl1.DataSource = dTableData;
            this.mgcData.SetFilter();
            //
            //MMessageBox.Information("Đã tìm xong!");
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
            //
            int indexCol = 0;
            ///////////////////////////////////////////////////////////////////////
            // Khởi tạo mgcData
            ///////////////////////////////////////////////////////////////////////
            //
            this.mgcData.gridView1.Columns.Clear();
            this.mgcData.gridView1.OptionsView.ColumnAutoWidth = false;
            this.mgcData.AddColumn(FieldName: "MAHOPDONG", Caption: "Mã HĐ", Width: 100, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Near, AllowEdit: false);
            this.mgcData.AddColumn(FieldName: "GIAODICHID", Caption: "ID GDịch", Width: 40, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Center, AllowEdit: false); // VORNAME + NAME
            this.mgcData.AddColumn(FieldName: "STEN", Caption: "Tên KH", Width: 200, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Near, AllowEdit: false); // VORNAME + NAME
            this.mgcData.AddColumn(FieldName: "KETID", Caption: "Mã tủ/ két", Width: 100, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Center, AllowEdit: false); // 
            this.mgcData.AddColumn(FieldName: "TRANGTHAI", Caption: "Trạng thái", Width: 120, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Near, AllowEdit: false); // 
            this.mgcData.AddColumn(FieldName: "NGAYPHATSINH", Caption: "Ngày phát sinh", Width: 80, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Far, AllowEdit: false);
            this.mgcData.AddColumn(FieldName: "DIENGIAI", Caption: "Diễn giải", Width: 60, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Near, AllowEdit: false); // vermietungsdatum
            this.mgcData.AddColumn(FieldName: "DONVI", Caption: "Đơn vị", Width: 60, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Near, AllowEdit: false);// laufzeit
            //
            this.mgcData.SetFilter();
            ///////////////////////////////////////////////////////////////////////
        }
        /// <summary>
        /// Hàm InitData
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public override void InitData()
        {
            base.InitData();
            //
            mdeTuNgay.EditValue = DateTime.Now;
            mdeDenNgay.EditValue = DateTime.Now;
        }
        /// <summary>
        /// Hàm LoadData
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public override void LoadData()
        {
            base.LoadData();
            //
            
        }
        /// <summary>
        /// Sự kiện khi hoàn thành
        /// CreateBy: truongnm 25.09.2019
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Command_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Add code here:
            if (!e.Cancelled && e.Error == null)//Check if the worker has been cancelled or if an error occured
            {
                
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Đã dừng");
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
            oStopwatch.Stop();
            mlblSumTime.Text = string.Format(@"ms: {0:#,##0}", oStopwatch.ElapsedMilliseconds);
            this.mcpMainProcess.Visible = false;
        }
        /// <summary>
        /// Xử lý bất đồng bộ
        /// CreateBy: truongnm 25.09.2019
        /// </summary>
        protected override void Command_DoWork(object sender, DoWorkEventArgs e)
        {
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
        /// Xử lý báo cáo khi đang chạy
        /// CreateBy: truongnm 24-05-2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Command_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        /// <summary>
        /// Hàm xử lý các event bấm bàn phím trên Form
        /// CreateBy: truongnm 04.04.2018
        /// </summary>
        protected override bool ProcessCmdKey(ref Message oMessage, Keys oKeys)
        {
            switch (oKeys)
            {
                case (Keys.F3):
                case (Keys.Enter):
                    Command_TimKiem();
                    Command_TimKiemFinish();
                    break;
                case (Keys.F1):
                    break;
                case (Keys.F2):
                    break;
                case (Keys.F4):
                    break;
                case (Keys.F6):
                    break;
            }
            return base.ProcessCmdKey(ref oMessage, oKeys);
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Event
       
        #endregion
        /// <summary>
        /// Sự kiện mTabControl_SelectedIndexChanged
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        private void mbtnTim_Click(object sender, EventArgs e)
        {
            Command_TimKiem();
            Command_TimKiemFinish();
        }
        /// <summary>
        /// Sự kiện mbtnIn_Click
        /// CreateBy: truongnm 18.03.2022
        /// </summary>
        private void mbtnIn_Click(object sender, EventArgs e)
        {
            f9LietKeGiaoDich_ReportDialog f9LietKeGiaoDich_ReportDialog = new f9LietKeGiaoDich_ReportDialog();
            f9LietKeGiaoDich_ReportDialog.BaoCaoGiaoDichTrongNgay = dTableData;
            f9LietKeGiaoDich_ReportDialog.sPathDotFile = Application.StartupPath + @"\template\3_Liet_ke_giao_dich_trong_ngay.dot";
            f9LietKeGiaoDich_ReportDialog.sTitleWord = "BÁO CÁO LIỆT KÊ GIAO DỊCH TRONG NGÀY";
            f9LietKeGiaoDich_ReportDialog.NguoiLap = sTenNhanVien;
            f9LietKeGiaoDich_ReportDialog.KiemSoat = "Nguyễn Kiểm Soát";
            f9LietKeGiaoDich_ReportDialog.ChiNhanh = Utils.Utilities.GetTenChiNhanh();
            f9LietKeGiaoDich_ReportDialog.MaChiNhanh = this.GetMaChiNhanh();
            f9LietKeGiaoDich_ReportDialog.NgayTao = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            f9LietKeGiaoDich_ReportDialog.GioTao = string.Format("{0:HH-mm-ss}", DateTime.Now);
            f9LietKeGiaoDich_ReportDialog.TuNgay = string.Format("{0:dd/MM/yyyy}", (DateTime)mdeTuNgay.EditValue);
            f9LietKeGiaoDich_ReportDialog.DenNgay = string.Format("{0:dd/MM/yyyy}", (DateTime)mdeDenNgay.EditValue);
            f9LietKeGiaoDich_ReportDialog.dNgayGiaoDich = DateTime.Now;
            f9LietKeGiaoDich_ReportDialog.StartPosition = FormStartPosition.CenterScreen;
            f9LietKeGiaoDich_ReportDialog.ShowDialog();
        }
    }
}
