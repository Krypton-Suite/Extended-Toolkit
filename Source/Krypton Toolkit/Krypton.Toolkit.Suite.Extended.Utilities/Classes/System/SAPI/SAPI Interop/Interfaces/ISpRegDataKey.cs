#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("92A66E2B-C830-4149-83DF-6FC2BA1E7A5B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpRegDataKey : ISpDataKey
    {
        [PreserveSig]
        new int SetData([MarshalAs(UnmanagedType.LPWStr)] string valueName, uint cbData, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] data);

        [PreserveSig]
        new int GetData([MarshalAs(UnmanagedType.LPWStr)] string valueName, ref uint pcbData, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] data);

        [PreserveSig]
        new int SetStringValue([MarshalAs(UnmanagedType.LPWStr)] string valueName, [MarshalAs(UnmanagedType.LPWStr)] string value);

        [PreserveSig]
        new int GetStringValue([MarshalAs(UnmanagedType.LPWStr)] string pszValueName, [MarshalAs(UnmanagedType.LPWStr)] out string ppszValue);

        [PreserveSig]
        new int SetDWORD([MarshalAs(UnmanagedType.LPWStr)] string valueName, uint dwValue);

        [PreserveSig]
        new int GetDWORD([MarshalAs(UnmanagedType.LPWStr)] string pszValueName, ref uint pdwValue);

        [PreserveSig]
        new int OpenKey([MarshalAs(UnmanagedType.LPWStr)] string pszSubKeyName, out ISpDataKey ppSubKey);

        [PreserveSig]
        new int CreateKey([MarshalAs(UnmanagedType.LPWStr)] string subKey, out ISpDataKey ppSubKey);

        [PreserveSig]
        new int DeleteKey([MarshalAs(UnmanagedType.LPWStr)] string subKey);

        [PreserveSig]
        new int DeleteValue([MarshalAs(UnmanagedType.LPWStr)] string valueName);

        [PreserveSig]
        new int EnumKeys(uint index, [MarshalAs(UnmanagedType.LPWStr)] out string ppszSubKeyName);

        [PreserveSig]
        new int EnumValues(uint Index, [MarshalAs(UnmanagedType.LPWStr)] out string ppszValueName);

        [PreserveSig]
        int SetKey(IntPtr hkey, bool fReadOnly);
    }
}