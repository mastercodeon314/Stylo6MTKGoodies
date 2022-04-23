using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stylo6MTKGoodiesInstaller.Pages;
using Stylo6MTKGoodiesInstaller.SharpShell_Installer;

namespace Stylo6MTKGoodiesInstaller.Logic
{
    public class Uninstaller
    {
        public static Uninstaller Instance;

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

        public Uninstaller()
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

        public void Uninstall()
        {
            Form1.frmSpinner.Start();

            Ext_UpdateStatus("Deleting files...");

            string[] excludedFiles = new string[]
            {
                "GitSE.dll",
                "SharpShell.dll",
                "Uninstall.exe"
            };

            List<string> filesToBePostDeleted = new List<string>();


            // Delete folders
            if (Directory.Exists(InstallLocation) == true)
            {
                string[] filesToDelete = Directory.EnumerateFiles(InstallLocation, "*.*", SearchOption.AllDirectories).ToArray();

                for (int i = 0; i < filesToDelete.Length; i++)
                {
                    if (File.Exists(filesToDelete[i]))
                    {
                        bool exclude = false;
                        for (int c = 0; c < excludedFiles.Length; c++)
                        {
                            if (Path.GetFileName(filesToDelete[i]) == excludedFiles[c])
                            {
                                filesToBePostDeleted.Add(filesToDelete[i]);
                                exclude = true;
                                break;
                            }
                        }

                        if (exclude == true)
                        {
                            continue;
                        }

                        if (Path.GetFileName(filesToDelete[i]) == "Uninstall.exe")
                        {
                            continue;
                        }

                        Ext_UpdateProgress(0);
                        Ext_UpdateDetails("Delete file: " + Path.GetFileName(filesToDelete[i]));
                        File.Delete(filesToDelete[i]);
                    }
                }
            }

            Ext_UpdateProgress(0);
            Ext_UpdateDetails("Unregistering GitSE shell extension");
            Ext_UpdateStatus("Unregistering shell extension...");

            UnregisterShellExtension();
            ExplorerManager.RestartExplorer();
            Thread.Sleep(500);

            if (filesToBePostDeleted.Count > 0)
            {
                foreach (string file in filesToBePostDeleted)
                {
                    if (File.Exists(file) == true)
                    {
                        if (Path.GetFileName(file) == "Uninstall.exe")
                        {
                            continue;
                        }
                        else
                        {
                            File.Delete(file);
                        }
                    }
                }
            }

            string[] dirs = Directory.GetDirectories(InstallLocation, "*", SearchOption.AllDirectories);

            for (int i = dirs.Length - 1; i >= 0; i--)
            {
                Ext_UpdateProgress(0);
                Ext_UpdateDetails("Remove folder: " + dirs[i].Replace(InstallLocation + "\\", ""));
                Directory.Delete(dirs[i]);
            }


            Ext_UpdateProgress(0);
            Ext_UpdateDetails("Unregistering Uninstaller");
            Ext_UpdateStatus("Unregistering uninstaller...");
            uninstallerManager.RemoveUninstaller();

            Ext_UpdateStatus("Uninstallation completed");

            Ext_ExtractionFinished(this, new EventArgs());
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

        private delegate void UpdateStatusDel(string status);
        private void Ext_UpdateStatus(string status)
        {
            if (Form1.Instance != null)
            {
                if (Form1.Instance.InvokeRequired)
                {
                    Form1.Instance.Invoke(new UpdateStatusDel(Ext_UpdateStatus), status);
                }
                else
                {
                    UninstallingPage pg = (UninstallingPage)Form1.Instance.pages[1];
                    pg.statusLbl.Text = status;
                }
            }
        }

        private delegate void UpdateProgDel(int prog);
        private void Ext_UpdateProgress(int prog)
        {
            if (Form1.Instance != null)
            {
                if (Form1.Instance.InvokeRequired)
                {
                    Form1.Instance.Invoke(new UpdateProgDel(Ext_UpdateProgress), prog);
                }
                else
                {
                    InstallProgress += 1;
                    UninstallingPage pg = (UninstallingPage)Form1.Instance.pages[1];
                    pg.progressBar1.Value = InstallProgress;
                }
            }
        }

        private delegate void UpdateDetailsDel(string details);
        private void Ext_UpdateDetails(string details)
        {
            if (Form1.Instance != null)
            {
                if (Form1.Instance.InvokeRequired)
                {
                    Form1.Instance.Invoke(new UpdateDetailsDel(Ext_UpdateDetails), details);
                }
                else
                {
                    UninstallingPage pg = (UninstallingPage)Form1.Instance.pages[1];
                    pg.detailsBox.Items.Add(details);
                    pg.detailsBox.SelectedIndex = pg.detailsBox.Items.Count - 1;
                }
            }
        }

        private void Ext_ExtractionFinished(object sender, EventArgs e)
        {
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
                        UninstallingPage pg = (UninstallingPage)Form1.Instance.pages[1];
                        pg.FinishedBannerText();
                        Form1.frmSpinner.Stop();
                        _installationFinished(this, new EventArgs());
                    }
                }
            }
        }
    }
}
