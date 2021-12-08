#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
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
}