﻿#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Core
{
    /// <summary>
    /// Represents a control that allows the selection of a colour by dragging the mouse across the desktop
    /// </summary>
    [DefaultProperty("Colour")]
    [DefaultEvent("ColourChanged")]
    public class ScreenColourPickerControl : Control, IColourEditor
    {
        #region Constants

        private static readonly object _eventColourChanged = new();

        private static readonly object _eventGridColourChanged = new();

        private static readonly object _eventImageChanged = new();

        private static readonly object _eventShowGridChanged = new();

        private static readonly object _eventShowTextWithSnapshotChanged = new();

        private static readonly object _eventZoomChanged = new();

        #endregion

        #region Fields

        private Color _colour;

        private Cursor _eyedropperCursor;

        private Color _gridColour;

        private Image _image;

        private bool _showGrid;

        private bool _showTextWithSnapshot;

        private int _zoom;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenColourPickerControl"/> class.
        /// </summary>
        public ScreenColourPickerControl()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, false);
            this.Zoom = 8;
            this.Colour = Color.Empty;
            this.ShowTextWithSnapshot = false;
            this.TabStop = false;
            this.TabIndex = 0;
            this.ShowGrid = true;
            this.GridColour = SystemColors.ControlDark;
        }

        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler GridColorChanged
        {
            add => this.Events.AddHandler(_eventGridColourChanged, value);
            remove => this.Events.RemoveHandler(_eventGridColourChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ImageChanged
        {
            add => this.Events.AddHandler(_eventImageChanged, value);
            remove => this.Events.RemoveHandler(_eventImageChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ShowGridChanged
        {
            add => this.Events.AddHandler(_eventShowGridChanged, value);
            remove => this.Events.RemoveHandler(_eventShowGridChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ShowTextWithSnapshotChanged
        {
            add => this.Events.AddHandler(_eventShowTextWithSnapshotChanged, value);
            remove => this.Events.RemoveHandler(_eventShowTextWithSnapshotChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ZoomChanged
        {
            add => this.Events.AddHandler(_eventZoomChanged, value);
            remove => this.Events.RemoveHandler(_eventZoomChanged, value);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the color of the grid.
        /// </summary>
        /// <value>The color of the grid.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "ControlDark")]
        public virtual Color GridColour
        {
            get => _gridColour;
            set
            {
                if (this.GridColour != value)
                {
                    _gridColour = value;

                    this.OnGridColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Returns if a snapshot image is available
        /// </summary>
        /// <value><c>true</c> if a snapshot image is available; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool HasSnapshot { get; protected set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Image), null)]
        public virtual Image Image
        {
            get => _image;
            set
            {
                if (this.Image != value)
                {
                    _image = value;

                    this.OnImageChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a pixel grid is displayed.
        /// </summary>
        /// <value><c>true</c> if a pixel grid is displayed; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        public virtual bool ShowGrid
        {
            get => _showGrid;
            set
            {
                if (this.ShowGrid != value)
                {
                    _showGrid = value;

                    this.OnShowGridChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether text should be shown when a snapshot is present.
        /// </summary>
        /// <value><c>true</c> if text is to be shown when a snapshot is present; otherwise, <c>false</c> to only show text when no snapshot is available.</value>
        [Category("Appearance")]
        [DefaultValue(false)]
        public virtual bool ShowTextWithSnapshot
        {
            get => _showTextWithSnapshot;
            set
            {
                if (this.ShowTextWithSnapshot != value)
                {
                    _showTextWithSnapshot = value;

                    this.OnShowTextWithSnapshotChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the tab order of the control within its container.
        /// </summary>
        /// <value>The index of the tab.</value>
        /// <returns>The index value of the control within the set of controls within its container. The controls in the container are included in the tab order.</returns>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(0)]
        public new int TabIndex
        {
            get => base.TabIndex;
            set => base.TabIndex = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the user can give the focus to this control using the TAB key.
        /// </summary>
        /// <value><c>true</c> if [tab stop]; otherwise, <c>false</c>.</value>
        /// <returns>true if the user can give the focus to the control using the TAB key; otherwise, false. The default is true.Note:This property will always return true for an instance of the <see cref="T:System.Windows.Forms.Form" /> class.</returns>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(false)]
        public new bool TabStop
        {
            get => base.TabStop;
            set => base.TabStop = value;
        }

        /// <summary>
        /// Gets or sets the zoom level of the snapshot image.
        /// </summary>
        /// <value>The zoom level.</value>
        [Category("Appearance")]
        [DefaultValue(8)]
        public virtual int Zoom
        {
            get => _zoom;
            set
            {
                if (this.Zoom != value)
                {
                    _zoom = value;

                    this.OnZoomChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating snapshot capture is in progress.
        /// </summary>
        /// <value><c>true</c> if snapshot capture is in progress; otherwise, <c>false</c>.</value>
        protected bool IsCapturing { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether redraw operations should occur.
        /// </summary>
        /// <value><c>true</c> if redraw operations should occur; otherwise, <c>false</c>.</value>
        protected bool LockUpdates { get; set; }

        /// <summary>
        /// Gets or sets the snapshot image.
        /// </summary>
        /// <value>The snapshot image.</value>
        protected Bitmap SnapshotImage { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the snapshot image.
        /// </summary>
        protected virtual void CreateSnapshotImage()
        {
            Size size;

            if (this.SnapshotImage != null)
            {
                this.SnapshotImage.Dispose();
                this.SnapshotImage = null;
            }

            size = this.GetSnapshotSize();
            if (!size.IsEmpty)
            {
                this.SnapshotImage = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
                this.Invalidate();
            }
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_eyedropperCursor != null)
                {
                    _eyedropperCursor.Dispose();
                }

                if (this.SnapshotImage != null)
                {
                    this.SnapshotImage.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Gets the center point based on the current zoom level.
        /// </summary>
        protected virtual Point GetCenterPoint()
        {
            int x;
            int y;

            x = this.ClientSize.Width / this.Zoom / 2;
            y = this.ClientSize.Height / this.Zoom / 2;

            return new Point(x, y);
        }

        /// <summary>
        /// Gets the size of the snapshot.
        /// </summary>
        protected virtual Size GetSnapshotSize()
        {
            int snapshotWidth;
            int snapshotHeight;

            snapshotWidth = (int)Math.Ceiling(this.ClientSize.Width / (double)this.Zoom);
            snapshotHeight = (int)Math.Ceiling(this.ClientSize.Height / (double)this.Zoom);

            return snapshotHeight != 0 && snapshotWidth != 0 ? new Size(snapshotWidth, snapshotHeight) : Size.Empty;
        }

        /// <summary>
        /// Raises the <see cref="ColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)this.Events[_eventColourChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.FontChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ForeColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);

            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="GridColorChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnGridColorChanged(EventArgs e)
        {
            EventHandler handler;

            this.Invalidate();

            handler = (EventHandler)this.Events[_eventGridColourChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ImageChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnImageChanged(EventArgs e)
        {
            EventHandler handler;

            this.Invalidate();

            handler = (EventHandler)this.Events[_eventImageChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left && !this.IsCapturing)
            {
                if (_eyedropperCursor == null)
                {
                    // ReSharper disable AssignNullToNotNullAttribute
                    _eyedropperCursor = new Cursor(this.GetType().Assembly.GetManifestResourceStream(
                        $"{this.GetType().Namespace}.Resources.eyedropper.cur"));
                }
                // ReSharper restore AssignNullToNotNullAttribute

                this.Cursor = _eyedropperCursor;
                this.IsCapturing = true;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.IsCapturing)
            {
                this.UpdateSnapshot();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.IsCapturing)
            {
                this.Cursor = Cursors.Default;
                this.IsCapturing = false;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            this.OnPaintBackground(e); // HACK: Easiest way of supporting things like BackgroundImage, BackgroundImageLayout etc

            // draw the current snapshot, if present
            if (this.SnapshotImage != null)
            {
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                e.Graphics.DrawImage(this.SnapshotImage, new Rectangle(0, 0, this.SnapshotImage.Width * this.Zoom, this.SnapshotImage.Height * this.Zoom), new Rectangle(Point.Empty, this.SnapshotImage.Size), GraphicsUnit.Pixel);
            }

            this.PaintAdornments(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.CreateSnapshotImage();
        }

        /// <summary>
        /// Raises the <see cref="ShowGridChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowGridChanged(EventArgs e)
        {
            EventHandler handler;

            this.Invalidate();

            handler = (EventHandler)this.Events[_eventShowGridChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ShowTextWithSnapshotChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowTextWithSnapshotChanged(EventArgs e)
        {
            EventHandler handler;

            this.Invalidate();

            handler = (EventHandler)this.Events[_eventShowTextWithSnapshotChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="ZoomChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnZoomChanged(EventArgs e)
        {
            EventHandler handler;

            this.CreateSnapshotImage();

            handler = (EventHandler)this.Events[_eventZoomChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Paints adornments onto the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected virtual void PaintAdornments(PaintEventArgs e)
        {
            // grid
            if (this.ShowGrid)
            {
                this.PaintGrid(e);
            }

            // center marker
            if (this.HasSnapshot)
            {
                this.PaintCenterMarker(e);
            }

            // image
            if (this.Image != null && (!this.HasSnapshot || this.ShowTextWithSnapshot))
            {
                e.Graphics.DrawImage(this.Image, (this.ClientSize.Width - this.Image.Size.Width) / 2, (this.ClientSize.Height - this.Image.Size.Height) / 2);
            }

            // draw text
            if (!string.IsNullOrEmpty(this.Text) && (!this.HasSnapshot || this.ShowTextWithSnapshot))
            {
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, this.BackColor, TextFormatFlags.ExpandTabs | TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis);
            }
        }

        /// <summary>
        /// Paints the center marker.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected virtual void PaintCenterMarker(PaintEventArgs e)
        {
            Point center;

            center = this.GetCenterPoint();

            using (Pen pen = new Pen(this.ForeColor))
            {
                e.Graphics.DrawRectangle(pen, center.X * this.Zoom, center.Y * this.Zoom, this.Zoom + 2, this.Zoom + 2);
            }
        }

        /// <summary>
        /// Paints the pixel grid.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected virtual void PaintGrid(PaintEventArgs e)
        {
            Rectangle viewport;
            int pixelSize;

            pixelSize = this.Zoom;
            viewport = this.ClientRectangle;

            using (Pen pen = new Pen(this.GridColour)
            {
                DashStyle = DashStyle.Dot
            })
            {
                for (int x = viewport.Left + 1; x < viewport.Right; x += pixelSize)
                {
                    e.Graphics.DrawLine(pen, x, viewport.Top, x, viewport.Bottom);
                }

                for (int y = viewport.Top + 1; y < viewport.Bottom; y += pixelSize)
                {
                    e.Graphics.DrawLine(pen, viewport.Left, y, viewport.Right, y);
                }

                e.Graphics.DrawRectangle(pen, viewport);
            }
        }

        /// <summary>
        /// Updates the snapshot.
        /// </summary>
        protected virtual void UpdateSnapshot()
        {
            Point cursor;

            cursor = MousePosition;
            cursor.X -= this.SnapshotImage.Width / 2;
            cursor.Y -= this.SnapshotImage.Height / 2;

            using (Graphics graphics = Graphics.FromImage(this.SnapshotImage))
            {
                Point center;

                // clear the image first, in case the mouse is near the borders of the screen so there isn't enough copy content to fill the area
                graphics.Clear(Color.Empty);

                // copy the image from the screen
                graphics.CopyFromScreen(cursor, Point.Empty, this.SnapshotImage.Size);

                // update the active color
                center = this.GetCenterPoint();
                this.Colour = this.SnapshotImage.GetPixel(center.X, center.Y);

                // force a redraw
                this.HasSnapshot = true;
                this.Refresh(); // just calling Invalidate isn't enough as the display will lag
            }
        }

        #endregion

        #region IColorEditor Interface

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add => this.Events.AddHandler(_eventColourChanged, value);
            remove => this.Events.RemoveHandler(_eventColourChanged, value);
        }

        /// <summary>
        /// Gets or sets the component color.
        /// </summary>
        /// <value>The component color.</value>
        [Category("Behavior")]
        [DefaultValue(typeof(Color), "Empty")]
        public virtual Color Colour
        {
            get => _colour;
            set
            {
                if (this.Colour != value)
                {
                    _colour = value;

                    this.OnColorChanged(EventArgs.Empty);
                }
            }
        }

        #endregion
    }
}