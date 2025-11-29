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

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable PossibleLossOfFraction
namespace Krypton.Toolkit.Suite.Extended.Navigator;

[DefaultEvent("ButtonClicked")]
[ToolboxBitmap(typeof(TableLayoutPanel))]
public class OutlookBar : Control
{

    private PaletteBase? _palette;
    private PaletteRedirect _paletteRedirect;
    private PaletteBackInheritRedirect _paletteBack;
    private PaletteBorderInheritRedirect _paletteBorder;
    private PaletteContentInheritRedirect _paletteContent;
    private IDisposable? _mementoBack;

    #region ... constructor ...
    public OutlookBar()
    {
        Paint += OutlookBar_Paint;
        MouseUp += OutlookBar_MouseUp;
        MouseMove += OutlookBar_MouseMove;
        MouseLeave += OutlookBar_MouseLeave;
        MouseDown += OutlookBar_MouseDown;
        MouseClick += OutlookBar_MouseClick;
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        SetStyle(ControlStyles.ResizeRedraw, true);
        _Buttons = new OutlookBarButtonCollection(this);

        // add Palette Handler
        if (_palette != null)
        {
            _palette.PalettePaint += OnPalettePaint;
        }

        KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;

        _palette = KryptonManager.CurrentGlobalPalette;
        _paletteRedirect = new PaletteRedirect(_palette);
        _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);
        _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);
        _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

        //only if Krypton
        if (Renderer == Renderer.Krypton)
        {
            InitColors();
        }
    }

    public event ButtonClickedEventHandler? ButtonClicked;
    public delegate void ButtonClickedEventHandler(object sender, EventArgs e);

    //Needed because this way the buttons can raise the ButtonClicked event...
    public void SetSelectionChanged(OutlookBarButton? button)
    {
        _SelectedButton = button;
        Invalidate();
        if (ButtonClicked != null)
        {
            ButtonClicked(this, new EventArgs());
        }
    }
    #endregion

    #region " Members... "

    //Private Members...
    private ToolTip oToolTip = new ToolTip();
    private ContextMenuStrip oContextMenuStrip;
    private OutlookBarButtonCollection _Buttons;
    private Renderer _Renderer = Renderer.Custom;
    private const int ImageDimension_Large = 24;
    private const int ImageDimension_Small = 18;
    private bool _DropDownHovering;
    private OutlookBarButton? _HoveringButton;
    private OutlookBarButton? _LeftClickedButton;
    private OutlookBarButton? _RightClickedButton;
    internal OutlookBarButton? _SelectedButton;
    private bool IsResizing;
    private bool CanGrow;
    private bool CanShrink;
    private Color _OutlookBarLineColour;
    private int _ButtonHeight = 35;
    private Color _ForeColourSelected;
    private Color _ButtonColourHoveringTop;
    private Color _ButtonColourSelectedTop;
    private Color _ButtonColourSelectedAndHoveringTop;
    private Color _ButtonColourPassiveTop;
    private Color _ButtonColourHoveringBottom;
    private Color _ButtonColourSelectedBottom;
    private Color _ButtonColourSelectedAndHoveringBottom;
    private Color _ButtonColoruPassiveBottom;
    private Color _GridColourDark;
    private Color _GridColourLight;
    private bool _DrawBorders;
    private bool _RemoveTopBorder;
    private bool isDebugMode = false;

    //Public Members...
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Behavior")]
    public OutlookBarButtonCollection Buttons => _Buttons;

    [Browsable(true)]
    public OutlookBarButton? SelectedButton => _SelectedButton;

    [Browsable(true)]
    public int SelectedIndex => Buttons.SelectedIndex(_SelectedButton);

    [Category("Appearance")]
    [DefaultValue(typeof(bool), "False")]
    public bool DrawBorders
    {
        get => _DrawBorders;
        set
        {
            _DrawBorders = value;
            Invalidate();
        }
    }
    [Category("Appearance")]
    [DefaultValue(typeof(bool), "False")]
    public bool RemoveTopBorder
    {
        get => _RemoveTopBorder;
        set
        {
            _RemoveTopBorder = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Renderer Renderer
    {
        get => _Renderer;
        set
        {
            _Renderer = value;
            InitColors();
            Invalidate();
        }
    }
    public override Size MinimumSize
    {
        get => new Size(GetBottomContainerLeftMargin(), GetBottomContainerRectangle().Height + GetGripRectangle().Height);
        //do nothing...
        set { }
    }
    [Category("Appearance"), DisplayName("LineColour")]
    public Color OutlookBarLineColour
    {
        get => _OutlookBarLineColour;
        set
        {
            _OutlookBarLineColour = value;
            Invalidate();
        }
    }
    [Category("Appearance")]
    public int ButtonHeight
    {
        get => _ButtonHeight;
        set
        {
            if (value < 5)
            {
                value = 5;
            }

            _ButtonHeight = value;
            Invalidate();
        }
    }
    [DisplayName("ForeColorNotSelected")]
    public override Color ForeColor
    {
        get => base.ForeColor;
        set
        {
            base.ForeColor = value;
            Invalidate();
        }
    }
    [Category("Appearance")]
    public Color ForeColourSelected
    {
        get => _ForeColourSelected;
        set
        {
            _ForeColourSelected = value;
            Invalidate();
        }
    }
    [DisplayName("ButtonFont")]
    public override Font? Font
    {
        get => base.Font;
        set
        {
            base.Font = value;
            Invalidate();
        }
    }
    [Category("Appearance"), DisplayName("ButtonHovering1")]
    public Color ButtonColourHoveringTop
    {
        get => _ButtonColourHoveringTop;
        set
        {
            _ButtonColourHoveringTop = value;
            Invalidate();
        }
    }
    [Category("Appearance"), DisplayName("ButtonSelected1")]
    public Color ButtonColourSelectedTop
    {
        get => _ButtonColourSelectedTop;
        set
        {
            _ButtonColourSelectedTop = value;
            Invalidate();
        }
    }
    [Category("Appearance"), DisplayName("ButtonSelectedHovering1")]
    public Color ButtonColourSelectedAndHoveringTop
    {
        get => _ButtonColourSelectedAndHoveringTop;
        set
        {
            _ButtonColourSelectedAndHoveringTop = value;
            Invalidate();
        }
    }
    [Category("Appearance"), DisplayName("ButtonPassive1")]
    public Color ButtonColourPassiveTop
    {
        get => _ButtonColourPassiveTop;
        set
        {
            _ButtonColourPassiveTop = value;
            Invalidate();
        }
    }
    [Category("Appearance"), DisplayName("ButtonHovering2")]
    public Color ButtonColourHoveringBottom
    {
        get => _ButtonColourHoveringBottom;
        set
        {
            _ButtonColourHoveringBottom = value;
            Invalidate();
        }
    }
    [Category("Appearance"), DisplayName("ButtonSelected2")]
    public Color ButtonColourSelectedBottom
    {
        get => _ButtonColourSelectedBottom;
        set
        {
            _ButtonColourSelectedBottom = value;
            Invalidate();
        }
    }
    [Category("Appearance"), DisplayName("ButtonSelectedHovering2")]
    public Color ButtonColourSelectedAndHoveringBottom
    {
        get => _ButtonColourSelectedAndHoveringBottom;
        set
        {
            _ButtonColourSelectedAndHoveringBottom = value;
            Invalidate();
        }
    }
    [Category("Appearance"), DisplayName("ButtonPassive2")]
    public Color ButtonColourPassiveBottom
    {
        get => _ButtonColoruPassiveBottom;
        set
        {
            _ButtonColoruPassiveBottom = value;
            Invalidate();
        }
    }

    //

    #endregion

    #region " Control events "



    private void OutlookBar_MouseClick(object sender, MouseEventArgs e)
    {
        _RightClickedButton = null;
        OutlookBarButton? mButton = Buttons[e.X, e.Y];
        if (mButton != null)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _SelectedButton = mButton;
                    if (ButtonClicked != null)
                    {
                        ButtonClicked(this, new EventArgs());
                    }

                    Invalidate();
                    break;
                case MouseButtons.Right:
                    _RightClickedButton = mButton;
                    Invalidate();
                    break;
            }
        }
        else
        {
            if (GetDropDownRectangle().Contains(e.X, e.Y))
            {
                CreateContextMenu();
            }
        }
    }
    private void OutlookBar_MouseDown(object sender, MouseEventArgs e)
    {
        IsResizing = GetGripRectangle().Contains(e.X, e.Y);
    }

    private void OutlookBar_MouseLeave(object sender, EventArgs e)
    {
        if (_RightClickedButton == null)
        {
            _HoveringButton = null;
            _DropDownHovering = false;
            Invalidate();
        }
    }

    private void OutlookBar_MouseMove(object sender, MouseEventArgs e)
    {
        _HoveringButton = null;
        //string EmptyLineVar = null;
        _DropDownHovering = false;
        if (IsResizing)
        {
            if (e.Y < -GetButtonHeight())
            {
                if (CanGrow)
                {
                    Height += GetButtonHeight();
                }
                else
                {
                    return;
                }
            }
            else if (e.Y > GetButtonHeight())
            {
                if (CanShrink)
                {
                    Height -= GetButtonHeight();
                }
                else
                {
                    return;
                }
            }
        }
        else
        {
            if (GetGripRectangle().Contains(e.X, e.Y))
            {
                Cursor = Cursors.SizeNS;
            }
            else if (GetDropDownRectangle().Contains(e.X, e.Y))
            {
                Cursor = Cursors.Hand;
                _DropDownHovering = true;
                Invalidate();
                //
                //adjust Tooltip...
                if (oToolTip.Tag != null)
                {
                    if (!oToolTip.Tag.Equals("Configure"))
                    {
                        oToolTip.Active = true;
                        oToolTip.SetToolTip(this, "Configure buttons");
                        oToolTip.Tag = "Configure";
                    }
                }
                else
                {
                    oToolTip.Active = true;
                    oToolTip.SetToolTip(this, "Configure buttons");
                    oToolTip.Tag = "Configure";
                }
                //EmptyLineVar = null;
            }
            else if (Buttons[e.X, e.Y] != null)
            {
                Cursor = Cursors.Hand;
                _HoveringButton = Buttons[e.X, e.Y];
                Invalidate();
                //string EmptyLineVar = null;
                //adjust tooltip...
                if (!Buttons[e.X, e.Y]!.IsLarge)
                {
                    if (oToolTip.Tag == null)
                    {
                        oToolTip.Active = true;
                        oToolTip.SetToolTip(this, Buttons[e.X, e.Y]!.Text);
                        oToolTip.Tag = Buttons[e.X, e.Y];
                    }
                    else
                    {
                        if (!oToolTip.Tag.Equals(Buttons[e.X, e.Y]))
                        {
                            oToolTip.Active = true;
                            oToolTip.SetToolTip(this, Buttons[e.X, e.Y]!.Text);
                            oToolTip.Tag = Buttons[e.X, e.Y];
                        }
                    }
                }
                else
                {
                    oToolTip.Active = false;
                }
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }
    }

    private void OutlookBar_MouseUp(object sender, MouseEventArgs e)
    {
        IsResizing = false;
        _LeftClickedButton = null;
    }

    #endregion

    #region " Graphics "

    private int _maxLargeButtonCount;
    private int _maxSmallButtonCount;

    internal void OutlookBar_Paint(object sender, PaintEventArgs e)
    {
        //string EmptyLineVar = null;
        _maxLargeButtonCount = (int)Math.Round(Math.Floor((Height - GetBottomContainerRectangle().Height - GetGripRectangle().Height) / (double)GetButtonHeight()));
        if (Buttons.CountVisible() < _maxLargeButtonCount)
        {
            _maxLargeButtonCount = Buttons.CountVisible();
        }

        CanShrink = _maxLargeButtonCount != 0;
        CanGrow = _maxLargeButtonCount < Buttons.CountVisible();

        Height = _maxLargeButtonCount * GetButtonHeight() + GetGripRectangle().Height + GetBottomContainerRectangle().Height;

        //Paint Grip...
        PaintGripRectangle(e.Graphics);

        //Paint Large Buttons...
        int syncLargeButtons = 0;
        int iterateLargeButtons = 0;
        for (iterateLargeButtons = 0; iterateLargeButtons <= Buttons.Count - 1; iterateLargeButtons++)
        {
            if (Buttons[iterateLargeButtons].Visible)
            {
                Rectangle rec = new Rectangle(0, syncLargeButtons * GetButtonHeight() + GetGripRectangle().Height, Width, GetButtonHeight());
                Buttons[iterateLargeButtons].Rectangle = rec;
                Buttons[iterateLargeButtons].IsLarge = true;
                PaintButton(Buttons[iterateLargeButtons], e.Graphics, _maxLargeButtonCount != syncLargeButtons);
                if (syncLargeButtons == _maxLargeButtonCount)
                {
                    break; // TODO: might not be correct. Was : Exit For
                }

                syncLargeButtons += 1;
            }
        }
        //Paint Small Buttons...
        _maxSmallButtonCount = (int)Math.Round(Math.Floor((Width - GetDropDownRectangle().Width - GetBottomContainerLeftMargin()) / (double)GetSmallButtonWidth()));

        if (Buttons.CountVisible() - _maxLargeButtonCount <= 0)
        {
            _maxSmallButtonCount = 0;
        }

        if (_maxSmallButtonCount >= Buttons.CountVisible() - _maxLargeButtonCount)
        {
            _maxSmallButtonCount = Buttons.CountVisible() - _maxLargeButtonCount;
        }


        int startX = Width - GetDropDownRectangle().Width - _maxSmallButtonCount * GetSmallButtonWidth();

        int syncSmallButtons = 0;
        int iterateSmallButtons = 0;

        for (iterateSmallButtons = iterateLargeButtons; iterateSmallButtons <= Buttons.Count - 1; iterateSmallButtons++)
        {
            if (syncSmallButtons == _maxSmallButtonCount)
            {
                break; // TODO: might not be correct. Was : Exit For
            }

            if (Buttons[iterateSmallButtons].Visible)
            {
                Rectangle rec = new Rectangle(startX + syncSmallButtons * GetSmallButtonWidth(), GetBottomContainerRectangle().Y, GetSmallButtonWidth(), GetBottomContainerRectangle().Height);
                Buttons[iterateSmallButtons].Rectangle = rec;
                Buttons[iterateSmallButtons].IsLarge = false;
                //OutlookBarButton refBtn = Buttons[IterateLargeButtons];
                PaintButton(Buttons[iterateSmallButtons], e.Graphics, false);
                syncSmallButtons += 1;
            }
        }

        for (int iterateMenuItems = iterateSmallButtons; iterateMenuItems <= Buttons.CountVisible() - 1; iterateMenuItems++)
        {
            Buttons[iterateMenuItems].Rectangle = new Rectangle();
        }

        //Draw Empty Space...
        Rectangle recEmptySpace = GetBottomContainerRectangle();
        {
            recEmptySpace.Width = Width - _maxSmallButtonCount * GetSmallButtonWidth() - GetDropDownRectangle().Width;
        }

        FillButton(recEmptySpace, e.Graphics, ButtonState.Passive, true, true, isDebugMode);

        //Paint DropDown...
        PaintDropDownRectangle(e.Graphics);

        //Finally, paint the bottom line...
        e.Graphics.DrawLine(new Pen(GetOutlookBarLineColour()), 0, Height - 1, Width - 1, Height - 1);
    }

    private void PaintButton(OutlookBarButton button, Graphics graphics, bool isLastLarge)
    {
        if (button.Equals(_HoveringButton))
        {
            if (_LeftClickedButton == null)
            {
                if (button.Equals(SelectedButton))
                {
                    FillButton(button.Rectangle, graphics, ButtonState.HoveringSelected, true, button.IsLarge, button.IsLarge);
                }
                else
                {
                    FillButton(button.Rectangle, graphics, ButtonState.Hovering, true, button.IsLarge, button.IsLarge);
                }
            }
            else
            {
                FillButton(button.Rectangle, graphics, ButtonState.Selected, true, button.IsLarge, button.IsLarge);
            }
        }
        else
        {
            if (button.Equals(SelectedButton))
            {
                FillButton(button.Rectangle, graphics, ButtonState.Selected, true, button.IsLarge, button.IsLarge);
            }
            else
            {
                FillButton(button.Rectangle, graphics, ButtonState.Passive, true, button.IsLarge, button.IsLarge);
            }
        }
        //string EmptyLineVar = null;
        //Text and icons...
        if (button.IsLarge & isLastLarge)
        {
            graphics.DrawString(button.Text, GetButtonFont(), GetButtonTextBrush(button.Equals(SelectedButton)),
                10 + ImageDimension_Large + 8,
                (float)button.Rectangle.Y + (GetButtonHeight() / 2 - GetButtonFont().Height / 2) + 2);
        }
        Rectangle recIma = new Rectangle();
        switch (button.IsLarge)
        {
            case true:
            {
                recIma.Width = ImageDimension_Large;
                recIma.Height = ImageDimension_Large;
                recIma.X = 10;
                recIma.Y = button.Rectangle.Y +
                           (int)Math.Floor(GetButtonHeight() / 2 - (double)(ImageDimension_Large / 2));
            }

                break;
            case false:
            {
                recIma.Width = ImageDimension_Small;
                recIma.Height = ImageDimension_Small;
                recIma.X = button.Rectangle.X + (int)Math.Floor(GetSmallButtonWidth() / 2 - (double)(ImageDimension_Small / 2));
                recIma.Y = button.Rectangle.Y + (int)Math.Floor(GetButtonHeight() / 2 - (double)(ImageDimension_Small / 2));
            }

                break;
        }
        if (button.IsLarge & isLastLarge)
        {
            graphics.DrawImage(button.Image.ToBitmap(), recIma);
        }

        if (button.IsLarge == false)
        {
            graphics.DrawImage(button.Image.ToBitmap(), recIma);
        }

        //Debug
        if (isDebugMode)
        {
            graphics.DrawRectangle(new Pen(Color.Red), recIma);
        }
    }

    private void FillButton(Rectangle rectangle, Graphics graphics, ButtonState buttonState, bool drawTopBorder, bool drawLeftBorder, bool drawRightBorder)
    {
        switch (Renderer)
        {
            case Renderer.Outlook2003:
                Brush aBrush = new LinearGradientBrush(rectangle, GetButtonColor(buttonState, 0), GetButtonColor(buttonState, 1), LinearGradientMode.Vertical);
                graphics.FillRectangle(aBrush, rectangle);
                aBrush.Dispose();
                break;
            case Renderer.Outlook2007:
                //string EmptyLineVar = null;
                //Filling the top part of the button...
                Rectangle topRectangle = rectangle;
                Brush topBrush = new LinearGradientBrush(topRectangle, GetButtonColor(buttonState, 0), GetButtonColor(buttonState, 1), LinearGradientMode.Vertical);
                topRectangle.Height = GetButtonHeight() * 15 / 32;
                graphics.FillRectangle(topBrush, topRectangle);
                topBrush.Dispose();
                //and the bottom part...
                Rectangle bottomRectangle = rectangle;
                Brush bottomBrush = new LinearGradientBrush(bottomRectangle, GetButtonColor(buttonState, 2), GetButtonColor(buttonState, 3), LinearGradientMode.Vertical);
                bottomRectangle.Y += GetButtonHeight() * 12 / 32;
                bottomRectangle.Height -= GetButtonHeight() * 12 / 32;
                graphics.FillRectangle(bottomBrush, bottomRectangle);
                bottomBrush.Dispose();
                break;

            case Renderer.Custom:
                Brush bBrush = new LinearGradientBrush(rectangle, GetButtonColor(buttonState, 0), GetButtonColor(buttonState, 1), LinearGradientMode.Vertical);
                graphics.FillRectangle(bBrush, rectangle);
                bBrush.Dispose();
                break;

            case Renderer.Krypton:
                using (GraphicsPath path = new GraphicsPath())
                {
                    if (_palette != null)
                    {
                        IRenderer? renderer = _palette.GetRenderer();
                        path.AddRectangle(rectangle);

                        using (RenderContext context = new RenderContext(this, graphics, rectangle, renderer))
                        {

                            PaletteState ps = PaletteState.Normal;


                            switch (buttonState)
                            {
                                case ButtonState.Hovering:
                                    ps = PaletteState.Tracking;
                                    break;
                                case ButtonState.Passive:
                                    ps = PaletteState.Normal;
                                    break;
                                case ButtonState.Selected:
                                    ps = PaletteState.Pressed;
                                    break;
                                case ButtonState.HoveringSelected:
                                    ps = PaletteState.CheckedTracking;
                                    break;
                            }

                            _paletteBack.Style = PaletteBackStyle.ButtonNavigatorStack;
                            _paletteBorder.Style = PaletteBorderStyle.ButtonNavigatorStack;

                            //check on renderer type
                            if (renderer?.ToString() == "Krypton.Toolkit.RenderSparkle")
                            {
                                _paletteBack.Style = PaletteBackStyle.ButtonInputControl;
                            }

                            if (renderer != null)
                            {
                                _mementoBack = renderer.RenderStandardBack.DrawBack(context, rectangle, path,
                                    _paletteBack, VisualOrientation.Top, ps, _mementoBack);
                            }
                            /*renderer.RenderStandardBorder.DrawBorder(context,
                                                       rectangle,
                                                       _paletteBorder,
                                                       VisualOrientation.Top,
                                                       ps);
                         */
                        }
                    }
                }
                break;
        }


        //Draw Top Border...
        if (drawTopBorder)
        {
            graphics.DrawLine(new Pen(GetOutlookBarLineColour()), rectangle.X, rectangle.Y, rectangle.Width + rectangle.X, rectangle.Y);
        }

        //DrawBorders?
        if (_DrawBorders)
        {
            //Draw Left Border...
            if (drawLeftBorder)
            {
                graphics.DrawLine(new Pen(GetOutlookBarLineColour()), rectangle.X, rectangle.Y, rectangle.X, rectangle.Y + rectangle.Height);
            }

            //Draw Right Border...
            if (drawRightBorder)
            {
                graphics.DrawLine(new Pen(GetOutlookBarLineColour()), rectangle.X + rectangle.Width - 1, rectangle.Y, rectangle.X + rectangle.Width - 1, rectangle.Y + rectangle.Height);
            }
        }
    }

    private void PaintGripRectangle(Graphics graphics)
    {
        //Paint the backcolor...
        graphics.FillRectangle(GetGripBrush(), GetGripRectangle());


        //Draw the icon...
        Icon? oIcon = GetGripIcon();
        Rectangle rectangleIcon = new Rectangle(Width / 2 - oIcon.Width / 2, GetGripRectangle().Height / 2 - oIcon.Height / 2 + 1, oIcon.Width, oIcon.Height);

        if (Renderer != Renderer.Krypton)
        {
            //Icon from file
            graphics.DrawIcon(oIcon, rectangleIcon);
        }
        else
        {
            //Painted
            PaintGrip(graphics, rectangleIcon, _GridColourDark, _GridColourLight);
        }
        oIcon.Dispose();

        //RemoveTopBorder?
        if (!_RemoveTopBorder)
        {
            graphics.DrawLine(new Pen(GetGripTopColor(), 1), 0, 0, Width, 0);
        }

        //DrawBorders?
        if (_DrawBorders)
        {
            graphics.DrawLine(new Pen(GetOutlookBarLineColour(), 1), 0, 0, 0, GetGripRectangle().Height);
            graphics.DrawLine(new Pen(GetOutlookBarLineColour(), 1), GetGripRectangle().Width - 1, 0, GetGripRectangle().Width - 1, GetGripRectangle().Height);
        }
    }

    private void PaintGrip(Graphics graphics, Rectangle rectangleIcon, Color darkGrip, Color lightGrip)
    {
        // White Grip - Shadow
        Rectangle grip = new Rectangle(rectangleIcon.X + rectangleIcon.Width / 2 - 10, rectangleIcon.Y + rectangleIcon.Height / 2, 2, 2);
        Rectangle iiGrip = new Rectangle(rectangleIcon.X + rectangleIcon.Width / 2 - 5, rectangleIcon.Y + rectangleIcon.Height / 2, 2, 2);
        Rectangle iiiGrip = new Rectangle(rectangleIcon.X + rectangleIcon.Width / 2, rectangleIcon.Y + rectangleIcon.Height / 2, 2, 2);
        Rectangle ivGrip = new Rectangle(rectangleIcon.X + rectangleIcon.Width / 2 + 5, rectangleIcon.Y + rectangleIcon.Height / 2, 2, 2);
        Rectangle vGrip = new Rectangle(rectangleIcon.X + rectangleIcon.Width / 2 + 10, rectangleIcon.Y + rectangleIcon.Height / 2, 2, 2);
        graphics.FillRectangle(new SolidBrush(lightGrip), grip);
        graphics.FillRectangle(new SolidBrush(lightGrip), iiGrip);
        graphics.FillRectangle(new SolidBrush(lightGrip), iiiGrip);
        graphics.FillRectangle(new SolidBrush(lightGrip), ivGrip);
        graphics.FillRectangle(new SolidBrush(lightGrip), vGrip);

        // dark Grip - Shadow
        Rectangle gripDark = new Rectangle(rectangleIcon.X + rectangleIcon.Width / 2 - 11, rectangleIcon.Y + rectangleIcon.Height / 2 - 1, 2, 2);
        Rectangle iiGripDark = new Rectangle(rectangleIcon.X + rectangleIcon.Width / 2 - 6, rectangleIcon.Y + rectangleIcon.Height / 2 - 1, 2, 2);
        Rectangle iiiGripDark = new Rectangle(rectangleIcon.X + rectangleIcon.Width / 2 - 1, rectangleIcon.Y + rectangleIcon.Height / 2 - 1, 2, 2);
        Rectangle ivGripDark = new Rectangle(rectangleIcon.X + rectangleIcon.Width / 2 + 4, rectangleIcon.Y + rectangleIcon.Height / 2 - 1, 2, 2);
        Rectangle vGripDark = new Rectangle(rectangleIcon.X + rectangleIcon.Width / 2 + 9, rectangleIcon.Y + rectangleIcon.Height / 2 - 1, 2, 2);
        graphics.FillRectangle(new SolidBrush(darkGrip), gripDark);
        graphics.FillRectangle(new SolidBrush(darkGrip), iiGripDark);
        graphics.FillRectangle(new SolidBrush(darkGrip), iiiGripDark);
        graphics.FillRectangle(new SolidBrush(darkGrip), ivGripDark);
        graphics.FillRectangle(new SolidBrush(darkGrip), vGripDark);
    }

    private void PaintDropDownRectangle(Graphics graphics)
    {
        //string EmptyLineVar = null;
        //Repaint the backcolor if the mouse is hovering...
        switch (_DropDownHovering)
        {
            case true:
                FillButton(GetDropDownRectangle(), graphics, ButtonState.Hovering, true, false, true);
                break;
            case false:
                FillButton(GetDropDownRectangle(), graphics, ButtonState.Passive, true, false, true);
                break;
        }

        //Debug
        if (isDebugMode)
        {
            graphics.DrawRectangle(new Pen(Color.Green), GetDropDownRectangle());
        }

        //Draw the icon...
        Icon oIcon = GetDropDownIcon();
        Rectangle rectangleIcon = new Rectangle(GetDropDownRectangle().X + (GetDropDownRectangle().Width / 2 - oIcon.Width / 2), GetDropDownRectangle().Y + (GetDropDownRectangle().Height / 2 - oIcon.Height / 2) + 1, oIcon.Width, oIcon.Height);
        if (Renderer != Renderer.Krypton)
        {
            //draw icon from file
            graphics.DrawIcon(oIcon, rectangleIcon);
        }
        else
        {
            //paint the arrow
            PaintDropDown(graphics, rectangleIcon, _GridColourDark, _GridColourLight);
        }
        //Debug
        if (isDebugMode)
        {
            graphics.DrawRectangle(new Pen(Color.Red), rectangleIcon);
        }

        //graphics.DrawIcon(oIcon, RectangleIcon);
        oIcon.Dispose();
    }

    private void PaintDropDown(Graphics graphics, Rectangle rectangleIcon, Color darkGrip, Color gripLight)
    {
        //draw White part
        Point[] ptWhite = new Point[3];
        ptWhite[0] = new Point(rectangleIcon.Left - 1, rectangleIcon.Top);
        ptWhite[1] = new Point(rectangleIcon.Left + rectangleIcon.Width / 2, rectangleIcon.Bottom + 1);
        ptWhite[2] = new Point(rectangleIcon.Right + 1, rectangleIcon.Top);
        graphics.FillPolygon(new SolidBrush(gripLight), ptWhite);

        //draw Colored part
        Point[] pt = new Point[3];
        pt[0] = new Point(rectangleIcon.Left - 1, rectangleIcon.Top);
        pt[1] = new Point(rectangleIcon.Left + rectangleIcon.Width / 2, rectangleIcon.Bottom);
        pt[2] = new Point(rectangleIcon.Right + 1, rectangleIcon.Top);
        graphics.FillPolygon(new SolidBrush(darkGrip), pt);
    }

    #endregion

    #region " Renderer-dependent values "

    private Color GetOutlookBarLineColour()
    {
        switch (Renderer)
        {
            case Renderer.Outlook2003:
                return Color.FromArgb(0, 45, 150);
            case Renderer.Outlook2007:
                return Color.FromArgb(101, 147, 207);
            case Renderer.Krypton:
                return OutlookBarLineColour;
            case Renderer.Custom:
                return OutlookBarLineColour;
        }
        return OutlookBarLineColour;
    }

    private Brush? GetButtonTextBrush(bool isSelected)
    {
        switch (Renderer)
        {
            case Renderer.Outlook2003:
                return Brushes.Black;
            case Renderer.Outlook2007:
                switch (isSelected)
                {
                    case false:
                        return new SolidBrush(Color.FromArgb(32, 77, 137));
                    case true:
                        return Brushes.Black;
                }
            case Renderer.Krypton:
                switch (isSelected)
                {
                    case false:
                        return new SolidBrush(ForeColor);
                    case true:
                        return new SolidBrush(ForeColourSelected);
                }
            case Renderer.Custom:
                switch (isSelected)
                {
                    case false:
                        return new SolidBrush(ForeColor);
                    case true:
                        return new SolidBrush(ForeColourSelected);
                }
        }
        return null;
    }
    private Font? GetButtonFont()
    {
        switch (Renderer)
        {
            case Renderer.Krypton:
                return new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            case Renderer.Outlook2003:
                return new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            case Renderer.Outlook2007:
                return new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            case Renderer.Custom:
                return Font;
        }
        return null;
    }
    private Color GetButtonColor(ButtonState buttonState, int colorIndex)
    {
        switch (Renderer)
        {
            case Renderer.Outlook2003:
                switch (buttonState)
                {
                    case ButtonState.Hovering | ButtonState.Selected:
                        if (colorIndex == 0)
                        {
                            return Color.FromArgb(232, 127, 8);
                        }

                        if (colorIndex == 1)
                        {
                            return Color.FromArgb(247, 218, 124);
                        }

                        break;
                    case ButtonState.Hovering:
                        if (colorIndex == 0)
                        {
                            return Color.FromArgb(255, 255, 220);
                        }

                        if (colorIndex == 1)
                        {
                            return Color.FromArgb(247, 192, 91);
                        }

                        break;
                    case ButtonState.Selected:
                        if (colorIndex == 0)
                        {
                            return Color.FromArgb(247, 218, 124);
                        }

                        if (colorIndex == 1)
                        {
                            return Color.FromArgb(232, 127, 8);
                        }

                        break;
                    case ButtonState.Passive:
                        if (colorIndex == 0)
                        {
                            return Color.FromArgb(203, 225, 252);
                        }

                        if (colorIndex == 1)
                        {
                            return Color.FromArgb(125, 166, 223);
                        }

                        break;
                }
                break;
            case Renderer.Outlook2007:
                switch (buttonState)
                {
                    case ButtonState.Hovering | ButtonState.Selected:
                        if (colorIndex == 0)
                        {
                            return Color.FromArgb(255, 189, 105);
                        }

                        if (colorIndex == 1)
                        {
                            return Color.FromArgb(255, 172, 66);
                        }

                        if (colorIndex == 2)
                        {
                            return Color.FromArgb(251, 140, 60);
                        }

                        if (colorIndex == 3)
                        {
                            return Color.FromArgb(254, 211, 101);
                        }

                        break;
                    case ButtonState.Hovering:
                        if (colorIndex == 0)
                        {
                            return Color.FromArgb(255, 254, 228);
                        }

                        if (colorIndex == 1)
                        {
                            return Color.FromArgb(255, 232, 166);
                        }

                        if (colorIndex == 2)
                        {
                            return Color.FromArgb(255, 215, 103);
                        }

                        if (colorIndex == 3)
                        {
                            return Color.FromArgb(255, 230, 159);
                        }

                        break;
                    case ButtonState.Selected:
                        if (colorIndex == 0)
                        {
                            return Color.FromArgb(255, 217, 170);
                        }

                        if (colorIndex == 1)
                        {
                            return Color.FromArgb(255, 187, 109);
                        }

                        if (colorIndex == 2)
                        {
                            return Color.FromArgb(255, 171, 63);
                        }

                        if (colorIndex == 3)
                        {
                            return Color.FromArgb(254, 225, 123);
                        }

                        break;
                    case ButtonState.Passive:
                        if (colorIndex == 0)
                        {
                            return Color.FromArgb(227, 239, 255);
                        }

                        if (colorIndex == 1)
                        {
                            return Color.FromArgb(196, 221, 255);
                        }

                        if (colorIndex == 2)
                        {
                            return Color.FromArgb(173, 209, 255);
                        }

                        if (colorIndex == 3)
                        {
                            return Color.FromArgb(193, 219, 255);
                        }

                        break;
                }
                break;
            case Renderer.Krypton:
                switch (buttonState)
                {
                    case ButtonState.Hovering | ButtonState.Selected:
                        if (colorIndex == 0)
                        {
                            return ButtonColourSelectedAndHoveringTop;
                        }

                        if (colorIndex == 1)
                        {
                            return ButtonColourSelectedAndHoveringBottom;
                        }

                        break;
                    case ButtonState.Hovering:
                        if (colorIndex == 0)
                        {
                            return ButtonColourHoveringTop;
                        }

                        if (colorIndex == 1)
                        {
                            return ButtonColourHoveringBottom;
                        }

                        break;
                    case ButtonState.Selected:
                        if (colorIndex == 0)
                        {
                            return ButtonColourSelectedTop;
                        }

                        if (colorIndex == 1)
                        {
                            return ButtonColourSelectedBottom;
                        }

                        break;
                    case ButtonState.Passive:
                        if (colorIndex == 0)
                        {
                            return ButtonColourPassiveTop;
                        }

                        if (colorIndex == 1)
                        {
                            return ButtonColourPassiveBottom;
                        }

                        break;
                }
                break;
            case Renderer.Custom:
                switch (buttonState)
                {
                    case ButtonState.Hovering | ButtonState.Selected:
                        if (colorIndex == 0)
                        {
                            return ButtonColourSelectedAndHoveringTop;
                        }

                        if (colorIndex == 1)
                        {
                            return ButtonColourSelectedAndHoveringBottom;
                        }

                        break;
                    case ButtonState.Hovering:
                        if (colorIndex == 0)
                        {
                            return ButtonColourHoveringTop;
                        }

                        if (colorIndex == 1)
                        {
                            return ButtonColourHoveringBottom;
                        }

                        break;
                    case ButtonState.Selected:
                        if (colorIndex == 0)
                        {
                            return ButtonColourSelectedTop;
                        }

                        if (colorIndex == 1)
                        {
                            return ButtonColourSelectedBottom;
                        }

                        break;
                    case ButtonState.Passive:
                        if (colorIndex == 0)
                        {
                            return ButtonColourPassiveTop;
                        }

                        if (colorIndex == 1)
                        {
                            return ButtonColourPassiveBottom;
                        }

                        break;
                }


                break;
        }
        return Color.FromArgb(247, 218, 124);
    }
    private int GetButtonHeight()
    {
        switch (Renderer)
        {
            case Renderer.Outlook2003:
                return 32;
            case Renderer.Outlook2007:
                return 32;
            case Renderer.Krypton:
                return 32;
            case Renderer.Custom:
                return ButtonHeight;
        }
        return 32;
    }

    private Rectangle GetBottomContainerRectangle()
    {
        return new Rectangle(0, Height - GetButtonHeight(), Width, GetButtonHeight());
    }
    private int GetBottomContainerLeftMargin()
    {
        switch (Renderer)
        {
            case Renderer.Outlook2003:
                return 15;
            case Renderer.Outlook2007:
                return 16;
            case Renderer.Krypton:
                return 16;
            case Renderer.Custom:
                return 16;
        }
        return 16;
    }

    private int GetSmallButtonWidth()
    {
        switch (Renderer)
        {
            case Renderer.Outlook2003:
                return 22;
            case Renderer.Outlook2007:
                return 26;
            case Renderer.Krypton:
                return 26;
            case Renderer.Custom:
                return 25;
        }
        return 25;
    }

    private Brush? GetGripBrush()
    {
        switch (Renderer)
        {
            case Renderer.Outlook2003:
                return new LinearGradientBrush(GetGripRectangle(), Color.FromArgb(89, 135, 214), Color.FromArgb(0, 45, 150), LinearGradientMode.Vertical);
            case Renderer.Outlook2007:
                return new LinearGradientBrush(GetGripRectangle(), Color.FromArgb(227, 239, 255), Color.FromArgb(179, 212, 255), LinearGradientMode.Vertical);
            case Renderer.Krypton:
                return new LinearGradientBrush(GetGripRectangle(), ButtonColourPassiveTop, ButtonColourPassiveBottom, LinearGradientMode.Vertical);
            case Renderer.Custom:
                return new LinearGradientBrush(GetGripRectangle(), ButtonColourPassiveTop, ButtonColourPassiveBottom, LinearGradientMode.Vertical);
        }
        return null;
    }
    private Rectangle GetGripRectangle()
    {
        int height = 0;
        switch (Renderer)
        {
            case Renderer.Outlook2003:
                height = 6;
                break;
            case Renderer.Outlook2007:
                height = 8;
                break;
            case Renderer.Krypton:
                height = 8;
                break;
            case Renderer.Custom:
                height = 8;
                break;
        }
        return new Rectangle(0, 0, Width, height);
    }
    private Icon? GetGripIcon()
    {
        switch (Renderer)
        {
            case Renderer.Outlook2003:
                return Properties.Resources.Grip2003;
            case Renderer.Outlook2007:
                return Properties.Resources.Grip2007;
            case Renderer.Krypton:
                return Properties.Resources.Grip2007;
            case Renderer.Custom:
                return Properties.Resources.Grip2007;
        }
        return null;
    }
    private Color GetGripTopColor()
    {
        switch (Renderer)
        {
            case Renderer.Outlook2003:
                return Color.Transparent;
            case Renderer.Outlook2007:
                return GetOutlookBarLineColour();
            case Renderer.Krypton:
                return GetOutlookBarLineColour();
            case Renderer.Custom:
                return Color.Transparent;
        }
        return Color.Transparent;
    }

    private Rectangle GetDropDownRectangle()
    {
        return new Rectangle(Width - GetSmallButtonWidth(), Height - GetButtonHeight(), GetSmallButtonWidth(), GetButtonHeight());
    }
    private Icon? GetDropDownIcon()
    {
        switch (Renderer)
        {
            case Renderer.Outlook2003:
                return Properties.Resources.DropDown2003;
            case Renderer.Outlook2007:
                return Properties.Resources.DropDown2007;
            case Renderer.Krypton:
                return Properties.Resources.DropDown2007;
            case Renderer.Custom:
                return Properties.Resources.DropDown2007;
        }
        return null;
    }

    #endregion

    #region " MenuItems and Options "

    private void CreateContextMenu()
    {
        oContextMenuStrip = new ContextMenuStrip();
        oContextMenuStrip.Items.Add("Show &More Buttons", Properties.Resources.Arrow_Up.ToBitmap(), ShowMoreButtons);
        oContextMenuStrip.Items.Add("Show Fe&wer Buttons", Properties.Resources.Arrow_Down.ToBitmap(), ShowFewerButtons);
        if (_maxLargeButtonCount >= Buttons.CountVisible())
        {
            oContextMenuStrip.Items[0].Enabled = false;
        }

        if (_maxLargeButtonCount == 0)
        {
            oContextMenuStrip.Items[1].Enabled = false;
        }

        oContextMenuStrip.Items.Add("Na&vigation Pane Options...", null, NavigationPaneOptions);
        ToolStripMenuItem mnuAdd = new ToolStripMenuItem("&Add or Remove Buttons", null);
        oContextMenuStrip.Items.Add(mnuAdd);
        foreach (OutlookBarButton oButton in Buttons)
        {
            if (oButton.Allowed)
            {
                ToolStripMenuItem mnuA = new ToolStripMenuItem();
                {
                    mnuA.Text = oButton.Text;
                    mnuA.Image = oButton.Image.ToBitmap();
                    mnuA.CheckOnClick = true;
                    mnuA.Checked = oButton.Visible;
                    mnuA.Tag = oButton;
                }
                mnuA.Click += ToggleVisible;
                mnuAdd.DropDownItems.Add(mnuA);
            }
        }
        int c = 0;
        foreach (OutlookBarButton oButton in Buttons)
        {
            if (oButton.Visible)
            {
                if (oButton.Rectangle == null)
                {
                    c += 1;
                }
            }
        }
        if (c > 0)
        {
            oContextMenuStrip.Items.Add(new ToolStripSeparator());
        }

        foreach (OutlookBarButton oButton in Buttons)
        {
            if (oButton.Rectangle == null)
            {
                if (oButton.Visible)
                {
                    ToolStripMenuItem mnu = new ToolStripMenuItem();
                    {
                        mnu.Text = oButton.Text;
                        mnu.Image = oButton.Image.ToBitmap();
                        mnu.Tag = oButton;
                        mnu.CheckOnClick = true;
                        if (SelectedButton != null)
                        {
                            if (SelectedButton.Equals(oButton))
                            {
                                mnu.Checked = true;
                            }
                        }
                    }
                    mnu.Click += MnuClicked;
                    oContextMenuStrip.Items.Add(mnu);
                }
            }
        }
        oContextMenuStrip.Show(this, new Point(Width, Height - GetButtonHeight() / 2));
    }
    private void ShowMoreButtons(object sender, EventArgs e)
    {
        Height += GetButtonHeight();
    }
    private void ShowFewerButtons(object sender, EventArgs e)
    {
        Height -= GetButtonHeight();
    }
    private void NavigationPaneOptions(object sender, EventArgs e)
    {
        _RightClickedButton = null;
        _HoveringButton = null;
        Invalidate();
        OutlookBarNavigationPaneOptions frm = new OutlookBarNavigationPaneOptions(Buttons);
        frm.ShowDialog();
        Invalidate();
    }
    private void ToggleVisible(object sender, EventArgs e)
    {
        OutlookBarButton oButton = (OutlookBarButton)((ToolStripMenuItem)sender).Tag;
        oButton.Visible = !oButton.Visible;
        Invalidate();
    }
    private void MnuClicked(object sender, EventArgs e)
    {
        OutlookBarButton oButton = (OutlookBarButton)((ToolStripMenuItem)sender).Tag;
        _SelectedButton = oButton;
        if (ButtonClicked != null)
        {
            ButtonClicked(this, new EventArgs());
        }
    }

    #endregion

    #region ... Krypton ...

    private void InitColors()
    {
        if (Renderer == Renderer.Krypton)
        {
            if (_palette != null)
            {
                _ButtonColourHoveringBottom =
                    _palette.GetBackColor2(PaletteBackStyle.ButtonNavigatorStack, PaletteState.Tracking);
                _ButtonColourHoveringTop =
                    _palette.GetBackColor1(PaletteBackStyle.ButtonNavigatorStack, PaletteState.Tracking);

                _ButtonColourSelectedBottom =
                    _palette.GetBackColor2(PaletteBackStyle.ButtonNavigatorStack, PaletteState.Pressed);
                _ButtonColourSelectedTop =
                    _palette.GetBackColor1(PaletteBackStyle.ButtonNavigatorStack, PaletteState.Pressed);

                _ButtonColoruPassiveBottom =
                    _palette.GetBackColor2(PaletteBackStyle.ButtonNavigatorStack, PaletteState.Normal);
                _ButtonColourPassiveTop =
                    _palette.GetBackColor1(PaletteBackStyle.ButtonNavigatorStack, PaletteState.Normal);

                _ButtonColourSelectedAndHoveringBottom =
                    _palette.GetBackColor2(PaletteBackStyle.ButtonNavigatorStack, PaletteState.CheckedTracking);
                _ButtonColourSelectedAndHoveringTop = _palette.GetBackColor1(PaletteBackStyle.ButtonNavigatorStack,
                    PaletteState.CheckedTracking);

                _OutlookBarLineColour = _palette.ColorTable.ToolStripBorder;

                _ForeColourSelected = _palette.GetContentShortTextColor1(PaletteContentStyle.ButtonNavigatorStack,
                    PaletteState.Pressed); //Color.Black;// _palette.ColorTable.MenuStripText;
                ForeColor = _palette.GetContentShortTextColor1(PaletteContentStyle.ButtonNavigatorStack,
                    PaletteState.Normal);

                _GridColourDark = _palette.ColorTable.GripDark;
                _GridColourLight = _palette.ColorTable.GripLight;
            }
        }
    }

    //Krypton Palette Events
    private void OnGlobalPaletteChanged(object sender, EventArgs e)
    {
        if (_palette != null)
        {
            _palette.PalettePaint -= OnPalettePaint;
        }

        _palette = KryptonManager.CurrentGlobalPalette;
        _paletteRedirect.Target = _palette;

        if (_palette != null)
        {
            _palette.PalettePaint += OnPalettePaint;
            //repaint with new values

            InitColors();

        }

        Invalidate();
    }

    //Kripton Palette Events
    private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
    {
        Invalidate();
    }
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {

            // Unhook from the palette events
            if (_palette != null)
            {
                _palette.PalettePaint -= OnPalettePaint;
                _palette = null;
            }

            // Unhook from the static events, otherwise we cannot be garbage collected
            KryptonManager.GlobalPaletteChanged -= OnGlobalPaletteChanged;
        }

        base.Dispose(disposing);
    }

    #endregion

}

#region ... Enums ...

[Flags]
internal enum ButtonState
{
    Passive,
    Hovering,
    Selected,
    HoveringSelected
}

public enum Renderer
{
    Outlook2003,
    Outlook2007,
    Krypton,
    Custom
}
#endregion