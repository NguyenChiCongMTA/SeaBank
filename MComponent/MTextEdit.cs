using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafeControl.MComponent
{
    public partial class MTextEdit : TextEdit
    {
        /// <summary>
        /// Khởi tạo MTextEdit
        /// CreateBy: truongnm 04.03.2022
        /// </summary>
        public MTextEdit()
        {
            InitializeComponent();
        }

        public MTextEdit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        //////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        #region Declare
        public string sColumnName { set; get; }
        #endregion
        //////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm InitForm()
        /// CreateBy: truongnm 04.03.2022
        /// </summary>
        public void InitForm()
        { 
            // Add code here:
        }
        /// <summary>
        /// Hàm InitData()
        /// CreateBy: truongnm 04.03.2022
        /// </summary>
        public void InitData()
        {
            // Add code here:
        }
        /// <summary>
        /// Hàm LoadData()
        /// CreateBy: truongnm 04.03.2022
        /// </summary>
        public void LoadData()
        {
            // Add code here:
        }
        #endregion
        //////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        #region Override

        #endregion
        //////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        #region Event

        #endregion

    }
}
