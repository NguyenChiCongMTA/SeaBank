using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeControl.app_object
{
    public class Obj_KhachHang
    {
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string SoCCCD { get; set; }
        public string NgayCap { get; set; }
        public string NoiCap { get; set; }
        public string Email { get; set; }
        public string SoTaiKhoan { get; set; }
        public string SoTheTinDung { get; set; }
        public string MaHopDong { get; set; }
        public string NgayBatDau { get; set; }
        public string MaCongTy { get; set; }
        public List<string> MaSoket { get; set; }
        public Obj_KhachHang() { }
        public Obj_KhachHang(string makhachhang, string tenkhachhang, string diachi, string dienthoai, string socccd, string ngaycap, string noicap, string email, string sotaikhoan, string sothetindung, string mahopdong, string ngaybatdau, string macongty, List<string> masoket)
        {
            MaKhachHang = makhachhang;
            TenKhachHang = tenkhachhang;
            DiaChi = diachi;
            DienThoai = dienthoai;
            SoCCCD = socccd;
            NgayCap = ngaycap;
            NoiCap = noicap;
            Email = email;
            SoTaiKhoan = sotaikhoan;
            SoTheTinDung = sothetindung;
            MaHopDong = mahopdong;
            NgayBatDau = ngaybatdau;
            MaCongTy = macongty;
            MaSoket = masoket;
        }
    }
}
