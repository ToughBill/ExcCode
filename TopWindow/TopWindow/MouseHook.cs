using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopWindow
{
    public delegate void MouseClickDele(MouseEventArgs e);
    public class MouseHook
    {
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_MBUTTONUP = 0x208;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_MBUTTONDBLCLK = 0x209;

        
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hWnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        public const int WH_MOUSE_LL = 14; // mouse hook constant  
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        private delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        private static HookProc _mouseHookProcedure;
        private static int _hMouseHook = 0;
        private static MouseClickDele _mouseClickCB;
        private static bool _firstClick = true;

        public static void SetMouseClickCallBack(MouseClickDele cb)
        {
            _mouseClickCB = cb;
        }
        public static void Start()
        {
            if (_hMouseHook == 0)
            {
                _mouseHookProcedure = new HookProc(MouseHookProc);
                //_hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, _mouseHookProcedure, Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                _hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, _mouseHookProcedure, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
                if (_hMouseHook == 0)
                {
                    Stop();
                    throw new Exception("SetWindowsHookEx failed.");
                }
            }
        }
        
        public static void Stop()
        {
            bool retMouse = true;

            if (_hMouseHook != 0)
            {
                retMouse = UnhookWindowsHookEx(_hMouseHook);
                _hMouseHook = 0;
            }
            
            if (!(retMouse))
                throw new Exception("UnhookWindowsHookEx failed.");
        }
 
        private static int MouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            MouseButtons button = MouseButtons.None;
            //int clickCount = 1;
            //switch (wParam)
            //{
            //    case WM_LBUTTONDOWN:
            //        button = MouseButtons.Left;
            //        clickCount = 1;
            //        break;
            //    case WM_LBUTTONUP:
            //        button = MouseButtons.Left;
            //        clickCount = 1;
            //        break;
            //    case WM_LBUTTONDBLCLK:
            //        button = MouseButtons.Left;
            //        clickCount = 2;
            //        break;
            //    case WM_RBUTTONDOWN:
            //        button = MouseButtons.Right;
            //        clickCount = 1;
            //        break;
            //    case WM_RBUTTONUP:
            //        button = MouseButtons.Right;
            //        clickCount = 1;
            //        break;
            //    case WM_RBUTTONDBLCLK:
            //        button = MouseButtons.Right;
            //        clickCount = 2;
            //        break;
            //    default:
            //        break;
            //}

            if(wParam == WM_LBUTTONDOWN || wParam == WM_RBUTTONDOWN)
            {
                if (_mouseClickCB != null)
                {
                    button = (wParam == WM_LBUTTONDOWN) ? MouseButtons.Left : MouseButtons.Right;
                    MouseHookStruct MyMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                    MouseEventArgs e = new MouseEventArgs(button, 1, MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y, 0);
                    _mouseClickCB(e);
                }
                _firstClick = false;
            }
            
            int ret = CallNextHookEx(_hMouseHook, nCode, wParam, lParam);
            return ret;
        }
    }
}
