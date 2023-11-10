using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;

namespace SafeControl.MComponent
{
    public partial class MTreeListLookUpEdit : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// Khởi tạo Control
        /// </summary>
        public MTreeListLookUpEdit()
        {
            InitializeComponent();
        }
        // 
        public TreeList treeList = null;
        //
        /// <summary>
        /// Load Control
        /// CreateBy: truongnm 16.06.2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xucTreeListLookUpEdit_Load(object sender, EventArgs e)
        {
            this.tllue.Properties.NullText = "Chưa chọn";
            //
            treeList = this.tllue.Properties.TreeList;
            //
            treeList.OptionsView.ShowAutoFilterRow = true;
            treeList.OptionsBehavior.EnableFiltering = true;
            treeList.OptionsFind.AllowFindPanel = false;
            treeList.OptionsFind.AlwaysVisible = false;
            treeList.OptionsFind.FindNullPrompt = ".. nhập giá trị vào để tìm kiếm";
            treeList.OptionsView.AutoWidth = true;
            treeList.OptionsBehavior.AutoPopulateColumns = false;
            treeList.OptionsView.EnableAppearanceEvenRow = true; // Đổi màu
            //treeList.Appearance.EvenRow.BackColor = Color.FromArgb(0xFF, 0xFF, 0x99);
            treeList.IndicatorWidth = 20; // Set row header width
            treeList.Nodes.Clear();
            treeList.Columns.Clear();
            //
        }
        /// <summary>
        /// Add Cột vào TreeListLookUpEdit
        /// Đây là phương thức Add Cột
        /// CreateBy: truongnm 16.06.2018
        /// </summary>
        public TreeListColumn AddColumn(string FieldName = "", string Caption = "", int Width = 40, int VisibleIndex = 0, bool Visible = true, DevExpress.Utils.FormatType FormatType = DevExpress.Utils.FormatType.None,
            string FormatString = "", FixedStyle FixedStyle = FixedStyle.None, bool AllowSize = true, DevExpress.XtraEditors.Repository.RepositoryItem ColumnEdit = null)
        {
            TreeListColumn colAdd = new TreeListColumn();
            colAdd.FieldName = FieldName;
            colAdd.Caption = Caption;
            colAdd.Width = Width;
            colAdd.VisibleIndex = VisibleIndex;
            colAdd.Visible = Visible;
            colAdd.Format.FormatType = FormatType;
            colAdd.Format.FormatString = FormatString;
            colAdd.Fixed = FixedStyle;
            colAdd.OptionsColumn.AllowSize = AllowSize;
            colAdd.ColumnEdit = ColumnEdit;
            this.treeList.Columns.Add(colAdd);
            return colAdd;
        }
        /// <summary>
        /// Hàm lọc trên TreeList
        /// CreateBy: truongnm 16.06.2018
        /// </summary>
        public void SetFilter()
        {
            for (int i = 0; i < this.treeList.Columns.Count; i++)
                this.treeList.Columns[i].OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
        }
        /// <summary>
        /// Override lại sự kiện này // Chưa dùng được
        /// </summary>
        protected virtual void Command_ttlue_tllue_EditValueChanged()
        { 
            // Add code here:

        }
        /// <summary>
        /// Khi chọn giá trị cho ttlue
        /// CreateBy: truongnm 16.06.2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tllue_EditValueChanged(object sender, EventArgs e)
        {
            Command_ttlue_tllue_EditValueChanged();
        }
    }
}
