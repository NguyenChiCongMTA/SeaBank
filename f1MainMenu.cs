using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafeControl
{
    public partial class f1MainMenu : fBase
    {
        public f1MainMenu()
        {
            InitializeComponent();

            
        }
        public string TenNhanVien { set; get; }
        public f0HomeLogin formLogin { set; get; }
        public string MaNganHang { set; get; }
        public string user { set; get; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mlNhanVien.Text = "Nhân viên: " + TenNhanVien;
            if (user == "admin")
                mbtn_f7QuanLyTaiKhoan.Visible = true;
            if(IsLimited())
            {
                this.Close();
                formLogin.Show();
            }    
        }

        private void fMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            formLogin.Show();
        }
        /// <summary>
        /// Sự kiện mbtn_f1InHopDong
        /// CreateBy: connc 08.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mpInHopDong_Click(object sender, EventArgs e)
        {
            if (!IsLimited())
            {
                f2InHopDong fm = new f2InHopDong();
                fm.formMainMenu = this;
                fm.TenNhanVien = TenNhanVien;
                fm.MaChiNhanh = MaNganHang;
                fm.Show();
            }
        }
        
        /// <summary>
        /// Sự kiện mbtn_f5BaoCaoHopDong
        /// CreateBy: connc 10.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbtn_f5BaoCaoHopDong_Click(object sender, EventArgs e)
        {
            //this.Hide();
            if (!IsLimited())
            {

                f5BaoCaoHopDong fm = new f5BaoCaoHopDong();
                fm.formMainMenu = this;
                fm.TenNhanVien = TenNhanVien;
                fm.MaNganHang = MaNganHang;
                fm.Show();
            }
        }
        /// <summary>
        /// Sự kiện mbtn_f3BaoCaoKet_Click
        /// CreateBy: connc 10.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbtn_f3BaoCaoKet_Click(object sender, EventArgs e)
        {
            //this.Hide();
            if (!IsLimited())
            {

                f4BaoCaoTiLeSuDungKet fm = new f4BaoCaoTiLeSuDungKet();
                fm.formMainMenu = this;
                fm.TenNhanVien = TenNhanVien;
                fm.MaNganHang = MaNganHang;
                fm.Show();
            }
        }

        /// <summary>
        /// Sự kiện mbtn_f8SendAPI_Click
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbtn_f8SendAPI_Click(object sender, EventArgs e)
        {
            //this.Hide();
            if (!IsLimited())
            {

                f8SendAPI fm = new f8SendAPI();
                fm.formMainMenu = this;
                fm.sTenNhanVien = TenNhanVien;
                fm.Show();
            }
        }
        /// <summary>
        /// Sự kiện mbtn_f2BaoCaoDoanhThu_Click
        /// CreateBy: truongnm 13.03.2022
        /// </summary>
        private void mbtn_f2BaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            //this.Hide();
            if (!IsLimited())
            {

                f3BaoCaoDoanhThu fm = new f3BaoCaoDoanhThu();
                fm.formMainMenu = this;
                fm.TenNhanVien = TenNhanVien;
                fm.MaNganHang = MaNganHang;
                fm.Show();
            }
        }
        /// <summary>
        /// Sự kiện mbtn_f6GiaHanHopDong_Click
        /// CreateBy: truongnm 13.03.2022
        /// </summary>
        private void mbtn_f6GiaHanHopDong_Click(object sender, EventArgs e)
        {
            //this.Hide();
            if (!IsLimited())
            {

                f6TuDongBaoGiaHan fm = new f6TuDongBaoGiaHan();
                fm.formMainMenu = this;
                fm.Show();
            }
        }
        /// <summary>
        /// Sự kiện mbtn_f7QuanLyTaiKhoan_Click
        /// CreateBy: truongnm 13.03.2022
        /// </summary>
        private void mbtn_f7QuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            //this.Hide();
            if (!IsLimited())
            {

                f7QuanLy fm = new f7QuanLy();
                fm.formMainMenu = this;
                fm.formMainMenu = this;
                fm.TenNhanVien = TenNhanVien;
                fm.Show();
            }
        }
        /// <summary>
        /// Sự kiện mbtn_f9LietKeGiaoDich_Click
        /// CreateBy: truongnm 19.03.2022
        /// </summary>
        private void mbtn_f9LietKeGiaoDich_Click(object sender, EventArgs e)
        {
            //this.Hide();
            if (!IsLimited())
            {

                f9LietKeGiaoDich fm = new f9LietKeGiaoDich();
                fm.formMainMenu = this;
                fm.sTenNhanVien = TenNhanVien;
                fm.Show();
            }
        }
    }
}
