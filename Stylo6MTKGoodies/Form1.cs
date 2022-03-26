using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stylo6MTKGoodies
{
    public partial class MainForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
(
    int nLeftRect,     // x-coordinate of upper-left corner
    int nTopRect,      // y-coordinate of upper-left corner
    int nRightRect,    // x-coordinate of lower-right corner
    int nBottomRect,   // y-coordinate of lower-right corner
    int nWidthEllipse, // width of ellipse
    int nHeightEllipse // height of ellipse
);

        public static MainForm Instance = null;

        Stylo6 stylo6;

        public MainForm()
        {
            Instance = this;
            InitializeComponent();           

            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            stylo6 = new Stylo6(outputBox);
            stylo6.CommandCompleted += CmdService_CommandCompleted;
            this.FormClosing += MainForm_FormClosing;
            this.DoubleBuffered = true;
        }

        private void CmdService_CommandCompleted(object sender, EventArgs e)
        {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.Enabled = true;
            }
        }

        private void DisableAllCommandButtons()
        {
            forceBromBtn.Enabled = false;
            blUnlockBtn.Enabled = false;
            rebootBtn.Enabled = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stylo6.Dispose();
        }

        private void forceBromBtn_Click(object sender, EventArgs e)
        {
            stylo6.ForceBrom();
            DisableAllCommandButtons();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            stylo6.Cancel();
        }

        private void blUnlockBtn_Click(object sender, EventArgs e)
        {
            stylo6.UnlockBootloader();
            //DisableAllCommandButtons();
        }

        private void rebootBtn_Click(object sender, EventArgs e)
        {
            stylo6.ExecuteMTKCommand("reset");
            DisableAllCommandButtons();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
