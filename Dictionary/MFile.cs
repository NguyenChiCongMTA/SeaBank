using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using SafeControl.Base;

namespace SafeControl.Dictionary
{
    /// <summary>
    /// Thư viện thao tác File IO
    /// </summary>
    [Serializable]
    public class MFile : MBase
    {
        /// <summary>
        /// Hàm xóa file biết đường dẫn
        /// CreateBy: truongnm: 28-06-2019
        /// </summary>
        public static void DeleteFileWithPath(string sPath)
        {
            FileInfo fOut = new FileInfo(sPath);
            if (fOut.Exists) fOut.Delete();
        }
        /// <summary>
        /// Open source file Py
        /// CreateBy: truongnm: 15-01-2018
        /// </summary>
        public string OpenFilePy1(string sFileName)
        {
            string sKetQua = string.Empty;
            StreamReader reader = new StreamReader(sFileName);
            sKetQua = @reader.ReadToEnd();
            reader.Close();
            return sKetQua;
        }
        /// <summary>
        /// Save source file Py
        /// CreateBy: truongnm: 15-01-2018
        /// </summary>
        public void SaveFilePy(string sFileName, string sContext)
        {
            using (StreamWriter write = new StreamWriter(sFileName))
            {
                write.Write(sContext);
                write.Close();
            }
        }
        /// <summary>
        /// Lưu file dạng Text
        /// CreateBy: truongnm: 24-25-2018
        /// </summary>
        /// <param name="fileName">tên file</param>
        public void SaveFile(string fileName,string sData)
        {
            using (StreamWriter write = new StreamWriter(fileName))
            { 
                write.Write(sData);
                write.Close();
            }
        }
        /// <summary>
        /// Lưu file dạng Binary
        /// CreateBy: truongnm 25.10.2018
        /// </summary>
        /// <param name="spath"></param>
        /// <param name="data"></param>
        public void SaveFileBinary(string spath, string data)
        {
            string[] _bdt = data.Trim().Split(' ');
            //
            using (FileStream stream = new FileStream(spath, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    foreach (string tmp in _bdt)
                    {
                        writer.Write(byte.Parse(tmp.Trim()));
                    }
                    writer.Close();
                }
            }
        }
        /// <summary>
        /// Lưu file dạng Bin
        /// CreateBy: truongnm 06.08.2019
        /// </summary>
        public void SaveFileFromBin(string path, byte[] data)
        {
            //
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    foreach (byte tmp in data)
                        writer.Write(tmp);
                    //
                    writer.Close();
                }
            }
        }
        /// <summary>
        /// Lưu file dạng Bin
        /// CreateBy: truongnm 06.08.2019
        /// </summary>
        public void SaveFileFromBin(string path, int[] data)
        {
            //
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    foreach (int tmp in data)
                        writer.Write(tmp);
                    //
                    writer.Close();
                }
            }
        }
        /// <summary>
        /// Mở file lớn đọc dạng byte - đúng với cả trường hợp File đấy đang bị sử dụng
        /// CreateBy: truongnm 28.08.2019
        /// </summary>
        public static List<byte> MOpenLargeFileWithOutBeingUsed(string sPathFile, int iNumRead = 4, long iStart=0, long iEnd=0)
        {
            List<byte> lResult = new List<byte>();
            //
            byte[] fb = new byte[iNumRead];
            using (BinaryReader binaryReader = new BinaryReader(new FileStream(sPathFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                //
                iEnd = iEnd < binaryReader.BaseStream.Length ? iEnd : binaryReader.BaseStream.Length;
                //
                long iSum = iEnd - iStart;
                long iVitri = iStart;
                //
                binaryReader.BaseStream.Seek(iVitri, SeekOrigin.Begin);
                //
                while (iVitri < iSum)
                {
                    binaryReader.Read(fb, 0, iNumRead);
                    //
                    lResult.AddRange(fb);
                    //
                    iVitri += iNumRead;
                }
                binaryReader.Close();
            }
            return lResult;
        }
        /// <summary>
        /// Open text file 
        /// CreateBy: truongnm: 15-01-2018
        /// </summary>
        public string OpenTextFile(string sFileName)
        {
            string sKetQua = string.Empty;
            StreamReader reader = new StreamReader(sFileName);
            sKetQua = @reader.ReadToEnd();
            reader.Close();
            return sKetQua;
        }
        
        
    }
}
