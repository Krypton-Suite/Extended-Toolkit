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
    /// Serialises and deserialises color palettes into and from the Jasc palette format.
    /// </summary>
    public class JascPaletteSerialiser : PaletteSerialiser
    {
        #region Properties

        /// <summary>
        /// Gets the default extension for files generated with this palette format.
        /// </summary>
        /// <value>The default extension for files generated with this palette format.</value>
        public override string DefaultExtension => "pal";

        /// <summary>
        /// Gets a descriptive name of the palette format
        /// </summary>
        /// <value>The descriptive name of the palette format.</value>
        public override string Name => "JASC Palette";

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
                using (StreamReader reader = new(stream))
                {
                    string? header;
                    string? version;

                    // check signature
                    header = reader.ReadLine();
                    version = reader.ReadLine();

                    result = header == "JASC-PAL" && version == "0100";
                }
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

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            results = [];

            using (StreamReader reader = new(stream))
            {
                string? header;
                string? version;
                int colorCount;

                // check signature
                header = reader.ReadLine();
                version = reader.ReadLine();

                if (header != "JASC-PAL" || version != "0100")
                {
                    throw new InvalidDataException("Invalid palette file");
                }

                colorCount = Convert.ToInt32(reader.ReadLine());
                for (int i = 0; i < colorCount; i++)
                {
                    int r;
                    int g;
                    int b;
                    string? data;
                    string[] parts;

                    data = reader.ReadLine();
                    parts = !string.IsNullOrEmpty(data) ? data.Split([
                        ' ',
                                                             '\t'
                    ], StringSplitOptions.RemoveEmptyEntries) : [];

                    if (!int.TryParse(parts[0], out r) || !int.TryParse(parts[1], out g) || !int.TryParse(parts[2], out b))
                    {
                        throw new InvalidDataException($"Invalid palette contents found with data '{data}'");
                    }

                    results.Add(Color.FromArgb(r, g, b));
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
            if (stream == null)
            {
#if !NETCOREAPP3_0_OR_GREATER
                throw new ArgumentNullException(nameof(stream));
#else
                ArgumentNullException.ThrowIfNull(stream);
#endif
            }

#if !NETCOREAPP3_0_OR_GREATER
            if (palette == null)
            {
                throw new ArgumentNullException(nameof(palette));
            }
#else
            ArgumentNullException.ThrowIfNull(palette);
#endif

            using (StreamWriter writer = new(stream, Encoding.UTF8))
            {
                writer.WriteLine("JASC-PAL");
                writer.WriteLine("0100");
                writer.WriteLine(palette.Count);
                foreach (Color color in palette)
                {
                    writer.Write("{0} ", color.R);
                    writer.Write("{0} ", color.G);
                    writer.Write("{0} ", color.B);
                    writer.WriteLine();
                }
            }
        }

        #endregion
    }
}