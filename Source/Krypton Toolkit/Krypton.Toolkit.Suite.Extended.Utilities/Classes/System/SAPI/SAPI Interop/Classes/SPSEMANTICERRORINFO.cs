#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [StructLayout(LayoutKind.Sequential)]
    internal class SPSEMANTICERRORINFO
    {
        internal uint ulLineNumber;

        internal uint pszScriptLineOffset;

        internal uint pszSourceOffset;

        internal uint pszDescriptionOffset;

        internal int hrResultCode;
    }
}