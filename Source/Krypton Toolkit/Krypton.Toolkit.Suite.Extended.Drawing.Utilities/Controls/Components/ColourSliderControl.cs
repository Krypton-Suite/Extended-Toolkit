﻿#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    /// <summary>
    /// Represents a control for selecting a value from a scale
    /// </summary>
    [DefaultValue("Value"), DefaultEvent("ValueChanged"), ToolboxItem(false)]
    public class ColourSliderControl : Control
    {
        #region Constants

        private static readonly object _eventBarBoundsChanged = new object();

        private static readonly object _eventBarPaddingChanged = new object();

        private static readonly object _eventBarStyleChanged = new object();

        private static readonly object _eventColour1Changed = new object();

        private static readonly object _eventColour2Changed = new object();

        private static readonly object _eventColour3Changed = new object();

        private static readonly object _eventCustomColoursChanged = new object();

        private static readonly object _eventDividerStyleChanged = new object();

        private static readonly object _eventLargeChangeChanged = new object();

        private static readonly object _eventMaximumChanged = new object();

        private static readonly object _eventMinimumChanged = new object();

        private static readonly object _eventNubColourChanged = new object();

        private static readonly object _eventNubSizeChanged = new object();

        private static readonly object _eventNubStyleChanged = new object();

        private static readonly object _eventOrientationChanged = new object();

        private static readonly object _eventShowValueDividerChanged = new object();

        private static readonly object _eventSmallChangeChanged = new object();

        private static readonly object _eventValueChanged = new object();

        #endregion

        #region Fields

        private Rectangle _barBounds;

        private Padding _barPadding;

        private ColourBarStyle _barStyle;

        private Color _colour1;

        private Color _colour2;

        private Color _colour3;

        private ColourCollection _customColours;

        private int _largeChange;

        private float _maximum;

        private float _minimum;

        private Color _nubColour;

        private Size _nubSize;

        private ColourSliderNubStyle _nubStyle;

        private Orientation _orientation;

        private bool _showValueDivider;

        private int _smallChange;

        private float _value;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColourSliderControl"/> class.
        /// </summary>
        public ColourSliderControl()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable, true);
            this.Orientation = Orientation.Horizontal;
            this.Colour1 = Color.Black;
            this.Colour2 = Color.FromArgb(127, 127, 127);
            this.Colour3 = Color.White;
            this.Minimum = 0;
            this.Maximum = 100;
            this.NubStyle = ColourSliderNubStyle.BottomRight;
            this.NubSize = new Size(8, 8);
            this.NubColour = Color.Black;
            this.SmallChange = 1;
            this.LargeChange = 10;
        }

        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler BarBoundsChanged
        {
            add => this.Events.AddHandler(_eventBarBoundsChanged, value);
            remove => this.Events.RemoveHandler(_eventBarBoundsChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler BarPaddingChanged
        {
            add => this.Events.AddHandler(_eventBarPaddingChanged, value);
            remove => this.Events.RemoveHandler(_eventBarPaddingChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler BarStyleChanged
        {
            add => this.Events.AddHandler(_eventBarStyleChanged, value);
            remove => this.Events.RemoveHandler(_eventBarStyleChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler Colour1Changed
        {
            add => this.Events.AddHandler(_eventColour1Changed, value);
            remove => this.Events.RemoveHandler(_eventColour1Changed, value);
        }

        [Category("Property Changed")]
        public event EventHandler Colour2Changed
        {
            add => this.Events.AddHandler(_eventColour2Changed, value);
            remove => this.Events.RemoveHandler(_eventColour2Changed, value);
        }

        [Category("Property Changed")]
        public event EventHandler Colour3Changed
        {
            add => this.Events.AddHandler(_eventColour3Changed, value);
            remove => this.Events.RemoveHandler(_eventColour3Changed, value);
        }

        [Category("Property Changed")]
        public event EventHandler CustomColoursChanged
        {
            add => this.Events.AddHandler(_eventCustomColoursChanged, value);
            remove => this.Events.RemoveHandler(_eventCustomColoursChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler DividerStyleChanged
        {
            add => this.Events.AddHandler(_eventDividerStyleChanged, value);
            remove => this.Events.RemoveHandler(_eventDividerStyleChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler LargeChangeChanged
        {
            add => this.Events.AddHandler(_eventLargeChangeChanged, value);
            remove => this.Events.RemoveHandler(_eventLargeChangeChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler MaximumChanged
        {
            add => this.Events.AddHandler(_eventMaximumChanged, value);
            remove => this.Events.RemoveHandler(_eventMaximumChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler MinimumChanged
        {
            add => this.Events.AddHandler(_eventMinimumChanged, value);
            remove => this.Events.RemoveHandler(_eventMinimumChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler NubColourChanged
        {
            add => this.Events.AddHandler(_eventNubColourChanged, value);
            remove => this.Events.RemoveHandler(_eventNubColourChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler NubSizeChanged
        {
            add => this.Events.AddHandler(_eventNubSizeChanged, value);
            remove => this.Events.RemoveHandler(_eventNubSizeChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler NubStyleChanged
        {
            add => this.Events.AddHandler(_eventNubStyleChanged, value);
            remove => this.Events.RemoveHandler(_eventNubStyleChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler OrientationChanged
        {
            add => this.Events.AddHandler(_eventOrientationChanged, value);
            remove => this.Events.RemoveHandler(_eventOrientationChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ShowValueDividerChanged
        {
            add => this.Events.AddHandler(_eventShowValueDividerChanged, value);
            remove => this.Events.RemoveHandler(_eventShowValueDividerChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler SmallChangeChanged
        {
            add => this.Events.AddHandler(_eventSmallChangeChanged, value);
            remove => this.Events.RemoveHandler(_eventSmallChangeChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ValueChanged
        {
            add => this.Events.AddHandler(_eventValueChanged, value);
            remove => this.Events.RemoveHandler(_eventValueChanged, value);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the location and size of the colour bar.
        /// </summary>
        /// <value>The location and size of the colour bar.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Rectangle BarBounds
        {
            get => _barBounds;
            protected set
            {
                if (this.BarBounds != value)
                {
                    _barBounds = value;

                    this.OnBarBoundsChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the bar padding.
        /// </summary>
        /// <value>The bar padding.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Padding BarPadding
        {
            get => _barPadding;
            protected set
            {
                if (this.BarPadding != value)
                {
                    _barPadding = value;

                    this.OnBarPaddingChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the bar style.
        /// </summary>
        /// <value>The bar style.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(ColourBarStyle), "TwoColour")]
        public virtual ColourBarStyle BarStyle
        {
            get => _barStyle;
            set
            {
                if (this.BarStyle != value)
                {
                    _barStyle = value;

                    this.OnBarStyleChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the first colour of the bar.
        /// </summary>
        /// <value>The first colour.</value>
        /// <remarks>This property is ignored if the <see cref="BarStyle"/> property is set to Custom and a valid colour set has been specified</remarks>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
        public virtual Color Colour1
        {
            get => _colour1;
            set
            {
                if (this.Colour1 != value)
                {
                    _colour1 = value;

                    this.OnColour1Changed(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the second colour of the bar.
        /// </summary>
        /// <value>The second colour.</value>
        /// <remarks>This property is ignored if the <see cref="BarStyle"/> property is set to Custom and a valid colour set has been specified</remarks>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "127, 127, 127")]
        public virtual Color Colour2
        {
            get => _colour2;
            set
            {
                if (this.Colour2 != value)
                {
                    _colour2 = value;

                    this.OnColour2Changed(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the third colour of the bar.
        /// </summary>
        /// <value>The third colour.</value>
        /// <remarks>This property is ignored if the <see cref="BarStyle"/> property is set to Custom and a valid colour set has been specified, or if the BarStyle is set to TwoColour.</remarks>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "White")]
        public virtual Color Colour3
        {
            get => _colour3;
            set
            {
                if (this.Colour3 != value)
                {
                    _colour3 = value;

                    this.OnColour3Changed(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the colour range used by the custom bar style.
        /// </summary>
        /// <value>The custom colours.</value>
        /// <remarks>This property is ignored if the <see cref="BarStyle"/> property is not set to Custom</remarks>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ColourCollection CustomColours
        {
            get => _customColours;
            set
            {
                if (this.CustomColours != value)
                {
                    _customColours = value;

                    this.OnCustomColoursChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        /// <returns>The <see cref="T:System.Drawing.Font" /> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont" /> property.</returns>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font
        {
            get => base.Font;
            set => base.Font = value;
        }

        /// <summary>
        /// Gets or sets the foreground colour of the control.
        /// </summary>
        /// <value>The colour of the fore.</value>
        /// <returns>The foreground <see cref="T:System.Drawing.Colour" /> of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultForeColour" /> property.</returns>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set => base.ForeColor = value;
        }

        /// <summary>
        /// Gets or sets a value to be added to or subtracted from the <see cref="Value"/> property when the selection is moved a large distance.
        /// </summary>
        /// <value>A numeric value. The default value is 10.</value>
        [Category("Behavior")]
        [DefaultValue(10)]
        public virtual int LargeChange
        {
            get => _largeChange;
            set
            {
                if (this.LargeChange != value)
                {
                    _largeChange = value;

                    this.OnLargeChangeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the upper limit of values of the selection range.
        /// </summary>
        /// <value>A numeric value. The default value is 100.</value>
        [Category("Behavior")]
        [DefaultValue(100F)]
        public virtual float Maximum
        {
            get => _maximum;
            set
            {
                // ReSharper disable CompareOfFloatsByEqualityOperator
                if (this.Maximum != value)
                // ReSharper restore CompareOfFloatsByEqualityOperator
                {
                    _maximum = value;

                    this.OnMaximumChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the lower limit of values of the selection range.
        /// </summary>
        /// <value>A numeric value. The default value is 0.</value>
        [Category("Behavior")]
        [DefaultValue(0F)]
        public virtual float Minimum
        {
            get => _minimum;
            set
            {
                // ReSharper disable CompareOfFloatsByEqualityOperator
                if (this.Minimum != value)
                // ReSharper restore CompareOfFloatsByEqualityOperator
                {
                    _minimum = value;

                    this.OnMinimumChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the colour of the selection nub.
        /// </summary>
        /// <value>The colour of the nub.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
        public virtual Color NubColour
        {
            get => _nubColour;
            set
            {
                if (this.NubColour != value)
                {
                    _nubColour = value;

                    this.OnNubColourChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the size of the selection nub.
        /// </summary>
        /// <value>The size of the nub.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Size), "8, 8")]
        public virtual Size NubSize
        {
            get => _nubSize;
            set
            {
                if (this.NubSize != value)
                {
                    _nubSize = value;

                    this.OnNubSizeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the selection nub style.
        /// </summary>
        /// <value>The nub style.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(ColourSliderNubStyle), "BottomRight")]
        public virtual ColourSliderNubStyle NubStyle
        {
            get => _nubStyle;
            set
            {
                if (this.NubStyle != value)
                {
                    _nubStyle = value;

                    this.OnNubStyleChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the orientation of the colour bar.
        /// </summary>
        /// <value>The orientation.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Orientation), "Horizontal")]
        public virtual Orientation Orientation
        {
            get => _orientation;
            set
            {
                if (this.Orientation != value)
                {
                    _orientation = value;

                    this.OnOrientationChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a divider is shown at the selection nub location.
        /// </summary>
        /// <value><c>true</c> if a value divider is to be shown; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(false)]
        public virtual bool ShowValueDivider
        {
            get => _showValueDivider;
            set
            {
                if (this.ShowValueDivider != value)
                {
                    _showValueDivider = value;

                    this.OnShowValueDividerChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the value to be added to or subtracted from the <see cref="Value"/> property when the selection is moved a small distance.
        /// </summary>
        /// <value>A numeric value. The default value is 1.</value>
        [Category("Behavior")]
        [DefaultValue(1)]
        public virtual int SmallChange
        {
            get => _smallChange;
            set
            {
                if (this.SmallChange != value)
                {
                    _smallChange = value;

                    this.OnSmallChangeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        /// <returns>The text associated with this control.</returns>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        /// <summary>
        /// Gets or sets a numeric value that represents the current position of the selection numb on the colour slider control.
        /// </summary>
        /// <value>A numeric value that is within the <see cref="Minimum"/> and <see cref="Maximum"/> range. The default value is 0.</value>
        [Category("Appearance")]
        [DefaultValue(0F)]
        public virtual float Value
        {
            get => _value;
            set
            {
                if (value < this.Minimum)
                {
                    value = this.Minimum;
                }
                if (value > this.Maximum)
                {
                    value = this.Maximum;
                }

                // ReSharper disable CompareOfFloatsByEqualityOperator
                if (this.Value != value)
                // ReSharper restore CompareOfFloatsByEqualityOperator
                {
                    _value = value;

                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the selection glyph.
        /// </summary>
        /// <value>The selection glyph.</value>
        protected Image SelectionGlyph { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the selection nub glyph.
        /// </summary>
        /// <returns>Image.</returns>
        protected virtual Image CreateNubGlyph()
        {
            Image image;

            image = new Bitmap(this.NubSize.Width + 1, this.NubSize.Height + 1, PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(image))
            {
                Point[] outer;
                Point firstCorner;
                Point lastCorner;
                Point tipCorner;

                if (this.NubStyle == ColourSliderNubStyle.BottomRight)
                {
                    lastCorner = new Point(this.NubSize.Width, this.NubSize.Height);

                    if (this.Orientation == Orientation.Horizontal)
                    {
                        firstCorner = new Point(0, this.NubSize.Height);
                        tipCorner = new Point(this.NubSize.Width / 2, 0);
                    }
                    else
                    {
                        firstCorner = new Point(this.NubSize.Width, 0);
                        tipCorner = new Point(0, this.NubSize.Height / 2);
                    }
                }
                else
                {
                    firstCorner = Point.Empty;

                    if (this.Orientation == Orientation.Horizontal)
                    {
                        lastCorner = new Point(this.NubSize.Width, 0);
                        tipCorner = new Point(this.NubSize.Width / 2, this.NubSize.Height);
                    }
                    else
                    {
                        lastCorner = new Point(0, this.NubSize.Height);
                        tipCorner = new Point(this.NubSize.Width, this.NubSize.Height / 2);
                    }
                }

                // draw the shape
                outer = new[]
                        {
                  firstCorner,
                  lastCorner,
                  tipCorner
                };

                // TODO: Add 3D edging similar to the mousewheel's diamond

                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (Brush brush = new SolidBrush(this.NubColour))
                {
                    g.FillPolygon(brush, outer);
                }
            }

            return image;
        }

        /// <summary>
        /// Defines the bar bounds and padding.
        /// </summary>
        protected virtual void DefineBar()
        {
            if (this.SelectionGlyph != null)
            {
                this.SelectionGlyph.Dispose();
            }

            this.BarPadding = this.GetBarPadding();
            this.BarBounds = this.GetBarBounds();
            this.SelectionGlyph = this.NubStyle != ColourSliderNubStyle.None ? this.CreateNubGlyph() : null;
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.SelectionGlyph != null)
            {
                this.SelectionGlyph.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Gets the bar bounds.
        /// </summary>
        /// <returns>Rectangle.</returns>
        protected virtual Rectangle GetBarBounds()
        {
            Rectangle clientRectangle;
            Padding padding;

            clientRectangle = this.ClientRectangle;
            padding = this.BarPadding + this.Padding;

            return new Rectangle(clientRectangle.Left + padding.Left, clientRectangle.Top + padding.Top, clientRectangle.Width - padding.Horizontal, clientRectangle.Height - padding.Vertical);
        }

        /// <summary>
        /// Gets the bar padding.
        /// </summary>
        /// <returns>Padding.</returns>
        protected virtual Padding GetBarPadding()
        {
            int left;
            int top;
            int right;
            int bottom;

            left = 0;
            top = 0;
            right = 0;
            bottom = 0;

            switch (this.NubStyle)
            {
                case ColourSliderNubStyle.BottomRight:
                    if (this.Orientation == Orientation.Horizontal)
                    {
                        bottom = this.NubSize.Height + 1;
                        left = this.NubSize.Width / 2 + 1;
                        right = left;
                    }
                    else
                    {
                        right = this.NubSize.Width + 1;
                        top = this.NubSize.Height / 2 + 1;
                        bottom = top;
                    }
                    break;
                case ColourSliderNubStyle.TopLeft:
                    if (this.Orientation == Orientation.Horizontal)
                    {
                        top = this.NubSize.Height + 1;
                        left = this.NubSize.Width / 2 + 1;
                        right = left;
                    }
                    else
                    {
                        left = this.NubSize.Width + 1;
                        top = this.NubSize.Height / 2 + 1;
                        bottom = top;
                    }
                    break;
            }

            return new Padding(left, top, right, bottom);
        }

        /// <summary>
        /// Determines whether the specified key is a regular input key or a special key that requires preprocessing.
        /// </summary>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values.</param>
        /// <returns>true if the specified key is a regular input key; otherwise, false.</returns>
        protected override bool IsInputKey(Keys keyData)
        {
            bool result;

            if ((keyData & Keys.Left) == Keys.Left || (keyData & Keys.Up) == Keys.Up || (keyData & Keys.Down) == Keys.Down || (keyData & Keys.Right) == Keys.Right || (keyData & Keys.PageUp) == Keys.PageUp || (keyData & Keys.PageDown) == Keys.PageDown || (keyData & Keys.Home) == Keys.Home || (keyData & Keys.End) == Keys.End)
            {
                result = true;
            }
            else
            {
                result = base.IsInputKey(keyData);
            }

            return result;
        }

        /// <summary>
        /// Raises the <see cref="BarBoundsChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnBarBoundsChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)this.Events[_eventBarBoundsChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="BarPaddingChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnBarPaddingChanged(EventArgs e)
        {
            EventHandler handler;

            this.Invalidate();

            handler = (EventHandler)this.Events[_eventBarPaddingChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="BarStyleChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnBarStyleChanged(EventArgs e)
        {
            EventHandler handler;

            this.Invalidate();

            handler = (EventHandler)this.Events[_eventBarStyleChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="Colour1Changed" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColour1Changed(EventArgs e)
        {
            EventHandler handler;

            this.Invalidate();

            handler = (EventHandler)this.Events[_eventColour1Changed];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="Colour2Changed" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColour2Changed(EventArgs e)
        {
            EventHandler handler;

            this.Invalidate();

            handler = (EventHandler)this.Events[_eventColour2Changed];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="Colour3Changed" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColour3Changed(EventArgs e)
        {
            EventHandler handler;

            this.Invalidate();

            handler = (EventHandler)this.Events[_eventColour3Changed];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="CustomColoursChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnCustomColoursChanged(EventArgs e)
        {
            EventHandler handler;

            this.Invalidate();

            handler = (EventHandler)this.Events[_eventCustomColoursChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="DividerStyleChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnDividerStyleChanged(EventArgs e)
        {
            EventHandler handler;

            this.DefineBar();
            this.Invalidate();

            handler = (EventHandler)this.Events[_eventDividerStyleChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            int step;
            float value;

            step = e.Shift ? this.LargeChange : this.SmallChange;
            value = this.Value;

            switch (e.KeyCode)
            {
                case Keys.Right:
                case Keys.Down:
                    value += step;
                    break;
                case Keys.Left:
                case Keys.Up:
                    value -= step;
                    break;
                case Keys.PageDown:
                    value += this.LargeChange;
                    break;
                case Keys.PageUp:
                    value -= this.LargeChange;
                    break;
                case Keys.Home:
                    value = this.Minimum;
                    break;
                case Keys.End:
                    value = this.Maximum;
                    break;
            }

            if (value < this.Minimum)
            {
                value = this.Minimum;
            }

            if (value > this.Maximum)
            {
                value = this.Maximum;
            }

            // ReSharper disable CompareOfFloatsByEqualityOperator
            if (value != this.Value)
            // ReSharper restore CompareOfFloatsByEqualityOperator
            {
                this.Value = value;

                e.Handled = true;
            }

            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raises the <see cref="LargeChangeChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnLargeChangeChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)this.Events[_eventLargeChangeChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="MaximumChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnMaximumChanged(EventArgs e)
        {
            EventHandler handler;

            this.Invalidate();

            handler = (EventHandler)this.Events[_eventMaximumChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="MinimumChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnMinimumChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)this.Events[_eventMinimumChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!this.Focused && this.TabStop)
            {
                this.Focus();
            }

            if (e.Button == MouseButtons.Left)
            {
                this.PointToValue(e.Location);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
            {
                this.PointToValue(e.Location);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseWheel"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data. </param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            float value;

            base.OnMouseWheel(e);

            value = this.Value + -(e.Delta / SystemInformation.MouseWheelScrollDelta * SystemInformation.MouseWheelScrollLines);

            if (value < this.Minimum)
            {
                value = this.Minimum;
            }

            if (value > this.Maximum)
            {
                value = this.Maximum;
            }

            this.Value = value;
        }

        /// <summary>
        /// Raises the <see cref="NubColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnNubColourChanged(EventArgs e)
        {
            EventHandler handler;

            this.Invalidate();

            handler = (EventHandler)this.Events[_eventNubColourChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="NubSizeChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnNubSizeChanged(EventArgs e)
        {
            EventHandler handler;

            this.DefineBar();
            this.Invalidate();

            handler = (EventHandler)this.Events[_eventNubSizeChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="NubStyleChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnNubStyleChanged(EventArgs e)
        {
            EventHandler handler;

            this.DefineBar();
            this.Invalidate();

            handler = (EventHandler)this.Events[_eventNubStyleChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="OrientationChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnOrientationChanged(EventArgs e)
        {
            EventHandler handler;

            this.DefineBar();
            this.Invalidate();

            handler = (EventHandler)this.Events[_eventOrientationChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.PaddingChanged" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);

            this.DefineBar();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            this.PaintBar(e);
            this.PaintAdornments(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.DefineBar();
        }

        /// <summary>
        /// Raises the <see cref="ShowValueDividerChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowValueDividerChanged(EventArgs e)
        {
            EventHandler handler;

            this.Invalidate();

            handler = (EventHandler)this.Events[_eventShowValueDividerChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="SmallChangeChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnSmallChangeChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)this.Events[_eventSmallChangeChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ValueChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnValueChanged(EventArgs e)
        {
            EventHandler handler;

            this.Refresh();

            handler = (EventHandler)this.Events[_eventValueChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Paints control adornments.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected virtual void PaintAdornments(PaintEventArgs e)
        {
            Point point;

            point = this.ValueToPoint(this.Value);

            // divider
            if (ShowValueDivider)
            {
                Point start;
                Point end;
                IntPtr hdc;

                if (Orientation == Orientation.Horizontal)
                {
                    start = new Point(point.X, this.BarBounds.Top);
                    end = new Point(point.X, this.BarBounds.Bottom);
                }
                else
                {
                    start = new Point(this.BarBounds.Left, point.Y);
                    end = new Point(this.BarBounds.Right, point.Y);
                }

                // draw a XOR'd line using Win32 API as this functionality isn't part of .NET
                hdc = e.Graphics.GetHdc();
                DrawingUtilitiesNativeMethods.SetROP2(hdc, DrawingUtilitiesNativeMethods.R2_NOT);
                DrawingUtilitiesNativeMethods.MoveToEx(hdc, start.X, start.Y, IntPtr.Zero);
                DrawingUtilitiesNativeMethods.LineTo(hdc, end.X, end.Y);
                e.Graphics.ReleaseHdc(hdc);
            }

            // drag nub
            if (this.NubStyle != ColourSliderNubStyle.None && this.SelectionGlyph != null)
            {
                int x;
                int y;

                if (this.Orientation == Orientation.Horizontal)
                {
                    x = point.X - this.NubSize.Width / 2;
                    if (this.NubStyle == ColourSliderNubStyle.BottomRight)
                    {
                        y = this.BarBounds.Bottom;
                    }
                    else
                    {
                        y = this.BarBounds.Top - this.NubSize.Height;
                    }
                }
                else
                {
                    y = point.Y - this.NubSize.Height / 2;
                    if (this.NubStyle == ColourSliderNubStyle.BottomRight)
                    {
                        x = this.BarBounds.Right;
                    }
                    else
                    {
                        x = this.BarBounds.Left - this.NubSize.Width;
                    }
                }

                e.Graphics.DrawImage(this.SelectionGlyph, x, y);
            }

            // focus
            if (this.Focused)
            {
                ControlPaint.DrawFocusRectangle(e.Graphics, Rectangle.Inflate(this.BarBounds, -2, -2));
            }
        }

        /// <summary>
        /// Paints the bar.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected virtual void PaintBar(PaintEventArgs e)
        {
            float angle;

            angle = this.Orientation == Orientation.Horizontal ? 0 : 90;

            if (this.BarBounds.Height > 0 && this.BarBounds.Width > 0)
            {
                ColorBlend blend;

                // HACK: Inflating the brush rectangle by 1 seems to get rid of a odd issue where the last colour is drawn on the first pixel

                blend = new ColorBlend();
                using (LinearGradientBrush brush = new LinearGradientBrush(Rectangle.Inflate(this.BarBounds, 1, 1), Color.Empty, Color.Empty, angle, false))
                {
                    switch (this.BarStyle)
                    {
                        case ColourBarStyle.TwoColour:
                            blend.Colors = new[]
                                           {
                               this.Colour1,
                               this.Colour2
                             };
                            blend.Positions = new[]
                                              {
                                  0F,
                                  1F
                                };
                            break;
                        case ColourBarStyle.ThreeColour:
                            blend.Colors = new[]
                                           {
                               this.Colour1,
                               this.Colour2,
                               this.Colour3
                             };
                            blend.Positions = new[]
                                              {
                                  0,
                                  0.5F,
                                  1
                                };
                            break;
                        case ColourBarStyle.Custom:
                            ColourCollection custom;
                            int count;

                            custom = this.CustomColours;
                            count = custom?.Count ?? 0;

                            if (custom != null && count > 0)
                            {
                                blend.Colors = custom.ToArray();
                                blend.Positions = Enumerable.Range(0, count).Select(i => i == 0 ? 0 : i == count - 1 ? 1 : (float)(1.0D / count) * i).ToArray();
                            }
                            else
                            {
                                blend.Colors = new[]
                                               {
                                 this.Colour1,
                                 this.Colour2
                               };
                                blend.Positions = new[]
                                                  {
                                    0F,
                                    1F
                                  };
                            }
                            break;
                    }

                    brush.InterpolationColors = blend;
                    e.Graphics.FillRectangle(brush, this.BarBounds);
                }
            }
        }

        /// <summary>
        /// Computes the location of the specified client point into value coordinates.
        /// </summary>
        /// <param name="location">The client coordinate <see cref="Point"/> to convert.</param>
        protected virtual void PointToValue(Point location)
        {
            float value;

            location.X += this.ClientRectangle.X - this.BarBounds.X;
            location.Y += this.ClientRectangle.Y - this.BarBounds.Y;

            switch (this.Orientation)
            {
                case Orientation.Horizontal:
                    value = this.Minimum + location.X / (float)this.BarBounds.Width * (this.Minimum + this.Maximum);
                    break;
                default:
                    value = this.Minimum + location.Y / (float)this.BarBounds.Height * (this.Minimum + this.Maximum);
                    break;
            }

            if (value < this.Minimum)
            {
                value = this.Minimum;
            }

            if (value > this.Maximum)
            {
                value = this.Maximum;
            }

            this.Value = value;
        }

        /// <summary>
        /// Computes the location of the value point into client coordinates.
        /// </summary>
        /// <param name="value">The value coordinate <see cref="Point"/> to convert.</param>
        /// <returns>A <see cref="Point"/> that represents the converted <see cref="Point"/>, value, in client coordinates.</returns>
        protected virtual Point ValueToPoint(float value)
        {
            double x;
            double y;
            Padding padding;

            padding = this.BarPadding + this.Padding;
            x = 0;
            y = 0;

            switch (this.Orientation)
            {
                case Orientation.Horizontal:
                    x = this.BarBounds.Width / this.Maximum * value;
                    break;
                default:
                    y = this.BarBounds.Height / this.Maximum * value;
                    break;
            }

            return new Point((int)x + padding.Left, (int)y + padding.Top);
        }

        #endregion
    }
}