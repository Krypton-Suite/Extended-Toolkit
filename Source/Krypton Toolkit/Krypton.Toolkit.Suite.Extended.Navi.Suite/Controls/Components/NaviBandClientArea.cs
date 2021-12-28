#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    [ToolboxItem(false)]
    public partial class NaviBandClientArea : NaviControl
    {
        // Fields
        private Bitmap backgroundCanvas;

        /// <summary>
        /// Initializes a new instance of the NaviBandClientArea
        /// </summary>
        public NaviBandClientArea()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the NaviBandClientArea
        /// </summary>
        public NaviBandClientArea(IContainer container)
        {
            container.Add(this);
            Initialize();
        }

        #region Properties

        /// <summary>
        /// Gets a bitmap containing the background of the ClientArea, 
        /// </summary>
        /// <remarks>This bitmap is used for faking opacity of the NaviGroup</remarks>
        public Bitmap BackgroundCanvas
        {
            get { return backgroundCanvas; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the 7control for the first time. 
        /// </summary>
        private void Initialize()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void InitializeCanvas()
        {
            if (backgroundCanvas != null)
                backgroundCanvas.Dispose();

            if (Size.Width == 0)
                Size = new System.Drawing.Size(1, Size.Height);
            if (Size.Height == 0)
                Size = new System.Drawing.Size(Size.Width, 1);

            backgroundCanvas = new Bitmap(Size.Width, Size.Height, PixelFormat.Format32bppPArgb);
        }

        /// <summary>
        /// Paints the background on a temporary cache
        /// </summary>
        public void PaintCanvas()
        {
            using (Graphics bitGraphics = Graphics.FromImage(backgroundCanvas))
            {
                if (Renderer != null)
                    Renderer.DrawNaviBandClientAreaBg(bitGraphics, ClientRectangle);
            }
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
        }

        /// <summary>
        /// Overriden. Raises the PaintBackground event
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            PaintCanvas();
            if (backgroundCanvas == null)
                InitializeCanvas();
            e.Graphics.DrawImageUnscaled(backgroundCanvas, new Point(0, 0));
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            InitializeCanvas();
            PaintCanvas();
            Invalidate();

            foreach (Control control in Controls)
                control.Invalidate();
        }

        #endregion
    }
}