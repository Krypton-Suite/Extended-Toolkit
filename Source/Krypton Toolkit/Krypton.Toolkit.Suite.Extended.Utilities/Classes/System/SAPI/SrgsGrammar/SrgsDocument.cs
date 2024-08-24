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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
    [Serializable]
    public class SrgsDocument
    {
        private SrgsGrammar _grammar;

        private Uri _baseUri;

        public Uri XmlBase
        {
            get => _grammar.XmlBase;
            set => _grammar.XmlBase = value;
        }

        public CultureInfo Culture
        {
            get => _grammar.Culture;
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
            get => _grammar.Root;
            set => _grammar.Root = value;
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
            set => _grammar.Mode = value != 0 ? GrammarType.DtmfGrammar : GrammarType.VoiceGrammar;
        }

        public SrgsPhoneticAlphabet PhoneticAlphabet
        {
            get => (SrgsPhoneticAlphabet)_grammar.PhoneticAlphabet;
            set
            {
                _grammar.PhoneticAlphabet = (AlphabetType)value;
                _grammar.HasPhoneticAlphabetBeenSet = true;
            }
        }

        public SrgsRulesCollection Rules => _grammar.Rules;

        public string Language
        {
            get => _grammar.Language;
            set => _grammar.Language = value;
        }

        public string Namespace
        {
            get => _grammar.Namespace;
            set => _grammar.Namespace = value;
        }

        public Collection<string> CodeBehind => _grammar.CodeBehind;

        public bool Debug
        {
            get => _grammar.Debug;
            set => _grammar.Debug = value;
        }

        public string Script
        {
            get => _grammar.Script;
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
            set => _grammar.TagFormat = value;
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
