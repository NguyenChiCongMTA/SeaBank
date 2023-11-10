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
    public class SendAPI_SmsByTemplate_body_utility_paramlist : MBase
    {
        public string user_id { set; get; }
        public string service_id { set; get; }
        public string id_temp { set; get; }
        public string channel { set; get; }
        public string co_code { set; get; }
        public SendAPI_SmsByTemplate_body_utility_paramlist_body_param body_param { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_SmsByTemplate_body_utility_paramlist(
            string _user_id
            , string _service_id
            , string _id_temp
            , string _channel
            , string _co_code
            , SendAPI_SmsByTemplate_body_utility_paramlist_body_param _body_param
        )
        {
            user_id = _user_id;
            service_id = _service_id;
            id_temp = _id_temp;
            channel = _channel;
            co_code = _co_code;
            body_param = _body_param;
        }
    }
}
