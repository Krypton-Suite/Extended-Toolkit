using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("8FCEBC98-4E49-4067-9C6C-D86A0E092E3D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpPhraseAlt : ISpPhrase
    {
        new void GetPhrase(out IntPtr ppCoMemPhrase);

        new void GetSerializedPhrase(out IntPtr ppCoMemPhrase);

        new void GetText(uint ulStart, uint ulCount, [MarshalAs(UnmanagedType.Bool)] bool fUseTextReplacements, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemText, out byte pbDisplayAttributes);

        new void Discard(uint dwValueTypes);

        void GetAltInfo(out ISpPhrase ppParent, out uint pulStartElementInParent, out uint pcElementsInParent, out uint pcElementsInAlt);

        void Commit();
    }
}