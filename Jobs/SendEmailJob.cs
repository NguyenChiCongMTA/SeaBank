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
    public class SendEmailJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {

            string textConfig = File.ReadAllText($@"{Application.StartupPath}{Constants.FilePathConstant.JOB_CONFIG}");
            var jobConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<JobConfig>(textConfig);

            string emailFile = jobConfig.EmailJobs[0].EmailTemplate;
            System.IO.DirectoryInfo directoryInfo = new DirectoryInfo($@"{Application.StartupPath}{Constants.FilePathConstant.TEMPLATE_EMAIL}");
            var fullPath = directoryInfo.GetFiles()?.FirstOrDefault(x => x.Name.Contains(emailFile))?.FullName;
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
            connect.InitSqlConnection();
            var tbl = connect.GetSqlDataSet(sSql).Tables[0];

            if(tbl != null && tbl.Rows.Count > 0)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    SendAPI_Email_header oSendAPI_Email_header = new SendAPI_Email_header(
                    "REQUEST"
                    , "SendMail"
                    , "1s5ZidrDWYSb8al89VARtrAQ"
                    , 1
                    , "SEAMOBILE3.0"
                    , "APPADR"
                    , "10.17.14.230"
                    , "ClientVersion=2_9_7_dev_SeAMobile;OS=Android;BRAND=samsung;MODEL=SM_A515F;TYPE=user;ID=QP1A_190711_020;BOOTLOADER=A515FXXU4CUA1"
                    , true
                    , "Nextgen"
                    , "127.0.0.1"
                    , "1389024700"
                    );
                    // security
                    SendAPI_Email_security oSendAPI_Email_security = new SendAPI_Email_security(
                        "Nosign"
                        , "SERVICE"
                        , "SB2015"
                        );

                    SendAPI_Email_body oSendAPI_Email_body = new SendAPI_Email_body(
                   "SendNormalMail"
                   , new SendAPI_Email_body_utility(
                       new SendAPI_Email_body_utility_paramlist(
                           "mailservice"
                           , row["semail"].ToString()
                           , jobConfig.EmailJobs[0].Subject
                           , true
                           , false
                           , "high"
                           , new SendAPI_Email_body_utility_paramlist_file_attachment(
                               new List<SendAPI_Email_body_utility_paramlist_file_attachment_file>()
                           )
                           ,  string.Format(sMau, row["sten"].ToString(), row["ifachid"].ToString(), Utilities.GetTenChiNhanh(),jobConfig.EmailJobs[0].HotLine)  //utility_paramlist_bodym.Text.Trim()
                       )
                     )
                   );
                    SendAPI_Email oSendAPI_Email = new SendAPI_Email(
                        oSendAPI_Email_header
                        , oSendAPI_Email_body
                        , oSendAPI_Email_security
                    );
                    string message = MBaseJson<SendAPI_Email>.SerializesAnObjectToJSON(oSendAPI_Email);
                    
                    NotificationSystem notificationSystem = new NotificationSystem();
                    EmailNotifierFactory emailNotifierFactory = new EmailNotifierFactory();
                    var rs = notificationSystem.NotifyUser(emailNotifierFactory, message);



                }
            }    

        }
    }
}
