using RestSharp;
using SafeControl.Base;
using SafeControl.Bussiness;
using SafeControl.Dictionary;
using SafeControl.Enum;
using SafeControl.MComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
namespace SafeControl
{
    /// <summary>
    /// Khởi tạo form 
    /// CreateBy: truongnm 25.03.2022
    /// </summary>
    public partial class f8SendAPI_SmsDialog : fBaseDialog
    {
        /// <summary>
        /// Khởi tạo form 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public f8SendAPI_SmsDialog()
        {
            InitializeComponent();
            //
            oMProcess = new MProcess();
            //
            // Đăng ký event tại đây
            // CreateBy: truongnm 25.03.2022
            //
            mcb_if8SendAPI_Sms_FileAttachDialog.SelectedIndexChanged += mcb_if8SendAPI_Sms_FileAttachDialog_SelectedIndexChanged;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Declare
        public int iOption = 0; // 1: Run
        //
        public f8SendAPI f8SendAPI { set; get; }
        //
        public string STEN { set; get; }
        public string SEMAIL { set; get; }
        public string SSDT { set; get; }
        public string IFACHID { set; get; }
        public string TENCHINHANH { set; get; }
        public DateTime dNgayPhatHanhBox { set; get; }
        public DateTime dNgayKetThucBox { set; get; }
        public string IPERSONID { set; get; }
        //
        string sTemp_sDataCURL_Result = string.Empty;
        string sTemp_BodyCurl = string.Empty;
        MProcess oMProcess = null;
        //
        PersonHistory oPersonHistory = null;
        IRestResponse response = null;
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm Command_Run
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void Command_Run()
        {
            //
            var client = new RestClient("http://10.9.70.237:8082/NOTIROUTING/rest/seab/process");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ASP.NET_SessionId=r1ytmv3cf0guaze0waoelafd");
            var body = sTemp_BodyCurl.Trim();
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            response = client.Execute(request);
        }
        /// <summary>
        /// Hàm Command_Run_Finish
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void Command_Run_Finish()
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MMessageBox.Information("Đã gửi sms thành công!");
                //
                oPersonHistory.AddPersonHistoryLog(DateTime.Now, sTenNhanVien, "Sms", string.Format("Số điện thoại: {0}\nNội dung:\n{1}", user_id.Text, content.Text));
                // Kết thúc
            }
            else
                MMessageBox.Information("Có lỗi: " + response.StatusDescription + "\n---------\n" + response.Content + "," + response.ErrorMessage);
            //
        }
        /// <summary>
        /// Hàm Command_Reset_Text
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void Command_Reset_Text() 
        {
            //
            
        }
        /// <summary>
        /// Hàm Command_GenSendAPI_Sms
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        public string Command_GenSendAPI_Sms()
        {
            string sResult = string.Empty;
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
                    , user_id.Text.Trim()
                    , "SMS"
                    , "SeABank"
                    , content.Text.Trim()
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
            sResult = MBaseJson<SendAPI_Sms>.SerializesAnObjectToJSON(oSendAPI_Sms);
            return sResult;
        }
        /// <summary>
        /// Hàm Command_GenSendAPI_Sms_1
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public string Command_GenSendAPI_Sms_1()
        {
            string sResult = string.Empty;
            // header
            SendAPI_Sms_1_header oSendAPI_Sms_1_header = new SendAPI_Sms_1_header(
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
            SendAPI_Sms_1_body oSendAPI_Sms_1_body = new SendAPI_Sms_1_body(
                "SendSms-1"
                , new SendAPI_Sms_1_body_utility(
                    new SendAPI_Sms_1_body_utility_paramlist(
                        user_id.Text.Trim()
                        , "SMS/FireBase/Zalo"
                        , "SeABank"
                        , content.Text.Trim()
                    )
                )
            );
            SendAPI_Sms_1 oSendAPI_Sms_1 = new SendAPI_Sms_1(
                oSendAPI_Sms_1_header
                , oSendAPI_Sms_1_body
            );
            sResult = MBaseJson<SendAPI_Sms_1>.SerializesAnObjectToJSON(oSendAPI_Sms_1);
            return sResult;
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Override
        /// <summary>
        /// Hàm Command_ChapNhan
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public override void Command_ChapNhan()
        {
            // Add code here:
            base.Command_ChapNhan();
            if (string.IsNullOrEmpty(content.Text)) return;
            //
            sTemp_BodyCurl = Command_GenSendAPI_Sms();
            //
            iOption = 1;
            this.RunDoWork();
        }
        /// <summary>
        /// Khởi tạo InitForm
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public override void InitForm()
        {
            // Add code here:
            base.InitForm();
            //
            mlb_TieuDe.Text = "Gửi : " + this.Text;
            //
            /// Tạo Các Enum if8SendAPI_Email_FileAttachDialog: 
            //this.mcb_if8SendAPI_Sms_FileAttachDialog.DataSource = System.Enum.GetValues(typeof(if8SendAPI_Email_FileAttachDialog));

            System.IO.DirectoryInfo directoryInfo = new DirectoryInfo($@"{Application.StartupPath}{Constants.FilePathConstant.TEMPLATE_SMS}");
            this.mcb_if8SendAPI_Sms_FileAttachDialog.DataSource = directoryInfo.GetFiles().Select(x => x.Name).ToList();

            //
        }
        /// <summary>
        /// Khởi tạo InitData
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public override void InitData()
        {
            // Add code here:
            base.InitData();
            //
            //this.mcb_if8SendAPI_Sms_FileAttachDialog.SelectedIndex = this.mcb_if8SendAPI_Sms_FileAttachDialog.Items.IndexOf(if8SendAPI_Email_FileAttachDialog.Sms_Active_HopDong);
            mtb_STEN.Text = STEN;
            user_id.Text = SSDT;
            // Load LogPerson
            // CreateBy: truongnm 25.03.2022
            oPersonHistory = new PersonHistory(IPERSONID);
            oPersonHistory = oPersonHistory.ReadPersonHistory();
        }
        /// <summary>
        /// Khởi tạo LoadData
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public override void LoadData()
        {
            // Add code here:
            base.LoadData();
        }
        /// <summary>
        /// Xử lý bất đồng bộ
        /// CreateBy: truongnm 24-05-2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Command_DoWork(object sender, DoWorkEventArgs e)
        {
            // Add code here:
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
                case 1:
                    Command_Run();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Xử lý khi chạy xong
        /// CreateBy: truongnm 24-05-2018
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
                    case 1:
                        Command_Run_Finish();
                        break;
                    default:
                        break;
                }
            }
            else if (e.Cancelled)
            {
                MMessageBox.Warning("Đã dừng");
            }
            else
            {
                MMessageBox.Error(e.Error.Message);
            }
            oStopwatch.Stop();
            mlblSumTime.Text = string.Format(@"ms: {0:#,##0}", oStopwatch.ElapsedMilliseconds);
            this.mcpMainProcess.Visible = false;
        }
        /// <summary>
        /// Xử lý báo cáo khi đang chạy
        /// CreateBy: truongnm 24-05-2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Command_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Add code here:

        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Event
        /// <summary>
        /// Sự kiện mcb_if8SendAPI_Sms_FileAttachDialog_SelectedIndexChanged
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        private void mcb_if8SendAPI_Sms_FileAttachDialog_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sMau = string.Empty;
            string sSubject = string.Empty;
            //            switch ((if8SendAPI_Email_FileAttachDialog)this.mcb_if8SendAPI_Sms_FileAttachDialog.SelectedValue)
            //            {
            //                case if8SendAPI_Email_FileAttachDialog.None:
            //                case if8SendAPI_Email_FileAttachDialog.Sms:
            //                case if8SendAPI_Email_FileAttachDialog.Email:
            //                    break;
            //                case if8SendAPI_Email_FileAttachDialog.Email_Active_HopDong:
            //                    sSubject = "Email_Active_HopDong";
            //                    sMau = string.Format(@"Thông báo phát hành hợp đồng cho thuê tủ két an toàn
            //Kính gửi quý khách : {0}.
            //Seabank xin trân trọng thông báo, Hợp đồng cho thuê tủ két an toàn số {1}. của Quý khách đã được phát hành thành công tại {2}.
            //Cảm ơn Quý khách đã tin tưởng và sử dụng dịch vụ của Seabank!
            //Nếu cần hỗ trợ thông tin hoặc tư vấn về hợp đồng, Quý khách vui lòng liên hệ Đơn vị phát hành hợp đồng hoặc gọi số hotline {3}
            //Trân trọng !
            //                    ", STEN, IFACHID, TENCHINHANH, mtb_hotline.Text);
            //                    break;
            //                case if8SendAPI_Email_FileAttachDialog.Sms_Active_HopDong:
            //                    sSubject = "Sms_Active_HopDong";
            //                    sMau = string.Format(@"Hợp đồng cho thuê tủ két an toàn số {0} của Quý Khách hàng đã được phát hành ngày {1:dd/MM/yyyy} Trân trọng cảm ơn Qúy Khách đã sử dụng dịch vụ của SeAbank!", IFACHID, dNgayPhatHanhBox);
            //                    break;
            //                case if8SendAPI_Email_FileAttachDialog.Sms_DenHan:
            //                    sSubject = "Sms_DenHan";
            //                    sMau = string.Format(@"Thời hạn thuê tủ két theo Hợp đồng cho thuê tủ két an toàn số {0} của Quý Khách hàng sẽ kết thúc vào ngày {1:dd/MM/yyyy}. Kính mời Qúy Khách đến Seabank hoặc liên hệ số hotline {2} để được hỗ trợ. Trân trọng!", IFACHID, dNgayKetThucBox, mtb_hotline.Text);
            //                    break;
            //            }
           
            string smsFile = mcb_if8SendAPI_Sms_FileAttachDialog.SelectedValue.ToString();
            System.IO.DirectoryInfo directoryInfo = new DirectoryInfo($@"{Application.StartupPath}{Constants.FilePathConstant.TEMPLATE_SMS}");
            var fullPath = directoryInfo.GetFiles()?.FirstOrDefault(x => x.Name == smsFile)?.FullName;
            sMau = File.ReadAllText(fullPath);
            //if(smsFile.Contains("Active"))
            //{
            //    sMau = string.Format(sMau, IFACHID, dNgayPhatHanhBox);
            //}    
            //else
            //    sMau = string.Format(sMau,IFACHID, dNgayKetThucBox, mtb_hotline.Text);

            Dictionary<string, string> replacements = new Dictionary<string, string>(){
                {"{HoTen}", STEN},
                {"{SoKet}", IFACHID},
                {"{ChiNhanh}",TENCHINHANH },
                {"{HotLine}", mtb_hotline.Text},
                {"{NgayPhatHanh}",dNgayPhatHanhBox.ToString("dd/MM/yyyy") },
                {"{NgayKetThuc}",dNgayKetThucBox.ToString("dd/MM/yyyy") },
                {"{Email}", SEMAIL}
            };

            foreach (string key in replacements.Keys)
            {
                sMau = sMau.Replace(key, replacements[key]);
            }

            content.Text = sMau != string.Empty ? sMau : content.Text;
        }
        #endregion
    }
}
