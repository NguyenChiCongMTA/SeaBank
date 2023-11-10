using SafeControl.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeControl.Bussiness
{
    /// <summary>
    /// Khởi tạo 
    /// CreateBy: truongnm 25.03.2022
    /// </summary>
    [Serializable]
    public class SendAPI_SmsByTemplate_header : MBase
    {
        public string reqType { set; get; }
        public string api { set; get; }
        public string apiKey { set; get; }
        public string channel { set; get; }
        public string subChannel { set; get; }
        public string location { set; get; }
        public string context { set; get; }
        public bool trusted { set; get; }
        public string requestAPI { set; get; }
        public string requestNode { set; get; }
        public int duration { set; get; }
        public int priority { set; get; }
        public string userID { set; get; }
        public bool synasyn { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_SmsByTemplate_header(
            string _reqType
            , string _api
            , string _apiKey
            , string _channel
            , string _subChannel
            , string _location
            , string _context
            , bool _trusted
            , string _requestAPI
            , string _requestNode
            , int _duration
            , int _priority
            , string _userID
            , bool _synasyn
        )
        {
            reqType = _reqType;
            api = _api;
            apiKey = _apiKey;
            channel = _channel;
            subChannel = _subChannel;
            location = _location;
            context = _context;
            trusted = _trusted;
            requestAPI = _requestAPI;
            requestNode = _requestNode;
            priority = _priority;
            duration = _duration;
            userID = _userID;
            synasyn = _synasyn;
        }
    }
}
