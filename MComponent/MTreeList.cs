using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList;
using DevExpress.Utils.Drawing;
using DevExpress.Utils;

namespace SafeControl.MComponent
{
    public partial class MTreeList : DevExpress.XtraEditors.XtraUserControl
    {
        public MTreeList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Load UserControl
        /// CreateBy: truongnm 16.06.2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xucTreeList_Load(object sender, EventArgs e)
        {
            this.treeList1.OptionsView.ShowAutoFilterRow = true;
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            this.treeList1.OptionsFind.AllowFindPanel = false;
            this.treeList1.OptionsFind.AlwaysVisible = false;
            this.treeList1.OptionsFind.FindNullPrompt = ".. nhập giá trị vào để tìm kiếm";
            this.treeList1.OptionsView.AutoWidth = true;
            this.treeList1.OptionsBehavior.AutoPopulateColumns = false;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true; // Đổi màu
            this.treeList1.OptionsView.ShowCheckBoxes = false; // Check box
            //this.treeList1.Appearance.EvenRow.BackColor = Color.FromArgb(0xFF, 0xFF, 0x99);
            this.treeList1.IndicatorWidth = 20; // Set row header width
            this.treeList1.Nodes.Clear();
            this.treeList1.Columns.Clear();
            // Sự kiện viết stt đầu dòng
            treeList1.CustomDrawNodeIndicator += treeList1_CustomDrawNodeIndicator;
        }
        /// <summary>
        /// Add Cột vào TreeList
        /// Đây là phương thức Add có Format Cột
        /// CreateBy: truongnm 16.06.2018
        /// EditBy: truongnm 17.03.2022
        /// </summary>
        public TreeListColumn AddColumn(string FieldName = "", string Caption = "", int Width = 40, int VisibleIndex = 0,bool Visible = true, DevExpress.Utils.FormatType FormatType = DevExpress.Utils.FormatType.None,
            string FormatString = "", FixedStyle FixedStyle = FixedStyle.None,bool UseTextOptions = true, HorzAlignment HorzAlignment = HorzAlignment.Default,VertAlignment VertAlignment = VertAlignment.Center,  bool AllowSize = true, DevExpress.XtraEditors.Repository.RepositoryItem ColumnEdit = null)
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
            colAdd.AppearanceCell.Options.UseTextOptions = UseTextOptions;
            colAdd.AppearanceCell.TextOptions.HAlignment = HorzAlignment;
            colAdd.AppearanceCell.TextOptions.VAlignment = VertAlignment;
            colAdd.OptionsColumn.AllowSize = AllowSize;
            colAdd.ColumnEdit = ColumnEdit;
            this.treeList1.Columns.Add(colAdd);
            return colAdd;
        }
        /// <summary>
        /// Hàm lọc trên TreeList
        /// CreateBy: truongnm 16.06.2018
        /// </summary>
        public void SetFilter()
        {
            for (int i = 0; i < this.treeList1.Columns.Count; i++)
                this.treeList1.Columns[i].OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
        }
        /// <summary>
        /// Hàm lọc trên GridControl
        /// CreateBy: truongnm 16.06.2018
        /// </summary>
        public void SetSoft(bool bSet = true)
        {
            //
            for (int i = 0; i < this.treeList1.Columns.Count; i++)
                this.treeList1.Columns[i].OptionsColumn.AllowSort = bSet;
            //
        }
        /// <summary>
        /// Hàm treeList1_CustomDrawNodeIndicator
        /// CreateBy: truongnm 17.03.2022
        /// </summary>
        private void treeList1_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            TreeList tree = sender as DevExpress.XtraTreeList.TreeList;
            IndicatorObjectInfoArgs args = e.ObjectArgs as IndicatorObjectInfoArgs;
            args.DisplayText = (tree.GetVisibleIndexByNode(e.Node) >= 0) ? (tree.GetVisibleIndexByNode(e.Node) + 1).ToString() : "";
            args.Appearance.ForeColor = Color.Blue;
            e.ImageIndex = -1;
        }
    }
}
