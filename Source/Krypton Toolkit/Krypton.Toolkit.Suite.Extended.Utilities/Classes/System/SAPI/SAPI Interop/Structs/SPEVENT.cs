#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal struct SPEVENT
    {
        public SPEVENTENUM eEventId;

        public SPEVENTLPARAMTYPE elParamType;

        public uint ulStreamNum;

        public ulong ullAudioStreamOffset;

        public IntPtr wParam;

        public IntPtr lParam;
    }
}