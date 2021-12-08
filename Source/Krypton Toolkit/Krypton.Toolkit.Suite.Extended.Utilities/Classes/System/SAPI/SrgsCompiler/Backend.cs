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
    internal sealed class Backend
    {
        private int _langId = CultureInfo.CurrentUICulture.LCID;

        private StringBlob _words;

        private StringBlob _symbols;

        private Guid _guid;

        private bool _fNeedWeightTable;

        private Graph _states = new Graph();

        private List<Rule> _rules = new List<Rule>();

        private int _ruleIndex;

        private Dictionary<int, Rule> _nameOffsetRules = new Dictionary<int, Rule>();

        private Rule _rootRule;

        private GrammarOptions _grammarOptions;

        private int _ulRecursiveDepth;

        private string _basePath;

        private List<Tag> _tags = new List<Tag>();

        private GrammarType _grammarMode;

        private AlphabetType _alphabet;

        private Collection<string> _globalTags = new Collection<string>();

        private static byte[] _abZero3 = new byte[3];

        private static char[] _achZero = new char[1];

        private const uint SPGF_RESET_DIRTY_FLAG = 2147483648u;

        private int _cImportedRules;

        private Collection<ScriptRef> _scriptRefs = new Collection<ScriptRef>();

        private byte[] _il;

        private byte[] _pdb;

        private bool _fLoadedFromBinary;

        internal StringBlob Words => _words;

        internal StringBlob Symbols => _symbols;

        internal int LangId
        {
            get
            {
                return _langId;
            }
            set
            {
                _langId = value;
            }
        }

        internal GrammarOptions GrammarOptions
        {
            get
            {
                return _grammarOptions;
            }
            set
            {
                _grammarOptions = value;
            }
        }

        internal GrammarType GrammarMode
        {
            set
            {
                _grammarMode = value;
            }
        }

        internal AlphabetType Alphabet
        {
            get
            {
                return _alphabet;
            }
            set
            {
                _alphabet = value;
            }
        }

        internal Collection<string> GlobalTags
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

        internal Collection<ScriptRef> ScriptRefs
        {
            set
            {
                _scriptRefs = value;
            }
        }

        internal byte[] IL
        {
            set
            {
                _il = value;
            }
        }

        internal byte[] PDB
        {
            set
            {
                _pdb = value;
            }
        }

        internal Backend()
        {
            _words = new StringBlob();
            _symbols = new StringBlob();
        }

        internal Backend(StreamMarshaler streamHelper)
        {
            InitFromBinaryGrammar(streamHelper);
        }

        internal void Optimize()
        {
            _states.Optimize();
            _fNeedWeightTable = true;
        }

        internal void Commit(StreamMarshaler streamBuffer)
        {
            long position = streamBuffer.Stream.Position;
            List<State> list = new List<State>(_states);
            _states = null;
            list.Sort();
            ValidateAndTagRules();
            CheckLeftRecursion(list);
            int num = (_basePath != null) ? (_basePath.Length + 1) : 0;
            int idWord = 0;
            if (_globalTags.Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (string globalTag in _globalTags)
                {
                    stringBuilder.Append(globalTag);
                }
                _symbols.Add(stringBuilder.ToString(), out idWord);
                idWord = _symbols.OffsetFromId(idWord);
                if (idWord > 65535)
                {
                    throw new OverflowException(SR.Get(SRID.TooManyRulesWithSemanticsGlobals));
                }
            }
            foreach (ScriptRef scriptRef in _scriptRefs)
            {
                _symbols.Add(scriptRef._sMethod, out scriptRef._idSymbol);
            }
            int cArcs;
            float[] pWeights;
            CfgGrammar.CfgSerializedHeader o = BuildHeader(list, num, (ushort)idWord, out cArcs, out pWeights);
            streamBuffer.WriteStream(o);
            streamBuffer.WriteArrayChar(_words.SerializeData(), _words.SerializeSize());
            streamBuffer.WriteArrayChar(_symbols.SerializeData(), _symbols.SerializeSize());
            foreach (Rule rule in _rules)
            {
                rule.Serialize(streamBuffer);
            }
            if (num > 0)
            {
                streamBuffer.WriteArrayChar(_basePath.ToCharArray(), _basePath.Length);
                streamBuffer.WriteArrayChar(_achZero, 1);
                streamBuffer.WriteArray(_abZero3, (num * 2) & 3);
            }
            streamBuffer.WriteStream(default(CfgArc));
            int iOffset = 1;
            uint iArcOffset = 1u;
            bool flag = (GrammarOptions & GrammarOptions.MssV1) == GrammarOptions.MssV1;
            foreach (State item in list)
            {
                item.SerializeStateEntries(streamBuffer, flag, pWeights, ref iArcOffset, ref iOffset);
            }
            if (_fNeedWeightTable)
            {
                streamBuffer.WriteArray(pWeights, cArcs);
            }
            if (!flag)
            {
                foreach (State item2 in list)
                {
                    item2.SetEndArcIndexForTags();
                }
            }
            for (int num2 = _tags.Count - 1; num2 >= 0; num2--)
            {
                if (_tags[num2]._cfgTag.ArcIndex == 0)
                {
                    _tags.RemoveAt(num2);
                }
            }
            _tags.Sort();
            foreach (Tag tag in _tags)
            {
                tag.Serialize(streamBuffer);
            }
            foreach (ScriptRef scriptRef2 in _scriptRefs)
            {
                scriptRef2.Serialize(_symbols, streamBuffer);
            }
            if (_il != null && _il.Length != 0)
            {
                streamBuffer.Stream.Write(_il, 0, _il.Length);
            }
            if (_pdb != null && _pdb.Length != 0)
            {
                streamBuffer.Stream.Write(_pdb, 0, _pdb.Length);
            }
        }

        internal static Backend CombineGrammar(string ruleName, Backend org, Backend extra)
        {
            Backend backend = new Backend();
            backend._fLoadedFromBinary = true;
            backend._fNeedWeightTable = org._fNeedWeightTable;
            backend._grammarMode = org._grammarMode;
            backend._grammarOptions = org._grammarOptions;
            Dictionary<State, State> srcToDestHash = new Dictionary<State, State>();
            foreach (Rule rule in org._rules)
            {
                if (rule.Name == ruleName)
                {
                    backend.CloneSubGraph(rule, org, extra, srcToDestHash, true);
                }
            }
            return backend;
        }

        internal State CreateNewState(Rule rule)
        {
            return _states.CreateNewState(rule);
        }

        internal void DeleteState(State state)
        {
            _states.DeleteState(state);
        }

        internal void MoveInputTransitionsAndDeleteState(State from, State to)
        {
            _states.MoveInputTransitionsAndDeleteState(from, to);
        }

        internal void MoveOutputTransitionsAndDeleteState(State from, State to)
        {
            _states.MoveOutputTransitionsAndDeleteState(from, to);
        }

        internal Rule CreateRule(string name, SPCFGRULEATTRIBUTES attributes)
        {
            SPCFGRULEATTRIBUTES sPCFGRULEATTRIBUTES = SPCFGRULEATTRIBUTES.SPRAF_TopLevel | SPCFGRULEATTRIBUTES.SPRAF_Active | SPCFGRULEATTRIBUTES.SPRAF_Export | SPCFGRULEATTRIBUTES.SPRAF_Import | SPCFGRULEATTRIBUTES.SPRAF_Interpreter | SPCFGRULEATTRIBUTES.SPRAF_Dynamic | SPCFGRULEATTRIBUTES.SPRAF_Root;
            if (attributes != 0 && ((attributes & ~sPCFGRULEATTRIBUTES) != 0 || ((attributes & SPCFGRULEATTRIBUTES.SPRAF_Import) != 0 && (attributes & SPCFGRULEATTRIBUTES.SPRAF_Export) != 0)))
            {
                throw new ArgumentException(SR.Get(SRID.InvalidFlagsSet), "attributes");
            }
            if ((attributes & SPCFGRULEATTRIBUTES.SPRAF_Import) != 0 && ((attributes & SPCFGRULEATTRIBUTES.SPRAF_TopLevel) != 0 || (attributes & SPCFGRULEATTRIBUTES.SPRAF_Active) != 0 || (attributes & SPCFGRULEATTRIBUTES.SPRAF_Root) != 0))
            {
                attributes &= ~(SPCFGRULEATTRIBUTES.SPRAF_TopLevel | SPCFGRULEATTRIBUTES.SPRAF_Active | SPCFGRULEATTRIBUTES.SPRAF_Root);
            }
            if ((attributes & SPCFGRULEATTRIBUTES.SPRAF_Import) != 0 && name[0] == '\0')
            {
                LogError(name, SRID.InvalidImport);
            }
            if (_fLoadedFromBinary)
            {
                foreach (Rule rule2 in _rules)
                {
                    string b = _symbols[rule2._cfgRule._nameOffset];
                    if (!rule2._cfgRule.Dynamic && name == b)
                    {
                        LogError(name, SRID.DuplicatedRuleName);
                    }
                }
            }
            int cImportedRules = 0;
            int idWord;
            Rule rule = new Rule(this, name, _symbols.Add(name, out idWord), attributes, _ruleIndex, 0, _grammarOptions & GrammarOptions.TagFormat, ref cImportedRules);
            rule._iSerialize2 = _ruleIndex++;
            if ((attributes & SPCFGRULEATTRIBUTES.SPRAF_Root) != 0)
            {
                if (_rootRule != null)
                {
                    LogError(name, SRID.RootRuleAlreadyDefined);
                }
                else
                {
                    _rootRule = rule;
                }
            }
            if (rule._cfgRule._nameOffset != 0)
            {
                _nameOffsetRules.Add(rule._cfgRule._nameOffset, rule);
            }
            _rules.Add(rule);
            _rules.Sort();
            return rule;
        }

        internal Rule FindRule(string sRule)
        {
            Rule rule = null;
            if (_nameOffsetRules.Count > 0)
            {
                int num = _symbols.Find(sRule);
                if (num > 0)
                {
                    int num2 = _symbols.OffsetFromId(num);
                    rule = ((num2 > 0 && _nameOffsetRules.ContainsKey(num2)) ? _nameOffsetRules[num2] : null);
                }
            }
            if (rule != null)
            {
                string name = rule.Name;
                if (!string.IsNullOrEmpty(sRule) && (string.IsNullOrEmpty(sRule) || string.IsNullOrEmpty(name) || !(name == sRule)))
                {
                    LogError(sRule, SRID.RuleNameIdConflict);
                }
            }
            if (rule == null)
            {
                return null;
            }
            return rule;
        }

        internal Arc WordTransition(string sWord, float flWeight, int requiredConfidence)
        {
            return CreateTransition(sWord, flWeight, requiredConfidence);
        }

        internal Arc SubsetTransition(string text, MatchMode matchMode)
        {
            text = NormalizeTokenWhiteSpace(text);
            return new Arc(text, null, _words, 1f, 0, null, matchMode, ref _fNeedWeightTable);
        }

        internal Arc RuleTransition(Rule rule, Rule parentRule, float flWeight)
        {
            Rule rule2 = null;
            if (flWeight < 0f)
            {
                XmlParser.ThrowSrgsException(SRID.UnsupportedFormat);
            }
            Rule specialRule = null;
            if (rule == CfgGrammar.SPRULETRANS_WILDCARD || rule == CfgGrammar.SPRULETRANS_DICTATION || rule == CfgGrammar.SPRULETRANS_TEXTBUFFER)
            {
                specialRule = rule;
            }
            else
            {
                rule2 = rule;
            }
            bool fNeedWeightTable = false;
            Arc arc = new Arc(null, rule2, _words, flWeight, 0, specialRule, MatchMode.AllWords, ref fNeedWeightTable);
            AddArc(arc);
            if (rule2 != null && parentRule != null)
            {
                rule2._listRules.Insert(0, parentRule);
            }
            return arc;
        }

        internal Arc EpsilonTransition(float flWeight)
        {
            return CreateTransition(null, flWeight, 0);
        }

        internal void AddSemanticInterpretationTag(Arc arc, CfgGrammar.CfgProperty propertyInfo)
        {
            Tag tag = new Tag(this, propertyInfo);
            _tags.Add(tag);
            arc.AddStartTag(tag);
            arc.AddEndTag(tag);
        }

        internal void AddPropertyTag(Arc start, Arc end, CfgGrammar.CfgProperty propertyInfo)
        {
            Tag tag = new Tag(this, propertyInfo);
            _tags.Add(tag);
            start.AddStartTag(tag);
            end.AddEndTag(tag);
        }

        internal State CloneSubGraph(State srcFromState, State srcEndState, State destFromState)
        {
            Dictionary<State, State> dictionary = new Dictionary<State, State>();
            Stack<State> stack = new Stack<State>();
            Dictionary<Tag, Tag> endArcs = new Dictionary<Tag, Tag>();
            dictionary.Add(srcFromState, destFromState);
            stack.Push(srcFromState);
            while (stack.Count > 0)
            {
                srcFromState = stack.Pop();
                destFromState = dictionary[srcFromState];
                foreach (Arc outArc in srcFromState.OutArcs)
                {
                    State end = outArc.End;
                    State state = null;
                    if (end != null)
                    {
                        if (!dictionary.ContainsKey(end))
                        {
                            state = CreateNewState(end.Rule);
                            dictionary.Add(end, state);
                            stack.Push(end);
                        }
                        else
                        {
                            state = dictionary[end];
                        }
                    }
                    Arc arc2 = new Arc(outArc, destFromState, state);
                    AddArc(arc2);
                    arc2.CloneTags(outArc, _tags, endArcs, null);
                    arc2.ConnectStates();
                }
            }
            return dictionary[srcEndState];
        }

        internal void CloneSubGraph(Rule rule, Backend org, Backend extra, Dictionary<State, State> srcToDestHash, bool fromOrg)
        {
            Backend backend = fromOrg ? org : extra;
            List<State> list = new List<State>();
            Dictionary<Tag, Tag> endArcs = new Dictionary<Tag, Tag>();
            CloneState(rule._firstState, list, srcToDestHash);
            while (list.Count > 0)
            {
                State state = list[0];
                list.RemoveAt(0);
                State start = srcToDestHash[state];
                foreach (Arc outArc in state.OutArcs)
                {
                    State end = outArc.End;
                    State end2 = null;
                    if (end != null)
                    {
                        if (!srcToDestHash.ContainsKey(end))
                        {
                            CloneState(end, list, srcToDestHash);
                        }
                        end2 = srcToDestHash[end];
                    }
                    int idWord = outArc.WordId;
                    if (backend != null && outArc.WordId > 0)
                    {
                        _words.Add(backend.Words[outArc.WordId], out idWord);
                    }
                    Arc arc2 = new Arc(outArc, start, end2, idWord);
                    arc2.CloneTags(outArc, _tags, endArcs, this);
                    if (outArc.RuleRef != null)
                    {
                        string text;
                        if (outArc.RuleRef.Name.IndexOf("URL:DYNAMIC#", StringComparison.Ordinal) == 0)
                        {
                            text = outArc.RuleRef.Name.Substring(12);
                            if (fromOrg && FindInRules(text) == null)
                            {
                                Rule rule2 = extra.FindInRules(text);
                                if (rule2 == null)
                                {
                                    XmlParser.ThrowSrgsException(SRID.DynamicRuleNotFound, text);
                                }
                                CloneSubGraph(rule2, org, extra, srcToDestHash, false);
                            }
                        }
                        else if (outArc.RuleRef.Name.IndexOf("URL:STATIC#", StringComparison.Ordinal) == 0)
                        {
                            text = outArc.RuleRef.Name.Substring(11);
                            if (!fromOrg && FindInRules(text) == null)
                            {
                                Rule rule3 = org.FindInRules(text);
                                if (rule3 == null)
                                {
                                    XmlParser.ThrowSrgsException(SRID.DynamicRuleNotFound, text);
                                }
                                CloneSubGraph(rule3, org, extra, srcToDestHash, true);
                            }
                        }
                        else
                        {
                            text = outArc.RuleRef.Name;
                            Rule rule4 = org.FindInRules(text);
                            if (!fromOrg)
                            {
                                CloneSubGraph(outArc.RuleRef, org, extra, srcToDestHash, true);
                            }
                        }
                        Rule rule5 = FindInRules(text);
                        if (rule5 == null)
                        {
                            rule5 = CloneState(outArc.RuleRef._firstState, list, srcToDestHash);
                        }
                        arc2.RuleRef = rule5;
                    }
                    arc2.ConnectStates();
                }
            }
        }

        internal void DeleteSubGraph(State state)
        {
            Stack<State> stack = new Stack<State>();
            Collection<Arc> collection = new Collection<Arc>();
            Collection<State> collection2 = new Collection<State>();
            stack.Push(state);
            while (stack.Count > 0)
            {
                state = stack.Pop();
                collection2.Add(state);
                collection.Clear();
                foreach (Arc outArc in state.OutArcs)
                {
                    State end = outArc.End;
                    if (end != null && !stack.Contains(end) && !collection2.Contains(end))
                    {
                        stack.Push(end);
                    }
                    collection.Add(outArc);
                }
                foreach (Arc item in collection)
                {
                    State state4 = item.Start = (item.End = null);
                }
            }
            foreach (State item2 in collection2)
            {
                DeleteState(item2);
            }
        }

        internal void SetRuleAttributes(Rule rule, SPCFGRULEATTRIBUTES dwAttributes)
        {
            if ((dwAttributes & SPCFGRULEATTRIBUTES.SPRAF_Root) != 0)
            {
                if (_rootRule != null)
                {
                    XmlParser.ThrowSrgsException(SRID.RootRuleAlreadyDefined);
                }
                else
                {
                    _rootRule = rule;
                }
            }
            rule._cfgRule.TopLevel = ((dwAttributes & SPCFGRULEATTRIBUTES.SPRAF_TopLevel) != 0);
            rule._cfgRule.DefaultActive = ((dwAttributes & SPCFGRULEATTRIBUTES.SPRAF_Active) != 0);
            rule._cfgRule.PropRule = ((dwAttributes & SPCFGRULEATTRIBUTES.SPRAF_Interpreter) != 0);
            rule._cfgRule.Export = ((dwAttributes & SPCFGRULEATTRIBUTES.SPRAF_Export) != 0);
            rule._cfgRule.Dynamic = ((dwAttributes & SPCFGRULEATTRIBUTES.SPRAF_Dynamic) != 0);
            rule._cfgRule.Import = ((dwAttributes & SPCFGRULEATTRIBUTES.SPRAF_Import) != 0);
        }

        internal void SetBasePath(string sBasePath)
        {
            if (!string.IsNullOrEmpty(sBasePath))
            {
                Uri uri = new Uri(sBasePath, UriKind.RelativeOrAbsolute);
                _basePath = uri.ToString();
            }
            else
            {
                _basePath = null;
            }
        }

        internal static string NormalizeTokenWhiteSpace(string sToken)
        {
            sToken = sToken.Trim(Helpers._achTrimChars);
            if (sToken.IndexOf("  ", StringComparison.Ordinal) == -1)
            {
                return sToken;
            }
            char[] array = sToken.ToCharArray();
            int length = 0;
            int num = 0;
            while (num < array.Length)
            {
                if (array[num] == ' ')
                {
                    do
                    {
                        num++;
                    }
                    while (array[num] == ' ');
                    array[length++] = ' ';
                }
                else
                {
                    array[length++] = array[num++];
                }
            }
            return new string(array, 0, length);
        }

        internal void InitFromBinaryGrammar(StreamMarshaler streamHelper)
        {
            CfgGrammar.CfgHeader header = CfgGrammar.ConvertCfgHeader(streamHelper);
            _words = header.pszWords;
            _symbols = header.pszSymbols;
            _grammarOptions = header.GrammarOptions;
            State[] array = new State[header.arcs.Length];
            SortedDictionary<int, Rule> sortedDictionary = new SortedDictionary<int, Rule>();
            int count = _rules.Count;
            BuildRulesFromBinaryGrammar(header, array, sortedDictionary, count);
            Arc[] array2 = new Arc[header.arcs.Length];
            bool flag = true;
            CfgArc cfgArc = default(CfgArc);
            State state = null;
            IEnumerator<KeyValuePair<int, Rule>> enumerator = sortedDictionary.GetEnumerator();
            if (enumerator.MoveNext())
            {
                KeyValuePair<int, Rule> current = enumerator.Current;
                Rule value = current.Value;
                for (int i = 1; i < header.arcs.Length; i++)
                {
                    CfgArc cfgArc2 = header.arcs[i];
                    if (cfgArc2.RuleRef)
                    {
                        value._listRules.Add(_rules[(int)cfgArc2.TransitionIndex]);
                    }
                    if (current.Key == i)
                    {
                        value = current.Value;
                        if (enumerator.MoveNext())
                        {
                            current = enumerator.Current;
                        }
                    }
                    if (flag || cfgArc.LastArc)
                    {
                        if (array[i] == null)
                        {
                            uint nextHandle = CfgGrammar.NextHandle;
                            array[i] = new State(value, nextHandle, i);
                            AddState(array[i]);
                        }
                        state = array[i];
                    }
                    int nextStartArcIndex = (int)cfgArc2.NextStartArcIndex;
                    State end = null;
                    if (state != null && nextStartArcIndex != 0)
                    {
                        if (array[nextStartArcIndex] == null)
                        {
                            uint nextHandle2 = CfgGrammar.NextHandle;
                            array[nextStartArcIndex] = new State(value, nextHandle2, nextStartArcIndex);
                            AddState(array[nextStartArcIndex]);
                        }
                        end = array[nextStartArcIndex];
                    }
                    float flWeight = (header.weights != null) ? header.weights[i] : 1f;
                    Arc arc;
                    if (cfgArc2.RuleRef)
                    {
                        Rule ruleRef = _rules[(int)cfgArc2.TransitionIndex];
                        arc = new Arc(null, ruleRef, _words, flWeight, 0, null, MatchMode.AllWords, ref _fNeedWeightTable);
                    }
                    else
                    {
                        int transitionIndex = (int)cfgArc2.TransitionIndex;
                        int num = (transitionIndex == 4194302 || transitionIndex == 4194301 || transitionIndex == 4194303) ? transitionIndex : 0;
                        arc = new Arc((int)((num == 0) ? cfgArc2.TransitionIndex : 0), flWeight, cfgArc2.LowConfRequired ? (-1) : (cfgArc2.HighConfRequired ? 1 : 0), num, MatchMode.AllWords, ref _fNeedWeightTable);
                    }
                    arc.Start = state;
                    arc.End = end;
                    AddArc(arc);
                    array2[i] = arc;
                    flag = false;
                    cfgArc = cfgArc2;
                }
            }
            int j = 1;
            int k = 0;
            for (; j < header.arcs.Length; j++)
            {
                CfgArc cfgArc3 = header.arcs[j];
                if (!cfgArc3.HasSemanticTag)
                {
                    continue;
                }
                for (; k < header.tags.Length && header.tags[k].StartArcIndex == j; k++)
                {
                    CfgSemanticTag cfgTag = header.tags[k];
                    Tag tag = new Tag(this, cfgTag);
                    _tags.Add(tag);
                    array2[tag._cfgTag.StartArcIndex].AddStartTag(tag);
                    array2[tag._cfgTag.EndArcIndex].AddEndTag(tag);
                    if (cfgTag._nameOffset > 0)
                    {
                        tag._cfgTag._nameOffset = _symbols.OffsetFromId(_symbols.Find(_symbols.FromOffset(cfgTag._nameOffset)));
                    }
                    else
                    {
                        tag._cfgTag._valueOffset = _symbols.OffsetFromId(_symbols.Find(_symbols.FromOffset(cfgTag._valueOffset)));
                    }
                }
            }
            _fNeedWeightTable = true;
            if (header.BasePath != null)
            {
                SetBasePath(header.BasePath);
            }
            _guid = header.GrammarGUID;
            _langId = header.langId;
            _grammarMode = header.GrammarMode;
            _fLoadedFromBinary = true;
        }

        private Arc CreateTransition(string sWord, float flWeight, int requiredConfidence)
        {
            return AddSingleWordTransition((!string.IsNullOrEmpty(sWord)) ? sWord : null, flWeight, requiredConfidence);
        }

        private CfgGrammar.CfgSerializedHeader BuildHeader(List<State> sortedStates, int cBasePath, ushort iSemanticGlobals, out int cArcs, out float[] pWeights)
        {
            cArcs = 1;
            pWeights = null;
            int num = 0;
            int num2 = 0;
            foreach (State sortedState in sortedStates)
            {
                sortedState.SerializeId = cArcs;
                int numArcs = sortedState.NumArcs;
                cArcs += numArcs;
                if (num2 < numArcs)
                {
                    num2 = numArcs;
                }
                num += sortedState.NumSemanticTags;
            }
            CfgGrammar.CfgSerializedHeader cfgSerializedHeader = new CfgGrammar.CfgSerializedHeader();
            uint num3 = (uint)Marshal.SizeOf(typeof(CfgGrammar.CfgSerializedHeader));
            cfgSerializedHeader.FormatId = CfgGrammar._SPGDF_ContextFree;
            _guid = Guid.NewGuid();
            cfgSerializedHeader.GrammarGUID = _guid;
            cfgSerializedHeader.LangID = (ushort)_langId;
            cfgSerializedHeader.pszSemanticInterpretationGlobals = iSemanticGlobals;
            cfgSerializedHeader.cArcsInLargestState = num2;
            cfgSerializedHeader.cchWords = _words.StringSize();
            cfgSerializedHeader.cWords = _words.Count;
            if (cfgSerializedHeader.cWords > 0)
            {
                cfgSerializedHeader.cWords++;
            }
            cfgSerializedHeader.pszWords = num3;
            num3 = (uint)((int)num3 + _words.SerializeSize() * 2);
            cfgSerializedHeader.cchSymbols = _symbols.StringSize();
            cfgSerializedHeader.pszSymbols = num3;
            num3 = (uint)((int)num3 + _symbols.SerializeSize() * 2);
            cfgSerializedHeader.cRules = _rules.Count;
            cfgSerializedHeader.pRules = num3;
            num3 = (uint)((int)num3 + _rules.Count * Marshal.SizeOf(typeof(CfgRule)));
            cfgSerializedHeader.cBasePath = ((cBasePath > 0) ? num3 : 0u);
            num3 = (uint)((int)num3 + ((cBasePath * 2 + 3) & -4));
            cfgSerializedHeader.cArcs = cArcs;
            cfgSerializedHeader.pArcs = num3;
            num3 = (uint)((int)num3 + cArcs * Marshal.SizeOf(typeof(CfgArc)));
            if (_fNeedWeightTable)
            {
                cfgSerializedHeader.pWeights = num3;
                num3 = (uint)((int)num3 + cArcs * Marshal.SizeOf(typeof(float)));
                pWeights = new float[cArcs];
                pWeights[0] = 0f;
            }
            else
            {
                cfgSerializedHeader.pWeights = 0u;
                num3 = num3;
            }
            if (_rootRule != null)
            {
                cfgSerializedHeader.ulRootRuleIndex = (uint)_rootRule._iSerialize;
            }
            else
            {
                cfgSerializedHeader.ulRootRuleIndex = uint.MaxValue;
            }
            cfgSerializedHeader.GrammarOptions = (GrammarOptions)((int)_grammarOptions | ((_alphabet != 0) ? 4 : 0));
            cfgSerializedHeader.GrammarOptions |= (GrammarOptions)((_scriptRefs.Count > 0) ? 18 : 0);
            cfgSerializedHeader.GrammarMode = (uint)_grammarMode;
            cfgSerializedHeader.cTags = num;
            cfgSerializedHeader.tags = num3;
            num3 = (uint)((int)num3 + num * Marshal.SizeOf(typeof(CfgSemanticTag)));
            cfgSerializedHeader.cScripts = _scriptRefs.Count;
            cfgSerializedHeader.pScripts = ((cfgSerializedHeader.cScripts > 0) ? num3 : 0u);
            num3 = (uint)((int)num3 + _scriptRefs.Count * Marshal.SizeOf(typeof(CfgScriptRef)));
            cfgSerializedHeader.cIL = ((_il != null) ? _il.Length : 0);
            cfgSerializedHeader.pIL = ((cfgSerializedHeader.cIL > 0) ? num3 : 0u);
            num3 = (uint)((int)num3 + cfgSerializedHeader.cIL * Marshal.SizeOf(typeof(byte)));
            cfgSerializedHeader.cPDB = ((_pdb != null) ? _pdb.Length : 0);
            cfgSerializedHeader.pPDB = ((cfgSerializedHeader.cPDB > 0) ? num3 : 0u);
            num3 = (cfgSerializedHeader.ulTotalSerializedSize = (uint)((int)num3 + cfgSerializedHeader.cPDB * Marshal.SizeOf(typeof(byte))));
            return cfgSerializedHeader;
        }

        private CfgGrammar.CfgHeader BuildRulesFromBinaryGrammar(CfgGrammar.CfgHeader header, State[] apStateTable, SortedDictionary<int, Rule> ruleFirstArcs, int previousCfgLastRules)
        {
            for (int i = 0; i < header.rules.Length; i++)
            {
                CfgRule cfgRule = header.rules[i];
                int firstArcIndex = (int)cfgRule.FirstArcIndex;
                cfgRule._nameOffset = _symbols.OffsetFromId(_symbols.Find(header.pszSymbols.FromOffset(cfgRule._nameOffset)));
                Rule rule = new Rule(this, _symbols.FromOffset(cfgRule._nameOffset), cfgRule, i + previousCfgLastRules, _grammarOptions & GrammarOptions.TagFormat, ref _cImportedRules);
                rule._firstState = _states.CreateNewState(rule);
                _rules.Add(rule);
                if (firstArcIndex > 0)
                {
                    ruleFirstArcs.Add((int)cfgRule.FirstArcIndex, rule);
                }
                rule._fStaticRule = ((!cfgRule.Dynamic) ? true : false);
                rule._cfgRule.DirtyRule = false;
                rule._fHasExitPath = (rule._fStaticRule ? true : false);
                if (firstArcIndex != 0)
                {
                    rule._firstState.SerializeId = (int)cfgRule.FirstArcIndex;
                    apStateTable[firstArcIndex] = rule._firstState;
                }
                if (rule._cfgRule.HasResources)
                {
                    throw new NotImplementedException();
                }
                if (header.ulRootRuleIndex == i)
                {
                    _rootRule = rule;
                }
                if (rule._cfgRule._nameOffset != 0)
                {
                    _nameOffsetRules.Add(rule._cfgRule._nameOffset, rule);
                }
            }
            return header;
        }

        private Rule CloneState(State srcToState, List<State> CloneStack, Dictionary<State, State> srcToDestHash)
        {
            bool flag = false;
            string ruleName = (srcToState.Rule.Name.IndexOf("URL:DYNAMIC#", StringComparison.Ordinal) != 0) ? srcToState.Rule.Name : srcToState.Rule.Name.Substring(12);
            Rule rule = FindInRules(ruleName);
            if (rule == null)
            {
                rule = srcToState.Rule.Clone(_symbols, ruleName);
                _rules.Add(rule);
                flag = true;
            }
            State state = CreateNewState(rule);
            srcToDestHash.Add(srcToState, state);
            CloneStack.Add(srcToState);
            if (flag)
            {
                rule._firstState = state;
            }
            return rule;
        }

        private Rule FindInRules(string ruleName)
        {
            foreach (Rule rule in _rules)
            {
                if (rule.Name == ruleName)
                {
                    return rule;
                }
            }
            return null;
        }

        private static void LogError(string rule, SRID srid, params object[] args)
        {
            string str = SR.Get(srid, args);
            throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Rule=\"{0}\" - ", new object[1]
            {
                rule
            }) + str);
        }

        private static void AddArc(Arc arc)
        {
        }

        private void ValidateAndTagRules()
        {
            bool flag = false;
            int num = 0;
            foreach (Rule rule in _rules)
            {
                rule._fHasExitPath |= ((byte)((rule._cfgRule.Dynamic | rule._cfgRule.Import) ? 1 : 0) != 0);
                rule._iSerialize = num++;
                flag |= (rule._cfgRule.Dynamic || rule._cfgRule.TopLevel || rule._cfgRule.Export);
                rule.Validate();
            }
            foreach (Rule rule2 in _rules)
            {
                if (rule2._cfgRule.Dynamic)
                {
                    rule2._cfgRule.HasDynamicRef = true;
                    _ulRecursiveDepth = 0;
                    rule2.PopulateDynamicRef(ref _ulRecursiveDepth);
                }
            }
        }

        private void CheckLeftRecursion(List<State> states)
        {
            foreach (State state in states)
            {
                bool fReachedEndState;
                state.CheckLeftRecursion(out fReachedEndState);
            }
        }

        private Arc AddSingleWordTransition(string s, float flWeight, int requiredConfidence)
        {
            Arc arc = new Arc(s, null, _words, flWeight, requiredConfidence, null, MatchMode.AllWords, ref _fNeedWeightTable);
            AddArc(arc);
            return arc;
        }

        internal void AddState(State state)
        {
            _states.Add(state);
        }
    }
}
