using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeControl.Base
{
    /// <summary>
    /// Thư viện thao tác với MBase
    /// CreateBy: truongnm 05.12.2019
    /// </summary>
    [Serializable]
    public class MBase
    {
        /// <summary>
        /// Hàm ToString
        /// CreateBy: truongnm 05.12.2019
        /// </summary>
        public override string ToString()
        {
            string sResult = base.ToString();
            string[] sSplitResult = sResult.Split('.');
            return sSplitResult.Length != 0 ? sSplitResult[sSplitResult.Length - 1] : sResult;
        }
    }
}
