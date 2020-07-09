using System;
using System.Collections.Generic;

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