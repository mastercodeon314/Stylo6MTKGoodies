using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stylo6MTKGoodiesInstaller.Pages;
using System.IO;
using Stylo6MTKGoodiesInstaller.Logic;

namespace Stylo6MTKGoodiesInstaller
{
    public partial class Form1 : Form
    {
        public static Form1 Instance = null;
        public static FormSpinner frmSpinner = null;

        public Installer Installer = null;
        static string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        static string _7z86Path = appPath + @"\7z-x86.dll";
        static string _7z64Path = appPath + @"\7z-x64.dll";
        static string _SevenSharpPath = appPath + @"\SevenZipSharp.dll";

        private int pageIdx = 0;
        public Control[] pages = null;
        private Control currentPage = null;

        private Banner bannerBox = null;

        private Guid InstalledGuid = Guid.Empty;



        public Form1()
        {
            InitializeComponent();
            Form1.Instance = this;
            Installer = new Installer();
            Installer.InstallationFinished += Installer_InstallationFinished;
            this.FormClosing += Form1_FormClosing;
            frmSpinner = new FormSpinner(this);

            createLibs();

            bannerBox = new Banner();
            bannerBox.Visible = true;

            pages = new Control[]
            {
                new WelcomePage(),
                new ChooseInstallFolder(bannerBox),
                new InstallingPage(bannerBox),
                new UninstallerTesterPage(bannerBox),
                new ComfirmUninstall(bannerBox),
                new SetupFinishedPage()
            };

            if (Installer.IsInstalled == true)
            {
                pageIdx = pages.Length - 2;
            }

            updatePage();
        }

        private void Installer_InstallationFinished(object sender, EventArgs e)
        {
            this.nextBtn.Text = "Next >";
            this.nextBtn.Enabled = true;
        }

        private void updatePage()
        {
            if (this.currentPage != null)
            {
                this.Controls.Remove(this.currentPage);
            }

            this.currentPage = pages[this.pageIdx];
            this.Controls.Add(pages[this.pageIdx]);

            Page pg = (Page)this.currentPage;
            pg.ChangeBannerText();

            switch (this.currentPage.Tag)
            {
                case "WelcomePage":
                {
                    this.backBtn.Visible = false;
                    this.nextBtn.Text = "Next >";
                    if (this.Controls.Contains(bannerBox)) this.Controls.Remove(bannerBox);
                    this.ControlBox = true;
                    break;
                }

                case "SetupFinishedPage":
                {
                    this.nextBtn.Text = "Finish";
                    lineLbl.Visible = true;
                    if (this.Controls.Contains(bannerBox))
                    {
                        this.Controls.Remove(bannerBox);
                    }
                        this.currentPage.Location = new Point(12, 12);
                    break;
                }

                case "ChooseInstallFolder":
                {
                    this.nextBtn.Text = "Install";
                    this.nextBtn.Enabled = true;
                    this.backBtn.Enabled = true;
                    this.cancelBtn.Enabled = true;
                    this.ControlBox = true;
                    break;
                }

                case "InstallerPage":
                {
                    this.nextBtn.Text = "Next >";
                    this.nextBtn.Enabled = false;
                    this.backBtn.Enabled = false;
                    this.cancelBtn.Enabled = false;

                    Installer.Install();

                    //this.ControlBox = false; // ??? Might keep this, dont know
                    break;
                }

                case "ComfirmUninstallPage":
                {
                    this.nextBtn.Text = "Uninstall";
                    this.nextBtn.Enabled = true;
                    this.backBtn.Visible = false;
                    this.cancelBtn.Enabled = true;
                    break;
                }

                case "UninstallerTesting":
                {
                    this.nextBtn.Text = "Next >";
                    this.nextBtn.Enabled = false;
                    this.backBtn.Enabled = false;
                    this.cancelBtn.Enabled = true;
                    break;
                }
            }

            if (((Page)currentPage).NoBanner == true)
            {
                if (this.Controls.Contains(bannerBox))
                {
                    this.Controls.Remove(bannerBox);
                }
                this.currentPage.Location = new Point(0, 0);

            }
            else
            {
                this.lineLbl.Visible = true;
                this.backBtn.Visible = true;
                this.currentPage.Location = new Point(12, 80);
                if (!this.Controls.Contains(bannerBox)) this.Controls.Add(bannerBox);
            }

            //if ((this.currentPage.Tag != (object)"ComfirmUninstallPage") && this.currentPage.Tag != (object)"SetupFinishedPage")
            //{
            //    if (this.pageIdx > 0)
            //    {
            //        this.backBtn.Visible = true;
            //        this.currentPage.Location = new Point(12, 80);
            //        if (!this.Controls.Contains(bannerBox)) this.Controls.Add(bannerBox);
            //    }
            //}
            //else if (this.currentPage.Tag != (object)"SetupFinishedPage")
            //{
            //    this.backBtn.Visible = true;
            //    this.currentPage.Location = new Point(12, 80);
            //    if (!this.Controls.Contains(bannerBox)) this.Controls.Add(bannerBox);
            //}
            //else if (this.currentPage.Tag == (object)"SetupFinishedPage")
            //{
            //    bannerBox.Visible = false;
            //    if (this.Controls.Contains(bannerBox))
            //    {
            //        this.Controls.Remove(bannerBox);
            //    }
            //    this.currentPage.Location = new Point(12, 12);
            //}
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.currentPage.Tag != (object)"SetupFinishedPage")
            {
                if (MessageBox.Show(this, "Are you sure you want to quit Stylo 6 MTKGoodies Setup?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    deleteLibs();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                deleteLibs();
            }
        }

        private void createLibs()
        {
            if (Environment.Is64BitProcess == true)
            {
                File.WriteAllBytes(_7z64Path, Stylo6MTKGoodiesInstaller.Properties.Resources._7z_x64);
            }
            else
            {
                File.WriteAllBytes(_7z86Path, Stylo6MTKGoodiesInstaller.Properties.Resources._7z_x86);
            }
            File.WriteAllBytes(_SevenSharpPath, Stylo6MTKGoodiesInstaller.Properties.Resources.SevenZipSharp);
        }

        private void deleteLibs()
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string _7z86Path = appPath + @"\7z-x86.dll";
            string _7z64Path = appPath + @"\7z-x64.dll";
            string _SevenSharpPath = appPath + @"\SevenZipSharp.dll";
            if (Environment.Is64BitProcess == true)
            {
                if (File.Exists(_7z64Path) == true) File.Delete(_7z64Path);
            }
            else
            {
                if (File.Exists(_7z86Path) == true) File.Delete(_7z86Path);
            }

            if (File.Exists(_SevenSharpPath) == true)
            {
                Process.Start(new ProcessStartInfo()
                {
                    Arguments = "/C choice /C Y /N /D Y /T 1 & Del \"" + _SevenSharpPath + "\"",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "cmd.exe"
                });
            }
        }

        private void selfDelete()
        {
            Process silentSelfDelete = new Process();
            silentSelfDelete.StartInfo.FileName = "cmd.exe";
            silentSelfDelete.StartInfo.Arguments = "/C choice /C Y /N /D Y /T 1 & Del " + Application.ExecutablePath;
            silentSelfDelete.StartInfo.CreateNoWindow = true;
            silentSelfDelete.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            silentSelfDelete.Start();
            Application.Exit();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (currentPage.Tag == (object)"InstallerPage")
            {
                pageIdx = pages.Length - 1;
                bannerBox.Visible = false;
                updatePage();
                return;
            }

            if (nextBtn.Text == "Finish")
            {
                this.Close();
            }

            if (currentPage.Tag == (object)"ChooseInstallFolder")
            {
                ChooseInstallFolder pg = (ChooseInstallFolder)currentPage;
                if (pg.SkipToUninstallerTesting == true)
                {
                    pageIdx = 3;
                    updatePage();
                    return;
                }
            }
            if (this.pageIdx + 1 < pages.Length)
            {
                this.pageIdx += 1;
            }

            updatePage();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (this.pageIdx - 1 >= 0)
            {
                this.pageIdx -= 1;
            }

            updatePage();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
