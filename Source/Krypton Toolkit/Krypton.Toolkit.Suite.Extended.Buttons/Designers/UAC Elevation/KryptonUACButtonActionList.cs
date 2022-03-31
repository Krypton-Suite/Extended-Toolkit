#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    internal class KryptonUACButtonActionList : DesignerActionList
    {
        #region Instance Fields
        private readonly KryptonUACButtonVersion2 _uacButton;
        private readonly IComponentChangeService _service;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonButtonActionList class.
        /// </summary>
        /// <param name="owner">Designer that owns this action list instance.</param>
        public KryptonUACButtonActionList(KryptonUACButtonDesigner owner)
            : base(owner.Component)
        {
            // Remember the button instance
            _uacButton = owner.Component as KryptonUACButtonVersion2;

            // Cache service used to notify when a property has changed
            _service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
        }
        #endregion

        #region Public
        public bool UseAsUACElevatedButton
        {
            get => _uacButton.UseAsUACElevatedButton;

            set
            {
                if (_uacButton.UseAsUACElevatedButton != value)
                {
                    _service.OnComponentChanged(_uacButton, null, _uacButton.UseAsUACElevatedButton, value);

                    _uacButton.UseAsUACElevatedButton = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the button style.
        /// </summary>
        public ButtonStyle ButtonStyle
        {
            get => _uacButton.ButtonStyle;

            set
            {
                if (_uacButton.ButtonStyle != value)
                {
                    _service.OnComponentChanged(_uacButton, null, _uacButton.ButtonStyle, value);
                    _uacButton.ButtonStyle = value;
                }
            }
        }

        /// <summary>Gets or sets the context menu strip.</summary>
        /// <value>The context menu strip.</value>
        public ContextMenuStrip ContextMenuStrip
        {
            get => _uacButton.ContextMenuStrip;

            set
            {
                if (_uacButton.ContextMenuStrip != value)
                {
                    _service.OnComponentChanged(_uacButton, null, _uacButton.ContextMenuStrip, value);

                    _uacButton.ContextMenuStrip = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the visual orientation.
        /// </summary>
        public VisualOrientation Orientation
        {
            get => _uacButton.Orientation;

            set
            {
                if (_uacButton.Orientation != value)
                {
                    _service.OnComponentChanged(_uacButton, null, _uacButton.Orientation, value);
                    _uacButton.Orientation = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the button text.
        /// </summary>
        public string Text
        {
            get => _uacButton.Values.Text;

            set
            {
                if (_uacButton.Values.Text != value)
                {
                    _service.OnComponentChanged(_uacButton, null, _uacButton.Values.Text, value);
                    _uacButton.Values.Text = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the extra button text.
        /// </summary>
        public string ExtraText
        {
            get => _uacButton.Values.ExtraText;

            set
            {
                if (_uacButton.Values.ExtraText != value)
                {
                    _service.OnComponentChanged(_uacButton, null, _uacButton.Values.ExtraText, value);
                    _uacButton.Values.ExtraText = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the button image.
        /// </summary>
        public Image Image
        {
            get => _uacButton.Values.Image;

            set
            {
                if (_uacButton.Values.Image != value)
                {
                    _service.OnComponentChanged(_uacButton, null, _uacButton.Values.Image, value);
                    _uacButton.Values.Image = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the palette mode.
        /// </summary>
        public PaletteMode PaletteMode
        {
            get => _uacButton.PaletteMode;

            set
            {
                if (_uacButton.PaletteMode != value)
                {
                    _service.OnComponentChanged(_uacButton, null, _uacButton.PaletteMode, value);
                    _uacButton.PaletteMode = value;
                }
            }
        }

        /// <summary>Gets or sets the font.</summary>
        /// <value>The font.</value>
        public Font ShortTextFont
        {
            get => _uacButton.StateCommon.Content.ShortText.Font;

            set
            {
                if (_uacButton.StateCommon.Content.ShortText.Font != value)
                {
                    _service.OnComponentChanged(_uacButton, null, _uacButton.StateCommon.Content.ShortText.Font, value);

                    _uacButton.StateCommon.Content.ShortText.Font = value;
                }
            }
        }

        /// <summary>Gets or sets the font.</summary>
        /// <value>The font.</value>
        public Font LongTextFont
        {
            get => _uacButton.StateCommon.Content.LongText.Font;

            set
            {
                if (_uacButton.StateCommon.Content.LongText.Font != value)
                {
                    _service.OnComponentChanged(_uacButton, null, _uacButton.StateCommon.Content.LongText.Font, value);

                    _uacButton.StateCommon.Content.LongText.Font = value;
                }
            }
        }
        #endregion

        #region Public Override
        /// <summary>
        /// Returns the collection of DesignerActionItem objects contained in the list.
        /// </summary>
        /// <returns>A DesignerActionItem array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            // Create a new collection for holding the single item we want to create
            DesignerActionItemCollection actions = new DesignerActionItemCollection();

            // This can be null when deleting a control instance at design time
            if (_uacButton != null)
            {
                // Add the list of button specific actions
                actions.Add(new DesignerActionHeaderItem("Appearance"));
                actions.Add(new DesignerActionPropertyItem("ButtonStyle", "Style", "Appearance", "Button style"));
                actions.Add(new DesignerActionPropertyItem("ContextMenuStrip", "Context Menu Strip", "Appearance", "The context menu strip for the control."));
                actions.Add(new DesignerActionPropertyItem("Orientation", "Orientation", "Appearance", "Button orientation"));
                actions.Add(new DesignerActionPropertyItem("ShortTextFont", "Short Text Font", "Appearance", "The short text font."));
                actions.Add(new DesignerActionPropertyItem("LongTextFont", "Long Text Font", "Appearance", "The long text font."));
                actions.Add(new DesignerActionHeaderItem("Values"));
                actions.Add(new DesignerActionPropertyItem("Text", "Text", "Values", "Button text"));
                actions.Add(new DesignerActionPropertyItem("ExtraText", "ExtraText", "Values", "Button extra text"));
                actions.Add(new DesignerActionPropertyItem("Image", "Image", "Values", "Button image"));
                actions.Add(new DesignerActionHeaderItem("Visuals"));
                actions.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
            }

            return actions;
        }
        #endregion
    }
}