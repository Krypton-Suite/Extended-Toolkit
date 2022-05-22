#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal class Arc : IComparer<Arc>, IComparable<Arc>
    {
        private State _start;

        private State _end;

        private int _iWord;

        private Rule _ruleRef;

        private int _specialTransitionIndex;

        private float _flWeight;

        private MatchMode _matchMode;

        private int _confidence;

        private uint _iSerialize;

        private Collection<Tag> _startTags;

        private Collection<Tag> _endTags;

        private static uint _serializeToken = 1u;

        internal bool IsEpsilonTransition
        {
            get
            {
                if (_ruleRef == null && _specialTransitionIndex == 0)
                {
                    return _iWord == 0;
                }
                return false;
            }
        }

        internal bool IsPropertylessTransition
        {
            get
            {
                if (_startTags == null)
                {
                    return _endTags == null;
                }
                return false;
            }
        }

        internal int SemanticTagCount
        {
            get
            {
                if (_startTags != null)
                {
                    return _startTags.Count;
                }
                return 0;
            }
        }

        internal State Start
        {
            get
            {
                return _start;
            }
            set
            {
                if (value != _start)
                {
                    if (_start != null)
                    {
                        _start.OutArcs.Remove(this);
                    }
                    _start = value;
                    if (_start != null)
                    {
                        _start.OutArcs.Add(this);
                    }
                }
            }
        }

        internal State End
        {
            get
            {
                return _end;
            }
            set
            {
                if (value != _end)
                {
                    if (_end != null)
                    {
                        _end.InArcs.Remove(this);
                    }
                    _end = value;
                    if (_end != null)
                    {
                        _end.InArcs.Add(this);
                    }
                }
            }
        }

        internal int WordId => _iWord;

        internal Rule RuleRef
        {
            get
            {
                return _ruleRef;
            }
            set
            {
                if ((_start != null && !_start.OutArcs.IsEmpty) || (_end != null && !_end.InArcs.IsEmpty))
                {
                    throw new InvalidOperationException();
                }
                _ruleRef = value;
            }
        }

        internal float Weight
        {
            get
            {
                return _flWeight;
            }
            set
            {
                _flWeight = value;
            }
        }

        internal int SpecialTransitionIndex => _specialTransitionIndex;

        internal Arc()
        {
        }

        internal Arc(Arc arc)
            : this()
        {
            _start = arc._start;
            _end = arc._end;
            _iWord = arc._iWord;
            _flWeight = arc._flWeight;
            _confidence = arc._confidence;
            _ruleRef = arc._ruleRef;
            _specialTransitionIndex = arc._specialTransitionIndex;
            _iSerialize = arc._iSerialize;
            _matchMode = arc._matchMode;
        }

        internal Arc(Arc arc, State start, State end)
            : this(arc)
        {
            _start = start;
            _end = end;
        }

        internal Arc(Arc arc, State start, State end, int wordId)
            : this(arc, start, end)
        {
            _iWord = wordId;
        }

        internal Arc(string sWord, Rule ruleRef, StringBlob words, float flWeight, int confidence, Rule specialRule, MatchMode matchMode, ref bool fNeedWeightTable)
            : this(sWord, ruleRef, words, flWeight, confidence, specialRule, _serializeToken++, matchMode, ref fNeedWeightTable)
        {
        }

        private Arc(string sWord, Rule ruleRef, StringBlob words, float flWeight, int confidence, Rule specialRule, uint iSerialize, MatchMode matchMode, ref bool fNeedWeightTable)
            : this(0, flWeight, confidence, 0, matchMode, ref fNeedWeightTable)
        {
            _ruleRef = ruleRef;
            _iSerialize = iSerialize;
            if (ruleRef == null)
            {
                if (specialRule != null)
                {
                    _specialTransitionIndex = ((specialRule == CfgGrammar.SPRULETRANS_WILDCARD) ? 4194302 : ((specialRule == CfgGrammar.SPRULETRANS_DICTATION) ? 4194301 : 4194303));
                }
                else
                {
                    words.Add(sWord, out _iWord);
                }
            }
        }

        internal Arc(int iWord, float flWeight, int confidence, int ulSpecialTransitionIndex, MatchMode matchMode, ref bool fNeedWeightTable)
            : this()
        {
            _confidence = confidence;
            _iWord = iWord;
            _flWeight = flWeight;
            _matchMode = matchMode;
            _iSerialize = _serializeToken++;
            if (!flWeight.Equals(1f))
            {
                fNeedWeightTable |= true;
            }
            _specialTransitionIndex = ulSpecialTransitionIndex;
        }

        public int CompareTo(Arc obj1)
        {
            return Compare(this, obj1);
        }

        int IComparer<Arc>.Compare(Arc obj1, Arc obj2)
        {
            return Compare(obj1, obj2);
        }

        private int Compare(Arc obj1, Arc obj2)
        {
            if (obj1 == obj2)
            {
                return 0;
            }
            if (obj1 == null)
            {
                return -1;
            }
            if (obj2 == null)
            {
                return 1;
            }
            int num = obj1.SortRank() - obj2.SortRank();
            return (num != 0) ? num : ((int)(obj1._iSerialize - obj2._iSerialize));
        }

        internal static int CompareContent(Arc arc1, Arc arc2)
        {
            if (arc1._iWord != arc2._iWord)
            {
                return arc1._iWord - arc2._iWord;
            }
            if (arc1._ruleRef != null || arc2._ruleRef != null || arc1._specialTransitionIndex - arc2._specialTransitionIndex + (arc1._confidence - arc2._confidence) != 0)
            {
                int num = 0;
                if (arc1._ruleRef != null || arc2._ruleRef != null)
                {
                    num = ((arc1._ruleRef != null && arc2._ruleRef == null) ? (-1) : ((arc1._ruleRef == null && arc2._ruleRef != null) ? 1 : string.Compare(arc1._ruleRef.Name, arc2._ruleRef.Name, StringComparison.CurrentCulture)));
                }
                if (num != 0)
                {
                    return num;
                }
                if (arc1._specialTransitionIndex != arc2._specialTransitionIndex)
                {
                    return arc1._specialTransitionIndex - arc2._specialTransitionIndex;
                }
                if (arc1._confidence != arc2._confidence)
                {
                    return arc1._confidence - arc2._confidence;
                }
            }
            return 0;
        }

        internal static int CompareContentForKey(Arc arc1, Arc arc2)
        {
            int num = CompareContent(arc1, arc2);
            if (num == 0)
            {
                return (int)(arc1._iSerialize - arc2._iSerialize);
            }
            return num;
        }

        internal float Serialize(StreamMarshaler streamBuffer, bool isLast, uint arcIndex)
        {
            CfgArc cfgArc = default(CfgArc);
            cfgArc.LastArc = isLast;
            cfgArc.HasSemanticTag = (SemanticTagCount > 0);
            cfgArc.NextStartArcIndex = (uint)((_end != null) ? _end.SerializeId : 0);
            if (_ruleRef != null)
            {
                cfgArc.RuleRef = true;
                cfgArc.TransitionIndex = (uint)_ruleRef._iSerialize;
            }
            else
            {
                cfgArc.RuleRef = false;
                if (_specialTransitionIndex != 0)
                {
                    cfgArc.TransitionIndex = (uint)_specialTransitionIndex;
                }
                else
                {
                    cfgArc.TransitionIndex = (uint)_iWord;
                }
            }
            cfgArc.LowConfRequired = (_confidence < 0);
            cfgArc.HighConfRequired = (_confidence > 0);
            cfgArc.MatchMode = (uint)_matchMode;
            _iSerialize = arcIndex;
            streamBuffer.WriteStream(cfgArc);
            return _flWeight;
        }

        internal static float SerializeExtraEpsilonWithTag(StreamMarshaler streamBuffer, Arc arc, bool isLast, uint arcIndex)
        {
            CfgArc cfgArc = default(CfgArc);
            cfgArc.LastArc = isLast;
            cfgArc.HasSemanticTag = true;
            cfgArc.NextStartArcIndex = arcIndex;
            cfgArc.TransitionIndex = 0u;
            cfgArc.LowConfRequired = false;
            cfgArc.HighConfRequired = false;
            cfgArc.MatchMode = (uint)arc._matchMode;
            streamBuffer.WriteStream(cfgArc);
            return arc._flWeight;
        }

        internal void SetArcIndexForTag(int iArc, uint iArcOffset, bool tagsCannotSpanOverMultipleArcs)
        {
            _startTags[iArc]._cfgTag.StartArcIndex = iArcOffset;
            _startTags[iArc]._cfgTag.ArcIndex = iArcOffset;
            if (tagsCannotSpanOverMultipleArcs)
            {
                _startTags[iArc]._cfgTag.EndArcIndex = iArcOffset;
            }
        }

        internal void SetEndArcIndexForTags()
        {
            if (_endTags != null)
            {
                foreach (Tag endTag in _endTags)
                {
                    endTag._cfgTag.EndArcIndex = _iSerialize;
                }
            }
        }

        internal static int CompareForDuplicateInputTransitions(Arc arc1, Arc arc2)
        {
            int num = CompareContent(arc1, arc2);
            if (num != 0)
            {
                return num;
            }
            return (int)(((arc1._start != null) ? arc1._start.Id : 0) - ((arc2._start != null) ? arc2._start.Id : 0));
        }

        internal static int CompareForDuplicateOutputTransitions(Arc arc1, Arc arc2)
        {
            int num = CompareContent(arc1, arc2);
            if (num != 0)
            {
                return num;
            }
            return (int)(((arc1._end != null) ? arc1._end.Id : 0) - ((arc2._end != null) ? arc2._end.Id : 0));
        }

        internal static int CompareIdenticalTransitions(Arc arc1, Arc arc2)
        {
            int num = (int)(((arc1._start != null) ? arc1._start.Id : 0) - ((arc2._start != null) ? arc2._start.Id : 0));
            if (num == 0 && (num = (int)(((arc1._end != null) ? arc1._end.Id : 0) - ((arc2._end != null) ? arc2._end.Id : 0))) == 0)
            {
                num = ((!arc1.SameTags(arc2)) ? 1 : 0);
            }
            return num;
        }

        internal void AddStartTag(Tag tag)
        {
            if (_startTags == null)
            {
                _startTags = new Collection<Tag>();
            }
            _startTags.Add(tag);
        }

        internal void AddEndTag(Tag tag)
        {
            if (_endTags == null)
            {
                _endTags = new Collection<Tag>();
            }
            _endTags.Add(tag);
        }

        internal void ClearTags()
        {
            _startTags = null;
            _endTags = null;
        }

        internal static void CopyTags(Arc src, Arc dest, Direction move)
        {
            if (src._startTags != null)
            {
                if (dest._startTags == null)
                {
                    dest._startTags = src._startTags;
                }
                else if (move == Direction.Right)
                {
                    for (int i = 0; i < src._startTags.Count; i++)
                    {
                        dest._startTags.Insert(i, src._startTags[i]);
                    }
                }
                else
                {
                    foreach (Tag startTag in src._startTags)
                    {
                        dest._startTags.Add(startTag);
                    }
                }
            }
            if (src._endTags != null)
            {
                if (dest._endTags == null)
                {
                    dest._endTags = src._endTags;
                }
                else if (move == Direction.Right)
                {
                    for (int j = 0; j < src._endTags.Count; j++)
                    {
                        dest._endTags.Insert(j, src._endTags[j]);
                    }
                }
                else
                {
                    foreach (Tag endTag in src._endTags)
                    {
                        dest._endTags.Add(endTag);
                    }
                }
            }
            src._startTags = (src._endTags = null);
        }

        internal void CloneTags(Arc arc, List<Tag> _tags, Dictionary<Tag, Tag> endArcs, Backend be)
        {
            if (arc._startTags != null)
            {
                if (_startTags == null)
                {
                    _startTags = new Collection<Tag>();
                }
                foreach (Tag startTag in arc._startTags)
                {
                    Tag tag = new Tag(startTag);
                    _tags.Add(tag);
                    _startTags.Add(tag);
                    endArcs.Add(startTag, tag);
                    if (be != null)
                    {
                        int idWord;
                        tag._cfgTag._nameOffset = be.Symbols.Add(startTag._be.Symbols.FromOffset(startTag._cfgTag._nameOffset), out idWord);
                        if (startTag._cfgTag._valueOffset != 0 && startTag._cfgTag.PropVariantType == VarEnum.VT_EMPTY)
                        {
                            tag._cfgTag._valueOffset = be.Symbols.Add(startTag._be.Symbols.FromOffset(startTag._cfgTag._valueOffset), out idWord);
                        }
                    }
                }
            }
            if (arc._endTags != null)
            {
                if (_endTags == null)
                {
                    _endTags = new Collection<Tag>();
                }
                foreach (Tag endTag in arc._endTags)
                {
                    Tag item = endArcs[endTag];
                    _endTags.Add(item);
                    endArcs.Remove(endTag);
                }
            }
        }

        internal bool SameTags(Arc arc)
        {
            bool flag = _startTags == null && arc._startTags == null;
            if (!flag && _startTags != null && arc._startTags != null && _startTags.Count == arc._startTags.Count)
            {
                flag = true;
                for (int i = 0; i < _startTags.Count; i++)
                {
                    flag &= (_startTags[i] == arc._startTags[i]);
                }
            }
            if (flag)
            {
                flag = (_endTags == null && arc._endTags == null);
                if (!flag && _endTags != null && arc._endTags != null && _endTags.Count == arc._endTags.Count)
                {
                    flag = true;
                    for (int j = 0; j < _endTags.Count; j++)
                    {
                        flag &= (_endTags[j] == arc._endTags[j]);
                    }
                }
            }
            return flag;
        }

        internal void ConnectStates()
        {
            if (_end != null)
            {
                _end.InArcs.Add(this);
            }
            if (_start != null)
            {
                _start.OutArcs.Add(this);
            }
        }

        private int SortRank()
        {
            int num = 0;
            if (_ruleRef != null)
            {
                num = 16777216 + _ruleRef._cfgRule._nameOffset;
            }
            if (_iWord != 0)
            {
                num += 33554432 + _iWord;
            }
            if (_specialTransitionIndex != 0)
            {
                num += 50331648;
            }
            return num;
        }
    }
}