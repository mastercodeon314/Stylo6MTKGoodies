using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stylo6MTKGoodiesInstaller.Pages
{
    public partial class SetupFinishedPage : Page
    {
        public SetupFinishedPage()
        {
            InitializeComponent();
            this.Tag = "SetupFinishedPage";
            this.NoBanner = true;
            this.Size = new Size(541, 330);
        }
    }
}
