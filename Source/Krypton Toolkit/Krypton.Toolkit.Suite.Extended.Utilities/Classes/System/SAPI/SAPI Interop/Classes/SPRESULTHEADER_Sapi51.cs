#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    internal class SPRESULTHEADER_Sapi51
    {
        internal uint ulSerializedSize;

        internal uint cbHeaderSize;

        internal Guid clsidEngine;

        internal Guid clsidAlternates;

        internal uint ulStreamNum;

        internal ulong ullStreamPosStart;

        internal ulong ullStreamPosEnd;

        internal uint ulPhraseDataSize;

        internal uint ulPhraseOffset;

        internal uint ulPhraseAltDataSize;

        internal uint ulPhraseAltOffset;

        internal uint ulNumPhraseAlts;

        internal uint ulRetainedDataSize;

        internal uint ulRetainedOffset;

        internal uint ulDriverDataSize;

        internal uint ulDriverDataOffset;

        internal float fTimePerByte;

        internal float fInputScaleFactor;

        internal SPRECORESULTTIMES times;
    }
}