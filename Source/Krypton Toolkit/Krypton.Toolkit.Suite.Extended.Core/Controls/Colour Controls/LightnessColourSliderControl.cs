#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    [ToolboxItem(false)]
    public class LightnessColourSliderControl : ColourSliderControl, IColourEditor
    {
        #region Constants

        private static readonly object _eventColourChanged = new object();

        #endregion

        #region Fields

        private Color _colour;

        #endregion

        #region Constructors

        public LightnessColourSliderControl()
        {
            this.BarStyle = ColourBarStyle.TWOCOLOUR;
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
            HSLColourStructure colour;

            colour = new HSLColourStructure(this.Colour);

            colour.L = 0;
            this.Colour1 = colour.ToRgbColour();

            colour.L = 1;
            this.Colour2 = colour.ToRgbColour();
        }

        /// <summary>
        /// Raises the <see cref="ColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColourChanged(EventArgs e)
        {
            EventHandler handler;

            this.CreateScale();
            this.Invalidate();

            handler = (EventHandler)this.Events[_eventColourChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColourSlider.ValueChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnValueChanged(EventArgs e)
        {
            if (!this.LockUpdates)
            {
                HSLColourStructure colour;

                this.LockUpdates = true;
                colour = new HSLColourStructure(this.Colour);
                colour.L = this.Value / 100D;
                _colour = colour.ToRgbColour();
                this.OnColourChanged(e);
                this.LockUpdates = false;
            }

            base.OnValueChanged(e);
        }

        #endregion

        #region IColorEditor Interface

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add { this.Events.AddHandler(_eventColourChanged, value); }
            remove { this.Events.RemoveHandler(_eventColourChanged, value); }
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

                    if (!this.LockUpdates)
                    {
                        this.LockUpdates = true;
                        this.Value = (float)new HSLColourStructure(value).L * 100;
                        this.OnColourChanged(EventArgs.Empty);
                        this.LockUpdates = false;
                    }
                }
            }
        }

        #endregion
    }
}