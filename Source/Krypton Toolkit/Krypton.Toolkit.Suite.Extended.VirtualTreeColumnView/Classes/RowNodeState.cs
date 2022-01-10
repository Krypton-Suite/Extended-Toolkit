#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView
{
    [Flags]
    public enum RowNodeState
    {
        None = 0, // Collapsed -> Default
        Expanded = 1,
        Disabled = 1 << 2,
        Selected = 1 << 3,
        Checked = 1 << 4,
        Tracking = 1 << 5,
        Pressed = 1 << 6    // For the headers only
    }
}
