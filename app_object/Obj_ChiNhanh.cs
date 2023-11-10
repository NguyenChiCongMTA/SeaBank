using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeControl.app_object
{
    public class Obj_ChiNhanh
    {
        public string TenChiNhanh { get; set; }
        public string SoGiayChungNhan { get; set; }
        public string NoiCap { get; set; }
        public string NgayCap { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string DaiDien { get; set; }
        public string ChucVu { get; set; }
        public string QuyetDinhUyQuyen { get; set; }

        public Obj_ChiNhanh() { }

        public Obj_ChiNhanh(string tenchinhanh, string sogiaychungnhan, string noicap, string ngaycap, string diachi, string dienthoai, string fax, string daidien, string chucvu, string quyetdinhuyquyen, string email)
        {
            TenChiNhanh = tenchinhanh;
            SoGiayChungNhan = sogiaychungnhan;
            NgayCap = ngaycap;
            NoiCap = noicap;
            DiaChi = diachi;
            DienThoai = dienthoai;
            Fax = fax;
            DaiDien = daidien;
            ChucVu = chucvu;
            QuyetDinhUyQuyen = quyetdinhuyquyen;
            Email = email;
        }
    }
}
