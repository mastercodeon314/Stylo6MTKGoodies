using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SevenZip;
using System.Windows.Forms;

namespace ADB
{
    public class AdbExtract
    {
        #region Adb Extraction
        static string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        static string _7z86Path = appPath + @"\7z-x86.dll";
        static string _7z64Path = appPath + @"\7z-x64.dll";
        static string _adbPath = appPath + @"\adb";
        static string _adbExePath = appPath + @"\adb\adb.exe";

        static bool _adbReady = false;

        public static bool AdbReady { get { return _adbReady; } }

        public static string AdbExePath { get { return _adbExePath; } }

        static AdbExtract()
        {
            // Init(); // ? Might cause problems, needs further testing
        }

        public static void Init()
        {
            if (AdbReady == false)
            {
                if (Environment.Is64BitProcess == true)
                {
                    File.WriteAllBytes(_7z64Path, ADB.Properties.Resources._7z_x64);
                }
                else
                {
                    File.WriteAllBytes(_7z86Path, ADB.Properties.Resources._7z_x86);
                }

                // set the SevenZip Library Path
                if (Environment.Is64BitProcess == true)
                {
                    SevenZipBase.SetLibraryPath(_7z64Path);
                }
                else
                {
                    SevenZipBase.SetLibraryPath(_7z86Path);
                }

                extractAdb();

                _adbReady = true;
            }
        }

        public static void CleanUp()
        {
            if (AdbReady == true)
            {
                if (File.Exists(_7z86Path) == true)
                {
                    File.Delete(_7z86Path);
                }

                if (File.Exists(_7z64Path) == true)
                {
                    File.Delete(_7z64Path);
                }

                // TODO: Kill adb and delete the exe
                if (Directory.Exists(_adbPath) == true)
                {
                }
            }
        }
        static void exeAdbZip()
        {
            string adbZipLoc = extractAdbZip();
            SevenZipExtractor ext = new SevenZipExtractor(adbZipLoc);
            int[] arr = Enumerable.Range(0, ext.ArchiveFileData.Count).ToArray();

            for (int i = 0; i < ext.ArchiveFileData.Count; i++)
            {
                MemoryStream str = new MemoryStream();
                string name = ext.ArchiveFileNames[i];
                ext.ExtractFile(name, str);

                if (File.Exists(_adbPath + name) == false)
                {
                    File.WriteAllBytes(_adbPath + @"\" + name, str.ToArray());
                }
                str.Dispose();
            }

            ext.Dispose();

            File.Delete(adbZipLoc);
        }


        private static void extractAdb()
        {
            if (Directory.Exists(_adbPath) == false)
            {
                Directory.CreateDirectory(_adbPath);

                exeAdbZip();
            }
            else
            {
                if (File.Exists(_adbExePath) == false)
                {
                    exeAdbZip();
                }
            }
        }

        static string extractAdbZip()
        {
            string zipPath = Environment.GetEnvironmentVariable("TEMP");
            zipPath += @"\adb.7z";
            if (File.Exists(zipPath) == false)
            {
                File.WriteAllBytes(zipPath, ADB.Properties.Resources.adb);
            }

            return zipPath;
        }
        #endregion
    }
}
