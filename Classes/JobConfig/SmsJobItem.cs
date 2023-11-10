using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeControl.Classes.JobConfig
{
    public class SmsJobItem
    {
        public string SmsTime { get; set; }
        public string SmsTemplate { get; set; }
        public string HotLine { get; set; }
    }
}
