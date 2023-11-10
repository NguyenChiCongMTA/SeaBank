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
    public class SendAPI_Email_body_utility_paramlist : MBase
    {
        public string from_add { set; get; }
        public string to_add { set; get; }
        public string subject { set; get; }
        public bool is_html_body { set; get; }
        public bool is_base64_body { set; get; }
        public string mail_priority { set; get; }
        public SendAPI_Email_body_utility_paramlist_file_attachment file_attachment { set; get; }
        public string bodym { set; get; }
        //
        /// <summary>
        /// Khởi tạo 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public SendAPI_Email_body_utility_paramlist(
            string _from_add
            , string _to_add
            , string _subject
            , bool _is_html_body
            , bool _is_base64_body
            , string _mail_priority
            , SendAPI_Email_body_utility_paramlist_file_attachment _file_attachment
            , string _bodym
        )
        {
            from_add = _from_add;
            to_add = _to_add;
            subject = _subject;
            is_html_body = _is_html_body;
            is_base64_body = _is_base64_body;
            mail_priority = _mail_priority;
            file_attachment = _file_attachment;
            bodym = _bodym;
        }
    }
}
