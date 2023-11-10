using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SafeControl.Base;

namespace SafeControl.Dictionary
{
    [Serializable]
    public class MMessageBox : MBase
    {
        public static void Information(string sMessage = "", string sClass = "this") { MessageBox.Show(sMessage, "Thông báo [" + sClass + "]", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        public static void Error(string sMessage = "", string sClass = "this") { MessageBox.Show(sMessage, "Lỗi [" + sClass + "]", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        public static void Warning(string sMessage = "", string sClass = "this") { MessageBox.Show(sMessage, "Cảnh báo [" + sClass + "]", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        public static DialogResult Question(string sMessage = "", string sClass = "this") { return MessageBox.Show(sMessage, "Lựa chọn [" + sClass + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
    }
}
