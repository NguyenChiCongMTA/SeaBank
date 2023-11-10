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
using System.IO;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using SafeControl.Base;
using System.Net.NetworkInformation;
using SafeControl.Dictionary;

namespace SafeControl
{
    public partial class f0HomeLogin : fBase
    {
        public f0HomeLogin()
        {
            InitializeComponent();
        }
        public string MAC_Adress;
        private void LoadUser()
        {
            using (StreamReader sRead = new StreamReader(Application.StartupPath + Constants.FilePathConstant.DATABASE_USER))
            {
                string StrRead = sRead.ReadToEnd().Trim();
                sRead.Close();
                if(StrRead.Trim() != "" )
                {
                    string[] tempRead = StrRead.Split('\n');
                    mtbTaiKhoan.Text = tempRead[0].Trim();
                    mtbMatKhau.Text = tempRead[1].Trim();
                    mtbMaNganHang.Text = tempRead[2].Trim();
                }
                
            }
            using (StreamReader sRead = new StreamReader(Application.StartupPath + Constants.FilePathConstant.DATABASE_MAC))
            {
                string StrRead = sRead.ReadToEnd().Trim();
                sRead.Close();
                if (StrRead.Trim() != "")
                {
                    MAC_Adress = StrRead;
                }

            }
        }
        
        private void SaveUser()
        {
            using (StreamWriter sWrite = new StreamWriter(Application.StartupPath + Constants.FilePathConstant.DATABASE_USER, false))
            {
                string sTemp = string.Format("{0}\n{1}\n{2}", mtbTaiKhoan.Text, " ", mtbMaNganHang.Text);
                    //this.oEncypt.Encrypt(this.tbPassword.Text, "12345", true));
                sWrite.Write(sTemp);
                sWrite.Close();
            }
        }
        private void SavePass()
        {
            using (StreamWriter sWrite = new StreamWriter(Application.StartupPath + Constants.FilePathConstant.DATABASE_USER, false))
            {
                string sTemp = string.Format("{0}\n{1}\n{2}", mtbTaiKhoan.Text, mtbMatKhau.Text, mtbMaNganHang.Text);
                //this.oEncypt.Encrypt(this.tbPassword.Text, "12345", true));
                sWrite.Write(sTemp);
                sWrite.Close();
            }
        }
        public string TenNhanVien;
        bool check_login = false;
        public string MaNganHang;
        private void DangNhap()
        {
            //if (!Global.oGlobal.CheckDongle()) return;
            if (this.mtbTaiKhoan.Text != "" && this.mtbMatKhau.Text != "")
            {
                try
                {
                    //if (!Global.oGlobal.CheckDongle()) return;
                    using (StreamReader sRead = new StreamReader(Application.StartupPath + Constants.FilePathConstant.DATABASE_USER_PASSWORD, false))
                    {
                        string sTemp = sRead.ReadToEnd();
                        string[] TaiKhoan = sTemp.Split('\n');

                        for (int i = 0; i < TaiKhoan.Length; i++)
                        {
                            string[] temp = TaiKhoan[i].Split('\t');
                            if (temp[0].Trim() == mtbTaiKhoan.Text.Trim() && temp[1].Trim() == Dictionary.MEncypt.Encrypt(mtbMatKhau.Text.Trim(), "123", true))
                            {
                                check_login = true;
                                TenNhanVien = temp[2].Trim();
                                MaNganHang = mtbMaNganHang.Text;
                                break;
                            }

                        }
                        //this.oEncypt.Encrypt(this.tbPassword.Text, "12345", true));
                        sRead.Close();
                    }
                    if (check_login == true)
                    {
                        if (mcbNhoMatKhau.Checked)
                            SavePass();
                        else
                        {
                            SaveUser();
                        }
                        this.Hide();

                        f1MainMenu fm = new f1MainMenu();
                        fm.TenNhanVien = TenNhanVien;
                        fm.MaNganHang = MaNganHang;
                        fm.formLogin = this;
                        fm.user = mtbTaiKhoan.Text;
                        fm.Show();
                    }
                    else
                        MessageBox.Show("Sai tên hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                catch (Exception e)
                {
                    MessageBox.Show("Sai tên hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Nhập thông tin đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public string sConnect { set; get; }
        public string mauConnectSqlServer1 = @"User={1};Password={2};Database={0};Dialect={3};Charset={4};ServerType={5};";
        public string setStringConnect(string database, string server, string password)
        {
            string Dialect = "3";
            string Charset = "WIN1252";
            string ServerType = FbServerType.Default.ToString();
            return sConnect = String.Format(mauConnectSqlServer1, database, server, password, Dialect, Charset, ServerType);

        }
        public bool IsServerConnected(string connectionString)
        {
            using (FbConnection connection = new FbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                    connection.Dispose();
                    return true;
                }
                catch (FbException) { return false; }
            }
        }
        public bool kiemTraKetNoi(string connectionString)
        {
            return IsServerConnected(connectionString);
        }
        public string GetNameComputer()
        {
            return SystemInformation.ComputerName;
        }
        public FbConnection sqlConnection { set; get; }
        public void InitSqlConnection()
        {
            sqlConnection = new FbConnection(sConnect);
        }
        public void CloseSqlConnection()
        {
            while (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            while (sqlConnection.State == ConnectionState.Connecting) sqlConnection.Close();
            while (sqlConnection.State == ConnectionState.Executing) sqlConnection.Close();
            while (sqlConnection.State == ConnectionState.Fetching) sqlConnection.Close();
            while (sqlConnection.State == ConnectionState.Broken) sqlConnection.Close();
            // Check if connection pools are cleared
            // EditBy: truongnm 12.03.2022
            FirebirdSql.Data.FirebirdClient.FbConnection.ClearAllPools();
        }
        private void mbtDangNhap_Click(object sender, EventArgs e)
        {
            /*if (!Global.oGlobal.CheckDongle()) return;
            if (!oLicense.CheckLicense())
            {
                MessageBox.Show("Phiên bản đã hết hạn! Bạn hãy liên hệ tác giả để đăng ký sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Global.oGlobal.CheckComputer()) return;*/
            //string stringconnect = setStringConnect(mtbDatabase.Text, mtbServer.Text, mtbPassword.Text);
            try
            {
                // Copy lại dữ liệu khi Click vào đăng nhập
                // EditBy: truongnm 27.03.2022
                Base.MCopyData.bCopyDataBaseFirebirdFormFilePathConfig(Application.StartupPath + Constants.FilePathConstant.DATABASE_COPY_DATABASE_CONFIG);
                
                // Kiểm tra MAC Address trước khi đăng nhập
                List<string> MAC = Dictionary.MNetworkInterface.GetMacAddress1();
                string[] list_mac = MAC_Adress.Split('\n');
                // EditBy: truongnm 27.03.2022
                for (int j = 0; j < list_mac.Length; j++)
                {
                    // Quy chuẩn lại dữ liệu vì có dấu '\r'
                    list_mac[j] = MString.MRemoveCharSpecial2(list_mac[j]);
                }

                int check = 0;
                for (int i = 0; i < MAC.Count; i++)
                {
                    string MAC_encrypt = Dictionary.MEncypt.Encrypt(MAC[i], MGlobal.sKey, true);
                    //
                    if (list_mac.Contains(MAC_encrypt))
                    {
                        if (!CheckBoxNumber())
                        {
                            this.DangNhap();
                            check = 1;
                        }
                        break;
                    }
                }
                if (check == 0)
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private bool CheckBoxNumber()
        {
            Base.Connect connect = new Base.Connect();
            connect.InitSqlConnection();
            var tbl = connect.GetSqlDataSet("select count(*) from fach").Tables[0];
            if((tbl?.Rows.Count ?? 0) > 0 )
            {
                var boxNumber = int.Parse(tbl.Rows[0][0].ToString());
                return boxNumber > 2000;
            }
            return false;
        }
        private void fHomeLogin_Load(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void fHomeLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}