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

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// Class for a KryptonDataGridViewFormattingColumn : KryptonDataGridViewTextBoxColumn with conditional formatting abilities
    /// </summary>
    /// <seealso cref="KryptonDataGridViewTextBoxColumn" />
    public class KryptonDataGridViewFormattingColumn : KryptonDataGridViewTextBoxColumn
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonDataGridViewFormattingColumn"/> class.
        /// </summary>
        public KryptonDataGridViewFormattingColumn()
        {
            CellTemplate = new FormattingCell();
            DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ValueType = typeof(FormattingCell);
            ContrastTextColour = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [contrast text color].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [contrast text color]; otherwise, <c>false</c>.
        /// </value>
        public bool ContrastTextColour { get; set; }
    }

    /// <summary>
    /// Formatting cell
    /// </summary>
    /// <seealso cref="Krypton.Toolkit.KryptonDataGridViewTextBoxCell" />
    public class FormattingCell : KryptonDataGridViewTextBoxCell
    {

        /// <summary>
        /// Gets or sets the type of the format.
        /// </summary>
        /// <value>
        /// The type of the format.
        /// </value>
        public EnumConditionalFormatType FormatType { get; set; }

        /// <summary>
        /// Gets or sets the format parameters.
        /// </summary>
        /// <value>
        /// The format parameters.
        /// </value>
        public IFormatParams FormatParams { get; set; }
        
        /// <summary>
        /// Contrasts the color.
        /// </summary>
        /// <param name="colour">The color.</param>
        /// <returns></returns>
        private static Color ContrastColour(Color colour)
        {
            //  Counting the perceptive luminance - human eye favors green color... 
            double a = (1 - (((0.299 * colour.R) + ((0.587 * colour.G) + (0.114 * colour.B)))
                             / 255));
            var d = a < 0.5 ? 0 : 255;

            //  dark colors - white font
            return Color.FromArgb(d, d, d);
        }

        /// <summary>
        /// Paints the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="clipBounds">The clip bounds.</param>
        /// <param name="cellBounds">The cell bounds.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="cellState">State of the cell.</param>
        /// <param name="value">The value.</param>
        /// <param name="formattedValue">The formatted value.</param>
        /// <param name="errorText">The error text.</param>
        /// <param name="cellStyle">The cell style.</param>
        /// <param name="advancedBorderStyle">The advanced border style.</param>
        /// <param name="paintParts">The paint parts.</param>
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, 
            DataGridViewElementStates cellState, object value, object formattedValue, string errorText, 
            DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
        {
            if (FormatParams != null)  // null can happen when cell set to Formatting but no condition has been set !
            {
                switch (FormatType)
                {
                    case EnumConditionalFormatType.Bar:
                        int barWidth;
                        BarParams par = (BarParams)FormatParams;
                        barWidth = (int)((cellBounds.Width - 10) * par.ProportionValue);
                        Style.BackColor = DataGridView.DefaultCellStyle.BackColor;
                        Style.ForeColor = DataGridView.DefaultCellStyle.ForeColor;

                        if (barWidth > 0) //(double)value > 0 &&
                        {
                            Rectangle r = new(cellBounds.X + 3, cellBounds.Y + 3, barWidth, cellBounds.Height - 8);
                            if (par.GradientFill)
                            {
                                using LinearGradientBrush linearBrush = new(r, par.BarColour, Color.White, LinearGradientMode.Horizontal);
                                graphics.FillRectangle(linearBrush, r);
                            }
                            else
                            {
                                using SolidBrush solidBrush = new(par.BarColour);
                                graphics.FillRectangle(solidBrush, r);
                            }

                            using Pen pen = new(par.BarColour);
                            graphics.DrawRectangle(pen, r);
                        }

                        break;
                    case EnumConditionalFormatType.TwoColoursRange:
                        TwoColoursParams twCpar = (TwoColoursParams)FormatParams;
                        Style.BackColor = twCpar.ValueColour;
                        //  if (ContrastTextColor)
                        Style.ForeColor = ContrastColour(twCpar.ValueColour);
                        break;
                    case EnumConditionalFormatType.ThreeColoursRange:
                        ThreeColoursParams thCpar = (ThreeColoursParams)FormatParams;
                        Style.BackColor = thCpar.ValueColour;
                        Style.ForeColor = ContrastColour(thCpar.ValueColour);
                        break;
                    default:
                        Style.BackColor = DataGridView.DefaultCellStyle.BackColor;
                        Style.ForeColor = DataGridView.DefaultCellStyle.ForeColor;
                        break;
                }
            }
            else
            {
                Style.BackColor = DataGridView.DefaultCellStyle.BackColor;
                Style.ForeColor = DataGridView.DefaultCellStyle.ForeColor;
            }

            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle,
            DataGridViewPaintParts.None | DataGridViewPaintParts.ContentForeground);
        }
    }
}