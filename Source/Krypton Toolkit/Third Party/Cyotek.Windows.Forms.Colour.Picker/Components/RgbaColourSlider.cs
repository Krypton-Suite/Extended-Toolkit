using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.Colour.Picker
{
    //[ToolboxItem(true)]
    public class RgbaColourSlider : ColourSlider
    {
        #region Constants

        private static readonly object _eventChannelChanged = new object();

        private static readonly object _eventColourChanged = new object();

        #endregion

        #region Fields

        private Brush _cellBackgroundBrush;

        private RgbaChannel _channel;

        private Color _colour;

        #endregion

        #region Constructors

        public RgbaColourSlider()
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
        [DefaultValue(typeof(RgbaChannel), "Red")]
        public virtual RgbaChannel Channel
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
            Color color;
            RgbaChannel channel;

            custom = new ColourCollection();
            color = this.Colour;
            channel = this.Channel;

            for (int i = 0; i < 254; i++)
            {
                int a;
                int r;
                int g;
                int b;

                a = color.A;
                r = color.R;
                g = color.G;
                b = color.B;

                switch (channel)
                {
                    case RgbaChannel.Red:
                        r = i;
                        break;
                    case RgbaChannel.Green:
                        g = i;
                        break;
                    case RgbaChannel.Blue:
                        b = i;
                        break;
                    case RgbaChannel.Alpha:
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

            type = typeof(RgbaColourSlider);

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