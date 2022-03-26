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
    public class TaskKiller : IDisposable
    {
        private Process _cmdProcess;

        private BackgroundWorker _cmdWorker;

        public TaskKiller()
        {
            _cmdWorker = new BackgroundWorker();
            _cmdWorker.WorkerSupportsCancellation = true;
            _cmdWorker.WorkerReportsProgress = true;
            _cmdWorker.DoWork += _cmdWorker_DoWork;
            Application.ThreadExit += Application_ThreadExit;
        }

        private void Application_ThreadExit(object sender, EventArgs e)
        {
            //this.Dispose();
        }

        public void Cancel()
        {
            if (_cmdWorker != null)
            {
                if (!_cmdProcess.HasExited)
                {
                    _cmdWorker.CancelAsync();
                }
            }
        }
        private void _cmdWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            if (_cmdProcess != null)
            {
                if (!_cmdProcess.HasExited)
                {
                    _cmdProcess.Kill();
                    _cmdProcess.Dispose();
                }
            }

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "taskkill";
            processStartInfo.Arguments = "/IM " + e.Argument.ToString() + " /F";
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardOutput = true;
            _cmdProcess = Process.Start(processStartInfo);

            string output = _cmdProcess.StandardOutput.ReadToEnd();

            e.Cancel = true;
            if (_cmdProcess.HasExited == false)
            {
                _cmdProcess.Close();
            }
        }

        public void ExecuteCommand(string command)
        {
            // Clears the buffer every time a new command is ran
            //_cmdOutput = String.Empty;

            _cmdWorker = new BackgroundWorker();
            _cmdWorker.WorkerSupportsCancellation = true;
            _cmdWorker.DoWork += _cmdWorker_DoWork;

            _cmdWorker.RunWorkerAsync(command);
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
                _cmdWorker.CancelAsync();

                while (_cmdWorker.IsBusy) Application.DoEvents();

                _cmdWorker.Dispose();
                _cmdWorker = null;
            }
        }
    }
}
