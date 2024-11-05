/* SkiaSharp cannot create BMP files, so bitmap IO is implemented manually
 * https://github.com/mono/SkiaSharp/issues/320
 */

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// Bitmap representation of a <seealso cref="SkiaSharp.SKImage"/>
    /// </summary>
    public class Image : IDisposable
    {
        private bool _isDisposed = false;

        protected readonly SKImage SkImage;
        public int Width => SkImage.Width;
        public int Height => SkImage.Height;

        public Image(SKImage skiaImage)
        {
            SkImage = skiaImage;
        }

        /// <summary>
        /// SkiaSharp cannot natively create BMP files. 
        /// This function creates bitmaps in memory manually.
        /// https://github.com/mono/SkiaSharp/issues/320
        /// </summary>
        private byte[] GetBitmapBytes()
        {
            using SKBitmap skBitmap = SKBitmap.FromImage(SkImage);

            BitmapHeader header = new(Width, Height);

            byte[] bitmapBytes = new byte[skBitmap.Bytes.Length + BitmapHeader.FileHeaderSize];

            IntPtr pHeader = IntPtr.Zero;

            try
            {
                pHeader = Marshal.AllocHGlobal(BitmapHeader.FileHeaderSize);
                Marshal.StructureToPtr(header, pHeader, false);

                // copy the header from the bytes of our custom bitmap header struct
                Marshal.Copy(pHeader, bitmapBytes, 0, BitmapHeader.FileHeaderSize);

                // copy the content of the bitmap from the SkiaSharp image
                Array.Copy(skBitmap.Bytes, 0, bitmapBytes, BitmapHeader.FileHeaderSize, skBitmap.Bytes.Length);
            }
            finally
            {
                Marshal.FreeHGlobal(pHeader);
            }

            return bitmapBytes;
        }

        public byte[] GetImageBytes(ImageFormat format = ImageFormat.Png, int quality = 100)
        {
            SKEncodedImageFormat skFormat = format.ToSkFormat();

            if (format == ImageFormat.Bmp)
            {
                return GetBitmapBytes();
            }

            using var skData = SkImage.Encode(skFormat, quality);
            return skData.ToArray();
        }

        public string SaveJpeg(string path, int quality = 85)
        {
            byte[] bytes = GetImageBytes(ImageFormat.Jpeg, quality);
            File.WriteAllBytes(path, bytes);
            return Path.GetFullPath(path);
        }

        public string SavePng(string path)
        {
            byte[] bytes = GetImageBytes(ImageFormat.Png, 100);
            File.WriteAllBytes(path, bytes);
            return Path.GetFullPath(path);
        }

        public string SaveBmp(string path)
        {
            byte[] bytes = GetImageBytes(ImageFormat.Bmp, 100);
            File.WriteAllBytes(path, bytes);
            return Path.GetFullPath(path);
        }

        public string SaveWebp(string path, int quality = 85)
        {
            byte[] bytes = GetImageBytes(ImageFormat.Webp, quality);
            File.WriteAllBytes(path, bytes);
            return Path.GetFullPath(path);
        }

        public string Save(string path, ImageFormat format = ImageFormat.Png, int quality = 85)
        {
            return format switch
            {
                ImageFormat.Png => SavePng(path),
                ImageFormat.Jpeg => SaveJpeg(path, quality),
                ImageFormat.Webp => SaveWebp(path, quality),
                ImageFormat.Bmp => SaveBmp(path),
                _ => throw new ArgumentException($"Unsupported image format: {format}"),
            };
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            SkImage.Dispose();
            _isDisposed = true;

            GC.SuppressFinalize(this);
        }
    }
}