#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal class Graph : IEnumerable<State>, IEnumerable
    {
        private State _startState;

        private State _curState;

        internal void Add(State state)
        {
            state.Init();
            if (_startState == null)
            {
                _curState = (_startState = state);
            }
            else
            {
                _curState = _curState.Add(state);
            }
        }

        internal void Remove(State state)
        {
            if (state == _startState)
            {
                _startState = state.Next;
            }
            if (state == _curState)
            {
                _curState = state.Prev;
            }
            state.Remove();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (State item = _startState; item != null; item = item.Next)
            {
                yield return item;
            }
        }

        IEnumerator<State> IEnumerable<State>.GetEnumerator()
        {
            for (State item = _startState; item != null; item = item.Next)
            {
                yield return item;
            }
        }

        internal State CreateNewState(Rule rule)
        {
            uint nextHandle = CfgGrammar.NextHandle;
            State state = new State(rule, nextHandle);
            Add(state);
            return state;
        }

        internal void DeleteState(State state)
        {
            Remove(state);
        }

        internal void Optimize()
        {
            foreach (State item in (IEnumerable<State>)this)
            {
                NormalizeTransitionWeights(item);
            }
            MergeDuplicateTransitions();
        }

        internal void MoveInputTransitionsAndDeleteState(State srcState, State destState)
        {
            List<Arc> list = srcState.InArcs.ToList();
            foreach (Arc item in list)
            {
                item.End = destState;
            }
            if (srcState.Rule._firstState == srcState)
            {
                srcState.Rule._firstState = destState;
            }
            DeleteState(srcState);
        }

        internal void MoveOutputTransitionsAndDeleteState(State srcState, State destState)
        {
            List<Arc> list = srcState.OutArcs.ToList();
            foreach (Arc item in list)
            {
                item.Start = destState;
            }
            DeleteState(srcState);
        }

        private void MergeDuplicateTransitions()
        {
            List<Arc> identicalWords = new List<Arc>();
            foreach (State item in (IEnumerable<State>)this)
            {
                if (item.OutArcs.ContainsMoreThanOneItem)
                {
                    MergeIdenticalTransitions(item.OutArcs, identicalWords);
                }
            }
            Stack<State> mergeStates = new Stack<State>();
            RecursiveMergeDuplicatedOutputTransition(mergeStates);
            RecursiveMergeDuplicatedInputTransition(mergeStates);
        }

        private void RecursiveMergeDuplicatedInputTransition(Stack<State> mergeStates)
        {
            foreach (State item in (IEnumerable<State>)this)
            {
                if (item.InArcs.ContainsMoreThanOneItem)
                {
                    MergeDuplicateInputTransitions(item.InArcs, mergeStates);
                }
            }
            List<Arc> identicalWords = new List<Arc>();
            while (mergeStates.Count > 0)
            {
                State state = mergeStates.Pop();
                if (state.InArcs.ContainsMoreThanOneItem)
                {
                    MergeIdenticalTransitions(state.InArcs, identicalWords);
                    MergeDuplicateInputTransitions(state.InArcs, mergeStates);
                }
            }
        }

        private void RecursiveMergeDuplicatedOutputTransition(Stack<State> mergeStates)
        {
            foreach (State item in (IEnumerable<State>)this)
            {
                if (item.OutArcs.ContainsMoreThanOneItem)
                {
                    MergeDuplicateOutputTransitions(item.OutArcs, mergeStates);
                }
            }
            List<Arc> identicalWords = new List<Arc>();
            while (mergeStates.Count > 0)
            {
                State state = mergeStates.Pop();
                if (state.OutArcs.ContainsMoreThanOneItem)
                {
                    MergeIdenticalTransitions(state.OutArcs, identicalWords);
                    MergeDuplicateOutputTransitions(state.OutArcs, mergeStates);
                }
            }
        }

        private void MergeDuplicateInputTransitions(ArcList arcs, Stack<State> mergeStates)
        {
            List<Arc> list = null;
            Arc arc = null;
            bool flag = false;
            foreach (Arc arc5 in arcs)
            {
                bool flag2 = arc5.Start == null || !arc5.Start.OutArcs.CountIsOne;
                if (arc != null && Arc.CompareContent(arc5, arc) == 0)
                {
                    if (!flag2)
                    {
                        if (list == null)
                        {
                            list = new List<Arc>();
                        }
                        if (!flag)
                        {
                            list.Add(arc);
                            flag = true;
                        }
                        list.Add(arc5);
                    }
                }
                else
                {
                    arc = (flag2 ? null : arc5);
                    flag = false;
                }
            }
            if (list != null)
            {
                list.Sort(Arc.CompareForDuplicateInputTransitions);
                arc = null;
                Arc arc3 = null;
                State state = null;
                bool flag3 = false;
                foreach (Arc item in list)
                {
                    if (arc == null || Arc.CompareContent(item, arc) != 0)
                    {
                        arc = item;
                        if (flag3)
                        {
                            AddToMergeStateList(mergeStates, state);
                        }
                        arc3 = null;
                        state = null;
                        flag3 = false;
                    }
                    Arc arc4 = item;
                    State start = arc4.Start;
                    if (MoveSemanticTagLeft(arc4))
                    {
                        if (arc3 != null)
                        {
                            if (!flag3)
                            {
                                foreach (Arc outArc in state.OutArcs)
                                {
                                    outArc.Weight *= arc3.Weight;
                                }
                                flag3 = true;
                            }
                            foreach (Arc outArc2 in start.OutArcs)
                            {
                                outArc2.Weight *= arc4.Weight;
                            }
                            arc4.Weight += arc3.Weight;
                            Arc.CopyTags(arc3, arc4, Direction.Left);
                            DeleteTransition(arc3);
                            MoveInputTransitionsAndDeleteState(state, start);
                        }
                        arc3 = arc4;
                        state = start;
                    }
                }
                if (flag3)
                {
                    AddToMergeStateList(mergeStates, state);
                }
            }
        }

        private void MergeDuplicateOutputTransitions(ArcList arcs, Stack<State> mergeStates)
        {
            List<Arc> list = null;
            Arc arc = null;
            bool flag = false;
            foreach (Arc arc5 in arcs)
            {
                bool flag2 = arc5.End == null || !arc5.End.InArcs.CountIsOne;
                if (arc != null && Arc.CompareContent(arc5, arc) == 0)
                {
                    if (!flag2)
                    {
                        if (list == null)
                        {
                            list = new List<Arc>();
                        }
                        if (!flag)
                        {
                            list.Add(arc);
                            flag = true;
                        }
                        list.Add(arc5);
                    }
                }
                else
                {
                    arc = (flag2 ? null : arc5);
                    flag = false;
                }
            }
            if (list != null)
            {
                list.Sort(Arc.CompareForDuplicateOutputTransitions);
                arc = null;
                Arc arc3 = null;
                State state = null;
                bool flag3 = false;
                foreach (Arc item in list)
                {
                    if (arc == null || Arc.CompareContent(item, arc) != 0)
                    {
                        arc = item;
                        if (flag3)
                        {
                            AddToMergeStateList(mergeStates, state);
                        }
                        arc3 = null;
                        state = null;
                        flag3 = false;
                    }
                    Arc arc4 = item;
                    State end = arc4.End;
                    if (end != end.Rule._firstState && MoveSemanticTagRight(arc4))
                    {
                        if (arc3 != null)
                        {
                            if (!flag3)
                            {
                                foreach (Arc outArc in state.OutArcs)
                                {
                                    outArc.Weight *= arc3.Weight;
                                }
                                flag3 = true;
                            }
                            foreach (Arc outArc2 in end.OutArcs)
                            {
                                outArc2.Weight *= arc4.Weight;
                            }
                            arc4.Weight += arc3.Weight;
                            Arc.CopyTags(arc3, arc4, Direction.Right);
                            DeleteTransition(arc3);
                            MoveOutputTransitionsAndDeleteState(state, end);
                        }
                        arc3 = arc4;
                        state = end;
                    }
                }
                if (flag3)
                {
                    AddToMergeStateList(mergeStates, state);
                }
            }
        }

        private static void AddToMergeStateList(Stack<State> mergeStates, State commonEndState)
        {
            NormalizeTransitionWeights(commonEndState);
            if (!mergeStates.Contains(commonEndState))
            {
                mergeStates.Push(commonEndState);
            }
        }

        internal static bool MoveSemanticTagLeft(Arc arc)
        {
            State start = arc.Start;
            Arc first = start.InArcs.First;
            if (start.InArcs.CountIsOne && start.OutArcs.CountIsOne && CanTagsBeMoved(first, arc))
            {
                Arc.CopyTags(arc, first, Direction.Left);
                return true;
            }
            return arc.IsPropertylessTransition;
        }

        internal static bool MoveSemanticTagRight(Arc arc)
        {
            State end = arc.End;
            Arc first = end.OutArcs.First;
            if (end.InArcs.CountIsOne && end.OutArcs.CountIsOne && CanTagsBeMoved(arc, first))
            {
                Arc.CopyTags(arc, first, Direction.Right);
                return true;
            }
            return arc.IsPropertylessTransition;
        }

        internal static bool CanTagsBeMoved(Arc start, Arc end)
        {
            if (start.RuleRef == null && end.RuleRef == null)
            {
                return end.SpecialTransitionIndex == 0;
            }
            return false;
        }

        private static void DeleteTransition(Arc arc)
        {
            State state3 = arc.Start = (arc.End = null);
        }

        private static void MergeIdenticalTransitions(ArcList arcs, List<Arc> identicalWords)
        {
            List<List<Arc>> list = null;
            Arc arc = arcs.First;
            foreach (Arc arc2 in arcs)
            {
                if (Arc.CompareContent(arc, arc2) != 0)
                {
                    if (identicalWords.Count >= 2)
                    {
                        identicalWords.Sort(Arc.CompareIdenticalTransitions);
                        if (list == null)
                        {
                            list = new List<List<Arc>>();
                        }
                        list.Add(new List<Arc>(identicalWords));
                    }
                    identicalWords.Clear();
                }
                arc = arc2;
                identicalWords.Add(arc2);
            }
            if (identicalWords.Count >= 2)
            {
                MergeIdenticalTransitions(identicalWords);
            }
            identicalWords.Clear();
            if (list != null)
            {
                foreach (List<Arc> item in list)
                {
                    MergeIdenticalTransitions(item);
                }
            }
        }

        private static void MergeIdenticalTransitions(List<Arc> identicalWords)
        {
            Collection<Arc> collection = null;
            Arc arc = null;
            foreach (Arc identicalWord in identicalWords)
            {
                if (arc != null && Arc.CompareIdenticalTransitions(arc, identicalWord) == 0)
                {
                    identicalWord.Weight += arc.Weight;
                    arc.ClearTags();
                    if (collection == null)
                    {
                        collection = new Collection<Arc>();
                    }
                    collection.Add(arc);
                }
                arc = identicalWord;
            }
            if (collection != null)
            {
                foreach (Arc item in collection)
                {
                    DeleteTransition(item);
                }
            }
        }

        private static void NormalizeTransitionWeights(State state)
        {
            float num = 0f;
            foreach (Arc outArc in state.OutArcs)
            {
                num += outArc.Weight;
            }
            if (!num.Equals(0f) && !num.Equals(1f))
            {
                float num2 = 1f / num;
                foreach (Arc outArc2 in state.OutArcs)
                {
                    outArc2.Weight *= num2;
                }
            }
        }
    }
}