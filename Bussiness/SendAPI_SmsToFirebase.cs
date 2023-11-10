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
    public class SendAPI_SmsToFirebase : MBase
    {
        public SendAPI_SmsToFirebase_header header { set; get; }
        public SendAPI_SmsToFirebase_body body { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_SmsToFirebase(SendAPI_SmsToFirebase_header _header, SendAPI_SmsToFirebase_body _body)
        {
            header = _header;
            body = _body;
        }
    }
}
