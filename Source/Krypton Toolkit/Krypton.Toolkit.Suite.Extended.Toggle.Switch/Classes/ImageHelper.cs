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

using System.Drawing;
using System.Drawing.Imaging;

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    public static class ImageHelper
    {
        private static float[][] _colourMatrixElements = {
                                            new float[] {(float)0.299, (float)0.299, (float)0.299, 0, 0},
                                            new float[] {(float)0.587, (float)0.587, (float)0.587, 0, 0},
                                            new float[] {(float)0.114, (float)0.114, (float)0.114, 0, 0},
                                            new float[] {0,  0,  0,  1, 0},
                                            new float[] {0, 0, 0, 0, 1}
                                        };

        private static ColorMatrix _grayscaleColourMatrix = new ColorMatrix(_colourMatrixElements);

        public static ImageAttributes GetGrayscaleAttributes()
        {
            ImageAttributes attr = new ImageAttributes();
            attr.SetColorMatrix(_grayscaleColourMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            return attr;
        }

        public static Size RescaleImageToFit(Size imageSize, Size canvasSize)
        {
            //Code "borrowed" from http://stackoverflow.com/questions/1940581/c-sharp-image-resizing-to-different-size-while-preserving-aspect-ratio
            // and the Math.Min improvement from http://stackoverflow.com/questions/6501797/resize-image-proportionally-with-maxheight-and-maxwidth-constraints

            // Figure out the ratio
            double ratioX = (double)canvasSize.Width / (double)imageSize.Width;
            double ratioY = (double)canvasSize.Height / (double)imageSize.Height;

            // use whichever multiplier is smaller
            double ratio = Math.Min(ratioX, ratioY);

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(imageSize.Height * ratio);
            int newWidth = Convert.ToInt32(imageSize.Width * ratio);

            Size resizedSize = new Size(newWidth, newHeight);

            if (resizedSize.Width > canvasSize.Width || resizedSize.Height > canvasSize.Height)
            {
                throw new Exception("ImageHelper.RescaleImageToFit - Resize failed!");
            }

            return resizedSize;
        }
    }
}