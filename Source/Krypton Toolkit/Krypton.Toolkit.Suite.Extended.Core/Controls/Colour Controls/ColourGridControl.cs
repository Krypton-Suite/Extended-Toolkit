#region MIT License
/*
 *
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


namespace Krypton.Toolkit.Suite.Extended.Core
{
    /// <summary>
    /// Represents a grid control, which displays a collection of colors using different styles.
    /// </summary>
    [DefaultProperty("Colour"), DefaultEvent("ColourChanged"), ToolboxItem(false)]
    public class ColourGridControl : Control, IColourEditor
    {
        #region Constants

        public const int InvalidIndex = -1;

        private readonly IDictionary<int, Rectangle> _colourRegions;

        private static readonly object _eventAutoAddColoursChanged = new();

        private static readonly object _eventAutoFitChanged = new();

        private static readonly object _eventCellBorderColourChanged = new();

        private static readonly object _eventCellBorderStyleChanged = new();

        private static readonly object _eventCellContextMenuStripChanged = new();

        private static readonly object _eventCellSizeChanged = new();

        private static readonly object _eventColourChanged = new();

        private static readonly object _eventColourIndexChanged = new();

        private static readonly object _eventColorsChanged = new();

        private static readonly object _eventColumnsChanged = new();

        private static readonly object _eventCustomColoursChanged = new();

        private static readonly object _eventEditingColour = new();

        private static readonly object _eventEditModeChanged = new();

        private static readonly object _eventHotIndexChanged = new();

        private static readonly object _eventPaletteChanged = new();

        private static readonly object _eventSelectedCellStyleChanged = new();

        private static readonly object _eventShowCustomColoursChanged = new();

        private static readonly object _eventShowToolTipsChanged = new();

        private static readonly object _eventSpacingChanged = new();

        #endregion

        #region Fields

        private bool _autoAddColors;

        private bool _autoFit;

        private Brush _cellBackgroundBrush;

        private Color _cellBorderColour;

        private ColourCellBorderStyle _cellBorderStyle;

        private ContextMenuStrip _cellContextMenuStrip;

        private Size _cellSize;

        private Color _colour;

        private int _colorIndex;

        private ColourCollection _colours;

        private int _columns;

        private ColourCollection _customColours;

        private ColourEditingMode _editMode;

        private int _hotIndex;

        private ColourPalette _palette;

        private int _previousColourIndex;

        private int _previousHotIndex;

        private ColourGridSelectedCellStyle _selectedCellStyle;

        private bool _showCustomColours;

        private bool _showToolTips;

        private Size _spacing;

        private ToolTip _toolTip;

        private int _updateCount;

        #endregion

        #region Constructors

        public ColourGridControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick | ControlStyles.SupportsTransparentBackColor, true);
            _previousHotIndex = InvalidIndex;
            _previousColourIndex = InvalidIndex;
            _hotIndex = InvalidIndex;

            _colourRegions = new Dictionary<int, Rectangle>();
            _colours = ColourPalettes.NamedColours;
            _customColours = new(Enumerable.Repeat(Color.White, 16));
            _showCustomColours = true;
            _cellSize = new(12, 12);
            _spacing = new(3, 3);
            _columns = 16;
            base.AutoSize = true;
            Padding = new(5);
            _autoAddColors = true;
            _cellBorderColour = SystemColors.ButtonShadow;
            _showToolTips = true;
            _toolTip = new();
            SeparatorHeight = 8;
            _editMode = ColourEditingMode.CustomOnly;
            _colour = Color.Black;
            _cellBorderStyle = ColourCellBorderStyle.FixedSingle;
            _selectedCellStyle = ColourGridSelectedCellStyle.Zoomed;
            _palette = ColourPalette.Named;

            SetScaledCellSize();
            RefreshColours();
        }

        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler AutoAddColoursChanged
        {
            add => Events.AddHandler(_eventAutoAddColoursChanged, value);
            remove => Events.RemoveHandler(_eventAutoAddColoursChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler AutoFitChanged
        {
            add => Events.AddHandler(_eventAutoFitChanged, value);
            remove => Events.RemoveHandler(_eventAutoFitChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler CellBorderColourChanged
        {
            add => Events.AddHandler(_eventCellBorderColourChanged, value);
            remove => Events.RemoveHandler(_eventCellBorderColourChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler CellBorderStyleChanged
        {
            add => Events.AddHandler(_eventCellBorderStyleChanged, value);
            remove => Events.RemoveHandler(_eventCellBorderStyleChanged, value);
        }

        /// <summary>
        /// Occurs when the CellContextMenuStrip property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler CellContextMenuStripChanged
        {
            add => Events.AddHandler(_eventCellContextMenuStripChanged, value);
            remove => Events.RemoveHandler(_eventCellContextMenuStripChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler CellSizeChanged
        {
            add => Events.AddHandler(_eventCellSizeChanged, value);
            remove => Events.RemoveHandler(_eventCellSizeChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ColourIndexChanged
        {
            add => Events.AddHandler(_eventColourIndexChanged, value);
            remove => Events.RemoveHandler(_eventColourIndexChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ColoursChanged
        {
            add => Events.AddHandler(_eventColorsChanged, value);
            remove => Events.RemoveHandler(_eventColorsChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ColumnsChanged
        {
            add => Events.AddHandler(_eventColumnsChanged, value);
            remove => Events.RemoveHandler(_eventColumnsChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler CustomColoursChanged
        {
            add => Events.AddHandler(_eventCustomColoursChanged, value);
            remove => Events.RemoveHandler(_eventCustomColoursChanged, value);
        }

        [Category("Action")]
        public event EventHandler<EditColourCancelEventArgs> EditingColour
        {
            add => Events.AddHandler(_eventEditingColour, value);
            remove => Events.RemoveHandler(_eventEditingColour, value);
        }

        [Category("Property Changed")]
        public event EventHandler EditModeChanged
        {
            add => Events.AddHandler(_eventEditModeChanged, value);
            remove => Events.RemoveHandler(_eventEditModeChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler HotIndexChanged
        {
            add => Events.AddHandler(_eventHotIndexChanged, value);
            remove => Events.RemoveHandler(_eventHotIndexChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler PaletteChanged
        {
            add => Events.AddHandler(_eventPaletteChanged, value);
            remove => Events.RemoveHandler(_eventPaletteChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler SelectedCellStyleChanged
        {
            add => Events.AddHandler(_eventSelectedCellStyleChanged, value);
            remove => Events.RemoveHandler(_eventSelectedCellStyleChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ShowCustomColoursChanged
        {
            add => Events.AddHandler(_eventShowCustomColoursChanged, value);
            remove => Events.RemoveHandler(_eventShowCustomColoursChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ShowToolTipsChanged
        {
            add => Events.AddHandler(_eventShowToolTipsChanged, value);
            remove => Events.RemoveHandler(_eventShowToolTipsChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler SpacingChanged
        {
            add => Events.AddHandler(_eventSpacingChanged, value);
            remove => Events.RemoveHandler(_eventSpacingChanged, value);
        }

        #endregion

        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ActualColumns { get; protected set; }

        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool AutoAddColours
        {
            get => _autoAddColors;
            set
            {
                if (AutoAddColours != value)
                {
                    _autoAddColors = value;

                    OnAutoAddColorsChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(false)]
        public virtual bool AutoFit
        {
            get => _autoFit;
            set
            {
                if (AutoFit != value)
                {
                    _autoFit = value;

                    OnAutoFitChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override bool AutoSize
        {
            get => base.AutoSize;
            set => base.AutoSize = value;
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "ButtonShadow")]
        public virtual Color CellBorderColour
        {
            get => _cellBorderColour;
            set
            {
                if (CellBorderColour != value)
                {
                    _cellBorderColour = value;

                    OnCellBorderColorChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(ColourCellBorderStyle), "FixedSingle")]
        public virtual ColourCellBorderStyle CellBorderStyle
        {
            get => _cellBorderStyle;
            set
            {
                if (CellBorderStyle != value)
                {
                    _cellBorderStyle = value;

                    OnCellBorderStyleChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Behavior")]
        [DefaultValue(typeof(ContextMenuStrip), null)]
        public ContextMenuStrip CellContextMenuStrip
        {
            get => _cellContextMenuStrip;
            set
            {
                if (_cellContextMenuStrip != value)
                {
                    _cellContextMenuStrip = value;

                    OnCellContextMenuStripChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Size), "12, 12")]
        public virtual Size CellSize
        {
            get => _cellSize;
            set
            {
                if (_cellSize != value)
                {
                    _cellSize = value;

                    OnCellSizeChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int ColourIndex
        {
            get => _colorIndex;
            set
            {
                if (ColourIndex != value)
                {
                    _previousColourIndex = _colorIndex;
                    _colorIndex = value;

                    if (value != InvalidIndex)
                    {
                        Colour = GetColour(value);
                    }

                    OnColorIndexChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ColourCollection Colours
        {
            get => _colours;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (Colours != value)
                {
                    RemoveEventHandlers(_colours);

                    _colours = value;

                    OnColorsChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(16)]
        public virtual int Columns
        {
            get => _columns;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Number of columns cannot be less than zero.");
                }

                if (Columns != value)
                {
                    _columns = value;
                    CalculateGridSize();

                    OnColumnsChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(false)]
        public Point CurrentCell => GetCell(ColourIndex);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ColourCollection CustomColours
        {
            get => _customColours;
            set
            {
                if (CustomColours != value)
                {
                    RemoveEventHandlers(_customColours);

                    _customColours = value;

                    OnCustomColorsChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Behavior")]
        [DefaultValue(typeof(ColourEditingMode), "CustomOnly")]
        public virtual ColourEditingMode EditMode
        {
            get => _editMode;
            set
            {
                if (EditMode != value)
                {
                    _editMode = value;

                    OnEditModeChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font
        {
            get => base.Font;
            set => base.Font = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set => base.ForeColor = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int HotIndex
        {
            get => _hotIndex;
            set
            {
                if (HotIndex != value)
                {
                    _previousHotIndex = HotIndex;
                    _hotIndex = value;

                    OnHotIndexChanged(EventArgs.Empty);
                }
            }
        }

        [DefaultValue(typeof(Padding), "5, 5, 5, 5")]
        public new Padding Padding
        {
            get => base.Padding;
            set => base.Padding = value;
        }

        [Category("Appearance")]
        [DefaultValue(typeof(ColourPalette), "Named")]
        public virtual ColourPalette Palette
        {
            get => _palette;
            set
            {
                if (Palette != value)
                {
                    _palette = value;

                    OnPaletteChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(ColourGridSelectedCellStyle), "Zoomed")]
        public virtual ColourGridSelectedCellStyle SelectedCellStyle
        {
            get => _selectedCellStyle;
            set
            {
                if (SelectedCellStyle != value)
                {
                    _selectedCellStyle = value;

                    OnSelectedCellStyleChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public virtual bool ShowCustomColors
        {
            get => _showCustomColours;
            set
            {
                if (ShowCustomColors != value)
                {
                    _showCustomColours = value;

                    OnShowCustomColoursChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool ShowToolTips
        {
            get => _showToolTips;
            set
            {
                if (ShowToolTips != value)
                {
                    _showToolTips = value;

                    OnShowToolTipsChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Size), "3, 3")]
        public virtual Size Spacing
        {
            get => _spacing;
            set
            {
                if (Spacing != value)
                {
                    _spacing = value;

                    OnSpacingChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        /// <summary>
        ///   Gets a value indicating whether painting of the control is allowed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if painting of the control is allowed; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool AllowPainting => _updateCount == 0;

        protected IDictionary<int, Rectangle> ColorRegions => _colourRegions;

        protected int CustomRows { get; set; }

        protected int PrimaryRows { get; set; }

        protected int SeparatorHeight { get; set; }

        protected bool WasKeyPressed { get; set; }

        #endregion

        #region Methods

        public virtual int AddCustomColor(Color value)
        {
            int newIndex;

            newIndex = GetColourIndex(value);

            if (newIndex == InvalidIndex)
            {
                if (AutoAddColours)
                {
                    CustomColours.Add(value);
                }
                else
                {
                    if (CustomColours == null)
                    {
                        CustomColours =
                        [
                            value
                        ];
                    }
                    else
                    {
                        CustomColours[0] = value;
                    }

                    newIndex = GetColourIndex(value);
                }

                RefreshColours();
            }

            return newIndex;
        }

        /// <summary>
        ///   Disables any redrawing of the image box
        /// </summary>
        public virtual void BeginUpdate()
        {
            _updateCount++;
        }

        /// <summary>
        ///   Enables the redrawing of the image box
        /// </summary>
        public virtual void EndUpdate()
        {
            if (_updateCount > 0)
            {
                _updateCount--;
            }

            if (AllowPainting)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// Returns the <see cref="Rectangle"/> describing the bounds of a single color cell
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more arguments are outside the
        /// required range.</exception>
        /// <param name="index">Zero-based index of the color cell to return.</param>
        /// <returns>
        /// The cell bounds.
        /// </returns>
        public Rectangle GetCellBounds(int index)
        {
            if (index < 0 || index > Colours.Count + CustomColours.Count - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return _colourRegions[index];
        }

        public Color GetColour(int index)
        {
            Color result;
            int colorCount;
            int customColorCount;

            colorCount = Colours != null ? Colours.Count : 0;
            customColorCount = CustomColours != null ? CustomColours.Count : 0;

            if (index < 0 || index > colorCount + customColorCount)
            {
                result = Color.Empty;
            }
            else
            {
                result = index > colorCount - 1 ? CustomColours[index - colorCount] : Colours[index];
            }

            return result;
        }

        public ColourSource GetColourSource(int colourIndex)
        {
            ColourSource result;
            int colourCount;
            int customColourCount;

            colourCount = Colours != null ? Colours.Count : 0;
            customColourCount = CustomColours != null ? CustomColours.Count : 0;

            if (colourCount < 0 || colourIndex > colourCount + customColourCount)
            {
                result = ColourSource.None;
            }
            else
            {
                result = colourIndex > colourCount - 1 ? ColourSource.Custom : ColourSource.Standard;
            }

            return result;
        }

        public ColourSource GetColourSource(Color colour)
        {
            int index;
            ColourSource result;

            index = Colours.IndexOf(colour);
            if (index != InvalidIndex)
            {
                result = ColourSource.Standard;
            }
            else
            {
                index = CustomColours.IndexOf(colour);
                result = index != InvalidIndex ? ColourSource.Custom : ColourSource.None;
            }

            return result;
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            return AutoSize ? GetAutoSize() : base.GetPreferredSize(proposedSize);
        }

        public ColourHitTestInfo HitTest(Point point)
        {
            ColourHitTestInfo result;
            int colourIndex;

            result = new();
            colourIndex = InvalidIndex;

            foreach (KeyValuePair<int, Rectangle> pair in _colourRegions.Where(pair => pair.Value.Contains(point)))
            {
                colourIndex = pair.Key;
                break;
            }

            result.Index = colourIndex;
            if (colourIndex != InvalidIndex)
            {
                result.Colour = colourIndex < Colours.Count + CustomColours.Count ? GetColour(colourIndex) : Color.White;
                result.Source = GetColourSource(colourIndex);
            }
            else
            {
                result.Source = ColourSource.None;
            }

            return result;
        }

        public void Invalidate(int index)
        {
            if (AllowPainting && index != InvalidIndex)
            {
                Rectangle bounds;

                if (_colourRegions.TryGetValue(index, out bounds))
                {
                    if (SelectedCellStyle == ColourGridSelectedCellStyle.Zoomed)
                    {
                        bounds.Inflate(Padding.Left, Padding.Top);
                    }

                    Invalidate(bounds);
                }
            }
        }

        public void Navigate(int offsetX, int offsetY)
        {
            Navigate(offsetX, offsetY, NavigationOrigin.Current);
        }

        public virtual void Navigate(int offsetX, int offsetY, NavigationOrigin origin)
        {
            Point cellLocation;
            Point offsetCellLocation;
            int row;
            int column;
            int index;

            switch (origin)
            {
                case NavigationOrigin.Begin:
                    cellLocation = Point.Empty;
                    break;
                case NavigationOrigin.End:
                    cellLocation = new(ActualColumns - 1, PrimaryRows + CustomRows - 1);
                    break;
                default:
                    cellLocation = CurrentCell;
                    break;
            }

            if (cellLocation.X == -1 && cellLocation.Y == -1)
            {
                cellLocation = Point.Empty; // If no cell is selected, assume the first one is for the purpose of keyboard navigation
            }

            offsetCellLocation = GetCellOffset(cellLocation, offsetX, offsetY);
            row = offsetCellLocation.Y;
            column = offsetCellLocation.X;
            index = GetCellIndex(column, row);
            if (index != InvalidIndex)
            {
                ColourIndex = index;
            }
        }

        protected virtual void CalculateCellSize()
        {
            int w;
            int h;

            w = (ClientSize.Width - Padding.Horizontal) / ActualColumns - Spacing.Width;
            h = (ClientSize.Height - Padding.Vertical) / (PrimaryRows + CustomRows) - Spacing.Height;

            if (w > 0 && h > 0)
            {
                CellSize = new(w, h);
            }
        }

        protected virtual void CalculateGridSize()
        {
            int primaryRows;
            int customRows;

            ActualColumns = Columns != 0 ? Columns : (ClientSize.Width + Spacing.Width - Padding.Vertical) / (_scaledCellSize.Width + Spacing.Width);
            if (ActualColumns < 1)
            {
                ActualColumns = 1;
            }

            primaryRows = GetRows(Colours != null ? Colours.Count : 0);
            if (primaryRows == 0)
            {
                primaryRows = 1;
            }

            customRows = ShowCustomColors ? GetRows(CustomColours != null ? CustomColours.Count : 0) : 0;

            PrimaryRows = primaryRows;
            CustomRows = customRows;
        }

        protected virtual Brush CreateTransparencyBrush()
        {
            Type type;

            type = typeof(ColourGridControl);

            using (Bitmap background = new(type.Assembly.GetManifestResourceStream(
                       $"{type.Namespace}.Resources.cellbackground.png")))
            {
                return new TextureBrush(background, WrapMode.Tile);
            }
        }

        protected void DefineColourRegions(ColourCollection colours, int rangeStart, int offset)
        {
            if (colours != null)
            {
                int rows;
                int index;

                rows = GetRows(colours.Count);
                index = 0;

                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < ActualColumns; column++)
                    {
                        if (index < colours.Count)
                        {
                            _colourRegions.Add(rangeStart + index, new(Padding.Left + column * (_scaledCellSize.Width + Spacing.Width), offset + row * (_scaledCellSize.Height + Spacing.Height), _scaledCellSize.Width, _scaledCellSize.Height));
                        }

                        index++;
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                RemoveEventHandlers(_colours);
                RemoveEventHandlers(_customColours);

                _toolTip?.Dispose();

                _cellBackgroundBrush?.Dispose();
            }

            base.Dispose(disposing);
        }

        protected virtual void EditColour(int colourIndex)
        {
            //using (ColorPickerDialog dialog = new ColorPickerDialog())
            //{
            //    dialog.Colour = this.GetColour(colourIndex);
            //    if (dialog.ShowDialog(this) == DialogResult.OK)
            //    {
            //        this.BeginUpdate();
            //        this.SetColour(colourIndex, dialog.Colour);
            //        this.Colour = dialog.Colour;
            //        this.EndUpdate();
            //    }
            //}
        }

        protected Size GetAutoSize()
        {
            int offset;
            int width;

            offset = CustomRows != 0 ? SeparatorHeight : 0;
            if (Columns != 0)
            {
                width = (_scaledCellSize.Width + Spacing.Width) * ActualColumns + Padding.Horizontal - Spacing.Width;
            }
            else
            {
                width = ClientSize.Width;
            }

            return new(width, (_scaledCellSize.Height + Spacing.Height) * (PrimaryRows + CustomRows) + offset + Padding.Vertical - Spacing.Height);
        }

        protected int GetCellIndex(Point point)
        {
            return GetCellIndex(point.X, point.Y);
        }

        protected virtual int GetCellIndex(int column, int row)
        {
            int result;

            if (column >= 0 && column < ActualColumns && row >= 0 && row < PrimaryRows + CustomRows)
            {
                int lastStandardRowOffset;

                lastStandardRowOffset = PrimaryRows * ActualColumns - Colours.Count;
                result = row * ActualColumns + column;
                if (row == PrimaryRows - 1 && column >= ActualColumns - lastStandardRowOffset)
                {
                    result -= lastStandardRowOffset;
                }
                if (row >= PrimaryRows)
                {
                    result -= lastStandardRowOffset;
                }

                if (result > Colours.Count + CustomColours.Count - 1)
                {
                    result = InvalidIndex;
                }
            }
            else
            {
                result = InvalidIndex;
            }

            return result;
        }

        protected Point GetCellOffset(int columnOffset, int rowOffset)
        {
            return GetCellOffset(CurrentCell, columnOffset, rowOffset);
        }

        protected Point GetCellOffset(Point cell, int columnOffset, int rowOffset)
        {
            int row;
            int column;
            int lastStandardRowOffset;
            int lastStandardRowLastColumn;

            lastStandardRowOffset = PrimaryRows * ActualColumns - Colours.Count;
            lastStandardRowLastColumn = ActualColumns - lastStandardRowOffset;
            column = cell.X + columnOffset;
            row = cell.Y + rowOffset;

            // if the row is the last row, but there aren't enough columns to fill the row - nudge it to the last available
            if (row == PrimaryRows - 1 && column >= lastStandardRowLastColumn)
            {
                column = lastStandardRowLastColumn - 1;
            }

            // wrap the column to the end of the previous row
            if (column < 0)
            {
                column = ActualColumns - 1;
                row--;
                if (row == PrimaryRows - 1)
                {
                    column = ActualColumns - (lastStandardRowOffset + 1);
                }
            }

            // wrap to column to the start of the next row
            if (row == PrimaryRows - 1 && column >= ActualColumns - lastStandardRowOffset || column >= ActualColumns)
            {
                column = 0;
                row++;
            }

            return new(column, row);
        }

        protected virtual int GetColourIndex(Color value)
        {
            int index;

            index = Colours != null ? Colours.IndexOf(value) : InvalidIndex;
            if (index == InvalidIndex && ShowCustomColors && CustomColours != null)
            {
                index = CustomColours.IndexOf(value);
                if (index != InvalidIndex)
                {
                    index += Colours.Count;
                }
            }

            return index;
        }

        protected virtual ColourCollection GetPredefinedPalette()
        {
            return ColourPalettes.GetPalette(Palette);
        }

        protected int GetRows(int count)
        {
            int rows;

            if (count != 0 && ActualColumns > 0)
            {
                rows = count / ActualColumns;
                if (count % ActualColumns != 0)
                {
                    rows++;
                }
            }
            else
            {
                rows = 0;
            }

            return rows;
        }

        protected override bool IsInputKey(Keys keyData)
        {
            bool result;

            if (keyData is Keys.Left or Keys.Up or Keys.Down or Keys.Right or Keys.Enter or Keys.Home or Keys.End)
            {
                result = true;
            }
            else
            {
                result = base.IsInputKey(keyData);
            }

            return result;
        }

        /// <summary>
        /// Raises the <see cref="AutoAddColoursChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnAutoAddColorsChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)Events[_eventAutoAddColoursChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="AutoFitChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnAutoFitChanged(EventArgs e)
        {
            EventHandler handler;

            if (AutoFit && AutoSize)
            {
                AutoSize = false;
            }

            RefreshColours();

            handler = (EventHandler)Events[_eventAutoFitChanged];

            handler?.Invoke(this, e);
        }

        protected override void OnAutoSizeChanged(EventArgs e)
        {
            if (AutoSize && AutoFit)
            {
                AutoFit = false;
            }

            base.OnAutoSizeChanged(e);

            if (AutoSize)
            {
                SizeToFit();
            }
        }

        /// <summary>
        /// Raises the <see cref="CellBorderColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnCellBorderColorChanged(EventArgs e)
        {
            EventHandler handler;

            if (AllowPainting)
            {
                Invalidate();
            }

            handler = (EventHandler)Events[_eventCellBorderColourChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="CellBorderStyleChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnCellBorderStyleChanged(EventArgs e)
        {
            EventHandler handler;

            if (AllowPainting)
            {
                Invalidate();
            }

            handler = (EventHandler)Events[_eventCellBorderStyleChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="CellContextMenuStripChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnCellContextMenuStripChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)Events[_eventCellContextMenuStripChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="CellSizeChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnCellSizeChanged(EventArgs e)
        {
            EventHandler handler;

            SetScaledCellSize();

            if (AutoSize)
            {
                SizeToFit();
            }

            if (AllowPainting)
            {
                RefreshColours();
                Invalidate();
            }

            handler = (EventHandler)Events[_eventCellSizeChanged];

            handler?.Invoke(this, e);
        }

        private void SetScaledCellSize()
        {
            Point dpi;
            float scaleX;
            float scaleY;

            dpi = NativeMethods.GetDesktopDpi();
            scaleX = dpi.X / 96F;
            scaleY = dpi.Y / 96F;

            if (scaleX > 1 && scaleY > 1)
            {
                _scaledCellSize = new((int)(_cellSize.Width * scaleX), (int)(_cellSize.Height * scaleY));
            }
            else
            {
                _scaledCellSize = _cellSize;
            }

            DebugUtilities.WriteLine(_scaledCellSize);
        }

        /// <summary>
        /// Raises the <see cref="ColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)Events[_eventColourChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColourIndexChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorIndexChanged(EventArgs e)
        {
            EventHandler handler = null;

            if (AllowPainting)
            {
                Invalidate(_previousColourIndex);
                Invalidate(ColourIndex);
            }

            handler = (EventHandler)Events[_eventColourIndexChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColoursChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorsChanged(EventArgs e)
        {
            EventHandler handler;

            AddEventHandlers(Colours);

            RefreshColours();

            handler = (EventHandler)Events[_eventColorsChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColumnsChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColumnsChanged(EventArgs e)
        {
            EventHandler handler;

            RefreshColours();

            handler = (EventHandler)Events[_eventColumnsChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="CustomColoursChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnCustomColorsChanged(EventArgs e)
        {
            EventHandler handler;

            AddEventHandlers(CustomColours);
            RefreshColours();

            handler = (EventHandler)Events[_eventCustomColoursChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="EditingColour" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EditColourCancelEventArgs" /> instance containing the event data.</param>
        protected virtual void OnEditingColour(EditColourCancelEventArgs e)
        {
            EventHandler<EditColourCancelEventArgs> handler;

            handler = (EventHandler<EditColourCancelEventArgs>)Events[_eventEditingColour];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="EditModeChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnEditModeChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)Events[_eventEditModeChanged];

            handler?.Invoke(this, e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (AllowPainting)
            {
                Invalidate(ColourIndex);
            }
        }

        /// <summary>
        /// Raises the <see cref="HotIndexChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnHotIndexChanged(EventArgs e)
        {
            EventHandler handler;

            SetToolTip();

            if (AllowPainting)
            {
                Invalidate(_previousHotIndex);
                Invalidate(HotIndex);
            }

            handler = (EventHandler)Events[_eventHotIndexChanged];

            handler?.Invoke(this, e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            WasKeyPressed = true;

            switch (e.KeyData)
            {
                case Keys.Down:
                    Navigate(0, 1);
                    e.Handled = true;
                    break;
                case Keys.Up:
                    Navigate(0, -1);
                    e.Handled = true;
                    break;
                case Keys.Left:
                    Navigate(-1, 0);
                    e.Handled = true;
                    break;
                case Keys.Right:
                    Navigate(1, 0);
                    e.Handled = true;
                    break;
                case Keys.Home:
                    Navigate(0, 0, NavigationOrigin.Begin);
                    e.Handled = true;
                    break;
                case Keys.End:
                    Navigate(0, 0, NavigationOrigin.End);
                    e.Handled = true;
                    break;
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (WasKeyPressed && ColourIndex != InvalidIndex)
            {
                switch (e.KeyData)
                {
                    case Keys.Enter:
                        ColourSource source;

                        source = GetColourSource(ColourIndex);

                        if (source == ColourSource.Custom && EditMode != ColourEditingMode.None || source == ColourSource.Standard && EditMode == ColourEditingMode.Both)
                        {
                            e.Handled = true;

                            StartColorEdit(ColourIndex);
                        }
                        break;
                    case Keys.Apps:
                    case Keys.F10 | Keys.Shift:
                        int x;
                        int y;
                        Point location;

                        location = _colourRegions[_colorIndex].Location;
                        x = location.X;
                        y = location.Y + _cellSize.Height;

                        ShowContextMenu(new(x, y));
                        break;
                }
            }

            WasKeyPressed = false;

            base.OnKeyUp(e);
        }

        private Size _scaledCellSize;

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (AllowPainting)
            {
                Invalidate(ColourIndex);
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            ColourHitTestInfo hitTest;

            base.OnMouseDoubleClick(e);

            hitTest = HitTest(e.Location);

            if (e.Button == MouseButtons.Left && (hitTest.Source == ColourSource.Custom && EditMode != ColourEditingMode.None || hitTest.Source == ColourSource.Standard && EditMode == ColourEditingMode.Both))
            {
                StartColorEdit(hitTest.Index);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!Focused && TabStop)
            {
                Focus();
            }

            ProcessMouseClick(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            HotIndex = InvalidIndex;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            HotIndex = HitTest(e.Location).Index;

            ProcessMouseClick(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Right)
            {
                int index;

                index = HitTest(e.Location).Index;

                if (index != InvalidIndex)
                {
                    Focus();
                    ColourIndex = index;

                    ShowContextMenu(e.Location);
                }
            }
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);

            if (AllowPainting)
            {
                RefreshColours();
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (AllowPainting)
            {
                int colorCount;

                colorCount = Colours.Count;

                System.Diagnostics.Debug.Print(e.ClipRectangle.Size == ClientSize ? "Performing full paint!" : "Performing partial paint!");

                OnPaintBackground(e); // HACK: Easiest way of supporting things like BackgroundImage, BackgroundImageLayout etc as the PaintBackground event is no longer being called

                // draw a design time dotted grid
                if (DesignMode)
                {
                    using (Pen pen = new(SystemColors.ButtonShadow)
                    {
                        DashStyle = DashStyle.Dot
                    })
                    {
                        e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
                    }
                }

                // draw cells for all current colors
                for (int i = 0; i < colorCount; i++)
                {
                    Rectangle bounds;

                    bounds = _colourRegions[i];
                    if (e.ClipRectangle.IntersectsWith(bounds))
                    {
                        PaintCell(e, i, i, Colours[i], bounds);
                    }
                }

                if (CustomColours.Count != 0 && ShowCustomColors)
                {
                    // draw a separator
                    PaintSeparator(e);

                    // and the custom colors
                    for (int i = 0; i < CustomColours.Count; i++)
                    {
                        Rectangle bounds;

                        if (_colourRegions.TryGetValue(colorCount + i, out bounds) && e.ClipRectangle.IntersectsWith(bounds))
                        {
                            PaintCell(e, i, colorCount + i, CustomColours[i], bounds);
                        }
                    }
                }

                // draw the selected color
                if (SelectedCellStyle != ColourGridSelectedCellStyle.None && ColourIndex >= 0)
                {
                    Rectangle bounds;

                    if (_colourRegions.TryGetValue(ColourIndex, out bounds) && e.ClipRectangle.IntersectsWith(bounds))
                    {
                        PaintSelectedCell(e, ColourIndex, Colour, bounds);
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="PaletteChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnPaletteChanged(EventArgs e)
        {
            EventHandler handler;

            Colours = GetPredefinedPalette();

            handler = (EventHandler)Events[_eventPaletteChanged];

            handler?.Invoke(this, e);
        }

        protected override void OnResize(EventArgs e)
        {
            RefreshColours();

            base.OnResize(e);
        }

        /// <summary>
        /// Raises the <see cref="SelectedCellStyleChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnSelectedCellStyleChanged(EventArgs e)
        {
            EventHandler handler;

            if (AllowPainting)
            {
                Invalidate();
            }

            handler = (EventHandler)Events[_eventSelectedCellStyleChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ShowCustomColoursChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowCustomColoursChanged(EventArgs e)
        {
            EventHandler handler;

            RefreshColours();

            handler = (EventHandler)Events[_eventShowCustomColoursChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ShowToolTipsChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowToolTipsChanged(EventArgs e)
        {
            EventHandler handler;

            if (ShowToolTips)
            {
                _toolTip = new();
            }
            else if (_toolTip != null)
            {
                _toolTip.Dispose();
                _toolTip = null;
            }

            handler = (EventHandler)Events[_eventShowToolTipsChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="SpacingChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnSpacingChanged(EventArgs e)
        {
            EventHandler handler;

            if (AutoSize)
            {
                SizeToFit();
            }

            if (AllowPainting)
            {
                RefreshColours();
                Invalidate();
            }

            handler = (EventHandler)Events[_eventSpacingChanged];

            handler?.Invoke(this, e);
        }

        protected virtual void PaintCell(PaintEventArgs e, int colourIndex, int cellIndex, Color colour, Rectangle bounds)
        {
            if (colour.A != 255)
            {
                PaintTransparentCell(e, bounds);
            }

            using (Brush brush = new SolidBrush(colour))
            {
                e.Graphics.FillRectangle(brush, bounds);
            }

            switch (CellBorderStyle)
            {
                case ColourCellBorderStyle.FixedSingle:
                    using (Pen pen = new(CellBorderColour))
                    {
                        e.Graphics.DrawRectangle(pen, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
                    }
                    break;
                case ColourCellBorderStyle.DoubleSoft:
                    HSLColourStructure shadedOuter;
                    HSLColourStructure shadedInner;

                    shadedOuter = new(colour);
                    shadedOuter.L -= 0.50;

                    shadedInner = new(colour);
                    shadedInner.L -= 0.20;

                    using (Pen pen = new(CellBorderColour))
                    {
                        e.Graphics.DrawRectangle(pen, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
                    }
                    e.Graphics.DrawRectangle(Pens.White, bounds.Left + 1, bounds.Top + 1, bounds.Width - 3, bounds.Height - 3);
                    using (Pen pen = new(Color.FromArgb(32, shadedOuter.ToRgbColour())))
                    {
                        e.Graphics.DrawRectangle(pen, bounds.Left + 2, bounds.Top + 2, bounds.Width - 5, bounds.Height - 5);
                    }
                    using (Pen pen = new(Color.FromArgb(32, shadedInner.ToRgbColour())))
                    {
                        e.Graphics.DrawRectangle(pen, bounds.Left + 3, bounds.Top + 3, bounds.Width - 7, bounds.Height - 7);
                    }
                    break;
            }

            if (HotIndex != InvalidIndex && HotIndex == cellIndex)
            {
                e.Graphics.DrawRectangle(Pens.Black, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
                e.Graphics.DrawRectangle(Pens.White, bounds.Left + 1, bounds.Top + 1, bounds.Width - 3, bounds.Height - 3);
            }
        }

        protected virtual void PaintSelectedCell(PaintEventArgs e, int colorIndex, Color color, Rectangle bounds)
        {
            switch (SelectedCellStyle)
            {
                case ColourGridSelectedCellStyle.Standard:
                    if (Focused)
                    {
                        ControlPaint.DrawFocusRectangle(e.Graphics, bounds);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(Pens.Black, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
                    }
                    break;
                case ColourGridSelectedCellStyle.Zoomed:
                    // make the cell larger according to the padding
                    if (SelectedCellStyle == ColourGridSelectedCellStyle.Zoomed)
                    {
                        bounds.Inflate(Padding.Left, Padding.Top);
                    }

                    // fill the inner
                    e.Graphics.FillRectangle(Brushes.White, bounds);
                    if (SelectedCellStyle == ColourGridSelectedCellStyle.Zoomed)
                    {
                        bounds.Inflate(-3, -3);
                    }
                    if (color.A != 255)
                    {
                        PaintTransparentCell(e, bounds);
                    }

                    using (Brush brush = new SolidBrush(color))
                    {
                        e.Graphics.FillRectangle(brush, bounds);
                    }

                    // draw a border
                    if (Focused)
                    {
                        bounds = new(bounds.Left - 2, bounds.Top - 2, bounds.Width + 4, bounds.Height + 4);
                        ControlPaint.DrawFocusRectangle(e.Graphics, bounds);
                    }
                    else
                    {
                        bounds = new(bounds.Left - 2, bounds.Top - 2, bounds.Width + 3, bounds.Height + 3);

                        using (Pen pen = new(CellBorderColour))
                        {
                            e.Graphics.DrawRectangle(pen, bounds);
                        }
                    }
                    break;
            }
        }

        protected virtual void PaintSeparator(PaintEventArgs e)
        {
            int x1;
            int y1;
            int x2;
            int y2;

            x1 = Padding.Left;
            x2 = ClientSize.Width - Padding.Right;
            y1 = SeparatorHeight / 2 + Padding.Top + PrimaryRows * (_scaledCellSize.Height + Spacing.Height) + 1 - Spacing.Height;
            y2 = y1;

            using (Pen pen = new(CellBorderColour))
            {
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        protected virtual void PaintTransparentCell(PaintEventArgs e, Rectangle bounds)
        {
            if (_cellBackgroundBrush == null)
            {
                _cellBackgroundBrush = CreateTransparencyBrush();
            }

            e.Graphics.FillRectangle(_cellBackgroundBrush, bounds);
        }

        protected virtual void ProcessMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ColourHitTestInfo hitTest;

                hitTest = HitTest(e.Location);

                if (hitTest.Source != ColourSource.None)
                {
                    Colour = hitTest.Colour;
                    ColourIndex = hitTest.Index;
                }
            }
        }

        protected virtual void RefreshColours()
        {
            if (AllowPainting)
            {
                System.Diagnostics.Debug.Print("Calculating colours...");

                CalculateGridSize();
                if (AutoFit)
                {
                    CalculateCellSize();
                }
                else if (AutoSize)
                {
                    SizeToFit();
                }

                _colourRegions.Clear();

                if (Colours != null)
                {
                    DefineColourRegions(Colours, 0, Padding.Top);
                    if (ShowCustomColors)
                    {
                        DefineColourRegions(CustomColours, Colours.Count, Padding.Top + SeparatorHeight + (_scaledCellSize.Height + Spacing.Height) * PrimaryRows);
                    }

                    ColourIndex = GetColourIndex(Colour);

                    if (!Colour.IsEmpty && ColourIndex == InvalidIndex && AutoAddColours && ShowCustomColors)
                    {
                        AddCustomColor(Colour);
                    }

                    Invalidate();
                }
            }
        }

        protected virtual void SetColour(int colourIndex, Color colour)
        {
            int colourCount;

            colourCount = Colours.Count;

            if (colourIndex < 0 || colourIndex > colourCount + CustomColours.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(colourIndex));
            }

            if (colourIndex > colourCount - 1)
            {
                CustomColours[colourIndex - colourCount] = colour;
            }
            else
            {
                Colours[colourIndex] = colour;
            }
        }

        private void AddEventHandlers(ColourCollection value)
        {
            if (value != null)
            {
                value.ItemInserted += ColoursCollectionChangedHandler;
                value.ItemRemoved += ColoursCollectionChangedHandler;
                value.ItemsCleared += ColoursCollectionChangedHandler;
                value.ItemReplaced += ColoursCollectionItemReplacedHandler;
            }
        }

        private void ColoursCollectionChangedHandler(object sender, ColourCollectionEventArgs e)
        {
            RefreshColours();
        }

        private void ColoursCollectionItemReplacedHandler(object sender, ColourCollectionEventArgs e)
        {
            ColourCollection collection;
            int index;

            collection = (ColourCollection)sender;
            index = _colorIndex;
            if (index != InvalidIndex && ReferenceEquals(collection, CustomColours))
            {
                index -= Colours.Count;
            }

            if (index >= 0 && index < collection.Count && collection[index] != Colour)
            {
                System.Diagnostics.Debug.Print("Replacing index {0} with {1}", index, collection[index]);

                _previousColourIndex = index;
                _colorIndex = -1;
                ColourIndex = index;
            }

            Invalidate(e.Index);
        }

        private Point GetCell(int index)
        {
            int row;
            int column;

            if (index == InvalidIndex)
            {
                row = -1;
                column = -1;
            }
            else if (index >= Colours.Count)
            {
                // custom color
                index -= Colours.Count;
                row = index / ActualColumns;
                column = index - row * ActualColumns;
                row += PrimaryRows;
            }
            else
            {
                // normal row
                row = index / ActualColumns;
                column = index - row * ActualColumns;
            }

            return new(column, row);
        }

        private void RemoveEventHandlers(ColourCollection value)
        {
            if (value != null)
            {
                value.ItemInserted -= ColoursCollectionChangedHandler;
                value.ItemRemoved -= ColoursCollectionChangedHandler;
                value.ItemsCleared -= ColoursCollectionChangedHandler;
                value.ItemReplaced -= ColoursCollectionItemReplacedHandler;
            }
        }

        private void SetToolTip()
        {
            if (ShowToolTips is true and true)
            {
#if USENAMEHACK
        string name;

        if (this.HotIndex != InvalidIndex)
        {
          name = this.HotIndex < this.Colors.Count ? this.Colors.GetName(this.HotIndex) : this.CustomColors.GetName(this.HotIndex);

          if (string.IsNullOrEmpty(name))
          {
            name = this.GetColor(this.HotIndex).Name;
          }
        }
        else
        {
          name = null;
        }

        _toolTip.SetToolTip(this, name);
#else
                _toolTip.SetToolTip(this, HotIndex != InvalidIndex ? GetColour(HotIndex).Name : null);
#endif
            }
        }

        private void ShowContextMenu(Point location)
        {
            _cellContextMenuStrip?.Show(this, location);
        }

        private void SizeToFit()
        {
            Size = GetAutoSize();
        }

        private void StartColorEdit(int index)
        {
            EditColourCancelEventArgs e;

            e = new(GetColour(index), index);
            OnEditingColour(e);

            if (!e.Cancel)
            {
                EditColour(index);
            }
        }

        #endregion

        #region IColorEditor Interface

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add => Events.AddHandler(_eventColourChanged, value);
            remove => Events.RemoveHandler(_eventColourChanged, value);
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
        public virtual Color Colour
        {
            get => _colour;
            set
            {
                int newIndex;

                _colour = value;

                if (!value.IsEmpty)
                {
                    // the new color matches the color at the current index, so don't change the index
                    // this stops the selection hopping about if you have duplicate colors in a palette
                    // otherwise, if the colors don't match, then find the index that does
                    newIndex = GetColour(ColourIndex) == value ? ColourIndex : GetColourIndex(value);

                    if (newIndex == InvalidIndex)
                    {
                        newIndex = AddCustomColor(value);
                    }
                }
                else
                {
                    newIndex = InvalidIndex;
                }

                ColourIndex = newIndex;

                OnColorChanged(EventArgs.Empty);
            }
        }

        #endregion
    }
}