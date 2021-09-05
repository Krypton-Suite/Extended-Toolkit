namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Hosts a collection of KryptonDataGridViewTextAndImageCell cells.
    /// </summary>
    public class KryptonDataGridViewTextAndImageColumn : DataGridViewColumn
    {
        #region Instance Fields

        private DataGridViewColumnSpecCollection _buttonSpecs;
        private Image imageValue;
        private Size imageSize;

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
            _buttonSpecs = new DataGridViewColumnSpecCollection(this);
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
            builder.Append(base.Name);
            builder.Append(", Index=");
            builder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
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
            cloned.imageSize = imageSize;
            // Move the button specs over to the new clone
            foreach (ButtonSpec bs in ButtonSpecs)
                cloned.ButtonSpecs.Add(bs.Clone());

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
                    throw new InvalidOperationException("KryptonDataGridViewTextAndImageColumn cell template required");

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
                                cell.MaxInputLength = value;
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
            get { return base.SortMode; }
            set { base.SortMode = value; }
        }

        /// <summary>
        /// Gets or sets the template used to model cell appearance.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }

            set
            {
                if ((value != null) && !(value is KryptonDataGridViewTextAndImageCell))
                    throw new InvalidCastException("Can only assign a object of type KryptonDataGridViewTextAndImageCell");

                base.CellTemplate = value;
            }
        }

        /// <summary>
        /// Gets the collection of the button specifications.
        /// </summary>
        [Category("Data")]
        [Description("Set of extra button specs to appear with control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DataGridViewColumnSpecCollection ButtonSpecs
        {
            get { return _buttonSpecs; }
        }
        #endregion

        #region Private
        private KryptonDataGridViewTextAndImageCell TextBoxCellTemplate
        {
            get { return (KryptonDataGridViewTextAndImageCell)CellTemplate; }
        }
        #endregion

        #region Internal
        internal void PerfomButtonSpecClick(DataGridViewButtonSpecClickEventArgs args)
        {
            if (ButtonSpecClick != null)
                ButtonSpecClick(this, args);
        }

        internal Size ImageSize
        {
            get { return imageSize; }
        }
        #endregion
    }
}
