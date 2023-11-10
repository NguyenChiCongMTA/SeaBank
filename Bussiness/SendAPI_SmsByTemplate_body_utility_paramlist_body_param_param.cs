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
    public class SendAPI_SmsByTemplate_body_utility_paramlist_body_param_param : MBase
    {
        public string param_name { set; get; }
        public string param_value { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_SmsByTemplate_body_utility_paramlist_body_param_param(
            string _param_name
            , string _param_value
        )
        {
            param_name = _param_name;
            param_value = _param_value;
        }
    }
}
