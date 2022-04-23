using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Stylo6MTKGoodiesInstaller.Logic
{
    public class UninstallerManager
    {
        private Guid _uninstallGuid = Guid.Empty;
        public Guid UninstallGuid
        {
            get
            {
                return _uninstallGuid;
            }
            set
            {
                _uninstallGuid = value;
            }

        }
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

        private string _installLOcation = string.Empty;
        public string InstallLocation
        {
            get
            {
                if (this.IsRegistered == true && this.UninstallGuid != Guid.Empty)
                {
                    RegistryKey parent = Registry.LocalMachine.OpenSubKey(UninstallRegKeyPath, true);
                    RegistryKey cc = parent.OpenSubKey(this.UninstallGuid.ToString("B"));
                    if (cc != null)
                    {
                        if (cc.GetValue("InstallLocation") != null)
                        {
                            return (string)cc.GetValue("InstallLocation");
                        }
                    }
                }
                return String.Empty;
            }
            set
            {
                _installLOcation = value;
            }
        }

        public bool IsRegistered
        {
            get
            {
                RegistryKey parent = Registry.LocalMachine.OpenSubKey(UninstallRegKeyPath, true);
                string[] keys = parent.GetSubKeyNames();

                foreach (string keyT in keys)
                {
                    RegistryKey cc = parent.OpenSubKey(keyT);
                    if (cc != null)
                    {
                        if (cc.GetValueNames().Length > 0)
                        {
                            string[] values = cc.GetValueNames();
                            foreach (string valueT in values)
                            {
                                if (valueT == "DisplayName")
                                {
                                    string DisplayValue = cc.GetValue("DisplayName").ToString();
                                    if (DisplayValue == DisplayName)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }

                return false;
            }
        }

        public UninstallerManager()
        {
            CheckIfINstalled();
        }

        private void CheckIfINstalled()
        {
            if (this.IsRegistered == true)
            {
                Guid result = Guid.Empty;

                RegistryKey parent = Registry.LocalMachine.OpenSubKey(UninstallRegKeyPath, true);
                string[] keys = parent.GetSubKeyNames();


                string guid = "";
                bool exit = false;
                foreach (string keyT in keys)
                {
                    if (exit == true)
                    {
                        break;
                    }

                    RegistryKey cc = parent.OpenSubKey(keyT);
                    if (cc != null)
                    {
                        if (cc.GetValueNames().Length > 0)
                        {
                            string[] values = cc.GetValueNames();
                            foreach (string valueT in values)
                            {
                                if (valueT == "DisplayName")
                                {
                                    string DisplayValue = cc.GetValue("DisplayName").ToString();
                                    if (DisplayValue == DisplayName)
                                    {
                                        guid = keyT;
                                        exit = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }


                if (guid != "")
                {
                    result = Guid.Parse(guid);
                    _uninstallGuid = result;
                }
            }
        }

        public void CreateUninstaller()
        {
            if (IsRegistered == true)
            {
                return;
            }
            if (UninstallGuid != Guid.Empty)
            {
                return;
            }

            using (RegistryKey parent = Registry.LocalMachine.OpenSubKey(UninstallRegKeyPath, true))
            {
                if (parent == null)
                {
                    throw new Exception(String.Format("Uninstall registry key '{0}' not found.", UninstallRegKeyPath));
                }
                try
                {
                    RegistryKey key = null;

                    try
                    {
                        UninstallGuid = Guid.NewGuid();
                        string guidText = UninstallGuid.ToString("B");
                        key = parent.OpenSubKey(guidText, true) ??
                              parent.CreateSubKey(guidText);

                        if (key == null)
                        {
                            throw new Exception(String.Format("Unable to create uninstaller '{0}\\{1}'", UninstallRegKeyPath, guidText));
                        }

                        Assembly asm = GetType().Assembly;
                        Version v = asm.GetName().Version;
                        string exe = "\"" + asm.CodeBase.Substring(8).Replace("/", "\\\\") + "\"";

                        key.SetValue("DisplayName", DisplayName);
                        key.SetValue("ApplicationVersion", v.ToString());
                        key.SetValue("Publisher", "Mastercodeon");
                        key.SetValue("DisplayIcon", exe);
                        key.SetValue("DisplayVersion", v.ToString(2));
                        key.SetValue("URLInfoAbout", "");
                        key.SetValue("Contact", "");
                        key.SetValue("InstallDate", DateTime.Now.ToString("yyyyMMdd"));
                        key.SetValue("InstallLocation", Installer.Instance.InstallLocation);
                        key.SetValue("UninstallString", Installer.Instance.InstallLocation + @"\Uninstall.exe"); // TO be changed when uninstaller exe is deployed

                    }
                    finally
                    {
                        if (key != null)
                        {
                            key.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception
                    (
                        "An error occurred writing uninstall information to the registry.  The service is fully installed but can only be uninstalled manually through the command line.",
                        ex
                    );
                }
            }
        }

        public void RemoveUninstaller()
        {
            if (UninstallGuid != Guid.Empty)
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(UninstallRegKeyPath, true))
                {
                    if (key == null)
                    {
                        return;
                    }
                    try
                    {
                        RegistryKey parent = Registry.LocalMachine.OpenSubKey(UninstallRegKeyPath, true);
                        string gguid = "{" + UninstallGuid.ToString() + "}";
                        parent.DeleteSubKey(gguid);
                        parent.Close();
                    }

                    catch (Exception ex)
                    {
                        throw new Exception
                            (
                                "An error occurred removing uninstall information from the registry.  The service was uninstalled will still show up in the add/remove program list.  To remove it manually delete the entry HKLM\\" +
                                UninstallRegKeyPath + "\\" + UninstallGuid, ex
                            );
                    }
                }
            }            
        }
    }
}
