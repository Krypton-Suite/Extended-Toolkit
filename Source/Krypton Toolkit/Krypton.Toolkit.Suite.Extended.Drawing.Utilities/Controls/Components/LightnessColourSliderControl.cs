#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    [ToolboxItem(true)]
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
            BarStyle = ColourBarStyle.TwoColour;
            Colour = Color.Black;
            BackColor = Color.Transparent;
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override float Value
        {
            get => base.Value;
            set => base.Value = (int)value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether input changes should be processed.
        /// </summary>
        /// <value><c>true</c> if input changes should be processed; otherwise, <c>false</c>.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
        protected bool LockUpdates { get; set; }

        #endregion

        #region Methods

        protected virtual void CreateScale()
        {
            HSLColour color;

            color = new HSLColour(Colour);

            color.L = 0;
            Colour1 = color.ToRgbColour();

            color.L = 1;
            Colour2 = color.ToRgbColour();
        }

        /// <summary>
        /// Raises the <see cref="ColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorChanged(EventArgs e)
        {
            EventHandler? handler;

            CreateScale();
            Invalidate();

            handler = Events[_eventColourChanged] as EventHandler;

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColorSlider.ValueChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnValueChanged(EventArgs e)
        {
            if (!LockUpdates)
            {
                HSLColour color;

                LockUpdates = true;
                color = new HSLColour(Colour);
                color.L = Value / 100D;
                _colour = color.ToRgbColour();
                OnColorChanged(e);
                LockUpdates = false;
            }

            base.OnValueChanged(e);
        }

        #endregion

        #region IColorEditor Interface

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add => Events.AddHandler(_eventColourChanged, value);
            remove => Events.RemoveHandler(_eventColourChanged, value);
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
        public virtual Color Colour
        {
            get => _colour;
            set
            {
                if (Colour != value)
                {
                    _colour = value;

                    if (!LockUpdates)
                    {
                        LockUpdates = true;
                        Value = (float)new HSLColour(value).L * 100;
                        OnColorChanged(EventArgs.Empty);
                        LockUpdates = false;
                    }
                }
            }
        }

        #endregion
    }
}