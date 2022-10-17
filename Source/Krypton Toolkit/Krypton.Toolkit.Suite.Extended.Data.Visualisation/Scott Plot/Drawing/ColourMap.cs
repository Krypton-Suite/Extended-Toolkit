#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class ColourMap
    {
        public static ColourMap Algae => new ColourMap(new Algae());
        public static ColourMap Amp => new ColourMap(new Amp());
        public static ColourMap Balance => new ColourMap(new Balance());
        public static ColourMap Blues => new ColourMap(new Blues());
        public static ColourMap Curl => new ColourMap(new Curl());
        public static ColourMap Deep => new ColourMap(new Deep());
        public static ColourMap Delta => new ColourMap(new Delta());
        public static ColourMap Dense => new ColourMap(new Dense());
        public static ColourMap Diff => new ColourMap(new Diff());
        public static ColourMap Grayscale => new ColourMap(new Grayscale());
        public static ColourMap GrayscaleR => new ColourMap(new GrayscaleR());
        public static ColourMap Greens => new ColourMap(new Greens());
        public static ColourMap Haline => new ColourMap(new Haline());
        public static ColourMap Ice => new ColourMap(new Ice());
        public static ColourMap Inferno => new ColourMap(new Inferno());
        public static ColourMap Jet => new ColourMap(new Jet());
        public static ColourMap Magma => new ColourMap(new Magma());
        public static ColourMap Matter => new ColourMap(new Matter());
        public static ColourMap Oxy => new ColourMap(new Oxy());
        public static ColourMap Phase => new ColourMap(new Phase());
        public static ColourMap Plasma => new ColourMap(new Plasma());
        public static ColourMap Rain => new ColourMap(new Rain());
        public static ColourMap Solar => new ColourMap(new Solar());
        public static ColourMap Speed => new ColourMap(new Speed());
        public static ColourMap Tarn => new ColourMap(new Tarn());
        public static ColourMap Tempo => new ColourMap(new Tempo());
        public static ColourMap Thermal => new ColourMap(new Thermal());
        public static ColourMap Topo => new ColourMap(new Topo());
        public static ColourMap Turbid => new ColourMap(new Turbid());
        public static ColourMap Turbo => new ColourMap(new Turbo());
        public static ColourMap Viridis => new ColourMap(new Viridis());

        private readonly IColourMap ThisColourMap;

        /// <summary>
        /// Name of this colormap
        /// </summary>
        public string Name => ThisColourMap.Name;

        private static readonly ColourMapFactory ColourMapFactory = new ColourMapFactory();

        public ColourMap(IColourMap colormap)
        {
            ThisColourMap = colormap ?? ColourMapFactory.GetDefaultColourMap();
        }

        public override string ToString() => $"Colormap {Name}";

        /// <summary>
        /// Create new instances of every colormap and return them as an array.
        /// </summary>
        /// <returns></returns>
        public static ColourMap[] GetColourMaps() => ColourMapFactory.GetAvailableColourMaps().ToArray();

        /// <summary>
        /// Return the names of all available 
        /// </summary>
        /// <returns></returns>
        public static string[] GetColormapNames() => ColourMapFactory.GetAvailableNames().ToArray();

        /// <summary>
        /// Create a new colormap by its name.
        /// </summary>
        /// <param name="name">colormap name</param>
        /// <param name="throwIfNotFound">if false the default colormap (Viridis) will be returned</param>
        /// <returns></returns>
        public static ColourMap GetColormapByName(string name, bool throwIfNotFound = true) =>
            throwIfNotFound ? ColourMapFactory.CreateOrThrow(name) : ColourMapFactory.CreateOrDefault(name);

        public (byte r, byte g, byte b) GetRGB(byte value) => ThisColourMap.GetRGB(value);

        public (byte r, byte g, byte b) GetRGB(double fraction)
        {
            fraction = Math.Max(fraction, 0);
            fraction = Math.Min(fraction, 1);
            return ThisColourMap.GetRGB((byte)(fraction * 255));
        }

        public int GetInt32(byte value, byte alpha = 255)
        {
            var (r, g, b) = GetRGB(value);
            return alpha << 24 | r << 16 | g << 8 | b;
        }

        public int GetInt32(double fraction, byte alpha = 255)
        {
            var (r, g, b) = GetRGB(fraction);
            return alpha << 24 | r << 16 | g << 8 | b;
        }

        public Color GetColor(byte value, double alpha = 1.0)
        {
            byte alphaByte = (byte)(255 * alpha);
            return Color.FromArgb(GetInt32(value, alphaByte));
        }

        public Color GetColor(double fraction, double alpha = 1.0)
        {
            byte alphaByte = (byte)(255 * alpha);
            return Color.FromArgb(GetInt32(fraction, alphaByte));
        }

        public Color RandomColor(Random rand, double alpha = 1.0)
        {
            byte alphaByte = (byte)(255 * alpha);
            return Color.FromArgb(GetInt32(rand.NextDouble(), alphaByte));
        }

        public void Apply(Bitmap bmp)
        {
            System.Drawing.Imaging.ColorPalette pal = bmp.Palette;
            for (int i = 0; i < 256; i++)
                pal.Entries[i] = GetColor((byte)i);
            bmp.Palette = pal;
        }

        public static byte[,] IntenstitiesToRGB(double[] intensities, IColourMap cmap)
        {
            byte[,] output = new byte[intensities.Length, 3];
            for (int i = 0; i < intensities.Length; i++)
            {
                double intensity = intensities[i] * 255;
                byte pixelIntensity = (byte)Math.Max(Math.Min(intensity, 255), 0);
                var (r, g, b) = cmap.GetRGB(pixelIntensity);
                output[i, 0] = r;
                output[i, 1] = g;
                output[i, 2] = b;
            }
            return output;
        }

        public static int[] GetRGBAs(double[] intensities, ColourMap colorMap, double minimumIntensity = 0)
        {
            int[] rgbas = new int[intensities.Length];
            for (int i = 0; i < intensities.Length; i++)
            {
                byte pixelIntensity = (byte)Math.Max(Math.Min(intensities[i] * 255, 255), 0);
                var (r, g, b) = colorMap.GetRGB(pixelIntensity);
                byte alpha = intensities[i] < minimumIntensity ? (byte)0 : (byte)255;
                byte[] argb = { b, g, r, alpha };
                rgbas[i] = BitConverter.ToInt32(argb, 0);
            }
            return rgbas;
        }

        public static int[] GetRGBAs(double?[] intensities, ColourMap colorMap, double minimumIntensity = 0)
        {
            int[] rgbas = new int[intensities.Length];
            for (int i = 0; i < intensities.Length; i++)
            {
                if (intensities[i].HasValue)
                {
                    byte pixelIntensity = (byte)Math.Max(Math.Min(intensities[i].Value * 255, 255), 0);
                    var (r, g, b) = colorMap.GetRGB(pixelIntensity);
                    byte alpha = intensities[i] < minimumIntensity ? (byte)0 : (byte)255;
                    byte[] argb = { b, g, r, alpha };
                    rgbas[i] = BitConverter.ToInt32(argb, 0);
                }
                else
                {
                    byte[] argb = { 0, 0, 0, 0 };
                    rgbas[i] = BitConverter.ToInt32(argb, 0);
                }
            }
            return rgbas;
        }

        public static Color[] GetColours(double[] intensities, ColourMap colorMap)
        {
            Color[] colors = new Color[intensities.Length];
            for (int i = 0; i < intensities.Length; i++)
            {
                byte pixelIntensity = (byte)Math.Max(Math.Min(intensities[i] * 255, 255), 0);
                var (r, g, b) = colorMap.GetRGB(pixelIntensity);
                colors[i] = Color.FromArgb(255, r, g, b);
            }
            return colors;
        }

        /// <summary>
        /// Return a bitmap showing the gradient of colors in a colormap.
        /// Defining min/max will create an image containing only part of the colormap.
        /// </summary>
        public static Bitmap Colorbar(ColourMap cmap, int width, int height, bool vertical = false, double min = 0, double max = 1)
        {
            if (width < 1 || height < 1)
                return null;

            if (min < 0)
                throw new ArgumentException($"{nameof(min)} must be >= 0");
            if (max > 1)
                throw new ArgumentException($"{nameof(max)} must be <= 1");
            if (min >= max)
                throw new ArgumentException($"{nameof(min)} must < {nameof(max)}");

            Bitmap bmp = new(width, height);
            using Graphics gfx = Graphics.FromImage(bmp);
            using Pen pen = new(Color.Magenta);

            if (vertical)
            {
                for (int y = 0; y < height; y++)
                {
                    double fraction = (double)y / (height);
                    fraction = fraction * (max - min) + min;
                    pen.Color = cmap.GetColor(fraction);
                    gfx.DrawLine(pen, 0, height - y - 1, width - 1, height - y - 1);
                }
            }
            else
            {
                for (int x = 0; x < width; x++)
                {
                    double fraction = (double)x / width;
                    fraction = fraction * (max - min) + min;
                    pen.Color = cmap.GetColor(fraction);
                    gfx.DrawLine(pen, x, 0, x, height - 1);
                }
            }

            return bmp;
        }
    }
}