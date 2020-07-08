using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [StructLayout(LayoutKind.Sequential)]
    internal class SPPHRASEREPLACEMENT
    {
        internal byte bDisplayAttributes;

        internal uint pszReplacementText;

        internal uint ulFirstElement;

        internal uint ulCountOfElements;
    }
}