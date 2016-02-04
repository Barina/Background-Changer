using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Background_Changer
{
    static class Program
    {
        private const string CHANGE_BG_COMMAND = "c";

        #region Dll Imports
        private const int HWND_BROADCAST = 0xffff;
        public static readonly uint WM_MSG = RegisterWindowMessage("WM_CHANGE_BG");

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32")]
        private static extern uint RegisterWindowMessage(string message);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        #endregion Dll Imports

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //args = new string[] { "c" };
            bool createNew = true;
            Mutex mutex = new Mutex(true, "background_changer", out createNew);

            if (createNew)
            {
                if (args.Length > 0)
                {
                    foreach (var arg in args)
                    {
                        if (arg == CHANGE_BG_COMMAND)
                        {
                            WallHelper.Instance.SetNextWallpaper();
                            mutex.ReleaseMutex();
                            return;
                        }
                    }
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                mutex.ReleaseMutex();
            }
            else
            {
                Process current = Process.GetCurrentProcess();
                Process process = null;
                foreach (Process proc in Process.GetProcessesByName(current.ProcessName))
                {
                    if (proc.Id != current.Id)
                    {
                        process = proc;
                        break;
                    }
                }
                if (args.Length > 0)
                {
                    foreach (var arg in args)
                    {
                        if (arg == CHANGE_BG_COMMAND)
                        {
                            if (process != null)
                                SendMessage(process.MainWindowHandle, WM_MSG, IntPtr.Zero, IntPtr.Zero);
                            else
                                WallHelper.Instance.SetNextWallpaper();
                            return;
                        }
                    }
                }
                if (process != null)
                    SetForegroundWindow(process.MainWindowHandle);
            }
        }
    }
}