using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace SafeControl.MComponent
{
    [ToolboxItem(true)]
    /// <summary>
    /// Khởi tạo Component
    /// CreateBy: truongnm 05.11.2018
    /// </summary>
    public partial class MPopupMenu : PopupMenu
    {
        public MPopupMenu()
        {
            InitializeComponent();
            //
            InitComponent();
        }

        public MPopupMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Declare
        public string sColumnName { set; get; } // Thêm cột sColumnName EditBy: truongnm 05.11.2018
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm khởi tạo
        /// CreateBy: truongnm 05.11.2018
        /// </summary>
        public void InitComponent()
        {
            
        }
        /// <summary>
        /// Hàm GetValue
        /// CreateBy: truongnm 05.11.2018
        /// </summary>
        public object GetValue()
        {
            return this.MenuCaption;
        }
        /// <summary>
        /// Hàm SetValue
        /// CreateBy: truongnm 05.11.2018
        /// </summary>
        public void SetValue(object value)
        {
            this.MenuCaption = value.ToString();
        }
        /// <summary>
        /// Hàm ReadOnly
        /// CreateBy: truongnm 07.05.2019
        /// </summary>
        public void SetReadOnly(bool value)
        {
            
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Override

        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Event

        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
    }
}
