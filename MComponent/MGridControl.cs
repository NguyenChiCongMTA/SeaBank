using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using SafeControl.Dictionary;

namespace SafeControl.MComponent
{
    public partial class MGridControl : MUCBase
    {
        public MGridControl()
        {
            InitializeComponent();
            //
            // Đăng ký event ở đây
            // CreateBy: truongnm 25.03.2022
            //
            this.gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
            //this.gridView1.RowCellStyle += gridView1_RowCellStyle;
        }
        /// <summary>
        /// Load form
        /// CreateBy: truongnm 17.06.2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xucGridControl_Load(object sender, EventArgs e)
        {
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = true;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.GroupPanelText = "Kéo thả các nhóm vào đây";
            // Set Header font
            this.gridView1.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.RowAutoHeight = true; // Word Wrap
            this.gridView1.IndicatorWidth = 40; // Set row header width
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true; // Đổi màu
            //this.gridView1.Appearance.EvenRow.BackColor = Color.FromArgb(0xFF, 0xFF, 0x99);
            this.gridView1.Columns.Clear();
            //
            this.gridView1.ClearGrouping();
            //this.gridView1.Columns["sIDLinhVuc_sTen"].GroupIndex = 0; // Định nghĩa Group ở đây
            this.gridView1.BestFitColumns(true);
        }
        /// <summary>
        /// gridView1_RowCellStyle
        /// CreateBy: truongnm 06.04.2022
        /// </summary>
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.RowHandle != view.FocusedRowHandle &&
               ((e.RowHandle % 2 == 0 && e.Column.VisibleIndex % 2 == 1) ||
               (e.Column.VisibleIndex % 2 == 0 && e.RowHandle % 2 == 1)))
                e.Appearance.BackColor = Color.NavajoWhite;
        }
        /// <summary>
        /// Add Cột vào GridControl
        /// Đây là phương thức Add có Format Cột
        /// CreateBy: truongnm 16.06.2018
        /// EditBy: truongnm 19.03.2022
        /// </summary>
        public GridColumn AddColumn(string FieldName = "", string Caption = "", int Width = 50, int VisibleIndex = 0, bool Visible = true, 
            DevExpress.Utils.FormatType FormatType = DevExpress.Utils.FormatType.None, string FormatString = "", DevExpress.Utils.DefaultBoolean AllowSort = DevExpress.Utils.DefaultBoolean.Default, bool AllowEdit = true,
            DevExpress.XtraGrid.Columns.FixedStyle FixedStyle = FixedStyle.None
            , bool UseTextOptions = true, DevExpress.Utils.HorzAlignment HorzAlignment = DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment VertAlignment = DevExpress.Utils.VertAlignment.Center
            , DevExpress.XtraEditors.Repository.RepositoryItem ColumnEdit = null)
        {
            GridColumn gridColAdd = new GridColumn();
            gridColAdd.FieldName = FieldName;
            gridColAdd.Caption = Caption;
            gridColAdd.Width = Width;
            gridColAdd.VisibleIndex = VisibleIndex;
            gridColAdd.Visible = Visible;
            gridColAdd.DisplayFormat.FormatType = FormatType;
            gridColAdd.DisplayFormat.FormatString = FormatString;
            gridColAdd.OptionsColumn.AllowSort = AllowSort;
            gridColAdd.OptionsColumn.AllowEdit = AllowEdit;
            gridColAdd.AppearanceCell.Options.UseTextOptions = UseTextOptions;
            gridColAdd.AppearanceCell.TextOptions.HAlignment = HorzAlignment;
            gridColAdd.AppearanceCell.TextOptions.VAlignment = VertAlignment;
            gridColAdd.Fixed = FixedStyle;
            gridColAdd.ColumnEdit = ColumnEdit;
            this.gridView1.Columns.Add(gridColAdd);
            return gridColAdd;
        }
        /// <summary>
        /// Hàm lọc trên GridControl
        /// CreateBy: truongnm 16.06.2018
        /// </summary>
        public void SetFilter()
        {
            //
            for (int i = 0; i < this.gridView1.Columns.Count; i++)
                this.gridView1.Columns[i].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            //
        }
        /// <summary>
        /// Hàm lọc trên GridControl
        /// CreateBy: truongnm 16.06.2018
        /// </summary>
        public void SetSoft(bool bSet=true)
        {
            //
            for (int i = 0; i < this.gridView1.Columns.Count; i++)
                this.gridView1.Columns[i].OptionsColumn.AllowSort = bSet ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
            //
        }
        /// <summary>
        /// Hàm lấy dữ liệu từ gridControl
        /// CreateBy: truongnm 15.10.2018
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableInGrid()
        {
            ////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////
            // Đây là chỉ lấy những dòng hiển thị >> chưa đủ
            // EditBy: truongnm 16.10.2018
            ////////////////////////////////////////////////////////////////////////////////////////
            DataTable table = ((DataView)(this.gridView1.DataSource)).Table.Clone();
            for (int i = 0; i < this.gridView1.DataRowCount; i++)
            {
                //if (this.gridView1.IsRowVisible(i) == RowVisibleState.Visible)
                    table.ImportRow(this.gridView1.GetDataRow(i));
            }
            ////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////
            return table;
        }
        /// <summary>
        /// Hàm gridView1_CustomDrawRowIndicator - đánh số thứ tự
        /// CreateBy: truongnm 15.10.2018
        /// </summary>
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            GridView gv = (GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                e.Info.Appearance.Font = MGlobal.fDefaultFont;
                e.Info.Appearance.ForeColor = Color.Blue;
                e.Info.Appearance.Options.UseFont = true;
                e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                e.Info.ImageIndex = -2;
            }
        }
    }
}
