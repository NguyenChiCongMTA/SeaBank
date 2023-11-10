using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using SafeControl.Base;

namespace SafeControl.Dictionary
{
    public enum OptionSelect
    {
        SQLserver, SQLserverNoPass, SQLexpress
    };

    public class MMDatalayer : MBase
    {
        public MMDatalayer()
        {
            loadConfig(Application.StartupPath + string.Format(Constants.FilePathConstant.CONFIG));
            sServerName = sConnect.Split(';')[0].Split('=')[1];
        }
        #region Declare
        public string mauConnectSqlExpress1 = @"server=.\SQLEXPRESS;AttachDbFilename={0};Integrated Security=True;Connect Timeout=30;User Instance=True";
        public string mauConnectSqlExpress2 = @"server={0};AttachDbFilename={1};Integrated Security=True;Connect Timeout=30;User Instance=True";
        public string mauConnectSqlServer1 = @"Server={0};Database={1};uid={2};pwd={3};";
        public string mauConnectSqlServer2 = @"Data Source={0};Initial Catalog={1};Integrated Security=True";
        public string mauConnectSqlServer3 = @"Data Source={0};Initial Catalog= master;UID={1}; PWD={2};Integrated Security=SSPI;Connect Timeout=30";
        public string sConnect { set; get; }
        public string sServerName { set; get; }
        public SqlConnection sqlConnection { set; get; }
        #endregion
        #region Sub/Func
        private void loadConfig(string sPath)
        {
            
        }
        public void writeConfig(string sPath)
        {
            
        }
        public void setStringConnect(OptionSelect optionSelect)
        {
            switch ((OptionSelect)optionSelect)
            {
                case OptionSelect.SQLserver:
                    sConnect = mauConnectSqlServer1;
                    break;
                case OptionSelect.SQLserverNoPass:
                    sConnect = mauConnectSqlServer2;
                    break;
                case OptionSelect.SQLexpress:
                    sConnect = mauConnectSqlExpress2;
                    break;
                default:
                    break;
            }
        }
        private static bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try { connection.Open(); return true; }
                catch (SqlException) { return false; }
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
        public void InitSqlConnection()
        {
            sqlConnection = new SqlConnection(sConnect);
        }
        public bool BulkInsertDataTable(string tableName, DataTable dataTable)
        {
            bool isSuccess;
            try
            {
                SqlConnection SqlConnectionObj = sqlConnection;
                SqlBulkCopy bulkCopy = new SqlBulkCopy(SqlConnectionObj, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);
                bulkCopy.DestinationTableName = tableName;
                SqlConnectionObj.Open();
                bulkCopy.WriteToServer(dataTable);
                isSuccess = true;
                SqlConnectionObj.Close();
            }
            catch (Exception ex)
            {
                isSuccess = false;
                MessageBox.Show(ex.Message, "Thông báo");
        }
            return isSuccess;
        }
        public string DropTable(string tableName)
        {
            string sDrop = string.Format(
            "IF OBJECT_ID('[dbo].[{0}]', 'U') IS NOT NULL\n" +
            "BEGIN DROP TABLE [dbo].[{0}] END", tableName);
            return sDrop;
        }
        public string CreateTABLE(string tableName, DataTable table)
        {
            string sqlsc;
            sqlsc = "CREATE TABLE " + tableName + "(";
            for (int i = 0; i < table.Columns.Count; i++)
            {
                sqlsc += "\n [" + table.Columns[i].ColumnName + "] ";
                string columnType = table.Columns[i].DataType.ToString();
                switch (columnType)
                {
                    case "System.Int32":
                        sqlsc += " int ";
                        break;
                    case "System.Int64":
                        sqlsc += " bigint ";
                        break;
                    case "System.Int16":
                        sqlsc += " smallint";
                        break;
                    case "System.Byte":
                        sqlsc += " tinyint";
                        break;
                    case "System.Decimal":
                        sqlsc += " decimal ";
                        break;
                    case "System.DateTime":
                        sqlsc += " datetime ";
                        break;
                    case "System.String":
                    default:
                        sqlsc += string.Format(" nvarchar({0}) ", table.Columns[i].MaxLength == -1 ? "max" : table.Columns[i].MaxLength.ToString());
                        break;
                }
                if (table.Columns[i].AutoIncrement)
                    sqlsc += " IDENTITY(" + table.Columns[i].AutoIncrementSeed.ToString() + "," + table.Columns[i].AutoIncrementStep.ToString() + ") ";
                if (!table.Columns[i].AllowDBNull)
                    sqlsc += " NOT NULL ";
                sqlsc += ",";
            }
            return sqlsc.Substring(0, sqlsc.Length - 1) + "\n)";
        }
        #endregion
        #region Exucute
        public int ExecuteNonQuery(string sSQL, CommandType commandType, SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            int efftectRecord = 0;
            SqlCommand com = new SqlCommand();
            com.CommandText = sSQL;
            com.Connection = sqlConnection;
            com.CommandType = commandType;
            try
            {
                efftectRecord = com.ExecuteNonQuery();
                com.Dispose();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo"); }
            sqlConnection.Close();
            return efftectRecord;
        }
        public int ExecuteNonQueryMaster(string sSQL, CommandType commandType)
        {
            SqlConnection sqlConnection = new SqlConnection(this.sConnect);
            sqlConnection.Open();
            int efftectRecord = 0;
            SqlCommand com = new SqlCommand();
            com.CommandText = sSQL;
            com.Connection = sqlConnection;
            com.CommandType = commandType;
            try
            {
                efftectRecord = com.ExecuteNonQuery();
                com.Dispose();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo"); }
            sqlConnection.Close();
            return efftectRecord;
        }
        public object ExecuteScalar(string sSQL, CommandType commandType, SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            object objValue = null;
            SqlCommand com = new SqlCommand();
            com.CommandText = sSQL;
            com.Connection = sqlConnection;
            com.CommandType = commandType;
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
            return objValue;
        }
        public object[] GetObjects(string sSQL, CommandType commandType, SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            object[] objValue = null;
            SqlCommand com = new SqlCommand();
            com.CommandText = sSQL;
            com.Connection = sqlConnection;
            com.CommandType = commandType;
            try
            {
                SqlDataReader sqlDataReader = com.ExecuteReader();
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
                //sqlTran.Rollback(); 
                MessageBox.Show(ex.Message, "Thông báo");
            }
            sqlConnection.Close();
            return objValue;
        }
        public SqlDataReader GetSqlDataReader(string sSQL)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sSQL;
            ConnectionState connectionState = sqlCommand.Connection.State;
            if (connectionState != ConnectionState.Open)
            {
                sqlCommand.Connection.Open();
            }
            try
            {
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlCommand.Dispose();
                return sqlDataReader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            sqlConnection.Close();
            return null;
        }
        public DataSet GetSqlDataSet(string sSQL)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sSQL;
            ConnectionState connectionState = sqlCommand.Connection.State;
            if (connectionState != ConnectionState.Open)
            {
                sqlCommand.Connection.Open();
            }
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet sDataSet = new DataSet(); sqlDataAdapter.Fill(sDataSet);
                sqlCommand.Dispose();
                return sDataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            sqlConnection.Close();
            return null;
        }
        #endregion
    }
}
