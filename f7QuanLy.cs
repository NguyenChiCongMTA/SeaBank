using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace SafeControl
{
    public partial class f7QuanLy : fBase
    {
        public f1MainMenu formMainMenu { set; get; }
        public string TenNhanVien { set; get; }
        public string MaNganHang { set; get; }
        public f7QuanLy()
        {
            InitializeComponent();
        }

        private void LoadUser()
        {
            using (StreamReader sRead = new StreamReader(Application.StartupPath + Constants.FilePathConstant.DATABASE_USER_PASSWORD))
            {
              
                string StrRead = sRead.ReadToEnd().Trim();
                sRead.Close();
                if (StrRead.Trim() != "")
                {
                    string[] tempRead = StrRead.Split('\n');
                    for(int i=0; i<tempRead.Length;i++)
                    {
                        string[] temp = tempRead[i].Split('\t');
                        mdgv_QuanLyTK.Rows.Add(i + 1, temp[0], temp[1], temp[2]);

                    }
                        
                }

            }
        }

        private void f7QuanLy_Load(object sender, EventArgs e)
        {
            mlNhanVien.Text = "Nhân viên: " + TenNhanVien;
            
            LoadUser();
        }
        
        private void mdgv_QuanLyTK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            mtb_user.Text = mdgv_QuanLyTK.SelectedRows[0].Cells[1].Value.ToString();
            mtb_pass.Text = mdgv_QuanLyTK.SelectedRows[0].Cells[2].Value.ToString();
            mtb_name.Text = mdgv_QuanLyTK.SelectedRows[0].Cells[3].Value.ToString();
        }
        private void SaveUser()
        {
            using (StreamWriter sWrite = new StreamWriter(Application.StartupPath + Constants.FilePathConstant.DATABASE_USER_PASSWORD, false))
            {
                for (int i = 0; i < mdgv_QuanLyTK.Rows.Count - 1; i++)
                {
                    string sTemp = string.Format("{0}\t{1}\t{2}\n", mdgv_QuanLyTK.Rows[i].Cells[1].Value.ToString(), mdgv_QuanLyTK.Rows[i].Cells[2].Value.ToString(), mdgv_QuanLyTK.Rows[i].Cells[3].Value.ToString());
                    sWrite.Write(sTemp);
                }
                sWrite.Close();
            }
        }
        public int check_them = 0;
        public void reset()
        {
            mtb_user.Text = "";
            mtb_pass.Text = "";
            mtb_name.Text = "";
        }
        public void enabale_all()
        {
            mtb_user.Enabled = true;
            mtb_pass.Enabled = true;
            mtb_name.Enabled = true;
        }
        public void disenabale_all()
        {
            mtb_user.Enabled = false;
            mtb_pass.Enabled = false;
            mtb_name.Enabled = false;
        }
        private void mbt_Them_Click(object sender, EventArgs e)
        {
            if (check_them == 0)
            {
                reset();
                enabale_all();
                mbt_Them.Text = "Lưu";
                check_them = 1;
            }
            else
            {
                mdgv_QuanLyTK.Rows.Add(mdgv_QuanLyTK.RowCount, mtb_user.Text, Dictionary.MEncypt.Encrypt(mtb_pass.Text, "123", true), mtb_name.Text);
                SaveUser();
                mdgv_QuanLyTK.Rows.Clear();
                LoadUser();
                MessageBox.Show("Thêm thành công!", "Thông báo");
                mbt_Them.Text = "Thêm";
                disenabale_all();
                check_them = 0;
                reset();
            }
        }
        public int check_sua = 0;
        private void mbt_Luu_Click(object sender, EventArgs e)
        {
            if(mtb_user.Text != "")
            {
                int vitri = 0;
                if (check_sua == 0)
                {
                    //reset();
                    enabale_all();
                    mbt_Luu.Text = "Lưu";
                    check_sua = 1;
                }
                else
                {
                    mdgv_QuanLyTK.SelectedRows[0].Cells[1].Value = mtb_user.Text;
                    mdgv_QuanLyTK.SelectedRows[0].Cells[2].Value = Dictionary.MEncypt.Encrypt(mtb_pass.Text, "123", true);
                    mdgv_QuanLyTK.SelectedRows[0].Cells[3].Value = mtb_name.Text;
                    SaveUser();
                    mdgv_QuanLyTK.Rows.Clear();
                    LoadUser();
                    MessageBox.Show("Sửa thành công!", "Thông báo");
                    mbt_Luu.Text = "Sửa";
                    disenabale_all();
                    check_sua = 0;
                    reset();
                }
                
            }
            else
                MessageBox.Show("Chọn tài khoản cần sửa!");

        }

        private void mbt_Xoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in mdgv_QuanLyTK.SelectedRows)
                if (!row.IsNewRow)
                    mdgv_QuanLyTK.Rows.Remove(row);
            SaveUser();
            mdgv_QuanLyTK.Rows.Clear();
            LoadUser();
            reset();
        }

        private void mtb_Huy_Click(object sender, EventArgs e)
        {
            reset();
            disenabale_all();
            if (check_sua == 1)
            {
                mbt_Luu.Text = "Sửa";
                check_sua = 0;
            }
            if (check_them == 0)
            {
                mbt_Them.Text = "Thêm";
                check_them = 0;
            }
        }

        private void mbtnPersonPermission_Click(object sender, EventArgs e)
        {
            f7QuanLy_PersonPermissionDialog f = new f7QuanLy_PersonPermissionDialog();
            f.ShowDialog();
        }
    }
}
