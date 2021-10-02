#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.TreeGridView
{
    public class CollapsingEventArgs : System.ComponentModel.CancelEventArgs
    {
        public CollapsingEventArgs(KryptonTreeGridNodeRow node) => Node = node;

        public KryptonTreeGridNodeRow Node { get; }
    }
}