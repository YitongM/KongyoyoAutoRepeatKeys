using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoRepeat
{
    internal class Program
    {
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        private static void Main(string[] args)
        {
            //Checks if application is running
            try
            {
                Process process = Process.GetProcessesByName("MemoQ")[0];
                if (process != null)
                {
                    process.WaitForInputIdle();
                    IntPtr s = process.MainWindowHandle;
                    SetForegroundWindow(s);

                    SendKeys.SendWait("^{ENTER 260}");
                    Console.WriteLine("Amazingly done like a pro!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Application stopped running!\nException: \n" + ex);
                Console.ReadKey();
                return;
            }
        }
    }
}