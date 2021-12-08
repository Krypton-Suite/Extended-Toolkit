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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    [DefaultEvent("ButtonClicked")]
    [ToolboxBitmap(typeof(TableLayoutPanel))]
    public class OutlookBar : Control
    {

        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;
        private PaletteBackInheritRedirect _paletteBack;
        private PaletteBorderInheritRedirect _paletteBorder;
        private PaletteContentInheritRedirect _paletteContent;
        private IDisposable _mementoBack;

        #region ... constructor ...
        public OutlookBar()
        {
            Paint += OutlookBar_Paint;
            MouseUp += OutlookBar_MouseUp;
            MouseMove += OutlookBar_MouseMove;
            MouseLeave += OutlookBar_MouseLeave;
            MouseDown += OutlookBar_MouseDown;
            MouseClick += OutlookBar_MouseClick;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this._Buttons = new OutlookBarButtonCollection(this);

            // add Palette Handler
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);
            _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);
            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);
            _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            //only if Krypton
            if (Renderer == Renderer.Krypton) InitColors();
        }

        public event ButtonClickedEventHandler ButtonClicked;
        public delegate void ButtonClickedEventHandler(object sender, System.EventArgs e);

        //Needed because this way the buttons can raise the ButtonClicked event...
        public void SetSelectionChanged(OutlookBarButton button)
        {
            this._SelectedButton = button;
            this.Invalidate();
            if (ButtonClicked != null)
            {
                ButtonClicked(this, new System.EventArgs());
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
        private OutlookBarButton _HoveringButton;
        private OutlookBarButton _LeftClickedButton;
        private OutlookBarButton _RightClickedButton;
        internal OutlookBarButton _SelectedButton;
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
        public OutlookBarButtonCollection Buttons
        {
            get { return this._Buttons; }
        }

        [Browsable(true)]
        public OutlookBarButton SelectedButton
        {
            get { return this._SelectedButton; }
        }

        [Browsable(true)]
        public int SelectedIndex
        {
            get { return this.Buttons.SelectedIndex(_SelectedButton); }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(bool), "False")]
        public bool DrawBorders
        {
            get { return this._DrawBorders; }
            set
            {
                this._DrawBorders = value;
                this.Invalidate();
            }
        }
        [Category("Appearance")]
        [DefaultValue(typeof(bool), "False")]
        public bool RemoveTopBorder
        {
            get { return this._RemoveTopBorder; }
            set
            {
                this._RemoveTopBorder = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        public Renderer Renderer
        {
            get { return this._Renderer; }
            set
            {
                this._Renderer = value;
                this.InitColors();
                this.Invalidate();
            }
        }
        public override Size MinimumSize
        {
            get { return new Size(this.GetBottomContainerLeftMargin(), this.GetBottomContainerRectangle().Height + GetGripRectangle().Height); }
            //do nothing...
            set { }
        }
        [Category("Appearance"), DisplayName("LineColour")]
        public Color OutlookBarLineColour
        {
            get { return this._OutlookBarLineColour; }
            set
            {
                this._OutlookBarLineColour = value;
                this.Invalidate();
            }
        }
        [Category("Appearance")]
        public int ButtonHeight
        {
            get { return this._ButtonHeight; }
            set
            {
                if (value < 5) value = 5;
                this._ButtonHeight = value;
                this.Invalidate();
            }
        }
        [DisplayName("ForeColorNotSelected")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                this.Invalidate();
            }
        }
        [Category("Appearance")]
        public Color ForeColourSelected
        {
            get { return this._ForeColourSelected; }
            set
            {
                this._ForeColourSelected = value;
                this.Invalidate();
            }
        }
        [DisplayName("ButtonFont")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                this.Invalidate();
            }
        }
        [Category("Appearance"), DisplayName("ButtonHovering1")]
        public Color ButtonColourHoveringTop
        {
            get { return this._ButtonColourHoveringTop; }
            set
            {
                this._ButtonColourHoveringTop = value;
                this.Invalidate();
            }
        }
        [Category("Appearance"), DisplayName("ButtonSelected1")]
        public Color ButtonColourSelectedTop
        {
            get { return this._ButtonColourSelectedTop; }
            set
            {
                this._ButtonColourSelectedTop = value;
                this.Invalidate();
            }
        }
        [Category("Appearance"), DisplayName("ButtonSelectedHovering1")]
        public Color ButtonColourSelectedAndHoveringTop
        {
            get { return this._ButtonColourSelectedAndHoveringTop; }
            set
            {
                this._ButtonColourSelectedAndHoveringTop = value;
                this.Invalidate();
            }
        }
        [Category("Appearance"), DisplayName("ButtonPassive1")]
        public Color ButtonColourPassiveTop
        {
            get { return this._ButtonColourPassiveTop; }
            set
            {
                this._ButtonColourPassiveTop = value;
                this.Invalidate();
            }
        }
        [Category("Appearance"), DisplayName("ButtonHovering2")]
        public Color ButtonColourHoveringBottom
        {
            get { return this._ButtonColourHoveringBottom; }
            set
            {
                this._ButtonColourHoveringBottom = value;
                this.Invalidate();
            }
        }
        [Category("Appearance"), DisplayName("ButtonSelected2")]
        public Color ButtonColourSelectedBottom
        {
            get { return this._ButtonColourSelectedBottom; }
            set
            {
                this._ButtonColourSelectedBottom = value;
                this.Invalidate();
            }
        }
        [Category("Appearance"), DisplayName("ButtonSelectedHovering2")]
        public Color ButtonColourSelectedAndHoveringBottom
        {
            get { return this._ButtonColourSelectedAndHoveringBottom; }
            set
            {
                this._ButtonColourSelectedAndHoveringBottom = value;
                this.Invalidate();
            }
        }
        [Category("Appearance"), DisplayName("ButtonPassive2")]
        public Color ButtonColourPassiveBottom
        {
            get { return this._ButtonColoruPassiveBottom; }
            set
            {
                this._ButtonColoruPassiveBottom = value;
                this.Invalidate();
            }
        }

        //

        #endregion

        #region " Control events "



        private void OutlookBar_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _RightClickedButton = null;
            OutlookBarButton mButton = this.Buttons[e.X, e.Y];
            if ((mButton != null))
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        this._SelectedButton = mButton;
                        if (ButtonClicked != null)
                        {
                            ButtonClicked(this, new System.EventArgs());
                        }

                        this.Invalidate();
                        break;
                    case MouseButtons.Right:
                        this._RightClickedButton = mButton;
                        this.Invalidate();
                        break;
                }
            }
            else
            {
                if (this.GetDropDownRectangle().Contains(e.X, e.Y))
                {
                    this.CreateContextMenu();
                }
            }
        }
        private void OutlookBar_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            IsResizing = GetGripRectangle().Contains(e.X, e.Y);
        }

        private void OutlookBar_MouseLeave(object sender, System.EventArgs e)
        {
            if (this._RightClickedButton == null)
            {
                this._HoveringButton = null;
                this._DropDownHovering = false;
                this.Invalidate();
            }
        }

        private void OutlookBar_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this._HoveringButton = null;
            //string EmptyLineVar = null;
            this._DropDownHovering = false;
            if (IsResizing)
            {
                if (e.Y < -GetButtonHeight())
                {
                    if (CanGrow)
                    {
                        this.Height += GetButtonHeight();
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
                        this.Height -= GetButtonHeight();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                if (this.GetGripRectangle().Contains(e.X, e.Y))
                {
                    this.Cursor = Cursors.SizeNS;
                }
                else if (GetDropDownRectangle().Contains(e.X, e.Y))
                {
                    this.Cursor = Cursors.Hand;
                    this._DropDownHovering = true;
                    this.Invalidate();
                    //
                    //adjust Tooltip...
                    if ((oToolTip.Tag != null))
                    {
                        if (!oToolTip.Tag.Equals("Configure"))
                        {
                            this.oToolTip.Active = true;
                            this.oToolTip.SetToolTip(this, "Configure buttons");
                            this.oToolTip.Tag = "Configure";
                        }
                    }
                    else
                    {
                        this.oToolTip.Active = true;
                        this.oToolTip.SetToolTip(this, "Configure buttons");
                        this.oToolTip.Tag = "Configure";
                    }
                    //EmptyLineVar = null;
                }
                else if ((this.Buttons[e.X, e.Y] != null))
                {
                    this.Cursor = Cursors.Hand;
                    this._HoveringButton = this.Buttons[e.X, e.Y];
                    this.Invalidate();
                    //string EmptyLineVar = null;
                    //adjust tooltip...
                    if (!this.Buttons[e.X, e.Y].isLarge)
                    {
                        if (oToolTip.Tag == null)
                        {
                            this.oToolTip.Active = true;
                            this.oToolTip.SetToolTip(this, this.Buttons[e.X, e.Y].Text);
                            this.oToolTip.Tag = this.Buttons[e.X, e.Y];
                        }
                        else
                        {
                            if (!oToolTip.Tag.Equals(this.Buttons[e.X, e.Y]))
                            {
                                this.oToolTip.Active = true;
                                this.oToolTip.SetToolTip(this, this.Buttons[e.X, e.Y].Text);
                                this.oToolTip.Tag = this.Buttons[e.X, e.Y];
                            }
                        }
                    }
                    else
                    {
                        this.oToolTip.Active = false;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void OutlookBar_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.IsResizing = false;
            this._LeftClickedButton = null;
        }

        #endregion

        #region " Graphics "

        private int MaxLargeButtonCount;
        private int MaxSmallButtonCount;

        internal void OutlookBar_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //string EmptyLineVar = null;
            this.MaxLargeButtonCount = (int)Math.Round(Math.Floor((double)(((double)((this.Height - this.GetBottomContainerRectangle().Height) - this.GetGripRectangle().Height)) / ((double)this.GetButtonHeight()))));
            if (this.Buttons.CountVisible() < MaxLargeButtonCount) MaxLargeButtonCount = this.Buttons.CountVisible();

            CanShrink = (MaxLargeButtonCount != 0);
            CanGrow = (MaxLargeButtonCount < this.Buttons.CountVisible());

            this.Height = (MaxLargeButtonCount * GetButtonHeight()) + GetGripRectangle().Height + GetBottomContainerRectangle().Height;

            //Paint Grip...
            this.PaintGripRectangle(e.Graphics);

            //Paint Large Buttons...
            int SyncLargeButtons = 0;
            int IterateLargeButtons = 0;
            for (IterateLargeButtons = 0; IterateLargeButtons <= this.Buttons.Count - 1; IterateLargeButtons++)
            {
                if (this.Buttons[IterateLargeButtons].Visible)
                {
                    Rectangle rec = new Rectangle(0, (SyncLargeButtons * GetButtonHeight()) + GetGripRectangle().Height, this.Width, GetButtonHeight());
                    Buttons[IterateLargeButtons].Rectangle = rec;
                    Buttons[IterateLargeButtons].isLarge = true;
                    this.PaintButton(Buttons[IterateLargeButtons], e.Graphics, (MaxLargeButtonCount != SyncLargeButtons));
                    if (SyncLargeButtons == MaxLargeButtonCount) break; // TODO: might not be correct. Was : Exit For

                    SyncLargeButtons += 1;
                }
            }
            //Paint Small Buttons...
            this.MaxSmallButtonCount = (int)Math.Round(Math.Floor((double)(((double)((this.Width - this.GetDropDownRectangle().Width) - this.GetBottomContainerLeftMargin())) / ((double)this.GetSmallButtonWidth()))));

            if ((this.Buttons.CountVisible() - MaxLargeButtonCount) <= 0)
            {
                MaxSmallButtonCount = 0;
            }

            if (MaxSmallButtonCount >= (this.Buttons.CountVisible() - MaxLargeButtonCount))
            {
                MaxSmallButtonCount = (this.Buttons.CountVisible() - MaxLargeButtonCount);
            }


            int StartX = this.Width - GetDropDownRectangle().Width - (MaxSmallButtonCount * this.GetSmallButtonWidth());

            int SyncSmallButtons = 0;
            int IterateSmallButtons = 0;

            for (IterateSmallButtons = IterateLargeButtons; IterateSmallButtons <= this.Buttons.Count - 1; IterateSmallButtons++)
            {
                if (SyncSmallButtons == MaxSmallButtonCount) break; // TODO: might not be correct. Was : Exit For

                if (this.Buttons[IterateSmallButtons].Visible)
                {
                    Rectangle rec = new Rectangle(StartX + (SyncSmallButtons * GetSmallButtonWidth()), GetBottomContainerRectangle().Y, GetSmallButtonWidth(), GetBottomContainerRectangle().Height);
                    this.Buttons[IterateSmallButtons].Rectangle = rec;
                    this.Buttons[IterateSmallButtons].isLarge = false;
                    //OutlookBarButton refBtn = Buttons[IterateLargeButtons];
                    this.PaintButton(this.Buttons[IterateSmallButtons], e.Graphics, false);
                    SyncSmallButtons += 1;
                }
            }

            for (int IterateMenuItems = IterateSmallButtons; IterateMenuItems <= this.Buttons.CountVisible() - 1; IterateMenuItems++)
            {
                this.Buttons[IterateMenuItems].Rectangle = new Rectangle();
            }

            //Draw Empty Space...
            Rectangle recEmptySpace = this.GetBottomContainerRectangle();
            {
                recEmptySpace.Width = this.Width - (MaxSmallButtonCount * this.GetSmallButtonWidth()) - this.GetDropDownRectangle().Width;
            }

            this.FillButton(recEmptySpace, e.Graphics, ButtonState.Passive, true, true, (isDebugMode));

            //Paint DropDown...
            this.PaintDropDownRectangle(e.Graphics);

            //Finally, paint the bottom line...
            e.Graphics.DrawLine(new Pen(this.GetOutlookBarLineColour()), 0, this.Height - 1, this.Width - 1, this.Height - 1);
        }

        private void PaintButton(OutlookBarButton Button, Graphics graphics, bool IsLastLarge)
        {
            if (Button.Equals(_HoveringButton))
            {
                if (_LeftClickedButton == null)
                {
                    if (Button.Equals(this.SelectedButton))
                    {
                        FillButton(Button.Rectangle, graphics, ButtonState.HoveringSelected, true, Button.isLarge, Button.isLarge);
                    }
                    else
                    {
                        this.FillButton(Button.Rectangle, graphics, ButtonState.Hovering, true, Button.isLarge, Button.isLarge);
                    }
                }
                else
                {
                    this.FillButton(Button.Rectangle, graphics, ButtonState.Selected, true, Button.isLarge, Button.isLarge);
                }
            }
            else
            {
                if (Button.Equals(SelectedButton))
                {
                    FillButton(Button.Rectangle, graphics, ButtonState.Selected, true, Button.isLarge, Button.isLarge);
                }
                else
                {
                    FillButton(Button.Rectangle, graphics, ButtonState.Passive, true, Button.isLarge, Button.isLarge);
                }
            }
            //string EmptyLineVar = null;
            //Text and icons...
            if (Button.isLarge & IsLastLarge == true)
            {
                graphics.DrawString(Button.Text, this.GetButtonFont(), this.GetButtonTextBrush(Button.Equals(this.SelectedButton)), 10 + ImageDimension_Large + 8, (float)Button.Rectangle.Y + ((GetButtonHeight() / 2) - (this.GetButtonFont().Height / 2)) + 2);
            }
            Rectangle recIma = new Rectangle();
            switch (Button.isLarge)
            {
                case true:
                    {
                        recIma.Width = ImageDimension_Large;
                        recIma.Height = ImageDimension_Large;
                        recIma.X = 10;
                        recIma.Y = Button.Rectangle.Y + (int)Math.Floor((double)(GetButtonHeight() / 2) - (double)(ImageDimension_Large / 2));
                    }

                    break;
                case false:
                    {
                        recIma.Width = ImageDimension_Small;
                        recIma.Height = ImageDimension_Small;
                        recIma.X = Button.Rectangle.X + (int)Math.Floor((double)(GetSmallButtonWidth() / 2) - (double)(ImageDimension_Small / 2));
                        recIma.Y = Button.Rectangle.Y + (int)Math.Floor((double)(GetButtonHeight() / 2) - (double)(ImageDimension_Small / 2));
                    }

                    break;
            }
            if (Button.isLarge & IsLastLarge == true) graphics.DrawImage(Button.Image.ToBitmap(), recIma);
            if (Button.isLarge == false) graphics.DrawImage(Button.Image.ToBitmap(), recIma);

            //Debug
            if (isDebugMode) graphics.DrawRectangle(new Pen(Color.Red), recIma);
        }

        private void FillButton(Rectangle rectangle, Graphics graphics, ButtonState buttonState, bool DrawTopBorder, bool DrawLeftBorder, bool DrawRightBorder)
        {
            switch (this.Renderer)
            {
                case Renderer.Outlook2003:
                    Brush aBrush = new LinearGradientBrush(rectangle, this.GetButtonColor(buttonState, 0), this.GetButtonColor(buttonState, 1), LinearGradientMode.Vertical);
                    graphics.FillRectangle(aBrush, rectangle);
                    aBrush.Dispose();
                    break;
                case Renderer.Outlook2007:
                    //string EmptyLineVar = null;
                    //Filling the top part of the button...
                    Rectangle TopRectangle = rectangle;
                    Brush TopBrush = new LinearGradientBrush(TopRectangle, this.GetButtonColor(buttonState, 0), this.GetButtonColor(buttonState, 1), LinearGradientMode.Vertical);
                    TopRectangle.Height = (GetButtonHeight() * 15) / 32;
                    graphics.FillRectangle(TopBrush, TopRectangle);
                    TopBrush.Dispose();
                    //and the bottom part...
                    Rectangle BottomRectangle = rectangle;
                    Brush BottomBrush = new LinearGradientBrush(BottomRectangle, this.GetButtonColor(buttonState, 2), this.GetButtonColor(buttonState, 3), LinearGradientMode.Vertical);
                    BottomRectangle.Y += (GetButtonHeight() * 12) / 32;
                    BottomRectangle.Height -= (GetButtonHeight() * 12) / 32;
                    graphics.FillRectangle(BottomBrush, BottomRectangle);
                    BottomBrush.Dispose();
                    break;

                case Renderer.Custom:
                    Brush bBrush = new LinearGradientBrush(rectangle, this.GetButtonColor(buttonState, 0), this.GetButtonColor(buttonState, 1), LinearGradientMode.Vertical);
                    graphics.FillRectangle(bBrush, rectangle);
                    bBrush.Dispose();
                    break;

                case Renderer.Krypton:
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        IRenderer renderer = _palette.GetRenderer();
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
                            if (renderer.ToString() == "ComponentFactory.Krypton.Toolkit.RenderSparkle")
                            {
                                _paletteBack.Style = PaletteBackStyle.ButtonInputControl;
                            }

                            _mementoBack = renderer.RenderStandardBack.DrawBack(context, rectangle, path, _paletteBack, VisualOrientation.Top, ps, _mementoBack);
                            /*renderer.RenderStandardBorder.DrawBorder(context,
                                                           rectangle,
                                                           _paletteBorder,
                                                           VisualOrientation.Top,
                                                           ps);
                             */
                        }
                    }
                    break;
            }


            //Draw Top Border...
            if (DrawTopBorder) graphics.DrawLine(new Pen(GetOutlookBarLineColour()), rectangle.X, rectangle.Y, rectangle.Width + rectangle.X, rectangle.Y);

            //DrawBorders?
            if (_DrawBorders)
            {
                //Draw Left Border...
                if (DrawLeftBorder) graphics.DrawLine(new Pen(GetOutlookBarLineColour()), rectangle.X, rectangle.Y, rectangle.X, rectangle.Y + rectangle.Height);
                //Draw Right Border...
                if (DrawRightBorder) graphics.DrawLine(new Pen(GetOutlookBarLineColour()), rectangle.X + rectangle.Width - 1, rectangle.Y, rectangle.X + rectangle.Width - 1, rectangle.Y + rectangle.Height);
            }
        }

        private void PaintGripRectangle(Graphics graphics)
        {
            //Paint the backcolor...
            graphics.FillRectangle(this.GetGripBrush(), this.GetGripRectangle());


            //Draw the icon...
            Icon oIcon = this.GetGripIcon();
            Rectangle RectangleIcon = new Rectangle((int)((int)this.Width / 2) - ((int)oIcon.Width / 2), (((int)(GetGripRectangle().Height) / 2) - (int)(oIcon.Height / 2)) + 1, oIcon.Width, oIcon.Height);

            if (Renderer != Renderer.Krypton)
            {
                //Icon from file
                graphics.DrawIcon(oIcon, RectangleIcon);
            }
            else
            {
                //Painted
                PaintGrip(graphics, RectangleIcon, _GridColourDark, _GridColourLight);
            }
            oIcon.Dispose();

            //RemoveTopBorder?
            if (!_RemoveTopBorder)
            {
                graphics.DrawLine(new Pen(this.GetGripTopColor(), 1), 0, 0, this.Width, 0);
            }

            //DrawBorders?
            if (_DrawBorders)
            {
                graphics.DrawLine(new Pen(this.GetOutlookBarLineColour(), 1), 0, 0, 0, GetGripRectangle().Height);
                graphics.DrawLine(new Pen(this.GetOutlookBarLineColour(), 1), GetGripRectangle().Width - 1, 0, GetGripRectangle().Width - 1, this.GetGripRectangle().Height);
            }
        }

        private void PaintGrip(Graphics graphics, Rectangle RectangleIcon, Color GripDark, Color GripLight)
        {
            // White Grip - Shadow
            Rectangle IGrip = new Rectangle((int)(RectangleIcon.X + RectangleIcon.Width / 2) - 10, (int)(RectangleIcon.Y + RectangleIcon.Height / 2), 2, 2);
            Rectangle IIGrip = new Rectangle((int)(RectangleIcon.X + RectangleIcon.Width / 2) - 5, (int)(RectangleIcon.Y + RectangleIcon.Height / 2), 2, 2);
            Rectangle IIIGrip = new Rectangle((int)(RectangleIcon.X + RectangleIcon.Width / 2), (int)(RectangleIcon.Y + RectangleIcon.Height / 2), 2, 2);
            Rectangle IVGrip = new Rectangle((int)(RectangleIcon.X + RectangleIcon.Width / 2) + 5, (int)(RectangleIcon.Y + RectangleIcon.Height / 2), 2, 2);
            Rectangle VGrip = new Rectangle((int)(RectangleIcon.X + RectangleIcon.Width / 2) + 10, (int)(RectangleIcon.Y + RectangleIcon.Height / 2), 2, 2);
            graphics.FillRectangle(new SolidBrush(GripLight), IGrip);
            graphics.FillRectangle(new SolidBrush(GripLight), IIGrip);
            graphics.FillRectangle(new SolidBrush(GripLight), IIIGrip);
            graphics.FillRectangle(new SolidBrush(GripLight), IVGrip);
            graphics.FillRectangle(new SolidBrush(GripLight), VGrip);

            // dark Grip - Shadow
            Rectangle IGripDark = new Rectangle((int)(RectangleIcon.X + RectangleIcon.Width / 2) - 11, (int)(RectangleIcon.Y + RectangleIcon.Height / 2) - 1, 2, 2);
            Rectangle IIGripDark = new Rectangle((int)(RectangleIcon.X + RectangleIcon.Width / 2) - 6, (int)(RectangleIcon.Y + RectangleIcon.Height / 2) - 1, 2, 2);
            Rectangle IIIGripDark = new Rectangle((int)(RectangleIcon.X + RectangleIcon.Width / 2) - 1, (int)(RectangleIcon.Y + RectangleIcon.Height / 2) - 1, 2, 2);
            Rectangle IVGripDark = new Rectangle((int)(RectangleIcon.X + RectangleIcon.Width / 2) + 4, (int)(RectangleIcon.Y + RectangleIcon.Height / 2) - 1, 2, 2);
            Rectangle VGripDark = new Rectangle((int)(RectangleIcon.X + RectangleIcon.Width / 2) + 9, (int)(RectangleIcon.Y + RectangleIcon.Height / 2) - 1, 2, 2);
            graphics.FillRectangle(new SolidBrush(GripDark), IGripDark);
            graphics.FillRectangle(new SolidBrush(GripDark), IIGripDark);
            graphics.FillRectangle(new SolidBrush(GripDark), IIIGripDark);
            graphics.FillRectangle(new SolidBrush(GripDark), IVGripDark);
            graphics.FillRectangle(new SolidBrush(GripDark), VGripDark);
        }

        private void PaintDropDownRectangle(Graphics graphics)
        {
            //string EmptyLineVar = null;
            //Repaint the backcolor if the mouse is hovering...
            switch (this._DropDownHovering)
            {
                case true:
                    this.FillButton(this.GetDropDownRectangle(), graphics, ButtonState.Hovering, true, false, true);
                    break;
                case false:
                    this.FillButton(this.GetDropDownRectangle(), graphics, ButtonState.Passive, true, false, true);
                    break;
            }

            //Debug
            if (isDebugMode) graphics.DrawRectangle(new Pen(Color.Green), this.GetDropDownRectangle());

            //Draw the icon...
            Icon oIcon = this.GetDropDownIcon();
            Rectangle RectangleIcon = new Rectangle((this.GetDropDownRectangle().X + ((this.GetDropDownRectangle().Width / 2) - (oIcon.Width / 2))), (this.GetDropDownRectangle().Y + (((this.GetDropDownRectangle().Height / 2) - (oIcon.Height / 2)) + 1)), oIcon.Width, oIcon.Height);
            if (Renderer != Renderer.Krypton)
            {
                //draw icon from file
                graphics.DrawIcon(oIcon, RectangleIcon);
            }
            else
            {
                //paint the arrow
                PaintDropDown(graphics, RectangleIcon, _GridColourDark, _GridColourLight);
            }
            //Debug
            if (isDebugMode) graphics.DrawRectangle(new Pen(Color.Red), RectangleIcon);

            //graphics.DrawIcon(oIcon, RectangleIcon);
            oIcon.Dispose();
        }

        private void PaintDropDown(Graphics graphics, Rectangle RectangleIcon, Color GripDark, Color GripLight)
        {
            //draw White part
            Point[] ptWhite = new Point[3];
            ptWhite[0] = new Point(RectangleIcon.Left - 1, RectangleIcon.Top);
            ptWhite[1] = new Point(RectangleIcon.Left + RectangleIcon.Width / 2, RectangleIcon.Bottom + 1);
            ptWhite[2] = new Point(RectangleIcon.Right + 1, RectangleIcon.Top);
            graphics.FillPolygon(new SolidBrush(GripLight), ptWhite);

            //draw Colored part
            Point[] pt = new Point[3];
            pt[0] = new Point(RectangleIcon.Left - 1, RectangleIcon.Top);
            pt[1] = new Point(RectangleIcon.Left + RectangleIcon.Width / 2, RectangleIcon.Bottom);
            pt[2] = new Point(RectangleIcon.Right + 1, RectangleIcon.Top);
            graphics.FillPolygon(new SolidBrush(GripDark), pt);
        }

        #endregion

        #region " Renderer-dependent values "

        private Color GetOutlookBarLineColour()
        {
            switch (this.Renderer)
            {
                case Renderer.Outlook2003:
                    return Color.FromArgb(0, 45, 150);
                case Renderer.Outlook2007:
                    return Color.FromArgb(101, 147, 207);
                case Renderer.Krypton:
                    return this.OutlookBarLineColour;
                case Renderer.Custom:
                    return this.OutlookBarLineColour;
            }
            return this.OutlookBarLineColour;
        }

        private Brush GetButtonTextBrush(bool isSelected)
        {
            switch (this.Renderer)
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
                    break;
                case Renderer.Krypton:
                    switch (isSelected)
                    {
                        case false:
                            return new SolidBrush(this.ForeColor);
                        case true:
                            return new SolidBrush(this.ForeColourSelected);
                    }
                    break;
                case Renderer.Custom:
                    switch (isSelected)
                    {
                        case false:
                            return new SolidBrush(this.ForeColor);
                        case true:
                            return new SolidBrush(this.ForeColourSelected);
                    }
                    break;
            }
            return null;
        }
        private Font GetButtonFont()
        {
            switch (this.Renderer)
            {
                case Renderer.Krypton:
                    return new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
                case Renderer.Outlook2003:
                    return new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
                case Renderer.Outlook2007:
                    return new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
                case Renderer.Custom:
                    return this.Font;
            }
            return null;
        }
        private Color GetButtonColor(ButtonState buttonstate, int colorIndex)
        {
            switch (this.Renderer)
            {
                case Renderer.Outlook2003:
                    switch (buttonstate)
                    {
                        case ButtonState.Hovering | ButtonState.Selected:
                            if (colorIndex == 0) return Color.FromArgb(232, 127, 8);
                            if (colorIndex == 1) return Color.FromArgb(247, 218, 124);
                            break;
                        case ButtonState.Hovering:
                            if (colorIndex == 0) return Color.FromArgb(255, 255, 220);
                            if (colorIndex == 1) return Color.FromArgb(247, 192, 91);
                            break;
                        case ButtonState.Selected:
                            if (colorIndex == 0) return Color.FromArgb(247, 218, 124);
                            if (colorIndex == 1) return Color.FromArgb(232, 127, 8);
                            break;
                        case ButtonState.Passive:
                            if (colorIndex == 0) return Color.FromArgb(203, 225, 252);
                            if (colorIndex == 1) return Color.FromArgb(125, 166, 223);
                            break;
                    }
                    break;
                case Renderer.Outlook2007:
                    switch (buttonstate)
                    {
                        case ButtonState.Hovering | ButtonState.Selected:
                            if (colorIndex == 0) return Color.FromArgb(255, 189, 105);
                            if (colorIndex == 1) return Color.FromArgb(255, 172, 66);
                            if (colorIndex == 2) return Color.FromArgb(251, 140, 60);
                            if (colorIndex == 3) return Color.FromArgb(254, 211, 101);
                            break;
                        case ButtonState.Hovering:
                            if (colorIndex == 0) return Color.FromArgb(255, 254, 228);
                            if (colorIndex == 1) return Color.FromArgb(255, 232, 166);
                            if (colorIndex == 2) return Color.FromArgb(255, 215, 103);
                            if (colorIndex == 3) return Color.FromArgb(255, 230, 159);
                            break;
                        case ButtonState.Selected:
                            if (colorIndex == 0) return Color.FromArgb(255, 217, 170);
                            if (colorIndex == 1) return Color.FromArgb(255, 187, 109);
                            if (colorIndex == 2) return Color.FromArgb(255, 171, 63);
                            if (colorIndex == 3) return Color.FromArgb(254, 225, 123);
                            break;
                        case ButtonState.Passive:
                            if (colorIndex == 0) return Color.FromArgb(227, 239, 255);
                            if (colorIndex == 1) return Color.FromArgb(196, 221, 255);
                            if (colorIndex == 2) return Color.FromArgb(173, 209, 255);
                            if (colorIndex == 3) return Color.FromArgb(193, 219, 255);
                            break;
                    }
                    break;
                case Renderer.Krypton:
                    switch (buttonstate)
                    {
                        case ButtonState.Hovering | ButtonState.Selected:
                            if (colorIndex == 0) return this.ButtonColourSelectedAndHoveringTop;
                            if (colorIndex == 1) return this.ButtonColourSelectedAndHoveringBottom;
                            break;
                        case ButtonState.Hovering:
                            if (colorIndex == 0) return this.ButtonColourHoveringTop;
                            if (colorIndex == 1) return this.ButtonColourHoveringBottom;
                            break;
                        case ButtonState.Selected:
                            if (colorIndex == 0) return this.ButtonColourSelectedTop;
                            if (colorIndex == 1) return this.ButtonColourSelectedBottom;
                            break;
                        case ButtonState.Passive:
                            if (colorIndex == 0) return this.ButtonColourPassiveTop;
                            if (colorIndex == 1) return this.ButtonColourPassiveBottom;
                            break;
                    }
                    break;
                case Renderer.Custom:
                    switch (buttonstate)
                    {
                        case ButtonState.Hovering | ButtonState.Selected:
                            if (colorIndex == 0) return this.ButtonColourSelectedAndHoveringTop;
                            if (colorIndex == 1) return this.ButtonColourSelectedAndHoveringBottom;
                            break;
                        case ButtonState.Hovering:
                            if (colorIndex == 0) return this.ButtonColourHoveringTop;
                            if (colorIndex == 1) return this.ButtonColourHoveringBottom;
                            break;
                        case ButtonState.Selected:
                            if (colorIndex == 0) return this.ButtonColourSelectedTop;
                            if (colorIndex == 1) return this.ButtonColourSelectedBottom;
                            break;
                        case ButtonState.Passive:
                            if (colorIndex == 0) return this.ButtonColourPassiveTop;
                            if (colorIndex == 1) return this.ButtonColourPassiveBottom;
                            break;
                    }


                    break;
            }
            return Color.FromArgb(247, 218, 124);
        }
        private int GetButtonHeight()
        {
            switch (this.Renderer)
            {
                case Renderer.Outlook2003:
                    return 32;
                case Renderer.Outlook2007:
                    return 32;
                case Renderer.Krypton:
                    return 32;
                case Renderer.Custom:
                    return this.ButtonHeight;
            }
            return 32;
        }

        private Rectangle GetBottomContainerRectangle()
        {
            return new Rectangle(0, this.Height - this.GetButtonHeight(), this.Width, this.GetButtonHeight());
        }
        private int GetBottomContainerLeftMargin()
        {
            switch (this.Renderer)
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
            switch (this.Renderer)
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

        private Brush GetGripBrush()
        {
            switch (this.Renderer)
            {
                case Renderer.Outlook2003:
                    return new LinearGradientBrush(this.GetGripRectangle(), Color.FromArgb(89, 135, 214), Color.FromArgb(0, 45, 150), LinearGradientMode.Vertical);
                case Renderer.Outlook2007:
                    return new LinearGradientBrush(this.GetGripRectangle(), Color.FromArgb(227, 239, 255), Color.FromArgb(179, 212, 255), LinearGradientMode.Vertical);
                case Renderer.Krypton:
                    return new LinearGradientBrush(this.GetGripRectangle(), this.ButtonColourPassiveTop, this.ButtonColourPassiveBottom, LinearGradientMode.Vertical);
                case Renderer.Custom:
                    return new LinearGradientBrush(this.GetGripRectangle(), this.ButtonColourPassiveTop, this.ButtonColourPassiveBottom, LinearGradientMode.Vertical);
            }
            return null;
        }
        private Rectangle GetGripRectangle()
        {
            int Height = 0;
            switch (this.Renderer)
            {
                case Renderer.Outlook2003:
                    Height = 6;
                    break;
                case Renderer.Outlook2007:
                    Height = 8;
                    break;
                case Renderer.Krypton:
                    Height = 8;
                    break;
                case Renderer.Custom:
                    Height = 8;
                    break;
            }
            return new Rectangle(0, 0, this.Width, Height);
        }
        private Icon GetGripIcon()
        {
            switch (this.Renderer)
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
            switch (this.Renderer)
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
            return new Rectangle((this.Width - GetSmallButtonWidth()), (this.Height - GetButtonHeight()), GetSmallButtonWidth(), GetButtonHeight());
        }
        private Icon GetDropDownIcon()
        {
            switch (this.Renderer)
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
            this.oContextMenuStrip = new ContextMenuStrip();
            this.oContextMenuStrip.Items.Add("Show &More Buttons", Properties.Resources.Arrow_Up.ToBitmap(), ShowMoreButtons);
            this.oContextMenuStrip.Items.Add("Show Fe&wer Buttons", Properties.Resources.Arrow_Down.ToBitmap(), ShowFewerButtons);
            if (this.MaxLargeButtonCount >= this.Buttons.CountVisible()) this.oContextMenuStrip.Items[0].Enabled = false;
            if (this.MaxLargeButtonCount == 0) this.oContextMenuStrip.Items[1].Enabled = false;
            this.oContextMenuStrip.Items.Add("Na&vigation Pane Options...", null, NavigationPaneOptions);
            ToolStripMenuItem mnuAdd = new ToolStripMenuItem("&Add or Remove Buttons", null);
            this.oContextMenuStrip.Items.Add(mnuAdd);
            foreach (OutlookBarButton oButton in this.Buttons)
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
            foreach (OutlookBarButton oButton in this.Buttons)
            {
                if (oButton.Visible)
                {
                    if (oButton.Rectangle == null) c += 1;
                }
            }
            if (c > 0) this.oContextMenuStrip.Items.Add(new ToolStripSeparator());
            foreach (OutlookBarButton oButton in this.Buttons)
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
                            if ((this.SelectedButton != null))
                            {
                                if (this.SelectedButton.Equals(oButton)) mnu.Checked = true;
                            }
                        }
                        mnu.Click += MnuClicked;
                        this.oContextMenuStrip.Items.Add(mnu);
                    }
                }
            }
            this.oContextMenuStrip.Show(this, new Point(this.Width, this.Height - (GetButtonHeight() / 2)));
        }
        private void ShowMoreButtons(object sender, System.EventArgs e)
        {
            this.Height += GetButtonHeight();
        }
        private void ShowFewerButtons(object sender, System.EventArgs e)
        {
            this.Height -= GetButtonHeight();
        }
        private void NavigationPaneOptions(object sender, System.EventArgs e)
        {
            this._RightClickedButton = null;
            this._HoveringButton = null;
            this.Invalidate();
            OutlookBarNavigationPaneOptions frm = new OutlookBarNavigationPaneOptions(this.Buttons);
            frm.ShowDialog();
            this.Invalidate();
        }
        private void ToggleVisible(object sender, System.EventArgs e)
        {
            OutlookBarButton oButton = (OutlookBarButton)((ToolStripMenuItem)sender).Tag;
            oButton.Visible = !oButton.Visible;
            this.Invalidate();
        }
        private void MnuClicked(object sender, System.EventArgs e)
        {
            OutlookBarButton oButton = (OutlookBarButton)((ToolStripMenuItem)sender).Tag;
            this._SelectedButton = oButton;
            if (ButtonClicked != null)
            {
                ButtonClicked(this, new System.EventArgs());
            }
        }

        #endregion

        #region ... Krypton ...

        private void InitColors()
        {
            if (Renderer == Renderer.Krypton)
            {
                this._ButtonColourHoveringBottom = _palette.GetBackColor2(PaletteBackStyle.ButtonNavigatorStack, PaletteState.Tracking);
                this._ButtonColourHoveringTop = _palette.GetBackColor1(PaletteBackStyle.ButtonNavigatorStack, PaletteState.Tracking);

                this._ButtonColourSelectedBottom = _palette.GetBackColor2(PaletteBackStyle.ButtonNavigatorStack, PaletteState.Pressed);
                this._ButtonColourSelectedTop = _palette.GetBackColor1(PaletteBackStyle.ButtonNavigatorStack, PaletteState.Pressed);

                this._ButtonColoruPassiveBottom = _palette.GetBackColor2(PaletteBackStyle.ButtonNavigatorStack, PaletteState.Normal);
                this._ButtonColourPassiveTop = _palette.GetBackColor1(PaletteBackStyle.ButtonNavigatorStack, PaletteState.Normal);

                this._ButtonColourSelectedAndHoveringBottom = _palette.GetBackColor2(PaletteBackStyle.ButtonNavigatorStack, PaletteState.CheckedTracking);
                this._ButtonColourSelectedAndHoveringTop = _palette.GetBackColor1(PaletteBackStyle.ButtonNavigatorStack, PaletteState.CheckedTracking);

                this._OutlookBarLineColour = _palette.ColorTable.ToolStripBorder;

                this._ForeColourSelected = _palette.GetContentShortTextColor1(PaletteContentStyle.ButtonNavigatorStack, PaletteState.Pressed);//Color.Black;// _palette.ColorTable.MenuStripText;
                this.ForeColor = _palette.GetContentShortTextColor1(PaletteContentStyle.ButtonNavigatorStack, PaletteState.Normal);

                this._GridColourDark = _palette.ColorTable.GripDark;
                this._GridColourLight = _palette.ColorTable.GripLight;
            }
        }

        //Kripton Palette Events
        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;

            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
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
                    _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                    _palette = null;
                }

                // Unhook from the static events, otherwise we cannot be garbage collected
                KryptonManager.GlobalPaletteChanged -= new EventHandler(OnGlobalPaletteChanged);
            }

            base.Dispose(disposing);
        }

        #endregion

    }

    #region ... Enums ...
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


}