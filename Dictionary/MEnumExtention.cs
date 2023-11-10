using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace SafeControl.Dictionary
{
    /// <summary>
    /// Thư viện thao tác với EnumExtention 
    /// CreateBy: truongnm 26.06.2018
    /// </summary>
    [Serializable]
    public class MEnumExtention 
    {
        /// <summary>
        /// Hàm lấy tên Enum
        /// CreateBy: truongnm 09.10.2019
        /// </summary>
        public static string MGetValueStringFromEnum(System.Enum iEnum)
        {
            return SafeControl.EnumConvert.LocalizedEnumConverter.ConvertToString(iEnum);
        }
    }
}
