using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using SafeControl.MComponent;

namespace SafeControl
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo directoryInfo = new DirectoryInfo($@"{Application.StartupPath}{Constants.FilePathConstant.TEMPLATE_SMS}");
            var files = System.IO.Directory.GetFiles($@"{Application.StartupPath}{Constants.FilePathConstant.TEMPLATE_EMAIL}");
            this.mListBox1.DataSource = directoryInfo.GetFiles().Select(x=>x.Name).ToList();
            
            //var folders = $@"{Application.StartupPath}\Templates\Emails";
            

        }

          private void mListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ss = (MListBox)sender;
            var file = ss.SelectedValue.ToString();
            System.IO.DirectoryInfo directoryInfo = new DirectoryInfo($@"{Application.StartupPath}{Constants.FilePathConstant.TEMPLATE_EMAIL}");
            var fullPath = directoryInfo.GetFiles().FirstOrDefault(x => x.Name == file).FullName;
            string text = File.ReadAllText(fullPath);
            mTextBox1.Text = text;
        }
    }
}
