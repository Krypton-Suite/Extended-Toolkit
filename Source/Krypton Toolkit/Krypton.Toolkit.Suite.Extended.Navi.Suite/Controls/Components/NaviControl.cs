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
    /// Represents a control with customizable drawing and layout styles
    /// </summary>
    [ToolboxItem(false)]
    public partial class NaviControl : ContainerControl
    {
        private NaviLayoutStyle layoutStyle = NaviLayoutStyle.Office2007Blue;
        private EventHandler layoutStyleChanged;
        private NaviRenderer renderer;

        protected readonly object threadLock = new object();

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NaviControl
        /// </summary>
        public NaviControl()
        {
        }

        /// <summary>
        /// Initializes a new instance of the NaviControl
        /// </summary>
        /// <param name="container">The parent container</param>
        public NaviControl(IContainer container)
        {
            container.Add(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Indicates how the control is presented to the user
        /// </summary>
        [DefaultValue(NaviLayoutStyle.Office2007Blue)]
        public NaviLayoutStyle LayoutStyle
        {
            get { return layoutStyle; }
            set
            {
                layoutStyle = value;
                if (layoutStyle != NaviLayoutStyle.StyleFromOwner)
                    renderer = null;
                OnLayoutStyleChanged(new EventArgs());
            }
        }

        /// <summary>
        /// Gets or sets the renderer responsible for drawing the control
        /// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public virtual NaviRenderer Renderer
        {
            get { return renderer; }
            set
            {
                renderer = value;
                layoutStyle = NaviLayoutStyle.StyleFromOwner;
                Invalidate();
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs after the layout style has been changed
        /// </summary>
        public event EventHandler LayoutStyleChanged
        {
            add { lock (threadLock) { layoutStyleChanged += value; } }
            remove { lock (threadLock) { layoutStyleChanged -= value; } }
        }

        #endregion

        #region Methods

        private void InitializeRenderer()
        {
            renderer = new NaviOffice7Renderer();

            switch (layoutStyle)
            {
                case NaviLayoutStyle.Office2003Blue:
                case NaviLayoutStyle.Office2003Green:
                case NaviLayoutStyle.Office2003Silver:
                    renderer = new NaviOffice3Renderer();
                    renderer.Initialize(layoutStyle);
                    break;
                case NaviLayoutStyle.Office2007Blue:
                case NaviLayoutStyle.Office2007Silver:
                case NaviLayoutStyle.Office2007Black:
                    renderer = new NaviOffice7Renderer();
                    renderer.Initialize(layoutStyle);
                    break;
                case NaviLayoutStyle.Office2010Blue:
                case NaviLayoutStyle.Office2010Silver:
                case NaviLayoutStyle.Office2010Black:
                    renderer = new NaviOffice10Renderer();
                    renderer.Initialize(layoutStyle);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Raises the LayoutStyleChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected virtual void OnLayoutStyleChanged(EventArgs e)
        {
            EventHandler handler = layoutStyleChanged;
            if (handler != null)
                handler(this, e);
            Invalidate();
        }

        /// <summary>
        /// Overriden. Raises the Paint event
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (renderer == null)
            {
                InitializeRenderer();
            }
        }

        /// <summary>
        /// Overriden. Raises the PaintBackground
        /// </summary>
        /// <param name="pevent">Additional paint info</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (renderer == null)
            {
                InitializeRenderer();
            }
        }

        #endregion
    }
}