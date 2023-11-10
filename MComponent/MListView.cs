using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafeControl.MComponent
{
    [ToolboxItem(true)]
    /// <summary>
    /// Khởi tạo Component
    /// CreateBy: truongnm 05.11.2018
    /// </summary>
    public partial class MListView : ListView
    {
        public MListView()
        {
            InitializeComponent();
            //
            InitComponent();
        }

        public MListView(IContainer container)
        {
            container.Add(this);
            //
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
        /// Hàm load lại STT ListView
        /// CreateBy: truongnm 22.05.2019
        /// </summary>
        public void LoadSTTListView()
        {
            //
            for (int i = 0; i < this.Items.Count; i++)
                this.Items[i].SubItems[0].Text = (i + 1).ToString();
        }
        /// <summary>
        /// Hàm add item vào trong ListView có kiểm tra xem đã có chưa
        /// CreateBy: truongnm 22.05.2019
        /// </summary>
        public void Add(ListViewItem itemData, int iKey = 0)
        {
            foreach (ListViewItem item in this.Items)
                if (itemData.SubItems[iKey].Text == item.SubItems[iKey].Text) return;
            //
            this.Items.Add(itemData);
        }
        /// <summary>
        /// Hàm khởi tạo
        /// CreateBy: truongnm 05.11.2018
        /// </summary>
        public void InitComponent()
        {
            this.HideSelection = false;
        }
        /// <summary>
        /// Hàm GetValue
        /// CreateBy: truongnm 05.11.2018
        /// </summary>
        public object GetValue()
        {
            return this.Text;
        }
        /// <summary>
        /// Hàm ReadOnly
        /// CreateBy: truongnm 07.05.2019
        /// </summary>
        public void SetReadOnly(bool value)
        {
            
        }
        /// <summary>
        /// Hàm SetValue
        /// CreateBy: truongnm 05.11.2018
        /// </summary>
        public void SetValue(object value)
        {
            this.Text = value.ToString();
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Override
        
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Event
        /// <summary>
        /// Hàm Command_AddData2ListView
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        public void Command_AddData2ListView(ListViewItem oListViewItem)
        {
            this.BeginUpdate();
            if (this.FindItemWithText(oListViewItem.Text) == null)
            {
                this.Items.Add(oListViewItem);
            }
            this.EndUpdate();
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
    }
}
