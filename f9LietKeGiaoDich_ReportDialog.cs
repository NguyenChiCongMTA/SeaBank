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
    public partial class f9LietKeGiaoDich_ReportDialog : fBaseDialog
    {
        /// <summary>
        /// Khởi tạo form 
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public f9LietKeGiaoDich_ReportDialog()
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
        public f9LietKeGiaoDich f9LietKeGiaoDich { set; get; }
        //
        private Word.Application word;
        private Word.Document wordDoc;
        //
        public string sPathDotFile = string.Empty;
        public string sTitleWord = string.Empty;
        public string ChiNhanh = string.Empty;
        public string MaChiNhanh = string.Empty;
        public string NgayTao = string.Empty;
        public string TuNgay = string.Empty;
        public string DenNgay = string.Empty;
        public string GioTao = string.Empty;
        public DataTable BaoCaoGiaoDichTrongNgay = null;
        public string NguoiLap = string.Empty;
        public string KiemSoat = string.Empty;
        //
        public DateTime dNgayGiaoDich { set; get; }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm ExportTable_BaoCaoGiaoDichTrongNgay
        /// CreateBy: truongnm 18.03.2022
        /// </summary>
        private void ExportTable_BaoCaoGiaoDichTrongNgay(int NColumns, object Start)
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
            for (int i = 0; i < BaoCaoGiaoDichTrongNgay.Rows.Count; i++)
            {
                Word.Row newRow = oTable.Rows.Add(ref missing);
                // Căn lề
                newRow.Cells[1].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[2].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                newRow.Cells[3].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[4].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                newRow.Cells[5].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[6].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[7].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[8].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[9].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                // Thêm dữ liệu
                newRow.Cells[1].Range.Text = (i + 1).ToString();
                newRow.Cells[2].Range.Text = BaoCaoGiaoDichTrongNgay.Rows[i][0].ToString();
                newRow.Cells[3].Range.Text = BaoCaoGiaoDichTrongNgay.Rows[i][1].ToString();
                newRow.Cells[4].Range.Text = BaoCaoGiaoDichTrongNgay.Rows[i][2].ToString();
                newRow.Cells[5].Range.Text = BaoCaoGiaoDichTrongNgay.Rows[i][3].ToString();
                newRow.Cells[6].Range.Text = BaoCaoGiaoDichTrongNgay.Rows[i][4].ToString();
                newRow.Cells[7].Range.Text = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(BaoCaoGiaoDichTrongNgay.Rows[i][5].ToString().Trim()));
                newRow.Cells[8].Range.Text = BaoCaoGiaoDichTrongNgay.Rows[i][6].ToString();
                newRow.Cells[9].Range.Text = BaoCaoGiaoDichTrongNgay.Rows[i][7].ToString();
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
                oTable.Rows[1].Range.Cells.Shading.BackgroundPatternColor = Word.WdColor.wdColorWhite; // Màu của dòng đầu tiên
                // Chiều rộng các cột
                oTable.Columns[1].Width = 30;
                oTable.Columns[2].Width = 80;
                oTable.Columns[3].Width = 40;
                oTable.Columns[4].Width = 120;
                oTable.Columns[5].Width = 40;
                oTable.Columns[6].Width = 80;
                oTable.Columns[7].Width = 70;
                oTable.Columns[8].Width = 80;
                oTable.Columns[9].Width = 80;
                //
                //Phúc, fit window
                oTable.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow);
                //Repeat header, lặp lại header
                oTable.Rows[1].HeadingFormat = -1;
                oTable.ApplyStyleHeadingRows = true;
                // Định nghĩa các cột
                oTable.Rows[1].Cells[1].Range.Text = "STT"; oTable.Rows[1].Cells[1].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Rows[1].Cells[2].Range.Text = "Số bút toán/ Số hợp đồng"; oTable.Rows[1].Cells[2].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Rows[1].Cells[3].Range.Text = "ID"; oTable.Rows[1].Cells[3].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Rows[1].Cells[4].Range.Text = "Tên KH"; oTable.Rows[1].Cells[4].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Rows[1].Cells[5].Range.Text = "Mã tủ/ két"; oTable.Rows[1].Cells[5].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Rows[1].Cells[6].Range.Text = "Trạng thái"; oTable.Rows[1].Cells[6].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Rows[1].Cells[7].Range.Text = "Ngày phát sinh"; oTable.Rows[1].Cells[7].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Rows[1].Cells[8].Range.Text = "Diễn giải"; oTable.Rows[1].Cells[8].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Rows[1].Cells[9].Range.Text = "Đơn vị"; oTable.Rows[1].Cells[9].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                //
                // Tự động Fit lại các cột cho cân
                oTable.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow);
            }
            else
            {
                // Nếu không có dữ liệu thì xóa bảng đi
                oTable.Rows[1].Delete();
            }
            
        }
        /// <summary>
        /// Hàm InsertWord_f9LietKeGiaoDich
        /// CreateBy: truongnm 18.03.2022
        /// </summary>
        public void InsertWord_f9LietKeGiaoDich()
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
                        case "BaoCaoGiaoDichTrongNgay":
                            myMergeField.Select();
                            //Gán khoảng trắng để xóa tên field
                            word.Selection.TypeText(" ");
                            ExportTable_BaoCaoGiaoDichTrongNgay(9, word.Selection.End);
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
            InsertWord_f9LietKeGiaoDich();
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
            ChiNhanh = mtb_ChiNhanh.Text.Trim();
            MaChiNhanh = mtb_MaChiNhanh.Text.Trim();
            NgayTao = string.Format("{0:dd/MM/yyyy}", (DateTime)mde_NgayTao_GioTao.EditValue);
            GioTao = string.Format("{0:HH:mm:ss}", (DateTime)mde_NgayTao_GioTao.EditValue);
            TuNgay = mtbTuNgay.Text;
            DenNgay = mtbDenNgay.Text;
            NguoiLap = mtb_NguoiLap.Text;
            KiemSoat = mtb_KiemSoat.Text;
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
            mtb_ChiNhanh.ReadOnly = true;
            mtb_MaChiNhanh.ReadOnly = true;
            //
            mtbTuNgay.ReadOnly = true;
            mtbDenNgay.ReadOnly = true;
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
            mtb_ChiNhanh.Text = ChiNhanh;
            mtb_MaChiNhanh.Text = MaChiNhanh;
            //
            mde_NgayTao_GioTao.EditValue = dNgayGiaoDich;
            mtbTuNgay.Text = TuNgay;
            mtbDenNgay.Text = DenNgay;
            //
            mtb_NguoiLap.Text = NguoiLap;
            mtb_KiemSoat.Text = KiemSoat;

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
