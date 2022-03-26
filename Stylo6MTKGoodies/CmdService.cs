using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.Threading;

namespace Stylo6MTKGoodies
{
    public class CmdService : IDisposable
    {
        private Process _cmdProcess;

        private TextBoxLogger _logger;

        private BackgroundWorker _cmdWorker;

        private TaskKiller _taskKiller;

        public event EventHandler <EventArgs> CommandCompleted;

        public CmdService(string cmdPath, TextBox log)
        {
            _taskKiller = new TaskKiller();
            _logger = new TextBoxLogger(log);
            _cmdWorker = new BackgroundWorker();
            _cmdWorker.WorkerSupportsCancellation = true;
            _cmdWorker.WorkerReportsProgress = true;
            _cmdWorker.DoWork += _cmdWorker_DoWork;
            _cmdWorker.RunWorkerCompleted += _cmdWorker_RunWorkerCompleted;
        }

        public CmdService(string cmdPath, RichTextBox log)
        {
            _taskKiller = new TaskKiller();
            _logger = new TextBoxLogger(log);
            _cmdWorker = new BackgroundWorker();
            _cmdWorker.WorkerSupportsCancellation = true;
            _cmdWorker.WorkerReportsProgress = true;
            _cmdWorker.DoWork += _cmdWorker_DoWork;
            _cmdWorker.RunWorkerCompleted += _cmdWorker_RunWorkerCompleted;
        }

        private void _cmdWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _logger.Log(Environment.NewLine + "Command completed! Unplug usb cable then run next command." + Environment.NewLine);
            if (CommandCompleted != null)
            {
                CommandCompleted(sender, e);
            }
        }

        public void Cancel()
        {
            t.Cancel();
            if (_cmdWorker != null && _cmdProcess != null)
            {
                if (!_cmdProcess.HasExited)
                {
                    _cmdWorker.CancelAsync();
                }
            }
        }

        CancellationTokenSource t = new CancellationTokenSource();

        private async Task<int> SPFlashTool(string args, int timeout)
        {
            Process process = new Process();
            //Cursor.Current = Cursors.WaitCursor;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c " + args;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WorkingDirectory = Application.StartupPath + @"\mtkclient\SPFlashTool";
            process.Start();
            t.Token.Register(() =>
            {
                if (!process.HasExited)
                {
                    _taskKiller.ExecuteCommand("flash_tool.exe");
                }
            });
            int result = await process.WaitForExitAsync();

            return result;
        }

        
        private void _cmdWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument.ToString() == "payload")
            {
                t = new CancellationTokenSource();

                _logger.Log("Waiting for device!..." + Environment.NewLine);
                _logger.Log("Please connect usb cable to device after it has been powered off." + Environment.NewLine);
                _logger.Log("Do not press any hardware buttons!" + Environment.NewLine);

                Task<int> spflashResponse = SPFlashTool("flash_tool.exe -i stallBrom.xml", 10000);

                if (spflashResponse.Result == 1)
                {
                    _logger.Log("Processing!..." + Environment.NewLine + Environment.NewLine);

                    ProcessStartInfo processStartInfo = new ProcessStartInfo();
                    processStartInfo.FileName = "cmd.exe";
                    processStartInfo.Arguments = "/c " + Application.StartupPath + @"\mtkclient\python3\python.exe " + Application.StartupPath + @"\mtkclient\mtk payload";
                    processStartInfo.UseShellExecute = false;
                    processStartInfo.RedirectStandardOutput = true;
                    processStartInfo.RedirectStandardInput = true;
                    processStartInfo.WorkingDirectory = Application.StartupPath + @"\mtkclient";
                    processStartInfo.CreateNoWindow = true;

                    _cmdProcess = Process.Start(processStartInfo);
                    _cmdProcess.EnableRaisingEvents = true;
                    _cmdProcess.OutputDataReceived += _cmdProcess_OutputDataReceived;
                    _cmdProcess.ErrorDataReceived += _cmdProcess_ErrorDataReceived;
                    _cmdProcess.BeginOutputReadLine();

                    while (_cmdProcess.HasExited == false && _cmdWorker.CancellationPending == false)
                    {
                        if (payloadSent == true)
                        {
                            payloadSent = false;
                            break;
                        }
                            Application.DoEvents();
                    }

                    e.Cancel = true;
                    _cmdProcess.CancelOutputRead();
                    _taskKiller.ExecuteCommand("python.exe");
                    _cmdProcess?.Close();
                    _cmdProcess = null;
                    return;
                }
                else
                {
                    _logger.Log(spflashResponse + "\n");
                }
            }
            else
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = "cmd.exe";
                processStartInfo.WorkingDirectory = Application.StartupPath + @"\mtkclient";
                processStartInfo.Arguments = "/c " + Application.StartupPath + @"\mtkclient\python3\python.exe mtk " + e.Argument.ToString();
                processStartInfo.UseShellExecute = false;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.RedirectStandardInput = true;
                
                processStartInfo.CreateNoWindow = true;

                _cmdProcess = Process.Start(processStartInfo);
                _cmdProcess.EnableRaisingEvents = true;
                _cmdProcess.OutputDataReceived += _cmdProcess_OutputDataReceived;
                _cmdProcess.ErrorDataReceived += _cmdProcess_ErrorDataReceived;

                _cmdProcess.BeginOutputReadLine();

                while (_cmdProcess.HasExited == false && _cmdWorker.CancellationPending == false)
                {
                    Application.DoEvents();
                }

                e.Cancel = true;
                _cmdProcess.CancelOutputRead();
                _taskKiller.ExecuteCommand("python.exe");
                _cmdProcess?.Close();
                _cmdProcess = null;
                return;
            }
        }

        private void _cmdProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data) == false)
            {
                _logger.Log(e.Data + Environment.NewLine);
            }
        }

        public void ExecuteCommand(string command)
        {
            // Clears the log every time a new command is ran
            _logger.Clear();

            _cmdWorker?.Dispose();
            _cmdWorker = new BackgroundWorker();
            _cmdWorker.WorkerSupportsCancellation = true;
            _cmdWorker.DoWork += _cmdWorker_DoWork;
            _cmdWorker.RunWorkerCompleted += _cmdWorker_RunWorkerCompleted;

            _cmdWorker.RunWorkerAsync(command);
        }

        bool payloadSent = false;
        private void _cmdProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(e.Data) == false)
            {
                if (e.Data.Contains("PLTools - Successfully sent payload"))
                {
                    payloadSent = true;                    
                }

                _logger.Log(e.Data + Environment.NewLine);
            }
        }

        public void Dispose()
        {
            if (_cmdProcess != null)
            {
                _cmdProcess.Close();
                _cmdProcess.Dispose();
            }
            if (_cmdWorker != null)
            {
                //if (_cmdWorker.IsBusy == true)
                {
                    _cmdWorker.CancelAsync();
                    _taskKiller.ExecuteCommand("python.exe");
                    while (_cmdWorker.IsBusy) Application.DoEvents();

                    _cmdWorker.Dispose();
                    _cmdWorker = null;
                }
            }
        }
    }
}
