using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace SafeControl.MComponent
{
    public partial class MUCBase : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// Khởi tạo usercontrol
        /// CreateBy: truongnm 16.08.2019
        /// </summary>
        public MUCBase()
        {
            InitializeComponent();
            //
            this.Load += LoadForm;
        }
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        #region Declare
        
        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm load form
        /// CreateBy: truongnm 16.08.2019
        /// </summary>
        public virtual void Command_LoadForm()
        {
            // Add code here:
            this.Validate();
            //
            InitForm();
            //
            InitData();
        }
        /// <summary>
        /// Hàm khởi tạo form
        /// CreateBy: truongnm 16.08.2019
        /// </summary>
        protected virtual void InitForm()
        {
            // Add code here:
        }
        /// <summary>
        /// Hàm khởi tạo dữ liệu form
        /// CreateBy: truongnm 16.08.2019
        /// </summary>
        protected virtual void InitData()
        {
            // Add code here:
        }
        /// <summary>
        /// Hàm load dữ liệu form
        /// CreateBy: truongnm 16.08.2019
        /// </summary>
        protected virtual void LoadData()
        {
            // Add code here:
        }
        /// <summary>
        /// Hàm save dữ liệu form
        /// CreateBy: truongnm 16.08.2019
        /// </summary>
        protected virtual void SaveData()
        {
            // Add code here:
        }
        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        #region Override
        /// <summary>
        /// Ẩn mask khi có lỗi xảy ra
        /// Create by: truongnm: 16.08.2019
        /// </summary>
        protected virtual void HideMask()
        {
            SplashScreenManager.CloseForm(false);
        }
        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        #region Event
        /// <summary>
        /// Sự kiện LoadForm
        /// CreateBy: truongnm 16.08.2019
        /// </summary>
        private void LoadForm(object sender, EventArgs e)
        {
            Command_LoadForm();
        }
        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
    }
}
