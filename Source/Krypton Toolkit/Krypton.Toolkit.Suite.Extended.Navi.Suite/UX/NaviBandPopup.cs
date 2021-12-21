#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class NaviBandPopup : KryptonForm
    {
        #region Designer Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // NaviBandPopup2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NaviBandPopup2";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        #endregion

        // Fields
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
            get { return content; }
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
            get { return resizable; }
            set { resizable = value; }
        }

        /// <summary>
        /// Gets or sets a reference to the renderer responsible for drawing the popup
        /// </summary>
        public NaviRenderer Renderer
        {
            get { return renderer; }
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

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        /// <summary>
        /// Overriden. Raises the PaintBackground and draws the background of the Navigation band
        /// </summary>
        /// <param name="pevent">Additional paint info</param>
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
            if ((e.Button == MouseButtons.Left)
            && (e.Clicks == 1))
            {
                if (resizeBounds.Contains(e.Location))
                {
                    startDrag = e.Location;
                    dragging = true;
                }
            }
            else
                dragging = false;
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