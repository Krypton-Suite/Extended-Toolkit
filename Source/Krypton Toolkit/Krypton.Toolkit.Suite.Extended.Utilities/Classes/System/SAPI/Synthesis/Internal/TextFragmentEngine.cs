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
    internal class TextFragmentEngine : ISsmlParser
    {
        private List<LexiconEntry> _lexicons;

        private SpeakInfo _speakInfo;

        private string _ssmlText;

        private bool _paragraphStarted = true;

        private bool _sentenceStarted = true;

        private ResourceLoader _resourceLoader;

        public string Ssml => _ssmlText;

        internal TextFragmentEngine(SpeakInfo speakInfo, string ssmlText, bool pexml, ResourceLoader resourceLoader, List<LexiconEntry> lexicons)
        {
            _lexicons = lexicons;
            _ssmlText = ssmlText;
            _speakInfo = speakInfo;
            _resourceLoader = resourceLoader;
        }

        public object ProcessSpeak(string sVersion, string sBaseUri, CultureInfo culture, List<SsmlXmlAttribute> extraNamespace)
        {
            _speakInfo.SetVoice(null, culture, VoiceGender.NotSet, VoiceAge.NotSet, 1);
            return _speakInfo.Voice;
        }

        public void ProcessText(string text, object voice, ref FragmentState fragmentState, int position, bool fIgnore)
        {
            if (!fIgnore)
            {
                TtsEngineAction action = fragmentState.Action;
                if (_paragraphStarted)
                {
                    fragmentState.Action = TtsEngineAction.StartParagraph;
                    _speakInfo.AddText((TTSVoice)voice, new TextFragment(fragmentState));
                    _paragraphStarted = false;
                    _sentenceStarted = true;
                }
                if (_sentenceStarted)
                {
                    fragmentState.Action = TtsEngineAction.StartSentence;
                    _speakInfo.AddText((TTSVoice)voice, new TextFragment(fragmentState));
                    _sentenceStarted = false;
                }
                fragmentState.Action = ActionTextFragment(action);
                _speakInfo.AddText((TTSVoice)voice, new TextFragment(fragmentState, text, _ssmlText, position, text.Length));
                fragmentState.Action = action;
            }
        }

        public void ProcessAudio(object voice, string sUri, string baseUri, bool fIgnore)
        {
            if (fIgnore)
            {
                return;
            }
            Uri uri = new Uri(sUri, UriKind.RelativeOrAbsolute);
            if (!uri.IsAbsoluteUri && !string.IsNullOrEmpty(baseUri))
            {
                if (baseUri[baseUri.Length - 1] != '/' && baseUri[baseUri.Length - 1] != '\\')
                {
                    int num = baseUri.LastIndexOf('/');
                    if (num < 0)
                    {
                        num = baseUri.LastIndexOf('\\');
                    }
                    if (num >= 0)
                    {
                        baseUri = baseUri.Substring(0, num);
                    }
                    baseUri += "/";
                }
                StringBuilder stringBuilder = new StringBuilder(baseUri);
                stringBuilder.Append(sUri);
                uri = new Uri(stringBuilder.ToString(), UriKind.RelativeOrAbsolute);
            }
            _speakInfo.AddAudio(new AudioData(uri, _resourceLoader));
        }

        public void ProcessBreak(object voice, ref FragmentState fragmentState, EmphasisBreak eBreak, int time, bool fIgnore)
        {
            if (!fIgnore)
            {
                TtsEngineAction action = fragmentState.Action;
                fragmentState.Action = ActionTextFragment(fragmentState.Action);
                _speakInfo.AddText((TTSVoice)voice, new TextFragment(fragmentState));
                fragmentState.Action = action;
            }
        }

        public void ProcessDesc(CultureInfo culture)
        {
        }

        public void ProcessEmphasis(bool noLevel, EmphasisWord word)
        {
        }

        public void ProcessMark(object voice, ref FragmentState fragmentState, string name, bool fIgnore)
        {
            if (!fIgnore)
            {
                TtsEngineAction action = fragmentState.Action;
                fragmentState.Action = ActionTextFragment(fragmentState.Action);
                _speakInfo.AddText((TTSVoice)voice, new TextFragment(fragmentState, name));
                fragmentState.Action = action;
            }
        }

        public object ProcessTextBlock(bool isParagraph, object voice, ref FragmentState fragmentState, CultureInfo culture, bool newCulture, VoiceGender gender, VoiceAge age)
        {
            if (culture != null && newCulture)
            {
                _speakInfo.SetVoice(null, culture, gender, age, 1);
            }
            if (isParagraph)
            {
                _paragraphStarted = true;
            }
            else
            {
                _sentenceStarted = true;
            }
            return _speakInfo.Voice;
        }

        public void EndProcessTextBlock(bool isParagraph)
        {
            if (isParagraph)
            {
                _paragraphStarted = true;
            }
            else
            {
                _sentenceStarted = true;
            }
        }

        public void ProcessPhoneme(ref FragmentState fragmentState, AlphabetType alphabet, string ph, char[] phoneIds)
        {
            fragmentState.Action = TtsEngineAction.Pronounce;
            fragmentState.Phoneme = _speakInfo.Voice.TtsEngine.ConvertPhonemes(phoneIds, alphabet);
        }

        public void ProcessProsody(string pitch, string range, string rate, string volume, string duration, string points)
        {
        }

        public void ProcessSayAs(string interpretAs, string format, string detail)
        {
        }

        public void ProcessSub(string alias, object voice, ref FragmentState fragmentState, int position, bool fIgnore)
        {
            ProcessText(alias, voice, ref fragmentState, position, fIgnore);
        }

        public object ProcessVoice(string name, CultureInfo culture, VoiceGender gender, VoiceAge age, int variant, bool fNewCulture, List<SsmlXmlAttribute> extraNamespace)
        {
            _speakInfo.SetVoice(name, culture, gender, age, variant);
            return _speakInfo.Voice;
        }

        public void ProcessLexicon(Uri uri, string type)
        {
            _lexicons.Add(new LexiconEntry(uri, type));
        }

        public void ProcessUnknownElement(object voice, ref FragmentState fragmentState, XmlReader reader)
        {
            StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.WriteNode(reader, false);
            xmlTextWriter.Close();
            string text = stringWriter.ToString();
            AddParseUnknownFragment(voice, ref fragmentState, text);
        }

        public void StartProcessUnknownAttributes(object voice, ref FragmentState fragmentState, string element, List<SsmlXmlAttribute> extraAttributes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "<{0}", new object[1]
            {
                element
            });
            foreach (SsmlXmlAttribute extraAttribute in extraAttributes)
            {
                stringBuilder.AppendFormat(CultureInfo.InvariantCulture, " {0}:{1}=\"{2}\" xmlns:{3}=\"{4}\"", extraAttribute._prefix, extraAttribute._name, extraAttribute._value, extraAttribute._prefix, extraAttribute._ns);
            }
            stringBuilder.Append(">");
            AddParseUnknownFragment(voice, ref fragmentState, stringBuilder.ToString());
        }

        public void EndProcessUnknownAttributes(object voice, ref FragmentState fragmentState, string element, List<SsmlXmlAttribute> extraAttributes)
        {
            AddParseUnknownFragment(voice, ref fragmentState, string.Format(CultureInfo.InvariantCulture, "</{0}>", new object[1]
            {
                element
            }));
        }

        public void ContainsPexml(string pexmlPrefix)
        {
        }

        public bool BeginPromptEngineOutput(object voice)
        {
            return false;
        }

        public void EndPromptEngineOutput(object voice)
        {
        }

        public bool ProcessPromptEngineDatabase(object voice, string fname, string delta, string idset)
        {
            return false;
        }

        public bool ProcessPromptEngineDiv(object voice)
        {
            return false;
        }

        public bool ProcessPromptEngineId(object voice, string id)
        {
            return false;
        }

        public bool BeginPromptEngineTts(object voice)
        {
            return false;
        }

        public void EndPromptEngineTts(object voice)
        {
        }

        public bool BeginPromptEngineWithTag(object voice, string tag)
        {
            return false;
        }

        public void EndPromptEngineWithTag(object voice, string tag)
        {
        }

        public bool BeginPromptEngineRule(object voice, string name)
        {
            return false;
        }

        public void EndPromptEngineRule(object voice, string name)
        {
        }

        public void EndElement()
        {
        }

        public void EndSpeakElement()
        {
        }

        private static TtsEngineAction ActionTextFragment(TtsEngineAction action)
        {
            return action;
        }

        private void AddParseUnknownFragment(object voice, ref FragmentState fragmentState, string text)
        {
            TtsEngineAction action = fragmentState.Action;
            fragmentState.Action = TtsEngineAction.ParseUnknownTag;
            _speakInfo.AddText((TTSVoice)voice, new TextFragment(fragmentState, text));
            fragmentState.Action = action;
        }
    }
}