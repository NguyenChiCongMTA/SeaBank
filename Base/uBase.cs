using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SafeControl.Dictionary;

namespace SafeControl.Base
{
    public partial class uBase : DevExpress.XtraEditors.XtraUserControl
    {
        public uBase()
        {
            InitializeComponent();
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            // Giao diện và dạng font
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = MGlobal.sSkinName;
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = MGlobal.fDefaultFont;
            //
            //
            // Đăng ký Event ở đây
            // CreateBy: truongnm 06.02.2021
            this.Load += this.uBase_Load;
        }
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Declare

        #endregion
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm InitForm
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public virtual void InitForm()
        {
            // Add code here:
        }
        /// <summary>
        /// Hàm InitData
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public virtual void InitData()
        {
            // Add code here:
        }
        /// <summary>
        /// Hàm LoadData
        /// CreateBy: truongnm 09.03.2022
        /// </summary>
        public virtual void LoadData()
        {
            // Add code here:
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Override

        #endregion
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        #region Event
        /// <summary>
        /// Sự kiện load form
        /// </summary>
        private void uBase_Load(object sender, EventArgs e)
        {
            InitForm();
            //
            InitData();
            //
            LoadData();
        }
        #endregion
    }
}
