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
    /// <summary>
    /// This class holds open/high/low/close (OHLC) price data over a time range.
    /// </summary>
    public class OHLC
    {
        public double Open;
        public double High;
        public double Low;
        public double Close;
        public DateTime DateTime;
        public TimeSpan TimeSpan;

        private bool IsNanOrInfinity(double val) => double.IsInfinity(val) || double.IsNaN(val);

        public bool IsValid
        {
            get
            {
                if (IsNanOrInfinity(Open))
                {
                    return false;
                }

                if (IsNanOrInfinity(High))
                {
                    return false;
                }

                if (IsNanOrInfinity(Low))
                {
                    return false;
                }

                if (IsNanOrInfinity(Close))
                {
                    return false;
                }

                return true;
            }
        }

        public override string ToString() =>
            $"OHLC: open={Open}, high={High}, low={Low}, close={Close}, start={DateTime}, span={TimeSpan}";

        /// <summary>
        /// OHLC price over a specific period of time
        /// </summary>
        /// <param name="open">opening price</param>
        /// <param name="high">maximum price</param>
        /// <param name="low">minimum price</param>
        /// <param name="close">closing price</param>
        /// <param name="timeStart">open time</param>
        /// <param name="timeSpan">width of the OHLC</param>
        public OHLC(double open, double high, double low, double close, DateTime timeStart, TimeSpan timeSpan)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
            DateTime = timeStart;
            TimeSpan = timeSpan;
        }

        /// <summary>
        /// OHLC price over a specific period of time
        /// </summary>
        /// <param name="open">opening price</param>
        /// <param name="high">maximum price</param>
        /// <param name="low">minimum price</param>
        /// <param name="close">closing price</param>
        /// <param name="timeStart">open time (DateTime.ToOADate() units)</param>
        /// <param name="timeSpan">width of the OHLC in days</param>
        public OHLC(double open, double high, double low, double close, double timeStart, double timeSpan = 1)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
            DateTime = DateTime.FromOADate(timeStart);
            TimeSpan = TimeSpan.FromDays(timeSpan);
        }
    }
}
