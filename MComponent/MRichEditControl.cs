using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System.Drawing;
using System.Text.RegularExpressions;

namespace SafeControl.MComponent
{
    [ToolboxItem(true)]
    /// <summary>
    /// Khởi tạo Component
    /// CreateBy: truongnm 05.11.2018
    /// </summary>
    public partial class MRichEditControl : RichEditControl
    {
        public MRichEditControl()
        {
            InitializeComponent();
            //
            InitComponent();
        }

        public MRichEditControl(IContainer container)
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
            this.Unit = DevExpress.Office.DocumentUnit.Centimeter;
            this.ActiveViewType = RichEditViewType.Simple;
            //
            InitData();
        }
        /// <summary>
        /// Hàm khởi tạo dữ liệu Component
        /// CreateBy: truongnm 29.07.2019
        /// </summary>
        public void InitData()
        {
            this.Document.DefaultCharacterProperties.FontName = "Times New Roman";
            this.Document.DefaultCharacterProperties.FontSize = 14f;
            //
            this.Document.DefaultParagraphProperties.Alignment = ParagraphAlignment.Justify;
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
        /// Hàm lấy DocumentRange từ RichEditControl
        /// CreateBy: truongnm 25.07.2019
        /// </summary>
        public DocumentRange getDocumentRange()
        {
            return this.Document.Selection;
        }
        /// <summary>
        /// Hàm lấy dữ liệu TEXT từ RichEditControl
        /// CreateBy: truongnm 25.07.2019
        /// </summary>
        public string getSelectText()
        {
            string sResult = string.Empty;
            //
            DocumentRange selection = this.Document.Selection;
            sResult = this.Document.GetText(selection);
            //
            return sResult;
        }
        /// <summary>
        /// Hàm lấy dữ liệu TEXT từ RichEditControl
        /// CreateBy: truongnm 30.07.2019
        /// </summary>
        public string getSelectTextFromDocumentRange(DocumentRange selection)
        {
            string sResult = string.Empty;
            //
            sResult = this.Document.GetText(selection);
            //
            return sResult;
        }
        /// <summary>
        /// Hàm edit định dạng dữ liệu chọn từ RichEditControl
        /// CreateBy: truongnm 25.07.2019
        /// </summary>
        public void editFormattedDocumentRange(DocumentRange selection, string sFontName = "Times New Roman", float fFontSize = 14f,
            Color? cForeColor = null, Color? cBackColor = null, UnderlineType eUnderline = UnderlineType.None, Color? cUnderlineColor = null, bool? bBold = false)
        {
            //
            CharacterProperties cp = this.Document.BeginUpdateCharacters(selection);
            cp.FontName = sFontName;
            cp.FontSize = fFontSize;
            cp.ForeColor = cForeColor;
            cp.BackColor = cBackColor;
            cp.Underline = eUnderline;
            cp.UnderlineColor = cUnderlineColor;
            cp.Bold = bBold;
            //
            this.Document.EndUpdateCharacters(cp);
        }
        /// <summary>
        /// Hàm tìm vị trí các biểu thức quan tâm
        /// CreateBy: truongnm 29.07.2019
        /// </summary>
        public List<DocumentRange> getListDocumentRangeWithReg(Regex sRegex)
        {
            List<DocumentRange> lDocumentRangeResult = new List<DocumentRange>();
            //
            ISearchResult searchResult = this.Document.StartSearch(sRegex);
            //
            while (searchResult.FindNext()) lDocumentRangeResult.Add(searchResult.CurrentResult);
            //
            return lDocumentRangeResult;
        }
        /// <summary>
        /// Hàm tìm vị trí các biểu thức quan tâm trong chuỗi đang chọn
        /// CreateBy: truongnm 30.07.2019
        /// </summary>
        public List<DocumentRange> getListDocumentRangeWithRegFromDocumentRange(DocumentRange documentRange, Regex sRegex)
        {
            List<DocumentRange> lDocumentRangeResult = new List<DocumentRange>();
            //
            ISearchResult searchResult = this.Document.StartSearch(sRegex, documentRange);
            //
            while (searchResult.FindNext()) lDocumentRangeResult.Add(searchResult.CurrentResult);
            //
            return lDocumentRangeResult;
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
    }
}
