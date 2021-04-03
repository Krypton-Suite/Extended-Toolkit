using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2017 Cyotek Ltd.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  /// <summary>
  /// Represents a grid control, which displays a collection of colors using different styles.
  /// </summary>
  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  public class ColorGrid : Control, IColorEditor
  {
    #region Constants

    public const int InvalidIndex = -1;

    private readonly IDictionary<int, Rectangle> _colorRegions;

    private static readonly object _eventAutoAddColorsChanged = new object();

    private static readonly object _eventAutoFitChanged = new object();

    private static readonly object _eventCellBorderColorChanged = new object();

    private static readonly object _eventCellBorderStyleChanged = new object();

    private static readonly object _eventCellContextMenuStripChanged = new object();

    private static readonly object _eventCellSizeChanged = new object();

    private static readonly object _eventColorChanged = new object();

    private static readonly object _eventColorIndexChanged = new object();

    private static readonly object _eventColorsChanged = new object();

    private static readonly object _eventColumnsChanged = new object();

    private static readonly object _eventCustomColorsChanged = new object();

    private static readonly object _eventEditingColor = new object();

    private static readonly object _eventEditModeChanged = new object();

    private static readonly object _eventHotIndexChanged = new object();

    private static readonly object _eventPaletteChanged = new object();

    private static readonly object _eventSelectedCellStyleChanged = new object();

    private static readonly object _eventShowCustomColorsChanged = new object();

    private static readonly object _eventShowToolTipsChanged = new object();

    private static readonly object _eventSpacingChanged = new object();

    #endregion

    #region Fields

    private bool _autoAddColors;

    private bool _autoFit;

    private Brush _cellBackgroundBrush;

    private Color _cellBorderColor;

    private ColorCellBorderStyle _cellBorderStyle;

    private ContextMenuStrip _cellContextMenuStrip;

    private Size _cellSize;

    private Color _color;

    private int _colorIndex;

    private ColorCollection _colors;

    private int _columns;

    private ColorCollection _customColors;

    private ColorEditingMode _editMode;

    private int _hotIndex;

    private ColorPalette _palette;

    private int _previousColorIndex;

    private int _previousHotIndex;

    private ColorGridSelectedCellStyle _selectedCellStyle;

    private bool _showCustomColors;

    private bool _showToolTips;

    private Size _spacing;

    private ToolTip _toolTip;

    private int _updateCount;

    #endregion

    #region Constructors

    public ColorGrid()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick | ControlStyles.SupportsTransparentBackColor, true);
      _previousHotIndex = InvalidIndex;
      _previousColorIndex = InvalidIndex;
      _hotIndex = InvalidIndex;

      _colorRegions = new Dictionary<int, Rectangle>();
      _colors = ColorPalettes.NamedColors;
      _customColors = new ColorCollection(Enumerable.Repeat(Color.White, 16));
      _showCustomColors = true;
      _cellSize = new Size(12, 12);
      _spacing = new Size(3, 3);
      _columns = 16;
      base.AutoSize = true;
      this.Padding = new Padding(5);
      _autoAddColors = true;
      _cellBorderColor = SystemColors.ButtonShadow;
      _showToolTips = true;
      _toolTip = new ToolTip();
      this.SeparatorHeight = 8;
      _editMode = ColorEditingMode.CustomOnly;
      _color = Color.Black;
      _cellBorderStyle = ColorCellBorderStyle.FixedSingle;
      _selectedCellStyle = ColorGridSelectedCellStyle.Zoomed;
      _palette = ColorPalette.Named;

      this.SetScaledCellSize();
      this.RefreshColors();
    }

    #endregion

    #region Events

    [Category("Property Changed")]
    public event EventHandler AutoAddColorsChanged
    {
      add { this.Events.AddHandler(_eventAutoAddColorsChanged, value); }
      remove { this.Events.RemoveHandler(_eventAutoAddColorsChanged, value); }
    }

    [Category("Property Changed")]
    public event EventHandler AutoFitChanged
    {
      add { this.Events.AddHandler(_eventAutoFitChanged, value); }
      remove { this.Events.RemoveHandler(_eventAutoFitChanged, value); }
    }

    [Category("Property Changed")]
    public event EventHandler CellBorderColorChanged
    {
      add { this.Events.AddHandler(_eventCellBorderColorChanged, value); }
      remove { this.Events.RemoveHandler(_eventCellBorderColorChanged, value); }
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
    public event EventHandler ColorIndexChanged
    {
      add { this.Events.AddHandler(_eventColorIndexChanged, value); }
      remove { this.Events.RemoveHandler(_eventColorIndexChanged, value); }
    }

    [Category("Property Changed")]
    public event EventHandler ColorsChanged
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
    public event EventHandler CustomColorsChanged
    {
      add { this.Events.AddHandler(_eventCustomColorsChanged, value); }
      remove { this.Events.RemoveHandler(_eventCustomColorsChanged, value); }
    }

    [Category("Action")]
    public event EventHandler<EditColorCancelEventArgs> EditingColor
    {
      add { this.Events.AddHandler(_eventEditingColor, value); }
      remove { this.Events.RemoveHandler(_eventEditingColor, value); }
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
    public event EventHandler ShowCustomColorsChanged
    {
      add { this.Events.AddHandler(_eventShowCustomColorsChanged, value); }
      remove { this.Events.RemoveHandler(_eventShowCustomColorsChanged, value); }
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
    public virtual bool AutoAddColors
    {
      get { return _autoAddColors; }
      set
      {
        if (this.AutoAddColors != value)
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
    public virtual Color CellBorderColor
    {
      get { return _cellBorderColor; }
      set
      {
        if (this.CellBorderColor != value)
        {
          _cellBorderColor = value;

          this.OnCellBorderColorChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(ColorCellBorderStyle), "FixedSingle")]
    public virtual ColorCellBorderStyle CellBorderStyle
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
    public virtual int ColorIndex
    {
      get { return _colorIndex; }
      set
      {
        if (this.ColorIndex != value)
        {
          _previousColorIndex = _colorIndex;
          _colorIndex = value;

          if (value != InvalidIndex)
          {
            this.Color = this.GetColor(value);
          }

          this.OnColorIndexChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual ColorCollection Colors
    {
      get { return _colors; }
      set
      {
        if (value == null)
        {
          throw new ArgumentNullException(nameof(value));
        }

        if (this.Colors != value)
        {
          this.RemoveEventHandlers(_colors);

          _colors = value;

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
      get { return this.GetCell(this.ColorIndex); }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual ColorCollection CustomColors
    {
      get { return _customColors; }
      set
      {
        if (this.CustomColors != value)
        {
          this.RemoveEventHandlers(_customColors);

          _customColors = value;

          this.OnCustomColorsChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(typeof(ColorEditingMode), "CustomOnly")]
    public virtual ColorEditingMode EditMode
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
    [DefaultValue(typeof(ColorPalette), "Named")]
    public virtual ColorPalette Palette
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
    [DefaultValue(typeof(ColorGridSelectedCellStyle), "Zoomed")]
    public virtual ColorGridSelectedCellStyle SelectedCellStyle
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
      get { return _showCustomColors; }
      set
      {
        if (this.ShowCustomColors != value)
        {
          _showCustomColors = value;

          this.OnShowCustomColorsChanged(EventArgs.Empty);
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
      get { return _colorRegions; }
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

      newIndex = this.GetColorIndex(value);

      if (newIndex == InvalidIndex)
      {
        if (this.AutoAddColors)
        {
          this.CustomColors.Add(value);
        }
        else
        {
          if (this.CustomColors == null)
          {
            this.CustomColors = new ColorCollection();
            this.CustomColors.Add(value);
          }
          else
          {
            this.CustomColors[0] = value;
          }

          newIndex = this.GetColorIndex(value);
        }

        this.RefreshColors();
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
      if (index < 0 || index > this.Colors.Count + this.CustomColors.Count - 1)
      {
        throw new ArgumentOutOfRangeException(nameof(index));
      }

      return _colorRegions[index];
    }

    public Color GetColor(int index)
    {
      Color result;
      int colorCount;
      int customColorCount;

      colorCount = this.Colors != null ? this.Colors.Count : 0;
      customColorCount = this.CustomColors != null ? this.CustomColors.Count : 0;

      if (index < 0 || index > colorCount + customColorCount)
      {
        result = Color.Empty;
      }
      else
      {
        result = index > colorCount - 1 ? this.CustomColors[index - colorCount] : this.Colors[index];
      }

      return result;
    }

    public ColorSource GetColorSource(int colorIndex)
    {
      ColorSource result;
      int colorCount;
      int customColorCount;

      colorCount = this.Colors != null ? this.Colors.Count : 0;
      customColorCount = this.CustomColors != null ? this.CustomColors.Count : 0;

      if (colorCount < 0 || colorIndex > colorCount + customColorCount)
      {
        result = ColorSource.None;
      }
      else
      {
        result = colorIndex > colorCount - 1 ? ColorSource.Custom : ColorSource.Standard;
      }

      return result;
    }

    public ColorSource GetColorSource(Color color)
    {
      int index;
      ColorSource result;

      index = this.Colors.IndexOf(color);
      if (index != InvalidIndex)
      {
        result = ColorSource.Standard;
      }
      else
      {
        index = this.CustomColors.IndexOf(color);
        result = index != InvalidIndex ? ColorSource.Custom : ColorSource.None;
      }

      return result;
    }

    public override Size GetPreferredSize(Size proposedSize)
    {
      return this.AutoSize ? this.GetAutoSize() : base.GetPreferredSize(proposedSize);
    }

    public ColorHitTestInfo HitTest(Point point)
    {
      ColorHitTestInfo result;
      int colorIndex;

      result = new ColorHitTestInfo();
      colorIndex = InvalidIndex;

      foreach (KeyValuePair<int, Rectangle> pair in _colorRegions.Where(pair => pair.Value.Contains(point)))
      {
        colorIndex = pair.Key;
        break;
      }

      result.Index = colorIndex;
      if (colorIndex != InvalidIndex)
      {
        result.Color = colorIndex < this.Colors.Count + this.CustomColors.Count ? this.GetColor(colorIndex) : Color.White;
        result.Source = this.GetColorSource(colorIndex);
      }
      else
      {
        result.Source = ColorSource.None;
      }

      return result;
    }

    public void Invalidate(int index)
    {
      if (this.AllowPainting && index != InvalidIndex)
      {
        Rectangle bounds;

        if (_colorRegions.TryGetValue(index, out bounds))
        {
          if (this.SelectedCellStyle == ColorGridSelectedCellStyle.Zoomed)
          {
            bounds.Inflate(this.Padding.Left, this.Padding.Top);
          }

          this.Invalidate(bounds);
        }
      }
    }

    public void Navigate(int offsetX, int offsetY)
    {
      this.Navigate(offsetX, offsetY, NavigationOrigin.Current);
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
        this.ColorIndex = index;
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

      primaryRows = this.GetRows(this.Colors != null ? this.Colors.Count : 0);
      if (primaryRows == 0)
      {
        primaryRows = 1;
      }

      customRows = this.ShowCustomColors ? this.GetRows(this.CustomColors != null ? this.CustomColors.Count : 0) : 0;

      this.PrimaryRows = primaryRows;
      this.CustomRows = customRows;
    }

    protected virtual Brush CreateTransparencyBrush()
    {
      Type type;

      type = typeof(ColorGrid);

      using (Bitmap background = new Bitmap(type.Assembly.GetManifestResourceStream(string.Concat(type.Namespace, ".Resources.cellbackground.png"))))
      {
        return new TextureBrush(background, WrapMode.Tile);
      }
    }

    protected void DefineColorRegions(ColorCollection colors, int rangeStart, int offset)
    {
      if (colors != null)
      {
        int rows;
        int index;

        rows = this.GetRows(colors.Count);
        index = 0;

        for (int row = 0; row < rows; row++)
        {
          for (int column = 0; column < this.ActualColumns; column++)
          {
            if (index < colors.Count)
            {
              _colorRegions.Add(rangeStart + index, new Rectangle(this.Padding.Left + column * (_scaledCellSize.Width + this.Spacing.Width), offset + row * (_scaledCellSize.Height + this.Spacing.Height), _scaledCellSize.Width, _scaledCellSize.Height));
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
        this.RemoveEventHandlers(_colors);
        this.RemoveEventHandlers(_customColors);

        _toolTip?.Dispose();

        _cellBackgroundBrush?.Dispose();
      }

      base.Dispose(disposing);
    }

    protected virtual void EditColor(int colorIndex)
    {
      using (ColorPickerDialog dialog = new ColorPickerDialog())
      {
        dialog.Color = this.GetColor(colorIndex);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          this.BeginUpdate();
          this.SetColor(colorIndex, dialog.Color);
          this.Color = dialog.Color;
          this.EndUpdate();
        }
      }
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

        lastStandardRowOffset = this.PrimaryRows * this.ActualColumns - this.Colors.Count;
        result = row * this.ActualColumns + column;
        if (row == this.PrimaryRows - 1 && column >= this.ActualColumns - lastStandardRowOffset)
        {
          result -= lastStandardRowOffset;
        }
        if (row >= this.PrimaryRows)
        {
          result -= lastStandardRowOffset;
        }

        if (result > this.Colors.Count + this.CustomColors.Count - 1)
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

      lastStandardRowOffset = this.PrimaryRows * this.ActualColumns - this.Colors.Count;
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

    protected virtual int GetColorIndex(Color value)
    {
      int index;

      index = this.Colors != null ? this.Colors.IndexOf(value) : InvalidIndex;
      if (index == InvalidIndex && this.ShowCustomColors && this.CustomColors != null)
      {
        index = this.CustomColors.IndexOf(value);
        if (index != InvalidIndex)
        {
          index += this.Colors.Count;
        }
      }

      return index;
    }

    protected virtual ColorCollection GetPredefinedPalette()
    {
      return ColorPalettes.GetPalette(this.Palette);
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
    /// Raises the <see cref="AutoAddColorsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnAutoAddColorsChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventAutoAddColorsChanged];

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

      this.RefreshColors();

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
    /// Raises the <see cref="CellBorderColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCellBorderColorChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.AllowPainting)
      {
        this.Invalidate();
      }

      handler = (EventHandler)this.Events[_eventCellBorderColorChanged];

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
        this.RefreshColors();
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
        _scaledCellSize = new Size((int) (_cellSize.Width * scaleX), (int) (_cellSize.Height * scaleY));
      }
      else
      {
        _scaledCellSize = _cellSize;
      }

      Debug.WriteLine(_scaledCellSize);
    }

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColorIndexChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorIndexChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.AllowPainting)
      {
        this.Invalidate(_previousColorIndex);
        this.Invalidate(this.ColorIndex);
      }

      handler = (EventHandler)this.Events[_eventColorIndexChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColorsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorsChanged(EventArgs e)
    {
      EventHandler handler;

      this.AddEventHandlers(this.Colors);

      this.RefreshColors();

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

      this.RefreshColors();

      handler = (EventHandler)this.Events[_eventColumnsChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="CustomColorsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCustomColorsChanged(EventArgs e)
    {
      EventHandler handler;

      this.AddEventHandlers(this.CustomColors);
      this.RefreshColors();

      handler = (EventHandler)this.Events[_eventCustomColorsChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="EditingColor" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EditColorCancelEventArgs" /> instance containing the event data.</param>
    protected virtual void OnEditingColor(EditColorCancelEventArgs e)
    {
      EventHandler<EditColorCancelEventArgs> handler;

      handler = (EventHandler<EditColorCancelEventArgs>)this.Events[_eventEditingColor];

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
        this.Invalidate(this.ColorIndex);
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
          this.Navigate(0, 0, NavigationOrigin.Begin);
          e.Handled = true;
          break;
        case Keys.End:
          this.Navigate(0, 0, NavigationOrigin.End);
          e.Handled = true;
          break;
      }

      base.OnKeyDown(e);
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
      if (this.WasKeyPressed && this.ColorIndex != InvalidIndex)
      {
        switch (e.KeyData)
        {
          case Keys.Enter:
            ColorSource source;

            source = this.GetColorSource(this.ColorIndex);

            if (source == ColorSource.Custom && this.EditMode != ColorEditingMode.None || source == ColorSource.Standard && this.EditMode == ColorEditingMode.Both)
            {
              e.Handled = true;

              this.StartColorEdit(this.ColorIndex);
            }
            break;
          case Keys.Apps:
          case Keys.F10 | Keys.Shift:
            int x;
            int y;
            Point location;

            location = _colorRegions[_colorIndex].Location;
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
        this.Invalidate(this.ColorIndex);
      }
    }

    protected override void OnMouseDoubleClick(MouseEventArgs e)
    {
      ColorHitTestInfo hitTest;

      base.OnMouseDoubleClick(e);

      hitTest = this.HitTest(e.Location);

      if (e.Button == MouseButtons.Left && (hitTest.Source == ColorSource.Custom && this.EditMode != ColorEditingMode.None || hitTest.Source == ColorSource.Standard && this.EditMode == ColorEditingMode.Both))
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
          this.ColorIndex = index;

          this.ShowContextMenu(e.Location);
        }
      }
    }

    protected override void OnPaddingChanged(EventArgs e)
    {
      base.OnPaddingChanged(e);

      if (this.AllowPainting)
      {
        this.RefreshColors();
        this.Invalidate();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (this.AllowPainting)
      {
        int colorCount;

        colorCount = this.Colors.Count;

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

          bounds = _colorRegions[i];
          if (e.ClipRectangle.IntersectsWith(bounds))
          {
            this.PaintCell(e, i, i, this.Colors[i], bounds);
          }
        }

        if (this.CustomColors.Count != 0 && this.ShowCustomColors)
        {
          // draw a separator
          this.PaintSeparator(e);

          // and the custom colors
          for (int i = 0; i < this.CustomColors.Count; i++)
          {
            Rectangle bounds;

            if (_colorRegions.TryGetValue(colorCount + i, out bounds) && e.ClipRectangle.IntersectsWith(bounds))
            {
              this.PaintCell(e, i, colorCount + i, this.CustomColors[i], bounds);
            }
          }
        }

        // draw the selected color
        if (this.SelectedCellStyle != ColorGridSelectedCellStyle.None && this.ColorIndex >= 0)
        {
          Rectangle bounds;

          if (_colorRegions.TryGetValue(this.ColorIndex, out bounds) && e.ClipRectangle.IntersectsWith(bounds))
          {
            this.PaintSelectedCell(e, this.ColorIndex, this.Color, bounds);
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

      this.Colors = this.GetPredefinedPalette();

      handler = (EventHandler)this.Events[_eventPaletteChanged];

      handler?.Invoke(this, e);
    }

    protected override void OnResize(EventArgs e)
    {
      this.RefreshColors();

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
    /// Raises the <see cref="ShowCustomColorsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowCustomColorsChanged(EventArgs e)
    {
      EventHandler handler;

      this.RefreshColors();

      handler = (EventHandler)this.Events[_eventShowCustomColorsChanged];

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
        this.RefreshColors();
        this.Invalidate();
      }

      handler = (EventHandler)this.Events[_eventSpacingChanged];

      handler?.Invoke(this, e);
    }

    protected virtual void PaintCell(PaintEventArgs e, int colorIndex, int cellIndex, Color color, Rectangle bounds)
    {
      if (color.A != 255)
      {
        this.PaintTransparentCell(e, bounds);
      }

      using (Brush brush = new SolidBrush(color))
      {
        e.Graphics.FillRectangle(brush, bounds);
      }

      switch (this.CellBorderStyle)
      {
        case ColorCellBorderStyle.FixedSingle:
          using (Pen pen = new Pen(this.CellBorderColor))
          {
            e.Graphics.DrawRectangle(pen, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
          }
          break;
        case ColorCellBorderStyle.DoubleSoft:
          HslColor shadedOuter;
          HslColor shadedInner;

          shadedOuter = new HslColor(color);
          shadedOuter.L -= 0.50;

          shadedInner = new HslColor(color);
          shadedInner.L -= 0.20;

          using (Pen pen = new Pen(this.CellBorderColor))
          {
            e.Graphics.DrawRectangle(pen, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
          }
          e.Graphics.DrawRectangle(Pens.White, bounds.Left + 1, bounds.Top + 1, bounds.Width - 3, bounds.Height - 3);
          using (Pen pen = new Pen(Color.FromArgb(32, shadedOuter.ToRgbColor())))
          {
            e.Graphics.DrawRectangle(pen, bounds.Left + 2, bounds.Top + 2, bounds.Width - 5, bounds.Height - 5);
          }
          using (Pen pen = new Pen(Color.FromArgb(32, shadedInner.ToRgbColor())))
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
        case ColorGridSelectedCellStyle.Standard:
          if (this.Focused)
          {
            ControlPaint.DrawFocusRectangle(e.Graphics, bounds);
          }
          else
          {
            e.Graphics.DrawRectangle(Pens.Black, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
          }
          break;
        case ColorGridSelectedCellStyle.Zoomed:
          // make the cell larger according to the padding
          if (this.SelectedCellStyle == ColorGridSelectedCellStyle.Zoomed)
          {
            bounds.Inflate(this.Padding.Left, this.Padding.Top);
          }

          // fill the inner
          e.Graphics.FillRectangle(Brushes.White, bounds);
          if (this.SelectedCellStyle == ColorGridSelectedCellStyle.Zoomed)
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

            using (Pen pen = new Pen(this.CellBorderColor))
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

      using (Pen pen = new Pen(this.CellBorderColor))
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
        ColorHitTestInfo hitTest;

        hitTest = this.HitTest(e.Location);

        if (hitTest.Source != ColorSource.None)
        {
          this.Color = hitTest.Color;
          this.ColorIndex = hitTest.Index;
        }
      }
    }

    protected virtual void RefreshColors()
    {
      if (this.AllowPainting)
      {
        Debug.Print("Calculating colors...");

        this.CalculateGridSize();
        if (this.AutoFit)
        {
          this.CalculateCellSize();
        }
        else if (this.AutoSize)
        {
          this.SizeToFit();
        }

        _colorRegions.Clear();

        if (this.Colors != null)
        {
          this.DefineColorRegions(this.Colors, 0, this.Padding.Top);
          if (this.ShowCustomColors)
          {
            this.DefineColorRegions(this.CustomColors, this.Colors.Count, this.Padding.Top + this.SeparatorHeight + (_scaledCellSize.Height + this.Spacing.Height) * this.PrimaryRows);
          }

          this.ColorIndex = this.GetColorIndex(this.Color);

          if (!this.Color.IsEmpty && this.ColorIndex == InvalidIndex && this.AutoAddColors && this.ShowCustomColors)
          {
            this.AddCustomColor(this.Color);
          }

          this.Invalidate();
        }
      }
    }

    protected virtual void SetColor(int colorIndex, Color color)
    {
      int colorCount;

      colorCount = this.Colors.Count;

      if (colorIndex < 0 || colorIndex > colorCount + this.CustomColors.Count)
      {
        throw new ArgumentOutOfRangeException(nameof(colorIndex));
      }

      if (colorIndex > colorCount - 1)
      {
        this.CustomColors[colorIndex - colorCount] = color;
      }
      else
      {
        this.Colors[colorIndex] = color;
      }
    }

    private void AddEventHandlers(ColorCollection value)
    {
      if (value != null)
      {
        value.ItemInserted += this.ColorsCollectionChangedHandler;
        value.ItemRemoved += this.ColorsCollectionChangedHandler;
        value.ItemsCleared += this.ColorsCollectionChangedHandler;
        value.ItemReplaced += this.ColorsCollectionItemReplacedHandler;
      }
    }

    private void ColorsCollectionChangedHandler(object sender, ColorCollectionEventArgs e)
    {
      this.RefreshColors();
    }

    private void ColorsCollectionItemReplacedHandler(object sender, ColorCollectionEventArgs e)
    {
      ColorCollection collection;
      int index;

      collection = (ColorCollection)sender;
      index = _colorIndex;
      if (index != InvalidIndex && ReferenceEquals(collection, this.CustomColors))
      {
        index -= this.Colors.Count;
      }

      if (index >= 0 && index < collection.Count && collection[index] != this.Color)
      {
        Debug.Print("Replacing index {0} with {1}", index, collection[index]);

        _previousColorIndex = index;
        _colorIndex = -1;
        this.ColorIndex = index;
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
      else if (index >= this.Colors.Count)
      {
        // custom color
        index -= this.Colors.Count;
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

    private void RemoveEventHandlers(ColorCollection value)
    {
      if (value != null)
      {
        value.ItemInserted -= this.ColorsCollectionChangedHandler;
        value.ItemRemoved -= this.ColorsCollectionChangedHandler;
        value.ItemsCleared -= this.ColorsCollectionChangedHandler;
        value.ItemReplaced -= this.ColorsCollectionItemReplacedHandler;
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
          _toolTip.SetToolTip(this, this.HotIndex != InvalidIndex ? this.GetColor(this.HotIndex).Name : null);
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
      EditColorCancelEventArgs e;

      e = new EditColorCancelEventArgs(this.GetColor(index), index);
      this.OnEditingColor(e);

      if (!e.Cancel)
      {
        this.EditColor(index);
      }
    }

    #endregion

    #region IColorEditor Interface

    [Category("Property Changed")]
    public event EventHandler ColorChanged
    {
      add { this.Events.AddHandler(_eventColorChanged, value); }
      remove { this.Events.RemoveHandler(_eventColorChanged, value); }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    public virtual Color Color
    {
      get { return _color; }
      set
      {
        int newIndex;

        _color = value;

        if (!value.IsEmpty)
        {
          // the new color matches the color at the current index, so don't change the index
          // this stops the selection hopping about if you have duplicate colors in a palette
          // otherwise, if the colors don't match, then find the index that does
          newIndex = this.GetColor(this.ColorIndex) == value ? this.ColorIndex : this.GetColorIndex(value);

          if (newIndex == InvalidIndex)
          {
            newIndex = this.AddCustomColor(value);
          }
        }
        else
        {
          newIndex = InvalidIndex;
        }

        this.ColorIndex = newIndex;

        this.OnColorChanged(EventArgs.Empty);
      }
    }

    #endregion
  }
}
