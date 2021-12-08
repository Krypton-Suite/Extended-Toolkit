#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal static class SsmlParser
    {
        private delegate bool ProcessPromptEngine0(object voice);

        private delegate bool ProcessPromptEngine1(object voice, string value);

        private struct SsmlAttributes
        {
            internal object _voice;

            internal FragmentState _fragmentState;

            internal bool _fRenderDesc;

            internal VoiceAge _age;

            internal VoiceGender _gender;

            internal string _baseUri;

            internal short _cPromptOutput;

            internal List<SsmlXmlAttribute> _unknownNamespaces;

            internal bool AddUnknowAttribute(SsmlXmlAttribute attribute, ref List<SsmlXmlAttribute> extraAttributes)
            {
                foreach (SsmlXmlAttribute unknownNamespace in _unknownNamespaces)
                {
                    if (unknownNamespace._name == attribute._prefix)
                    {
                        if (extraAttributes == null)
                        {
                            extraAttributes = new List<SsmlXmlAttribute>();
                        }
                        extraAttributes.Add(attribute);
                        return true;
                    }
                }
                return false;
            }

            internal bool AddUnknowAttribute(XmlReader reader, ref List<SsmlXmlAttribute> extraAttributes)
            {
                foreach (SsmlXmlAttribute unknownNamespace in _unknownNamespaces)
                {
                    if (unknownNamespace._name == reader.Prefix)
                    {
                        if (extraAttributes == null)
                        {
                            extraAttributes = new List<SsmlXmlAttribute>();
                        }
                        extraAttributes.Add(new SsmlXmlAttribute(reader.Prefix, reader.LocalName, reader.Value, reader.NamespaceURI));
                        return true;
                    }
                }
                return false;
            }

            internal bool IsOtherNamespaceElement(XmlReader reader)
            {
                foreach (SsmlXmlAttribute unknownNamespace in _unknownNamespaces)
                {
                    if (unknownNamespace._name == reader.Prefix)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private delegate void ParseElementDelegates(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmlAttributes, bool fIgnore);

        private static readonly string[] _elementsName = new string[25]
        {
            "audio",
            "break",
            "database",
            "desc",
            "div",
            "emphasis",
            "id",
            "lexicon",
            "mark",
            "meta",
            "metadata",
            "p",
            "paragraph",
            "phoneme",
            "prompt_output",
            "prosody",
            "rule",
            "s",
            "say-as",
            "sentence",
            "speak",
            "sub",
            "tts",
            "voice",
            "withtag"
        };

        private static readonly ParseElementDelegates[] _parseElements = new ParseElementDelegates[25]
        {
            ParseAudio,
            ParseBreak,
            ParseDatabase,
            ParseDesc,
            ParseDiv,
            ParseEmphasis,
            ParseId,
            ParseLexicon,
            ParseMark,
            NoOp,
            ParseMetaData,
            ParseParagraph,
            ParseParagraph,
            ParsePhoneme,
            ParsePromptOutput,
            ParseProsody,
            ParseRule,
            ParseSentence,
            ParseSayAs,
            ParseSentence,
            NoOp,
            ParseSub,
            ParseTts,
            ParseVoice,
            ParseWithTag
        };

        private static readonly string[] _breakStrength = new string[6]
        {
            "medium",
            "none",
            "strong",
            "weak",
            "x-strong",
            "x-weak"
        };

        private static readonly EmphasisBreak[] _breakEmphasis = new EmphasisBreak[6]
        {
            EmphasisBreak.Medium,
            EmphasisBreak.None,
            EmphasisBreak.Strong,
            EmphasisBreak.Weak,
            EmphasisBreak.ExtraStrong,
            EmphasisBreak.ExtraWeak
        };

        private static readonly string[] _emphasisNames = new string[4]
        {
            "moderate",
            "none",
            "reduced",
            "strong"
        };

        private static readonly EmphasisWord[] _emphasisWord = new EmphasisWord[4]
        {
            EmphasisWord.Moderate,
            EmphasisWord.None,
            EmphasisWord.Reduced,
            EmphasisWord.Strong
        };

        private static readonly int[] _pitchWords = new int[6]
        {
            0,
            4,
            2,
            3,
            5,
            1
        };

        private static readonly string[] _pitchNames = new string[6]
        {
            "default",
            "high",
            "low",
            "medium",
            "x-high",
            "x-low"
        };

        private static readonly int[] _rangeWords = new int[6]
        {
            0,
            4,
            2,
            3,
            5,
            1
        };

        private static readonly string[] _rangeNames = new string[6]
        {
            "default",
            "high",
            "low",
            "medium",
            "x-high",
            "x-low"
        };

        private static readonly int[] _rateWords = new int[6]
        {
            0,
            4,
            3,
            2,
            5,
            1
        };

        private static readonly string[] _rateNames = new string[6]
        {
            "default",
            "fast",
            "medium",
            "slow",
            "x-fast",
            "x-slow"
        };

        private static readonly int[] _volumeWords = new int[7]
        {
            -1,
            -6,
            -5,
            -2,
            -4,
            -7,
            -3
        };

        private static readonly string[] _volumeNames = new string[7]
        {
            "default",
            "loud",
            "medium",
            "silent",
            "soft",
            "x-loud",
            "x-soft"
        };

        private const string xmlNamespace = "http://www.w3.org/XML/1998/namespace";

        private const string xmlNamespaceSsml = "http://www.w3.org/2001/10/synthesis";

        private const string xmlNamespaceXmlns = "http://www.w3.org/2000/xmlns/";

        private const string xmlNamespacePrompt = "http://schemas.microsoft.com/Speech/2003/03/PromptEngine";

        internal static void Parse(string ssml, ISsmlParser engine, object voice)
        {
            string text = ssml.Replace('\n', ' ');
            text = text.Replace('\r', ' ');
            XmlTextReader reader = new XmlTextReader(new StringReader(text));
            Parse(reader, engine, voice);
        }

        internal static void Parse(XmlReader reader, ISsmlParser engine, object voice)
        {
            try
            {
                bool flag = false;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "speak")
                    {
                        if (flag)
                        {
                            ThrowFormatException(SRID.GrammarDefTwice);
                        }
                        else
                        {
                            ProcessSpeakElement(reader, engine, voice);
                            flag = true;
                        }
                    }
                }
                if (!flag)
                {
                    ThrowFormatException(SRID.SynthesizerNoSpeak);
                }
            }
            catch (XmlException innerException)
            {
                throw new FormatException(SR.Get(SRID.InvalidXml), innerException);
            }
        }

        private static void ProcessSpeakElement(XmlReader reader, ISsmlParser engine, object voice)
        {
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            ssmlAttributes._voice = voice;
            ssmlAttributes._age = VoiceAge.NotSet;
            ssmlAttributes._gender = VoiceGender.NotSet;
            ssmlAttributes._unknownNamespaces = new List<SsmlXmlAttribute>();
            string dest = null;
            string dest2 = null;
            string dest3 = null;
            CultureInfo cultureInfo = null;
            List<SsmlXmlAttribute> list = new List<SsmlXmlAttribute>();
            Exception innerException = null;
            while (reader.MoveToNextAttribute())
            {
                bool flag = false;
                if (reader.NamespaceURI.Length == 0)
                {
                    string localName = reader.LocalName;
                    if (localName == "version")
                    {
                        CheckForDuplicates(ref dest, reader);
                        if (dest != "1.0")
                        {
                            ThrowFormatException(SRID.InvalidVersion);
                        }
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else if (reader.NamespaceURI == "http://www.w3.org/XML/1998/namespace")
                {
                    string localName = reader.LocalName;
                    if (!(localName == "lang"))
                    {
                        if (localName == "base")
                        {
                            CheckForDuplicates(ref dest3, reader);
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        CheckForDuplicates(ref dest2, reader);
                        try
                        {
                            cultureInfo = new CultureInfo(dest2);
                        }
                        catch (ArgumentException ex)
                        {
                            innerException = ex;
                            int num = reader.Value.IndexOf("-", StringComparison.Ordinal);
                            if (num > 0)
                            {
                                try
                                {
                                    cultureInfo = new CultureInfo(reader.Value.Substring(0, num));
                                }
                                catch (ArgumentException)
                                {
                                    flag = true;
                                }
                            }
                            else
                            {
                                flag = true;
                            }
                        }
                    }
                }
                else if (reader.NamespaceURI == "http://www.w3.org/2000/xmlns/")
                {
                    if (reader.Value != "http://www.w3.org/2001/10/synthesis" && reader.Value != "http://schemas.microsoft.com/Speech/2003/03/PromptEngine")
                    {
                        ssmlAttributes._unknownNamespaces.Add(new SsmlXmlAttribute(reader.Prefix, reader.LocalName, reader.Value, reader.NamespaceURI));
                    }
                    else if (reader.Value == "http://schemas.microsoft.com/Speech/2003/03/PromptEngine")
                    {
                        engine.ContainsPexml(reader.LocalName);
                    }
                }
                else
                {
                    list.Add(new SsmlXmlAttribute(reader.Prefix, reader.LocalName, reader.Value, reader.NamespaceURI));
                }
                if (flag)
                {
                    ThrowFormatException(innerException, SRID.InvalidElement, reader.Name);
                }
            }
            if (string.IsNullOrEmpty(dest))
            {
                ThrowFormatException(SRID.MissingRequiredAttribute, "version", "speak");
            }
            if (string.IsNullOrEmpty(dest2))
            {
                ThrowFormatException(SRID.MissingRequiredAttribute, "lang", "speak");
            }
            List<SsmlXmlAttribute> extraAttributes = null;
            foreach (SsmlXmlAttribute item in list)
            {
                ssmlAttributes.AddUnknowAttribute(item, ref extraAttributes);
            }
            voice = engine.ProcessSpeak(dest, dest3, cultureInfo, ssmlAttributes._unknownNamespaces);
            ssmlAttributes._fragmentState.LangId = cultureInfo.LCID;
            ssmlAttributes._voice = voice;
            ssmlAttributes._baseUri = dest3;
            SsmlElement possibleElements = SsmlElement.Voice | SsmlElement.Audio | SsmlElement.Lexicon | SsmlElement.Meta | SsmlElement.MetaData | SsmlElement.Sentence | SsmlElement.Paragraph | SsmlElement.SayAs | SsmlElement.Phoneme | SsmlElement.Sub | SsmlElement.Emphasis | SsmlElement.Break | SsmlElement.Prosody | SsmlElement.Mark | SsmlElement.Text | SsmlElement.PromptEngineOutput | ElementPromptEngine(ssmlAttributes);
            ProcessElement(reader, engine, "speak", possibleElements, ssmlAttributes, false, extraAttributes);
            engine.EndSpeakElement();
        }

        private static void ProcessElement(XmlReader reader, ISsmlParser engine, string sElement, SsmlElement possibleElements, SsmlAttributes ssmAttributesParent, bool fIgnore, List<SsmlXmlAttribute> extraAttributes)
        {
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            ssmlAttributes = ssmAttributesParent;
            if (extraAttributes != null && extraAttributes.Count > 0)
            {
                engine.StartProcessUnknownAttributes(ssmlAttributes._voice, ref ssmlAttributes._fragmentState, sElement, extraAttributes);
            }
            reader.MoveToElement();
            if (!reader.IsEmptyElement)
            {
                reader.Read();
                do
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            {
                                int num = Array.BinarySearch(_elementsName, reader.LocalName);
                                if (num >= 0)
                                {
                                    _parseElements[num](reader, engine, possibleElements, ssmlAttributes, fIgnore);
                                }
                                else
                                {
                                    if (ssmlAttributes.IsOtherNamespaceElement(reader))
                                    {
                                        engine.ProcessUnknownElement(ssmlAttributes._voice, ref ssmlAttributes._fragmentState, reader);
                                        break;
                                    }
                                    ThrowFormatException(SRID.InvalidElement, reader.Name);
                                }
                                reader.Read();
                                break;
                            }
                        case XmlNodeType.Text:
                            if ((possibleElements & SsmlElement.Text) != 0)
                            {
                                engine.ProcessText(reader.Value, ssmlAttributes._voice, ref ssmlAttributes._fragmentState, GetColumnPosition(reader), fIgnore);
                            }
                            else
                            {
                                ThrowFormatException(SRID.InvalidElement, reader.Name);
                            }
                            reader.Read();
                            break;
                        default:
                            reader.Read();
                            break;
                        case XmlNodeType.EndElement:
                            break;
                    }
                }
                while (reader.NodeType != XmlNodeType.EndElement && reader.NodeType != 0);
            }
            if (extraAttributes != null && extraAttributes.Count > 0)
            {
                engine.EndProcessUnknownAttributes(ssmlAttributes._voice, ref ssmlAttributes._fragmentState, sElement, extraAttributes);
            }
        }

        private static void ParseAudio(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(element, SsmlElement.Audio, reader.Name);
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            List<SsmlXmlAttribute> extraAttributes = null;
            ssmlAttributes = ssmAttributesParent;
            string dest = null;
            bool flag = false;
            while (reader.MoveToNextAttribute())
            {
                bool flag2 = reader.NamespaceURI.Length != 0;
                if (!flag2)
                {
                    string localName = reader.LocalName;
                    if (localName == "src")
                    {
                        CheckForDuplicates(ref dest, reader);
                        try
                        {
                            engine.ProcessAudio(ssmlAttributes._voice, dest, ssmlAttributes._baseUri, fIgnore);
                        }
                        catch (IOException)
                        {
                            flag = true;
                        }
                        catch (WebException)
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        flag2 = true;
                    }
                }
                if (flag2 && !ssmlAttributes.AddUnknowAttribute(reader, ref extraAttributes))
                {
                    ThrowFormatException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            ssmlAttributes._fRenderDesc = flag;
            SsmlElement possibleElements = SsmlElement.Voice | SsmlElement.Audio | SsmlElement.Sentence | SsmlElement.Paragraph | SsmlElement.SayAs | SsmlElement.Phoneme | SsmlElement.Sub | SsmlElement.Emphasis | SsmlElement.Break | SsmlElement.Prosody | SsmlElement.Mark | SsmlElement.Desc | SsmlElement.Text | SsmlElement.PromptEngineOutput | ElementPromptEngine(ssmlAttributes);
            ProcessElement(reader, engine, sElement, possibleElements, ssmlAttributes, !flag, extraAttributes);
            engine.EndElement();
        }

        private static void ParseBreak(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(element, SsmlElement.Break, reader.Name);
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            List<SsmlXmlAttribute> extraAttributes = null;
            ssmlAttributes = ssmAttributesParent;
            ssmlAttributes._fragmentState.Action = TtsEngineAction.Silence;
            ssmlAttributes._fragmentState.Emphasis = -7;
            string dest = null;
            string dest2 = null;
            while (reader.MoveToNextAttribute())
            {
                bool flag = reader.NamespaceURI.Length != 0;
                if (!flag)
                {
                    string localName = reader.LocalName;
                    if (!(localName == "time"))
                    {
                        if (localName == "strength")
                        {
                            CheckForDuplicates(ref dest2, reader);
                            if (dest == null)
                            {
                                ssmlAttributes._fragmentState.Duration = 0;
                                int num = Array.BinarySearch(_breakStrength, dest2);
                                if (num < 0)
                                {
                                    flag = true;
                                }
                                else if (ssmlAttributes._fragmentState.Emphasis != -1)
                                {
                                    ssmlAttributes._fragmentState.Emphasis = (int)_breakEmphasis[num];
                                }
                            }
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        CheckForDuplicates(ref dest, reader);
                        ssmlAttributes._fragmentState.Emphasis = -1;
                        ssmlAttributes._fragmentState.Duration = ParseCSS2Time(dest);
                        flag = (ssmlAttributes._fragmentState.Duration < 0);
                    }
                }
                if (flag && !ssmlAttributes.AddUnknowAttribute(reader, ref extraAttributes))
                {
                    ThrowFormatException(SRID.InvalidSpeakAttribute, reader.Name, "break");
                }
            }
            engine.ProcessBreak(ssmlAttributes._voice, ref ssmlAttributes._fragmentState, (EmphasisBreak)ssmlAttributes._fragmentState.Emphasis, ssmlAttributes._fragmentState.Duration, fIgnore);
            ProcessElement(reader, engine, sElement, (SsmlElement)0, ssmlAttributes, true, extraAttributes);
            engine.EndElement();
        }

        private static void ParseDesc(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(element, SsmlElement.Desc, reader.Name);
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            List<SsmlXmlAttribute> extraAttributes = null;
            ssmlAttributes = ssmAttributesParent;
            string dest = null;
            CultureInfo cultureInfo = null;
            while (reader.MoveToNextAttribute())
            {
                bool flag = reader.NamespaceURI != "http://www.w3.org/XML/1998/namespace";
                if (!flag)
                {
                    string localName = reader.LocalName;
                    if (localName == "lang")
                    {
                        CheckForDuplicates(ref dest, reader);
                        try
                        {
                            cultureInfo = new CultureInfo(dest);
                        }
                        catch (ArgumentException)
                        {
                            flag = true;
                        }
                        flag = (flag && cultureInfo != null);
                    }
                    else
                    {
                        flag = true;
                    }
                }
                if (flag && !ssmlAttributes.AddUnknowAttribute(reader, ref extraAttributes))
                {
                    ThrowFormatException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            engine.ProcessDesc(cultureInfo);
            ProcessElement(reader, engine, sElement, SsmlElement.Text, ssmlAttributes, true, extraAttributes);
            engine.EndElement();
        }

        private static void ParseEmphasis(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(element, SsmlElement.Emphasis, reader.Name);
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            List<SsmlXmlAttribute> extraAttributes = null;
            ssmlAttributes = ssmAttributesParent;
            ssmlAttributes._fragmentState.Emphasis = 2;
            string dest = null;
            while (reader.MoveToNextAttribute())
            {
                bool flag = reader.NamespaceURI.Length != 0;
                if (!flag)
                {
                    string localName = reader.LocalName;
                    if (localName == "level")
                    {
                        CheckForDuplicates(ref dest, reader);
                        int num = Array.BinarySearch(_emphasisNames, dest);
                        if (num < 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            ssmlAttributes._fragmentState.Emphasis = (int)_emphasisWord[num];
                        }
                    }
                    else
                    {
                        flag = true;
                    }
                }
                if (flag && !ssmlAttributes.AddUnknowAttribute(reader, ref extraAttributes))
                {
                    ThrowFormatException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            engine.ProcessEmphasis(!string.IsNullOrEmpty(dest), (EmphasisWord)ssmlAttributes._fragmentState.Emphasis);
            SsmlElement possibleElements = SsmlElement.AudioMarkTextWithStyle | ElementPromptEngine(ssmlAttributes);
            ProcessElement(reader, engine, sElement, possibleElements, ssmlAttributes, fIgnore, extraAttributes);
            engine.EndElement();
        }

        private static void ParseMark(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(element, SsmlElement.Mark, reader.Name);
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            List<SsmlXmlAttribute> extraAttributes = null;
            ssmlAttributes = ssmAttributesParent;
            string dest = null;
            while (reader.MoveToNextAttribute())
            {
                bool flag = reader.NamespaceURI.Length != 0;
                if (!flag)
                {
                    string localName = reader.LocalName;
                    if (localName == "name")
                    {
                        CheckForDuplicates(ref dest, reader);
                    }
                    else
                    {
                        flag = true;
                    }
                }
                if (flag && !ssmlAttributes.AddUnknowAttribute(reader, ref extraAttributes))
                {
                    ThrowFormatException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            if (string.IsNullOrEmpty(dest))
            {
                ThrowFormatException(SRID.MissingRequiredAttribute, "name", "mark");
            }
            ssmlAttributes._fragmentState.Action = TtsEngineAction.Bookmark;
            engine.ProcessMark(ssmlAttributes._voice, ref ssmlAttributes._fragmentState, dest, fIgnore);
            ProcessElement(reader, engine, sElement, (SsmlElement)0, ssmlAttributes, true, extraAttributes);
            engine.EndElement();
        }

        private static void ParseMetaData(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            ValidateElement(element, SsmlElement.MetaData, reader.Name);
            if (reader.IsEmptyElement)
            {
                return;
            }
            int num = 1;
            do
            {
                reader.Read();
                if (reader.NodeType == XmlNodeType.Element)
                {
                    num++;
                }
                if (reader.NodeType == XmlNodeType.EndElement || reader.NodeType == XmlNodeType.None)
                {
                    num--;
                }
            }
            while (num > 0);
        }

        private static void ParseParagraph(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(element, SsmlElement.Paragraph, reader.Name);
            ParseTextBlock(reader, engine, true, sElement, ssmAttributesParent, fIgnore);
        }

        private static void ParseSentence(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(element, SsmlElement.Sentence, reader.Name);
            ParseTextBlock(reader, engine, false, sElement, ssmAttributesParent, fIgnore);
        }

        private static void ParseTextBlock(XmlReader reader, ISsmlParser engine, bool isParagraph, string sElement, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            List<SsmlXmlAttribute> extraAttributes = null;
            ssmlAttributes = ssmAttributesParent;
            string dest = null;
            CultureInfo cultureInfo = null;
            while (reader.MoveToNextAttribute())
            {
                bool flag = reader.NamespaceURI != "http://www.w3.org/XML/1998/namespace";
                if (!flag)
                {
                    string localName = reader.LocalName;
                    if (localName == "lang")
                    {
                        CheckForDuplicates(ref dest, reader);
                        try
                        {
                            cultureInfo = new CultureInfo(dest);
                        }
                        catch (ArgumentException)
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        flag = true;
                    }
                }
                if (flag && !ssmlAttributes.AddUnknowAttribute(reader, ref extraAttributes))
                {
                    ThrowFormatException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            bool flag2 = cultureInfo != null && cultureInfo.LCID != ssmlAttributes._fragmentState.LangId;
            ssmlAttributes._voice = engine.ProcessTextBlock(isParagraph, ssmlAttributes._voice, ref ssmlAttributes._fragmentState, cultureInfo, flag2, ssmlAttributes._gender, ssmlAttributes._age);
            if (flag2)
            {
                ssmlAttributes._fragmentState.LangId = cultureInfo.LCID;
            }
            SsmlElement ssmlElement = SsmlElement.AudioMarkTextWithStyle | ElementPromptEngine(ssmlAttributes);
            if (isParagraph)
            {
                ssmlElement |= SsmlElement.Sentence;
            }
            ProcessElement(reader, engine, sElement, ssmlElement, ssmlAttributes, fIgnore, extraAttributes);
            engine.EndProcessTextBlock(isParagraph);
            engine.EndElement();
        }

        private static void ParsePhoneme(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(element, SsmlElement.Phoneme, reader.Name);
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            List<SsmlXmlAttribute> extraAttributes = null;
            ssmlAttributes = ssmAttributesParent;
            string dest = null;
            AlphabetType alphabetType = AlphabetType.Ipa;
            string dest2 = null;
            char[] array = null;
            while (reader.MoveToNextAttribute())
            {
                bool flag = reader.NamespaceURI.Length != 0;
                if (!flag)
                {
                    string localName = reader.LocalName;
                    if (!(localName == "alphabet"))
                    {
                        if (localName == "ph")
                        {
                            CheckForDuplicates(ref dest2, reader);
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        CheckForDuplicates(ref dest, reader);
                        switch (dest)
                        {
                            case "ipa":
                                alphabetType = AlphabetType.Ipa;
                                break;
                            case "sapi":
                            case "x-sapi":
                            case "x-microsoft-sapi":
                                alphabetType = AlphabetType.Sapi;
                                break;
                            case "ups":
                            case "x-ups":
                            case "x-microsoft-ups":
                                alphabetType = AlphabetType.Ups;
                                break;
                            default:
                                throw new FormatException(SR.Get(SRID.UnsupportedAlphabet));
                        }
                    }
                }
                if (flag && !ssmlAttributes.AddUnknowAttribute(reader, ref extraAttributes))
                {
                    ThrowFormatException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            if (string.IsNullOrEmpty(dest2))
            {
                ThrowFormatException(SRID.MissingRequiredAttribute, "ph", "phoneme");
            }
            try
            {
                switch (alphabetType)
                {
                    case AlphabetType.Sapi:
                        array = PhonemeConverter.ConvertPronToId(dest2, ssmlAttributes._fragmentState.LangId).ToCharArray();
                        break;
                    case AlphabetType.Ups:
                        array = PhonemeConverter.UpsConverter.ConvertPronToId(dest2).ToCharArray();
                        alphabetType = AlphabetType.Ipa;
                        break;
                    default:
                        array = dest2.ToCharArray();
                        try
                        {
                            PhonemeConverter.ValidateUpsIds(array);
                        }
                        catch (FormatException)
                        {
                            if (dest != null)
                            {
                                throw;
                            }
                            array = PhonemeConverter.ConvertPronToId(dest2, ssmlAttributes._fragmentState.LangId).ToCharArray();
                            alphabetType = AlphabetType.Sapi;
                        }
                        break;
                }
            }
            catch (FormatException)
            {
                ThrowFormatException(SRID.InvalidItemAttribute, "phoneme");
            }
            engine.ProcessPhoneme(ref ssmlAttributes._fragmentState, alphabetType, dest2, array);
            ProcessElement(reader, engine, sElement, SsmlElement.Text, ssmlAttributes, fIgnore, extraAttributes);
            engine.EndElement();
        }

        private static void ParseProsody(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(element, SsmlElement.Prosody, reader.Name);
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            List<SsmlXmlAttribute> extraAttributes = null;
            ssmlAttributes = ssmAttributesParent;
            string attribute = null;
            string dest = null;
            string attribute2 = null;
            string attribute3 = null;
            string dest2 = null;
            string attribute4 = null;
            Prosody prosody = (ssmlAttributes._fragmentState.Prosody != null) ? ssmlAttributes._fragmentState.Prosody.Clone() : new Prosody();
            while (reader.MoveToNextAttribute())
            {
                bool flag = reader.NamespaceURI.Length != 0;
                if (!flag)
                {
                    switch (reader.LocalName)
                    {
                        case "pitch":
                            flag = ParseNumberHz(reader, ref attribute, _pitchNames, _pitchWords, ref prosody._pitch);
                            break;
                        case "range":
                            flag = ParseNumberHz(reader, ref attribute2, _rangeNames, _rangeWords, ref prosody._range);
                            break;
                        case "rate":
                            flag = ParseNumberRelative(reader, ref attribute3, _rateNames, _rateWords, ref prosody._rate);
                            break;
                        case "volume":
                            flag = ParseNumberRelative(reader, ref attribute4, _volumeNames, _volumeWords, ref prosody._volume);
                            break;
                        case "duration":
                            CheckForDuplicates(ref dest2, reader);
                            prosody.Duration = ParseCSS2Time(dest2);
                            break;
                        case "contour":
                            CheckForDuplicates(ref dest, reader);
                            prosody.SetContourPoints(ParseContour(dest));
                            if (prosody.GetContourPoints() == null)
                            {
                                flag = true;
                            }
                            break;
                        default:
                            flag = true;
                            break;
                    }
                }
                if (flag && !ssmlAttributes.AddUnknowAttribute(reader, ref extraAttributes))
                {
                    ThrowFormatException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            if (string.IsNullOrEmpty(attribute) && string.IsNullOrEmpty(dest) && string.IsNullOrEmpty(attribute2) && string.IsNullOrEmpty(attribute3) && string.IsNullOrEmpty(dest2) && string.IsNullOrEmpty(attribute4))
            {
                ThrowFormatException(SRID.MissingRequiredAttribute, "pitch, contour, range, rate, duration, volume", "prosody");
            }
            ssmlAttributes._fragmentState.Prosody = prosody;
            engine.ProcessProsody(attribute, attribute2, attribute3, attribute4, dest2, dest);
            SsmlElement possibleElements = SsmlElement.Voice | SsmlElement.Audio | SsmlElement.Sentence | SsmlElement.Paragraph | SsmlElement.SayAs | SsmlElement.Phoneme | SsmlElement.Sub | SsmlElement.Emphasis | SsmlElement.Break | SsmlElement.Prosody | SsmlElement.Mark | SsmlElement.Text | SsmlElement.PromptEngineOutput | ElementPromptEngine(ssmlAttributes);
            ProcessElement(reader, engine, sElement, possibleElements, ssmlAttributes, fIgnore, extraAttributes);
            engine.EndElement();
        }

        private static void ParseSayAs(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(element, SsmlElement.SayAs, reader.Name);
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            List<SsmlXmlAttribute> extraAttributes = null;
            ssmlAttributes = ssmAttributesParent;
            string dest = null;
            string dest2 = null;
            string dest3 = null;
            TTSEngine.SayAs sayAs = new TTSEngine.SayAs();
            while (reader.MoveToNextAttribute())
            {
                bool flag = reader.NamespaceURI.Length != 0;
                if (!flag)
                {
                    switch (reader.LocalName)
                    {
                        case "type":
                        case "interpret-as":
                            CheckForDuplicates(ref dest, reader);
                            sayAs.InterpretAs = dest;
                            break;
                        case "format":
                            CheckForDuplicates(ref dest2, reader);
                            sayAs.Format = dest2;
                            break;
                        case "detail":
                            CheckForDuplicates(ref dest3, reader);
                            sayAs.Detail = dest3;
                            break;
                        default:
                            flag = true;
                            break;
                    }
                }
                if (flag && !ssmlAttributes.AddUnknowAttribute(reader, ref extraAttributes))
                {
                    ThrowFormatException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            if (string.IsNullOrEmpty(dest))
            {
                ThrowFormatException(SRID.MissingRequiredAttribute, "interpret-as", "say-as");
            }
            ssmlAttributes._fragmentState.SayAs = sayAs;
            engine.ProcessSayAs(dest, dest2, dest3);
            ProcessElement(reader, engine, sElement, SsmlElement.Text, ssmlAttributes, fIgnore, extraAttributes);
            engine.EndElement();
        }

        private static void ParseSub(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(element, SsmlElement.Sub, reader.Name);
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            List<SsmlXmlAttribute> extraAttributes = null;
            ssmlAttributes = ssmAttributesParent;
            string dest = null;
            int position = 0;
            while (reader.MoveToNextAttribute())
            {
                bool flag = reader.NamespaceURI.Length != 0;
                if (!flag)
                {
                    string localName = reader.LocalName;
                    if (localName == "alias")
                    {
                        CheckForDuplicates(ref dest, reader);
                        XmlTextReader xmlTextReader = reader as XmlTextReader;
                        if (xmlTextReader != null && engine.Ssml != null)
                        {
                            position = engine.Ssml.IndexOf(reader.Value, xmlTextReader.LinePosition + reader.LocalName.Length, StringComparison.Ordinal);
                        }
                    }
                    else
                    {
                        flag = true;
                    }
                }
                if (flag && !ssmlAttributes.AddUnknowAttribute(reader, ref extraAttributes))
                {
                    ThrowFormatException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            if (string.IsNullOrEmpty(dest))
            {
                ThrowFormatException(SRID.MissingRequiredAttribute, "alias", "sub");
            }
            engine.ProcessSub(dest, ssmlAttributes._voice, ref ssmlAttributes._fragmentState, position, fIgnore);
            ProcessElement(reader, engine, sElement, SsmlElement.Text, ssmlAttributes, true, extraAttributes);
            engine.EndElement();
        }

        private static void ParseVoice(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(element, SsmlElement.Voice, reader.Name);
            if (ssmAttributesParent._cPromptOutput > 0)
            {
                ThrowFormatException(SRID.InvalidVoiceElementInPromptOutput);
            }
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            ssmlAttributes = ssmAttributesParent;
            string dest = null;
            string dest2 = null;
            string dest3 = null;
            string dest4 = null;
            string dest5 = null;
            string dest6 = null;
            CultureInfo cultureInfo = null;
            int result = -1;
            List<SsmlXmlAttribute> extraAttributes = null;
            List<SsmlXmlAttribute> list = null;
            List<SsmlXmlAttribute> list2 = null;
            while (reader.MoveToNextAttribute())
            {
                bool flag = false;
                if (reader.NamespaceURI.Length == 0)
                {
                    switch (reader.LocalName)
                    {
                        case "gender":
                            {
                                CheckForDuplicates(ref dest2, reader);
                                VoiceGender gender;
                                if (!SsmlParserHelpers.TryConvertGender(dest2, out gender))
                                {
                                    flag = true;
                                }
                                else
                                {
                                    ssmlAttributes._gender = gender;
                                }
                                break;
                            }
                        case "age":
                            {
                                CheckForDuplicates(ref dest5, reader);
                                VoiceAge age;
                                if (!SsmlParserHelpers.TryConvertAge(dest5, out age))
                                {
                                    flag = true;
                                }
                                else
                                {
                                    ssmlAttributes._age = age;
                                }
                                break;
                            }
                        case "variant":
                            CheckForDuplicates(ref dest3, reader);
                            if (!int.TryParse(dest3, out result) || result <= 0)
                            {
                                flag = true;
                            }
                            break;
                        case "name":
                            CheckForDuplicates(ref dest4, reader);
                            break;
                        default:
                            flag = true;
                            break;
                    }
                }
                else if (reader.Prefix == "xmlns" && reader.Value == "http://schemas.microsoft.com/Speech/2003/03/PromptEngine")
                {
                    CheckForDuplicates(ref dest6, reader);
                }
                else if (reader.NamespaceURI == "http://www.w3.org/XML/1998/namespace")
                {
                    string localName = reader.LocalName;
                    if (localName == "lang")
                    {
                        CheckForDuplicates(ref dest, reader);
                        try
                        {
                            cultureInfo = new CultureInfo(dest);
                        }
                        catch (ArgumentException)
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else if (reader.NamespaceURI == "http://www.w3.org/2000/xmlns/")
                {
                    if (reader.Value != "http://www.w3.org/2001/10/synthesis")
                    {
                        if (list2 == null)
                        {
                            list2 = new List<SsmlXmlAttribute>();
                        }
                        SsmlXmlAttribute item = new SsmlXmlAttribute(reader.Prefix, reader.LocalName, reader.Value, reader.NamespaceURI);
                        list2.Add(item);
                        ssmlAttributes._unknownNamespaces.Add(item);
                    }
                }
                else
                {
                    if (list == null)
                    {
                        list = new List<SsmlXmlAttribute>();
                    }
                    list.Add(new SsmlXmlAttribute(reader.Prefix, reader.LocalName, reader.Value, reader.NamespaceURI));
                }
                if (flag && !ssmlAttributes.AddUnknowAttribute(reader, ref extraAttributes))
                {
                    ThrowFormatException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            if (list != null)
            {
                foreach (SsmlXmlAttribute item2 in list)
                {
                    ssmlAttributes.AddUnknowAttribute(item2, ref extraAttributes);
                }
            }
            if (string.IsNullOrEmpty(dest) && string.IsNullOrEmpty(dest2) && string.IsNullOrEmpty(dest5) && string.IsNullOrEmpty(dest3) && string.IsNullOrEmpty(dest4) && string.IsNullOrEmpty(dest6))
            {
                ThrowFormatException(SRID.MissingRequiredAttribute, "'xml:lang' or 'gender' or 'age' or 'variant' or 'name'", "voice");
            }
            cultureInfo = ((cultureInfo == null) ? new CultureInfo(ssmlAttributes._fragmentState.LangId) : cultureInfo);
            bool fNewCulture = cultureInfo.LCID != ssmlAttributes._fragmentState.LangId;
            ssmlAttributes._voice = engine.ProcessVoice(dest4, cultureInfo, ssmlAttributes._gender, ssmlAttributes._age, result, fNewCulture, list2);
            ssmlAttributes._fragmentState.LangId = cultureInfo.LCID;
            SsmlElement possibleElements = SsmlElement.Voice | SsmlElement.Audio | SsmlElement.Sentence | SsmlElement.Paragraph | SsmlElement.SayAs | SsmlElement.Phoneme | SsmlElement.Sub | SsmlElement.Emphasis | SsmlElement.Break | SsmlElement.Prosody | SsmlElement.Mark | SsmlElement.Text | SsmlElement.PromptEngineOutput | ElementPromptEngine(ssmlAttributes);
            ProcessElement(reader, engine, sElement, possibleElements, ssmlAttributes, fIgnore, extraAttributes);
            if (list2 != null)
            {
                foreach (SsmlXmlAttribute item3 in list2)
                {
                    ssmlAttributes._unknownNamespaces.Remove(item3);
                }
            }
            engine.EndElement();
        }

        private static void ParseLexicon(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(element, SsmlElement.Lexicon, reader.Name);
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            List<SsmlXmlAttribute> extraAttributes = null;
            ssmlAttributes = ssmAttributesParent;
            string dest = null;
            string dest2 = null;
            while (reader.MoveToNextAttribute())
            {
                bool flag = reader.NamespaceURI.Length != 0;
                if (!flag)
                {
                    string localName = reader.LocalName;
                    if (!(localName == "uri"))
                    {
                        if (localName == "type")
                        {
                            CheckForDuplicates(ref dest2, reader);
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        CheckForDuplicates(ref dest, reader);
                    }
                }
                if (flag && !ssmlAttributes.AddUnknowAttribute(reader, ref extraAttributes))
                {
                    ThrowFormatException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            if (string.IsNullOrEmpty(dest))
            {
                ThrowFormatException(SRID.MissingRequiredAttribute, "uri", "lexicon");
            }
            Uri uri = new Uri(dest, UriKind.RelativeOrAbsolute);
            if (!uri.IsAbsoluteUri && ssmlAttributes._baseUri != null)
            {
                dest = ssmlAttributes._baseUri + "/" + dest;
                uri = new Uri(dest, UriKind.RelativeOrAbsolute);
            }
            engine.ProcessLexicon(uri, dest2);
            ProcessElement(reader, engine, sElement, (SsmlElement)0, ssmlAttributes, true, extraAttributes);
            engine.EndElement();
        }

        private static void ParsePromptEngine0(XmlReader reader, ISsmlParser engine, SsmlElement elementAllowed, SsmlElement element, ProcessPromptEngine0 process, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(elementAllowed, element, reader.Name);
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            ssmlAttributes = ssmAttributesParent;
            while (reader.MoveToNextAttribute())
            {
                if (reader.NamespaceURI == "http://www.w3.org/2000/xmlns/" && reader.Value == "http://schemas.microsoft.com/Speech/2003/03/PromptEngine")
                {
                    engine.ContainsPexml(reader.LocalName);
                }
                else
                {
                    ThrowFormatException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            if (!process(ssmlAttributes._voice))
            {
                ThrowFormatException(SRID.InvalidElement, reader.Name);
            }
            ProcessElement(reader, engine, sElement, SsmlElement.AudioMarkTextWithStyle | ElementPromptEngine(ssmlAttributes), ssmlAttributes, fIgnore, null);
        }

        private static string ParsePromptEngine1(XmlReader reader, ISsmlParser engine, SsmlElement elementAllowed, SsmlElement element, string attribute, ProcessPromptEngine1 process, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(elementAllowed, element, reader.Name);
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            ssmlAttributes = ssmAttributesParent;
            string dest = null;
            while (reader.MoveToNextAttribute())
            {
                if (reader.LocalName == attribute)
                {
                    CheckForDuplicates(ref dest, reader);
                }
                else
                {
                    ThrowFormatException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            if (!process(ssmlAttributes._voice, dest))
            {
                ThrowFormatException(SRID.InvalidElement, reader.Name);
            }
            ProcessElement(reader, engine, sElement, SsmlElement.AudioMarkTextWithStyle | ElementPromptEngine(ssmlAttributes), ssmlAttributes, fIgnore, null);
            return dest;
        }

        private static void ParsePromptOutput(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            ssmAttributesParent._cPromptOutput++;
            ParsePromptEngine0(reader, engine, element, SsmlElement.PromptEngineOutput, engine.BeginPromptEngineOutput, ssmAttributesParent, fIgnore);
            engine.EndElement();
            ssmAttributesParent._cPromptOutput--;
            engine.EndPromptEngineOutput(ssmAttributesParent._voice);
        }

        private static void ParseDiv(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            ParsePromptEngine0(reader, engine, element, SsmlElement.PromptEngineDiv, engine.ProcessPromptEngineDiv, ssmAttributesParent, fIgnore);
            engine.EndElement();
        }

        private static void ParseDatabase(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string sElement = ValidateElement(element, SsmlElement.PromptEngineDatabase, reader.Name);
            SsmlAttributes ssmlAttributes = default(SsmlAttributes);
            ssmlAttributes = ssmAttributesParent;
            string dest = null;
            string dest2 = null;
            string dest3 = null;
            while (reader.MoveToNextAttribute())
            {
                bool flag = false;
                if (!flag)
                {
                    switch (reader.LocalName)
                    {
                        case "fname":
                            CheckForDuplicates(ref dest, reader);
                            break;
                        case "idset":
                            CheckForDuplicates(ref dest3, reader);
                            break;
                        case "delta":
                            CheckForDuplicates(ref dest2, reader);
                            break;
                        default:
                            flag = true;
                            break;
                    }
                }
                if (flag)
                {
                    ThrowFormatException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            if (!engine.ProcessPromptEngineDatabase(ssmlAttributes._voice, dest, dest2, dest3))
            {
                ThrowFormatException(SRID.InvalidElement, reader.Name);
            }
            ProcessElement(reader, engine, sElement, (SsmlElement)0, ssmlAttributes, fIgnore, null);
            engine.EndElement();
        }

        private static void ParseId(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            ParsePromptEngine1(reader, engine, element, SsmlElement.PromptEngineId, "id", engine.ProcessPromptEngineId, ssmAttributesParent, fIgnore);
            engine.EndElement();
        }

        private static void ParseTts(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            ParsePromptEngine0(reader, engine, element, SsmlElement.PromptEngineTTS, engine.BeginPromptEngineTts, ssmAttributesParent, fIgnore);
            engine.EndElement();
            engine.EndPromptEngineTts(ssmAttributesParent._voice);
        }

        private static void ParseWithTag(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string tag = ParsePromptEngine1(reader, engine, element, SsmlElement.PromptEngineWithTag, "tag", engine.BeginPromptEngineWithTag, ssmAttributesParent, fIgnore);
            engine.EndElement();
            engine.EndPromptEngineWithTag(ssmAttributesParent._voice, tag);
        }

        private static void ParseRule(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmAttributesParent, bool fIgnore)
        {
            string name = ParsePromptEngine1(reader, engine, element, SsmlElement.PromptEngineRule, "name", engine.BeginPromptEngineRule, ssmAttributesParent, fIgnore);
            engine.EndElement();
            engine.EndPromptEngineRule(ssmAttributesParent._voice, name);
        }

        private static void CheckForDuplicates(ref string dest, XmlReader reader)
        {
            if (!string.IsNullOrEmpty(dest))
            {
                StringBuilder stringBuilder = new StringBuilder(reader.LocalName);
                if (reader.NamespaceURI.Length > 0)
                {
                    stringBuilder.Append(reader.NamespaceURI);
                    stringBuilder.Append(":");
                }
                ThrowFormatException(SRID.InvalidAttributeDefinedTwice, reader.Value, stringBuilder);
            }
            dest = reader.Value;
        }

        private static int ParseCSS2Time(string time)
        {
            time = time.Trim(Helpers._achTrimChars);
            int num = time.IndexOf("ms", StringComparison.Ordinal);
            int result = -1;
            float result2;
            if (num > 0 && time.Length == num + 2)
            {
                result = (float.TryParse(time.Substring(0, num), out result2) ? ((int)((double)result2 + 0.5)) : (-1));
            }
            else if ((num = time.IndexOf('s')) > 0 && time.Length == num + 1)
            {
                result = (float.TryParse(time.Substring(0, num), out result2) ? ((int)(result2 * 1000f)) : (-1));
            }
            return result;
        }

        private static ContourPoint[] ParseContour(string contour)
        {
            char[] array = contour.ToCharArray();
            List<ContourPoint> list = new List<ContourPoint>();
            int num = 0;
            try
            {
                bool percent;
                while (num < array.Length && (num = NextChar(array, num, '(', false, out percent)) >= 0)
                {
                    bool percent2;
                    int num2 = NextChar(array, num, ',', true, out percent2);
                    int num3 = NextChar(array, num2, ')', true, out percent);
                    ProsodyNumber number = default(ProsodyNumber);
                    ProsodyNumber number2 = default(ProsodyNumber);
                    if (!percent2 || !TryParseNumber(contour.Substring(num, num2 - (num + 1)), ref number) || number.SsmlAttributeId == int.MaxValue)
                    {
                        return null;
                    }
                    bool isHz;
                    if (!TryParseHz(contour.Substring(num2, num3 - (num2 + 1)), ref number2, true, out isHz))
                    {
                        return null;
                    }
                    if (list.Count == 0)
                    {
                        if (number.Number > 0f && number.Number < 100f)
                        {
                            list.Add(new ContourPoint(0f, number2.Number, ContourPointChangeType.Hz));
                        }
                    }
                    else if (list[list.Count - 1].Start > number.Number)
                    {
                        return null;
                    }
                    if (number.Number >= 0f && number.Number <= 1f)
                    {
                        list.Add(new ContourPoint(number.Number, number2.Number, (!isHz) ? ContourPointChangeType.Percentage : ContourPointChangeType.Hz));
                    }
                    num = num3;
                }
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            if (list.Count < 1)
            {
                return null;
            }
            if (!list[list.Count - 1].Start.Equals(1.0))
            {
                list.Add(new ContourPoint(1f, list[list.Count - 1].Change, list[list.Count - 1].ChangeType));
            }
            return list.ToArray();
        }

        private static int NextChar(char[] ach, int start, char expected, bool skipDigit, out bool percent)
        {
            percent = false;
            while (start < ach.Length && (ach[start] == ' ' || ach[start] == '\t' || ach[start] == '\n' || ach[start] == '\r'))
            {
                start++;
            }
            if (skipDigit)
            {
                while (start < ach.Length && ach[start] != expected && ((percent = (ach[start] == '%')) || char.IsDigit(ach[start]) || ach[start] == 'H' || ach[start] == 'z' || ach[start] == '.' || ach[start] == '+' || ach[start] == '-'))
                {
                    start++;
                }
                while (start < ach.Length && (ach[start] == ' ' || ach[start] == '\t' || ach[start] == '\n' || ach[start] == '\r'))
                {
                    start++;
                }
            }
            if (start >= ach.Length || ach[start] != expected)
            {
                if (!skipDigit && start == ach.Length)
                {
                    return -1;
                }
                throw new InvalidOperationException();
            }
            return start + 1;
        }

        private static bool ParseNumberHz(XmlReader reader, ref string attribute, string[] attributeValues, int[] attributeConst, ref ProsodyNumber number)
        {
            bool result = false;
            CheckForDuplicates(ref attribute, reader);
            int num = Array.BinarySearch(attributeValues, attribute);
            if (num < 0)
            {
                bool isHz;
                if (!TryParseHz(attribute, ref number, false, out isHz))
                {
                    result = true;
                }
            }
            else
            {
                number = new ProsodyNumber(attributeConst[num]);
            }
            return result;
        }

        private static bool ParseNumberRelative(XmlReader reader, ref string attribute, string[] attributeValues, int[] attributeConst, ref ProsodyNumber number)
        {
            bool result = false;
            CheckForDuplicates(ref attribute, reader);
            int num = Array.BinarySearch(attributeValues, attribute);
            if (num < 0)
            {
                if (!TryParseNumber(attribute, ref number))
                {
                    result = true;
                }
            }
            else
            {
                number = new ProsodyNumber(attributeConst[num]);
            }
            return result;
        }

        private static bool TryParseNumber(string sNumber, ref ProsodyNumber number)
        {
            bool result = false;
            decimal result2 = default(decimal);
            number.Unit = ProsodyUnit.Default;
            sNumber = sNumber.Trim(Helpers._achTrimChars);
            if (!string.IsNullOrEmpty(sNumber))
            {
                if (!decimal.TryParse(sNumber, out result2))
                {
                    if (sNumber[sNumber.Length - 1] == '%' && decimal.TryParse(sNumber.Substring(0, sNumber.Length - 1), out result2))
                    {
                        float num = (float)result2 / 100f;
                        if (sNumber[0] != '+' && sNumber[0] != '-')
                        {
                            number.Number *= num;
                        }
                        else
                        {
                            number.Number += number.Number * num;
                        }
                        result = true;
                    }
                }
                else
                {
                    if (sNumber[0] != '+' && sNumber[0] != '-')
                    {
                        number.Number = (float)result2;
                        number.SsmlAttributeId = int.MaxValue;
                    }
                    else if (number.IsNumberPercent)
                    {
                        number.Number *= (float)result2;
                    }
                    else
                    {
                        number.Number += (float)result2;
                    }
                    number.IsNumberPercent = false;
                    result = true;
                }
            }
            return result;
        }

        private static bool TryParseHz(string sNumber, ref ProsodyNumber number, bool acceptHzRelative, out bool isHz)
        {
            isHz = false;
            bool flag = false;
            number.SsmlAttributeId = int.MaxValue;
            ProsodyUnit prosodyUnit = ProsodyUnit.Default;
            sNumber = sNumber.Trim(Helpers._achTrimChars);
            if (sNumber.IndexOf("Hz", StringComparison.Ordinal) == sNumber.Length - 2)
            {
                prosodyUnit = ProsodyUnit.Hz;
            }
            else if (sNumber.IndexOf("st", StringComparison.Ordinal) == sNumber.Length - 2)
            {
                prosodyUnit = ProsodyUnit.Semitone;
            }
            if (prosodyUnit != 0)
            {
                flag = (TryParseNumber(sNumber.Substring(0, sNumber.Length - 2), ref number) && (acceptHzRelative || number.SsmlAttributeId == int.MaxValue));
                isHz = true;
            }
            else
            {
                flag = (TryParseNumber(sNumber, ref number) && number.SsmlAttributeId == int.MaxValue);
            }
            return flag;
        }

        private static string ValidateElement(SsmlElement possibleElements, SsmlElement currentElement, string sElement)
        {
            if ((possibleElements & currentElement) == 0)
            {
                ThrowFormatException(SRID.InvalidElement, sElement);
            }
            return sElement;
        }

        private static void ThrowFormatException(SRID id, params object[] args)
        {
            throw new FormatException(SR.Get(id, args));
        }

        private static void ThrowFormatException(Exception innerException, SRID id, params object[] args)
        {
            throw new FormatException(SR.Get(id, args), innerException);
        }

        private static void NoOp(XmlReader reader, ISsmlParser engine, SsmlElement element, SsmlAttributes ssmlAttributes, bool fIgnore)
        {
            ProcessElement(reader, engine, null, (SsmlElement)0, ssmlAttributes, true, null);
        }

        private static SsmlElement ElementPromptEngine(SsmlAttributes ssmlAttributes)
        {
            if (ssmlAttributes._cPromptOutput <= 0)
            {
                return (SsmlElement)0;
            }
            return SsmlElement.PromptEngineChildren;
        }

        private static int GetColumnPosition(XmlReader reader)
        {
            XmlTextReader xmlTextReader = reader as XmlTextReader;
            if (xmlTextReader == null)
            {
                return 0;
            }
            return xmlTextReader.LinePosition - 1;
        }
    }
}