using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stylo6MTKGoodiesInstaller.Logic;

namespace Stylo6MTKGoodiesInstaller.Pages
{
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
            this.Tag = "WelcomePage";
            this.Size = new Size(541, 340);
            this.NoBanner = true;
            this.logoBox.SizeMode = PictureBoxSizeMode.StretchImage;

            //var oldParent = this;
            //var newParent = logoBox;

            //foreach (var label in oldParent.Controls.OfType<Label>())
            //{
            //    label.Location = newParent.PointToClient(label.Parent.PointToScreen(label.Location));
            //    label.Parent = newParent;
            //    label.BackColor = Color.Transparent;
            //}
        }
    }
}
