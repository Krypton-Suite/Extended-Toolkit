#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("C8D7C7E2-0DDE-44b7-AFE3-B0C991FBEB5E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpDisplayAlternates
    {
        void GetDisplayAlternates(IntPtr pPhrase, uint cRequestCount, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] ppCoMemPhrases, out uint pcPhrasesReturned);
    }
}