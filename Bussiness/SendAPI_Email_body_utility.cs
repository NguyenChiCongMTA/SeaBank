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
    public class SendAPI_Email_body_utility : MBase
    {
        public SendAPI_Email_body_utility_paramlist paramlist { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_Email_body_utility(
            SendAPI_Email_body_utility_paramlist _paramlist
        )
        {
            paramlist = _paramlist;
        }
    }
}
