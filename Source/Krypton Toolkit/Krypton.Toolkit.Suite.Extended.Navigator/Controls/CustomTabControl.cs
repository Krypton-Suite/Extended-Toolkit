#region MIT License
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


// ReSharper disable RedundantOverriddenMember
namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    /// <summary>
    /// Summary description for TabControl.
    /// </summary>
    [ToolboxBitmap(typeof(TabControl)), ToolboxItem(false)] //,
    public class CustomTabControl : TabControl
    {

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        /// 
        #region ... Declarations ...
        private Container? _components;
        private SubClass? _scUpDown = null;
        private ImageList? _leftRightImages = null;
        private const int N_MARGIN = 5;

        private Rectangle _mCloseRect;

        #endregion

        #region ... Properties ...

        [Editor(typeof(TabpageExCollectionEditor), typeof(UITypeEditor))]
        public new TabPageCollection TabPages => base.TabPages;

        private Boolean _preserveTabColour;
        [Browsable(true), Category("Appearance-Extended")]
        public Boolean PreserveTabColour
        {
            get => _preserveTabColour;
            set { _preserveTabColour = value; Invalidate(); }
        }

        private Color _buttonsBackColour = Color.FromArgb(191, 219, 255);
        [Browsable(true), Category("Appearance-Extended")]
        public Color ButtonsBackColour
        {
            get => _buttonsBackColour;
            set { _buttonsBackColour = value; Invalidate(); }
        }

        private Color _buttonsBorderColour = Color.FromArgb(111, 157, 217);
        [Browsable(true), Category("Appearance-Extended")]
        public Color ButtonsBorderColour
        {
            get => _buttonsBorderColour;
            set { _buttonsBorderColour = value; Invalidate(); }
        }

        private Color _borderColour = SystemColors.ControlDark;
        [Browsable(true), Category("Appearance-Extended")]
        public Color BorderColour
        {
            get => _borderColour;
            set { _borderColour = value; Invalidate(); }
        }

        private int _borderWidth = 1;
        [Browsable(false), Category("Appearance-Extended")]
        public int BorderWidth
        {
            get => _borderWidth;
            set { _borderWidth = value; Invalidate(); }
        }

        private int _cornerRoundRadiusWidth = 12;
        [Browsable(true), Category("Appearance-Extended")]
        public int CornerRoundRadiusWidth
        {
            get => _cornerRoundRadiusWidth;
            set { _cornerRoundRadiusWidth = value; Invalidate(); }
        }

        private DrawingMethods.CornerType _cornerType = DrawingMethods.CornerType.Rounded;
        [Browsable(true), Category("Appearance-Extended")]
        public DrawingMethods.CornerType CornerType
        {
            get => _cornerType;
            set { _cornerType = value; Invalidate(); }
        }

        private bool _useExtendedLayout;
        [Browsable(true), Category("Appearance-Extended")]
        public bool UseExtendedLayout
        {
            get => _useExtendedLayout;
            set
            {
                bool result = value;
                if (result)
                {
                    SizeMode = TabSizeMode.Fixed;
                    Alignment = TabAlignment.Right;
                    DrawMode = TabDrawMode.OwnerDrawFixed;
                    ItemSize = new Size(25, 100);
                    Appearance = TabAppearance.Normal;
                }
                else
                {
                    SizeMode = TabSizeMode.Normal;
                    //this.Alignment = TabAlignment.Top;
                    DrawMode = TabDrawMode.OwnerDrawFixed;
                    ItemSize = new Size(77, 25);
                    Multiline = false;
                }

                _useExtendedLayout = value;
            }
        }

        private Color _tabColourHotLight = Color.FromArgb(255, 241, 196);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourHotLight
        {
            get => _tabColourHotLight;
            set { _tabColourHotLight = value; Invalidate(); }
        }

        private Color _tabColourHotDark = Color.FromArgb(255, 215, 83);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourHotDark
        {
            get => _tabColourHotDark;
            set { _tabColourHotDark = value; Invalidate(); }
        }

        private Color _tabColourSelectedLight = Color.FromArgb(255, 229, 196);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourSelectedLight
        {
            get => _tabColourSelectedLight;
            set { _tabColourSelectedLight = value; Invalidate(); }
        }

        private Color _tabColourSelectedDark = Color.FromArgb(254, 182, 93);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourSelectedDark
        {
            get => _tabColourSelectedDark;
            set { _tabColourSelectedDark = value; Invalidate(); }
        }

        private Color _tabColourPressedLight = Color.FromArgb(255, 229, 196);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourPressedLight
        {
            get => _tabColourPressedLight;
            set { _tabColourPressedLight = value; Invalidate(); }
        }

        private Color _tabColourPressedDark = Color.FromArgb(254, 182, 93);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourPressedDark
        {
            get => _tabColourPressedDark;
            set { _tabColourPressedDark = value; Invalidate(); }
        }

        private Color _tabColourDefaultLight = Color.FromArgb(227, 239, 255);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourDefaultLight
        {
            get => _tabColourDefaultLight;
            set { _tabColourDefaultLight = value; Invalidate(); }
        }

        private Color _tabColourDefaultDark = Color.FromArgb(191, 219, 255);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourDefaultDark
        {
            get => _tabColourDefaultDark;
            set { _tabColourDefaultDark = value; Invalidate(); }
        }

        private Color _tabHotForeColour = SystemColors.HotTrack;
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabHotForeColour
        {
            get => _tabHotForeColour;
            set { _tabHotForeColour = value; Invalidate(); }
        }

        private Color _tabSelectedForeColour = SystemColors.Highlight;
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabSelectedForeColour
        {
            get => _tabSelectedForeColour;
            set { _tabSelectedForeColour = value; Invalidate(); }
        }

        private Color _tabForeColour = Color.FromArgb(61, 66, 139);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabForeColour
        {
            get => _tabForeColour;
            set { _tabForeColour = value; Invalidate(); }
        }

        private Color _standardBackColour = SystemColors.Control;
        [Browsable(true), Category("Appearance-Extended")]
        public Color StandardBackColour
        {
            get => _standardBackColour;
            set { _standardBackColour = value; Invalidate(); }
        }

        private int _cornerWidth = 2;
        private int _cornerLeftWidth;
        private int _cornerRightWidth;
        [Browsable(true), Category("Appearance-Extended")]
        public CornWidth CornerWidth
        {
            get => (CornWidth)_cornerWidth;
            set
            {
                _cornerWidth = (int)value;

                switch (_cornerSymmetry)
                {
                    case 0: //both
                        {
                            _cornerLeftWidth = _cornerWidth;
                            _cornerRightWidth = _cornerWidth;
                            break;
                        }
                    case 1: //left
                        {
                            _cornerLeftWidth = 0;
                            _cornerRightWidth = _cornerWidth;
                            break;
                        }
                    case 2: //right
                        {
                            _cornerLeftWidth = _cornerWidth;
                            _cornerRightWidth = 0;
                            break;
                        }
                }
                Invalidate();
            }
        }

        private int _cornerSymmetry;
        [Browsable(true), Category("Appearance-Extended")]
        public CornSymmetry CornerSymmetry
        {
            get => (CornSymmetry)_cornerSymmetry;
            set
            {
                _cornerSymmetry = (int)value;

                switch (_cornerSymmetry)
                {
                    case 0: //both
                        {
                            _cornerLeftWidth = _cornerWidth;
                            _cornerRightWidth = _cornerWidth;
                            break;
                        }
                    case 1: //left
                        {
                            _cornerLeftWidth = 0;
                            _cornerRightWidth = _cornerWidth;
                            break;
                        }
                    case 2: //right
                        {
                            _cornerLeftWidth = _cornerWidth;
                            _cornerRightWidth = 0;
                            break;
                        }
                }
                Invalidate();
            }
        }

        private int _allowSelectedTabHighSize;
        private Boolean _allowSelectedTabHigh;
        [Browsable(true), Category("Appearance-Extended")]
        public Boolean AllowSelectedTabHigh
        {
            get => _allowSelectedTabHigh;
            set { _allowSelectedTabHigh = value; Invalidate(); }
        }

        private Boolean _allowCloseButton;
        [Browsable(true), Category("Appearance-Extended")]
        public Boolean AllowCloseButton
        {
            get => _allowCloseButton;
            set { _allowCloseButton = value; Invalidate(); }
        }

        private Boolean _allowInternalNavigatorButtons;
        private Boolean _allowNavigatorButtons;
        [Browsable(true), Category("Appearance-Extended")]
        public Boolean AllowNavigatorButtons
        {
            get => _allowNavigatorButtons;
            set { _allowNavigatorButtons = value; Invalidate(); }
        }

        private Boolean _allowContextButton = true;
        [Browsable(true), Category("Appearance-Extended")]
        public Boolean AllowContextButton
        {
            get => _allowContextButton;
            set { _allowContextButton = value; Invalidate(); }
        }

        #endregion

        #region ... enum ...
        public enum CornWidth
        {
            Null = 0,
            Thin = 2,
            Medium = 3,
            Thick = 4,
            Max = 6,
            Overflow = 8
        };

        public enum CornSymmetry
        {
            Both = 0,
            Right = 1,
            Left = 2
        };


        #endregion

        #region ... Constructor ...

        public CustomTabControl()
        {

            // double buffering
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();


            _scroller.ScrollLeft += Scroller_ScrollLeft;
            _scroller.ScrollRight += Scroller_ScrollRight;
            _scroller.TabClose += Scroller_TabClose;
            _scroller.ContextualMenu += Scroller_ContextMenuButton;

            InitColors();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// 

        #endregion

        #region ... Init Colors ...


        private void InitColors()
        {

            HotTrack = true;

            StandardBackColour = Color.FromArgb(191, 219, 255);
            BorderColour = Color.FromArgb(111, 157, 217);


            ButtonsBackColour = Color.FromArgb(191, 219, 255);
            ButtonsBorderColour = Color.FromArgb(111, 157, 217);

            TabColourHotDark = Color.FromArgb(255, 213, 77); ; // Color.Gold; // 
            TabColourHotLight = Color.FromArgb(255, 239, 177); // Color.LightGoldenrodYellow; // 

            TabColourSelectedDark = Color.FromArgb(235, 122, 5);// _paletteBack.GetBackColor1(PaletteState.Pressed); // Color.FromArgb(252, 143, 61);//  
            TabColourSelectedLight = Color.FromArgb(254, 195, 108);//= _paletteBack.GetBackColor2(PaletteState.Pressed); // Color.FromArgb(255, 224, 192);// 

            TabColourPressedDark = Color.FromArgb(232, 142, 49);// _paletteBack.GetBackColor1(PaletteState.Pressed); // Color.FromArgb(252, 143, 61);//  
            TabColourPressedLight = Color.FromArgb(252, 207, 100);//= _paletteBack.GetBackColor2(PaletteState.Pressed); // Color.FromArgb(255, 224, 192);// 

            if ((_preserveTabColour == false)) //to avoid black text on black tab
            {
                TabForeColour = Color.FromArgb(21, 66, 139);
            }
            else
            {
                TabForeColour = Color.FromArgb(21, 66, 139);
            }

            TabHotForeColour = Color.FromArgb(21, 66, 139);
            TabSelectedForeColour = Color.FromArgb(21, 66, 139);
            TabColourDefaultDark = Color.FromArgb(191, 219, 255);
            TabColourDefaultLight = Color.FromArgb(227, 239, 255);

            Invalidate();

        }

        #endregion

        #region ... overridden methods ...

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            //before selecting the page, check if the close button hevers a tap being 
            //selected, if so, do not process the base event.
            try
            {
                if (!e.TabPage.ClientRectangle.Contains(_mCloseRect))
                { base.OnSelecting(e); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                base.OnSelecting(e);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Graphics g = CreateGraphics();
            for (int i = 0; i < TabCount; i++)
            {
                if (GetTabRect(i).Contains(e.X, e.Y))
                {
                    if (HotTrack)
                    {
                        //DrawTab(g, this.TabPages[i], i, true);
                        TabPages[i].Tag = true;
                    }
                }
                else
                {
                    //DrawTab(g, this.TabPages[i], i, false);
                    TabPages[i].Tag = false;
                }
            }
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            for (int i = 0; i < TabCount; i++)
            {
                TabPages[i].Tag = false;
            }
            Invalidate();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            Point mouse;
            try
            {
                mouse = e.Location;
                if (_mCloseRect.Contains(mouse))
                {
                    Controls.RemoveAt(SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //msgError(ex.Message + "\n\nslidingTabControl_MouseClick");
            }

            base.OnMouseClick(e);
        }
        private void this_MouseClick(object sender, MouseEventArgs e)
        {
            Point mouse;
            try
            {
                mouse = e.Location;
                if (sender.Equals(Parent))
                {
                    mouse.Y = e.Location.Y - Location.Y;
                    mouse.X = e.Location.X - Location.X;
                }
                if (_mCloseRect.Contains(mouse))
                {
                    Controls.RemoveAt(SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //msgError(ex.Message + "\n\nslidingTabControl_MouseClick");
            }

        }

        private void this_ParentChanged(object sender, EventArgs e)
        {
            try
            {
                Parent.MouseClick += this_MouseClick;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        protected override bool ProcessMnemonic(char charCode)
        {

            foreach (TabPage p in TabPages)
            {
                if (IsMnemonic(charCode, p.Text))
                {
                    SelectedTab = p;
                    Focus();
                    return true;
                }
            }
            return base.ProcessMnemonic(charCode);
        }

        //bool FlagControl = false;

        private void FlatTabControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Menu)
            {
                //FlagControl = true;
            }
            else
            {
                //FlagControl = false;
            }
            UpdateStyles();
        }


        protected override void OnPaint(PaintEventArgs e)

        {
            base.OnPaint(e);

            //Draw Controls
            DrawControl(e.Graphics);

        }

        #endregion

        #region ... Draw Methods ...

        internal void DrawControl(Graphics g)
        {
            if (!Visible)
            {
                return;
            }

            Rectangle tabControlArea = ClientRectangle;
            Rectangle tabArea = DisplayRectangle;

            //----------------------------
            // fill client area
            Brush br = new SolidBrush(_standardBackColour); //(SystemColors.Control); UPDATED
            g.FillRectangle(br, tabControlArea);
            br.Dispose();
            //----------------------------

            //----------------------------
            // draw border
            int nDelta = SystemInformation.Border3DSize.Width;

            Pen border = new Pen(_borderColour, _borderWidth);
            tabArea.Inflate(nDelta, nDelta);
            g.DrawRectangle(border, tabArea);
            border.Dispose();
            //----------------------------


            //----------------------------
            // clip region for drawing tabs
            Region rsaved = g.Clip;
            Rectangle rreg;

            int nWidth = tabArea.Width + N_MARGIN;

            // exclude customcontrol for painting
            nWidth -= _scroller.Width;


            //if top or bottom leave a blank space for Close button or navigator
            if ((Alignment == TabAlignment.Top) || (Alignment == TabAlignment.Bottom))
            {
                rreg = new Rectangle(tabArea.Left, tabControlArea.Top, nWidth - N_MARGIN, tabControlArea.Height);
            }
            else
            {
                rreg = ClientRectangle;
            }

            g.SetClip(rreg);

            // draw tabs
            for (int i = 0; i < TabCount; i++)
                DrawTab(g, TabPages[i], i);

            g.Clip = rsaved;
            //----------------------------


            //----------------------------
            // draw background to cover flat border areas
            if (SelectedTab != null)
            {
                TabPage tabPage = SelectedTab;
                Color color = tabPage.BackColor;
                border = new Pen(color);

                tabArea.Offset(1, 1);
                tabArea.Width -= 2;
                tabArea.Height -= 2;

                g.DrawRectangle(border, tabArea);
                tabArea.Width -= 1;
                tabArea.Height -= 1;
                g.DrawRectangle(border, tabArea);

                border.Dispose();
            }
            //----------------------------
        }

        internal void DrawTab(Graphics g, TabPage tabPage, int nIndex)
        {
            Rectangle recBounds = GetTabRect(nIndex);
            RectangleF tabTextArea = GetTabRect(nIndex);


            //debug --> to be fixed
            if (recBounds.Width == 0)
            {
                recBounds.Width = 50;
            }

            if (tabTextArea.Width == 0)
            {
                tabTextArea.Width = 50;
            }

            if (recBounds.Height == 0)
            {
                recBounds.Width = 22;
            }

            if (tabTextArea.Height == 0)
            {
                tabTextArea.Width = 22;
            }

            bool bSelected = (SelectedIndex == nIndex);
            bool bHot = false;

            if (tabPage.Tag != null)
            {
                bHot = (bool)tabPage.Tag;
            }



            //for buttons appearance
            if (Appearance != TabAppearance.Normal)
            {
                _cornerLeftWidth = 0;
                _cornerRightWidth = 0;
                _cornerWidth = 0;
                _cornerRoundRadiusWidth = 2;
                Alignment = TabAlignment.Top;

            }

            //maximum radius
            if (_cornerRoundRadiusWidth > 32)
            {
                _cornerRoundRadiusWidth = 32;
            }


            //Tab Hedaer Status
            DrawingMethods.TabHeaderStatus status = DrawingMethods.TabHeaderStatus.Normal;
            if (_preserveTabColour)
            {
                status = DrawingMethods.TabHeaderStatus.NormalPreserve;
            }

            if (bHot)
            {
                status = DrawingMethods.TabHeaderStatus.Hot;
            }


            //bool bHotselected = false;

            if ((bSelected) && (!bHot))
            {
                status = DrawingMethods.TabHeaderStatus.Selected;
            }
            else if ((bSelected) && (bHot))
            {
                status = DrawingMethods.TabHeaderStatus.HotSelected;
                //bHotselected = true;
            }

            //Selected tab has to be highter?
            if (!_allowSelectedTabHigh)
            { _allowSelectedTabHighSize = 0; }
            else
            { _allowSelectedTabHighSize = 2; }

            //AC.ExtendedRenderer.Toolkit.Drawing.DrawingMethods.VisualOrientation visualorientation;

            //Set visual orientation for Krypton Renderer
            if (Alignment == TabAlignment.Top)
            {
                //visualorientation = DrawingMethods.VisualOrientation.Top;
            }
            else if (Alignment == TabAlignment.Right)
            {
                //visualorientation = DrawingMethods.VisualOrientation.Right;
            }
            else if (Alignment == TabAlignment.Left)
            {
                //visualorientation = DrawingMethods.VisualOrientation.Left;
            }
            else
            {
                //visualorientation = DrawingMethods.VisualOrientation.Bottom;
            }

            //----------------------------
            // fill this tab with background color
            Brush br = new SolidBrush(tabPage.BackColor);

            //Color for Border Clearing
            Color clearBorderColor = new Color();


            //Font for header
            Font fnt = Font;

            //draw contents
            switch (_cornerType)
            {
                case DrawingMethods.CornerType.Squared:

                    //Create tab Header Points (Sqared)
                    Point[] pt = DrawingMethods.GetTabSquaredPoints(recBounds, _cornerWidth, Alignment, _cornerLeftWidth, _cornerRightWidth, Appearance, status, _allowSelectedTabHighSize, false);
                    Point[] ptBorder = DrawingMethods.GetTabSquaredPoints(recBounds, _cornerWidth, Alignment, _cornerLeftWidth, _cornerRightWidth, Appearance, status, _allowSelectedTabHighSize, true);


                    switch (status)
                    {
                        case DrawingMethods.TabHeaderStatus.Selected:
                            if (Appearance == TabAppearance.Normal)
                            {
                                DrawingMethods.DrawTabHeader(g, pt, recBounds, tabPage.BackColor, _tabColourSelectedDark, tabPage.BackColor, 90, Alignment, _useExtendedLayout, status, false);
                                clearBorderColor = _tabColourSelectedLight;
                            }
                            else
                            {
                                DrawingMethods.DrawTabHeader(g, pt, recBounds, _tabColourSelectedLight, _tabColourSelectedDark, tabPage.BackColor, 90, Alignment, _useExtendedLayout, status, false);
                                clearBorderColor = _tabColourPressedLight;
                            }
                            fnt = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
                            br = new SolidBrush(_tabSelectedForeColour);

                            break;

                        case DrawingMethods.TabHeaderStatus.HotSelected:
                            if (Appearance == TabAppearance.Normal)
                            {
                                DrawingMethods.DrawTabHeader(g, pt, recBounds, tabPage.BackColor, _tabColourPressedDark, tabPage.BackColor, 90, Alignment, _useExtendedLayout, status, false);
                                clearBorderColor = _tabColourPressedLight;
                            }
                            else
                            {
                                DrawingMethods.DrawTabHeader(g, pt, recBounds, _tabColourPressedLight, _tabColourPressedDark, _tabColourPressedLight, 90, Alignment, _useExtendedLayout, status, false);
                                clearBorderColor = _tabColourPressedLight;
                            }
                            fnt = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
                            br = new SolidBrush(_tabSelectedForeColour);
                            clearBorderColor = _tabColourPressedLight;
                            break;

                        case DrawingMethods.TabHeaderStatus.Hot:
                            DrawingMethods.DrawTabHeader(g, pt, recBounds, _tabColourHotLight, _tabColourHotDark, DrawingMethods.GetLighterColour(_tabColourHotLight), 90, Alignment, _useExtendedLayout, status, false);
                            br = new SolidBrush(_tabHotForeColour);
                            clearBorderColor = _tabColourHotDark;
                            break;

                        case DrawingMethods.TabHeaderStatus.Normal:
                            DrawingMethods.DrawTabHeader(g, pt, recBounds, _tabColourDefaultLight, _tabColourDefaultDark, _tabColourDefaultLight, 90, Alignment, _useExtendedLayout, status, false);
                            br = new SolidBrush(_tabForeColour);
                            clearBorderColor = _tabColourDefaultDark;
                            break;

                        case DrawingMethods.TabHeaderStatus.NormalPreserve:
                            DrawingMethods.DrawTabHeader(g, pt, recBounds, Color.White, DrawingMethods.GetModifiedColour(tabPage.BackColor, -20, 7, 0), tabPage.BackColor, 90, Alignment, _useExtendedLayout, status, true);
                            br = new SolidBrush(_tabForeColour);
                            clearBorderColor = Color.White;
                            break;
                    }
                    // draw border
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.DrawPolygon(new Pen(clearBorderColor, 1), ptBorder);
                    g.DrawPolygon(new Pen(_borderColour, _borderWidth), pt);
                    break;

                case DrawingMethods.CornerType.Rounded:

                    GraphicsPath path = DrawingMethods.GetTabRoundedPath(recBounds, _cornerRoundRadiusWidth, Alignment, false, status, Appearance, _allowSelectedTabHighSize);
                    GraphicsPath pathBorder = DrawingMethods.GetTabRoundedPath(recBounds, _cornerRoundRadiusWidth, Alignment, true, status, Appearance, _allowSelectedTabHighSize);
                    if (Appearance != TabAppearance.Normal)
                    {
                        path = DrawingMethods.GetRoundedSquarePath(recBounds, 8);
                        Rectangle innerBorder = recBounds;
                        innerBorder.Offset(1, 1);
                        innerBorder.Height -= 2;
                        innerBorder.Width -= 2;
                        pathBorder = DrawingMethods.GetRoundedSquarePath(innerBorder, 8);

                    }

                    switch (status)
                    {
                        case DrawingMethods.TabHeaderStatus.Selected:
                            if (Appearance == TabAppearance.Normal)
                            {
                                DrawingMethods.DrawTabHeader(g, path, recBounds, tabPage.BackColor, _tabColourSelectedDark, tabPage.BackColor, 90, Alignment, _useExtendedLayout, status, false);
                                clearBorderColor = _tabColourSelectedLight;
                            }
                            else
                            {
                                DrawingMethods.DrawTabHeader(g, path, recBounds, _tabColourSelectedLight, _tabColourSelectedDark, tabPage.BackColor, 90, Alignment, _useExtendedLayout, status, false);
                                clearBorderColor = _tabColourPressedLight;
                            }
                            fnt = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
                            br = new SolidBrush(_tabSelectedForeColour);

                            break;

                        case DrawingMethods.TabHeaderStatus.HotSelected:
                            if (Appearance == TabAppearance.Normal)
                            {
                                DrawingMethods.DrawTabHeader(g, path, recBounds, tabPage.BackColor, _tabColourPressedDark, tabPage.BackColor, 90, Alignment, _useExtendedLayout, status, false);
                                clearBorderColor = _tabColourPressedLight;
                            }
                            else
                            {
                                DrawingMethods.DrawTabHeader(g, path, recBounds, _tabColourPressedLight, _tabColourPressedDark, _tabColourPressedLight, 90, Alignment, _useExtendedLayout, status, false);
                                clearBorderColor = _tabColourPressedLight;
                            }
                            fnt = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
                            br = new SolidBrush(_tabSelectedForeColour);

                            break;

                        case DrawingMethods.TabHeaderStatus.Hot:
                            DrawingMethods.DrawTabHeader(g, path, recBounds, _tabColourHotLight, _tabColourHotDark, DrawingMethods.GetLighterColour(_tabColourHotLight), 90, Alignment, _useExtendedLayout, status, false);
                            br = new SolidBrush(_tabHotForeColour);
                            clearBorderColor = _tabColourHotDark;
                            break;

                        case DrawingMethods.TabHeaderStatus.Normal:
                            DrawingMethods.DrawTabHeader(g, path, recBounds, _tabColourDefaultLight, _tabColourDefaultDark, _tabColourDefaultLight, 90, Alignment, _useExtendedLayout, status, false);
                            br = new SolidBrush(_tabForeColour);
                            clearBorderColor = _tabColourDefaultDark;
                            break;

                        case DrawingMethods.TabHeaderStatus.NormalPreserve:
                            DrawingMethods.DrawTabHeader(g, path, recBounds, Color.White, DrawingMethods.GetModifiedColour(tabPage.BackColor, -20, 7, 0), tabPage.BackColor, 90, Alignment, _useExtendedLayout, status, true);
                            br = new SolidBrush(_tabForeColour);
                            clearBorderColor = Color.White;
                            break;
                    }


                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.DrawPath(new Pen(clearBorderColor, 1), pathBorder);
                    g.DrawPath(new Pen(_borderColour, _borderWidth), path);


                    path.Dispose();
                    /*experimental
					PaletteState buttonState = PaletteState.Pressed;

					switch (Status)
					{
						case DrawingMethods.TabHeaderStatus.HotSelected:
							buttonState = PaletteState.CheckedTracking;
							fnt = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
							br = new SolidBrush(_tabSelectedForeColor);
							break;

						case DrawingMethods.TabHeaderStatus.Selected:
							buttonState = PaletteState.Pressed;
							fnt = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
							br = new SolidBrush(_tabSelectedForeColor);
							break;

						case DrawingMethods.TabHeaderStatus.Normal:
							buttonState = PaletteState.Normal;
							br = new SolidBrush(_tabForeColor);
							break;

						case DrawingMethods.TabHeaderStatus.NormalPreserve:
							buttonState = PaletteState.Normal;
							br = new SolidBrush(_tabForeColor);
							break;

						case DrawingMethods.TabHeaderStatus.Hot:
							buttonState = PaletteState.Tracking;
							br = new SolidBrush(_tabHotForeColor);
							break;
					}

					_paletteBack.Style = PaletteBackStyle.ButtonStandalone;
					IRenderer renderer = _palette.GetRenderer();
					// Create the rendering context that is passed into all renderer calls
					using (RenderContext renderContext = new RenderContext(this, g, recBounds, renderer))
					{
						// Set the style of button we want to draw
						_paletteBack.Style = PaletteBackStyle.ButtonStandalone;
						_paletteBorder.Style = PaletteBorderStyle.ButtonStandalone;
						_paletteContent.Style = PaletteContentStyle.ButtonStandalone;

						// Do we need to draw the background?
						if (_paletteBack.GetBackDraw(buttonState) == InheritBool.True)
						{
							using (GraphicsPath path = DrawingMethods.GetTabRoundedPath(recBounds, _roundRadiusWidth, Alignment))
							{
								// Ask renderer to draw the background
								//_mementoBack2 = renderer.RenderStandardBack.DrawBack(renderContext, recBounds, path, _paletteBack, visualorientation, buttonState, _mementoBack2);

								g.FillPath(DrawingMethods.GetBlendBrush(recBounds,_tabColorDefaultLight,_tabColorDefaultDark,90F),path);

								//renderer.RenderStandardBorder.DrawBorder(renderContext, recBounds, _paletteBorder, visualorientation, buttonState);
							}
						}
						g.SmoothingMode = SmoothingMode.AntiAlias;
						Rectangle rct = recBounds;
						g.DrawPath(new Pen(_borderColor, _borderWidth), DrawingMethods.GetTabRoundedPath(rct, _roundRadiusWidth, Alignment));

					}*/
                    break;
            }

            //----------------------------

            if (((status == DrawingMethods.TabHeaderStatus.Selected) || (status == DrawingMethods.TabHeaderStatus.HotSelected)) && (Appearance == TabAppearance.Normal))
            {
                //----------------------------
                // clear bottom lines
                //Pen pen = new Pen(ClearBorderColor);
                Pen pen = new Pen(tabPage.BackColor);

                DrawingMethods.ClearTabSelectedBottomLine(g, recBounds, pen, Alignment);

                pen.Dispose();
                //----------------------------
            }
            //----------------------------

            //----------------------------
            // draw tab's icon
            if (ImageList != null && (tabPage.ImageIndex >= 0) && (ImageList != null) && (ImageList.Images[tabPage.ImageIndex] != null))
            {
                int nLeftMargin = 8;
                int nRightMargin = 2;

                Image img = ImageList.Images[tabPage.ImageIndex];

                Rectangle rimage = new Rectangle(recBounds.X + nLeftMargin, recBounds.Y + 1, img.Width, img.Height);

                // adjust rectangles
                float nAdj = (nLeftMargin + img.Width + nRightMargin);

                // adjust rectangles
                if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom)
                {
                    nAdj = (nLeftMargin + img.Width + nRightMargin);

                    rimage.Y += (recBounds.Height - img.Height) / 2;
                    tabTextArea.X += nAdj;
                    tabTextArea.Width -= nAdj;
                }
                else
                {
                    if (!_useExtendedLayout)
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        rimage.X -= 5;
                    }
                    //rimage.X += (recBounds.Width - img.Width) / 2;

                    rimage.Y += 3;

                    nAdj = (float)(10 + img.Height);
                    tabTextArea.Y += img.Height;
                    tabTextArea.Height -= img.Height;
                }

                // draw icon
                g.DrawImage(img, rimage);
            }
            //no image
            else
            {
                if (_useExtendedLayout)
                {
                    tabTextArea.Y += 16;
                    tabTextArea.Height -= 16;
                }
            }
            //----------------------------

            //----------------------------
            // draw string
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            //rtl
            if (RightToLeft == RightToLeft.Yes)
            {
                stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            }

            //Disabled
            if (!Enabled)
            {
                br = new SolidBrush(SystemColors.GrayText);
            }


            if (Alignment == TabAlignment.Right || Alignment == TabAlignment.Left)
            {
                //not ExtendedLayout
                if (_useExtendedLayout == false)
                {
                    stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                    tabTextArea.Offset(-3, -5);
                }
                else
                //Extended Layout
                {
                    tabTextArea.Height = tabTextArea.Height + 8;
                    tabTextArea.Offset(4, -12);
                    stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                    stringFormat.Trimming = StringTrimming.EllipsisCharacter;
                }
            }
            else
            {
                tabTextArea.Offset(-5, 0);
            }

            //use AntiAlias
            if (Utility.IsVista())
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            }
            else
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            }

            g.DrawString(tabPage.Text, fnt, br, tabTextArea, stringFormat);
            //----------------------------


            br.Dispose();
        }

        internal void DrawIcons(Graphics g)
        {
            if ((_leftRightImages == null) || (_leftRightImages.Images.Count != 4))
            {
                return;
            }

            //----------------------------
            // calc positions
            Rectangle tabControlArea = ClientRectangle;

            Rectangle r0 = new Rectangle();
            if (_scUpDown != null)
            {
                WIN32.GetClientRect(_scUpDown.Handle, ref r0);
            }

            //paint backcolor
            Brush br = new SolidBrush(_buttonsBackColour);
            r0.Width = r0.Width - 1;
            g.FillRectangle(br, r0);
            br.Dispose();

            //paint border
            Pen border = new Pen(_buttonsBorderColour);
            Rectangle rborder = r0;
            rborder.Height = rborder.Height - 1;
            rborder.Width = rborder.Width - 0;
            g.DrawRectangle(border, rborder);
            border.Dispose();


            int nMiddle = (r0.Width / 2);
            int nTop = (r0.Height - 16) / 2;
            int nLeft = (nMiddle - 16) / 2;

            Rectangle r1 = new Rectangle(nLeft, nTop, 16, 16);
            Rectangle r2 = new Rectangle(nMiddle + nLeft, nTop, 16, 16);
            //----------------------------

            //----------------------------
            // draw buttons
            Image? img = _leftRightImages.Images[1];
            if (img != null)
            {
                if (TabCount > 0)
                {
                    Rectangle r3 = GetTabRect(0);
                    if (r3.Left < tabControlArea.Left)
                    {
                        g.DrawImage(img, r1);
                    }
                    else
                    {
                        img = _leftRightImages.Images[3];
                        if (img != null)
                        {
                            g.DrawImage(img, r1);
                        }
                    }
                }
            }

            img = _leftRightImages.Images[0];
            if (img != null)
            {
                if (TabCount > 0)
                {
                    Rectangle r3 = GetTabRect(TabCount - 1);
                    if (r3.Right > (tabControlArea.Width - r0.Width))
                    {
                        g.DrawImage(img, r2);
                    }
                    else
                    {
                        img = _leftRightImages.Images[2];
                        if (img != null)
                        {
                            g.DrawImage(img, r2);
                        }
                    }
                }
            }
            Invalidate();
            //----------------------------
        }
        #endregion

        #region ... Component Designer generated code (Init and Dispose) ....
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _components = new Container();
        }

        //TabControl overrides dispose to clean up the component list.
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

                if (_upDown != null)
                {
                    _upDown.ReleaseHandle();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region ... TabpageExCollectionEditor ...

        internal class TabpageExCollectionEditor : CollectionEditor
        {
            public TabpageExCollectionEditor(Type type) : base(type)
            {
            }

            protected override Type CreateCollectionItemType()
            {
                return typeof(TabPage);
            }
        }

        #endregion

        #region ... Overidden WndProc / Custom Scroller ...
        private NativeUpDown? _upDown;
        private TabScroller _scroller = new TabScroller();
        private Point _pt;

        private int ScrollPosition
        {
            get
            {
                int multiplier = -1;
                Rectangle tabRect;
                do
                {
                    tabRect = GetTabRect(multiplier + 1);
                    multiplier++;
                }
                while (tabRect.Left < 0 && multiplier < TabCount);
                return multiplier;
            }
        }


        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WIN32.WM_PARENTNOTIFY)
            {
                if ((ushort)(m.WParam.ToInt32() & 0xFFFF) == WIN32.WM_CREATE)
                {
                    System.Text.StringBuilder windowName = new System.Text.StringBuilder(16);
                    WIN32.RealGetWindowClass(m.LParam, windowName, 16);
                    if (windowName.ToString() == "msctls_updown32")

                    {
                        //unhook the existing updown control as it will be recreated if 
                        //the tabcontrol is recreated (alignment, visible changed etc..)
                        if (_upDown != null)
                        {
                            _upDown.ReleaseHandle();
                            //Scroller.LeftScroller.Enabled = true;
                            //Scroller.RightScroller.Enabled = true;
                        }
                        else
                        {
                            //Scroller.LeftScroller.Enabled = false;
                            //Scroller.RightScroller.Enabled = false;
                        }
                        //and hook it.
                        _upDown = new NativeUpDown();
                        _upDown.AssignHandle(m.LParam);
                    }
                }
            }
            base.WndProc(ref m);
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            //if (this.Multiline == false)
            //{
            //Scroller.Font = new Font("Marlett", this.Font.Size, FontStyle.Regular, GraphicsUnit.Pixel, this.Font.GdiCharSet);
            WIN32.SetParent(_scroller.Handle, Handle);
            //}
            OnFontChanged(EventArgs.Empty);
        }


        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            //this.Scroller.Font = new Font("Marlett", this.Font.SizeInPoints, FontStyle.Regular, GraphicsUnit.Point);
            _scroller.Height = 23;// this.ItemSize.Height;
            _scroller.Width = 92;// this.ItemSize.Height * 3;

            OnResize(EventArgs.Empty);
        }

        private bool IsFirstTabHidden()
        {
            float firstPagePosition = 0;
            bool display = false;

            //there are tab pages?
            if (TabCount > 0)
            {
                firstPagePosition = GetTabRect(0).Left;
                //not visible?
                if ((firstPagePosition < 0))
                {
                    display = true;
                }
                else
                {
                    display = false;
                }
            }
            return display;
        }

        private bool IsLastTabHidden()
        {
            bool display = false;

            //there are tab pages?
            if (TabCount > 0)
            {
                //visible?
                if ((GetTabRect(TabCount - 1).Right > _scroller.Left))
                {
                    display = true;
                }
                else
                {
                    display = false;
                }
            }
            return display;
        }


        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            //show Close button?
            if (_allowCloseButton)
            {
                _scroller.CloseButton.Visible = true;
            }
            else
            {
                _scroller.CloseButton.Visible = false;
            }

            //show Context button?
            if (_allowContextButton)
            {
                _scroller.ContextMenuButton.Visible = true;
            }
            else
            {
                _scroller.ContextMenuButton.Visible = false;
            }

            //test on tab pages 
            if ((!IsLastTabHidden()) && (!IsFirstTabHidden()))
            {
                _allowInternalNavigatorButtons = false;
            }
            else
            {
                _allowInternalNavigatorButtons = true;
            }
            //show navigator buttons?
            if ((_allowNavigatorButtons) && (_allowInternalNavigatorButtons))
            {
                _scroller.LeftScroller.Visible = true;
                _scroller.RightScroller.Visible = true;
            }
            else
            {
                _scroller.LeftScroller.Visible = false;
                _scroller.RightScroller.Visible = false;
            }

            //multiline, no navigator
            if (Multiline)
            {
                _allowNavigatorButtons = false;
            }

            //which buttons to display
            if (_allowCloseButton)
            {
                if ((_allowNavigatorButtons) && (_allowInternalNavigatorButtons))
                {
                    if (_allowContextButton)
                    {
                        //navigator and close and context
                        _scroller.Width = 92;
                    }
                    else
                    {
                        //navigator and close
                        _scroller.Width = 69;
                    }

                }
                else
                {
                    if (_allowContextButton)
                    {
                        //only close and context
                        _scroller.Width = 46;
                    }
                    else
                    {
                        //close
                        _scroller.Width = 23;
                    }

                }
            }
            else
            {
                if ((_allowNavigatorButtons) && (_allowInternalNavigatorButtons))
                {
                    if (_allowContextButton)
                    {
                        //navigator and context
                        _scroller.Width = 69;
                    }
                    else
                    {
                        //navigator
                        _scroller.Width = 46;
                    }

                }
                else
                {
                    if (_allowContextButton)
                    {
                        //context
                        _scroller.Width = 23;
                    }
                    else
                    {
                        //nothing
                        _scroller.Width = 0;
                    }

                }
            }

            if (Alignment == TabAlignment.Top)
            {
                _scroller.Location = new Point(Width - _scroller.Width - 1, 2);
            }
            else if (Alignment == TabAlignment.Bottom)
            {
                _scroller.Location = new Point(Width - _scroller.Width - 1, Height - _scroller.Height - 1);
            }
            else if (Alignment == TabAlignment.Right)
            {
                _scroller.Location = new Point(Width - _scroller.Width - 1, Height - _scroller.Height - 1);
            }
            else if (Alignment == TabAlignment.Left)
            {
                _scroller.Location = new Point(2, Height - _scroller.Height - 1);
            }


            //For Context Menu
            _pt = new Point(_scroller.Right - 23, _scroller.Bottom);

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(true);
            //if (this.Multiline)
            //    return;
            if (Alignment == TabAlignment.Top)
            {
                _scroller.Location = new Point(Width - _scroller.Width - 1, 2);
            }
            else
            {
                _scroller.Location = new Point(Width - _scroller.Width, Height - _scroller.Height - 1);
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
        }

        private void ToolstripItemEvent(object sender, EventArgs e)
        {
            ToolStripMenuItem tsi = (ToolStripMenuItem)sender;
            //tsi.Checked = true;
            TabPage tp = (TabPage)tsi.Tag;
            SelectedTab = tp;
            Invalidate();
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);

        }
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
        }

        private void Scroller_ScrollLeft(Object sender, EventArgs e)
        {
            if (TabCount == 0)
            {
                return;
            }

            int scrollPos = Math.Max(0, (ScrollPosition - 1) * 0x10000);
            WIN32.SendMessage(Handle, WIN32.WM_HSCROLL, (IntPtr)(scrollPos | 0x4), IntPtr.Zero);
            WIN32.SendMessage(Handle, WIN32.WM_HSCROLL, (IntPtr)(scrollPos | 0x8), IntPtr.Zero);
            Invalidate();
        }


        private void Scroller_ScrollRight(Object sender, EventArgs e)
        {
            if (TabCount == 0)
            {
                return;
            }

            if (GetTabRect(TabCount - 1).Right <= _scroller.Left)
            {
                return;
            }

            int scrollPos = Math.Max(0, (ScrollPosition + 1) * 0x10000);
            WIN32.SendMessage(Handle, WIN32.WM_HSCROLL, (IntPtr)(scrollPos | 0x4), IntPtr.Zero);
            WIN32.SendMessage(Handle, WIN32.WM_HSCROLL, (IntPtr)(scrollPos | 0x8), IntPtr.Zero);
            Invalidate();
        }


        private void Scroller_TabClose(Object sender, EventArgs e)
        {
            if (SelectedTab != null)
            {
                TabPages.Remove(SelectedTab);
            }
        }

        private void Scroller_ContextMenuButton(Object sender, EventArgs e)
        {
            _scroller.ContextMenuStrip1.DropShadowEnabled = true;

            //clear items
            _scroller.ContextMenuStrip1.Items.Clear();

            //Counter 
            int i = 0;
            //Add Items
            foreach (TabPage tp in TabPages)
            {
                try
                {
                    //TabPage tp = (TabPage)e.Control;
                    ToolStripMenuItem item;
                    if ((ImageList != null) && (tp.ImageIndex >= 0))
                    {
                        item = new ToolStripMenuItem(tp.Text, ImageList.Images[tp.ImageIndex], ToolstripItemEvent);
                    }
                    else
                    {
                        item = new ToolStripMenuItem(tp.Text, null, ToolstripItemEvent);
                    }
                    item.Tag = tp;
                    _scroller.ContextMenuStrip1.Items.Add(item);


                    //show checked
                    if (SelectedIndex == i)
                    {
                        item.Checked = true;
                    }
                }
                catch
                {
                    //silent
                }
                i++;
            }



            //show Menu
            _scroller.ContextMenuStrip1.Show(PointToScreen(_pt));

        }

        #endregion


        #region   ... Custom Scroller with Close Button, ContextMenu ...

        internal class TabScroller : Control
        {

            #region   Windows Form Designer generated code

            public TabScroller()
                : base()
            {
                this.SetStyle(ControlStyles.DoubleBuffer, true);
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                UpdateStyles();

                //This call is required by the Windows Form Designer.
                InitializeComponent();

                //Add any initialization after the InitializeComponent() call
                //this.BackColor = Color.Transparent;

            }


            //TabScroller overrides dispose to clean up the component list.
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (components != null)
                    {
                        components.Dispose();
                    }
                }
                base.Dispose(disposing);
            }


            //Required by the Windows Form Designer
            private IContainer? components = null;


            //NOTE: The following procedure is required by the Windows Form Designer
            //It can be modified using the Windows Form Designer.  
            //Do not modify it using the code editor.
            internal CustomNavigatorButton LeftScroller;
            internal CustomNavigatorButton RightScroller;
            internal CustomNavigatorButton CloseButton;
            internal CustomNavigatorButton ContextMenuButton;
            internal ContextMenuStrip ContextMenuStrip1;
            [System.Diagnostics.DebuggerStepThrough()]
            private void InitializeComponent()
            {
                this.RightScroller = new CustomNavigatorButton(Color.FromArgb(111, 157, 217), Color.FromArgb(227, 239, 255), Color.FromArgb(191, 219, 255), Color.FromArgb(61, 66, 139));
                this.LeftScroller = new CustomNavigatorButton(Color.FromArgb(111, 157, 217), Color.FromArgb(227, 239, 255), Color.FromArgb(191, 219, 255), Color.FromArgb(61, 66, 139));
                this.CloseButton = new CustomNavigatorButton(Color.FromArgb(111, 157, 217), Color.FromArgb(227, 239, 255), Color.FromArgb(191, 219, 255), Color.FromArgb(61, 66, 139));
                this.ContextMenuButton = new CustomNavigatorButton(Color.FromArgb(111, 157, 217), Color.FromArgb(227, 239, 255), Color.FromArgb(191, 219, 255), Color.FromArgb(61, 66, 139));
                this.ContextMenuStrip1 = new ContextMenuStrip();
                this.SuspendLayout();
                //
                //LeftScroller
                //
                this.LeftScroller.Dock = System.Windows.Forms.DockStyle.Left;
                this.LeftScroller.Location = new System.Drawing.Point(0, 0);
                this.LeftScroller.Name = "LeftScroller";
                this.LeftScroller.TabIndex = 0;
                this.LeftScroller.Text = "3";
                this.LeftScroller.Text = "3";
                this.LeftScroller.Click += new EventHandler(LeftScroller_Click);
                //
                //RightScroller
                //
                this.RightScroller.Dock = System.Windows.Forms.DockStyle.Right;
                this.RightScroller.Location = new System.Drawing.Point(23, 0);
                this.RightScroller.Name = "RightScroller";
                this.RightScroller.TabIndex = 1;
                this.RightScroller.Text = "4";
                this.RightScroller.Text = "4";
                this.RightScroller.Click += new EventHandler(RightScroller_Click);
                //
                //CloseButton
                //
                this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
                this.CloseButton.Location = new System.Drawing.Point(46, 0);
                this.CloseButton.Name = "CloseButton";
                this.CloseButton.TabIndex = 2;
                this.CloseButton.Text = "r";
                this.CloseButton.Text = "r";
                this.CloseButton.Click += new EventHandler(CloseButton_Click);
                //
                //ContextMenuButton
                //
                this.ContextMenuButton.Dock = System.Windows.Forms.DockStyle.Right;
                this.ContextMenuButton.Location = new System.Drawing.Point(69, 0);
                this.ContextMenuButton.Name = "ContextMenuButton";
                this.ContextMenuButton.TabIndex = 3;
                this.ContextMenuButton.Text = "7";
                this.ContextMenuButton.Text = "7";
                this.ContextMenuButton.Click += new EventHandler(ContextMenuButton_Click);
                //
                //ContextMenuStrip1
                //
                this.ContextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.0F);
                this.ContextMenuStrip1.Name = "ContextMenuStrip1";
                //
                //TabScroller
                //
                this.Controls.Add(this.LeftScroller);
                this.Controls.Add(this.RightScroller);
                this.Controls.Add(this.CloseButton);
                this.Controls.Add(this.ContextMenuButton);
                this.Font = new System.Drawing.Font("Marlett", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)2);
                this.Name = "TabScroller";
                this.Size = new System.Drawing.Size(69, 23);
                this.Resize += new EventHandler(TabScroller_Resize);
                this.BackColor = Color.Transparent;
                this.ResumeLayout(false);

            }

            #endregion

            public event EventHandler? TabClose;
            public event EventHandler? ScrollLeft;
            public event EventHandler? ScrollRight;
            public event EventHandler? ContextualMenu;

            private void TabScroller_Resize(object sender, EventArgs e)
            {
                //LeftScroller.Width = this.Width / 3;
                //RightScroller.Width = this.Width / 3;
                //CloseButton.Width = this.Width / 3;
            }


            private void LeftScroller_Click(object sender, EventArgs e)
            {
                if (ScrollLeft != null)
                {
                    ScrollLeft(this, EventArgs.Empty);
                }
            }


            private void RightScroller_Click(object sender, EventArgs e)
            {
                if (ScrollRight != null)
                {
                    ScrollRight(this, EventArgs.Empty);
                }
            }


            private void CloseButton_Click(object sender, EventArgs e)
            {
                if (TabClose != null)
                {
                    TabClose(this, EventArgs.Empty);
                }
            }

            private void ContextMenuButton_Click(object sender, EventArgs e)
            {
                if (TabClose != null && ContextualMenu != null)
                {
                    ContextualMenu(this, EventArgs.Empty);
                }
            }


        }

        #endregion

        #region  ... UpDown Control Subclasser ...

        internal class NativeUpDown : NativeWindow
        {

            public NativeUpDown() : base() { }

            private const int WM_DESTROY = 0x2;
            private const int WM_NCDESTROY = 0x82;
            private const int WM_WINDOWPOSCHANGING = 0x46;

            [StructLayout(LayoutKind.Sequential)]
            private struct Windowpos
            {
                public IntPtr hwnd, hwndInsertAfter;
                public int x, y, cx, cy, flags;
            }

            [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_DESTROY || m.Msg == WM_NCDESTROY)
                {
                    ReleaseHandle();
                }
                else if (m.Msg == WM_WINDOWPOSCHANGING)
                {
                    //Move the updown control off the edge so it's not visible
                    Windowpos wp = (Windowpos)(m.GetLParam(typeof(Windowpos)));
                    wp.x += wp.cx;
                    Marshal.StructureToPtr(wp, m.LParam, true);
                    _bounds = new Rectangle(wp.x, wp.y, wp.cx, wp.cy);
                }
                base.WndProc(ref m);
            }


            private Rectangle _bounds;
            internal Rectangle Bounds => _bounds;
        }

        #endregion

    }

}