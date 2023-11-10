using SafeControl.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeControl.Bussiness
{
    /// <summary>
    /// Khởi tạo 
    /// CreateBy: truongnm 25.03.2022
    /// </summary>
    [Serializable]
    public class SendAPI_Email_body_utility_paramlist_file_attachment_file : MBase
    {
        public string file_name { set; get; }
        public string file_byte64 { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_Email_body_utility_paramlist_file_attachment_file(string _file_name, string _file_byte64)
        {
            file_name = _file_name;
            file_byte64 = _file_byte64;
        }
    }
}
