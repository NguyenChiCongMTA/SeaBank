using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using SafeControl.Base;
using SafeControl.Api;

namespace SafeControl.Dictionary
{
    /// <summary>
    /// Thư viện thao tác CMD
    /// </summary>
    [Serializable]
    public class MProcess : MBase
    {
        /// <summary>
        /// Lệnh Kill Pro với tên chương trình
        /// CreateBy: truongnm: 28-06-2019
        public static void KillProcess(string sNamePro)
        {
            foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName(sNamePro))
                proc.Kill();
        }
        /// <summary>
        /// Lệnh CMD chạy không chờ
        /// /// CreateBy: truongnm: 15-01-2018
        /// </summary>
        /// <param name="sCMD"></param>
        /// <param name="sWD"></param>
        public void ExcuteCMDNoWait(string sCMD, string sWD)
        {
            ProcessStartInfo oProcessStartInfo = new ProcessStartInfo();
            oProcessStartInfo.CreateNoWindow = true;
            //
            oProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            oProcessStartInfo.FileName = "cmd";
            //
            oProcessStartInfo.Arguments = "/Q /C " + sCMD;
            oProcessStartInfo.WorkingDirectory = sWD;
            //
            Process oProcess = Process.Start(oProcessStartInfo);
        }
        /// <summary>
        /// Lệnh CMD chạy DosBox
        /// /// CreateBy: truongnm: 26-10-2018
        /// </summary>
        /// <param name="sCMD"></param>
        /// <param name="sWD"></param>
        public void ExcuteDosBox(string sCMD, string sWD)
        {
            ProcessStartInfo oProcessStartInfo = new ProcessStartInfo();
            oProcessStartInfo.CreateNoWindow = true;
            oProcessStartInfo.RedirectStandardOutput = true;
            oProcessStartInfo.UseShellExecute = false;
            oProcessStartInfo.RedirectStandardError = true;
            oProcessStartInfo.RedirectStandardError = true;
            oProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            oProcessStartInfo.FileName = "cmd";
            //
            String s = "";
            String t = "";
            //
            oProcessStartInfo.Arguments = "/Q /C " + sCMD;
            oProcessStartInfo.WorkingDirectory = sWD;
            //
            Process oProcess = Process.Start(oProcessStartInfo);
            //
            // tìm DosBox
            IntPtr pDosBox = IntPtr.Zero;
            while (pDosBox == IntPtr.Zero)
                pDosBox = WinAPI_user32.FindWindow("SDL_app", null);
            // minimums Windows
            WinAPI_user32.CloseWindow(pDosBox);
            //
            while ("exit" != sCMD)
            {
                //
                s = oProcess.StandardOutput.ReadToEnd();
                t = oProcess.StandardError.ReadToEnd();
                if (!sCMD.StartsWith("cd ") && s != null && s != "")
                    Console.WriteLine(s.Trim());
                if (t != null && t != "")
                    Console.WriteLine("Lenh sai");
                if (sCMD.StartsWith("cd ") && t == "")
                {
                    string sdir = sCMD.Split(' ')[1];
                    if (sdir == "..")
                    {
                        try
                        {
                            sWD = Directory.GetParent(sWD).FullName;
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Duong dan khong hop le");
                        }
                    }
                    else
                    {
                        if (Directory.Exists(sdir))
                        {
                            sWD = sdir;
                        }
                        else if (Directory.Exists(sWD + "\\" + sdir))
                        {
                            sWD += "\\" + sdir;
                        }
                    }
                }
                Console.WriteLine("");
                oProcess.WaitForExit();
                sCMD = "exit";
            }
            oProcess.Close();
        }
        /// <summary>
        /// Lệnh CMD chạy
        /// /// CreateBy: truongnm: 15-01-2018
        /// </summary>
        /// <param name="sCMD"></param>
        /// <param name="sWD"></param>
        public void ExcuteCMD(string sCMD, string sWD)
        {
            ProcessStartInfo oProcessStartInfo = new ProcessStartInfo();
            oProcessStartInfo.CreateNoWindow = true;
            oProcessStartInfo.RedirectStandardOutput = true;
            oProcessStartInfo.UseShellExecute = false;
            oProcessStartInfo.RedirectStandardError = true;
            oProcessStartInfo.RedirectStandardError = true;
            oProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            oProcessStartInfo.FileName = "cmd";
            //
            String s = "";
            String t = "";
            //
            oProcessStartInfo.Arguments = "/Q /C " + sCMD;
            oProcessStartInfo.WorkingDirectory = sWD;
            //
            Process oProcess = Process.Start(oProcessStartInfo);
            //
            while ("exit" != sCMD)
            {
                //
                s = oProcess.StandardOutput.ReadToEnd();
                t = oProcess.StandardError.ReadToEnd();
                if (!sCMD.StartsWith("cd ") && s != null && s != "")
                    Console.WriteLine(s.Trim());
                if (t != null && t != "")
                    Console.WriteLine("Lenh sai");
                if (sCMD.StartsWith("cd ") && t == "")
                {
                    string sdir = sCMD.Split(' ')[1];
                    if (sdir == "..")
                    {
                        try
                        {
                            sWD = Directory.GetParent(sWD).FullName;
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Duong dan khong hop le");
                        }
                    }
                    else
                    {
                        if (Directory.Exists(sdir))
                        {
                            sWD = sdir;
                        }
                        else if (Directory.Exists(sWD + "\\" + sdir))
                        {
                            sWD += "\\" + sdir;
                        }
                    }
                }
                Console.WriteLine("");
                oProcess.WaitForExit();
                sCMD = "exit";
            }
            oProcess.Close();
        }
        /// <summary>
        /// Lệnh CMD chạy
        /// CreateBy: truongnm: 28-02-2019
        /// </summary>
        /// <param name="sCMD"></param>
        /// <param name="sWD"></param>
        public string ExcuteCMD2String(string sCMD, string sWD)
        {
            ProcessStartInfo oProcessStartInfo = new ProcessStartInfo();
            oProcessStartInfo.CreateNoWindow = true;
            oProcessStartInfo.RedirectStandardOutput = true;
            oProcessStartInfo.UseShellExecute = false;
            oProcessStartInfo.RedirectStandardError = true;
            oProcessStartInfo.RedirectStandardError = true;
            oProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            oProcessStartInfo.FileName = "cmd";
            //
            String s = "";
            String t = "";
            //
            oProcessStartInfo.Arguments = "/Q /C " + sCMD;
            oProcessStartInfo.WorkingDirectory = sWD;
            //
            Process oProcess = Process.Start(oProcessStartInfo);
            //
            while ("exit" != sCMD)
            {
                //
                s = oProcess.StandardOutput.ReadToEnd();
                t = oProcess.StandardError.ReadToEnd();
                if (!sCMD.StartsWith("cd ") && s != null && s != "")
                    Console.WriteLine(s.Trim());
                if (t != null && t != "")
                    Console.WriteLine("Lenh sai");
                if (sCMD.StartsWith("cd ") && t == "")
                {
                    string sdir = sCMD.Split(' ')[1];
                    if (sdir == "..")
                    {
                        try
                        {
                            sWD = Directory.GetParent(sWD).FullName;
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Duong dan khong hop le");
                        }
                    }
                    else
                    {
                        if (Directory.Exists(sdir))
                        {
                            sWD = sdir;
                        }
                        else if (Directory.Exists(sWD + "\\" + sdir))
                        {
                            sWD += "\\" + sdir;
                        }
                    }
                }
                Console.WriteLine("");
                oProcess.WaitForExit();
                sCMD = "exit";
            }
            oProcess.Close();
            //
            if (s == null || s == "")
            {
                Console.WriteLine("Lenh sai: ");
                return "Lenh sai:\n" + t.ToString();
            }
            return s.ToString();
        }
    }
}
