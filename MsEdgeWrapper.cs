using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);
        public delegate bool HandlerRoutine(CtrlTypes CtrlType);
        private static Process p;

        public enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        {
            p.Kill();
            return true;
        }

        static Process[] getMsEdgeProcesses()
        {
            return Process.GetProcessesByName("MicrosoftEdge");
        }

        static Process startMsEdge()
        {
            if(getMsEdgeProcesses().Length > 0)
            {
                throw new Exception("An instance of Microsoft Edge is already running");
            }

            Process.Start("microsoft-edge:google.com");

            Process[] processes = getMsEdgeProcesses();

            if(processes.Length == 0)
            {
                throw new Exception("No instance of Microsoft Edge was available after attempting to start it");
            }
            if(processes.Length > 1)
            {
                throw new Exception("More than one instance of Microsoft Edge was available after starting a single instance");
            }

            return processes[0];
        }

        static void Main(string[] args)
        {
            p = startMsEdge();

            SetConsoleCtrlHandler(new HandlerRoutine(ConsoleCtrlCheck), true);

            while(true)
            {
                Thread.Sleep(8000);
            }
        }
    }
}
