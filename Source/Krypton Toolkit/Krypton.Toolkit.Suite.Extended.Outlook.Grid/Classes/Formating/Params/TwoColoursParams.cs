#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

//--------------------------------------------------------------------------------
// Copyright (C) 2013-2021 JDH Software - <support@jdhsoftware.com>
//
// This program is provided to you under the terms of the Microsoft Public
// License (Ms-PL) as published at https://github.com/Cocotteseb/Krypton-OutlookGrid/blob/master/LICENSE.md
//
// Visit https://www.jdhsoftware.com and follow @jdhsoftware on Twitter
//
//--------------------------------------------------------------------------------
#endregion

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
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
            writer.WriteElementString("MinimumColor", MinimumColour.ToArgb().ToString());
            writer.WriteElementString("MaximumColor", MaximumColour.ToArgb().ToString());
        }
    }
}
