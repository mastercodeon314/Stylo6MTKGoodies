using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stylo6MTKGoodiesInstaller.Pages;
using Stylo6MTKGoodiesInstaller.SharpShell_Installer;

namespace Stylo6MTKGoodiesInstaller.Logic
{
    public class Installer
    {
        public static Installer Instance;

        private string _installLocation = string.Empty;
        public string InstallLocation
        {
            get
            {
                return _installLocation;
            }
            set
            {
                _installLocation = value;
            }
        }

        public delegate void _installationFinishedDel(object sender, EventArgs e);

        private _installationFinishedDel _installationFinished;
        public event _installationFinishedDel InstallationFinished
        {
            add { _installationFinished += value; }
            remove { _installationFinished -= value; }
        }

        private UninstallerManager uninstallerManager;
        private Guid UninstallGuid { get; set; }
        private string UninstallRegKeyPath
        {
            get
            {
                return @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            }
        }

        public string DisplayName
        {
            get
            {
                return "GitSE";
            }
        }

        private bool _isInstalled = false;
        public bool IsInstalled
        {
            get
            {
                return _isInstalled;
            }
            set
            {
                _isInstalled = value;
            }
        }

        public int InstallProgress = 0;

        public Installer()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            uninstallerManager = new UninstallerManager();
            _isInstalled = uninstallerManager.IsRegistered == true && (uninstallerManager.UninstallGuid != Guid.Empty);

            if (IsInstalled == true)
            {
                UninstallGuid = uninstallerManager.UninstallGuid;
                InstallLocation = uninstallerManager.InstallLocation;
            }
        }

        public void Install()
        {
            ExtractArchives ext = new ExtractArchives(this.InstallLocation);
            ext.ExtractionFinished += Ext_ExtractionFinished;
            ext.UpdateDetails += Ext_UpdateDetails;
            ext.UpdateProgress += Ext_UpdateProgress;
            ext.UpdateStatus += Ext_UpdateStatus;
            ext.Extract_Git_Libs();
            uninstallerManager.InstallLocation = this.InstallLocation;
        }

        

        public void RegisterShellExtension()
        {
            RegAsm n = new RegAsm();
            if (Environment.Is64BitOperatingSystem)
            {
                n.Register64(this.InstallLocation + @"\GitSE.dll", true);
            }
            else
            {
                n.Register32(this.InstallLocation + @"\GitSE.dll", true);
            }
        }

        public void UnregisterShellExtension()
        {
            RegAsm n = new RegAsm();
            if (Environment.Is64BitOperatingSystem)
            {
                n.Unregister64(this.InstallLocation + @"\GitSE.dll");
            }
            else
            {
                n.Unregister32(this.InstallLocation + @"\GitSE.dll");
            }
        }

        private void Ext_UpdateStatus(string status)
        {
            if (Form1.Instance != null)
            {
                if (Form1.Instance.InvokeRequired)
                {
                    Form1.Instance.Invoke(new ExtractArchives.UpdateStatusDel(Ext_UpdateStatus), status);
                }
                else
                {
                    InstallingPage pg = (InstallingPage)Form1.Instance.pages[2];
                    pg.statusLbl.Text = status;
                }
            }
        }

        private void Ext_UpdateProgress(int prog)
        {
            if (Form1.Instance != null)
            {
                if (Form1.Instance.InvokeRequired)
                {
                    Form1.Instance.Invoke(new ExtractArchives.UpdateProgDel(Ext_UpdateProgress), prog);
                }
                else
                {
                    InstallProgress += 1;
                    InstallingPage pg = (InstallingPage)Form1.Instance.pages[2];
                    pg.progressBar1.Value = InstallProgress;
                }
            }
        }

        private void Ext_UpdateDetails(string details)
        {
            if (Form1.Instance != null)
            {
                if (Form1.Instance.InvokeRequired)
                {
                    Form1.Instance.Invoke(new ExtractArchives.UpdateDetailsDel(Ext_UpdateDetails), details);
                }
                else
                {
                    InstallingPage pg = (InstallingPage)Form1.Instance.pages[2];
                    pg.detailsBox.Items.Add(details);
                    pg.detailsBox.SelectedIndex = pg.detailsBox.Items.Count - 1;
                }
            }
        }

        private void Ext_ExtractionFinished(object sender, EventArgs e)
        {
            Ext_UpdateProgress(0);
            Ext_UpdateDetails("Registering Uninstaller");
            Ext_UpdateStatus("Registering Uninstaller...");
            uninstallerManager.CreateUninstaller();

            Ext_UpdateDetails("Registering GitSE shell extension");
            Ext_UpdateStatus("Registering shell extension...");
            Ext_UpdateProgress(0);
            RegisterShellExtension();

            Ext_UpdateStatus("Installation completed");
            finishEvent();
        }

        public delegate void finishEventDel();
        private void finishEvent()
        {
            if (Form1.Instance != null)
            {
                if (Form1.Instance.InvokeRequired)
                {
                    Form1.Instance.Invoke(new finishEventDel(finishEvent));
                }
                else
                {
                    if (_installationFinished != null)
                    {
                        InstallingPage pg = (InstallingPage)Form1.Instance.pages[2];
                        pg.FinishedBannerText();
                        Form1.frmSpinner.Stop();
                        _installationFinished(this, new EventArgs());
                    }
                }
            }
        }

        private void createPath()
        {
            if (Directory.Exists(this.InstallLocation) == false)
            {
                Directory.CreateDirectory(this.InstallLocation);
            }
        }
    }
}
