using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using SafeControl.Base;

namespace SafeControl.Api
{
    public class WinAPI_user32 : MBase
    {
        //////////////////////////////////////////////////////////////////////////////////////////
        #region Declare
        public const int WM_SYSCOMMAND = 274;
        public const int SC_MAXIMIZE = 61488;
        //
        const int WM_GETTEXT = 0x000D;
        const int WM_GETTEXTLENGTH = 0x000E;
        //
        public const uint WS_BORDER = 0x00800000;
        public const uint WS_DLGFRAME = 0x00400000;
        public const uint WS_THICKFRAME = 0x00040000;
        public const uint WS_CAPTION = WS_BORDER | WS_DLGFRAME;
        public const uint WS_MINIMIZE = 0x20000000;
        public const uint WS_MAXIMIZE = 0x01000000;
        public const uint WS_SYSMENU = 0x00080000;
        public const uint WS_VISIBLE = 0x10000000;
        public const int GWL_STYLE = -16;
        //
        public const UInt32 WM_CLOSE = 0x0010;
        //
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [Flags]
        public enum SetWindowPosFlags: uint
        {
            SWP_ASYNCWINDOWPOS = 0x4000,
            SWP_DEFERERASE = 0x2000,
            SWP_DRAWFRAME = 0x0020,
            SWP_FRAMECHANGED = 0x0020,
            SWP_HIDEWINDOW = 0x0080,
            SWP_NOACTIVATE = 0x0010,
            SWP_NOCOPYBITS = 0x0100,
            SWP_NOMOVE = 0x0002,
            SWP_NOOWNERZORDER = 0x0200,
            SWP_NOREDRAW = 0x0008,
            SWP_NOREPOSITION = 0x0200,
            SWP_NOSENDCHANGING = 0x0400,
            SWP_NOSIZE = 0x0001,
            SWP_NOZORDER = 0x0004,
            SWP_SHOWWINDOW = 0x0040,
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////
        #region user32.dll
        /// <summary>
        /// Hàm SetParent
        /// CreateBy: truongnm 04.11.2019
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        /// <summary>
        /// Hàm MoveWindow
        /// CreateBy: truongnm 04.11.2019
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        /// <summary>
        /// Hàm ShowWindow
        /// CreateBy: truongnm 04.11.2019
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// Hàm SetWindowPos
        /// CreateBy: truongnm 04.11.2019
        /// </summary>
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cX, int cY, SetWindowPosFlags wFlags);
        /// <summary>
        /// Hàm tìm cửa sổ windowns
        /// CreateBy: truongnm 19.10.2018
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string className = null, string windowCaption = null);
        /// <summary>
        /// Hàm Minimum cửa sổ windowns
        /// CreateBy: truongnm 19.10.2018
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr CloseWindow(IntPtr hWnd);
        /// <summary>
        /// Hàm sửa tên cửa sổ windowns
        /// CreateBy: truongnm 19.10.2018
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowText(IntPtr hWnd, string windowText = null);
        /// <summary>
        /// Hàm tìm cửa sổ windowns
        /// CreateBy: truongnm 19.10.2018
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr parentWindow, IntPtr childWindow, string className = null, string windowName = null);
        /// <summary>
        /// Hàm lấy tất cả các ChildWindows
        /// CreateBy: truongnm 23.10.2018
        /// </summary>
        /// <param name="hParent"></param>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        public static List<IntPtr> GetAllChildrenWindowHandles(IntPtr hParent, int maxCount)
        {
            List<IntPtr> result = new List<IntPtr>();
            int ct = 0;
            IntPtr prevChild = IntPtr.Zero;
            IntPtr currChild = IntPtr.Zero;
            while (true && ct < maxCount)
            {
                currChild = FindWindowEx(hParent, prevChild, null, null);
                if (currChild == IntPtr.Zero) break;
                result.Add(currChild);
                prevChild = currChild;
                ++ct;
            }
            return result;
        }
        /// <summary>
        /// Hàm Show MessageBox
        /// uType: [0:6]
        ///        0:   OK
        ///        1:   OK - Cancel
        ///        2:   About - Retry - Ignore
        ///        3:   Yes - No - Cancel
        ///        4:   Yes - No
        ///        5:   Retry - Cancel
        ///        6:   Cancel - Try Again - Continue
        /// CreateBy: truongnm 19.10.2018
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int MessageBox(IntPtr hWnd, string lpText = null, string lpCaption = null, uint uType = 0);
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(int hWnd, int Msg, int wparam, int lparam);

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wparam, IntPtr lparam);

        public static string GetControlText(IntPtr hWnd)
        {
            // Get the size of the string required to hold the window title (including trailing null.) 
            Int32 titleSize = SendMessage((int)hWnd, WM_GETTEXTLENGTH, 0, 0).ToInt32();

            // If titleSize is 0, there is no title so return an empty string (or null)
            if (titleSize == 0)
                return String.Empty;

            StringBuilder title = new StringBuilder(titleSize + 1);

            SendMessage(hWnd, (int)WM_GETTEXT, title.Capacity, title);

            return title.ToString();
        }
        /// <summary>
        /// Hàm GetWindowLong
        /// CreateBy: truongnm 04.11.2019
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        /// <summary>
        /// Hàm SetWindowLong
        /// CreateBy: truongnm 04.11.2019
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        /// <summary>
        /// Hàm SetWindowLong
        /// CreateBy: truongnm 06.11.2019
        /// </summary>
        [DllImport("user32.dll", SetLastError=true)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT Rect);
        /// <summary>
        /// Hàm GetWindowThreadProcessId
        /// CreateBy: truongnm 07.11.2019
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        #region Chưa rõ chức năng
        /// <summary>
        /// Hàm gửi message | Chưa rõ chức năng
        /// CreateBy: truongnm 19.10.2018
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int message = 0, int wParam = 0, StringBuilder lParam = null);
        #endregion
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm Bỏ đi border của Window handle
        /// CreateBy: truongnm 04.11.2019
        /// </summary>
        public static void MRemoveBorder(IntPtr wHandle)
        {
            int curStyle = GetWindowLong(wHandle, GWL_STYLE);
            SetWindowLong(wHandle, GWL_STYLE, (int)(curStyle & ~WS_CAPTION));
        }
        /// <summary>
        /// Hàm đóng Window handle
        /// CreateBy: truongnm 04.11.2019
        /// </summary>
        public static void MCloseWindow(IntPtr hWnd)
        {
            SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }
        #endregion
    }
}
