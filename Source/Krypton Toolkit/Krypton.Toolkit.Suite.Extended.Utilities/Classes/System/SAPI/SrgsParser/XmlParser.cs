#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser
{
    internal class XmlParser : ISrgsParser
    {
        [Serializable]
        internal class ForwardReference
        {
            internal string _name;

            internal string _value;

            internal ForwardReference(string name, string value)
            {
                _name = name;
                _value = value;
            }
        }

        internal const string emptyNamespace = "";

        internal const string xmlNamespace = "http://www.w3.org/XML/1998/namespace";

        internal const string srgsNamespace = "http://www.w3.org/2001/06/grammar";

        internal const string sapiNamespace = "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions";

        private IElementFactory _parser;

        private XmlReader _reader;

        private XmlTextReader _xmlTextReader;

        private string _filename;

        private string _shortFilename;

        private CultureInfo _langId;

        private bool _hasTagFormat;

        private List<string> _rules = new List<string>();

        private List<ForwardReference> _scripts = new List<ForwardReference>();

        private static readonly char[] _invalidRuleIdChars = new char[4]
        {
            '.',
            ':',
            '-',
            '#'
        };

        private static readonly char[] _SlashBackSlash = new char[2]
        {
            '\\',
            '/'
        };

        public IElementFactory ElementFactory
        {
            set
            {
                _parser = value;
            }
        }

        internal XmlParser(XmlReader reader, Uri uri)
        {
            _reader = reader;
            _xmlTextReader = (reader as XmlTextReader);
            if (uri == null && _xmlTextReader != null && _xmlTextReader.BaseURI.Length > 0)
            {
                try
                {
                    uri = new Uri(_xmlTextReader.BaseURI);
                }
                catch (UriFormatException)
                {
                }
            }
            if (uri != null)
            {
                _filename = ((!uri.IsAbsoluteUri || !uri.IsFile) ? uri.OriginalString : uri.LocalPath);
                int num = _filename.LastIndexOfAny(_SlashBackSlash);
                _shortFilename = ((num >= 0) ? _filename.Substring(num + 1) : _filename);
            }
        }

        public void Parse()
        {
            try
            {
                bool flag = false;
                while (_reader.Read())
                {
                    if (_reader.NodeType == XmlNodeType.Element && _reader.LocalName == "grammar")
                    {
                        if (_reader.NamespaceURI != "http://www.w3.org/2001/06/grammar")
                        {
                            ThrowSrgsException(SRID.InvalidSrgsNamespace);
                        }
                        if (flag)
                        {
                            ThrowSrgsException(SRID.GrammarDefTwice);
                        }
                        else
                        {
                            ParseGrammar(_reader, _parser.Grammar);
                            flag = true;
                        }
                    }
                }
                if (!flag)
                {
                    ThrowSrgsException(SRID.InvalidSrgs);
                }
            }
            catch (XmlException innerException)
            {
                _parser.RemoveAllRules();
                ThrowSrgsExceptionWithPosition(_filename, _reader, SR.Get(SRID.InvalidXmlFormat), innerException);
            }
            catch (FormatException ex)
            {
                _parser.RemoveAllRules();
                ThrowSrgsExceptionWithPosition(_filename, _reader, ex.Message, ex.InnerException);
            }
            catch
            {
                _parser.RemoveAllRules();
                throw;
            }
        }

        internal static void ParseText(IElement parent, string sChars, string pronunciation, string display, float reqConfidence, CreateTokenCallback createTokens)
        {
            sChars = sChars.Trim(Helpers._achTrimChars);
            char[] array = sChars.ToCharArray();
            int num = 0;
            int length = sChars.Length;
            for (int num2 = 0; num2 < array.Length; num2 = num + 1)
            {
                if (array[num2] == ' ')
                {
                    num = num2;
                }
                else
                {
                    if (array[num2] == '"')
                    {
                        for (num = ++num2; num < length && array[num] != '"'; num++)
                        {
                        }
                        if (num >= length || array[num] != '"')
                        {
                            ThrowSrgsException(SRID.InvalidQuotedString);
                        }
                        if (num + 1 != length && array[num + 1] != ' ')
                        {
                            ThrowSrgsException(SRID.InvalidQuotedString);
                        }
                    }
                    else
                    {
                        for (num = num2 + 1; num < length && array[num] != ' '; num++)
                        {
                        }
                    }
                    string text = sChars.Substring(num2, num - num2);
                    if (text.IndexOf('"') != -1)
                    {
                        ThrowSrgsException(SRID.InvalidTokenString);
                    }
                    createTokens?.Invoke(parent, text, pronunciation, display, reqConfidence);
                }
            }
        }

        internal static void ThrowSrgsException(SRID id, params object[] args)
        {
            throw new FormatException(SR.Get(id, args));
        }

        internal static void ThrowSrgsExceptionWithPosition(string filename, XmlReader xmlReader, string sError, Exception innerException)
        {
            XmlTextReader xmlTextReader = xmlReader as XmlTextReader;
            if (xmlTextReader != null)
            {
                string text = SR.Get(SRID.Line);
                string text2 = SR.Get(SRID.Position);
                int lineNumber = xmlTextReader.LineNumber;
                int linePosition = xmlTextReader.LinePosition;
                sError = ((filename != null) ? string.Format(CultureInfo.InvariantCulture, "{0}({1},{2}): error : {3}", filename, lineNumber, linePosition, sError) : (sError + string.Format(CultureInfo.InvariantCulture, " [{0}={1}, {2}={3}]", text, lineNumber, text2, linePosition)));
            }
            throw new FormatException(sError, innerException);
        }

        private void ParseGrammar(XmlReader reader, IGrammar grammar)
        {
            string dest = null;
            string dest2 = null;
            string dest3 = null;
            string dest4 = null;
            GrammarType grammarType = GrammarType.VoiceGrammar;
            while (reader.MoveToNextAttribute())
            {
                bool flag = false;
                string namespaceURI = reader.NamespaceURI;
                if (namespaceURI == null || namespaceURI.Length != 0)
                {
                    if (!(namespaceURI == "http://www.w3.org/XML/1998/namespace"))
                    {
                        if (namespaceURI == "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions")
                        {
                            switch (reader.LocalName)
                            {
                                case "alphabet":
                                    CheckForDuplicates(ref dest, reader);
                                    switch (dest)
                                    {
                                        case "ipa":
                                            grammar.PhoneticAlphabet = AlphabetType.Ipa;
                                            break;
                                        case "sapi":
                                        case "x-sapi":
                                        case "x-microsoft-sapi":
                                            grammar.PhoneticAlphabet = AlphabetType.Sapi;
                                            break;
                                        case "ups":
                                        case "x-ups":
                                        case "x-microsoft-ups":
                                            grammar.PhoneticAlphabet = AlphabetType.Ups;
                                            break;
                                        default:
                                            ThrowSrgsException(SRID.UnsupportedPhoneticAlphabet, reader.Value);
                                            break;
                                    }
                                    break;
                                case "language":
                                    CheckForDuplicates(ref dest2, reader);
                                    if (dest2 == "C#" || dest2 == "VB.Net")
                                    {
                                        grammar.Language = dest2;
                                    }
                                    else
                                    {
                                        ThrowSrgsException(SRID.UnsupportedLanguage, reader.Value);
                                    }
                                    break;
                                case "namespace":
                                    CheckForDuplicates(ref dest3, reader);
                                    if (string.IsNullOrEmpty(dest3))
                                    {
                                        ThrowSrgsException(SRID.NoName1, "namespace");
                                    }
                                    grammar.Namespace = dest3;
                                    break;
                                case "codebehind":
                                    if (reader.Value.Length == 0)
                                    {
                                        ThrowSrgsException(SRID.NoName1, "codebehind");
                                    }
                                    grammar.CodeBehind.Add(reader.Value);
                                    break;
                                case "debug":
                                    {
                                        bool result;
                                        if (bool.TryParse(reader.Value, out result))
                                        {
                                            grammar.Debug = result;
                                        }
                                        break;
                                    }
                                default:
                                    flag = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        namespaceURI = reader.LocalName;
                        if (!(namespaceURI == "lang"))
                        {
                            if (namespaceURI == "base")
                            {
                                grammar.XmlBase = new Uri(reader.Value);
                            }
                        }
                        else
                        {
                            string value = reader.Value;
                            try
                            {
                                grammar.Culture = (_langId = new CultureInfo(value));
                            }
                            catch (ArgumentException)
                            {
                                int num = reader.Value.IndexOf("-", StringComparison.Ordinal);
                                if (num <= 0)
                                {
                                    throw;
                                }
                                grammar.Culture = (_langId = new CultureInfo(reader.Value.Substring(0, num)));
                            }
                        }
                    }
                }
                else
                {
                    switch (reader.LocalName)
                    {
                        case "root":
                            if (grammar.Root == null)
                            {
                                grammar.Root = reader.Value;
                            }
                            else
                            {
                                ThrowSrgsException(SRID.RootRuleAlreadyDefined);
                            }
                            break;
                        case "version":
                            CheckForDuplicates(ref dest4, reader);
                            if (dest4 != "1.0")
                            {
                                ThrowSrgsException(SRID.InvalidVersion);
                            }
                            break;
                        case "tag-format":
                            namespaceURI = reader.Value;
                            switch (namespaceURI)
                            {
                                default:
                                    if (namespaceURI.Length == 0)
                                    {
                                        break;
                                    }
                                    goto case null;
                                case "semantics/1.0":
                                    grammar.TagFormat = SrgsTagFormat.W3cV1;
                                    _hasTagFormat = true;
                                    break;
                                case "semantics-ms/1.0":
                                    grammar.TagFormat = SrgsTagFormat.MssV1;
                                    _hasTagFormat = true;
                                    break;
                                case "properties-ms/1.0":
                                    grammar.TagFormat = SrgsTagFormat.KeyValuePairs;
                                    _hasTagFormat = true;
                                    break;
                                case null:
                                    ThrowSrgsException(SRID.InvalidTagFormat);
                                    break;
                            }
                            break;
                        case "mode":
                            namespaceURI = reader.Value;
                            if (!(namespaceURI == "voice"))
                            {
                                if (namespaceURI == "dtmf")
                                {
                                    GrammarType grammarType3 = grammar.Mode = GrammarType.DtmfGrammar;
                                    grammarType = grammarType3;
                                }
                                else
                                {
                                    ThrowSrgsException(SRID.InvalidGrammarMode);
                                }
                            }
                            else
                            {
                                grammar.Mode = GrammarType.VoiceGrammar;
                            }
                            break;
                        default:
                            flag = true;
                            break;
                    }
                }
                if (flag)
                {
                    ThrowSrgsException(SRID.InvalidGrammarAttribute, reader.Name);
                }
            }
            if (dest4 == null)
            {
                ThrowSrgsException(SRID.MissingRequiredAttribute, "version", "grammar");
            }
            if (_langId == null)
            {
                if (grammarType == GrammarType.VoiceGrammar)
                {
                    ThrowSrgsException(SRID.MissingRequiredAttribute, "xml:lang", "grammar");
                }
                else
                {
                    _langId = CultureInfo.CurrentUICulture;
                }
            }
            ProcessRulesAndScriptsNodes(reader, grammar);
            ValidateScripts();
            foreach (ForwardReference script in _scripts)
            {
                _parser.AddScript(grammar, script._name, script._value);
            }
            grammar.PostParse(null);
        }

        private IRule ParseRule(IGrammar grammar, XmlReader reader)
        {
            string dest = null;
            string dest2 = null;
            string dest3 = null;
            RulePublic rulePublic = RulePublic.NotSet;
            RuleDynamic ruleDynamic = RuleDynamic.NotSet;
            string dest4 = null;
            string dest5 = null;
            string dest6 = null;
            string dest7 = null;
            string dest8 = null;
            while (reader.MoveToNextAttribute())
            {
                bool flag = false;
                string namespaceURI = reader.NamespaceURI;
                if (namespaceURI == null || namespaceURI.Length != 0)
                {
                    if (namespaceURI == "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions")
                    {
                        switch (reader.LocalName)
                        {
                            case "dynamic":
                                CheckForDuplicates(ref dest3, reader);
                                if (!(dest3 == "true"))
                                {
                                    if (dest3 == "false")
                                    {
                                        ruleDynamic = RuleDynamic.False;
                                    }
                                    else
                                    {
                                        ThrowSrgsException(SRID.InvalidDynamicSetting);
                                    }
                                }
                                else
                                {
                                    ruleDynamic = RuleDynamic.True;
                                }
                                break;
                            case "baseclass":
                                CheckForDuplicates(ref dest4, reader);
                                if (string.IsNullOrEmpty(dest4))
                                {
                                    ThrowSrgsException(SRID.NoName1, "baseclass");
                                }
                                break;
                            case "onInit":
                                CheckForDuplicates(ref dest5, reader);
                                dest5 = reader.Value;
                                break;
                            case "onParse":
                                CheckForDuplicates(ref dest6, reader);
                                dest6 = reader.Value;
                                break;
                            case "onError":
                                CheckForDuplicates(ref dest7, reader);
                                dest7 = reader.Value;
                                break;
                            case "onRecognition":
                                CheckForDuplicates(ref dest8, reader);
                                break;
                            default:
                                flag = true;
                                break;
                        }
                    }
                }
                else
                {
                    namespaceURI = reader.LocalName;
                    if (!(namespaceURI == "id"))
                    {
                        if (namespaceURI == "scope")
                        {
                            CheckForDuplicates(ref dest2, reader);
                            if (!(dest2 == "private"))
                            {
                                if (dest2 == "public")
                                {
                                    rulePublic = RulePublic.True;
                                }
                                else
                                {
                                    ThrowSrgsException(SRID.InvalidRuleScope);
                                }
                            }
                            else
                            {
                                rulePublic = RulePublic.False;
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
                    }
                }
                if (flag)
                {
                    ThrowSrgsException(SRID.InvalidRuleAttribute, reader.Name);
                }
            }
            if (string.IsNullOrEmpty(dest))
            {
                ThrowSrgsException(SRID.NoRuleId);
            }
            if (dest5 != null && rulePublic != 0)
            {
                ThrowSrgsException(SRID.OnInitOnPublicRule, "OnInit", dest);
            }
            if (dest8 != null && rulePublic != 0)
            {
                ThrowSrgsException(SRID.OnInitOnPublicRule, "OnRecognition", dest);
            }
            ValidateRuleId(dest);
            bool hasSCript = dest5 != null || dest6 != null || dest7 != null || dest8 != null;
            IRule rule = grammar.CreateRule(dest, rulePublic, ruleDynamic, hasSCript);
            if (!string.IsNullOrEmpty(dest5))
            {
                rule.CreateScript(grammar, dest, dest5, RuleMethodScript.onInit);
            }
            if (!string.IsNullOrEmpty(dest6))
            {
                rule.CreateScript(grammar, dest, dest6, RuleMethodScript.onParse);
            }
            if (!string.IsNullOrEmpty(dest7))
            {
                rule.CreateScript(grammar, dest, dest7, RuleMethodScript.onError);
            }
            if (!string.IsNullOrEmpty(dest8))
            {
                rule.CreateScript(grammar, dest, dest8, RuleMethodScript.onRecognition);
            }
            rule.BaseClass = dest4;
            _rules.Add(dest);
            if (!ProcessChildNodes(reader, rule, rule, "rule") && ruleDynamic != 0)
            {
                ThrowSrgsException(SRID.InvalidEmptyRule, "rule", dest);
            }
            return rule;
        }

        private IRuleRef ParseRuleRef(IElement parent, XmlReader reader)
        {
            IRuleRef ruleRef = null;
            string dest = null;
            string dest2 = null;
            string dest3 = null;
            while (reader.MoveToNextAttribute())
            {
                bool flag = false;
                string namespaceURI = reader.NamespaceURI;
                if (namespaceURI == null || namespaceURI.Length != 0)
                {
                    if (namespaceURI == "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions")
                    {
                        namespaceURI = reader.LocalName;
                        if (!(namespaceURI == "semantic-key"))
                        {
                            if (namespaceURI == "params")
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
                    else
                    {
                        flag = true;
                    }
                }
                else
                {
                    switch (reader.LocalName)
                    {
                        case "uri":
                            CheckForDuplicates(ref dest3, reader);
                            ValidateRulerefNotPointingToSelf(dest3);
                            break;
                        case "special":
                            if (ruleRef != null)
                            {
                                ThrowSrgsException(SRID.InvalidAttributeDefinedTwice, reader.Value, "special");
                            }
                            switch (reader.Value)
                            {
                                case "NULL":
                                    ruleRef = _parser.Null;
                                    break;
                                case "VOID":
                                    ruleRef = _parser.Void;
                                    break;
                                case "GARBAGE":
                                    ruleRef = _parser.Garbage;
                                    break;
                                default:
                                    ThrowSrgsException(SRID.InvalidSpecialRuleRef);
                                    break;
                            }
                            _parser.InitSpecialRuleRef(parent, ruleRef);
                            break;
                        default:
                            flag = true;
                            break;
                        case "type":
                            break;
                    }
                }
                if (flag)
                {
                    ThrowSrgsException(SRID.InvalidRulerefAttribute, reader.Name);
                }
            }
            ProcessChildNodes(reader, null, null, "ruleref");
            if (ruleRef == null)
            {
                if (dest3 == null)
                {
                    ThrowSrgsException(SRID.InvalidRuleRef, "uri");
                }
                ruleRef = _parser.CreateRuleRef(parent, new Uri(dest3, UriKind.RelativeOrAbsolute), dest, dest2);
            }
            else
            {
                if (dest3 != null)
                {
                    ThrowSrgsException(SRID.NoUriForSpecialRuleRef);
                }
                if (!string.IsNullOrEmpty(dest) || !string.IsNullOrEmpty(dest2))
                {
                    ThrowSrgsException(SRID.NoAliasForSpecialRuleRef);
                }
            }
            ruleRef.PostParse(parent);
            return ruleRef;
        }

        private IOneOf ParseOneOf(IElement parent, IRule rule, XmlReader reader)
        {
            IOneOf oneOf = _parser.CreateOneOf(parent, rule);
            while (reader.MoveToNextAttribute())
            {
                bool flag = false;
                string namespaceURI = reader.NamespaceURI;
                if ((namespaceURI != null && namespaceURI.Length == 0) || namespaceURI == "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions")
                {
                    flag = true;
                }
                if (flag)
                {
                    ThrowSrgsException(SRID.InvalidOneOfAttribute, reader.Name);
                }
            }
            ProcessChildNodes(reader, oneOf, rule, "one-of");
            oneOf.PostParse(parent);
            return oneOf;
        }

        private IItem ParseItem(IElement parent, IRule rule, XmlReader reader)
        {
            float repeatProbability = 0.5f;
            int minRepeat = 1;
            int maxRepeat = 1;
            float weight = 1f;
            while (reader.MoveToNextAttribute())
            {
                bool flag = false;
                string namespaceURI = reader.NamespaceURI;
                if (namespaceURI == null || namespaceURI.Length != 0)
                {
                    if (namespaceURI == "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions")
                    {
                        flag = true;
                    }
                }
                else
                {
                    switch (reader.LocalName)
                    {
                        case "repeat":
                            SetRepeatValues(reader.Value, out minRepeat, out maxRepeat);
                            break;
                        case "repeat-prob":
                            repeatProbability = Convert.ToSingle(reader.Value, CultureInfo.InvariantCulture);
                            break;
                        case "weight":
                            weight = Convert.ToSingle(reader.Value, CultureInfo.InvariantCulture);
                            break;
                        default:
                            flag = true;
                            break;
                    }
                }
                if (flag)
                {
                    ThrowSrgsException(SRID.InvalidItemAttribute, reader.Name);
                }
            }
            IItem item = _parser.CreateItem(parent, rule, minRepeat, maxRepeat, repeatProbability, weight);
            ProcessChildNodes(reader, item, rule, "item");
            item.PostParse(parent);
            return item;
        }

        private ISubset ParseSubset(IElement parent, XmlReader reader)
        {
            string dest = null;
            MatchMode matchMode = MatchMode.Subsequence;
            while (reader.MoveToNextAttribute())
            {
                bool flag = reader.NamespaceURI.Length == 0;
                string namespaceURI = reader.NamespaceURI;
                if (namespaceURI == "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions")
                {
                    namespaceURI = reader.LocalName;
                    if (namespaceURI == "match")
                    {
                        CheckForDuplicates(ref dest, reader);
                        switch (reader.Value)
                        {
                            case "subsequence":
                                matchMode = MatchMode.Subsequence;
                                break;
                            case "ordered-subset":
                                matchMode = MatchMode.OrderedSubset;
                                break;
                            case "subsequence-content-required":
                                matchMode = MatchMode.SubsequenceContentRequired;
                                break;
                            case "ordered-subset-content-required":
                                matchMode = MatchMode.OrderedSubsetContentRequired;
                                break;
                            default:
                                flag = true;
                                break;
                        }
                    }
                    else
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    ThrowSrgsException(SRID.InvalidSubsetAttribute, reader.Name);
                }
            }
            string text = GetStringContent(reader).Trim();
            if (text.Length == 0)
            {
                ThrowSrgsException(SRID.InvalidEmptyElement, "subset");
            }
            return _parser.CreateSubset(parent, text, matchMode);
        }

        private IToken ParseToken(IElement parent, XmlReader reader)
        {
            string text = null;
            string text2 = null;
            float reqConfidence = -1f;
            while (reader.MoveToNextAttribute())
            {
                bool flag = false;
                string namespaceURI = reader.NamespaceURI;
                if (namespaceURI == null || namespaceURI.Length != 0)
                {
                    if (namespaceURI == "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions")
                    {
                        switch (reader.LocalName)
                        {
                            case "pron":
                                if (string.IsNullOrEmpty(text))
                                {
                                    text = reader.Value.Trim(Helpers._achTrimChars);
                                    if (string.IsNullOrEmpty(text))
                                    {
                                        ThrowSrgsException(SRID.EmptyPronunciationString);
                                    }
                                }
                                else
                                {
                                    ThrowSrgsException(SRID.MuliplePronunciationString);
                                }
                                break;
                            case "display":
                                if (string.IsNullOrEmpty(text2))
                                {
                                    text2 = reader.Value.Trim(Helpers._achTrimChars);
                                    if (string.IsNullOrEmpty(text2))
                                    {
                                        ThrowSrgsException(SRID.EmptyDisplayString);
                                    }
                                }
                                else
                                {
                                    ThrowSrgsException(SRID.MultipleDisplayString);
                                }
                                break;
                            case "reqconf":
                                switch (reader.Value)
                                {
                                    case "high":
                                        reqConfidence = 0.8f;
                                        break;
                                    case "normal":
                                        reqConfidence = 0.5f;
                                        break;
                                    case "low":
                                        reqConfidence = 0.2f;
                                        break;
                                    default:
                                        ThrowSrgsException(SRID.InvalidReqConfAttribute, reader.Name);
                                        break;
                                }
                                break;
                            default:
                                flag = true;
                                break;
                        }
                    }
                }
                else
                {
                    flag = true;
                }
                if (flag)
                {
                    ThrowSrgsException(SRID.InvalidTokenAttribute, reader.Name);
                }
            }
            string text3 = GetStringContent(reader).Trim(Helpers._achTrimChars);
            if (string.IsNullOrEmpty(text3))
            {
                ThrowSrgsException(SRID.InvalidEmptyElement, "token");
            }
            if (text3.IndexOf('"') >= 0)
            {
                ThrowSrgsException(SRID.InvalidTokenString);
            }
            return _parser.CreateToken(parent, text3, text, text2, reqConfidence);
        }

        private void ParseText(IElement parent, string sChars, string pronunciation, string display, float reqConfidence)
        {
            ParseText(parent, sChars, pronunciation, display, reqConfidence, _parser.CreateToken);
        }

        private IElement ParseTag(IElement parent, XmlReader reader)
        {
            string tagContent = GetTagContent(parent, reader);
            if (string.IsNullOrEmpty(tagContent))
            {
                return _parser.CreateSemanticTag(parent);
            }
            if (_parser.Grammar.TagFormat != SrgsTagFormat.KeyValuePairs)
            {
                ISemanticTag semanticTag = _parser.CreateSemanticTag(parent);
                semanticTag.Content(parent, tagContent, 0);
                return semanticTag;
            }
            IPropertyTag propertyTag = _parser.CreatePropertyTag(parent);
            string name;
            object value;
            ParsePropertyTag(tagContent, out name, out value);
            propertyTag.NameValue(parent, name, value);
            return propertyTag;
        }

        private string GetTagContent(IElement parent, XmlReader reader)
        {
            if (!_hasTagFormat)
            {
                ThrowSrgsException(SRID.MissingTagFormat);
            }
            while (reader.MoveToNextAttribute())
            {
                bool flag = false;
                string namespaceURI = reader.NamespaceURI;
                if ((namespaceURI != null && namespaceURI.Length == 0) || namespaceURI == "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions")
                {
                    flag = true;
                }
                if (flag)
                {
                    ThrowSrgsException(SRID.InvalidTagAttribute, reader.Name);
                }
            }
            return GetStringContent(reader).Trim(Helpers._achTrimChars);
        }

        private static void ParseLexicon(XmlReader reader)
        {
            bool flag = false;
            bool flag2 = false;
            while (reader.MoveToNextAttribute())
            {
                string localName = reader.LocalName;
                if (!(localName == "uri"))
                {
                    if (!(localName == "type"))
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag2 = true;
                }
                if (flag)
                {
                    ThrowSrgsException(SRID.InvalidLexiconAttribute, reader.Name);
                }
            }
            if (!flag2)
            {
                ThrowSrgsException(SRID.MissingRequiredAttribute, "uri", "lexicon");
            }
        }

        private static void ParseMeta(XmlReader reader)
        {
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "name":
                    case "http-equiv":
                        if (flag2)
                        {
                            ThrowSrgsException(SRID.MetaNameHTTPEquiv);
                        }
                        flag2 = true;
                        break;
                    case "content":
                        flag3 = flag;
                        flag = true;
                        break;
                    default:
                        flag3 = true;
                        break;
                }
                if (flag3)
                {
                    ThrowSrgsException(SRID.InvalidMetaAttribute, reader.Name);
                }
            }
            if (!flag)
            {
                ThrowSrgsException(SRID.MissingRequiredAttribute, "content", "meta");
            }
            if (!flag2)
            {
                ThrowSrgsException(SRID.MissingRequiredAttribute, "name or http-equiv", "meta");
            }
        }

        private void ParseScript(XmlReader reader, IGrammar grammar)
        {
            int line = (_filename != null) ? _xmlTextReader.LineNumber : (-1);
            string text = null;
            while (reader.MoveToNextAttribute())
            {
                string namespaceURI = reader.NamespaceURI;
                if (namespaceURI == null || namespaceURI.Length != 0)
                {
                    if (!(namespaceURI == "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions"))
                    {
                        continue;
                    }
                    namespaceURI = reader.LocalName;
                    if (namespaceURI == "rule")
                    {
                        if (string.IsNullOrEmpty(text))
                        {
                            text = reader.Value;
                        }
                        else
                        {
                            ThrowSrgsException(SRID.RuleAttributeDefinedMultipeTimes);
                        }
                    }
                    else
                    {
                        ThrowSrgsException(SRID.InvalidScriptAttribute);
                    }
                }
                else
                {
                    ThrowSrgsException(SRID.InvalidScriptAttribute);
                }
            }
            if (string.IsNullOrEmpty(text))
            {
                _parser.AddScript(grammar, GetStringContent(reader), _filename, line);
            }
            else
            {
                _scripts.Add(new ForwardReference(text, _parser.AddScript(grammar, text, GetStringContent(reader), _filename, line)));
            }
        }

        private static void ParseAssemblyReference(XmlReader reader, IGrammar grammar)
        {
            while (reader.MoveToNextAttribute())
            {
                string namespaceURI = reader.NamespaceURI;
                if (namespaceURI == null || namespaceURI.Length != 0)
                {
                    if (namespaceURI == "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions")
                    {
                        namespaceURI = reader.LocalName;
                        if (namespaceURI == "assembly")
                        {
                            grammar.AssemblyReferences.Add(reader.Value);
                        }
                        else
                        {
                            ThrowSrgsException(SRID.InvalidAssemblyReferenceAttribute);
                        }
                    }
                }
                else
                {
                    ThrowSrgsException(SRID.InvalidScriptAttribute);
                }
            }
        }

        private static void ParseImportNamespace(XmlReader reader, IGrammar grammar)
        {
            while (reader.MoveToNextAttribute())
            {
                string namespaceURI = reader.NamespaceURI;
                if (namespaceURI == null || namespaceURI.Length != 0)
                {
                    if (namespaceURI == "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions")
                    {
                        namespaceURI = reader.LocalName;
                        if (namespaceURI == "namespace")
                        {
                            grammar.ImportNamespaces.Add(reader.Value);
                        }
                        else
                        {
                            ThrowSrgsException(SRID.InvalidImportNamespaceAttribute);
                        }
                    }
                }
                else
                {
                    ThrowSrgsException(SRID.InvalidScriptAttribute);
                }
            }
        }

        private bool ProcessChildNodes(XmlReader reader, IElement parent, IRule rule, string parentName)
        {
            bool flag = true;
            List<IPropertyTag> list = null;
            reader.MoveToElement();
            if (!reader.IsEmptyElement)
            {
                reader.Read();
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    bool flag2 = false;
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (parent == null)
                        {
                            ThrowSrgsException(SRID.InvalidNotEmptyElement, parentName);
                        }
                        IElement element = null;
                        string namespaceURI = reader.NamespaceURI;
                        if (!(namespaceURI == "http://www.w3.org/2001/06/grammar"))
                        {
                            if (namespaceURI == "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions")
                            {
                                namespaceURI = reader.LocalName;
                                if (namespaceURI == "subset")
                                {
                                    if (parent is IRule || parent is IItem)
                                    {
                                        element = ParseSubset(parent, reader);
                                    }
                                    else
                                    {
                                        flag2 = true;
                                    }
                                }
                                else
                                {
                                    flag2 = true;
                                }
                            }
                            else
                            {
                                reader.Skip();
                            }
                        }
                        else
                        {
                            switch (reader.LocalName)
                            {
                                case "example":
                                    if (!(parent is IRule) || !flag)
                                    {
                                        ThrowSrgsException(SRID.InvalidExampleOrdering);
                                        break;
                                    }
                                    reader.Skip();
                                    continue;
                                case "ruleref":
                                    element = ParseRuleRef(parent, reader);
                                    break;
                                case "one-of":
                                    element = ParseOneOf(parent, rule, reader);
                                    break;
                                case "item":
                                    element = ParseItem(parent, rule, reader);
                                    break;
                                case "token":
                                    element = ParseToken(parent, reader);
                                    break;
                                case "tag":
                                    {
                                        element = ParseTag(parent, reader);
                                        IPropertyTag propertyTag = element as IPropertyTag;
                                        if (propertyTag != null)
                                        {
                                            if (list == null)
                                            {
                                                list = new List<IPropertyTag>();
                                            }
                                            list.Add(propertyTag);
                                        }
                                        break;
                                    }
                                default:
                                    flag2 = true;
                                    break;
                            }
                        }
                        flag2 = ParseChildNodeElement(parent, flag2, element);
                        flag = false;
                    }
                    else if (reader.NodeType == XmlNodeType.Text || reader.NodeType == XmlNodeType.CDATA)
                    {
                        if (parent == null)
                        {
                            ThrowSrgsException(SRID.InvalidNotEmptyElement, parentName);
                        }
                        flag2 = ParseChildNodeText(reader, parent);
                        flag = false;
                    }
                    else
                    {
                        reader.Skip();
                    }
                    if (flag2)
                    {
                        ThrowSrgsException(SRID.InvalidElement, reader.Name);
                    }
                }
            }
            reader.Read();
            if (list != null)
            {
                foreach (IPropertyTag item in list)
                {
                    item.PostParse(parent);
                }
            }
            return !flag;
        }

        private bool ParseChildNodeText(XmlReader reader, IElement parent)
        {
            bool result = false;
            string value = reader.Value;
            IElementText value2 = _parser.CreateText(parent, value);
            ParseText(parent, value, null, null, -1f);
            if (parent is IOneOf)
            {
                result = true;
            }
            else
            {
                IRule rule = parent as IRule;
                if (rule != null)
                {
                    _parser.AddElement(rule, value2);
                }
                else
                {
                    IItem item = parent as IItem;
                    if (item != null)
                    {
                        _parser.AddElement(item, value2);
                    }
                    else
                    {
                        result = true;
                    }
                }
            }
            reader.Read();
            return result;
        }

        private bool ParseChildNodeElement(IElement parent, bool isInvalidNode, IElement child)
        {
            if (child != null)
            {
                IOneOf oneOf = parent as IOneOf;
                if (oneOf != null)
                {
                    IItem item = child as IItem;
                    if (item != null)
                    {
                        _parser.AddItem(oneOf, item);
                    }
                    else
                    {
                        isInvalidNode = true;
                    }
                }
                else
                {
                    IRule rule = parent as IRule;
                    if (rule != null)
                    {
                        _parser.AddElement(rule, child);
                    }
                    else
                    {
                        IItem item2 = parent as IItem;
                        if (item2 != null)
                        {
                            _parser.AddElement(item2, child);
                        }
                        else
                        {
                            isInvalidNode = true;
                        }
                    }
                }
            }
            return isInvalidNode;
        }

        private void ProcessRulesAndScriptsNodes(XmlReader reader, IGrammar grammar)
        {
            bool flag = false;
            reader.MoveToElement();
            if (!reader.IsEmptyElement)
            {
                reader.Read();
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    bool flag2 = false;
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        string namespaceURI = reader.NamespaceURI;
                        if (!(namespaceURI == "http://www.w3.org/2001/06/grammar"))
                        {
                            if (namespaceURI == "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions")
                            {
                                switch (reader.LocalName)
                                {
                                    case "script":
                                        ParseScript(reader, grammar);
                                        flag = true;
                                        break;
                                    case "assemblyReference":
                                        ParseAssemblyReference(reader, grammar);
                                        flag = true;
                                        break;
                                    case "importNamespace":
                                        ParseImportNamespace(reader, grammar);
                                        flag = true;
                                        break;
                                    default:
                                        flag2 = true;
                                        break;
                                }
                            }
                            else
                            {
                                reader.Skip();
                            }
                        }
                        else
                        {
                            switch (reader.LocalName)
                            {
                                case "lexicon":
                                    if (flag)
                                    {
                                        ThrowSrgsException(SRID.InvalidGrammarOrdering);
                                    }
                                    ParseLexicon(reader);
                                    break;
                                case "meta":
                                    if (flag)
                                    {
                                        ThrowSrgsException(SRID.InvalidGrammarOrdering);
                                    }
                                    ParseMeta(reader);
                                    break;
                                case "metadata":
                                    if (flag)
                                    {
                                        ThrowSrgsException(SRID.InvalidGrammarOrdering);
                                    }
                                    reader.Skip();
                                    break;
                                case "rule":
                                    {
                                        IRule rule = ParseRule(grammar, reader);
                                        rule.PostParse(grammar);
                                        flag = true;
                                        break;
                                    }
                                case "tag":
                                    if (flag || (_hasTagFormat && grammar.TagFormat != SrgsTagFormat.W3cV1))
                                    {
                                        ThrowSrgsException(SRID.InvalidGrammarOrdering);
                                    }
                                    grammar.GlobalTags.Add(GetTagContent(grammar, reader));
                                    break;
                                default:
                                    flag2 = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (reader.NodeType == XmlNodeType.Text)
                        {
                            ThrowSrgsException(SRID.InvalidElement, "text");
                        }
                        reader.Skip();
                    }
                    if (flag2)
                    {
                        ThrowSrgsException(SRID.InvalidElement, reader.Name);
                    }
                }
            }
            reader.Read();
        }

        private static string GetStringContent(XmlReader reader)
        {
            StringBuilder stringBuilder = new StringBuilder();
            reader.MoveToElement();
            if (!reader.IsEmptyElement)
            {
                reader.Read();
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    stringBuilder.Append(reader.ReadString());
                    bool flag = false;
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        string namespaceURI = reader.NamespaceURI;
                        if (namespaceURI == "http://www.w3.org/2001/06/grammar" || namespaceURI == "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions")
                        {
                            flag = true;
                        }
                        else
                        {
                            reader.Skip();
                        }
                    }
                    else if (reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.Skip();
                    }
                    if (flag)
                    {
                        ThrowSrgsException(SRID.InvalidElement, reader.Name);
                    }
                }
            }
            reader.Read();
            return stringBuilder.ToString();
        }

        private static void ParsePropertyTag(string sTag, out string name, out object value)
        {
            name = null;
            value = string.Empty;
            int num = sTag.IndexOf('=');
            if (num >= 0)
            {
                name = sTag.Substring(0, num).Trim(Helpers._achTrimChars);
                num++;
            }
            else
            {
                num = 0;
            }
            int length = sTag.Length;
            if (num >= length)
            {
                return;
            }
            if (sTag[num] == '"')
            {
                num++;
                int num2 = sTag.IndexOf('"', num + 1);
                if (num2 + 1 != length)
                {
                    ThrowSrgsException(SRID.IncorrectAttributeValue, name, sTag.Substring(num));
                }
                value = sTag.Substring(num, num2 - num);
                return;
            }
            string text = sTag.Substring(num);
            int result;
            double result2;
            bool result3;
            if (int.TryParse(text, out result))
            {
                value = result;
            }
            else if (double.TryParse(text, out result2))
            {
                value = result2;
            }
            else if (bool.TryParse(text, out result3))
            {
                value = result3;
            }
            else
            {
                ThrowSrgsException(SRID.InvalidNameValueProperty, name, text);
            }
        }

        private static void SetRepeatValues(string repeat, out int minRepeat, out int maxRepeat)
        {
            minRepeat = (maxRepeat = 1);
            if (!string.IsNullOrEmpty(repeat))
            {
                int num = repeat.IndexOf("-", StringComparison.Ordinal);
                if (num < 0)
                {
                    int num2 = Convert.ToInt32(repeat, CultureInfo.InvariantCulture);
                    if (num2 < 0 || num2 > 255)
                    {
                        ThrowSrgsException(SRID.MinMaxOutOfRange, num2, num2);
                    }
                    minRepeat = (maxRepeat = num2);
                }
                else if (0 < num)
                {
                    minRepeat = Convert.ToInt32(repeat.Substring(0, num), CultureInfo.InvariantCulture);
                    if (num < repeat.Length - 1)
                    {
                        maxRepeat = Convert.ToInt32(repeat.Substring(num + 1), CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        maxRepeat = int.MaxValue;
                    }
                    if (minRepeat < 0 || minRepeat > 255 || (maxRepeat != int.MaxValue && (maxRepeat < 0 || maxRepeat > 255)))
                    {
                        ThrowSrgsException(SRID.MinMaxOutOfRange, minRepeat, maxRepeat);
                    }
                    if (minRepeat > maxRepeat)
                    {
                        throw new ArgumentException(SR.Get(SRID.MinGreaterThanMax));
                    }
                }
                else
                {
                    ThrowSrgsException(SRID.InvalidItemRepeatAttribute, repeat);
                }
            }
            else
            {
                ThrowSrgsException(SRID.InvalidItemAttribute2);
            }
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
                ThrowSrgsException(SRID.InvalidAttributeDefinedTwice, reader.Value, stringBuilder);
            }
            dest = reader.Value;
        }

        internal static void ValidateRuleId(string id)
        {
            Helpers.ThrowIfEmptyOrNull(id, "id");
            if (XmlReader.IsName(id))
            {
                switch (id)
                {
                    default:
                        if (id.IndexOfAny(_invalidRuleIdChars) == -1)
                        {
                            return;
                        }
                        break;
                    case "NULL":
                    case "VOID":
                    case "GARBAGE":
                        break;
                }
            }
            ThrowSrgsException(SRID.InvalidRuleId, id);
        }

        private void ValidateRulerefNotPointingToSelf(string uri)
        {
            if (_filename != null && uri.IndexOf(_shortFilename, StringComparison.Ordinal) == 0 && ((uri.Length > _shortFilename.Length && uri[_shortFilename.Length] == '#') || uri.Length == _shortFilename.Length))
            {
                ThrowSrgsException(SRID.InvalidRuleRefSelf);
            }
        }

        private void ValidateScripts()
        {
            foreach (ForwardReference script in _scripts)
            {
                if (!_rules.Contains(script._name))
                {
                    ThrowSrgsException(SRID.InvalidScriptDefinition, script._name);
                }
            }
            List<string> list = new List<string>();
            foreach (string rule in _rules)
            {
                if (list.Contains(rule))
                {
                    ThrowSrgsException(SRID.RuleAttributeDefinedMultipeTimes, rule);
                }
                list.Add(rule);
            }
        }
    }
}