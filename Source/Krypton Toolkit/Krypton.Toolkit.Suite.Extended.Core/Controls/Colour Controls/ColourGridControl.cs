#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;

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

        private static readonly object _eventAutoAddColoursChanged = new object();

        private static readonly object _eventAutoFitChanged = new object();

        private static readonly object _eventCellBorderColourChanged = new object();

        private static readonly object _eventCellBorderStyleChanged = new object();

        private static readonly object _eventCellContextMenuStripChanged = new object();

        private static readonly object _eventCellSizeChanged = new object();

        private static readonly object _eventColourChanged = new object();

        private static readonly object _eventColourIndexChanged = new object();

        private static readonly object _eventColorsChanged = new object();

        private static readonly object _eventColumnsChanged = new object();

        private static readonly object _eventCustomColoursChanged = new object();

        private static readonly object _eventEditingColour = new object();

        private static readonly object _eventEditModeChanged = new object();

        private static readonly object _eventHotIndexChanged = new object();

        private static readonly object _eventPaletteChanged = new object();

        private static readonly object _eventSelectedCellStyleChanged = new object();

        private static readonly object _eventShowCustomColoursChanged = new object();

        private static readonly object _eventShowToolTipsChanged = new object();

        private static readonly object _eventSpacingChanged = new object();

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
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick | ControlStyles.SupportsTransparentBackColor, true);
            _previousHotIndex = InvalidIndex;
            _previousColourIndex = InvalidIndex;
            _hotIndex = InvalidIndex;

            _colourRegions = new Dictionary<int, Rectangle>();
            _colours = ColourPalettes.NamedColours;
            _customColours = new ColourCollection(Enumerable.Repeat(Color.White, 16));
            _showCustomColours = true;
            _cellSize = new Size(12, 12);
            _spacing = new Size(3, 3);
            _columns = 16;
            base.AutoSize = true;
            this.Padding = new Padding(5);
            _autoAddColors = true;
            _cellBorderColour = SystemColors.ButtonShadow;
            _showToolTips = true;
            _toolTip = new ToolTip();
            this.SeparatorHeight = 8;
            _editMode = ColourEditingMode.CUSTOMONLY;
            _colour = Color.Black;
            _cellBorderStyle = ColourCellBorderStyle.FIXEDSINGLE;
            _selectedCellStyle = ColourGridSelectedCellStyle.ZOOMED;
            _palette = ColourPalette.NAMED;

            this.SetScaledCellSize();
            this.RefreshColours();
        }

        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler AutoAddColoursChanged
        {
            add { this.Events.AddHandler(_eventAutoAddColoursChanged, value); }
            remove { this.Events.RemoveHandler(_eventAutoAddColoursChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler AutoFitChanged
        {
            add { this.Events.AddHandler(_eventAutoFitChanged, value); }
            remove { this.Events.RemoveHandler(_eventAutoFitChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler CellBorderColourChanged
        {
            add { this.Events.AddHandler(_eventCellBorderColourChanged, value); }
            remove { this.Events.RemoveHandler(_eventCellBorderColourChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler CellBorderStyleChanged
        {
            add { this.Events.AddHandler(_eventCellBorderStyleChanged, value); }
            remove { this.Events.RemoveHandler(_eventCellBorderStyleChanged, value); }
        }

        /// <summary>
        /// Occurs when the CellContextMenuStrip property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler CellContextMenuStripChanged
        {
            add { this.Events.AddHandler(_eventCellContextMenuStripChanged, value); }
            remove { this.Events.RemoveHandler(_eventCellContextMenuStripChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler CellSizeChanged
        {
            add { this.Events.AddHandler(_eventCellSizeChanged, value); }
            remove { this.Events.RemoveHandler(_eventCellSizeChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ColourIndexChanged
        {
            add { this.Events.AddHandler(_eventColourIndexChanged, value); }
            remove { this.Events.RemoveHandler(_eventColourIndexChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ColoursChanged
        {
            add { this.Events.AddHandler(_eventColorsChanged, value); }
            remove { this.Events.RemoveHandler(_eventColorsChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ColumnsChanged
        {
            add { this.Events.AddHandler(_eventColumnsChanged, value); }
            remove { this.Events.RemoveHandler(_eventColumnsChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler CustomColoursChanged
        {
            add { this.Events.AddHandler(_eventCustomColoursChanged, value); }
            remove { this.Events.RemoveHandler(_eventCustomColoursChanged, value); }
        }

        [Category("Action")]
        public event EventHandler<EditColourCancelEventArgs> EditingColour
        {
            add { this.Events.AddHandler(_eventEditingColour, value); }
            remove { this.Events.RemoveHandler(_eventEditingColour, value); }
        }

        [Category("Property Changed")]
        public event EventHandler EditModeChanged
        {
            add { this.Events.AddHandler(_eventEditModeChanged, value); }
            remove { this.Events.RemoveHandler(_eventEditModeChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler HotIndexChanged
        {
            add { this.Events.AddHandler(_eventHotIndexChanged, value); }
            remove { this.Events.RemoveHandler(_eventHotIndexChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler PaletteChanged
        {
            add { this.Events.AddHandler(_eventPaletteChanged, value); }
            remove { this.Events.RemoveHandler(_eventPaletteChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler SelectedCellStyleChanged
        {
            add { this.Events.AddHandler(_eventSelectedCellStyleChanged, value); }
            remove { this.Events.RemoveHandler(_eventSelectedCellStyleChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ShowCustomColoursChanged
        {
            add { this.Events.AddHandler(_eventShowCustomColoursChanged, value); }
            remove { this.Events.RemoveHandler(_eventShowCustomColoursChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ShowToolTipsChanged
        {
            add { this.Events.AddHandler(_eventShowToolTipsChanged, value); }
            remove { this.Events.RemoveHandler(_eventShowToolTipsChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler SpacingChanged
        {
            add { this.Events.AddHandler(_eventSpacingChanged, value); }
            remove { this.Events.RemoveHandler(_eventSpacingChanged, value); }
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
            get { return _autoAddColors; }
            set
            {
                if (this.AutoAddColours != value)
                {
                    _autoAddColors = value;

                    this.OnAutoAddColorsChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(false)]
        public virtual bool AutoFit
        {
            get { return _autoFit; }
            set
            {
                if (this.AutoFit != value)
                {
                    _autoFit = value;

                    this.OnAutoFitChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "ButtonShadow")]
        public virtual Color CellBorderColour
        {
            get { return _cellBorderColour; }
            set
            {
                if (this.CellBorderColour != value)
                {
                    _cellBorderColour = value;

                    this.OnCellBorderColorChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(ColourCellBorderStyle), "FixedSingle")]
        public virtual ColourCellBorderStyle CellBorderStyle
        {
            get { return _cellBorderStyle; }
            set
            {
                if (this.CellBorderStyle != value)
                {
                    _cellBorderStyle = value;

                    this.OnCellBorderStyleChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Behavior")]
        [DefaultValue(typeof(ContextMenuStrip), null)]
        public ContextMenuStrip CellContextMenuStrip
        {
            get { return _cellContextMenuStrip; }
            set
            {
                if (_cellContextMenuStrip != value)
                {
                    _cellContextMenuStrip = value;

                    this.OnCellContextMenuStripChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Size), "12, 12")]
        public virtual Size CellSize
        {
            get { return _cellSize; }
            set
            {
                if (_cellSize != value)
                {
                    _cellSize = value;

                    this.OnCellSizeChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int ColourIndex
        {
            get { return _colorIndex; }
            set
            {
                if (this.ColourIndex != value)
                {
                    _previousColourIndex = _colorIndex;
                    _colorIndex = value;

                    if (value != InvalidIndex)
                    {
                        this.Colour = this.GetColour(value);
                    }

                    this.OnColorIndexChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ColourCollection Colours
        {
            get { return _colours; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (this.Colours != value)
                {
                    this.RemoveEventHandlers(_colours);

                    _colours = value;

                    this.OnColorsChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(16)]
        public virtual int Columns
        {
            get { return _columns; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Number of columns cannot be less than zero.");
                }

                if (this.Columns != value)
                {
                    _columns = value;
                    this.CalculateGridSize();

                    this.OnColumnsChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(false)]
        public Point CurrentCell
        {
            get { return this.GetCell(this.ColourIndex); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ColourCollection CustomColours
        {
            get { return _customColours; }
            set
            {
                if (this.CustomColours != value)
                {
                    this.RemoveEventHandlers(_customColours);

                    _customColours = value;

                    this.OnCustomColorsChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Behavior")]
        [DefaultValue(typeof(ColourEditingMode), "CustomOnly")]
        public virtual ColourEditingMode EditMode
        {
            get { return _editMode; }
            set
            {
                if (this.EditMode != value)
                {
                    _editMode = value;

                    this.OnEditModeChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int HotIndex
        {
            get { return _hotIndex; }
            set
            {
                if (this.HotIndex != value)
                {
                    _previousHotIndex = this.HotIndex;
                    _hotIndex = value;

                    this.OnHotIndexChanged(EventArgs.Empty);
                }
            }
        }

        [DefaultValue(typeof(Padding), "5, 5, 5, 5")]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(ColourPalette), "Named")]
        public virtual ColourPalette Palette
        {
            get { return _palette; }
            set
            {
                if (this.Palette != value)
                {
                    _palette = value;

                    this.OnPaletteChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(ColourGridSelectedCellStyle), "Zoomed")]
        public virtual ColourGridSelectedCellStyle SelectedCellStyle
        {
            get { return _selectedCellStyle; }
            set
            {
                if (this.SelectedCellStyle != value)
                {
                    _selectedCellStyle = value;

                    this.OnSelectedCellStyleChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public virtual bool ShowCustomColors
        {
            get { return _showCustomColours; }
            set
            {
                if (this.ShowCustomColors != value)
                {
                    _showCustomColours = value;

                    this.OnShowCustomColoursChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool ShowToolTips
        {
            get { return _showToolTips; }
            set
            {
                if (this.ShowToolTips != value)
                {
                    _showToolTips = value;

                    this.OnShowToolTipsChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Size), "3, 3")]
        public virtual Size Spacing
        {
            get { return _spacing; }
            set
            {
                if (this.Spacing != value)
                {
                    _spacing = value;

                    this.OnSpacingChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        /// <summary>
        ///   Gets a value indicating whether painting of the control is allowed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if painting of the control is allowed; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool AllowPainting
        {
            get { return _updateCount == 0; }
        }

        protected IDictionary<int, Rectangle> ColorRegions
        {
            get { return _colourRegions; }
        }

        protected int CustomRows { get; set; }

        protected int PrimaryRows { get; set; }

        protected int SeparatorHeight { get; set; }

        protected bool WasKeyPressed { get; set; }

        #endregion

        #region Methods

        public virtual int AddCustomColor(Color value)
        {
            int newIndex;

            newIndex = this.GetColourIndex(value);

            if (newIndex == InvalidIndex)
            {
                if (this.AutoAddColours)
                {
                    this.CustomColours.Add(value);
                }
                else
                {
                    if (this.CustomColours == null)
                    {
                        this.CustomColours = new ColourCollection();
                        this.CustomColours.Add(value);
                    }
                    else
                    {
                        this.CustomColours[0] = value;
                    }

                    newIndex = this.GetColourIndex(value);
                }

                this.RefreshColours();
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

            if (this.AllowPainting)
            {
                this.Invalidate();
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
            if (index < 0 || index > this.Colours.Count + this.CustomColours.Count - 1)
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

            colorCount = this.Colours != null ? this.Colours.Count : 0;
            customColorCount = this.CustomColours != null ? this.CustomColours.Count : 0;

            if (index < 0 || index > colorCount + customColorCount)
            {
                result = Color.Empty;
            }
            else
            {
                result = index > colorCount - 1 ? this.CustomColours[index - colorCount] : this.Colours[index];
            }

            return result;
        }

        public ColourSource GetColourSource(int colourIndex)
        {
            ColourSource result;
            int colourCount;
            int customColourCount;

            colourCount = this.Colours != null ? this.Colours.Count : 0;
            customColourCount = this.CustomColours != null ? this.CustomColours.Count : 0;

            if (colourCount < 0 || colourIndex > colourCount + customColourCount)
            {
                result = ColourSource.NONE;
            }
            else
            {
                result = colourIndex > colourCount - 1 ? ColourSource.CUSTOM : ColourSource.STANDARD;
            }

            return result;
        }

        public ColourSource GetColourSource(Color colour)
        {
            int index;
            ColourSource result;

            index = this.Colours.IndexOf(colour);
            if (index != InvalidIndex)
            {
                result = ColourSource.STANDARD;
            }
            else
            {
                index = this.CustomColours.IndexOf(colour);
                result = index != InvalidIndex ? ColourSource.CUSTOM : ColourSource.NONE;
            }

            return result;
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            return this.AutoSize ? this.GetAutoSize() : base.GetPreferredSize(proposedSize);
        }

        public ColourHitTestInfo HitTest(Point point)
        {
            ColourHitTestInfo result;
            int colourIndex;

            result = new ColourHitTestInfo();
            colourIndex = InvalidIndex;

            foreach (KeyValuePair<int, Rectangle> pair in _colourRegions.Where(pair => pair.Value.Contains(point)))
            {
                colourIndex = pair.Key;
                break;
            }

            result.Index = colourIndex;
            if (colourIndex != InvalidIndex)
            {
                result.Colour = colourIndex < this.Colours.Count + this.CustomColours.Count ? this.GetColour(colourIndex) : Color.White;
                result.Source = this.GetColourSource(colourIndex);
            }
            else
            {
                result.Source = ColourSource.NONE;
            }

            return result;
        }

        public void Invalidate(int index)
        {
            if (this.AllowPainting && index != InvalidIndex)
            {
                Rectangle bounds;

                if (_colourRegions.TryGetValue(index, out bounds))
                {
                    if (this.SelectedCellStyle == ColourGridSelectedCellStyle.ZOOMED)
                    {
                        bounds.Inflate(this.Padding.Left, this.Padding.Top);
                    }

                    this.Invalidate(bounds);
                }
            }
        }

        public void Navigate(int offsetX, int offsetY)
        {
            this.Navigate(offsetX, offsetY, NavigationOrigin.CURRENT);
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
                case NavigationOrigin.BEGIN:
                    cellLocation = Point.Empty;
                    break;
                case NavigationOrigin.END:
                    cellLocation = new Point(this.ActualColumns - 1, this.PrimaryRows + this.CustomRows - 1);
                    break;
                default:
                    cellLocation = this.CurrentCell;
                    break;
            }

            if (cellLocation.X == -1 && cellLocation.Y == -1)
            {
                cellLocation = Point.Empty; // If no cell is selected, assume the first one is for the purpose of keyboard navigation
            }

            offsetCellLocation = this.GetCellOffset(cellLocation, offsetX, offsetY);
            row = offsetCellLocation.Y;
            column = offsetCellLocation.X;
            index = this.GetCellIndex(column, row);
            if (index != InvalidIndex)
            {
                this.ColourIndex = index;
            }
        }

        protected virtual void CalculateCellSize()
        {
            int w;
            int h;

            w = (this.ClientSize.Width - this.Padding.Horizontal) / this.ActualColumns - this.Spacing.Width;
            h = (this.ClientSize.Height - this.Padding.Vertical) / (this.PrimaryRows + this.CustomRows) - this.Spacing.Height;

            if (w > 0 && h > 0)
            {
                this.CellSize = new Size(w, h);
            }
        }

        protected virtual void CalculateGridSize()
        {
            int primaryRows;
            int customRows;

            this.ActualColumns = this.Columns != 0 ? this.Columns : (this.ClientSize.Width + this.Spacing.Width - this.Padding.Vertical) / (_scaledCellSize.Width + this.Spacing.Width);
            if (this.ActualColumns < 1)
            {
                this.ActualColumns = 1;
            }

            primaryRows = this.GetRows(this.Colours != null ? this.Colours.Count : 0);
            if (primaryRows == 0)
            {
                primaryRows = 1;
            }

            customRows = this.ShowCustomColors ? this.GetRows(this.CustomColours != null ? this.CustomColours.Count : 0) : 0;

            this.PrimaryRows = primaryRows;
            this.CustomRows = customRows;
        }

        protected virtual Brush CreateTransparencyBrush()
        {
            Type type;

            type = typeof(ColourGridControl);

            using (Bitmap background = new Bitmap(type.Assembly.GetManifestResourceStream(string.Concat(type.Namespace, ".Resources.cellbackground.png"))))
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

                rows = this.GetRows(colours.Count);
                index = 0;

                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < this.ActualColumns; column++)
                    {
                        if (index < colours.Count)
                        {
                            _colourRegions.Add(rangeStart + index, new Rectangle(this.Padding.Left + column * (_scaledCellSize.Width + this.Spacing.Width), offset + row * (_scaledCellSize.Height + this.Spacing.Height), _scaledCellSize.Width, _scaledCellSize.Height));
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
                this.RemoveEventHandlers(_colours);
                this.RemoveEventHandlers(_customColours);

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

            offset = this.CustomRows != 0 ? this.SeparatorHeight : 0;
            if (this.Columns != 0)
            {
                width = (_scaledCellSize.Width + this.Spacing.Width) * this.ActualColumns + this.Padding.Horizontal - this.Spacing.Width;
            }
            else
            {
                width = this.ClientSize.Width;
            }

            return new Size(width, (_scaledCellSize.Height + this.Spacing.Height) * (this.PrimaryRows + this.CustomRows) + offset + this.Padding.Vertical - this.Spacing.Height);
        }

        protected int GetCellIndex(Point point)
        {
            return this.GetCellIndex(point.X, point.Y);
        }

        protected virtual int GetCellIndex(int column, int row)
        {
            int result;

            if (column >= 0 && column < this.ActualColumns && row >= 0 && row < this.PrimaryRows + this.CustomRows)
            {
                int lastStandardRowOffset;

                lastStandardRowOffset = this.PrimaryRows * this.ActualColumns - this.Colours.Count;
                result = row * this.ActualColumns + column;
                if (row == this.PrimaryRows - 1 && column >= this.ActualColumns - lastStandardRowOffset)
                {
                    result -= lastStandardRowOffset;
                }
                if (row >= this.PrimaryRows)
                {
                    result -= lastStandardRowOffset;
                }

                if (result > this.Colours.Count + this.CustomColours.Count - 1)
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
            return this.GetCellOffset(this.CurrentCell, columnOffset, rowOffset);
        }

        protected Point GetCellOffset(Point cell, int columnOffset, int rowOffset)
        {
            int row;
            int column;
            int lastStandardRowOffset;
            int lastStandardRowLastColumn;

            lastStandardRowOffset = this.PrimaryRows * this.ActualColumns - this.Colours.Count;
            lastStandardRowLastColumn = this.ActualColumns - lastStandardRowOffset;
            column = cell.X + columnOffset;
            row = cell.Y + rowOffset;

            // if the row is the last row, but there aren't enough columns to fill the row - nudge it to the last available
            if (row == this.PrimaryRows - 1 && column >= lastStandardRowLastColumn)
            {
                column = lastStandardRowLastColumn - 1;
            }

            // wrap the column to the end of the previous row
            if (column < 0)
            {
                column = this.ActualColumns - 1;
                row--;
                if (row == this.PrimaryRows - 1)
                {
                    column = this.ActualColumns - (lastStandardRowOffset + 1);
                }
            }

            // wrap to column to the start of the next row
            if (row == this.PrimaryRows - 1 && column >= this.ActualColumns - lastStandardRowOffset || column >= this.ActualColumns)
            {
                column = 0;
                row++;
            }

            return new Point(column, row);
        }

        protected virtual int GetColourIndex(Color value)
        {
            int index;

            index = this.Colours != null ? this.Colours.IndexOf(value) : InvalidIndex;
            if (index == InvalidIndex && this.ShowCustomColors && this.CustomColours != null)
            {
                index = this.CustomColours.IndexOf(value);
                if (index != InvalidIndex)
                {
                    index += this.Colours.Count;
                }
            }

            return index;
        }

        protected virtual ColourCollection GetPredefinedPalette()
        {
            return ColourPalettes.GetPalette(this.Palette);
        }

        protected int GetRows(int count)
        {
            int rows;

            if (count != 0 && this.ActualColumns > 0)
            {
                rows = count / this.ActualColumns;
                if (count % this.ActualColumns != 0)
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

            if (keyData == Keys.Left || keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Right || keyData == Keys.Enter || keyData == Keys.Home || keyData == Keys.End)
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

            handler = (EventHandler)this.Events[_eventAutoAddColoursChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="AutoFitChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnAutoFitChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.AutoFit && this.AutoSize)
            {
                this.AutoSize = false;
            }

            this.RefreshColours();

            handler = (EventHandler)this.Events[_eventAutoFitChanged];

            handler?.Invoke(this, e);
        }

        protected override void OnAutoSizeChanged(EventArgs e)
        {
            if (this.AutoSize && this.AutoFit)
            {
                this.AutoFit = false;
            }

            base.OnAutoSizeChanged(e);

            if (this.AutoSize)
            {
                this.SizeToFit();
            }
        }

        /// <summary>
        /// Raises the <see cref="CellBorderColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnCellBorderColorChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.AllowPainting)
            {
                this.Invalidate();
            }

            handler = (EventHandler)this.Events[_eventCellBorderColourChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="CellBorderStyleChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnCellBorderStyleChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.AllowPainting)
            {
                this.Invalidate();
            }

            handler = (EventHandler)this.Events[_eventCellBorderStyleChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="CellContextMenuStripChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnCellContextMenuStripChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)this.Events[_eventCellContextMenuStripChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="CellSizeChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnCellSizeChanged(EventArgs e)
        {
            EventHandler handler;

            this.SetScaledCellSize();

            if (this.AutoSize)
            {
                this.SizeToFit();
            }

            if (this.AllowPainting)
            {
                this.RefreshColours();
                this.Invalidate();
            }

            handler = (EventHandler)this.Events[_eventCellSizeChanged];

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
                _scaledCellSize = new Size((int)(_cellSize.Width * scaleX), (int)(_cellSize.Height * scaleY));
            }
            else
            {
                _scaledCellSize = _cellSize;
            }

            Debug.WriteLine(_scaledCellSize);
        }

        /// <summary>
        /// Raises the <see cref="ColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)this.Events[_eventColourChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColourIndexChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorIndexChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.AllowPainting)
            {
                this.Invalidate(_previousColourIndex);
                this.Invalidate(this.ColourIndex);
            }

            handler = (EventHandler)this.Events[_eventColourIndexChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColoursChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorsChanged(EventArgs e)
        {
            EventHandler handler;

            this.AddEventHandlers(this.Colours);

            this.RefreshColours();

            handler = (EventHandler)this.Events[_eventColorsChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColumnsChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColumnsChanged(EventArgs e)
        {
            EventHandler handler;

            this.RefreshColours();

            handler = (EventHandler)this.Events[_eventColumnsChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="CustomColoursChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnCustomColorsChanged(EventArgs e)
        {
            EventHandler handler;

            this.AddEventHandlers(this.CustomColours);
            this.RefreshColours();

            handler = (EventHandler)this.Events[_eventCustomColoursChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="EditingColour" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EditColourCancelEventArgs" /> instance containing the event data.</param>
        protected virtual void OnEditingColour(EditColourCancelEventArgs e)
        {
            EventHandler<EditColourCancelEventArgs> handler;

            handler = (EventHandler<EditColourCancelEventArgs>)this.Events[_eventEditingColour];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="EditModeChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnEditModeChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)this.Events[_eventEditModeChanged];

            handler?.Invoke(this, e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.AllowPainting)
            {
                this.Invalidate(this.ColourIndex);
            }
        }

        /// <summary>
        /// Raises the <see cref="HotIndexChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnHotIndexChanged(EventArgs e)
        {
            EventHandler handler;

            this.SetToolTip();

            if (this.AllowPainting)
            {
                this.Invalidate(_previousHotIndex);
                this.Invalidate(this.HotIndex);
            }

            handler = (EventHandler)this.Events[_eventHotIndexChanged];

            handler?.Invoke(this, e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            this.WasKeyPressed = true;

            switch (e.KeyData)
            {
                case Keys.Down:
                    this.Navigate(0, 1);
                    e.Handled = true;
                    break;
                case Keys.Up:
                    this.Navigate(0, -1);
                    e.Handled = true;
                    break;
                case Keys.Left:
                    this.Navigate(-1, 0);
                    e.Handled = true;
                    break;
                case Keys.Right:
                    this.Navigate(1, 0);
                    e.Handled = true;
                    break;
                case Keys.Home:
                    this.Navigate(0, 0, NavigationOrigin.BEGIN);
                    e.Handled = true;
                    break;
                case Keys.End:
                    this.Navigate(0, 0, NavigationOrigin.END);
                    e.Handled = true;
                    break;
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (this.WasKeyPressed && this.ColourIndex != InvalidIndex)
            {
                switch (e.KeyData)
                {
                    case Keys.Enter:
                        ColourSource source;

                        source = this.GetColourSource(this.ColourIndex);

                        if (source == ColourSource.CUSTOM && this.EditMode != ColourEditingMode.NONE || source == ColourSource.STANDARD && this.EditMode == ColourEditingMode.BOTH)
                        {
                            e.Handled = true;

                            this.StartColorEdit(this.ColourIndex);
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

                        this.ShowContextMenu(new Point(x, y));
                        break;
                }
            }

            this.WasKeyPressed = false;

            base.OnKeyUp(e);
        }

        private Size _scaledCellSize;

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (this.AllowPainting)
            {
                this.Invalidate(this.ColourIndex);
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            ColourHitTestInfo hitTest;

            base.OnMouseDoubleClick(e);

            hitTest = this.HitTest(e.Location);

            if (e.Button == MouseButtons.Left && (hitTest.Source == ColourSource.CUSTOM && this.EditMode != ColourEditingMode.NONE || hitTest.Source == ColourSource.STANDARD && this.EditMode == ColourEditingMode.BOTH))
            {
                this.StartColorEdit(hitTest.Index);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!this.Focused && this.TabStop)
            {
                this.Focus();
            }

            this.ProcessMouseClick(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.HotIndex = InvalidIndex;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            this.HotIndex = this.HitTest(e.Location).Index;

            this.ProcessMouseClick(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Right)
            {
                int index;

                index = this.HitTest(e.Location).Index;

                if (index != InvalidIndex)
                {
                    this.Focus();
                    this.ColourIndex = index;

                    this.ShowContextMenu(e.Location);
                }
            }
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);

            if (this.AllowPainting)
            {
                this.RefreshColours();
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.AllowPainting)
            {
                int colorCount;

                colorCount = this.Colours.Count;

                Debug.Print(e.ClipRectangle.Size == this.ClientSize ? "Performing full paint!" : "Performing partial paint!");

                this.OnPaintBackground(e); // HACK: Easiest way of supporting things like BackgroundImage, BackgroundImageLayout etc as the PaintBackground event is no longer being called

                // draw a design time dotted grid
                if (this.DesignMode)
                {
                    using (Pen pen = new Pen(SystemColors.ButtonShadow)
                    {
                        DashStyle = DashStyle.Dot
                    })
                    {
                        e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }

                // draw cells for all current colors
                for (int i = 0; i < colorCount; i++)
                {
                    Rectangle bounds;

                    bounds = _colourRegions[i];
                    if (e.ClipRectangle.IntersectsWith(bounds))
                    {
                        this.PaintCell(e, i, i, this.Colours[i], bounds);
                    }
                }

                if (this.CustomColours.Count != 0 && this.ShowCustomColors)
                {
                    // draw a separator
                    this.PaintSeparator(e);

                    // and the custom colors
                    for (int i = 0; i < this.CustomColours.Count; i++)
                    {
                        Rectangle bounds;

                        if (_colourRegions.TryGetValue(colorCount + i, out bounds) && e.ClipRectangle.IntersectsWith(bounds))
                        {
                            this.PaintCell(e, i, colorCount + i, this.CustomColours[i], bounds);
                        }
                    }
                }

                // draw the selected color
                if (this.SelectedCellStyle != ColourGridSelectedCellStyle.NONE && this.ColourIndex >= 0)
                {
                    Rectangle bounds;

                    if (_colourRegions.TryGetValue(this.ColourIndex, out bounds) && e.ClipRectangle.IntersectsWith(bounds))
                    {
                        this.PaintSelectedCell(e, this.ColourIndex, this.Colour, bounds);
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

            this.Colours = this.GetPredefinedPalette();

            handler = (EventHandler)this.Events[_eventPaletteChanged];

            handler?.Invoke(this, e);
        }

        protected override void OnResize(EventArgs e)
        {
            this.RefreshColours();

            base.OnResize(e);
        }

        /// <summary>
        /// Raises the <see cref="SelectedCellStyleChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnSelectedCellStyleChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.AllowPainting)
            {
                this.Invalidate();
            }

            handler = (EventHandler)this.Events[_eventSelectedCellStyleChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ShowCustomColoursChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowCustomColoursChanged(EventArgs e)
        {
            EventHandler handler;

            this.RefreshColours();

            handler = (EventHandler)this.Events[_eventShowCustomColoursChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ShowToolTipsChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowToolTipsChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.ShowToolTips)
            {
                _toolTip = new ToolTip();
            }
            else if (_toolTip != null)
            {
                _toolTip.Dispose();
                _toolTip = null;
            }

            handler = (EventHandler)this.Events[_eventShowToolTipsChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="SpacingChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnSpacingChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.AutoSize)
            {
                this.SizeToFit();
            }

            if (this.AllowPainting)
            {
                this.RefreshColours();
                this.Invalidate();
            }

            handler = (EventHandler)this.Events[_eventSpacingChanged];

            handler?.Invoke(this, e);
        }

        protected virtual void PaintCell(PaintEventArgs e, int colourIndex, int cellIndex, Color colour, Rectangle bounds)
        {
            if (colour.A != 255)
            {
                this.PaintTransparentCell(e, bounds);
            }

            using (Brush brush = new SolidBrush(colour))
            {
                e.Graphics.FillRectangle(brush, bounds);
            }

            switch (this.CellBorderStyle)
            {
                case ColourCellBorderStyle.FIXEDSINGLE:
                    using (Pen pen = new Pen(this.CellBorderColour))
                    {
                        e.Graphics.DrawRectangle(pen, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
                    }
                    break;
                case ColourCellBorderStyle.DOUBLESOFT:
                    HSLColourStructure shadedOuter;
                    HSLColourStructure shadedInner;

                    shadedOuter = new HSLColourStructure(colour);
                    shadedOuter.L -= 0.50;

                    shadedInner = new HSLColourStructure(colour);
                    shadedInner.L -= 0.20;

                    using (Pen pen = new Pen(this.CellBorderColour))
                    {
                        e.Graphics.DrawRectangle(pen, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
                    }
                    e.Graphics.DrawRectangle(Pens.White, bounds.Left + 1, bounds.Top + 1, bounds.Width - 3, bounds.Height - 3);
                    using (Pen pen = new Pen(Color.FromArgb(32, shadedOuter.ToRgbColour())))
                    {
                        e.Graphics.DrawRectangle(pen, bounds.Left + 2, bounds.Top + 2, bounds.Width - 5, bounds.Height - 5);
                    }
                    using (Pen pen = new Pen(Color.FromArgb(32, shadedInner.ToRgbColour())))
                    {
                        e.Graphics.DrawRectangle(pen, bounds.Left + 3, bounds.Top + 3, bounds.Width - 7, bounds.Height - 7);
                    }
                    break;
            }

            if (this.HotIndex != InvalidIndex && this.HotIndex == cellIndex)
            {
                e.Graphics.DrawRectangle(Pens.Black, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
                e.Graphics.DrawRectangle(Pens.White, bounds.Left + 1, bounds.Top + 1, bounds.Width - 3, bounds.Height - 3);
            }
        }

        protected virtual void PaintSelectedCell(PaintEventArgs e, int colorIndex, Color color, Rectangle bounds)
        {
            switch (this.SelectedCellStyle)
            {
                case ColourGridSelectedCellStyle.STANDARD:
                    if (this.Focused)
                    {
                        ControlPaint.DrawFocusRectangle(e.Graphics, bounds);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(Pens.Black, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
                    }
                    break;
                case ColourGridSelectedCellStyle.ZOOMED:
                    // make the cell larger according to the padding
                    if (this.SelectedCellStyle == ColourGridSelectedCellStyle.ZOOMED)
                    {
                        bounds.Inflate(this.Padding.Left, this.Padding.Top);
                    }

                    // fill the inner
                    e.Graphics.FillRectangle(Brushes.White, bounds);
                    if (this.SelectedCellStyle == ColourGridSelectedCellStyle.ZOOMED)
                    {
                        bounds.Inflate(-3, -3);
                    }
                    if (color.A != 255)
                    {
                        this.PaintTransparentCell(e, bounds);
                    }

                    using (Brush brush = new SolidBrush(color))
                    {
                        e.Graphics.FillRectangle(brush, bounds);
                    }

                    // draw a border
                    if (this.Focused)
                    {
                        bounds = new Rectangle(bounds.Left - 2, bounds.Top - 2, bounds.Width + 4, bounds.Height + 4);
                        ControlPaint.DrawFocusRectangle(e.Graphics, bounds);
                    }
                    else
                    {
                        bounds = new Rectangle(bounds.Left - 2, bounds.Top - 2, bounds.Width + 3, bounds.Height + 3);

                        using (Pen pen = new Pen(this.CellBorderColour))
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

            x1 = this.Padding.Left;
            x2 = this.ClientSize.Width - this.Padding.Right;
            y1 = this.SeparatorHeight / 2 + this.Padding.Top + this.PrimaryRows * (_scaledCellSize.Height + this.Spacing.Height) + 1 - this.Spacing.Height;
            y2 = y1;

            using (Pen pen = new Pen(this.CellBorderColour))
            {
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        protected virtual void PaintTransparentCell(PaintEventArgs e, Rectangle bounds)
        {
            if (_cellBackgroundBrush == null)
            {
                _cellBackgroundBrush = this.CreateTransparencyBrush();
            }

            e.Graphics.FillRectangle(_cellBackgroundBrush, bounds);
        }

        protected virtual void ProcessMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ColourHitTestInfo hitTest;

                hitTest = this.HitTest(e.Location);

                if (hitTest.Source != ColourSource.NONE)
                {
                    this.Colour = hitTest.Colour;
                    this.ColourIndex = hitTest.Index;
                }
            }
        }

        protected virtual void RefreshColours()
        {
            if (this.AllowPainting)
            {
                Debug.Print("Calculating colours...");

                this.CalculateGridSize();
                if (this.AutoFit)
                {
                    this.CalculateCellSize();
                }
                else if (this.AutoSize)
                {
                    this.SizeToFit();
                }

                _colourRegions.Clear();

                if (this.Colours != null)
                {
                    this.DefineColourRegions(this.Colours, 0, this.Padding.Top);
                    if (this.ShowCustomColors)
                    {
                        this.DefineColourRegions(this.CustomColours, this.Colours.Count, this.Padding.Top + this.SeparatorHeight + (_scaledCellSize.Height + this.Spacing.Height) * this.PrimaryRows);
                    }

                    this.ColourIndex = this.GetColourIndex(this.Colour);

                    if (!this.Colour.IsEmpty && this.ColourIndex == InvalidIndex && this.AutoAddColours && this.ShowCustomColors)
                    {
                        this.AddCustomColor(this.Colour);
                    }

                    this.Invalidate();
                }
            }
        }

        protected virtual void SetColour(int colourIndex, Color colour)
        {
            int colourCount;

            colourCount = this.Colours.Count;

            if (colourIndex < 0 || colourIndex > colourCount + this.CustomColours.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(colourIndex));
            }

            if (colourIndex > colourCount - 1)
            {
                this.CustomColours[colourIndex - colourCount] = colour;
            }
            else
            {
                this.Colours[colourIndex] = colour;
            }
        }

        private void AddEventHandlers(ColourCollection value)
        {
            if (value != null)
            {
                value.ItemInserted += this.ColoursCollectionChangedHandler;
                value.ItemRemoved += this.ColoursCollectionChangedHandler;
                value.ItemsCleared += this.ColoursCollectionChangedHandler;
                value.ItemReplaced += this.ColoursCollectionItemReplacedHandler;
            }
        }

        private void ColoursCollectionChangedHandler(object sender, ColourCollectionEventArgs e)
        {
            this.RefreshColours();
        }

        private void ColoursCollectionItemReplacedHandler(object sender, ColourCollectionEventArgs e)
        {
            ColourCollection collection;
            int index;

            collection = (ColourCollection)sender;
            index = _colorIndex;
            if (index != InvalidIndex && ReferenceEquals(collection, this.CustomColours))
            {
                index -= this.Colours.Count;
            }

            if (index >= 0 && index < collection.Count && collection[index] != this.Colour)
            {
                Debug.Print("Replacing index {0} with {1}", index, collection[index]);

                _previousColourIndex = index;
                _colorIndex = -1;
                this.ColourIndex = index;
            }

            this.Invalidate(e.Index);
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
            else if (index >= this.Colours.Count)
            {
                // custom color
                index -= this.Colours.Count;
                row = index / this.ActualColumns;
                column = index - row * this.ActualColumns;
                row += this.PrimaryRows;
            }
            else
            {
                // normal row
                row = index / this.ActualColumns;
                column = index - row * this.ActualColumns;
            }

            return new Point(column, row);
        }

        private void RemoveEventHandlers(ColourCollection value)
        {
            if (value != null)
            {
                value.ItemInserted -= this.ColoursCollectionChangedHandler;
                value.ItemRemoved -= this.ColoursCollectionChangedHandler;
                value.ItemsCleared -= this.ColoursCollectionChangedHandler;
                value.ItemReplaced -= this.ColoursCollectionItemReplacedHandler;
            }
        }

        private void SetToolTip()
        {
            if (this.ShowToolTips)
            {
                if (this.ShowToolTips)
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
                    _toolTip.SetToolTip(this, this.HotIndex != InvalidIndex ? this.GetColour(this.HotIndex).Name : null);
#endif
                }
            }
        }

        private void ShowContextMenu(Point location)
        {
            _cellContextMenuStrip?.Show(this, location);
        }

        private void SizeToFit()
        {
            this.Size = this.GetAutoSize();
        }

        private void StartColorEdit(int index)
        {
            EditColourCancelEventArgs e;

            e = new EditColourCancelEventArgs(this.GetColour(index), index);
            this.OnEditingColour(e);

            if (!e.Cancel)
            {
                this.EditColour(index);
            }
        }

        #endregion

        #region IColorEditor Interface

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add { this.Events.AddHandler(_eventColourChanged, value); }
            remove { this.Events.RemoveHandler(_eventColourChanged, value); }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
        public virtual Color Colour
        {
            get { return _colour; }
            set
            {
                int newIndex;

                _colour = value;

                if (!value.IsEmpty)
                {
                    // the new color matches the color at the current index, so don't change the index
                    // this stops the selection hopping about if you have duplicate colors in a palette
                    // otherwise, if the colors don't match, then find the index that does
                    newIndex = this.GetColour(this.ColourIndex) == value ? this.ColourIndex : this.GetColourIndex(value);

                    if (newIndex == InvalidIndex)
                    {
                        newIndex = this.AddCustomColor(value);
                    }
                }
                else
                {
                    newIndex = InvalidIndex;
                }

                this.ColourIndex = newIndex;

                this.OnColorChanged(EventArgs.Empty);
            }
        }

        #endregion
    }
}