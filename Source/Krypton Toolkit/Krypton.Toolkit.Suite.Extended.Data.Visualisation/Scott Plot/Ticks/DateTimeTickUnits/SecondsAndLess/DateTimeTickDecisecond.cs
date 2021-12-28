#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    class DateTimeTickDecisecond : DateTimeTickUnitBase
    {
        public DateTimeTickDecisecond(CultureInfo culture, int maxTickCount, int? manualSpacing) : base(culture, maxTickCount, manualSpacing)
        {
            kind = DateTimeUnit.Decisecond;
            if (manualSpacing == null)
                deltas = new int[] { 1, 2, 5 };
        }

        protected override DateTime Floor(DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
        }

        protected override DateTime Increment(DateTime value, int delta)
        {
            return value.AddMilliseconds(delta * 100);
        }

        protected override string GetTickLabel(DateTime value)
        {
            string date = value.ToString("d", culture); // short date
            string time = value.ToString("hh:mm:ss.f", culture); // long time
            return $"{date}\n{time}";
        }
    }
}
