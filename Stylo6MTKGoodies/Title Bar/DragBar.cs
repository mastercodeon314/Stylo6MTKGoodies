using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Stylo6MTKGoodies.TitleBar
{
    public class DragBar : Panel
    {
        private bool drag = false; // determine if we should be moving the form
        private Point startPoint = new Point(0, 0); // also for the moving
        Form dragForm = null;

        public void SetDragForm(Form form)
        {
            if (this.DesignMode == true)
            {
                //this.BackColor = Color.Gray;
            }
            else
            {
                dragForm = form;
                //this.BackColor = dragForm.BackColor;
            }
        }

        public DragBar()
        {
            this.MouseDown += AmgAppLogo_MouseDown;
            this.MouseUp += AmgAppLogo_MouseUp;
            this.MouseMove += AmgAppLogo_MouseMove;
        }

        private void AmgAppLogo_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            { // if we should be dragging it, we need to figure out some movement
                Point p1 = new Point(e.X, e.Y);
                Point p2 = dragForm.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.startPoint.X,
                                     p2.Y - this.startPoint.Y);
                dragForm.Location = p3;
            }
        }

        private void AmgAppLogo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.drag = false;
            }
        }

        private void AmgAppLogo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.startPoint = e.Location;
                this.drag = true;
            }
        }
    }
}
