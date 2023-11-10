using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using SafeControl.Base;
namespace SafeControl
{
    public partial class fConnect : fBase
    {
        public fConnect()
        {
            InitializeComponent();
            // 
            InitSqlConnection();
            CloseSqlConnection();
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

        public void mbtTestConnect_Click(object sender, EventArgs e)
        {
            //
            string stringconnect = setStringConnect(mtbDatabase.Text, mtbServer.Text, mtbPassword.Text);
            try
            {
                // Sử dụng hàm copy này có thể copy dữ liệu ở bất cứ sự kiện nào trong chương trình
                MCopyData.bCopyDataBaseFirebirdFormFilePathConfig(Application.StartupPath + Constants.FilePathConstant.DATABASE_COPY_DATABASE_CONFIG);
                //
                bool trangThaiKetNoi = kiemTraKetNoi(stringconnect);
                MessageBox.Show(string.Format("Trạng thái kết nối là {0}!", trangThaiKetNoi), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (trangThaiKetNoi)
                {
                    mlbTrangThaiKetNoi.Text = "Trạng thái: đang kết nối";                    
                }      
                else 
                    mlbTrangThaiKetNoi.Text = "Trạng thái: không có kết nối";
                // Kiểm tra kết nối xong thì hủy kết nối
                CloseSqlConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
            
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

        public void mbtLuuKetNoi_Click(object sender, EventArgs e)
        {
            string stringconnect = setStringConnect(mtbDatabase.Text, mtbServer.Text, mtbPassword.Text);
            try
            {
                using (StreamWriter sWrite = new StreamWriter(Application.StartupPath + Constants.FilePathConstant.DATABASE_CONNECT, false))
                {
                    sWrite.Write(stringconnect);
                    sWrite.Close();
                }
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
