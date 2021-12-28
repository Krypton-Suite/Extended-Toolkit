#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    [Serializable]
    public class PromptBuilder
    {
        internal enum SsmlState
        {
            Header = 1,
            Paragraph = 2,
            Sentence = 4,
            StyleEmphasis = 8,
            StyleProsody = 0x10,
            Voice = 0x20,
            Ended = 0x40
        }

        [Serializable]
        private struct StackElement
        {
            internal SsmlElement _possibleChildren;

            internal SsmlState _state;

            internal CultureInfo _culture;

            internal StackElement(SsmlElement possibleChildren, SsmlState state, CultureInfo culture)
            {
                _possibleChildren = possibleChildren;
                _state = state;
                _culture = culture;
            }
        }

        private enum ElementType
        {
            Prosody,
            Emphasis,
            SayAs,
            Phoneme,
            Sub,
            Break,
            Audio,
            Bookmark,
            StartVoice,
            StartParagraph,
            StartSentence,
            EndSentence,
            EndParagraph,
            StartStyle,
            EndStyle,
            EndVoice,
            Text,
            SsmlMarkup
        }

        [Serializable]
        private struct AttributeItem
        {
            internal string _key;

            internal string _value;

            internal string _namespace;

            internal AttributeItem(string key, string value)
            {
                _key = key;
                _value = value;
                _namespace = null;
            }

            internal AttributeItem(string ns, string key, string value)
                : this(key, value)
            {
                _namespace = ns;
            }
        }

        [Serializable]
        private class Element
        {
            internal ElementType _type;

            internal string _text;

            internal Collection<AttributeItem> _attributes;

            internal Element(ElementType type)
            {
                _type = type;
            }

            internal Element(ElementType type, string text)
                : this(type)
            {
                _text = text;
            }
        }

        private Stack<StackElement> _elementStack = new Stack<StackElement>();

        private CultureInfo _culture;

        private List<Element> _elements = new List<Element>();

        private static ResourceLoader _resourceLoader = new ResourceLoader();

        private const string _xmlnsDefault = "http://www.w3.org/2001/10/synthesis";

        private static readonly string[] _promptBuilderElementName = new string[11]
        {
            "prosody",
            "emphasis",
            "say-as",
            "phoneme",
            "sub",
            "break",
            "audio",
            "mark",
            "voice",
            "p",
            "s"
        };

        public bool IsEmpty => _elements.Count == 0;

        public CultureInfo Culture
        {
            get
            {
                return _culture;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _culture = value;
            }
        }

        public PromptBuilder()
            : this(CultureInfo.CurrentUICulture)
        {
        }

        public PromptBuilder(CultureInfo culture)
        {
            Helpers.ThrowIfNull(culture, "culture");
            if (culture.Equals(CultureInfo.InvariantCulture))
            {
                throw new ArgumentException(SR.Get(SRID.InvariantCultureInfo), "culture");
            }
            _culture = culture;
            ClearContent();
        }

        public void ClearContent()
        {
            _elements.Clear();
            _elementStack.Push(new StackElement(SsmlElement.Voice | SsmlElement.Audio | SsmlElement.Lexicon | SsmlElement.Meta | SsmlElement.MetaData | SsmlElement.Sentence | SsmlElement.Paragraph | SsmlElement.SayAs | SsmlElement.Phoneme | SsmlElement.Sub | SsmlElement.Emphasis | SsmlElement.Break | SsmlElement.Prosody | SsmlElement.Mark | SsmlElement.Text | SsmlElement.PromptEngineOutput, SsmlState.Header, _culture));
        }

        public void AppendText(string textToSpeak)
        {
            Helpers.ThrowIfNull(textToSpeak, "textToSpeak");
            ValidateElement(_elementStack.Peek(), SsmlElement.Text);
            _elements.Add(new Element(ElementType.Text, textToSpeak));
        }

        public void AppendText(string textToSpeak, PromptRate rate)
        {
            Helpers.ThrowIfNull(textToSpeak, "textToSpeak");
            if (rate < PromptRate.NotSet || rate > PromptRate.ExtraSlow)
            {
                throw new ArgumentOutOfRangeException("rate");
            }
            ValidateElement(_elementStack.Peek(), SsmlElement.Text);
            Element element = new Element(ElementType.Prosody, textToSpeak);
            _elements.Add(element);
            string value = null;
            switch (rate)
            {
                case PromptRate.ExtraFast:
                    value = "x-fast";
                    break;
                case PromptRate.ExtraSlow:
                    value = "x-slow";
                    break;
                default:
                    value = rate.ToString().ToLowerInvariant();
                    break;
                case PromptRate.NotSet:
                    break;
            }
            if (!string.IsNullOrEmpty(value))
            {
                element._attributes = new Collection<AttributeItem>();
                element._attributes.Add(new AttributeItem("rate", value));
            }
        }

        public void AppendText(string textToSpeak, PromptVolume volume)
        {
            Helpers.ThrowIfNull(textToSpeak, "textToSpeak");
            if (volume < PromptVolume.NotSet || volume > PromptVolume.Default)
            {
                throw new ArgumentOutOfRangeException("volume");
            }
            ValidateElement(_elementStack.Peek(), SsmlElement.Text);
            Element element = new Element(ElementType.Prosody, textToSpeak);
            _elements.Add(element);
            string value = null;
            switch (volume)
            {
                case PromptVolume.ExtraSoft:
                    value = "x-soft";
                    break;
                case PromptVolume.ExtraLoud:
                    value = "x-loud";
                    break;
                default:
                    value = volume.ToString().ToLowerInvariant();
                    break;
                case PromptVolume.NotSet:
                    break;
            }
            if (!string.IsNullOrEmpty(value))
            {
                element._attributes = new Collection<AttributeItem>();
                element._attributes.Add(new AttributeItem("volume", value));
            }
        }

        public void AppendText(string textToSpeak, PromptEmphasis emphasis)
        {
            Helpers.ThrowIfNull(textToSpeak, "textToSpeak");
            if (emphasis < PromptEmphasis.NotSet || emphasis > PromptEmphasis.Reduced)
            {
                throw new ArgumentOutOfRangeException("emphasis");
            }
            ValidateElement(_elementStack.Peek(), SsmlElement.Text);
            Element element = new Element(ElementType.Emphasis, textToSpeak);
            _elements.Add(element);
            if (emphasis != 0)
            {
                element._attributes = new Collection<AttributeItem>();
                element._attributes.Add(new AttributeItem("level", emphasis.ToString().ToLowerInvariant()));
            }
        }

        public void StartStyle(PromptStyle style)
        {
            Helpers.ThrowIfNull(style, "style");
            StackElement stackElement = _elementStack.Peek();
            ValidateElement(stackElement, SsmlElement.Prosody);
            SsmlState ssmlState = (SsmlState)0;
            SsmlElement possibleChildren = stackElement._possibleChildren;
            _elements.Add(new Element(ElementType.StartStyle));
            if (style.Emphasis != 0)
            {
                Element element = new Element(ElementType.Emphasis);
                _elements.Add(element);
                element._attributes = new Collection<AttributeItem>();
                element._attributes.Add(new AttributeItem("level", style.Emphasis.ToString().ToLowerInvariant()));
                possibleChildren = SsmlElement.AudioMarkTextWithStyle;
                ssmlState = SsmlState.StyleEmphasis;
            }
            if (style.Rate != 0 || style.Volume != 0)
            {
                if (ssmlState != 0)
                {
                    _elements.Add(new Element(ElementType.StartStyle));
                }
                Element element2 = new Element(ElementType.Prosody);
                _elements.Add(element2);
                if (style.Rate != 0)
                {
                    string value;
                    switch (style.Rate)
                    {
                        case PromptRate.ExtraFast:
                            value = "x-fast";
                            break;
                        case PromptRate.ExtraSlow:
                            value = "x-slow";
                            break;
                        default:
                            value = style.Rate.ToString().ToLowerInvariant();
                            break;
                    }
                    element2._attributes = new Collection<AttributeItem>();
                    element2._attributes.Add(new AttributeItem("rate", value));
                }
                if (style.Volume != 0)
                {
                    string value2;
                    switch (style.Volume)
                    {
                        case PromptVolume.ExtraSoft:
                            value2 = "x-soft";
                            break;
                        case PromptVolume.ExtraLoud:
                            value2 = "x-loud";
                            break;
                        default:
                            value2 = style.Volume.ToString().ToLowerInvariant();
                            break;
                    }
                    if (element2._attributes == null)
                    {
                        element2._attributes = new Collection<AttributeItem>();
                    }
                    element2._attributes.Add(new AttributeItem("volume", value2));
                }
                possibleChildren = (SsmlElement.Voice | SsmlElement.Audio | SsmlElement.Sentence | SsmlElement.Paragraph | SsmlElement.SayAs | SsmlElement.Phoneme | SsmlElement.Sub | SsmlElement.Emphasis | SsmlElement.Break | SsmlElement.Prosody | SsmlElement.Mark | SsmlElement.Text | SsmlElement.PromptEngineOutput);
                ssmlState |= SsmlState.StyleProsody;
            }
            _elementStack.Push(new StackElement(possibleChildren, ssmlState, stackElement._culture));
        }

        public void EndStyle()
        {
            StackElement stackElement = _elementStack.Pop();
            if (stackElement._state != 0)
            {
                if ((stackElement._state & (SsmlState)24) == 0)
                {
                    throw new InvalidOperationException(SR.Get(SRID.PromptBuilderMismatchStyle));
                }
                _elements.Add(new Element(ElementType.EndStyle));
                if (stackElement._state == (SsmlState)24)
                {
                    _elements.Add(new Element(ElementType.EndStyle));
                }
            }
        }

        public void StartVoice(VoiceInfo voice)
        {
            Helpers.ThrowIfNull(voice, "voice");
            if (!VoiceInfo.ValidateGender(voice.Gender))
            {
                throw new ArgumentException(SR.Get(SRID.EnumInvalid, "VoiceGender"), "voice");
            }
            if (!VoiceInfo.ValidateAge(voice.Age))
            {
                throw new ArgumentException(SR.Get(SRID.EnumInvalid, "VoiceAge"), "voice");
            }
            StackElement stackElement = _elementStack.Peek();
            ValidateElement(stackElement, SsmlElement.Voice);
            CultureInfo culture = (voice.Culture == null) ? stackElement._culture : voice.Culture;
            Element element = new Element(ElementType.StartVoice);
            element._attributes = new Collection<AttributeItem>();
            _elements.Add(element);
            if (!string.IsNullOrEmpty(voice.Name))
            {
                element._attributes.Add(new AttributeItem("name", voice.Name));
            }
            if (voice.Culture != null)
            {
                element._attributes.Add(new AttributeItem("xml", "lang", voice.Culture.Name));
            }
            if (voice.Gender != 0)
            {
                element._attributes.Add(new AttributeItem("gender", voice.Gender.ToString().ToLowerInvariant()));
            }
            if (voice.Age != 0)
            {
                element._attributes.Add(new AttributeItem("age", ((int)voice.Age).ToString(CultureInfo.InvariantCulture)));
            }
            if (voice.Variant >= 0)
            {
                element._attributes.Add(new AttributeItem("variant", voice.Variant.ToString(CultureInfo.InvariantCulture)));
            }
            _elementStack.Push(new StackElement(SsmlElement.Voice | SsmlElement.Audio | SsmlElement.Sentence | SsmlElement.SayAs | SsmlElement.Phoneme | SsmlElement.Sub | SsmlElement.Emphasis | SsmlElement.Break | SsmlElement.Prosody | SsmlElement.Mark | SsmlElement.Text | SsmlElement.PromptEngineOutput, SsmlState.Voice, culture));
        }

        public void StartVoice(string name)
        {
            Helpers.ThrowIfEmptyOrNull(name, "name");
            StartVoice(new VoiceInfo(name));
        }

        public void StartVoice(VoiceGender gender)
        {
            StartVoice(new VoiceInfo(gender));
        }

        public void StartVoice(VoiceGender gender, VoiceAge age)
        {
            StartVoice(new VoiceInfo(gender, age));
        }

        public void StartVoice(VoiceGender gender, VoiceAge age, int voiceAlternate)
        {
            StartVoice(new VoiceInfo(gender, age, voiceAlternate));
        }

        public void StartVoice(CultureInfo culture)
        {
            StartVoice(new VoiceInfo(culture));
        }

        public void EndVoice()
        {
            if (_elementStack.Pop()._state != SsmlState.Voice)
            {
                throw new InvalidOperationException(SR.Get(SRID.PromptBuilderMismatchVoice));
            }
            _elements.Add(new Element(ElementType.EndVoice));
        }

        public void StartParagraph()
        {
            StartParagraph(null);
        }

        public void StartParagraph(CultureInfo culture)
        {
            StackElement stackElement = _elementStack.Peek();
            ValidateElement(stackElement, SsmlElement.Paragraph);
            Element element = new Element(ElementType.StartParagraph);
            _elements.Add(element);
            if (culture != null)
            {
                if (culture.Equals(CultureInfo.InvariantCulture))
                {
                    throw new ArgumentException(SR.Get(SRID.InvariantCultureInfo), "culture");
                }
                element._attributes = new Collection<AttributeItem>();
                element._attributes.Add(new AttributeItem("xml", "lang", culture.Name));
            }
            else
            {
                culture = stackElement._culture;
            }
            _elementStack.Push(new StackElement(SsmlElement.Voice | SsmlElement.Audio | SsmlElement.Sentence | SsmlElement.SayAs | SsmlElement.Phoneme | SsmlElement.Sub | SsmlElement.Emphasis | SsmlElement.Break | SsmlElement.Prosody | SsmlElement.Mark | SsmlElement.Text | SsmlElement.PromptEngineOutput, SsmlState.Paragraph, culture));
        }

        public void EndParagraph()
        {
            if (_elementStack.Pop()._state != SsmlState.Paragraph)
            {
                throw new InvalidOperationException(SR.Get(SRID.PromptBuilderMismatchParagraph));
            }
            _elements.Add(new Element(ElementType.EndParagraph));
        }

        public void StartSentence()
        {
            StartSentence(null);
        }

        public void StartSentence(CultureInfo culture)
        {
            StackElement stackElement = _elementStack.Peek();
            ValidateElement(stackElement, SsmlElement.Sentence);
            Element element = new Element(ElementType.StartSentence);
            _elements.Add(element);
            if (culture != null)
            {
                if (culture.Equals(CultureInfo.InvariantCulture))
                {
                    throw new ArgumentException(SR.Get(SRID.InvariantCultureInfo), "culture");
                }
                element._attributes = new Collection<AttributeItem>();
                element._attributes.Add(new AttributeItem("xml", "lang", culture.Name));
            }
            else
            {
                culture = stackElement._culture;
            }
            _elementStack.Push(new StackElement(SsmlElement.AudioMarkTextWithStyle, SsmlState.Sentence, culture));
        }

        public void EndSentence()
        {
            if (_elementStack.Pop()._state != SsmlState.Sentence)
            {
                throw new InvalidOperationException(SR.Get(SRID.PromptBuilderMismatchSentence));
            }
            _elements.Add(new Element(ElementType.EndSentence));
        }

        public void AppendTextWithHint(string textToSpeak, SayAs sayAs)
        {
            Helpers.ThrowIfNull(textToSpeak, "textToSpeak");
            if (sayAs < SayAs.SpellOut || sayAs > SayAs.Text)
            {
                throw new ArgumentOutOfRangeException("sayAs");
            }
            ValidateElement(_elementStack.Peek(), SsmlElement.Text);
            if (sayAs != SayAs.Text)
            {
                Element element = new Element(ElementType.SayAs, textToSpeak);
                _elements.Add(element);
                element._attributes = new Collection<AttributeItem>();
                string value = null;
                string value2 = null;
                switch (sayAs)
                {
                    case SayAs.SpellOut:
                        value = "characters";
                        break;
                    case SayAs.NumberOrdinal:
                        value = "ordinal";
                        break;
                    case SayAs.NumberCardinal:
                        value = "cardinal";
                        break;
                    case SayAs.Date:
                        value = "date";
                        break;
                    case SayAs.DayMonthYear:
                        value = "date";
                        value2 = "dmy";
                        break;
                    case SayAs.MonthDayYear:
                        value = "date";
                        value2 = "mdy";
                        break;
                    case SayAs.YearMonthDay:
                        value = "date";
                        value2 = "ymd";
                        break;
                    case SayAs.YearMonth:
                        value = "date";
                        value2 = "ym";
                        break;
                    case SayAs.MonthYear:
                        value = "date";
                        value2 = "my";
                        break;
                    case SayAs.MonthDay:
                        value = "date";
                        value2 = "md";
                        break;
                    case SayAs.DayMonth:
                        value = "date";
                        value2 = "dm";
                        break;
                    case SayAs.Year:
                        value = "date";
                        value2 = "y";
                        break;
                    case SayAs.Month:
                        value = "date";
                        value2 = "m";
                        break;
                    case SayAs.Day:
                        value = "date";
                        value2 = "d";
                        break;
                    case SayAs.Time:
                        value = "time";
                        break;
                    case SayAs.Time24:
                        value = "time";
                        value2 = "hms24";
                        break;
                    case SayAs.Time12:
                        value = "time";
                        value2 = "hms12";
                        break;
                    case SayAs.Telephone:
                        value = "telephone";
                        break;
                }
                element._attributes.Add(new AttributeItem("interpret-as", value));
                if (!string.IsNullOrEmpty(value2))
                {
                    element._attributes.Add(new AttributeItem("format", value2));
                }
            }
            else
            {
                AppendText(textToSpeak);
            }
        }

        public void AppendTextWithHint(string textToSpeak, string sayAs)
        {
            Helpers.ThrowIfNull(textToSpeak, "textToSpeak");
            Helpers.ThrowIfEmptyOrNull(sayAs, "sayAs");
            ValidateElement(_elementStack.Peek(), SsmlElement.Text);
            Element element = new Element(ElementType.SayAs, textToSpeak);
            _elements.Add(element);
            element._attributes = new Collection<AttributeItem>();
            element._attributes.Add(new AttributeItem("interpret-as", sayAs));
        }

        public void AppendTextWithPronunciation(string textToSpeak, string pronunciation)
        {
            Helpers.ThrowIfEmptyOrNull(textToSpeak, "textToSpeak");
            Helpers.ThrowIfEmptyOrNull(pronunciation, "pronunciation");
            ValidateElement(_elementStack.Peek(), SsmlElement.Text);
            PhonemeConverter.ValidateUpsIds(pronunciation);
            Element element = new Element(ElementType.Phoneme, textToSpeak);
            _elements.Add(element);
            element._attributes = new Collection<AttributeItem>();
            element._attributes.Add(new AttributeItem("ph", pronunciation));
        }

        public void AppendTextWithAlias(string textToSpeak, string substitute)
        {
            Helpers.ThrowIfNull(textToSpeak, "textToSpeak");
            Helpers.ThrowIfNull(substitute, "substitute");
            ValidateElement(_elementStack.Peek(), SsmlElement.Text);
            Element element = new Element(ElementType.Sub, textToSpeak);
            _elements.Add(element);
            element._attributes = new Collection<AttributeItem>();
            element._attributes.Add(new AttributeItem("alias", substitute));
        }

        public void AppendBreak()
        {
            ValidateElement(_elementStack.Peek(), SsmlElement.Break);
            _elements.Add(new Element(ElementType.Break));
        }

        public void AppendBreak(PromptBreak strength)
        {
            ValidateElement(_elementStack.Peek(), SsmlElement.Break);
            Element element = new Element(ElementType.Break);
            _elements.Add(element);
            string text = null;
            switch (strength)
            {
                case PromptBreak.None:
                    text = "none";
                    break;
                case PromptBreak.ExtraSmall:
                    text = "x-weak";
                    break;
                case PromptBreak.Small:
                    text = "weak";
                    break;
                case PromptBreak.Medium:
                    text = "medium";
                    break;
                case PromptBreak.Large:
                    text = "strong";
                    break;
                case PromptBreak.ExtraLarge:
                    text = "x-strong";
                    break;
                default:
                    throw new ArgumentNullException("strength");
            }
            element._attributes = new Collection<AttributeItem>();
            element._attributes.Add(new AttributeItem("strength", text));
        }

        public void AppendBreak(TimeSpan duration)
        {
            ValidateElement(_elementStack.Peek(), SsmlElement.Break);
            if (duration.Ticks < 0)
            {
                throw new ArgumentOutOfRangeException("duration");
            }
            Element element = new Element(ElementType.Break);
            _elements.Add(element);
            element._attributes = new Collection<AttributeItem>();
            element._attributes.Add(new AttributeItem("time", duration.TotalMilliseconds + "ms"));
        }

        public void AppendAudio(string path)
        {
            Helpers.ThrowIfEmptyOrNull(path, "path");
            Uri audioFile;
            try
            {
                audioFile = new Uri(path, UriKind.RelativeOrAbsolute);
            }
            catch (UriFormatException ex)
            {
                throw new ArgumentException(ex.Message, path, ex);
            }
            ValidateElement(_elementStack.Peek(), SsmlElement.Audio);
            AppendAudio(audioFile);
        }

        public void AppendAudio(Uri audioFile)
        {
            Helpers.ThrowIfNull(audioFile, "audioFile");
            ValidateElement(_elementStack.Peek(), SsmlElement.Audio);
            Element element = new Element(ElementType.Audio);
            _elements.Add(element);
            element._attributes = new Collection<AttributeItem>();
            element._attributes.Add(new AttributeItem("src", audioFile.ToString()));
        }

        public void AppendAudio(Uri audioFile, string alternateText)
        {
            Helpers.ThrowIfNull(audioFile, "audioFile");
            Helpers.ThrowIfNull(alternateText, "alternateText");
            ValidateElement(_elementStack.Peek(), SsmlElement.Audio);
            Element element = new Element(ElementType.Audio, alternateText);
            _elements.Add(element);
            element._attributes = new Collection<AttributeItem>();
            element._attributes.Add(new AttributeItem("src", audioFile.ToString()));
        }

        public void AppendBookmark(string bookmarkName)
        {
            Helpers.ThrowIfEmptyOrNull(bookmarkName, "bookmarkName");
            ValidateElement(_elementStack.Peek(), SsmlElement.Mark);
            Element element = new Element(ElementType.Bookmark);
            _elements.Add(element);
            element._attributes = new Collection<AttributeItem>();
            element._attributes.Add(new AttributeItem("name", bookmarkName));
        }

        public void AppendPromptBuilder(PromptBuilder promptBuilder)
        {
            Helpers.ThrowIfNull(promptBuilder, "promptBuilder");
            StringReader stringReader = new StringReader(promptBuilder.ToXml());
            XmlTextReader xmlTextReader = new XmlTextReader(stringReader);
            AppendSsml(xmlTextReader);
            xmlTextReader.Close();
            stringReader.Close();
        }

        public void AppendSsml(string path)
        {
            Helpers.ThrowIfEmptyOrNull(path, "path");
            AppendSsml(new Uri(path, UriKind.Relative));
        }

        public void AppendSsml(Uri ssmlFile)
        {
            Helpers.ThrowIfNull(ssmlFile, "ssmlFile");
            string localPath;
            Uri redirectedUri;
            using (Stream input = _resourceLoader.LoadFile(ssmlFile, out localPath, out redirectedUri))
            {
                try
                {
                    AppendSsml(new XmlTextReader(input));
                }
                finally
                {
                    _resourceLoader.UnloadFile(localPath);
                }
            }
        }

        public void AppendSsml(XmlReader ssmlFile)
        {
            Helpers.ThrowIfNull(ssmlFile, "ssmlFile");
            AppendSsmlInternal(ssmlFile);
        }

        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public void AppendSsmlMarkup(string ssmlMarkup)
        {
            Helpers.ThrowIfEmptyOrNull(ssmlMarkup, "ssmlMarkup");
            _elements.Add(new Element(ElementType.SsmlMarkup, ssmlMarkup));
        }

        public string ToXml()
        {
            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                using (XmlTextWriter writer = new XmlTextWriter(stringWriter))
                {
                    WriteXml(writer);
                    SsmlState state = _elementStack.Peek()._state;
                    if (state != SsmlState.Header)
                    {
                        string str = SR.Get(SRID.PromptBuilderInvalideState);
                        switch (state)
                        {
                            case SsmlState.Ended:
                                str += SR.Get(SRID.PromptBuilderStateEnded);
                                break;
                            case SsmlState.Sentence:
                                str += SR.Get(SRID.PromptBuilderStateSentence);
                                break;
                            case SsmlState.Paragraph:
                                str += SR.Get(SRID.PromptBuilderStateParagraph);
                                break;
                            case SsmlState.StyleEmphasis:
                            case SsmlState.StyleProsody:
                            case (SsmlState)24:
                                str += SR.Get(SRID.PromptBuilderStateStyle);
                                break;
                            case SsmlState.Voice:
                                str += SR.Get(SRID.PromptBuilderStateVoice);
                                break;
                            default:
                                throw new NotSupportedException();
                        }
                        throw new InvalidOperationException(str);
                    }
                    return stringWriter.ToString();
                }
            }
        }

        private void WriteXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("speak");
            writer.WriteAttributeString("version", "1.0");
            writer.WriteAttributeString("xmlns", "http://www.w3.org/2001/10/synthesis");
            writer.WriteAttributeString("xml", "lang", null, _culture.Name);
            bool flag = false;
            foreach (Element element in _elements)
            {
                flag = (flag || element._type == ElementType.StartSentence || element._type == ElementType.StartParagraph || element._type == ElementType.StartStyle || element._type == ElementType.StartVoice);
                switch (element._type)
                {
                    case ElementType.Text:
                        writer.WriteString(element._text);
                        break;
                    case ElementType.SsmlMarkup:
                        writer.WriteRaw(element._text);
                        break;
                    case ElementType.Prosody:
                    case ElementType.Emphasis:
                    case ElementType.SayAs:
                    case ElementType.Phoneme:
                    case ElementType.Sub:
                    case ElementType.Break:
                    case ElementType.Audio:
                    case ElementType.Bookmark:
                    case ElementType.StartVoice:
                    case ElementType.StartParagraph:
                    case ElementType.StartSentence:
                        writer.WriteStartElement(_promptBuilderElementName[(int)element._type]);
                        if (element._attributes != null)
                        {
                            foreach (AttributeItem attribute in element._attributes)
                            {
                                if (attribute._namespace == null)
                                {
                                    writer.WriteAttributeString(attribute._key, attribute._value);
                                }
                                else
                                {
                                    writer.WriteAttributeString(attribute._namespace, attribute._key, null, attribute._value);
                                }
                            }
                        }
                        if (element._text != null)
                        {
                            writer.WriteString(element._text);
                        }
                        if (!flag)
                        {
                            writer.WriteEndElement();
                        }
                        flag = false;
                        break;
                    case ElementType.EndSentence:
                    case ElementType.EndParagraph:
                    case ElementType.EndStyle:
                    case ElementType.EndVoice:
                        writer.WriteEndElement();
                        break;
                    default:
                        throw new NotSupportedException();
                    case ElementType.StartStyle:
                        break;
                }
            }
            writer.WriteEndElement();
        }

        private static void ValidateElement(StackElement stackElement, SsmlElement currentElement)
        {
            if ((stackElement._possibleChildren & currentElement) == 0)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, SR.Get(SRID.PromptBuilderInvalidElement), new object[2]
                {
                    currentElement.ToString(),
                    stackElement._state.ToString()
                }));
            }
        }

        private void AppendSsmlInternal(XmlReader ssmlFile)
        {
            StackElement stackElement = _elementStack.Peek();
            ValidateElement(_elementStack.Peek(), SsmlElement.Voice);
            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                using (XmlTextWriter writer = new XmlTextWriter(stringWriter))
                {
                    TextWriterEngine engine = new TextWriterEngine(writer, stackElement._culture);
                    SsmlParser.Parse(ssmlFile, engine, null);
                }
                _elements.Add(new Element(ElementType.SsmlMarkup, stringWriter.ToString()));
            }
        }
    }
}
