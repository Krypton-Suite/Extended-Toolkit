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
    internal class SPSERIALIZEDPHRASEALT
    {
        internal uint ulStartElementInParent;

        internal uint cElementsInParent;

        internal uint cElementsInAlternate;

        internal uint cbAltExtra;
    }
}