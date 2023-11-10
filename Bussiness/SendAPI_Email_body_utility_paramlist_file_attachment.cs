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
    public class SendAPI_Email_body_utility_paramlist_file_attachment : MBase
    {
        public List<SendAPI_Email_body_utility_paramlist_file_attachment_file> file { get; set; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_Email_body_utility_paramlist_file_attachment(List<SendAPI_Email_body_utility_paramlist_file_attachment_file> _file)
        {
            file = _file;
        }
    }
}
