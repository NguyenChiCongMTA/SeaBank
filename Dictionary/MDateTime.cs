using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using SafeControl.Base;

namespace SafeControl.Dictionary
{
    /// <summary>
    /// Thư viện thao tác với DateTime
    /// CreateBy: truongnm 23.08.2019
    /// </summary>
    [Serializable]
    public class MDateTime : MBase
    {
        /// <summary>
        /// Hàm CongTruThemNgay
        /// + thì số ngày là > 0
        /// - thì số ngày < 0
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public static DateTime CongTruThemNgay(DateTime dTuNgay, int iSoNgay)
        {
            // Lấy ngày đến hạn chọn trừ đi (nhân với -1) số ngày trong vòng
            return dTuNgay.AddDays(iSoNgay);
            
        }
    }
}
