using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    /// <summary></summary>
    public class ControlHelper
    {
        /// <summary>Initializes a new instance of the <see cref="ControlHelper"/> class.</summary>
        public ControlHelper()
        {

        }

        /// <summary>Relocates the selected control.</summary>
        /// <param name="control">The control.</param>
        /// <param name="location">The location.</param>
        public static void RelocateSelectedControl(Control control, Point location) => control.Location = location;
    }
}