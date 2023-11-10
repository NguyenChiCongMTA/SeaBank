using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using SafeControl.Base;
using Newtonsoft.Json;

namespace SafeControl.Dictionary
{
    /// <summary>
    /// Thư viện thao tác với FileBase64
    /// CreateBy: truongnm 17.03.2022
    /// </summary>
    [Serializable]
    public class MFileBase64 : MBase
    {
        /// <summary>
        /// Hàm ToBase64String
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public static string ToBase64String(string fileName)
        {
            using (FileStream reader = new FileStream(fileName, FileMode.Open))
            {
                byte[] buffer = new byte[reader.Length];
                reader.Read(buffer, 0, (int)reader.Length);
                return Convert.ToBase64String(buffer);
            }
        }
        /// <summary>
        /// Hàm ToString
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public static void ToString(string fileName, string serializedFile)
        {
            using (System.IO.FileStream reader = System.IO.File.Create(fileName))
            {
                byte[] buffer = Convert.FromBase64String(serializedFile);
                reader.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
