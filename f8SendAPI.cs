using SafeControl.Bussiness;
using SafeControl.Dictionary;
using SafeControl.Enum;
using SafeControl.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using DevExpress.Utils.Drawing;
using DevExpress.XtraTreeList;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using System.Reflection;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using RestSharp;
using DevExpress.XtraGrid.Views.Grid;

namespace SafeControl
{
    /// <summary>
    /// Khởi tạo form 
    /// CreateBy: truongnm 09.03.2022
    /// </summary>
    public partial class f8SendAPI : fBaseProcess
    {
        /// <summary>
        /// Khởi tạo form 
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public f8SendAPI()
        {
            InitializeComponent();
            //
            oMProcess = new MProcess();
            dTableData = new DataTable();
            connect = new Base.Connect();
            //
            // Đăng ký sự kiện ở đây
            // CreateBy: truongnm 10.03.2022
            mll_Run_cURL.LinkClicked += mll_Run_cURL_LinkClicked;
            mll_OptionSelectThreadRun.LinkClicked += mll_OptionSelectThreadRun_LinkClicked;
            mtcEmailSmsData.SelectedIndexChanged += mTabControl_SelectedIndexChanged;
            mtcSendSMS.SelectedIndexChanged += mTabControl_SelectedIndexChanged;
            mcb_iDaySelect.SelectedIndexChanged += mcb_iDaySelect_SelectedIndexChanged;
            mnudTrongVong.ValueChanged += mnudTrongVong_ValueChanged;
            mgcData.gridView1.RowCellStyle += gridView1_RowCellStyle;
        } 
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Declare
        public f1MainMenu formMainMenu { set; get; }
        private iOption_f8SendAPI iOption;
        private MProcess oMProcess = null;

        //
        string sTemp_sDataCURL = string.Empty;
        string sTemp_sDataCURL_Result = string.Empty;
        DataTable dTableData = null;
        Base.Connect connect = null;
        //
        PersonHistory oPersonHistory = null;
        //
        #endregion
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// gridView1_RowCellStyle
        /// CreateBy: truongnm 06.04.2022
        /// </summary>
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            //
            if (view == null) return;
            //
            if (mdeDenNgay.EditValue == null || mdeDenNgay.EditValue.ToString() == "") { return; }
            //
            if (e.RowHandle != view.FocusedRowHandle && e.RowHandle >= 0)
            {
                //
                bool _markEmail = Command_CheckPersonHistory(view.GetRowCellValue(e.RowHandle, "IPERSONID").ToString(), iPersonHistoryLogType.Email);
                //
                bool _markSms = Command_CheckPersonHistory(view.GetRowCellValue(e.RowHandle, "IPERSONID").ToString(), iPersonHistoryLogType.Sms);
                //
                if (_markEmail && _markSms) // Đã gửi cả 02
                {
                    e.Appearance.BackColor = mpDaGuiCa2.BackColor;
                }
                else if (!_markEmail && _markSms) // Đã gửi Sms
                {
                    e.Appearance.BackColor = mpDaGuiSms.BackColor;
                }
                else if (_markEmail && !_markSms) // Đã gửi Email
                {
                    e.Appearance.BackColor = mpDaGuiEmail.BackColor;
                }
                else if (!_markEmail && !_markSms) // Chưa gửi
                {
                    //e.Appearance.BackColor = Color.Black;
                }
            }
            //
        }
        /// <summary>
        /// Hàm Command_CheckPersonHistory
        /// CreateBy: truongnm 26.03.2022
        /// </summary>
        public bool Command_CheckPersonHistory(string personid, iPersonHistoryLogType iPersonHistoryLogType) 
        {
            bool bResult = false;
            //
            // Lấy ngày đến hạn chọn trừ đi (nhân với -1) số ngày trong vòng
            DateTime dCaculator = (mdeDenNgay.EditValue == null || mdeDenNgay.EditValue.ToString() == "") ?
                DateTime.Now :
                MDateTime.CongTruThemNgay(
                    (DateTime)mdeDenNgay.EditValue
                    , -1 * Convert.ToInt32(mnudTrongVong.Value)
                );
            //
            oPersonHistory = new PersonHistory(personid);
            oPersonHistory = oPersonHistory.ReadPersonHistory();
            bResult = oPersonHistory.CheckLogFromDate(dCaculator, (DateTime)mdeDenNgay.EditValue, iPersonHistoryLogType);
            //
            return bResult;
        }
        /// <summary>
        /// Hàm Command_Run
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_Run()
        {
            this.CancelDoWork();
            //
            iOption = (iOption_f8SendAPI)this.mcb_iOption_f8SendAPI.SelectedValue;
            this.RunDoWork();
        }
        /// <summary>
        /// Hàm Command_GenSendAPI_Email
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        public void Command_TimKiem()
        {
            string sSql = @"
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
where 1 = 1
and kundfach.personid = person.id
and kundfach.fachid = fach.id
and fach.vermietungsdatum is not null
and fach.laufzeit is not null
and kundfach.loeschdatum is null
and fach.mandat_id is not null
and fach.mandat_id != ''
and
(
    ('{0}'='')
    OR
    ('{1}'='')
    OR
    (
        (fach.laufzeit >= cast('{0:yyyy-MM-dd}' as date))
        AND
        (fach.laufzeit <= cast('{1:yyyy-MM-dd}' as date))
    )
)
";
            // Lấy ngày đến hạn chọn trừ đi (nhân với -1) số ngày trong vòng
            DateTime dCaculator = (mdeDenNgay.EditValue == null || mdeDenNgay.EditValue.ToString() == "") ? 
                DateTime.Now :
                MDateTime.CongTruThemNgay(
                    (DateTime)mdeDenNgay.EditValue
                    , -1 * Convert.ToInt32(mnudTrongVong.Value)
                );
            //
            sSql = string.Format(sSql, dCaculator, mdeDenNgay.EditValue);
            connect.InitSqlConnection();
            dTableData = connect.GetSqlDataSet(sSql).Tables[0];
        }
        /// <summary>
        /// Hàm Command_GenSendAPI_Email
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        public void Command_TimKiemFinish()
        {
            //
            this.mgcData.gridControl1.DataSource = dTableData;
            this.mgcData.SetFilter();
            //
            //MMessageBox.Information("Đã tìm xong!");
        }
        /// <summary>
        /// Hàm Command_GenSendAPI_Email
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        public void Command_TabSelect()
        {
            if (mtcEmailSmsData.SelectedTab == tabPageEmailData)
            {
                this.mcbSelectEmailOrSms.SelectedIndex = this.mcbSelectEmailOrSms.Items.IndexOf(iSelectEmailOrSms.SendEmail);
            }
            else
            {
                if (mtcSendSMS.SelectedTab == tabPageSendSms)
                    this.mcbSelectEmailOrSms.SelectedIndex = this.mcbSelectEmailOrSms.Items.IndexOf(iSelectEmailOrSms.SendSms);
                else if (mtcSendSMS.SelectedTab == tabPageSendSms_1)
                    this.mcbSelectEmailOrSms.SelectedIndex = this.mcbSelectEmailOrSms.Items.IndexOf(iSelectEmailOrSms.SendSms_1);
                else if (mtcSendSMS.SelectedTab == tabPageSendSmsByBatch)
                    this.mcbSelectEmailOrSms.SelectedIndex = this.mcbSelectEmailOrSms.Items.IndexOf(iSelectEmailOrSms.SendSmsByBatch);
                else if (mtcSendSMS.SelectedTab == tabPageSendSmsByTemplate)
                    this.mcbSelectEmailOrSms.SelectedIndex = this.mcbSelectEmailOrSms.Items.IndexOf(iSelectEmailOrSms.SendSmsByTemplate);
                else if (mtcSendSMS.SelectedTab == tabPageSendSmsToFirebase)
                    this.mcbSelectEmailOrSms.SelectedIndex = this.mcbSelectEmailOrSms.Items.IndexOf(iSelectEmailOrSms.SendSmsToFirebase);
            }
        }
        /// <summary>
        /// Hàm Command_GenSendAPI_Email
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        public void Command_GenSendAPI_Email()
        {
            // header
            SendAPI_Email_header oSendAPI_Email_header = new SendAPI_Email_header(
                f8SendAPI_Email.header.reqType.Text.Trim()
                , f8SendAPI_Email.header.api.Text.Trim()
                , f8SendAPI_Email.header.apiKey.Text.Trim()
                , Convert.ToInt32(f8SendAPI_Email.header.priority.Text.Trim())
                , f8SendAPI_Email.header.channel.Text.Trim()
                , f8SendAPI_Email.header.subChannel.Text.Trim()
                , f8SendAPI_Email.header.location.Text.Trim()
                , f8SendAPI_Email.header.context.Text.Trim()
                , Convert.ToBoolean(f8SendAPI_Email.header.trusted.Text.Trim())
                , f8SendAPI_Email.header.requestAPI.Text.Trim()
                , f8SendAPI_Email.header.requestNode.Text.Trim()
                , f8SendAPI_Email.header.userID.Text.Trim()
                );
            // security
            SendAPI_Email_security oSendAPI_Email_security = new SendAPI_Email_security(
                f8SendAPI_Email.security.sign.Text.Trim()
                , f8SendAPI_Email.security.sender.Text.Trim()
                , f8SendAPI_Email.security.code.Text.Trim()
                );
            // body
            // lấy file_attachment từ listview
            List<SendAPI_Email_body_utility_paramlist_file_attachment_file> lfile_attachment = new List<SendAPI_Email_body_utility_paramlist_file_attachment_file>();
            for (int i = 0; i < f8SendAPI_Email.body.file.Items.Count; i++)
                lfile_attachment.Add(
                    new SendAPI_Email_body_utility_paramlist_file_attachment_file(
                        f8SendAPI_Email.body.file.Items[i].SubItems[0].Text
                        , f8SendAPI_Email.body.file.Items[i].SubItems[1].Text
                    )
                );
            //
            SendAPI_Email_body oSendAPI_Email_body = new SendAPI_Email_body(
                f8SendAPI_Email.body.command.Text.Trim()
                , new SendAPI_Email_body_utility(
                    new SendAPI_Email_body_utility_paramlist(
                        f8SendAPI_Email.body.utility_paramlist_from_add.Text.Trim()
                        , f8SendAPI_Email.body.utility_paramlist_to_add.Text.Trim()
                        , f8SendAPI_Email.body.utility_paramlist_subject.Text.Trim()
                        , Convert.ToBoolean(f8SendAPI_Email.body.utility_paramlist_is_html_body.Text.Trim())
                        , false
                        , f8SendAPI_Email.body.utility_paramlist_mail_priority.Text.Trim()
                        , new SendAPI_Email_body_utility_paramlist_file_attachment(
                            lfile_attachment
                        )
                        , f8SendAPI_Email.body.utility_paramlist_bodym.Text.Trim()
                    )  
                  )
                );
            SendAPI_Email oSendAPI_Email = new SendAPI_Email(
                oSendAPI_Email_header
                , oSendAPI_Email_body
                , oSendAPI_Email_security
            );
            mrContext.Text += "\n--------------\nKết quả SendAPI_Email chuyển sang Json:\n" 
                + MBaseJson<SendAPI_Email>.SerializesAnObjectToJSON(oSendAPI_Email);
        }
        /// <summary>
        /// Hàm Command_GenSendAPI_Sms
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        public void Command_GenSendAPI_Sms()
        {
            // header
            SendAPI_Sms_header oSendAPI_Sms_header = new SendAPI_Sms_header(
                f8SendAPI_Sms.header.reqType.Text.Trim()
                , f8SendAPI_Sms.header.api.Text.Trim()
                , f8SendAPI_Sms.header.apiKey.Text.Trim()
                , f8SendAPI_Sms.header.channel.Text.Trim()
                , f8SendAPI_Sms.header.subChannel.Text.Trim()
                , f8SendAPI_Sms.header.location.Text.Trim()
                , f8SendAPI_Sms.header.context.Text.Trim()
                , Convert.ToBoolean(f8SendAPI_Sms.header.trusted.Text.Trim())
                , f8SendAPI_Sms.header.requestAPI.Text.Trim()
                , f8SendAPI_Sms.header.requestNode.Text.Trim()
                , Convert.ToInt32(f8SendAPI_Sms.header.duration.Text.Trim())
                , Convert.ToInt32(f8SendAPI_Sms.header.priority.Text.Trim())
                , f8SendAPI_Sms.header.userID.Text.Trim()
                , Convert.ToBoolean(f8SendAPI_Sms.header.synasyn.Text.Trim())
                );
            // body
            SendAPI_Sms_body oSendAPI_Sms_body = new SendAPI_Sms_body(
                f8SendAPI_Sms.body.command.Text.Trim()
                , new SendAPI_Sms_body_utility(
                    f8SendAPI_Sms.body.utility_key.Text.Trim()
                    , f8SendAPI_Sms.body.utility_user_id.Text.Trim()
                    , f8SendAPI_Sms.body.utility_channel.Text.Trim()
                    , f8SendAPI_Sms.body.utility_service_id.Text.Trim()
                    , f8SendAPI_Sms.body.utility_content.Text.Trim()
                    , f8SendAPI_Sms.body.utility_co_code.Text.Trim()
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
            mrContext.Text += "\n--------------\nKết quả SendAPI_Sms chuyển sang Json:\n"
                + MBaseJson<SendAPI_Sms>.SerializesAnObjectToJSON(oSendAPI_Sms);
        }
        /// <summary>
        /// Hàm Command_GenSendAPI_Sms_1
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_GenSendAPI_Sms_1()
        {
            // header
            SendAPI_Sms_1_header oSendAPI_Sms_1_header = new SendAPI_Sms_1_header(
                f8SendAPI_Sms_1.header.reqType.Text.Trim()
                , f8SendAPI_Sms_1.header.api.Text.Trim()
                , f8SendAPI_Sms_1.header.apiKey.Text.Trim()
                , f8SendAPI_Sms_1.header.channel.Text.Trim()
                , f8SendAPI_Sms_1.header.subChannel.Text.Trim()
                , f8SendAPI_Sms_1.header.location.Text.Trim()
                , f8SendAPI_Sms_1.header.context.Text.Trim()
                , Convert.ToBoolean(f8SendAPI_Sms_1.header.trusted.Text.Trim())
                , f8SendAPI_Sms_1.header.requestAPI.Text.Trim()
                , f8SendAPI_Sms_1.header.requestNode.Text.Trim()
                , Convert.ToInt32(f8SendAPI_Sms_1.header.duration.Text.Trim())
                , Convert.ToInt32(f8SendAPI_Sms_1.header.priority.Text.Trim())
                , f8SendAPI_Sms_1.header.userID.Text.Trim()
                , Convert.ToBoolean(f8SendAPI_Sms_1.header.synasyn.Text.Trim())
                );
            // body
            SendAPI_Sms_1_body oSendAPI_Sms_1_body = new SendAPI_Sms_1_body(
                f8SendAPI_Sms_1.body.command.Text.Trim()
                , new SendAPI_Sms_1_body_utility(
                    new SendAPI_Sms_1_body_utility_paramlist(
                        f8SendAPI_Sms_1.body.utility_paramlist_user_id.Text.Trim()
                        ,f8SendAPI_Sms_1.body.utility_paramlist_channel.Text.Trim()
                        , f8SendAPI_Sms_1.body.utility_paramlist_service_id.Text.Trim()
                        , f8SendAPI_Sms_1.body.utility_paramlist_infor.Text.Trim()
                    )
                )
            );
            SendAPI_Sms_1 oSendAPI_Sms_1 = new SendAPI_Sms_1(
                oSendAPI_Sms_1_header
                , oSendAPI_Sms_1_body
            );
            mrContext.Text += "\n--------------\nKết quả SendAPI_Sms_1 chuyển sang Json:\n"
                + MBaseJson<SendAPI_Sms_1>.SerializesAnObjectToJSON(oSendAPI_Sms_1);
        }
        /// <summary>
        /// Hàm Command_GenSendAPI_SmsByTemplate
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_GenSendAPI_SmsByTemplate()
        {
            // header
            SendAPI_SmsByTemplate_header oSendAPI_SmsByTemplate_header = new SendAPI_SmsByTemplate_header(
                f8SendAPI_SmsByTemplate.header.reqType.Text.Trim()
                , f8SendAPI_SmsByTemplate.header.api.Text.Trim()
                , f8SendAPI_SmsByTemplate.header.apiKey.Text.Trim()
                , f8SendAPI_SmsByTemplate.header.channel.Text.Trim()
                , f8SendAPI_SmsByTemplate.header.subChannel.Text.Trim()
                , f8SendAPI_SmsByTemplate.header.location.Text.Trim()
                , f8SendAPI_SmsByTemplate.header.context.Text.Trim()
                , Convert.ToBoolean(f8SendAPI_SmsByTemplate.header.trusted.Text.Trim())
                , f8SendAPI_SmsByTemplate.header.requestAPI.Text.Trim()
                , f8SendAPI_SmsByTemplate.header.requestNode.Text.Trim()
                , Convert.ToInt32(f8SendAPI_SmsByTemplate.header.duration.Text.Trim())
                , Convert.ToInt32(f8SendAPI_SmsByTemplate.header.priority.Text.Trim())
                , f8SendAPI_SmsByTemplate.header.userID.Text.Trim()
                , Convert.ToBoolean(f8SendAPI_SmsByTemplate.header.synasyn.Text.Trim())
                );
            // body
            // lấy param từ listview
            List<SendAPI_SmsByTemplate_body_utility_paramlist_body_param_param> lparam = new List<SendAPI_SmsByTemplate_body_utility_paramlist_body_param_param>();
            for (int i = 0; i < f8SendAPI_SmsByTemplate.body.utility_paramlist_body_param_param.Items.Count; i++)
                lparam.Add(
                    new SendAPI_SmsByTemplate_body_utility_paramlist_body_param_param(
                        f8SendAPI_SmsByTemplate.body.utility_paramlist_body_param_param.Items[i].SubItems[0].Text
                        , f8SendAPI_SmsByTemplate.body.utility_paramlist_body_param_param.Items[i].SubItems[1].Text
                    )
                );
            //
            SendAPI_SmsByTemplate_body oSendAPI_SmsByTemplate_body = new SendAPI_SmsByTemplate_body(
                f8SendAPI_SmsByTemplate.body.command.Text.Trim()
                , new SendAPI_SmsByTemplate_body_utility(
                    new SendAPI_SmsByTemplate_body_utility_paramlist(
                        f8SendAPI_SmsByTemplate.body.utility_paramlist_user_id.Text.Trim()
                        , f8SendAPI_SmsByTemplate.body.utility_paramlist_service_id.Text.Trim()
                        , f8SendAPI_SmsByTemplate.body.utility_paramlist_id_temp.Text.Trim()
                        , f8SendAPI_SmsByTemplate.body.utility_paramlist_channel.Text.Trim()
                        , f8SendAPI_SmsByTemplate.body.utility_paramlist_co_code.Text.Trim()
                        , new SendAPI_SmsByTemplate_body_utility_paramlist_body_param(
                            lparam
                        )
                    )
                )
            );
            SendAPI_SmsByTemplate oSendAPI_SmsByTemplate = new SendAPI_SmsByTemplate(
                oSendAPI_SmsByTemplate_header
                , oSendAPI_SmsByTemplate_body
            );
            mrContext.Text += "\n--------------\nKết quả SendAPI_SmsByTemplate chuyển sang Json:\n"
                + MBaseJson<SendAPI_SmsByTemplate>.SerializesAnObjectToJSON(oSendAPI_SmsByTemplate);
        }
        /// <summary>
        /// Hàm Command_GenSendAPI_SmsByBatch
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_GenSendAPI_SmsByBatch()
        {
            // header
            SendAPI_SmsByBatch_header oSendAPI_SmsByBatch_header = new SendAPI_SmsByBatch_header(
                f8SendAPI_SmsByBatch.header.reqType.Text.Trim()
                , f8SendAPI_SmsByBatch.header.api.Text.Trim()
                , f8SendAPI_SmsByBatch.header.apiKey.Text.Trim()
                , f8SendAPI_SmsByBatch.header.channel.Text.Trim()
                , f8SendAPI_SmsByBatch.header.subChannel.Text.Trim()
                , f8SendAPI_SmsByBatch.header.location.Text.Trim()
                , f8SendAPI_SmsByBatch.header.context.Text.Trim()
                , Convert.ToBoolean(f8SendAPI_SmsByBatch.header.trusted.Text.Trim())
                , f8SendAPI_SmsByBatch.header.requestAPI.Text.Trim()
                , f8SendAPI_SmsByBatch.header.requestNode.Text.Trim()
                , Convert.ToInt32(f8SendAPI_SmsByBatch.header.duration.Text.Trim())
                , Convert.ToInt32(f8SendAPI_SmsByBatch.header.priority.Text.Trim())
                , f8SendAPI_SmsByBatch.header.userID.Text.Trim()
                , Convert.ToBoolean(f8SendAPI_SmsByBatch.header.synasyn.Text.Trim())
                );
            // body
            // lấy param từ listview
            List<SendAPI_SmsByBatch_body_utility_paramlist_batch> lbatch = new List<SendAPI_SmsByBatch_body_utility_paramlist_batch>();
            for (int i = 0; i < f8SendAPI_SmsByBatch.body.utility_paramlist_batch.Items.Count; i++)
                lbatch.Add(
                    new SendAPI_SmsByBatch_body_utility_paramlist_batch(
                        f8SendAPI_SmsByBatch.body.utility_paramlist_batch.Items[i].SubItems[0].Text
                        , f8SendAPI_SmsByBatch.body.utility_paramlist_batch.Items[i].SubItems[1].Text
                        , f8SendAPI_SmsByBatch.body.utility_paramlist_batch.Items[i].SubItems[2].Text
                    )
                );
            //
            SendAPI_SmsByBatch_body oSendAPI_SmsByBatch_body = new SendAPI_SmsByBatch_body(
                f8SendAPI_SmsByBatch.body.command.Text.Trim()
                , new SendAPI_SmsByBatch_body_utility(
                    new SendAPI_SmsByBatch_body_utility_paramlist(
                        lbatch
                    )
                )
            );
            SendAPI_SmsByBatch oSendAPI_SmsByBatch = new SendAPI_SmsByBatch(
                oSendAPI_SmsByBatch_header
                , oSendAPI_SmsByBatch_body
            );
            mrContext.Text += "\n--------------\nKết quả SendAPI_SmsByBatch chuyển sang Json:\n"
                + MBaseJson<SendAPI_SmsByBatch>.SerializesAnObjectToJSON(oSendAPI_SmsByBatch);
        }
        /// <summary>
        /// Hàm Command_GenSendAPI_SmsToFirebase
        /// CreateBy: truongnm 18.03.2022
        /// </summary>
        public void Command_GenSendAPI_SmsToFirebase()
        {
            // header
            SendAPI_SmsToFirebase_header oSendAPI_SmsToFirebase_header = new SendAPI_SmsToFirebase_header(
                f8SendAPI_SmsToFirebase.header.reqType.Text.Trim()
                , f8SendAPI_SmsToFirebase.header.api.Text.Trim()
                , f8SendAPI_SmsToFirebase.header.apiKey.Text.Trim()
                , f8SendAPI_SmsToFirebase.header.channel.Text.Trim()
                , f8SendAPI_SmsToFirebase.header.subChannel.Text.Trim()
                , f8SendAPI_SmsToFirebase.header.location.Text.Trim()
                , f8SendAPI_SmsToFirebase.header.context.Text.Trim()
                , Convert.ToBoolean(f8SendAPI_SmsToFirebase.header.trusted.Text.Trim())
                , f8SendAPI_SmsToFirebase.header.requestAPI.Text.Trim()
                , f8SendAPI_SmsToFirebase.header.requestNode.Text.Trim()
                , Convert.ToInt32(f8SendAPI_SmsToFirebase.header.duration.Text.Trim())
                , Convert.ToInt32(f8SendAPI_SmsToFirebase.header.priority.Text.Trim())
                , f8SendAPI_SmsToFirebase.header.userID.Text.Trim()
                , Convert.ToBoolean(f8SendAPI_SmsToFirebase.header.synasyn.Text.Trim())
                );
            // body
            SendAPI_SmsToFirebase_body oSendAPI_SmsToFirebase_body = new SendAPI_SmsToFirebase_body(
                f8SendAPI_SmsToFirebase.body.command.Text.Trim()
                , new SendAPI_SmsToFirebase_body_utility(
                    f8SendAPI_SmsToFirebase.body.utility_key.Text.Trim()
                    , f8SendAPI_SmsToFirebase.body.utility_user_id.Text.Trim()
                    , f8SendAPI_SmsToFirebase.body.utility_channel.Text.Trim()
                    , f8SendAPI_SmsToFirebase.body.utility_service_id.Text.Trim()
                    , f8SendAPI_SmsToFirebase.body.utility_content.Text.Trim()
                    , f8SendAPI_SmsToFirebase.body.utility_co_code.Text.Trim()
                )
                );
            SendAPI_SmsToFirebase oSendAPI_SmsToFirebase = new SendAPI_SmsToFirebase(
                oSendAPI_SmsToFirebase_header
                , oSendAPI_SmsToFirebase_body
            );
            mrContext.Text += "\n--------------\nKết quả SendAPI_SmsToFirebase chuyển sang Json:\n"
                + MBaseJson<SendAPI_SmsToFirebase>.SerializesAnObjectToJSON(oSendAPI_SmsToFirebase);
        }
        /// <summary>
        /// Hàm mcb_iOption_f8SendAPI_AutoSelectFrom_iOption
        /// CreateBy: truongnm 10.03.2022
        /// </summary>
        public void mcb_iOption_f8SendAPI_AutoSelectFrom_iOption()
        {
            this.mcb_iOption_f8SendAPI.SelectedIndex = this.mcb_iOption_f8SendAPI.Items.IndexOf(iOption);
        }
        /// <summary>
        /// Hàm Command_RunCURL
        /// CreateBy: truongnm 10.03.2022
        /// </summary>
        public void Command_RunCURL()
        {
            sTemp_sDataCURL_Result = string.Empty;
            sTemp_sDataCURL_Result = oMProcess.ExcuteCMD2String(sTemp_sDataCURL, Application.StartupPath + "/curl-7.82.0-win32-mingw/bin");
        }
        /// <summary>
        /// Hàm Command_RunCURL_FINISH
        /// CreateBy: truongnm 10.03.2022
        /// </summary>
        public void Command_RunCURL_FINISH()
        {
            StringBuilder sbOut = new StringBuilder();
            sbOut.AppendLine(string.Format("\n------------\nKết quả chạy cURL: [{0:yyyy/MM/dd HH:mm:ss}]", DateTime.Now));
            sbOut.AppendLine(sTemp_sDataCURL_Result);
            //
            mrContext.Text += sbOut.ToString();
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Override
        /// <summary>
        /// Hàm InitForm
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public override void InitForm()
        {
            base.InitForm();
            //
            /// Tạo Các Enum iSelectEmailOrSms: 
            this.mcbSelectEmailOrSms.DataSource = System.Enum.GetValues(typeof(iSelectEmailOrSms));
            //
            /// Tạo Các Enum iOption_f8SendAPI: 
            this.mcb_iOption_f8SendAPI.DataSource = System.Enum.GetValues(typeof(iOption_f8SendAPI));
            //
            /// Tạo Các Enum iOption_f8SendAPI: 
            this.mcb_iDaySelect.DataSource = System.Enum.GetValues(typeof(iDaySelect));
            //
            mnudTrongVong.Maximum = 99999;
            //
            int indexCol = 0;
            ///////////////////////////////////////////////////////////////////////
            // Khởi tạo mgcData
            ///////////////////////////////////////////////////////////////////////
            //
            this.mgcData.gridView1.Columns.Clear();
            this.mgcData.gridView1.OptionsView.ColumnAutoWidth = false;
            this.mgcData.AddColumn(FieldName: "SHOPDONGID", Caption: "Mã HĐ", Width: 120, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Near, AllowEdit: false);
            this.mgcData.AddColumn(FieldName: "IPERSONID", Caption: "Mã KH", Width: 80, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Center, AllowEdit: false, Visible: false);
            this.mgcData.AddColumn(FieldName: "SMAKH", Caption: "Mã KH", Width: 80, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Center, AllowEdit: false);
            this.mgcData.AddColumn(FieldName: "STEN", Caption: "Tên KH", Width: 200, VisibleIndex: indexCol++, AllowEdit: false); // VORNAME + NAME
            this.mgcData.AddColumn(FieldName: "SEMAIL", Caption: "Email", Width: 200, VisibleIndex: indexCol++, AllowEdit: false); // 
            this.mgcData.AddColumn(FieldName: "SSDT", Caption: "Phone", Width: 80, VisibleIndex: indexCol++, FormatType: FormatType.Custom, FormatString: "[<=999999][$-,100]###-###;[$-,100](##) ###-###", AllowEdit: false); // 
            this.mgcData.AddColumn(FieldName: "IFACHID", Caption: "Số Box", Width: 60, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Center, AllowEdit: false);
            this.mgcData.AddColumn(FieldName: "DNGAYMO", Caption: "Ngày mở", Width: 100, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Far, AllowEdit: false); // vermietungsdatum
            this.mgcData.AddColumn(FieldName: "DNGAYHETHAN", Caption: "Ngày đến hạn", Width: 100, VisibleIndex: indexCol++, HorzAlignment: HorzAlignment.Far, AllowEdit: false);// laufzeit
            ////////////////////////////////////////////////////////////////////
            // Cột tiếp theo là button SendEmail
            RepositoryItemButtonEdit btnSendMail = new RepositoryItemButtonEdit();
            btnSendMail.AutoHeight = true;
            btnSendMail.Name = "btnSendMail";
            btnSendMail.LookAndFeel.UseDefaultLookAndFeel = true;
            btnSendMail.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //
            EditorButton editButton = new EditorButton(
                DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
                , "Email", -1, true, true, false
                , DevExpress.Utils.HorzAlignment.Near
                , SafeControl.Properties.Resources.Mail_icon
            );
            btnSendMail.Buttons.Clear();
            btnSendMail.Buttons.Add(editButton);
            //
            this.mgcData.AddColumn(FieldName: "EMAIL", Caption: "#", Width: 70, VisibleIndex: indexCol++, ColumnEdit: btnSendMail, FixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            // Event btnSendMail_ButtonClick
            btnSendMail.ButtonClick += btnSendMail_ButtonClick;
            ////////////////////////////////////////////////////////////////////
            // Cột tiếp theo là button SendSms
            RepositoryItemButtonEdit btnSendSms = new RepositoryItemButtonEdit();
            btnSendSms.AutoHeight = true;
            btnSendSms.Name = "btnSendSms";
            btnSendSms.LookAndFeel.UseDefaultLookAndFeel = true;
            btnSendSms.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //
            editButton = new EditorButton(
                DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
                , "Sms", -1, true, true, false
                , DevExpress.Utils.HorzAlignment.Near
                , SafeControl.Properties.Resources.SMS_bubble_icon
            );
            btnSendSms.Buttons.Clear();
            btnSendSms.Buttons.Add(editButton);
            //
            this.mgcData.AddColumn(FieldName: "SMS", Caption: "#", Width: 70, VisibleIndex: indexCol++, ColumnEdit: btnSendSms, FixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            // Event btnSendSms_ButtonClick
            btnSendSms.ButtonClick += btnSendSms_ButtonClick;
            ////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////
            // Cột tiếp theo là button History
            RepositoryItemButtonEdit btnHistory = new RepositoryItemButtonEdit();
            btnHistory.AutoHeight = true;
            btnHistory.Name = "btnHistory";
            btnHistory.LookAndFeel.UseDefaultLookAndFeel = true;
            btnHistory.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //
            editButton = new EditorButton(
                DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
                , "History", -1, true, true, false
                , DevExpress.Utils.HorzAlignment.Near
                , SafeControl.Properties.Resources.search_mini
            );
            btnHistory.Buttons.Clear();
            btnHistory.Buttons.Add(editButton);
            //
            this.mgcData.AddColumn(FieldName: "#", Caption: "#", Width: 70, VisibleIndex: indexCol++, ColumnEdit: btnHistory, FixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            // Event btnHistory_ButtonClick
            btnHistory.ButtonClick += btnHistory_ButtonClick;
            ////////////////////////////////////////////////////////////////////
            //
            this.mgcData.SetFilter();
            ///////////////////////////////////////////////////////////////////////
        }
        /// <summary>
        /// Sự kiện btnSendMail_ButtonClick
        /// CreateBy: truongnm 19.03.2022
        private void btnSendMail_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Command_btnSendMail_ButtonClick();
        }
        /// <summary>
        /// Sự kiện btnSendSms_ButtonClick
        /// CreateBy: truongnm 19.03.2022
        private void btnSendSms_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Command_btnSendSms_ButtonClick();
        }
        /// <summary>
        /// Sự kiện btnHistory_ButtonClick
        /// CreateBy: truongnm 25.03.2022
        private void btnHistory_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Command_btnHistory_ButtonClick();
        }
        /// <summary>
        /// Hàm Command_btnSendMail_ButtonClick
        /// CreateBy: truongnm 19.03.2022
        /// </summary>
        private void Command_btnSendMail_ButtonClick()
        {
            if (mdeDenNgay.EditValue == null || mdeDenNgay.EditValue.ToString() == "") { MMessageBox.Error("Phải nhập đến ngày"); return; }
            //
            if (Command_CheckPersonHistory(mgcData.gridView1.GetFocusedDataRow()["IPERSONID"].ToString(), iPersonHistoryLogType.Email))
            {
                if (DialogResult.No == MMessageBox.Question("Hệ thống đã ghi nhận gửi Email cho khách hàng này, bạn có muốn tiếp tục gửi tiếp không?"))
                {
                    return;
                }
            }
            //
            f8SendAPI_EmailDialog f = new f8SendAPI_EmailDialog();
            f.STEN = mgcData.gridView1.GetFocusedDataRow()["STEN"].ToString();
            f.SEMAIL = mgcData.gridView1.GetFocusedDataRow()["SEMAIL"].ToString();
            f.SSDT = mgcData.gridView1.GetFocusedDataRow()["SSDT"].ToString();
            f.IFACHID = mgcData.gridView1.GetFocusedDataRow()["IFACHID"].ToString();
            f.TENCHINHANH = Utils.Utilities.GetTenChiNhanh();
            DateTime dNgayPhatHanhBox = new DateTime(); DateTime dNgayKetThucBox = new DateTime();
            this.GetNgayPhatHanhVaKetThucBox(f.IFACHID, ref dNgayPhatHanhBox, ref dNgayKetThucBox);
            f.dNgayPhatHanhBox = dNgayPhatHanhBox;
            f.dNgayKetThucBox = dNgayKetThucBox;
            f.IPERSONID = mgcData.gridView1.GetFocusedDataRow()["IPERSONID"].ToString();
            f.sTenNhanVien = sTenNhanVien;
            f.ShowDialog();
        }
        /// <summary>
        /// Hàm Command_btnSendSms_ButtonClick
        /// CreateBy: truongnm 19.03.2022
        /// </summary>
        private void Command_btnSendSms_ButtonClick()
        {
            if (mdeDenNgay.EditValue == null || mdeDenNgay.EditValue.ToString() == "") { MMessageBox.Error("Phải nhập đến ngày"); return; }
            //
            if (Command_CheckPersonHistory(mgcData.gridView1.GetFocusedDataRow()["IPERSONID"].ToString(), iPersonHistoryLogType.Sms))
            {
                if (DialogResult.No == MMessageBox.Question("Hệ thống đã ghi nhận gửi Sms cho khách hàng này, bạn có muốn tiếp tục gửi tiếp không?"))
                {
                    return;
                }
            }
            //
            f8SendAPI_SmsDialog f = new f8SendAPI_SmsDialog();
            f.STEN = mgcData.gridView1.GetFocusedDataRow()["STEN"].ToString();
            f.SEMAIL = mgcData.gridView1.GetFocusedDataRow()["SEMAIL"].ToString();
            f.SSDT = mgcData.gridView1.GetFocusedDataRow()["SSDT"].ToString();
            f.IFACHID = mgcData.gridView1.GetFocusedDataRow()["IFACHID"].ToString();
            f.TENCHINHANH = Utils.Utilities.GetTenChiNhanh();
            DateTime dNgayPhatHanhBox = new DateTime(); DateTime dNgayKetThucBox = new DateTime();
            this.GetNgayPhatHanhVaKetThucBox(f.IFACHID, ref dNgayPhatHanhBox, ref dNgayKetThucBox);
            f.dNgayPhatHanhBox = dNgayPhatHanhBox;
            f.dNgayKetThucBox = dNgayKetThucBox;
            f.IPERSONID = mgcData.gridView1.GetFocusedDataRow()["IPERSONID"].ToString();
            f.sTenNhanVien = sTenNhanVien;
            f.ShowDialog();
        }
        /// <summary>
        /// Hàm Command_btnHistory_ButtonClick
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        private void Command_btnHistory_ButtonClick()
        {
            //
            f8SendAPI_HistoryDialog f = new f8SendAPI_HistoryDialog();
            f.IPERSONID = mgcData.gridView1.GetFocusedDataRow()["IPERSONID"].ToString();
            f.sTenNhanVien = sTenNhanVien;
            f.ShowDialog();
        }
        /// <summary>
        /// Hàm InitData
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public override void InitData()
        {
            base.InitData();
            //
            this.mcbSelectEmailOrSms.SelectedIndex = this.mcbSelectEmailOrSms.Items.IndexOf(iSelectEmailOrSms.SendEmail);
            //
            this.mcb_iOption_f8SendAPI.SelectedIndex = this.mcb_iOption_f8SendAPI.Items.IndexOf(iOption_f8SendAPI.None);
            //
            this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N14);
            //
            mdeDenNgay.EditValue = DateTime.Now;
        }
        /// <summary>
        /// Hàm LoadData
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public override void LoadData()
        {
            base.LoadData();
            //
            
        }
        /// <summary>
        /// Sự kiện khi hoàn thành
        /// CreateBy: truongnm 25.09.2019
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Command_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Add code here:
            if (!e.Cancelled && e.Error == null)//Check if the worker has been cancelled or if an error occured
            {
                switch (iOption)
                {
                    case iOption_f8SendAPI.None:
                        break;
                    case iOption_f8SendAPI.LoadData:
                        Command_TimKiem();
                        break;
                    case iOption_f8SendAPI.Email:
                        break;
                    case iOption_f8SendAPI.SendEmail:
                        break;
                    case iOption_f8SendAPI.Sms:
                        break;
                    case iOption_f8SendAPI.SendSms:
                        break;
                    case iOption_f8SendAPI.SendSms_1:
                        break;
                    case iOption_f8SendAPI.SendSmsByTemplate:
                        break;
                    case iOption_f8SendAPI.SendSmsByBatch:
                        break;
                    case iOption_f8SendAPI.SendSmsToFirebase:
                        break;
                    case iOption_f8SendAPI.RunCUrl:
                        Command_RunCURL_FINISH();
                        break;
                    default:
                        break;
                }
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Đã dừng");
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
            oStopwatch.Stop();
            mlblSumTime.Text = string.Format(@"ms: {0:#,##0}", oStopwatch.ElapsedMilliseconds);
            this.mcpMainProcess.Visible = false;
        }
        /// <summary>
        /// Xử lý bất đồng bộ
        /// CreateBy: truongnm 25.09.2019
        /// </summary>
        protected override void Command_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;// Capture the BackgroundWorker that fired the event
            object[] arrObjects = (object[])e.Argument;// Collect the array of objects the we recived from the main thread
            //
            if (sendingWorker.CancellationPending)// At each iteration of the loop, check if there is a cancellation request pending 
            {
                e.Cancel = true;// If a cancellation request is pending,assgine this flag a value of true
                return;
            }
            //
            oStopwatch.Reset();
            oStopwatch.Start();
            this.mcpMainProcess.Invoke((Action)(() => this.mcpMainProcess.Visible = true));
            this.mlblSumTime.Invoke((Action)(() => this.mlblSumTime.Visible = true));
            //
            switch (iOption)
            {
                case iOption_f8SendAPI.None:
                    break;
                case iOption_f8SendAPI.LoadData:
                    Command_TimKiemFinish();
                    break;
                case iOption_f8SendAPI.Email:
                    break;
                case iOption_f8SendAPI.SendEmail:
                    break;
                case iOption_f8SendAPI.Sms:
                    break;
                case iOption_f8SendAPI.SendSms:
                    break;
                case iOption_f8SendAPI.SendSms_1:
                    break;
                case iOption_f8SendAPI.SendSmsByTemplate:
                    break;
                case iOption_f8SendAPI.SendSmsByBatch:
                    break;
                case iOption_f8SendAPI.SendSmsToFirebase:
                    break;
                case iOption_f8SendAPI.RunCUrl:
                    Command_RunCURL();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Xử lý báo cáo khi đang chạy
        /// CreateBy: truongnm 24-05-2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Command_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        /// <summary>
        /// Hàm xử lý các event bấm bàn phím trên Form
        /// CreateBy: truongnm 04.04.2018
        /// </summary>
        protected override bool ProcessCmdKey(ref Message oMessage, Keys oKeys)
        {
            switch (oKeys)
            {
                case (Keys.F3):
                case (Keys.Enter):
                    Command_TimKiem();
                    Command_TimKiemFinish();
                    break;
                case (Keys.F1):
                    break;
                case (Keys.F2):
                    break;
                case (Keys.F4):
                    break;
                case (Keys.F6):
                    break;
            }
            return base.ProcessCmdKey(ref oMessage, oKeys);
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Event
        /// <summary>
        /// Sự kiện mcbSelectEmailOrSms_SelectedIndexChanged
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        private void mcbSelectEmailOrSms_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MMessageBox.Information(MEnumExtention.MGetValueStringFromEnum(((iSelectEmailOrSms)this.mcbSelectEmailOrSms.SelectedValue)));
            switch ((iSelectEmailOrSms)this.mcbSelectEmailOrSms.SelectedValue)
            {
                case iSelectEmailOrSms.SendEmail:
                    mtcEmailSmsData.SelectedTab = tabPageEmailData;
                    break;
                case iSelectEmailOrSms.SendSms:
                    mtcEmailSmsData.SelectedTab = tabPageSmsData;
                    mtcSendSMS.SelectedTab = tabPageSendSms;
                    break;
                case iSelectEmailOrSms.SendSms_1:
                    mtcEmailSmsData.SelectedTab = tabPageSmsData;
                    mtcSendSMS.SelectedTab = tabPageSendSms_1;
                    break;
                case iSelectEmailOrSms.SendSmsByTemplate:
                    mtcEmailSmsData.SelectedTab = tabPageSmsData;
                    mtcSendSMS.SelectedTab = tabPageSendSmsByTemplate;
                    break;
                case iSelectEmailOrSms.SendSmsByBatch:
                    mtcEmailSmsData.SelectedTab = tabPageSmsData;
                    mtcSendSMS.SelectedTab = tabPageSendSmsByBatch;
                    break;
                case iSelectEmailOrSms.SendSmsToFirebase:
                    mtcEmailSmsData.SelectedTab = tabPageSmsData;
                    mtcSendSMS.SelectedTab = tabPageSendSmsToFirebase;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Sự kiện mcb_iDaySelect_SelectedIndexChanged
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        private void mcb_iDaySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            mnudTrongVong.Value = (iDaySelect)this.mcb_iDaySelect.SelectedValue != iDaySelect.NN ?
                Convert.ToInt32(((iDaySelect)this.mcb_iDaySelect.SelectedValue)) : mnudTrongVong.Value;
        }
        /// <summary>
        /// Sự kiện mnudTrongVong_ValueChanged
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        private void mnudTrongVong_ValueChanged(object sender, EventArgs e)
        {
            switch ((int)mnudTrongVong.Value)
            {
                case (int)iDaySelect.N1:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N1);
                    break;
                case (int)iDaySelect.N2:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N2);
                    break;
                case (int)iDaySelect.N3:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N3);
                    break;
                case (int)iDaySelect.N5:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N5);
                    break;
                case (int)iDaySelect.N7:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N7);
                    break;
                case (int)iDaySelect.N14:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N14);
                    break;
                case (int)iDaySelect.N30:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N30);
                    break;
                case (int)iDaySelect.N45:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N45);
                    break;
                case (int)iDaySelect.N60:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N60);
                    break;
                case (int)iDaySelect.NHY:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.NHY);
                    break;
                case (int)iDaySelect.N1Y:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N1Y);
                    break;
                case (int)iDaySelect.N1HY:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N1HY);
                    break;
                case (int)iDaySelect.N2Y:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N2Y);
                    break;
                case (int)iDaySelect.N3Y:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N3Y);
                    break;
                case (int)iDaySelect.N5Y:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N5Y);
                    break;
                case (int)iDaySelect.N10Y:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N10Y);
                    break;
                case (int)iDaySelect.N20Y:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N20Y);
                    break;
                case (int)iDaySelect.N30Y:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N30Y);
                    break;
                case (int)iDaySelect.N50Y:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.N50Y);
                    break;
                default:
                    this.mcb_iDaySelect.SelectedIndex = this.mcb_iDaySelect.Items.IndexOf(iDaySelect.NN);
                    break;
            }
        }
        
        /// <summary>
        /// Sự kiện mll_Run_cURL_LinkClicked
        /// CreateBy: truongnm 10.03.2022
        /// </summary>
        private void mll_Run_cURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            iOption = iOption_f8SendAPI.RunCUrl;
            //
            sTemp_sDataCURL_Result = string.Empty;
            sTemp_sDataCURL = mrContext.SelectedText.Trim();
            //
            // Đang tạm comment lại chỗ này
            // EditBy: truongnm 26.03.2022
            //
            //sTemp_sDataCURL = MString.MRemoveCharSpecial2(sTemp_sDataCURL, 4);
            //
            mcb_iOption_f8SendAPI_AutoSelectFrom_iOption();
            //
            Command_Run();
        }
        /// <summary>
        /// Sự kiện mll_OptionSelectThreadRun_LinkClicked
        /// CreateBy: truongnm 10.03.2022
        /// </summary>
        private void mll_OptionSelectThreadRun_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Command_Run();
        }
        #endregion
        /// <summary>
        /// Sự kiện mllGenJsonData_LinkClicked
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        private void mllGenJsonData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch ((iSelectEmailOrSms)this.mcbSelectEmailOrSms.SelectedValue)
            {
                case iSelectEmailOrSms.SendEmail:
                    Command_GenSendAPI_Email();
                    break;
                case iSelectEmailOrSms.SendSms:
                    Command_GenSendAPI_Sms();
                    break;
                case iSelectEmailOrSms.SendSms_1:
                    Command_GenSendAPI_Sms_1();
                    break;
                case iSelectEmailOrSms.SendSmsByTemplate:
                    Command_GenSendAPI_SmsByTemplate();
                    break;
                case iSelectEmailOrSms.SendSmsByBatch:
                    Command_GenSendAPI_SmsByBatch();
                    break;
                case iSelectEmailOrSms.SendSmsToFirebase:
                    Command_GenSendAPI_SmsToFirebase();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Sự kiện mTabControl_SelectedIndexChanged
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        private void mTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Command_TabSelect();
        }
        /// <summary>
        /// Sự kiện mTabControl_SelectedIndexChanged
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        private void mbtnTim_Click(object sender, EventArgs e)
        {
            //
            Command_TimKiem();
            Command_TimKiemFinish();
        }
        /// <summary>
        /// Sự kiện mbtnIn_Click
        /// CreateBy: truongnm 18.03.2022
        /// </summary>
        private void mbtnIn_Click(object sender, EventArgs e)
        {
            f8SendAPI_ReportDialog f8SendAPI_ReportDialog = new f8SendAPI_ReportDialog();
            f8SendAPI_ReportDialog.iTrongVongNNgayToi = Convert.ToInt32(mnudTrongVong.Value);
            f8SendAPI_ReportDialog.BangHopDongKetSatDenHan = dTableData;
            f8SendAPI_ReportDialog.sPathDotFile = Application.StartupPath + @"\template\5_Bao_cao_hop_dong_ket_sap_het_han.dot";
            f8SendAPI_ReportDialog.sTitleWord = "BÁO CÁO HỢP ĐỒNG KÉT SẮP HẾT HẠN";
            f8SendAPI_ReportDialog.sDenNgay = string.Format("{0:dd/MM/yyyy}", mdeDenNgay.EditValue);
            f8SendAPI_ReportDialog.sNguoiLapBieu = sTenNhanVien;
            f8SendAPI_ReportDialog.sKiemSoat = "Nguyễn Kiểm Soát";
            f8SendAPI_ReportDialog.sTenNganHang = Utils.Utilities.GetTenChiNhanh();
            f8SendAPI_ReportDialog.sChiNhanh = this.GetMaChiNhanh();
            f8SendAPI_ReportDialog.StartPosition = FormStartPosition.CenterScreen;
            f8SendAPI_ReportDialog.ShowDialog();
        }

        private void mLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var client = new RestClient("http://10.9.60.176:1105/ApiFrame.svc/api/json");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ASP.NET_SessionId=r1ytmv3cf0guaze0waoelafd");
            var body = mrContext.SelectedText.Trim();
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            MMessageBox.Information(response.Content);
        }

        private void mLinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var client = new RestClient("http://10.9.70.237:8082/NOTIROUTING/rest/seab/process");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ASP.NET_SessionId=r1ytmv3cf0guaze0waoelafd");
            var body = mrContext.SelectedText.Trim();
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            MMessageBox.Information(response.Content);
        }
    }
}
