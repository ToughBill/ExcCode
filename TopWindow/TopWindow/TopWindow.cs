using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TopWindow
{
    class TopWindow
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        /// <summary>   

        public enum GWL
        {
            GWL_WNDPROC = -4,
            GWL_HINSTANCE = -6,
            GWL_HWNDPARENT = -8,
            GWL_STYLE = -16,
            GWL_EXSTYLE = -20,
            GWL_USERDATA = -21,
            GWL_ID = -12
        }

        private const int HWND_TOPMOST = -1;
        private const int HWND_NOTOPMOST = -2;

        private enum SetWinPosFlags
        {
            SWP_NOSIZE        =  0x0001,
            SWP_NOMOVE        =  0x0002,
            SWP_NOZORDER      =  0x0004,
            SWP_NOREDRAW      =  0x0008,
            SWP_NOACTIVATE    =  0x0010,
            SWP_FRAMECHANGED  =  0x0020,
            SWP_SHOWWINDOW    =  0x0040,
            SWP_HIDEWINDOW    =  0x0080,
            SWP_NOCOPYBITS    =  0x0100,
            SWP_NOOWNERZORDER =  0x0200,
            SWP_NOSENDCHANGING=  0x0400
        }

        public string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        
    }
}
