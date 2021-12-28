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
    /// This class represents a Band which is a part of the Navigation bar
    /// </summary>
    /// <remarks>
    /// The band is the actual control container which will be displayed when the user clicks
    /// on the button which has been assigned to this band. 
    /// The size of this control is controlled by the layout engine. 
    /// </remarks>
    [
     Designer("Krypton.Toolkit.Suite.Extended.Navi.Suite.NaviBandDesigner, Krypton.Toolkit.Suite.Extended.Navi.Suite, Version=2.0.0.0, Culture=neutral, PublicKeyToken=86dab5aa2dd98116"),
    ToolboxItem(false)
    ]
    public partial class NaviBand : NaviControl
    {
        #region Fields

        private NaviButton button;
        private NaviBar ownerBar;
        private Image largeImage;
        private Image smallImage;
        private NaviBandClientArea clientArea;
        private int order;
        private int originalOrder;
        private int largeImageIndex;
        private int smallImageIndex;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the Navigation band
        /// </summary>
        public NaviBand()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the Navigation band
        /// </summary>
        public NaviBand(IContainer container)
        {
            container.Add(this);
            Initialize();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the position in a list of this band
        /// </summary>
        internal int Order
        {
            get { return order; }
            set { order = value; }
        }

        /// <summary>
        /// Gets or sets the original position in a list of this band
        /// </summary>
        internal int OriginalOrder
        {
            get { return originalOrder; }
            set { originalOrder = value; }
        }

        /// <summary>
        /// Gets or sets the large image displayed when the button is not in minimized mode
        /// </summary>
        [
        DefaultValue(null),
        Localizable(true),
        Category("Appearance"),
        Description("The image displayed when the button is not displayed as a small button"),
        ]
        public Image LargeImage
        {
            get { return largeImage; }
            set
            {
                largeImage = value;
                if (button != null)
                    button.LargeImage = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or set the image displayed when the button is in minimized mode
        /// </summary>
        [
        DefaultValue(null),
        Localizable(true),
        Description("The image displayed when the button is displayed as a small button"),
        ]
        public Image SmallImage
        {
            get { return smallImage; }
            set
            {
                smallImage = value;
                if (button != null)
                    button.SmallImage = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The image displayed when the button is not displayed as a small button
        /// </summary>
        [
        Category("Appearance"),
        Description("The image displayed when the button is not displayed as a small button"),
        Editor(typeof(LargeImageIndexEditor), typeof(System.Drawing.Design.UITypeEditor)),
        TypeConverter(typeof(LargeImageIndexConverter)),
        ]
        public int LargeImageIndex
        {
            get { return largeImageIndex; }
            set
            {
                largeImageIndex = value;
                if (button != null)
                    button.Invalidate();
            }
        }

        /// <summary>
        /// The image displayed when the button is displayed as a small button
        /// </summary>
        [
        Category("Appearance"),
        Description("The image displayed when the button is displayed as a small button"),
        Editor(typeof(SmallImageIndexEditor), typeof(System.Drawing.Design.UITypeEditor)),
        TypeConverter(typeof(SmallImageIndexConverter)),
        ]
        public int SmallImageIndex
        {
            get { return smallImageIndex; }
            set
            {
                smallImageIndex = value;
                if (button != null)
                    button.Invalidate();
            }
        }

        /// <summary>
        /// Gets the list of large images
        /// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public ImageList LargeImages
        {
            get { return ownerBar.LargeImages; }
        }

        /// <summary>
        /// Gets the list of small images
        /// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public ImageList SmallImages
        {
            get { return ownerBar.SmallImages; }
        }

        /// <summary>
        /// Gets the button which is associated with this band
        /// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public NaviButton Button
        {
            get { return button; }
            internal set
            {
                button = value;
                button.Band = this;
                button.Text = Text;
            }
        }

        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)
        ]
        public NaviBandClientArea ClientArea
        {
            get { return clientArea; }
            set { clientArea = value; }
        }

        /// <summary>
        /// Gets or sets the renderer for this control
        /// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public override NaviRenderer Renderer
        {
            get { return base.Renderer; }
            set { base.Renderer = value; clientArea.Renderer = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the owner bar for this control
        /// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public NaviBar OwnerBar
        {
            get { return ownerBar; }
            internal set { ownerBar = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the control for the first time. 
        /// </summary>
        internal void Initialize()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            if (clientArea == null)
                clientArea = new NaviBandClientArea();

            clientArea.Name = "ClientArea";
            clientArea.Location = new Point(0, 0);
            clientArea.Size = Size;
            clientArea.Renderer = Renderer;

            if (!Controls.Contains(clientArea))
                Controls.Add(clientArea);

            ResizeRedraw = true;
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
            Renderer.DrawNaviBandBg(e.Graphics, ClientRectangle);
        }

        /// <summary>
        /// Overriden. Raises the PaintBackground and draws the background of the Navigation band
        /// </summary>
        /// <param name="pevent">Additional paint info</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        /// <summary>
        /// Overriden. Raises the Resize event and Invalidates the control
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            clientArea.Size = Size;
            Invalidate();
        }

        /// <summary>
        /// Overriden. Raises the TetChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (button != null)
                button.Text = Text;
        }

        /// <summary>
        /// Overloaded. Raises the VisibleChanged event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (button != null)
                button.Visible = Visible;
        }

        #endregion
    }
}
