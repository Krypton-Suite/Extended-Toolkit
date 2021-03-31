using System;
using System.ComponentModel;
using System.Drawing;

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
        [DefaultValue(typeof(ColourWheel), null)]
        public virtual ColourWheel ColourWheel
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
        /// Gets or sets the linked <see cref="LightnessColourSlider"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(LightnessColourSlider), null)]
        public virtual LightnessColourSlider LightnessColourSlider
        {
            get { return _lightnessColorSlider; }
            set
            {
                if (this.LightnessColourSlider != value)
                {
                    _lightnessColorSlider = value;

                    this.OnLightnessColorSliderChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the linked <see cref="ScreenColourPicker"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(ScreenColourPicker), null)]
        public virtual ScreenColourPicker ScreenColourPicker
        {
            get { return _screenColorPicker; }
            set
            {
                if (this.ScreenColourPicker != value)
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
        /// <param name="control">The <see cref="IColourEditor"/> to bind to.</param>
        protected virtual void BindEvents(IColourEditor control)
        {
            control.ColourChanged += this.ColorChangedHandler;
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

            if (this.LightnessColourSlider != null)
            {
                this.BindEvents(this.LightnessColourSlider);
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

            if (this.ScreenColourPicker != null)
            {
                this.BindEvents(this.ScreenColourPicker);
            }

            handler = (EventHandler)this.Events[_eventScreenColorPickerChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Sets the color of the given editor.
        /// </summary>
        /// <param name="control">The <see cref="IColourEditor"/> to update.</param>
        /// <param name="sender">The <see cref="IColourEditor"/> triggering the update.</param>
        protected virtual void SetColor(IColourEditor control, IColourEditor sender)
        {
            if (control != null && control != sender)
            {
                control.Colour = sender.Colour;
            }
        }

        /// <summary>
        /// Synchronizes linked components with the specified <see cref="IColourEditor"/>.
        /// </summary>
        /// <param name="sender">The <see cref="IColourEditor"/> triggering the update.</param>
        protected virtual void Synchronize(IColourEditor sender)
        {
            if (!this.LockUpdates)
            {
                try
                {
                    this.LockUpdates = true;
                    this.SetColor(this.ColourGrid, sender);
                    this.SetColor(this.ColourWheel, sender);
                    this.SetColor(this.ScreenColourPicker, sender);
                    this.SetColor(this.ColourEditor, sender);
                    this.SetColor(this.LightnessColourSlider, sender);
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
                IColourEditor source;

                source = (IColourEditor)sender;

                this.LockUpdates = true;
                this.Colour = source.Colour;
                this.LockUpdates = false;
                this.Synchronize(source);
            }
        }

        #endregion

        #region IColourEditor Interface

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
                    _hslColor = new HslColour(value);

                    this.OnColorChanged(EventArgs.Empty);
                }
            }
        }

        #endregion
    }
}