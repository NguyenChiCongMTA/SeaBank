using SafeControl.Base;
using SafeControl.Dictionary;
using SafeControl.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafeControl.Bussiness
{
    /// <summary>
    /// Khởi tạo 
    /// CreateBy: truongnm 25.03.2022
    /// </summary>
    [Serializable]
    public class PersonHistory : MBase
    {
        public string personid { set; get; }
        public List<PersonHistoryLog> PersonHistoryLog { set; get; }
        MFile oMFile = null;
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public PersonHistory(string _personid = "", List<PersonHistoryLog> _PersonHistoryLog = null)
        {
            personid = _personid;
            PersonHistoryLog = _PersonHistoryLog != null ? _PersonHistoryLog : new List<PersonHistoryLog>();
            //
            oMFile = new MFile();
        }
        /// <summary>
        /// Hàm SavePersonHistory
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void SavePersonHistory() 
        {
            oMFile.SaveFile(GetDuongDanHistory() + string.Format("/{0}.txt", personid), MBaseJson<PersonHistory>.SerializesAnObjectToJSON(this));
        }
        /// <summary>
        /// Hàm ReadPersonHistory
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public PersonHistory ReadPersonHistory()
        {
            if (!File.Exists(GetDuongDanHistory() + string.Format("/{0}.txt", personid))) 
                oMFile.SaveFile(GetDuongDanHistory() + string.Format("/{0}.txt", personid), MBaseJson<PersonHistory>.SerializesAnObjectToJSON(this));
            //
            return MBaseJson<PersonHistory>.DeserializeObject(new MFile().OpenTextFile(GetDuongDanHistory() + string.Format("/{0}.txt", personid)));
        }
        /// <summary>
        /// Hàm AddPersonHistoryLog
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void AddPersonHistoryLog(DateTime _dCreate, string _sUserWrite,string _sType, string _sContext)
        {
            PersonHistoryLog oPersonHistoryLog = new Bussiness.PersonHistoryLog(_dCreate, _sUserWrite,_sType, _sContext);
            this.PersonHistoryLog.Add(oPersonHistoryLog);
            //
            SavePersonHistory();
        }
        /// <summary>
        /// Hàm AddPersonHistoryLog
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void DeletePersonHistoryLog(DateTime _dCreate, string _sUserWrite, string _sType, string _sContext)
        {
            PersonHistoryLog oPersonHistoryLog = new Bussiness.PersonHistoryLog(_dCreate, _sUserWrite,_sType, _sContext);
            this.PersonHistoryLog.Remove(oPersonHistoryLog);
            //
            SavePersonHistory(); 
        }
        /// <summary>
        /// Hàm ToDataTablePersionHistoryLog
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public DataTable ToDataTablePersionHistoryLog()
        {
            DataTable dDataTable = new DataTable();
            // Định nghĩa cột
            DataColumn dc;
            //
            dc = new DataColumn(); dc.ColumnName = "dCreate"; dc.Caption = "dCreate"; dc.DataType = typeof(DateTime); dDataTable.Columns.Add(dc);
            dc = new DataColumn(); dc.ColumnName = "sUserWrite"; dc.Caption = "sUserWrite"; dc.DataType = typeof(string); dDataTable.Columns.Add(dc);
            dc = new DataColumn(); dc.ColumnName = "sType"; dc.Caption = "sType"; dc.DataType = typeof(string); dDataTable.Columns.Add(dc);
            dc = new DataColumn(); dc.ColumnName = "sContext"; dc.Caption = "sContext"; dc.DataType = typeof(string); dDataTable.Columns.Add(dc);
            // Thêm hàng
            //
            for (int i = 0; i < PersonHistoryLog.Count; i++)
            {
                DataRow dr = dDataTable.NewRow();
                dr["dCreate"] = PersonHistoryLog[i].dCreate;
                dr["sUserWrite"] = PersonHistoryLog[i].sUserWrite;
                dr["sType"] = PersonHistoryLog[i].sType;
                dr["sContext"] = PersonHistoryLog[i].sContext;
                dDataTable.Rows.Add(dr);
            }
            return dDataTable;
        }
        /// <summary>
        /// Hàm GetDuongDanHistory
        /// Hàm này là hàm đặc thù của Project - SafeControl -
        /// CreateBy: truongnm 19.03.2022
        /// </summary>
        public string GetDuongDanHistory()
        {
            //
            return oMFile.OpenTextFile(Application.StartupPath + Constants.FilePathConstant.DATABASE_HISTORY_CONFIG).Trim();
        }
        /// <summary>
        /// Hàm CheckLogFromDate
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public bool CheckLogFromDate(DateTime dTuNgay, DateTime dDenNgay, iPersonHistoryLogType iPersonHistoryLogType)
        {
            bool bResult = false;
            // Duyệt các log
            for (int i = 0; i < PersonHistoryLog.Count; i++)
            {
                bResult = PersonHistoryLog[i].CheckLogFromDate(dTuNgay, dDenNgay, iPersonHistoryLogType);
                if (bResult) return bResult;
            }
            //
            return bResult;
        }
    }
}
