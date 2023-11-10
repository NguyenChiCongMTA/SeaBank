using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Reflection;
namespace SafeControl
{
    public partial class f3BaoCaoDoanhThu : fBase
    {
        public f1MainMenu formMainMenu { set; get; }
        public string MaNganHang { set; get; }
        public string TenNhanVien { set; get; }
        public f3BaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private Word.Application oWord;
        private Word.Document oWordDoc;
        public DataTable Input;

        private string TenChiNhanh(string MaChiNhanh)
        {
            Base.Connect connect = new Base.Connect();
            connect.InitSqlConnection();
            string sql = "select dmf_firma.name from dmf_firma, dmf_offices where dmf_firma.id = dmf_offices.id and dmf_offices.name = '{0}'";
            sql = string.Format(sql, MaChiNhanh);
            DataTable dt = connect.GetSqlDataSet(sql).Tables[0];
            string tenchinhanh = dt.Rows[0][0].ToString();
            return tenchinhanh;
        }

        public void ExportBienBan(string TemplatePath)
        {
            object oTemplatePath = TemplatePath;
            object missing = Missing.Value;
            //Gan Document oWordDoc bang cach add Template vao trong Word
            oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref missing, ref missing, ref missing);
            //Phúc
            int TotalTable = 1;

            //Duyet tat ca cac MergeField tren Word
            foreach (Word.Field myMergeField in oWordDoc.Fields)
            {
                //Get lấy rang có chứa MergrField
                Word.Range rngFieldCode = myMergeField.Code;
                string fieldText = rngFieldCode.Text;

                if (fieldText.StartsWith(" MERGEFIELD"))
                {
                    int endMerge = fieldText.IndexOf("\\");
                    int fieldNameLength = fieldText.Length - endMerge;
                    string fieldName = fieldText.Substring(11, endMerge - 11);
                    fieldName = fieldName.Trim();

                    switch (fieldName)
                    {
                        
                        case "ChiNhanh":
                            {
                                myMergeField.Select();
                                oWord.Selection.TypeText(TenChiNhanh(MaNganHang));
                                break;
                            }
                        case "MaChiNhanh":
                            {
                                myMergeField.Select();
                                oWord.Selection.TypeText(MaNganHang);
                                break;
                            }
                        case "NgayTao":
                            {
                                myMergeField.Select();
                                string ngaythang = (DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year).ToString();
                                oWord.Selection.TypeText(ngaythang);
                                break;
                            }
                        case "NguoiLap":
                            {
                                myMergeField.Select();
                                oWord.Selection.TypeText(mtbNguoiLapBieu.Text);
                                break;
                            }
                        case "KiemSoat":
                            {
                                myMergeField.Select();
                                oWord.Selection.TypeText(mtbNguoiPheDuyet.Text);
                                break;
                            }
                        
                        #region Báo cáo bảng
                        case "BaoCaoDoanhThu":
                            {
                                TotalTable++;
                                myMergeField.Select();
                                //Gán khoảng trắng để xóa tên field
                                oWord.Selection.TypeText(" ");
                                //Ghi danh sách ứng viên vào bảng có 4 cột, tại vị trí start, end
                                ExportTable(4, oWord.Selection.End, TotalTable);
                                break;
                            }
                        case "TongHopDong":
                            {
                                TotalTable++;
                                myMergeField.Select();
                                oWord.Selection.TypeText(" ");
                                this.ExportTable(2, oWord.Selection.End, TotalTable);
                                break;
                            }

                        case "BaoCaoTongLuongKetTonKho":
                            {
                                TotalTable++;
                                myMergeField.Select();
                                oWord.Selection.TypeText(" ");
                                ExportTable(4, oWord.Selection.End, TotalTable);
                                break;
                            }
                        case "BaoCaoGiaoDichTrongNgay":
                            {
                                TotalTable++;
                                myMergeField.Select();
                                oWord.Selection.TypeText(" ");
                                ExportTable(9, oWord.Selection.End, TotalTable);
                                break;
                            }
                        #endregion
                    }

                }
            }
            //System.Windows.Forms.MessageBox.Show(oWordDoc.Tables.Count.ToString());
            oWord.Visible = true;
            //oWord.Caption = "Biên bản kiểm phiếu ";
        }


        private void ExportTable(int NColumns, object Start, int NTables)
        {
            //Khoi tao range theo vi tri de add Ungvien len Word
            Word.Range range = oWordDoc.Range(ref Start, ref Start);
            object missing = System.Type.Missing;
            //Tạo bảng với 1 hàng và NColumns cột tại vùng range
            Word.Table tbl = oWordDoc.Tables.Add(range, 1, NColumns, ref missing, ref missing);
            //Phúc
            tbl.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            tbl.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
            //Add thêm rows vào bảng  
            for (int i = 0; i < Input.Rows.Count; i++)
            {
                Word.Row newRow = oWordDoc.Tables[NTables].Rows.Add(ref missing);
                //newRow.Range.Font.Bold = 0;
                //newRow.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                string hovaten = Input.Rows[i]["hodem"].ToString() + " " +
                                 Input.Rows[i]["ten"].ToString();
                //Phúc
                newRow.Cells[1].Range.ParagraphFormat.Alignment =
                    Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                //Đã căn giữa
                newRow.Cells[1].Range.Text = (i + 1).ToString() + ".";
                newRow.Cells[2].Range.Text = Input.Rows[i]["hodem"].ToString() + " " +
                                                Input.Rows[i]["ten"].ToString();

                newRow.Cells[3].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[3].Range.Text = Input.Rows[i]["SoPhieuBau"].ToString();
                //+"/" + KetQuaBauCuTongHop.SOCHIATYLE.ToString();
                newRow.Cells[4].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[4].Range.Text = Input.Rows[i]["Tyle"].ToString() + " %";

                //Word.Row newRow2 = oWordDoc.Tables[1].Rows.Add(ref missing);
                //newRow2.Cells[1].Range.Text = "tổng số đảng viên chính thức được triệu tập.";
            }
            if (tbl.Rows.Count > 1)
            {
                //tbl.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustifyLow;
                tbl.Range.ParagraphFormat.LineSpacing = 9.5F;
                tbl.Range.ParagraphFormat.SpaceBefore = 4.5F;
                tbl.Range.ParagraphFormat.SpaceAfter = 2.0F;
                tbl.Range.Borders.Enable = 1;
                tbl.Rows[1].Range.Font.Italic = 1;

                tbl.Columns[1].Width = 50;
                tbl.Columns[2].Width = 200;
                tbl.Columns[3].Width = 70;
                tbl.Columns[4].Width = 150;
                //Phúc, fit window
                tbl.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow);
                //Repeat header, lặp lại header
                tbl.Rows[1].HeadingFormat = -1;
                tbl.ApplyStyleHeadingRows = true;

                tbl.Rows[1].Cells[1].Range.Text = "STT";
                tbl.Rows[1].Cells[1].Range.ParagraphFormat.Alignment =
                    Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                tbl.Rows[1].Cells[2].Range.Text = "Họ và tên";
                tbl.Rows[1].Cells[2].Range.ParagraphFormat.Alignment =
                    Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                tbl.Rows[1].Cells[3].Range.Text = "Số phiếu";
                tbl.Rows[1].Cells[3].Range.ParagraphFormat.Alignment =
                    Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                tbl.Rows[1].Cells[4].Range.Text = "Tỷ lệ %";// tính theo quy chế bầu cử tại Đại hội XI";
                tbl.Rows[1].Cells[4].Range.ParagraphFormat.Alignment =
                    Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
            else
            {
                tbl.Rows[1].Delete();
            }
        }

        private void mPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbtn_ThongKe_DoanhThu_Click(object sender, EventArgs e)
        {

        }
       
    }
}
