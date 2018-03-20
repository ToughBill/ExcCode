using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopWindow
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        //[DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        //private static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        [DllImport("user32.dll")]
        public static extern UInt32 RegisterHotKey(IntPtr hWnd, UInt32 id, UInt32 fsModifiers, UInt32 vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

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
            SWP_NOSIZE = 0x0001,
            SWP_NOMOVE = 0x0002,
            SWP_NOZORDER = 0x0004,
            SWP_NOREDRAW = 0x0008,
            SWP_NOACTIVATE = 0x0010,
            SWP_FRAMECHANGED = 0x0020,
            SWP_SHOWWINDOW = 0x0040,
            SWP_HIDEWINDOW = 0x0080,
            SWP_NOCOPYBITS = 0x0100,
            SWP_NOOWNERZORDER = 0x0200,
            SWP_NOSENDCHANGING = 0x0400
        }

        public enum FieldOffsets
        {
            GWL_WNDPROC = -4,
            GWL_HINSTANCE = -6,
            GWL_HWNDPARENT = -8,
            GWL_STYLE = -16,
            GWL_EXSTYLE = -20,
            GWL_USERDATA = -21,
            GWL_ID = -12
        }

        private enum ExtendedWindowStyles : long
        {
            WS_EX_DLGMODALFRAME = 0x00000001L,
            WS_EX_NOPARENTNOTIFY = 0x00000004L,
            WS_EX_TOPMOST = 0x00000008L,
            WS_EX_ACCEPTFILES = 0x00000010L,
            WS_EX_TRANSPARENT = 0x00000020L
        }

        private enum ModeControlKey : uint
        {
            MOD_ALT = 0x0001,
            MOD_CONTROL = 0x0002,
            MOD_SHIFT = 0x0004,
            MOD_WIN = 0x0008
        }

        private IntPtr m_curTopWin;
        private bool m_isShift, m_isCtrl, m_isAlt;
        private uint m_charCode;
        private int HOT_KEY_ID = 247696411;
        public Form1()
        {
            InitializeComponent();
            m_curTopWin = IntPtr.Zero;
            this.Location = new Point(SystemInformation.WorkingArea.Width - this.Width, SystemInformation.WorkingArea.Height - this.Height);
            this.TopMost = true;
        }

        private bool SetTopWindow()
        {
            IntPtr handle = GetForegroundWindow();
            if (handle == IntPtr.Zero) return false;
            if (handle == m_curTopWin)
            {
                ClearCurrentTopWin();
                return true;
            }

            SetWindowPos(m_curTopWin, HWND_NOTOPMOST, 0, 0, 0, 0, (int)SetWinPosFlags.SWP_NOMOVE | (int)SetWinPosFlags.SWP_NOSIZE);
            long dwExStyle = GetWindowLong(handle, (int)FieldOffsets.GWL_EXSTYLE);
            dwExStyle |= (long)ExtendedWindowStyles.WS_EX_TOPMOST;
            //::SetWindowLong(m_topWindHwnd, GWL_EXSTYLE, dwExStyle);
            SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, (int)SetWinPosFlags.SWP_NOMOVE | (int)SetWinPosFlags.SWP_NOSIZE);
            m_curTopWin = handle;

            const int charsLen = 512;
            StringBuilder buff = new StringBuilder(charsLen);
            if (GetWindowText(m_curTopWin, buff, charsLen) > 0)
            {
                txtWinTitle.Text = buff.ToString();
            }

            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadConfigFile();
            RegisterHostKey();
        }

        private void ReadConfigFile()
        {
            //TODO: read from file
            chkShift.Checked =  m_isShift = true;
            chkCtrl.Checked = m_isCtrl = false;
            chkAlt.Checked = m_isAlt = true;
            m_charCode = (uint)Keys.W;
            txtChar.Text = ((char)m_charCode).ToString();
            //m_charCode = 125; //}

        }

        private void RegisterHostKey()
        {
            uint flag = 0;
            if (m_isShift) flag |= (uint)ModeControlKey.MOD_SHIFT;
            if (m_isCtrl) flag |= (uint)ModeControlKey.MOD_CONTROL;
            if (m_isAlt) flag |= (uint)ModeControlKey.MOD_ALT;
            RegisterHotKey(this.Handle, (uint)HOT_KEY_ID, flag, m_charCode);
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOT_KEY_ID)
            {
                SetTopWindow();
            }
            base.WndProc(ref m);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, HOT_KEY_ID);
        }

        private void btnSetHotKey_Click(object sender, EventArgs e)
        {
            UnregisterHotKey(this.Handle, HOT_KEY_ID);
            m_isShift = chkShift.Checked;
            m_isCtrl = chkCtrl.Checked;
            m_isAlt = chkAlt.Checked;
            m_charCode = (uint)txtChar.Text.Trim()[0];

            RegisterHostKey();
            SetHotKeyControlsStatus(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetHotKeyControlsStatus(true);
        }
        private void SetHotKeyControlsStatus(bool isEdit)
        {
            if (isEdit)
            {
                chkShift.Enabled = chkCtrl.Enabled = chkAlt.Enabled = true;
                txtChar.ReadOnly = false;
            }
            else
            {
                chkShift.Enabled = chkCtrl.Enabled = chkAlt.Enabled = false;
                txtChar.ReadOnly = true;
            }
        }

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnable.Checked)
            {
                RegisterHostKey();
            }
            else
            {
                m_curTopWin = IntPtr.Zero;
                txtWinTitle.Text = string.Empty;
                UnregisterHotKey(this.Handle, HOT_KEY_ID);
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //show context menu even if left click
                //Type t = typeof(NotifyIcon);
                //MethodInfo mi = t.GetMethod("ShowContextMenu", BindingFlags.NonPublic | BindingFlags.Instance);
                //mi.Invoke(notifyIcon, null);
                this.Show();
                this.WindowState = FormWindowState.Normal;
            } 
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearCurrentTopWin();
        }
        private void ClearCurrentTopWin()
        {
            if (m_curTopWin != IntPtr.Zero)
            {
                SetWindowPos(m_curTopWin, HWND_NOTOPMOST, 0, 0, 0, 0, (int)SetWinPosFlags.SWP_NOMOVE | (int)SetWinPosFlags.SWP_NOSIZE);
                m_curTopWin = IntPtr.Zero;
                txtWinTitle.Text = string.Empty;
            }
        }

        private void tsmSelectWin_Click(object sender, EventArgs e)
        {
            MouseHook.SetMouseClickCallBack(MouseClickDele);
            MouseHook.Start();
        }

        public void MouseClickDele(MouseEventArgs e)
        {
            SetTopWindow();
            MouseHook.Stop();
        }
    }
}
