﻿#region BSD License
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
    /// Class for a Token cell
    /// </summary>
    public class TokenCell : KryptonDataGridViewTextBoxCell
    {
        //List<Token> TokenList;
        /// <summary>
        /// Constructor
        /// </summary>
        public TokenCell()
            : base()
        {
            //Value type is an integer. 
            //Formatted value type is an image since we derive from the ImageCell 
            ValueType = typeof(TokenCell);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            Token tok = (Token)Value;
            if (tok != null)
            {
                return tok.Text;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Overrides Paint
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="clipBounds"></param>
        /// <param name="cellBounds"></param>
        /// <param name="rowIndex"></param>
        /// <param name="elementState"></param>
        /// <param name="value"></param>
        /// <param name="formattedValue"></param>
        /// <param name="errorText"></param>
        /// <param name="cellStyle"></param>
        /// <param name="advancedBorderStyle"></param>
        /// <param name="paintParts"></param>
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            float factorX = graphics.DpiX > 96 ? 1f * graphics.DpiX / 96 : 1f;
            float factorY = graphics.DpiY > 96 ? 1f * graphics.DpiY / 96 : 1f;

            int nextPosition = cellBounds.X + (int)(1 * factorX);
            Font f = KryptonManager.CurrentGlobalPalette.GetContentShortTextFont(PaletteContentStyle.GridDataCellList, PaletteState.Normal);

            Token tok = (Token)Value;
            if (tok != null)
            {
                Rectangle rectangle = new();
                Size s = TextRenderer.MeasureText(tok.Text, f);
                rectangle.Width = s.Width + (int)(10 * factorX);
                rectangle.X = nextPosition;
                rectangle.Y = cellBounds.Y + (int)(2 * factorY);
                rectangle.Height = (int)(17 * factorY);
                nextPosition += rectangle.Width + (int)(5 * factorX);

                graphics.FillRectangle(new SolidBrush(tok.BackColour), rectangle);
                TextRenderer.DrawText(graphics, tok.Text, f, rectangle, tok.ForeColour);
            }
        }

        /// <summary>
        /// Overrides GetPreferredSize
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="cellStyle"></param>
        /// <param name="rowIndex"></param>
        /// <param name="constraintSize"></param>
        /// <returns></returns>
        protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
        {
            float factorX = graphics.DpiX > 96 ? 1f * graphics.DpiX / 96 : 1f;
            float factorY = graphics.DpiY > 96 ? 1f * graphics.DpiY / 96 : 1f;

            Size tmpSize = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
            Font f = KryptonManager.CurrentGlobalPalette.GetContentShortTextFont(PaletteContentStyle.GridDataCellList, PaletteState.Normal);
            int nextPosition = (int)(1 * factorX);
            if (Value != null)
            {
                Token tok = (Token)Value;
                Size s = TextRenderer.MeasureText(tok.Text, f);
                nextPosition += s.Width + (int)(10 * factorX) + (int)(5 * factorX);

                tmpSize.Width = nextPosition;
            }
            return tmpSize;
        }

        /// <summary>
        /// Update cell's value when the user clicks on a star 
        /// </summary>
        /// <param name="e">A DataGridViewCellEventArgs that contains the event data.</param>
        protected override void OnContentClick(DataGridViewCellEventArgs e) => base.OnContentClick(e);

        #region Invalidate cells when mouse moves or leaves the cell

        /// <summary>
        /// Overrides OnMouseLeave
        /// </summary>
        /// <param name="rowIndex">the row that contains the cell.</param>
        protected override void OnMouseLeave(int rowIndex) => base.OnMouseLeave(rowIndex);

        /// <summary>
        /// Overrides OnMouseMove
        /// </summary>
        /// <param name="e">A DataGridViewCellMouseEventArgs that contains the event data.</param>
        protected override void OnMouseMove(DataGridViewCellMouseEventArgs e) => base.OnMouseMove(e);
        #endregion
    }
}