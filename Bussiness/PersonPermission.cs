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
    public class PersonPermission : MBase
    {
        public List<PersonPermissionLog> PersonPermissionLog { set; get; }
        MFile oMFile = null;
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public PersonPermission(List<PersonPermissionLog> _PersonPermissionLog = null)
        {
            PersonPermissionLog = _PersonPermissionLog != null ? _PersonPermissionLog : new List<PersonPermissionLog>();
            //
            oMFile = new MFile();
        }
        /// <summary>
        /// Hàm SavePersonPermission
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void SavePersonPermission() 
        {
            oMFile.SaveFile(GetDuongDanPermission() + string.Format(Constants.FilePathConstant.PERSON_PERMISSION_LOG), MBaseJson<PersonPermission>.SerializesAnObjectToJSON(this));
        }
        /// <summary>
        /// Hàm ReadPersonPermission
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public PersonPermission ReadPersonPermission()
        {
            if (!File.Exists(GetDuongDanPermission() + string.Format(Constants.FilePathConstant.PERSON_PERMISSION_LOG)))
                oMFile.SaveFile(GetDuongDanPermission() + string.Format(Constants.FilePathConstant.PERSON_PERMISSION_LOG), MBaseJson<PersonPermission>.SerializesAnObjectToJSON(this));
            //
            return MBaseJson<PersonPermission>.DeserializeObject(new MFile().OpenTextFile(GetDuongDanPermission() + string.Format(Constants.FilePathConstant.PERSON_PERMISSION_LOG)));
        }
        /// <summary>
        /// Hàm AddPersonPermissionLog
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void AddPersonPermissionLog(string _sControlName, string _sPersonPermission, string _sNote)
        {
            PersonPermissionLog oPersonPermissionLog = new Bussiness.PersonPermissionLog(_sControlName, _sPersonPermission, _sNote);
            this.PersonPermissionLog.Add(oPersonPermissionLog);
            //
            SavePersonPermission();
        }
        /// <summary>
        /// Hàm EditPersonPermissionLog
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void EditPersonPermissionLog(string _sControlName, string _sPersonPermission, string _sNote, string _sControlNameNew, string _sPersonPermissionNew, string _sNoteNew)
        {
            //
            int iIndex = 0;
            //
            foreach (var item in PersonPermissionLog)
            {
                if ((item.sControlName == _sControlName) && (item.sPersonPermission == _sPersonPermission) && (item.sNote == _sNote)) break;
                iIndex++;
            }
            if (iIndex >= PersonPermissionLog.Count) return;
            //
            this.PersonPermissionLog[iIndex].sControlName = _sControlNameNew;
            this.PersonPermissionLog[iIndex].sPersonPermission = _sPersonPermissionNew;
            this.PersonPermissionLog[iIndex].sNote = _sNoteNew;
            //
            SavePersonPermission();
        }
        /// <summary>
        /// Hàm AddPersonPermissionLog
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void DeletePersonPermissionLog(string _sControlName, string _sPersonPermission, string _sNote)
        {
            PersonPermissionLog oPersonPermissionLog = new Bussiness.PersonPermissionLog(_sControlName, _sPersonPermission, _sNote);
            this.PersonPermissionLog.Remove(oPersonPermissionLog);
            //
            SavePersonPermission(); 
        }
        /// <summary>
        /// Hàm GetDuongDanPermission
        /// Hàm này là hàm đặc thù của Project - SafeControl -
        /// CreateBy: truongnm 05.04.2022
        /// </summary>
        public string GetDuongDanPermission()
        {
            //
            return oMFile.OpenTextFile(Application.StartupPath + Constants.FilePathConstant.DATABASE_PERMISSION_CONFIG).Trim();
        }
        /// <summary>
        /// Hàm ToDataTablePersionPermissionLog
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public DataTable ToDataTablePersionPermissionLog()
        {
            DataTable dDataTable = new DataTable();
            // Định nghĩa cột
            DataColumn dc;
            //
            dc = new DataColumn(); dc.ColumnName = "sControlName"; dc.Caption = "sControlName"; dc.DataType = typeof(string); dDataTable.Columns.Add(dc);
            dc = new DataColumn(); dc.ColumnName = "sPersonPermission"; dc.Caption = "sPersonPermission"; dc.DataType = typeof(string); dDataTable.Columns.Add(dc);
            dc = new DataColumn(); dc.ColumnName = "sNote"; dc.Caption = "sNote"; dc.DataType = typeof(string); dDataTable.Columns.Add(dc);
            // Thêm hàng
            //
            for (int i = 0; i < PersonPermissionLog.Count; i++)
            {
                DataRow dr = dDataTable.NewRow();
                dr["sControlName"] = PersonPermissionLog[i].sControlName;
                dr["sPersonPermission"] = PersonPermissionLog[i].sPersonPermission;
                dr["sNote"] = PersonPermissionLog[i].sNote;
                dDataTable.Rows.Add(dr);
            }
            return dDataTable;
        }
        /// <summary>
        /// Ham IsCheckPermission
        /// CreateBy: truongnm 05.04.2022
        /// </summary>
        public bool IsCheckPermission(string _sControlName, string sUserName) 
        {
            bool bResult = false;
            // Duyệt các log
            for (int i = 0; i < PersonPermissionLog.Count; i++)
            {
                bResult = PersonPermissionLog[i].IsCheckPermission(_sControlName, sUserName);
                if (bResult) return bResult;
            }
            //
            return bResult;
        }
    }
}
