#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    /// <summary>
    /// Represents a control for selecting the saturation of a color
    /// </summary>
    [ToolboxItem(true)]
    public class SaturationColourSliderControl : ColourSliderControl
    {
        #region Constants

        private static readonly object _eventColourChanged = new object();

        #endregion

        #region Fields

        private Color _colour;

        #endregion

        #region Constructors

        public SaturationColourSliderControl()
        {
            this.BarStyle = ColourBarStyle.TwoColour;
            this.Colour = Color.Black;
            BackColor = Color.Transparent;
        }

        #endregion

        #region Events

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
            HSLColour color;

            color = new HSLColour(this.Colour);

            color.S = 0;
            this.Colour1 = color.ToRgbColour();

            color.S = 1;
            this.Colour2 = color.ToRgbColour();
        }

        /// <summary>
        /// Raises the <see cref="ColorChanged" /> event.
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

        #endregion
    }
}