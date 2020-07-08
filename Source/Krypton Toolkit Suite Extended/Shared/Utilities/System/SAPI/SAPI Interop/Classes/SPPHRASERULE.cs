using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    internal class SPPHRASERULE
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        internal string pszName;

        internal uint ulId;

        internal uint ulFirstElement;

        internal uint ulCountOfElements;

        internal IntPtr pNextSibling;

        internal IntPtr pFirstChild;

        internal float SREngineConfidence;

        internal byte Confidence;
    }
}