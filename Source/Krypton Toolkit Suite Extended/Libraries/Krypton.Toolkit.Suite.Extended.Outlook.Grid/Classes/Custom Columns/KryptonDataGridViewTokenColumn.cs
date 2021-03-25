﻿#region MS-PL License
/*
* Copyright (C) 2013 - 2018 JDH Software - <support@jdhsoftware.com>
*
* This program is provided to you under the terms of the Microsoft Public
* License (Ms-PL) as published at https://kryptonoutlookgrid.codeplex.com/license
*
* Visit http://www.jdhsoftware.com and follow @jdhsoftware on Twitter
*/
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
            this.Text = text;
            this.BackColour = bg;
            this.ForeColour = fg;
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
        public int CompareTo(Token other)
        {
            return this.Text.CompareTo(other.Text);
        }

        /// <summary>
        /// Overrides ToString
        /// </summary>
        /// <returns>String that represents TextAndImage</returns>
        public override string ToString()
        {
            return Text;
        }

        /// <summary>
        /// Overrides Equals
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>true if equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return this.Text.Equals(obj.ToString());
        }

        /// <summary>
        /// Overrides GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

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
            this.ValueType = typeof(TokenCell);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            Token tok = (Token)this.Value;
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
            float factorX = graphics.DpiX > 96 ? (1f * graphics.DpiX / 96) : 1f;
            float factorY = graphics.DpiY > 96 ? (1f * graphics.DpiY / 96) : 1f;

            int nextPosition = cellBounds.X + (int)(1 * factorX);
            Font f = KryptonManager.CurrentGlobalPalette.GetContentShortTextFont(PaletteContentStyle.GridDataCellList, PaletteState.Normal);

            Token tok = (Token)this.Value;
            if (tok != null)
            {
                Rectangle rectangle = new Rectangle();
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
            float factorX = graphics.DpiX > 96 ? (1f * graphics.DpiX / 96) : 1f;
            float factorY = graphics.DpiY > 96 ? (1f * graphics.DpiY / 96) : 1f;

            Size tmpSize = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
            Font f = KryptonManager.CurrentGlobalPalette.GetContentShortTextFont(PaletteContentStyle.GridDataCellList, PaletteState.Normal);
            int nextPosition = (int)(1 * factorX);
            if (this.Value != null)
            {
                Token tok = (Token)this.Value;
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
        protected override void OnContentClick(DataGridViewCellEventArgs e)
        {
            base.OnContentClick(e);
        }

        #region Invalidate cells when mouse moves or leaves the cell

        /// <summary>
        /// Overrides OnMouseLeave
        /// </summary>
        /// <param name="rowIndex">the row that contains the cell.</param>
        protected override void OnMouseLeave(int rowIndex)
        {
            base.OnMouseLeave(rowIndex);
        }

        /// <summary>
        /// Overrides OnMouseMove
        /// </summary>
        /// <param name="e">A DataGridViewCellMouseEventArgs that contains the event data.</param>
        protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseMove(e);
        }
        #endregion
    }

    /// <summary>
    /// Class for a rating celle
    /// </summary>
    public class TokenListCell : KryptonDataGridViewTextBoxCell
    {
        //List<Token> TokenList;
        /// <summary>
        /// Constructor
        /// </summary>
        public TokenListCell()
            : base()
        {
            //Value type is an integer. 
            //Formatted value type is an image since we derive from the ImageCell 
            this.ValueType = typeof(List<TokenListCell>);
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
            float factorX = graphics.DpiX > 96 ? (1f * graphics.DpiX / 96) : 1f;
            float factorY = graphics.DpiY > 96 ? (1f * graphics.DpiY / 96) : 1f;

            int nextPosition = cellBounds.X + (int)(1 * factorX);
            Font f = KryptonManager.CurrentGlobalPalette.GetContentShortTextFont(PaletteContentStyle.GridDataCellList, PaletteState.Normal);

            foreach (Token tok in (List<Token>)this.Value)
            {
                Rectangle rectangle = new Rectangle();
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
            float factorX = graphics.DpiX > 96 ? (1f * graphics.DpiX / 96) : 1f;
            float factorY = graphics.DpiY > 96 ? (1f * graphics.DpiY / 96) : 1f;

            Size tmpSize = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
            Font f = KryptonManager.CurrentGlobalPalette.GetContentShortTextFont(PaletteContentStyle.GridDataCellList, PaletteState.Normal);
            int nextPosition = (int)(1 * factorX);
            if (this.Value != null)
            {
                foreach (Token tok in (List<Token>)this.Value)
                {
                    Size s = TextRenderer.MeasureText(tok.Text, f);
                    nextPosition += s.Width + (int)(10 * factorX) + (int)(5 * factorX);
                }
                tmpSize.Width = nextPosition;
            }
            return tmpSize;
        }

        /// <summary>
        /// Update cell's value when the user clicks on a star 
        /// </summary>
        /// <param name="e">A DataGridViewCellEventArgs that contains the event data.</param>
        protected override void OnContentClick(DataGridViewCellEventArgs e)
        {
            base.OnContentClick(e);
        }

        #region Invalidate cells when mouse moves or leaves the cell

        /// <summary>
        /// Overrides OnMouseLeave
        /// </summary>
        /// <param name="rowIndex">the row that contains the cell.</param>
        protected override void OnMouseLeave(int rowIndex)
        {
            base.OnMouseLeave(rowIndex);
        }

        /// <summary>
        /// Overrides OnMouseMove
        /// </summary>
        /// <param name="e">A DataGridViewCellMouseEventArgs that contains the event data.</param>
        protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseMove(e);
        }
        #endregion
    }

    /// <summary>
    /// Class for a rating column
    /// </summary>
    public class KryptonDataGridViewTokenColumn : KryptonDataGridViewTextBoxColumn
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public KryptonDataGridViewTokenColumn()
            : base()
        {
            this.CellTemplate = new TokenCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(TokenCell);
        }
    }

    /// <summary>
    /// Class for a rating column
    /// </summary>
    public class KryptonDataGridViewTokenListColumn : KryptonDataGridViewTextBoxColumn
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public KryptonDataGridViewTokenListColumn()
            : base()
        {
            this.CellTemplate = new TokenListCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(List<TokenListCell>);
        }
    }
}