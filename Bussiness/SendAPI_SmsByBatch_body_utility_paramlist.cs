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
    public class SendAPI_SmsByBatch_body_utility_paramlist : MBase
    {
        public List<SendAPI_SmsByBatch_body_utility_paramlist_batch> batch { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_SmsByBatch_body_utility_paramlist(
            List<SendAPI_SmsByBatch_body_utility_paramlist_batch> _batch
        )
        {
            batch = _batch;
        }
    }
}
