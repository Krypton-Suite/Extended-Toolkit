using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using System;
using System.Collections.ObjectModel;

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
