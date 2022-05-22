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
    internal interface ISsmlParser
    {
        string Ssml
        {
            get;
        }

        object ProcessSpeak(string sVersion, string sBaseUri, CultureInfo culture, List<SsmlXmlAttribute> extraNamespace);

        void ProcessText(string text, object voice, ref FragmentState fragmentState, int position, bool fIgnore);

        void ProcessAudio(object voice, string sUri, string baseUri, bool fIgnore);

        void ProcessBreak(object voice, ref FragmentState fragmentState, EmphasisBreak eBreak, int time, bool fIgnore);

        void ProcessDesc(CultureInfo culture);

        void ProcessEmphasis(bool noLevel, EmphasisWord word);

        void ProcessMark(object voice, ref FragmentState fragmentState, string name, bool fIgnore);

        object ProcessTextBlock(bool isParagraph, object voice, ref FragmentState fragmentState, CultureInfo culture, bool newCulture, VoiceGender gender, VoiceAge age);

        void EndProcessTextBlock(bool isParagraph);

        void ProcessPhoneme(ref FragmentState fragmentState, AlphabetType alphabet, string ph, char[] phoneIds);

        void ProcessProsody(string pitch, string range, string rate, string volume, string duration, string points);

        void ProcessSayAs(string interpretAs, string format, string detail);

        void ProcessSub(string alias, object voice, ref FragmentState fragmentState, int position, bool fIgnore);

        object ProcessVoice(string name, CultureInfo culture, VoiceGender gender, VoiceAge age, int variant, bool fNewCulture, List<SsmlXmlAttribute> extraNamespace);

        void ProcessLexicon(Uri uri, string type);

        void EndElement();

        void EndSpeakElement();

        void ProcessUnknownElement(object voice, ref FragmentState fragmentState, XmlReader reader);

        void StartProcessUnknownAttributes(object voice, ref FragmentState fragmentState, string element, List<SsmlXmlAttribute> extraAttributes);

        void EndProcessUnknownAttributes(object voice, ref FragmentState fragmentState, string element, List<SsmlXmlAttribute> extraAttributes);

        void ContainsPexml(string pexmlPrefix);

        bool BeginPromptEngineOutput(object voice);

        void EndPromptEngineOutput(object voice);

        bool ProcessPromptEngineDatabase(object voice, string fname, string delta, string idset);

        bool ProcessPromptEngineDiv(object voice);

        bool ProcessPromptEngineId(object voice, string id);

        bool BeginPromptEngineTts(object voice);

        void EndPromptEngineTts(object voice);

        bool BeginPromptEngineWithTag(object voice, string tag);

        void EndPromptEngineWithTag(object voice, string tag);

        bool BeginPromptEngineRule(object voice, string name);

        void EndPromptEngineRule(object voice, string name);
    }
}