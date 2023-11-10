using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SafeControl.Base;

namespace SafeControl.Dictionary
{
    public class MFileEx : MBase
    {
        //
        public static string Png = "PNG Portable Network Graphics (*.png)|" + "*.png";
        public static string Jpg = "JPEG File Interchange Format (*.jpg *.jpeg *jfif)|" + "*.jpg;*.jpeg;*.jfif";
        public static string Bmp = "BMP Windows Bitmap (*.bmp)|" + "*.bmp";
        public static string Tif = "TIF Tagged Imaged File Format (*.tif *.tiff)|" + "*.tif;*.tiff";
        public static string Gif = "GIF Graphics Interchange Format (*.gif)|" + "*.gif";
        public static string ExcelFile = "Excel file|" + "*.xls;*.xlsx;*.xlsm;*.csv";
        public static string PDFFile = "PDF file|" + "*.pdf";
        public static string VideoFile = "MP4, WMV, AVI file|" + "*.mp4;*.wmv;*.avi";
        public static string WavFile = "Wav file|" + "*.wav";
        public static string ZipFile = "Zip file |" + "*.rar; *.zip; *.7z"; 
        //
        public static string EmailFile = "Email file |" + "*.eml";
        public static string RarFile = "Rar file |" + "*.rar;"; 
        //
        public static string TableKeyFile = "Table Key file |" + "*.tblkey";
        //
        public static string AllImagesExpand = "*.png; *.jpg; *.jpeg; *.jfif; *.bmp;*.tif; *.tiff; *.gif";
        public static string AllImages = "Image file|" + "*.png; *.jpg; *.jpeg; *.jfif; *.bmp;*.tif; *.tiff; *.gif";
        public static string AllDocument = "Document(*.doc,*.docx)|*.doc;*.docx|Excel(*.xls,*.xlsx)|*.xls;*.xlsx|PDF(*.pdf)|*.pdf|Text(*.txt)|*.txt|Image(*.tif,*.tiff,*.jpg,*.gif)|*.tif;*.tiff;*.jpg;*.gif";
        public static string AllFiles = "All files (*.*)" + "|*.*";
        //
    }
}
