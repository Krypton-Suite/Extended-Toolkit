using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
    [TypeLibType(16)]
    internal struct SPVCONTEXT
    {
        public IntPtr pCategory;

        public IntPtr pBefore;

        public IntPtr pAfter;
    }
}
