#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal abstract class ParseElementCollection : ParseElement
    {
        internal enum Position
        {
            Before,
            After
        }

        protected Backend _backend;

        protected Arc _startArc;

        protected Arc _endArc;

        protected ParseElementCollection(Backend backend, Rule rule)
            : base(rule)
        {
            _backend = backend;
        }

        internal void AddSemanticInterpretationTag(CfgGrammar.CfgProperty propertyInfo)
        {
            if (_endArc != null && _endArc.RuleRef != null)
            {
                Arc arc = _backend.EpsilonTransition(1f);
                _backend.AddSemanticInterpretationTag(arc, propertyInfo);
                State end = arc.Start = _backend.CreateNewState(_rule);
                _endArc.End = end;
                _endArc = arc;
            }
            else
            {
                if (_startArc == null)
                {
                    _startArc = (_endArc = _backend.EpsilonTransition(1f));
                }
                _backend.AddSemanticInterpretationTag(_endArc, propertyInfo);
            }
        }

        internal void AddSementicPropertyTag(CfgGrammar.CfgProperty propertyInfo)
        {
            if (_startArc == null)
            {
                _startArc = (_endArc = _backend.EpsilonTransition(1f));
            }
            _backend.AddPropertyTag(_startArc, _endArc, propertyInfo);
        }

        protected Arc InsertState(Arc arc, float weight, Position position)
        {
            if (arc.IsEpsilonTransition)
            {
                if (position == Position.Before && arc.End != null && arc.End.InArcs.CountIsOne && Graph.MoveSemanticTagRight(arc))
                {
                    return arc;
                }
                if (position == Position.After && arc.Start != null && arc.Start.OutArcs.CountIsOne && Graph.MoveSemanticTagLeft(arc))
                {
                    return arc;
                }
            }
            Arc arc2 = _backend.EpsilonTransition(weight);
            State state = _backend.CreateNewState(_rule);
            if (position == Position.Before)
            {
                arc2.End = state;
                arc.Start = state;
            }
            else
            {
                arc.End = state;
                arc2.Start = state;
            }
            return arc2;
        }

        protected static Arc TrimStart(Arc start, Backend backend)
        {
            Arc arc = start;
            if (start.End != null)
            {
                State end = arc.End;
                while (arc.IsEpsilonTransition && end != null && Graph.MoveSemanticTagRight(arc) && end.InArcs.CountIsOne && end.OutArcs.CountIsOne)
                {
                    arc.End = null;
                    arc = end.OutArcs.First;
                    arc.Start = null;
                    backend.DeleteState(end);
                    end = arc.End;
                }
            }
            return arc;
        }

        protected static Arc TrimEnd(Arc end, Backend backend)
        {
            Arc arc = end;
            if (arc != null)
            {
                State start = arc.Start;
                while (arc.IsEpsilonTransition && start != null && Graph.MoveSemanticTagLeft(arc) && start.InArcs.CountIsOne && start.OutArcs.CountIsOne)
                {
                    arc.Start = null;
                    arc = start.InArcs.First;
                    arc.End = null;
                    backend.DeleteState(start);
                    start = arc.Start;
                }
            }
            return arc;
        }

        protected void PostParse(ParseElementCollection parent)
        {
            if (_startArc != null)
            {
                parent.AddArc(_startArc, _endArc);
            }
        }

        internal void AddArc(Arc arc)
        {
            AddArc(arc, arc);
        }

        internal virtual void AddArc(Arc start, Arc end)
        {
            State state = null;
            if (_startArc == null)
            {
                _startArc = start;
                _endArc = end;
                return;
            }
            bool flag = false;
            if (_endArc.IsEpsilonTransition && start.IsEpsilonTransition)
            {
                start = TrimStart(start, _backend);
                if (start.IsEpsilonTransition)
                {
                    _endArc = TrimEnd(_endArc, _backend);
                    if (_endArc.IsEpsilonTransition)
                    {
                        State start2 = _endArc.Start;
                        State end2 = start.End;
                        flag = true;
                        if (start2 == null)
                        {
                            Arc.CopyTags(_endArc, start, Direction.Right);
                            _startArc = start;
                        }
                        else if (end2 == null)
                        {
                            Arc.CopyTags(start, _endArc, Direction.Left);
                            end = _endArc;
                        }
                        else if (_endArc.IsPropertylessTransition && start.IsPropertylessTransition)
                        {
                            start.End = null;
                            _endArc.Start = null;
                            _backend.MoveInputTransitionsAndDeleteState(start2, end2);
                        }
                        else
                        {
                            Arc.CopyTags(start, _endArc, Direction.Left);
                            start.End = null;
                            _endArc.End = end2;
                        }
                    }
                }
            }
            if (!flag)
            {
                if (_endArc.IsEpsilonTransition && Graph.CanTagsBeMoved(_endArc, start))
                {
                    Arc.CopyTags(_endArc, start, Direction.Right);
                    if (_endArc.Start != null)
                    {
                        state = _endArc.Start;
                        _endArc.Start = null;
                    }
                    if (_endArc == _startArc)
                    {
                        _startArc = start;
                    }
                }
                else if (start.IsEpsilonTransition && Graph.CanTagsBeMoved(start, _endArc))
                {
                    Arc.CopyTags(start, _endArc, Direction.Left);
                    if (start.End != null)
                    {
                        state = start.End;
                        start.End = null;
                        _endArc.End = state;
                        state = null;
                    }
                    if (start == end)
                    {
                        end = _endArc;
                    }
                }
                else
                {
                    state = _backend.CreateNewState(_rule);
                    _endArc.End = state;
                }
                if (state != null)
                {
                    start.Start = state;
                }
            }
            _endArc = end;
        }
    }
}