using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyotek.Windows.Forms.Colour.Picker
{
    /// <summary>
    /// Represents a control that binds multiple editors together as a single composite unit.
    /// </summary>
    [DefaultEvent("ColorChanged")]
    public class ColourEditorManager : Component, IColourEditor
    {
        #region Constants

        private static readonly object _eventColorChanged = new object();

        private static readonly object _eventColorEditorChanged = new object();

        private static readonly object _eventColorGridChanged = new object();

        private static readonly object _eventColorWheelChanged = new object();

        private static readonly object _eventLightnessColorSliderChanged = new object();

        private static readonly object _eventScreenColorPickerChanged = new object();

        #endregion

        #region Fields

        private Color _color;

        private ColourEditor _colorEditor;

        private ColourGrid _grid;

        private HslColour _hslColor;

        private LightnessColourSlider _lightnessColorSlider;

        private ScreenColourPicker _screenColorPicker;

        private ColourWheel _wheel;

        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler ColourEditorChanged
        {
            add { this.Events.AddHandler(_eventColorEditorChanged, value); }
            remove { this.Events.RemoveHandler(_eventColorEditorChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ColourGridChanged
        {
            add { this.Events.AddHandler(_eventColorGridChanged, value); }
            remove { this.Events.RemoveHandler(_eventColorGridChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ColourWheelChanged
        {
            add { this.Events.AddHandler(_eventColorWheelChanged, value); }
            remove { this.Events.RemoveHandler(_eventColorWheelChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler LightnessColourSliderChanged
        {
            add { this.Events.AddHandler(_eventLightnessColorSliderChanged, value); }
            remove { this.Events.RemoveHandler(_eventLightnessColorSliderChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ScreenColourPickerChanged
        {
            add { this.Events.AddHandler(_eventScreenColorPickerChanged, value); }
            remove { this.Events.RemoveHandler(_eventScreenColorPickerChanged, value); }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the linked <see cref="Picker.ColourEditor"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(ColourEditor), null)]
        public virtual ColourEditor ColourEditor
        {
            get { return _colorEditor; }
            set
            {
                if (this.ColourEditor != value)
                {
                    _colorEditor = value;

                    this.OnColorEditorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the linked <see cref="ColourGrid"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(ColourGrid), null)]
        public virtual ColourGrid ColourGrid
        {
            get { return _grid; }
            set
            {
                if (this.ColourGrid != value)
                {
                    _grid = value;

                    this.OnColorGridChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the linked <see cref="ColourWheel"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(ColorWheel), null)]
        public virtual ColorWheel ColourWheel
        {
            get { return _wheel; }
            set
            {
                if (this.ColourWheel != value)
                {
                    _wheel = value;

                    this.OnColorWheelChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the component color as a HSL structure.
        /// </summary>
        /// <value>The component color.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual HslColour HslColour
        {
            get { return _hslColor; }
            set
            {
                if (this.HslColour != value)
                {
                    _hslColor = value;
                    _color = value.ToRgbColor();

                    this.OnColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the linked <see cref="LightnessColorSlider"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(LightnessColorSlider), null)]
        public virtual LightnessColorSlider LightnessColorSlider
        {
            get { return _lightnessColorSlider; }
            set
            {
                if (this.LightnessColorSlider != value)
                {
                    _lightnessColorSlider = value;

                    this.OnLightnessColorSliderChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the linked <see cref="ScreenColorPicker"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(ScreenColorPicker), null)]
        public virtual ScreenColorPicker ScreenColorPicker
        {
            get { return _screenColorPicker; }
            set
            {
                if (this.ScreenColorPicker != value)
                {
                    _screenColorPicker = value;

                    this.OnScreenColorPickerChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether updating of linked components is disabled.
        /// </summary>
        /// <value><c>true</c> if updated of linked components is disabled; otherwise, <c>false</c>.</value>
        protected bool LockUpdates { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Binds events for the specified editor.
        /// </summary>
        /// <param name="control">The <see cref="IColorEditor"/> to bind to.</param>
        protected virtual void BindEvents(IColorEditor control)
        {
            control.ColorChanged += this.ColorChangedHandler;
        }

        /// <summary>
        /// Raises the <see cref="ColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorChanged(EventArgs e)
        {
            EventHandler handler;

            this.Synchronize(this);

            handler = (EventHandler)this.Events[_eventColorChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColorEditorChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorEditorChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.ColourEditor != null)
            {
                this.BindEvents(this.ColourEditor);
            }

            handler = (EventHandler)this.Events[_eventColorEditorChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColorGridChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorGridChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.ColourGrid != null)
            {
                this.BindEvents(this.ColourGrid);
            }

            handler = (EventHandler)this.Events[_eventColorGridChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColorWheelChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorWheelChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.ColourWheel != null)
            {
                this.BindEvents(this.ColourWheel);
            }

            handler = (EventHandler)this.Events[_eventColorWheelChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="LightnessColorSliderChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnLightnessColorSliderChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.LightnessColorSlider != null)
            {
                this.BindEvents(this.LightnessColorSlider);
            }

            handler = (EventHandler)this.Events[_eventLightnessColorSliderChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ScreenColorPickerChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnScreenColorPickerChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.ScreenColorPicker != null)
            {
                this.BindEvents(this.ScreenColorPicker);
            }

            handler = (EventHandler)this.Events[_eventScreenColorPickerChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Sets the color of the given editor.
        /// </summary>
        /// <param name="control">The <see cref="IColorEditor"/> to update.</param>
        /// <param name="sender">The <see cref="IColorEditor"/> triggering the update.</param>
        protected virtual void SetColor(IColorEditor control, IColorEditor sender)
        {
            if (control != null && control != sender)
            {
                control.Color = sender.Color;
            }
        }

        /// <summary>
        /// Synchronizes linked components with the specified <see cref="IColorEditor"/>.
        /// </summary>
        /// <param name="sender">The <see cref="IColorEditor"/> triggering the update.</param>
        protected virtual void Synchronize(IColorEditor sender)
        {
            if (!this.LockUpdates)
            {
                try
                {
                    this.LockUpdates = true;
                    this.SetColor(this.ColourGrid, sender);
                    this.SetColor(this.ColourWheel, sender);
                    this.SetColor(this.ScreenColorPicker, sender);
                    this.SetColor(this.ColourEditor, sender);
                    this.SetColor(this.LightnessColorSlider, sender);
                }
                finally
                {
                    this.LockUpdates = false;
                }
            }
        }

        /// <summary>
        /// Handler for linked controls.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ColorChangedHandler(object sender, EventArgs e)
        {
            if (!this.LockUpdates)
            {
                IColorEditor source;

                source = (IColorEditor)sender;

                this.LockUpdates = true;
                this.Colour = source.Color;
                this.LockUpdates = false;
                this.Synchronize(source);
            }
        }

        #endregion

        #region IColorEditor Interface

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add { this.Events.AddHandler(_eventColorChanged, value); }
            remove { this.Events.RemoveHandler(_eventColorChanged, value); }
        }

        /// <summary>
        /// Gets or sets the component color.
        /// </summary>
        /// <value>The component color.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Color Colour
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    _hslColor = new HslColor(value);

                    this.OnColorChanged(EventArgs.Empty);
                }
            }
        }

        #endregion
    }
}