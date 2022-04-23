using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace ADB
{
    public delegate void StatusCheckDoneDel(List<AdbDevice> devices);
    public delegate void AdbDevicesChangedEDell();
    public class Adb : IDisposable
    {
        private List<AdbDevice> _adbDevices;

        public List<AdbDevice> SavedAdbDevices { get { return _adbDevices; } set { _adbDevices = value; } }

        public bool DeviceAvailable
        {
            get
            {
                return _adbDevices != null && _adbDevices.Count > 0;
            }
        }

        public event AdbDevicesChangedEDell DevicesChanged;

        private AdbListener _listener;

        public Adb()
        {
            if (!AdbExtract.AdbReady)
            {
                AdbExtract.Init();
            }

            _adbDevices = new List<AdbDevice>();
            _listener = new AdbListener();
            _listener.AdbDevicesChanged += _listener_AdbDevicesChanged;
            _listener.StartPolling();
        }

        public void InitalStatusCheck()
        {
            Task.Run(() => init());
        }

        private async Task init()
        {
            string[] deviceList = await AdbAPI.GetDeviceList();

            foreach (string dev in deviceList)
            {
                AdbDevice adbDevice = new AdbDevice(dev, this);
                await adbDevice.updateState();
                this.SavedAdbDevices.Add(adbDevice);
            }

            if (DevicesChanged != null)
            {
                DevicesChanged();
            }
        }

        public string[] GetSavedDeviceNames()
        {
            List<string> devices = new List<string>();

            foreach (AdbDevice dev in this.SavedAdbDevices)
            {
                devices.Add(dev.DeviceName);
            }

            return devices.ToArray();
        }

        private async Task _listener_AdbDevicesChanged(string[] newDeviceList)
        {
            if (this.SavedAdbDevices.Count > 0)
            {
                foreach (AdbDevice dev in this.SavedAdbDevices)
                {
                    await dev.updateState();
                }

                if (newDeviceList.Length > this.SavedAdbDevices.Count)
                {
                    string[] savedDevices = GetSavedDeviceNames();
                    foreach (string device in newDeviceList)
                    {
                        if (savedDevices.Contains(device) == false)
                        {
                            AdbDevice dev = new AdbDevice(device, this);

                            await dev.updateState();

                            this.SavedAdbDevices.Add(dev);
                        }
                    }
                }

                if (DevicesChanged != null)
                {
                    DevicesChanged();
                }
            }
            else
            {
                foreach (string device in newDeviceList)
                {
                    AdbDevice dev = new AdbDevice(device, this);

                    await dev.updateState();

                    this.SavedAdbDevices.Add(dev);
                }

                if (this.SavedAdbDevices.Count > 0)
                {
                    if (DevicesChanged != null)
                    {
                        DevicesChanged();
                    }
                }
            }
        }

        public void FireEvents()
        {
            if (DevicesChanged != null)
            {
                DevicesChanged();
            }
        }

        private bool containsName(string devName)
        {
            foreach (AdbDevice dev in this.SavedAdbDevices)
            {
                if (dev.DeviceName == devName)
                {
                    return true;
                }
            }
            return false;
        }

        public void Dispose()
        {
            if (AdbExtract.AdbReady)
            {
                AdbExtract.CleanUp();
            }
        }
    }
}
