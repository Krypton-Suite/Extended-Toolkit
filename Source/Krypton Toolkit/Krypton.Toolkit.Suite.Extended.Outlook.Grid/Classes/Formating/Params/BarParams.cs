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
        public object Clone() => MemberwiseClone();

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

