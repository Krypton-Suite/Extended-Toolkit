#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal class GrammarElement : ParseElement, IGrammar, IElement
    {
        private Backend _backend;

        private List<Rule> _undefRules = new List<Rule>();

        private List<Rule> _rules = new List<Rule>();

        private CustomGrammar _cg;

        private string _sRoot;

        private bool _hasRoot;

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
            set
            {
                _backend.GrammarMode = value;
            }
        }

        AlphabetType IGrammar.PhoneticAlphabet
        {
            set
            {
                _backend.Alphabet = value;
            }
        }

        SrgsTagFormat IGrammar.TagFormat
        {
            get
            {
                return SrgsDocument.GrammarOptions2TagFormat(_backend.GrammarOptions);
            }
            set
            {
                _backend.GrammarOptions = SrgsDocument.TagFormat2GrammarOptions(value);
            }
        }

        Collection<string> IGrammar.GlobalTags
        {
            get
            {
                return _backend.GlobalTags;
            }
            set
            {
                _backend.GlobalTags = value;
            }
        }

        internal List<Rule> UndefRules => _undefRules;

        internal Backend Backend => _backend;

        string IGrammar.Language
        {
            get
            {
                return _cg._language;
            }
            set
            {
                _cg._language = value;
            }
        }

        string IGrammar.Namespace
        {
            get
            {
                return _cg._namespace;
            }
            set
            {
                _cg._namespace = value;
            }
        }

        Collection<string> IGrammar.CodeBehind
        {
            get
            {
                return _cg._codebehind;
            }
            set
            {
                _cg._codebehind = value;
            }
        }

        bool IGrammar.Debug
        {
            set
            {
                _cg._fDebugScript = value;
            }
        }

        Collection<string> IGrammar.ImportNamespaces
        {
            get
            {
                return _cg._importNamespaces;
            }
            set
            {
                _cg._importNamespaces = value;
            }
        }

        Collection<string> IGrammar.AssemblyReferences
        {
            get
            {
                return _cg._assemblyReferences;
            }
            set
            {
                _cg._assemblyReferences = value;
            }
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