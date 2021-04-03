using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.Colour.Picker
{
    /// <summary>
    /// Represents a grid control, which displays a collection of colors using different styles.
    /// </summary>
    [DefaultProperty("Colour")]
    [DefaultEvent("ColourChanged")]
    public class ColourGrid : Control, IColourEditor
    {
        #region Constants
        private const int INVALID_INDEX = -1;
        #endregion

        #region Read Only
        private readonly IDictionary<int, Rectangle> _colourRegions;

        private static readonly object _eventAutoAddColoursChanged = new object(), _eventAutoFitChanged = new object(),
                                       _eventCellBorderColourChanged = new object(), _eventCellBorderStyleChanged = new object(),
                                       _eventCellContextMenuStripChanged = new object(), _eventCellSizeChanged = new object(),
                                       _eventColourChanged = new object(), _eventColourIndexChanged = new object(),
                                       _eventColoursChanged = new object(), _eventColumnsChanged = new object(),
                                       _eventCustomColoursChanged = new object(), _eventEditingColour = new object(),
                                       _eventEditModeChanged = new object(), _eventHotIndexChanged = new object(),
                                       _eventPaletteChanged = new object(), _eventSelectedCellStyleChanged = new object(),
                                       _eventShowCustomColoursChanged = new object(), _eventShowToolTipsChanged = new object(),
                                       _eventSpacingChanged = new object();
        #endregion

        #region Variables
        private bool _autoAddColours, _autoFit, _showCustomColours, _showToolTips;

        private Brush _cellBackgroundBrush;

        private Color _cellBorderColour, _colour;

        private ColourCellBorderStyle _cellBorderStyle;

        private ColourCollection _colours, _customColours;

        private ColourPalette _palette;

        private ColourEditingMode _colourEditingMode;

        private ColourGridSelectedCellStyle _selectedCellStyle;

        private ContextMenuStrip _cellContextMenu;

        private int _colourIndex, _columns, _hotIndex, _previousColourIndex, _previousHotIndex, _updateCount;

        private ToolTip _toolTip;

        private Size _cellSize, _spacing;
        #endregion

        #region Properties
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ActualColumns { get; protected set; }

        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool AutoAddColours
        {
            get { return _autoAddColours; }
            set
            {
                if (this.AutoAddColours != value)
                {
                    _autoAddColours = value;

                    this.OnAutoAddColoursChanged(EventArgs.Empty);
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

                    this.OnCellBorderColourChanged(EventArgs.Empty);
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
            get { return _cellContextMenu; }
            set
            {
                if (_cellContextMenu != value)
                {
                    _cellContextMenu = value;

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
            get { return _colourIndex; }
            set
            {
                if (this.ColourIndex != value)
                {
                    _previousColourIndex = _colourIndex;
                    _colourIndex = value;

                    if (value != INVALID_INDEX)
                    {
                        this.Colour = this.GetColour(value);
                    }

                    this.OnColourIndexChanged(EventArgs.Empty);
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

                    this.OnColoursChanged(EventArgs.Empty);
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
            get { return this.GetCell(this.ColorIndex); }
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
        public virtual bool ShowCustomColours
        {
            get => _showCustomColours;

            set
            {
                if (ShowCustomColours != value)
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
            get => _showToolTips;

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

        protected IDictionary<int, Rectangle> ColourRegions => _colourRegions;

        protected int CustomRows { get; set; }

        protected int PrimaryRows { get; set; }

        protected int SeparatorHeight { get; set; }

        protected bool WasKeyPressed { get; set; }
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
            add { this.Events.AddHandler(_eventColoursChanged, value); }
            remove { this.Events.RemoveHandler(_eventColoursChanged, value); }
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

        #region Constructor
        public ColourGrid()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick | ControlStyles.SupportsTransparentBackColor, true);

            _previousHotIndex = INVALID_INDEX;

            _previousColourIndex = INVALID_INDEX;

            _hotIndex = INVALID_INDEX;

            _colourRegions = new Dictionary<int, Rectangle>();

            _colours = ColourPalettes.NamedColours;

            _customColours = new ColourCollection(Enumerable.Repeat(Color.White, 16));

            _showCustomColours = true;

            _cellSize = new Size(12, 12);

            _spacing = new Size(3, 3);
        }
        #endregion

        #region IColourEditor Implementation
        [Category("Appearance"), DefaultValue(typeof(Color), "Black")]
        public Color Colour
        {
            get => _colour;

            set
            {
                int newIndex;

                _colour = value;

                if (!value.IsEmpty)
                {
                    newIndex = GetColour(ColourIndex) == value ? ColourIndex : GetColourIndex(value);

                    if (newIndex == INVALID_INDEX)
                    {
                        newIndex = AddCustomColour(value);
                    }
                }
                else
                {
                    newIndex = INVALID_INDEX;
                }

                ColourIndex = newIndex;

                OnColourChanged(EventArgs.Empty);
            }
        }

        [Category("Property Changed")]
        public event EventHandler ColourChanged { add => Events.AddHandler(_eventColourChanged, value); remove => Events.RemoveHandler(_eventColourChanged, value); }
        #endregion
    }
}