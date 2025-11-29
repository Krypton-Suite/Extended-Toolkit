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

namespace Krypton.Toolkit.Suite.Extended.Core;

/// <summary>
/// Serializes and deserializes color palettes into and from the Gimp palette format.
/// </summary>
public class GimpPaletteSerialiser : PaletteSerialiser
{
    #region Properties

    /// <summary>
    /// Gets the default extension for files generated with this palette format.
    /// </summary>
    /// <value>The default extension for files generated with this palette format.</value>
    public override string DefaultExtension => "gpl";

    /// <summary>
    /// Gets a descriptive name of the palette format
    /// </summary>
    /// <value>The descriptive name of the palette format.</value>
    public override string Name => "GIMP Palette";

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

                header = reader.ReadLine();

                result = header == "GIMP Palette";
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
            string header;
            int swatchIndex;
            bool readingPalette;

            readingPalette = false;

            // check signature
            header = reader.ReadLine();

            if (header != "GIMP Palette")
            {
                throw new InvalidDataException("Invalid palette file");
            }

            // read the swatches
            swatchIndex = 0;

            while (!reader.EndOfStream)
            {
                string data;

                data = reader.ReadLine();

                if (!string.IsNullOrEmpty(data))
                {
                    if (data[0] == '#')
                    {
                        // comment
                        readingPalette = true;
                    }
                    else if (!readingPalette)
                    {
                        // custom attribute
                    }
                    else if (readingPalette)
                    {
                        int r;
                        int g;
                        int b;
                        string[] parts;
                        string name;

                        // TODO: Optimize this a touch. Microoptimization? Maybe.

                        parts = !string.IsNullOrEmpty(data) ? data.Split([
                            ' ',
                            '\t'
                        ], StringSplitOptions.RemoveEmptyEntries) : [];
                        name = parts.Length > 3 ? string.Join(" ", parts, 3, parts.Length - 3) : null;

                        if (!int.TryParse(parts[0], out r) || !int.TryParse(parts[1], out g) || !int.TryParse(parts[2], out b))
                        {
                            throw new InvalidDataException($"Invalid palette contents found with data '{data}'");
                        }

                        results.Add(Color.FromArgb(r, g, b));
#if USENAMEHACK
              results.SetName(swatchIndex, name);
#endif

                        swatchIndex++;
                    }
                }
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
        int swatchIndex;

        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (palette == null)
        {
            throw new ArgumentNullException(nameof(palette));
        }

        swatchIndex = 0;

        // TODO: Allow name and columns attributes to be specified

        using (StreamWriter writer = new(stream, Encoding.ASCII))
        {
            writer.WriteLine("GIMP Palette");
            writer.WriteLine("Name: ");
            writer.WriteLine("Columns: 8");
            writer.WriteLine("#");

            foreach (Color colour in palette)
            {
                writer.Write("{0,-3} ", colour.R);
                writer.Write("{0,-3} ", colour.G);
                writer.Write("{0,-3} ", colour.B);
#if USENAMEHACK
          writer.Write(palette.GetName(swatchIndex));
#else
                if (colour.IsNamedColor)
                {
                    writer.Write(colour.Name);
                }
                else
                {
                    writer.Write("#{0:X2}{1:X2}{2:X2} Swatch {3}", colour.R, colour.G, colour.B, swatchIndex);
                }
#endif
                writer.WriteLine();

                swatchIndex++;
            }
        }
    }

    #endregion
}