using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stylo6MTKGoodies
{
    public class Stylo6
    {
        public event EventHandler CommandCompleted;

        private CmdService cmdService;
        public Stylo6(TextBox outputBox)
        {
            cmdService = new CmdService("cmd.exe", outputBox);
            cmdService.CommandCompleted += CmdService_CommandCompleted;
        }

        private void CmdService_CommandCompleted(object sender, EventArgs e)
        {
            if (this.CommandCompleted != null)
            {
                CommandCompleted(sender, e);
            }
        }

        public void ForceBrom(bool delay)
        {
            if (cmdService != null)
            {
                // python mtk payload
                cmdService.ExecuteCommand("payload", delay);
            }
        }

        public void ForceBrom()
        {            
            if (cmdService != null)
            {
                // python mtk payload
                cmdService.ExecuteCommand("payload", true);
            }
        }

        public void UnlockBootloader()
        {
            // python mtk da seccfg unlock
            // python mtk xflash seccfg unlock
            if (cmdService != null)
            {
                // New version bootloader unlock command
                cmdService.ExecuteCommand("da seccfg unlock");

                // Old version bootloader unlock command
                //cmdService.ExecuteCommand("xflash seccfg unlock");
            }
        }

        public void LockBootloader()
        {
            // python mtk da seccfg lock
            // python mtk xflash seccfg lock
            if (cmdService != null)
            {
                // New version bootloader lock command
                cmdService.ExecuteCommand("da seccfg lock");

                // Old version bootloader lock command
                //cmdService.ExecuteCommand("xflash seccfg lock");
            }
        }

        public void Reboot()
        {
            if (cmdService != null)
            {
                // python mtk reset
                cmdService.ExecuteCommand("reset");
            }
        }

        public void ExecuteMTKCommand(string command)
        {
            if (cmdService != null)
            {
                // Execute mtk command
                cmdService.ExecuteCommand(command);
            }
        }

        public void Cancel()
        {
            if (cmdService != null)
            {
                cmdService.Cancel();
            }
        }

        public void Dispose()
        {
            if (cmdService != null)
            {
                cmdService.Dispose();
            }
        }
    }
}
