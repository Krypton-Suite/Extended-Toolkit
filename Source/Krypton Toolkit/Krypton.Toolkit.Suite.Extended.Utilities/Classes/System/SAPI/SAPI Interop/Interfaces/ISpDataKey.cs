#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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