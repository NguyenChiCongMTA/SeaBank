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
    public partial class f8SendAPI_SmsByTemplate_body : uBase
    {
        /// <summary>
        /// Khởi tạo form 
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public f8SendAPI_SmsByTemplate_body()
        {
            InitializeComponent();
            //
            // Đăng ký event tại đây
            // CreateBy: truongnm 17.03.2022
            //
            mllAdd.LinkClicked += mllAdd_LinkClicked;
            mllDel.LinkClicked += mllDel_LinkClicked;
        }
        public string sparam_name { set; get; }
        public string sparam_value { set; get; }
        /// <summary>
        /// Hàm mllAdd_LinkClicked
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        private void mllAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            f8SendAPI_SmsByTemplate_bodyDialog f = new f8SendAPI_SmsByTemplate_bodyDialog();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.CallBackUI += CallBackUI_f8SendAPI_SmsByTemplate_body;
            f.f8SendAPI_SmsByTemplate_body = this;
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
                    utility_paramlist_body_param_param.BeginUpdate();
                    foreach (ListViewItem item in this.utility_paramlist_body_param_param.SelectedItems)
                    {
                        this.utility_paramlist_body_param_param.Items.Remove(item);
                    }
                }
                finally
                {
                    utility_paramlist_body_param_param.EndUpdate();
                }
            }
        }
        /// <summary>
        /// Hàm CallBackUI_f8SendAPI_SmsByTemplate_body
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        private void CallBackUI_f8SendAPI_SmsByTemplate_body(object sender, EventArgs e)
        {
            Command_AddData2ListView();
        }
        /// <summary>
        /// Hàm Command_AddData2ListView
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_AddData2ListView()
        {
            if (sparam_name == "" || sparam_name == null || sparam_name == string.Empty) return;
            if (sparam_value == "" || sparam_value == null || sparam_value == string.Empty) return;
            //
            utility_paramlist_body_param_param.Command_AddData2ListView(new ListViewItem(new string[] { sparam_name, sparam_value }));
        }
    }
}
