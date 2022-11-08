#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine;

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