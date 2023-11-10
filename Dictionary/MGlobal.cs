using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using SafeControl.Base;

namespace SafeControl.Dictionary
{
    /// <summary>
    /// Thư viện thao tác với Global
    /// CreateBy: truongnm 10.08.2018
    /// </summary>
    [Serializable]
    public class MGlobal : MBase
    {
        public static string sSkinName = "Office 2013"; // Giao diện
        public static string sPhienBan = "[v1.0.5]"; // Phiên bản
        public static string sCultureInfoName = "vi"; // Ngôn ngữ
        public static Font fDefaultFont = new Font("Segoe UI", 8.25F); // Font hệ thống
        public static int iWINWORD = 30;
        public static DateTime iDay = new DateTime(year: 2022, month: 4, day: 14);
        public static string sKey = "12345@Abc$";
        //
        public List<string> SkinAll = new List<string>()
        {
            "DevExpress Style",
            "DevExpress Dark Style",
            "Office 2010 Silver",
            "Office 2010 Blue",
            "Office 2013",
            "Office 2013 Dark Gray",
            "Seven Classic",
            "McSkin",
            "VS2010",
            "Visual Studio 2013 Blue",
            "Visual Studio 2013 Light",
            "High Contrast",
            "Liquid Sky",
            "London Liquid Sky",
            "Metropolis",
            "Metropolis Dark",
            "Office 2007 Black",
            "Office 2007 Silver",
            "Office 2007 Blue",
            "Seven",
            "Sharp",
            "Sharp Plus",
            "Office 2013 Dark Gray",
            "Office 2013 Light Gray",
            "Visual Studio 2013 Blue",
            "Visual Studio 2013 Light",
            "Visual Studio 2013 Dark"
        };
    }
}
