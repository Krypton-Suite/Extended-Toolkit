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
    /// Public class for the underlying editing control
    /// </summary>
    [ToolboxItem(false)]
    public class PercentageEditingControl : DataGridViewTextBoxEditingControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PercentageEditingControl()
            : base()
        {
        }

        /// <summary>
        /// Returns if the character is a valid digit
        /// </summary>
        /// <param name="c">The character.</param>
        /// <returns>True if valid digit, false otherwise.</returns>
        private bool IsValidForNumberInput(char c)
        {
            return Char.IsDigit(c);
            // OrElse c = Chr(8) OrElse c = "."c OrElse c = "-"c OrElse c = "("c OrElse c = ")"c
        }

        /// <summary>
        /// Overrides onKeypPress
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!IsValidForNumberInput(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}