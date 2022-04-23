using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stylo6MTKGoodiesInstaller.Logic;

namespace Stylo6MTKGoodiesInstaller.Pages
{
    public partial class InstallingPage : Page
    {
        public string InstallLocation = "";

        public InstallingPage(Banner prntBanner) : base(prntBanner)
        {
            InitializeComponent();
            this.Tag = "InstallerPage";
            this.NoBanner = false;
        }

        private void showDetailsBtn_Click(object sender, EventArgs e)
        {
            this.showDetailsBtn.Visible = false;
            this.detailsBox.Visible = true;
        }

        public override void ChangeBannerText()
        {
            parentBanner.headerLbl.Text = "Installing";
            parentBanner.subTextLbl.Text = "Please wait while Stylo 6 MTK Goodies is being installed.";
        }

        public void FinishedBannerText()
        {
            parentBanner.headerLbl.Text = "Installation Complete";
            parentBanner.subTextLbl.Text = "Installation was completed successfully.";
        }
    }
}
