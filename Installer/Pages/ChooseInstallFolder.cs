using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Stylo6MTKGoodiesInstaller.Logic;

namespace Stylo6MTKGoodiesInstaller.Pages
{
    public partial class ChooseInstallFolder : Page
    {
        private DriveInfo _driveInfo;
        public string InstallLocation = "";
        public bool SkipToUninstallerTesting = false;
        public ChooseInstallFolder(Banner prntBanner) : base(prntBanner)
        {
            InitializeComponent();
            this.Tag = "ChooseInstallFolder";
            this.NoBanner = false;

            if (Environment.Is64BitOperatingSystem == true)
            {
                this.destinationBox.Text = @"C:\Program Files\Stylo6MTKGoodies";
            }
            else
            {
                this.destinationBox.Text = @"C:\Program Files (x86)\Stylo6MTKGoodies";
            }

            updateSpaceInfos();
        }

        public override void ChangeBannerText()
        {
            parentBanner.headerLbl.Text = "Choose Install Location";
            parentBanner.subTextLbl.Text = "Choose the folder in which to install Stylo 6 MTK Goodies.";
        }

        private void updateSpaceInfos()
        {
            string driveRoot = Path.GetPathRoot(this.destinationBox.Text);
            _driveInfo = new DriveInfo(driveRoot);

            long freeSpaceBytes = _driveInfo.AvailableFreeSpace;
            string freeSpace = SizeSuffix(freeSpaceBytes);

            SpaceAvaLbl.Text = "Space available: " + freeSpace;

            long spaceRequiredBytes = 58910364L;

            string spaceRequired = SizeSuffix(spaceRequiredBytes);
            spaceReqLbl.Text = "Space required: " + spaceRequired;

            // TODO add together all the byte sizes of the zips once extracted and hard code those values to be converted as above

        }

        static readonly string[] SizeSuffixes =
                  { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }

            int i = 0;
            decimal dValue = (decimal)value;
            while (Math.Round(dValue, decimalPlaces) >= 1000)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}", dValue, SizeSuffixes[i]);
        }

        private void createPath()
        {
            if (Directory.Exists(this.destinationBox.Text) == false)
            {
                Directory.CreateDirectory(this.destinationBox.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //createPath();
            //ExtractArchives ext = new ExtractArchives(this.destinationBox.Text);
            //ext.Extract_Git_Libs(this.progLbl);
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                //if (Environment.Is64BitOperatingSystem == true)
                //{
                //    fbd.RootFolder = Environment.SpecialFolder.ProgramFiles;
                //}
                //else 
                //{
                //    fbd.RootFolder = Environment.SpecialFolder.ProgramFilesX86;
                //}
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;

                fbd.Description = "Select the folder to install Stylo 6 MTK Goodies in:";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    this.destinationBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void destinationBox_TextChanged(object sender, EventArgs e)
        {
            this.InstallLocation = this.destinationBox.Text;
            Form1.Instance.Installer.InstallLocation = this.InstallLocation;
        }

        private void uninstallerTesterBox_CheckedChanged(object sender, EventArgs e)
        {
            SkipToUninstallerTesting = uninstallerTesterBox.Checked;
        }
    }
}
