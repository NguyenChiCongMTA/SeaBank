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
    public class SendAPI_Sms_body : MBase
    {
        public string command { set; get; }
        public SendAPI_Sms_body_utility utility { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_Sms_body(string _command, SendAPI_Sms_body_utility _utility)
        {
            command = _command;
            utility = _utility;
        }
    }
}
