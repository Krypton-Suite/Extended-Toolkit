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
    /// <summary>
    /// A colorbar translates numeric intensity values to colors.
    /// The Colorbar plot type displays a Colorbar along an edge of the plot.
    /// </summary>
    public class Colorbar : IPlottable
    {
        public Edge Edge = Edge.Right;

        private ColourMap _colormap;
        private Bitmap? _bmpScale;

        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get => 0; set { } }
        public int YAxisIndex { get => 0; set { } }

        /// <summary>
        /// Width of the colorbar rectangle
        /// </summary>
        public int Width = 20;

        public readonly Font TickLabelFont = new();
        public Color TickMarkColor = Color.Black;
        public float TickMarkLength = 3;
        public float TickMarkWidth = 1;

        private readonly List<Tick> _manualTicks = new();
        private bool _automaticTickEnable = true;
        private int _automaticTickMinimumSpacing = 40;
        private Func<double, string> _automaticTickFormatter = position => $"{position:F2}";

        private double _minValue;
        public double MinValue
        {
            get => (_plottable is IHasColormap p) ? p.ColormapMin : _minValue;
            set => _minValue = value;
        }

        private double _maxValue = 1;
        public double MaxValue
        {
            get => (_plottable is IHasColormap p) ? p.ColormapMax : _maxValue;
            set => _maxValue = value;
        }

        private bool _minIsClipped = false;
        public bool MinIsClipped
        {
            get => (_plottable is IHasColormap p) ? p.ColormapMinIsClipped : _minIsClipped;
            set => _minIsClipped = value;
        }

        private bool _maxIsClipped = false;
        public bool MaxIsClipped
        {
            get => (_plottable is IHasColormap p) ? p.ColormapMaxIsClipped : _maxIsClipped;
            set => _maxIsClipped = value;
        }

        private double _minColor;
        public double MinColor { get => _minColor; set { _minColor = value; UpdateBitmap(); } }

        private double _maxColor = 1;
        public double MaxColor { get => _maxColor; set { _maxColor = value; UpdateBitmap(); } }

        /// <summary>
        /// If populated, this object holds the plottable containing the heatmap and value data this colorbar represents
        /// </summary>
        private IHasColormap? _plottable;

        public Colorbar(ColourMap? colormap = null)
        {
            UpdateColormap(colormap ?? ColourMap.Viridis);
        }

        public Colorbar(IHasColormap plottable)
        {
            _plottable = plottable;
            UpdateColormap(plottable.Colormap);
        }

        /// <summary>
        /// Configure ticks that are automatically generated in the absense of manually-added ticks
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="minimumSpacing">Minimum number of vertical pixels between tick positions</param>
        /// <param name="formatter">Optional custom string formatter to translate tick positions to labels</param>
        public void AutomaticTicks(bool enable = true, int? minimumSpacing = null, Func<double, string>? formatter = null)
        {
            if (enable)
            {
                _manualTicks.Clear();
            }

            _automaticTickEnable = enable;
            _automaticTickMinimumSpacing = minimumSpacing ?? _automaticTickMinimumSpacing;
            _automaticTickFormatter = formatter ?? _automaticTickFormatter;
        }

        /// <summary>
        /// Clear the list of manually-defined ticks.
        /// To enable automatic tick placement call 
        /// </summary>
        public void ClearTicks()
        {
            _manualTicks.Clear();
        }

        /// <summary>
        /// Add a tick to the list of manually-defined ticks (disabling automatic tick placement)
        /// </summary>
        /// <param name="fraction">from 0 (darkest) to 1 (brightest)</param>
        /// <param name="label">string displayed beside the tick</param>
        public void AddTick(double fraction, string label)
        {
            _manualTicks.Add(new(fraction, label, true, false));
        }

        /// <summary>
        /// Manually define ticks (disabling automatic tick placement)
        /// </summary>
        /// <param name="fractions">from 0 (darkest) to 1 (brightest)</param>
        /// <param name="labels">strings displayed beside the ticks</param>
        public void AddTicks(double[] fractions, string[] labels)
        {
            if (fractions.Length != labels.Length)
            {
                throw new("fractions and labels must have the same length");
            }

            for (int i = 0; i < fractions.Length; i++)
            {
                _manualTicks.Add(new(fractions[i], labels[i], true, false));
            }
        }

        /// <summary>
        /// Manually define ticks (disabling automatic tick placement)
        /// </summary>
        /// <param name="fractions">from 0 (darkest) to 1 (brightest)</param>
        /// <param name="labels">strings displayed beside the ticks</param>
        public void SetTicks(double[] fractions, string[] labels)
        {
            if (fractions.Length != labels.Length)
            {
                throw new("fractions and labels must have the same length");
            }

            ClearTicks();
            AddTicks(fractions, labels);
        }

        public LegendItem[]? GetLegendItems() => null;

        public AxisLimits GetAxisLimits() => new(double.NaN, double.NaN, double.NaN, double.NaN);

        public void ValidateData(bool deep = false) { }

        /// <summary>
        /// Re-Render the colorbar using a new colormap
        /// </summary>
        public void UpdateColormap(ColourMap? newColormap)
        {
            _colormap = newColormap ?? ColourMap.Viridis;
            UpdateBitmap();
        }

        private void UpdateBitmap()
        {
            _bmpScale?.Dispose();
            _bmpScale = GetBitmap();
        }

        /// <summary>
        /// Return a Bitmap of just the color portion of the colorbar.
        /// The width is defined by the Width field
        /// The height will be 256
        /// </summary>
        /// <returns></returns>
        public Bitmap GetBitmap() =>
            ColourMap.Colorbar(_colormap, Width, 256, true, MinColor, MaxColor);

        /// <summary>
        /// Return a Bitmap of just the color portion of the colorbar
        /// </summary>
        /// <param name="width">width of the Bitmap</param>
        /// <param name="height">height of the Bitmap</param>
        /// <param name="vertical">if true, colormap will be vertically oriented (tall and skinny)</param>
        /// <returns></returns>
        public Bitmap GetBitmap(int width, int height, bool vertical = true) =>
            ColourMap.Colorbar(_colormap, width, height, vertical, MinColor, MaxColor);

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (_bmpScale is null)
            {
                UpdateBitmap();
            }

            RectangleF colorbarRect = RenderColorbar(dims, bmp);

            RenderTicks(dims, bmp, lowQuality, colorbarRect);
        }

        /// <summary>
        /// Return a list of ticks evenly spaced between the min and max values.
        /// </summary>
        /// <param name="height">height of the vertical colorbar</param>
        /// <param name="tickSpacing">minimum pixel distance between adjacent ticks</param>
        /// <returns></returns>
        private List<Tick> GetEvenlySpacedTicks(float height, double tickSpacing)
        {
            List<Tick> ticks = new();
            int tickCount = (int)(height / tickSpacing);
            tickCount = Math.Max(tickCount, 1);
            double tickSpacingFraction = 1.0 / tickCount;
            double valueSpan = MaxValue - MinValue;
            for (int i = 0; i <= tickCount; i++)
            {
                double colorbarFraction = tickSpacingFraction * i;
                double tickPosition = MinValue + colorbarFraction * valueSpan;

                string tickLabel = _automaticTickFormatter(tickPosition);
                if (MinIsClipped && i == 0)
                {
                    tickLabel = $"\u2264{tickLabel}";
                }

                if (MaxIsClipped && i == tickCount)
                {
                    tickLabel = $"\u2265{tickLabel}";
                }

                Tick tick = new(colorbarFraction, tickLabel, isMajor: true, isDateTime: false);
                ticks.Add(tick);
            }

            return ticks;
        }

        private RectangleF RenderColorbar(PlotDimensions dims, Bitmap bmp)
        {
            float scaleLeftPad = 10;

            PointF location = new(dims.DataOffsetX + dims.DataWidth + scaleLeftPad, dims.DataOffsetY);
            SizeF size = new(Width, dims.DataHeight);
            RectangleF rect = new(location, size);

            using (Graphics gfx = GDI.Graphics(bmp, dims, lowQuality: true, clipToDataArea: false))
            {
                using (var pen = GDI.Pen(Color.Black))
                {
                    if (_bmpScale != null)
                    {
                        gfx.DrawImage(_bmpScale, location.X, location.Y, size.Width, size.Height + 1);
                    }
                    gfx.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
                }
            }

            return rect;
        }

        private void RenderTicks(PlotDimensions dims, Bitmap bmp, bool lowQuality, RectangleF colorbarRect)
        {
            float tickLeftPx = colorbarRect.Right;
            float tickRightPx = tickLeftPx + TickMarkLength;
            float tickLabelPx = tickRightPx + 2;

            using Graphics gfx = GDI.Graphics(bmp, dims, lowQuality, false);
            using var tickMarkPen = GDI.Pen(TickMarkColor, TickMarkWidth);
            using var tickLabelBrush = GDI.Brush(TickLabelFont.Color);
            using var tickFont = GDI.Font(TickLabelFont);
            using var sf = new StringFormat() { LineAlignment = StringAlignment.Center };

            bool useManualTicks = (_manualTicks.Count > 0 || _automaticTickEnable == false);
            List<Tick> ticks = useManualTicks ? _manualTicks : GetEvenlySpacedTicks(colorbarRect.Height, _automaticTickMinimumSpacing);

            foreach (Tick tick in ticks)
            {
                float y = colorbarRect.Top + (float)((1 - tick.Position) * colorbarRect.Height);
                gfx.DrawLine(tickMarkPen, tickLeftPx, y, tickRightPx, y);
                gfx.DrawString(tick.Label, tickFont, tickLabelBrush, tickLabelPx, y, sf);
            }
        }
    }
}
