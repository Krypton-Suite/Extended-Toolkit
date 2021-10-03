﻿namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
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
}