﻿#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class DateTimeTickThousandYear : DateTimeTickUnitBase
    {
        public DateTimeTickThousandYear(CultureInfo culture, int maxTickCount, int? manualSpacing) : base(culture, maxTickCount, manualSpacing)
        {
            kind = DateTimeUnit.ThousandYear;
            if (manualSpacing == null)
            {
                deltas = new int[] { 1, 2, 5 };
            }
        }

        protected override DateTime Floor(DateTime value)
        {
            return new DateTime(value.Year - (value.Year % 1000), 1, 1);
        }

        protected override DateTime Increment(DateTime value, int delta)
        {
            return value.AddYears(delta * 1000);
        }

        protected override string GetTickLabel(DateTime value)
        {
            var dt = new DateTime(value.Year, 1, 1);
            string localizedLabel = dt.ToString("yyyy", culture); // year only
            return $"{localizedLabel}\n ";
        }
    }
}
