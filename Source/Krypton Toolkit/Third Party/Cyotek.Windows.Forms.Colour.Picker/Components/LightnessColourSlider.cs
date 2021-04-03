using System;
using System.ComponentModel;
using System.Drawing;

namespace Cyotek.Windows.Forms.Colour.Picker
{
    //[ToolboxItem(true)]
    public class LightnessColourSlider : ColourSlider, IColourEditor
    {
        #region Constants

        private static readonly object _eventColorChanged = new object();

        #endregion

        #region Fields

        private Color _color;

        #endregion

        #region Constructors

        public LightnessColourSlider()
        {
            this.BarStyle = ColourBarStyle.TwoColour;
            this.Colour = Color.Black;
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

        /// <summary>
        /// Gets or sets a value indicating whether input changes should be processed.
        /// </summary>
        /// <value><c>true</c> if input changes should be processed; otherwise, <c>false</c>.</value>
        protected bool LockUpdates { get; set; }

        #endregion

        #region Methods

        protected virtual void CreateScale()
        {
            HslColour color;

            color = new HslColour(this.Colour);

            color.L = 0;
            this.Colour1 = color.ToRgbColor();

            color.L = 1;
            this.Colour2 = color.ToRgbColor();
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

            handler = (EventHandler)this.Events[_eventColorChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColorSlider.ValueChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnValueChanged(EventArgs e)
        {
            if (!this.LockUpdates)
            {
                HslColour color;

                this.LockUpdates = true;
                color = new HslColour(this.Colour);
                color.L = this.Value / 100D;
                _color = color.ToRgbColor();
                this.OnColorChanged(e);
                this.LockUpdates = false;
            }

            base.OnValueChanged(e);
        }

        #endregion

        #region IColorEditor Interface

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add { this.Events.AddHandler(_eventColorChanged, value); }
            remove { this.Events.RemoveHandler(_eventColorChanged, value); }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
        public virtual Color Colour
        {
            get { return _color; }
            set
            {
                if (this.Colour != value)
                {
                    _color = value;

                    if (!this.LockUpdates)
                    {
                        this.LockUpdates = true;
                        this.Value = (float)new HslColour(value).L * 100;
                        this.OnColorChanged(EventArgs.Empty);
                        this.LockUpdates = false;
                    }
                }
            }
        }

        #endregion
    }
}