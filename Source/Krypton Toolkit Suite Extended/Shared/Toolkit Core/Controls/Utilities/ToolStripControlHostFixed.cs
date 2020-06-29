using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Core
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