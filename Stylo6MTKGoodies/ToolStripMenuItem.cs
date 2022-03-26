using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Darkness
{
    public class ToolStripMenuItem : System.Windows.Forms.ToolStripMenuItem
    {
        public ToolStripMenuItem() : base()
        {
            this.ForeColor = Color.Silver;
            this.BackColor = Color.FromArgb(255, 33, 33, 33);

        }

    }
}
