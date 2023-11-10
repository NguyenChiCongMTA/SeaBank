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
    public class SendAPI_SmsByTemplate : MBase
    {
        public SendAPI_SmsByTemplate_header header { set; get; }
        public SendAPI_SmsByTemplate_body body { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_SmsByTemplate(SendAPI_SmsByTemplate_header _header, SendAPI_SmsByTemplate_body _body)
        {
            header = _header;
            body = _body;
        }
    }
}
