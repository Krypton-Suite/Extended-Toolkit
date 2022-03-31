#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
    [Serializable]
    internal class SrgsItemList : Collection<SrgsItem>
    {
        protected override void InsertItem(int index, SrgsItem item)
        {
            Helpers.ThrowIfNull(item, "item");
            base.InsertItem(index, item);
        }
    }
}
