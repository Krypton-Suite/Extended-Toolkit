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
