using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeControl.Classes
{
    public class NotificationSystem
    {
        public RestResponse NotifyUser(INotifierFactory factory, string message)
        {
            INotifier notifier = factory.CreateNotifier();

            return notifier.SendNotification(message);
        }
    }
}
