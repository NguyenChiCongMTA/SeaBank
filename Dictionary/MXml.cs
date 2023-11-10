using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using SafeControl.Base;
using System.Xml;

namespace SafeControl.Dictionary
{
    /// <summary>
    /// Thư viện thao tác - XML
    /// </summary>
    [Serializable]
    public class MXml : MBase
    {
        /// <summary>
        /// Lệnh GetLenFile
        /// Tính theo Bytes
        /// CreateBy: truongnm: 07.05.2020
        public static long GetLenFile(string sPathFileXml)
        {
            long lResult = 0;
            //
            FileInfo oFileInfo = new FileInfo(sPathFileXml);
            //
            if (oFileInfo.Exists) lResult = oFileInfo.Length;
            //
            return lResult;
        }
        /// <summary>
        /// Lệnh GetStringFromElementsByTagName
        /// CreateBy: truongnm: 05.05.2020
        public static string GetStringFromElementsByTagName(string sPathFileXml, string sTagName)
        {
            string sResult = string.Empty;
            //
            XmlDocument oXmlDocument = new XmlDocument();
            XmlNodeList oXmlNodeList = null;
            //
            oXmlDocument.Load(sPathFileXml);
            //
            sResult = GetDataByNode(oXmlDocument.GetElementsByTagName(sTagName));
            //
            oXmlDocument.RemoveAll();
            //
            return sResult;
        }
        /// <summary>
        /// Lệnh GetElementsByTagName
        /// CreateBy: truongnm: 05.05.2020
        public static XmlNodeList GetElementsByTagName(string sPathFileXml, string sTagName)
        {
            string sResult = string.Empty;
            //
            XmlDocument oXmlDocument = new XmlDocument();
            XmlNodeList oXmlNodeList = null;
            //
            oXmlDocument.Load(sPathFileXml);
            //
            oXmlNodeList = oXmlDocument.GetElementsByTagName(sTagName);
            //
            oXmlDocument.RemoveAll();
            //
            return oXmlNodeList;
        }
        /// <summary>
        /// Hàm lấy dữ liệu từ - XmlNode
        /// CreateBy: truongnm 05.05.2020
        /// </summary>
        private static string GetDataByNode(XmlNodeList oXmlNodeList)
        {
            try
            {
                //
                string sResult = "";
                //
                // EditBy: truongnm 21.05.2020
                sResult += string.Format("{0}\n", oXmlNodeList[0].InnerText); // dữ liệu full lấy từ NodeText 0
                //
                //for (int i = 0; i < oXmlNodeList.Count; i++)
                //{
                //    sResult += string.Format("{0}\n", oXmlNodeList[i].InnerText); // dữ liệu full
                //}
                //
                return sResult;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        /// <summary>
        /// Lệnh SelectSingleNode
        /// CreateBy: truongnm: 05.05.2020
        public static XmlNode SelectSingleNode(string sPathFileXml, string sXPath)
        {
            string sResult = string.Empty;
            //
            XmlDocument oXmlDocument = new XmlDocument();
            XmlNode oXmlNode = null;
            //
            oXmlDocument.Load(sPathFileXml);
            //
            oXmlNode = oXmlDocument.SelectSingleNode(sXPath);
            //
            oXmlDocument.RemoveAll();
            //
            return oXmlNode;
        }
        /// <summary>
        /// Lệnh GetValueSelectSingleNode
        /// CreateBy: truongnm: 05.05.2020
        public static string GetValueSelectSingleNode(string sPathFileXml, string sXPath, bool bVal = false, string sAttributes = "", bool bLong = false)
        {
            string sResult = string.Empty;
            //
            XmlDocument oXmlDocument = new XmlDocument();
            XmlNode oXmlNode = null;
            //
            oXmlDocument.Load(sPathFileXml);
            //
            oXmlNode = oXmlDocument.SelectSingleNode(sXPath);
            //
            oXmlDocument.RemoveAll();
            //
            return oXmlNode == null ? "" : bVal ? oXmlNode.Attributes.Count == 0 ? "" : oXmlNode.Attributes[sAttributes].Value : oXmlNode.InnerText;
        }
    }
}
