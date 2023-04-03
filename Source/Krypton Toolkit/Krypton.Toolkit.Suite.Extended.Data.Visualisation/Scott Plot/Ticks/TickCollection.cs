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
    public class TickCollection
    {
        // This class creates pretty tick labels (with offset and exponent) uses graph settings
        // to inspect the tick font and ensure tick labels will not overlap. 
        // It also respects manually defined tick spacing settings set via plt.Grid().

        /// <summary>
        /// Label to show in the corner when using multiplier or offset notation
        /// </summary>
        public string CornerLabel { get; private set; }

        /// <summary>
        /// Measured size of the largest tick label
        /// </summary>
        public float LargestLabelWidth { get; private set; } = 15;

        /// <summary>
        /// Measured size of the largest tick label
        /// </summary>
        public float LargestLabelHeight { get; private set; } = 12;

        /// <summary>
        /// Controls how to translate positions to strings
        /// </summary>
        public TickLabelFormatOptions LabelFormat = TickLabelFormatOptions.Numeric;

        /// <summary>
        /// If True, these ticks are placed along a vertical (Y) axis.
        /// This is used to determine whether tick density should be based on tick label width or height.
        /// </summary>
        public AxisOrientation Orientation;

        /// <summary>
        /// If True, the sign of numeric tick labels will be inverted.
        /// This is used to give the appearance of descending ticks.
        /// </summary>
        public bool LabelUsingInvertedSign;

        /// <summary>
        /// Define how minor ticks are distributed (evenly vs. log scale)
        /// </summary>
        public MinorTickDistribution MinorTickDistribution;

        public string numericFormatString;
        public string dateTimeFormatString;

        /// <summary>
        /// If defined, this function will be used to generate tick labels from positions
        /// </summary>
        public Func<double, string> ManualTickFormatter = null;

        public int radix = 10;
        public string prefix = null;

        public double manualSpacingX = 0;
        public double manualSpacingY = 0;
        public DateTimeUnit? manualDateTimeSpacingUnitX = null;
        public DateTimeUnit? manualDateTimeSpacingUnitY = null;

        public CultureInfo Culture = CultureInfo.DefaultThreadCurrentCulture;

        public bool useMultiplierNotation = false;
        public bool useOffsetNotation = false;
        public bool useExponentialNotation = true;

        /// <summary>
        /// Optimally packed tick labels have a density 1.0 and lower densities space ticks farther apart.
        /// </summary>
        public float TickDensity = 1.0f;

        /// <summary>
        /// Defines the minimum distance (in coordinate units) for major ticks.
        /// </summary>
        public double MinimumTickSpacing = 0;

        /// <summary>
        /// If True, non-integer tick positions will not be used.
        /// This may be desired for log10-scaled axes so tick marks are even powers of 10.
        /// </summary>
        public bool IntegerPositionsOnly = false;

        public void Recalculate(PlotDimensions dims, Font tickFont)
        {
            if (TickCollectionStorage.manualTickPositions is null)
            {
                // first pass uses forced density with manual label sizes to consistently approximate labels
                if (LabelFormat == TickLabelFormatOptions.DateTime)
                {
                    RecalculatePositionsAutomaticDatetime(dims, 20, 24, (int)(10 * TickDensity));
                }
                else
                {
                    RecalculatePositionsAutomaticNumeric(dims, 15, 12, (int)(10 * TickDensity));
                }

                // second pass calculates density using measured labels produced by the first pass
                (LargestLabelWidth, LargestLabelHeight) = MaxLabelSize(tickFont);
                if (LabelFormat == TickLabelFormatOptions.DateTime)
                {
                    RecalculatePositionsAutomaticDatetime(dims, LargestLabelWidth, LargestLabelHeight, null);
                }
                else
                {
                    RecalculatePositionsAutomaticNumeric(dims, LargestLabelWidth, LargestLabelHeight, null);
                }
            }
            else
            {
                double min = Orientation == AxisOrientation.Vertical ? dims.YMin : dims.XMin;
                double max = Orientation == AxisOrientation.Vertical ? dims.YMax : dims.XMax;

                var visibleIndexes = Enumerable.Range(0, TickCollectionStorage.manualTickPositions.Count())
                    .Where(i => TickCollectionStorage.manualTickPositions[i] >= min)
                    .Where(i => TickCollectionStorage.manualTickPositions[i] <= max);

                TickCollectionStorage.tickPositionsMajor = visibleIndexes.Select(x => TickCollectionStorage.manualTickPositions[x]).ToArray();
                TickCollectionStorage.tickPositionsMinor = null;
                TickCollectionStorage.tickLabels = visibleIndexes.Select(x => TickCollectionStorage.manualTickLabels[x]).ToArray();
                CornerLabel = null;
                (LargestLabelWidth, LargestLabelHeight) = MaxLabelSize(tickFont);
            }
        }

        public void SetCulture(
            string shortDatePattern = null,
            string decimalSeparator = null,
            string numberGroupSeparator = null,
            int? decimalDigits = null,
            int? numberNegativePattern = null,
#pragma warning disable CS8632
            int[]? numberGroupSizes = null
#pragma warning restore CS8632
        )
        {
            // Culture may be null if the thread culture is the same is the system culture.
            // If it is null, assigning it to a clone of the current culture solves this and also makes it mutable.
            Culture = Culture ?? (CultureInfo)CultureInfo.CurrentCulture.Clone();
            Culture.DateTimeFormat.ShortDatePattern = shortDatePattern ?? Culture.DateTimeFormat.ShortDatePattern;
            Culture.NumberFormat.NumberDecimalDigits = decimalDigits ?? Culture.NumberFormat.NumberDecimalDigits;
            Culture.NumberFormat.NumberDecimalSeparator = decimalSeparator ?? Culture.NumberFormat.NumberDecimalSeparator;
            Culture.NumberFormat.NumberGroupSeparator = numberGroupSeparator ?? Culture.NumberFormat.NumberGroupSeparator;
            Culture.NumberFormat.NumberGroupSizes = numberGroupSizes ?? Culture.NumberFormat.NumberGroupSizes;
            Culture.NumberFormat.NumberNegativePattern = numberNegativePattern ?? Culture.NumberFormat.NumberNegativePattern;
        }

        private (float width, float height) MaxLabelSize(Font tickFont)
        {
            if (TickCollectionStorage.tickLabels is null || TickCollectionStorage.tickLabels.Length == 0)
            {
                return (0, 0);
            }

            string largestString = "";
            foreach (string s in TickCollectionStorage.tickLabels.Where(x => string.IsNullOrEmpty(x) == false))
            {
                if (s.Length > largestString.Length)
                {
                    largestString = s;
                }
            }

            if (LabelFormat == TickLabelFormatOptions.DateTime)
            {
                // widen largest string based on the longest month name
                foreach (string s in new DateTimeFormatInfo().MonthGenitiveNames)
                {
                    string s2 = $"{s}\n1985";
                    if (s2.Length > largestString.Length)
                    {
                        largestString = s2;
                    }
                }
            }

            var maxLabelSize = GDI.MeasureString(largestString.Trim(), tickFont);
            return (maxLabelSize.Width, maxLabelSize.Height);
        }

        private void RecalculatePositionsAutomaticDatetime(PlotDimensions dims, float labelWidth, float labelHeight, int? forcedTickCount)
        {
            double low, high;
            int tickCount;

            if (MinimumTickSpacing > 0)
            {
                throw new InvalidOperationException("minimum tick spacing does not support DateTime ticks");
            }

            if (Orientation == AxisOrientation.Vertical)
            {
                low = dims.YMin - dims.UnitsPerPxY; // add an extra pixel to capture the edge tick
                high = dims.YMax + dims.UnitsPerPxY; // add an extra pixel to capture the edge tick
                tickCount = (int)(dims.DataHeight / labelHeight * TickDensity);
                tickCount = forcedTickCount ?? tickCount;
            }
            else
            {
                low = dims.XMin - dims.UnitsPerPxX; // add an extra pixel to capture the edge tick
                high = dims.XMax + dims.UnitsPerPxX; // add an extra pixel to capture the edge tick
                tickCount = (int)(dims.DataWidth / labelWidth * TickDensity);
                tickCount = forcedTickCount ?? tickCount;
            }

            if (low < high)
            {
                low = Math.Max(low, new DateTime(0100, 1, 1, 0, 0, 0).ToOADate()); // minimum OADate value
                high = Math.Min(high, DateTime.MaxValue.ToOADate());

                var dtManualUnits = (Orientation == AxisOrientation.Vertical) ? manualDateTimeSpacingUnitY : manualDateTimeSpacingUnitX;
                var dtManualSpacing = (Orientation == AxisOrientation.Vertical) ? manualSpacingY : manualSpacingX;

                try
                {
                    DateTime from = DateTime.FromOADate(low);
                    DateTime to = DateTime.FromOADate(high);

                    var unitFactory = new DateTimeUnitFactory();
                    IDateTimeUnit tickUnit = unitFactory.CreateUnit(from, to, Culture, tickCount, dtManualUnits, (int)dtManualSpacing);
                    (TickCollectionStorage.tickPositionsMajor, TickCollectionStorage.tickLabels) = tickUnit.GetTicksAndLabels(from, to, dateTimeFormatString);
                    TickCollectionStorage.tickLabels = TickCollectionStorage.tickLabels.Select(x => x.Trim()).ToArray();
                }
                catch
                {
                    TickCollectionStorage.tickPositionsMajor = new double[] { }; // far zoom out can produce FromOADate() exception
                }
            }
            else
            {
                TickCollectionStorage.tickPositionsMajor = new double[] { };
            }

            // dont forget to set all the things
            TickCollectionStorage.tickPositionsMinor = null;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            CornerLabel = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        private void RecalculatePositionsAutomaticNumeric(PlotDimensions dims, float labelWidth, float labelHeight, int? forcedTickCount)
        {
            double low, high, tickSpacing;
            int maxTickCount;

            if (Orientation == AxisOrientation.Vertical)
            {
                low = dims.YMin - dims.UnitsPerPxY; // add an extra pixel to capture the edge tick
                high = dims.YMax + dims.UnitsPerPxY; // add an extra pixel to capture the edge tick
                maxTickCount = (int)(dims.DataHeight / labelHeight * TickDensity);
                maxTickCount = forcedTickCount ?? maxTickCount;
                tickSpacing = (manualSpacingY != 0) ? manualSpacingY : GetIdealTickSpacing(low, high, maxTickCount, radix);
                tickSpacing = Math.Max(tickSpacing, MinimumTickSpacing);
            }
            else
            {
                low = dims.XMin - dims.UnitsPerPxX; // add an extra pixel to capture the edge tick
                high = dims.XMax + dims.UnitsPerPxX; // add an extra pixel to capture the edge tick
                maxTickCount = (int)(dims.DataWidth / labelWidth * TickDensity);
                maxTickCount = forcedTickCount ?? maxTickCount;
                tickSpacing = (manualSpacingX != 0) ? manualSpacingX : GetIdealTickSpacing(low, high, maxTickCount, radix);
                tickSpacing = Math.Max(tickSpacing, MinimumTickSpacing);
            }

            // now that tick spacing is known, populate the list of ticks and labels
            double firstTickOffset = low % tickSpacing;
            int tickCount = (int)((high - low) / tickSpacing) + 2;
            tickCount = tickCount > 1000 ? 1000 : tickCount;
            tickCount = tickCount < 1 ? 1 : tickCount;
            TickCollectionStorage.tickPositionsMajor = Enumerable.Range(0, tickCount)
                                           .Select(x => low - firstTickOffset + tickSpacing * x)
                                           .Where(x => low <= x && x <= high)
                                           .ToArray();

            if (TickCollectionStorage.tickPositionsMajor.Length < 2)
            {
                double tickBelow = low - firstTickOffset;
                double firstTick = TickCollectionStorage.tickPositionsMajor.Length > 0 ? TickCollectionStorage.tickPositionsMajor[0] : tickBelow;
                double nextTick = tickBelow + tickSpacing;
                TickCollectionStorage.tickPositionsMajor = new double[] { firstTick, nextTick };
            }

            if (IntegerPositionsOnly)
            {
                int firstTick = (int)TickCollectionStorage.tickPositionsMajor[0];
                TickCollectionStorage.tickPositionsMajor = TickCollectionStorage.tickPositionsMajor.Where(x => x == (int)x).Distinct().ToArray();

                if (TickCollectionStorage.tickPositionsMajor.Length < 2)
                {
                    TickCollectionStorage.tickPositionsMajor = new double[] { firstTick - 1, firstTick, firstTick + 1 };
                }
            }

            (TickCollectionStorage.tickLabels, CornerLabel) = GetPrettyTickLabels(
                TickCollectionStorage.tickPositionsMajor,
                    useMultiplierNotation,
                    useOffsetNotation,
                    useExponentialNotation,
                    invertSign: LabelUsingInvertedSign,
                    culture: Culture
                );

            if (MinorTickDistribution == MinorTickDistribution.Log)
            {
                TickCollectionStorage.tickPositionsMinor = MinorFromMajorLog(TickCollectionStorage.tickPositionsMajor, low, high);
            }
            else
            {
                TickCollectionStorage.tickPositionsMinor = MinorFromMajor(TickCollectionStorage.tickPositionsMajor, 5, low, high);
            }
        }

        public override string ToString()
        {
            string allTickLabels = string.Join(", ", TickCollectionStorage.tickLabels);
            return $"Tick Collection: [{allTickLabels}] {CornerLabel}";
        }

        private static double GetIdealTickSpacing(double low, double high, int maxTickCount, int radix = 10)
        {
            double range = high - low;
            int exponent = (int)Math.Log(range, radix);
            List<double> tickSpacings = new List<double>() { Math.Pow(radix, exponent) };
            tickSpacings.Add(tickSpacings.Last());
            tickSpacings.Add(tickSpacings.Last());

            double[] divBy;
            if (radix == 10)
            {
                divBy = new double[] { 2, 2, 2.5 }; // 10, 5, 2.5, 1
            }
            else if (radix == 16)
            {
                divBy = new double[] { 2, 2, 2, 2 }; // 16, 8, 4, 2, 1
            }
            else
            {
                throw new ArgumentException($"radix {radix} is not supported");
            }

            int divisions = 0;
            int tickCount = 0;
            while ((tickCount < maxTickCount) && (tickSpacings.Count < 1000))
            {
                tickSpacings.Add(tickSpacings.Last() / divBy[divisions++ % divBy.Length]);
                tickCount = (int)(range / tickSpacings.Last());
            }

            return tickSpacings[tickSpacings.Count - 3];
        }

        private string FormatLocal(double value, CultureInfo culture)
        {
            // if a custom format string exists use it
            if (numericFormatString != null)
            {
                return value.ToString(numericFormatString, culture);
            }

            // if the number is round or large, use the numeric format
            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#the-numeric-n-format-specifier
            bool isRoundNumber = ((int)value == value);
            bool isLargeNumber = (Math.Abs(value) > 1000);
            if (isRoundNumber || isLargeNumber)
            {
                return value.ToString("N0", culture);
            }

            // otherwise the number is probably small or very precise to use the general format (with slight rounding)
            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#the-general-g-format-specifier
            return Math.Round(value, 10).ToString("G", culture);
        }

        public (string[], string) GetPrettyTickLabels(
                double[] positions,
                bool useMultiplierNotation,
                bool useOffsetNotation,
                bool useExponentialNotation,
                bool invertSign,
                CultureInfo culture
            )
        {
            // given positions returns nicely-formatted labels (with offset and multiplier)

            string[] labels = new string[positions.Length];
            string cornerLabel = "";

            if (positions.Length == 0)
            {
                return (labels, cornerLabel);
            }

            double range = positions.Last() - positions.First();

            double exponent = (int)(Math.Log10(range));

            double multiplier = 1;
            if (useMultiplierNotation)
            {
                if (Math.Abs(exponent) > 2)
                {
                    multiplier = Math.Pow(10, exponent);
                }
            }

            double offset = 0;
            if (useOffsetNotation)
            {
                offset = positions.First();
                if (Math.Abs(offset / range) < 10)
                {
                    offset = 0;
                }
            }

            for (int i = 0; i < positions.Length; i++)
            {
                double adjustedPosition = (positions[i] - offset) / multiplier;
                if (invertSign)
                {
                    adjustedPosition *= -1;
                }

                labels[i] = ManualTickFormatter is null ? FormatLocal(adjustedPosition, culture) : ManualTickFormatter(adjustedPosition);
                if (labels[i] == "-0")
                {
                    labels[i] = "0";
                }
            }

            if (useExponentialNotation)
            {
                if (multiplier != 1)
                {
                    cornerLabel += $"e{exponent} ";
                }

                if (offset != 0)
                {
                    cornerLabel += Tools.ScientificNotation(offset);
                }
            }
            else
            {
                if (multiplier != 1)
                {
                    cornerLabel += FormatLocal(multiplier, culture);
                }

                if (offset != 0)
                {
                    cornerLabel += $" +{FormatLocal(offset, culture)}";
                }

                cornerLabel = cornerLabel.Replace("+-", "-");
            }

            return (labels, cornerLabel);
        }

#pragma warning disable CS8632
        public double[]? MinorFromMajor(double[] majorTicks, double minorTicksPerMajorTick, double lowerLimit, double upperLimit)
#pragma warning restore CS8632
        {
            if ((majorTicks == null) || (majorTicks.Length < 2))
            {
                return null;
            }

            double majorTickSpacing = majorTicks[1] - majorTicks[0];
            double minorTickSpacing = majorTickSpacing / minorTicksPerMajorTick;

            List<double> majorTicksWithPadding = new List<double>();
            majorTicksWithPadding.Add(majorTicks[0] - majorTickSpacing);
            majorTicksWithPadding.AddRange(majorTicks);

            List<double> minorTicks = new List<double>();
            foreach (var majorTickPosition in majorTicksWithPadding)
            {
                for (int i = 1; i < minorTicksPerMajorTick; i++)
                {
                    double minorTickPosition = majorTickPosition + minorTickSpacing * i;
                    if ((minorTickPosition > lowerLimit) && (minorTickPosition < upperLimit))
                    {
                        minorTicks.Add(minorTickPosition);
                    }
                }
            }

            return minorTicks.ToArray();
        }

        /// <summary>
        /// Return an array of log-spaced minor tick marks for the given range
        /// </summary>
        /// <param name="majorTickPositions">Locations of visible major ticks. Must be evenly spaced.</param>
        /// <param name="min">Do not include minor ticks less than this value.</param>
        /// <param name="max">Do not include minor ticks greater than this value.</param>
        /// <param name="divisions">Number of minor ranges to divide each major range into. (A range is the space between tick marks)</param>
        /// <returns>Array of minor tick positions (empty at positions occupied by major ticks)</returns>
        public double[] MinorFromMajorLog(double[] majorTickPositions, double min, double max, int divisions = 5)
        {
            if ((majorTickPositions is null) || (majorTickPositions.Length < 2))
            {
                // if too few major ticks are visible, don't attempt to render minor ticks
                return null;
            }

            double majorTickSpacing = majorTickPositions[1] - majorTickPositions[0];
            double lowerBound = majorTickPositions.First() - majorTickSpacing;
            double upperBound = majorTickPositions.Last() + majorTickSpacing;

            double[] offsets = Enumerable.Range(1, divisions - 1).Select(x => majorTickSpacing * Math.Log10(x * 10 / divisions)).ToArray();

            List<double> minorTicks = new();
            for (double majorTick = lowerBound; majorTick <= upperBound; majorTick += majorTickSpacing)
            {
                minorTicks.AddRange(offsets.Select(x => majorTick + x));
            }

            return minorTicks.Where(x => x >= min && x <= max).ToArray();
        }

        public static string[] GetDateLabels(double[] ticksOADate, CultureInfo culture)
        {

            TimeSpan dtTickSep;
            string dtFmt = null;

            try
            {
                // TODO: replace this with culture-aware format
                dtTickSep = DateTime.FromOADate(ticksOADate[1]) - DateTime.FromOADate(ticksOADate[0]);
                if (dtTickSep.TotalDays > 365 * 5)
                {
                    dtFmt = "{0:yyyy}";
                }
                else if (dtTickSep.TotalDays > 365)
                {
                    dtFmt = "{0:yyyy-MM}";
                }
                else if (dtTickSep.TotalDays > .5)
                {
                    dtFmt = "{0:yyyy-MM-dd}";
                }
                else if (dtTickSep.TotalMinutes > .5)
                {
                    dtFmt = "{0:yyyy-MM-dd\nH:mm}";
                }
                else
                {
                    dtFmt = "{0:yyyy-MM-dd\nH:mm:ss}";
                }
            }
            catch
            {
            }

            string[] labels = new string[ticksOADate.Length];
            for (int i = 0; i < ticksOADate.Length; i++)
            {
                try
                {
                    DateTime dt = DateTime.FromOADate(ticksOADate[i]);
                    string lbl = string.Format(culture, dtFmt, dt);
                    labels[i] = lbl;
                }
                catch
                {
                    labels[i] = "?";
                }
            }
            return labels;
        }

        private Tick[] GetMajorTicks()
        {
            if (TickCollectionStorage.tickPositionsMajor is null || TickCollectionStorage.tickPositionsMajor.Length == 0)
            {
                return new Tick[] { };
            }

            Tick[] ticks = new Tick[TickCollectionStorage.tickPositionsMajor.Length];
            for (int i = 0; i < ticks.Length; i++)
            {
                ticks[i] = new Tick(
                    position: TickCollectionStorage.tickPositionsMajor[i],
                    label: TickCollectionStorage.tickLabels[i],
                    isMajor: true,
                    isDateTime: LabelFormat == TickLabelFormatOptions.DateTime);
            }

            return ticks;
        }

        private Tick[] GetMinorTicks()
        {
            if (TickCollectionStorage.tickPositionsMinor is null || TickCollectionStorage.tickPositionsMinor.Length == 0)
            {
                return new Tick[] { };
            }

            Tick[] ticks = new Tick[TickCollectionStorage.tickPositionsMinor.Length];
            for (int i = 0; i < ticks.Length; i++)
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                ticks[i] = new Tick(
                    position: TickCollectionStorage.tickPositionsMinor[i],
                    label: null,
                    isMajor: false,
                    isDateTime: LabelFormat == TickLabelFormatOptions.DateTime);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            }

            return ticks;
        }

        public Tick[] GetTicks()
        {
            return GetMajorTicks().Concat(GetMinorTicks()).ToArray();
        }

        public Tick[] GetVisibleMajorTicks(PlotDimensions dims)
        {
            double high, low;
            if (Orientation == AxisOrientation.Vertical)
            {
                low = dims.YMin - dims.UnitsPerPxY; // add an extra pixel to capture the edge tick
                high = dims.YMax + dims.UnitsPerPxY; // add an extra pixel to capture the edge tick
            }
            else
            {
                low = dims.XMin - dims.UnitsPerPxX; // add an extra pixel to capture the edge tick
                high = dims.XMax + dims.UnitsPerPxX; // add an extra pixel to capture the edge tick
            }

            return GetMajorTicks()
                .Where(t => t.Position >= low && t.Position <= high)
                .ToArray();
        }

        public Tick[] GetVisibleMinorTicks(PlotDimensions dims)
        {
            double high, low;
            if (Orientation == AxisOrientation.Vertical)
            {
                low = dims.YMin - dims.UnitsPerPxY; // add an extra pixel to capture the edge tick
                high = dims.YMax + dims.UnitsPerPxY; // add an extra pixel to capture the edge tick
            }
            else
            {
                low = dims.XMin - dims.UnitsPerPxX; // add an extra pixel to capture the edge tick
                high = dims.XMax + dims.UnitsPerPxX; // add an extra pixel to capture the edge tick
            }

            return GetMinorTicks()
                .Where(t => t.Position >= low && t.Position <= high)
                .ToArray();
        }

        public Tick[] GetVisibleTicks(PlotDimensions dims)
        {
            return GetVisibleMajorTicks(dims).Concat(GetVisibleMinorTicks(dims)).ToArray();
        }
    }
}