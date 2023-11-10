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
    public class SendAPI_Sms_body_utility : MBase
    {
        public string key { set; get; }
        public string user_id { set; get; }
        public string channel { set; get; }
        public string service_id { set; get; }
        public string content { set; get; }
        public string co_code { set; get; }
        public int is_update { set; get; }
        public string branch_name { set; get; }
        public string job { set; get; }
        public string notify_key { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_Sms_body_utility(
            string _key
            , string _user_id
            , string _channel
            , string _service_id
            , string _content
            , string _co_code
            , int _is_update
            , string _branch_name
            , string _job
            , string _notify_key
        )
        {
            key = _key;
            user_id = _user_id;
            channel = _channel;
            service_id = _service_id;
            content = _content;
            co_code = _co_code;
            is_update = _is_update;
            branch_name = _branch_name;
            job = _job;
            notify_key = _notify_key;
        }
    }
}
