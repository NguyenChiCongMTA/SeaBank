using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;

namespace SafeControl.MComponent
{
    [ToolboxItem(true)]
    /// <summary>
    /// Khởi tạo Component
    /// CreateBy: truongnm 05.11.2018
    /// </summary>
    public partial class MNavBarControl : DevExpress.XtraNavBar.NavBarControl
    {
        public MNavBarControl()
        {
            InitializeComponent();
            //
            InitComponent();
        }
        public MNavBarControl(IContainer container)
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
            this.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            //
            this.OptionsNavPane.ShowOverflowButton = false;
            this.OptionsNavPane.ShowOverflowPanel = false;
            //this.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed; // Ẩn / Hiện NavPane - EditBy: truongnm 06.11.2018
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
