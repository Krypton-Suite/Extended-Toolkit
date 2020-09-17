using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    public class ToolStripControlHostFixed : ToolStripControlHost
    {
        public ToolStripControlHostFixed() : base(new Control())
        {

        }

        public ToolStripControlHostFixed(Control c) : base(c)
        {

        }
    }
}