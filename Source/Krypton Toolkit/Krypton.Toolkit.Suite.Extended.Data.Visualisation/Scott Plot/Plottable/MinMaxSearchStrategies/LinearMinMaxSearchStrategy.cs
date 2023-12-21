#region MIT License
/*
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

using System.Linq.Expressions;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class LinearMinMaxSearchStrategy<T> : IMinMaxSearchStrategy<T> where T : struct, IComparable
    {
        private T[] _sourceArray;
        public virtual T[] SourceArray
        {
            get => _sourceArray;
            set => _sourceArray = value;
        }

        // precompiled lambda expressions for fast math on generic
        private static Func<T, T, bool> _lessThanExp;
        private static Func<T, T, bool> _greaterThanExp;
        private void InitExp()
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), "a");
            ParameterExpression paramB = Expression.Parameter(typeof(T), "b");
            // add the parameters together
            BinaryExpression bodyLessThan = Expression.LessThan(paramA, paramB);
            BinaryExpression bodyGreaterThan = Expression.GreaterThan(paramA, paramB);
            // compile it
            _lessThanExp = Expression.Lambda<Func<T, T, bool>>(bodyLessThan, paramA, paramB).Compile();
            _greaterThanExp = Expression.Lambda<Func<T, T, bool>>(bodyGreaterThan, paramA, paramB).Compile();
        }

        public LinearMinMaxSearchStrategy()
        {
            InitExp();
        }

        public virtual void MinMaxRangeQuery(int l, int r, out double lowestValue, out double highestValue)
        {
            T lowestValueT = _sourceArray[l];
            T highestValueT = _sourceArray[l];
            for (int i = l; i <= r; i++)
            {
                if (_lessThanExp(_sourceArray[i], lowestValueT))
                {
                    lowestValueT = _sourceArray[i];
                }

                if (_greaterThanExp(_sourceArray[i], highestValueT))
                {
                    highestValueT = _sourceArray[i];
                }
            }
            lowestValue = Convert.ToDouble(lowestValueT);
            highestValue = Convert.ToDouble(highestValueT);
        }

        public virtual double SourceElement(int index)
        {
            return Convert.ToDouble(_sourceArray[index]);
        }

        public void updateElement(int index, T newValue)
        {
            _sourceArray[index] = newValue;
        }

        public void updateRange(int from, int to, T[] newData, int fromData = 0)
        {
            // TODO: Turn this into a foreach loop
            for (int i = from; i < to; i++)
            {
                _sourceArray[i] = newData[i - from + fromData];
            }
        }
    }
}
