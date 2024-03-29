﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
        private IContainer components = null;

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
            if (((_palette != null)))
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }
            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            //(6) Create accessor objects for the back, border and content
            m_paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);
            m_paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);
            m_paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            //Set Properties
            BackColor = Color.Transparent;
            Size = new Size(16, 16);

            InitColors();

        }

        //Palette State
        private KryptonManager k_manager = new KryptonManager();
        private PaletteBackInheritRedirect m_paletteBack;
        private PaletteBorderInheritRedirect m_paletteBorder;
        private PaletteContentInheritRedirect m_paletteContent;
        private IDisposable m_mementoContent;
        private IDisposable m_mementoBack1;
        private IDisposable m_mementoBack2;

        private PaletteBase _palette;
        private PaletteRedirect _paletteRedirect;

        //Colors
        private Color m_innerColor = Color.FromArgb(99, 106, 116);
        private Color m_outerColor = Color.FromArgb(236, 236, 236);

        //Declares
        private bool m_highlight = false;
        private bool m_down = false;
        private VisualOrientation m_orientation = VisualOrientation.Top;
        private ButtonStyles m_buttonstyle = ButtonStyles.MinusButton;
        private PaletteBackStyle m_visuallook = PaletteBackStyle.ButtonStandalone;
        private bool m_singleClick = false;

        //Events
        public event SliderButtonFireEventHandler SliderButtonFire;
        public delegate void SliderButtonFireEventHandler(KryptonSliderButton Sender, EventArgs e);

        //Properties
        public bool SingleClick
        {
            get => m_singleClick;
            set
            {
                m_singleClick = value;
                Invalidate();
            }
        }
        public VisualOrientation Orientation
        {
            get => m_orientation;
            set
            {
                if (m_orientation != value)
                {
                    m_orientation = value;
                    PerformLayout();
                    Invalidate();
                }
            }
        }
        public ButtonStyles ButtonStyle
        {
            get => m_buttonstyle;
            set
            {
                m_buttonstyle = value;
                Invalidate();
            }
        }
        public PaletteBackStyle VisualLook
        {
            get => m_visuallook;
            set
            {
                if (m_visuallook != value)
                {
                    m_visuallook = value;
                    Invalidate();
                }
            }
        }
        public int EventFireRate
        {
            get => FireTimer.Interval;
            set
            {
                if (FireTimer.Interval != value & !m_down)
                {
                    FireTimer.Interval = value;
                }
            }
        }

        //ComponentFactory Palette Painting
        protected override void OnPaint(PaintEventArgs e)
        {

            //Define Bounds
            Rectangle ButtonBounds = new Rectangle(0, 0, 16, 16);
            RectangleF ButtonCircleBounds = new RectangleF((float)0, (float)0, (float)15.1, (float)15.1);

            //Smoothing Mode
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            //Paint Base
            base.OnPaint(e);

            if (_palette != null)
            {

                //Get the renderer associated with this palette
                IRenderer Renderer = _palette.GetRenderer();

                //Create the rendering context that is passed into all renderer calls
                using (RenderContext RenderContext = new RenderContext(this, e.Graphics, ButtonBounds, Renderer))
                {

                    // Set the style we want picked up from the base palette
                    m_paletteBack.Style = PaletteBackStyle.HeaderPrimary;


                    //Fill The Space
                    using (GraphicsPath Path = GetButtonPath(ButtonBounds))
                    {
                        // Ask renderer to draw the background
                        m_mementoBack1 = Renderer.RenderStandardBack.DrawBack(RenderContext, ButtonBounds, Path, m_paletteBack, m_orientation, (Enabled ? PaletteState.Normal : PaletteState.Disabled), m_mementoBack1);
                    }

                    // We want the inner part of the control to act like a button, so 
                    // we need to find the correct palette state based on if the mouse 
                    // is over the control if the mouse button is pressed down or not.
                    PaletteState ButtonState = GetButtonState();

                    // Set the style of button we want to draw
                    m_paletteBack.Style = m_visuallook;
                    m_paletteBorder.Style = (PaletteBorderStyle)m_visuallook;
                    m_paletteContent.Style = (PaletteContentStyle)m_visuallook;

                    // Do we need to draw the background?
                    if (m_paletteBack.GetBackDraw(ButtonState) == InheritBool.True)
                    {
                        using (GraphicsPath Path = GetRoundedSquarePath(ButtonCircleBounds))
                        {
                            // Ask renderer to draw the background
                            m_mementoBack2 = Renderer.RenderStandardBack.DrawBack(RenderContext, ButtonBounds, Path, m_paletteBack, m_orientation, ButtonState, m_mementoBack2);
                        }
                    }

                    // Do we need to draw the border?
                    if (m_paletteBorder.GetBorderDraw(ButtonState) == InheritBool.True)
                    {
                        // Now we draw the border of the inner area, also in ButtonStandalone style
                        e.Graphics.DrawEllipse(new Pen(m_paletteBorder.GetBorderColor2(ButtonState)), ButtonCircleBounds);
                    }

                    e.Graphics.SmoothingMode = SmoothingMode.None;

                    //Draw Magnifying Sign
                    switch (m_buttonstyle)
                    {
                        case ButtonStyles.MinusButton:
                            Rectangle MinusOuterBounds = new Rectangle(3, (Height / 2) - 2, 10, 4);
                            Rectangle MinusInnerBounds = new Rectangle(4, (Height / 2) - 1, 8, 2);

                            e.Graphics.FillRectangle(new SolidBrush(m_outerColor), MinusOuterBounds);
                            e.Graphics.FillRectangle(new SolidBrush(m_innerColor), MinusInnerBounds);

                            break;
                        case ButtonStyles.PlusButton:
                            DrawPlusOuter(e.Graphics, m_outerColor);
                            DrawPlusInner(e.Graphics, m_innerColor);
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
                Rectangle ButtonBounds = new Rectangle(0, 0, 16, 16);

                // Get the renderer associated with this palette
                IRenderer Renderer = _palette.GetRenderer();

                // Create a layout context used to allow the renderer to layout the content
                using (ViewLayoutContext ViewContext = new ViewLayoutContext(this, Renderer))
                {

                    // Setup the appropriate style for the content
                    m_paletteContent.Style = (PaletteContentStyle)m_visuallook;

                    // Cleaup resources by disposing of old memento instance
                    if (m_mementoContent != null)
                    {
                        m_mementoContent.Dispose();
                    }

                    // Ask the renderer to work out how the Content values will be layed out and
                    // return a memento object that we cache for use when actually performing painting
                    m_mementoContent = Renderer.RenderStandardContent.LayoutContent(ViewContext, ButtonBounds, m_paletteContent, this, m_orientation, buttonState, false, false);
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
                    _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                    _palette = null;
                }


                KryptonManager.GlobalPaletteChanged -= new EventHandler(OnGlobalPaletteChanged);

                //Dispose Memento Content
                if (m_mementoContent != null)
                {
                    m_mementoContent.Dispose();
                    m_mementoContent = null;
                }

                //Dispose Memento BackGround One
                if (m_mementoBack1 != null)
                {
                    m_mementoBack1.Dispose();
                    m_mementoBack1 = null;
                }

                //Dispose Memento BackGround Two
                if (m_mementoBack2 != null)
                {
                    m_mementoBack2.Dispose();
                    m_mementoBack2 = null;
                }

                if (components != null)
                {
                    components.Dispose();
                }

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
                if (m_down)
                {
                    if (m_highlight)
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
                    if (m_highlight)
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
        private GraphicsPath GetButtonPath(RectangleF Bounds)
        {
            GraphicsPath Path = new GraphicsPath();
            Path.AddEllipse(Bounds);
            return Path;
        }
        private void DrawPlusOuter(Graphics Gfx, Color Fill)
        {
            Gfx.FillRectangle(new SolidBrush(Fill), new Rectangle(3, (Height / 2) - 2, 10, 4));
            Gfx.FillRectangle(new SolidBrush(Fill), new Rectangle((Width / 2) - 2, 3, 4, 10));
        }
        private void DrawPlusInner(Graphics Gfx, Color Fill)
        {
            Gfx.FillRectangle(new SolidBrush(Fill), new Rectangle(4, (Height / 2) - 1, 8, 2));
            Gfx.FillRectangle(new SolidBrush(Fill), new Rectangle((Width / 2) - 1, 4, 2, 8));
        }

        //Key Mouse Events
        private void KryptonSliderButton_MouseDown(object sender, MouseEventArgs e)
        {
            m_down = true;
            //Single click?
            if (!m_singleClick)
            { FireTimer.Start(); }

            Invalidate();
        }
        private void KryptonSliderButton_MouseEnter(object sender, EventArgs e)
        {
            m_highlight = true;
            Invalidate();
        }
        private void KryptonSliderButton_MouseLeave(object sender, EventArgs e)
        {
            m_highlight = false;
            Invalidate();
        }
        private void KryptonSliderButton_MouseUp(object sender, MouseEventArgs e)
        {
            m_down = false;

            //Single click?
            if (!m_singleClick)
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
        private void k_palette_BasePaletteChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void k_palette_BaseRendererChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void k_palette_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }

        //Fire Machine Gun
        private void FireTimer_Tick(object sender, EventArgs e)
        {
            if (SliderButtonFire != null)
            {
                SliderButtonFire(this, new EventArgs());
            }
        }


        //Krypton Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }

        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (((_palette != null)))
            {
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;
            if (((_palette != null)))
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                InitColors();
            }
            Invalidate();

        }

        private void InitColors()
        {
            //Colors
            m_innerColor = _palette.ColorTable.GripDark;

            // Ignore this color if the palette uses an Office2010-Renderer
            if (_palette.GetRenderer() is RenderOffice2010 or RenderOffice2013 or RenderMicrosoft365)
            {
                m_outerColor = Color.Transparent;
            }
            else
            {
                m_outerColor = _palette.ColorTable.GripLight;
            }
        }

    }
}