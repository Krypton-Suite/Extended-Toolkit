using System;
using System.Drawing;
using System.Linq;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class Colourmap
    {
        public static Colourmap Algae => new Colourmap(new Algae());
        public static Colourmap Amp => new Colourmap(new Amp());
        public static Colourmap Balance => new Colourmap(new Balance());
        public static Colourmap Blues => new Colourmap(new Blues());
        public static Colourmap Curl => new Colourmap(new Curl());
        public static Colourmap Deep => new Colourmap(new Deep());
        public static Colourmap Delta => new Colourmap(new Delta());
        public static Colourmap Dense => new Colourmap(new Dense());
        public static Colourmap Diff => new Colourmap(new Diff());
        public static Colourmap Grayscale => new Colourmap(new Grayscale());
        public static Colourmap GrayscaleR => new Colourmap(new GrayscaleR());
        public static Colourmap Greens => new Colourmap(new Greens());
        public static Colourmap Haline => new Colourmap(new Haline());
        public static Colourmap Ice => new Colourmap(new Ice());
        public static Colourmap Inferno => new Colourmap(new Inferno());
        public static Colourmap Jet => new Colourmap(new Jet());
        public static Colourmap Magma => new Colourmap(new Magma());
        public static Colourmap Matter => new Colourmap(new Matter());
        public static Colourmap Oxy => new Colourmap(new Oxy());
        public static Colourmap Phase => new Colourmap(new Phase());
        public static Colourmap Plasma => new Colourmap(new Plasma());
        public static Colourmap Rain => new Colourmap(new Rain());
        public static Colourmap Solar => new Colourmap(new Solar());
        public static Colourmap Speed => new Colourmap(new Speed());
        public static Colourmap Tarn => new Colourmap(new Tarn());
        public static Colourmap Tempo => new Colourmap(new Tempo());
        public static Colourmap Thermal => new Colourmap(new Thermal());
        public static Colourmap Topo => new Colourmap(new Topo());
        public static Colourmap Turbid => new Colourmap(new Turbid());
        public static Colourmap Turbo => new Colourmap(new Turbo());
        public static Colourmap Viridis => new Colourmap(new Viridis());

        private readonly IColourmap cmap;
        public readonly string Name;
        public Colourmap(IColourmap colourmap)
        {
            cmap = colourmap ?? new Grayscale();
            Name = cmap.GetType().Name;
        }

        public override string ToString()
        {
            return $"Colourmap {Name}";
        }

        public static Colourmap[] GetColourmaps()
        {
            IColourmap[] ics = AppDomain.CurrentDomain.GetAssemblies()
                                .SelectMany(s => s.GetTypes())
                                .Where(p => p.IsInterface == false)
                                .Where(p => p.ToString().StartsWith("ScottPlot.Drawing."))
                                .Select(x => x.ToString())
                                .Select(path => (IColourmap)Activator.CreateInstance(Type.GetType(path)))
                                .ToArray();

            return ics.Select(x => new Colourmap(x)).ToArray();
        }

        public (byte r, byte g, byte b) GetRGB(byte value)
        {
            return cmap.GetRGB(value);
        }

        public (byte r, byte g, byte b) GetRGB(double fraction)
        {
            fraction = Math.Max(fraction, 0);
            fraction = Math.Min(fraction, 1);
            return cmap.GetRGB((byte)(fraction * 255));
        }

        public int GetInt32(byte value)
        {
            var (r, g, b) = GetRGB(value);
            return 255 << 24 | r << 16 | g << 8 | b;
        }

        public int GetInt32(double fraction)
        {
            var (r, g, b) = GetRGB(fraction);
            return 255 << 24 | r << 16 | g << 8 | b;
        }

        public Color GetColour(byte value)
        {
            return Color.FromArgb(GetInt32(value));
        }

        public Color GetColour(double fraction)
        {
            return Color.FromArgb(GetInt32(fraction));
        }

        public void Apply(Bitmap bmp)
        {
            System.Drawing.Imaging.ColorPalette pal = bmp.Palette;
            for (int i = 0; i < 256; i++)
                pal.Entries[i] = GetColour((byte)i);
            bmp.Palette = pal;
        }

        public static byte[,] IntenstitiesToRGB(double[] intensities, IColourmap cmap)
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

        public static int[] GetRGBAs(double[] intensities, Colourmap colorMap, double minimumIntensity = 0)
        {
            int[] rgbas = new int[intensities.Length];
            for (int i = 0; i < intensities.Length; i++)
            {
                byte pixelIntensity = (byte)Math.Max(Math.Min(intensities[i] * 255, 255), 0);
                var (r, g, b) = colorMap.GetRGB(pixelIntensity);
                byte alpha = pixelIntensity < minimumIntensity ? (byte)0 : (byte)255;
                byte[] argb = { b, g, r, alpha };
                rgbas[i] = BitConverter.ToInt32(argb, 0);
            }
            return rgbas;
        }

        public static Color[] GetColours(double[] intensities, Colourmap colorMap)
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

        public static Bitmap Colourbar(Colourmap cmap, int width, int height, bool vertical = false)
        {
            if (width < 1 || height < 1)
                return null;

            Bitmap bmp = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(bmp))
            using (Pen pen = new Pen(Color.Magenta))
            {
                if (vertical)
                {
                    for (int y = 0; y < height; y++)
                    {
                        double fraction = (double)y / (height);
                        pen.Color = cmap.GetColour(fraction);
                        gfx.DrawLine(pen, 0, height - y - 1, width - 1, height - y - 1);
                    }
                }
                else
                {
                    for (int x = 0; x < width; x++)
                    {
                        double fraction = (double)x / width;
                        pen.Color = cmap.GetColour(fraction);
                        gfx.DrawLine(pen, x, 0, x, height - 1);
                    }
                }
            }
            return bmp;
        }
    }
}