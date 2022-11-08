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
    internal abstract class ITtsEngineProxy
    {
        protected AlphabetConverter _alphabetConverter;

        internal abstract AlphabetType EngineAlphabet
        {
            get;
        }

        internal AlphabetConverter AlphabetConverter => _alphabetConverter;

        internal ITtsEngineProxy(int lcid)
        {
            _alphabetConverter = new AlphabetConverter(lcid);
        }

        internal abstract IntPtr GetOutputFormat(IntPtr targetFormat);

        internal abstract void AddLexicon(Uri lexicon, string mediaType);

        internal abstract void RemoveLexicon(Uri lexicon);

        internal abstract void Speak(List<TextFragment> frags, byte[] wfx);

        internal abstract void ReleaseInterface();

        internal abstract char[] ConvertPhonemes(char[] phones, AlphabetType alphabet);
    }
}