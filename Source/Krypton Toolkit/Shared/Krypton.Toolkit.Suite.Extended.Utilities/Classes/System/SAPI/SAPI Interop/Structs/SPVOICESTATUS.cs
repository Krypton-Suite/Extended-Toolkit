#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal struct SPVOICESTATUS
    {
        internal uint ulCurrentStream;

        internal uint ulLastStreamQueued;

        internal int hrLastResult;

        internal SpeechRunState dwRunningState;

        internal uint ulInputWordPos;

        internal uint ulInputWordLen;

        internal uint ulInputSentPos;

        internal uint ulInputSentLen;

        internal int lBookmarkId;

        internal ushort PhonemeId;

        internal int VisemeId;

        internal uint dwReserved1;

        internal uint dwReserved2;
    }
}