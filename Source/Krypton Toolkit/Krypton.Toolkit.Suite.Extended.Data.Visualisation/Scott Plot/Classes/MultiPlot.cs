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
    [Obsolete("This class will be deleted in a future version. See ScottPlot FAQ for details.")]
    public class MultiPlot
    {
        public readonly Plot[] subplots;
        public readonly int rows, cols;
        public readonly int width, height;

        private readonly Bitmap bmp;
        private readonly Graphics gfx;

        public int subplotCount => rows * cols;
        public int subplotWidth => width / cols;
        public int subplotHeight => height / rows;

        public MultiPlot(int width = 800, int height = 600, int rows = 1, int cols = 1)
        {
            if (rows < 1 || cols < 1)
            {
                throw new ArgumentException("must have at least 1 row and column");
            }

            this.width = width;
            this.height = height;
            this.rows = rows;
            this.cols = cols;

            bmp = new Bitmap(width, height);
            gfx = Graphics.FromImage(bmp);

            subplots = new Plot[subplotCount];
            for (int i = 0; i < subplotCount; i++)
                subplots[i] = new Plot(subplotWidth, subplotHeight);
        }

        private void Render()
        {
            gfx.Clear(Color.White);
            int subplotIndex = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Bitmap subplotBmp = subplots[subplotIndex++].Render(subplotWidth, subplotHeight, false);
                    Point pt = new Point(col * subplotWidth, row * subplotHeight);
                    gfx.DrawImage(subplotBmp, pt);
                }
            }
        }

        public Bitmap GetBitmap()
        {
            Render();
            return bmp;
        }

        public void SaveFig(string filePath)
        {
            filePath = Path.GetFullPath(filePath);
            string fileFolder = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(fileFolder))
            {
                throw new Exception($"ERROR: folder does not exist: {fileFolder}");
            }

            ImageFormat imageFormat;
            string extension = Path.GetExtension(filePath).ToUpper();
            if (extension == ".JPG" || extension == ".JPEG")
            {
                imageFormat = ImageFormat.Jpeg; // TODO: use jpgEncoder to set custom compression level
            }
            else if (extension == ".PNG")
            {
                imageFormat = ImageFormat.Png;
            }
            else if (extension == ".TIF" || extension == ".TIFF")
            {
                imageFormat = ImageFormat.Tiff;
            }
            else if (extension == ".BMP")
            {
                imageFormat = ImageFormat.Bmp;
            }
            else
            {
                throw new NotImplementedException($"Extension not supported: {extension}");
            }

            Render();
            bmp.Save(filePath, imageFormat);
        }

        public Plot GetSubplot(int rowIndex, int columnIndex)
        {
            if (rowIndex < 0 || rowIndex >= rows)
            {
                throw new ArgumentException("invalid row index");
            }

            if (columnIndex < 0 || columnIndex >= cols)
            {
                throw new ArgumentException("invalid column index");
            }

            int subplotIndex = rowIndex * cols + columnIndex;
            return subplots[subplotIndex];
        }
    }
}