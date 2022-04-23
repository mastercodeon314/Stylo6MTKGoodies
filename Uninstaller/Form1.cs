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

        public Uninstaller Uninstaller = null;
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
            Uninstaller = new Uninstaller();
            Uninstaller.InstallationFinished += Uninstaller_InstallationFinished;

            if (Uninstaller.IsInstalled == false)
            {
                Application.Exit();
            }

            this.FormClosing += Form1_FormClosing;
            frmSpinner = new FormSpinner(this);

            //createLibs();

            bannerBox = new Banner();
            bannerBox.Visible = true;

            pages = new Control[]
            {
                //new WelcomePage(),
                //new ChooseInstallFolder(bannerBox),
                //new InstallingPage(bannerBox),
                //new UninstallerTesterPage(bannerBox),
                new ComfirmUninstall(bannerBox),
                new UninstallingPage(bannerBox)
            };

            if (Uninstaller.IsInstalled == true)
            {
                pageIdx = 0;
            }
            else
            {
                Application.Exit();
            }

            updatePage();
        }

        private void Uninstaller_InstallationFinished(object sender, EventArgs e)
        {
            this.nextBtn.Text = "Close";
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
                case "UninstallerPage":
                {
                    Uninstaller.Instance.Uninstall();
                    this.cancelBtn.Enabled = false;
                    this.backBtn.Enabled = false;
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
            if (this.currentPage.Tag != (object)"UninstallerPage")
            {
                if (MessageBox.Show(this, "Are you sure you want to quit GitSE Setup?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    //deleteLibs();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                selfDelete();
            }
        }

        //private void createLibs()
        //{
        //    if (Environment.Is64BitProcess == true)
        //    {
        //        File.WriteAllBytes(_7z64Path, GitSE_Installer.Properties.Resources._7z_x64);
        //    }
        //    else
        //    {
        //        File.WriteAllBytes(_7z86Path, GitSE_Installer.Properties.Resources._7z_x86);
        //    }
        //    File.WriteAllBytes(_SevenSharpPath, GitSE_Installer.Properties.Resources.SevenZipSharp);
        //}

        //private void deleteLibs()
        //{
        //    string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        //    string _7z86Path = appPath + @"\7z-x86.dll";
        //    string _7z64Path = appPath + @"\7z-x64.dll";
        //    string _SevenSharpPath = appPath + @"\SevenZipSharp.dll";
        //    if (Environment.Is64BitProcess == true)
        //    {
        //        if (File.Exists(_7z64Path) == true) File.Delete(_7z64Path);
        //    }
        //    else
        //    {
        //        if (File.Exists(_7z64Path) == true) File.Delete(_7z86Path);
        //    }

        //    if (File.Exists(_SevenSharpPath) == true)
        //    {
        //        Process.Start(new ProcessStartInfo()
        //        {
        //            Arguments = "/C choice /C Y /N /D Y /T 1 & Del \"" + _SevenSharpPath + "\"",
        //            WindowStyle = ProcessWindowStyle.Hidden,
        //            CreateNoWindow = true,
        //            FileName = "cmd.exe"
        //        });
        //    }
        //}

        private void selfDelete()
        {
            //Process silentSelfDelete = new Process();
            //silentSelfDelete.StartInfo.FileName = "cmd.exe";
            //silentSelfDelete.StartInfo.Arguments = "/C timeout /T 1 & Del " + '"'.ToString() + Application.ExecutablePath + '"'.ToString();
            //silentSelfDelete.StartInfo.CreateNoWindow = true;
            //silentSelfDelete.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //silentSelfDelete.Start();

            //Process deleteInstallDir = new Process();
            //deleteInstallDir.StartInfo.FileName = "cmd.exe";
            //deleteInstallDir.StartInfo.Arguments = "/C taskkill /F /IM explorer.exe & timout /T 1r & timeout /T 3 & RD /Q /S " + '"'.ToString() + Uninstaller.InstallLocation + '"'.ToString();
            //deleteInstallDir.StartInfo.CreateNoWindow = true;
            //deleteInstallDir.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //deleteInstallDir.Start();

            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe",
    String.Format("/k {0} & {1} & {2}",
        "timeout /T 3 /NOBREAK >NUL",
        "rmdir /s /q \"" + Application.StartupPath + "\"",
        "exit"
    )
);

            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            psi.UseShellExecute = true;

            Process.Start(psi);

            //Application.Exit();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {

            if (nextBtn.Text == "Uninstall")
            {
                if (this.pageIdx + 1 < pages.Length)
                {
                    this.pageIdx += 1;
                    updatePage();
                }
            }
            else
            {
                this.Close();
            }
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
