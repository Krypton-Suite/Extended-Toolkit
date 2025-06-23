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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis;

internal class TtsProxySsml : ITtsEngineProxy
{
    private TtsEngineSsml _ssmlEngine;

    private ITtsEngineSite _site;

    internal override AlphabetType EngineAlphabet => AlphabetType.Ipa;

    internal TtsProxySsml(TtsEngineSsml ssmlEngine, ITtsEngineSite site, int lcid)
        : base(lcid)
    {
        _ssmlEngine = ssmlEngine;
        _site = site;
    }

    internal override IntPtr GetOutputFormat(IntPtr targetFormat)
    {
        return _ssmlEngine.GetOutputFormat(SpeakOutputFormat.WaveFormat, targetFormat);
    }

    internal override void AddLexicon(Uri lexicon, string mediaType)
    {
        _ssmlEngine.AddLexicon(lexicon, mediaType, _site);
    }

    internal override void RemoveLexicon(Uri lexicon)
    {
        _ssmlEngine.RemoveLexicon(lexicon, _site);
    }

    internal override void Speak(List<TextFragment> frags, byte[] wfx)
    {
        GCHandle gCHandle = GCHandle.Alloc(wfx, GCHandleType.Pinned);
        try
        {
            IntPtr waveHeader = gCHandle.AddrOfPinnedObject();
            _ssmlEngine.Speak(frags.ToArray(), waveHeader, _site);
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
            return phones;
        }
        return _alphabetConverter.SapiToIpa(phones);
    }

    internal override void ReleaseInterface()
    {
    }
}