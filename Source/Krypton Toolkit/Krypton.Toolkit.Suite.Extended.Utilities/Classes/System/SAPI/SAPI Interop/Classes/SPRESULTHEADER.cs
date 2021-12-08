#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    internal class SPRESULTHEADER
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

        internal uint fAlphabet;

        internal SPRESULTHEADER()
        {
        }

        internal SPRESULTHEADER(SPRESULTHEADER_Sapi51 source)
        {
            ulSerializedSize = source.ulSerializedSize;
            cbHeaderSize = source.cbHeaderSize;
            clsidEngine = source.clsidEngine;
            clsidAlternates = source.clsidAlternates;
            ulStreamNum = source.ulStreamNum;
            ullStreamPosStart = source.ullStreamPosStart;
            ullStreamPosEnd = source.ullStreamPosEnd;
            ulPhraseDataSize = source.ulPhraseDataSize;
            ulPhraseOffset = source.ulPhraseOffset;
            ulPhraseAltDataSize = source.ulPhraseAltDataSize;
            ulPhraseAltOffset = source.ulPhraseAltOffset;
            ulNumPhraseAlts = source.ulNumPhraseAlts;
            ulRetainedDataSize = source.ulRetainedDataSize;
            ulRetainedOffset = source.ulRetainedOffset;
            ulDriverDataSize = source.ulDriverDataSize;
            ulDriverDataOffset = source.ulDriverDataOffset;
            fTimePerByte = source.fTimePerByte;
            fInputScaleFactor = source.fInputScaleFactor;
            times = source.times;
        }

        internal void Validate()
        {
            ValidateOffsetAndLength(0u, cbHeaderSize);
            ValidateOffsetAndLength(ulPhraseOffset, ulPhraseDataSize);
            ValidateOffsetAndLength(ulPhraseAltOffset, ulPhraseAltDataSize);
            ValidateOffsetAndLength(ulRetainedOffset, ulRetainedDataSize);
            ValidateOffsetAndLength(ulDriverDataOffset, ulDriverDataSize);
        }

        private void ValidateOffsetAndLength(uint offset, uint length)
        {
            if (offset + length > ulSerializedSize)
            {
                throw new FormatException(SR.Get(SRID.ResultInvalidFormat));
            }
        }
    }
}