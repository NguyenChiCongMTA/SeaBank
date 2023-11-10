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
    public class SendAPI_Email_security : MBase
    {
        public string sign { set; get; }
        public string sender { set; get; }
        public string code { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_Email_security(string _sign, string _sender, string _code)
        {
            sign = _sign;
            sender = _sender;
            code = _code;
        }
    }
}
