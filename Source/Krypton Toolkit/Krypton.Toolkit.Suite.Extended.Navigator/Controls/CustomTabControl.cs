#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Security.Permissions;

using Krypton.Toolkit.Suite.Extended.Drawing;

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
        private System.ComponentModel.Container components = null;
        private SubClass scUpDown = null;
        private ImageList leftRightImages = null;
        private const int nMargin = 5;

        private Rectangle m_closeRect = new Rectangle();

        #endregion

        #region ... Properties ...

        [Editor(typeof(TabpageExCollectionEditor), typeof(UITypeEditor))]
        public new TabPageCollection TabPages
        {
            get
            {
                return base.TabPages;
            }
        }

        private Boolean _preserveTabColour = false;
        [Browsable(true), Category("Appearance-Extended")]
        public Boolean PreserveTabColour
        {
            get { return _preserveTabColour; }
            set { _preserveTabColour = value; Invalidate(); }
        }

        private Color _buttonsBackColour = Color.FromArgb(191, 219, 255);
        [Browsable(true), Category("Appearance-Extended")]
        public Color ButtonsBackColour
        {
            get { return _buttonsBackColour; }
            set { _buttonsBackColour = value; Invalidate(); }
        }

        private Color _buttonsBorderColour = Color.FromArgb(111, 157, 217);
        [Browsable(true), Category("Appearance-Extended")]
        public Color ButtonsBorderColour
        {
            get { return _buttonsBorderColour; }
            set { _buttonsBorderColour = value; Invalidate(); }
        }

        private Color _borderColour = SystemColors.ControlDark;
        [Browsable(true), Category("Appearance-Extended")]
        public Color BorderColour
        {
            get { return _borderColour; }
            set { _borderColour = value; Invalidate(); }
        }

        private int _borderWidth = 1;
        [Browsable(false), Category("Appearance-Extended")]
        public int BorderWidth
        {
            get { return _borderWidth; }
            set { _borderWidth = value; Invalidate(); }
        }

        private int _cornerRoundRadiusWidth = 12;
        [Browsable(true), Category("Appearance-Extended")]
        public int CornerRoundRadiusWidth
        {
            get { return _cornerRoundRadiusWidth; }
            set { _cornerRoundRadiusWidth = value; Invalidate(); }
        }

        private DrawingMethods.CornerType _cornerType = DrawingMethods.CornerType.Rounded;
        [Browsable(true), Category("Appearance-Extended")]
        public DrawingMethods.CornerType CornerType
        {
            get { return _cornerType; }
            set { _cornerType = value; Invalidate(); }
        }

        private Boolean _useExtendedLayout = false;
        [Browsable(true), Category("Appearance-Extended")]
        public Boolean UseExtendedLayout
        {
            get { return _useExtendedLayout; }
            set
            {
                Boolean result = value;
                if (result == true)
                {
                    this.SizeMode = TabSizeMode.Fixed;
                    this.Alignment = TabAlignment.Right;
                    this.DrawMode = TabDrawMode.OwnerDrawFixed;
                    this.ItemSize = new Size(25, 100);
                    this.Appearance = TabAppearance.Normal;
                }
                else
                {
                    this.SizeMode = TabSizeMode.Normal;
                    //this.Alignment = TabAlignment.Top;
                    this.DrawMode = TabDrawMode.OwnerDrawFixed;
                    this.ItemSize = new Size(77, 25);
                    this.Multiline = false;
                }

                _useExtendedLayout = value;
            }
        }

        private Color _tabColourHotLight = Color.FromArgb(255, 241, 196);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourHotLight
        {
            get { return _tabColourHotLight; }
            set { _tabColourHotLight = value; Invalidate(); }
        }

        private Color _tabColourHotDark = Color.FromArgb(255, 215, 83);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourHotDark
        {
            get { return _tabColourHotDark; }
            set { _tabColourHotDark = value; Invalidate(); }
        }

        private Color _tabColourSelectedLight = Color.FromArgb(255, 229, 196);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourSelectedLight
        {
            get { return _tabColourSelectedLight; }
            set { _tabColourSelectedLight = value; Invalidate(); }
        }

        private Color _tabColourSelectedDark = Color.FromArgb(254, 182, 93);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourSelectedDark
        {
            get { return _tabColourSelectedDark; }
            set { _tabColourSelectedDark = value; Invalidate(); }
        }

        private Color _tabColourPressedLight = Color.FromArgb(255, 229, 196);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourPressedLight
        {
            get { return _tabColourPressedLight; }
            set { _tabColourPressedLight = value; Invalidate(); }
        }

        private Color _tabColourPressedDark = Color.FromArgb(254, 182, 93);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourPressedDark
        {
            get { return _tabColourPressedDark; }
            set { _tabColourPressedDark = value; Invalidate(); }
        }

        private Color _tabColourDefaultLight = Color.FromArgb(227, 239, 255);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourDefaultLight
        {
            get { return _tabColourDefaultLight; }
            set { _tabColourDefaultLight = value; Invalidate(); }
        }

        private Color _tabColourDefaultDark = Color.FromArgb(191, 219, 255);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourDefaultDark
        {
            get { return _tabColourDefaultDark; }
            set { _tabColourDefaultDark = value; Invalidate(); }
        }

        private Color _tabHotForeColour = SystemColors.HotTrack;
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabHotForeColour
        {
            get { return _tabHotForeColour; }
            set { _tabHotForeColour = value; Invalidate(); }
        }

        private Color _tabSelectedForeColour = SystemColors.Highlight;
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabSelectedForeColour
        {
            get { return _tabSelectedForeColour; }
            set { _tabSelectedForeColour = value; Invalidate(); }
        }

        private Color _tabForeColour = Color.FromArgb(61, 66, 139);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabForeColour
        {
            get { return _tabForeColour; }
            set { _tabForeColour = value; Invalidate(); }
        }

        private Color _standardBackColour = SystemColors.Control;
        [Browsable(true), Category("Appearance-Extended")]
        public Color StandardBackColour
        {
            get { return _standardBackColour; }
            set { _standardBackColour = value; Invalidate(); }
        }

        private int _cornerWidth = 2;
        private int _cornerLeftWidth;
        private int _cornerRightWidth;
        [Browsable(true), Category("Appearance-Extended")]
        public CornWidth CornerWidth
        {
            get { return (CornWidth)_cornerWidth; }
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

        private int _cornerSymmetry = 0;
        [Browsable(true), Category("Appearance-Extended")]
        public CornSymmetry CornerSymmetry
        {
            get { return (CornSymmetry)_cornerSymmetry; }
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

        private int _allowSelectedTabHighSize = 0;
        private Boolean _allowSelectedTabHigh = false;
        [Browsable(true), Category("Appearance-Extended")]
        public Boolean AllowSelectedTabHigh
        {
            get { return _allowSelectedTabHigh; }
            set { _allowSelectedTabHigh = value; Invalidate(); }
        }

        private Boolean _allowCloseButton = false;
        [Browsable(true), Category("Appearance-Extended")]
        public Boolean AllowCloseButton
        {
            get { return _allowCloseButton; }
            set { _allowCloseButton = value; Invalidate(); }
        }

        private Boolean _allowInternalNavigatorButtons = false;
        private Boolean _allowNavigatorButtons = false;
        [Browsable(true), Category("Appearance-Extended")]
        public Boolean AllowNavigatorButtons
        {
            get { return _allowNavigatorButtons; }
            set { _allowNavigatorButtons = value; Invalidate(); }
        }

        private Boolean _allowContextButton = true;
        [Browsable(true), Category("Appearance-Extended")]
        public Boolean AllowContextButton
        {
            get { return _allowContextButton; }
            set { _allowContextButton = value; Invalidate(); }
        }

        #endregion

        #region ... enum ...
        public enum CornWidth : int
        {
            Null = 0,
            Thin = 2,
            Medium = 3,
            Thick = 4,
            Max = 6,
            Overflow = 8
        };

        public enum CornSymmetry : int
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
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();


            this.Scroller.ScrollLeft += new EventHandler(Scroller_ScrollLeft);
            this.Scroller.ScrollRight += new EventHandler(Scroller_ScrollRight);
            this.Scroller.TabClose += new EventHandler(Scroller_TabClose);
            this.Scroller.ContextualMenu += new EventHandler(Scroller_ContextMenuButton);

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

            this.HotTrack = true;

            this.StandardBackColour = Color.FromArgb(191, 219, 255);
            this.BorderColour = Color.FromArgb(111, 157, 217);


            this.ButtonsBackColour = Color.FromArgb(191, 219, 255);
            this.ButtonsBorderColour = Color.FromArgb(111, 157, 217);

            this.TabColourHotDark = Color.FromArgb(255, 213, 77); ; // Color.Gold; // 
            this.TabColourHotLight = Color.FromArgb(255, 239, 177); // Color.LightGoldenrodYellow; // 

            this.TabColourSelectedDark = Color.FromArgb(235, 122, 5);// _paletteBack.GetBackColor1(PaletteState.Pressed); // Color.FromArgb(252, 143, 61);//  
            this.TabColourSelectedLight = Color.FromArgb(254, 195, 108);//= _paletteBack.GetBackColor2(PaletteState.Pressed); // Color.FromArgb(255, 224, 192);// 

            this.TabColourPressedDark = Color.FromArgb(232, 142, 49);// _paletteBack.GetBackColor1(PaletteState.Pressed); // Color.FromArgb(252, 143, 61);//  
            this.TabColourPressedLight = Color.FromArgb(252, 207, 100);//= _paletteBack.GetBackColor2(PaletteState.Pressed); // Color.FromArgb(255, 224, 192);// 

            if ((_preserveTabColour == false)) //to avoid black text on black tab
            {
                this.TabForeColour = Color.FromArgb(21, 66, 139);
            }
            else
            {
                this.TabForeColour = Color.FromArgb(21, 66, 139);
            }

            this.TabHotForeColour = Color.FromArgb(21, 66, 139);
            this.TabSelectedForeColour = Color.FromArgb(21, 66, 139);
            this.TabColourDefaultDark = Color.FromArgb(191, 219, 255);
            this.TabColourDefaultLight = Color.FromArgb(227, 239, 255);

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
                if (!e.TabPage.ClientRectangle.Contains(m_closeRect))
                { base.OnSelecting(e); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                base.OnSelecting(e);
            }
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < this.TabCount; i++)
            {
                if (this.GetTabRect(i).Contains(e.X, e.Y))
                {
                    if (this.HotTrack)
                    {
                        //DrawTab(g, this.TabPages[i], i, true);
                        this.TabPages[i].Tag = true;
                    }
                }
                else
                {
                    //DrawTab(g, this.TabPages[i], i, false);
                    this.TabPages[i].Tag = false;
                }
            }
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            for (int i = 0; i < this.TabCount; i++)
            {
                this.TabPages[i].Tag = false;
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
                if (m_closeRect.Contains(mouse))
                {
                    Controls.RemoveAt(this.SelectedIndex);
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
                if (sender.Equals(this.Parent))
                {
                    mouse.Y = e.Location.Y - this.Location.Y;
                    mouse.X = e.Location.X - this.Location.X;
                }
                if (m_closeRect.Contains(mouse))
                {
                    Controls.RemoveAt(this.SelectedIndex);
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
                this.Parent.MouseClick += new MouseEventHandler(this_MouseClick);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        protected override bool ProcessMnemonic(char charCode)
        {

            foreach (TabPage p in this.TabPages)
            {
                if (Control.IsMnemonic(charCode, p.Text))
                {
                    this.SelectedTab = p;
                    this.Focus();
                    return true;
                }
            }
            return base.ProcessMnemonic(charCode);
        }

        //bool FlagControl = false;

        private void FlatTabControl_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Menu)
            {
                //FlagControl = true;
            }
            else
            {
                //FlagControl = false;
            }
            this.UpdateStyles();
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
                return;

            Rectangle TabControlArea = this.ClientRectangle;
            Rectangle TabArea = this.DisplayRectangle;

            //----------------------------
            // fill client area
            Brush br = new SolidBrush(_standardBackColour); //(SystemColors.Control); UPDATED
            g.FillRectangle(br, TabControlArea);
            br.Dispose();
            //----------------------------

            //----------------------------
            // draw border
            int nDelta = SystemInformation.Border3DSize.Width;

            Pen border = new Pen(_borderColour, _borderWidth);
            TabArea.Inflate(nDelta, nDelta);
            g.DrawRectangle(border, TabArea);
            border.Dispose();
            //----------------------------


            //----------------------------
            // clip region for drawing tabs
            Region rsaved = g.Clip;
            Rectangle rreg;

            int nWidth = TabArea.Width + nMargin;

            // exclude customcontrol for painting
            nWidth -= this.Scroller.Width;


            //if top or bottom leave a blank space for Close button or navigator
            if ((this.Alignment == TabAlignment.Top) || (this.Alignment == TabAlignment.Bottom))
            {
                rreg = new Rectangle(TabArea.Left, TabControlArea.Top, nWidth - nMargin, TabControlArea.Height);
            }
            else
            {
                rreg = ClientRectangle;
            }

            g.SetClip(rreg);

            // draw tabs
            for (int i = 0; i < this.TabCount; i++)
                DrawTab(g, this.TabPages[i], i);

            g.Clip = rsaved;
            //----------------------------


            //----------------------------
            // draw background to cover flat border areas
            if (this.SelectedTab != null)
            {
                TabPage tabPage = this.SelectedTab;
                Color color = tabPage.BackColor;
                border = new Pen(color);

                TabArea.Offset(1, 1);
                TabArea.Width -= 2;
                TabArea.Height -= 2;

                g.DrawRectangle(border, TabArea);
                TabArea.Width -= 1;
                TabArea.Height -= 1;
                g.DrawRectangle(border, TabArea);

                border.Dispose();
            }
            //----------------------------
        }

        internal void DrawTab(Graphics g, TabPage tabPage, int nIndex)
        {
            Rectangle recBounds = this.GetTabRect(nIndex);
            RectangleF tabTextArea = (RectangleF)this.GetTabRect(nIndex);


            //debug --> to be fixed
            if (recBounds.Width == 0) recBounds.Width = 50;
            if (tabTextArea.Width == 0) tabTextArea.Width = 50;
            if (recBounds.Height == 0) recBounds.Width = 22;
            if (tabTextArea.Height == 0) tabTextArea.Width = 22;

            bool bSelected = (this.SelectedIndex == nIndex);
            bool bHot = false;

            if (tabPage.Tag != null)
            {
                bHot = (bool)tabPage.Tag;
            }



            //for buttons appearance
            if (this.Appearance != TabAppearance.Normal)
            {
                _cornerLeftWidth = 0;
                _cornerRightWidth = 0;
                _cornerWidth = 0;
                _cornerRoundRadiusWidth = 2;
                this.Alignment = TabAlignment.Top;

            }

            //maximum radius
            if (_cornerRoundRadiusWidth > 32) _cornerRoundRadiusWidth = 32;



            //Tab Hedaer Status
            DrawingMethods.TabHeaderStatus Status = DrawingMethods.TabHeaderStatus.Normal;
            if (_preserveTabColour) Status = DrawingMethods.TabHeaderStatus.NormalPreserve;
            if (bHot) Status = DrawingMethods.TabHeaderStatus.Hot;


            //bool bHotselected = false;

            if ((bSelected) && (!bHot))
            {
                Status = DrawingMethods.TabHeaderStatus.Selected;
            }
            else if ((bSelected) && (bHot))
            {
                Status = DrawingMethods.TabHeaderStatus.HotSelected;
                //bHotselected = true;
            }

            //Selected tab has to be highter?
            if (!_allowSelectedTabHigh)
            { _allowSelectedTabHighSize = 0; }
            else
            { _allowSelectedTabHighSize = 2; }

            //AC.ExtendedRenderer.Toolkit.Drawing.DrawingMethods.VisualOrientation visualorientation;

            //Set visual orientation for Krypton Renderer
            if (this.Alignment == TabAlignment.Top)
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
            Color ClearBorderColor = new Color();


            //Font for header
            Font fnt = Font;

            //draw contents
            switch (_cornerType)
            {
                case DrawingMethods.CornerType.Squared:

                    //Create tab Header Points (Sqared)
                    Point[] pt = DrawingMethods.GetTabSquaredPoints(recBounds, _cornerWidth, Alignment, _cornerLeftWidth, _cornerRightWidth, this.Appearance, Status, _allowSelectedTabHighSize, false);
                    Point[] ptBorder = DrawingMethods.GetTabSquaredPoints(recBounds, _cornerWidth, Alignment, _cornerLeftWidth, _cornerRightWidth, this.Appearance, Status, _allowSelectedTabHighSize, true);


                    switch (Status)
                    {
                        case DrawingMethods.TabHeaderStatus.Selected:
                            if (this.Appearance == TabAppearance.Normal)
                            {
                                DrawingMethods.DrawTabHeader(g, pt, recBounds, tabPage.BackColor, _tabColourSelectedDark, tabPage.BackColor, 90, Alignment, _useExtendedLayout, Status, false);
                                ClearBorderColor = _tabColourSelectedLight;
                            }
                            else
                            {
                                DrawingMethods.DrawTabHeader(g, pt, recBounds, _tabColourSelectedLight, _tabColourSelectedDark, tabPage.BackColor, 90, Alignment, _useExtendedLayout, Status, false);
                                ClearBorderColor = _tabColourPressedLight;
                            }
                            fnt = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
                            br = new SolidBrush(_tabSelectedForeColour);

                            break;

                        case DrawingMethods.TabHeaderStatus.HotSelected:
                            if (this.Appearance == TabAppearance.Normal)
                            {
                                DrawingMethods.DrawTabHeader(g, pt, recBounds, tabPage.BackColor, _tabColourPressedDark, tabPage.BackColor, 90, Alignment, _useExtendedLayout, Status, false);
                                ClearBorderColor = _tabColourPressedLight;
                            }
                            else
                            {
                                DrawingMethods.DrawTabHeader(g, pt, recBounds, _tabColourPressedLight, _tabColourPressedDark, _tabColourPressedLight, 90, Alignment, _useExtendedLayout, Status, false);
                                ClearBorderColor = _tabColourPressedLight;
                            }
                            fnt = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
                            br = new SolidBrush(_tabSelectedForeColour);
                            ClearBorderColor = _tabColourPressedLight;
                            break;

                        case DrawingMethods.TabHeaderStatus.Hot:
                            DrawingMethods.DrawTabHeader(g, pt, recBounds, _tabColourHotLight, _tabColourHotDark, DrawingMethods.GetLighterColour(_tabColourHotLight), 90, Alignment, _useExtendedLayout, Status, false);
                            br = new SolidBrush(_tabHotForeColour);
                            ClearBorderColor = _tabColourHotDark;
                            break;

                        case DrawingMethods.TabHeaderStatus.Normal:
                            DrawingMethods.DrawTabHeader(g, pt, recBounds, _tabColourDefaultLight, _tabColourDefaultDark, _tabColourDefaultLight, 90, Alignment, _useExtendedLayout, Status, false);
                            br = new SolidBrush(_tabForeColour);
                            ClearBorderColor = _tabColourDefaultDark;
                            break;

                        case DrawingMethods.TabHeaderStatus.NormalPreserve:
                            DrawingMethods.DrawTabHeader(g, pt, recBounds, Color.White, DrawingMethods.GetModifiedColour(tabPage.BackColor, -20, 7, 0), tabPage.BackColor, 90, Alignment, _useExtendedLayout, Status, true);
                            br = new SolidBrush(_tabForeColour);
                            ClearBorderColor = Color.White;
                            break;
                    }
                    // draw border
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.DrawPolygon(new Pen(ClearBorderColor, 1), ptBorder);
                    g.DrawPolygon(new Pen(_borderColour, _borderWidth), pt);
                    break;

                case DrawingMethods.CornerType.Rounded:

                    GraphicsPath path = DrawingMethods.GetTabRoundedPath(recBounds, _cornerRoundRadiusWidth, Alignment, false, Status, Appearance, _allowSelectedTabHighSize);
                    GraphicsPath pathBorder = DrawingMethods.GetTabRoundedPath(recBounds, _cornerRoundRadiusWidth, Alignment, true, Status, Appearance, _allowSelectedTabHighSize);
                    if (this.Appearance != TabAppearance.Normal)
                    {
                        path = DrawingMethods.GetRoundedSquarePath(recBounds, 8);
                        Rectangle InnerBorder = recBounds;
                        InnerBorder.Offset(1, 1);
                        InnerBorder.Height -= 2;
                        InnerBorder.Width -= 2;
                        pathBorder = DrawingMethods.GetRoundedSquarePath(InnerBorder, 8);

                    }

                    switch (Status)
                    {
                        case DrawingMethods.TabHeaderStatus.Selected:
                            if (this.Appearance == TabAppearance.Normal)
                            {
                                DrawingMethods.DrawTabHeader(g, path, recBounds, tabPage.BackColor, _tabColourSelectedDark, tabPage.BackColor, 90, Alignment, _useExtendedLayout, Status, false);
                                ClearBorderColor = _tabColourSelectedLight;
                            }
                            else
                            {
                                DrawingMethods.DrawTabHeader(g, path, recBounds, _tabColourSelectedLight, _tabColourSelectedDark, tabPage.BackColor, 90, Alignment, _useExtendedLayout, Status, false);
                                ClearBorderColor = _tabColourPressedLight;
                            }
                            fnt = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
                            br = new SolidBrush(_tabSelectedForeColour);

                            break;

                        case DrawingMethods.TabHeaderStatus.HotSelected:
                            if (this.Appearance == TabAppearance.Normal)
                            {
                                DrawingMethods.DrawTabHeader(g, path, recBounds, tabPage.BackColor, _tabColourPressedDark, tabPage.BackColor, 90, Alignment, _useExtendedLayout, Status, false);
                                ClearBorderColor = _tabColourPressedLight;
                            }
                            else
                            {
                                DrawingMethods.DrawTabHeader(g, path, recBounds, _tabColourPressedLight, _tabColourPressedDark, _tabColourPressedLight, 90, Alignment, _useExtendedLayout, Status, false);
                                ClearBorderColor = _tabColourPressedLight;
                            }
                            fnt = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
                            br = new SolidBrush(_tabSelectedForeColour);

                            break;

                        case DrawingMethods.TabHeaderStatus.Hot:
                            DrawingMethods.DrawTabHeader(g, path, recBounds, _tabColourHotLight, _tabColourHotDark, DrawingMethods.GetLighterColour(_tabColourHotLight), 90, Alignment, _useExtendedLayout, Status, false);
                            br = new SolidBrush(_tabHotForeColour);
                            ClearBorderColor = _tabColourHotDark;
                            break;

                        case DrawingMethods.TabHeaderStatus.Normal:
                            DrawingMethods.DrawTabHeader(g, path, recBounds, _tabColourDefaultLight, _tabColourDefaultDark, _tabColourDefaultLight, 90, Alignment, _useExtendedLayout, Status, false);
                            br = new SolidBrush(_tabForeColour);
                            ClearBorderColor = _tabColourDefaultDark;
                            break;

                        case DrawingMethods.TabHeaderStatus.NormalPreserve:
                            DrawingMethods.DrawTabHeader(g, path, recBounds, Color.White, DrawingMethods.GetModifiedColour(tabPage.BackColor, -20, 7, 0), tabPage.BackColor, 90, Alignment, _useExtendedLayout, Status, true);
                            br = new SolidBrush(_tabForeColour);
                            ClearBorderColor = Color.White;
                            break;
                    }


                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.DrawPath(new Pen(ClearBorderColor, 1), pathBorder);
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

            if (((Status == DrawingMethods.TabHeaderStatus.Selected) || (Status == DrawingMethods.TabHeaderStatus.HotSelected)) && (this.Appearance == TabAppearance.Normal))
            {
                //----------------------------
                // clear bottom lines
                //Pen pen = new Pen(ClearBorderColor);
                Pen pen = new Pen(tabPage.BackColor);

                DrawingMethods.ClearTabSelectedBottomLine(g, recBounds, pen, this.Alignment);

                pen.Dispose();
                //----------------------------
            }
            //----------------------------

            //----------------------------
            // draw tab's icon
            if ((tabPage.ImageIndex >= 0) && (ImageList != null) && (ImageList.Images[tabPage.ImageIndex] != null))
            {
                int nLeftMargin = 8;
                int nRightMargin = 2;

                Image img = ImageList.Images[tabPage.ImageIndex];

                Rectangle rimage = new Rectangle(recBounds.X + nLeftMargin, recBounds.Y + 1, img.Width, img.Height);

                // adjust rectangles
                float nAdj = (float)(nLeftMargin + img.Width + nRightMargin);

                // adjust rectangles
                if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom)
                {
                    nAdj = (float)(nLeftMargin + img.Width + nRightMargin);

                    rimage.Y += (recBounds.Height - img.Height) / 2;
                    tabTextArea.X += nAdj;
                    tabTextArea.Width -= nAdj;
                }
                else
                {
                    if (_useExtendedLayout == false)
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
                if (_useExtendedLayout == true)
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
            if (this.RightToLeft == RightToLeft.Yes)
            {
                stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            }

            //Disabled
            if (!this.Enabled) br = new SolidBrush(SystemColors.GrayText);


            if (this.Alignment == TabAlignment.Right || this.Alignment == TabAlignment.Left)
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
            if ((leftRightImages == null) || (leftRightImages.Images.Count != 4))
                return;

            //----------------------------
            // calc positions
            Rectangle TabControlArea = this.ClientRectangle;

            Rectangle r0 = new Rectangle();
            WIN32.GetClientRect(scUpDown.Handle, ref r0);

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
            Image img = leftRightImages.Images[1];
            if (img != null)
            {
                if (this.TabCount > 0)
                {
                    Rectangle r3 = this.GetTabRect(0);
                    if (r3.Left < TabControlArea.Left)
                        g.DrawImage(img, r1);
                    else
                    {
                        img = leftRightImages.Images[3];
                        if (img != null)
                            g.DrawImage(img, r1);
                    }
                }
            }

            img = leftRightImages.Images[0];
            if (img != null)
            {
                if (this.TabCount > 0)
                {
                    Rectangle r3 = this.GetTabRect(this.TabCount - 1);
                    if (r3.Right > (TabControlArea.Width - r0.Width))
                        g.DrawImage(img, r2);
                    else
                    {
                        img = leftRightImages.Images[2];
                        if (img != null)
                            g.DrawImage(img, r2);
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
            components = new System.ComponentModel.Container();
        }

        //TabControl overrides dispose to clean up the component list.
        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

                if (UpDown != null)
                    UpDown.ReleaseHandle();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region ... TabpageExCollectionEditor ...

        internal class TabpageExCollectionEditor : CollectionEditor
        {
            public TabpageExCollectionEditor(System.Type type) : base(type)
            {
            }

            protected override Type CreateCollectionItemType()
            {
                return typeof(TabPage);
            }
        }

        #endregion

        #region ... Overidden WndProc / Custom Scroller ...
        private NativeUpDown UpDown = null;
        private TabScroller Scroller = new TabScroller();
        private Point pt = new Point();

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
                while (tabRect.Left < 0 && multiplier < this.TabCount);
                return multiplier;
            }
        }


        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WIN32.WM_PARENTNOTIFY)
            {
                if ((ushort)(m.WParam.ToInt32() & 0xFFFF) == WIN32.WM_CREATE)
                {
                    System.Text.StringBuilder WindowName = new System.Text.StringBuilder(16);
                    WIN32.RealGetWindowClass(m.LParam, WindowName, 16);
                    if (WindowName.ToString() == "msctls_updown32")

                    {
                        //unhook the existing updown control as it will be recreated if 
                        //the tabcontrol is recreated (alignment, visible changed etc..)
                        if (UpDown != null)
                        {
                            UpDown.ReleaseHandle();
                            //Scroller.LeftScroller.Enabled = true;
                            //Scroller.RightScroller.Enabled = true;
                        }
                        else
                        {
                            //Scroller.LeftScroller.Enabled = false;
                            //Scroller.RightScroller.Enabled = false;
                        }
                        //and hook it.
                        UpDown = new NativeUpDown();
                        UpDown.AssignHandle(m.LParam);
                    }
                }
            }
            base.WndProc(ref m);
        }


        protected override void OnHandleCreated(System.EventArgs e)
        {
            base.OnHandleCreated(e);
            ///if (this.Multiline == false)
            //{
            //Scroller.Font = new Font("Marlett", this.Font.Size, FontStyle.Regular, GraphicsUnit.Pixel, this.Font.GdiCharSet);
            WIN32.SetParent(Scroller.Handle, this.Handle);
            //}
            this.OnFontChanged(EventArgs.Empty);
        }


        protected override void OnFontChanged(System.EventArgs e)
        {
            base.OnFontChanged(e);
            //this.Scroller.Font = new Font("Marlett", this.Font.SizeInPoints, FontStyle.Regular, GraphicsUnit.Point);
            this.Scroller.Height = 23;// this.ItemSize.Height;
            this.Scroller.Width = 92;// this.ItemSize.Height * 3;

            this.OnResize(EventArgs.Empty);
        }

        private bool IsFirstTabHidden()
        {
            float FirstPagePosition = 0;
            bool Display = false;

            //there are tab pages?
            if (this.TabCount > 0)
            {
                FirstPagePosition = GetTabRect(0).Left;
                //not visible?
                if ((FirstPagePosition < 0))
                {
                    Display = true;
                }
                else
                {
                    Display = false;
                }
            }
            return Display;
        }

        private bool IsLastTabHidden()
        {
            bool Display = false;

            //there are tab pages?
            if (this.TabCount > 0)
            {
                //visible?
                if ((GetTabRect(this.TabCount - 1).Right > this.Scroller.Left))
                {
                    Display = true;
                }
                else
                {
                    Display = false;
                }
            }
            return Display;
        }


        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            //show Close button?
            if (_allowCloseButton == true)
            {
                this.Scroller.CloseButton.Visible = true;
            }
            else
            {
                this.Scroller.CloseButton.Visible = false;
            }

            //show Context button?
            if (_allowContextButton == true)
            {
                this.Scroller.ContextMenuButton.Visible = true;
            }
            else
            {
                this.Scroller.ContextMenuButton.Visible = false;
            }

            //test on tab pages 
            if ((IsLastTabHidden() == false) && (IsFirstTabHidden() == false))
            {
                _allowInternalNavigatorButtons = false;
            }
            else
            {
                _allowInternalNavigatorButtons = true;
            }
            //show navigator buttons?
            if ((_allowNavigatorButtons == true) && (_allowInternalNavigatorButtons == true))
            {
                this.Scroller.LeftScroller.Visible = true;
                this.Scroller.RightScroller.Visible = true;
            }
            else
            {
                this.Scroller.LeftScroller.Visible = false;
                this.Scroller.RightScroller.Visible = false;
            }

            //multiline, no navigator
            if (this.Multiline == true) _allowNavigatorButtons = false;

            //which buttons to display
            if (_allowCloseButton == true)
            {
                if ((_allowNavigatorButtons == true) && (_allowInternalNavigatorButtons == true))
                {
                    if (_allowContextButton == true)
                    {
                        //navigator and close and context
                        this.Scroller.Width = 92;
                    }
                    else
                    {
                        //navigator and close
                        this.Scroller.Width = 69;
                    }

                }
                else
                {
                    if (_allowContextButton == true)
                    {
                        //only close and context
                        this.Scroller.Width = 46;
                    }
                    else
                    {
                        //close
                        this.Scroller.Width = 23;
                    }

                }
            }
            else
            {
                if ((_allowNavigatorButtons == true) && (_allowInternalNavigatorButtons == true))
                {
                    if (_allowContextButton == true)
                    {
                        //navigator and context
                        this.Scroller.Width = 69;
                    }
                    else
                    {
                        //navigator
                        this.Scroller.Width = 46;
                    }

                }
                else
                {
                    if (_allowContextButton == true)
                    {
                        //context
                        this.Scroller.Width = 23;
                    }
                    else
                    {
                        //nothing
                        this.Scroller.Width = 0;
                    }

                }
            }

            if (this.Alignment == TabAlignment.Top)
                Scroller.Location = new Point(this.Width - Scroller.Width - 1, 2);
            else if (this.Alignment == TabAlignment.Bottom)
                Scroller.Location = new Point(this.Width - Scroller.Width - 1, this.Height - Scroller.Height - 1);
            else if (this.Alignment == TabAlignment.Right)
                Scroller.Location = new Point(this.Width - Scroller.Width - 1, this.Height - Scroller.Height - 1);
            else if (this.Alignment == TabAlignment.Left)
                Scroller.Location = new Point(2, this.Height - Scroller.Height - 1);


            //For Context Menu
            pt = new Point(Scroller.Right - 23, Scroller.Bottom);

        }
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Invalidate(true);
            //if (this.Multiline)
            //    return;
            if (this.Alignment == TabAlignment.Top)
                Scroller.Location = new Point(this.Width - Scroller.Width - 1, 2);
            else
                Scroller.Location = new Point(this.Width - Scroller.Width, this.Height - Scroller.Height - 1);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
        }

        private void ToolstripItemEvent(Object sender, EventArgs e)
        {
            ToolStripMenuItem tsi = (ToolStripMenuItem)sender;
            //tsi.Checked = true;
            TabPage tp = (TabPage)tsi.Tag;
            this.SelectedTab = tp;
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

        private void Scroller_ScrollLeft(Object sender, System.EventArgs e)
        {
            if (this.TabCount == 0)
                return;
            int scrollPos = Math.Max(0, (ScrollPosition - 1) * 0x10000);
            WIN32.SendMessage(this.Handle, WIN32.WM_HSCROLL, (IntPtr)(scrollPos | 0x4), IntPtr.Zero);
            WIN32.SendMessage(this.Handle, WIN32.WM_HSCROLL, (IntPtr)(scrollPos | 0x8), IntPtr.Zero);
            Invalidate();
        }


        private void Scroller_ScrollRight(Object sender, System.EventArgs e)
        {
            if (this.TabCount == 0)
                return;
            if (GetTabRect(this.TabCount - 1).Right <= this.Scroller.Left)
                return;
            int scrollPos = Math.Max(0, (ScrollPosition + 1) * 0x10000);
            WIN32.SendMessage(this.Handle, WIN32.WM_HSCROLL, (IntPtr)(scrollPos | 0x4), IntPtr.Zero);
            WIN32.SendMessage(this.Handle, WIN32.WM_HSCROLL, (IntPtr)(scrollPos | 0x8), IntPtr.Zero);
            Invalidate();
        }


        private void Scroller_TabClose(Object sender, System.EventArgs e)
        {
            if (this.SelectedTab != null)
                this.TabPages.Remove(this.SelectedTab);
        }

        private void Scroller_ContextMenuButton(Object sender, System.EventArgs e)
        {
            Scroller.ContextMenuStrip1.DropShadowEnabled = true;

            //clear items
            Scroller.ContextMenuStrip1.Items.Clear();

            //Counter 
            int i = 0;
            //Add Items
            foreach (TabPage tp in this.TabPages)
            {
                try
                {
                    //TabPage tp = (TabPage)e.Control;
                    ToolStripMenuItem item;
                    if ((this.ImageList != null) && (tp.ImageIndex >= 0))
                    {
                        item = new ToolStripMenuItem(tp.Text, this.ImageList.Images[tp.ImageIndex], ToolstripItemEvent);
                    }
                    else
                    {
                        item = new ToolStripMenuItem(tp.Text, null, ToolstripItemEvent);
                    }
                    item.Tag = tp;
                    Scroller.ContextMenuStrip1.Items.Add(item);


                    //show checked
                    if (this.SelectedIndex == i) item.Checked = true;
                }
                catch
                {
                    //silent
                }
                i++;
            }



            //show Menu
            Scroller.ContextMenuStrip1.Show(PointToScreen(pt));

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
            private System.ComponentModel.IContainer components = null;


            //NOTE: The following procedure is required by the Windows Form Designer
            //It can be modified using the Windows Form Designer.  
            //Do not modify it using the code editor.
            internal CustomNavigatorButton LeftScroller;
            internal CustomNavigatorButton RightScroller;
            internal CustomNavigatorButton CloseButton;
            internal CustomNavigatorButton ContextMenuButton;
            internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
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

            public event EventHandler TabClose;
            public event EventHandler ScrollLeft;
            public event EventHandler ScrollRight;
            public event EventHandler ContextualMenu;

            private void TabScroller_Resize(Object sender, System.EventArgs e)
            {
                //LeftScroller.Width = this.Width / 3;
                //RightScroller.Width = this.Width / 3;
                //CloseButton.Width = this.Width / 3;
            }


            private void LeftScroller_Click(Object sender, System.EventArgs e)
            {
                if (ScrollLeft != null)
                    ScrollLeft(this, EventArgs.Empty);
            }


            private void RightScroller_Click(Object sender, System.EventArgs e)
            {
                if (ScrollRight != null)
                    ScrollRight(this, EventArgs.Empty);
            }


            private void CloseButton_Click(Object sender, System.EventArgs e)
            {
                if (TabClose != null)
                    TabClose(this, EventArgs.Empty);
            }

            private void ContextMenuButton_Click(Object sender, System.EventArgs e)
            {
                if (TabClose != null)
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
            private struct WINDOWPOS
            {
                public IntPtr hwnd, hwndInsertAfter;
                public int x, y, cx, cy, flags;
            }

            [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
            protected override void WndProc(ref System.Windows.Forms.Message m)
            {
                if (m.Msg == WM_DESTROY || m.Msg == WM_NCDESTROY)
                    this.ReleaseHandle();
                else if (m.Msg == WM_WINDOWPOSCHANGING)
                {
                    //Move the updown control off the edge so it's not visible
                    WINDOWPOS wp = (WINDOWPOS)(m.GetLParam(typeof(WINDOWPOS)));
                    wp.x += wp.cx;
                    Marshal.StructureToPtr(wp, m.LParam, true);
                    _bounds = new Rectangle(wp.x, wp.y, wp.cx, wp.cy);
                }
                base.WndProc(ref m);
            }


            private Rectangle _bounds;
            internal Rectangle Bounds
            {
                get { return _bounds; }
            }

        }

        #endregion

    }

}