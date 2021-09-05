﻿namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Class for a TextAndImage cell
    /// </summary>
    public class KryptonDataGridViewTextAndImageCell : KryptonDataGridViewTextBoxCell
    {
        private Image imageValue;
        private Size imageSize;

        /// <summary>
        /// Constructor
        /// </summary>
        public KryptonDataGridViewTextAndImageCell()
            : base()
        {
        }

        /// <summary>
        /// Overrides ValueType
        /// </summary>
        public override Type ValueType
        {
            get { return typeof(TextAndImage); }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        protected override bool SetValue(int rowIndex, object value)
        {
            if (value != null && !((OutlookGridRow)OwningRow).IsGroupRow) //Test to catch crash when first column is text and image when grouping
                Image = ((TextAndImage)value).Image;
            return base.SetValue(rowIndex, value);
        }

        /// <summary>
        /// Overrides Clone
        /// </summary>
        /// <returns>The cloned KryptonDataGridViewTextAndImageCell</returns>
        public override object Clone()
        {
            KryptonDataGridViewTextAndImageCell c = base.Clone() as KryptonDataGridViewTextAndImageCell;
            c.imageValue = imageValue;
            c.imageSize = imageSize;
            return c;
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public Image Image
        {
            get { return imageValue; }
            set
            {
                if (Image != value)
                {
                    imageValue = value;
                    imageSize = value.Size;

                    //if (this.InheritedStyle != null)
                    //{
                    Padding inheritedPadding = Style.Padding;
                    //Padding inheritedPadding = this.InheritedStyle.Padding;
                    Style.Padding = new Padding(imageSize.Width + 2,
                        inheritedPadding.Top, inheritedPadding.Right,
                        inheritedPadding.Bottom);
                    //}
                }
            }
        }

        /// <summary>
        /// Overrides Paint
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="clipBounds"></param>
        /// <param name="cellBounds"></param>
        /// <param name="rowIndex"></param>
        /// <param name="cellState"></param>
        /// <param name="value"></param>
        /// <param name="formattedValue"></param>
        /// <param name="errorText"></param>
        /// <param name="cellStyle"></param>
        /// <param name="advancedBorderStyle"></param>
        /// <param name="paintParts"></param>
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            //TODO : improve we assume it is a 16x16 image 
            if (Value != null && ((TextAndImage)Value).Image != null)
            {
                Padding inheritedPadding = Style.Padding;
                Style.Padding = new Padding(imageSize.Width + 2,
                    inheritedPadding.Top, inheritedPadding.Right,
                    inheritedPadding.Bottom);
                //To be in phase with highlight feature who forces the style.

                // Draw the image clipped to the cell.
                System.Drawing.Drawing2D.GraphicsContainer container = graphics.BeginContainer();
                graphics.SetClip(cellBounds);
                graphics.DrawImage(((TextAndImage)Value).Image, new Rectangle(cellBounds.Location.X + 2, cellBounds.Location.Y + ((cellBounds.Height - 16) / 2) - 1, 16, 16));
                graphics.EndContainer(container);
            }

            // Paint the base content
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }
    }
}