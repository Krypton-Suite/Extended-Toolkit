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
    /// <summary>
    /// Represents a control that binds multiple editors together as a single composite unit.
    /// </summary>
    [DefaultEvent("ColourChanged"), ToolboxItem(false)]
    public class ColourEditorManager : Component, IColourEditor
    {
        #region Constants

        private static readonly object _eventColourChanged = new object();

        private static readonly object _eventColourEditorChanged = new object();

        private static readonly object _eventColourGridChanged = new object();

        private static readonly object _eventColourWheelChanged = new object();

        private static readonly object _eventLightnessColourSliderChanged = new object();

        private static readonly object _eventScreenColourPickerChanged = new object();

        #endregion

        #region Fields

        private Color _colour;

        private ColourEditorControl _colourEditor;

        private ColourGridControl _grid;

        private HSLColourStructure _hslColour;

        private LightnessColourSliderControl _lightnessColourSlider;

        private ScreenColourPickerControl _screenColourPicker;

        private ColourWheelControl _wheel;

        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler ColourEditorChanged
        {
            add { this.Events.AddHandler(_eventColourEditorChanged, value); }
            remove { this.Events.RemoveHandler(_eventColourEditorChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ColourGridChanged
        {
            add { this.Events.AddHandler(_eventColourGridChanged, value); }
            remove { this.Events.RemoveHandler(_eventColourGridChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ColourWheelChanged
        {
            add { this.Events.AddHandler(_eventColourWheelChanged, value); }
            remove { this.Events.RemoveHandler(_eventColourWheelChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler LightnessColourSliderChanged
        {
            add { this.Events.AddHandler(_eventLightnessColourSliderChanged, value); }
            remove { this.Events.RemoveHandler(_eventLightnessColourSliderChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ScreenColourPickerChanged
        {
            add { this.Events.AddHandler(_eventScreenColourPickerChanged, value); }
            remove { this.Events.RemoveHandler(_eventScreenColourPickerChanged, value); }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the linked <see cref="ColourEditorControl"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(ColourEditorControl), null)]
        public virtual ColourEditorControl ColourEditor
        {
            get { return _colourEditor; }
            set
            {
                if (this.ColourEditor != value)
                {
                    _colourEditor = value;

                    this.OnColourEditorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the linked <see cref="ColourGridControl"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(ColourGridControl), null)]
        public virtual ColourGridControl ColourGrid
        {
            get { return _grid; }
            set
            {
                if (this.ColourGrid != value)
                {
                    _grid = value;

                    this.OnColourGridChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the linked <see cref="ColourWheelControl"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(ColourWheelControl), null)]
        public virtual ColourWheelControl ColourWheel
        {
            get { return _wheel; }
            set
            {
                if (this.ColourWheel != value)
                {
                    _wheel = value;

                    this.OnColourWheelChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the component color as a HSL structure.
        /// </summary>
        /// <value>The component color.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual HSLColourStructure HSLColour
        {
            get { return _hslColour; }
            set
            {
                if (this.HSLColour != value)
                {
                    _hslColour = value;
                    _colour = value.ToRgbColour();

                    this.OnColourChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the linked <see cref="LightnessColourSliderControl"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(LightnessColourSliderControl), null)]
        public virtual LightnessColourSliderControl LightnessColourSlider
        {
            get { return _lightnessColourSlider; }
            set
            {
                if (this.LightnessColourSlider != value)
                {
                    _lightnessColourSlider = value;

                    this.OnLightnessColourSliderChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the linked <see cref="ScreenColourPickerControl"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(ScreenColourPickerControl), null)]
        public virtual ScreenColourPickerControl ScreenColourPicker
        {
            get { return _screenColourPicker; }
            set
            {
                if (this.ScreenColourPicker != value)
                {
                    _screenColourPicker = value;

                    this.OnScreenColourPickerChanged(EventArgs.Empty);
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
            control.ColourChanged += this.ColourChangedHandler;
        }

        /// <summary>
        /// Raises the <see cref="ColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColourChanged(EventArgs e)
        {
            EventHandler handler;

            this.Synchronise(this);

            handler = (EventHandler)this.Events[_eventColourChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColourEditorChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColourEditorChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.ColourEditor != null)
            {
                this.BindEvents(this.ColourEditor);
            }

            handler = (EventHandler)this.Events[_eventColourEditorChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColourGridChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColourGridChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.ColourGrid != null)
            {
                this.BindEvents(this.ColourGrid);
            }

            handler = (EventHandler)this.Events[_eventColourGridChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColourWheelChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColourWheelChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.ColourWheel != null)
            {
                this.BindEvents(this.ColourWheel);
            }

            handler = (EventHandler)this.Events[_eventColourWheelChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="LightnessColourSliderChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnLightnessColourSliderChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.LightnessColourSlider != null)
            {
                this.BindEvents(this.LightnessColourSlider);
            }

            handler = (EventHandler)this.Events[_eventLightnessColourSliderChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ScreenColourPickerChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnScreenColourPickerChanged(EventArgs e)
        {
            EventHandler handler;

            if (this.ScreenColourPicker != null)
            {
                this.BindEvents(this.ScreenColourPicker);
            }

            handler = (EventHandler)this.Events[_eventScreenColourPickerChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Sets the color of the given editor.
        /// </summary>
        /// <param name="control">The <see cref="IColourEditor"/> to update.</param>
        /// <param name="sender">The <see cref="IColourEditor"/> triggering the update.</param>
        protected virtual void SetColour(IColourEditor control, IColourEditor sender)
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
        protected virtual void Synchronise(IColourEditor sender)
        {
            if (!this.LockUpdates)
            {
                try
                {
                    this.LockUpdates = true;
                    this.SetColour(this.ColourGrid, sender);
                    this.SetColour(this.ColourWheel, sender);
                    this.SetColour(this.ScreenColourPicker, sender);
                    this.SetColour(this.ColourEditor, sender);
                    this.SetColour(this.LightnessColourSlider, sender);
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
        private void ColourChangedHandler(object sender, EventArgs e)
        {
            if (!this.LockUpdates)
            {
                IColourEditor source;

                source = (IColourEditor)sender;

                this.LockUpdates = true;
                this.Colour = source.Colour;
                this.LockUpdates = false;
                this.Synchronise(source);
            }
        }

        #endregion

        #region IColorEditor Interface

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add { this.Events.AddHandler(_eventColourChanged, value); }
            remove { this.Events.RemoveHandler(_eventColourChanged, value); }
        }

        /// <summary>
        /// Gets or sets the component color.
        /// </summary>
        /// <value>The component color.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Color Colour
        {
            get { return _colour; }
            set
            {
                if (_colour != value)
                {
                    _colour = value;
                    _hslColour = new HSLColourStructure(value);

                    this.OnColourChanged(EventArgs.Empty);
                }
            }
        }

        #endregion
    }
}