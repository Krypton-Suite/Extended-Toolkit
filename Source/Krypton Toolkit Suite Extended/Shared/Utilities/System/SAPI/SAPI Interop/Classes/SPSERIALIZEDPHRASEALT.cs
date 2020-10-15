using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [StructLayout(LayoutKind.Sequential)]
    internal class SPSERIALIZEDPHRASEALT
    {
        internal uint ulStartElementInParent;

        internal uint cElementsInParent;

        internal uint cElementsInAlternate;

        internal uint cbAltExtra;
    }
}