using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SafeControl.Base;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data;

namespace SafeControl.Dictionary
{
    /// <summary>
    /// Thư viện thao tác với String
    /// CreateBy: truongnm 26.06.2018
    /// </summary>
    [Serializable]
    public class MString : MBase
    {
        /// <summary>
        /// Hàm cắt chu kì
        /// </summary>
        /// CreateBy: truongnm 26.06.2018
        public string MChuKi(string Str, int ddck)
        {
            //
            // Xử lý dữ liệu
            //
            Str = Str.Trim();
            Str = Str.Replace("\r\n", " ");
            Str = Str.Replace("\n", " ");
            Str = Str.Replace("\r", " ");
            Str = Str.Replace("  ", " ");
            Str = Str.Replace(" ", "");
            int ddc = Str.Length;
            int dem = 0;
            int demSpace = 0;
            for (int i = 0; i < ddc; i++)
            {
                dem = dem + 1;
                if (dem % ddck == 0)
                {
                    Str = Str.Insert(dem + demSpace, "\n");
                    demSpace = demSpace + 1;
                }
            }
            return (Str);
        }
        /// <summary>
        /// Hàm bỏ các ký tự đặc biệt, Allchar = false là TH không bỏ khoảng trống
        /// </summary>
        /// CreateBy: truongnm 16.01.2019
        public static string MRemoveCharSpecial(string sString, bool bAllChar = true)
        {
            string sResult = sString;
            //
            while (sResult.IndexOf("\r") != -1) sResult = sResult.Replace("\r", "");
            while (sResult.IndexOf("\n") != -1) sResult = sResult.Replace("\n", "");
            while (sResult.IndexOf("\t") != -1) sResult = sResult.Replace("\t", "");
            while (sResult.IndexOf("\0") != -1) sResult = sResult.Replace("\0", "");
            //
            if (bAllChar)
            {
                while (sResult.IndexOf(" ") != -1) sResult = sResult.Replace(" ", "");
            }
            else // trường hợp ngoại trừ dấu cách " "
            {
                while (sResult.IndexOf("  ") != -1) sResult = sResult.Replace("  ", " "); // đổi 2 dấu cách thành 1 dấu cách
            }
            return sResult;
        }
        /// <summary>
        /// Hàm bỏ các ký tự đặc biệt
        /// iOption:
        /// 0: Xóa all
        /// 1: Bỏ qua dấu cách
        /// 2: Quy chuẩn dạng bảng khóa, mã
        /// 3: Quy chuẩn bỏ \r \0; 2 space thành 1 space; 2 \n thành 1 \n; 2 \t thành 1 \t
        /// 4: Quy chuẩn bỏ \r \n;
        /// </summary>
        /// CreateBy: truongnm 04.09.2019
        /// EditBy: truongnm 10.03.2022
        public static string MRemoveCharSpecial2(string sString, int iOption = 0)
        {
            string sResult = sString;
            //
            switch (iOption)
            {
                case 0: // 0: Xóa all
                default:
                    while (sResult.IndexOf("\r") != -1) sResult = sResult.Replace("\r", "");
                    while (sResult.IndexOf("\n") != -1) sResult = sResult.Replace("\n", "");
                    while (sResult.IndexOf("\t") != -1) sResult = sResult.Replace("\t", "");
                    while (sResult.IndexOf("\0") != -1) sResult = sResult.Replace("\0", "");
                    while (sResult.IndexOf(" ") != -1) sResult = sResult.Replace(" ", "");
                    break;
                case 1: // 1: Bỏ qua dấu cách
                    while (sResult.IndexOf("\r") != -1) sResult = sResult.Replace("\r", "");
                    while (sResult.IndexOf("\n") != -1) sResult = sResult.Replace("\n", "");
                    while (sResult.IndexOf("\t") != -1) sResult = sResult.Replace("\t", "");
                    while (sResult.IndexOf("\0") != -1) sResult = sResult.Replace("\0", "");
                    while (sResult.IndexOf("  ") != -1) sResult = sResult.Replace("  ", " "); // đổi 2 dấu cách thành 1 dấu cách
                    break;
                case 2: // 2: Quy chuẩn dạng bảng khóa, mã
                    while (sResult.IndexOf("\r") != -1) sResult = sResult.Replace("\r", "");
                    while (sResult.IndexOf("\0") != -1) sResult = sResult.Replace("\0", "");
                    while (sResult.IndexOf(" ") != -1) sResult = sResult.Replace(" ", "");
                    break;
                case 3: // 3: Quy chuẩn bỏ \r \0; 2 space thành 1 space; 2 \n thành 1 \n; 2 \t thành 1 \t
                    while (sResult.IndexOf("\r") != -1) sResult = sResult.Replace("\r", "");
                    while (sResult.IndexOf("\0") != -1) sResult = sResult.Replace("\0", "");
                    while (sResult.IndexOf("  ") != -1) sResult = sResult.Replace("  ", " ");
                    while (sResult.IndexOf("\t\t") != -1) sResult = sResult.Replace("\t\t", "\t");
                    break;
                case 4: // 4: Quy chuẩn bỏ \r \n;
                    while (sResult.IndexOf("\r") != -1) sResult = sResult.Replace("\r", "");
                    while (sResult.IndexOf("\n") != -1) sResult = sResult.Replace("\n", "");
                    break;
            }
            //
            return sResult;
        }
        /// <summary>
        /// Hàm in ra màn hình với độ dài cho phép
        /// Format 1 String With Number
        /// </summary>
        /// CreateBy: truongnm 10.06.2019
        public static string MFormat1StringWNum(string sString, int iNum = 10)
        {
            return string.Format("{0,-" + iNum + "}", sString);
        }
        /// <summary>
        /// Hàm in ra màn hình với độ dài cho phép
        /// Format N String With Number
        /// </summary>
        /// CreateBy: truongnm 10.06.2019
        public static string MFormatNStringWNum(string[] sString, int iNum = 10)
        {
            string sResult = string.Empty;
            foreach (var item in sString)
            {
                sResult += string.Format("{0,-" + iNum + "}", item);
            }
            return sResult;
        }
        /// <summary>
        /// Hàm so sánh điều kiện OR
        /// CreateBy: truongnm 04.09.2019
        /// </summary>
        /// <returns></returns>
        public static bool MIsORWithArr(string sString1, string[] sString2)
        {
            bool bResult = false;
            foreach (var item in sString2)
                if (sString1 == item) return true;
            return bResult;
        }

        /// <summary>
        /// Hàm cộng/trừ 2 số
        /// CreateBy: truongnm 10.07.2019
        /// </summary>
        public static string MCongTru2Number(string sNumber1 = "123", string sNumber2 = "122", bool bTru = true)
        {
            try
            {
                if (sNumber1 == "" || sNumber2 == "") return sNumber1;
                //
                int iNum1 = int.Parse(sNumber1); int iNum2 = int.Parse(sNumber2);
                //
                return bTru ? Convert.ToString(Math.Abs(iNum1 - iNum2)) : Convert.ToString(iNum1 + iNum2);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// Hàm thống kê tần số mẫu
        /// CreateBy: truongnm 09.08.2019
        /// </summary>
        public static Dictionary<string, int> MTanSoMau(string sData = "", int iDoDaiDuLieu = 1, int iCachBac = 1)
        {
            Dictionary<string, int> dResult = new Dictionary<string, int>();
            //
            int iSum = sData.Trim().Length;
            string sTemp = string.Empty;
            //
            for (int i = 0; i < iSum; i = i + iCachBac)
            {
                if (i + iDoDaiDuLieu >= iSum) sTemp = sData.Substring(i);
                else sTemp = sData.Substring(i, iDoDaiDuLieu);
                //
                int iViTri = dResult.Keys.ToList().IndexOf(sTemp); // Tìm vị trí trong từ điển
                if (iViTri == -1) dResult.Add(sTemp, 1); // trường hợp chưa có
                else dResult[sTemp] += 1;
                //
            }
            //
            return dResult;
        }
        /// <summary>
        /// Hàm thống kê tần số mẫu - theo cột
        /// CreateBy: truongnm 22.08.2019
        /// </summary>
        public static List<StringBuilder> MTanSoMauByCollumn(string sData = "", int iDoDaiDuLieu = 1, int iCachBac = 1)
        {
            int iSum = sData.Trim().Length;
            string sTemp = string.Empty;
            List<StringBuilder> lTemp = new List<StringBuilder>();
            //
            for (int i = 0; i < iSum; i = i + iCachBac)
            {
                if (i + iDoDaiDuLieu >= iSum) sTemp = sData.Substring(i);
                else sTemp = sData.Substring(i, iDoDaiDuLieu);
                //
                if (i == 0)
                {
                    for (int j = 0; j < sTemp.Length; j++)
                    {
                        StringBuilder sAddTemp = new StringBuilder(sTemp.Substring(j, 1));
                        lTemp.Add(sAddTemp); // trường hợp chưa có
                    }
                }
                else
                {
                    for (int j = 0; j < sTemp.Length; j++)
                        lTemp[j].Append(sTemp.Substring(j, 1)); // trường hợp chưa có
                }
                //
            }
            //
            return lTemp;
        }
        /// <summary>
        /// Hàm sắp xếp lại từ điển với: 
        /// iVal - 0: theo Key; 1:  theo Value - 
        /// iSort - 0: Tăng dần; 1: giảm dần - 
        /// CreateBy: truongnm 12.08.2019
        /// </summary>
        public static Dictionary<double, double> MSoftDictionary(Dictionary<double, double> dicData, int iVal = 0, int iSort = 0)
        {
            // Add code here:
            switch (iSort)
            {
                case 0:
                    var l = iVal == 0 ? dicData.OrderBy(o => o.Key) : dicData.OrderBy(o => o.Value);
                    dicData = l.ToDictionary(k => k.Key, v => v.Value);
                    break;
                case 1:
                    l = iVal == 0 ? dicData.OrderByDescending(o => o.Key) : dicData.OrderByDescending(o => o.Value);
                    dicData = l.ToDictionary(k => k.Key, v => v.Value);
                    break;
                default:
                    break;
            }
            //
            return dicData;
        }
        /// <summary>
        /// Hàm sắp xếp lại từ điển với: 
        /// iVal - 0: theo Key; 1:  theo Value - 
        /// iSort - 0: Tăng dần; 1: giảm dần - 
        /// CreateBy: truongnm 12.08.2019
        /// </summary>
        public static Dictionary<string, int> MSoftDictionary(Dictionary<string, int> dicData, int iVal = 0, int iSort = 0)
        {
            // Add code here:
            switch (iSort)
            {
                case 0:
                    var l = iVal == 0 ? dicData.OrderBy(o => o.Key) : dicData.OrderBy(o => o.Value);
                    dicData = l.ToDictionary(k => k.Key, v => v.Value);
                    break;
                case 1:
                    l = iVal == 0 ? dicData.OrderByDescending(o => o.Key) : dicData.OrderByDescending(o => o.Value);
                    dicData = l.ToDictionary(k => k.Key, v => v.Value);
                    break;
                default:
                    break;
            }
            //
            return dicData;
        }
        /// <summary>
        /// Hàm sắp xếp lại từ điển với: 
        /// iVal - 0: theo Key; 1:  theo Value - 
        /// iSort - 0: Tăng dần; 1: giảm dần - 
        /// CreateBy: truongnm 12.08.2019
        /// </summary>
        public static Dictionary<int, double> MSoftDictionary(Dictionary<int, double> dicData, int iVal = 0, int iSort = 0)
        {
            // Add code here:
            switch (iSort)
            {
                case 0:
                    var l = iVal == 0 ? dicData.OrderBy(o => o.Key) : dicData.OrderBy(o => o.Value);
                    dicData = l.ToDictionary(k => k.Key, v => v.Value);
                    break;
                case 1:
                    l = iVal == 0 ? dicData.OrderByDescending(o => o.Key) : dicData.OrderByDescending(o => o.Value);
                    dicData = l.ToDictionary(k => k.Key, v => v.Value);
                    break;
                default:
                    break;
            }
            //
            return dicData;
        }
        /// <summary>
        /// Hàm tính Autocorection - Xét trùng hoàn toàn: 
        /// CreateBy: truongnm 12.08.2019
        /// </summary>
        public static List<Dictionary<string, int>> MAutoCorrection(string sData, int iMax = 1024)
        {
            // Add code here:
            List<Dictionary<string, int>> lResult = new List<Dictionary<string, int>>();
            //
            for (int i = 1; i < iMax + 1; i++)
            {
                Dictionary<string, int> dic = MTanSoMau(sData, i, i);
                lResult.Add(dic);
            }
            //
            return lResult;
        }
        /// <summary>
        /// Hàm tính Autocorection - PP Anh Tuấn: 
        /// CreateBy: truongnm 13.08.2019
        /// </summary>
        public static Dictionary<int, double> MAutoCorrection_PP2(string sData, int iMin = 2, int iMax = 1024, bool bDong = true)
        {
            // Add code here:
            Dictionary<int, double> lResult = new Dictionary<int, double>();
            //
            sData = MRemoveCharSpecial(sData);
            //
            int dd = sData.Length;
            //
            for (int i = iMin; i < iMax + 1; i++)
            {
                double xx = 0;
                //
                if (bDong)
                {
                    for (int j = 0; j < dd - i; j++)
                        xx += sData.Substring(j, 1) == sData.Substring(j + i, 1) ? 1 : 0;
                }
                else // Cần kiểm tra lại tính theo cột
                {
                    for (int j = 0; j < dd / i; j++)
                        xx += sData.Substring(j, 1) == sData.Substring(j * i, 1) ? 1 : 0;
                }
                //
                lResult.Add(i, xx / (dd - i));
            }
            //
            return lResult;
        }
        /// <summary>
        /// Hàm tính Autocorection - Xét trùng hoàn toàn tính theo cột: 
        /// CreateBy: truongnm 22.08.2019
        /// </summary>
        public static List<List<StringBuilder>> MAutoCorrectionByCollumn(string sData, ref List<List<List<int>>> lIndex, int iMin = 2, int iMax = 1024)
        {
            // Add code here:
            List<List<StringBuilder>> lResult = new List<List<StringBuilder>>();
            //
            sData = MRemoveCharSpecial(sData);
            //
            lIndex = new List<List<List<int>>>();
            //
            for (int i = iMin; i < iMax + 1; i++)
            {
                List<StringBuilder> dic = MTanSoMauByCollumn(sData, i, i);
                lResult.Add(dic);
                // Tính Index cho mỗi chu kỳ
                List<List<int>> lTempIndexPeriod = new List<List<int>>();
                //
                for (int j = 0; j < dic.Count; j++)
                {
                    List<int> lTempIndex = new List<int>();
                    //
                    int iIndex = 0;
                    //
                    StringBuilder stringBuilder = new StringBuilder(dic[j].ToString());
                    // Tìm các vị trí xuất hiện trong dic
                    while ((iIndex = dic.FindIndex(iIndex, val => val.ToString().Trim() == stringBuilder.ToString().Trim())) != -1)
                    {
                        lTempIndex.Add(iIndex);
                        iIndex = iIndex + 1;
                    }
                    // Kiểm tra nếu không tìm thấy gì thì lưu lại vị trí dữ liệu
                    if (lTempIndex.Count == 0) lTempIndex.Add(j);
                    // Lưu lại giá trị
                    lTempIndexPeriod.Add(lTempIndex);
                }
                lIndex.Add(lTempIndexPeriod);
            }
            //
            return lResult;
        }
        /// <summary>
        /// Hàm nhặt cách bậc
        /// CreateBy: truongnm 27.08.2019
        /// </summary>
        public static string MNhatCachBac(string sData = "0123456789", int iNhat = 1, int iCachBac = 1)
        {
            string sResult = string.Empty;
            //
            sData = MRemoveCharSpecial(sData);
            int iSum = sData.Length;
            for (int i = 0; i < iSum; i = i + iCachBac)
            {
                string sTemp = string.Empty;
                //
                if (i + iNhat >= iSum) sTemp = sData.Substring(i);
                else sTemp = sData.Substring(i, iNhat);
                //
                sResult += sTemp;
            }
            //
            return sResult;
        }
        /// <summary>
        /// Hàm đảo BIT
        /// CreateBy: truongnm 06.09.2019
        /// </summary>
        public static string MDaoBit(string sData = "0000001")
        {
            string sResult = string.Empty;
            //
            for (int i = 0; i < sData.Length; i++)
                sResult += (Convert.ToInt32(sData.Substring(i, 1)) + 1) % 2;
            //
            return sResult;
        }
        /// <summary>
        /// Hàm đảo xâu
        /// CreateBy: truongnm 06.09.2019
        /// </summary>
        public static string MDaoXau(string sData = "0000001")
        {
            string sResult = string.Empty;
            //
            for (int i = 0; i < sData.Length; i++)
                sResult = sData.Substring(i, 1) + sResult;
            //
            return sResult;
        }
        /// <summary>
        /// Hàm đảo xâu
        /// CreateBy: truongnm 06.09.2019
        /// </summary>
        public static string MDEC2HEX(long lData = 100, bool isLittleEndian = true, int iCder = 32)
        {
            string sResult = string.Empty;
            //
            byte[] bArrTest = null;
            switch (iCder)
            {
                case 32:
                    bArrTest = BitConverter.GetBytes((int)lData);
                    break;
                case 64:
                    bArrTest = BitConverter.GetBytes(lData);
                    break;
            }
            if (isLittleEndian)
                Array.Reverse(bArrTest);
            sResult = BitConverter.ToString(bArrTest);
            //
            return sResult;
        }
        /// <summary>
        /// Hàm PostgresMira_UnixTimeStampToDateTime
        /// CreateBy: truongnm 02.12.2019
        /// </summary>
        public static DateTime MPostgresMira_UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return unixStart.AddMilliseconds(unixTimeStamp);
        }
        /// <summary>
        /// Hàm PostgresMira_UnixTimeStampToDateTime
        /// CreateBy: truongnm 03.12.2019
        /// </summary>
        public static long MPostgresMira_DateTimeToUnixTimeStamp(DateTime dTime)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return Convert.ToInt64((dTime - unixStart).TotalMilliseconds);
        }
        /// <summary>
        /// Hàm MSqlMoris_DateTimeToUnixTimeStamp
        /// CreateBy: truongnm 12.05.2020
        /// </summary>
        public static long MSqlMoris_DateTimeToUnixTimeStamp(DateTime dTime)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return Convert.ToInt64((dTime - unixStart).TotalMilliseconds) * 1000;
        }
        /// <summary>
        /// Unicode2String - OK
        /// Ex: sUnicodeString = "This string <U+0102> <U+0103> <U+0104>"
        /// Result = "This string "
        /// CreateBy: truongnm: 30-01-2020
        /// </summary>
        public static string MUnicode2String(string sUnicodeString = "This string Chua xác d<U+1ECB>nh                 <U+1EE4> Đôm Xay")
        {
            string sResult = string.Empty;
            //
            Regex regex = new Regex(@"<U\+(?<data>\w+)>");
            //
            sResult = MDecoderUTF16(sUnicodeString, regex, @"data");
            //
            return sResult;
            //
        }
        /// <summary>
        /// MDecoderUTF16
        /// CreateBy: truongnm: 04.02.2020
        /// </summary>
        public static string MDecoderUTF16(string sUTF16, Regex oRegex, string sNameGroup)
        {
            return oRegex.Replace(
                sUTF16,
                m => ((char)int.Parse(m.Groups[sNameGroup].Value, NumberStyles.HexNumber)).ToString()
                );
        }
        /// <summary>
        /// MReplaceInDic
        /// CreateBy: truongnm: 12.02.2020
        /// </summary>
        public static string MReplaceInDic(string sData, Dictionary<string, string> dDic)
        {
            string sResult = string.Empty;
            //
            List<string> lKey = dDic.Keys.ToList();
            List<string> lVal = dDic.Values.ToList();
            //
            for (int i = 0; i < lKey.Count; i++)
            {
                if (sData.Trim() == lKey[i].Trim())
                {
                    sResult += sData.Replace(lKey[i], lVal[i]);
                    break;
                }
            }
            //
            return sResult;
        }

        /// <summary>
        /// Hàm dữ liệu tham chiếu mô hình
        /// CreateBy: truongnm 09.03.2020
        /// </summary>
        public static string MGetDataThamChieu(DataTable dTableThamChieu, string sExpresion, string sGetName)
        {
            string sResult = string.Empty;
            //
            DataRow[] FoundRow = dTableThamChieu.Select(sExpresion);
            //
            if (FoundRow.Length == 0) return "";
            //
            sResult = FoundRow[0][sGetName].ToString();
            //
            return sResult;
        }
    }
}
