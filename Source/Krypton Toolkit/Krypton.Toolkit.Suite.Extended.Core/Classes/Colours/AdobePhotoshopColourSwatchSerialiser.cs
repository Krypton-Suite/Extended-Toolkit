#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Core
{
    /// <summary>
    /// Deserialises colour palettes into and from the images and palettes using the  ILBM (IFF Interleaved Bitmap) format.
    /// </summary>
    public class AdobePhotoshopColourSwatchSerialiser : PaletteSerialiser
    {
        #region Properties

        /// <summary>
        /// Gets the default extension for files generated with this palette format.
        /// </summary>
        /// <value>The default extension for files generated with this palette format.</value>
        public override string DefaultExtension => "aco";

        /// <summary>
        /// Gets a descriptive name of the palette format
        /// </summary>
        /// <value>The descriptive name of the palette format.</value>
        public override string Name => "Adobe Photoshop Colour Swatch";

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether this instance can read palette from data the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns><c>true</c> if this instance can read palette data from the specified stream; otherwise, <c>false</c>.</returns>
        public override bool CanReadFrom(Stream stream)
        {
            bool result;

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            try
            {
                int version;

                // read the version, which occupies two bytes
                // first byte is 0, the second 1 so I assume this is added to make 1
                //version = this.ReadShort(stream);
                version = stream.ReadByte() + stream.ReadByte();

                result = version == 1 || version == 2;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Deserializes the <see cref="ColourCollection" /> contained by the specified <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> that contains the palette to deserialize.</param>
        /// <returns>The <see cref="ColourCollection" /> being deserialized.</returns>
        public override ColourCollection Deserialise(Stream stream)
        {
            AdobePhotoshopColourSwatchFileVersion version;
            ColourCollection results;

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            // read the version, which occupies two bytes
            version = (AdobePhotoshopColourSwatchFileVersion)this.ReadInt16(stream);

            if (version != AdobePhotoshopColourSwatchFileVersion.VersionOne && version != AdobePhotoshopColourSwatchFileVersion.VersionTwo)
            {
                throw new InvalidDataException("Invalid version information.");
            }

            // the specification states that a version2 palette follows a version1
            // the only difference between version1 and version2 is the inclusion
            // of a name property. Perhaps there's addtional color spaces as well
            // but we can't support them all anyway
            // I noticed some files no longer include a version 1 palette

            results = this.ReadPalette(stream, version);
            if (version == AdobePhotoshopColourSwatchFileVersion.VersionOne)
            {
                version = (AdobePhotoshopColourSwatchFileVersion)this.ReadInt16(stream);
                if (version == AdobePhotoshopColourSwatchFileVersion.VersionTwo)
                {
                    results = this.ReadPalette(stream, version);
                }
            }

            return results;
        }

        /// <summary>
        /// Serializes the specified <see cref="ColourCollection" /> and writes the palette to a file using the specified <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> used to write the palette.</param>
        /// <param name="palette">The <see cref="ColourCollection" /> to serialize.</param>
        public override void Serialise(Stream stream, ColourCollection palette)
        {
            this.Serialize(stream, palette, AdobePhotoshopColourSwatchColourSpace.RGB);
        }

        public void Serialize(Stream stream, ColourCollection palette, AdobePhotoshopColourSwatchColourSpace colourSpace)
        {
            this.Serialize(stream, palette, AdobePhotoshopColourSwatchFileVersion.VersionTwo, colourSpace);
        }

        public void Serialize(Stream stream, ColourCollection palette, AdobePhotoshopColourSwatchFileVersion version)
        {
            this.Serialize(stream, palette, version, AdobePhotoshopColourSwatchColourSpace.RGB);
        }

        public void Serialize(Stream stream, ColourCollection palette, AdobePhotoshopColourSwatchFileVersion version, AdobePhotoshopColourSwatchColourSpace colourSpace)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (palette == null)
            {
                throw new ArgumentNullException(nameof(palette));
            }

            if (version == AdobePhotoshopColourSwatchFileVersion.VersionTwo)
            {
                this.WritePalette(stream, palette, AdobePhotoshopColourSwatchFileVersion.VersionOne, colourSpace);
            }
            this.WritePalette(stream, palette, version, colourSpace);
        }

        protected virtual ColourCollection ReadPalette(Stream stream, AdobePhotoshopColourSwatchFileVersion version)
        {
            int colourCount;
            ColourCollection results;

            results = new();

            // read the number of colors, which also occupies two bytes
            colourCount = this.ReadInt16(stream);

            for (int i = 0; i < colourCount; i++)
            {
                AdobePhotoshopColourSwatchColourSpace colorSpace;
                int value1;
                int value2;
                int value3;
                string name;

                // again, two bytes for the color space
                colorSpace = (AdobePhotoshopColourSwatchColourSpace)this.ReadInt16(stream);

                value1 = this.ReadInt16(stream);
                value2 = this.ReadInt16(stream);
                value3 = this.ReadInt16(stream);
                this.ReadInt16(stream); // only CMYK supports this field. As we can't handle CMYK colors, we read the value to advance the stream but don't do anything with it

                if (version == AdobePhotoshopColourSwatchFileVersion.VersionTwo)
                {
                    int length;

                    // need to read the name even though currently our colour collection doesn't support names
                    length = this.ReadInt32(stream);
                    name = this.ReadString(stream, length);
                }
                else
                {
                    name = string.Empty;
                }

                switch (colorSpace)
                {
                    case AdobePhotoshopColourSwatchColourSpace.RGB:
                        int red;
                        int green;
                        int blue;

                        // RGB.
                        // The first three values in the color data are red , green , and blue . They are full unsigned
                        //  16-bit values as in Apple's RGBColor data structure. Pure red = 65535, 0, 0.

                        red = value1 / 256;
                        green = value2 / 256;
                        blue = value3 / 256;

                        results.Add(Color.FromArgb(red, green, blue));
                        break;

                    case AdobePhotoshopColourSwatchColourSpace.HSB:
                        double hue;
                        double saturation;
                        double brightness;

                        // HSB.
                        // The first three values in the color data are hue , saturation , and brightness . They are full
                        // unsigned 16-bit values as in Apple's HSVColor data structure. Pure red = 0,65535, 65535.

                        hue = value1 / 182.04;
                        saturation = value2 / 655.35;
                        brightness = value3 / 655.35;

                        results.Add(new HSLColourStructure(hue, saturation, brightness).ToRgbColour());
                        break;

                    case AdobePhotoshopColourSwatchColourSpace.GreyScale:

                        int gray;

                        // Grayscale.
                        // The first value in the color data is the gray value, from 0...10000.
                        gray = (int)(value1 / 39.0625);

                        results.Add(Color.FromArgb(gray, gray, gray));
                        break;

                    default:
                        throw new InvalidDataException(string.Format("Color space '{0}' not supported.", colorSpace));
                }

#if USENAMEHACK
        results.SetName(i, name);
#endif
            }

            return results;
        }

        protected virtual void WritePalette(Stream stream, ColourCollection palette, AdobePhotoshopColourSwatchFileVersion version, AdobePhotoshopColourSwatchColourSpace colorSpace)
        {
            int swatchIndex;

            this.WriteInt16(stream, (short)version);
            this.WriteInt16(stream, (short)palette.Count);

            swatchIndex = 0;

            foreach (Color colour in palette)
            {
                short value1;
                short value2;
                short value3;
                short value4;

                swatchIndex++;

                switch (colorSpace)
                {
                    case AdobePhotoshopColourSwatchColourSpace.RGB:
                        value1 = (short)(colour.R * 256);
                        value2 = (short)(colour.G * 256);
                        value3 = (short)(colour.B * 256);
                        value4 = 0;
                        break;
                    case AdobePhotoshopColourSwatchColourSpace.HSB:
                        value1 = (short)(colour.GetHue() * 182.04);
                        value2 = (short)(colour.GetSaturation() * 655.35);
                        value3 = (short)(colour.GetBrightness() * 655.35);
                        value4 = 0;
                        break;
                    case AdobePhotoshopColourSwatchColourSpace.GreyScale:
                        if (colour.R == colour.G && colour.R == colour.B)
                        {
                            // already grayscale
                            value1 = (short)(colour.R * 39.0625);
                        }
                        else
                        {
                            // color is not grayscale, convert
                            value1 = (short)((colour.R + colour.G + colour.B) / 3.0 * 39.0625);
                        }
                        value2 = 0;
                        value3 = 0;
                        value4 = 0;
                        break;
                    default:
                        throw new InvalidOperationException("Color space not supported.");
                }

                this.WriteInt16(stream, (short)colorSpace);
                this.WriteInt16(stream, value1);
                this.WriteInt16(stream, value2);
                this.WriteInt16(stream, value3);
                this.WriteInt16(stream, value4);

                if (version == AdobePhotoshopColourSwatchFileVersion.VersionTwo)
                {
                    string name;

#if USENAMEHACK
          name = palette.GetName(swatchIndex - 1);
          if (string.IsNullOrEmpty(name))
          {
            name = string.Format("Swatch {0}", swatchIndex);
          }
#else
                    name = colour.IsNamedColor ? colour.Name : string.Format("Swatch {0}", swatchIndex);
#endif

                    this.WriteInt32(stream, name.Length);
                    this.WriteString(stream, name);
                }
            }
        }

        #endregion
    }
}