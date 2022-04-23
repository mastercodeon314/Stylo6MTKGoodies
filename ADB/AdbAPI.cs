using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB
{
    public delegate void GetDeviceListEventDel(string[] deviceList);
    public delegate void CommandCompletedDel(string result);
    public class AdbAPI
    {
        public static event GetDeviceListEventDel GetDeviceListEvent;

        public static event CommandCompletedDel CommandCompleted;

        public static async Task<string> WaitForDevice()
        {
            return await adb("wait-for-device");
        }

        #region device check
        private static async Task<string> dev()
        {
            string res = await adb("devices");
            return res;
        }

        public static async Task<string[]> GetDeviceList()
        {

            string r = await dev();

            string[] deviceList = splitByLines(r);

            if (GetDeviceListEvent != null)
            {
                GetDeviceListEvent(deviceList);
            }

            return deviceList;
        }

        static string[] splitByLines(string x)
        {
            string[] result = x.Split(new char[] { '\r', '\n' });
            List<string> lines = new List<string>();

            foreach (string line in result)
            {
                if (line != String.Empty)
                {
                    if (line.Contains('\t'))
                    {
                        int tabIdx = line.IndexOf('\t');
                        string sub = line.Substring(0, tabIdx);
                        lines.Add(sub);
                    }
                }
            }

            return lines.ToArray();
        }
        #endregion

        #region Adb Command sender
        public static async Task<string> adb(string command, string device, bool kill = false)
        {
            Process process = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.FileName = AdbExtract.AdbExePath;
            process.StartInfo = processStartInfo;
            processStartInfo.Arguments = "-s " + device + " " + command;
            process.Start();

            string returnData = await process.StandardOutput.ReadToEndAsync();

            if (kill == true) process.Close();

            if (CommandCompleted != null)
            {
                if (command == "wait-for-device")
                {
                    CommandCompleted("Finished waiting for device");
                }
                else
                {
                    CommandCompleted(returnData);
                }                
            }

            return returnData;
        }

        public static async Task<string> adb(string command, bool kill = false)
        {
            Process process = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.FileName = AdbExtract.AdbExePath;
            process.StartInfo = processStartInfo;
            processStartInfo.Arguments = command;
            process.Start();

            string returnData = await process.StandardOutput.ReadToEndAsync();

            if (kill == true) process.Close();

            if (CommandCompleted != null)
            {
                if (command == "wait-for-device")
                {
                    CommandCompleted("Finished waiting for device");
                }
                else
                {
                    CommandCompleted(returnData);
                }
            }

            return returnData;
        }
        #endregion
    }
}
