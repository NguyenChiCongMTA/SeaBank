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
using DevExpress.Utils;
using System.IO;
namespace SafeControl
{

    public partial class f4BaoCaoTiLeSuDungKet : fBase
    {
        public f1MainMenu formMainMenu { set; get; }
        public string TenNhanVien { set; get; }
        public string MaNganHang { set; get; }
        public string NameNganHang { set; get; }
        public f4BaoCaoTiLeSuDungKet()
        {
            InitializeComponent();
        }
        // Chức năng lấy CSDL về máy local
        // đường dẫn cũ
        //đường dẫn mới
        //lệnh copy
        //kết nối
        //copy đè CSDL
        //tạo backup


        /// <summary>
        /// Sự kiện f4BaoCaoTiLeSuDungKet_Load
        /// CreateBy: connc 10.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void f4BaoCaoTiLeSuDungKet_Load(object sender, EventArgs e)
        {
            mlNhanVien.Text = "Nhân viên: " + TenNhanVien;
            mtbNguoiLapBieu.Text = TenNhanVien;
            //
            // Tạm thời comment lại các vị trí fix
            // EditBy: truongnm 20.03.2022
            //
            //mlb_BaoCaoTinhHinh.Location = new Point(Convert.ToInt16((this.Width - mlb_BaoCaoTinhHinh.Width) / 2), 50);
            //int y = 100;
            //int kc = 40;
            //int x_1 = this.Width / 2 - 300 - 50;
            //int x_2 = this.Width / 2 + 50;
            
            ////vi tri label
            //mlbNgayBatDau.Location = new Point(x_1, y);
            //mde_NgayBatDau.Location = new Point(mlbNgayBatDau.Location.X + mlbNgayBatDau.Size.Width, y);

            //mlb_NgayKetThuc.Location = new Point(x_2, y);
            //mde_NgayKetthuc.Location = new Point(mlb_NgayKetThuc.Location.X + mlb_NgayKetThuc.Size.Width, y);

            //y = y + kc;
            //mlb_NguoiLap.Location = new Point(x_1, y);
            //mtbNguoiLapBieu.Location = new Point(mlb_NguoiLap.Location.X + mlb_NguoiLap.Size.Width, y);

            //mlb_NguoiKiemSoat.Location = new Point(x_2, y);
            //mtbNguoiPheDuyet.Location = new Point(mlb_NguoiKiemSoat.Location.X + mlb_NguoiKiemSoat.Size.Width, y);

            //y = y + kc;
            ////vi tri button
            //mbtn_InBaoCao.Location = new Point((this.Width - mbtn_ThongKe.Width) / 2, y);
            //mbtn_ThongKe.Location = new Point(mbtn_InBaoCao.Location.X - mbtn_ThongKe.Size.Width - 20, y);
            //mbtn_Thoat.Location = new Point(mbtn_InBaoCao.Location.X + mbtn_ThongKe.Size.Width + 20, y);

            // date time
            mde_NgayBatDau.EditValue = DateTime.Today;
            mde_NgayKetthuc.EditValue = DateTime.Today;
        }
        /// <summary>
        /// Sự kiện f4BaoCaoTiLeSuDungKet_FormClosed
        /// CreateBy: connc 10.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void f4BaoCaoTiLeSuDungKet_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMainMenu.Show();
        }
        /// <summary>
        /// Sự kiện mbtn_Thoat_Click
        /// CreateBy: connc 10.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbtn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            formMainMenu.Show();
        }
        /// <summary>
        /// Sự kiện mbtn_ThongKe_Click
        /// CreateBy: connc 10.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbtn_ThongKe_Click(object sender, EventArgs e)
        {
            Base.Connect connect = new Base.Connect();
            connect.InitSqlConnection();
            string sql = "select * from anlage";
            DataTable dt = connect.GetSqlDataSet(sql).Tables[0];
            mdtgv_TinhHinhSuDungKet.DataSource = dt;
        }
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
        public int check_contact = 0;
        app_object.Obj_LoaiBox LoaiBox_1 = new app_object.Obj_LoaiBox();
        app_object.Obj_LoaiBox LoaiBox_2 = new app_object.Obj_LoaiBox();
        app_object.Obj_LoaiBox LoaiBox_3 = new app_object.Obj_LoaiBox();

        private void mbtn_ThongKe_Click_1(object sender, EventArgs e)
        {
            
            DateTime first = mde_NgayBatDau.DateTime;
            
            Number_box(mde_NgayBatDau.DateTime);
        }
        List<int> suddung;
        List<int> dattruoc;
        List<int> tong;
        List<int> controng;
        public void Number_box( DateTime thoigianbatdau)
        {
            int num = 0;
            Base.Connect connect = new Base.Connect();
            connect.InitSqlConnection();
            string sql_sudung = "";
            string sql_dattruoc = "";
            string sql_tong = "";
            try
            {
                
                // EditBy: truongnm 13.03.2022
                
                sql_sudung = @"select fach.id, fach.vermietungsdatum, fach.laufzeit
                        from fach
                        where  fach.anzeighoehe = {0} 
                        and fach.vermietungsdatum <=  cast('{1:yyyy-MM-dd}' as date)
                        and  cast('{1:yyyy-MM-dd}' as date ) < fach.laufzeit";
                sql_dattruoc = @"select fach.id, fach.vermietungsdatum, fach.laufzeit
                        from fach
                        where  fach.anzeighoehe = {0}
                        and fach.vermietungsdatum <= cast('{1:yyyy-MM-dd}' as date)
                        and  fach.laufzeit  is null";
                sql_tong = @"select fach.id, fach.vermietungsdatum, fach.laufzeit
                        from fach
                        where  fach.anzeighoehe = {0} ";
                string sql = "";
                suddung = new List<int>();
                dattruoc = new List<int>();
                tong = new List<int>();
                controng = new List<int>();
                DataTable dt = new DataTable();
                int[] loaibox = { 50, 100, 200 };
                string[] loaibox_ = { "50*300*400", "100*300*400", "200*300*400" };
                for (int i = 0; i < loaibox.Length; i++)
                {
                    sql = string.Format(sql_sudung, loaibox[i], thoigianbatdau);
                    dt = connect.GetSqlDataSet(sql).Tables[0];
                    suddung.Add(dt.Rows.Count);
                    sql = string.Format(sql_dattruoc, loaibox[i], thoigianbatdau);
                    dt = connect.GetSqlDataSet(sql).Tables[0];
                    dattruoc.Add(dt.Rows.Count);
                    sql = string.Format(sql_tong, loaibox[i]);
                    dt = connect.GetSqlDataSet(sql).Tables[0];
                    tong.Add(dt.Rows.Count);
                    controng.Add(tong[i] - suddung[i] - dattruoc[i]);
                }
                mdtgv_TinhHinhSuDungKet.Rows.Clear();
                //
                for (int i = 0; i < loaibox_.Length; i++)
                    mdtgv_TinhHinhSuDungKet.Rows.Add(loaibox_[i], suddung[i], controng[i], dattruoc[i], tong[i]);
            }
            catch (Exception e)
            {
                MessageBox.Show("Chọn ít nhất một mốc thời gian!", "Thông báo");
            }
        }
        private void mbtn_Thoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mbtn_InBaoCao_Click_1(object sender, EventArgs e)
        {
            int check_b = 1;
            int check_e = 1;
            DateTime first = mde_NgayBatDau.DateTime;
            DateTime end = mde_NgayKetthuc.DateTime;
            if (first.Year == 1)
                check_b = 0;
            if (end.Year == 1)
                check_e = 0;
            Number_box(mde_NgayBatDau.DateTime);
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
            object oTempPath = Application.StartupPath + @"\template\3_Bao_cao_ti_le_su_dung_ket.dot";

            object missing = Missing.Value;

            Word.Application word = new Word.Application();
            Word.Document wordDoc = new Word.Document();
            //Gan Document bang cach add temp vao trong word
            word.Visible = true;
            Object oTemplatePath = oTempPath;
            wordDoc = word.Documents.Add(ref oTemplatePath, ref missing, ref missing, ref missing);

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

                        case "ChiNhanh":
                            myMergeField.Select();
                            word.Selection.TypeText(NameNganHang);
                            break;
                        case "MaChiNhanh":
                            myMergeField.Select();
                            word.Selection.TypeText(MaNganHang);
                            break;
                        case "NgayTao":
                            myMergeField.Select();
                            string ngaythang = (DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year).ToString();
                            word.Selection.TypeText(ngaythang);
                            break;
                        case "SuDungLoai1":
                            myMergeField.Select();
                            word.Selection.TypeText(suddung[0].ToString());
                            break;
                        case "TrongLoai1":
                            myMergeField.Select();
                            word.Selection.TypeText(controng[0].ToString());
                            break;
                        case "DatTruocLoai1":
                            myMergeField.Select();
                            word.Selection.TypeText(dattruoc[0].ToString());
                            break;
                        case "TongLoai1":
                            myMergeField.Select();
                            word.Selection.TypeText(tong[0].ToString());
                            break;
                        case "SuDungLoai2":
                            myMergeField.Select();
                            word.Selection.TypeText(suddung[1].ToString());
                            break;
                        case "TrongLoai2":
                            myMergeField.Select();
                            word.Selection.TypeText(controng[1].ToString());
                            break;
                        case "DatTruocLoai2":
                            myMergeField.Select();
                            word.Selection.TypeText(dattruoc[1].ToString());
                            break;
                        case "TongLoai2":
                            myMergeField.Select();
                            word.Selection.TypeText(tong[1].ToString());
                            break;
                        case "SuDungLoai3":
                            myMergeField.Select();
                            word.Selection.TypeText(suddung[2].ToString());
                            break;
                        case "TrongLoai3":
                            myMergeField.Select();
                            word.Selection.TypeText(controng[2].ToString());
                            break;
                        case "DatTruocLoai3":
                            myMergeField.Select();
                            word.Selection.TypeText(dattruoc[2].ToString());
                            break;
                        case "TongLoai3":
                            myMergeField.Select();
                            word.Selection.TypeText(tong[2].ToString());
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
            word.Caption = "Báo cáo tình hình sử dụng két";
        }
    }
}
