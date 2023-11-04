﻿#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class RGBAColourSliderControl : ColourSliderControl
    {
        #region Constants

        private static readonly object _eventChannelChanged = new();

        private static readonly object _eventColourChanged = new();

        #endregion

        #region Fields

        private Brush _cellBackgroundBrush;

        private RGBAChannel _channel;

        private Color _colour;

        #endregion

        #region Constructors

        public RGBAColourSliderControl()
        {
            base.BarStyle = ColourBarStyle.Custom;
            base.Maximum = 255;
            this.Colour = Color.Black;
            this.CreateScale();
        }

        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler ChannelChanged
        {
            add => this.Events.AddHandler(_eventChannelChanged, value);
            remove => this.Events.RemoveHandler(_eventChannelChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add => this.Events.AddHandler(_eventColourChanged, value);
            remove => this.Events.RemoveHandler(_eventColourChanged, value);
        }

        #endregion

        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ColourBarStyle BarStyle
        {
            get => base.BarStyle;
            set => base.BarStyle = value;
        }

        [Category("Appearance")]
        [DefaultValue(typeof(RGBAChannel), "Red")]
        public virtual RGBAChannel Channel
        {
            get => _channel;
            set
            {
                if (this.Channel != value)
                {
                    _channel = value;

                    this.OnChannelChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color Colour1
        {
            get => base.Colour1;
            set => base.Colour1 = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color Colour2
        {
            get => base.Colour2;
            set => base.Colour2 = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color Colour3
        {
            get => base.Colour3;
            set => base.Colour3 = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override float Maximum
        {
            get => base.Maximum;
            set => base.Maximum = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override float Minimum
        {
            get => base.Minimum;
            set => base.Minimum = value;
        }

        public override float Value
        {
            get => base.Value;
            set => base.Value = (int)value;
        }

        #endregion

        #region Methods

        protected virtual void CreateScale()
        {
            ColourCollection custom;
            Color colour;
            RGBAChannel channel;

            custom = new();
            colour = this.Colour;
            channel = this.Channel;

            for (int i = 0; i < 254; i++)
            {
                int a;
                int r;
                int g;
                int b;

                a = colour.A;
                r = colour.R;
                g = colour.G;
                b = colour.B;

                switch (channel)
                {
                    case RGBAChannel.Red:
                        r = i;
                        break;
                    case RGBAChannel.Green:
                        g = i;
                        break;
                    case RGBAChannel.Blue:
                        b = i;
                        break;
                    case RGBAChannel.Alpha:
                        a = i;
                        break;
                }

                custom.Add(Color.FromArgb(a, r, g, b));
            }

            this.CustomColours = custom;
        }

        protected virtual Brush CreateTransparencyBrush()
        {
            Type type;

            type = typeof(RGBAColourSliderControl);

            using (Bitmap background = new(type.Assembly.GetManifestResourceStream(
                       $"{type.Namespace}.Resources.cellbackground.png")))
            {
                return new TextureBrush(background, WrapMode.Tile);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_cellBackgroundBrush != null)
                {
                    _cellBackgroundBrush.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Raises the <see cref="ChannelChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnChannelChanged(EventArgs e)
        {
            EventHandler handler;

            this.CreateScale();
            this.Invalidate();

            handler = (EventHandler)this.Events[_eventChannelChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorChanged(EventArgs e)
        {
            EventHandler handler;

            this.CreateScale();
            this.Invalidate();

            handler = (EventHandler)this.Events[_eventColourChanged];

            handler?.Invoke(this, e);
        }

        protected override void PaintBar(PaintEventArgs e)
        {
            if (this.Colour.A != 255)
            {
                if (_cellBackgroundBrush == null)
                {
                    _cellBackgroundBrush = this.CreateTransparencyBrush();
                }

                e.Graphics.FillRectangle(_cellBackgroundBrush, this.BarBounds);
            }

            base.PaintBar(e);
        }

        #endregion
    }
}