#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal class TtsProxyCom : ITtsEngineProxy
    {
        private ITtsEngineSsml _comEngine;

        private IntPtr _iSite;

        internal override AlphabetType EngineAlphabet => AlphabetType.Ipa;

        internal TtsProxyCom(ITtsEngineSsml comEngine, IntPtr iSite, int lcid)
            : base(lcid)
        {
            _iSite = iSite;
            _comEngine = comEngine;
        }

        internal override IntPtr GetOutputFormat(IntPtr targetFormat)
        {
            IntPtr waveHeader;
            _comEngine.GetOutputFormat(!(targetFormat != IntPtr.Zero) ? SpeakOutputFormat.Text : SpeakOutputFormat.WaveFormat, targetFormat, out waveHeader);
            return waveHeader;
        }

        internal override void AddLexicon(Uri lexicon, string mediaType)
        {
            _comEngine.AddLexicon(lexicon.ToString(), mediaType, _iSite);
        }

        internal override void RemoveLexicon(Uri lexicon)
        {
            _comEngine.RemoveLexicon(lexicon.ToString(), _iSite);
        }

        internal override void Speak(List<TextFragment> frags, byte[] wfx)
        {
            GCHandle gCHandle = GCHandle.Alloc(wfx, GCHandleType.Pinned);
            try
            {
                IntPtr waveHeader = gCHandle.AddrOfPinnedObject();
                Collection<IntPtr> collection = [];
                IntPtr fragments = TextFragmentInterop.FragmentToPtr(frags, collection);
                try
                {
                    _comEngine.Speak(fragments, frags.Count, waveHeader, _iSite);
                }
                finally
                {
                    foreach (IntPtr item in collection)
                    {
                        Marshal.FreeCoTaskMem(item);
                    }
                }
            }
            finally
            {
                gCHandle.Free();
            }
        }

        internal override void ReleaseInterface()
        {
            Marshal.ReleaseComObject(_comEngine);
        }

        internal override char[] ConvertPhonemes(char[] phones, AlphabetType alphabet)
        {
            if (alphabet == AlphabetType.Ipa)
            {
                return phones;
            }
            return _alphabetConverter.SapiToIpa(phones);
        }
    }
}