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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    /// <summary>
    ///   Component for displaying images with support for scrolling and zooming.
    /// </summary>
    [DefaultProperty("Image")]
    [ToolboxBitmap(typeof(ImageBoxExtended), "ToolboxBitmaps.ImageBox.bmp")]
    [ToolboxItem(true)]
    /* [Designer("Cyotek.Windows.Forms.Design.ImageBoxDesigner", Cyotek.Windows.Forms.ImageBox.Design.dll, PublicKeyToken=58daa28b0b2de221")] */
    public class ImageBoxExtended : VirtualScrollableControl
    {
        #region Constants

        private static readonly object _eventAllowClickZoomChanged = new object();

        private static readonly object _eventAllowDoubleClickChanged = new object();

        private static readonly object _eventAllowUnfocusedMouseWheelChanged = new object();

        private static readonly object _eventAllowZoomChanged = new object();

        private static readonly object _eventAutoCenterChanged = new object();

        private static readonly object _eventAutoPanChanged = new object();

        private static readonly object _eventDropShadowSizeChanged = new object();

        private static readonly object _eventGridCellSizeChanged = new object();

        private static readonly object _eventGridColorAlternateChanged = new object();

        private static readonly object _eventGridColorChanged = new object();

        private static readonly object _eventGridDisplayModeChanged = new object();

        private static readonly object _eventGridScaleChanged = new object();

        private static readonly object _eventImageBorderColorChanged = new object();

        private static readonly object _eventImageBorderStyleChanged = new object();

        private static readonly object _eventImageChanged = new object();

        private static readonly object _eventInterpolationModeChanged = new object();

        private static readonly object _eventInvertMouseChanged = new object();

        private static readonly object _eventLimitSelectionToImageChanged = new object();

        private static readonly object _eventPanEnd = new object();

        private static readonly object _eventPanStart = new object();

        private static readonly object _eventPixelGridColorChanged = new object();

        private static readonly object _eventPixelGridThresholdChanged = new object();

        private static readonly object _eventScaleTextChanged = new object();

        private static readonly object _eventSelected = new object();

        private static readonly object _eventSelecting = new object();

        private static readonly object _eventSelectionColorChanged = new object();

        private static readonly object _eventSelectionModeChanged = new object();

        private static readonly object _eventSelectionRegionChanged = new object();

        private static readonly object _eventShortcutsEnabledChanged = new object();

        private static readonly object _eventShowPixelGridChanged = new object();

        private static readonly object _eventSizeModeChanged = new object();

        private static readonly object _eventSizeToFitChanged = new object();

        private static readonly object _eventTextAlignChanged = new object();

        private static readonly object _eventTextBackColorChanged = new object();

        private static readonly object _eventTextDisplayModeChanged = new object();

        private static readonly object _eventTextPaddingChanged = new object();

        private static readonly object _eventVirtualDraw = new object();

        private static readonly object _eventVirtualModeChanged = new object();

        private static readonly object _eventVirtualSizeChanged = new object();

        private static readonly object _eventZoomChanged = new object();

        private static readonly object _eventZoomed = new object();

        private static readonly object _eventZoomLevelsChanged = new object();

        private const int MaxZoom = 3500;

        private const int MinZoom = 1;

        private const int SelectionDeadZone = 5;

        #endregion

        #region Fields

        private bool _allowClickZoom;

        private bool _allowDoubleClick;

        private bool _allowUnfocusedMouseWheel;

        private bool _allowZoom;

        private bool _autoCenter;

        private bool _autoPan;

        private int _dropShadowSize;

        private int _gridCellSize;

        private Color _gridColor;

        private Color _gridColorAlternate;

        private ImageBoxGridDisplayMode _gridDisplayMode;

        private ImageBoxGridScale _gridScale;

        private Bitmap? _gridTile;

        private Image _image;

        private Color _imageBorderColor;

        private ImageBoxBorderStyle _imageBorderStyle;

        private InterpolationMode _interpolationMode;

        private bool _invertMouse;

        private bool _isPanning;

        private bool _limitSelectionToImage;

        private Color _pixelGridColor;

        private int _pixelGridThreshold;

        private bool _scaleText;

        private Color _selectionColor;

        private ImageBoxSelectionMode _selectionMode;

        private RectangleF _selectionRegion;

        private bool _shortcutsEnabled;

        private bool _showPixelGrid;

        private ImageBoxSizeMode _sizeMode;

        private Point _startMousePosition;

        private Point _startScrollPosition;

        private ContentAlignment _textAlign;

        private Color _textBackColor;

        private ImageBoxGridDisplayMode _textDisplayMode;

        private Padding _textPadding;

        private Brush? _texture;

        private int _updateCount;

        private bool _virtualMode;

        private Size _virtualSize;

        private int _zoom;

        private ZoomLevelCollection _zoomLevels;
        private bool _isSelecting;

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="ImageBoxExtended" /> class.
        /// </summary>
        public ImageBoxExtended()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.StandardDoubleClick, false);

            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            BeginUpdate();
            WheelScrollsControl = false;
            AllowZoom = true;
            LimitSelectionToImage = true;
            DropShadowSize = 3;
            ImageBorderStyle = ImageBoxBorderStyle.None;
            BackColor = Color.White;
            AutoSize = false;
            AutoScroll = true;
            GridScale = ImageBoxGridScale.Small;
            GridDisplayMode = ImageBoxGridDisplayMode.Client;
            GridColor = Color.Gainsboro;
            GridColorAlternate = Color.White;
            GridCellSize = 8;
            AutoPan = true;
            InterpolationMode = InterpolationMode.NearestNeighbor;
            AutoCenter = true;
            SelectionColor = SystemColors.Highlight;
            ActualSize();
            ShortcutsEnabled = true;
            ZoomLevels = ZoomLevelCollection.Default;
            ImageBorderColor = SystemColors.ControlDark;
            PixelGridColor = Color.DimGray;
            PixelGridThreshold = 5;
            TextAlign = ContentAlignment.MiddleCenter;
            TextBackColor = Color.Transparent;
            TextDisplayMode = ImageBoxGridDisplayMode.Client;
            EndUpdate();
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Events

        /// <summary>
        ///   Occurs when the AllowClickZoom property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AllowClickZoomChanged
        {
            add => Events.AddHandler(_eventAllowClickZoomChanged, value);
            remove => Events.RemoveHandler(_eventAllowClickZoomChanged, value);
        }

        /// <summary>
        ///   Occurs when the AllowDoubleClick property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AllowDoubleClickChanged
        {
            add => Events.AddHandler(_eventAllowDoubleClickChanged, value);
            remove => Events.RemoveHandler(_eventAllowDoubleClickChanged, value);
        }

        /// <summary>
        /// Occurs when the AllowUnfocusedMouseWheel property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AllowUnfocusedMouseWheelChanged
        {
            add => Events.AddHandler(_eventAllowUnfocusedMouseWheelChanged, value);
            remove => Events.RemoveHandler(_eventAllowUnfocusedMouseWheelChanged, value);
        }

        /// <summary>
        ///   Occurs when the AllowZoom property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AllowZoomChanged
        {
            add => Events.AddHandler(_eventAllowZoomChanged, value);
            remove => Events.RemoveHandler(_eventAllowZoomChanged, value);
        }

        /// <summary>
        ///   Occurs when the AutoCenter property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AutoCenterChanged
        {
            add => Events.AddHandler(_eventAutoCenterChanged, value);
            remove => Events.RemoveHandler(_eventAutoCenterChanged, value);
        }

        /// <summary>
        ///   Occurs when the AutoPan property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AutoPanChanged
        {
            add => Events.AddHandler(_eventAutoPanChanged, value);
            remove => Events.RemoveHandler(_eventAutoPanChanged, value);
        }

        /// <summary>
        ///   Occurs when the DropShadowSize property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler DropShadowSizeChanged
        {
            add => Events.AddHandler(_eventDropShadowSizeChanged, value);
            remove => Events.RemoveHandler(_eventDropShadowSizeChanged, value);
        }

        /// <summary>
        ///   Occurs when the GridSizeCell property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler GridCellSizeChanged
        {
            add => Events.AddHandler(_eventGridCellSizeChanged, value);
            remove => Events.RemoveHandler(_eventGridCellSizeChanged, value);
        }

        /// <summary>
        ///   Occurs when the GridColorAlternate property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler GridColorAlternateChanged
        {
            add => Events.AddHandler(_eventGridColorAlternateChanged, value);
            remove => Events.RemoveHandler(_eventGridColorAlternateChanged, value);
        }

        /// <summary>
        ///   Occurs when the GridColor property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler GridColorChanged
        {
            add => Events.AddHandler(_eventGridColorChanged, value);
            remove => Events.RemoveHandler(_eventGridColorChanged, value);
        }

        /// <summary>
        ///   Occurs when the GridDisplayMode property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler GridDisplayModeChanged
        {
            add => Events.AddHandler(_eventGridDisplayModeChanged, value);
            remove => Events.RemoveHandler(_eventGridDisplayModeChanged, value);
        }

        /// <summary>
        ///   Occurs when the GridScale property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler GridScaleChanged
        {
            add => Events.AddHandler(_eventGridScaleChanged, value);
            remove => Events.RemoveHandler(_eventGridScaleChanged, value);
        }

        /// <summary>
        ///   Occurs when the ImageBorderColor property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ImageBorderColorChanged
        {
            add => Events.AddHandler(_eventImageBorderColorChanged, value);
            remove => Events.RemoveHandler(_eventImageBorderColorChanged, value);
        }

        /// <summary>
        ///   Occurs when the ImageBorderStyle property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ImageBorderStyleChanged
        {
            add => Events.AddHandler(_eventImageBorderStyleChanged, value);
            remove => Events.RemoveHandler(_eventImageBorderStyleChanged, value);
        }

        /// <summary>
        ///   Occurs when the Image property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ImageChanged
        {
            add => Events.AddHandler(_eventImageChanged, value);
            remove => Events.RemoveHandler(_eventImageChanged, value);
        }

        /// <summary>
        ///   Occurs when the InterpolationMode property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler InterpolationModeChanged
        {
            add => Events.AddHandler(_eventInterpolationModeChanged, value);
            remove => Events.RemoveHandler(_eventInterpolationModeChanged, value);
        }

        /// <summary>
        ///   Occurs when the InvertMouse property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler InvertMouseChanged
        {
            add => Events.AddHandler(_eventInvertMouseChanged, value);
            remove => Events.RemoveHandler(_eventInvertMouseChanged, value);
        }

        /// <summary>
        ///   Occurs when the LimitSelectionToImage property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler LimitSelectionToImageChanged
        {
            add => Events.AddHandler(_eventLimitSelectionToImageChanged, value);
            remove => Events.RemoveHandler(_eventLimitSelectionToImageChanged, value);
        }

        /// <summary>
        ///   Occurs when panning the control completes.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler PanEnd
        {
            add => Events.AddHandler(_eventPanEnd, value);
            remove => Events.RemoveHandler(_eventPanEnd, value);
        }

        /// <summary>
        ///   Occurs when panning the control starts.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler PanStart
        {
            add => Events.AddHandler(_eventPanStart, value);
            remove => Events.RemoveHandler(_eventPanStart, value);
        }

        /// <summary>
        ///   Occurs when the PixelGridColor property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler PixelGridColorChanged
        {
            add => Events.AddHandler(_eventPixelGridColorChanged, value);
            remove => Events.RemoveHandler(_eventPixelGridColorChanged, value);
        }

        /// <summary>
        /// Occurs when the PixelGridThreshold property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler PixelGridThresholdChanged
        {
            add => Events.AddHandler(_eventPixelGridThresholdChanged, value);
            remove => Events.RemoveHandler(_eventPixelGridThresholdChanged, value);
        }

        /// <summary>
        /// Occurs when the ScaleText property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ScaleTextChanged
        {
            add => Events.AddHandler(_eventScaleTextChanged, value);
            remove => Events.RemoveHandler(_eventScaleTextChanged, value);
        }

        /// <summary>
        ///   Occurs when a selection region has been defined
        /// </summary>
        [Category("Action")]
        public event EventHandler<EventArgs> Selected
        {
            // TODO: The event signature is wrong and should just be EventHandler - breaking change however. Do in the 2.0 scroll changes branch.
            add => Events.AddHandler(_eventSelected, value);
            remove => Events.RemoveHandler(_eventSelected, value);
        }

        /// <summary>
        ///   Occurs when the user starts to define a selection region.
        /// </summary>
        [Category("Action")]
        public event EventHandler<ImageBoxExtendedCancelEventArgs> Selecting
        {
            add => Events.AddHandler(_eventSelecting, value);
            remove => Events.RemoveHandler(_eventSelecting, value);
        }

        /// <summary>
        ///   Occurs when the SelectionColor property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler SelectionColorChanged
        {
            add => Events.AddHandler(_eventSelectionColorChanged, value);
            remove => Events.RemoveHandler(_eventSelectionColorChanged, value);
        }

        /// <summary>
        ///   Occurs when the SelectionMode property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler SelectionModeChanged
        {
            add => Events.AddHandler(_eventSelectionModeChanged, value);
            remove => Events.RemoveHandler(_eventSelectionModeChanged, value);
        }

        /// <summary>
        ///   Occurs when the SelectionRegion property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler SelectionRegionChanged
        {
            add => Events.AddHandler(_eventSelectionRegionChanged, value);
            remove => Events.RemoveHandler(_eventSelectionRegionChanged, value);
        }

        /// <summary>
        ///   Occurs when the ShortcutsEnabled property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ShortcutsEnabledChanged
        {
            add => Events.AddHandler(_eventShortcutsEnabledChanged, value);
            remove => Events.RemoveHandler(_eventShortcutsEnabledChanged, value);
        }

        /// <summary>
        ///   Occurs when the ShowPixelGrid property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ShowPixelGridChanged
        {
            add => Events.AddHandler(_eventShowPixelGridChanged, value);
            remove => Events.RemoveHandler(_eventShowPixelGridChanged, value);
        }

        /// <summary>
        /// Occurs when the SizeMode property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler SizeModeChanged
        {
            add => Events.AddHandler(_eventSizeModeChanged, value);
            remove => Events.RemoveHandler(_eventSizeModeChanged, value);
        }

        /// <summary>
        ///   Occurs when the SizeToFit property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler SizeToFitChanged
        {
            add => Events.AddHandler(_eventSizeToFitChanged, value);
            remove => Events.RemoveHandler(_eventSizeToFitChanged, value);
        }

        /// <summary>
        /// Occurs when the TextAlign property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler TextAlignChanged
        {
            add => Events.AddHandler(_eventTextAlignChanged, value);
            remove => Events.RemoveHandler(_eventTextAlignChanged, value);
        }

        /// <summary>
        /// Occurs when the TextBackColor property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler TextBackColorChanged
        {
            add => Events.AddHandler(_eventTextBackColorChanged, value);
            remove => Events.RemoveHandler(_eventTextBackColorChanged, value);
        }

        /// <summary>
        /// Occurs when the TextDisplayMode property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler TextDisplayModeChanged
        {
            add => Events.AddHandler(_eventTextDisplayModeChanged, value);
            remove => Events.RemoveHandler(_eventTextDisplayModeChanged, value);
        }

        /// <summary>
        /// Occurs when the TextPadding property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler TextPaddingChanged
        {
            add => Events.AddHandler(_eventTextPaddingChanged, value);
            remove => Events.RemoveHandler(_eventTextPaddingChanged, value);
        }

        /// <summary>
        ///   Occurs when virtual painting should occur
        /// </summary>
        [Category("Appearance")]
        public event PaintEventHandler VirtualDraw
        {
            add => Events.AddHandler(_eventVirtualDraw, value);
            remove => Events.RemoveHandler(_eventVirtualDraw, value);
        }

        /// <summary>
        ///   Occurs when the VirtualMode property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler VirtualModeChanged
        {
            add => Events.AddHandler(_eventVirtualModeChanged, value);
            remove => Events.RemoveHandler(_eventVirtualModeChanged, value);
        }

        /// <summary>
        ///   Occurs when the VirtualSize property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler VirtualSizeChanged
        {
            add => Events.AddHandler(_eventVirtualSizeChanged, value);
            remove => Events.RemoveHandler(_eventVirtualSizeChanged, value);
        }

        /// <summary>
        ///   Occurs when the Zoom property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ZoomChanged
        {
            add => Events.AddHandler(_eventZoomChanged, value);
            remove => Events.RemoveHandler(_eventZoomChanged, value);
        }

        /// <summary>
        /// Occurs when then a zoom action is performed.
        /// </summary>
        [Category("Action")]
        public event EventHandler<ImageBoxExtendedZoomEventArgs> Zoomed
        {
            add => Events.AddHandler(_eventZoomed, value);
            remove => Events.RemoveHandler(_eventZoomed, value);
        }

        /// <summary>
        ///   Occurs when the ZoomLevels property is changed
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ZoomLevelsChanged
        {
            add => Events.AddHandler(_eventZoomLevelsChanged, value);
            remove => Events.RemoveHandler(_eventZoomLevelsChanged, value);
        }

        #endregion

        #region Static Methods

        /// <summary>
        ///   Creates a bitmap image containing a 2x2 grid using the specified cell size and colors.
        /// </summary>
        /// <param name="cellSize">Size of the cell.</param>
        /// <param name="cellColor">Cell color.</param>
        /// <param name="alternateCellColor">Alternate cell color.</param>
        /// <returns></returns>
        public static Bitmap CreateCheckerBoxTile(int cellSize, Color cellColor, Color alternateCellColor)
        {
            Bitmap result;
            int width;
            int height;

            // draw the tile
            width = cellSize * 2;
            height = cellSize * 2;
            result = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(result))
            {
                using (Brush brush = new SolidBrush(cellColor))
                {
                    g.FillRectangle(brush, new Rectangle(cellSize, 0, cellSize, cellSize));
                    g.FillRectangle(brush, new Rectangle(0, cellSize, cellSize, cellSize));
                }

                using (Brush brush = new SolidBrush(alternateCellColor))
                {
                    g.FillRectangle(brush, new Rectangle(0, 0, cellSize, cellSize));
                    g.FillRectangle(brush, new Rectangle(cellSize, cellSize, cellSize, cellSize));
                }
            }

            return result;
        }

        /// <summary>
        ///   Creates a checked tile texture using default values.
        /// </summary>
        /// <returns></returns>
        public static Bitmap CreateCheckerBoxTile()
        {
            return CreateCheckerBoxTile(8, Color.Gainsboro, Color.WhiteSmoke);
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets a value indicating whether clicking the control with the mouse will automatically zoom in or out.
        /// </summary>
        /// <value>
        ///   <c>true</c> if clicking the control allows zooming; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        [Category("Behavior")]
        public virtual bool AllowClickZoom
        {
            get => _allowClickZoom;
            set
            {
                if (_allowClickZoom != value)
                {
                    _allowClickZoom = value;
                    OnAllowClickZoomChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the DoubleClick event can be raised.
        /// </summary>
        /// <value><c>true</c> if the DoubleClick event can be raised; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(false)]
        public virtual bool AllowDoubleClick
        {
            get => _allowDoubleClick;
            set
            {
                if (AllowDoubleClick != value)
                {
                    _allowDoubleClick = value;

                    OnAllowDoubleClickChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Behavior")]
        [DefaultValue(false)]
        public virtual bool AllowUnfocusedMouseWheel
        {
            get => _allowUnfocusedMouseWheel;
            set
            {
                if (AllowUnfocusedMouseWheel != value)
                {
                    _allowUnfocusedMouseWheel = value;

                    OnAllowUnfocusedMouseWheelChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets a value indicating whether the user can change the zoom level.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the zoom level can be changed; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool AllowZoom
        {
            get => _allowZoom;
            set
            {
                if (AllowZoom != value)
                {
                    _allowZoom = value;

                    OnAllowZoomChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets a value indicating whether the image is centered where possible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the image should be centered where possible; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        [Category("Appearance")]
        public virtual bool AutoCenter
        {
            get => _autoCenter;
            set
            {
                if (_autoCenter != value)
                {
                    _autoCenter = value;
                    OnAutoCenterChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets if the mouse can be used to pan the control.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the control can be auto panned; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>If this property is set, the SizeToFit property cannot be used.</remarks>
        [DefaultValue(true)]
        [Category("Behavior")]
        public virtual bool AutoPan
        {
            get => _autoPan;
            set
            {
                if (_autoPan != value)
                {
                    _autoPan = value;
                    OnAutoPanChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets a value indicating whether the container enables the user to scroll to any content placed outside of its visible boundaries.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the container enables auto-scrolling; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        public override bool AutoScroll
        {
            get => base.AutoScroll;
            set => base.AutoScroll = value;
        }

        /// <summary>
        ///   Gets or sets the minimum size of the auto-scroll.
        /// </summary>
        /// <value></value>
        /// <returns>
        ///   A <see cref="T:System.Drawing.Size" /> that determines the minimum size of the virtual area through which the user can scroll.
        /// </returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size AutoScrollMinSize
        {
            get => base.AutoScrollMinSize;
            set => base.AutoScrollMinSize = value;
        }

        /// <summary>
        ///   Specifies if the control should auto size to fit the image contents.
        /// </summary>
        /// <value></value>
        /// <returns>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>
        /// </returns>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(false)]
        public override bool AutoSize
        {
            get => base.AutoSize;
            set
            {
                if (base.AutoSize != value)
                {
                    base.AutoSize = value;
                    AdjustLayout();
                }
            }
        }

        /// <summary>
        ///   Gets or sets the background color for the control.
        /// </summary>
        /// <value></value>
        /// <returns>
        ///   A <see cref="T:System.Drawing.Color" /> that represents the background color of the control. The default is the value of the
        ///   <see
        ///     cref="P:System.Windows.Forms.Control.DefaultBackColor" />
        ///   property.
        /// </returns>
        [DefaultValue(typeof(Color), "White")]
        public override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        /// <summary>
        ///   Gets or sets the background image displayed in the control.
        /// </summary>
        /// <value></value>
        /// <returns>
        ///   An <see cref="T:System.Drawing.Image" /> that represents the image to display in the background of the control.
        /// </returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage
        {
            get => base.BackgroundImage;
            set => base.BackgroundImage = value;
        }

        /// <summary>
        ///   Gets or sets the background image layout as defined in the <see cref="T:System.Windows.Forms.ImageLayout" /> enumeration.
        /// </summary>
        /// <value>The background image layout.</value>
        /// <returns>
        ///   One of the values of <see cref="T:System.Windows.Forms.ImageLayout" /> (
        ///   <see
        ///     cref="F:System.Windows.Forms.ImageLayout.Center" />
        ///   , <see cref="F:System.Windows.Forms.ImageLayout.None" />,
        ///   <see
        ///     cref="F:System.Windows.Forms.ImageLayout.Stretch" />
        ///   , <see cref="F:System.Windows.Forms.ImageLayout.Tile" />, or
        ///   <see
        ///     cref="F:System.Windows.Forms.ImageLayout.Zoom" />
        ///   ). <see cref="F:System.Windows.Forms.ImageLayout.Tile" /> is the default value.
        /// </returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLayout BackgroundImageLayout
        {
            get => base.BackgroundImageLayout;
            set => base.BackgroundImageLayout = value;
        }

        /// <summary>
        /// Gets the point at the center of the currently displayed image viewport.
        /// </summary>
        /// <value>The point at the center of the current image viewport.</value>
        [Browsable(false)]
        public Point CenterPoint
        {
            get
            {
                Rectangle viewport;

                viewport = GetImageViewPort();

                return new Point(viewport.Width / 2, viewport.Height / 2);
            }
        }

        /// <summary>
        ///   Gets or sets the size of the drop shadow.
        /// </summary>
        /// <value>The size of the drop shadow.</value>
        [Category("Appearance")]
        [DefaultValue(3)]
        public virtual int DropShadowSize
        {
            get => _dropShadowSize;
            set
            {
                if (DropShadowSize != value)
                {
                    _dropShadowSize = value;

                    OnDropShadowSizeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets the size of the grid cells.
        /// </summary>
        /// <value>The size of the grid cells.</value>
        [Category("Appearance")]
        [DefaultValue(8)]
        public virtual int GridCellSize
        {
            get => _gridCellSize;
            set
            {
                if (_gridCellSize != value)
                {
                    _gridCellSize = value;
                    OnGridCellSizeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets the color of primary cells in the grid.
        /// </summary>
        /// <value>The color of primary cells in the grid.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Gainsboro")]
        public virtual Color GridColor
        {
            get => _gridColor;
            set
            {
                if (_gridColor != value)
                {
                    _gridColor = value;
                    OnGridColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets the color of alternate cells in the grid.
        /// </summary>
        /// <value>The color of alternate cells in the grid.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "White")]
        public virtual Color GridColorAlternate
        {
            get => _gridColorAlternate;
            set
            {
                if (_gridColorAlternate != value)
                {
                    _gridColorAlternate = value;
                    OnGridColorAlternateChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets the grid display mode.
        /// </summary>
        /// <value>The grid display mode.</value>
        [DefaultValue(ImageBoxGridDisplayMode.Client)]
        [Category("Appearance")]
        public virtual ImageBoxGridDisplayMode GridDisplayMode
        {
            get => _gridDisplayMode;
            set
            {
                if (_gridDisplayMode != value)
                {
                    _gridDisplayMode = value;
                    OnGridDisplayModeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets the grid scale.
        /// </summary>
        /// <value>The grid scale.</value>
        [DefaultValue(typeof(ImageBoxGridScale), "Small")]
        [Category("Appearance")]
        public virtual ImageBoxGridScale GridScale
        {
            get => _gridScale;
            set
            {
                if (_gridScale != value)
                {
                    _gridScale = value;
                    OnGridScaleChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [Category("Appearance")]
        [DefaultValue(null)]
        public virtual Image Image
        {
            get => _image;
            set
            {
                if (_image != value)
                {
                    // disable animations
                    if (IsAnimating)
                    {
                        ImageAnimator.StopAnimate(Image, OnFrameChangedHandler);
                    }

                    _image = value;
                    OnImageChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets the color of the image border.
        /// </summary>
        /// <value>The color of the image border.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "ControlDark")]
        public virtual Color ImageBorderColor
        {
            get => _imageBorderColor;
            set
            {
                if (ImageBorderColor != value)
                {
                    _imageBorderColor = value;

                    OnImageBorderColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets the image border style.
        /// </summary>
        /// <value>The image border style.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(ImageBoxBorderStyle), "None")]
        public virtual ImageBoxBorderStyle ImageBorderStyle
        {
            get => _imageBorderStyle;
            set
            {
                if (ImageBorderStyle != value)
                {
                    _imageBorderStyle = value;

                    OnImageBorderStyleChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets the interpolation mode.
        /// </summary>
        /// <value>The interpolation mode.</value>
        [Category("Appearance")]
        [DefaultValue(InterpolationMode.NearestNeighbor)]
        public virtual InterpolationMode InterpolationMode
        {
            get => _interpolationMode;
            set
            {
                if (value == InterpolationMode.Invalid)
                {
                    value = InterpolationMode.Default;
                }

                if (_interpolationMode != value)
                {
                    _interpolationMode = value;
                    OnInterpolationModeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets a value indicating whether the mouse should be inverted when panning the control.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the mouse should be inverted when panning the control; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        [Category("Behavior")]
        public virtual bool InvertMouse
        {
            get => _invertMouse;
            set
            {
                if (_invertMouse != value)
                {
                    _invertMouse = value;
                    OnInvertMouseChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the image is currently being displayed at 100% zoom
        /// </summary>
        /// <value><c>true</c> if the image is currently being displayed at 100% zoom; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public virtual bool IsActualSize => Zoom == 100;

        /// <summary>
        ///   Gets a value indicating whether this control is panning.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this control is panning; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual bool IsPanning
        {
            get => _isPanning;
            protected set
            {
                if (_isPanning != value)
                {
                    CancelEventArgs args;

                    args = new CancelEventArgs();

                    if (value)
                    {
                        OnPanStart(args);
                    }
                    else
                    {
                        OnPanEnd(EventArgs.Empty);
                    }

                    if (!args.Cancel)
                    {
                        _isPanning = value;

                        if (value)
                        {
                            _startScrollPosition = AutoScrollPosition;
                            Cursor = Cursors.SizeAll;
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Gets or sets a value indicating whether this a selection region is currently being drawn.
        /// </summary>
        /// <value>
        ///   <c>true</c> if a selection region is currently being drawn; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsSelecting
        {
            get => _isSelecting;
            protected set => _isSelecting = value;
        }

        /// <summary>
        ///   Gets or sets a value indicating whether selection regions should be limited to the image boundaries.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selection regions should be limited to image boundaries; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool LimitSelectionToImage
        {
            get => _limitSelectionToImage;
            set
            {
                if (LimitSelectionToImage != value)
                {
                    _limitSelectionToImage = value;

                    OnLimitSelectionToImageChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the pixel grid.
        /// </summary>
        /// <value>The color of the pixel grid.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "DimGray")]
        public virtual Color PixelGridColor
        {
            get => _pixelGridColor;
            set
            {
                if (PixelGridColor != value)
                {
                    _pixelGridColor = value;

                    OnPixelGridColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum size of zoomed pixel's before the pixel grid will be drawn
        /// </summary>
        /// <value>The pixel grid threshold.</value>
        [Category("Behavior")]
        [DefaultValue(5)]
        public virtual int PixelGridThreshold
        {
            get => _pixelGridThreshold;
            set
            {
                if (PixelGridThreshold != value)
                {
                    _pixelGridThreshold = value;

                    OnPixelGridThresholdChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the font size of text is scaled according to the current zoom level.
        /// </summary>
        /// <value><c>true</c> if the size of text is scaled according to the current zoom level; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(false)]
        public virtual bool ScaleText
        {
            get => _scaleText;
            set
            {
                if (ScaleText != value)
                {
                    _scaleText = value;

                    OnScaleTextChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets the color of selection regions.
        /// </summary>
        /// <value>
        ///   The color of selection regions.
        /// </value>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Highlight")]
        public virtual Color SelectionColor
        {
            get => _selectionColor;
            set
            {
                if (SelectionColor != value)
                {
                    _selectionColor = value;

                    OnSelectionColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets the selection mode.
        /// </summary>
        /// <value>
        ///   The selection mode.
        /// </value>
        [Category("Behavior")]
        [DefaultValue(typeof(ImageBoxSelectionMode), "None")]
        public virtual ImageBoxSelectionMode SelectionMode
        {
            get => _selectionMode;
            set
            {
                if (SelectionMode != value)
                {
                    _selectionMode = value;

                    OnSelectionModeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets the selection region.
        /// </summary>
        /// <value>
        ///   The selection region.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual RectangleF SelectionRegion
        {
            get => _selectionRegion;
            set
            {
                if (SelectionRegion != value)
                {
                    _selectionRegion = value;

                    OnSelectionRegionChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets a value indicating whether the defined shortcuts are enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> to enable the shortcuts; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool ShortcutsEnabled
        {
            get => _shortcutsEnabled;
            set
            {
                if (ShortcutsEnabled != value)
                {
                    _shortcutsEnabled = value;

                    OnShortcutsEnabledChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a pixel grid is displayed when the control is zoomed.
        /// </summary>
        /// <value><c>true</c> if a pixel grid is displayed when the control is zoomed; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(false)]
        public virtual bool ShowPixelGrid
        {
            get => _showPixelGrid;
            set
            {
                if (ShowPixelGrid != value)
                {
                    _showPixelGrid = value;

                    OnShowPixelGridChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the size mode of images hosted in the control.
        /// </summary>
        /// <value>The size mode.</value>
        [Category("Behavior")]
        [DefaultValue(typeof(ImageBoxSizeMode), "Normal")]
        public virtual ImageBoxSizeMode SizeMode
        {
            get => _sizeMode;
            set
            {
                if (SizeMode != value)
                {
                    _sizeMode = value;

                    OnSizeModeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets a value indicating whether the control should automatically size to fit the image contents.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the control should size to fit the image contents; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        [Category("Appearance")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property is deprecated and will be removed in a future version of the component. Implementors should use the SizeMode property instead.")]
        public virtual bool SizeToFit
        {
            get => SizeMode == ImageBoxSizeMode.Fit;
            set
            {
                if (SizeMode == ImageBoxSizeMode.Fit != value)
                {
                    SizeMode = value ? ImageBoxSizeMode.Fit : ImageBoxSizeMode.Normal;
                    OnSizeToFitChanged(EventArgs.Empty);

                    if (value)
                    {
                        AutoPan = false;
                    }
                    else
                    {
                        ActualSize();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the alignment of the text on the control.
        /// </summary>
        /// <value>One of the <see cref="ContentAlignment"/> values. The default is <c>MiddleCenter</c>.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        public virtual ContentAlignment TextAlign
        {
            get => _textAlign;
            set
            {
                if (TextAlign != value)
                {
                    _textAlign = value;

                    OnTextAlignChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the text background.
        /// </summary>
        /// <value>The color of the text background.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Transparent")]
        public virtual Color TextBackColor
        {
            get => _textBackColor;
            set
            {
                if (TextBackColor != value)
                {
                    _textBackColor = value;

                    OnTextBackColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the text display mode.
        /// </summary>
        /// <value>The text display mode.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(ImageBoxGridDisplayMode), "Client")]
        public virtual ImageBoxGridDisplayMode TextDisplayMode
        {
            get => _textDisplayMode;
            set
            {
                if (TextDisplayMode != value)
                {
                    _textDisplayMode = value;

                    OnTextDisplayModeChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Padding), "0, 0, 0, 0")]
        public virtual Padding TextPadding
        {
            get => _textPadding;
            set
            {
                if (TextPadding != value)
                {
                    _textPadding = value;

                    OnTextPaddingChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets a value indicating whether the control acts as a virtual image box.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the control acts as a virtual image box; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        ///   When this property is set to <c>true</c>, the Image property is ignored in favor of the VirtualSize property. In addition, the VirtualDraw event is raised to allow custom painting of the image area.
        /// </remarks>
        [Category("Behavior")]
        [DefaultValue(false)]
        public virtual bool VirtualMode
        {
            get => _virtualMode;
            set
            {
                if (VirtualMode != value)
                {
                    _virtualMode = value;

                    OnVirtualModeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets the size of the virtual image.
        /// </summary>
        /// <value>The size of the virtual image.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Size), "0, 0")]
        public virtual Size VirtualSize
        {
            get => _virtualSize;
            set
            {
                if (VirtualSize != value)
                {
                    _virtualSize = value;

                    OnVirtualSizeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets the zoom.
        /// </summary>
        /// <value>The zoom.</value>
        [DefaultValue(100)]
        [Category("Appearance")]
        public virtual int Zoom
        {
            get => _zoom;
            set => SetZoom(value, value > Zoom ? ImageBoxZoomActions.ZoomIn : ImageBoxZoomActions.ZoomOut, ImageBoxActionSources.Unknown);
        }

        /// <summary>
        ///   Gets the zoom factor.
        /// </summary>
        /// <value>The zoom factor.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual double ZoomFactor => (double)Zoom / 100;

        /// <summary>
        ///   Gets or sets the zoom levels.
        /// </summary>
        /// <value>The zoom levels.</value>
        [Browsable(false) /*Category("Behavior"), DefaultValue(typeof(ZoomLevelCollection), "7, 10, 15, 20, 25, 30, 50, 70, 100, 150, 200, 300, 400, 500, 600, 700, 800, 1200, 1600")*/]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ZoomLevelCollection ZoomLevels
        {
            get => _zoomLevels;
            set
            {
                if (ZoomLevels != value)
                {
                    _zoomLevels = value;

                    OnZoomLevelsChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets a value indicating whether painting of the control is allowed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if painting of the control is allowed; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool AllowPainting => _updateCount == 0;

        /// <summary>
        /// Gets or sets a value indicating whether the current image is animated.
        /// </summary>
        /// <value><c>true</c> if the current image is animated; otherwise, <c>false</c>.</value>
        protected bool IsAnimating { get; set; }

        /// <summary>
        ///   Gets the height of the scaled image.
        /// </summary>
        /// <value>The height of the scaled image.</value>
        protected virtual int ScaledImageHeight => Convert.ToInt32(ViewSize.Height * ZoomFactor);

        /// <summary>
        ///   Gets the width of the scaled image.
        /// </summary>
        /// <value>The width of the scaled image.</value>
        protected virtual int ScaledImageWidth => Convert.ToInt32(ViewSize.Width * ZoomFactor);

        /// <summary>
        /// Gets the size of the view.
        /// </summary>
        /// <value>The size of the view.</value>
        protected virtual Size ViewSize => VirtualMode ? VirtualSize : GetImageSize();

        /// <summary>
        /// Gets or sets a value indicating whether a drag operation was cancelled.
        /// </summary>
        /// <value><c>true</c> if the drag operation was cancelled; otherwise, <c>false</c>.</value>
        protected bool WasDragCancelled { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///   Resets the zoom to 100%.
        /// </summary>
        public virtual void ActualSize()
        {
            PerformActualSize(ImageBoxActionSources.Unknown);
        }

        /// <summary>
        ///   Disables any redrawing of the image box
        /// </summary>
        public virtual void BeginUpdate()
        {
            _updateCount++;
        }

        /// <summary>
        ///   Centers the given point in the image in the center of the control
        /// </summary>
        /// <param name="imageLocation">The point of the image to attempt to center.</param>
        public virtual void CenterAt(Point imageLocation)
        {
            ScrollTo(imageLocation, new Point(ClientSize.Width / 2, ClientSize.Height / 2));
        }

        /// <summary>
        ///   Centers the given point in the image in the center of the control
        /// </summary>
        /// <param name="x">The X co-ordinate of the point to center.</param>
        /// <param name="y">The Y co-ordinate of the point to center.</param>
        public void CenterAt(int x, int y)
        {
            CenterAt(new Point(x, y));
        }

        /// <summary>
        ///   Centers the given point in the image in the center of the control
        /// </summary>
        /// <param name="x">The X co-ordinate of the point to center.</param>
        /// <param name="y">The Y co-ordinate of the point to center.</param>
        public void CenterAt(float x, float y)
        {
            CenterAt(new Point((int)x, (int)y));
        }

        /// <summary>
        /// Resets the viewport to show the center of the image.
        /// </summary>
        public virtual void CenterToImage()
        {
            AutoScrollPosition = new Point((AutoScrollMinSize.Width - ClientSize.Width) / 2, (AutoScrollMinSize.Height - ClientSize.Height) / 2);
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
        ///   Fits a given <see cref="T:System.Drawing.Rectangle" /> to match image boundaries
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>
        ///   A <see cref="T:System.Drawing.Rectangle" /> structure remapped to fit the image boundaries
        /// </returns>
        public Rectangle FitRectangle(Rectangle rectangle)
        {
            int x;
            int y;
            int w;
            int h;

            x = rectangle.X;
            y = rectangle.Y;
            w = rectangle.Width;
            h = rectangle.Height;

            if (x < 0)
            {
                x = 0;
            }

            if (y < 0)
            {
                y = 0;
            }

            if (x + w > ViewSize.Width)
            {
                w = ViewSize.Width - x;
            }

            if (y + h > ViewSize.Height)
            {
                h = ViewSize.Height - y;
            }

            return new Rectangle(x, y, w, h);
        }

        /// <summary>
        ///   Fits a given <see cref="T:System.Drawing.RectangleF" /> to match image boundaries
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>
        ///   A <see cref="T:System.Drawing.RectangleF" /> structure remapped to fit the image boundaries
        /// </returns>
        public RectangleF FitRectangle(RectangleF rectangle)
        {
            float x;
            float y;
            float w;
            float h;

            x = rectangle.X;
            y = rectangle.Y;
            w = rectangle.Width;
            h = rectangle.Height;

            if (x < 0)
            {
                w -= -x;
                x = 0;
            }

            if (y < 0)
            {
                h -= -y;
                y = 0;
            }

            if (x + w > ViewSize.Width)
            {
                w = ViewSize.Width - x;
            }

            if (y + h > ViewSize.Height)
            {
                h = ViewSize.Height - y;
            }

            return new RectangleF(x, y, w, h);
        }

        /// <summary>
        ///   Gets the image view port.
        /// </summary>
        /// <returns></returns>
        public virtual Rectangle GetImageViewPort()
        {
            Rectangle viewPort;

            if (!ViewSize.IsEmpty)
            {
                Rectangle innerRectangle;
                Point offset;
                int width;
                int height;

                innerRectangle = GetInsideViewPort(true);

                if (!HScroll && !VScroll) // if no scrolling is present, tinker the view port so that the image and any applicable borders all fit inside
                {
                    innerRectangle.Inflate(-GetImageBorderOffset(), -GetImageBorderOffset());
                }

                if (SizeMode != ImageBoxSizeMode.Stretch)
                {
                    if (AutoCenter)
                    {
                        int x;
                        int y;

                        x = !HScroll ? (innerRectangle.Width - (ScaledImageWidth + Padding.Horizontal)) / 2 : 0;
                        y = !VScroll ? (innerRectangle.Height - (ScaledImageHeight + Padding.Vertical)) / 2 : 0;

                        offset = new Point(x, y);
                    }
                    else
                    {
                        offset = Point.Empty;
                    }

                    width = Math.Min(ScaledImageWidth - Math.Abs(AutoScrollPosition.X), innerRectangle.Width);
                    height = Math.Min(ScaledImageHeight - Math.Abs(AutoScrollPosition.Y), innerRectangle.Height);
                }
                else
                {
                    offset = Point.Empty;
                    width = innerRectangle.Width;
                    height = innerRectangle.Height;
                }

                viewPort = new Rectangle(offset.X + innerRectangle.Left, offset.Y + innerRectangle.Top, width, height);
            }
            else
            {
                viewPort = Rectangle.Empty;
            }

            return viewPort;
        }

        /// <summary>
        ///   Gets the inside view port, excluding any padding.
        /// </summary>
        /// <returns></returns>
        public Rectangle GetInsideViewPort()
        {
            return GetInsideViewPort(false);
        }

        /// <summary>
        ///   Gets the inside view port.
        /// </summary>
        /// <param name="includePadding">
        ///   if set to <c>true</c> [include padding].
        /// </param>
        /// <returns></returns>
        public virtual Rectangle GetInsideViewPort(bool includePadding)
        {
            int left;
            int top;
            int width;
            int height;

            left = 0;
            top = 0;
            width = ClientSize.Width;
            height = ClientSize.Height;

            if (includePadding)
            {
                left += Padding.Left;
                top += Padding.Top;
                width -= Padding.Horizontal;
                height -= Padding.Vertical;
            }

            return new Rectangle(left, top, width, height);
        }

        /// <summary>
        ///   Returns the source <see cref="T:System.Drawing.Point" /> repositioned to include the current image offset and scaled by the current zoom level
        /// </summary>
        /// <param name="source">The source <see cref="Point"/> to offset.</param>
        /// <returns>A <see cref="Point"/> which has been repositioned to match the current zoom level and image offset</returns>
        public virtual Point GetOffsetPoint(Point source)
        {
            PointF offset;

            offset = GetOffsetPoint(new PointF(source.X, source.Y));

            return new Point((int)offset.X, (int)offset.Y);
        }

        /// <summary>
        ///   Returns the source co-ordinates repositioned to include the current image offset and scaled by the current zoom level
        /// </summary>
        /// <param name="x">The source X co-ordinate.</param>
        /// <param name="y">The source Y co-ordinate.</param>
        /// <returns>A <see cref="Point"/> which has been repositioned to match the current zoom level and image offset</returns>
        public Point GetOffsetPoint(int x, int y)
        {
            return GetOffsetPoint(new Point(x, y));
        }

        /// <summary>
        ///   Returns the source co-ordinates repositioned to include the current image offset and scaled by the current zoom level
        /// </summary>
        /// <param name="x">The source X co-ordinate.</param>
        /// <param name="y">The source Y co-ordinate.</param>
        /// <returns>A <see cref="Point"/> which has been repositioned to match the current zoom level and image offset</returns>
        public PointF GetOffsetPoint(float x, float y)
        {
            return GetOffsetPoint(new PointF(x, y));
        }

        /// <summary>
        ///   Returns the source <see cref="T:System.Drawing.PointF" /> repositioned to include the current image offset and scaled by the current zoom level
        /// </summary>
        /// <param name="source">The source <see cref="PointF"/> to offset.</param>
        /// <returns>A <see cref="PointF"/> which has been repositioned to match the current zoom level and image offset</returns>
        public virtual PointF GetOffsetPoint(PointF source)
        {
            Rectangle viewport;
            PointF scaled;
            int offsetX;
            int offsetY;

            viewport = GetImageViewPort();
            scaled = GetScaledPoint(source);
            offsetX = viewport.Left + Padding.Left + AutoScrollPosition.X;
            offsetY = viewport.Top + Padding.Top + AutoScrollPosition.Y;

            return new PointF(scaled.X + offsetX, scaled.Y + offsetY);
        }

        /// <summary>
        ///   Returns the source <see cref="T:System.Drawing.RectangleF" /> scaled according to the current zoom level and repositioned to include the current image offset
        /// </summary>
        /// <param name="source">The source <see cref="RectangleF"/> to offset.</param>
        /// <returns>A <see cref="RectangleF"/> which has been resized and repositioned to match the current zoom level and image offset</returns>
        public virtual RectangleF GetOffsetRectangle(RectangleF source)
        {
            RectangleF viewport;
            RectangleF scaled;
            float offsetX;
            float offsetY;

            viewport = GetImageViewPort();
            scaled = GetScaledRectangle(source);
            offsetX = viewport.Left + Padding.Left + AutoScrollPosition.X;
            offsetY = viewport.Top + Padding.Top + AutoScrollPosition.Y;

            return new RectangleF(new PointF(scaled.Left + offsetX, scaled.Top + offsetY), scaled.Size);
        }

        /// <summary>
        ///   Returns the source rectangle scaled according to the current zoom level and repositioned to include the current image offset
        /// </summary>
        /// <param name="x">The X co-ordinate of the source rectangle.</param>
        /// <param name="y">The Y co-ordinate of the source rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <returns>A <see cref="Rectangle"/> which has been resized and repositioned to match the current zoom level and image offset</returns>
        public Rectangle GetOffsetRectangle(int x, int y, int width, int height)
        {
            return GetOffsetRectangle(new Rectangle(x, y, width, height));
        }

        /// <summary>
        ///   Returns the source rectangle scaled according to the current zoom level and repositioned to include the current image offset
        /// </summary>
        /// <param name="x">The X co-ordinate of the source rectangle.</param>
        /// <param name="y">The Y co-ordinate of the source rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <returns>A <see cref="RectangleF"/> which has been resized and repositioned to match the current zoom level and image offset</returns>
        public RectangleF GetOffsetRectangle(float x, float y, float width, float height)
        {
            return GetOffsetRectangle(new RectangleF(x, y, width, height));
        }

        /// <summary>
        ///   Returns the source <see cref="T:System.Drawing.Rectangle" /> scaled according to the current zoom level and repositioned to include the current image offset
        /// </summary>
        /// <param name="source">The source <see cref="Rectangle"/> to offset.</param>
        /// <returns>A <see cref="Rectangle"/> which has been resized and repositioned to match the current zoom level and image offset</returns>
        public virtual Rectangle GetOffsetRectangle(Rectangle source)
        {
            Rectangle viewport;
            Rectangle scaled;
            int offsetX;
            int offsetY;

            viewport = GetImageViewPort();
            scaled = GetScaledRectangle(source);
            offsetX = viewport.Left + Padding.Left + AutoScrollPosition.X;
            offsetY = viewport.Top + Padding.Top + AutoScrollPosition.Y;

            return new Rectangle(new Point(scaled.Left + offsetX, scaled.Top + offsetY), scaled.Size);
        }

        /// <summary>
        ///   Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="proposedSize">The custom-sized area for a control.</param>
        /// <returns>
        ///   An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.
        /// </returns>
        public override Size GetPreferredSize(Size proposedSize)
        {
            Size size;

            if (!ViewSize.IsEmpty)
            {
                int width;
                int height;

                // get the size of the image
                width = ScaledImageWidth;
                height = ScaledImageHeight;

                // add an offset based on padding
                width += Padding.Horizontal;
                height += Padding.Vertical;

                // add an offset based on the border style
                width += GetImageBorderOffset();
                height += GetImageBorderOffset();

                size = new Size(width, height);
            }
            else
            {
                size = base.GetPreferredSize(proposedSize);
            }

            return size;
        }

        /// <summary>
        ///   Returns the source <see cref="T:System.Drawing.Point" /> scaled according to the current zoom level
        /// </summary>
        /// <param name="x">The X co-ordinate of the point to scale.</param>
        /// <param name="y">The Y co-ordinate of the point to scale.</param>
        /// <returns>A <see cref="Point"/> which has been scaled to match the current zoom level</returns>
        public Point GetScaledPoint(int x, int y)
        {
            return GetScaledPoint(new Point(x, y));
        }

        /// <summary>
        ///   Returns the source <see cref="T:System.Drawing.Point" /> scaled according to the current zoom level
        /// </summary>
        /// <param name="x">The X co-ordinate of the point to scale.</param>
        /// <param name="y">The Y co-ordinate of the point to scale.</param>
        /// <returns>A <see cref="Point"/> which has been scaled to match the current zoom level</returns>
        public PointF GetScaledPoint(float x, float y)
        {
            return GetScaledPoint(new PointF(x, y));
        }

        /// <summary>
        ///   Returns the source <see cref="T:System.Drawing.Point" /> scaled according to the current zoom level
        /// </summary>
        /// <param name="source">The source <see cref="Point"/> to scale.</param>
        /// <returns>A <see cref="Point"/> which has been scaled to match the current zoom level</returns>
        public virtual Point GetScaledPoint(Point source)
        {
            return new Point((int)(source.X * ZoomFactor), (int)(source.Y * ZoomFactor));
        }

        /// <summary>
        ///   Returns the source <see cref="T:System.Drawing.PointF" /> scaled according to the current zoom level
        /// </summary>
        /// <param name="source">The source <see cref="PointF"/> to scale.</param>
        /// <returns>A <see cref="PointF"/> which has been scaled to match the current zoom level</returns>
        public virtual PointF GetScaledPoint(PointF source)
        {
            return new PointF((float)(source.X * ZoomFactor), (float)(source.Y * ZoomFactor));
        }

        /// <summary>
        ///   Returns the source rectangle scaled according to the current zoom level
        /// </summary>
        /// <param name="x">The X co-ordinate of the source rectangle.</param>
        /// <param name="y">The Y co-ordinate of the source rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <returns>A <see cref="Rectangle"/> which has been scaled to match the current zoom level</returns>
        public Rectangle GetScaledRectangle(int x, int y, int width, int height)
        {
            return GetScaledRectangle(new Rectangle(x, y, width, height));
        }

        /// <summary>
        ///   Returns the source rectangle scaled according to the current zoom level
        /// </summary>
        /// <param name="x">The X co-ordinate of the source rectangle.</param>
        /// <param name="y">The Y co-ordinate of the source rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <returns>A <see cref="RectangleF"/> which has been scaled to match the current zoom level</returns>
        public RectangleF GetScaledRectangle(float x, float y, float width, float height)
        {
            return GetScaledRectangle(new RectangleF(x, y, width, height));
        }

        /// <summary>
        ///   Returns the source rectangle scaled according to the current zoom level
        /// </summary>
        /// <param name="location">The location of the source rectangle.</param>
        /// <param name="size">The size of the source rectangle.</param>
        /// <returns>A <see cref="Rectangle"/> which has been scaled to match the current zoom level</returns>
        public Rectangle GetScaledRectangle(Point location, Size size)
        {
            return GetScaledRectangle(new Rectangle(location, size));
        }

        /// <summary>
        ///   Returns the source rectangle scaled according to the current zoom level
        /// </summary>
        /// <param name="location">The location of the source rectangle.</param>
        /// <param name="size">The size of the source rectangle.</param>
        /// <returns>A <see cref="Rectangle"/> which has been scaled to match the current zoom level</returns>
        public RectangleF GetScaledRectangle(PointF location, SizeF size)
        {
            return GetScaledRectangle(new RectangleF(location, size));
        }

        /// <summary>
        ///   Returns the source <see cref="T:System.Drawing.Rectangle" /> scaled according to the current zoom level
        /// </summary>
        /// <param name="source">The source <see cref="Rectangle"/> to scale.</param>
        /// <returns>A <see cref="Rectangle"/> which has been scaled to match the current zoom level</returns>
        public virtual Rectangle GetScaledRectangle(Rectangle source)
        {
            return new Rectangle((int)(source.Left * ZoomFactor), (int)(source.Top * ZoomFactor), (int)(source.Width * ZoomFactor), (int)(source.Height * ZoomFactor));
        }

        /// <summary>
        ///   Returns the source <see cref="T:System.Drawing.RectangleF" /> scaled according to the current zoom level
        /// </summary>
        /// <param name="source">The source <see cref="RectangleF"/> to scale.</param>
        /// <returns>A <see cref="RectangleF"/> which has been scaled to match the current zoom level</returns>
        public virtual RectangleF GetScaledRectangle(RectangleF source)
        {
            return new RectangleF((float)(source.Left * ZoomFactor), (float)(source.Top * ZoomFactor), (float)(source.Width * ZoomFactor), (float)(source.Height * ZoomFactor));
        }

        /// <summary>
        ///   Returns the source size scaled according to the current zoom level
        /// </summary>
        /// <param name="width">The width of the size to scale.</param>
        /// <param name="height">The height of the size to scale.</param>
        /// <returns>A <see cref="SizeF"/> which has been resized to match the current zoom level</returns>
        public SizeF GetScaledSize(float width, float height)
        {
            return GetScaledSize(new SizeF(width, height));
        }

        /// <summary>
        ///   Returns the source size scaled according to the current zoom level
        /// </summary>
        /// <param name="width">The width of the size to scale.</param>
        /// <param name="height">The height of the size to scale.</param>
        /// <returns>A <see cref="Size"/> which has been resized to match the current zoom level</returns>
        public Size GetScaledSize(int width, int height)
        {
            return GetScaledSize(new Size(width, height));
        }

        /// <summary>
        ///   Returns the source <see cref="T:System.Drawing.SizeF" /> scaled according to the current zoom level
        /// </summary>
        /// <param name="source">The source <see cref="SizeF"/> to scale.</param>
        /// <returns>A <see cref="SizeF"/> which has been resized to match the current zoom level</returns>
        public virtual SizeF GetScaledSize(SizeF source)
        {
            return new SizeF((float)(source.Width * ZoomFactor), (float)(source.Height * ZoomFactor));
        }

        /// <summary>
        ///   Returns the source <see cref="T:System.Drawing.Size" /> scaled according to the current zoom level
        /// </summary>
        /// <param name="source">The source <see cref="Size"/> to scale.</param>
        /// <returns>A <see cref="Size"/> which has been resized to match the current zoom level</returns>
        public virtual Size GetScaledSize(Size source)
        {
            return new Size((int)(source.Width * ZoomFactor), (int)(source.Height * ZoomFactor));
        }

        /// <summary>
        ///   Creates an image based on the current selection region
        /// </summary>
        /// <returns>An image containing the selection contents if a selection if present, otherwise null</returns>
        /// <remarks>The caller is responsible for disposing of the returned image</remarks>
        public Image? GetSelectedImage()
        {
            Image? result;

            result = null;

            if (!SelectionRegion.IsEmpty)
            {
                Rectangle rect;

                rect = FitRectangle(new Rectangle((int)SelectionRegion.X, (int)SelectionRegion.Y, (int)SelectionRegion.Width, (int)SelectionRegion.Height));

                if (rect.Width > 0 && rect.Height > 0)
                {
                    result = new Bitmap(rect.Width, rect.Height);

                    using (Graphics g = Graphics.FromImage(result))
                    {
                        g.DrawImage(Image, new Rectangle(Point.Empty, rect.Size), rect, GraphicsUnit.Pixel);
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///   Gets the source image region.
        /// </summary>
        /// <returns></returns>
        public virtual RectangleF GetSourceImageRegion()
        {
            RectangleF region;

            if (!ViewSize.IsEmpty)
            {
                if (SizeMode != ImageBoxSizeMode.Stretch)
                {
                    float sourceLeft;
                    float sourceTop;
                    float sourceWidth;
                    float sourceHeight;
                    Rectangle viewPort;

                    viewPort = GetImageViewPort();
                    sourceLeft = (float)(-AutoScrollPosition.X / ZoomFactor);
                    sourceTop = (float)(-AutoScrollPosition.Y / ZoomFactor);
                    sourceWidth = (float)(viewPort.Width / ZoomFactor);
                    sourceHeight = (float)(viewPort.Height / ZoomFactor);

                    region = new RectangleF(sourceLeft, sourceTop, sourceWidth, sourceHeight);
                }
                else
                {
                    region = new RectangleF(PointF.Empty, ViewSize);
                }
            }
            else
            {
                region = RectangleF.Empty;
            }

            return region;
        }

        /// <summary>
        ///   Determines whether the specified point is located within the image view port
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        ///   <c>true</c> if the specified point is located within the image view port; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsPointInImage(Point point)
        {
            return GetImageViewPort().Contains(point);
        }

        /// <summary>
        ///   Determines whether the specified point is located within the image view port
        /// </summary>
        /// <param name="x">The X co-ordinate of the point to check.</param>
        /// <param name="y">The Y co-ordinate of the point to check.</param>
        /// <returns>
        ///   <c>true</c> if the specified point is located within the image view port; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPointInImage(int x, int y)
        {
            return IsPointInImage(new Point(x, y));
        }

        /// <summary>
        ///   Determines whether the specified point is located within the image view port
        /// </summary>
        /// <param name="x">The X co-ordinate of the point to check.</param>
        /// <param name="y">The Y co-ordinate of the point to check.</param>
        /// <returns>
        ///   <c>true</c> if the specified point is located within the image view port; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPointInImage(float x, float y)
        {
            return IsPointInImage(new Point((int)x, (int)y));
        }

        /// <summary>
        ///   Converts the given client size point to represent a coordinate on the source image.
        /// </summary>
        /// <param name="point">The source point.</param>
        /// <returns><c>Point.Empty</c> if the point could not be matched to the source image, otherwise the new translated point</returns>
        public Point PointToImage(Point point)
        {
            return PointToImage(point, false);
        }

        /// <summary>
        ///   Converts the given client size point to represent a coordinate on the source image.
        /// </summary>
        /// <param name="x">The X co-ordinate of the point to convert.</param>
        /// <param name="y">The Y co-ordinate of the point to convert.</param>
        /// <returns><c>Point.Empty</c> if the point could not be matched to the source image, otherwise the new translated point</returns>
        public Point PointToImage(float x, float y)
        {
            return PointToImage(x, y, false);
        }

        /// <summary>
        ///   Converts the given client size point to represent a coordinate on the source image.
        /// </summary>
        /// <param name="x">The X co-ordinate of the point to convert.</param>
        /// <param name="y">The Y co-ordinate of the point to convert.</param>
        /// <param name="fitToBounds">
        ///   if set to <c>true</c> and the point is outside the bounds of the source image, it will be mapped to the nearest edge.
        /// </param>
        /// <returns><c>Point.Empty</c> if the point could not be matched to the source image, otherwise the new translated point</returns>
        public Point PointToImage(float x, float y, bool fitToBounds)
        {
            return PointToImage(new Point((int)x, (int)y), fitToBounds);
        }

        /// <summary>
        ///   Converts the given client size point to represent a coordinate on the source image.
        /// </summary>
        /// <param name="x">The X co-ordinate of the point to convert.</param>
        /// <param name="y">The Y co-ordinate of the point to convert.</param>
        /// <returns><c>Point.Empty</c> if the point could not be matched to the source image, otherwise the new translated point</returns>
        public Point PointToImage(int x, int y)
        {
            return PointToImage(x, y, false);
        }

        /// <summary>
        ///   Converts the given client size point to represent a coordinate on the source image.
        /// </summary>
        /// <param name="x">The X co-ordinate of the point to convert.</param>
        /// <param name="y">The Y co-ordinate of the point to convert.</param>
        /// <param name="fitToBounds">
        ///   if set to <c>true</c> and the point is outside the bounds of the source image, it will be mapped to the nearest edge.
        /// </param>
        /// <returns><c>Point.Empty</c> if the point could not be matched to the source image, otherwise the new translated point</returns>
        public Point PointToImage(int x, int y, bool fitToBounds)
        {
            return PointToImage(new Point(x, y), fitToBounds);
        }

        /// <summary>
        ///   Converts the given client size point to represent a coordinate on the source image.
        /// </summary>
        /// <param name="point">The source point.</param>
        /// <param name="fitToBounds">
        ///   if set to <c>true</c> and the point is outside the bounds of the source image, it will be mapped to the nearest edge.
        /// </param>
        /// <returns><c>Point.Empty</c> if the point could not be matched to the source image, otherwise the new translated point</returns>
        public virtual Point PointToImage(Point point, bool fitToBounds)
        {
            Rectangle viewport;
            int x;
            int y;

            viewport = GetImageViewPort();

            if (!fitToBounds || viewport.Contains(point))
            {
                if (AutoScrollPosition != Point.Empty)
                {
                    point = new Point(point.X - AutoScrollPosition.X, point.Y - AutoScrollPosition.Y);
                }

                x = (int)((point.X - viewport.X) / ZoomFactor);
                y = (int)((point.Y - viewport.Y) / ZoomFactor);

                if (fitToBounds)
                {
                    if (x < 0)
                    {
                        x = 0;
                    }
                    else if (x > ViewSize.Width)
                    {
                        x = ViewSize.Width;
                    }

                    if (y < 0)
                    {
                        y = 0;
                    }
                    else if (y > ViewSize.Height)
                    {
                        y = ViewSize.Height;
                    }
                }
            }
            else
            {
                x = 0; // Return Point.Empty if we couldn't match
                y = 0;
            }

            return new Point(x, y);
        }

        /// <summary>
        ///   Scrolls the control to the given point in the image, offset at the specified display point
        /// </summary>
        /// <param name="x">The X co-ordinate of the point to scroll to.</param>
        /// <param name="y">The Y co-ordinate of the point to scroll to.</param>
        /// <param name="relativeX">The X co-ordinate relative to the <c>x</c> parameter.</param>
        /// <param name="relativeY">The Y co-ordinate relative to the <c>y</c> parameter.</param>
        public void ScrollTo(int x, int y, int relativeX, int relativeY)
        {
            ScrollTo(new Point(x, y), new Point(relativeX, relativeY));
        }

        /// <summary>
        ///   Scrolls the control to the given point in the image, offset at the specified display point
        /// </summary>
        /// <param name="x">The X co-ordinate of the point to scroll to.</param>
        /// <param name="y">The Y co-ordinate of the point to scroll to.</param>
        /// <param name="relativeX">The X co-ordinate relative to the <c>x</c> parameter.</param>
        /// <param name="relativeY">The Y co-ordinate relative to the <c>y</c> parameter.</param>
        public void ScrollTo(float x, float y, float relativeX, float relativeY)
        {
            ScrollTo(new Point((int)x, (int)y), new Point((int)relativeX, (int)relativeY));
        }

        /// <summary>
        ///   Scrolls the control to the given point in the image, offset at the specified display point
        /// </summary>
        /// <param name="imageLocation">The point of the image to attempt to scroll to.</param>
        /// <param name="relativeDisplayPoint">The relative display point to offset scrolling by.</param>
        public virtual void ScrollTo(Point imageLocation, Point relativeDisplayPoint)
        {
            int x;
            int y;

            x = (int)(imageLocation.X * ZoomFactor) - relativeDisplayPoint.X;
            y = (int)(imageLocation.Y * ZoomFactor) - relativeDisplayPoint.Y;

            AutoScrollPosition = new Point(x, y);
        }

        /// <summary>
        ///   Creates a selection region which encompasses the entire image
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown if no image is currently set</exception>
        public virtual void SelectAll()
        {
            SelectionRegion = new RectangleF(PointF.Empty, ViewSize);
        }

        /// <summary>
        ///   Clears any existing selection region
        /// </summary>
        public virtual void SelectNone()
        {
            SelectionRegion = RectangleF.Empty;
        }

        /// <summary>
        ///   Zooms into the image
        /// </summary>
        public virtual void ZoomIn()
        {
            ZoomIn(true);
        }

        /// <summary>
        ///   Zooms into the image
        /// </summary>
        /// <param name="preservePosition"><c>true</c> if the current scrolling position should be preserved relative to the new zoom level, <c>false</c> to reset.</param>
        public virtual void ZoomIn(bool preservePosition)
        {
            PerformZoomIn(ImageBoxActionSources.Unknown, preservePosition);
        }

        /// <summary>
        ///   Zooms out of the image
        /// </summary>
        public virtual void ZoomOut()
        {
            ZoomOut(true);
        }

        /// <summary>
        ///   Zooms out of the image
        /// </summary>
        /// <param name="preservePosition"><c>true</c> if the current scrolling position should be preserved relative to the new zoom level, <c>false</c> to reset.</param>
        public virtual void ZoomOut(bool preservePosition)
        {
            PerformZoomOut(ImageBoxActionSources.Unknown, preservePosition);
        }

        /// <summary>
        ///   Zooms to the maximum size for displaying the entire image within the bounds of the control.
        /// </summary>
        public virtual void ZoomToFit()
        {
            if (!ViewSize.IsEmpty)
            {
                Rectangle innerRectangle;
                double zoom;
                double aspectRatio;

                AutoScrollMinSize = Size.Empty;

                innerRectangle = GetInsideViewPort(true);

                if (ViewSize.Width > ViewSize.Height)
                {
                    aspectRatio = (double)innerRectangle.Width / ViewSize.Width;
                    zoom = aspectRatio * 100.0;

                    if (innerRectangle.Height < ViewSize.Height * zoom / 100.0)
                    {
                        aspectRatio = (double)innerRectangle.Height / ViewSize.Height;
                        zoom = aspectRatio * 100.0;
                    }
                }
                else
                {
                    aspectRatio = (double)innerRectangle.Height / ViewSize.Height;
                    zoom = aspectRatio * 100.0;

                    if (innerRectangle.Width < ViewSize.Width * zoom / 100.0)
                    {
                        aspectRatio = (double)innerRectangle.Width / ViewSize.Width;
                        zoom = aspectRatio * 100.0;
                    }
                }

                Zoom = (int)Math.Round(Math.Floor(zoom));
            }
        }

        /// <summary>
        ///   Adjusts the view port to fit the given region
        /// </summary>
        /// <param name="x">The X co-ordinate of the selection region.</param>
        /// <param name="y">The Y co-ordinate of the selection region.</param>
        /// <param name="width">The width of the selection region.</param>
        /// <param name="height">The height of the selection region.</param>
        public void ZoomToRegion(float x, float y, float width, float height)
        {
            ZoomToRegion(new RectangleF(x, y, width, height));
        }

        /// <summary>
        ///   Adjusts the view port to fit the given region
        /// </summary>
        /// <param name="x">The X co-ordinate of the selection region.</param>
        /// <param name="y">The Y co-ordinate of the selection region.</param>
        /// <param name="width">The width of the selection region.</param>
        /// <param name="height">The height of the selection region.</param>
        public void ZoomToRegion(int x, int y, int width, int height)
        {
            ZoomToRegion(new RectangleF(x, y, width, height));
        }

        /// <summary>
        ///   Adjusts the view port to fit the given region
        /// </summary>
        /// <param name="rectangle">The rectangle to fit the view port to.</param>
        public virtual void ZoomToRegion(RectangleF rectangle)
        {
            double ratioX;
            double ratioY;
            double zoomFactor;
            int cx;
            int cy;

            ratioX = ClientSize.Width / rectangle.Width;
            ratioY = ClientSize.Height / rectangle.Height;
            zoomFactor = Math.Min(ratioX, ratioY);
            cx = (int)(rectangle.X + rectangle.Width / 2);
            cy = (int)(rectangle.Y + rectangle.Height / 2);

            Zoom = (int)(zoomFactor * 100);
            CenterAt(new Point(cx, cy));
        }

        /// <summary>
        ///   Adjusts the layout.
        /// </summary>
        protected virtual void AdjustLayout()
        {
            if (AllowPainting)
            {
                if (AutoSize)
                {
                    AdjustSize();
                }
                else if (SizeMode != ImageBoxSizeMode.Normal)
                {
                    ZoomToFit();
                }
                else if (AutoScroll)
                {
                    AdjustViewPort();
                }

                Invalidate();
            }
        }

        /// <summary>
        ///   Adjusts the scroll.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        protected virtual void AdjustScroll(int x, int y)
        {
            Point scrollPosition;

            scrollPosition = new Point(HorizontalScroll.Value + x, VerticalScroll.Value + y);

            UpdateScrollPosition(scrollPosition);
        }

        /// <summary>
        ///   Adjusts the size.
        /// </summary>
        protected virtual void AdjustSize()
        {
            if (AutoSize && Dock == DockStyle.None)
            {
                Size = PreferredSize;
            }
        }

        /// <summary>
        ///   Adjusts the view port.
        /// </summary>
        protected virtual void AdjustViewPort()
        {
            if (AutoScroll && !ViewSize.IsEmpty)
            {
                AutoScrollMinSize = new Size(ScaledImageWidth + Padding.Horizontal, ScaledImageHeight + Padding.Vertical);
            }
        }

        /// <summary>
        ///   Creates the grid tile image.
        /// </summary>
        /// <param name="cellSize">Size of the cell.</param>
        /// <param name="firstColor">The first color.</param>
        /// <param name="secondColor">Color of the second.</param>
        /// <returns></returns>
        protected virtual Bitmap CreateGridTileImage(int cellSize, Color firstColor, Color secondColor)
        {
            float scale;

            // rescale the cell size
            switch (GridScale)
            {
                case ImageBoxGridScale.Medium:
                    scale = 1.5F;
                    break;

                case ImageBoxGridScale.Large:
                    scale = 2;
                    break;

                case ImageBoxGridScale.Tiny:
                    scale = 0.5F;
                    break;

                default:
                    scale = 1;
                    break;
            }

            cellSize = (int)(cellSize * scale);

            return CreateCheckerBoxTile(cellSize, firstColor, secondColor);
        }

        /// <summary>
        ///   Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (IsAnimating)
                {
                    ImageAnimator.StopAnimate(Image, OnFrameChangedHandler);
                }

                if (_texture != null)
                {
                    _texture.Dispose();
                    _texture = null;
                }

                if (_gridTile != null)
                {
                    _gridTile.Dispose();
                    _gridTile = null;
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Draws the background of the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected virtual void DrawBackground(PaintEventArgs e)
        {
            Rectangle innerRectangle;

            innerRectangle = GetInsideViewPort();

            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(brush, innerRectangle);
            }

            if (_texture != null && GridDisplayMode != ImageBoxGridDisplayMode.None)
            {
                switch (GridDisplayMode)
                {
                    case ImageBoxGridDisplayMode.Image:
                        Rectangle fillRectangle;

                        fillRectangle = GetImageViewPort();
                        e.Graphics.FillRectangle(_texture, fillRectangle);
                        break;

                    case ImageBoxGridDisplayMode.Client:
                        e.Graphics.FillRectangle(_texture, innerRectangle);
                        break;
                }
            }
        }

        /// <summary>
        ///   Draws a drop shadow.
        /// </summary>
        /// <param name="g">The graphics. </param>
        /// <param name="viewPort"> The view port. </param>
        protected virtual void DrawDropShadow(Graphics g, Rectangle viewPort)
        {
            Rectangle rightEdge;
            Rectangle bottomEdge;

            rightEdge = new Rectangle(viewPort.Right + 1, viewPort.Top + DropShadowSize, DropShadowSize, viewPort.Height);
            bottomEdge = new Rectangle(viewPort.Left + DropShadowSize, viewPort.Bottom + 1, viewPort.Width + 1, DropShadowSize);

            using (Brush brush = new SolidBrush(ImageBorderColor))
            {
                g.FillRectangles(brush, [
                    rightEdge,
                                  bottomEdge
                ]);
            }
        }

        /// <summary>
        ///   Draws a glow shadow.
        /// </summary>
        /// <param name="g">The graphics.</param>
        /// <param name="viewPort">The view port.</param>
        protected virtual void DrawGlowShadow(Graphics g, Rectangle viewPort)
        {
            // Glow code adapted from http://www.codeproject.com/Articles/372743/gGlowBox-Create-a-glow-effect-around-a-focused-con

            g.SetClip(viewPort, CombineMode.Exclude); // make sure the inside glow doesn't appear

            using (GraphicsPath path = new GraphicsPath())
            {
                int glowSize;
                int feather;

                path.AddRectangle(viewPort);
                glowSize = DropShadowSize * 3;
                feather = 50;

                for (int i = 1; i <= glowSize; i += 2)
                {
                    int alpha;

                    alpha = feather - feather / glowSize * i;

                    using (Pen pen = new Pen(Color.FromArgb(alpha, ImageBorderColor), i)
                    {
                        LineJoin = LineJoin.Round
                    })
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }
        }

        /// <summary>
        ///   Draws the image.
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void DrawImage(Graphics g)
        {
            InterpolationMode currentInterpolationMode;
            PixelOffsetMode currentPixelOffsetMode;

            currentInterpolationMode = g.InterpolationMode;
            currentPixelOffsetMode = g.PixelOffsetMode;

            g.InterpolationMode = GetInterpolationMode();

            // disable pixel offsets. Thanks to Rotem for the info.
            // http://stackoverflow.com/questions/14070311/why-is-graphics-drawimage-cropping-part-of-my-image/14070372#14070372
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            try
            {
                // Animation. Thanks to teamalpha5441 for the contribution
                if (IsAnimating && !DesignMode)
                {
                    ImageAnimator.UpdateFrames(Image);
                }

                g.DrawImage(Image, GetImageViewPort(), GetSourceImageRegion(), GraphicsUnit.Pixel);
            }
            catch (Exception ex)
            {
                TextRenderer.DrawText(g, ex.Message, Font, ClientRectangle, ForeColor, BackColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak | TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix);
            }

            g.PixelOffsetMode = currentPixelOffsetMode;
            g.InterpolationMode = currentInterpolationMode;
        }

        /// <summary>
        ///   Draws a border around the image.
        /// </summary>
        /// <param name="graphics"> The graphics. </param>
        protected virtual void DrawImageBorder(Graphics graphics)
        {
            if (ImageBorderStyle != ImageBoxBorderStyle.None)
            {
                Rectangle viewPort;

                graphics.SetClip(GetInsideViewPort()); // make sure the image border doesn't overwrite the control border

                viewPort = GetImageViewPort();
                viewPort = new Rectangle(viewPort.Left - 1, viewPort.Top - 1, viewPort.Width + 1, viewPort.Height + 1);

                using (Pen borderPen = new Pen(ImageBorderColor))
                {
                    graphics.DrawRectangle(borderPen, viewPort);
                }

                switch (ImageBorderStyle)
                {
                    case ImageBoxBorderStyle.FixedSingleDropShadow:
                        DrawDropShadow(graphics, viewPort);
                        break;
                    case ImageBoxBorderStyle.FixedSingleGlowShadow:
                        DrawGlowShadow(graphics, viewPort);
                        break;
                }

                graphics.ResetClip();
            }
        }

        /// <summary>
        /// Draws the specified text within the specified bounds using the specified device context.
        /// </summary>
        /// <param name="graphics">The device context in which to draw the text.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="bounds">The <see cref="Rectangle"/> that represents the bounds of the text.</param>
        protected void DrawLabel(Graphics graphics, string text, Rectangle bounds)
        {
            DrawLabel(graphics, text, Font, ForeColor, TextBackColor, TextAlign, bounds);
        }

        /// <summary>
        /// Draws the specified text within the specified bounds using the specified device context and font.
        /// </summary>
        /// <param name="graphics">The device context in which to draw the text.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The <see cref="Font"/> to apply to the drawn text.</param>
        /// <param name="bounds">The <see cref="Rectangle"/> that represents the bounds of the text.</param>
        protected void DrawLabel(Graphics graphics, string text, Font font, Rectangle bounds)
        {
            DrawLabel(graphics, text, font, ForeColor, TextBackColor, TextAlign, bounds);
        }

        /// <summary>
        /// Draws the specified text within the specified bounds using the specified device context, font, and color.
        /// </summary>
        /// <param name="graphics">The device context in which to draw the text.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The <see cref="Font"/> to apply to the drawn text.</param>
        /// <param name="foreColor">The <see cref="Color"/> to apply to the text.</param>
        /// <param name="bounds">The <see cref="Rectangle"/> that represents the bounds of the text.</param>
        protected void DrawLabel(Graphics graphics, string text, Font font, Color foreColor, Rectangle bounds)
        {
            DrawLabel(graphics, text, font, foreColor, TextBackColor, TextAlign, bounds);
        }

        /// <summary>
        /// Draws the specified text within the specified bounds using the specified device context, font, color, and back color.
        /// </summary>
        /// <param name="graphics">The device context in which to draw the text.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The <see cref="Font"/> to apply to the drawn text.</param>
        /// <param name="foreColor">The <see cref="Color"/> to apply to the text.</param>
        /// <param name="backColor">The <see cref="Color"/> to apply to the area represented by <c>bounds</c>.</param>
        /// <param name="bounds">The <see cref="Rectangle"/> that represents the bounds of the text.</param>
        protected void DrawLabel(Graphics graphics, string text, Font font, Color foreColor, Color backColor, Rectangle bounds)
        {
            DrawLabel(graphics, text, font, foreColor, backColor, TextAlign, bounds);
        }

        /// <summary>
        /// Draws the specified text within the specified bounds using the specified device context, font, color, back color, and formatting instructions.
        /// </summary>
        /// <param name="graphics">The device context in which to draw the text.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The <see cref="Font"/> to apply to the drawn text.</param>
        /// <param name="foreColor">The <see cref="Color"/> to apply to the text.</param>
        /// <param name="backColor">The <see cref="Color"/> to apply to the area represented by <c>bounds</c>.</param>
        /// <param name="textAlign">The <see cref="ContentAlignment"/> to apply to the text.</param>
        /// <param name="bounds">The <see cref="Rectangle"/> that represents the bounds of the text.</param>
        protected void DrawLabel(Graphics graphics, string text, Font font, Color foreColor, Color backColor, ContentAlignment textAlign, Rectangle bounds)
        {
            DrawLabel(graphics, text, font, foreColor, backColor, textAlign, bounds, ScaleText);
        }

        /// <summary>
        /// Draws the specified text within the specified bounds using the specified device context, font, color, back color, and formatting instructions.
        /// </summary>
        /// <param name="graphics">The device context in which to draw the text.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The <see cref="Font"/> to apply to the drawn text.</param>
        /// <param name="foreColor">The <see cref="Color"/> to apply to the text.</param>
        /// <param name="backColor">The <see cref="Color"/> to apply to the area represented by <c>bounds</c>.</param>
        /// <param name="textAlign">The <see cref="ContentAlignment"/> to apply to the text.</param>
        /// <param name="bounds">The <see cref="Rectangle"/> that represents the bounds of the text.</param>
        /// <param name="scaleText">If set to <c>true</c> the font size is scaled according to the current zoom level.</param>
        protected virtual void DrawLabel(Graphics graphics, string text, Font font, Color foreColor, Color backColor, ContentAlignment textAlign, Rectangle bounds, bool scaleText)
        {
            DrawLabel(graphics, text, font, foreColor, backColor, textAlign, bounds, scaleText, Padding.Empty);
        }

        /// <summary>
        /// Draws the specified text within the specified bounds using the specified device context, font, color, back color, and formatting instructions.
        /// </summary>
        /// <param name="graphics">The device context in which to draw the text.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The <see cref="Font"/> to apply to the drawn text.</param>
        /// <param name="foreColor">The <see cref="Color"/> to apply to the text.</param>
        /// <param name="backColor">The <see cref="Color"/> to apply to the area represented by <c>bounds</c>.</param>
        /// <param name="textAlign">The <see cref="ContentAlignment"/> to apply to the text.</param>
        /// <param name="bounds">The <see cref="Rectangle"/> that represents the bounds of the text.</param>
        /// <param name="scaleText">If set to <c>true</c> the font size is scaled according to the current zoom level.</param>
        /// <param name="padding">Padding to apply around the text</param>
        protected virtual void DrawLabel(Graphics graphics, string text, Font font, Color foreColor, Color backColor, ContentAlignment textAlign, Rectangle bounds, bool scaleText, Padding padding)
        {
            TextFormatFlags flags;

            if (scaleText)
            {
                font = new Font(font.FontFamily, (float)(font.Size * ZoomFactor), font.Style);
            }

            flags = TextFormatFlags.NoPrefix | TextFormatFlags.WordEllipsis | TextFormatFlags.WordBreak | TextFormatFlags.NoPadding;

            switch (textAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    flags |= TextFormatFlags.Left;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    flags |= TextFormatFlags.Right;
                    break;
                default:
                    flags |= TextFormatFlags.HorizontalCenter;
                    break;
            }

            switch (textAlign)
            {
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopRight:
                    flags |= TextFormatFlags.Top;
                    break;
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomRight:
                    flags |= TextFormatFlags.Bottom;
                    break;
                default:
                    flags |= TextFormatFlags.VerticalCenter;
                    break;
            }

            if (padding.Horizontal != 0 || padding.Vertical != 0)
            {
                Size size;
                int x;
                int y;
                int width;
                int height;

                size = TextRenderer.MeasureText(graphics, text, font, bounds.Size, flags);
                width = size.Width;
                height = size.Height;

                switch (textAlign)
                {
                    case ContentAlignment.TopLeft:
                        x = bounds.Left + padding.Left;
                        y = bounds.Top + padding.Top;
                        break;
                    case ContentAlignment.TopCenter:
                        x = bounds.Left + padding.Left + ((bounds.Width - width) / 2 - padding.Right);
                        y = bounds.Top + padding.Top;
                        break;
                    case ContentAlignment.TopRight:
                        x = bounds.Right - (padding.Right + width);
                        y = bounds.Top + padding.Top;
                        break;
                    case ContentAlignment.MiddleLeft:
                        x = bounds.Left + padding.Left;
                        y = bounds.Top + padding.Top + (bounds.Height - height) / 2;
                        break;
                    case ContentAlignment.MiddleCenter:
                        x = bounds.Left + padding.Left + ((bounds.Width - width) / 2 - padding.Right);
                        y = bounds.Top + padding.Top + (bounds.Height - height) / 2;
                        break;
                    case ContentAlignment.MiddleRight:
                        x = bounds.Right - (padding.Right + width);
                        y = bounds.Top + padding.Top + (bounds.Height - height) / 2;
                        break;
                    case ContentAlignment.BottomLeft:
                        x = bounds.Left + padding.Left;
                        y = bounds.Bottom - (padding.Bottom + height);
                        break;
                    case ContentAlignment.BottomCenter:
                        x = bounds.Left + padding.Left + ((bounds.Width - width) / 2 - padding.Right);
                        y = bounds.Bottom - (padding.Bottom + height);
                        break;
                    case ContentAlignment.BottomRight:
                        x = bounds.Right - (padding.Right + width);
                        y = bounds.Bottom - (padding.Bottom + height);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(textAlign));
                }

                if (backColor != Color.Empty && backColor.A > 0)
                {
                    using (Brush brush = new SolidBrush(backColor))
                    {
                        graphics.FillRectangle(brush, x - padding.Left, y - padding.Top, width + padding.Horizontal, height + padding.Vertical);
                    }
                }

                bounds = new Rectangle(x, y, width, height);

                //bounds = new Rectangle(bounds.Left + padding.Left, bounds.Top + padding.Top, bounds.Width - padding.Horizontal, bounds.Height - padding.Vertical);
            }

            TextRenderer.DrawText(graphics, text, font, bounds, foreColor, backColor, flags);

            if (scaleText)
            {
                font.Dispose();
            }
        }

        /// <summary>
        ///   Draws a pixel grid.
        /// </summary>
        /// <param name="g">The graphics to draw the grid to.</param>
        protected virtual void DrawPixelGrid(Graphics g)
        {
            float pixelSize;

            pixelSize = (float)ZoomFactor;

            if (pixelSize > PixelGridThreshold)
            {
                Rectangle viewport;
                float offsetX;
                float offsetY;

                viewport = GetImageViewPort();
                offsetX = Math.Abs(AutoScrollPosition.X) % pixelSize;
                offsetY = Math.Abs(AutoScrollPosition.Y) % pixelSize;

                using (Pen pen = new Pen(PixelGridColor)
                {
                    DashStyle = DashStyle.Dot
                })
                {
                    for (float x = viewport.Left + pixelSize - offsetX; x < viewport.Right; x += pixelSize)
                    {
                        g.DrawLine(pen, x, viewport.Top, x, viewport.Bottom);
                    }

                    for (float y = viewport.Top + pixelSize - offsetY; y < viewport.Bottom; y += pixelSize)
                    {
                        g.DrawLine(pen, viewport.Left, y, viewport.Right, y);
                    }

                    g.DrawRectangle(pen, viewport);
                }
            }
        }

        /// <summary>
        ///   Draws the selection region.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.Windows.Forms.PaintEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void DrawSelection(PaintEventArgs e)
        {
            RectangleF rect;

            e.Graphics.SetClip(GetInsideViewPort(true));

            rect = GetOffsetRectangle(SelectionRegion);

            using (Brush brush = new SolidBrush(Color.FromArgb(128, SelectionColor)))
            {
                e.Graphics.FillRectangle(brush, rect);
            }

            using (Pen pen = new Pen(SelectionColor))
            {
                e.Graphics.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
            }

            e.Graphics.ResetClip();
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected virtual void DrawText(PaintEventArgs e)
        {
            Rectangle bounds;

            bounds = TextDisplayMode == ImageBoxGridDisplayMode.Client ? GetInsideViewPort() : GetImageViewPort();

            DrawLabel(e.Graphics, Text, Font, ForeColor, TextBackColor, TextAlign, bounds, ScaleText, TextPadding);
        }

        /// <summary>
        /// Completes an ongoing selection or drag operation.
        /// </summary>
        protected virtual void EndDrag()
        {
            IsSelecting = false;
            OnSelected(EventArgs.Empty);
        }

        /// <summary>
        ///   Gets an offset based on the current image border style.
        /// </summary>
        /// <returns></returns>
        protected virtual int GetImageBorderOffset()
        {
            int offset;

            switch (ImageBorderStyle)
            {
                case ImageBoxBorderStyle.FixedSingle:
                    offset = 1;
                    break;

                case ImageBoxBorderStyle.FixedSingleDropShadow:
                    offset = DropShadowSize + 1;
                    break;
                default:
                    offset = 0;
                    break;
            }

            return offset;
        }

        protected virtual InterpolationMode GetInterpolationMode()
        {
            InterpolationMode mode;

            mode = InterpolationMode;

            if (mode == InterpolationMode.Default)
            {
                // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                if (Zoom < 100)
                {
                    // TODO: Check to see if we should cherry pick other modes depending on how much the image is actually zoomed
                    mode = InterpolationMode.HighQualityBicubic;
                }
                else
                {
                    mode = InterpolationMode.NearestNeighbor;
                }
            }

            return mode;
        }

        /// <summary>
        ///   Determines whether the specified key is a regular input key or a special key that requires preprocessing.
        /// </summary>
        /// <param name="keyData">
        ///   One of the <see cref="T:System.Windows.Forms.Keys" /> values.
        /// </param>
        /// <returns>
        ///   true if the specified key is a regular input key; otherwise, false.
        /// </returns>
        protected override bool IsInputKey(Keys keyData)
        {
            bool result;

            if ((keyData & Keys.Right) == Keys.Right | (keyData & Keys.Left) == Keys.Left | (keyData & Keys.Up) == Keys.Up | (keyData & Keys.Down) == Keys.Down)
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
        ///   Raises the <see cref="AllowClickZoomChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAllowClickZoomChanged(EventArgs e)
        {
            EventHandler? handler;

            handler = Events[_eventAllowClickZoomChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="AllowDoubleClickChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAllowDoubleClickChanged(EventArgs e)
        {
            EventHandler? handler;

            SetStyle(ControlStyles.StandardDoubleClick, AllowDoubleClick);

            handler = Events[_eventAllowDoubleClickChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="AllowUnfocusedMouseWheelChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnAllowUnfocusedMouseWheelChanged(EventArgs e)
        {
            EventHandler? handler;

            if (AllowUnfocusedMouseWheel)
            {
                // TODO: Not doing any reference counting so there's
                // currently no way of disabling the message filter
                // after the first time it has been enabled
                ImageBoxExtendedMouseWheelMessageFilter.Active = true;
            }

            handler = Events[_eventAllowUnfocusedMouseWheelChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="AllowZoomChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAllowZoomChanged(EventArgs e)
        {
            EventHandler? handler;

            handler = Events[_eventAllowZoomChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="AutoCenterChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAutoCenterChanged(EventArgs e)
        {
            EventHandler? handler;

            Invalidate();

            handler = Events[_eventAutoCenterChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="AutoPanChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAutoPanChanged(EventArgs e)
        {
            EventHandler? handler;

            handler = Events[_eventAutoPanChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.BackColorChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            Invalidate();
        }

        /// <summary>
        ///   Raises the <see cref="ScrollControl.BorderStyleChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected override void OnBorderStyleChanged(EventArgs e)
        {
            base.OnBorderStyleChanged(e);

            AdjustLayout();
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.DockChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnDockChanged(EventArgs e)
        {
            base.OnDockChanged(e);

            if (Dock != DockStyle.None)
            {
                AutoSize = false;
            }
        }

        /// <summary>
        ///   Raises the <see cref="DropShadowSizeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnDropShadowSizeChanged(EventArgs e)
        {
            EventHandler? handler;

            Invalidate();

            handler = Events[_eventDropShadowSizeChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.FontChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ForeColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);

            Invalidate();
        }

        /// <summary>
        ///   Raises the <see cref="GridCellSizeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnGridCellSizeChanged(EventArgs e)
        {
            EventHandler? handler;

            InitializeGridTile();

            handler = Events[_eventGridCellSizeChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="GridColorAlternateChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnGridColorAlternateChanged(EventArgs e)
        {
            EventHandler? handler;

            InitializeGridTile();

            handler = Events[_eventGridColorAlternateChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="GridColorChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnGridColorChanged(EventArgs e)
        {
            EventHandler? handler;

            InitializeGridTile();

            handler = Events[_eventGridColorChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="GridDisplayModeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnGridDisplayModeChanged(EventArgs e)
        {
            EventHandler? handler;

            InitializeGridTile();
            Invalidate();

            handler = Events[_eventGridDisplayModeChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="GridScaleChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnGridScaleChanged(EventArgs e)
        {
            EventHandler? handler;

            InitializeGridTile();

            handler = Events[_eventGridScaleChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="ImageBorderColorChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnImageBorderColorChanged(EventArgs e)
        {
            EventHandler? handler;

            Invalidate();

            handler = Events[_eventImageBorderColorChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="ImageBorderStyleChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnImageBorderStyleChanged(EventArgs e)
        {
            EventHandler? handler;

            Invalidate();

            handler = Events[_eventImageBorderStyleChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="ImageChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnImageChanged(EventArgs e)
        {
            EventHandler? handler;

            IsAnimating = false;

            if (Image != null)
            {
                try
                {
                    IsAnimating = ImageAnimator.CanAnimate(Image);
                    if (IsAnimating)
                    {
                        ImageAnimator.Animate(Image, OnFrameChangedHandler);
                    }
                }
                catch (ArgumentException)
                {
                    // probably a disposed image, ignore
                }
            }

            AdjustLayout();

            handler = Events[_eventImageChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="InterpolationModeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnInterpolationModeChanged(EventArgs e)
        {
            EventHandler? handler;

            Invalidate();

            handler = Events[_eventInterpolationModeChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="InvertMouseChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnInvertMouseChanged(EventArgs e)
        {
            EventHandler? handler;

            handler = Events[_eventInvertMouseChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.KeyDown" /> event.
        /// </summary>
        /// <param name="e">
        ///   A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            ProcessScrollingShortcuts(e);

            if (ShortcutsEnabled && AllowZoom && SizeMode == ImageBoxSizeMode.Normal)
            {
                ProcessImageShortcuts(e);
            }
        }

        /// <summary>
        ///   Raises the <see cref="LimitSelectionToImageChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnLimitSelectionToImageChanged(EventArgs e)
        {
            EventHandler? handler;

            handler = Events[_eventLimitSelectionToImageChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">
        ///   A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!Focused)
            {
                Focus();
            }
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">
        ///   A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
            {
                ProcessPanning(e);
                ProcessSelection(e);
            }
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">
        ///   A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            bool doNotProcessClick;

            base.OnMouseUp(e);

            doNotProcessClick = IsPanning || IsSelecting;

            if (IsPanning)
            {
                IsPanning = false;
            }

            if (IsSelecting)
            {
                EndDrag();
            }
            WasDragCancelled = false;

            if (!doNotProcessClick && AllowZoom && AllowClickZoom && !IsPanning && SizeMode == ImageBoxSizeMode.Normal)
            {
                if (e.Button == MouseButtons.Left && ModifierKeys == Keys.None)
                {
                    ProcessMouseZoom(true, e.Location);
                }
                else if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left && ModifierKeys != Keys.None)
                {
                    ProcessMouseZoom(false, e.Location);
                }
            }
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.MouseWheel" /> event.
        /// </summary>
        /// <param name="e">
        ///   A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (AllowZoom && SizeMode == ImageBoxSizeMode.Normal)
            {
                int spins;

                // The MouseWheel event can contain multiple "spins" of the wheel so we need to adjust accordingly
                spins = Math.Abs(e.Delta / SystemInformation.MouseWheelScrollDelta);

                // TODO: Really should update the source method to handle multiple increments rather than calling it multiple times
                for (int i = 0; i < spins; i++)
                {
                    ProcessMouseZoom(e.Delta > 0, e.Location);
                }
            }
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.PaddingChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            AdjustLayout();
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">
        ///   A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (AllowPainting)
            {
                // draw the background
                DrawBackground(e);

                // draw the image
                if (!ViewSize.IsEmpty)
                {
                    DrawImageBorder(e.Graphics);
                }
                if (VirtualMode)
                {
                    OnVirtualDraw(e);
                }
                else if (Image != null)
                {
                    DrawImage(e.Graphics);
                }

                // draw the grid
                if (ShowPixelGrid && !VirtualMode)
                {
                    DrawPixelGrid(e.Graphics);
                }

                // draw the selection
                if (SelectionRegion != Rectangle.Empty)
                {
                    DrawSelection(e);
                }

                // text
                if (!string.IsNullOrEmpty(Text) && TextDisplayMode != ImageBoxGridDisplayMode.None)
                {
                    DrawText(e);
                }

                base.OnPaint(e);
            }
        }

        /// <summary>
        ///   Raises the <see cref="PanEnd" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnPanEnd(EventArgs e)
        {
            EventHandler? handler;

            handler = Events[_eventPanEnd] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="PanStart" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.ComponentModel.CancelEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnPanStart(CancelEventArgs e)
        {
            EventHandler? handler;

            handler = Events[_eventPanStart] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.ParentChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            AdjustLayout();
        }

        /// <summary>
        ///   Raises the <see cref="PixelGridColorChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnPixelGridColorChanged(EventArgs e)
        {
            EventHandler? handler;

            Invalidate();

            handler = Events[_eventPixelGridColorChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="PixelGridThresholdChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnPixelGridThresholdChanged(EventArgs e)
        {
            EventHandler? handler;

            handler = Events[_eventPixelGridThresholdChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">
        ///   An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnResize(EventArgs e)
        {
            AdjustLayout();

            base.OnResize(e);
        }

        /// <summary>
        /// Raises the <see cref="ScaleTextChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnScaleTextChanged(EventArgs e)
        {
            EventHandler? handler;

            Invalidate();

            handler = Events[_eventScaleTextChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.ScrollableControl.Scroll" /> event.
        /// </summary>
        /// <param name="se">
        ///   A <see cref="T:System.Windows.Forms.ScrollEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnScroll(ScrollEventArgs se)
        {
            Invalidate();

            base.OnScroll(se);
        }

        /// <summary>
        ///   Raises the <see cref="Selected" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnSelected(EventArgs e)
        {
            EventHandler<EventArgs>? handler;

            switch (SelectionMode)
            {
                case ImageBoxSelectionMode.Zoom:
                    if (SelectionRegion.Width > SelectionDeadZone && SelectionRegion.Height > SelectionDeadZone)
                    {
                        ZoomToRegion(SelectionRegion);
                        SelectNone();
                    }
                    break;
            }

            handler = Events[_eventSelected] as EventHandler<EventArgs>;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="Selecting" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnSelecting(ImageBoxExtendedCancelEventArgs e)
        {
            EventHandler<ImageBoxExtendedCancelEventArgs>? handler;

            handler = Events[_eventSelecting] as EventHandler<ImageBoxExtendedCancelEventArgs>;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="SelectionColorChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnSelectionColorChanged(EventArgs e)
        {
            EventHandler? handler;

            handler = Events[_eventSelectionColorChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="SelectionModeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnSelectionModeChanged(EventArgs e)
        {
            EventHandler? handler;

            handler = Events[_eventSelectionModeChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="SelectionRegionChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnSelectionRegionChanged(EventArgs e)
        {
            EventHandler? handler;

            Invalidate();

            handler = Events[_eventSelectionRegionChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="ShortcutsEnabledChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnShortcutsEnabledChanged(EventArgs e)
        {
            EventHandler? handler;

            handler = Events[_eventShortcutsEnabledChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="ShowPixelGridChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnShowPixelGridChanged(EventArgs e)
        {
            EventHandler? handler;

            Invalidate();

            handler = Events[_eventShowPixelGridChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="SizeModeChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnSizeModeChanged(EventArgs e)
        {
            EventHandler? handler;

            AdjustLayout();

            handler = Events[_eventSizeModeChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="SizeToFitChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnSizeToFitChanged(EventArgs e)
        {
            EventHandler? handler;

            AdjustLayout();

            handler = Events[_eventSizeToFitChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="TextAlignChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnTextAlignChanged(EventArgs e)
        {
            EventHandler? handler;

            Invalidate();

            handler = Events[_eventTextAlignChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="TextBackColorChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnTextBackColorChanged(EventArgs e)
        {
            EventHandler? handler;

            Invalidate();

            handler = Events[_eventTextBackColorChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="TextDisplayModeChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnTextDisplayModeChanged(EventArgs e)
        {
            EventHandler? handler;

            Invalidate();

            handler = Events[_eventTextDisplayModeChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="TextPaddingChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnTextPaddingChanged(EventArgs e)
        {
            EventHandler? handler;

            handler = Events[_eventTextPaddingChanged] as EventHandler;

            Invalidate();

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="VirtualDraw" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="PaintEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnVirtualDraw(PaintEventArgs e)
        {
            PaintEventHandler? handler;

            handler = Events[_eventVirtualDraw] as PaintEventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="VirtualModeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnVirtualModeChanged(EventArgs e)
        {
            EventHandler? handler;

            AdjustLayout();

            handler = Events[_eventVirtualModeChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="VirtualSizeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnVirtualSizeChanged(EventArgs e)
        {
            EventHandler? handler;

            AdjustLayout();

            handler = Events[_eventVirtualSizeChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="ZoomChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnZoomChanged(EventArgs e)
        {
            EventHandler? handler;

            AdjustLayout();

            handler = Events[_eventZoomChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="Zoomed" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnZoomed(ImageBoxExtendedZoomEventArgs e)
        {
            EventHandler<ImageBoxExtendedZoomEventArgs>? handler;

            handler = Events[_eventZoomed] as EventHandler<ImageBoxExtendedZoomEventArgs>;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="ZoomLevelsChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnZoomLevelsChanged(EventArgs e)
        {
            EventHandler? handler;

            handler = Events[_eventZoomLevelsChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        ///   Processes shortcut keys for zooming and selection
        /// </summary>
        /// <param name="e">
        ///   The <see cref="KeyEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void ProcessImageShortcuts(KeyEventArgs e)
        {
            Point currentPixel;
            int currentZoom;
            Point relativePoint;

            relativePoint = CenterPoint;
            currentPixel = PointToImage(relativePoint);
            currentZoom = Zoom;

            switch (e.KeyCode)
            {
                case Keys.Home:
                    if (AllowZoom)
                    {
                        PerformActualSize(ImageBoxActionSources.User);
                    }
                    break;

                case Keys.PageDown:
                case Keys.Oemplus:
                    if (AllowZoom)
                    {
                        PerformZoomIn(ImageBoxActionSources.User, true);
                    }
                    break;

                case Keys.PageUp:
                case Keys.OemMinus:
                    if (AllowZoom)
                    {
                        PerformZoomOut(ImageBoxActionSources.User, true);
                    }
                    break;
            }

            if (Zoom != currentZoom)
            {
                ScrollTo(currentPixel, relativePoint);
            }
        }

        /// <summary>
        ///   Processes zooming with the mouse. Attempts to keep the pre-zoom image pixel under the mouse after the zoom has completed.
        /// </summary>
        /// <param name="isZoomIn">
        ///   if set to <c>true</c> zoom in, otherwise zoom out.
        /// </param>
        /// <param name="cursorPosition">The cursor position.</param>
        protected virtual void ProcessMouseZoom(bool isZoomIn, Point cursorPosition)
        {
            PerformZoom(isZoomIn ? ImageBoxZoomActions.ZoomIn : ImageBoxZoomActions.ZoomOut, ImageBoxActionSources.User, true, cursorPosition);
        }

        /// <summary>
        ///   Performs mouse based panning
        /// </summary>
        /// <param name="e">
        ///   The <see cref="MouseEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void ProcessPanning(MouseEventArgs e)
        {
            if (AutoPan && !ViewSize.IsEmpty && SelectionMode == ImageBoxSelectionMode.None)
            {
                if (!IsPanning && HScroll | VScroll)
                {
                    _startMousePosition = e.Location;
                    IsPanning = true;
                }

                if (IsPanning)
                {
                    int x;
                    int y;
                    Point position;

                    if (!InvertMouse)
                    {
                        x = -_startScrollPosition.X + (_startMousePosition.X - e.Location.X);
                        y = -_startScrollPosition.Y + (_startMousePosition.Y - e.Location.Y);
                    }
                    else
                    {
                        x = -(_startScrollPosition.X + (_startMousePosition.X - e.Location.X));
                        y = -(_startScrollPosition.Y + (_startMousePosition.Y - e.Location.Y));
                    }

                    position = new Point(x, y);

                    UpdateScrollPosition(position);
                }
            }
        }

        /// <summary>
        ///   Processes shortcut keys for scrolling
        /// </summary>
        /// <param name="e">
        ///   The <see cref="KeyEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void ProcessScrollingShortcuts(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    AdjustScroll(-(e.Modifiers == Keys.None ? HorizontalScroll.SmallChange : HorizontalScroll.LargeChange), 0);
                    break;

                case Keys.Right:
                    AdjustScroll(e.Modifiers == Keys.None ? HorizontalScroll.SmallChange : HorizontalScroll.LargeChange, 0);
                    break;

                case Keys.Up:
                    AdjustScroll(0, -(e.Modifiers == Keys.None ? VerticalScroll.SmallChange : VerticalScroll.LargeChange));
                    break;

                case Keys.Down:
                    AdjustScroll(0, e.Modifiers == Keys.None ? VerticalScroll.SmallChange : VerticalScroll.LargeChange);
                    break;
            }
        }

        /// <summary>
        ///   Performs mouse based region selection
        /// </summary>
        /// <param name="e">
        ///   The <see cref="MouseEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void ProcessSelection(MouseEventArgs e)
        {
            if (SelectionMode != ImageBoxSelectionMode.None && e.Button == MouseButtons.Left && !WasDragCancelled)
            {
                if (!IsSelecting)
                {
                    StartDrag(e);
                }

                if (IsSelecting)
                {
                    float x;
                    float y;
                    float w;
                    float h;
                    Point imageOffset;
                    RectangleF selection;

                    imageOffset = GetImageViewPort().Location;

                    if (e.X < _startMousePosition.X)
                    {
                        x = e.X;
                        w = _startMousePosition.X - e.X;
                    }
                    else
                    {
                        x = _startMousePosition.X;
                        w = e.X - _startMousePosition.X;
                    }

                    if (e.Y < _startMousePosition.Y)
                    {
                        y = e.Y;
                        h = _startMousePosition.Y - e.Y;
                    }
                    else
                    {
                        y = _startMousePosition.Y;
                        h = e.Y - _startMousePosition.Y;
                    }

                    x = x - imageOffset.X - AutoScrollPosition.X;
                    y = y - imageOffset.Y - AutoScrollPosition.Y;

                    x = x / (float)ZoomFactor;
                    y = y / (float)ZoomFactor;
                    w = w / (float)ZoomFactor;
                    h = h / (float)ZoomFactor;

                    if (w != 0 && h != 0)
                    {
                        selection = new RectangleF(x, y, w, h);
                        if (LimitSelectionToImage)
                        {
                            selection = FitRectangle(selection);
                        }

                        SelectionRegion = selection;
                    }
                }
            }
        }

        /// <summary>
        /// Resets the <see cref="SizeMode"/> property whilsts retaining the original <see cref="Zoom"/>.
        /// </summary>
        protected void RestoreSizeMode()
        {
            if (SizeMode != ImageBoxSizeMode.Normal)
            {
                int previousZoom;

                previousZoom = Zoom;
                SizeMode = ImageBoxSizeMode.Normal;
                Zoom = previousZoom; // Stop the zoom getting reset to 100% before calculating the new zoom
            }
        }

        /// <summary>
        /// Initializes a selection or drag operation.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void StartDrag(MouseEventArgs e)
        {
            ImageBoxExtendedCancelEventArgs args;

            args = new ImageBoxExtendedCancelEventArgs(e.Location);

            OnSelecting(args);

            WasDragCancelled = args.Cancel;
            IsSelecting = !args.Cancel;
            if (IsSelecting)
            {
                SelectNone();

                _startMousePosition = e.Location;
            }
        }

        /// <summary>
        ///   Updates the scroll position.
        /// </summary>
        /// <param name="position">The position.</param>
        protected virtual void UpdateScrollPosition(Point position)
        {
            AutoScrollPosition = position;
            Invalidate();
            OnScroll(new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        /// <summary>
        /// Gets the size of the image.
        /// </summary>
        /// <remarks>If an error occurs, for example due to the image being disposed, an empty size is returned</remarks>
        /// <returns>Size.</returns>
        private Size GetImageSize()
        {
            Size result;

            // HACK: This whole thing stinks. Hey MS, how about an IsDisposed property for images?

            if (Image != null)
            {
                try
                {
                    result = Image.Size;
                }
                catch
                {
                    result = Size.Empty;
                }
            }
            else
            {
                result = Size.Empty;
            }

            return result;
        }

        /// <summary>
        /// Returns an appropriate zoom level based on the specified action, relative to the current zoom level.
        /// </summary>
        /// <param name="action">The action to determine the zoom level.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if an unsupported action is specified.</exception>
        private int GetZoomLevel(ImageBoxZoomActions action)
        {
            int result;

            switch (action)
            {
                case ImageBoxZoomActions.None:
                    result = Zoom;
                    break;
                case ImageBoxZoomActions.ZoomIn:
                    result = ZoomLevels.NextZoom(Zoom);
                    break;
                case ImageBoxZoomActions.ZoomOut:
                    result = ZoomLevels.PreviousZoom(Zoom);
                    break;
                case ImageBoxZoomActions.ActualSize:
                    result = 100;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action));
            }

            return result;
        }

        /// <summary>
        ///   Initializes the grid tile.
        /// </summary>
        private void InitializeGridTile()
        {
            _texture?.Dispose();
            _gridTile?.Dispose();

            if (GridDisplayMode != ImageBoxGridDisplayMode.None && GridCellSize != 0)
            {
                if (GridScale != ImageBoxGridScale.None)
                {
                    _gridTile = CreateGridTileImage(GridCellSize, GridColor, GridColorAlternate);
                    _texture = new TextureBrush(_gridTile);
                }
                else
                {
                    _texture = new SolidBrush(GridColor);
                }
            }

            Invalidate();
        }

        /// <summary>
        /// Called when the animation frame changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnFrameChangedHandler(object? sender, EventArgs eventArgs)
        {
            Invalidate();
        }

        /// <summary>
        /// Resets the zoom to 100%.
        /// </summary>
        /// <param name="source">The source that initiated the action.</param>
        private void PerformActualSize(ImageBoxActionSources source)
        {
            SizeMode = ImageBoxSizeMode.Normal;
            SetZoom(100, ImageBoxZoomActions.ActualSize | (Zoom < 100 ? ImageBoxZoomActions.ZoomIn : ImageBoxZoomActions.ZoomOut), source);
        }

        /// <summary>
        /// Performs a zoom action.
        /// </summary>
        /// <param name="action">The action to perform.</param>
        /// <param name="source">The source that initiated the action.</param>
        /// <param name="preservePosition"><c>true</c> if the current scrolling position should be preserved relative to the new zoom level, <c>false</c> to reset.</param>
        private void PerformZoom(ImageBoxZoomActions action, ImageBoxActionSources source, bool preservePosition)
        {
            PerformZoom(action, source, preservePosition, CenterPoint);
        }

        /// <summary>
        /// Performs a zoom action.
        /// </summary>
        /// <param name="action">The action to perform.</param>
        /// <param name="source">The source that initiated the action.</param>
        /// <param name="preservePosition"><c>true</c> if the current scrolling position should be preserved relative to the new zoom level, <c>false</c> to reset.</param>
        /// <param name="relativePoint">A <see cref="Point"/> describing the current center of the control.</param>
        private void PerformZoom(ImageBoxZoomActions action, ImageBoxActionSources source, bool preservePosition, Point relativePoint)
        {
            Point currentPixel;
            int currentZoom;
            int newZoom;

            currentPixel = PointToImage(relativePoint);
            currentZoom = Zoom;
            newZoom = GetZoomLevel(action);

            RestoreSizeMode();
            SetZoom(newZoom, action, source);

            if (preservePosition && Zoom != currentZoom)
            {
                ScrollTo(currentPixel, relativePoint);
            }
        }

        /// <summary>
        /// Zooms into the image
        /// </summary>
        /// <param name="source">The source that initiated the action.</param>
        /// <param name="preservePosition"><c>true</c> if the current scrolling position should be preserved relative to the new zoom level, <c>false</c> to reset.</param>
        private void PerformZoomIn(ImageBoxActionSources source, bool preservePosition)
        {
            PerformZoom(ImageBoxZoomActions.ZoomIn, source, preservePosition);
        }

        /// <summary>
        /// Zooms out of the image
        /// </summary>
        /// <param name="source">The source that initiated the action.</param>
        /// <param name="preservePosition"><c>true</c> if the current scrolling position should be preserved relative to the new zoom level, <c>false</c> to reset.</param>
        private void PerformZoomOut(ImageBoxActionSources source, bool preservePosition)
        {
            PerformZoom(ImageBoxZoomActions.ZoomOut, source, preservePosition);
        }

        /// <summary>
        /// Updates the current zoom.
        /// </summary>
        /// <param name="value">The new zoom value.</param>
        /// <param name="actions">The zoom actions that caused the value to be updated.</param>
        /// <param name="source">The source of the zoom operation.</param>
        private void SetZoom(int value, ImageBoxZoomActions actions, ImageBoxActionSources source)
        {
            int previousZoom;

            previousZoom = Zoom;

            if (value < MinZoom)
            {
                value = MinZoom;
            }
            else if (value > MaxZoom)
            {
                value = MaxZoom;
            }

            if (_zoom != value)
            {
                _zoom = value;

                OnZoomChanged(EventArgs.Empty);

                OnZoomed(new ImageBoxExtendedZoomEventArgs(actions, source, previousZoom, Zoom));
            }
        }

        #endregion
    }
}