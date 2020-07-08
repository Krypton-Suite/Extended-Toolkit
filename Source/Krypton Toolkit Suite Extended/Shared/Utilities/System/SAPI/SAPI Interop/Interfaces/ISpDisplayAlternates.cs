using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("C8D7C7E2-0DDE-44b7-AFE3-B0C991FBEB5E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpDisplayAlternates
    {
        void GetDisplayAlternates(IntPtr pPhrase, uint cRequestCount, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] ppCoMemPhrases, out uint pcPhrasesReturned);
    }
}