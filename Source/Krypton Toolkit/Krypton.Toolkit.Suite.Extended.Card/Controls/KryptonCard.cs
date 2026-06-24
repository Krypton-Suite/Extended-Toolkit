#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Card;

/// <summary>
/// Material-inspired card container for grouping related content with optional header, image, content, actions, and footer sections.
/// </summary>
[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonCard), "ToolboxBitmaps.KryptonCard.bmp")]
[DefaultEvent(nameof(CardClick))]
[DefaultProperty(nameof(Title))]
[Designer(typeof(KryptonCardDesigner))]
[DesignerCategory(@"code")]
[Description(@"Groups related content in a themed card with optional header, image, content, actions, and footer sections.")]
public class KryptonCard : UserControl
{
    private readonly KryptonCardChrome _surface;
    private readonly Panel _bodyPanel;
    private readonly Timer _animationTimer;
    private int _cornerRadius = CardMetrics.DefaultCornerRadius;
    private int _elevation = CardMetrics.DefaultElevation;
    private int _restElevation = CardMetrics.DefaultElevation;
    private int _hoverElevation = CardMetrics.DefaultHoverElevation;
    private int _targetElevation;
    private bool _autoHideEmptySections = true;
    private bool _clickable;
    private bool _selected;
    private bool _animateElevationOnHover = true;
    private bool _enableHoverFeedback = true;
    private bool _enableRipple = true;
    private bool _useBlurredShadow = true;
    private bool _isHovered;
    private bool _expandable;
    private bool _expanded = true;
    private bool _animateExpandCollapse = true;
    private bool _expandOnHeaderClick = true;
    private bool _animatingExpandCollapse;
    private CardAppearance _appearance = CardAppearance.Elevated;
    private CardExpandDirection _expandDirection = CardExpandDirection.SlideDown;
    private string _title = string.Empty;
    private Point _rippleCenter;
    private int _rippleRadius;
    private int _rippleAlpha;
    private int _bodyExpandedHeight;
    private int _bodyCurrentHeight;
    private int _bodyTargetHeight;
    private int _expandedCardHeight;
    private int _collapsedCardHeight;

    /// <summary>
    /// Initializes a new instance of the <see cref="KryptonCard"/> class.
    /// </summary>
    public KryptonCard()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint
                  | ControlStyles.OptimizedDoubleBuffer
                  | ControlStyles.ResizeRedraw
                  | ControlStyles.UserPaint, true);

        MinimumSize = new Size(120, 80);
        Size = new Size(320, 240);
        BackColor = Color.Transparent;
        AccessibleRole = AccessibleRole.Grouping;

        Header = AttachSection(new KryptonCardHeader());
        TitleGroup = AttachSection(new KryptonCardTitleGroup());
        CardImage = AttachSection(new KryptonCardImage());
        Content = AttachSection(new KryptonCardContent());
        Actions = AttachSection(new KryptonCardActions());
        Footer = AttachSection(new KryptonCardFooter());

        _bodyPanel = new Panel
        {
            Dock = DockStyle.Top,
            Margin = Padding.Empty,
            Padding = Padding.Empty,
        };

        _surface = new KryptonCardChrome
        {
            Dock = DockStyle.Fill,
        };
        _surface.ApplyAppearance();
        _surface.Click += SurfaceOnClick;
        _surface.MouseEnter += SurfaceOnMouseEnter;
        _surface.MouseLeave += SurfaceOnMouseLeave;
        _surface.MouseDown += SurfaceOnMouseDown;
        Header.Click += HeaderOnClick;

        Controls.Add(_surface);

        _bodyPanel.Controls.Add(Content);
        _bodyPanel.Controls.Add(Footer);
        _bodyPanel.Controls.Add(Actions);
        _bodyPanel.Controls.Add(CardImage);
        _bodyPanel.Controls.Add(TitleGroup);

        _surface.Controls.Add(_bodyPanel);
        _surface.Controls.Add(Header);

        _animationTimer = new Timer { Interval = CardMetrics.AnimationIntervalMilliseconds };
        _animationTimer.Tick += AnimationTimerOnTick;

        ApplyAppearance();
        ApplyShadowPadding();
        UpdateSectionVisibility();
        UpdateAccessibility();
        _surface.UpdateRegion();
    }

    /// <summary>
    /// Occurs when the card surface is clicked and <see cref="Clickable"/> is enabled.
    /// </summary>
    [Category(@"Action")]
    [Description(@"Occurs when the card surface is clicked and Clickable is enabled.")]
    public event EventHandler? CardClick;

    /// <summary>
    /// Occurs when the <see cref="Selected"/> value changes.
    /// </summary>
    [Category(@"Property Changed")]
    [Description(@"Occurs when the Selected value changes.")]
    public event EventHandler? SelectedChanged;

    /// <summary>
    /// Occurs when the <see cref="Expanded"/> value changes.
    /// </summary>
    [Category(@"Property Changed")]
    [Description(@"Occurs when the Expanded value changes.")]
    public event EventHandler? ExpandedChanged;

    /// <summary>
    /// Occurs when an expand or collapse animation completes.
    /// </summary>
    [Category(@"Action")]
    [Description(@"Occurs when an expand or collapse animation completes.")]
    public event EventHandler? ExpandAnimationCompleted;

    /// <summary>
    /// Gets the header section.
    /// </summary>
    [Category(@"Card Sections")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public KryptonCardHeader Header { get; }

    /// <summary>
    /// Gets the title group section.
    /// </summary>
    [Category(@"Card Sections")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public KryptonCardTitleGroup TitleGroup { get; }

    /// <summary>
    /// Gets the full-width image section.
    /// </summary>
    [Category(@"Card Sections")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public KryptonCardImage CardImage { get; }

    /// <summary>
    /// Gets the primary content section.
    /// </summary>
    [Category(@"Card Sections")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public KryptonCardContent Content { get; }

    /// <summary>
    /// Gets the actions section.
    /// </summary>
    [Category(@"Card Sections")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public KryptonCardActions Actions { get; }

    /// <summary>
    /// Gets the footer section.
    /// </summary>
    [Category(@"Card Sections")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public KryptonCardFooter Footer { get; }

    /// <summary>
    /// Gets or sets the primary title used for accessibility and the header section.
    /// </summary>
    [Category(@"Appearance")]
    [DefaultValue("")]
    [Localizable(true)]
    public string Title
    {
        get => _title;
        set
        {
            _title = value ?? string.Empty;
            if (string.IsNullOrWhiteSpace(Header.Title))
            {
                Header.Title = _title;
            }

            UpdateAccessibility();
        }
    }

    /// <summary>
    /// Gets access to the card surface background palette.
    /// </summary>
    [Category(@"Visuals")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public PaletteBack CardBack => _surface.StateCommon;

    /// <summary>
    /// Gets or sets the visual appearance of the card.
    /// </summary>
    [Category(@"Appearance")]
    [DefaultValue(CardAppearance.Elevated)]
    public CardAppearance Appearance
    {
        get => _appearance;
        set
        {
            _appearance = value;
            ApplyAppearance();
        }
    }

    /// <summary>
    /// Gets or sets the corner radius applied to the card surface.
    /// </summary>
    [Category(@"Appearance")]
    [DefaultValue(CardMetrics.DefaultCornerRadius)]
    public int CornerRadius
    {
        get => _cornerRadius;
        set
        {
            _cornerRadius = Math.Max(0, value);
            _surface.CornerRadius = _cornerRadius;
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets the card elevation used to render a soft drop shadow.
    /// </summary>
    [Category(@"Appearance")]
    [DefaultValue(CardMetrics.DefaultElevation)]
    public int Elevation
    {
        get => _elevation;
        set
        {
            _restElevation = Math.Max(0, Math.Min(value, 24));
            ApplyCurrentElevation();
            ApplyShadowPadding();
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets the elevation used while the card is hovered.
    /// </summary>
    [Category(@"Appearance")]
    [DefaultValue(CardMetrics.DefaultHoverElevation)]
    public int HoverElevation
    {
        get => _hoverElevation;
        set => _hoverElevation = Math.Max(0, Math.Min(value, 24));
    }

    /// <summary>
    /// Gets or sets a value indicating whether hover uses blurred shadow rendering.
    /// </summary>
    [Category(@"Appearance")]
    [DefaultValue(true)]
    public bool UseBlurredShadow
    {
        get => _useBlurredShadow;
        set
        {
            _useBlurredShadow = value;
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether empty sections are hidden automatically.
    /// </summary>
    [Category(@"Behavior")]
    [DefaultValue(true)]
    public bool AutoHideEmptySections
    {
        get => _autoHideEmptySections;
        set
        {
            _autoHideEmptySections = value;
            UpdateSectionVisibility();
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the card raises <see cref="CardClick"/> when clicked.
    /// </summary>
    [Category(@"Behavior")]
    [DefaultValue(false)]
    public bool Clickable
    {
        get => _clickable;
        set
        {
            _clickable = value;
            UpdateInteractionState();
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the card is selected.
    /// </summary>
    [Category(@"Appearance")]
    [DefaultValue(false)]
    public bool Selected
    {
        get => _selected;
        set
        {
            if (_selected == value)
            {
                return;
            }

            _selected = value;
            _surface.Selected = value;
            SelectedChanged?.Invoke(this, EventArgs.Empty);
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether elevation animates on hover.
    /// </summary>
    [Category(@"Behavior")]
    [DefaultValue(true)]
    public bool AnimateElevationOnHover
    {
        get => _animateElevationOnHover;
        set => _animateElevationOnHover = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether hover feedback is enabled.
    /// </summary>
    [Category(@"Behavior")]
    [DefaultValue(true)]
    public bool EnableHoverFeedback
    {
        get => _enableHoverFeedback;
        set => _enableHoverFeedback = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether ripple feedback is shown on press.
    /// </summary>
    [Category(@"Behavior")]
    [DefaultValue(true)]
    public bool EnableRipple
    {
        get => _enableRipple;
        set => _enableRipple = value;
    }

    /// <summary>
    /// Gets or sets the accessible name used for assistive technologies.
    /// </summary>
    [Category(@"Accessibility")]
    [DefaultValue("")]
    [Localizable(true)]
    public string AccessibleCardName
    {
        get => AccessibleName ?? string.Empty;
        set
        {
            AccessibleName = value;
            UpdateAccessibility();
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the card body can expand and collapse.
    /// </summary>
    [Category(@"Behavior")]
    [DefaultValue(false)]
    public bool Expandable
    {
        get => _expandable;
        set
        {
            if (_expandable == value)
            {
                return;
            }

            _expandable = value;
            if (_expandable)
            {
                CacheExpandMetrics();
                _bodyCurrentHeight = _expanded ? _bodyExpandedHeight : CardMetrics.MinimumCollapsedBodyHeight;
                _bodyTargetHeight = _bodyCurrentHeight;
                ApplyExpandLayout();
            }
            else
            {
                _expanded = true;
                _bodyPanel.Visible = true;
                _bodyPanel.Height = _bodyExpandedHeight;
                Height = Math.Max(_expandedCardHeight, Height);
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the card body is expanded.
    /// </summary>
    [Category(@"Behavior")]
    [DefaultValue(true)]
    public bool Expanded
    {
        get => _expanded;
        set
        {
            if (!_expandable || _expanded == value)
            {
                return;
            }

            _expanded = value;
            BeginExpandCollapseAnimation();
            ExpandedChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Gets a value indicating whether the card is currently animating open or closed.
    /// </summary>
    [Browsable(false)]
    public bool IsExpandAnimating => _animatingExpandCollapse;

    /// <summary>
    /// Gets or sets a value indicating whether expand and collapse is animated.
    /// </summary>
    [Category(@"Behavior")]
    [DefaultValue(true)]
    public bool AnimateExpandCollapse
    {
        get => _animateExpandCollapse;
        set => _animateExpandCollapse = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether clicking the header toggles expansion.
    /// </summary>
    [Category(@"Behavior")]
    [DefaultValue(true)]
    public bool ExpandOnHeaderClick
    {
        get => _expandOnHeaderClick;
        set => _expandOnHeaderClick = value;
    }

    /// <summary>
    /// Gets or sets the slide direction used for expand and collapse animations.
    /// </summary>
    [Category(@"Behavior")]
    [DefaultValue(CardExpandDirection.SlideDown)]
    public CardExpandDirection ExpandDirection
    {
        get => _expandDirection;
        set => _expandDirection = value;
    }

    /// <summary>
    /// Expands the card body when <see cref="Expandable"/> is enabled.
    /// </summary>
    public void Expand()
    {
        if (_expandable)
        {
            Expanded = true;
        }
    }

    /// <summary>
    /// Collapses the card body when <see cref="Expandable"/> is enabled.
    /// </summary>
    public void Collapse()
    {
        if (_expandable)
        {
            Expanded = false;
        }
    }

    /// <summary>
    /// Toggles the expanded state when <see cref="Expandable"/> is enabled.
    /// </summary>
    public void ToggleExpanded()
    {
        if (_expandable)
        {
            Expanded = !Expanded;
        }
    }

    /// <summary>
    /// Updates section visibility according to <see cref="AutoHideEmptySections"/>.
    /// </summary>
    public void UpdateSectionVisibility()
    {
        if (!_autoHideEmptySections)
        {
            Header.Visible = true;
            TitleGroup.Visible = true;
            CardImage.Visible = true;
            Content.Visible = true;
            Actions.Visible = true;
            Footer.Visible = true;
            return;
        }

        Header.Visible = !Header.IsSectionEmpty();
        TitleGroup.Visible = !TitleGroup.IsSectionEmpty();
        CardImage.Visible = !CardImage.IsSectionEmpty();
        Content.Visible = !Content.IsSectionEmpty();
        Actions.Visible = !Actions.IsSectionEmpty();
        Footer.Visible = !Footer.IsSectionEmpty();

        if (_expandable)
        {
            CacheExpandMetrics();
            ApplyExpandLayout();
        }
    }

    /// <inheritdoc />
    protected override void OnLayout(LayoutEventArgs levent)
    {
        base.OnLayout(levent);

        if (_expandable && _bodyExpandedHeight <= 0)
        {
            CacheExpandMetrics();
            ApplyExpandLayout();
        }
    }

    /// <inheritdoc />
    protected override void OnRightToLeftChanged(EventArgs e)
    {
        base.OnRightToLeftChanged(e);
        ApplyRtlToSections();
    }

    /// <inheritdoc />
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        int drawElevation = Appearance == CardAppearance.Elevated ? _elevation : 0;
        if (drawElevation > 0)
        {
            CardRendering.DrawElevationShadow(
                e.Graphics,
                _surface.Bounds,
                _cornerRadius,
                drawElevation,
                CardRendering.ResolveShadowColor(this),
                _useBlurredShadow);
        }

        if (_enableRipple && _rippleAlpha > 0 && _rippleRadius > 0)
        {
            Point center = _surface.PointToClient(_rippleCenter);
            Color rippleColor = Color.FromArgb(_rippleAlpha, CardRendering.ResolveShadowColor(this));
            CardRendering.DrawRipple(e.Graphics, _surface.Bounds, center, _rippleRadius, rippleColor);
        }
    }

    /// <inheritdoc />
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        _surface.UpdateRegion();
    }

    /// <inheritdoc />
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _animationTimer.Tick -= AnimationTimerOnTick;
            _animationTimer.Dispose();
            _surface.Click -= SurfaceOnClick;
            _surface.MouseEnter -= SurfaceOnMouseEnter;
            _surface.MouseLeave -= SurfaceOnMouseLeave;
            _surface.MouseDown -= SurfaceOnMouseDown;
            Header.Click -= HeaderOnClick;
        }

        base.Dispose(disposing);
    }

    internal Control DesignContentPanel => Content;

    internal Control DesignActionsPanel => Actions.DesignPanel;

    internal Control DesignFooterPanel => Footer;

    private T AttachSection<T>(T section) where T : KryptonCardSection
    {
        section.OwnerCard = this;
        return section;
    }

    private void ApplyAppearance()
    {
        _surface.Appearance = _appearance;
        ApplyCurrentElevation();
        ApplyShadowPadding();
        Invalidate();
    }

    private void ApplyCurrentElevation()
    {
        if (_appearance != CardAppearance.Elevated)
        {
            _elevation = 0;
            _targetElevation = 0;
            return;
        }

        _targetElevation = _isHovered && _animateElevationOnHover ? _hoverElevation : _restElevation;
        _elevation = _targetElevation;
    }

    private void ApplyRtlToSections()
    {
        bool rtl = RightToLeft == RightToLeft.Yes;
        Header.RightToLeft = RightToLeft;
        TitleGroup.RightToLeft = RightToLeft;
        CardImage.RightToLeft = RightToLeft;
        Content.RightToLeft = RightToLeft;
        Actions.RightToLeft = RightToLeft;
        Footer.RightToLeft = RightToLeft;
        Actions.ApplyRtl(rtl);
    }

    private void UpdateInteractionState()
    {
        Cursor = _clickable ? Cursors.Hand : Cursors.Default;
        TabStop = _clickable;
    }

    private void UpdateAccessibility()
    {
        if (string.IsNullOrWhiteSpace(AccessibleName))
        {
            AccessibleName = string.IsNullOrWhiteSpace(_title) ? Name : _title;
        }
    }

    private void SurfaceOnClick(object? sender, EventArgs e)
    {
        if (_clickable)
        {
            CardClick?.Invoke(this, e);
            OnClick(e);
        }
    }

    private void SurfaceOnMouseEnter(object? sender, EventArgs e)
    {
        if (!_enableHoverFeedback || Appearance != CardAppearance.Elevated)
        {
            return;
        }

        _isHovered = true;
        if (_animateElevationOnHover)
        {
            _targetElevation = _hoverElevation;
            _animationTimer.Start();
        }
        else
        {
            _elevation = _hoverElevation;
            ApplyShadowPadding();
            Invalidate();
        }
    }

    private void SurfaceOnMouseLeave(object? sender, EventArgs e)
    {
        _isHovered = false;
        if (!_enableHoverFeedback || Appearance != CardAppearance.Elevated)
        {
            return;
        }

        if (_animateElevationOnHover)
        {
            _targetElevation = _restElevation;
            _animationTimer.Start();
        }
        else
        {
            _elevation = _restElevation;
            ApplyShadowPadding();
            Invalidate();
        }
    }

    private void SurfaceOnMouseDown(object? sender, MouseEventArgs e)
    {
        if (!_enableRipple || e.Button != MouseButtons.Left)
        {
            return;
        }

        _rippleCenter = _surface.PointToScreen(e.Location);
        _rippleRadius = 0;
        _rippleAlpha = CardMetrics.RippleMaxAlpha;
        _animationTimer.Start();
    }

    private void HeaderOnClick(object? sender, EventArgs e)
    {
        if (_expandable && _expandOnHeaderClick)
        {
            ToggleExpanded();
        }
    }

    private void BeginExpandCollapseAnimation()
    {
        CacheExpandMetrics();
        _bodyTargetHeight = _expanded ? _bodyExpandedHeight : CardMetrics.MinimumCollapsedBodyHeight;

        if (!_animateExpandCollapse)
        {
            ApplyExpandState(animate: false);
            ExpandAnimationCompleted?.Invoke(this, EventArgs.Empty);
            return;
        }

        _animatingExpandCollapse = true;
        _animationTimer.Start();
    }

    private void ApplyExpandState(bool animate)
    {
        _animatingExpandCollapse = false;
        _bodyCurrentHeight = _bodyTargetHeight;
        ApplyExpandLayout();
    }

    private void CacheExpandMetrics()
    {
        UpdateSectionVisibility();

        int previousBodyHeight = _bodyPanel.Height;
        _bodyPanel.SuspendLayout();
        _bodyPanel.Visible = true;
        _bodyPanel.Height = 10000;
        _bodyPanel.PerformLayout();

        int measuredBodyHeight = 0;
        foreach (Control control in _bodyPanel.Controls)
        {
            if (!control.Visible)
            {
                continue;
            }

            if (control.Dock is DockStyle.Top or DockStyle.Bottom)
            {
                measuredBodyHeight += control.Height;
            }
        }

        if (Content.Visible)
        {
            measuredBodyHeight += Math.Max(
                CardMetrics.MinimumExpandedBodyContentHeight,
                Content.PreferredSize.Height);
        }

        _bodyExpandedHeight = Math.Max(measuredBodyHeight, CardMetrics.MinimumExpandedBodyContentHeight);
        _bodyPanel.Height = previousBodyHeight > 0 ? previousBodyHeight : _bodyExpandedHeight;

        int headerHeight = Header.Visible ? Header.Height : 0;
        _expandedCardHeight = headerHeight + _bodyExpandedHeight + Padding.Vertical + 8;
        _collapsedCardHeight = Math.Max(MinimumSize.Height, headerHeight + Padding.Vertical + 8);

        _bodyPanel.ResumeLayout(true);
    }

    private void ApplyExpandLayout()
    {
        if (!_expandable)
        {
            return;
        }

        _bodyPanel.Visible = _bodyCurrentHeight > 0 || _expanded;
        int bodyWidth = Math.Max(0, _surface.ClientSize.Width);

        if (_animatingExpandCollapse && _expandDirection == CardExpandDirection.SlideUp)
        {
            int bodyTop = Math.Max(Header.Visible ? Header.Bottom : 0, _surface.ClientSize.Height - _bodyCurrentHeight);
            _bodyPanel.Dock = DockStyle.None;
            _bodyPanel.SetBounds(0, bodyTop, bodyWidth, Math.Max(0, _bodyCurrentHeight));
        }
        else
        {
            _bodyPanel.Dock = DockStyle.Top;
            _bodyPanel.Width = bodyWidth;
            _bodyPanel.Height = Math.Max(0, _bodyCurrentHeight);
        }

        int targetCardHeight = _collapsedCardHeight + Math.Max(0, _bodyCurrentHeight);
        Height = targetCardHeight;

        _surface.PerformLayout();
        _surface.UpdateRegion();
        Invalidate();
    }

    private void AnimateExpandCollapseStep()
    {
        if (_bodyCurrentHeight == _bodyTargetHeight)
        {
            _animatingExpandCollapse = false;
            _bodyPanel.Dock = DockStyle.Top;
            ApplyExpandLayout();
            ExpandAnimationCompleted?.Invoke(this, EventArgs.Empty);
            return;
        }

        int step = CardMetrics.ExpandCollapseStep;
        if (_bodyCurrentHeight < _bodyTargetHeight)
        {
            _bodyCurrentHeight = Math.Min(_bodyTargetHeight, _bodyCurrentHeight + step);
        }
        else
        {
            _bodyCurrentHeight = Math.Max(_bodyTargetHeight, _bodyCurrentHeight - step);
        }

        ApplyExpandLayout();
    }

    private void AnimationTimerOnTick(object? sender, EventArgs e)
    {
        bool animatingElevation = _elevation != _targetElevation;
        bool animatingRipple = _rippleAlpha > 0;
        bool animatingExpand = _animatingExpandCollapse && _expandable;

        if (animatingElevation)
        {
            int step = Math.Max(1, Math.Abs(_targetElevation - _elevation) / 2);
            if (_elevation < _targetElevation)
            {
                _elevation = Math.Min(_targetElevation, _elevation + step);
            }
            else
            {
                _elevation = Math.Max(_targetElevation, _elevation - step);
            }

            ApplyShadowPadding();
        }

        if (animatingRipple)
        {
            _rippleRadius += CardMetrics.RippleGrowth;
            _rippleAlpha = Math.Max(0, _rippleAlpha - CardMetrics.RippleFadeStep);
        }

        if (animatingExpand)
        {
            AnimateExpandCollapseStep();
        }

        Invalidate();

        if (!animatingElevation && !animatingRipple && !animatingExpand)
        {
            _animationTimer.Stop();
        }
    }

    private void ApplyShadowPadding()
    {
        Padding shadowPadding = GetShadowPadding();
        if (Padding != shadowPadding)
        {
            Padding = shadowPadding;
        }
    }

    private Padding GetShadowPadding()
    {
        if (Appearance != CardAppearance.Elevated || _elevation <= 0)
        {
            return Padding.Empty;
        }

        int inset = Math.Max(2, _elevation);
        return new Padding(inset, inset, inset, inset);
    }
}
