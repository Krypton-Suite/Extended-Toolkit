using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Core
{
    public class ToolStripControlHostFixed : ToolStripControlHost
    {
        public ToolStripControlHostFixed() : base(new Control())
        {

        }

        public ToolStripControlHostFixed(Control control) : base(control)
        {

        }
    }
}