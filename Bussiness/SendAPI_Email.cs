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
    public class SendAPI_Email : MBase
    {
        public SendAPI_Email_header header { set; get; }
        public SendAPI_Email_body body { set; get; }
        public SendAPI_Email_security security { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_Email(SendAPI_Email_header _header, SendAPI_Email_body _body, SendAPI_Email_security _security)
        {
            header = _header;
            body = _body;
            security = _security;
        }
    }
}
