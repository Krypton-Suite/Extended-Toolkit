using System;
using System.ComponentModel;
using System.Drawing;

namespace Cyotek.Windows.Forms.Colour.Picker
{
    /// <summary>
    /// Represents a control for selecting the saturation of a color
    /// </summary>
    public class SaturationColourSlider : ColourSlider
    {
        #region Constants

        private static readonly object _eventColorChanged = new object();

        #endregion

        #region Fields

        private Color _color;

        #endregion

        #region Constructors

        public SaturationColourSlider()
        {
            this.BarStyle = ColourBarStyle.TwoColour;
            this.Colour = Color.Black;
        }

        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add { this.Events.AddHandler(_eventColorChanged, value); }
            remove { this.Events.RemoveHandler(_eventColorChanged, value); }
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
        [DefaultValue(typeof(Color), "Black")]
        public virtual Color Colour
        {
            get { return _color; }
            set
            {
                if (this.Colour != value)
                {
                    _color = value;

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
            HslColour color;

            color = new HslColour(this.Colour);

            color.S = 0;
            this.Colour1 = color.ToRgbColor();

            color.S = 1;
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

        #endregion
    }
}