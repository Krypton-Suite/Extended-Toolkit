#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    /// <summary>
    /// Summary description for FlatTabControl.
    /// </summary>
    [ToolboxBitmap(typeof(TabControl)), ToolboxItem(false)] //,
    public class FlatTabControl : TabControl
    {
        private IContainer components;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        /// 
        #region ... Declarations ...
        private SubClass scUpDown = null;
        private bool bUpDown; // true when the button UpDown is required
        private ImageList leftRightImages = null;
        private const int nMargin = 5;

        private Rectangle m_closeRect = new Rectangle();
        private bool bFirtsLoad = true;
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

        private Color _buttonsBackColour = SystemColors.Control;
        [Browsable(true), Category("Appearance-Extended")]
        public Color ButtonsBackColour
        {
            get { return _buttonsBackColour; }
            set { _buttonsBackColour = value; Invalidate(); }
        }

        private Color _buttonsBorderColour = SystemColors.ControlDark;
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

        private const int _borderWidth = 1;
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
                    this.ItemSize = new Size(91, 25);
                    this.Multiline = false;
                }

                _useExtendedLayout = value;
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

        private Color _tabColourDefaultLight = Color.FromArgb(194, 224, 255);
        [Browsable(true), Category("Appearance-Extended")]
        public Color TabColourDefaultLight
        {
            get { return _tabColourDefaultLight; }
            set { _tabColourDefaultLight = value; Invalidate(); }
        }

        private Color _tabColourDefaultDark = Color.FromArgb(194, 224, 255);
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

        private Color _tabForeColour = SystemColors.ControlText;
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

        private Boolean _allowCloseButton = false;
        [Browsable(true), Category("Appearance-Extended")]
        public Boolean AllowCloseButton
        {
            get { return _allowCloseButton; }
            set { _allowCloseButton = value; Invalidate(); }
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
        public FlatTabControl()
        {

            // double buffering
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();


            bUpDown = true;

            this.VisibleChanged += new EventHandler(FlatTabControl_VisibleChanged);
            this.ControlAdded += new ControlEventHandler(FlatTabControl_ControlAdded);
            this.ControlRemoved += new ControlEventHandler(FlatTabControl_ControlRemoved);
            this.SelectedIndexChanged += new EventHandler(FlatTabControl_SelectedIndexChanged);

            leftRightImages = new ImageList();
            //leftRightImages.ImageSize = new Size(16, 16); // default

            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FlatTabControl));
            Bitmap updownImage = ((System.Drawing.Bitmap)(resources.GetObject("TabIcons.bmp")));

            if (updownImage != null)
            {
                updownImage.MakeTransparent(Color.White);
                leftRightImages.Images.AddStrip(updownImage);
            }


            //allow Close
            this.ParentChanged += new EventHandler(this_ParentChanged);


        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// 

        #endregion

        #region ... overridden methods ...
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                leftRightImages.Dispose();
            }
            base.Dispose(disposing);
        }

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
            this.UpdateStyles();
        }


        // Check in UpDown Is visible


        protected override void OnPaint(PaintEventArgs e)

        {
            base.OnPaint(e);
            DrawControl(e.Graphics);

            //firt load?
            if (bFirtsLoad == true)
            {
                FindUpDown();
                UpdateUpDown();
                bFirtsLoad = false;

            }

            //bool bIsVisibleUpDown = false;

            // Check in UpDown Is visible
            if (bUpDown)
            {
                if (WIN32.IsWindowVisible(scUpDown.Handle))
                {
                    //bIsVisibleUpDown = true;
                }
            }


            if (_allowCloseButton == true)
            {
                System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FlatTabControl));
                Bitmap closeImage = ((System.Drawing.Bitmap)(resources.GetObject("CloseIcon.bmp")));

                closeImage.MakeTransparent(Color.White);

                if (Alignment == TabAlignment.Top)
                {
                    //if (bIsVisibleUpDown)
                    //{
                    //    m_closeRect = new Rectangle(ClientRectangle.X + ClientRectangle.Width - 56, ClientRectangle.Y + 8, 14, 14);
                    //}
                    //else
                    //{
                    m_closeRect = new Rectangle(ClientRectangle.X + ClientRectangle.Width - 18, ClientRectangle.Y + 8, 14, 14);
                    //}
                }
                else if (Alignment == TabAlignment.Right)
                {
                    m_closeRect = new Rectangle(ClientRectangle.X + ClientRectangle.Width - 21, ClientRectangle.Y + ClientRectangle.Height - 18, 14, 14);
                }
                else if (Alignment == TabAlignment.Left)
                {
                    m_closeRect = new Rectangle(ClientRectangle.X + 8, ClientRectangle.Y + ClientRectangle.Height - 18, 14, 14);
                }
                else if (Alignment == TabAlignment.Bottom)
                {
                    //if (bIsVisibleUpDown)
                    //{
                    //    m_closeRect = new Rectangle(ClientRectangle.X + ClientRectangle.Width - 56, ClientRectangle.Y + ClientRectangle.Height - 21, 14, 14);
                    //}
                    //else
                    //{
                    m_closeRect = new Rectangle(ClientRectangle.X + ClientRectangle.Width - 18, ClientRectangle.Y + ClientRectangle.Height - 21, 14, 14);
                    //}
                }

                //paint border and backcolor of the button
                Rectangle closeBorder = m_closeRect;
                closeBorder.Inflate(3, 3);
                closeBorder.Width -= 1;
                closeBorder.Height -= 1;
                e.Graphics.FillRectangle(new SolidBrush(_buttonsBackColour), closeBorder);
                e.Graphics.DrawRectangle(new Pen(_buttonsBorderColour), closeBorder);

                //paint the image
                e.Graphics.DrawImage(closeImage, m_closeRect);

                // e.Graphics.DrawRectangle(new Pen(Color.Red), m_closeRect);
            }

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

            // exclude close button control for painting
            if (_allowCloseButton)
            {
                nWidth -= 20;
            }

            if (bUpDown)
            {
                // exclude updown control for painting
                if (WIN32.IsWindowVisible(scUpDown.Handle))
                {
                    Rectangle rupdown = new Rectangle();
                    WIN32.GetWindowRect(scUpDown.Handle, ref rupdown);
                    Rectangle rupdown2 = this.RectangleToClient(rupdown);

                    nWidth = rupdown2.X;
                }
            }

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
                this.Alignment = TabAlignment.Top;
            }

            //Tab Hedaer Status
            DrawingMethods.TabHeaderStatus Status = DrawingMethods.TabHeaderStatus.Normal;
            if (_preserveTabColour) Status = DrawingMethods.TabHeaderStatus.NormalPreserve;
            if (bHot) Status = DrawingMethods.TabHeaderStatus.Hot;

            //bool bHotselected = false;

            if ((bSelected) && (!bHot))
            { Status = DrawingMethods.TabHeaderStatus.Selected; }
            else if ((bSelected) && (bHot))
            {
                Status = DrawingMethods.TabHeaderStatus.HotSelected;
                //bHotselected = true;
            }

            //Selected tab has to be highter
            if (!_allowSelectedTabHigh)
            { _allowSelectedTabHighSize = 0; }
            else
            { _allowSelectedTabHighSize = 1; }

            //Create tab Header Points (Sqared)
            Point[] pt = DrawingMethods.GetTabSquaredPoints(recBounds, _cornerWidth, Alignment, _cornerLeftWidth, _cornerRightWidth, this.Appearance, Status, _allowSelectedTabHighSize, false);

            //----------------------------
            // fill this tab with background color
            Brush br = new SolidBrush(tabPage.BackColor);

            //Font for header
            Font fnt = Font;

            switch (Status)
            {
                case DrawingMethods.TabHeaderStatus.Selected:
                    DrawingMethods.DrawTabHeader(g, pt, recBounds, _tabColourSelectedLight, _tabColourSelectedDark, tabPage.BackColor, 90, Alignment, _useExtendedLayout, Status, false);
                    fnt = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
                    br = new SolidBrush(_tabForeColour);
                    break;

                case DrawingMethods.TabHeaderStatus.HotSelected:
                    DrawingMethods.DrawTabHeader(g, pt, recBounds, _tabColourSelectedLight, DrawingMethods.GetLighterColour(_tabColourSelectedDark), tabPage.BackColor, 90, Alignment, _useExtendedLayout, Status, false);
                    fnt = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
                    br = new SolidBrush(_tabHotForeColour);
                    break;

                case DrawingMethods.TabHeaderStatus.Hot:
                    DrawingMethods.DrawTabHeader(g, pt, recBounds, _tabColourHotLight, _tabColourHotDark, _tabColourHotLight, 90, Alignment, _useExtendedLayout, Status, false);
                    br = new SolidBrush(_tabHotForeColour);
                    break;

                case DrawingMethods.TabHeaderStatus.Normal:
                    DrawingMethods.DrawTabHeader(g, pt, recBounds, _tabColourDefaultLight, _tabColourDefaultDark, _tabColourDefaultLight, 90, Alignment, _useExtendedLayout, Status, false);
                    br = new SolidBrush(_tabForeColour);
                    break;

                case DrawingMethods.TabHeaderStatus.NormalPreserve:
                    DrawingMethods.DrawTabHeader(g, pt, recBounds, DrawingMethods.GetSystemLighterColour(tabPage.BackColor), DrawingMethods.GetDarkerColour(tabPage.BackColor), tabPage.BackColor, 90, Alignment, _useExtendedLayout, Status, true);
                    br = new SolidBrush(_tabForeColour);
                    break;
            }

            //----------------------------

            //----------------------------
            // draw border
            //g.DrawRectangle(SystemPens.ControlDark, recBounds);
            g.DrawPolygon(new Pen(_borderColour, _borderWidth), pt);
            //----------------------------

            if (((Status == DrawingMethods.TabHeaderStatus.Selected) || (Status == DrawingMethods.TabHeaderStatus.HotSelected)) && (this.Appearance == TabAppearance.Normal))
            {
                //----------------------------
                // clear bottom lines
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
            if (this.RightToLeft == RightToLeft.Yes) stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

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


        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            FindUpDown();
            Invalidate();
        }
        private void FlatTabControl_VisibleChanged(object sender, EventArgs e)
        {
            FindUpDown();
            //UpdateUpDown();
            bFirtsLoad = true;
        }
        private void FlatTabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            FindUpDown();
            //UpdateUpDown();
            bFirtsLoad = true;
        }

        private void FlatTabControl_ControlRemoved(object sender, ControlEventArgs e)
        {
            FindUpDown();
            //UpdateUpDown();
            bFirtsLoad = true;
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            FindUpDown();
            base.OnSelectedIndexChanged(e);
            Update();
            Invalidate();	// we need to update border and background colors
        }
        private void FlatTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUpDown();
            Update();
            Invalidate();   // we need to update border and background colors
        }


        private void FindUpDown()
        {
            bool bFound = false;

            // find the UpDown control
            IntPtr pWnd = WIN32.GetWindow(this.Handle, WIN32.GW_CHILD);

            while (pWnd != IntPtr.Zero)
            {
                //----------------------------
                // Get the window class name
                char[] className = new char[33];

                int length = WIN32.GetClassName(pWnd, className, 32);

                string s = new string(className, 0, length);
                //----------------------------

                if (s == "msctls_updown32")
                {
                    bFound = true;
                    // not updown or Handle = 0 or handle = null, recreate one
                    if ((!bUpDown) || (scUpDown.Handle == IntPtr.Zero) || (scUpDown.Handle == null))
                    {
                        try
                        {
                            if (scUpDown.Handle != null)
                                scUpDown.DestroyHandle();
                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex.Message);
                        }

                        //----------------------------
                        // Subclass it
                        this.scUpDown = new SubClass(pWnd, true);
                        this.scUpDown.SubClassedWndProc += new SubClass.SubClassWndProcEventHandler(scUpDown_SubClassedWndProc);
                        //----------------------------

                        //Update position
                        //UpdateUpDown();

                        bUpDown = true;
                    }
                    break;
                }

                pWnd = WIN32.GetWindow(pWnd, WIN32.GW_HWNDNEXT);
            }

            if ((!bFound) && (bUpDown))
                bUpDown = false;
        }

        private void UpdateUpDown()
        {
            if (bUpDown)
            {
                if (WIN32.IsWindowVisible(scUpDown.Handle))
                {
                    Rectangle rect = new Rectangle();

                    WIN32.GetClientRect(scUpDown.Handle, ref rect);


                    //move the rect is allow close in on (TOP)
                    if ((this.Alignment == TabAlignment.Top) && (_allowCloseButton == true))
                    { WIN32.MoveWindow(scUpDown.Handle, this.Width - 60, rect.Y + 5, rect.Width, rect.Height, true); }
                    else if ((this.Alignment == TabAlignment.Top) && (_allowCloseButton == false))
                    //if ((this.Alignment == TabAlignment.Top))
                    { WIN32.MoveWindow(scUpDown.Handle, this.Width - 41, rect.Y + 5, rect.Width, rect.Height, true); }

                    //move the rect is allow close in on (Bottom)
                    if ((this.Alignment == TabAlignment.Bottom) && (_allowCloseButton == true))
                    { WIN32.MoveWindow(scUpDown.Handle, this.Width - 60, this.Height - 24, rect.Width, rect.Height, true); }
                    else if ((this.Alignment == TabAlignment.Bottom) && (_allowCloseButton == false))
                    //if ((this.Alignment == TabAlignment.Bottom))
                    { WIN32.MoveWindow(scUpDown.Handle, this.Width - 41, this.Height - 24, rect.Width, rect.Height, true); }



                    WIN32.InvalidateRect(scUpDown.Handle, ref rect, true);

                    //Try Disabling Theme
                    try
                    {
                        WIN32.SetWindowTheme(scUpDown.Handle, "", "");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        #region scUpDown_SubClassedWndProc Event Handler

        private int scUpDown_SubClassedWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WIN32.WM_PAINT:
                    {
                        //------------------------
                        // redraw
                        IntPtr hDC = WIN32.GetWindowDC(scUpDown.Handle);
                        Graphics g = Graphics.FromHdc(hDC);

                        DrawIcons(g);

                        g.Dispose();
                        WIN32.ReleaseDC(scUpDown.Handle, hDC);
                        //------------------------

                        // return 0 (processed)
                        m.Result = IntPtr.Zero;

                        //------------------------
                        // validate current rect
                        Rectangle rect = new Rectangle();

                        WIN32.GetClientRect(scUpDown.Handle, ref rect);
                        WIN32.ValidateRect(scUpDown.Handle, ref rect);
                        //------------------------

                    }
                    return 1;
            }

            return 0;
        }
        #endregion

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }


        #endregion


        #region TabpageExCollectionEditor

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
    }
}