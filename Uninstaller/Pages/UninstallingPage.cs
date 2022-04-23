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
    public partial class UninstallingPage : Page
    {
        public string InstallLocation = "";

        public UninstallingPage(Banner prntBanner) : base(prntBanner)
        {
            InitializeComponent();
            this.Tag = "UninstallerPage";
            this.NoBanner = false;
        }

        private void showDetailsBtn_Click(object sender, EventArgs e)
        {
            this.showDetailsBtn.Visible = false;
            this.detailsBox.Visible = true;
        }

        public override void ChangeBannerText()
        {
            parentBanner.headerLbl.Text = "Uninstalling";
            parentBanner.subTextLbl.Text = "Please wait while GitSE is being uninstalled.";
        }

        public void FinishedBannerText()
        {
            parentBanner.headerLbl.Text = "Uninstallation Complete";
            parentBanner.subTextLbl.Text = "Uninstallation was completed successfully.";
        }
    }
}
