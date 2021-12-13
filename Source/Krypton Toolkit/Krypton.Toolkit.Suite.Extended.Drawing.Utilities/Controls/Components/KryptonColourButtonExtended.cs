#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    [ToolboxItem(true), ToolboxBitmap(typeof(KryptonColourButtonExtended), "ToolboxBitmaps.KryptonColourButtonExtended.bmp"), DefaultEvent("SelectedColourChanged"), DefaultProperty("SelectedColour"), Designer(typeof(KryptonColourButtonExtendedDesigner)), DesignerCategory("code"), Description("Raises an event when the user clicks it."), ClassInterface(ClassInterfaceType.AutoDispatch), ComVisible(true)]
    public partial class KryptonColourButtonExtended : VisualSimpleBase, IButtonControl, IContentValues
    {
        #region Fields
        private readonly ViewDrawButtonExtended _drawButton;
        private ButtonStyle _style;
        private readonly ButtonController _buttonController;
        private readonly PaletteRedirectDropDownButton _paletteDropDownButtonImages;
        private readonly PaletteTripleOverride _overrideFocus;
        private readonly PaletteTripleOverride _overrideNormal;
        private readonly PaletteTripleOverride _overrideTracking;
        private readonly PaletteTripleOverride _overridePressed;
        private KryptonCommand _command;
        private Rectangle _selectedRect;
        private Color _selectedColour;
        private Color _emptyBorderColour;
        private readonly List<Color> _recentColours;
        private Image _wasImage;
        private bool _wasEnabled;
        private bool _isDefault;
        private bool _useMnemonic;

        //private ViewDrawButtonExtended vdbe = new ViewDrawButtonExtended(null, null, null, null, null, null, VisualOrientation.Top, true);

        // Context menu items
        private readonly KryptonContextMenu _kryptonContextMenu;
        private readonly KryptonContextMenuSeparator _separatorTheme;
        private readonly KryptonContextMenuSeparator _separatorStandard;
        private readonly KryptonContextMenuSeparator _separatorRecent;
        private readonly KryptonContextMenuHeading _headingTheme;
        private readonly KryptonContextMenuHeading _headingStandard;
        private readonly KryptonContextMenuHeading _headingRecent;
        private readonly KryptonContextMenuColorColumns _coloursTheme;
        private readonly KryptonContextMenuColorColumns _coloursStandard;
        private readonly KryptonContextMenuColorColumns _coloursRecent;
        private readonly KryptonContextMenuSeparator _separatorNoColour;
        private readonly KryptonContextMenuItems _itemsNoColour;
        private readonly KryptonContextMenuItem _itemNoColour;
        private readonly KryptonContextMenuSeparator _separatorMoreColours;
        private readonly KryptonContextMenuItems _itemsMoreColours;
        private readonly KryptonContextMenuItem _itemMoreColours;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the drop down portion of the color button is pressed.
        /// </summary>
        [Category("Action")]
        [Description("Occurs when the drop down portion of the color button is pressed.")]
        public event EventHandler<ContextPositionMenuArgs> DropDown;

        /// <summary>
        /// Occurs when the value of the KryptonCommand property changes.
        /// </summary>
        [Category("Property Changed")]
        [Description("Occurs when the value of the KryptonCommand property changes.")]
        public event EventHandler KryptonCommandChanged;

        /// <summary>
        /// Occurs when the SelectedColor property changes value.
        /// </summary>
        [Category("Property Changed")]
        [Description("Occurs when the SelectedColour property changes value.")]
        public event EventHandler<ColorEventArgs> SelectedColourChanged;

        /// <summary>
        /// Occurs when the user is tracking over a color.
        /// </summary>
        [Category("Action")]
        [Description("Occurs when user is tracking over a colour.")]
        public event EventHandler<ColorEventArgs> TrackingColour;

        /// <summary>
        /// Occurs when the user selects the more colors option.
        /// </summary>
        [Category("Action")]
        [Description("Occurs when user selects the more colours option.")]
        public event CancelEventHandler MoreColours;
        #endregion

        #region Constructor
        public KryptonColourButtonExtended()
        {
            // We generate click events manually, suppress default
            // production of them by the base Control class
            SetStyle(ControlStyles.StandardClick |
                     ControlStyles.StandardDoubleClick, false);

            // Set default color button properties
            _style = ButtonStyle.Standalone;
            VisibleThemes = true;
            VisibleStandard = true;
            VisibleRecent = true;
            VisibleNoColour = true;
            VisibleMoreColours = true;
            AutoRecentColours = true;
            SchemeThemes = ColorScheme.OfficeThemes;
            SchemeStandard = ColorScheme.OfficeStandard;
            _selectedRect = new Rectangle(0, 12, 16, 4);
            _selectedColour = Color.Red;
            _emptyBorderColour = Color.DarkGray;
            DialogResult = DialogResult.None;
            _useMnemonic = true;
            MaxRecentColours = 10;
            _recentColours = new List<Color>();

            // Create the context menu items
            _kryptonContextMenu = new KryptonContextMenu();
            _separatorTheme = new KryptonContextMenuSeparator();
            _headingTheme = new KryptonContextMenuHeading("Theme Colours");
            _coloursTheme = new KryptonContextMenuColorColumns(ColorScheme.OfficeThemes);
            _separatorStandard = new KryptonContextMenuSeparator();
            _headingStandard = new KryptonContextMenuHeading("Standard Colours");
            _coloursStandard = new KryptonContextMenuColorColumns(ColorScheme.OfficeStandard);
            _separatorRecent = new KryptonContextMenuSeparator();
            _headingRecent = new KryptonContextMenuHeading("Recent Colours");
            _coloursRecent = new KryptonContextMenuColorColumns(ColorScheme.None);
            _separatorNoColour = new KryptonContextMenuSeparator();
            _itemNoColour = new KryptonContextMenuItem("&No Colour", Properties.Resources.ButtonNoColour, OnClickNoColour);
            _itemsNoColour = new KryptonContextMenuItems();
            _itemsNoColour.Items.Add(_itemNoColour);
            _separatorMoreColours = new KryptonContextMenuSeparator();
            _itemMoreColours = new KryptonContextMenuItem("&More Colours...", OnClickMoreColours);
            _itemsMoreColours = new KryptonContextMenuItems();
            _itemsMoreColours.Items.Add(_itemMoreColours);
            _kryptonContextMenu.Items.AddRange(new KryptonContextMenuItemBase[] { _separatorTheme, _headingTheme, _coloursTheme,
                                                                                  _separatorStandard, _headingStandard, _coloursStandard,
                                                                                  _separatorRecent, _headingRecent, _coloursRecent,
                                                                                  _separatorNoColour, _itemsNoColour,
                                                                                  _separatorMoreColours, _itemsMoreColours});

            // Create content storage
            Values = CreateButtonValues(NeedPaintDelegate);
            Values.TextChanged += OnButtonTextChanged;
            Images = new DropDownButtonImages(NeedPaintDelegate);

            // Image need an extra redirector to check the local images first
            _paletteDropDownButtonImages = new PaletteRedirectDropDownButton(Redirector, Images);

            // Create the palette storage
            Strings = new PaletteColorButtonStrings();
            StateCommon = new PaletteTripleRedirect(Redirector, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone, NeedPaintDelegate);
            StateDisabled = new PaletteTriple(StateCommon, NeedPaintDelegate);
            StateNormal = new PaletteTriple(StateCommon, NeedPaintDelegate);
            StateTracking = new PaletteTriple(StateCommon, NeedPaintDelegate);
            StatePressed = new PaletteTriple(StateCommon, NeedPaintDelegate);
            OverrideDefault = new PaletteTripleRedirect(Redirector, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone, NeedPaintDelegate);
            OverrideFocus = new PaletteTripleRedirect(Redirector, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone, NeedPaintDelegate);

            // Create the override handling classes
            _overrideFocus = new PaletteTripleOverride(OverrideFocus, StateNormal, PaletteState.FocusOverride);
            _overrideNormal = new PaletteTripleOverride(OverrideDefault, _overrideFocus, PaletteState.NormalDefaultOverride);
            _overrideTracking = new PaletteTripleOverride(OverrideFocus, StateTracking, PaletteState.FocusOverride);
            _overridePressed = new PaletteTripleOverride(OverrideFocus, StatePressed, PaletteState.FocusOverride);

            // Create the view color button instance
            _drawButton = new ViewDrawButtonExtended(StateDisabled,
                                             _overrideNormal,
                                             _overrideTracking,
                                             _overridePressed,
                                             new PaletteMetricRedirect(Redirector),
                                             this,
                                             VisualOrientation.Top,
                                             UseMnemonic)
            {

                // Set default color button state
                DropDown = true,
                Splitter = true,
                TestForFocusCues = true,
                DropDownPalette = _paletteDropDownButtonImages
            };

            // Create a color button controller to handle button style behaviour
            _buttonController = new ButtonController(_drawButton, NeedPaintDelegate)
            {
                BecomesFixed = true
            };

            // Assign the controller to the view element to treat as a button
            _drawButton.MouseController = _buttonController;
            _drawButton.KeyController = _buttonController;
            _drawButton.SourceController = _buttonController;

            // Need to know when user clicks the button view or mouse selects it
            _buttonController.Click += OnButtonClick;
            _buttonController.MouseSelect += OnButtonSelect;

            // Create the view manager instance
            ViewManager = new ViewManager(this, _drawButton);
        }
        #endregion

        #region Public
        [Browsable(true), Localizable(true), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), RefreshProperties(RefreshProperties.All)]
        public override bool AutoSize { get => base.AutoSize; set => base.AutoSize = value; }

        [Browsable(false), Localizable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Padding { get => base.Padding; set => base.Padding = value; }

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public override string Text { get => Values.Text; set => Values.Text = value; }

        private bool ShouldSerializeText()
        {
            // Never serialize, let the color button values serialize instead
            return false;
        }

        public override void ResetText()
        {
            Values.ResetText();
        }

        /// <summary>
        /// Gets or sets the ContextMenuStrip associated with this control.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ContextMenuStrip ContextMenuStrip
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Gets and sets the KryptonContextMenu to show when right clicked.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override KryptonContextMenu KryptonContextMenu
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Gets and sets the maximum number of recent colors to store and display.
        /// </summary>
        [Category("Behavior")]
        [Description("Determine the maximum number of recent colors to store and display.")]
        [DefaultValue(10)]
        public int MaxRecentColours { get; set; }

        /// <summary>
        /// Gets and sets the visible state of the themes color set.
        /// </summary>
        [Category("Behavior")]
        [Description("Determine the visible state of the themes color set.")]
        [DefaultValue(true)]
        public bool VisibleThemes { get; set; }

        /// <summary>
        /// Gets and sets the visible state of the standard color set.
        /// </summary>
        [Category("Behavior")]
        [Description("Determine the visible state of the standard color set.")]
        [DefaultValue(true)]
        public bool VisibleStandard { get; set; }

        /// <summary>
        /// Gets and sets the visible state of the recent color set.
        /// </summary>
        [Category("Behavior")]
        [Description("Determine the visible state of the recent color set.")]
        [DefaultValue(true)]
        public bool VisibleRecent { get; set; }

        /// <summary>
        /// Gets and sets the visible state of the no color menu item.
        /// </summary>
        [Category("Behavior")]
        [Description("Determine if the 'No Colour' menu item is used.")]
        [DefaultValue(true)]
        public bool VisibleNoColour { get; set; }

        /// <summary>
        /// Gets and sets the visible state of the more colors menu item.
        /// </summary>
        [Category("Behavior")]
        [Description("Determine if the 'More Colours...' menu item is used.")]
        [DefaultValue(true)]
        public bool VisibleMoreColours { get; set; }

        /// <summary>
        /// Gets and sets if the recent colors should be automatically updated.
        /// </summary>
        [Category("Behavior")]
        [Description("Should recent colors be automatically updated.")]
        [DefaultValue(true)]
        public bool AutoRecentColours { get; set; }

        /// <summary>
        /// Gets and sets the color scheme for the themes color set.
        /// </summary>
        [Category("Behavior")]
        [Description("Color scheme to use for the themes color set.")]
        [DefaultValue(typeof(ColorScheme), "OfficeThemes")]
        public ColorScheme SchemeThemes { get; set; }

        /// <summary>
        /// Gets and sets the color scheme for the standard color set.
        /// </summary>
        [Category("Behavior")]
        [Description("Color scheme to use for the standard color set.")]
        [DefaultValue(typeof(ColorScheme), "OfficeStandard")]
        public ColorScheme SchemeStandard { get; set; }

        /// <summary>
        /// Gets and sets the selected color.
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [Description("Selected color.")]
        [DefaultValue(typeof(Color), "Red")]
        public Color SelectedColour
        {
            get => _selectedColour;

            set
            {
                if (value != _selectedColour)
                {
                    _selectedColour = value;
                    Values.SelectedColour = value;
                    UpdateRecentColours(_selectedColour);
                    OnSelectedColourChanged(_selectedColour);
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets and sets the selected color block when selected color is empty.
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [Description("Border color of selected block when selected color is empty.")]
        [DefaultValue(typeof(Color), "DarkGray")]
        public Color EmptyBorderColour
        {
            get => _emptyBorderColour;

            set
            {
                if (value != _emptyBorderColour)
                {
                    _emptyBorderColour = value;
                    Values.EmptyBorderColour = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets and sets the selected color drawing rectangle.
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [Description("Selected color drawing rectangle.")]
        [DefaultValue(typeof(Rectangle), "0,12,16,4")]
        public Rectangle SelectedRect
        {
            get => _selectedRect;

            set
            {
                _selectedRect = value;
                Values.SelectedRect = value;
                PerformNeedPaint(true);
            }
        }

        /// <summary>
        /// Gets and sets the visual orientation of the control.
        /// </summary>
        [Category("Visuals")]
        [Description("Visual orientation of the control.")]
        [DefaultValue(typeof(VisualOrientation), "Top")]
        public virtual VisualOrientation ButtonOrientation
        {
            get => _drawButton.Orientation;

            set
            {
                if (_drawButton.Orientation != value)
                {
                    _drawButton.Orientation = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets and sets the position of the drop arrow within the color button.
        /// </summary>
        [Category("Visuals")]
        [Description("Position of the drop arrow within the color button.")]
        [DefaultValue(typeof(VisualOrientation), "Right")]
        public virtual VisualOrientation DropDownPosition
        {
            get => _drawButton.DropDownPosition;

            set
            {
                if (_drawButton.DropDownPosition != value)
                {
                    _drawButton.DropDownPosition = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets and sets the orientation of the drop arrow within the color button.
        /// </summary>
        [Category("Visuals")]
        [Description("Orientation of the drop arrow within the color button.")]
        [DefaultValue(typeof(VisualOrientation), "Bottom")]
        public virtual VisualOrientation DropDownOrientation
        {
            get
            {
                switch (_drawButton.DropDownOrientation)
                {
                    default:
                    case VisualOrientation.Top:
                        return VisualOrientation.Bottom;
                    case VisualOrientation.Bottom:
                        return VisualOrientation.Top;
                    case VisualOrientation.Left:
                        return VisualOrientation.Right;
                    case VisualOrientation.Right:
                        return VisualOrientation.Left;
                }
            }

            set
            {
                VisualOrientation converted;
                switch (value)
                {
                    default:
                    case VisualOrientation.Bottom:
                        converted = VisualOrientation.Top;
                        break;
                    case VisualOrientation.Top:
                        converted = VisualOrientation.Bottom;
                        break;
                    case VisualOrientation.Right:
                        converted = VisualOrientation.Left;
                        break;
                    case VisualOrientation.Left:
                        converted = VisualOrientation.Right;
                        break;
                }

                if (_drawButton.DropDownOrientation != converted)
                {
                    _drawButton.DropDownOrientation = converted;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets and sets if the color button works as a splitter or as a drop down.
        /// </summary>
        [Category("Visuals")]
        [Description("Determine if color button acts as a splitter or just a drop down.")]
        [DefaultValue(true)]
        public virtual bool Splitter
        {
            get => _drawButton.Splitter;

            set
            {
                if (_drawButton.Splitter != value)
                {
                    _drawButton.Splitter = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets and sets the color button style.
        /// </summary>
        [Category("Visuals")]
        [Description("Color button style.")]
        public ButtonStyle ButtonStyle
        {
            get => _style;

            set
            {
                if (_style != value)
                {
                    _style = value;
                    SetStyles(_style);
                    PerformNeedPaint(true);
                }
            }
        }

        private bool ShouldSerializeButtonStyle()
        {
            return (ButtonStyle != ButtonStyle.Standalone);
        }

        private void ResetButtonStyle()
        {
            ButtonStyle = ButtonStyle.Standalone;
        }

        /// <summary>
        /// Gets access to the color button content.
        /// </summary>
        [Category("Visuals")]
        [Description("Color button values")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColourButtonValues Values { get; }

        private bool ShouldSerializeValues()
        {
            return !Values.IsDefault;
        }

        /// <summary>
        /// Gets access to the image value overrides.
        /// </summary>
        [Category("Visuals")]
        [Description("Image value overrides.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DropDownButtonImages Images { get; }

        private bool ShouldSerializeImages()
        {
            return !Images.IsDefault;
        }

        /// <summary>
        /// Gets access to the context menu display strings.
        /// </summary>
        [Category("Visuals")]
        [Description("Context menu display strings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteColorButtonStrings Strings { get; }

        /// <summary>
        /// Gets access to the common color button appearance that other states can override.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining common color button appearance that other states can override.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTripleRedirect StateCommon { get; }

        private bool ShouldSerializeStateCommon()
        {
            return !StateCommon.IsDefault;
        }

        /// <summary>
        /// Gets access to the disabled color button appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining disabled color button appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTriple StateDisabled { get; }

        private bool ShouldSerializeStateDisabled()
        {
            return !StateDisabled.IsDefault;
        }

        /// <summary>
        /// Gets access to the normal color button appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining normal color button appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTriple StateNormal { get; }

        private bool ShouldSerializeStateNormal()
        {
            return !StateNormal.IsDefault;
        }

        /// <summary>
        /// Gets access to the hot tracking color button appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining hot tracking color button appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTriple StateTracking { get; }

        private bool ShouldSerializeStateTracking()
        {
            return !StateTracking.IsDefault;
        }

        /// <summary>
        /// Gets access to the pressed color button appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining pressed color button appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTriple StatePressed { get; }

        private bool ShouldSerializeStatePressed()
        {
            return !StatePressed.IsDefault;
        }

        /// <summary>
        /// Gets access to the normal color button appearance when default.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining normal color button appearance when default.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTripleRedirect OverrideDefault { get; }

        private bool ShouldSerializeOverrideDefault()
        {
            return !OverrideDefault.IsDefault;
        }

        /// <summary>
        /// Gets access to the color button appearance when it has focus.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining color button appearance when it has focus.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTripleRedirect OverrideFocus { get; }

        private bool ShouldSerializeOverrideFocus()
        {
            return !OverrideFocus.IsDefault;
        }

        /// <summary>
        /// Gets or sets the value returned to the parent form when the color button is clicked.
        /// </summary>
        [Category("Behavior")]
        [Description("The dialog-box result produced in a modal form by clicking the color button.")]
        [DefaultValue(typeof(DialogResult), "None")]
        public DialogResult DialogResult { get; set; }

        /// <summary>
        /// Gets and sets the associated KryptonCommand.
        /// </summary>
        [Category("Behavior")]
        [Description("Command associated with the color button.")]
        [DefaultValue(null)]
        public virtual KryptonCommand KryptonCommand
        {
            get => _command;

            set
            {
                if (_command != value)
                {
                    if (_command != null)
                    {
                        _command.PropertyChanged -= OnCommandPropertyChanged;
                    }
                    else
                    {
                        _wasEnabled = Enabled;
                        _wasImage = Values.Image;
                    }

                    _command = value;
                    OnKryptonCommandChanged(EventArgs.Empty);

                    if (_command != null)
                    {
                        _command.PropertyChanged += OnCommandPropertyChanged;
                    }
                    else
                    {
                        Enabled = _wasEnabled;
                        Values.Image = _wasImage;
                    }
                }
            }
        }

        /// <summary>
        /// Notifies a control that it is the default color button so that its appearance and behavior is adjusted accordingly. 
        /// </summary>
        /// <param name="value">true if the control should behave as a default color button; otherwise false.</param>
        public void NotifyDefault(bool value)
        {
            if (!ViewDrawButtonExtended.IsFixed && (_isDefault != value))
            {
                // Remember new default status
                _isDefault = value;

                // Decide if the default overrides should be applied
                _overrideNormal.Apply = value;

                // Change in deault state requires a layout and repaint
                base.PerformNeedPaint(true);
            }
        }

        /// <summary>
        /// Generates a Click event for the control.
        /// </summary>
        public void PerformClick()
        {
            if (CanSelect)
            {
                OnClick(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Generates a DropDown event for the control.
        /// </summary>
        public void PerformDropDown()
        {
            if (CanSelect)
            {
                ShowDropDown();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether an ampersand is included in the text of the control. 
        /// </summary>
        [Category("Appearance")]
        [Description("When true the first character after an ampersand will be used as a mnemonic.")]
        [DefaultValue(true)]
        public bool UseMnemonic
        {
            get => _useMnemonic;

            set
            {
                if (_useMnemonic != value)
                {
                    _useMnemonic = value;
                    _drawButton.UseMnemonic = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Fix the control to a particular palette state.
        /// </summary>
        /// <param name="state">Palette state to fix.</param>
        public virtual void SetFixedState(PaletteState state)
        {
            if (state == PaletteState.NormalDefaultOverride)
            {
                // Setup the overrides correctly to match state
                _overrideFocus.Apply = true;
                _overrideNormal.Apply = true;

                // Must pass a proper drawing state to the view
                state = PaletteState.Normal;
            }

            // Request fixed state from the view
            _drawButton.FixedState = state;
        }

        /// <summary>
        /// Determins the IME status of the object when selected.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get => base.ImeMode;
            set => base.ImeMode = value;
        }
        #endregion

        #region IContentValues
        /// <summary>
        /// Gets the content short text.
        /// </summary>
        /// <returns>String value.</returns>
        public string GetShortText() => KryptonCommand?.Text ?? Values.GetShortText();

        /// <summary>
        /// Gets the content long text.
        /// </summary>
        /// <returns>String value.</returns>
        public string GetLongText() => KryptonCommand?.ExtraText ?? Values.GetLongText();

        /// <summary>
        /// Gets the content image.
        /// </summary>
        /// <param name="state">The state for which the image is needed.</param>
        /// <returns>Image value.</returns>
        public Image GetImage(PaletteState state) => Values.GetImage(state);

        /// <summary>
        /// Gets the image color that should be transparent.
        /// </summary>
        /// <param name="state">The state for which the image is needed.</param>
        /// <returns>Color value.</returns>
        public Color GetImageTransparentColor(PaletteState state) =>
            KryptonCommand?.ImageTransparentColor ?? Values.GetImageTransparentColor(state);

        #endregion

        #region Protected Overrides
        protected override Size DefaultSize => new Size(90, 25);

        protected override ImeMode DefaultImeMode => ImeMode.Disable;

        protected override void OnEnabledChanged(EventArgs e)
        {
            _drawButton.Enabled = Enabled;

            PerformNeedPaint(true);

            base.OnEnabledChanged(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            //ViewDrawButton viewDrawButton = new ViewDrawButton();
            if (!ViewDrawButtonExtended.IsFixed)
            {
                // Apply the focus overrides
                _overrideFocus.Apply = true;
                _overrideTracking.Apply = true;
                _overridePressed.Apply = true;

                // Change in focus requires a repaint
                base.PerformNeedPaint(false);
            }

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (!ViewDrawButtonExtended.IsFixed)
            {
                // Apply the focus overrides
                _overrideFocus.Apply = false;
                _overrideTracking.Apply = false;
                _overridePressed.Apply = false;

                // Change in focus requires a repaint
                PerformNeedPaint(false);
            }

            base.OnLostFocus(e);
        }

        protected override void OnClick(EventArgs e)
        {
            // Find the form this color button is on
            Form owner = FindForm();

            // If we find a valid owner
            if (owner != null)
            {
                // Update owner with our dialog result setting
                owner.DialogResult = DialogResult;
            }

            // Let base class fire standard event
            base.OnClick(e);

            // If we have an attached command then execute it
            KryptonCommand?.PerformExecute();
        }

        protected override bool ProcessMnemonic(char charCode)
        {
            // Are we allowed to process mnemonics?
            if (UseMnemonic && CanProcessMnemonic())
            {
                // Does the color button primary text contain the mnemonic?
                if (IsMnemonic(charCode, Values.Text))
                {
                    if (!Splitter)
                    {
                        PerformDropDown();
                    }
                    else
                    {
                        PerformClick();
                    }

                    return true;
                }
            }

            // No match found, let base class do standard processing
            return base.ProcessMnemonic(charCode);
        }

        protected override void ContextMenuClosed()
        {
            _buttonController.RemoveFixed();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg != PI.WM_CONTEXTMENU)
            {
                base.WndProc(ref m);
            }
        }
        #endregion

        #region Protected Virtual
        protected virtual void OnDropDown(ContextPositionMenuArgs e) => DropDown?.Invoke(this, e);

        /// <summary>
        /// Raises the SelectedColorChanged event.
        /// </summary>
        /// <param name="selectedColour">New selected color.</param>
        protected virtual void OnSelectedColourChanged(Color selectedColour) => SelectedColourChanged?.Invoke(this, new ColorEventArgs(selectedColour));

        /// <summary>
        /// Raises the TrackingColor event.
        /// </summary>
        /// <param name="e">An ColorEventArgs that contains the event data.</param>
        protected virtual void OnTrackingColour(ColorEventArgs e) => TrackingColour?.Invoke(this, e);

        /// <summary>
        /// Raises the MoreColors event.
        /// </summary>
        /// <param name="e">An CancelEventArgs that contains the event data.</param>
        protected virtual void OnMoreColours(CancelEventArgs e) => MoreColours?.Invoke(this, e);

        /// <summary>
        /// Raises the KryptonCommandChanged event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected virtual void OnKryptonCommandChanged(EventArgs e)
        {
            KryptonCommandChanged?.Invoke(this, e);

            // Use the values from the new command
            if (KryptonCommand != null)
            {
                Enabled = KryptonCommand.Enabled;
                Values.Image = KryptonCommand.ImageSmall;
            }

            // Redraw to update the text/extratext/image properties
            PerformNeedPaint(true);
        }

        /// <summary>
        /// Handles a change in the property of an attached command.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">A PropertyChangedEventArgs that contains the event data.</param>
        protected virtual void OnCommandPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Enabled":
                    Enabled = KryptonCommand.Enabled;
                    break;
                case "ImageSmall":
                    Values.Image = KryptonCommand.ImageSmall;
                    PerformNeedPaint(true);
                    break;
                case "Text":
                case "ExtraText":
                case "ImageTransparentColor":
                    PerformNeedPaint(true);
                    break;
            }
        }

        /// <summary>
        /// Update the state objects to reflect the new color button style.
        /// </summary>
        /// <param name="buttonStyle">New color button style.</param>
        protected virtual void SetStyles(ButtonStyle buttonStyle)
        {
            StateCommon.SetStyles(buttonStyle);
            OverrideDefault.SetStyles(buttonStyle);
            OverrideFocus.SetStyles(buttonStyle);
        }

        /// <summary>
        /// Creates a values storage object appropriate for control.
        /// </summary>
        /// <returns>Set of color button values.</returns>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        protected virtual ColourButtonValues CreateButtonValues(NeedPaintHandler needPaint) => new ColourButtonValues(needPaint);

        /// <summary>
        /// Gets access to the view element for the color button.
        /// </summary>
        protected virtual ViewDrawButtonExtended ViewDrawButtonExtended => _drawButton;
        #endregion

        #region Implementation
        private void OnButtonTextChanged(object sender, EventArgs e) => OnTextChanged(EventArgs.Empty);

        private void OnButtonClick(object sender, MouseEventArgs e)
        {
            bool showingContextMenu = false;

            // Do we need to show a drop down menu?
            if (!Splitter || (Splitter && _drawButton.SplitRectangle.Contains(e.Location)))
            {
                showingContextMenu = ShowDropDown();
            }
            else
            {
                // Raise the standard click event
                OnClick(EventArgs.Empty);

                // Raise event to indicate it was a mouse activated click
                OnMouseClick(e);
            }

            // If not showing a context menu then perform cleanup straight away
            if (!showingContextMenu)
            {
                ContextMenuClosed();
            }
        }

        private bool ShowDropDown()
        {
            bool showingContextMenu = false;

            // Update the context menu state
            UpdateContextMenu();

            // Update the krypton menu with this controls palette state
            if (_kryptonContextMenu != null)
            {
                if (PaletteMode != PaletteMode.Custom)
                {
                    _kryptonContextMenu.PaletteMode = PaletteMode;
                }
                else
                {
                    _kryptonContextMenu.Palette = Palette;
                }
            }

            // Package up the context menu and positioning values we will use later
            ContextPositionMenuArgs cpma = new ContextPositionMenuArgs(null,
                                                                       _kryptonContextMenu,
                                                                       GetPositionH(),
                                                                       GetPositionV());
            // Let use examine and later values
            OnDropDown(cpma);

            // If we still want to show a context menu
            if (!cpma.Cancel)
            {
                if (cpma.KryptonContextMenu != null)
                {
                    // Convert the client rect to screen coords
                    Rectangle screenRect = RectangleToScreen(ClientRectangle);
                    if (CommonHelper.ValidKryptonContextMenu(cpma.KryptonContextMenu))
                    {
                        // Modify the screen rect so that we have a pixel gap between color button and menu
                        switch (cpma.PositionV)
                        {
                            case KryptonContextMenuPositionV.Above:
                                screenRect.Y -= 1;
                                break;
                            case KryptonContextMenuPositionV.Below:
                                screenRect.Height += 1;
                                break;
                        }

                        switch (cpma.PositionH)
                        {
                            case KryptonContextMenuPositionH.Before:
                                screenRect.X -= 1;
                                break;
                            case KryptonContextMenuPositionH.After:
                                screenRect.Width += 1;
                                break;
                        }

                        // We are showing a drop down
                        showingContextMenu = true;

                        // Decide which separators are needed
                        DecideOnVisible(_separatorTheme, _coloursTheme);
                        DecideOnVisible(_separatorStandard, _coloursStandard);
                        DecideOnVisible(_separatorRecent, _coloursRecent);
                        DecideOnVisible(_separatorNoColour, _itemsNoColour);
                        DecideOnVisible(_separatorMoreColours, _itemsMoreColours);

                        // Monitor relevant events inside the context menu
                        HookContextMenuEvents(_kryptonContextMenu.Items, true);

                        // Show relative to the screen rectangle
                        cpma.KryptonContextMenu.Closed += OnKryptonContextMenuClosed;
                        cpma.KryptonContextMenu.Show(this, screenRect, cpma.PositionH, cpma.PositionV);
                    }
                }
            }

            return showingContextMenu;
        }

        private KryptonContextMenuPositionH GetPositionH()
        {
            switch (DropDownOrientation)
            {
                default:
                case VisualOrientation.Bottom:
                case VisualOrientation.Top:
                    return KryptonContextMenuPositionH.Left;
                case VisualOrientation.Left:
                    return KryptonContextMenuPositionH.Before;
                case VisualOrientation.Right:
                    return KryptonContextMenuPositionH.After;
            }
        }

        private KryptonContextMenuPositionV GetPositionV()
        {
            switch (DropDownOrientation)
            {
                default:
                case VisualOrientation.Bottom:
                    return KryptonContextMenuPositionV.Below;
                case VisualOrientation.Top:
                    return KryptonContextMenuPositionV.Above;
                case VisualOrientation.Left:
                case VisualOrientation.Right:
                    return KryptonContextMenuPositionV.Top;
            }
        }

        private void OnContextMenuClosed(object sender, EventArgs e) => ContextMenuClosed();

        private void OnKryptonContextMenuClosed(object sender, EventArgs e)
        {
            KryptonContextMenu kcm = (KryptonContextMenu)sender;
            kcm.Closed -= OnKryptonContextMenuClosed;
            ContextMenuClosed();

            // Unhook from item events
            HookContextMenuEvents(_kryptonContextMenu.Items, false);
        }

        void OnButtonSelect(object sender, MouseEventArgs e)
        {
            // Take the focus if allowed
            if (CanFocus)
            {
                Focus();
            }
        }

        private void HookContextMenuEvents(KryptonContextMenuCollection collection, bool hook)
        {
            // Search for items of interest
            foreach (KryptonContextMenuItemBase item in collection)
            {
                // Hook into color events
                if (item is KryptonContextMenuColorColumns columns)
                {
                    columns.SelectedColor = _selectedColour;

                    if (hook)
                    {
                        columns.TrackingColor += OnColumnsTrackingColor;
                        columns.SelectedColorChanged += OnColumnsSelectedColourChanged;
                    }
                    else
                    {
                        columns.TrackingColor -= OnColumnsTrackingColor;
                        columns.SelectedColorChanged -= OnColumnsSelectedColourChanged;
                    }
                }
            }
        }

        private void UpdateRecentColours(Color color)
        {
            // Do we need to update the recent colors collection?
            if (AutoRecentColours)
            {
                // We do not add to recent colors if it is inside another color columns 
                foreach (KryptonContextMenuItemBase item in _kryptonContextMenu.Items)
                {
                    // Only interested in the non-recent colors color columns
                    if ((item != _coloursRecent) && (item is KryptonContextMenuColorColumns colors))
                    {
                        // Cast to correct type

                        // We do not change the theme or standard entries if they are not to be used
                        if (((item == _coloursTheme) && !VisibleThemes) ||
                            ((item == _coloursStandard) && !VisibleStandard))
                        {
                            continue;
                        }

                        // If matching color found, do not add to recent colors
                        if (colors.ContainsColor(color))
                        {
                            return;
                        }
                    }
                }

                // If this color valid and so possible to become a recent color
                if ((color != null) && !color.Equals(Color.Empty))
                {
                    bool found = false;
                    foreach (Color recentColor in _recentColours)
                    {
                        if (recentColor.Equals(color))
                        {
                            found = true;
                            break;
                        }
                    }

                    // If the color is not already part of the recent colors
                    if (!found)
                    {
                        // Add to start of the list
                        _recentColours.Insert(0, color);

                        // Enforce the maximum number of recent colors
                        if (_recentColours.Count > MaxRecentColours)
                        {
                            _recentColours.RemoveRange(MaxRecentColours, _recentColours.Count - MaxRecentColours);
                        }
                    }
                }
            }
        }

        private void UpdateContextMenu()
        {
            // Update visible state based of properties
            _separatorTheme.Visible = _headingTheme.Visible = _coloursTheme.Visible = VisibleThemes;
            _separatorStandard.Visible = _headingStandard.Visible = _coloursStandard.Visible = VisibleStandard;
            _separatorRecent.Visible = _headingRecent.Visible = _coloursRecent.Visible = (VisibleRecent && (_recentColours.Count > 0));
            _itemsNoColour.Visible = VisibleNoColour;
            _itemsMoreColours.Visible = VisibleMoreColours;

            // Define the display strings
            _headingTheme.Text = Strings.ThemeColors;
            _headingStandard.Text = Strings.StandardColors;
            _headingRecent.Text = Strings.RecentColors;
            _itemNoColour.Text = Strings.NoColor;
            _itemMoreColours.Text = Strings.MoreColors;

            // Define the colors used in the first two color schemes
            _coloursTheme.ColorScheme = SchemeThemes;
            _coloursStandard.ColorScheme = SchemeStandard;

            // Define the recent colors
            if (_recentColours.Count == 0)
            {
                _coloursRecent.SetCustomColors(null);
            }
            else
            {
                // Create an array of color arrays
                Color[][] colors = new Color[_recentColours.Count][];

                // Each column is just a single color
                for (int i = 0; i < _recentColours.Count; i++)
                {
                    colors[i] = new Color[] { _recentColours[i] };
                }

                _coloursRecent.SetCustomColors(colors);
            }

            // Should the no color entry be checked?
            _itemNoColour.Checked = _selectedColour.Equals(Color.Empty);
        }

        private void DecideOnVisible(KryptonContextMenuItemBase visible, KryptonContextMenuItemBase target)
        {
            bool previous = false;

            // Only search if the target itself is visible
            if (target.Visible)
            {
                // Check all items before the target
                foreach (KryptonContextMenuItemBase item in _kryptonContextMenu.Items)
                {
                    // Finish when we reach the target
                    if (item == target)
                    {
                        break;
                    }

                    // We do not consider existing separators
                    if (!((item is KryptonContextMenuSeparator) ||
                          (item is KryptonContextMenuHeading)))
                    {
                        // If the previous item is visible, then make the parameter visible
                        if (item.Visible)
                        {
                            previous = true;
                            break;
                        }
                    }
                }
            }

            visible.Visible = previous;
        }

        private void OnColumnsTrackingColor(object sender, ColorEventArgs e) => OnTrackingColour(new ColorEventArgs(e.Color));

        private void OnColumnsSelectedColourChanged(object sender, ColorEventArgs e) => SelectedColour = e.Color;

        private void OnClickNoColour(object sender, EventArgs e) => SelectedColour = Color.Empty;

        private void OnClickMoreColours(object sender, EventArgs e)
        {
            // Give user a chance to cancel showing the standard more colors dialog
            CancelEventArgs cea = new CancelEventArgs();
            OnMoreColours(cea);

            // If not instructed to cancel then...
            if (!cea.Cancel)
            {
                // Use a standard color dialog for the selection of custom colors
                KryptonColourButtonCustomColourDialog cwd = new KryptonColourButtonCustomColourDialog
                {
                    Colour = SelectedColour
                };

                // Only if user selected a value do we want to use it
                if (cwd.ShowDialog() == DialogResult.OK)
                {
                    SelectedColour = cwd.Colour;
                }
            }
        }
        #endregion
    }
}