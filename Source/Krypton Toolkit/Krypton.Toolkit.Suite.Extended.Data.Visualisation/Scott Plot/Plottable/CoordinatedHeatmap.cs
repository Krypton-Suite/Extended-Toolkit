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
    [Obsolete("This plot type has been deprecated. Min/max and interpolation settings are exposed in the regular Heatmap.")]
    public class CoordinatedHeatmap : Heatmap
    {
        protected override void RenderHeatmap(PlotDimensions dims, Bitmap bmp, bool lowQuality)
        {
            using Graphics gfx = GDI.Graphics(bmp, dims, lowQuality);

            gfx.InterpolationMode = Interpolation;
            gfx.PixelOffsetMode = PixelOffsetMode.Half;

            int drawFromX = (int)Math.Round(dims.GetPixelX(XMin));
            int drawFromY = (int)Math.Round(dims.GetPixelY(YMax));
            int drawWidth = (int)Math.Round(dims.GetPixelX(XMax) - drawFromX);
            int drawHeight = (int)Math.Round(dims.GetPixelY(YMin) - drawFromY);
            Rectangle destRect = new Rectangle(drawFromX, drawFromY, drawWidth, drawHeight);
            ImageAttributes attr = new ImageAttributes();
            attr.SetWrapMode(WrapMode.TileFlipXY);

            if (BackgroundImage != null && !DisplayImageAbove)
            {
                gfx.DrawImage(BackgroundImage, destRect, 0, 0, BackgroundImage.Width, BackgroundImage.Height, GraphicsUnit.Pixel, attr);
            }

            gfx.DrawImage(BmpHeatmap, destRect, 0, 0, BmpHeatmap.Width, BmpHeatmap.Height, GraphicsUnit.Pixel, attr);

            if (BackgroundImage != null && DisplayImageAbove)
            {
                gfx.DrawImage(BackgroundImage, destRect, 0, 0, BackgroundImage.Width, BackgroundImage.Height, GraphicsUnit.Pixel, attr);
            }
        }

        public override AxisLimits GetAxisLimits()
        {
            return new AxisLimits(XMin, XMax, YMin, YMax);
        }
    }
}
