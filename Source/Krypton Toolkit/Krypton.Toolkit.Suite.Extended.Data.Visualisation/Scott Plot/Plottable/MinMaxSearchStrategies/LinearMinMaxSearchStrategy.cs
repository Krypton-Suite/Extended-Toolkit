#region MIT License
/*
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

using System.Linq.Expressions;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class LinearMinMaxSearchStrategy<T> : IMinMaxSearchStrategy<T> where T : struct, IComparable
    {
        private T[] sourceArray;
        public virtual T[] SourceArray
        {
            get => sourceArray;
            set => sourceArray = value;
        }

        // precompiled lambda expressions for fast math on generic
        private static Func<T, T, bool> LessThanExp;
        private static Func<T, T, bool> GreaterThanExp;
        private void InitExp()
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), "a");
            ParameterExpression paramB = Expression.Parameter(typeof(T), "b");
            // add the parameters together
            BinaryExpression bodyLessThan = Expression.LessThan(paramA, paramB);
            BinaryExpression bodyGreaterThan = Expression.GreaterThan(paramA, paramB);
            // compile it
            LessThanExp = Expression.Lambda<Func<T, T, bool>>(bodyLessThan, paramA, paramB).Compile();
            GreaterThanExp = Expression.Lambda<Func<T, T, bool>>(bodyGreaterThan, paramA, paramB).Compile();
        }

        public LinearMinMaxSearchStrategy()
        {
            InitExp();
        }

        public virtual void MinMaxRangeQuery(int l, int r, out double lowestValue, out double highestValue)
        {
            T lowestValueT = sourceArray[l];
            T highestValueT = sourceArray[l];
            for (int i = l; i <= r; i++)
            {
                if (LessThanExp(sourceArray[i], lowestValueT))
                {
                    lowestValueT = sourceArray[i];
                }

                if (GreaterThanExp(sourceArray[i], highestValueT))
                {
                    highestValueT = sourceArray[i];
                }
            }
            lowestValue = Convert.ToDouble(lowestValueT);
            highestValue = Convert.ToDouble(highestValueT);
        }

        public virtual double SourceElement(int index)
        {
            return Convert.ToDouble(sourceArray[index]);
        }

        public void updateElement(int index, T newValue)
        {
            sourceArray[index] = newValue;
        }

        public void updateRange(int from, int to, T[] newData, int fromData = 0)
        {
            // TODO: Turn this into a foreach loop
            for (int i = from; i < to; i++)
            {
                sourceArray[i] = newData[i - from + fromData];
            }
        }
    }
}
