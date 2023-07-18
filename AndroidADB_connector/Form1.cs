using AndroidADB_connector.Data;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using Timer = System.Windows.Forms.Timer;

namespace AndroidADB_connector
{
    public partial class Form1 : Form
    {
        private List<ADB_Device> devices;
        private ADB_Device? selectedDevice;
        private string tmpLine = "";
        private bool exited = false;

        private Timer timer;

        private static readonly string originalTitle = "ADB Connector";

        public Form1()
        {
            InitializeComponent();
            this.Text = originalTitle;

            devices = new List<ADB_Device>();

            loadingPanel.Dock = DockStyle.Fill;
            loadingPanel.Visible = false;

            timer = new Timer();
            timer.Interval = 2500;
            timer.Tick += timer_Tick;

            btnRefresh_Click(null, null);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Text = "Refreshing device list...";
            loadingPanel.Visible = true;

            await Task.Run(() =>
            {
                RefreshDevices();
            });

            dgDevices.DataSource = devices;
            loadingPanel.Visible = false;
            this.Text = originalTitle;
            tbPort.Text = "";
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (selectedDevice != null)
            {
                var port = string.IsNullOrEmpty(tbPort.Text) ? selectedDevice.Port.ToString() : tbPort.Text;
                if (!string.IsNullOrEmpty(port))
                {
                    this.Text = "Connecting device...";
                    loadingPanel.Visible = true;

                    bool result = await Task<bool>.Run(() =>
                    {
                        return ConnectDevice(int.Parse(port));
                    });

                    if (!result)
                        MessageBox.Show("Unable to connect selected device.");
                    else
                    {
                        selectedDevice.Port = int.Parse(port);
                        selectedDevice.Status = true;

                        var dev = devices.Find(dev => dev.DeviceID == selectedDevice.DeviceID);

                        if (dev != null)
                        {
                            dev.Port = int.Parse(port);
                            dev.Status = true;
                        }

                        dgDevices.Refresh();
                        tbPort.Text = "";
                    }

                    loadingPanel.Visible = false;
                    this.Text = originalTitle;
                } else
                {
                    this.Text = "No port was given!";
                    timer.Start();
                }
            } else
            {
                this.Text = "No device was selected!";
                timer.Start();
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            this.Text = "Disconnecting all...";

            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };
            p.StartInfo = startInfo;

            p.Start();

            p.StandardInput.WriteLine($"adb disconnect");
            p.StandardInput.WriteLine("exit");
            exited = p.WaitForExit(1000);
            if (!exited)
                p.Kill();

            tmpLine = p.StandardOutput.ReadToEnd();

            p.Dispose();

            btnRefresh_Click(null, null);
        }

        private void dgDevices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDevices.SelectedRows.Count > 0)
            {
                selectedDevice = (ADB_Device)dgDevices.SelectedRows[0].DataBoundItem;
                tbPort.Focus();
            }
            else
            {
                selectedDevice = null;
            }
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Text = originalTitle;
        }

        private void tbPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void RefreshDevices()
        {
            devices = new List<ADB_Device>();

            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };
            p.StartInfo = startInfo;

            p.Start();

            p.StandardInput.WriteLine("adb devices -l");
            p.StandardInput.WriteLine("exit");
            exited = p.WaitForExit(1000);
            if (!exited)
                p.Kill();

            tmpLine = p.StandardOutput.ReadToEnd();

            // pridobim IDs
            List<string> id_output = new List<string>(tmpLine.Split("\r\n", StringSplitOptions.RemoveEmptyEntries));
            foreach (var entry in id_output)
            {
                if ((!entry.Contains("unauthorized") && Regex.IsMatch(entry, @"^\S+\s+device product:\S+\smodel:\S+\s+|device:\S+\s+\S+")))
                {
                    var match = Regex.Match(entry, @"^(\S+)\s+device product:");

                    if (match.Success)
                    {
                        // I know that device is connected
                        if (match.Groups[1].Value.Contains(":"))
                        {
                            string[] ip_port = match.Groups[1].Value.Split(":");

                            p.Start();
                            p.StandardInput.WriteLine($"adb -s {match.Groups[1].Value} shell getprop ro.serialno");
                            p.StandardInput.WriteLine("exit");
                            exited = p.WaitForExit(1000);
                            if (!exited)
                                p.Kill();

                            tmpLine = p.StandardOutput.ReadToEnd();
                            var devSer = Regex.Match(tmpLine, @"ro\.serialno\s+(.*)").Groups[1].Value;
                            devSer = Regex.Replace(devSer, "[^a-zA-Z0-9_.-]+", "", RegexOptions.Compiled);

                            var dev = devices.Find(dev => dev.DeviceID == devSer);

                            if (dev != null)
                            {
                                dev.IP = ip_port[0];
                                dev.Port = int.Parse(ip_port[1]);
                                continue;
                            } else
                            {
                                devices.Add(new ADB_Device() { DeviceID = devSer });
                            }
                        } else
                        {
                            devices.Add(new ADB_Device() { DeviceID = match.Groups[1].Value });
                        }

                        var device = devices.Last();

                        AddAdditionalInfo(device);
                    }
                }
            }

            p.StandardOutput.Close();
            p.StandardInput.Close();
            exited = p.WaitForExit(1000);
            if (!exited)
                p.Kill();

            p.Dispose();
        }

        private void AddAdditionalInfo(ADB_Device device)
        {
            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };
            p.StartInfo = startInfo;

            p.Start();
            p.StandardInput.WriteLine($"adb -s {device.DeviceID} shell getprop ro.product.model");
            p.StandardInput.WriteLine("exit");
            exited = p.WaitForExit(1000);
            if (!exited)
                p.Kill();

            tmpLine = p.StandardOutput.ReadToEnd();
            var match = Regex.Match(tmpLine, @"ro\.product\.model\s+(.*)");
            if (match.Success)
            {
                device.DeviceName = match.Groups[1].Value.Trim();
            }
            else
            {
                device.DeviceName = "Unknown device";
            }

            p.Start();
            p.StandardInput.WriteLine($"adb -s {device.DeviceID} shell ip route");
            p.StandardInput.WriteLine("exit");
            exited = p.WaitForExit(1000);
            if (!exited)
                p.Kill();

            tmpLine = p.StandardOutput.ReadToEnd();
            device.IP = Regex.Match(tmpLine, @"\b(?:\d{1,3}\.){3}\d{1,3}\b(?!\/[0-9]{2})").Value;

            device.Port = -1;
            device.Status = false;
        }

        private bool ConnectDevice(int port)
        {
            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };
            p.StartInfo = startInfo;

            p.Start();
            // start adb on device
            p.StandardInput.WriteLine($"adb -s {selectedDevice.DeviceID} tcpip {port}");

            // connect the device
            p.StandardInput.WriteLine($"adb connect {selectedDevice.IP}:{port}");
            p.StandardInput.WriteLine("exit");
            exited = p.WaitForExit(1000);
            if (!exited)
                p.Kill();

            tmpLine = p.StandardOutput.ReadToEnd();

            p.Dispose();

            return tmpLine.Contains("connected");
        }
    }
}