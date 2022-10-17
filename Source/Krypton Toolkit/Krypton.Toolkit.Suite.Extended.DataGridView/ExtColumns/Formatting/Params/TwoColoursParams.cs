#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// Two scale color class parameters
    /// </summary>
    /// <seealso cref="IFormatParams" />
    public class TwoColoursParams : IFormatParams
    {
        /// <summary>
        /// Minimum color
        /// </summary>
        public Color MinimumColour;
        /// <summary>
        /// Maximum color
        /// </summary>
        public Color MaximumColour;
        /// <summary>
        /// Color associated to the value between min and max color
        /// </summary>
        public Color ValueColour;

        /// <summary>
        /// Initializes a new instance of the <see cref="TwoColoursParams"/> class.
        /// </summary>
        /// <param name="minColour">The minimum color.</param>
        /// <param name="maxColour">The maximum color.</param>
        public TwoColoursParams(Color minColour, Color maxColour)
        {
            MinimumColour = minColour;
            MaximumColour = maxColour;
        }

        /// <summary>
        /// Crée un objet qui est une copie de l'instance actuelle.
        /// </summary>
        /// <returns>
        /// Nouvel objet qui est une copie de cette instance.
        /// </returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Persists the parameters.
        /// </summary>
        /// <param name="writer">The XML writer.</param>
        public void Persist(XmlWriter writer)
        {
            writer.WriteElementString("MinimumColour", MinimumColour.ToArgb().ToString());
            writer.WriteElementString("MaximumColour", MaximumColour.ToArgb().ToString());
        }
    }
}