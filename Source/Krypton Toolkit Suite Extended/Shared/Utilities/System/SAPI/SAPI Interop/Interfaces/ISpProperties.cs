using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("5B4FB971-B115-4DE1-AD97-E482E3BF6EE4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpProperties
    {
        [PreserveSig]
        int SetPropertyNum([MarshalAs(UnmanagedType.LPWStr)] string pName, int lValue);

        [PreserveSig]
        int GetPropertyNum([MarshalAs(UnmanagedType.LPWStr)] string pName, out int plValue);

        [PreserveSig]
        int SetPropertyString([MarshalAs(UnmanagedType.LPWStr)] string pName, [MarshalAs(UnmanagedType.LPWStr)] string pValue);

        [PreserveSig]
        int GetPropertyString([MarshalAs(UnmanagedType.LPWStr)] string pName, [MarshalAs(UnmanagedType.LPWStr)] out string ppCoMemValue);
    }
}