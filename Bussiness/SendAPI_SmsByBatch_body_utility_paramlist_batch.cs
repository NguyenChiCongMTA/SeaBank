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
    public class SendAPI_SmsByBatch_body_utility_paramlist_batch : MBase
    {
        public string phone { set; get; }
        public string channel { set; get; }
        public string infor { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_SmsByBatch_body_utility_paramlist_batch(
            string _phone
            , string _channel
            , string _infor
        )
        {
            phone = _phone;
            channel = _channel;
            infor = _infor;
        }
    }
}
