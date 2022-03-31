#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class RGBAColourSliderControl : ColourSliderControl
    {
        #region Constants

        private static readonly object _eventChannelChanged = new object();

        private static readonly object _eventColourChanged = new object();

        #endregion

        #region Fields

        private Brush _cellBackgroundBrush;

        private RGBAChannel _channel;

        private Color _colour;

        #endregion

        #region Constructors

        public RGBAColourSliderControl()
        {
            base.BarStyle = ColourBarStyle.CUSTOM;
            base.Maximum = 255;
            this.Colour = Color.Black;
            this.CreateScale();
        }

        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler ChannelChanged
        {
            add { this.Events.AddHandler(_eventChannelChanged, value); }
            remove { this.Events.RemoveHandler(_eventChannelChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add { this.Events.AddHandler(_eventColourChanged, value); }
            remove { this.Events.RemoveHandler(_eventColourChanged, value); }
        }

        #endregion

        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ColourBarStyle BarStyle
        {
            get { return base.BarStyle; }
            set { base.BarStyle = value; }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(RGBAChannel), "Red")]
        public virtual RGBAChannel Channel
        {
            get { return _channel; }
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
            get { return _colour; }
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
            get { return base.Colour1; }
            set { base.Colour1 = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color Colour2
        {
            get { return base.Colour2; }
            set { base.Colour2 = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color Colour3
        {
            get { return base.Colour3; }
            set { base.Colour3 = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override float Maximum
        {
            get { return base.Maximum; }
            set { base.Maximum = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override float Minimum
        {
            get { return base.Minimum; }
            set { base.Minimum = value; }
        }

        public override float Value
        {
            get { return base.Value; }
            set { base.Value = (int)value; }
        }

        #endregion

        #region Methods

        protected virtual void CreateScale()
        {
            ColourCollection custom;
            Color colour;
            RGBAChannel channel;

            custom = new ColourCollection();
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
                    case RGBAChannel.RED:
                        r = i;
                        break;
                    case RGBAChannel.GREEN:
                        g = i;
                        break;
                    case RGBAChannel.BLUE:
                        b = i;
                        break;
                    case RGBAChannel.ALPHA:
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

            using (Bitmap background = new Bitmap(type.Assembly.GetManifestResourceStream(string.Concat(type.Namespace, ".Resources.cellbackground.png"))))
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