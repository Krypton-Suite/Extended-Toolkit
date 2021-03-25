#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
    [TypeLibType(16)]
    internal struct SPVCONTEXT
    {
        public IntPtr pCategory;

        public IntPtr pBefore;

        public IntPtr pAfter;
    }
}
