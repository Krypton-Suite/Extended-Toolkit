#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;

[ComImport, Guid("B638799F-6598-4c56-B3ED-509CA3F35B22"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface ISpCategory
{
    void GetType(out SPCATEGORYTYPE peCategoryType);

    void SetPrefix([MarshalAs(UnmanagedType.LPWStr)] string pszPrefix);

    void GetPrefix([MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemPrefix);

    void SetIsPrefixRequired([MarshalAs(UnmanagedType.Bool)] bool fRequired);

    void GetIsPrefixRequired([MarshalAs(UnmanagedType.Bool)] out bool pfRequired);

    void SetState(SPCATEGORYSTATE eCategoryState);

    void GetState(out SPCATEGORYSTATE peCategoryState);

    void SetName([MarshalAs(UnmanagedType.LPWStr)] string pszName);

    void GetName([MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemName);

    void SetIcon([MarshalAs(UnmanagedType.LPWStr)] string pszIcon);

    void GetIcon([MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemIcon);
}