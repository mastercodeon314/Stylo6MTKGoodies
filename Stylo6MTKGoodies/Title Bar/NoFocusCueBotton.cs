using System.ComponentModel;
using System.Windows.Forms;

namespace Stylo6MTKGoodies.TitleBar
{
    /// <summary>
    /// Modified button which has no focus rectangles when the form which contains this button loses fucus while the button was focused.
    /// </summary>
    [ToolboxItem(typeof(NoFocusCueBotton))]
    public class NoFocusCueBotton : Button
    {
        protected override bool ShowFocusCues => false;

        /// <summary>
        /// Creates a new instance of a <see cref="NoFocusCueBotton"/>
        /// </summary>
        public NoFocusCueBotton() { }

        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(false);
        }
    }
}