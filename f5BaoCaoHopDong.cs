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
using System.IO;
using System.Reflection;
namespace SafeControl
{
    public partial class f5BaoCaoHopDong : fBase
    {
        public f1MainMenu formMainMenu { set; get; }
        public string TenNhanVien { set; get; }
        public string MaNganHang { set; get; }
        public string NameNganHang { set; get; }
        public f5BaoCaoHopDong()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Sự kiện mbtn_Thoat
        /// CreateBy: connc 10.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbtn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            //formMainMenu.Show();
        }
        /// <summary>
        /// Sự kiện f5BaoCaoHopDong_FormClosed
        /// CreateBy: connc 10.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void f5BaoCaoHopDong_FormClosed(object sender, FormClosedEventArgs e)
        {
            //formMainMenu.Show();
        }
        /// <summary>
        /// Sự kiện mbtn_InBaoCao
        /// CreateBy: connc 10.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbtn_InBaoCao_Click(object sender, EventArgs e)
        {
            if ((mde_NgayBatDau.EditValue == null || mde_NgayBatDau.EditValue.ToString() == "") || (mde_NgayKetthuc.EditValue == null || mde_NgayKetthuc.EditValue.ToString() == "")) { Dictionary.MMessageBox.Error("Phải chọn khoảng thời gian!"); return; }
            int check_b = 1;
            int check_e = 1;
            DateTime first = mde_NgayBatDau.DateTime;
            DateTime end = mde_NgayKetthuc.DateTime;
            if (first.Year == 1)
                check_b = 0;
            if (end.Year == 1)
                check_e = 0;
            object oTempPath = Application.StartupPath + @"\template\1_Bao_cao_tinh_hinh_su_dung_hop_dong.dot";

            object missing = Missing.Value;

            Word.Application word = new Word.Application();
            Word.Document wordDoc = new Word.Document();
            //Gan Document bang cach add temp vao trong word
            word.Visible = true;
            Object oTemplatePath = oTempPath;
            wordDoc = word.Documents.Add(ref oTemplatePath, ref missing, ref missing, ref missing);
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
                            break;
                        case 1:
                            MaNganHang = tempRead[0].Trim();
                            break;
                        case 2:
                            MaNganHang = tempRead[0].Trim();
                            NameNganHang = tempRead[1].Trim();
                            break;
                        case 3:
                            MaNganHang = tempRead[0].Trim();
                            NameNganHang = tempRead[1].Trim();
                            break;
                        case 4:
                            MaNganHang = tempRead[0].Trim();
                            NameNganHang = tempRead[1].Trim();
                            break;
                        case 5:
                            MaNganHang = tempRead[0].Trim();
                            NameNganHang = tempRead[1].Trim();
                            break;
                        case 6:
                            MaNganHang = tempRead[0].Trim();
                            NameNganHang = tempRead[1].Trim();
                            break;
                        case 7:
                           MaNganHang = tempRead[0].Trim();
                            NameNganHang = tempRead[1].Trim();
                            break;
                        case 8:
                            MaNganHang = tempRead[0].Trim();
                            NameNganHang = tempRead[1].Trim();
                            break;
                        case 9:
                            MaNganHang = tempRead[0].Trim();
                            NameNganHang = tempRead[1].Trim();
                            break;
                        case 10:
                            MaNganHang = tempRead[0].Trim();
                            NameNganHang = tempRead[1].Trim();
                            break;
                        case 11:
                            MaNganHang = tempRead[0].Trim();
                            NameNganHang = tempRead[1].Trim();
                            break;
                        case 12:
                            MaNganHang = tempRead[0].Trim();
                            NameNganHang = tempRead[1].Trim();
                            break;
                        case 13:
                            MaNganHang = tempRead[0].Trim();
                            NameNganHang = tempRead[1].Trim();
                            break;
                        case 14:
                            MaNganHang = tempRead[0].Trim();
                            NameNganHang = tempRead[1].Trim();
                            break;
                        default:
                            break;
                    }
                }
            }
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
                    string fieldName = fieldText.Substring(11, endMerge - 11);
                    fieldName = fieldName.Trim();
                    switch (fieldName)
                    {
                        
                        case "TenChiNhanh":
                            myMergeField.Select();
                            word.Selection.TypeText(NameNganHang);
                            break;
                        case "MaChiNhanh":
                            myMergeField.Select();
                            word.Selection.TypeText(MaNganHang);
                            break;
                        case "NgayThang":
                            myMergeField.Select();
                            string ngaythang = (DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year).ToString();
                            word.Selection.TypeText(ngaythang);
                            break;
                        case "Loai1Active":
                            myMergeField.Select();
                            word.Selection.TypeText(Number_box(LoaiBox_1, mde_NgayBatDau.DateTime, mde_NgayKetthuc.DateTime , 0, 0).ToString());
                            break;
                        case "Loai2Active":
                            myMergeField.Select();
                            word.Selection.TypeText(Number_box(LoaiBox_2, mde_NgayBatDau.DateTime, mde_NgayKetthuc.DateTime, 0, 0).ToString());
                            break;
                        case "Loai3Active":
                            myMergeField.Select();
                            word.Selection.TypeText(Number_box(LoaiBox_3, mde_NgayBatDau.DateTime, mde_NgayKetthuc.DateTime, 0, 0).ToString());
                            break;
                        case "Loai1InActive":
                            myMergeField.Select();
                            word.Selection.TypeText(Number_box(LoaiBox_1, mde_NgayBatDau.DateTime, mde_NgayKetthuc.DateTime,1, 0).ToString());
                            break;
                        case "Loai2InActive":
                            myMergeField.Select();
                            word.Selection.TypeText(Number_box(LoaiBox_2, mde_NgayBatDau.DateTime, mde_NgayKetthuc.DateTime, 1, 0).ToString());
                            break;
                        case "Loai3InActive":
                            myMergeField.Select();
                            word.Selection.TypeText(Number_box(LoaiBox_3, mde_NgayBatDau.DateTime, mde_NgayKetthuc.DateTime, 1, 0).ToString());
                            break;
                        case "KiemSoat":
                            myMergeField.Select();
                            word.Selection.TypeText(" " + mtbNguoiPheDuyet.Text + " ");
                            break;
                        case "NguoiLap":
                            myMergeField.Select(); 
                            word.Selection.TypeText(mtbNguoiLapBieu.Text);
                            break;
                        default:
                            break;
                    }
                }
            }
            word.Visible = true;
            word.Caption = "Báo cáo tình hình sử dụng hợp đồng";
        }
        /// <summary>
        /// Sự kiện TenChiNhanh
        /// CreateBy: connc 10.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Sự kiện f5BaoCaoHopDong_Load
        /// CreateBy: connc 10.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public int check_contact = 0;
        app_object.Obj_LoaiBox LoaiBox_1 = new app_object.Obj_LoaiBox();
        app_object.Obj_LoaiBox LoaiBox_2 = new app_object.Obj_LoaiBox();
        app_object.Obj_LoaiBox LoaiBox_3 = new app_object.Obj_LoaiBox();
        //public string machinhanh = "VA210331";  
        private void f5BaoCaoHopDong_Load(object sender, EventArgs e)
        {
            mlNhanVien.Text = "Nhân viên: " + TenNhanVien;
            mtbNguoiLapBieu.Text = TenNhanVien;
          //  mlb_BaoCaoTinhHinh.Location = new Point(Convert.ToInt16((this.Width - mlb_BaoCaoTinhHinh.Width) / 2), 50);
          //  int x_1 = this.Width / 2 - 300 - 50;
          //  int x_2 = this.Width / 2 + 50;
          //  //vi tri label
          //  mlbNgayBatDau.Location = new Point(x_1, 120);
          //  mlb_LoaiBox.Location = new Point(x_1, 160);
          //  mlb_NguoiLap.Location = new Point(x_1, 200);

          //  mlb_NgayKetThuc.Location = new Point(x_2, 120);
          //  mlb_LoaiHopDong.Location = new Point(x_2, 160);
          //  mlb_NguoiKiemSoat.Location = new Point(x_2, 200);
          //  //vi tri text box
          //  mde_NgayBatDau.Location = new Point(mlbNgayBatDau.Location.X + mlbNgayBatDau.Size.Width , 120);
          //  mcb_LoaiBox.Location = new Point(mlb_LoaiBox.Location.X + mlb_LoaiBox.Size.Width, 160);
          //  mtbNguoiLapBieu.Location = new Point(mlb_NguoiLap.Location.X + mlb_NguoiLap.Size.Width, 200);

          //  mde_NgayKetthuc.Location = new Point(mlb_NgayKetThuc.Location.X + mlb_NgayKetThuc.Size.Width, 120);
          //  mcb_LoaiHopDong.Location = new Point(mlb_LoaiHopDong.Location.X + mlb_LoaiHopDong.Size.Width, 160);
          //  mtbNguoiPheDuyet.Location = new Point(mlb_NguoiKiemSoat.Location.X + mlb_NguoiKiemSoat.Size.Width, 200);

          ////vi tri button
          //  mbtn_InBaoCao.Location = new Point((this.Width - mbtn_InBaoCao.Width) / 2, 240);
          //  mbtn_ThongKe.Location = new Point(mbtn_InBaoCao.Location.X - mbtn_InBaoCao.Size.Width - 20, 240);
          //  mbtn_Thoat.Location = new Point(mbtn_InBaoCao.Location.X + mbtn_InBaoCao.Size.Width + 20, 240);

            LoaiBox_1.width = 50; LoaiBox_1.height = 300; LoaiBox_1.depth = 400;
            LoaiBox_2.width = 100; LoaiBox_2.height = 300; LoaiBox_2.depth = 400;
            LoaiBox_3.width = 200; LoaiBox_3.height = 300; LoaiBox_3.depth = 400;
            // date time
            mde_NgayBatDau.EditValue = DateTime.Today;
            mde_NgayKetthuc.EditValue = DateTime.Today;
            
        }
        /// <summary>
        /// Sự kiện mbtn_ThongKe_Click
        /// CreateBy: connc 10.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public int Number_box(app_object.Obj_LoaiBox LoaiBox, DateTime thoigianbatdau, DateTime thoigiankethuc, int check_contact, int hienthi)
        {
            int num = 0;
            Base.Connect connect = new Base.Connect();
            connect.InitSqlConnection();
            string sql_0 = "";
            string sql_1 = "";
            string sql_2 = "";
            try
            {

                sql_0 = @"select  fach.mandat_id, fach.vermietungsdatum, fach.laufzeit  from fach
                                where (fach.anzeighoehe = {0} or 0 = {0})
                                and fach.vermietungsdatum <= cast('{2:yyyy-MM-dd}' as date)
                                and    fach.vermietungsdatum >= cast('{1:yyyy-MM-dd}' as date) and fach.laufzeit is not null";
                sql_1 = @"select  fach.mandat_id, fach.vermietungsdatum, fach.laufzeit  from fach
                                 where (fach.anzeighoehe = {0} or 0 = {0})
                                  and ( fach.vermietungsdatum is null or fach.vermietungsdatum >cast('{2:yyyy-MM-dd}' as date) 
                                or fach.vermietungsdatum < cast('{1:yyyy-MM-dd}' as date) or fach.laufzeit is null  )";
                sql_2 = @" select fach.mandat_id, fach.vermietungsdatum, fach.laufzeit from fach
                            where (fach.anzeighoehe = {0} or 0 = {0})";
                string sql = "";
                if (check_contact == 0)
                    sql = string.Format(sql_0, LoaiBox.width, thoigianbatdau, thoigiankethuc);
                if (check_contact == 1)
                    sql = string.Format(sql_1, LoaiBox.width, thoigianbatdau, thoigiankethuc);
                if (check_contact == 2)
                    sql = string.Format(sql_2, LoaiBox.width, thoigianbatdau, thoigiankethuc);
                
                DataTable dt = connect.GetSqlDataSet(sql).Tables[0];
                int dem = 1;
                if (hienthi == 1)
                {
                    mdgv_BaoCaoTinhHinhSuDungHopDong.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                        //if (dt.Rows[i][0].ToString().Trim() != "")
                        mdgv_BaoCaoTinhHinhSuDungHopDong.Rows.Add(dem++, dt.Rows[i][0], dt.Rows[i][1].ToString().Split(' ')[0].Replace('-', '/'), dt.Rows[i][2].ToString().Split(' ')[0].Replace('-', '/'));
                }
                
                num = dt.Rows.Count;
  
            }
            catch (Exception e)
            {
                MessageBox.Show("Chọn khoảng thời gian!", "Thông báo");
            }
            return num;
        }
        
        
        /// <summary>
        /// Sự kiện mbtn_ThongKe_Click
        /// CreateBy: connc 11.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbtn_ThongKe_Click(object sender, EventArgs e)
        {
            if ((mde_NgayBatDau.EditValue == null || mde_NgayBatDau.EditValue.ToString() == "") ||(mde_NgayKetthuc.EditValue == null || mde_NgayKetthuc.EditValue.ToString() == "")) { Dictionary.MMessageBox.Error("Phải chọn khoảng thời gian!"); return; }
            int num_contact = 0;
            int check_b = 1;
            int check_e = 1;
            app_object.Obj_LoaiBox box = new app_object.Obj_LoaiBox();

            if (mcb_LoaiBox.Text.Trim() == "50x300x400")
                box.width = 50; 
            if (mcb_LoaiBox.Text.Trim() == "100x300x400")
                box.width = 100; 
            if (mcb_LoaiBox.Text.Trim() == "200x300x400")
                box.width = 200;
            if (mcb_LoaiBox.Text.Trim() == "Tất cả")
                box.width = 0;
            if (mcb_LoaiHopDong.Text == "Tất cả")
                check_contact = 2;
            if (mcb_LoaiHopDong.Text == "Hợp đồng active")
                check_contact = 0;
            if (mcb_LoaiHopDong.Text == "Hợp đồng inactive")
                check_contact = 1;
            DateTime first = mde_NgayBatDau.DateTime;
            DateTime end = mde_NgayKetthuc.DateTime;
            if (first.Year == 1)
                check_b = 0;
            if (end.Year == 1)
                check_e = 0;
                   
            num_contact = Number_box(box, mde_NgayBatDau.DateTime, mde_NgayKetthuc.DateTime, check_contact, 1);
            
        }
    }
}
