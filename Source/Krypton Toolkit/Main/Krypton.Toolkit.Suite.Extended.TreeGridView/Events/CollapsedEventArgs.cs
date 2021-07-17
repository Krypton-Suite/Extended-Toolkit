#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.TreeGridView
{
    public class CollapsedEventArgs : TreeGridNodeEventBase
    {
        public CollapsedEventArgs(KryptonTreeGridNodeRow node)
            : base(node)
        {
        }
    }
}