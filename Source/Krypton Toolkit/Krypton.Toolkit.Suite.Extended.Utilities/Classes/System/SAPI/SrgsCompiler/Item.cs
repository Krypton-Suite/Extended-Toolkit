﻿#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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
    internal sealed class Item : ParseElementCollection, IItem, IElement
    {
        private float _repeatProbability = 0.5f;

        private int _minRepeat = -1;

        private int _maxRepeat = -1;

        private const int NotSet = -1;

        internal Item(Backend backend, Rule rule, int minRepeat, int maxRepeat, float repeatProbability, float weigth)
            : base(backend, rule)
        {
            _minRepeat = minRepeat;
            _maxRepeat = maxRepeat;
            _repeatProbability = repeatProbability;
        }

        void IElement.PostParse(IElement parentElement)
        {
            if (_maxRepeat != _minRepeat && _startArc != null && _startArc == _endArc && _endArc.IsEpsilonTransition && !_endArc.IsPropertylessTransition)
            {
                XmlParser.ThrowSrgsException(SRID.InvalidTagInAnEmptyItem);
            }
            if (_startArc == null || _maxRepeat == 0)
            {
                if (_maxRepeat == 0 && _startArc != null && _startArc.End != null)
                {
                    State end = _startArc.End;
                    _startArc.End = null;
                    _backend.DeleteSubGraph(end);
                }
                _startArc = (_endArc = _backend.EpsilonTransition(_repeatProbability));
            }
            else if (_minRepeat != 1 || _maxRepeat != 1)
            {
                _startArc = InsertState(_startArc, _repeatProbability, Position.Before);
                State end2 = _startArc.End;
                if (_maxRepeat == int.MaxValue && _minRepeat == 1)
                {
                    _endArc = InsertState(_endArc, 1f, Position.After);
                    AddEpsilonTransition(_endArc.Start, end2, 1f - _repeatProbability);
                }
                else
                {
                    State srcFromState = end2;
                    for (uint num = 1u; num < _maxRepeat && num < 255; num++)
                    {
                        State state = _backend.CreateNewState(_endArc.Start.Rule);
                        State state2 = _backend.CloneSubGraph(srcFromState, _endArc.Start, state);
                        _endArc.End = state;
                        _endArc = state2.OutArcs.First;
                        if (_maxRepeat == int.MaxValue)
                        {
                            if (num == _minRepeat - 1)
                            {
                                _endArc = InsertState(_endArc, 1f, Position.After);
                                AddEpsilonTransition(_endArc.Start, state, 1f - _repeatProbability);
                                break;
                            }
                        }
                        else if (num <= _maxRepeat - _minRepeat)
                        {
                            AddEpsilonTransition(end2, state, 1f - _repeatProbability);
                        }
                        srcFromState = state;
                    }
                }
                if (_minRepeat == 0 && (_startArc != _endArc || !_startArc.IsEpsilonTransition))
                {
                    if (!_endArc.IsEpsilonTransition || _endArc.SemanticTagCount > 0)
                    {
                        _endArc = InsertState(_endArc, 1f, Position.After);
                    }
                    AddEpsilonTransition(end2, _endArc.Start, 1f - _repeatProbability);
                }
                _startArc = ParseElementCollection.TrimStart(_startArc, _backend);
            }
            PostParse((ParseElementCollection)parentElement);
        }

        private void AddEpsilonTransition(State start, State end, float weigth)
        {
            Arc arc = _backend.EpsilonTransition(weigth);
            arc.Start = start;
            arc.End = end;
        }
    }
}