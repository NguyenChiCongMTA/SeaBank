using SafeControl.Base;
using SafeControl.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeControl.Bussiness
{
    /// <summary>
    /// Khởi tạo 
    /// CreateBy: truongnm 05.04.2022
    /// </summary>
    [Serializable]
    public class PersonPermissionLog : MBase
    {
        public string sControlName { set; get; }
        public string sPersonPermission { set; get; }
        public string sNote { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 05.04.2022
        /// </summary>
        public PersonPermissionLog(string _sControlName, string _sPersonPermission, string _sNote)
        {
            sControlName = _sControlName;
            sPersonPermission = _sPersonPermission;
            sNote = _sNote;
        }
        /// <summary>
        /// Ham IsCheckPermission
        /// CreateBy: truongnm 05.04.2022
        /// </summary>
        public bool IsCheckPermission(string _sControlName, string sUserName) 
        {
            bool bResult = false;
            //
            if (_sControlName != sControlName) return false;
            //
            bResult = sPersonPermission.Contains(sUserName);
            //
            return bResult;
        }
    }
}
