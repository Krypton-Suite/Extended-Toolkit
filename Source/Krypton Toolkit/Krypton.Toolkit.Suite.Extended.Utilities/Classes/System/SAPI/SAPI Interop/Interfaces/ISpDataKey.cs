#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("14056581-E16C-11D2-BB90-00C04F8EE6C0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpDataKey
    {
        [PreserveSig]
        int SetData([MarshalAs(UnmanagedType.LPWStr)] string valueName, uint cbData, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] data);

        [PreserveSig]
        int GetData([MarshalAs(UnmanagedType.LPWStr)] string valueName, ref uint pcbData, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] data);

        [PreserveSig]
        int SetStringValue([MarshalAs(UnmanagedType.LPWStr)] string valueName, [MarshalAs(UnmanagedType.LPWStr)] string value);

        [PreserveSig]
        int GetStringValue([MarshalAs(UnmanagedType.LPWStr)] string valueName, [MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        int SetDWORD([MarshalAs(UnmanagedType.LPWStr)] string valueName, uint dwValue);

        [PreserveSig]
        int GetDWORD([MarshalAs(UnmanagedType.LPWStr)] string valueName, ref uint pdwValue);

        [PreserveSig]
        int OpenKey([MarshalAs(UnmanagedType.LPWStr)] string subKeyName, out ISpDataKey ppSubKey);

        [PreserveSig]
        int CreateKey([MarshalAs(UnmanagedType.LPWStr)] string subKey, out ISpDataKey ppSubKey);

        [PreserveSig]
        int DeleteKey([MarshalAs(UnmanagedType.LPWStr)] string subKey);

        [PreserveSig]
        int DeleteValue([MarshalAs(UnmanagedType.LPWStr)] string valueName);

        [PreserveSig]
        int EnumKeys(uint index, [MarshalAs(UnmanagedType.LPWStr)] out string ppszSubKeyName);

        [PreserveSig]
        int EnumValues(uint index, [MarshalAs(UnmanagedType.LPWStr)] out string valueName);
    }
}