using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office;
using System.Data.OleDb;
using System.Reflection;
using SafeControl.Bussiness;
using SafeControl.Dictionary;
using SafeControl.Enum;
using SafeControl.Base;
using System.IO;

namespace SafeControl
{
    public partial class f2InHopDong : fBase
    {
        public f1MainMenu formMainMenu { set; get; }
        public string TenNhanVien { set; get; }
        public string MaChiNhanh { set; get; }

        private Word.Application word;
        private Word.Document wordDoc;

        public f2InHopDong()
        {
            InitializeComponent();
            word = new Word.Application();
            wordDoc = new Word.Document();

        }
        private void f2InHopDong_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMainMenu.Show();
        }

        private void f2InHopDong_Load(object sender, EventArgs e)
        {
            #region vùng nhãn
            mlNhanVien.Text = "Nhân viên: " + TenNhanVien;
            //mlb_InHopDong.Location = new Point(Convert.ToInt16((this.Width - mlb_InHopDong.Width) / 2), 30);
            //splitContainer1.SplitterDistance = 80;
            #endregion
            #region chia giao diện chính
            //int w = mPanel1.Width/3;
            //int h = splitContainer1.Size.Height - splitContainer1.SplitterDistance;
            //mPanel2.Size = new Size(w, h);
            //mPanel3.Size = new Size(w, h); 
            #endregion
            #region Giao diện khách hàng
            //mlbThongTinKhachHang.Location = new Point(Convert.ToInt16((mPanel2.Size.Width - mlbThongTinKhachHang.Width) / 2), 30);
            //int x_kh = (mPanel2.Size.Width - 322) / 2;
            //int y_kh = 100;
            //int kc = 40;
            ////vi tri ma khach hang
            //mlb_MaKhachHang.Location = new Point(x_kh, y_kh);
            //mtb_MaKhachHang.Location = new Point(x_kh+ 100, y_kh);
            //mbt_TimMaKH.Location = new Point(x_kh + 300, y_kh);
            ////vi tri ten khach hang
            //y_kh += kc;
            //mlb_TenKhachHang.Location = new Point(x_kh, y_kh);
            //mtb_TenKhachHang.Location = new Point(x_kh + 100, y_kh);
            //mbt_TimTenKH.Location = new Point(x_kh + 300, y_kh);
            ////vi tri cccd
            //y_kh += kc;
            //mlb_CCCD.Location = new Point(x_kh, y_kh);
            //mtb_CCCD.Location = new Point(x_kh + 100, y_kh);
            //mbt_TimCCCD.Location = new Point(x_kh + 300, y_kh);
            ////vi tri ma doanh nghiêp
            //y_kh += kc;
            //mlb_MaDoanhNghiep.Location = new Point(x_kh, y_kh);
            //mtb_MaDoanhNghiep.Location = new Point(x_kh + 100, y_kh);
            //mbt_TimMaDN.Location = new Point(x_kh + 300, y_kh);
            //// vi tri noi cap
            //y_kh += kc;
            //mlb_NoiCapDN.Location = new Point(x_kh, y_kh);
            //mtb_NoiCapDN.Location = new Point(x_kh + 100, y_kh);
            //// vi tri ngay cap
            //y_kh += kc;
            //mlb_NgayCapDN.Location = new Point(x_kh, y_kh);
            //mtb_NgayCapDN.Location = new Point(x_kh + 100, y_kh);
            //// vi tri dai dien
            //y_kh += kc;
            //mlb_DaiDienDN.Location = new Point(x_kh, y_kh);
            //mtb_DaiDienDN.Location = new Point(x_kh + 100, y_kh);
            //// vi tri chuc vu
            //y_kh += kc;
            //mlb_ChucVuDN.Location = new Point(x_kh, y_kh);
            //mtb_ChucVuDN.Location = new Point(x_kh + 100, y_kh);
            //// vi tri uy quyen
            //y_kh += kc;
            //mlb_UyQuyenDN.Location = new Point(x_kh, y_kh);
            //mtb_UyQuyenDN.Location = new Point(x_kh + 100, y_kh);
            //// vi tri fax
            //y_kh += kc;
            //mlb_Fax.Location = new Point(x_kh, y_kh);
            //mtb_Fax.Location = new Point(x_kh + 100, y_kh);
            #endregion
            #region Giao diện ngân hàng
            //mlbThongTinNganHang.Location = new Point(Convert.ToInt16((mPanel3.Size.Width - mlbThongTinNganHang.Width) / 2), 30);
            //int x_nh = (mPanel3.Size.Width - 322) / 2;
            ////int x_nh = 50;
            //int y_nh = 100;
            ////int kc = 40;
            ////vi tri ma chi nhanh
            //mlb_MaChiNhanh.Location = new Point(x_nh, y_nh);
            //mtb_MaChiNhanh.Location = new Point(x_nh + 100, y_nh); 
            ////vi tri ten chi nhanh
            //y_nh += kc;
            //mlb_TenChiNhanh.Location = new Point(x_nh, y_nh);
            //mtb_TenChiNhanh.Location = new Point(x_nh + 100, y_nh);
            ////vi tri SoDKKD
            //y_nh += kc;
            //mlb_SoDKKD.Location = new Point(x_nh, y_nh);
            //mtb_SoDKKD.Location = new Point(x_nh + 100, y_nh);
            ////vi tri NoiCap
            //y_nh += kc;
            //mlb_NoiCap.Location = new Point(x_nh, y_nh);
            //mtb_NoiCap.Location = new Point(x_nh + 100, y_nh);
            //// vi tri ngay cap
            //y_nh += kc;
            //mlb_NgayCap.Location = new Point(x_nh, y_nh);
            //mtb_NgayCap.Location = new Point(x_kh + 100, y_nh);
            //// vi tri dai dien
            //y_nh += kc;
            //mlb_DaiDien.Location = new Point(x_nh, y_nh);
            //mtb_DaiDien.Location = new Point(x_nh + 100, y_nh);
            //// vi tri chuc vu
            //y_nh += kc;
            //mlb_ChucVu.Location = new Point(x_nh, y_nh);
            //mtb_ChucVu.Location = new Point(x_nh + 100, y_nh);
            //// vi tri uy quyen
            //y_nh += kc;
            //mlb_QuyetDinhUQ.Location = new Point(x_nh, y_nh);
            //mtb_UyQuyen.Location = new Point(x_nh + 100, y_nh);
            //// vi tri Luu
            //y_nh += kc;
            //mbt_Luu.Location = new Point(mPanel3.Size.Width/2 - 40, y_nh);
            #endregion
            #region Giao diện hợp đồng
            //mlbThongTinHopDong.Location = new Point(Convert.ToInt16((mPanel4.Size.Width - mlbThongTinHopDong.Width) / 2), 30);
            //int x_hd = (mPanel4.Size.Width - 322) / 2;
            ////int x_nh = 50;
            //int y_hd = 100;
            //// vi tri ma hop dong
            //mlb_MaHopDong.Location = new Point(x_hd, y_hd);
            //mtb_MaHopDong.Location = new Point(x_hd + 100, y_hd);
            //mbt_TimMaHD.Location = new Point(x_hd + 300, y_hd);
            ////vi tri ngay bat dau
            ////mlb_NgayBatDau.Location = new Point(Convert.ToInt16(this.Width / 2 + 150), 160);
            ////mde_NgayBatDau.Location = new Point(Convert.ToInt16(this.Width / 2 + 150 + 100), 160);
            ////vi tri loai hop dong
            //y_hd += kc;
            //mlb_LoaiHopDong.Location = new Point(x_hd, y_hd);
            //mcb_LoaiHopDong.Location = new Point(x_hd + 100, y_hd);
            //// vi tri thong bao so ngay
            //y_hd += kc;
            //mlb_ThongBaoSoNgay.Location = new Point(x_hd, y_hd);
            //mtb_ThongBaoSoNgay.Location = new Point(x_hd + 100, y_hd);
            ////vi tri button
            //y_hd += kc;
            //mbt_TimKiem.Location = new Point(mPanel4.Size.Width / 2 - 140, y_hd);
            //mbt_In.Location = new Point(mPanel4.Size.Width / 2 - 40, y_hd);
            //mbt_Thoat.Location = new Point(mPanel4.Size.Width / 2 + 60, y_hd);
            #endregion
            //mPanel1.Size = new Size(this.Width, y_kh + 50 + splitContainer1.SplitterDistance);

            CN = ThongTinChiNhanh(MaChiNhanh);
            mtb_MaChiNhanh.Text = MaChiNhanh;
            mtb_TenChiNhanh.Text = CN.TenChiNhanh;
            mtb_DaiDien.Text = CN.DaiDien;
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
                            mtb_MaChiNhanh.Text = tempRead[0].Trim();
                            break;
                        case 2:
                            mtb_MaChiNhanh.Text = tempRead[0].Trim();
                            mtb_TenChiNhanh.Text = tempRead[1].Trim();
                            break;
                        case 3:
                            mtb_MaChiNhanh.Text = tempRead[0].Trim();
                            mtb_TenChiNhanh.Text = tempRead[1].Trim();
                            mtb_SoDKKD.Text = tempRead[2].Trim();
                            break;
                        case 4:
                            mtb_NoiCap.Text = tempRead[3].Trim();
                            mtb_MaChiNhanh.Text = tempRead[0].Trim();
                            mtb_TenChiNhanh.Text = tempRead[1].Trim();
                            mtb_SoDKKD.Text = tempRead[2].Trim();
                            break;
                        case 5:
                            mtb_NgayCap.Text = tempRead[4].Trim();
                            mtb_NoiCap.Text = tempRead[3].Trim();
                            mtb_MaChiNhanh.Text = tempRead[0].Trim();
                            mtb_TenChiNhanh.Text = tempRead[1].Trim();
                            mtb_SoDKKD.Text = tempRead[2].Trim();
                            break;
                        case 6:
                            mtb_DaiDien.Text = tempRead[5].Trim();
                            mtb_NgayCap.Text = tempRead[4].Trim();
                            mtb_NoiCap.Text = tempRead[3].Trim();
                            mtb_MaChiNhanh.Text = tempRead[0].Trim();
                            mtb_TenChiNhanh.Text = tempRead[1].Trim();
                            mtb_SoDKKD.Text = tempRead[2].Trim();
                            break;
                        case 7:
                            mtb_ChucVu.Text = tempRead[6].Trim();
                            mtb_DaiDien.Text = tempRead[5].Trim();
                            mtb_NgayCap.Text = tempRead[4].Trim();
                            mtb_NoiCap.Text = tempRead[3].Trim();
                            mtb_MaChiNhanh.Text = tempRead[0].Trim();
                            mtb_TenChiNhanh.Text = tempRead[1].Trim();
                            mtb_SoDKKD.Text = tempRead[2].Trim();
                            break;
                        case 8:
                            mtb_UyQuyen.Text = tempRead[7].Trim();
                            mtb_ChucVu.Text = tempRead[6].Trim();
                            mtb_DaiDien.Text = tempRead[5].Trim();
                            mtb_NgayCap.Text = tempRead[4].Trim();
                            mtb_NoiCap.Text = tempRead[3].Trim();
                            mtb_MaChiNhanh.Text = tempRead[0].Trim();
                            mtb_TenChiNhanh.Text = tempRead[1].Trim();
                            mtb_SoDKKD.Text = tempRead[2].Trim();
                            break;
                        case 9:
                            mtb_ThongBaoSoNgay1.Text = tempRead[8].Trim();
                            mtb_UyQuyen.Text = tempRead[7].Trim();
                            mtb_ChucVu.Text = tempRead[6].Trim();
                            mtb_DaiDien.Text = tempRead[5].Trim();
                            mtb_NgayCap.Text = tempRead[4].Trim();
                            mtb_NoiCap.Text = tempRead[3].Trim();
                            mtb_MaChiNhanh.Text = tempRead[0].Trim();
                            mtb_TenChiNhanh.Text = tempRead[1].Trim();
                            mtb_SoDKKD.Text = tempRead[2].Trim();
                            break;
                        case 10:
                            mtb_ThongBaoSoNgay2.Text = tempRead[9].Trim();
                            mtb_ThongBaoSoNgay1.Text = tempRead[8].Trim();
                            mtb_UyQuyen.Text = tempRead[7].Trim();
                            mtb_ChucVu.Text = tempRead[6].Trim();
                            mtb_DaiDien.Text = tempRead[5].Trim();
                            mtb_NgayCap.Text = tempRead[4].Trim();
                            mtb_NoiCap.Text = tempRead[3].Trim();
                            mtb_MaChiNhanh.Text = tempRead[0].Trim();
                            mtb_TenChiNhanh.Text = tempRead[1].Trim();
                            mtb_SoDKKD.Text = tempRead[2].Trim();
                            break;
                        case 11:
                            mtb_ThongBaoSoNgay2.Text = tempRead[9].Trim();
                            mtb_ThongBaoSoNgay3.Text = tempRead[10].Trim();
                            mtb_ThongBaoSoNgay1.Text = tempRead[8].Trim();
                            mtb_UyQuyen.Text = tempRead[7].Trim();
                            mtb_ChucVu.Text = tempRead[6].Trim();
                            mtb_DaiDien.Text = tempRead[5].Trim();
                            mtb_NgayCap.Text = tempRead[4].Trim();
                            mtb_NoiCap.Text = tempRead[3].Trim();
                            mtb_MaChiNhanh.Text = tempRead[0].Trim();
                            mtb_TenChiNhanh.Text = tempRead[1].Trim();
                            mtb_SoDKKD.Text = tempRead[2].Trim();
                            break;
                        case 12:
                            mtb_DiaChi.Text = tempRead[11].Trim();
                            mtb_ThongBaoSoNgay2.Text = tempRead[9].Trim();
                            mtb_ThongBaoSoNgay3.Text = tempRead[10].Trim();
                            mtb_ThongBaoSoNgay1.Text = tempRead[8].Trim();
                            mtb_UyQuyen.Text = tempRead[7].Trim();
                            mtb_ChucVu.Text = tempRead[6].Trim();
                            mtb_DaiDien.Text = tempRead[5].Trim();
                            mtb_NgayCap.Text = tempRead[4].Trim();
                            mtb_NoiCap.Text = tempRead[3].Trim();
                            mtb_MaChiNhanh.Text = tempRead[0].Trim();
                            mtb_TenChiNhanh.Text = tempRead[1].Trim();
                            mtb_SoDKKD.Text = tempRead[2].Trim();
                            break;
                        case 13:
                            mtb_DiaChi.Text = tempRead[11].Trim();
                            mtb_SoDT.Text = tempRead[12].Trim();
                            mtb_ThongBaoSoNgay2.Text = tempRead[9].Trim();
                            mtb_ThongBaoSoNgay3.Text = tempRead[10].Trim();
                            mtb_ThongBaoSoNgay1.Text = tempRead[8].Trim();
                            mtb_UyQuyen.Text = tempRead[7].Trim();
                            mtb_ChucVu.Text = tempRead[6].Trim();
                            mtb_DaiDien.Text = tempRead[5].Trim();
                            mtb_NgayCap.Text = tempRead[4].Trim();
                            mtb_NoiCap.Text = tempRead[3].Trim();
                            mtb_MaChiNhanh.Text = tempRead[0].Trim();
                            mtb_TenChiNhanh.Text = tempRead[1].Trim();
                            mtb_SoDKKD.Text = tempRead[2].Trim();
                            break;
                        case 14:
                            mtb_Fax_NH.Text = tempRead[13].Trim();
                            mtb_DiaChi.Text = tempRead[11].Trim();
                            mtb_SoDT.Text = tempRead[12].Trim();
                            mtb_ThongBaoSoNgay2.Text = tempRead[9].Trim();
                            mtb_ThongBaoSoNgay3.Text = tempRead[10].Trim();
                            mtb_ThongBaoSoNgay1.Text = tempRead[8].Trim();
                            mtb_UyQuyen.Text = tempRead[7].Trim();
                            mtb_ChucVu.Text = tempRead[6].Trim();
                            mtb_DaiDien.Text = tempRead[5].Trim();
                            mtb_NgayCap.Text = tempRead[4].Trim();
                            mtb_NoiCap.Text = tempRead[3].Trim();
                            mtb_MaChiNhanh.Text = tempRead[0].Trim();
                            mtb_TenChiNhanh.Text = tempRead[1].Trim();
                            mtb_SoDKKD.Text = tempRead[2].Trim();
                            break;
                        default:
                            break;
                    }
                }

            }
            //mcb_LoaiHopDong.SetReadOnly = true;
        }

        app_object.Obj_KhachHang KH;
        app_object.Obj_ChiNhanh CN;
        app_object.Obj_HopDong HD;
        
        /// <summary>
        /// lấy hợp đồng trong cơ sỏ dữ liệu
        /// </summary>
        /// <param name="LoaiBox"></param>
        /// <param name="thoigianbatdau"></param>
        /// <param name="thoigiankethuc"></param>
        /// <param name="check_contact"></param>
        /// <param name="check_dgv"></param>
        /// <returns></returns>
        /// 
        
        public void ThongTinKhachHang(List<app_object.Obj_KhachHang> list_kh, string makhachhang, string tenkhachhang, string cccd, string macongty, string mahopdong)
        {
            
            Base.Connect connect = new Base.Connect();
            connect.InitSqlConnection();
            string sql = @"select person.name, person.vorname,person.plz, person.strasse,person.ort, person.telefon , person.modem, fach.blz, fach.kontonummer,
                        legidat.nummer, legidat.ausstellungsdatum, legidat.ausstellungsort, fach.ustid , fach.mandat_id, fach.vermietungsdatum , fach.fachnummer, person.stammnummer
                        from person, kundfach, fach , legidat
                        where kundfach.personid = person.id  and person.legidatid = legidat.id
                        and kundfach.loeschdatum is null
                        and kundfach.fachid = fach.id
                        and ((position( upper('{1}') in upper((person.name || ' ' || person.vorname))) != 0) or 1 = {2} )
                        and ( 2 = {4} or (position( '{3}' in legidat.nummer))!= 0)
                        and ( 3 = {6} or (position( '{5}' in person.stammnummer))!= 0 )
                        and (4 = {8} or (position( upper('{7}') in upper(fach.ustid)))!= 0)
                        and (5 = {10} or (position( '{9}' in fach.mandat_id))!= 0)
                        and   fach.mandat_id !='' and fach.mandat_id is not null    ";
            int i2 = 1, i4 = 2, i6 = 3, i8 = 4, i10 = 5;
            if (makhachhang != "")
                i6 = 0;
            if (tenkhachhang != "")
                i2 = 0;
            if (cccd != "")
                i4 = 0;
            if (macongty != "")
                i8 = 0;
            if (mahopdong != "")
                i10 = 0;
            sql = string.Format(sql, tenkhachhang.Trim(), tenkhachhang.Trim(), i2, cccd, i4, makhachhang.Trim() != "" ? makhachhang.Trim() : (-1).ToString(), i6, macongty.Trim(), i8, mahopdong.Trim(), i10);
            DataTable dt = connect.GetSqlDataSet(sql).Tables[0];
            if(dt.Rows.Count>0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    KH = new app_object.Obj_KhachHang();
                    KH.TenKhachHang = dt.Rows[j][0].ToString() + " " + dt.Rows[j][1].ToString();
                    KH.DiaChi = dt.Rows[j][2].ToString() + dt.Rows[j][3].ToString() + ", " + dt.Rows[j][4].ToString();
                    KH.DienThoai = dt.Rows[j][5].ToString();
                    KH.SoCCCD = dt.Rows[j][9].ToString();
                    KH.NgayCap = dt.Rows[j][10].ToString().Split(' ')[0];
                    KH.NoiCap = dt.Rows[j][11].ToString();
                    KH.Email = dt.Rows[j][6].ToString();
                    KH.SoTaiKhoan = dt.Rows[j][7].ToString();
                    KH.SoTheTinDung = dt.Rows[j][8].ToString();
                    KH.MaHopDong = dt.Rows[j][13].ToString();
                    KH.NgayBatDau = dt.Rows[j][14].ToString().Split(' ')[0];
                    KH.MaKhachHang = dt.Rows[j][16].ToString();
                    List<string> masoket = new List<string>();

                    for (int i = j; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][16].ToString() == KH.MaKhachHang)
                            masoket.Add(dt.Rows[i][15].ToString());
                    }
                    KH.MaSoket = masoket;
                    list_kh.Add(KH);
                }
                ///list_kh.Add(KH);
                /*
                for(int t = 0; t<list_kh.Count; t++)
                {
                    for (int i = 0; i < list_kh[t].MaSoket.Count; i++)
                    {
                        sql = @"select person.name, person.vorname,person.plz, person.strasse,person.ort, person.telefon , person.modem, fach.blz, fach.kontonummer,
                        legidat.nummer, legidat.ausstellungsdatum, legidat.ausstellungsort, fach.ustid , fach.mandat_id, fach.vermietungsdatum , fach.fachnummer, person.stammnummer
                        from person, kundfach, fach , legidat
                        where  kundfach.fachid = fach.id and fach.fachnummer = {0} and  person.stammnummer != '{1}'  and kundfach.personid = person.id  and person.legidatid = legidat.id
                        and kundfach.loeschdatum is null";

                        sql = string.Format(sql, list_kh[t].MaSoket[i], list_kh[t].MaKhachHang);
                        DataTable dt1 = connect.GetSqlDataSet(sql).Tables[0];
                        if (dt1.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt1.Rows.Count; j++)
                            {
                                KH = new app_object.Obj_KhachHang();
                                KH.TenKhachHang = dt1.Rows[j][1].ToString() + " " + dt1.Rows[j][0].ToString();
                                KH.DiaChi = dt1.Rows[j][2].ToString() + dt1.Rows[j][3].ToString() + ", " + dt1.Rows[j][4].ToString();
                                KH.DienThoai = dt1.Rows[j][5].ToString();
                                KH.SoCCCD = dt1.Rows[j][9].ToString();
                                KH.NgayCap = dt1.Rows[j][10].ToString().Split(' ')[0];
                                KH.NoiCap = dt1.Rows[j][11].ToString();
                                KH.Email = dt1.Rows[j][6].ToString();
                                KH.SoTaiKhoan = dt1.Rows[j][7].ToString();
                                KH.SoTheTinDung = dt1.Rows[j][8].ToString();
                                KH.MaHopDong = dt1.Rows[j][13].ToString();
                                KH.NgayBatDau = dt1.Rows[j][14].ToString().Split(' ')[0];
                                List<string> masoket1 = new List<string>();
                                masoket1.Add(dt1.Rows[j][15].ToString());
                                KH.MaSoket = masoket1;
                                KH.MaKhachHang = dt1.Rows[j][16].ToString();
                                list_kh.Add(KH);
                            }

                        }
                    }
                }*/
                
                
            }
            
        }
        public app_object.Obj_ChiNhanh ThongTinChiNhanh(string machinhanh)
        {
            CN = new app_object.Obj_ChiNhanh();
            Base.Connect connect = new Base.Connect();
            connect.InitSqlConnection();
            string sql = "";

            sql = @"select d.name,d.plz,d.strasse, d.ort, d.telefon, d.fax, d.ansprechpartner, d.email
                    from dmf_firma as d , dmf_offices
                    where dmf_offices.name = '{0}'  and dmf_offices.dmf_firma_id = d.id";
            sql = string.Format(sql, machinhanh);
            DataTable dt = connect.GetSqlDataSet(sql).Tables[0];
            CN.TenChiNhanh = dt.Rows[0][0].ToString();
            CN.DiaChi = dt.Rows[0][1].ToString() + dt.Rows[0][2].ToString() + ", " + dt.Rows[0][3].ToString();
            CN.DienThoai = dt.Rows[0][4].ToString();
            CN.Fax = dt.Rows[0][5].ToString();
            CN.DaiDien = dt.Rows[0][6].ToString();
            CN.Email = dt.Rows[0][7].ToString();
            return CN;
        }
        public app_object.Obj_HopDong ThongTinHopDong(string mahopdong)
        {
            HD = new app_object.Obj_HopDong();
            Base.Connect connect = new Base.Connect();
            connect.InitSqlConnection();
            string sql = "";

            sql = @"select fach.mandat_id, fach.id, groessen.bezeichnung, fach.vermietungsdatum, fach.laufzeit, fach.schluesselnr
                    from fach , groessen
                    where     fach.mandat_id = '{0}'  and fach.groessenid = groessen.id";
            sql = string.Format(sql, mahopdong);
            DataTable dt = connect.GetSqlDataSet(sql).Tables[0];
            HD.SoHopDong = dt.Rows[0][0].ToString();
            HD.MaKet = dt.Rows[0][1].ToString();
            HD.LoaiKet = dt.Rows[0][2].ToString();
            HD.NgayBatDau = dt.Rows[0][3].ToString();
            HD.NgayKetThuc = dt.Rows[0][4].ToString();
            HD.MaChiaKhoa = dt.Rows[0][5].ToString();
            sql = @"SELECT   SUM(tempTable.betrag)
                    FROM (
                    select  fach.mandat_id,DMF_ABRECH_GEBUEHREN.betrag
                    from fach , DMF_ABRECH_GEBUEHREN , DMF_ABRECH
                    where
                    fach.mandat_id = '{0}'
                    and DMF_ABRECH.fachid = fach.id
                    and DMF_ABRECH.id =  DMF_ABRECH_GEBUEHREN.dmf_abrech_id
                    group by   fach.mandat_id  ,DMF_ABRECH_GEBUEHREN.betrag
                    )   AS tempTable";
            sql = string.Format(sql, mahopdong);
            dt = connect.GetSqlDataSet(sql).Tables[0];
            HD.PhiThanhToan = dt.Rows[0][0].ToString();
            return HD;
        }
        List<app_object.Obj_KhachHang> list_KH;
        
        private void mbt_TimKiem_Click(object sender, EventArgs e)
        {
            list_KH = new List<app_object.Obj_KhachHang>();
            string MaKhachHang = mtb_MaKhachHang.Text.Trim();
            string TenKhachHang = mtb_TenKhachHang.Text.Trim();
            string NgayBatDau = Convert.ToString(mde_NgayBatDau.DateTime.Month + "-" + mde_NgayBatDau.DateTime.Day + "-" + mde_NgayBatDau.DateTime.Year);
            string CCCD = mtb_CCCD.Text;
            string MaCongTy = mtb_MaDoanhNghiep.Text;
            string MaHopDong = mtb_MaHopDong.Text;
            if (MaKhachHang == "" && TenKhachHang == "" && CCCD == "" && MaCongTy == "" && MaHopDong == "")
            {
                MessageBox.Show("Nhập thông tin cần tìm kiếm!", "Thông báo");
            }
            else
            {
                ThongTinKhachHang(list_KH, MaKhachHang, TenKhachHang, CCCD, MaCongTy, MaHopDong);
                mdgv_ThongTinKhachHang.Rows.Clear();
                if (list_KH.Count > 0)
                {
                    int dem = 1;
                    for (int i = 0; i < list_KH[0].MaSoket.Count; i++)
                    {

                        mdgv_ThongTinKhachHang.Rows.Add(dem++, list_KH[0].MaHopDong, list_KH[0].TenKhachHang, list_KH[0].NgayBatDau, list_KH[0].DiaChi, list_KH[0].DienThoai, list_KH[0].SoCCCD, list_KH[0].NgayCap, list_KH[0].NoiCap, list_KH[0].Email, list_KH[0].SoTaiKhoan, list_KH[0].SoTheTinDung, list_KH[0].MaSoket[i], list_KH[0].MaKhachHang);
                    }
                    for (int i = 1; i < list_KH.Count; i++)
                    {

                        mdgv_ThongTinKhachHang.Rows.Add(dem++, list_KH[i].MaHopDong, list_KH[i].TenKhachHang, list_KH[i].NgayBatDau, list_KH[i].DiaChi, list_KH[i].DienThoai, list_KH[i].SoCCCD, list_KH[i].NgayCap, list_KH[i].NoiCap, list_KH[i].Email, list_KH[i].SoTaiKhoan, list_KH[i].SoTheTinDung, list_KH[i].MaSoket[0], list_KH[i].MaKhachHang);
                    }
                }
            }
            
        }

        public List<app_object.Obj_KhachHang> KhachHangChung(List<app_object.Obj_KhachHang> list_kh, string MaKhachHang)
        {
            list_kh = new List<app_object.Obj_KhachHang>();
            Base.Connect connect = new Base.Connect();
            connect.InitSqlConnection();
            string sql = "";

            sql = @"select person.name, person.vorname, person.plz, person.strasse, person.ort, person.telefon, person.modem, fach.blz, fach.kontonummer,
                    legidat.nummer, legidat.ausstellungsdatum, legidat.ausstellungsort, fach.ustid , fach.mandat_id, fach.vermietungsdatum, fach.fachnummer, person.stammnummer
                    from person, kundfach, fach , legidat
                    where  kundfach.fachid = fach.id and person.stammnummer = '{0}' and kundfach.personid = person.id  and person.legidatid = legidat.id
                    and kundfach.loeschdatum is null";
            sql = string.Format(sql, MaKhachHang);
            DataTable dt = connect.GetSqlDataSet(sql).Tables[0];
            
            
            KH = new app_object.Obj_KhachHang();
            KH.TenKhachHang = dt.Rows[0][0].ToString().ToUpper() + " " + dt.Rows[0][1].ToString().ToUpper();
            KH.DiaChi = dt.Rows[0][2].ToString() + dt.Rows[0][3].ToString() + ", " + dt.Rows[0][4].ToString();
            KH.DienThoai = dt.Rows[0][5].ToString();
            KH.SoCCCD = dt.Rows[0][9].ToString();
            KH.NgayCap = dt.Rows[0][10].ToString().Split(' ')[0].Replace('-','/');
            KH.NoiCap = dt.Rows[0][11].ToString();
            KH.Email = dt.Rows[0][6].ToString();
            KH.SoTaiKhoan = dt.Rows[0][7].ToString();
            KH.SoTheTinDung = dt.Rows[0][8].ToString();
            KH.MaCongTy = dt.Rows[0][12].ToString();
            KH.MaHopDong = dt.Rows[0][13].ToString();
            KH.NgayBatDau = dt.Rows[0][14].ToString().Split(' ')[0];
            string masoket = dt.Rows[0][15].ToString().Split(' ')[0];
            KH.MaKhachHang = dt.Rows[0][16].ToString();
            list_kh.Add(KH);
            
            sql = @"select person.name, person.vorname,person.plz, person.strasse,person.ort, person.telefon , person.modem, fach.blz, fach.kontonummer,
                    legidat.nummer, legidat.ausstellungsdatum, legidat.ausstellungsort, fach.ustid , fach.mandat_id, fach.vermietungsdatum , fach.fachnummer, person.stammnummer
                    from person, kundfach, fach , legidat
                    where  kundfach.fachid = fach.id and fach.fachnummer = {0} and  person.stammnummer != '{1}'  and kundfach.personid = person.id  and person.legidatid = legidat.id
                    and kundfach.loeschdatum is null";

            sql = string.Format(sql, masoket, list_kh[0].MaKhachHang);
            DataTable dt1 = connect.GetSqlDataSet(sql).Tables[0];
            if (dt1.Rows.Count > 0)
            {
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    KH = new app_object.Obj_KhachHang();
                    KH.TenKhachHang = dt1.Rows[j][0].ToString() + " " + dt1.Rows[j][1].ToString();
                    KH.DiaChi = dt1.Rows[j][2].ToString() + dt1.Rows[j][3].ToString() + ", " + dt1.Rows[j][4].ToString();
                    KH.DienThoai = dt1.Rows[j][5].ToString();
                    KH.SoCCCD = dt1.Rows[j][9].ToString();
                    KH.NgayCap = dt1.Rows[j][10].ToString().Split(' ')[0];
                    KH.NoiCap = dt1.Rows[j][11].ToString();
                    KH.Email = dt1.Rows[j][6].ToString();
                    KH.SoTaiKhoan = dt1.Rows[j][7].ToString();
                    KH.SoTheTinDung = dt1.Rows[j][8].ToString();
                    KH.MaHopDong = dt1.Rows[j][13].ToString();
                    KH.NgayBatDau = dt1.Rows[j][14].ToString().Split(' ')[0];
                    List<string> masoket1 = new List<string>();
                    masoket1.Add(dt1.Rows[j][15].ToString());
                    KH.MaKhachHang = dt1.Rows[j][16].ToString();
                    list_kh.Add(KH);
                }

            }
            return list_kh;
        }

        app_object.Obj_KhachHang K_H;
        private void mDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Base.Connect connect = new Base.Connect();
            connect.InitSqlConnection();
            string sql = @"select person.name, person.vorname,person.plz, person.strasse,person.ort, person.telefon , person.modem, fach.blz, fach.kontonummer,
                        legidat.nummer, legidat.ausstellungsdatum, legidat.ausstellungsort, fach.ustid , fach.mandat_id, fach.vermietungsdatum , fach.fachnummer, person.stammnummer
                        from person, kundfach, fach , legidat
                        where kundfach.personid = person.id  and person.legidatid = legidat.id
                        and kundfach.loeschdatum is null
                        and kundfach.fachid = fach.id
                        and (person.stammnummer = '{0}' )                     
                        and (fach.mandat_id = '{1}')";
            
            sql = string.Format(sql, mdgv_ThongTinKhachHang.SelectedRows[0].Cells[13].Value.ToString(), mdgv_ThongTinKhachHang.SelectedRows[0].Cells[1].Value.ToString());
            DataTable dt = connect.GetSqlDataSet(sql).Tables[0];
            mtb_TenKhachHang.Text = mdgv_ThongTinKhachHang.SelectedRows[0].Cells[2].Value.ToString();
            mtb_MaKhachHang.Text = mdgv_ThongTinKhachHang.SelectedRows[0].Cells[13].Value.ToString();
            mtb_CCCD.Text = mdgv_ThongTinKhachHang.SelectedRows[0].Cells[6].Value.ToString();
            mtb_MaDoanhNghiep.Text = dt.Rows[0][12].ToString();
            mtb_MaHopDong.Text = mdgv_ThongTinKhachHang.SelectedRows[0].Cells[1].Value.ToString();

        }
        
        public void InsertWord(string path, app_object.Obj_HopDong HD, app_object.Obj_ChiNhanh CN, List<app_object.Obj_KhachHang> list_kh, int i, string title)
        {
                object missing = Missing.Value;

                //Gan Document bang cach add temp vao trong word
                
                Object oTemplatePath = path;
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
                        DateTime start_time;
                        string time = "";
                        switch (fieldName)
                        {

                            case "SoHopDong":
                                myMergeField.Select();
                                word.Selection.TypeText(HD.SoHopDong);
                                break;
                            case "NgayThangNam":
                                myMergeField.Select();
                                word.Selection.TypeText(( "ngày "+DateTime.Today.Day + " tháng " + DateTime.Today.Month + " năm " + DateTime.Today.Year).ToString());
                                break;
                            case "ChiNhanh":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_TenChiNhanh.Text);
                                break;
                            case "CustName":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh[0].TenKhachHang);
                                break;
                            case "BussNo":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh[0].MaCongTy != "" ? list_kh[0].MaCongTy : " ");
                                break;
                            case "CustAddress":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh[0].DiaChi != "" ? list_kh[0].DiaChi : " ");
                                break;
                            case "CustPhoneNumber":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh[0].DienThoai != "" ? list_kh[0].DienThoai : " ");
                                break;
                            case "CustCertificateNo":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh[0].SoCCCD != "" ? list_kh[0].SoCCCD : " ");
                                break;
                            case "Issuedate":
                                myMergeField.Select();
                                //word.Selection.TypeText(list_kh[0].NgayCap != "" ? list_kh[0].NgayCap : " ");
                                if (list_kh[0].NgayCap.Trim() != "")
                                {
                                    myMergeField.Select();
                                    start_time = Convert.ToDateTime(list_kh[0].NgayCap);
                                    time = "";

                                    if (Convert.ToInt16(start_time.Day.ToString()) >= 10)
                                        time = start_time.Day.ToString() + "/";
                                    else
                                        time = "0" + start_time.Day.ToString() + "/";

                                    if (Convert.ToInt16(start_time.Month.ToString()) >= 10)
                                        time = time + start_time.Month.ToString() + "/";
                                    else
                                        time = time + "0" + start_time.Month.ToString() + "/";

                                    time = time + start_time.Year.ToString();
                                    word.Selection.TypeText(time);
                                }
                                else
                                    word.Selection.TypeText(" ");
                                break;
                            case "IssueBy":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh[0].NoiCap != "" ? list_kh[0].NoiCap : " ");
                                break;
                            case "CustEmail":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh[0].Email != "" ? list_kh[0].Email : " ");
                                break;
                            case "CustAccountNumber":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh[0].SoTaiKhoan != "" ? list_kh[0].SoTheTinDung : " ");//sothetindung
                                break;
                            case "DebitCreditNumber":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh[0].SoTheTinDung != "" ? list_kh[0].SoTaiKhoan : " ");//sotaikhoan
                                break;
                            case "Cust2Name":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh.Count>1 ? list_kh[i].TenKhachHang : " ");
                                break;
                            case "Cust2Address":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh.Count>1 ? list_kh[i].DiaChi : " ");
                                break;
                            case "Cust2PhoneNumber":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh.Count>1 ? list_kh[i].DienThoai : " ");
                                break;
                            case "Cust2CertificateNo":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh.Count>1 ? list_kh[i].SoCCCD : " ");
                                break;
                            case "Cust2Issuedate":
                                myMergeField.Select();
                                //word.Selection.TypeText(list_kh.Count>1 ? list_kh[i].NgayCap : " ");
                                if (list_kh.Count>1 && list_kh[i].NgayCap.Trim() != "")
                                {
                                    myMergeField.Select();
                                    start_time = Convert.ToDateTime(list_kh[i].NgayCap);
                                    time = "";

                                    if (Convert.ToInt16(start_time.Day.ToString()) >= 10)
                                        time = start_time.Day.ToString() + "/";
                                    else
                                        time = "0" + start_time.Day.ToString() + "/";

                                    if (Convert.ToInt16(start_time.Month.ToString()) >= 10)
                                        time = time + start_time.Month.ToString() + "/";
                                    else
                                        time = time + "0" + start_time.Month.ToString() + "/";

                                    time = time + start_time.Year.ToString();
                                    word.Selection.TypeText(time);
                                }
                                else
                                    word.Selection.TypeText(" ");
                                break;
                            case "Cust2IssueBy":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh.Count>1 ? list_kh[i].NoiCap : " ");
                                break;
                            case "Cust2Email":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh.Count>1 ? list_kh[i].Email : " ");
                                break;
                            case "Cust2AccountNumber":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh.Count>1 ? list_kh[i].SoTheTinDung : " ");//sothetindung
                                break;
                            case "Cust2DebitCreditNumber":
                                myMergeField.Select();
                                word.Selection.TypeText(list_kh.Count > 1 ? list_kh[1].SoTaiKhoan : " ");//sotaikhoan
                                break;
                            case "BankBranch":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_TenChiNhanh.Text);
                                break;
                            case "BankCertificateNumber":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_SoDKKD.Text);
                                break;
                            case "BankIssueBy":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_NoiCap.Text);
                                break;
                            case "BankIssueDate":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_NgayCap.Text);
                                break;
                            case "BankAddress":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_DiaChi.Text);
                                break;
                            case "BankPhoneNumber":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_SoDT.Text);
                                break;
                            case "BankFax":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_Fax_NH.Text);
                                break;
                            case "BankEmail":
                                myMergeField.Select();
                                word.Selection.TypeText(CN.Email);
                                break;
                            case "BankRepresentatives":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_DaiDien.Text);
                                break;
                            case "BankPosition":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_ChucVu.Text);
                                break;
                            case "BankAuthorizationNo":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_UyQuyen.Text);
                                break;
                            case "BussIssueBy":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_NoiCapDN.Text);
                                break;
                            case "BussIssueDate":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_NgayCapDN.Text);
                                break;
                            case "CustNameBuss":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_DaiDienDN.Text);
                                break;
                            case "BussPosition":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_ChucVuDN.Text);
                                break;
                            case "BussAuthorizationNo":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_UyQuyenDN.Text);
                                break;
                            case "BussFax":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_Fax.Text);
                                break;
                            case "MaKet":
                                myMergeField.Select();
                                word.Selection.TypeText(HD.MaKet);
                                break;
                            case "DanhSachKet":                             
                                myMergeField.Select();
                                //Gán khoảng trắng để xóa tên field
                                word.Selection.TypeText(" ");
                                //Ghi danh sách ứng viên vào bảng có 4 cột, tại vị trí start, end
                                ExportTable_DanhSachKet(5, word.Selection.End);
                                break;
                            case "LoaiNganKet":
                                myMergeField.Select();
                                word.Selection.TypeText(HD.LoaiKet);
                                break;
                            case "KichThuoc":
                                myMergeField.Select();
                                word.Selection.TypeText(HD.LoaiKet);
                                break;
                            case "MaChiaKhoa":
                                myMergeField.Select();
                                word.Selection.TypeText(HD.MaChiaKhoa);
                                break;
                            case "LoaiChiaKhoa":
                                myMergeField.Select();
                                word.Selection.TypeText(HD.MaChiaKhoa);
                                break;
                            case "RentMonth":
                                int SoThang = 0;
                                if (HD.NgayBatDau != "" && HD.NgayKetThuc != "")
                                {
                                    DateTime startDate = Convert.ToDateTime(HD.NgayBatDau);
                                    DateTime endDate = Convert.ToDateTime(HD.NgayKetThuc);
                                    SoThang = Math.Abs((startDate.Month - endDate.Month) + 12 * (startDate.Year - endDate.Year));
                                }
                                myMergeField.Select();
                                word.Selection.TypeText(SoThang.ToString());
                                break;
                            case "FromDate":
                                myMergeField.Select();
                                start_time = Convert.ToDateTime(HD.NgayBatDau);
                                time ="";
                                
                                if(Convert.ToInt16(start_time.Day.ToString()) >= 10)
                                    time = start_time.Day.ToString() + "/";
                                else
                                    time = "0" + start_time.Day.ToString() + "/";

                                if(Convert.ToInt16(start_time.Month.ToString()) >= 10)
                                    time = time + start_time.Month.ToString() + "/";
                                else
                                    time = time + "0" + start_time.Month.ToString() + "/";

                                time = time + start_time.Year.ToString();
                                word.Selection.TypeText(time);
                                break;
                            case "ToDate":
                                myMergeField.Select();
                                DateTime end_time = Convert.ToDateTime(HD.NgayBatDau);
                                string time1 ="";
                                if (Convert.ToInt16(end_time.Day.ToString()) >= 10)
                                    time1 = end_time.Day.ToString() + "/";
                                else
                                    time1 = "0" + end_time.Day.ToString() + "/";

                                if (Convert.ToInt16(end_time.Month.ToString()) >= 10)
                                    time1 =time1+ end_time.Month.ToString() + "/";
                                else
                                    time1 = time1 + "0" + end_time.Month.ToString() + "/";

                                time1 = time1 + end_time.Year.ToString();
                                word.Selection.TypeText(time1);
                                break;
                            case "Amount":
                                myMergeField.Select();
                                word.Selection.TypeText(" ");
                                break;
                            case "Amountbyword":
                                myMergeField.Select();
                                word.Selection.TypeText(" ");
                                break;
                            case "Fee":
                                myMergeField.Select();
                                word.Selection.TypeText(" ");
                                break;
                            case "FeeByWord":
                                myMergeField.Select();
                                word.Selection.TypeText(" ");
                                break;
                            case "TotalFee":
                                myMergeField.Select();
                                word.Selection.TypeText(" ");
                                break;
                            case "TotalFeeByWord":
                                myMergeField.Select();
                                word.Selection.TypeText(" ");
                                break;
                            case "EndDays1":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_ThongBaoSoNgay1.Text);
                                break;
                            case "EndDays2":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_ThongBaoSoNgay2.Text);
                                break;
                            case "EndDays3":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_ThongBaoSoNgay3.Text);
                                break;
                            case "RenewDays":
                                myMergeField.Select();
                                word.Selection.TypeText(mtb_ThongBaoSoNgay1.Text);
                                break;
                            case "NumerOfChange":
                                myMergeField.Select();
                                word.Selection.TypeText("  ");
                                break;
                            case "ChangeDate":
                                myMergeField.Select();
                                word.Selection.TypeText("  ");
                                break;
                            case "BussIssueChangeBy":
                                myMergeField.Select();
                                word.Selection.TypeText("  ");
                                break;
                            
                            default:
                                break;
                        }
                    }
                }
                word.Visible = true;
                word.Caption = title;
                
        }
        public string join_unit(string n)
       {
           int sokytu = n.Length;
           int sodonvi = (sokytu % 3 > 0) ? (sokytu / 3 + 1) : (sokytu / 3);
           n = n.PadLeft(sodonvi * 3, '0');
           sokytu = n.Length;
           string chuoi = "";
           int i = 1;
           while (i <= sodonvi)
           {
               if (i == sodonvi) chuoi = join_number((int.Parse(n.Substring(sokytu - (i * 3), 3))).ToString()) + unit(i) + chuoi;
               else chuoi = join_number(n.Substring(sokytu - (i * 3), 3)) + unit(i) + chuoi;
               i += 1;
           }
           return chuoi;
       }


        public string unit(int n)
       {
           string chuoi = "";
           if (n == 1) chuoi = " đồng ";
           else if (n == 2) chuoi = " nghìn ";
           else if (n == 3) chuoi = " triệu ";
           else if (n == 4) chuoi = " tỷ ";
           else if (n == 5) chuoi = " nghìn tỷ ";
           else if (n == 6) chuoi = " triệu tỷ ";
           else if (n == 7) chuoi = " tỷ tỷ ";
           return chuoi;
       }


        public string convert_number(string n)
       {
           string chuoi = "";
           if (n == "0") chuoi = "không";
           else if (n == "1") chuoi = "một";
           else if (n == "2") chuoi = "hai";
           else if (n == "3") chuoi = "ba";
           else if (n == "4") chuoi = "bốn";
           else if (n == "5") chuoi = "năm";
           else if (n == "6") chuoi = "sáu";
           else if (n == "7") chuoi = "bảy";
           else if (n == "8") chuoi = "tám";
           else if (n == "9") chuoi = "chín";
           return chuoi;
       }


        public string join_number(string n)
       {
           string chuoi = "";
           int i = 1, j = n.Length;
           while (i <= j)
           {
               if (i == 1) chuoi = convert_number(n.Substring(j - i, 1)) + chuoi;
               else if (i == 2) chuoi = convert_number(n.Substring(j - i, 1)) + " mươi " + chuoi;
               else if (i == 3) chuoi = convert_number(n.Substring(j - i, 1)) + " trăm " + chuoi;
               i += 1;
           }
           return chuoi;
       }
        
        
        private void ExportTable_DanhSachKet(int NColumns, object Start)
        {
            //Khoi tao range theo vi tri de add Ungvien len Word
            Word.Range range = wordDoc.Range(ref Start, ref Start);
            object missing = System.Type.Missing;
            //Tạo bảng với 1 hàng và NColumns cột tại vùng range
            Word.Table tbl = wordDoc.Tables.Add(range, 1, NColumns, ref missing, ref missing);
            //Phúc
            tbl.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            tbl.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;

            Base.Connect connect = new Base.Connect();
            connect.InitSqlConnection();
            string sql = "";
            sql = @"select fach.mandat_id, fach.id, groessen.bezeichnung, fach.vermietungsdatum, fach.laufzeit, fach.schluesselnr
                    from fach , groessen , person, kundfach
                    where    person.stammnummer = '{0}'  and fach.groessenid = groessen.id
                    and kundfach.fachid = fach.id and kundfach.personid = person.id
                    and kundfach.loeschdatum is null";

            sql = string.Format(sql, mdgv_ThongTinKhachHang.SelectedRows[0].Cells[13].Value.ToString());
            DataTable dt = connect.GetSqlDataSet(sql).Tables[0];
            //Add thêm rows vào bảng  
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Word.Row newRow = wordDoc.Tables[1].Rows.Add(ref missing);
                //newRow.Range.Font.Bold = 0;
                //newRow.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                
                newRow.Cells[1].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[2].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[3].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[4].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                newRow.Cells[5].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                //Đã căn giữa
                newRow.Cells[1].Range.Text = (i + 1).ToString();
                
                newRow.Cells[2].Range.Text = dt.Rows[i][1].ToString();

                newRow.Cells[3].Range.Text = dt.Rows[i][2].ToString();

                newRow.Cells[4].Range.Text = dt.Rows[i][2].ToString();

                newRow.Cells[5].Range.Text = dt.Rows[i][5].ToString();

                
            }
            if (tbl.Rows.Count > 1)
            {
                //tbl.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustifyLow;
                tbl.Range.ParagraphFormat.LineSpacing = 9.5F;
                tbl.Range.ParagraphFormat.SpaceBefore = 4.5F;
                tbl.Range.ParagraphFormat.SpaceAfter = 2.0F;
                tbl.Range.Borders.Enable = 1;
                tbl.Rows[1].Range.Font.Italic = 1;

                tbl.Columns[1].Width = 20;
                tbl.Columns[2].Width = 120;
                tbl.Columns[3].Width = 70;
                tbl.Columns[4].Width = 70;
                tbl.Columns[5].Width = 70;
                
                //Phúc, fit window
                tbl.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow);
                //Repeat header, lặp lại header
                tbl.Rows[1].HeadingFormat = -1;
                tbl.ApplyStyleHeadingRows = true;

                tbl.Rows[1].Cells[1].Range.Text = "STT";
                tbl.Rows[1].Cells[1].Range.ParagraphFormat.Alignment =
                    Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                tbl.Rows[1].Cells[2].Range.Text = "Mã số tủ két an toàn";
                tbl.Rows[1].Cells[2].Range.ParagraphFormat.Alignment =
                    Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                tbl.Rows[1].Cells[3].Range.Text = "Loại tủ két";
                tbl.Rows[1].Cells[3].Range.ParagraphFormat.Alignment =
                    Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                tbl.Rows[1].Cells[4].Range.Text = "Kích thước";
                tbl.Rows[1].Cells[4].Range.ParagraphFormat.Alignment =
                    Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                tbl.Rows[1].Cells[5].Range.Text = "Mã số chìa khóa";
                tbl.Rows[1].Cells[5].Range.ParagraphFormat.Alignment =
                    Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
            else
            {
                tbl.Rows[1].Delete();
            }
        }
        public string replace_special_word(string chuoi)
       {
           chuoi = chuoi.Replace("không mươi không ", "");
           chuoi = chuoi.Replace("không mươi", "lẻ");
           chuoi = chuoi.Replace("i không", "i");
           chuoi = chuoi.Replace("i năm", "i lăm");
           chuoi = chuoi.Replace("một mươi", "mười");
           chuoi = chuoi.Replace("mươi một", "mươi mốt");
           return chuoi;
       }
        private void mbt_In_Click(object sender, EventArgs e)
        {
            if (mdgv_ThongTinKhachHang.SelectedRows.Count == 0 || mtb_MaHopDong.Text == "" || mtb_MaKhachHang.Text == "" || mtb_CCCD.Text == "")
                MessageBox.Show("Chọn hợp đồng cần in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    HD = ThongTinHopDong(mdgv_ThongTinKhachHang.SelectedRows[0].Cells[1].Value.ToString());
                    list_KH = new List<app_object.Obj_KhachHang>();
                    list_KH = KhachHangChung(list_KH, mtb_MaKhachHang.Text);
                    MProcess.KillProcess("WINWORD");
                    // Đóng rồi thì khởi tạo lại!
                    word = new Word.Application();
                    wordDoc = new Word.Document();
                    if (mcb_LoaiHopDong.Text == "1. Hợp đồng cho thuê tủ két an toàn cá nhân")
                    {
                        string oTempPath = Application.StartupPath + @"\template\2_Hop_dong_cho_thue_tu_ket_an_toan_1.dot";
                        string title = "HỢP ĐỒNG CHO THUÊ TỦ KÉT AN TOÀN CÁ NHÂN";
                        if (list_KH.Count > 1)
                        {
                            for (int i = 1; i < list_KH.Count; i++)
                            {
                                InsertWord(oTempPath, HD, CN, list_KH, i, title);
                            }
                        }
                        else
                            InsertWord(oTempPath, HD, CN, list_KH, 9, title);
                    }
                    if (mcb_LoaiHopDong.Text == "2. Hợp đồng cho thuê tủ két an toàn doanh nghiệp")
                    {
                        string oTempPath = Application.StartupPath + @"\template\2_Hop_dong_cho_thue_tu_ket_an_toan_2.dot";
                        string title = "HỢP ĐỒNG CHO THUÊ TỦ KÉT AN TOÀN DOANH NGHIỆP";
                        if (list_KH.Count > 1)
                        {
                            for (int i = 1; i < list_KH.Count; i++)
                            {
                                InsertWord(oTempPath, HD, CN, list_KH, i, title);
                            }
                        }
                        else
                            InsertWord(oTempPath, HD, CN, list_KH, 9, title);
                    }
                    if (mcb_LoaiHopDong.Text == "3. Thỏa thuận quản lý và sử dụng tủ két thuê chung")
                    {
                        string oTempPath = Application.StartupPath + @"\template\2_Thoa_thuan_ket_thue_chung.dot";
                        string title = "THỎA THUẬN QUẢN LÝ VÀ SỬ DỤNG TỦ KÉT THUÊ CHUNG";
                        if (list_KH.Count > 1)
                        {
                            for (int i = 1; i < list_KH.Count; i++)
                            {
                                InsertWord(oTempPath, HD, CN, list_KH, i, title);
                            }
                        }
                        else
                            InsertWord(oTempPath, HD, CN, list_KH, 9, title);
                    }
                    if (mcb_LoaiHopDong.Text == "4. Phụ lục hợp đồng cho thuê tủ két an toàn cá nhân")
                    {
                        string oTempPath = Application.StartupPath + @"\template\2_Phu_luc_hop_dong_cho_thue_tu_ket_an_toan_1.dot";
                        string title = "PHỤ LỤC HỢP ĐỒNG CHO THUÊ TỦ KÉT AN TOÀN CÁ NHÂN";
                        if (list_KH.Count > 1)
                        {
                            for (int i = 1; i < list_KH.Count; i++)
                            {
                                InsertWord(oTempPath, HD, CN, list_KH, i, title);
                            }
                        }
                        else
                            InsertWord(oTempPath, HD, CN, list_KH, 9, title);
                    }
                    if (mcb_LoaiHopDong.Text == "5. Phụ lục hợp đồng cho thuê tủ két an toàn doanh nghiệp")
                    {
                        string oTempPath = Application.StartupPath + @"\template\2_Phu_luc_hop_dong_cho_thue_tu_ket_an_toan_2.dot";
                        string title = "PHỤ LỤC HỢP ĐỒNG CHO THUÊ TỦ KÉT AN TOÀN DOANH NGHIỆP";
                        if (list_KH.Count > 1)
                        {
                            for (int i = 1; i < list_KH.Count; i++)
                            {
                                InsertWord(oTempPath, HD, CN, list_KH, i, title);
                            }
                        }
                        else
                            InsertWord(oTempPath, HD, CN, list_KH, 9, title);
                    }
                    if (mcb_LoaiHopDong.Text == "6. Biên bản thanh lý hợp đồng cá nhân")
                    {
                        string oTempPath = Application.StartupPath + @"\template\2_Bien_ban_thanh_ly_hop_dong_ca_nhan.dot";
                        string title = "BIÊN BẢN THANH LÝ HỢP ĐỒNG CHO THUÊ TỦ KÉT AN TOÀN CÁ NHÂN";
                        if (list_KH.Count > 1)
                        {
                            for (int i = 1; i < list_KH.Count; i++)
                            {
                                InsertWord(oTempPath, HD, CN, list_KH, i, title);
                            }
                        }
                        else
                            InsertWord(oTempPath, HD, CN, list_KH, 9, title);
                    }
                    if (mcb_LoaiHopDong.Text == "7. Biên bản thanh lý hợp đồng doanh nghiệp")
                    {
                        string oTempPath = Application.StartupPath + @"\template\2_Bien_ban_thanh_ly_hop_dong_doanh_ngiep.dot";
                        string title = "BIÊN BẢN THANH LÝ HỢP ĐỒNG CHO THUÊ TỦ KÉT AN TOÀN DOANH NGHIỆP";
                        if (list_KH.Count > 1)
                        {
                            for (int i = 1; i < list_KH.Count; i++)
                            {
                                InsertWord(oTempPath, HD, CN, list_KH, i, title);
                            }
                        }
                        else
                            InsertWord(oTempPath, HD, CN, list_KH, 9, title);
                    }
                    using (StreamWriter sWrite = new StreamWriter(Application.StartupPath + Constants.FilePathConstant.DATABASE_HISTORY_PRINT, true))
                    {
                        string sTemp = string.Format("\n{0}\t{1}\t{2}\t{3}", DateTime.Today, mtb_MaHopDong.Text, TenNhanVien, mcb_LoaiHopDong.Text);
                        sWrite.Write(sTemp);
                        sWrite.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thiếu file template. Đề nghị kiểm tra lại!");
                }
            }
            
        }

        private void mlb_MaDoanhNghiep_Click(object sender, EventArgs e)
        {

        }

        private void mbt_TimMaKH_Click(object sender, EventArgs e)
        {
            mtb_MaHopDong.Text = "";
            mtb_MaDoanhNghiep.Text = "";
            mtb_TenKhachHang.Text = "";
            mtb_CCCD.Text = "";
            if (mtb_MaKhachHang.Text == "")
            {
                MessageBox.Show("Nhập thông tin cần tìm kiếm!", "Thông báo");
            }
            else
            {
                TimKiem();
            }
        }

        private void mbt_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sWrite = new StreamWriter(Application.StartupPath + Constants.FilePathConstant.DATABASE_INFO_BANK, false))
                {
                    string sTemp = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n{8}\n{9}\n{10}\n{11}\n{12}\n{13}",
                        mtb_MaChiNhanh.Text, mtb_TenChiNhanh.Text, mtb_SoDKKD.Text, mtb_NoiCap.Text, mtb_NgayCap.Text, mtb_DaiDien.Text, mtb_ChucVu.Text, 
                        mtb_UyQuyen.Text, mtb_ThongBaoSoNgay1.Text, mtb_ThongBaoSoNgay2.Text, mtb_ThongBaoSoNgay3.Text, mtb_DiaChi.Text, mtb_SoDT.Text, mtb_Fax_NH.Text);
                    //this.oEncypt.Encrypt(this.tbPassword.Text, "12345", true));
                    sWrite.Write(sTemp);
                    sWrite.Close();
                }
                MessageBox.Show("Nhập thông tin ngân hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nhập thông tin ngân hàng!");
            }
        }
        public void TimKiem()
        {
            list_KH = new List<app_object.Obj_KhachHang>();
            string MaKhachHang = mtb_MaKhachHang.Text.Trim();
            string TenKhachHang = mtb_TenKhachHang.Text.Trim();
            string NgayBatDau = Convert.ToString(mde_NgayBatDau.DateTime.Month + "-" + mde_NgayBatDau.DateTime.Day + "-" + mde_NgayBatDau.DateTime.Year);
            string CCCD = mtb_CCCD.Text;
            string MaCongTy = mtb_MaDoanhNghiep.Text;
            string MaHopDong = mtb_MaHopDong.Text;

            ThongTinKhachHang(list_KH, MaKhachHang, TenKhachHang, CCCD, MaCongTy, MaHopDong);
            mdgv_ThongTinKhachHang.Rows.Clear();
            if (list_KH.Count > 0)
            {
                int dem = 1;
                for (int i = 0; i < list_KH[0].MaSoket.Count; i++)
                {

                    mdgv_ThongTinKhachHang.Rows.Add(dem++, list_KH[0].MaHopDong, list_KH[0].TenKhachHang, list_KH[0].NgayBatDau, list_KH[0].DiaChi, list_KH[0].DienThoai, list_KH[0].SoCCCD, list_KH[0].NgayCap, list_KH[0].NoiCap, list_KH[0].Email, list_KH[0].SoTaiKhoan, list_KH[0].SoTheTinDung, list_KH[0].MaSoket[i], list_KH[0].MaKhachHang);
                }
                for (int i = 1; i < list_KH.Count; i++)
                {
                    if (list_KH[i].MaSoket.Count>0)
                        mdgv_ThongTinKhachHang.Rows.Add(dem++, list_KH[i].MaHopDong, list_KH[i].TenKhachHang, list_KH[i].NgayBatDau, list_KH[i].DiaChi, list_KH[i].DienThoai, list_KH[i].SoCCCD, list_KH[i].NgayCap, list_KH[i].NoiCap, list_KH[i].Email, list_KH[i].SoTaiKhoan, list_KH[i].SoTheTinDung, list_KH[i].MaSoket[0], list_KH[i].MaKhachHang);
                }
            }
        }
        private void mbt_TimTenKH_Click(object sender, EventArgs e)
        {
            mtb_MaHopDong.Text = "";
            mtb_MaDoanhNghiep.Text = "";
            mtb_MaKhachHang.Text = "";
            mtb_CCCD.Text = "";
            if (mtb_TenKhachHang.Text == "")
            {
                MessageBox.Show("Nhập thông tin cần tìm kiếm!", "Thông báo");
            }
            else
            {
                TimKiem();
            }
        }

        private void mbt_TimCCCD_Click(object sender, EventArgs e)
        {
            mtb_MaHopDong.Text = "";
            mtb_MaDoanhNghiep.Text = "";
            mtb_MaKhachHang.Text = "";
            mtb_TenKhachHang.Text = "";
            if (mtb_CCCD.Text == "")
            {
                MessageBox.Show("Nhập thông tin cần tìm kiếm!", "Thông báo");
            }
            else
            {
                TimKiem();
            }
        }

        private void mbt_TimMaDN_Click(object sender, EventArgs e)
        {
            mtb_MaHopDong.Text = "";
            mtb_CCCD.Text = "";
            mtb_MaKhachHang.Text = "";
            mtb_TenKhachHang.Text = "";
            if (mtb_MaDoanhNghiep.Text == "")
            {
                MessageBox.Show("Nhập thông tin cần tìm kiếm!", "Thông báo");
            }
            else
            {
                TimKiem();
            }
        }

        private void mbt_TimMaHD_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void mbt_TimMaHD_Click(object sender, EventArgs e)
        {
            mtb_MaDoanhNghiep.Text = "";
            mtb_CCCD.Text = "";
            mtb_MaKhachHang.Text = "";
            mtb_TenKhachHang.Text = "";
            if (mtb_MaHopDong.Text == "")
            {
                MessageBox.Show("Nhập thông tin cần tìm kiếm!", "Thông báo");
            }
            else
            {
                TimKiem();
            }
        }
    }
}