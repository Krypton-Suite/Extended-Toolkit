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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal sealed class Rule : ParseElementCollection, IRule, IElement, IComparable<Rule>
    {
        internal CfgRule _cfgRule;

        internal State _firstState;

        internal bool _fHasExitPath;

        internal bool _fHasDynamicRef;

        internal bool _fIsEpsilonRule;

        internal int _iSerialize;

        internal int _iSerialize2;

        internal List<Rule> _listRules = new List<Rule>();

        internal bool _fStaticRule;

        private string _id;

        private string _baseclass;

        private StringBuilder _script = new StringBuilder();

        private StringBuilder _constructors = new StringBuilder();

        internal string Name => _id;

        string IRule.BaseClass
        {
            get
            {
                return _baseclass;
            }
            set
            {
                _baseclass = value;
            }
        }

        internal string BaseClass => _baseclass;

        internal StringBuilder Script => _script;

        internal StringBuilder Constructors => _constructors;

        internal Rule(int iSerialize)
            : base(null, null)
        {
            _iSerialize = iSerialize;
        }

        internal Rule(Backend backend, string name, CfgRule cfgRule, int iSerialize, GrammarOptions SemanticFormat, ref int cImportedRules)
            : base(backend, null)
        {
            _rule = this;
            Init(name, cfgRule, iSerialize, SemanticFormat, ref cImportedRules);
        }

        internal Rule(Backend backend, string name, int offsetName, SPCFGRULEATTRIBUTES attributes, int id, int iSerialize, GrammarOptions SemanticFormat, ref int cImportedRules)
            : base(backend, null)
        {
            _rule = this;
            Init(name, new CfgRule(id, offsetName, attributes), iSerialize, SemanticFormat, ref cImportedRules);
        }

        int IComparable<Rule>.CompareTo(Rule rule2)
        {
            if (_cfgRule.Import)
            {
                if (!rule2._cfgRule.Import)
                {
                    return -1;
                }
                return _cfgRule._nameOffset - rule2._cfgRule._nameOffset;
            }
            if (_cfgRule.Dynamic)
            {
                if (!rule2._cfgRule.Dynamic)
                {
                    return 1;
                }
                return _cfgRule._nameOffset - rule2._cfgRule._nameOffset;
            }
            if (!rule2._cfgRule.Import)
            {
                if (!rule2._cfgRule.Dynamic)
                {
                    return _cfgRule._nameOffset - rule2._cfgRule._nameOffset;
                }
                return -1;
            }
            return 1;
        }

        internal void Validate()
        {
            if (!_cfgRule.Dynamic && !_cfgRule.Import && _id != "VOID" && _firstState.NumArcs == 0)
            {
                XmlParser.ThrowSrgsException(SRID.EmptyRule);
            }
            else
            {
                _fHasDynamicRef = _cfgRule.Dynamic;
            }
        }

        internal void PopulateDynamicRef(ref int iRecursiveDepth)
        {
            if (iRecursiveDepth > 256)
            {
                XmlParser.ThrowSrgsException(SRID.MaxTransitionsCount);
            }
            foreach (Rule listRule in _listRules)
            {
                if (!listRule._fHasDynamicRef)
                {
                    listRule._fHasDynamicRef = true;
                    listRule.PopulateDynamicRef(ref iRecursiveDepth);
                }
            }
        }

        internal Rule Clone(StringBlob symbol, string ruleName)
        {
            Rule rule = new Rule(_iSerialize);
            int idWord;
            int nameOffset = symbol.Add(ruleName, out idWord);
            rule._id = ruleName;
            rule._cfgRule = new CfgRule(idWord, nameOffset, _cfgRule._flag);
            rule._cfgRule.DirtyRule = true;
            rule._cfgRule.FirstArcIndex = 0u;
            return rule;
        }

        internal void Serialize(StreamMarshaler streamBuffer)
        {
            _cfgRule.FirstArcIndex = (uint)((_firstState != null && !_firstState.OutArcs.IsEmpty) ? _firstState.SerializeId : 0);
            _cfgRule.DirtyRule = true;
            streamBuffer.WriteStream(_cfgRule);
        }

        void IElement.PostParse(IElement grammar)
        {
            if (_endArc == null)
            {
                _firstState = _backend.CreateNewState(this);
                return;
            }
            TrimEndEpsilons(_endArc, _backend);
            if (_startArc.IsEpsilonTransition && _startArc.End != null && Graph.MoveSemanticTagRight(_startArc))
            {
                _firstState = _startArc.End;
                _startArc.End = null;
            }
            else
            {
                _firstState = _backend.CreateNewState(this);
                _startArc.Start = _firstState;
            }
        }

        void IRule.CreateScript(IGrammar grammar, string rule, string method, RuleMethodScript type)
        {
            ((GrammarElement)grammar).CustomGrammar._scriptRefs.Add(new ScriptRef(rule, method, type));
        }

        private void Init(string id, CfgRule cfgRule, int iSerialize, GrammarOptions SemanticFormat, ref int cImportedRules)
        {
            _id = id;
            _cfgRule = cfgRule;
            _firstState = null;
            _cfgRule.DirtyRule = true;
            _iSerialize = iSerialize;
            _fHasExitPath = false;
            _fHasDynamicRef = false;
            _fIsEpsilonRule = false;
            _fStaticRule = false;
            if (_cfgRule.Import)
            {
                cImportedRules++;
            }
        }

        private static void TrimEndEpsilons(Arc end, Backend backend)
        {
            State start = end.Start;
            if (start != null && end.IsEpsilonTransition && start.OutArcs.CountIsOne && Graph.MoveSemanticTagLeft(end))
            {
                end.Start = null;
                foreach (Arc item in start.InArcs.ToList())
                {
                    item.End = null;
                    TrimEndEpsilons(item, backend);
                }
                backend.DeleteState(start);
            }
        }
    }
}