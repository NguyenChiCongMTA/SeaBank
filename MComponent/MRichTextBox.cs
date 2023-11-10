using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace SafeControl.MComponent
{
    [ToolboxItem(true)]
    /// <summary>
    /// Khởi tạo Component
    /// CreateBy: truongnm 05.11.2018
    /// </summary>
    public partial class MRichTextBox : RichTextBox
    {
        public MRichTextBox()
        {
            InitializeComponent();
            //
            InitComponent();
        }

        public MRichTextBox(IContainer container)
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
        /// Hàm reset định dạng richtextbox
        /// CreateBy: truongnm 23.08.2019
        /// </summary>
        public void ResetFormat()
        {
            string sTextTemp = this.Text;
            this.ResetText();
            this.Text = sTextTemp;
        }
        /// <summary>
        /// Hàm khởi tạo
        /// CreateBy: truongnm 05.11.2018
        /// </summary>
        public void InitComponent()
        {
            this.HideSelection = false;
            this.Font = new Font("Courier New", 9.25F);
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //
            this.AcceptsTab = true;
            // Đăng ký event
            this.KeyPress += this_KeyPress;
        }
        /// <summary>
        /// Hàm ReadOnly
        /// CreateBy: truongnm 07.05.2019
        /// </summary>
        public void SetReadOnly(bool value)
        {
            this.ReadOnly = value;
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
        /// <summary>
        /// Mở file dạng Text
        /// CreateBy: truongnm 06.08.2019
        /// </summary>
        public string OpenFile(string fileName)
        {
            StringBuilder sResult = new StringBuilder();
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                sResult.Append(streamReader.ReadToEnd());
                streamReader.Close();
            }
            return sResult.ToString();
        }
        /// <summary>
        /// Lưu file dạng Text
        /// CreateBy: truongnm 06.08.2019
        /// </summary>
        public void SaveFile(string fileName, string sData)
        {
            StreamWriter write = new StreamWriter(fileName);
            write.Write(sData);
            write.Close();
        }
        /// <summary>
        /// Lưu file dạng Bin
        /// CreateBy: truongnm 06.08.2019
        /// </summary>
        public void SaveFileFromBin(string path, string data)
        {
            string[] _bdt = data.Trim().Split(' ');
            //
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    foreach (string tmp in _bdt)
                        writer.Write(byte.Parse(tmp.Trim()));
                    //
                    writer.Close();
                }
            }
        }
        /// <summary>
        /// Lưu file dạng Bin
        /// CreateBy: truongnm 06.08.2019
        /// </summary>
        public void SaveFileFromBin(string path, byte[] data)
        {
            //
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    foreach (byte tmp in data)
                        writer.Write(tmp);
                    //
                    writer.Close();
                }
            }
        }
        /// <summary>
        /// Hàm bôi màu
        /// CreateBy: truongnm 07.08.2019
        /// </summary>
        public void BrushText(int iSelectionStart, int iSelectionLength,
            Color cSelectionColor, Color cSelectionBackColor)
        {
            this.SelectionStart = iSelectionStart;
            this.SelectionLength = iSelectionLength;
            // Bôi màu
            this.SelectionColor = cSelectionColor;
            this.SelectionBackColor = cSelectionBackColor;
        }
        /// <summary>
        /// Hàm bôi màu
        /// CreateBy: truongnm 19.08.2019
        /// </summary>
        public void BrushCollum(int iIndexCollum, int iSumCollum, int iSumRow, Color cSelectionColor, Color cSelectionBackColor)
        {
            // Loại bỏ các kí tự thừa
            while (this.Text.IndexOf("\r") != -1) this.Text = this.Text.Replace("\r", "");
            while (this.Text.IndexOf("\t") != -1) this.Text = this.Text.Replace("\t", "");
            while (this.Text.IndexOf(" ") != -1) this.Text = this.Text.Replace(" ", "");
            //
            for (int i = 0; i < iSumRow; i++)
                BrushText(iIndexCollum + (i * (iSumCollum + 1)), 1, cSelectionColor, cSelectionBackColor);
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Override
        /// <summary>
        /// Hàm bắt các key từ bàn phím
        /// CreateBy: truongnm 08.08.2019
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// Hàm bắt các key từ bàn phím
        /// CreateBy: truongnm 19.08.2019
        /// </summary>
        private void this_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 9)
                e.Handled = false;
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        #region Event

        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
    }
}
