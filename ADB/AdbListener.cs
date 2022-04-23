using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADB
{
    public delegate Task AdbDevicesChangedDel(string[] deviceList);

    public class AdbListener
    {
        private string[] _lastDeviceList = null;
        public event AdbDevicesChangedDel AdbDevicesChanged;

        private AdbAPI api;
        private Task PollingTask;

        public AdbListener()
        {
            api = new AdbAPI();
            getInitalDeviceList();
        }

        CancellationTokenSource s_cts = new CancellationTokenSource();


        public void StartPolling()
        {
            if (PollingTask == null)
            {
                s_cts = new CancellationTokenSource();
                PollingTask = Task.Run(() => Api_PollDeviceList(), s_cts.Token);
            }
            else
            {
                if (PollingTask.Status != TaskStatus.Running)
                {
                    s_cts = new CancellationTokenSource();
                    PollingTask = Task.Run(() => Api_PollDeviceList(), s_cts.Token);
                }
            }
            
        }

        public void StopPolling()
        {
            if (PollingTask != null)
            {
                if (PollingTask.Status == TaskStatus.Running)
                {
                    s_cts.Cancel();
                }
            }
        }

        private void getInitalDeviceList()
        {
            AdbAPI.GetDeviceListEvent += Api_GetDeviceListEvent;
            Task.Run(() => AdbAPI.GetDeviceList());
        }

        private void Api_GetDeviceListEvent(string[] deviceList)
        {
            _lastDeviceList = deviceList;
            AdbAPI.GetDeviceListEvent -= Api_GetDeviceListEvent;
        }

        private async Task Api_PollDeviceList()
        {
            while (true)
            {
                if (s_cts.IsCancellationRequested)
                {
                    break;
                }
                string[] devices = await AdbAPI.GetDeviceList();
                bool isEqual = Enumerable.SequenceEqual(devices, _lastDeviceList);
                if (isEqual)
                {
                    continue;
                }
                else
                {
                    if (AdbDevicesChanged != null)
                    {
                        _lastDeviceList = devices;
                        await AdbDevicesChanged(devices);
                    }
                }
            }
        }
    }
}
