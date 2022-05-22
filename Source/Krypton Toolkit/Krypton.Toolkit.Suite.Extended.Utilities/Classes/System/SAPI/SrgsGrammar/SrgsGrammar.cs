#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
    [Serializable]
    internal sealed class SrgsGrammar : IGrammar, IElement
    {
        private bool _isSapiExtensionUsed;

        private Uri _xmlBase;

        private CultureInfo _culture = CultureInfo.CurrentUICulture;

        private SrgsGrammarMode _mode;

        private SrgsPhoneticAlphabet _phoneticAlphabet = SrgsPhoneticAlphabet.Ipa;

        private bool _hasPhoneticAlphabetBeenSet;

        private bool _hasPronunciation;

        private SrgsRule _root;

        private SrgsTagFormat _tagFormat;

        private Collection<string> _globalTags = new Collection<string>();

        private bool _isModeSet;

        private SrgsRulesCollection _rules;

        private string _sRoot;

        internal bool _fContainsCode;

        private string _language;

        private Collection<string> _codebehind = new Collection<string>();

        private string _namespace;

        internal bool _fDebug;

        private string _script = string.Empty;

        private List<XmlParser.ForwardReference> _scriptsForwardReference = new List<XmlParser.ForwardReference>();

        private Collection<string> _usings = new Collection<string>();

        private Collection<string> _assemblyReferences = new Collection<string>();

        string IGrammar.Root
        {
            get
            {
                return _sRoot;
            }
            set
            {
                _sRoot = value;
            }
        }

        public Uri XmlBase
        {
            get
            {
                return _xmlBase;
            }
            set
            {
                _xmlBase = value;
            }
        }

        public CultureInfo Culture
        {
            get
            {
                return _culture;
            }
            set
            {
                Helpers.ThrowIfNull(value, "value");
                _culture = value;
            }
        }

        public GrammarType Mode
        {
            get
            {
                if (_mode != 0)
                {
                    return GrammarType.DtmfGrammar;
                }
                return GrammarType.VoiceGrammar;
            }
            set
            {
                _mode = ((value != 0) ? SrgsGrammarMode.Dtmf : SrgsGrammarMode.Voice);
                _isModeSet = true;
            }
        }

        public AlphabetType PhoneticAlphabet
        {
            get
            {
                return (AlphabetType)_phoneticAlphabet;
            }
            set
            {
                _phoneticAlphabet = (SrgsPhoneticAlphabet)value;
            }
        }

        public SrgsRule Root
        {
            get
            {
                return _root;
            }
            set
            {
                _root = value;
            }
        }

        public SrgsTagFormat TagFormat
        {
            get
            {
                return _tagFormat;
            }
            set
            {
                _tagFormat = value;
            }
        }

        public Collection<string> GlobalTags
        {
            get
            {
                return _globalTags;
            }
            set
            {
                _globalTags = value;
            }
        }

        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
            }
        }

        public string Namespace
        {
            get
            {
                return _namespace;
            }
            set
            {
                _namespace = value;
            }
        }

        public Collection<string> CodeBehind
        {
            get
            {
                return _codebehind;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public bool Debug
        {
            get
            {
                return _fDebug;
            }
            set
            {
                _fDebug = value;
            }
        }

        public string Script
        {
            get
            {
                return _script;
            }
            set
            {
                Helpers.ThrowIfEmptyOrNull(value, "value");
                _script = value;
            }
        }

        public Collection<string> ImportNamespaces
        {
            get
            {
                return _usings;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public Collection<string> AssemblyReferences
        {
            get
            {
                return _assemblyReferences;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        internal SrgsRulesCollection Rules => _rules;

        internal bool HasPronunciation
        {
            get
            {
                return _hasPronunciation;
            }
            set
            {
                _hasPronunciation = value;
            }
        }

        internal bool HasPhoneticAlphabetBeenSet
        {
            set
            {
                _hasPhoneticAlphabetBeenSet = value;
            }
        }

        internal bool HasSapiExtension
        {
            get
            {
                return _isSapiExtensionUsed;
            }
            set
            {
                _isSapiExtensionUsed = value;
            }
        }

        internal SrgsGrammar()
        {
            _rules = new SrgsRulesCollection();
        }

        internal void WriteSrgs(XmlWriter writer)
        {
            writer.WriteStartElement("grammar", "http://www.w3.org/2001/06/grammar");
            writer.WriteAttributeString("xml", "lang", null, _culture.ToString());
            if (_root != null)
            {
                writer.WriteAttributeString("root", _root.Id);
            }
            WriteSTGAttributes(writer);
            if (_isModeSet)
            {
                switch (_mode)
                {
                    case SrgsGrammarMode.Voice:
                        writer.WriteAttributeString("mode", "voice");
                        break;
                    case SrgsGrammarMode.Dtmf:
                        writer.WriteAttributeString("mode", "dtmf");
                        break;
                }
            }
            string text = null;
            switch (_tagFormat)
            {
                case SrgsTagFormat.MssV1:
                    text = "semantics-ms/1.0";
                    break;
                case SrgsTagFormat.W3cV1:
                    text = "semantics/1.0";
                    break;
                case SrgsTagFormat.KeyValuePairs:
                    text = "properties-ms/1.0";
                    break;
            }
            if (text != null)
            {
                writer.WriteAttributeString("tag-format", text);
            }
            if (_hasPhoneticAlphabetBeenSet || (_phoneticAlphabet != 0 && HasPronunciation))
            {
                string value = (_phoneticAlphabet == SrgsPhoneticAlphabet.Ipa) ? "ipa" : ((_phoneticAlphabet == SrgsPhoneticAlphabet.Ups) ? "x-microsoft-ups" : "x-microsoft-sapi");
                writer.WriteAttributeString("sapi", "alphabet", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", value);
            }
            if (_xmlBase != null)
            {
                writer.WriteAttributeString("xml:base", _xmlBase.ToString());
            }
            writer.WriteAttributeString("version", "1.0");
            writer.WriteAttributeString("xmlns", "http://www.w3.org/2001/06/grammar");
            if (_isSapiExtensionUsed)
            {
                writer.WriteAttributeString("xmlns", "sapi", null, "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions");
            }
            foreach (SrgsRule rule in _rules)
            {
                rule.Validate(this);
            }
            foreach (string globalTag in _globalTags)
            {
                writer.WriteElementString("tag", globalTag);
            }
            WriteGrammarElements(writer);
            writer.WriteEndElement();
        }

        internal void Validate()
        {
            bool hasPronunciation = HasSapiExtension = false;
            HasPronunciation = hasPronunciation;
            foreach (SrgsRule rule in _rules)
            {
                rule.Validate(this);
            }
            _isSapiExtensionUsed |= HasPronunciation;
            _fContainsCode |= (_language != null || _script.Length > 0 || _usings.Count > 0 || _assemblyReferences.Count > 0 || _codebehind.Count > 0 || _namespace != null || _fDebug);
            _isSapiExtensionUsed |= _fContainsCode;
            if (!HasPronunciation)
            {
                PhoneticAlphabet = AlphabetType.Sapi;
            }
            if (_root != null && !_rules.Contains(_root))
            {
                XmlParser.ThrowSrgsException(SRID.RootNotDefined, _root.Id);
            }
            if (_globalTags.Count > 0)
            {
                _tagFormat = SrgsTagFormat.W3cV1;
            }
            if (_fContainsCode)
            {
                if (_tagFormat == SrgsTagFormat.Default)
                {
                    _tagFormat = SrgsTagFormat.KeyValuePairs;
                }
                if (_tagFormat != SrgsTagFormat.KeyValuePairs)
                {
                    XmlParser.ThrowSrgsException(SRID.InvalidSemanticProcessingType);
                }
            }
        }

        IRule IGrammar.CreateRule(string id, RulePublic publicRule, RuleDynamic dynamic, bool hasScript)
        {
            SrgsRule srgsRule = new SrgsRule(id);
            if (publicRule != RulePublic.NotSet)
            {
                srgsRule.Scope = ((publicRule != 0) ? SrgsRuleScope.Private : SrgsRuleScope.Public);
            }
            srgsRule.Dynamic = dynamic;
            return srgsRule;
        }

        void IElement.PostParse(IElement parent)
        {
            if (_sRoot != null)
            {
                bool flag = false;
                foreach (SrgsRule rule in Rules)
                {
                    if (rule.Id == _sRoot)
                    {
                        Root = rule;
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    XmlParser.ThrowSrgsException(SRID.RootNotDefined, _sRoot);
                }
            }
            foreach (XmlParser.ForwardReference item in _scriptsForwardReference)
            {
                SrgsRule srgsRule = Rules[item._name];
                if (srgsRule != null)
                {
                    srgsRule.Script += item._value;
                }
                else
                {
                    XmlParser.ThrowSrgsException(SRID.InvalidScriptDefinition);
                }
            }
            Validate();
        }

        internal void AddScript(string rule, string code)
        {
            if (rule == null)
            {
                _script += code;
            }
            else
            {
                _scriptsForwardReference.Add(new XmlParser.ForwardReference(rule, code));
            }
        }

        private void WriteSTGAttributes(XmlWriter writer)
        {
            if (_language != null)
            {
                writer.WriteAttributeString("sapi", "language", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", _language);
            }
            if (_namespace != null)
            {
                writer.WriteAttributeString("sapi", "namespace", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", _namespace);
            }
            foreach (string item in _codebehind)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    writer.WriteAttributeString("sapi", "codebehind", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", item);
                }
            }
            if (_fDebug)
            {
                writer.WriteAttributeString("sapi", "debug", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", "True");
            }
        }

        private void WriteGrammarElements(XmlWriter writer)
        {
            foreach (string assemblyReference in _assemblyReferences)
            {
                writer.WriteStartElement("sapi", "assemblyReference", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions");
                writer.WriteAttributeString("sapi", "assembly", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", assemblyReference);
                writer.WriteEndElement();
            }
            foreach (string @using in _usings)
            {
                if (!string.IsNullOrEmpty(@using))
                {
                    writer.WriteStartElement("sapi", "importNamespace", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions");
                    writer.WriteAttributeString("sapi", "namespace", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", @using);
                    writer.WriteEndElement();
                }
            }
            WriteRules(writer);
            WriteGlobalScripts(writer);
        }

        private void WriteRules(XmlWriter writer)
        {
            foreach (SrgsRule rule in _rules)
            {
                rule.WriteSrgs(writer);
            }
        }

        private void WriteGlobalScripts(XmlWriter writer)
        {
            if (_script.Length > 0)
            {
                writer.WriteStartElement("sapi", "script", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions");
                writer.WriteCData(_script);
                writer.WriteEndElement();
            }
        }
    }
}
