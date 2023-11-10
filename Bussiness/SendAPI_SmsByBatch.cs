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
    public class SendAPI_SmsByBatch : MBase
    {
        public SendAPI_SmsByBatch_header header { set; get; }
        public SendAPI_SmsByBatch_body body { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_SmsByBatch(SendAPI_SmsByBatch_header _header, SendAPI_SmsByBatch_body _body)
        {
            header = _header;
            body = _body;
        }
    }
}
