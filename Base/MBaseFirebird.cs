using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using SafeControl.Base;

namespace SafeControl.Base
{
    /// <summary>
    /// Thư viện thao tác với BaseFirebird
    /// CreateBy: truongnm 13.03.2022
    /// </summary>
    [Serializable]
    public class MBaseFirebird : MBase
    {
        /// <summary>
        /// Hàm SetAllFbConnectionPoolsAreCleared
        /// CreateBy: truongnm 13.03.2022
        /// </summary>
        public static void SetAllFbConnectionPoolsAreCleared()
        {
            // Check if connection pools are cleared
            // EditBy: truongnm 12.03.2022
            while (FirebirdSql.Data.FirebirdClient.FbConnection.ConnectionPoolsCount != 0)
                FirebirdSql.Data.FirebirdClient.FbConnection.ClearAllPools();
        }
    }
}
