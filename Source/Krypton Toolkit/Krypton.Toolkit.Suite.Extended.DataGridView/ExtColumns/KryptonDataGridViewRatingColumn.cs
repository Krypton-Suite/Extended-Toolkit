#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// Class for a rating column
    /// </summary>
    public class KryptonDataGridViewRatingColumn : DataGridViewImageColumn
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public KryptonDataGridViewRatingColumn()
        {
            CellTemplate = new RatingCell();
            DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ValueType = typeof(int);
        }
    }

    /// <summary>
    /// Class for a rating celle
    /// </summary>
    public class RatingCell : DataGridViewImageCell
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RatingCell()
        {
            //Value type is an integer. 
            //Formatted value type is an image since we derive from the ImageCell 
            ValueType = typeof(int);
        }

        /// <summary>
        /// Overrides GetFormattedValue
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rowIndex"></param>
        /// <param name="cellStyle"></param>
        /// <param name="valueTypeConverter"></param>
        /// <param name="formattedValueTypeConverter"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override object? GetFormattedValue(object? value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter? valueTypeConverter, TypeConverter? formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value == null)
            {
                return null; //For example, it is also the case for group row...
            }
            else
            {
                return _starImages[(int)value];
            }
        }

        /// <summary>
        /// Overrides DefaultNewRowValue
        /// </summary>
        public override object DefaultNewRowValue =>
            //default new row to 3 stars 
            3;

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
            Image? cellImage = (Image)formattedValue;
            if (!ReadOnly)
            {
                if (DataGridView != null)
                {
                    int starNumber = GetStarFromMouse(cellBounds, DataGridView.PointToClient(Control.MousePosition));

                    if (starNumber != -1)
                    {
                        cellImage = _starHotImages[starNumber];
                    }
                }
            }
            // suppress painting of selection 
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, cellImage, errorText, cellStyle, advancedBorderStyle, paintParts & ~DataGridViewPaintParts.SelectionBackground);
        }

        /// <summary>
        /// Update cell's value when the user clicks on a star 
        /// </summary>
        /// <param name="e">A DataGridViewCellEventArgs that contains the event data.</param>
        protected override void OnContentClick(DataGridViewCellEventArgs e)
        {
            base.OnContentClick(e);
            if (!ReadOnly)
            {
                if (DataGridView != null)
                {
                    int starNumber = GetStarFromMouse(DataGridView.GetCellDisplayRectangle(DataGridView.CurrentCellAddress.X, DataGridView.CurrentCellAddress.Y, false), DataGridView.PointToClient(Control.MousePosition));

                    if (starNumber != -1)
                    {
                        Value = starNumber;
                    }
                }
            }
        }

        #region Invalidate cells when mouse moves or leaves the cell

        /// <summary>
        /// Overrides OnMouseLeave
        /// </summary>
        /// <param name="rowIndex">the row that contains the cell.</param>
        protected override void OnMouseLeave(int rowIndex)
        {
            base.OnMouseLeave(rowIndex);
            if (DataGridView != null)
            {
                DataGridView.InvalidateCell(this);
            }
        }

        /// <summary>
        /// Overrides OnMouseMove
        /// </summary>
        /// <param name="e">A DataGridViewCellMouseEventArgs that contains the event data.</param>
        protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (DataGridView != null)
            {
                DataGridView.InvalidateCell(this);
            }
        }
        #endregion

        #region Private Implementation

        static Image?[] _starImages;
        static Image?[] _starHotImages;
        const int Imagewidth = 58;

        private int GetStarFromMouse(Rectangle cellBounds, Point mouseLocation)
        {
            if (cellBounds.Contains(mouseLocation))
            {
                int mouseXRelativeToCell = mouseLocation.X - cellBounds.X;
                int imageXArea = cellBounds.Width / 2 - Imagewidth / 2;
                if (mouseXRelativeToCell + 4 < imageXArea || mouseXRelativeToCell >= imageXArea + Imagewidth)
                {
                    return -1;
                }
                else
                {
                    int oo = (int)Math.Round((float)(mouseXRelativeToCell - imageXArea + 2) / (float)Imagewidth * 10f, MidpointRounding.AwayFromZero);
                    if (oo is > 10 or < 0)
                    {
                        System.Diagnostics.Debugger.Break();
                    }

                    return oo;
                }
            }
            else
            {
                return -1;
            }
        }

        //setup star images 
        #region Load star images

        static RatingCell()
        {
            _starImages = new Image?[11];
            _starHotImages = new Image[11];
            var resources = new ComponentResourceManager(typeof(KryptonDataGridViewRatingColumn));

            // load normal stars 
            for (int i = 0; i <= 10; i++)
            {
                _starImages[i] = resources.GetObject($"star{i}") as Image;
            }

            // load hot normal stars 
            for (int i = 0; i <= 10; i++)
            {
                _starHotImages[i] = resources.GetObject($"starhot{i}") as Image;
            }
        }
        #endregion

        #endregion

    }
}