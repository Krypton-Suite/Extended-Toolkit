#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2026 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Captures and blurs owner content for frosted-glass backdrops.
/// </summary>
public static class BottomSheetBlurRenderer
{
    public static Bitmap? CaptureControl(Control? control)
    {
        if (control == null || control.Width <= 0 || control.Height <= 0 || !control.IsHandleCreated)
        {
            return null;
        }

        var bitmap = new Bitmap(control.Width, control.Height);
        control.DrawToBitmap(bitmap, new Rectangle(Point.Empty, control.Size));
        return bitmap;
    }

    public static Bitmap ApplyBlur(Bitmap source, int radius, double opacity)
    {
        int scale = Math.Max(2, Math.Min(12, radius));
        int smallWidth = Math.Max(1, source.Width / scale);
        int smallHeight = Math.Max(1, source.Height / scale);

        using var downscaled = new Bitmap(smallWidth, smallHeight);
        using (Graphics downscaleGraphics = Graphics.FromImage(downscaled))
        {
            downscaleGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            downscaleGraphics.DrawImage(source, 0, 0, smallWidth, smallHeight);
        }

        var blurred = new Bitmap(source.Width, source.Height);
        using (Graphics graphics = Graphics.FromImage(blurred))
        {
            graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            graphics.DrawImage(downscaled, 0, 0, blurred.Width, blurred.Height);

            int alpha = (int)Math.Round(BottomSheetAnimation.Clamp(opacity, 0d, 1d) * 160d);
            if (alpha > 0)
            {
                using SolidBrush dim = new(Color.FromArgb(alpha, Color.Black));
                graphics.FillRectangle(dim, new Rectangle(Point.Empty, blurred.Size));
            }
        }

        return blurred;
    }
}
