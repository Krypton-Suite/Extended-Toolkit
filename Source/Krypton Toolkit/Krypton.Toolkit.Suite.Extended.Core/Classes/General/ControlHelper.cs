#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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