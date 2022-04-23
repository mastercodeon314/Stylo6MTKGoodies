using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Stylo6MTKGoodiesInstaller
{
    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //if (IsAdministrator() == false)
            //{
            //    // Restart program and run as admin
            //    var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
            //    startInfo.Verb = "runas";
            //    System.Diagnostics.Process.Start(startInfo);
            //    Application.Exit();
            //    return;
            //}
            //AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        //private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        //{
        //    deleteLibs();
        //}

        //private static void deleteLibs()
        //{
        //    string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        //    string _7z86Path = appPath + @"\7z-x86.dll";
        //    string _7z64Path = appPath + @"\7z-x64.dll";
        //    string _SevenSharpPath = appPath + @"\SevenZipSharp.dll";
        //    if (Environment.Is64BitProcess == true)
        //    {
        //        if (File.Exists(_7z64Path) == true) File.Delete(_7z64Path);
        //    }
        //    else
        //    {
        //        if (File.Exists(_7z64Path) == true) File.Delete(_7z86Path);
        //    }

        //    if (File.Exists(_SevenSharpPath) == true)
        //    {
        //        Process.Start(new ProcessStartInfo()
        //        {
        //            Arguments = "/C choice /C Y /N /D Y /T 1 & Del \"" + _SevenSharpPath + "\"",
        //            WindowStyle = ProcessWindowStyle.Hidden,
        //            CreateNoWindow = true,
        //            FileName = "cmd.exe"
        //        });
        //        //File.Delete(_SevenSharpPath);
        //    }
        //}

        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
