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
    public class SendAPI_Sms_1 : MBase
    {
        public SendAPI_Sms_1_header header { set; get; }
        public SendAPI_Sms_1_body body { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_Sms_1(SendAPI_Sms_1_header _header, SendAPI_Sms_1_body _body)
        {
            header = _header;
            body = _body;
        }
    }
}
