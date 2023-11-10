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
    /// Thư viện thao tác với Color
    /// CreateBy: truongnm 23.08.2019
    /// </summary>
    [Serializable]
    public class MColor : MBase
    {
        /// <summary>
        /// Hàm lấy màu từ Int
        /// CreateBy: truongnm 23.08.2019
        /// </summary>
        public static Color getColorByInt(int iRGB = 0x000000)
        {
            if (iRGB > Math.Pow(2, 24)) return Color.White; // Kiểm tra giá trị
            //
            return Color.FromArgb((iRGB >> 16) & 0xff, (iRGB >> 8) & 0xff, (iRGB >> 0) & 0xff);
        }
        /// <summary>
        /// Hàm đổi màu sang Int
        /// CreateBy: truongnm 23.08.2019
        /// </summary>
        public static int getIntByColor(Color cColor)
        {
            return cColor.R << 16 | cColor.G << 8 | cColor.B;
        }
    }
}
