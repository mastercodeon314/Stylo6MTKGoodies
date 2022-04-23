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
    public partial class Page : UserControl
    {
        public bool NoBanner = false;
        public Page()
        {
            InitializeComponent();

            this.Size = new Size(541, 244);
            this.Location = new Point(12, 80);
        }

        public Banner parentBanner = null;
        public Page(Banner prntBanner)
        {
            InitializeComponent();

            parentBanner = prntBanner;

            this.Size = new Size(541, 244);
            this.Location = new Point(12, 80);
        }

        public virtual void ChangeBannerText()
        {

        }
    }
}
