﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;
using System.Xml;

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// Three scale color class parameters
    /// </summary>
    /// <seealso cref="IFormatParams" />
    public class ThreeColoursParams : IFormatParams
    {
        /// <summary>
        /// The minimum color
        /// </summary>
        public Color MinimumColour;
        /// <summary>
        /// The medium color
        /// </summary>
        public Color MediumColour;
        /// <summary>
        /// The maximum color
        /// </summary>
        public Color MaximumColour;
        /// <summary>
        /// The color associated to the value
        /// </summary>
        public Color ValueColour;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreeColoursParams"/> class.
        /// </summary>
        /// <param name="minColour">The minimum color.</param>
        /// <param name="mediumColour">Color of the medium.</param>
        /// <param name="maxColour">The maximum color.</param>
        public ThreeColoursParams(Color minColour, Color mediumColour, Color maxColour)
        {
            MinimumColour = minColour;
            MediumColour = mediumColour;
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
        void IFormatParams.Persist(XmlWriter writer)
        {
            writer.WriteElementString("MinimumColour", MinimumColour.ToArgb().ToString());
            writer.WriteElementString("MediumColour", MediumColour.ToArgb().ToString());
            writer.WriteElementString("MaximumColour", MaximumColour.ToArgb().ToString());
        }
    }
}