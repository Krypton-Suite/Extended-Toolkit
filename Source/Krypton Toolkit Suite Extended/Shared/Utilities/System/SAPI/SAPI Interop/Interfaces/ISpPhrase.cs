using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("1A5C0354-B621-4b5a-8791-D306ED379E53"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpPhrase
    {
        void GetPhrase(out IntPtr ppCoMemPhrase);

        void GetSerializedPhrase(out IntPtr ppCoMemPhrase);

        void GetText(uint ulStart, uint ulCount, [MarshalAs(UnmanagedType.Bool)] bool fUseTextReplacements, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemText, out byte pbDisplayAttributes);

        void Discard(uint dwValueTypes);
    }
}