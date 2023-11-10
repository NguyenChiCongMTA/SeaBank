using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafeControl.Utils
{
    public static class Utilities
    {
        public static string GetTenChiNhanh()
        {
            string sResult = string.Empty;
            //
            using (StreamReader sRead = new StreamReader(Application.StartupPath + Constants.FilePathConstant.DATABASE_INFO_BANK))
            {
                string StrRead = sRead.ReadToEnd().Trim();
                sRead.Close();
                if (StrRead.Trim() != "")
                {
                    string[] tempRead = StrRead.Split('\n');
                    switch (tempRead.Length)
                    {
                        case 0:
                        case 1:
                            break;
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            sResult = tempRead[1].Trim();
                            break;
                    }
                }

            }
            //
            return sResult;
        }


    }
}
