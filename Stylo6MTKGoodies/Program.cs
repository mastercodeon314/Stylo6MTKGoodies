using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stylo6MTKGoodies
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // TODO build a prompt from this know file that will check to see after its created the file if there is only mtkclient\SPFlashTool\history.ini existing,
            // and no other files or folders along this path. 
            History.DoHistory(Application.StartupPath + @"\mtkclient\SPFlashTool\history.ini");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
