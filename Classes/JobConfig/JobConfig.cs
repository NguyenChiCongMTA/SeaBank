using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeControl.Classes.JobConfig
{
    public class JobConfig
    {
        public EmailJobItem[] EmailJobs { get; set; }
        public SmsJobItem[] SmsJobs { get; set; }
        public int Han { get; set; }
        public string RefreshDataJob { get; set; }
    }
}
