using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeControl.Classes
{
    public interface INotifier
    {
        RestResponse SendNotification(string message);
    }
}
