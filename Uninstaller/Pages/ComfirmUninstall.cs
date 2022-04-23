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
    public partial class ComfirmUninstall : Page
    {
        public ComfirmUninstall(Banner prntBanner) : base(prntBanner)
        {
            InitializeComponent();
            this.NoBanner = false;

            this.Tag = (object)"ComfirmUninstallPage";
            this.uninstallLocationBox.Text = Form1.Instance.Uninstaller.InstallLocation;
        }

        public override void ChangeBannerText()
        {
            parentBanner.headerLbl.Text = "Uninstall GitSE";
            parentBanner.subTextLbl.Text = "Remove GitSE from your computer.";
        }
    }
}
