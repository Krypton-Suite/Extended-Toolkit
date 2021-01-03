#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal enum AudioCodec
    {
        PCM16 = 0x80,
        PCM8 = 0x7F,
        G711U = 0,
        G711A = 8,
        Undefined = -1
    }
}