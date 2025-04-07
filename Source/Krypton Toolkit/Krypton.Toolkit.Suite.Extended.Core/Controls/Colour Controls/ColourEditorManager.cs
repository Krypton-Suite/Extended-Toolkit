#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Core
{
    /// <summary>
    /// Represents a control that binds multiple editors together as a single composite unit.
    /// </summary>
    [DefaultEvent("ColourChanged"), ToolboxItem(false)]
    public class ColourEditorManager : Component, IColourEditor
    {
        #region Constants

        private static readonly object _eventColourChanged = new();

        private static readonly object _eventColourEditorChanged = new();

        private static readonly object _eventColourGridChanged = new();

        private static readonly object _eventColourWheelChanged = new();

        private static readonly object _eventLightnessColourSliderChanged = new();

        private static readonly object _eventScreenColourPickerChanged = new();

        #endregion

        #region Fields

        private Color _colour;

        private ColourEditorControl? _colourEditor;

        private ColourGridControl? _grid;

        private HSLColourStructure _hslColour;

        private LightnessColourSliderControl? _lightnessColourSlider;

        private ScreenColourPickerControl? _screenColourPicker;

        private ColourWheelControl? _wheel;

        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler ColourEditorChanged
        {
            add => Events.AddHandler(_eventColourEditorChanged, value);
            remove => Events.RemoveHandler(_eventColourEditorChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ColourGridChanged
        {
            add => Events.AddHandler(_eventColourGridChanged, value);
            remove => Events.RemoveHandler(_eventColourGridChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ColourWheelChanged
        {
            add => Events.AddHandler(_eventColourWheelChanged, value);
            remove => Events.RemoveHandler(_eventColourWheelChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler LightnessColourSliderChanged
        {
            add => Events.AddHandler(_eventLightnessColourSliderChanged, value);
            remove => Events.RemoveHandler(_eventLightnessColourSliderChanged, value);
        }

        [Category("Property Changed")]
        public event EventHandler ScreenColourPickerChanged
        {
            add => Events.AddHandler(_eventScreenColourPickerChanged, value);
            remove => Events.RemoveHandler(_eventScreenColourPickerChanged, value);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the linked <see cref="ColourEditorControl"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(ColourEditorControl), null!)]
        public virtual ColourEditorControl? ColourEditor
        {
            get => _colourEditor;
            set
            {
                if (ColourEditor != value)
                {
                    _colourEditor = value;

                    OnColourEditorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the linked <see cref="ColourGridControl"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(ColourGridControl), null!)]
        public virtual ColourGridControl? ColourGrid
        {
            get => _grid;
            set
            {
                if (ColourGrid != value)
                {
                    _grid = value;

                    OnColourGridChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the linked <see cref="ColourWheelControl"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(ColourWheelControl), null!)]
        public virtual ColourWheelControl? ColourWheel
        {
            get => _wheel;
            set
            {
                if (ColourWheel != value)
                {
                    _wheel = value;

                    OnColourWheelChanged(EventArgs.Empty);
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
            get => _hslColour;
            set
            {
                if (HSLColour != value)
                {
                    _hslColour = value;
                    _colour = value.ToRgbColour();

                    OnColourChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the linked <see cref="LightnessColourSliderControl"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(LightnessColourSliderControl), null!)]
        public virtual LightnessColourSliderControl? LightnessColourSlider
        {
            get => _lightnessColourSlider;
            set
            {
                if (LightnessColourSlider != value)
                {
                    _lightnessColourSlider = value;

                    OnLightnessColourSliderChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the linked <see cref="ScreenColourPickerControl"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(ScreenColourPickerControl), null!)]
        public virtual ScreenColourPickerControl? ScreenColourPicker
        {
            get => _screenColourPicker;
            set
            {
                if (ScreenColourPicker != value)
                {
                    _screenColourPicker = value;

                    OnScreenColourPickerChanged(EventArgs.Empty);
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
            control.ColourChanged += ColourChangedHandler;
        }

        /// <summary>
        /// Raises the <see cref="ColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColourChanged(EventArgs e)
        {
            EventHandler handler;

            Synchronise(this);

            handler = (EventHandler)Events[_eventColourChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColourEditorChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColourEditorChanged(EventArgs e)
        {
            EventHandler handler;

            if (ColourEditor != null)
            {
                BindEvents(ColourEditor);
            }

            handler = (EventHandler)Events[_eventColourEditorChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColourGridChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColourGridChanged(EventArgs e)
        {
            EventHandler handler;

            if (ColourGrid != null)
            {
                BindEvents(ColourGrid);
            }

            handler = (EventHandler)Events[_eventColourGridChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColourWheelChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColourWheelChanged(EventArgs e)
        {
            EventHandler handler;

            if (ColourWheel != null)
            {
                BindEvents(ColourWheel);
            }

            handler = (EventHandler)Events[_eventColourWheelChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="LightnessColourSliderChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnLightnessColourSliderChanged(EventArgs e)
        {
            EventHandler handler;

            if (LightnessColourSlider != null)
            {
                BindEvents(LightnessColourSlider);
            }

            handler = (EventHandler)Events[_eventLightnessColourSliderChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ScreenColourPickerChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnScreenColourPickerChanged(EventArgs e)
        {
            EventHandler handler;

            if (ScreenColourPicker != null)
            {
                BindEvents(ScreenColourPicker);
            }

            handler = (EventHandler)Events[_eventScreenColourPickerChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Sets the color of the given editor.
        /// </summary>
        /// <param name="control">The <see cref="IColourEditor"/> to update.</param>
        /// <param name="sender">The <see cref="IColourEditor"/> triggering the update.</param>
        protected virtual void SetColour(IColourEditor? control, IColourEditor sender)
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
            if (!LockUpdates)
            {
                try
                {
                    LockUpdates = true;
                    SetColour(ColourGrid, sender);
                    SetColour(ColourWheel, sender);
                    SetColour(ScreenColourPicker, sender);
                    SetColour(ColourEditor, sender);
                    SetColour(LightnessColourSlider, sender);
                }
                finally
                {
                    LockUpdates = false;
                }
            }
        }

        /// <summary>
        /// Handler for linked controls.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ColourChangedHandler(object? sender, EventArgs e)
        {
            if (!LockUpdates)
            {
                IColourEditor source;

                source = (IColourEditor)sender;

                LockUpdates = true;
                Colour = source.Colour;
                LockUpdates = false;
                Synchronise(source);
            }
        }

        #endregion

        #region IColorEditor Interface

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add => Events.AddHandler(_eventColourChanged, value);
            remove => Events.RemoveHandler(_eventColourChanged, value);
        }

        /// <summary>
        /// Gets or sets the component color.
        /// </summary>
        /// <value>The component color.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Color Colour
        {
            get => _colour;
            set
            {
                if (_colour != value)
                {
                    _colour = value;
                    _hslColour = new(value);

                    OnColourChanged(EventArgs.Empty);
                }
            }
        }

        #endregion
    }
}