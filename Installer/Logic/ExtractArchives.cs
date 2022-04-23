using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SevenZip;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Stylo6MTKGoodiesInstaller.Logic
{
    public class ExtractArchives
    {
        static string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        static string _7z86Path = appPath + @"\7z-x86.dll";
        static string _7z64Path = appPath + @"\7z-x64.dll";

        public string InstallLocation = "";
        private string tempPath = "";

        private EventHandler _ExtractionFinished;
        public event EventHandler ExtractionFinished
        {
            add
            {
                _ExtractionFinished += value;
            }
            remove
            {
                _ExtractionFinished -= value;
            }
        }

        public delegate void UpdateDetailsDel(string dets);

        private UpdateDetailsDel _updateDetails;
        public event UpdateDetailsDel UpdateDetails
        {
            add
            {
                _updateDetails += value;
            }

            remove
            {
                _updateDetails -= value;
            }
        }

        public delegate void UpdateStatusDel(string dets);

        private UpdateStatusDel _updateStatus;
        public event UpdateStatusDel UpdateStatus
        {
            add
            {
                _updateStatus += value;
            }

            remove
            {
                _updateStatus -= value;
            }
        }

        public delegate void UpdateProgDel(int prog);

        private UpdateProgDel _updateProg;
        public event UpdateProgDel UpdateProgress
        {
            add
            {
                _updateProg += value;
            }

            remove
            {
                _updateProg -= value;
            }
        }

        public ExtractArchives(string installLoc)
        {
            InstallLocation = installLoc;
            if (Environment.Is64BitProcess == true)
            {
                SevenZipBase.SetLibraryPath(_7z64Path);
            }
            else
            {
                SevenZipBase.SetLibraryPath(_7z86Path);
            }

            tempPath = Environment.GetEnvironmentVariable("TEMP");

        }
        Thread thrd = null;
        public void Extract_Git_Libs()
        {
            thrd = new Thread(new ThreadStart(gitExt));
            thrd.Start();
        }

        private void gitExt()
        {
            // Extracting MinGit 7z
            string gitZipArchive = this.extractGitZips();
            SevenZipExtractor ext = new SevenZipExtractor(gitZipArchive);

            ext.FileExtractionFinished += Ext_FileExtractionFinished;
            ext.FileExtractionStarted += Ext_FileExtractionStarted;
            Form1.frmSpinner.Start();

            if (_updateStatus != null) _updateStatus("Extracting MinGit...");
            ext.ExtractFiles(this.InstallLocation, Enumerable.Range(0, ext.ArchiveFileData.Count).ToArray());
            
            ext.Dispose();
            deleteGitZips();


            // Extracting GitSE 7z
            string gitSEArchivePath = extractGitSE();
            ext = new SevenZipExtractor(gitSEArchivePath);

            ext.FileExtractionFinished += Ext_FileExtractionFinished;
            ext.FileExtractionStarted += Ext_FileExtractionStarted;

            if (_updateStatus != null) _updateStatus("Extracting GitSE...");
            ext.ExtractFiles(this.InstallLocation, Enumerable.Range(0, ext.ArchiveFileData.Count).ToArray());

            
            ext.Dispose();
            deleteGitSE();


            if (_ExtractionFinished != null)
            {
                _ExtractionFinished(this, new EventArgs());
            }
            thrd = null;
        }

        private void Ext_FileExtractionStarted(object sender, FileInfoEventArgs e)
        {
            string path = this.InstallLocation + @"\" + e.FileInfo.FileName;
            if (_updateDetails != null) _updateDetails("Extract: " + Path.GetFileName(path));
        }

        private void Ext_FileExtractionFinished(object sender, FileInfoEventArgs e)
        {
            SevenZipExtractor ext = (SevenZipExtractor)sender;

            //if (_updateDetails != null) _updateDetails("Finished Extracting: " + this.InstallLocation + @"\" + e.FileInfo.FileName);

            double a = (((double)e.FileInfo.Index + 1.0) / (double)ext.ArchiveFileData.Count) * 100.0;
            if (_updateProg != null) _updateProg((int)Math.Round(a, 2));
        }

        StringBuilder sb = new StringBuilder();

        private void Ext_ExtractionFinished(object sender, EventArgs e)
        {
            SevenZipExtractor ext = (SevenZipExtractor)sender;
            ext.Dispose();

            thrd = null;
        }

        //delegate void updateProgDel(int percentDone);
        //delegate void updateDetailsBoxDel(string detail);

        //private void updateDetailsBox(string details)
        //{
        //    if (Form1.Instance != null)
        //    {
        //        if (Form1.Instance.InvokeRequired)
        //        {
        //            Form1.Instance.Invoke(new updateDetailsBoxDel(updateDetailsBox), details);
        //        }
        //        else
        //        {
        //            detailsBox.Items.Add(details);
        //            detailsBox.SelectedIndex = detailsBox.Items.Count - 1;
        //        }
        //    }
        //}

        //private void updateProg(int percentDone)
        //{
        //    if (Form1.Instance != null)
        //    {
        //        if (Form1.Instance.InvokeRequired)
        //        {
        //            Form1.Instance.Invoke(new updateProgDel(updateProg), percentDone);
        //        }
        //        else
        //        {
        //            //progCT.Text = "7z Progress: " + percentDone.ToString() + "%";
        //            ProgressBar p = (ProgressBar)progCT;
        //            p.Value = percentDone;
        //        }
        //    }
        //}

        private string extractGitZips()
        {
            string zipPath = tempPath;
            if (Environment.Is64BitOperatingSystem == true)
            {
                zipPath += @"\MinGit-x64.7z";
                if (File.Exists(zipPath) == false)
                {
                    File.WriteAllBytes(zipPath, Stylo6MTKGoodiesInstaller.Properties.Resources.MinGit_x64);
                }
                else
                {
                    File.Delete(zipPath);
                    File.WriteAllBytes(zipPath, Stylo6MTKGoodiesInstaller.Properties.Resources.MinGit_x64);
                }
            }
            else
            {
                zipPath += @"\MinGit-x86.7z";
                if (File.Exists(zipPath) == false)
                {
                    File.WriteAllBytes(zipPath, Stylo6MTKGoodiesInstaller.Properties.Resources.MinGit_x86);
                }
                else
                {
                    File.Delete(zipPath);
                    File.WriteAllBytes(zipPath, Stylo6MTKGoodiesInstaller.Properties.Resources.MinGit_x86);
                }
            }

            return zipPath;
        }

        private string extractGitSE()
        {
            string zipPath = tempPath;
            zipPath += @"\GitSE.7z";
            if (File.Exists(zipPath) == false)
            {
                File.WriteAllBytes(zipPath, Stylo6MTKGoodiesInstaller.Properties.Resources.GitSE);
            }
            else
            {
                File.Delete(zipPath);
                File.WriteAllBytes(zipPath, Stylo6MTKGoodiesInstaller.Properties.Resources.GitSE);
            }

            return zipPath;
        }

        private string deleteGitZips()
        {
            string zipPath = System.Environment.GetEnvironmentVariable("TEMP");
            if (Environment.Is64BitOperatingSystem == true)
            {
                zipPath += @"\MinGit-x64.7z";
                if (File.Exists(zipPath) == true)
                {
                    File.Delete(zipPath);
                }
            }
            else
            {
                zipPath += @"\MinGit-x86.7z";
                if (File.Exists(zipPath) == true)
                {
                    File.Delete(zipPath);
                }
            }

            return zipPath;
        }

        private string deleteGitSE()
        {
            string zipPath = tempPath;
            zipPath += @"\GitSE.7z";
            if (File.Exists(zipPath) == true)
            {
                File.Delete(zipPath);
            }

            return zipPath;
        }
    }
}
