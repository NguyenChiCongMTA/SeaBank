using SafeControl.Base;
using SafeControl.Dictionary;
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
    /// CreateBy: truongnm 17.03.2022
    /// </summary>
    public partial class f8SendAPI_ReportDialog : fBaseDialog
    {
        /// <summary>
        /// Khởi tạo form 
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public f8SendAPI_ReportDialog()
        {
            InitializeComponent();
            //
            word = new Word.Application();
            wordDoc = new Word.Document();
            //
            // Đăng ký event ở đây
            // CreateBy: truongnm 17.03.2022
            //
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Declare
        public int iOption = 0; // 1: Run
        string sTempFileName = string.Empty;
        string sTempFileBase64 = string.Empty;
        public f8SendAPI f8SendAPI { set; get; }
        //
        private Word.Application word;
        private Word.Document wordDoc;
        //
        public string sPathDotFile = string.Empty;
        public string sTenNganHang = string.Empty;
        public string sChiNhanh = string.Empty;
        public int iTrongVongNNgayToi = 0;
        public string sDenNgay;
        public DataTable BangHopDongKetSatDenHan = null;
        public string sNgayThangNam = string.Empty;
        public string sNguoiLapBieu = string.Empty;
        public string sKiemSoat = string.Empty;
        public string sTitleWord = string.Empty;
        //
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm ExportTable_BangHopDongKetSatDenHan
        /// CreateBy: truongnm 18.03.2022
        /// </summary>
        private void ExportTable_BangHopDongKetSatDenHan(int NColumns, object Start)
        {
            //Khoi tao range theo vi tri de add Ungvien len Word
            Word.Range range = wordDoc.Range(ref Start, ref Start);
            object missing = System.Type.Missing;
            //Tạo bảng với 1 hàng và NColumns cột tại vùng range
            Word.Table oTable = wordDoc.Tables.Add(range, 1, NColumns, ref missing, ref missing);
            // Vẽ đường viền
            oTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            oTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
            //
            //Add thêm rows vào bảng  
            for (int i = 0; i < BangHopDongKetSatDenHan.Rows.Count; i++)
            {
                Word.Row newRow = oTable.Rows.Add(ref missing);
                // Căn lề
                newRow.Cells[1].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[2].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[3].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                newRow.Cells[4].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[5].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                newRow.Cells[6].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                // Thêm dữ liệu
                newRow.Cells[1].Range.Text = (i + 1).ToString();
                newRow.Cells[2].Range.Text = BangHopDongKetSatDenHan.Rows[i][3].ToString();
                newRow.Cells[3].Range.Text = BangHopDongKetSatDenHan.Rows[i][4].ToString();
                newRow.Cells[4].Range.Text = BangHopDongKetSatDenHan.Rows[i][1].ToString();
                newRow.Cells[5].Range.Text = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(BangHopDongKetSatDenHan.Rows[i][7].ToString().Trim()));
                newRow.Cells[6].Range.Text = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(BangHopDongKetSatDenHan.Rows[i][8].ToString().Trim()));
                //
            }
            // Thêm tiêu đề ở đây
            if (oTable.Rows.Count > 1)
            {
                // Styte tiêu đề
                oTable.Range.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
                oTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                //
                oTable.Range.ParagraphFormat.SpaceBefore = 6F;
                oTable.Range.ParagraphFormat.SpaceAfter = 6F;
                oTable.Range.Borders.Enable = 1;
                oTable.Rows[1].Range.Font.Bold = 1; // Cỡ chữ Béo
                oTable.Rows[1].Range.Cells.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray05; // Màu của dòng đầu tiên
                // Chiều rộng các cột
                oTable.Columns[1].Width = 30;
                oTable.Columns[2].Width = 40;
                oTable.Columns[3].Width = 120;
                oTable.Columns[4].Width = 60;
                oTable.Columns[5].Width = 70;
                oTable.Columns[6].Width = 70;
                //
                //Phúc, fit window
                oTable.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow);
                //Repeat header, lặp lại header
                oTable.Rows[1].HeadingFormat = -1;
                oTable.ApplyStyleHeadingRows = true;
                // Định nghĩa các cột
                oTable.Rows[1].Cells[1].Range.Text = "STT"; oTable.Rows[1].Cells[1].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Rows[1].Cells[2].Range.Text = "MÃ KH"; oTable.Rows[1].Cells[2].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Rows[1].Cells[3].Range.Text = "TÊN KH"; oTable.Rows[1].Cells[3].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Rows[1].Cells[4].Range.Text = "SỐ BOX"; oTable.Rows[1].Cells[4].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Rows[1].Cells[5].Range.Text = "NGÀY MỞ"; oTable.Rows[1].Cells[5].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Rows[1].Cells[6].Range.Text = "NGÀY HẾT HẠN"; oTable.Rows[1].Cells[6].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                //
                // Tự động Fit lại các cột cho cân
                oTable.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitFixed);
            }
            else
            {
                // Nếu không có dữ liệu thì xóa bảng đi
                oTable.Rows[1].Delete();
            }
            
        }
        /// <summary>
        /// Hàm InsertWord_f8SendAPI
        /// CreateBy: truongnm 18.03.2022
        /// </summary>
        public void InsertWord_f8SendAPI()
        {
            object missing = Missing.Value;
            //
            //Gan Document bang cach add temp vao trong word
            Object oTemplatePath = sPathDotFile;
            wordDoc = word.Documents.Add(ref oTemplatePath, ref missing, ref missing, ref missing);
            //
            //Duyet tat ca cac MergeField tren Word
            foreach (Word.Field myMergeField in wordDoc.Fields)
            {
                //Lay range co chua MergeField
                Word.Range rangeFieldCode = myMergeField.Code;
                string fieldText = rangeFieldCode.Text;

                if (fieldText.StartsWith(" MERGEFIELD"))
                {
                    int endMerge = fieldText.IndexOf("\\");
                    int fieldNameLength = fieldText.Length - endMerge;
                    string fieldName = fieldText.Substring(11, endMerge - 11).Trim();
                    FieldInfo field_info = this.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    //
                    switch (fieldName)
                    {
                        default:
                            myMergeField.Select();
                            word.Selection.TypeText(field_info.GetValue(this).ToString());
                            break;
                        case "BangHopDongKetSatDenHan":
                            myMergeField.Select();
                            //Gán khoảng trắng để xóa tên field
                            word.Selection.TypeText(" ");
                            ExportTable_BangHopDongKetSatDenHan(6, word.Selection.End);
                            break;
                    }
                }
            }
            word.Visible = true;
            word.Caption = sTitleWord;
            //
        }
        /// <summary>
        /// Hàm Command_Run
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_Run()
        {
            //
            InsertWord_f8SendAPI();
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
            if (this.GetCountNameProcess("WINWORD") >= MGlobal.iWINWORD)
                if (DialogResult.Yes == MMessageBox.Question(string.Format("Đã có hơn {0} chương trình WINWORD đang chạy! Để bớt chậm bạn có muốn đóng hết tất cả các cửa sổ WINWORD lại?", MGlobal.iWINWORD)))
                    if (DialogResult.Yes == MMessageBox.Question("Hãy chắc chắn là đã lưu hết tất cả file word?"))
                        MProcess.KillProcess("WINWORD");
            // Đóng rồi thì khởi tạo lại!
            word = new Word.Application();
            wordDoc = new Word.Document();
            //
            sTenNganHang = mtb_sTenNganHang.Text.Trim();
            sChiNhanh = mtb_sChiNhanh.Text.Trim();
            //iTrongVongNNgayToi = Convert.ToInt32(mnudTrongVong.Value);
            //BangHopDongKetSatDenHan = dTableData;
            sNgayThangNam = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", (DateTime)mde_sNgayThangNam.EditValue);
            sNguoiLapBieu = mtb_sNguoiLapBieu.Text;
            sKiemSoat = mtb_sKiemSoat.Text;
            //
            iOption = 1;
            this.RunDoWork();
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
            mlb_TieuDe.Text = "In : " + sTitleWord;
            //
            mtb_sTenNganHang.ReadOnly = true;
            mtb_sChiNhanh.ReadOnly = true;
            //
            mtb_iTrongVongNNgayToi.ReadOnly = true;
            mtb_sDenNgay.ReadOnly = true;
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
            mtb_sTenNganHang.Text = sTenNganHang;
            mtb_sChiNhanh.Text = sChiNhanh;
            mtb_sDenNgay.Text = sDenNgay;
            mtb_iTrongVongNNgayToi.Text = iTrongVongNNgayToi.ToString();
            //
            mde_sNgayThangNam.EditValue = DateTime.Now;
            mtb_sNguoiLapBieu.Text = sNguoiLapBieu;
            mtb_sKiemSoat.Text = sKiemSoat;
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
