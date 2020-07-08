using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("B2745EFD-42CE-48CA-81F1-A96E02538A90"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpPhoneticAlphabetSelection
    {
        void IsAlphabetUPS([MarshalAs(UnmanagedType.Bool)] out bool pfIsUPS);

        void SetAlphabetToUPS([MarshalAs(UnmanagedType.Bool)] bool fForceUPS);
    }
}