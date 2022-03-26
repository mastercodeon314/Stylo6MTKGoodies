using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Darkness
{
    public class MenuStrip : System.Windows.Forms.MenuStrip
    {
        public MenuStrip() : base()
        {
            this.Renderer = new MyRenderer();
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }

            protected override void OnRenderToolStripBorder(System.Windows.Forms.ToolStripRenderEventArgs e)
            {
                //e.Graphics.FillRectangle(Brushes.Gray, e.ConnectedArea);
                //e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(0, 1, e.AffectedBounds.Width - 2, e.AffectedBounds.Height - 3));
            }

            // Custom rendered to overcome bug in WindowsForms
            protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
            {
                var g = e.Graphics;
                var fillColor = (e.Item.Selected ? this.ColorTable.CheckSelectedBackground : this.ColorTable.CheckBackground);
                g.FillRectangle(new SolidBrush(fillColor), new Rectangle(3, 1, 19, 19));
                g.DrawRectangle(new Pen(new SolidBrush(this.ColorTable.ButtonCheckedHighlightBorder), 1), new Rectangle(3, 1, 19, 19));
                // Draw the check mark. (two lines)
                g.DrawLines(System.Drawing.Pens.Silver, new Point[] { new Point(10, 9), new Point(12, 11), new Point(16, 7) });
                g.DrawLines(System.Drawing.Pens.Silver, new Point[] { new Point(10, 10), new Point(12, 12), new Point(16, 8) });
                // base.OnRenderItemCheck(e); <-- **don't** let the base do its own rendering.

                /*var g = e.Graphics;
                var width = 19;
                var height = (int)(19 * DisplayScaleFactor.Height);
                var offset = 6;
                // Determine fillcolor of rectangle around check mark
                var fillColor = (e.Item.Selected ? this.ColorTable.CheckSelectedBackground : this.ColorTable.CheckBackground);
                var rectangle = new Rectangle(2, 0, width, height);

                using (var fillBrush = new SolidBrush(fillColor))
                {
                    g.FillRectangle(fillBrush, rectangle);
                }

                using (var highlightBrush = new SolidBrush(this.ColorTable.ButtonCheckedHighlightBorder))
                using (var highlightPen = new Pen(highlightBrush, 1))
                {
                    g.DrawRectangle(highlightPen, rectangle);
                }

                DrawCheckMark(g, 0 + offset);
                DrawCheckMark(g, 1 + offset);*/

                // base.OnRenderItemCheck(e); <-- don't do the underlying render.
            }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color ToolStripDropDownBackground
            {
                get
                {
                    return Color.FromArgb(255, 33, 33, 33);
                }
            }

            public override Color MenuStripGradientBegin => Color.FromArgb(40, 40, 40);
            public override Color MenuStripGradientEnd => Color.FromArgb(33, 33, 33);

            public override Color ButtonSelectedHighlight
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }
            public override Color ButtonSelectedGradientBegin
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }
            public override Color ButtonSelectedGradientEnd
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }

            public override Color ButtonSelectedGradientMiddle
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }

            public override Color ButtonPressedHighlight
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }

            public override Color ButtonPressedGradientBegin
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }
            public override Color ButtonPressedGradientEnd
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }
            public override Color ButtonPressedGradientMiddle
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }

            public override Color MenuItemSelected
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }

            public override Color MenuBorder
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }

            public override Color ImageMarginGradientMiddle
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }
            public override Color ImageMarginGradientBegin
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }
            public override Color ImageMarginGradientEnd
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }
            public override Color ImageMarginRevealedGradientMiddle
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }

            public override Color CheckBackground
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }
            public override Color CheckSelectedBackground
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }

            public override Color CheckPressedBackground
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }

            public override Color ButtonCheckedGradientBegin
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }
            public override Color ButtonCheckedGradientMiddle
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }
            public override Color ButtonCheckedGradientEnd
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }

            public override Color ButtonCheckedHighlight
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }

            public override Color ButtonCheckedHighlightBorder
            {
                get { return Color.FromArgb(255, 33, 33, 33); }
            }
        }
    }
}
