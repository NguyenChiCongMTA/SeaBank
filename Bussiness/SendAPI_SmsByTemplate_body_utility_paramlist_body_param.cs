﻿using SafeControl.Base;
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
    public class SendAPI_SmsByTemplate_body_utility_paramlist_body_param : MBase
    {
        public List<SendAPI_SmsByTemplate_body_utility_paramlist_body_param_param> param { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_SmsByTemplate_body_utility_paramlist_body_param(
            List<SendAPI_SmsByTemplate_body_utility_paramlist_body_param_param> _param
        )
        {
            param = _param;
        }
    }
}
