#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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