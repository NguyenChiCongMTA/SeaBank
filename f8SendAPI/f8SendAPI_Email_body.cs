using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SafeControl.Base;
using SafeControl.Dictionary;

namespace SafeControl
{
    /// <summary>
    /// Khởi tạo form 
    /// CreateBy: truongnm 09.03.2022
    /// </summary>
    public partial class f8SendAPI_Email_body : uBase
    {
        /// <summary>
        /// Khởi tạo form 
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public f8SendAPI_Email_body()
        {
            InitializeComponent();
            //
            // Đăng ký event tại đây
            // CreateBy: truongnm 17.03.2022
            //
            mllAdd.LinkClicked += mllAdd_LinkClicked;
            mllDel.LinkClicked += mllDel_LinkClicked;
        }
        public string sfile_name { set; get; }
        public string sfile_byte64 { set; get; }
        /// <summary>
        /// Hàm mllAdd_LinkClicked
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        private void mllAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            f8SendAPI_Email_bodyDialog f = new f8SendAPI_Email_bodyDialog();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.CallBackUI += CallBackUI_f8SendAPI_Email_body;
            f.f8SendAPI_Email_body = this;
            f.ShowDialog();
        }
        /// <summary>
        /// Hàm mllDel_LinkClicked
        /// CreateBy: truongnm 17.03.2022
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
        /// Hàm CallBackUI_f8SendAPI_Email_body
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        private void CallBackUI_f8SendAPI_Email_body(object sender, EventArgs e)
        {
            Command_AddData2ListView();
        }
        /// <summary>
        /// Hàm Command_AddData2ListView
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_AddData2ListView()
        {
            if (sfile_name == "" || sfile_name == null || sfile_name == string.Empty) return;
            if (sfile_byte64 == "" || sfile_byte64 == null || sfile_byte64 == string.Empty) return;
            //
            file.Command_AddData2ListView(new ListViewItem(new string[] { sfile_name, sfile_byte64 }));
        }
    }
}
