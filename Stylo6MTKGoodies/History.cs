using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Stylo6MTKGoodies
{
    public class History
    {
        public static void DoHistory(string path)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("[RecentOpenFile]");
            stringBuilder.AppendLine("lastDir=" + Application.StartupPath.Replace("\\", "\\\\") + @"\\mtkclient\\spflashtool\\MT6765_Android_scatter.txt");
            stringBuilder.AppendLine("scatterHistory=" + Application.StartupPath.Replace("\\", "\\\\") + @"\\mtkclient\\spflashtool\\MT6765_Android_scatter.txt");
            stringBuilder.AppendLine("authHistory=@Invalid()");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("[LastDAFilePath]");
            stringBuilder.AppendLine("lastDir=" + Application.StartupPath.Replace("\\", "\\\\") + @"\\mtkclient\\spflashtool\\MTK_AllInOne_DA.bin");

            File.WriteAllText(path, stringBuilder.ToString());
        }
    }
}
