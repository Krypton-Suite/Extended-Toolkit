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
    /// Parameters for Bar formatting
    /// </summary>
    /// <seealso cref="IFormatParams" />
    public class BarParams : IFormatParams
    {
        /// <summary>
        /// The bar color
        /// </summary>
        public Color BarColour;
        /// <summary>
        /// The gradient fill
        /// </summary>
        public bool GradientFill;
        /// <summary>
        /// The proportion value
        /// </summary>
        public double ProportionValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="BarParams"/> class.
        /// </summary>
        /// <param name="barColour">Color of the bar.</param>
        /// <param name="gradientFill">if set to <c>true</c> [gradient fill].</param>
        public BarParams(Color barColour, bool gradientFill)
        {
            BarColour = barColour;
            GradientFill = gradientFill;
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
            writer.WriteElementString("BarColour", BarColour.ToArgb().ToString());
            writer.WriteElementString("GradientFill", CommonHelper.BoolToString(GradientFill));
        }
    }
}