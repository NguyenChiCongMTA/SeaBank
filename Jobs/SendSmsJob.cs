using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.XtraRichEdit.Import.Html;
using Quartz;
using SafeControl.Base;
using SafeControl.Bussiness;
using SafeControl.Classes;
using SafeControl.Classes.JobConfig;
using SafeControl.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafeControl
{
    public class SendSmsJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            
            string textConfig = File.ReadAllText($@"{Application.StartupPath}{Constants.FilePathConstant.JOB_CONFIG}");
            var jobConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<JobConfig>(textConfig);

            string smsFile = jobConfig.SmsJobs[0].SmsTemplate;
            System.IO.DirectoryInfo directoryInfo = new DirectoryInfo($@"{Application.StartupPath}{Constants.FilePathConstant.TEMPLATE_SMS}");
            var fullPath = directoryInfo.GetFiles()?.FirstOrDefault(x => x.Name.Contains(smsFile))?.FullName;
            string sMau = File.ReadAllText(fullPath);

            string sSql =
            @"
select distinct
fach.mandat_id as shopdongid,
fachid as ifachid,
personid as ipersonid,
person.stammnummer as smakh,
(person.name || ' ' || person.vorname) as sten,
person.modem as semail,
person.telefon as ssdt,
fach.vermietungsdatum as dngaymo,
fach.laufzeit as dngayhethan
from kundfach, person, fach
where 1=1
            and kundfach.personid = person.id
            and kundfach.fachid = fach.id
            and fach.vermietungsdatum is not null
            and fach.laufzeit is not null
            and kundfach.loeschdatum is null
            and fach.mandat_id is not null
            and fach.mandat_id != ''
            and
            (
                ('{0}' = '')
                OR
                ('{1}' = '')
                OR
                (
                    (fach.laufzeit >= cast('{0:yyyy-MM-dd}' as date))
                    AND
                    (fach.laufzeit <= cast('{1:yyyy-MM-dd}' as date))
                )
            )
            ";

            Base.Connect connect = new Base.Connect();

            DateTime fromDate = DateTime.Now.AddDays(-1 * jobConfig.Han);
            sSql = string.Format(sSql, fromDate, DateTime.Now);

            connect.InitSqlConnection();
            var tbl = connect.GetSqlDataSet(sSql).Tables[0];

            if(tbl != null && tbl.Rows.Count > 0)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    string smsContent = sMau;
                    DateTime dNgayPhatHanhBox = DateTime.Now;
                    DateTime dNgayKetThucBox = DateTime.Now;
                    GetNgayPhatHanhVaKetThucBox(row["ifachid"].ToString(), ref dNgayPhatHanhBox, ref dNgayKetThucBox);


                    Dictionary<string, string> replacements = new Dictionary<string, string>(){
                        {"{HoTen}", row["sten"].ToString()},
                        {"{SoKet}", row["ifachid"].ToString()},
                        {"{HotLine}", jobConfig.SmsJobs[0].HotLine},
                        {"{NgayKetThuc}",dNgayKetThucBox.ToString("dd/MM/yyyy") },
                    };

                    foreach (string key in replacements.Keys)
                    {
                        sMau = sMau.Replace(key, replacements[key]);
                    }

                    // header
                    SendAPI_Sms_header oSendAPI_Sms_header = new SendAPI_Sms_header(
                        "REQUEST"
                        , "NOTI_ROUTING_API"
                        , "qmklfoni1ezxlf2ckpygpfx12152020"
                        , "T24"
                        , "ODS"
                        , "123.24.47.24"
                        , "Mozilla/5.0(WindowsNT10.0)"
                        , false
                        , "T24"
                        , "1"
                        , 0
                        , 1
                        , "dap.dv"
                        , true
                        );
                    // body
                    SendAPI_Sms_body oSendAPI_Sms_body = new SendAPI_Sms_body(
                        "SendSms"
                        , new SendAPI_Sms_body_utility(
                            "AUTH-1-1594416001-17032022100459"
                    , row["semail"].ToString()
                            , "SMS"
                            , "SeABank"
                            , smsContent
                            , "VN0010002"
                            , 0
                            , "SeABank"
                            , "AUTH_SMS_OUT"
                            , ""
                        )
                        );
                    SendAPI_Sms oSendAPI_Sms = new SendAPI_Sms(
                    oSendAPI_Sms_header
                        , oSendAPI_Sms_body
                    );
                    var message = MBaseJson<SendAPI_Sms>.SerializesAnObjectToJSON(oSendAPI_Sms);
                    NotificationSystem notificationSystem = new NotificationSystem();
                    SmsNotifierFactory smsNotifierFactory = new SmsNotifierFactory();
                    var rs = notificationSystem.NotifyUser(smsNotifierFactory, message);
                }
            }    

        }


        public virtual void GetNgayPhatHanhVaKetThucBox(string fachid, ref DateTime dNgayPhatHanh, ref DateTime dNgayKetThuc)
        {
            
            Base.Connect connect = new Base.Connect();
            string sSql = @"
select distinct
fach.vermietungsdatum,
fach.laufzeit
from fach
where 1 = 1
and fach.id = {0}
";
            
            sSql = string.Format(sSql, fachid);
            connect.InitSqlConnection();
            DataTable dTableData = connect.GetSqlDataSet(sSql).Tables[0];
            
            if (dTableData.Rows.Count <= 0) return;

            dNgayPhatHanh = Convert.ToDateTime(dTableData.Rows[0][0]);
            dNgayKetThuc = Convert.ToDateTime(dTableData.Rows[0][1]);

        }

    }
}
