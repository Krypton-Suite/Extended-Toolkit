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
    internal class OneOf : ParseElementCollection, IOneOf, IElement
    {
        private State _startState;

        private State _endState;

        public OneOf(Rule rule, Backend backend)
            : base(backend, rule)
        {
            _startState = _backend.CreateNewState(rule);
            _endState = _backend.CreateNewState(rule);
            _startArc = _backend.EpsilonTransition(1f);
            _startArc.End = _startState;
            _endArc = _backend.EpsilonTransition(1f);
            _endArc.Start = _endState;
        }

        void IElement.PostParse(IElement parentElement)
        {
            if (_startArc.End.OutArcs.IsEmpty)
            {
                XmlParser.ThrowSrgsException(SRID.EmptyOneOf);
            }
            _startArc = ParseElementCollection.TrimStart(_startArc, _backend);
            _endArc = ParseElementCollection.TrimEnd(_endArc, _backend);
            PostParse((ParseElementCollection)parentElement);
        }

        internal override void AddArc(Arc start, Arc end)
        {
            start = ParseElementCollection.TrimStart(start, _backend);
            end = ParseElementCollection.TrimEnd(end, _backend);
            State start2 = end.Start;
            State end2 = start.End;
            if ((start.IsEpsilonTransition & start.IsPropertylessTransition) && end2 != null && end2.InArcs.IsEmpty)
            {
                start.End = null;
                _backend.MoveOutputTransitionsAndDeleteState(end2, _startState);
            }
            else
            {
                start.Start = _startState;
            }
            if ((end.IsEpsilonTransition & end.IsPropertylessTransition) && start2 != null && start2.OutArcs.IsEmpty)
            {
                end.Start = null;
                _backend.MoveInputTransitionsAndDeleteState(start2, _endState);
            }
            else
            {
                end.End = _endState;
            }
        }
    }
}