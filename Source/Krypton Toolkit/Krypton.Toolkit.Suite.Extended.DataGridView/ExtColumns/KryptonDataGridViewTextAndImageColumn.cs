#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// Hosts a collection of KryptonDataGridViewTextAndImageCell cells.
    /// </summary>
    public class KryptonDataGridViewTextAndImageColumn : DataGridViewColumn
    {
        #region Instance Fields

        private Image imageValue;

        #endregion

        #region Events
        /// <summary>
        /// Occurs when the user clicks a button spec.
        /// </summary>
        public event EventHandler<DataGridViewButtonSpecClickEventArgs> ButtonSpecClick;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonDataGridViewTextBoxColumn class.
        /// </summary>
        public KryptonDataGridViewTextAndImageColumn()
            : base(new KryptonDataGridViewTextAndImageCell())
        {
            ButtonSpecs = new DataGridViewColumnSpecCollection(this);
            SortMode = DataGridViewColumnSortMode.Automatic;
        }

        /// <summary>
        /// Returns a String that represents the current Object.
        /// </summary>
        /// <returns>A String that represents the current Object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(0x40);
            builder.Append("KryptonDataGridViewTextAndImageColumn { Name=");
            builder.Append(Name);
            builder.Append(", Index=");
            builder.Append(Index.ToString(CultureInfo.CurrentCulture));
            builder.Append(" }");
            return builder.ToString();
        }

        /// <summary>
        /// Create a cloned copy of the column.
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            KryptonDataGridViewTextAndImageColumn cloned = base.Clone() as KryptonDataGridViewTextAndImageColumn;
            cloned.imageValue = imageValue;
            cloned.ImageSize = ImageSize;
            // Move the button specs over to the new clone
            foreach (ButtonSpec bs in ButtonSpecs)
            {
                cloned.ButtonSpecs.Add(bs.Clone());
            }

            return cloned;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }

            base.Dispose(disposing);
        }
        #endregion

        #region Public

        ///// <summary>
        ///// Gets or Sets the image
        ///// </summary>
        //public Image Image
        //{
        //    get { return this.imageValue; }
        //    set
        //    {
        //        if (this.Image != value)
        //        {
        //            this.imageValue = value;
        //            this.imageSize = value.Size;
        //            if (this.InheritedStyle != null)
        //            {
        //                Padding inheritedPadding = this.InheritedStyle.Padding;
        //                this.InheritedStyle.Padding = new Padding(imageSize.Width + 2, inheritedPadding.Top, inheritedPadding.Right, inheritedPadding.Bottom);
        //                //Padding inheritedPadding = this.InheritedStyle.Padding;
        //                //this.Style.Padding = new Padding(18, inheritedPadding.Top, inheritedPadding.Right, inheritedPadding.Bottom);

        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Gets or sets the maximum number of characters that can be entered into the text box.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(int), "32767")]
        public int MaxInputLength
        {
            get
            {
                if (TextBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("KryptonDataGridViewTextAndImageColumn cell template required");
                }

                return TextBoxCellTemplate.MaxInputLength;
            }

            set
            {
                if (MaxInputLength != value)
                {
                    TextBoxCellTemplate.MaxInputLength = value;
                    if (DataGridView != null)
                    {
                        DataGridViewRowCollection rows = DataGridView.Rows;
                        int count = rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            DataGridViewTextBoxCell cell = rows.SharedRow(i).Cells[Index] as DataGridViewTextBoxCell;
                            if (cell != null)
                            {
                                cell.MaxInputLength = value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the sort mode for the column.
        /// </summary>
        [DefaultValue(typeof(DataGridViewColumnSortMode), "Automatic")]
        public new DataGridViewColumnSortMode SortMode
        {
            get => base.SortMode;
            set => base.SortMode = value;
        }

        /// <summary>
        /// Gets or sets the template used to model cell appearance.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DataGridViewCell CellTemplate
        {
            get => base.CellTemplate;

            set
            {
                if ((value != null) && !(value is KryptonDataGridViewTextAndImageCell))
                {
                    throw new InvalidCastException("Can only assign a object of type KryptonDataGridViewTextAndImageCell");
                }

                base.CellTemplate = value;
            }
        }

        /// <summary>
        /// Gets the collection of the button specifications.
        /// </summary>
        [Category("Data")]
        [Description("Set of extra button specs to appear with control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DataGridViewColumnSpecCollection ButtonSpecs { get; }

        #endregion

        #region Private
        private KryptonDataGridViewTextAndImageCell TextBoxCellTemplate => (KryptonDataGridViewTextAndImageCell)CellTemplate;

        #endregion

        #region Internal
        internal void PerformButtonSpecClick(DataGridViewButtonSpecClickEventArgs args)
        {
            ButtonSpecClick?.Invoke(this, args);
        }

        internal Size ImageSize { get; private set; }

        #endregion
    }

    /// <summary>
    /// Class for TextAndImage object
    /// </summary>
    public class TextAndImage : IComparable<TextAndImage>
    {
        /// <summary>
        /// The text
        /// </summary>
        public string Text;
        /// <summary>
        /// The image
        /// </summary>
        public Image Image;

        /// <summary>
        /// Constructor
        /// </summary>
        public TextAndImage()
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="img">The image.</param>
        public TextAndImage(string text, Image img)
        {
            Text = text;
            Image = img;
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
            return Text.Equals(obj?.ToString());
        }

        /// <summary>
        /// Overrides GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public int CompareTo(TextAndImage other)
        {
            return Text.CompareTo(other.Text);
        }
    }

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
        {
        }

        /// <summary>
        /// Overrides ValueType
        /// </summary>
        public override Type ValueType => typeof(TextAndImage);

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        protected override bool SetValue(int rowIndex, object value)
        {
            if (value != null)
            {
                Image = ((TextAndImage)value).Image;
            }

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
            get => imageValue;
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
            if (((TextAndImage)Value)?.Image != null)
            {
                //Padding inheritedPadding = this.InheritedStyle.Padding;
                //this.Style.Padding = new Padding(18, inheritedPadding.Top, inheritedPadding.Right, inheritedPadding.Bottom);
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