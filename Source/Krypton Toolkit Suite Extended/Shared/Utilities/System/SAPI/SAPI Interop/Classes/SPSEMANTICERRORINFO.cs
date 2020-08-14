using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [StructLayout(LayoutKind.Sequential)]
    internal class SPSEMANTICERRORINFO
    {
        internal uint ulLineNumber;

        internal uint pszScriptLineOffset;

        internal uint pszSourceOffset;

        internal uint pszDescriptionOffset;

        internal int hrResultCode;
    }
}