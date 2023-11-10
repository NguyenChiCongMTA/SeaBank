using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using SafeControl.Base;
namespace SafeControl.Dictionary
{
    /// <summary>
    /// Thư viện thao tác Image
    /// </summary>
    [Serializable]
    public class MImage : MBase
    {
        /////////////////////////////////////////////////////////////////////
        #region Declare

        #endregion
        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm khởi tạo lớp
        /// </summary>
        /// CreateBy: truongnm 05.08.2019
        public MImage()
        {
            
        }
        /// <summary>
        /// Hàm cover từ Image sang Byte array
        /// CreateBy: truongnm 05.08.2019
        /// </summary>
        public static byte[] Image2ByteArray(Image imageIn)
        {
            ImageFormat imageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
            //
            var memoryStream = new MemoryStream();
            imageIn.Save(memoryStream, imageFormat);
            return memoryStream.ToArray();
        }
        /// <summary>
        /// Hàm cover từ Byte array sang Image
        /// CreateBy: truongnm 05.08.2019
        /// </summary>
        public static Image ByteArray2Image(byte[] byteArrayIn)
        {
            var memoryStream = new MemoryStream(byteArrayIn);
            return Image.FromStream(memoryStream);
        }
        #endregion
        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        #region Override
        
        #endregion
        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        #region Event
        
        #endregion
        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
    }
}
