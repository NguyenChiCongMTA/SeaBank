using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeControl.app_object
{
    public class Obj_HopDong
    {
        public string SoHopDong { get; set; }
        public string MaKet { get; set; }
        public string LoaiKet { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string PhiThanhToan { get; set; }
        public string MaChiaKhoa { get; set; }
        
        public Obj_HopDong() { }
        public Obj_HopDong(string sohopdong, string maket, string loaiket, string ngaybatdau, string ngayketthuc, string phithanhtoan, string machiakhoa)
        {
            SoHopDong = sohopdong;
            MaKet = maket;
            LoaiKet = loaiket;
            NgayBatDau = ngaybatdau;
            NgayKetThuc = ngayketthuc;
            PhiThanhToan = phithanhtoan;
            MaChiaKhoa = machiakhoa;
        }
    }
}
