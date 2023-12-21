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

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class DateTimeTickUnitBase : IDateTimeUnit
    {
        // base class implements Seconds Unit
        protected DateTimeUnit kind = DateTimeUnit.Second;
        protected CultureInfo culture;
        protected int[] deltas = new int[] { 1, 2, 5, 10, 15, 30 };
        protected int maxTickCount;

        public DateTimeTickUnitBase(CultureInfo culture, int maxTickCount, int? manualSpacing)
        {
            this.culture = culture;
            this.maxTickCount = maxTickCount;
            if (manualSpacing.HasValue)
            {
                deltas = new int[] { manualSpacing.Value };
            }
        }

        protected virtual DateTime Floor(DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0);
        }

        protected virtual DateTime Increment(DateTime value, int delta)
        {
            return value.AddSeconds(delta);
        }

        protected virtual string GetTickLabel(DateTime value)
        {
            string date = value.ToString("d", culture); // short date
            string time = value.ToString("T", culture); // long time
            return $"{date}\n{time}";
        }

        public (double[] Ticks, string[] Labels) GetTicksAndLabels(DateTime from, DateTime to, string format)
        {
            DateTime[] ticks = GetTicks(from, to, deltas, maxTickCount);
            string[] labels = (format is null) ?
                ticks.Select(t => GetTickLabel(t)).ToArray() :
                ticks.Select(t => t.ToString(format, culture)).ToArray();
            return (ticks.Select(t => t.ToOADate()).ToArray(), labels);
        }

        protected DateTime[] GetTicks(DateTime from, DateTime to, int[] deltas, int maxTickCount)
        {
            DateTime[] result = new DateTime[] { };
            foreach (var delta in deltas)
            {
                result = GetTicks(from, to, delta);
                if (result.Length <= maxTickCount)
                {
                    return result;
                }
            }
            return result;
        }

        protected virtual DateTime[] GetTicks(DateTime from, DateTime to, int delta)
        {
            var dates = new List<DateTime>();
            DateTime dt = Floor(from);
            while (dt <= to)
            {
                if (dt >= from)
                {
                    dates.Add(dt);
                }

                try
                {
                    dt = Increment(dt, delta);
                }
                catch
                {
                    break; // our date is larger than possible
                }
            }
            return dates.ToArray();
        }
    }
}
