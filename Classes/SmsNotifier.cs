using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeControl.Classes
{
    public class SmsNotifier : INotifier
    {
        public RestResponse SendNotification(string message)
        {
            //
            var client = new RestClient("http://10.9.70.237:8082/NOTIROUTING/rest/seab/process");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ASP.NET_SessionId=r1ytmv3cf0guaze0waoelafd");
            var body = message.Trim();
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            return client.Execute(request);
        }
    }
}
