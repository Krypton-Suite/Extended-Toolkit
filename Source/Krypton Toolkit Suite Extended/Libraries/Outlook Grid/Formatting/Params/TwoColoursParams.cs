//--------------------------------------------------------------------------------
// Copyright (C) 2013-2015 JDH Software - <support@jdhsoftware.com>
//
// This program is provided to you under the terms of the Microsoft Public
// License (Ms-PL) as published at https://kryptonoutlookgrid.codeplex.com/license
//
// Visit http://www.jdhsoftware.com and follow @jdhsoftware on Twitter
//
//--------------------------------------------------------------------------------

using System.Drawing;
using System.Xml;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Two scale colour class parameters
    /// </summary>
    /// <seealso cref="IFormatParams" />
    public class TwoColoursParams : IFormatParams
    {
        /// <summary>
        /// Minimum colour
        /// </summary>
        public Color MinimumColour;
        /// <summary>
        /// Maximum colour
        /// </summary>
        public Color MaximumColour;
        /// <summary>
        /// Colour associated to the value between min and max color
        /// </summary>
        public Color ValueColour;

        /// <summary>
        /// Initializes a new instance of the <see cref="TwoColoursParams"/> class.
        /// </summary>
        /// <param name="minColour">The minimum colour.</param>
        /// <param name="maxColour">The maximum colour.</param>
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