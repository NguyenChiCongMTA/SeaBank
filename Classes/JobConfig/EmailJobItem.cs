using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeControl.Classes.JobConfig
{
    public class EmailJobItem
    {
        public string EmailTime { get; set; }
        public string EmailTemplate { get; set; }
        public string Subject { get; set; }
        public string HotLine { get; set; }
    }
}
