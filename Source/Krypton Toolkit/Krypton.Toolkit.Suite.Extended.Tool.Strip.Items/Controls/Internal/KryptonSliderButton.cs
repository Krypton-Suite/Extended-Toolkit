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

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolboxBitmap(typeof(TrackBar)), ToolboxItem(false)]
    public partial class KryptonSliderButton : UserControl, IContentValues
    {
        #region Designer Code
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer? components;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FireTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // FireTimer
            // 
            this.FireTimer.Interval = 1000;
            this.FireTimer.Tick += new System.EventHandler(this.FireTimer_Tick);
            // 
            // KryptonSliderButton
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "KryptonSliderButton";
            this.Size = new System.Drawing.Size(16, 16);
            this.MouseLeave += new System.EventHandler(this.KryptonSliderButton_MouseLeave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.KryptonSliderButton_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.KryptonSliderButton_MouseUp);
            this.MouseEnter += new System.EventHandler(this.KryptonSliderButton_MouseEnter);
            this.ResumeLayout(false);

        }

        #endregion

        internal Timer FireTimer;
        #endregion

        #region ...   Enums    ...
        public enum ButtonStyles
        {
            PlusButton = 0,
            MinusButton = 1
        }
        #endregion
        public KryptonSliderButton()
        {

            //Initialize Component
            InitializeComponent();

            //(1) To remove flicker we use double buffering for drawing
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);

            //(5) Create redirection object to the base palette
            if (_palette != null)
            {
                _palette.PalettePaint += OnPalettePaint;
            }
            KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            //(6) Create accessor objects for the back, border and content
            _mPaletteBack = new PaletteBackInheritRedirect(_paletteRedirect);
            _mPaletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);
            _mPaletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            //Set Properties
            BackColor = Color.Transparent;
            Size = new Size(16, 16);

            InitColors();

        }

        //Palette State
        private KryptonManager _kManager = new KryptonManager();
        private PaletteBackInheritRedirect _mPaletteBack;
        private PaletteBorderInheritRedirect _mPaletteBorder;
        private PaletteContentInheritRedirect _mPaletteContent;
        private IDisposable _mMementoContent;
        private IDisposable _mMementoBack1;
        private IDisposable _mMementoBack2;

        private PaletteBase _palette;
        private PaletteRedirect _paletteRedirect;

        //Colors
        private Color _mInnerColor = Color.FromArgb(99, 106, 116);
        private Color _mOuterColor = Color.FromArgb(236, 236, 236);

        //Declares
        private bool _mHighlight;
        private bool _mDown;
        private VisualOrientation _mOrientation = VisualOrientation.Top;
        private ButtonStyles _mButtonstyle = ButtonStyles.MinusButton;
        private PaletteBackStyle _mVisuallook = PaletteBackStyle.ButtonStandalone;
        private bool _mSingleClick;

        //Events
        public event SliderButtonFireEventHandler SliderButtonFire;
        public delegate void SliderButtonFireEventHandler(KryptonSliderButton sender, EventArgs e);

        //Properties
        public bool SingleClick
        {
            get => _mSingleClick;
            set
            {
                _mSingleClick = value;
                Invalidate();
            }
        }
        public VisualOrientation Orientation
        {
            get => _mOrientation;
            set
            {
                if (_mOrientation != value)
                {
                    _mOrientation = value;
                    PerformLayout();
                    Invalidate();
                }
            }
        }
        public ButtonStyles ButtonStyle
        {
            get => _mButtonstyle;
            set
            {
                _mButtonstyle = value;
                Invalidate();
            }
        }
        public PaletteBackStyle VisualLook
        {
            get => _mVisuallook;
            set
            {
                if (_mVisuallook != value)
                {
                    _mVisuallook = value;
                    Invalidate();
                }
            }
        }
        public int EventFireRate
        {
            get => FireTimer.Interval;
            set
            {
                if (FireTimer.Interval != value & !_mDown)
                {
                    FireTimer.Interval = value;
                }
            }
        }

        //ComponentFactory Palette Painting
        protected override void OnPaint(PaintEventArgs e)
        {

            //Define Bounds
            Rectangle buttonBounds = new Rectangle(0, 0, 16, 16);
            RectangleF buttonCircleBounds = new RectangleF(0, 0, (float)15.1, (float)15.1);

            //Smoothing Mode
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            //Paint Base
            base.OnPaint(e);

            if (_palette != null)
            {

                //Get the renderer associated with this palette
                IRenderer renderer = _palette.GetRenderer();

                //Create the rendering context that is passed into all renderer calls
                using (RenderContext renderContext = new RenderContext(this, e.Graphics, buttonBounds, renderer))
                {

                    // Set the style we want picked up from the base palette
                    _mPaletteBack.Style = PaletteBackStyle.HeaderPrimary;


                    //Fill The Space
                    using (GraphicsPath path = GetButtonPath(buttonBounds))
                    {
                        // Ask renderer to draw the background
                        _mMementoBack1 = renderer.RenderStandardBack.DrawBack(renderContext, buttonBounds, path, _mPaletteBack, _mOrientation, Enabled ? PaletteState.Normal : PaletteState.Disabled, _mMementoBack1);
                    }

                    // We want the inner part of the control to act like a button, so 
                    // we need to find the correct palette state based on if the mouse 
                    // is over the control if the mouse button is pressed down or not.
                    PaletteState buttonState = GetButtonState();

                    // Set the style of button we want to draw
                    _mPaletteBack.Style = _mVisuallook;
                    _mPaletteBorder.Style = (PaletteBorderStyle)_mVisuallook;
                    _mPaletteContent.Style = (PaletteContentStyle)_mVisuallook;

                    // Do we need to draw the background?
                    if (_mPaletteBack.GetBackDraw(buttonState) == InheritBool.True)
                    {
                        using (GraphicsPath path = GetRoundedSquarePath(buttonCircleBounds))
                        {
                            // Ask renderer to draw the background
                            _mMementoBack2 = renderer.RenderStandardBack.DrawBack(renderContext, buttonBounds, path, _mPaletteBack, _mOrientation, buttonState, _mMementoBack2);
                        }
                    }

                    // Do we need to draw the border?
                    if (_mPaletteBorder.GetBorderDraw(buttonState) == InheritBool.True)
                    {
                        // Now we draw the border of the inner area, also in ButtonStandalone style
                        e.Graphics.DrawEllipse(new Pen(_mPaletteBorder.GetBorderColor2(buttonState)), buttonCircleBounds);
                    }

                    e.Graphics.SmoothingMode = SmoothingMode.None;

                    //Draw Magnifying Sign
                    switch (_mButtonstyle)
                    {
                        case ButtonStyles.MinusButton:
                            Rectangle minusOuterBounds = new Rectangle(3, Height / 2 - 2, 10, 4);
                            Rectangle minusInnerBounds = new Rectangle(4, Height / 2 - 1, 8, 2);

                            e.Graphics.FillRectangle(new SolidBrush(_mOuterColor), minusOuterBounds);
                            e.Graphics.FillRectangle(new SolidBrush(_mInnerColor), minusInnerBounds);

                            break;
                        case ButtonStyles.PlusButton:
                            DrawPlusOuter(e.Graphics, _mOuterColor);
                            DrawPlusInner(e.Graphics, _mInnerColor);
                            break;
                    }

                }
            }

        }
        protected override void OnLayout(LayoutEventArgs e)
        {

            //Active Palette
            //If m_palette IsNot Nothing Then
            if (_palette != null)
            {

                // We want the inner part of the control to act like a button, so 
                // we need to find the correct palette state based on if the mouse 
                // is over the control and currently being pressed down or not.
                PaletteState buttonState = GetButtonState();

                // Create a rectangle inset, this is where we will draw a button
                Rectangle buttonBounds = new Rectangle(0, 0, 16, 16);

                // Get the renderer associated with this palette
                IRenderer renderer = _palette.GetRenderer();

                // Create a layout context used to allow the renderer to layout the content
                using (ViewLayoutContext viewContext = new ViewLayoutContext(this, renderer))
                {

                    // Setup the appropriate style for the content
                    _mPaletteContent.Style = (PaletteContentStyle)_mVisuallook;

                    // Cleaup resources by disposing of old memento instance
                    _mMementoContent?.Dispose();

                    // Ask the renderer to work out how the Content values will be layed out and
                    // return a memento object that we cache for use when actually performing painting
                    _mMementoContent = renderer.RenderStandardContent.LayoutContent(viewContext, buttonBounds, _mPaletteContent, this, _mOrientation, buttonState);
                    //m_mementoContent = Renderer.RenderStandardContent.LayoutContent(ViewContext, ButtonBounds, m_paletteContent, this, m_orientation, false, buttonState, false);

                }
            }

            //Base Layout Call
            base.OnLayout(e);

        }

        //Disposal
        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {

                if (_palette != null)
                {
                    _palette.PalettePaint -= OnPalettePaint;
                    _palette = null;
                }


                KryptonManager.GlobalPaletteChanged -= OnGlobalPaletteChanged;

                //Dispose Memento Content
                if (_mMementoContent != null)
                {
                    _mMementoContent.Dispose();
                    _mMementoContent = null;
                }

                //Dispose Memento BackGround One
                if (_mMementoBack1 != null)
                {
                    _mMementoBack1.Dispose();
                    _mMementoBack1 = null;
                }

                //Dispose Memento BackGround Two
                if (_mMementoBack2 != null)
                {
                    _mMementoBack2.Dispose();
                    _mMementoBack2 = null;
                }

                components?.Dispose();

            }

            base.Dispose(disposing);
        }

        //Button Helpers
        private PaletteState GetButtonState()
        {
            if (!Enabled)
            {
                return PaletteState.Disabled;
            }
            else
            {
                if (_mDown)
                {
                    if (_mHighlight)
                    {
                        return PaletteState.CheckedPressed;
                    }
                    else
                    {
                        return PaletteState.Pressed;
                    }
                }
                else
                {
                    if (_mHighlight)
                    {
                        return PaletteState.Tracking;
                    }
                    else
                    {
                        return PaletteState.Normal;
                    }
                }
            }
        }
        public GraphicsPath GetRoundedSquarePath(RectangleF bounds)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(bounds);
            path.CloseFigure();
            return path;
        }
        private GraphicsPath GetButtonPath(RectangleF bounds)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(bounds);
            return path;
        }
        private void DrawPlusOuter(Graphics gfx, Color fill)
        {
            gfx.FillRectangle(new SolidBrush(fill), new Rectangle(3, Height / 2 - 2, 10, 4));
            gfx.FillRectangle(new SolidBrush(fill), new Rectangle(Width / 2 - 2, 3, 4, 10));
        }
        private void DrawPlusInner(Graphics gfx, Color fill)
        {
            gfx.FillRectangle(new SolidBrush(fill), new Rectangle(4, Height / 2 - 1, 8, 2));
            gfx.FillRectangle(new SolidBrush(fill), new Rectangle(Width / 2 - 1, 4, 2, 8));
        }

        //Key Mouse Events
        private void KryptonSliderButton_MouseDown(object? sender, MouseEventArgs e)
        {
            _mDown = true;
            //Single click?
            if (!_mSingleClick)
            { FireTimer.Start(); }

            Invalidate();
        }
        private void KryptonSliderButton_MouseEnter(object? sender, EventArgs e)
        {
            _mHighlight = true;
            Invalidate();
        }
        private void KryptonSliderButton_MouseLeave(object? sender, EventArgs e)
        {
            _mHighlight = false;
            Invalidate();
        }
        private void KryptonSliderButton_MouseUp(object? sender, MouseEventArgs e)
        {
            _mDown = false;

            //Single click?
            if (!_mSingleClick)
            { FireTimer.Stop(); }
            else
            { SliderButtonFire(this, new EventArgs()); }

            Invalidate();
        }

        //Implements IContentValues
        public Image GetImage(PaletteState state)
        {
            return null;
        }
        public Color GetImageTransparentColor(PaletteState state)
        {
            return Color.Empty;
        }
        public string GetLongText()
        {
            return string.Empty;
        }
        public string GetShortText()
        {
            return string.Empty;
        }

        //Krypton Palette
        private void k_palette_BasePaletteChanged(object? sender, EventArgs e)
        {
            Invalidate();
        }
        private void k_palette_BaseRendererChanged(object? sender, EventArgs e)
        {
            Invalidate();
        }
        private void k_palette_PalettePaint(object? sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }

        //Fire Machine Gun
        private void FireTimer_Tick(object? sender, EventArgs e)
        {
            SliderButtonFire?.Invoke(this, new EventArgs());
        }


        //Krypton Events
        private void OnPalettePaint(object? sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }

        private void OnGlobalPaletteChanged(object? sender, EventArgs e)
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
                InitColors();
            }
            Invalidate();

        }

        private void InitColors()
        {
            //Colors
            _mInnerColor = _palette.ColorTable.GripDark;

            // Ignore this color if the palette uses an Office2010-Renderer
            if (_palette.GetRenderer() is RenderOffice2010 or RenderOffice2013 or RenderMicrosoft365)
            {
                _mOuterColor = Color.Transparent;
            }
            else
            {
                _mOuterColor = _palette.ColorTable.GripLight;
            }
        }

    }
}