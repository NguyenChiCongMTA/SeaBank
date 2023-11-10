using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using SafeControl.Base;
using System.Windows.Forms;
using SafeControl.Dictionary;

namespace SafeControl.Base
{
    /// <summary>
    /// Thư viện thao tác với CopyData
    /// CreateBy: truongnm 13.03.2022
    /// </summary>
    [Serializable]
    public class MCopyData : MBase
    {
        /// <summary>
        /// Hàm bCopyFileFormStringPath
        /// CreateBy: truongnm 13.03.2022
        /// </summary>
        public static bool bCopyFileFormStringPath(string fileName, string targetPath, string sourcePath)
        {
            bool bResult = false;
            //
            // Nối các đường dẫn với nhau
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            // Xóa đi rồi copy
            FileInfo fi2 = new FileInfo(destFile);
            if (File.Exists(destFile) && File.Exists(sourceFile))
            {
                fi2.Delete();
                //
                System.IO.File.Copy(sourceFile, destFile, true);
                //
                bResult = true;
            }
            else
                MMessageBox.Error(string.Format("Kiểm tra lại đường dẫn nguồn ({0})và đích ({1}) copy", sourceFile, destFile));
            //
            return bResult;
        }
        /// <summary>
        /// Hàm bCopyDataBaseFirebirdFormStringPath
        /// CreateBy: truongnm 13.03.2022
        /// </summary>
        public static bool bCopyDataBaseFirebirdFormStringPath(string fileName = "SAFECONTROL.FDB", string targetPath = @"D:\database", string sourcePath = @"C:\Program Files (x86)\SafeControl\data")
        {
            bool bResult = false;
            // Đóng tất cả các kết nối của Firebird đến việc copydata
            MBaseFirebird.SetAllFbConnectionPoolsAreCleared();
            // Bắt đầu copy
            bResult = bCopyFileFormStringPath(fileName, targetPath, sourcePath);
            //
            return bResult;
        }
        /// <summary>
        /// Hàm bCopyDataBaseFirebirdFormFilePathConfig
        /// Cách sử dụng:
        /// bCopyDataBaseFirebirdFormFilePathConfig(Application.StartupPath + Constants.FilePathConstant.DATABASE_COPY_DATABASE_CONFIG)
        /// CreateBy: truongnm 13.03.2022
        /// </summary>
        public static bool bCopyDataBaseFirebirdFormFilePathConfig(string sFilePathConfig)
        {
            bool bResult = false;
            // Đóng tất cả các kết nối của Firebird đến việc copydata
            MBaseFirebird.SetAllFbConnectionPoolsAreCleared();
            // Lấy đọc file dữ liệu config để lấy các tham số
            string sReadToEnd = string.Empty;
            StreamReader reader = new StreamReader(sFilePathConfig);
            sReadToEnd = @reader.ReadToEnd();
            reader.Close();
            string[] sTempParameter = sReadToEnd.Trim().Split('\n');
            //
            string fileName = sTempParameter[0].Trim(); // "SAFECONTROL.FDB";
            string sourcePath = sTempParameter[1].Trim();//@"C:\Program Files (x86)\SafeControl\data";
            string targetPath = sTempParameter[2].Trim();  //@"D:\database";
            // Bắt đầu copy
            bResult = bCopyFileFormStringPath(fileName, targetPath, sourcePath);
            //
            return bResult;
        }
    }
}
