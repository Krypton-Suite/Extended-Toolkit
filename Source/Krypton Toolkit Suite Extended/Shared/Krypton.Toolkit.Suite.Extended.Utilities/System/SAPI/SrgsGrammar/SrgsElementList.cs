#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using System;
using System.Collections.ObjectModel;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
    [Serializable]
    internal class SrgsElementList : Collection<SrgsElement>
    {
        protected override void InsertItem(int index, SrgsElement element)
        {
            Helpers.ThrowIfNull(element, "element");
            base.InsertItem(index, element);
        }
    }
}
