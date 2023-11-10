using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using SafeControl.Base;
using System.IO;
using System.Text.RegularExpressions;
namespace SafeControl.Dictionary
{
    /// <summary>
    /// Thư viện thao tác với Excel
    /// CreateBy: truongnm 26.06.2018
    /// </summary>
    [Serializable]
    public class MExcel : MBase
    {
        /// <summary>
        /// ImportExcelXLS - đuôi *.xls
        /// CreateBy: truongnm 07.09.2018
        /// </summary>
        public static DataTable ImportExcelXLS(String FileName ="", bool hasHeaders = true, string sheetName = "Sheet1")
        {
            String HDR = hasHeaders ? "Yes" : "No";
            String strConn = String.Empty;
            if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";
            OleDbConnection cnn = new OleDbConnection(strConn);
            OleDbCommand oconn = new OleDbCommand(string.Format("SELECT * FROM [{0}$]", sheetName), cnn);
            cnn.Open();
            OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnn.Close();
            adp.Dispose();
            return dt;
        }
        /// <summary>
        /// ImportExcelCSV - đuôi *.csv
        /// CreateBy: truongnm 07.09.2018
        /// </summary>
        public static DataTable ImportExcelCSV(String FileName = "", char Sep = ',')
        {
            StreamReader sr = new StreamReader(FileName);
            string[] headers = sr.ReadLine().Split(Sep);
            DataTable dt = new DataTable();
            foreach (string item in headers)
                dt.Columns.Add(item);
            //
            while (!sr.EndOfStream)
            {
                string[] sRows = sr.ReadLine().Split(Sep);
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = sRows[i];
                }
                dt.Rows.Add(dr);
            }
            sr.Close();
            //
            return dt;
        }
    }
}
