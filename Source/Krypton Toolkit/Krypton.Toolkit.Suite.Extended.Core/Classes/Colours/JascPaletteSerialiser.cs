#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.IO;
using System.Text;

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
        public override string DefaultExtension
        {
            get { return "pal"; }
        }

        /// <summary>
        /// Gets a descriptive name of the palette format
        /// </summary>
        /// <value>The descriptive name of the palette format.</value>
        public override string Name
        {
            get { return "JASC Palette"; }
        }

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
                using (StreamReader reader = new StreamReader(stream))
                {
                    string header;
                    string version;

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

            results = new ColourCollection();

            using (StreamReader reader = new StreamReader(stream))
            {
                string header;
                string version;
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
                    string data;
                    string[] parts;

                    data = reader.ReadLine();
                    parts = !string.IsNullOrEmpty(data) ? data.Split(new[]
                                                                     {
                                                             ' ',
                                                             '\t'
                                                           }, StringSplitOptions.RemoveEmptyEntries) : new string[0];

                    if (!int.TryParse(parts[0], out r) || !int.TryParse(parts[1], out g) || !int.TryParse(parts[2], out b))
                    {
                        throw new InvalidDataException(string.Format("Invalid palette contents found with data '{0}'", data));
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
                throw new ArgumentNullException(nameof(stream));
            }

            if (palette == null)
            {
                throw new ArgumentNullException(nameof(palette));
            }

            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
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