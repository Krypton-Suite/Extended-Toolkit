#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
    [Flags]
    internal enum SPVESACTIONS
    {
        SPVES_CONTINUE = 0x0,
        SPVES_ABORT = 0x1,
        SPVES_SKIP = 0x2,
        SPVES_RATE = 0x4,
        SPVES_VOLUME = 0x8
    }
}
