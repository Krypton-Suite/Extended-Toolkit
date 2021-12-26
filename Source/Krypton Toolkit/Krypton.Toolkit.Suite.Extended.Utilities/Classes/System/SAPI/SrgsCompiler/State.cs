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
    internal sealed class State : IComparable<State>
    {
        internal enum RecurFlag : uint
        {
            RF_CHECKED_EPSILON = 1u,
            RF_CHECKED_EXIT_PATH = 2u,
            RF_CHECKED_LEFT_RECURSION = 4u,
            RF_IN_LEFT_RECUR_CHECK = 8u
        }

        private ArcList _outArcs = new ArcList();

        private ArcList _inArcs = new ArcList();

        private int _iSerialize;

        private uint _id;

        private Rule _rule;

        private State _next;

        private State _prev;

        private RecurFlag _recurseFlag;

        internal State Next => _next;

        internal State Prev => _prev;

        internal int NumArcs
        {
            get
            {
                int num = 0;
                foreach (Arc outArc in _outArcs)
                {
                    if (outArc.SemanticTagCount > 0)
                    {
                        num += outArc.SemanticTagCount - 1;
                    }
                }
                int num2 = 0;
                foreach (Arc outArc2 in _outArcs)
                {
                    num2++;
                }
                return num2 + num;
            }
        }

        internal int NumSemanticTags
        {
            get
            {
                int num = 0;
                foreach (Arc outArc in _outArcs)
                {
                    num += outArc.SemanticTagCount;
                }
                return num;
            }
        }

        internal Rule Rule => _rule;

        internal uint Id => _id;

        internal ArcList OutArcs => _outArcs;

        internal ArcList InArcs => _inArcs;

        internal int SerializeId
        {
            get
            {
                return _iSerialize;
            }
            set
            {
                _iSerialize = value;
            }
        }

        internal State(Rule rule, uint hState, int iSerialize)
        {
            _rule = rule;
            _iSerialize = iSerialize;
            _id = hState;
        }

        internal State(Rule rule, uint hState)
            : this(rule, hState, (int)hState)
        {
        }

        int IComparable<State>.CompareTo(State state2)
        {
            return Compare(this, state2);
        }

        internal void SerializeStateEntries(StreamMarshaler streamBuffer, bool tagsCannotSpanOverMultipleArcs, float[] pWeights, ref uint iArcOffset, ref int iOffset)
        {
            List<Arc> list = _outArcs.ToList();
            list.Sort();
            Arc arc = (list.Count > 0) ? list[list.Count - 1] : null;
            IEnumerator<Arc> enumerator = ((IEnumerable<Arc>)list).GetEnumerator();
            enumerator.MoveNext();
            uint num = (uint)(list.Count + (int)iArcOffset);
            uint num2 = num;
            foreach (Arc item in list)
            {
                int semanticTagCount = item.SemanticTagCount;
                if (semanticTagCount > 0)
                {
                    item.SetArcIndexForTag(0, iArcOffset, tagsCannotSpanOverMultipleArcs);
                }
                if (semanticTagCount <= 1)
                {
                    pWeights[iOffset++] = item.Serialize(streamBuffer, arc == item, iArcOffset++);
                }
                else
                {
                    iArcOffset++;
                    pWeights[iOffset++] = Arc.SerializeExtraEpsilonWithTag(streamBuffer, item, arc == item, num);
                    num = (uint)((int)num + (semanticTagCount - 1));
                }
            }
            enumerator = ((IEnumerable<Arc>)list).GetEnumerator();
            enumerator.MoveNext();
            num = num2;
            foreach (Arc item2 in list)
            {
                int semanticTagCount2 = item2.SemanticTagCount;
                if (semanticTagCount2 > 1)
                {
                    for (int i = 1; i < semanticTagCount2 - 1; i++)
                    {
                        item2.SetArcIndexForTag(i, iArcOffset, tagsCannotSpanOverMultipleArcs);
                        num++;
                        pWeights[iOffset++] = Arc.SerializeExtraEpsilonWithTag(streamBuffer, item2, true, num);
                        iArcOffset++;
                    }
                    item2.SetArcIndexForTag(semanticTagCount2 - 1, iArcOffset, tagsCannotSpanOverMultipleArcs);
                    pWeights[iOffset++] = item2.Serialize(streamBuffer, true, iArcOffset++);
                    num++;
                }
            }
        }

        internal void SetEndArcIndexForTags()
        {
            foreach (Arc outArc in _outArcs)
            {
                outArc.SetEndArcIndexForTags();
            }
        }

        internal void Init()
        {
        }

        internal State Add(State state)
        {
            _next = state;
            state._prev = this;
            return state;
        }

        internal void Remove()
        {
            if (_prev != null)
            {
                _prev._next = _next;
            }
            if (_next != null)
            {
                _next._prev = _prev;
            }
            _next = (_prev = null);
        }

        internal void CheckLeftRecursion(out bool fReachedEndState)
        {
            fReachedEndState = false;
            if ((_recurseFlag & RecurFlag.RF_IN_LEFT_RECUR_CHECK) != 0)
            {
                XmlParser.ThrowSrgsException(SRID.CircularRuleRef, (_rule != null) ? _rule._rule.Name : string.Empty);
            }
            else if ((_recurseFlag & RecurFlag.RF_CHECKED_LEFT_RECURSION) == 0)
            {
                _recurseFlag |= (RecurFlag)12u;
                foreach (Arc outArc in _outArcs)
                {
                    bool fReachedEndState2 = false;
                    if (outArc.RuleRef != null && outArc.RuleRef._firstState != null)
                    {
                        State firstState = outArc.RuleRef._firstState;
                        if ((firstState._recurseFlag & RecurFlag.RF_IN_LEFT_RECUR_CHECK) != 0 || (firstState._recurseFlag & RecurFlag.RF_CHECKED_LEFT_RECURSION) == 0)
                        {
                            firstState.CheckLeftRecursion(out fReachedEndState2);
                        }
                        else
                        {
                            fReachedEndState2 = outArc.RuleRef._fIsEpsilonRule;
                        }
                    }
                    if (fReachedEndState2 || (outArc.RuleRef == null && outArc.WordId == 0 && outArc.WordId == 0))
                    {
                        if (outArc.End != null)
                        {
                            outArc.End.CheckLeftRecursion(out fReachedEndState);
                        }
                        else
                        {
                            fReachedEndState = true;
                        }
                    }
                }
                _recurseFlag &= (RecurFlag)4294967287u;
                if ((_rule._firstState == this) & fReachedEndState)
                {
                    _rule._fIsEpsilonRule = true;
                }
            }
        }

        private static int Compare(State state1, State state2)
        {
            if (state1._rule._cfgRule._nameOffset != state2._rule._cfgRule._nameOffset)
            {
                return state1._rule._cfgRule._nameOffset - state2._rule._cfgRule._nameOffset;
            }
            int num = (state1._rule._firstState == state1) ? (-1) : 0;
            int num2 = (state2._rule._firstState == state2) ? (-1) : 0;
            if (num != num2)
            {
                return num - num2;
            }
            Arc arc = (state1._outArcs != null && !state1._outArcs.IsEmpty) ? state1._outArcs.First : null;
            Arc arc2 = (state2._outArcs != null && !state2._outArcs.IsEmpty) ? state2._outArcs.First : null;
            int num3 = ((arc != null) ? (((arc.RuleRef != null) ? 16777216 : 0) + arc.WordId) : state1._iSerialize) - ((arc2 != null) ? (((arc2.RuleRef != null) ? 16777216 : 0) + arc2.WordId) : state2._iSerialize);
            return (num3 != 0) ? num3 : (state1._iSerialize - state2._iSerialize);
        }
    }
}