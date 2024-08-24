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

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public partial class NaviBandPopup : KryptonForm
    {
        private NaviRenderer renderer = new NaviOffice7Renderer();
        private Point startDrag;
        private Control content;
        private Rectangle resizeBounds;
        private bool resizable;
        private bool dragging;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviBandPopup class
        /// </summary>
        public NaviBandPopup()
        {
            InitializeComponent();
            ResizeRedraw = true;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            Padding = new Padding(3);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the actual content of the popup form
        /// </summary>
        public Control Content
        {
            get => content;
            set
            {
                content = value;
                if (content != null)
                {
                    Controls.Clear();
                    content.Dock = DockStyle.Fill;
                    Controls.Add(content);
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the popup is resizable
        /// </summary>
        public bool Resizable
        {
            get => resizable;
            set => resizable = value;
        }

        /// <summary>
        /// Gets or sets a reference to the renderer responsible for drawing the popup
        /// </summary>
        public new NaviRenderer Renderer
        {
            get => renderer;
            set { renderer = value; Invalidate(); }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Calculates the bounds of the resizing grip
        /// </summary>
        private void CalculateResizeBounds()
        {
            if (RightToLeft == RightToLeft.No)
            {
                resizeBounds = new Rectangle(Width - 3, 0, 3, Height);
            }
            else
            {
                resizeBounds = new Rectangle(0, 0, 3, Height);
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Gets additional creation params
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                return param;
            }
        }

        /// <summary>
        /// Overriden. Raises the Paint event
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override bool ShowWithoutActivation => true;

        /// <summary>
        /// Overriden. Raises the PaintBackground and draws the background of the Navigation band
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            renderer.DrawNaviBandPopupBg(e.Graphics, ClientRectangle);
        }

        /// <summary>
        /// Overriden. Raises the MouseDown event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left
            && e.Clicks == 1)
            {
                if (resizeBounds.Contains(e.Location))
                {
                    startDrag = e.Location;
                    dragging = true;
                }
            }
            else
            {
                dragging = false;
            }
        }

        /// <summary>
        /// Overriden. Raises the MouseDown event.
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (dragging)
            {
                int newWidth;
                if (RightToLeft == RightToLeft.Yes)
                {
                    int incAmount = PointToScreen(e.Location).X - Location.X;
                    newWidth = Size.Width - incAmount + 3;

                    if (newWidth < MinimumSize.Width)
                    {
                        Size = new Size(MinimumSize.Width, Size.Height);
                    }
                    else
                    {
                        Size = new Size(Size.Width - incAmount + 3, Size.Height);
                        Location = new Point(Location.X + incAmount - 3, Location.Y);
                    }
                }
                else
                {
                    newWidth = e.Location.X + 3;
                    Size = new Size(newWidth < MinimumSize.Width ? MinimumSize.Width : e.Location.X + 3,
                       Size.Height);

                    Cursor = Cursors.SizeWE;
                }
            }
            else if (resizeBounds.Contains(e.Location))
            {
                Cursor = Cursors.SizeWE;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Overriden. Raises the MouseLeave event and changes the cursor back to default
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            dragging = false;
        }

        /// <summary>
        /// Overloaded. Raises the Resize event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CalculateResizeBounds();
        }

        /// <summary>
        /// Overriden. Raises the MouseUp event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            dragging = false;
        }

        /// <summary>
        /// Overriden. Raises the RightToLeftChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            CalculateResizeBounds();
        }

        #endregion
    }
}