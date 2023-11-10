using SafeControl.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafeControl.Base
{
    public partial class fEncrypt : fBase
    {
        public fEncrypt()
        {
            InitializeComponent();
        }

        private void mbt_MaHoa_Click(object sender, EventArgs e)
        {
            string[] mac = mrtb_MAC.Text.Split('\n');
            for (int i = 0; i < mac.Length; i++)
            {
                if (mac[i].Trim() != "")
                    mrtb_encrypt.Text += (Dictionary.MEncypt.Encrypt(mac[i].Trim(), mtb_key.Text, true)+"\n");
            }
        }
        
        private void fEncrypt_Load(object sender, EventArgs e)
        {
            List<string> list_MAC = new List<string>();
            list_MAC = Dictionary.MNetworkInterface.GetMacAddress1();
            for (int i = 0; i < list_MAC.Count; i++)
                if (list_MAC[i].Trim() !="")
                    mrtb_MAC.Text += (list_MAC[i] + "\n");
            //
            mtb_key.Text = MGlobal.sKey;
        }
    }
}
