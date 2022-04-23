using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stylo6MTKGoodiesInstaller.Logic;

namespace Stylo6MTKGoodiesInstaller.Pages
{
    public partial class UninstallerTesterPage : Page
    {
        private UninstallerManager UninstallerManager { get; set; }
        public UninstallerTesterPage()
        {
            InitializeComponent();
            this.Tag = (object)"UninstallerTesting";
            UninstallerManager = new UninstallerManager();
            isRegBox.Checked = UninstallerManager.IsRegistered;
        }

        public UninstallerTesterPage(Banner prntBanner) : base(prntBanner)
        {
            InitializeComponent();
            this.Tag = (object)"UninstallerTesting";
            UninstallerManager = new UninstallerManager();
            isRegBox.Checked = UninstallerManager.IsRegistered;
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            UninstallerManager.CreateUninstaller();
            isRegBox.Checked = UninstallerManager.IsRegistered;
        }

        private void unregBtn_Click(object sender, EventArgs e)
        {
            UninstallerManager.RemoveUninstaller();
            isRegBox.Checked = UninstallerManager.IsRegistered;
        }
    }
}
