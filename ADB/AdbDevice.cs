using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB
{
    public delegate Task DeviceStateChangedDel(DeviceState state);

    public enum DeviceState
    {
        Disconnected,
        ConnectedNotBooted,
        ConnectedFullyBooted
    }

    public class AdbDevice
    {
        private DeviceState _state = DeviceState.Disconnected;
        public DeviceState State
        {
            get
            {
                return _state;
            }
             set
            {
                _state = value;
                
            }
        }

        public event DeviceStateChangedDel DeviceStateChanged;

        public string DeviceName { get; set; }

        private Adb _adb;

        public AdbDevice(string devName, Adb adb)
        {
            DeviceName = devName;
            _adb = adb;
        }

        public string ExecuteCommand(string command)
        {
            string res = Task<string>.Run(() => AdbAPI.adb(command, DeviceName)).GetAwaiter().GetResult();
            return res;
        }

        public void UpdateState()
        {
            Task.Run(() => updateState());
        }

        public async Task updateState()
        {
            await checkAttached();
            await Task.Run(() => waitForBooted()); // ? Dont know if i need wait here, VS says I do
        }

        private async Task checkAttached()
        {
            bool isAttached = false;

            string[] devices = await AdbAPI.GetDeviceList();

            foreach (string device in devices)
            {
                if (device == this.DeviceName)
                {
                    isAttached = true;
                    this.State = DeviceState.ConnectedNotBooted;

                    if (DeviceStateChanged != null)
                    {
                        DeviceStateChanged(_state);
                    }
                    break;
                }
            }

            if (isAttached == false)
            {
                this.State = DeviceState.Disconnected;

                if (DeviceStateChanged != null)
                {
                    DeviceStateChanged(_state);
                }
            }
        }


        private async Task checkBooted()
        {
            string res = await AdbAPI.adb("shell getprop sys.boot_completed", this.DeviceName);
            if (res != null)
            {
                res = res.Replace('\r'.ToString(), "").Replace('\n'.ToString(), "");
            }

            if (res == "1")
            {
                this.State = DeviceState.ConnectedFullyBooted;
                if (DeviceStateChanged != null)
                {
                    DeviceStateChanged(_state);
                }
            }
            else
            {
                this.State = DeviceState.ConnectedFullyBooted;
                if (DeviceStateChanged != null)
                {
                    DeviceStateChanged(_state);
                }
            }
        }

        private async Task<string> boot_completed()
        {
            string res = await AdbAPI.adb("shell getprop sys.boot_completed", this.DeviceName);
            if (res != null)
            {
                res = res.Replace('\r'.ToString(), "").Replace('\n'.ToString(), "");
            }

            return res;
        }

        private async Task waitForBooted()
        {
            if (this.State == DeviceState.Disconnected)
            {
                return;
            }

            bool result = false;            

            string res = await boot_completed();

            if (res == "1")
            {
                this.State = DeviceState.ConnectedFullyBooted;
                if (DeviceStateChanged != null)
                {
                    DeviceStateChanged(_state);
                }
                result = true;
                return;
            }
            else
            {
                while (res != "1")
                {
                    res = await boot_completed();
                }

                if (res == "1")
                {
                    this.State = DeviceState.ConnectedFullyBooted;
                    if (DeviceStateChanged != null)
                    {
                        DeviceStateChanged(_state);
                    }
                }
            }
        }

        public void FireEvents()
        {
            if (DeviceStateChanged != null)
            {
                DeviceStateChanged(_state);
            }
        }
    }
}
