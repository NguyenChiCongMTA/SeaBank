﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SafeControl.MComponent
{
    [ToolboxItem(true)]
    /// <summary>
    /// Khởi tạo Component
    /// CreateBy: truongnm 05.11.2018
    /// </summary>
    public partial class MLabelControl : DevExpress.XtraEditors.LabelControl
    {
        public MLabelControl()
        {
            InitializeComponent();
            //
            InitComponent();
        }

        public MLabelControl(IContainer container)
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
