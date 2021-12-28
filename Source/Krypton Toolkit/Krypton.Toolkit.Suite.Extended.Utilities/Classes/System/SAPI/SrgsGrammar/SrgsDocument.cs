#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
    [Serializable]
    public class SrgsDocument
    {
        private SrgsGrammar _grammar;

        private Uri _baseUri;

        public Uri XmlBase
        {
            get
            {
                return _grammar.XmlBase;
            }
            set
            {
                _grammar.XmlBase = value;
            }
        }

        public CultureInfo Culture
        {
            get
            {
                return _grammar.Culture;
            }
            set
            {
                Helpers.ThrowIfNull(value, "value");
                if (value.Equals(CultureInfo.InvariantCulture))
                {
                    throw new ArgumentException(SR.Get(SRID.InvariantCultureInfo), "value");
                }
                _grammar.Culture = value;
            }
        }

        public SrgsRule Root
        {
            get
            {
                return _grammar.Root;
            }
            set
            {
                _grammar.Root = value;
            }
        }

        public SrgsGrammarMode Mode
        {
            get
            {
                if (_grammar.Mode != 0)
                {
                    return SrgsGrammarMode.Dtmf;
                }
                return SrgsGrammarMode.Voice;
            }
            set
            {
                _grammar.Mode = ((value != 0) ? GrammarType.DtmfGrammar : GrammarType.VoiceGrammar);
            }
        }

        public SrgsPhoneticAlphabet PhoneticAlphabet
        {
            get
            {
                return (SrgsPhoneticAlphabet)_grammar.PhoneticAlphabet;
            }
            set
            {
                _grammar.PhoneticAlphabet = (AlphabetType)value;
                _grammar.HasPhoneticAlphabetBeenSet = true;
            }
        }

        public SrgsRulesCollection Rules => _grammar.Rules;

        public string Language
        {
            get
            {
                return _grammar.Language;
            }
            set
            {
                _grammar.Language = value;
            }
        }

        public string Namespace
        {
            get
            {
                return _grammar.Namespace;
            }
            set
            {
                _grammar.Namespace = value;
            }
        }

        public Collection<string> CodeBehind => _grammar.CodeBehind;

        public bool Debug
        {
            get
            {
                return _grammar.Debug;
            }
            set
            {
                _grammar.Debug = value;
            }
        }

        public string Script
        {
            get
            {
                return _grammar.Script;
            }
            set
            {
                Helpers.ThrowIfEmptyOrNull(value, "value");
                _grammar.Script = value;
            }
        }

        public Collection<string> ImportNamespaces => _grammar.ImportNamespaces;

        public Collection<string> AssemblyReferences => _grammar.AssemblyReferences;

        internal SrgsTagFormat TagFormat
        {
            set
            {
                _grammar.TagFormat = value;
            }
        }

        internal Uri BaseUri => _baseUri;

        internal SrgsGrammar Grammar => _grammar;

        public SrgsDocument()
        {
            _grammar = new SrgsGrammar();
        }

        public SrgsDocument(string path)
        {
            Helpers.ThrowIfEmptyOrNull(path, "path");
            using (XmlTextReader srgsGrammar = new XmlTextReader(path))
            {
                Load(srgsGrammar);
            }
        }

        public SrgsDocument(XmlReader srgsGrammar)
        {
            Helpers.ThrowIfNull(srgsGrammar, "srgsGrammar");
            Load(srgsGrammar);
        }

        public SrgsDocument(GrammarBuilder builder)
        {
            Helpers.ThrowIfNull(builder, "builder");
            _grammar = new SrgsGrammar();
            _grammar.Culture = builder.Culture;
            IElementFactory elementFactory = new SrgsElementFactory(_grammar);
            builder.CreateGrammar(elementFactory);
        }

        public SrgsDocument(SrgsRule grammarRootRule)
            : this()
        {
            Helpers.ThrowIfNull(grammarRootRule, "grammarRootRule");
            Root = grammarRootRule;
            Rules.Add(grammarRootRule);
        }

        public void WriteSrgs(XmlWriter srgsGrammar)
        {
            Helpers.ThrowIfNull(srgsGrammar, "srgsGrammar");
            _grammar.Validate();
            _grammar.WriteSrgs(srgsGrammar);
        }

        internal void Load(XmlReader srgsGrammar)
        {
            _grammar = new SrgsGrammar();
            _grammar.PhoneticAlphabet = AlphabetType.Sapi;
            XmlParser xmlParser = new XmlParser(srgsGrammar, null);
            xmlParser.ElementFactory = new SrgsElementFactory(_grammar);
            xmlParser.Parse();
            if (!string.IsNullOrEmpty(srgsGrammar.BaseURI))
            {
                _baseUri = new Uri(srgsGrammar.BaseURI);
            }
        }

        internal static GrammarOptions TagFormat2GrammarOptions(SrgsTagFormat value)
        {
            GrammarOptions result = GrammarOptions.KeyValuePairs;
            switch (value)
            {
                case SrgsTagFormat.KeyValuePairs:
                    result = GrammarOptions.KeyValuePairSrgs;
                    break;
                case SrgsTagFormat.MssV1:
                    result = GrammarOptions.MssV1;
                    break;
                case SrgsTagFormat.W3cV1:
                    result = GrammarOptions.W3cV1;
                    break;
            }
            return result;
        }

        internal static SrgsTagFormat GrammarOptions2TagFormat(GrammarOptions value)
        {
            SrgsTagFormat result = SrgsTagFormat.Default;
            switch (value & GrammarOptions.TagFormat)
            {
                case GrammarOptions.MssV1:
                    result = SrgsTagFormat.MssV1;
                    break;
                case GrammarOptions.W3cV1:
                    result = SrgsTagFormat.W3cV1;
                    break;
                case GrammarOptions.KeyValuePairs:
                case GrammarOptions.KeyValuePairSrgs:
                    result = SrgsTagFormat.KeyValuePairs;
                    break;
            }
            return result;
        }
    }
}
