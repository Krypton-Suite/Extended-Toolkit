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
    /// Token object
    /// </summary>
    public class Token : IComparable<Token>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Token()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">Text of the token</param>
        /// <param name="bg">Background color</param>
        /// <param name="fg">Foreground text color</param>
        public Token(string text, Color bg, Color fg)
        {
            Text = text;
            
            BackColour = bg;

            ForeColour = fg;
        }

        /// <summary>
        /// Text of the token
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Background color
        /// </summary>
        public Color BackColour { get; set; }
        /// <summary>
        /// Foreground text color
        /// </summary>
        public Color ForeColour { get; set; }

        /// <summary>
        /// Compare a Token to another
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Token other) => Text.CompareTo(other.Text);

        /// <summary>
        /// Overrides ToString
        /// </summary>
        /// <returns>String that represents TextAndImage</returns>
        public override string ToString() => Text;

        /// <summary>
        /// Overrides Equals
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>true if equal, false otherwise.</returns>
        public override bool Equals(object obj) => Text.Equals(obj.ToString());

        /// <summary>
        /// Overrides GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => base.GetHashCode();
    }
}