using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("5B559F40-E952-11D2-BB91-00C04F8EE6C0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpObjectWithToken
    {
        [PreserveSig]
        int SetObjectToken(ISpObjectToken pToken);

        [PreserveSig]
        int GetObjectToken(out ISpObjectToken ppToken);
    }
}