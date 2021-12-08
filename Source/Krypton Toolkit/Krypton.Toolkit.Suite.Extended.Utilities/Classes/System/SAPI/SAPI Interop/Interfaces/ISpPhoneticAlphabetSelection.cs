#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("B2745EFD-42CE-48CA-81F1-A96E02538A90"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpPhoneticAlphabetSelection
    {
        void IsAlphabetUPS([MarshalAs(UnmanagedType.Bool)] out bool pfIsUPS);

        void SetAlphabetToUPS([MarshalAs(UnmanagedType.Bool)] bool fForceUPS);
    }
}