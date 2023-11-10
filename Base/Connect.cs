using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Windows.Forms;
using System.IO;
namespace SafeControl.Base
{
    class Connect
    {
        public string sConnect { set; get; }
        public string mauConnectSqlServer1 = @"User={1};Password={2};Database={0};Dialect={3};Charset={4};ServerType={5};";
        public string setStringConnect(string database, string server, string password)
        {
            string Dialect = "3";
            string Charset = "WIN1252";
            string ServerType = FbServerType.Default.ToString();
            return sConnect = String.Format(mauConnectSqlServer1, database, server, password, Dialect, Charset, ServerType);
        }
        private static bool IsServerConnected(string connectionString)
        {
            using (FbConnection connection = new FbConnection(connectionString))
            {
                try { connection.Open(); return true; }
                catch (FbException) { return false; }
            }
        }
        public bool kiemTraKetNoi(string connectionString)
        {
            return IsServerConnected(connectionString);
        }
        
        public FbConnection sqlConnection { set; get; }
        public void InitSqlConnection()
        {
            using (StreamReader sRead = new StreamReader(Application.StartupPath + Constants.FilePathConstant.DATABASE_CONNECT))
            {
                sConnect = sRead.ReadToEnd().Trim();
                sRead.Close();
            }
            sqlConnection = new FbConnection(sConnect);
            sqlConnection.Open();
        }
        public void CloseSqlConnection()
        {
            sqlConnection.Close();
            MBaseFirebird.SetAllFbConnectionPoolsAreCleared();
        }
        public int ExecuteNonQuery(string sSQL, FbCommand commandType, FbConnection sqlConnection)
        {
            int efftectRecord = 0;
            FbCommand com = new FbCommand();
            com.CommandText = sSQL;
            com.Connection = sqlConnection;
            com.CommandType = commandType.CommandType;
            ConnectionState connectionState = com.Connection.State;
            if (connectionState != ConnectionState.Open)
            {
                InitSqlConnection();
            }
            try
            {
                efftectRecord = com.ExecuteNonQuery();

                com.Dispose();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo"); }
            sqlConnection.Close();
            MBaseFirebird.SetAllFbConnectionPoolsAreCleared();
            return efftectRecord;
        }
        
        public object ExecuteScalar(string sSQL, FbCommand commandType, FbConnection sqlConnection)
        {
            object objValue = null;
            FbCommand com = new FbCommand();
            com.CommandText = sSQL;
            com.Connection = sqlConnection;
            com.CommandType = commandType.CommandType;
            ConnectionState connectionState = com.Connection.State;
            if (connectionState != ConnectionState.Open)
            {
                InitSqlConnection();
            }
            try
            {
                objValue = com.ExecuteScalar();

                com.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            sqlConnection.Close();
            MBaseFirebird.SetAllFbConnectionPoolsAreCleared();
            return objValue;
        }
        public object[] GetObjects(string sSQL, FbCommand commandType, FbConnection sqlConnection)
        {
            
            object[] objValue = null;
            FbCommand com = new FbCommand();
            com.CommandText = sSQL;
            com.Connection = sqlConnection;
            com.CommandType = commandType.CommandType;
            ConnectionState connectionState = com.Connection.State;
            if (connectionState != ConnectionState.Open)
            {
                InitSqlConnection();
            }
            try
            {
                FbDataReader sqlDataReader = com.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objValue = new object[sqlDataReader.FieldCount];
                    sqlDataReader.GetValues(objValue);
                }
                sqlDataReader.Close();
                sqlDataReader.Dispose();
                com.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            sqlConnection.Close();
            MBaseFirebird.SetAllFbConnectionPoolsAreCleared();
            return objValue;
        }
        public FbDataReader GetSqlDataReader(string sSQL)
        {
            FbCommand sqlCommand = new FbCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sSQL;
            ConnectionState connectionState = sqlCommand.Connection.State;
            if (connectionState != ConnectionState.Open)
            {
                InitSqlConnection();
            }
            try
            {
                FbDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlCommand.Dispose();
                return sqlDataReader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            sqlConnection.Close();
            MBaseFirebird.SetAllFbConnectionPoolsAreCleared();
            return null;
        }
        public DataSet GetSqlDataSet(string sSQL)
        {
            FbCommand sqlCommand = new FbCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sSQL;
            ConnectionState connectionState = sqlCommand.Connection.State;
            if (connectionState != ConnectionState.Open)
            {
                InitSqlConnection();
            }
            try
            {
                FbDataAdapter sqlDataAdapter = new FbDataAdapter(sqlCommand);
                DataSet sDataSet = new DataSet(); 
                sqlDataAdapter.Fill(sDataSet);
                sqlCommand.Dispose();
                return sDataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            sqlConnection.Close();
            MBaseFirebird.SetAllFbConnectionPoolsAreCleared();
            return null;
        }
        
    }
}
