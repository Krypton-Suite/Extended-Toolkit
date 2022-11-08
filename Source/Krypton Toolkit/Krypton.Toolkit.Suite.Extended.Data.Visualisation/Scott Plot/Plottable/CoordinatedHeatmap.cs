#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
                gfx.DrawImage(BackgroundImage, destRect, 0, 0, BackgroundImage.Width, BackgroundImage.Height, GraphicsUnit.Pixel, attr);

            gfx.DrawImage(BmpHeatmap, destRect, 0, 0, BmpHeatmap.Width, BmpHeatmap.Height, GraphicsUnit.Pixel, attr);

            if (BackgroundImage != null && DisplayImageAbove)
                gfx.DrawImage(BackgroundImage, destRect, 0, 0, BackgroundImage.Width, BackgroundImage.Height, GraphicsUnit.Pixel, attr);
        }

        public override AxisLimits GetAxisLimits()
        {
            return new AxisLimits(XMin, XMax, YMin, YMax);
        }
    }
}
