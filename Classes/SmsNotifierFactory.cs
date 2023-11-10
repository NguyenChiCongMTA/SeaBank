using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeControl.Classes
{
    public class SmsNotifierFactory : INotifierFactory
    {
        public INotifier CreateNotifier()
        {
            return new SmsNotifier();
        }
    }
}
