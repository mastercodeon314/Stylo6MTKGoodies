using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADB;

namespace COMPortScanner
{
    public partial class AdbTesting : Form
    {
        private Adb Adb;
        private AdbDevice SelectedDevice;

        public AdbTesting()
        {
            InitializeComponent();
            this.Load += AdbTesting_Load;
        }

        private void AdbTesting_Load(object sender, EventArgs e)
        {
            Adb = new Adb();
            Adb.DevicesChanged += Adb_DevicesChanged;
            Adb.InitalStatusCheck();            
        }

        private void Adb_DevicesChanged()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => Adb_DevicesChanged()));
            }
            else
            {
                updateDeviceBox();
                string[] savedDevs = Adb.GetSavedDeviceNames();
                List<string> comboDevs = new List<string>();
                
                foreach (string dev in comboBox1.Items)
                {
                    comboDevs.Add(dev);
                }

                if (Enumerable.SequenceEqual(savedDevs, comboDevs.ToArray()) == false)
                {
                    if (comboBox1.Items.Count == 0)
                    {
                        comboBox1.Items.Clear();

                        foreach (AdbDevice device in Adb.SavedAdbDevices)
                        {
                            comboBox1.Items.Add(device.DeviceName);
                        }

                        if (comboBox1.SelectedIndex == -1 && comboBox1.Items.Count > 0)
                        {
                            comboBox1.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        comboBox1.Items.Clear();

                        foreach (AdbDevice device in Adb.SavedAdbDevices)
                        {
                            comboBox1.Items.Add(device.DeviceName);
                        }
                    }
                }
                
            }
        }

        private void updateDeviceBox()
        {
            deviceBox.Items.Clear();

            foreach (AdbDevice device in Adb.SavedAdbDevices)
            {
                if (device.State == DeviceState.ConnectedNotBooted || device.State == DeviceState.ConnectedFullyBooted)
                {
                    deviceBox.Items.Add(device.DeviceName);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SelectedDevice != null)
            {
                this.SelectedDevice.DeviceStateChanged -= SelectedDevice_DeviceStateChanged;
            }
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() != "")
                {
                    foreach (AdbDevice dev in Adb.SavedAdbDevices)
                    {
                        if (dev.DeviceName == comboBox1.SelectedItem.ToString())
                        {
                            if (this.SelectedDevice != null)
                            {
                                if (this.SelectedDevice.DeviceName == comboBox1.SelectedItem.ToString())
                                {
                                    return;
                                }
                                else
                                {
                                    this.SelectedDevice = dev;
                                    this.SelectedDevice.DeviceStateChanged += SelectedDevice_DeviceStateChanged;
                                    this.SelectedDevice.FireEvents();
                                }
                            }
                            else
                            {
                                this.SelectedDevice = dev;
                                this.SelectedDevice.DeviceStateChanged += SelectedDevice_DeviceStateChanged;
                                this.SelectedDevice.FireEvents();
                            }
                            
                        }
                    }
                }
            }
        }

        private Task SelectedDevice_DeviceStateChanged(DeviceState state)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SelectedDevice_DeviceStateChanged(state)));
            }
            else
            {
                switch (state)
                {
                    case DeviceState.Disconnected:
                    {
                        attachedBox.Checked = false;
                        bootedBox.Checked = false;
                        break;
                    }
                    case DeviceState.ConnectedNotBooted:
                    {
                        attachedBox.Checked = true;
                        bootedBox.Checked = false;
                        break;
                    }
                    case DeviceState.ConnectedFullyBooted:
                    {
                        bootedBox.Checked = true;
                        attachedBox.Checked = true;
                        break;
                    }
                }

                updateDeviceBox();
            }

            return null;
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (this.SelectedDevice != null)
            {
                if (this.SelectedDevice.State == DeviceState.ConnectedNotBooted || this.SelectedDevice.State == DeviceState.ConnectedFullyBooted)
                {
                    if (this.commandBox.Text != "")
                    {
                        string res = this.SelectedDevice.ExecuteCommand(this.commandBox.Text);
                        this.outputBox.Text = res;
                    }                    
                }
            }
        }
    }
}
