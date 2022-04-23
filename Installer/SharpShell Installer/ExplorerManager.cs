using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Stylo6MTKGoodiesInstaller.SharpShell_Installer
{
    /// <summary>
    /// A Helper Class for managing certain features of Windows Explorer
    /// </summary>
    public static class ExplorerManager
    {
        /// <summary>
        /// Restarts the explorer process.
        /// </summary>
        public static void RestartExplorer()
        {
            var explorerProcess = Process.GetProcesses().FirstOrDefault(p => p.ProcessName == "explorer");
            if (explorerProcess != null)
                explorerProcess.Kill();
        }
    }
}
