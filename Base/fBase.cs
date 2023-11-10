using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SafeControl.Dictionary;
using System.IO;
using SafeControl.Base;
using SafeControl.Bussiness;

namespace SafeControl
{
    public partial class fBase : DevExpress.XtraEditors.XtraForm
    {
        public fBase()
        {
            InitializeComponent();
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            // Giao diện và dạng font
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = MGlobal.sSkinName;
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = MGlobal.fDefaultFont;
            //
            //
            // Đăng ký Event ở đây
            // CreateBy: truongnm 06.02.2021
            this.Load += this.fBase_Load;
            mllRefreshDataBase.LinkClicked += mllRefreshDataBase_LinkClicked;
            mllPhienBan.LinkClicked += mllPhienBan_LinkClicked;
        }
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Declare
        public string sUser { set; get; }
        public string sTenNhanVien { set; get; }
        #endregion
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm Command_RefreshDataBase
        /// CreateBy: truongnm 24.03.2022
        /// </summary>
        public virtual void Command_RefreshDataBase()
        {
            try
            {
                // Add code here:
                // Sử dụng hàm copy này có thể copy dữ liệu ở bất cứ sự kiện nào trong chương trình
                MCopyData.bCopyDataBaseFirebirdFormFilePathConfig(Application.StartupPath + Constants.FilePathConstant.DATABASE_COPY_DATABASE_CONFIG);
                //
                Command_LoadDataBaseInfor();
                //
                MMessageBox.Information("Đã copy thành công dữ liệu!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database đang được sử dụng bởi chương trình khác. Tắt chương trình khi sử dụng hệ thống!");
            }
        }
        /// <summary>
        /// Hàm Command_LoadDataBaseInfor
        /// CreateBy: truongnm 24.03.2022
        /// </summary>
        public virtual void Command_LoadDataBaseInfor()
        {
            // Add code here:
            string sResult = "database='{0}' | time='{1:dd/MM/yyyy HH:mm:ss}' | size={2:#,##0.00} MB";
            // Lấy đọc file dữ liệu config để lấy các tham số
            string sReadToEnd = string.Empty;
            StreamReader reader = new StreamReader(Application.StartupPath + Constants.FilePathConstant.DATABASE_COPY_DATABASE_CONFIG);
            sReadToEnd = @reader.ReadToEnd();
            reader.Close();
            string[] sTempParameter = sReadToEnd.Trim().Split('\n');
            //
            string fileName = sTempParameter[0].Trim(); // "SAFECONTROL.FDB";
            string sourcePath = sTempParameter[1].Trim();//@"C:\Program Files (x86)\SafeControl\data";
            string targetPath = sTempParameter[2].Trim();  //@"D:\database";
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.FileInfo oFileInfo = new System.IO.FileInfo(destFile);
            //
            sResult = string.Format(sResult, fileName, oFileInfo.LastWriteTime, (oFileInfo.Length / 1024) / 1024);
            //
            mlblDataBaseInfor.Text = sResult;
            //
        }
        /// <summary>
        /// Hàm InitForm
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public virtual void InitForm()
        {
            // Add code here:
        }
        /// <summary>
        /// Hàm InitData
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public virtual void InitData()
        {
            // Add code here:
            Command_LoadDataBaseInfor();
            mllPhienBan.Text = MGlobal.sPhienBan;
            //// Kiểm tra đến ngày 14.04.2022 thì ko cho dùng nữa
            //// CreateBy: truongnm 27.03.2022
            //if (string.Format("{0:dd/MM/yyyy}", DateTime.Now) == string.Format("{0:dd/MM/yyyy}", MGlobal.iDay)) Application.Exit();
            ///////////////////////////////////////////
            // Kiểm tra quyền đăng nhập
            // EditBy: truongnm 06.04.2022
            ///////////////////////////////////////////
            if (!IsPersonPermisstion(this.Name, GetUser()))
            {
                MMessageBox.Error("Bạn không có quyền truy cập vào chức năng này!");
                this.Dispose();
            }
        }
        /// <summary>
        /// Hàm LoadData
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public virtual void LoadData()
        {
            // Add code here:
        }
        /// <summary>
        /// Hàm GetMaChiNhanh
        /// Hàm này là hàm đặc thù của Project - SafeControl -
        /// CreateBy: truongnm 19.03.2022
        /// </summary>
        public virtual string GetMaChiNhanh()
        {
            MFile oMFile = new MFile();
            string sResult = string.Empty;
            //
            string sTemp = oMFile.OpenTextFile(Application.StartupPath + Constants.FilePathConstant.DATABASE_USER);
            sResult = sTemp.Trim().Split('\n')[2].Trim();
            //
            return sResult;
        }
        /// <summary>
        /// Hàm GetTenChiNhanh
        /// Hàm này là hàm đặc thù của Project - SafeControl -
        /// CreateBy: truongnm 19.03.2022
        /// </summary>
        public virtual string GetTenChiNhanh(string sMaChiNhanh)
        {
            string sResult = string.Empty;
            //
            app_object.Obj_ChiNhanh CN = new app_object.Obj_ChiNhanh();
            Base.Connect connect = new Base.Connect();
            connect.InitSqlConnection();
            //
            string sql = @"select d.name,d.plz,d.strasse, d.ort, d.telefon, d.fax, d.ansprechpartner, d.email
                    from dmf_firma as d , dmf_offices
                    where dmf_offices.name = '{0}'  and dmf_offices.dmf_firma_id = d.id";
            sql = string.Format(sql, sMaChiNhanh);
            DataTable dt = connect.GetSqlDataSet(sql).Tables[0];
            CN.TenChiNhanh = dt.Rows[0][0].ToString();
            CN.DiaChi = dt.Rows[0][1].ToString() + dt.Rows[0][2].ToString() + ", " + dt.Rows[0][3].ToString();
            CN.DienThoai = dt.Rows[0][4].ToString();
            CN.Fax = dt.Rows[0][5].ToString();
            CN.DaiDien = dt.Rows[0][6].ToString();
            CN.Email = dt.Rows[0][7].ToString();
            //
            sResult = CN.TenChiNhanh;
            //
            return sResult;
        }
        /// <summary>
        /// Hàm GetUser
        /// Hàm này là hàm đặc thù của Project - SafeControl -
        /// CreateBy: truongnm 19.03.2022
        /// </summary>
        public virtual string GetUser()
        {
            string sResult = string.Empty;
            //
            using (StreamReader sRead = new StreamReader(Application.StartupPath + Constants.FilePathConstant.DATABASE_USER))
            {
                string StrRead = sRead.ReadToEnd().Trim();
                sRead.Close();
                if (StrRead.Trim() != "")
                {
                    string[] tempRead = StrRead.Split('\n');
                    switch (tempRead.Length)
                    {
                        case 0:
                        case 1:
                            break;
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            sResult = tempRead[0].Trim();
                            break;
                    }
                }

            }
            //
            return sResult;
        }
        /// <summary>
        /// Hàm GetTenChiNhanh
        /// Hàm này là hàm đặc thù của Project - SafeControl -
        /// CreateBy: truongnm 19.03.2022
        /// </summary>
        
        /// <summary>
        /// Hàm GetNgayPhatHanhVaKetThucBox
        /// Hàm này là hàm đặc thù của Project - SafeControl -
        /// CreateBy: truongnm 23.03.2022
        /// </summary>
        public virtual void GetNgayPhatHanhVaKetThucBox(string fachid, ref DateTime dNgayPhatHanh, ref DateTime dNgayKetThuc)
        {
            //
            Base.Connect connect = new Base.Connect();
            string sSql = @"
select distinct
fach.vermietungsdatum,
fach.laufzeit
from fach
where 1 = 1
and fach.id = {0}
";
            //
            sSql = string.Format(sSql, fachid);
            connect.InitSqlConnection();
            DataTable dTableData = connect.GetSqlDataSet(sSql).Tables[0];
            //
            if (dTableData.Rows.Count <= 0) return;

            dNgayPhatHanh = Convert.ToDateTime(dTableData.Rows[0][0]);
            dNgayKetThuc = Convert.ToDateTime(dTableData.Rows[0][1]);

        }
        /// <summary>
        /// Lệnh GetCountNameProcess
        /// CreateBy: truongnm: 28-06-2019
        public virtual int GetCountNameProcess(string sNamePro)
        {
            int iResult = 0;
            foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName(sNamePro))
                iResult++;
            return iResult;
        }
        /// <summary>
        /// Lệnh IsPersonPermisstion
        /// CreateBy: truongnm: 28-06-2019
        public virtual bool IsPersonPermisstion(string sFormName,string sUser)
        {
            bool bResult = false;
            //
            PersonPermission oPersonPermission = new PersonPermission();
            oPersonPermission = oPersonPermission.ReadPersonPermission();
            //
            bResult = oPersonPermission.IsCheckPermission(sFormName, sUser);
            //
            return bResult;
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Override
        
        #endregion
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Event
        /// <summary>
        /// Sự kiện load form
        /// </summary>
        private void fBase_Load(object sender, EventArgs e)
        {
            InitForm();
            //
            InitData();
            //
            LoadData();
        }
        /// <summary>
        /// Sự kiện mllRefreshDataBase_LinkClicked
        /// CreateBy: truongnm 24.03.2022
        /// </summary>
        private void mllRefreshDataBase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Command_RefreshDataBase();
        }
        /// <summary>
        /// Sự kiện mllPhienBan_LinkClicked
        /// CreateBy: truongnm 30.03.2022
        /// </summary>
        private void mllPhienBan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fUpdateVersion f = new fUpdateVersion();
            f.Show();
        }
        #endregion

        private void mllRefreshDataBase_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}