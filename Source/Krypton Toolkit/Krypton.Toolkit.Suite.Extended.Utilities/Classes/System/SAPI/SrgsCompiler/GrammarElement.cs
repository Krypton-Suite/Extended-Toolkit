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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal class GrammarElement : ParseElement, IGrammar, IElement
    {
        private Backend _backend;

        private List<Rule> _undefRules = new();

        private List<Rule> _rules = new();

        private CustomGrammar _cg;

        private string _sRoot;

        private bool _hasRoot;

        string IGrammar.Root
        {
            get => _sRoot;
            set => _sRoot = value;
        }

        Uri IGrammar.XmlBase
        {
            set
            {
                if (value != null)
                {
                    _backend.SetBasePath(value.ToString());
                }
            }
        }

        CultureInfo IGrammar.Culture
        {
            set
            {
                Helpers.ThrowIfNull(value, "value");
                _backend.LangId = value.LCID;
            }
        }

        GrammarType IGrammar.Mode
        {
            set => _backend.GrammarMode = value;
        }

        AlphabetType IGrammar.PhoneticAlphabet
        {
            set => _backend.Alphabet = value;
        }

        SrgsTagFormat IGrammar.TagFormat
        {
            get => SrgsDocument.GrammarOptions2TagFormat(_backend.GrammarOptions);
            set => _backend.GrammarOptions = SrgsDocument.TagFormat2GrammarOptions(value);
        }

        Collection<string> IGrammar.GlobalTags
        {
            get => _backend.GlobalTags;
            set => _backend.GlobalTags = value;
        }

        internal List<Rule> UndefRules => _undefRules;

        internal Backend Backend => _backend;

        string IGrammar.Language
        {
            get => _cg._language;
            set => _cg._language = value;
        }

        string IGrammar.Namespace
        {
            get => _cg._namespace;
            set => _cg._namespace = value;
        }

        Collection<string> IGrammar.CodeBehind
        {
            get => _cg._codebehind;
            set => _cg._codebehind = value;
        }

        bool IGrammar.Debug
        {
            set => _cg._fDebugScript = value;
        }

        Collection<string> IGrammar.ImportNamespaces
        {
            get => _cg._importNamespaces;
            set => _cg._importNamespaces = value;
        }

        Collection<string> IGrammar.AssemblyReferences
        {
            get => _cg._assemblyReferences;
            set => _cg._assemblyReferences = value;
        }

        internal CustomGrammar CustomGrammar => _cg;

        internal GrammarElement(Backend backend, CustomGrammar cg)
            : base(null)
        {
            _cg = cg;
            _backend = backend;
        }

        IRule IGrammar.CreateRule(string id, RulePublic publicRule, RuleDynamic dynamic, bool hasScript)
        {
            SPCFGRULEATTRIBUTES sPCFGRULEATTRIBUTES = (SPCFGRULEATTRIBUTES)0;
            if (id == _sRoot)
            {
                sPCFGRULEATTRIBUTES |= (SPCFGRULEATTRIBUTES.SPRAF_TopLevel | SPCFGRULEATTRIBUTES.SPRAF_Active | SPCFGRULEATTRIBUTES.SPRAF_Root);
                _hasRoot = true;
            }
            if (publicRule == RulePublic.True)
            {
                sPCFGRULEATTRIBUTES |= (SPCFGRULEATTRIBUTES.SPRAF_TopLevel | SPCFGRULEATTRIBUTES.SPRAF_Export);
            }
            if (dynamic == RuleDynamic.True)
            {
                sPCFGRULEATTRIBUTES |= SPCFGRULEATTRIBUTES.SPRAF_Dynamic;
            }
            Rule rule = GetRule(id, sPCFGRULEATTRIBUTES);
            if (publicRule == RulePublic.True || id == _sRoot || hasScript)
            {
                _cg._rules.Add(rule);
            }
            return rule;
        }

        void IElement.PostParse(IElement parent)
        {
            if (_sRoot != null && !_hasRoot)
            {
                XmlParser.ThrowSrgsException(SRID.RootNotDefined, _sRoot);
            }
            if (_undefRules.Count > 0)
            {
                Rule rule = _undefRules[0];
                XmlParser.ThrowSrgsException(SRID.UndefRuleRef, rule.Name);
            }
            if ((((IGrammar)this).CodeBehind.Count > 0 || ((IGrammar)this).ImportNamespaces.Count > 0 || ((IGrammar)this).AssemblyReferences.Count > 0 || CustomGrammar._scriptRefs.Count > 0) && ((IGrammar)this).TagFormat != SrgsTagFormat.KeyValuePairs)
            {
                XmlParser.ThrowSrgsException(SRID.InvalidSemanticProcessingType);
            }
        }

        internal void AddScript(string name, string code)
        {
            foreach (Rule rule in _cg._rules)
            {
                if (rule.Name == name)
                {
                    rule.Script.Append(code);
                    break;
                }
            }
        }

        private Rule GetRule(string sRuleId, SPCFGRULEATTRIBUTES dwAttributes)
        {
            Rule rule = _backend.FindRule(sRuleId);
            if (rule != null)
            {
                int num = _undefRules.IndexOf(rule);
                if (num != -1)
                {
                    _backend.SetRuleAttributes(rule, dwAttributes);
                    _undefRules.RemoveAt(num);
                }
                else
                {
                    XmlParser.ThrowSrgsException(SRID.RuleRedefinition, sRuleId);
                }
            }
            else
            {
                rule = _backend.CreateRule(sRuleId, dwAttributes);
            }
            return rule;
        }
    }
}