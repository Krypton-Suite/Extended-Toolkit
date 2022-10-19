#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
    [Serializable]
    [DebuggerDisplay("Rule={_id.ToString()} Scope={_scope.ToString()}")]
    [DebuggerTypeProxy(typeof(SrgsRuleDebugDisplay))]
    public class SrgsRule : IRule, IElement
    {
        internal class SrgsRuleDebugDisplay
        {
            private SrgsRule _rule;

            public object Id => _rule.Id;

            public object Scope => _rule.Scope;

            public object BaseClass => _rule.BaseClass;

            public object Script => _rule.Script;

            public object OnInit => _rule.OnInit;

            public object OnParse => _rule.OnParse;

            public object OnError => _rule.OnError;

            public object OnRecognition => _rule.OnRecognition;

            public object Count => _rule._elements.Count;

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public SrgsElement[] AKeys
            {
                get
                {
                    SrgsElement[] array = new SrgsElement[_rule._elements.Count];
                    for (int i = 0; i < _rule._elements.Count; i++)
                    {
                        array[i] = _rule._elements[i];
                    }
                    return array;
                }
            }

            public SrgsRuleDebugDisplay(SrgsRule rule)
            {
                _rule = rule;
            }
        }

        private SrgsElementList _elements;

        private string _id;

        private SrgsRuleScope _scope = SrgsRuleScope.Private;

        private RuleDynamic _dynamic = RuleDynamic.NotSet;

        private bool _isScopeSet;

        private string _baseclass;

        private string _script = string.Empty;

        private string _onInit;

        private string _onParse;

        private string _onError;

        private string _onRecognition;

        private static readonly char[] invalidChars = new char[23]
        {
            '?',
            '*',
            '+',
            '|',
            '(',
            ')',
            '^',
            '$',
            '/',
            ';',
            '.',
            '=',
            '<',
            '>',
            '[',
            ']',
            '{',
            '}',
            '\\',
            ' ',
            '\t',
            '\r',
            '\n'
        };

        public Collection<SrgsElement> Elements => _elements;

        public string Id
        {
            get => _id;
            set
            {
                XmlParser.ValidateRuleId(value);
                _id = value;
            }
        }

        public SrgsRuleScope Scope
        {
            get => _scope;
            set
            {
                _scope = value;
                _isScopeSet = true;
            }
        }

        public string BaseClass
        {
            get => _baseclass;
            set => _baseclass = value;
        }

        public string Script
        {
            get => _script;
            set
            {
                Helpers.ThrowIfEmptyOrNull(value, "value");
                _script = value;
            }
        }

        public string OnInit
        {
            get => _onInit;
            set
            {
                ValidateIdentifier(value);
                _onInit = value;
            }
        }

        public string OnParse
        {
            get => _onParse;
            set
            {
                ValidateIdentifier(value);
                _onParse = value;
            }
        }

        public string OnError
        {
            get => _onError;
            set
            {
                ValidateIdentifier(value);
                _onError = value;
            }
        }

        public string OnRecognition
        {
            get => _onRecognition;
            set
            {
                ValidateIdentifier(value);
                _onRecognition = value;
            }
        }

        internal RuleDynamic Dynamic
        {
            get => _dynamic;
            set => _dynamic = value;
        }

        internal bool HasCode => _script.Length > 0;

        private SrgsRule()
        {
            _elements = new SrgsElementList();
        }

        public SrgsRule(string id)
            : this()
        {
            XmlParser.ValidateRuleId(id);
            Id = id;
        }

        public SrgsRule(string id, params SrgsElement[] elements)
            : this()
        {
            Helpers.ThrowIfNull(elements, "elements");
            XmlParser.ValidateRuleId(id);
            Id = id;
            int num = 0;
            while (true)
            {
                if (num < elements.Length)
                {
                    if (elements[num] == null)
                    {
                        break;
                    }
                    _elements.Add(elements[num]);
                    num++;
                    continue;
                }
                return;
            }
            throw new ArgumentNullException("elements", SR.Get(SRID.ParamsEntryNullIllegal));
        }

        public void Add(SrgsElement element)
        {
            Helpers.ThrowIfNull(element, "element");
            Elements.Add(element);
        }

        internal void WriteSrgs(XmlWriter writer)
        {
            if (Elements.Count == 0)
            {
                XmlParser.ThrowSrgsException(SRID.InvalidEmptyRule, "rule", _id);
            }
            writer.WriteStartElement("rule");
            writer.WriteAttributeString("id", _id);
            if (_isScopeSet)
            {
                switch (_scope)
                {
                    case SrgsRuleScope.Private:
                        writer.WriteAttributeString("scope", "private");
                        break;
                    case SrgsRuleScope.Public:
                        writer.WriteAttributeString("scope", "public");
                        break;
                }
            }
            if (_baseclass != null)
            {
                writer.WriteAttributeString("sapi", "baseclass", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", _baseclass);
            }
            if (_dynamic != RuleDynamic.NotSet)
            {
                writer.WriteAttributeString("sapi", "dynamic", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", (_dynamic == RuleDynamic.True) ? "true" : "false");
            }
            if (OnInit != null)
            {
                writer.WriteAttributeString("sapi", "onInit", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", OnInit);
            }
            if (OnParse != null)
            {
                writer.WriteAttributeString("sapi", "onParse", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", OnParse);
            }
            if (OnError != null)
            {
                writer.WriteAttributeString("sapi", "onError", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", OnError);
            }
            if (OnRecognition != null)
            {
                writer.WriteAttributeString("sapi", "onRecognition", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", OnRecognition);
            }
            Type right = null;
            foreach (SrgsElement element in _elements)
            {
                Type type = element.GetType();
                if (type == typeof(SrgsText) && type == right)
                {
                    writer.WriteString(" ");
                }
                right = type;
                element.WriteSrgs(writer);
            }
            writer.WriteEndElement();
            if (HasCode)
            {
                WriteScriptElement(writer, _script);
            }
        }

        internal void Validate(SrgsGrammar grammar)
        {
            bool flag = HasCode || _onInit != null || _onParse != null || _onError != null || _onRecognition != null || _baseclass != null;
            grammar._fContainsCode |= flag;
            grammar.HasSapiExtension |= flag;
            if (_dynamic != RuleDynamic.NotSet)
            {
                grammar.HasSapiExtension = true;
            }
            if (OnInit != null && Scope != 0)
            {
                XmlParser.ThrowSrgsException(SRID.OnInitOnPublicRule, "OnInit", Id);
            }
            if (OnRecognition != null && Scope != 0)
            {
                XmlParser.ThrowSrgsException(SRID.OnInitOnPublicRule, "OnRecognition", Id);
            }
            foreach (SrgsElement element in _elements)
            {
                element.Validate(grammar);
            }
        }

        void IElement.PostParse(IElement grammar)
        {
            ((SrgsGrammar)grammar).Rules.Add(this);
        }

        void IRule.CreateScript(IGrammar grammar, string rule, string method, RuleMethodScript type)
        {
            switch (type)
            {
                case RuleMethodScript.onInit:
                    _onInit = method;
                    break;
                case RuleMethodScript.onParse:
                    _onParse = method;
                    break;
                case RuleMethodScript.onRecognition:
                    _onRecognition = method;
                    break;
                case RuleMethodScript.onError:
                    _onError = method;
                    break;
            }
        }

        private void WriteScriptElement(XmlWriter writer, string sCode)
        {
            writer.WriteStartElement("sapi", "script", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions");
            writer.WriteAttributeString("sapi", "rule", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", _id);
            writer.WriteCData(sCode);
            writer.WriteEndElement();
        }

        private void ValidateIdentifier(string s)
        {
            if (s == _id)
            {
                XmlParser.ThrowSrgsException(SRID.ConstructorNotAllowed, _id);
            }
            if (s != null && (s.IndexOfAny(invalidChars) >= 0 || s.Length == 0))
            {
                XmlParser.ThrowSrgsException(SRID.InvalidMethodName);
            }
        }
    }
}
