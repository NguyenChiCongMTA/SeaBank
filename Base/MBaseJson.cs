using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using SafeControl.Base;
using Newtonsoft.Json;

namespace SafeControl.Base
{
    /// <summary>
    /// Thư viện thao tác với BaseJson
    /// CreateBy: truongnm 16.03.2022
    /// </summary>
    [Serializable]
    public class MBaseJson<T> : MBase
    {
        /// <summary>
        /// Hàm SetAllFbConnectionPoolsAreCleared
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        public static string SerializesAnObjectToJSON(T obj)
        {
            //
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        /// <summary>
        /// Hàm DeserializeObject
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        public static T DeserializeObject(string sJsonData)
        {
            //
            return (T)JsonConvert.DeserializeObject<T>(sJsonData);
        }
        
    }
}
