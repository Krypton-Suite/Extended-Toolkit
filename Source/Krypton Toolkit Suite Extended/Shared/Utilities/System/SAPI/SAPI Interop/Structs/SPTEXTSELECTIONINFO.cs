#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal struct SPTEXTSELECTIONINFO
    {
        internal uint ulStartActiveOffset;

        internal uint cchActiveChars;

        internal uint ulStartSelection;

        internal uint cchSelection;

        internal SPTEXTSELECTIONINFO(uint ulStartActiveOffset, uint cchActiveChars, uint ulStartSelection, uint cchSelection)
        {
            this.ulStartActiveOffset = ulStartActiveOffset;
            this.cchActiveChars = cchActiveChars;
            this.ulStartSelection = ulStartSelection;
            this.cchSelection = cchSelection;
        }
    }
}