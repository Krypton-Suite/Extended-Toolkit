using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("88A3342A-0BED-4834-922B-88D43173162F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpPhraseBuilder : ISpPhrase
    {
        new void GetPhrase(out IntPtr ppCoMemPhrase);

        new void GetSerializedPhrase(out IntPtr ppCoMemPhrase);

        new void GetText(uint ulStart, uint ulCount, [MarshalAs(UnmanagedType.Bool)] bool fUseTextReplacements, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemText, out byte pbDisplayAttributes);

        new void Discard(uint dwValueTypes);

        void InitFromPhrase(SPPHRASE pPhrase);

        void Slot6();

        void Slot7();

        void Slot8();

        void Slot9();

        void Slot10();
    }
}
