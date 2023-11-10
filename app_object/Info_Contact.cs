using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeControl.app_object
{
    public class Info_Contact
    {
        public string Name_API { get; set; }
        public string API_key { get; set; }
        public string URL { get; set; }
        public string Method { get; set; }
        public string Content_type { get; set; }
        public string Gate { get; set; }
        public string Address { get; set; }
        public Info_Contact() { }

        public Info_Contact(string _Name_API, string _API_key, string _URL, string _Method, string _Content_type, string _Gate, string _Address)
        {
            Name_API = _Name_API;
            API_key = _API_key;
            URL = _URL;
            Method = _Method;
            Content_type = _Content_type;
            Gate = _Gate;
            Address = _Address;
            
        }
    }
}
