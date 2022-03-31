#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    /// <summary>
    /// Represents a container control which can be expanded or collapsed to a header bar only. 
    /// </summary>
    [
     Designer("Krypton.Toolkit.Suite.Extended.Navi.Suite.NaviGroupDesigner, Krypton.Toolkit.Suite.Extended.Navi.Suite, Version=2.0.0.0, Culture=neutral, PublicKeyToken=86dab5aa2dd98116"),
    ToolboxItem(true),
    ToolboxBitmap(typeof(NaviGroup))
    ]
    public partial class NaviGroup : NaviControl, ISupportInitialize
    {
        #region Fields

        private Region headerRegion;
        private Rectangle headerRectangle;
        private Rectangle headerTextBounds;
        private MouseEventHandler headerMouseClick;
        private InputState viewState;
        private ContextMenuStrip m_contextMenuStrip;
        private ContextMenuStrip m_headerContextMenuStrip;
        private string caption;
        private bool expanded;
        private int headerHeight;
        private int expandedHeight;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the GroupView class
        /// </summary>
        public NaviGroup()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the GroupView class
        /// </summary>
        /// <param name="container">The container to which this control belongs</param>
        public NaviGroup(IContainer container)
           : this()
        {
            container.Add(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the text displayed in the header region
        /// </summary>
        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        /// <summary>
        /// Gets or sets the height of the header
        /// </summary>
        [
        DefaultValue(20)
        ]
        public int HeaderHeight
        {
            get { return headerHeight; }
            set
            {
                if (headerHeight != value)
                {
                    CreateBounds(value);
                }
                headerHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the control is expanded or collapsed to the header only
        /// </summary>
        [
        DefaultValue(true)
        ]
        public bool Expanded
        {
            get { return expanded; }
            set
            {
                if (expanded != value)
                {
                    if (value)
                    {
                        Expand();
                    }
                    else
                    {
                        Collapse();
                    }
                }
                expanded = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the GroupView when it's expanded
        /// </summary>
        [
        DefaultValue(150),
        ]
        public int ExpandedHeight
        {
            get { return expandedHeight; }
            set { expandedHeight = value; }
        }

        /// <summary>
        /// Overriden. Gets or sets the current height of the GroupView
        /// </summary>
        public new int Height
        {
            get { return base.Height; }
            set
            {
                base.Height = value;
                // Make sure expanded hight is always as much as the height when a control 
                // is expanded. 
                if (expanded)
                    expandedHeight = value;
            }
        }

        /// <summary>
        /// Overriden. Gets or sets the ContextMenuStrip associated with this control
        /// </summary>
        public new ContextMenuStrip ContextMenuStrip
        {
            get { return m_contextMenuStrip; }
            set { m_contextMenuStrip = value; }
        }

        /// <summary>
        /// Gets or sets the shortcut menu to display when the user right-clicks the header. 
        /// </summary>
        public ContextMenuStrip HeaderContextMenuStrip
        {
            get { return m_headerContextMenuStrip; }
            set { m_headerContextMenuStrip = value; }
        }

        /// <summary>
        /// Gets the region used for the header
        /// </summary>
        [Browsable(false)]
        public Region HeaderRegion
        {
            get { return headerRegion; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the control for the first time
        /// </summary>
        private void Initialize()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            this.expanded = true;
            this.headerHeight = 20;
            this.expandedHeight = 150;
            this.viewState = InputState.Normal;
            this.Padding = new Padding(1, 1, 1, 1);
        }

        /// <summary>
        /// Creates a new Region for the header using a specified Height. 
        /// </summary>
        /// <param name="height">The height of the header</param>
        private void CreateBounds(int height)
        {
            headerRectangle = new Rectangle(0, 0, Width, height);
            headerRegion = new Region(headerRectangle);
            headerTextBounds = headerRectangle;
            if (RightToLeft == RightToLeft.Yes)
            {
                headerTextBounds.Width -= 19;
                headerTextBounds.X += 16;
            }
            else
            {
                headerTextBounds.Width -= 16;
                headerTextBounds.X += 3;
            }
            Padding = new Padding(Padding.Left, headerHeight + 2, Padding.Right, Padding.Bottom);
        }

        /// <summary>
        /// Expands the view to full height
        /// </summary>
        public void Expand()
        {
            expanded = true;
            Height = expandedHeight;
        }

        /// <summary>
        /// Collapses the view to the header only
        /// </summary>
        public void Collapse()
        {
            expanded = false;
            Height = headerHeight;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Overriden. Raises the Paint event 
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Parent is NaviBandClientArea)
            {
                ((NaviBandClientArea)Parent).PaintCanvas();
                e.Graphics.DrawImage(((NaviBandClientArea)Parent).BackgroundCanvas, 0, 0,
                   new Rectangle(Location, Size), GraphicsUnit.Pixel);
            }
            else
            {
                Renderer.DrawNaviGroupBg(e.Graphics, ClientRectangle);
            }

            Renderer.DrawNaviGroupHeader(e.Graphics, headerRectangle, viewState, expanded,
               RightToLeft == RightToLeft.Yes);

            Renderer.DrawText(e.Graphics, Renderer.CalcGroupTextbounds(headerTextBounds), this.Font, Renderer.ColourTable.Text, caption,
               RightToLeft == RightToLeft.Yes);

            if (DesignMode)
            {
                Rectangle containerRect = ClientRectangle;
                containerRect.X++;
                containerRect.Y += headerHeight + 1;
                containerRect.Width -= 3;
                containerRect.Height -= (headerHeight + 3);

                Renderer.DrawHatchedPanel(e.Graphics, containerRect);
            }
        }

        /// <summary>
        /// Overriden. Raises the PaintBackground event 
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        /// <summary>
        /// Overriden. Raises the MouseClick event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            bool headerClicked = headerRegion.IsVisible(new Point(e.X, e.Y));
            if (headerClicked)
            {
                base.OnMouseClick(e);
                OnHeaderMouseClick(e);
            }
            else
            {
                base.OnMouseClick(e);
                if ((m_contextMenuStrip != null) && (e.Button == MouseButtons.Right))
                {
                    m_contextMenuStrip.Show(this, e.Location);
                }
            }
        }

        /// <summary>
        /// Overriden. Raises the MouseMove event and shows a hand when the mouse is moved over the header
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (headerRegion.IsVisible(new Point(e.X, e.Y)))
            {
                Cursor = Cursors.Hand;
                viewState = InputState.Hovered;
                Invalidate();
            }
            else
            {
                Cursor = Cursors.Default;
                viewState = InputState.Normal;
                Invalidate();
            }
        }

        /// <summary>
        /// Overriden. Raises the MouseLeave event and changes the current cursor to the default. 
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor = Cursors.Default;
            viewState = InputState.Normal;
            Invalidate();
        }

        /// <summary>
        /// Overriden. Raises the Resize event and reinitializes the bounds of the header
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CreateBounds(headerHeight);
            Invalidate();
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            Invalidate();
        }

        #endregion

        #region Event Handling

        /// <summary>
        /// Occurs when the user clicks with the mouse inside the header region
        /// </summary>
        public event MouseEventHandler HeaderMouseClick
        {
            add { lock (threadLock) { headerMouseClick += value; } }
            remove { lock (threadLock) { headerMouseClick -= value; } }
        }

        /// <summary>
        /// Occurs when the user clicks with the mouse inside the header region
        /// </summary>
        /// <param name="e">Additional mouse event info</param>
        protected virtual void OnHeaderMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (expanded)
                {
                    Collapse();
                }
                else
                {
                    Expand();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (m_headerContextMenuStrip != null)
                {
                    m_headerContextMenuStrip.Show(this, e.Location);
                }
            }
            MouseEventHandler handler = headerMouseClick;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region ISupportInitialize Members

        /// <summary>
        /// Starts the initialization for the control
        /// </summary>
        public void BeginInit()
        {
        }

        /// <summary>
        /// Automatically creates the bounds for the control based on the current header height.
        /// </summary>
        public void EndInit()
        {
            CreateBounds(headerHeight);
        }

        #endregion
    }
}