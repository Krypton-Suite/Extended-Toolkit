#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;

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