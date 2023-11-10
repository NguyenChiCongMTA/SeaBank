using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeControl.Classes
{
    public class EmailNotifierFactory : INotifierFactory
    {
        public INotifier CreateNotifier()
        {
            return new EmailNotifier();
        }
    }
}
