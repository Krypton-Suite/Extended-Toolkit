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

#pragma warning disable CS1574, CS1584, CS1581, CS1580
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