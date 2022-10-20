#region MIT License
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
    public class FileCreator
    {
        #region Variables

        #endregion

        #region Constructors
        public FileCreator()
        {

        }
        #endregion

        #region Methods
        public void GenerateNewFile(SimpleEditor editor) => editor.Text = string.Format(MiscellaneousResources.FreshFile, DateTime.Now.ToString());

        /// <summary>
        /// Writes the colour file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="darkestColour">The darkest colour.</param>
        /// <param name="mediumColour">The medium colour.</param>
        /// <param name="lightColour">The light colour.</param>
        /// <param name="lightestColour">The lightest colour.</param>
        public void WriteColourFile(string filePath, string darkestColour, string mediumColour, string lightColour, string lightestColour)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            StreamWriter writer = new StreamWriter(filePath);

            writer.WriteLine($"Darkest Colour: ({ darkestColour })");

            writer.WriteLine($"Medium Colour: ({ mediumColour })");

            writer.WriteLine($"Light Colour: ({ lightColour })");

            writer.WriteLine($"Lightest Colour: ({ lightestColour })");

            writer.Flush();

            writer.Dispose();
        }
        #endregion
    }
}