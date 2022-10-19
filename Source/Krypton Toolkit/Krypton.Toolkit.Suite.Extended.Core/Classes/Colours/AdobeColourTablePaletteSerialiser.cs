﻿#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Core
{
    /// <summary>
    /// Serializes and deserializes 8bit color palettes from raw byte data.
    /// </summary>
    public class AdobeColourTablePaletteSerialiser : PaletteSerialiser
    {
        #region Properties

        /// <summary>
        /// Gets the default extension for files generated with this palette format.
        /// </summary>
        /// <value>The default extension for files generated with this palette format.</value>
        public override string DefaultExtension => "act";

        /// <summary>
        /// Gets the maximum number of colors supported by this format.
        /// </summary>
        /// <value>
        /// The maximum value number of colors supported by this format.
        /// </value>
        public override int Maximum => 256;

        /// <summary>
        /// Gets the minimum numbers of colors supported by this format.
        /// </summary>
        /// <value>
        /// The minimum number of colors supported by this format.
        /// </value>
        public override int Minimum => 1;

        /// <summary>
        /// Gets a descriptive name of the palette format
        /// </summary>
        /// <value>The descriptive name of the palette format.</value>
        public override string Name => "Adobe Color Table";

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
                result = stream.Length == 768 || stream.Length == 772;
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
            ColourCollection results;
            int count;

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            results = new ColourCollection();

            count = (int)(stream.Length / 3);

            for (int i = 0; i < count; i++)
            {
                int r;
                int g;
                int b;

                r = stream.ReadByte();
                g = stream.ReadByte();
                b = stream.ReadByte();

                results.Add(Color.FromArgb(r, g, b));
            }

            if (count == 257)
            {
                int realCount;

                // undocumented on the spec page, but when poking around
                // the Optimized Colors preset files of CS2, I found that
                // four extra bytes were added to some files. The second of
                // these extra bytes specified how many colours are
                // really in use (anything else is just padding)

                realCount = results[256].G;

                while (results.Count > realCount)
                {
                    results.RemoveAt(realCount);
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
            int count = 0;

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (palette == null)
            {
                throw new ArgumentNullException(nameof(palette));
            }

            count = palette.Count;

            if (count > 256)
            {
                throw new InvalidDataException("A maximum of 255 colors are supported by this format.");
            }

            foreach (Color colour in palette)
            {
                stream.WriteByte(colour.R);
                stream.WriteByte(colour.G);
                stream.WriteByte(colour.B);
            }

            if (count < 256)
            {
                // add padding
                for (int i = count; i < 256; i++)
                {
                    stream.WriteByte(0);
                    stream.WriteByte(0);
                    stream.WriteByte(0);
                }

                // add an extra four bytes which seem to describe the number
                // of used colours
                stream.WriteByte(0);
                stream.WriteByte((byte)count);
                stream.WriteByte(0);
                stream.WriteByte(0);
            }

            stream.Flush();
        }

        #endregion
    }
}