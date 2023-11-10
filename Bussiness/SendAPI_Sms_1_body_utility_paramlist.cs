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
    public class SendAPI_Sms_1_body_utility_paramlist : MBase
    {
        public string user_id { set; get; }
        public string channel { set; get; }
        public string service_id { set; get; }
        public string infor { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_Sms_1_body_utility_paramlist(
            string _user_id
            , string _channel
            , string _service_id
            , string _infor
        )
        {
            user_id = _user_id;
            channel = _channel;
            service_id = _service_id;
            infor = _infor;
        }
    }
}
