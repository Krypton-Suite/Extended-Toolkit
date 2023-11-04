﻿#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

using SAPIGuids = Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop.SAPIGuids;
using SPEAKFLAGS = Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine.SPEAKFLAGS;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal class TtsProxySapi : ITtsEngineProxy
    {
        private ITtsEngine _sapiEngine;

        private IntPtr _iSite;

        internal override AlphabetType EngineAlphabet => AlphabetType.Sapi;

        internal TtsProxySapi(ITtsEngine sapiEngine, IntPtr iSite, int lcid)
            : base(lcid)
        {
            _iSite = iSite;
            _sapiEngine = sapiEngine;
        }

        internal override IntPtr GetOutputFormat(IntPtr preferedFormat)
        {
            Guid pTargetFmtId = SAPIGuids.SPDFID_WaveFormatEx;
            Guid pOutputFormatId = default(Guid);
            IntPtr ppCoMemOutputWaveFormatEx = IntPtr.Zero;
            _sapiEngine.GetOutputFormat(ref pTargetFmtId, preferedFormat, out pOutputFormatId, out ppCoMemOutputWaveFormatEx);
            return ppCoMemOutputWaveFormatEx;
        }

        internal override void AddLexicon(Uri lexicon, string mediaType)
        {
        }

        internal override void RemoveLexicon(Uri lexicon)
        {
        }

        internal override void Speak(List<TextFragment> frags, byte[] wfx)
        {
            GCHandle gCHandle = GCHandle.Alloc(wfx, GCHandleType.Pinned);
            try
            {
                IntPtr pWaveFormatEx = gCHandle.AddrOfPinnedObject();
                GCHandle sapiFragLast = default(GCHandle);
                if (ConvertTextFrag.ToSapi(frags, ref sapiFragLast))
                {
                    Guid rguidFormatId = SAPIGuids.SPDFID_WaveFormatEx;
                    try
                    {
                        _sapiEngine.Speak(SPEAKFLAGS.SPF_DEFAULT, ref rguidFormatId, pWaveFormatEx, sapiFragLast.AddrOfPinnedObject(), _iSite);
                    }
                    finally
                    {
                        ConvertTextFrag.FreeTextSegment(ref sapiFragLast);
                    }
                }
            }
            finally
            {
                gCHandle.Free();
            }
        }

        internal override char[] ConvertPhonemes(char[] phones, AlphabetType alphabet)
        {
            if (alphabet == AlphabetType.Ipa)
            {
                return _alphabetConverter.IpaToSapi(phones);
            }
            return phones;
        }

        internal override void ReleaseInterface()
        {
            Marshal.ReleaseComObject(_sapiEngine);
        }
    }
}