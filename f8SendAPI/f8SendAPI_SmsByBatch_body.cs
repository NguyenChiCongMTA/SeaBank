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
    public partial class f8SendAPI_SmsByBatch_body : uBase
    {
        /// <summary>
        /// Khởi tạo form 
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public f8SendAPI_SmsByBatch_body()
        {
            InitializeComponent();
            //
            // Đăng ký event tại đây
            // CreateBy: truongnm 17.03.2022
            //
            mllAdd.LinkClicked += mllAdd_LinkClicked;
            mllDel.LinkClicked += mllDel_LinkClicked;
        }
        public string sphone { set; get; }
        public string schannel { set; get; }
        public string sinfor { set; get; }
        /// <summary>
        /// Hàm mllAdd_LinkClicked
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        private void mllAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            f8SendAPI_SmsByBatch_bodyDialog f = new f8SendAPI_SmsByBatch_bodyDialog();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.CallBackUI += CallBackUI_f8SendAPI_SmsByBatch_body;
            f.f8SendAPI_SmsByBatch_body = this;
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
                    utility_paramlist_batch.BeginUpdate();
                    foreach (ListViewItem item in this.utility_paramlist_batch.SelectedItems)
                    {
                        this.utility_paramlist_batch.Items.Remove(item);
                    }
                }
                finally
                {
                    utility_paramlist_batch.EndUpdate();
                }
            }
        }
        /// <summary>
        /// Hàm CallBackUI_f8SendAPI_SmsByBatch_body
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        private void CallBackUI_f8SendAPI_SmsByBatch_body(object sender, EventArgs e)
        {
            Command_AddData2ListView();
        }
        /// <summary>
        /// Hàm Command_AddData2ListView
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_AddData2ListView()
        {
            if (sphone == "" || sphone == null || sphone == string.Empty) return;
            if (schannel == "" || schannel == null || schannel == string.Empty) return;
            if (sinfor == "" || sinfor == null || sinfor == string.Empty) return;
            //
            utility_paramlist_batch.Command_AddData2ListView(new ListViewItem(new string[] { sphone, schannel, sinfor }));
        }
    }
}
