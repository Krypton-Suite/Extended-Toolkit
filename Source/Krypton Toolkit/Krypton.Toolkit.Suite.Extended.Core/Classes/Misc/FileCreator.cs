#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.IO;

using Krypton.Toolkit.Suite.Extended.Core.Resources;

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