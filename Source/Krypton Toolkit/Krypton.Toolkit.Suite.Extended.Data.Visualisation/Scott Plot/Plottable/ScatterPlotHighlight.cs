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

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    [Obsolete("This plot type is deprecated: Use a regular scatter plot and call GetPointNearest(). See examples in documentation.", true)]
    public class ScatterPlotHighlight : ScatterPlot, IPlottable, IHasPoints, IHasHighlightablePoints
    {
        public MarkerShape highlightedShape = MarkerShape.OPENCIRCLE;
        public float highlightedMarkerSize = 10;
        public Color highlightedColor = Color.Red;
        protected bool[] isHighlighted;

        public ScatterPlotHighlight(double[] xs, double[] ys, double[] xErr = null, double[] yErr = null) :
                                    base(xs, ys, xErr, yErr) => HighlightClear();

        public new void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false) => throw new NotImplementedException();
        public void HighlightClear() => throw new NotImplementedException();
        public (double x, double y, int index) HighlightPoint(int index) => throw new NotImplementedException();
        public (double x, double y, int index) HighlightPointNearestX(double x) => throw new NotImplementedException();
        public (double x, double y, int index) HighlightPointNearestY(double y) => throw new NotImplementedException();
        public (double x, double y, int index) HighlightPointNearest(double x, double y) => throw new NotImplementedException();
    }
}
