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
    public partial class frmAbout : Form
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

        public frmAbout()
        {
            InitializeComponent();

            appIcon1.SetDragForm(this);
            dragBar1.SetDragForm(this);
            dragBar2.SetDragForm(this);

            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.DoubleBuffered = true;

            infoBox.TextAlign = HorizontalAlignment.Center;

            this.VisibleChanged += FrmAbout_VisibleChanged;

            
        }

        private void FrmAbout_VisibleChanged(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
