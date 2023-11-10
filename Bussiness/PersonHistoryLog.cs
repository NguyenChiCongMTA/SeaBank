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
    /// CreateBy: truongnm 25.03.2022
    /// </summary>
    [Serializable]
    public class PersonHistoryLog : MBase
    {
        public DateTime dCreate { set; get; }
        public string sUserWrite { set; get; }
        public string sType { set; get; }
        public string sContext { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public PersonHistoryLog(DateTime _dCreate, string _sUserWrite,string _sType, string _sContext)
        {
            dCreate = _dCreate;
            sUserWrite = _sUserWrite;
            sType = _sType;
            sContext = _sContext;
        }
        /// <summary>
        /// Hàm CheckLogFromDate
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public bool CheckLogFromDate(DateTime dTuNgay, DateTime dDenNgay, iPersonHistoryLogType iPersonHistoryLogType) 
        {
            bool bResult = false;
            switch (iPersonHistoryLogType)
            {
                case iPersonHistoryLogType.None:
                case iPersonHistoryLogType.Null:
                default:
                    return bResult;
                case iPersonHistoryLogType.Email:
                    // Trường hợp ngày không thỏa mãn
                    if ((dCreate < dTuNgay || dCreate > dDenNgay) && (sType == "Email")) { return bResult; }
                    break;
                case iPersonHistoryLogType.Sms:
                    // Trường hợp ngày không thỏa mãn
                    if ((dCreate < dTuNgay || dCreate > dDenNgay) && (sType == "Sms")) { return bResult; }
                    break;
            }
            // Trường hợp ngày thỏa mãn
            bResult = true;
            //
            return bResult;
        }
    }
}
