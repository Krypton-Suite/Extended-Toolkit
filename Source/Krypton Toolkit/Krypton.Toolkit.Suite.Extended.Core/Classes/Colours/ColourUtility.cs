#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    /// <summary>
    /// https://stackoverflow.com/questions/7255514/generating-colours-after-applying-opacity-of-black-and-white
    /// </summary>
    public class ColourUtility
    {
        #region Constants
        private const int MINIMUM_COLOUR_VALUE = 0, MAXIMUM_COLOUR_VALUE = 255;
        #endregion

        #region Variables
        private Color _colour;

        private Random randomColour = new Random(DateTime.Now.Millisecond);

        private AllMergedColourSettingsManager _colourSettingsManager = new AllMergedColourSettingsManager();
        #endregion

        #region Constructor
        public ColourUtility()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColourUtility"/> class.
        /// </summary>
        /// <param name="originalColour">The original colour.</param>
        public ColourUtility(Color originalColour)
        {
            _colour = originalColour;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the transformed colour.
        /// </summary>
        /// <param name="overlay">The overlay.</param>
        /// <returns></returns>
        public Color GetTransformedColour(Color overlay)
        {
            using (var bitmap = new Bitmap(1, 1))
            {
                var g = Graphics.FromImage(bitmap);

                using (Brush baseBrush = new SolidBrush(_colour))
                {
                    g.FillRectangle(baseBrush, 0, 0, 1, 1);
                }

                using (Brush overlayBrush = new SolidBrush(Color.FromArgb(127, overlay)))
                {
                    g.FillRectangle(overlayBrush, 0, 0, 1, 1);
                }

                return bitmap.GetPixel(0, 0);
            }
        }

        /// <summary>
        /// Sets the hue.
        /// </summary>
        /// <param name="baseColour">The base colour.</param>
        /// <returns></returns>
        public static Color SetHue(Color baseColour)
        {
            var tmpColour = new HSV();

            tmpColour.hue = baseColour.GetHue();

            tmpColour.saturation = baseColour.GetSaturation();

            tmpColour.brightness = baseColour.GetBrightness();

            return ColourFromHSL(tmpColour);
        }

        /// <summary>
        /// Colour from HSL.
        /// </summary>
        /// <param name="hsl">The HSL.</param>
        /// <returns></returns>
        private static Color ColourFromHSL(HSV hsl)
        {
            if (hsl.saturation == 0)
            {
                int l = (int)hsl.brightness;

                return Color.FromArgb(255, l, l, l);
            }

            double min, max, h;

            h = hsl.hue / 360d;

            max = hsl.brightness < 0.5 ? hsl.brightness * (1 + hsl.saturation) : (hsl.brightness + hsl.saturation) - (hsl.brightness * hsl.saturation);

            min = (hsl.brightness * 2d) - max;

            Color c = Color.FromArgb(255, (int)(255 * RGBChannelFromHue(min, max, h + 1 / 3d)), (int)(255 * RGBChannelFromHue(min, max, h)), (int)(255 * RGBChannelFromHue(min, max, h - 1 / 3d)));

            return c;
        }

        /// <summary>
        /// RGBs the channel from hue.
        /// </summary>
        /// <param name="m1">The m1.</param>
        /// <param name="m2">The m2.</param>
        /// <param name="h">The h.</param>
        /// <returns></returns>
        public static double RGBChannelFromHue(double m1, double m2, double h)
        {
            h = (h + 1d) % 1d;

            if (h < 0)
            {
                h += 1;
            }

            if (h * 6 < 1) return m1 + (m2 - m1) * 6 * h;
            else if (h * 2 < 1) return m2;
            else if (h * 3 < 2) return m1 + (m2 - m1) * 6 * (2d / 3d - h);
            else return m1;
        }

        /// <summary>
        /// Generates a random colour.
        /// </summary>
        /// <param name="useAlphaChannelValue">if set to <c>true</c> [use alpha channel value].</param>
        /// <returns>A random colour.</returns>
        public Color GenerateRandomColour(bool useAlphaChannelValue = false)
        {
            Color randomColourOutput;

            //if (useAlphaChannelValue)
            //{
            //    a = (byte)randomColour.Next(0, 255);
            //}
            //else
            //{
            randomColourOutput = Color.FromArgb(randomColour.Next(255), randomColour.Next(255), randomColour.Next(255));
            //}

            return randomColourOutput;

        }
        #endregion

        #region Structs
        public struct HSV
        {
            public float hue, saturation, brightness;
        }
        #endregion
    }
}