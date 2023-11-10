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
    public partial class f8SendAPI_EmailDialog : fBaseDialog
    {
        /// <summary>
        /// Khởi tạo form 
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public f8SendAPI_EmailDialog()
        {
            InitializeComponent();
            //
            oMProcess = new MProcess();
            //
            // Đăng ký event tại đây
            // CreateBy: truongnm 25.03.2022
            //
            mllAdd.LinkClicked += mllAdd_LinkClicked;
            mllDel.LinkClicked += mllDel_LinkClicked;
            mcb_if8SendAPI_Email_FileAttachDialog.SelectedIndexChanged += mcb_if8SendAPI_Email_FileAttachDialog_SelectedIndexChanged;
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
        PersonHistory oPersonHistory = null;
        //
        string sTemp_sDataCURL_Result = string.Empty;
        string sTemp_BodyCurl = string.Empty;
        MProcess oMProcess = null;
        IRestResponse response = null;
        //
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
            var client = new RestClient("http://10.9.60.176:1105/ApiFrame.svc/api/json");
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
                MMessageBox.Information("Đã gửi mail thành công!");
                // Ghi lại lịch sử
                oPersonHistory.AddPersonHistoryLog(DateTime.Now, sTenNhanVien, "Email", string.Format("Chủ đề: {0}\nNội dung:\n{1}", utility_paramlist_subject.Text, utility_paramlist_bodym.Text));
                //
            }
            else
                MMessageBox.Information("Có lỗi: " + response.StatusDescription + "\n---------\n" + response.Content);
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
        /// Hàm Command_GenSendAPI_Email
        /// CreateBy: truongnm 16.03.2022
        /// </summary>
        public string Command_GenSendAPI_Email()
        {
            string sResult = string.Empty;
            // header
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
            // body
            // lấy file_attachment từ listview
            List<SendAPI_Email_body_utility_paramlist_file_attachment_file> lfile_attachment = new List<SendAPI_Email_body_utility_paramlist_file_attachment_file>();
            for (int i = 0; i < file.Items.Count; i++)
                lfile_attachment.Add(
                    new SendAPI_Email_body_utility_paramlist_file_attachment_file(
                        file.Items[i].SubItems[0].Text
                        , file.Items[i].SubItems[1].Text
                    )
                );
            //
            SendAPI_Email_body oSendAPI_Email_body = new SendAPI_Email_body(
                "SendNormalMail"
                , new SendAPI_Email_body_utility(
                    new SendAPI_Email_body_utility_paramlist(
                        "mailservice"
                        , utility_paramlist_to_add.Text.Trim()
                        , utility_paramlist_subject.Text.Trim()
                        , true
                        , false
                        , "high"
                        , new SendAPI_Email_body_utility_paramlist_file_attachment(
                            lfile_attachment
                        )
                        , utility_paramlist_bodym.Text.Trim()
                    )
                  )
                );
            SendAPI_Email oSendAPI_Email = new SendAPI_Email(
                oSendAPI_Email_header
                , oSendAPI_Email_body
                , oSendAPI_Email_security
            );
            sResult = MBaseJson<SendAPI_Email>.SerializesAnObjectToJSON(oSendAPI_Email);
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
            //
            sTemp_BodyCurl = Command_GenSendAPI_Email();
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
            /// Tạo Các Enum iSelectEmailOrSms: 
            //this.mcb_if8SendAPI_Email_FileAttachDialog.DataSource = System.Enum.GetValues(typeof(if8SendAPI_Email_FileAttachDialog));
            System.IO.DirectoryInfo directoryInfo = new DirectoryInfo($@"{Application.StartupPath}{Constants.FilePathConstant.TEMPLATE_EMAIL}");
            var list = directoryInfo.GetFiles().Select(x => x.Name).ToList();
            list.Insert(0, "Chọn mẫu");
            this.mcb_if8SendAPI_Email_FileAttachDialog.DataSource = list;
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
            //this.mcb_if8SendAPI_Email_FileAttachDialog.SelectedIndex =  this.mcb_if8SendAPI_Email_FileAttachDialog.Items.IndexOf(if8SendAPI_Email_FileAttachDialog.Email_Active_HopDong);
            mtb_STEN.Text = STEN;
            utility_paramlist_to_add.Text = SEMAIL;
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
        /// Sự kiện mcb_if8SendAPI_Email_FileAttachDialog_SelectedIndexChanged
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        private void mcb_if8SendAPI_Email_FileAttachDialog_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sMau = string.Empty;
            string sSubject = string.Empty;
            //switch ((if8SendAPI_Email_FileAttachDialog)this.mcb_if8SendAPI_Email_FileAttachDialog.SelectedValue)
            //{
            //    case if8SendAPI_Email_FileAttachDialog.None:
            //    case if8SendAPI_Email_FileAttachDialog.Email:
            //    case if8SendAPI_Email_FileAttachDialog.Sms:
            //        break;
            //    case if8SendAPI_Email_FileAttachDialog.Email_Active_HopDong:
            //        sSubject = "Email_Active_HopDong";
            //        sMau = string.Format(@"Thông báo phát hành hợp đồng cho thuê tủ két an toàn
            //Kính gửi quý khách : {0}.
            //Seabank xin trân trọng thông báo, Hợp đồng cho thuê tủ két an toàn số {1}. của Quý khách đã được phát hành thành công tại {2}.
            //Cảm ơn Quý khách đã tin tưởng và sử dụng dịch vụ của Seabank!
            //Nếu cần hỗ trợ thông tin hoặc tư vấn về hợp đồng, Quý khách vui lòng liên hệ Đơn vị phát hành hợp đồng hoặc gọi số hotline {3}
            //Trân trọng !
            //                    ", STEN, IFACHID, TENCHINHANH, mtb_hotline.Text);
            //        break;
            //    case if8SendAPI_Email_FileAttachDialog.Sms_Active_HopDong:
            //        sSubject = "Sms_Active_HopDong";
            //        sMau = string.Format(@"Hợp đồng cho thuê tủ két an toàn số {0} của Quý Khách hàng đã được phát hành ngày {1:dd/MM/yyyy} Trân trọng cảm ơn Qúy Khách đã sử dụng dịch vụ của SeAbank!", IFACHID, dNgayPhatHanhBox);
            //        break;
            //    case if8SendAPI_Email_FileAttachDialog.Sms_DenHan:
            //        sSubject = "Sms_DenHan";
            //        sMau = string.Format(@"Thời hạn thuê tủ két theo Hợp đồng cho thuê tủ két an toàn số {0} của Quý Khách hàng sẽ kết thúc vào ngày {1:dd/MM/yyyy}. Kính mời Qúy Khách đến Seabank hoặc liên hệ số hotline {2} để được hỗ trợ. Trân trọng!", IFACHID, dNgayKetThucBox, mtb_hotline.Text);
            //        break;
            //}
            //var s = (MComboBox)sender;
            string emailFile = mcb_if8SendAPI_Email_FileAttachDialog.SelectedValue.ToString();
            System.IO.DirectoryInfo directoryInfo = new DirectoryInfo($"{Application.StartupPath}{Constants.FilePathConstant.TEMPLATE_EMAIL}");
            var fullPath = directoryInfo.GetFiles()?.FirstOrDefault(x => x.Name == emailFile)?.FullName;
            if (fullPath == null) {
                utility_paramlist_bodym.Text = string.Empty;
                return; 
            }
            sMau = File.ReadAllText(fullPath);
            string sql = $@"select person.ID, person.PLZ,person.STRASSE,person.ORT,person.TELEFON,legidat.NUMMER,legidat.ausstellungsdatum, legidat.ausstellungsort,fach.mandat_id,
                        fach.blz,fach.ustid
                        from person,legidat,kundfach, fach
                        where person.legidatid = legidat.id
                        and  kundfach.personid = person.id
                        and kundfach.loeschdatum is null
                        and kundfach.fachid = fach.id   
                        and person.id = {IPERSONID}";
            Base.Connect connect = new Connect();
            connect.InitSqlConnection();
            var dtable = connect.GetSqlDataSet(sql).Tables[0];

            var f = new ConvertMoney();

            Dictionary<string, string> replacements = new Dictionary<string, string>(){
                {"{HoTen}", STEN},
                {"{SoKet}", IFACHID},
                {"{ChiNhanh}",TENCHINHANH },
                {"{HotLine}", mtb_hotline.Text},
                {"{NgayPhatHanh}",dNgayPhatHanhBox.ToString("dd/MM/yyyy") },
                {"{NgayKetThuc}",dNgayKetThucBox.ToString("dd/MM/yyyy") },
                {"{Email}", SEMAIL},
                {"{DiaChi}",$"{dtable.Rows[0]["PLZ"]} {dtable.Rows[0]["STRASSE"]} {dtable.Rows[0]["ORT"]}" },
                {"{SoDienThoai}",$"{dtable.Rows[0]["TELEFON"]}" },
                {"{SoCCCD}",$"{dtable.Rows[0]["NUMMER"]}" },
                {"{NgayCapCCCD}",$"{dtable.Rows[0]["ausstellungsdatum"]}" },
                {"{NoiCapCCCD}",$"{dtable.Rows[0]["ausstellungsort"]}" },
                {"{SoHopDong}",$"{dtable.Rows[0]["mandat_id"]}" },
                {"{SoTaiKhoan}",$"{dtable.Rows[0]["blz"]}" },
                {"{MaSoDoanhNghiep}",$"{txtMaDoanhNghiep.Text}" },
                {"{CoQuanCap}",$"{txtCoQuanCap.Text}" },
                {"{NgayCap}",$"{txtNgayCapLanDau.Text}" },
                {"{LanThayDoi}",$"{txtLanThayDoi.Text}" },
                {"{NgayThayDoi}",$"{txtNgayThayDoi.Text}" },
                {"{NoiCap}",$"{txtNoiCap.Text}" },
                {"{SoFax}",$"{txtFax.Text}" },
                {"{PhiGiaHan}",$"{txtPhiGiaHan.Text}" },
                {"{PhiGiaHanBangChu}",$"{f.join_unit(txtPhiGiaHan.Text)}" },
                {"{EmailSeaBank}",$"{txtEmailSeABank.Text}" },
            };

            foreach (string key in replacements.Keys)
            {
                sMau = sMau.Replace(key, replacements[key]);
            }

            //sMau = string.Format(sMau, STEN, IFACHID, TENCHINHANH, mtb_hotline.Text);
            utility_paramlist_bodym.Text = sMau != string.Empty ? sMau : utility_paramlist_bodym.Text;
            utility_paramlist_subject.Text = sSubject != string.Empty ? sSubject : utility_paramlist_subject.Text;
        }
        public string sfile_name { set; get; }
        public string sfile_byte64 { set; get; }
        /// <summary>
        /// Hàm mllAdd_LinkClicked
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        private void mllAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            f8SendAPI_Email_FileAttachDialog f = new f8SendAPI_Email_FileAttachDialog();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.CallBackUI += CallBackUI_f8SendAPI_EmailDialog;
            f.f8SendAPI_EmailDialog = this;
            f.ShowDialog();
        }
        /// <summary>
        /// Hàm mllDel_LinkClicked
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        private void mllDel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MMessageBox.Question("Bạn muốn xóa?") == DialogResult.Yes)
            {
                try
                {
                    file.BeginUpdate();
                    foreach (ListViewItem item in this.file.SelectedItems)
                    {
                        this.file.Items.Remove(item);
                    }
                }
                finally
                {
                    file.EndUpdate();
                }
            }
        }
        /// <summary>
        /// Hàm CallBackUI_f8SendAPI_EmailDialog
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        private void CallBackUI_f8SendAPI_EmailDialog(object sender, EventArgs e)
        {
            Command_AddData2ListView();
        }
        /// <summary>
        /// Hàm Command_AddData2ListView
        /// CreateBy: truongnm 25.03.2022
        /// </summary>
        public void Command_AddData2ListView()
        {
            if (sfile_name == "" || sfile_name == null || sfile_name == string.Empty) return;
            if (sfile_byte64 == "" || sfile_byte64 == null || sfile_byte64 == string.Empty) return;
            //
            file.Command_AddData2ListView(new ListViewItem(new string[] { sfile_name, sfile_byte64 }));
        }
        #endregion
    }
}
