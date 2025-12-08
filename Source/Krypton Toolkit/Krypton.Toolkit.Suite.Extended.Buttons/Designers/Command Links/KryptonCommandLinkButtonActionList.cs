#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Buttons;

internal class KryptonCommandLinkButtonActionList : DesignerActionList
{
    #region Instance Fields
    private readonly KryptonCommandLinkButton _button;
    private readonly IComponentChangeService _service;
    #endregion

    #region Identity
    /// <summary>
    /// Initialize a new instance of the KryptonButtonActionList class.
    /// </summary>
    /// <param name="owner">Designer that owns this action list instance.</param>
    public KryptonCommandLinkButtonActionList(KryptonCommandLinkButtonDesigner owner) : base(owner.Component)
    {
        // Remember the button instance
        _button = owner.Component as KryptonCommandLinkButton;

        // Cache service used to notify when a property has changed
        _service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
    }
    #endregion

    #region Public
    /// <summary>
    /// Gets and sets the button style.
    /// </summary>
    public ButtonStyle ButtonStyle
    {
        get => _button.ButtonStyle;

        set
        {
            if (_button.ButtonStyle != value)
            {
                _service.OnComponentChanged(_button, null, _button.ButtonStyle, value);
                _button.ButtonStyle = value;
            }
        }
    }

    /// <summary>
    /// Gets and sets the visual orientation.
    /// </summary>
    public VisualOrientation Orientation
    {
        get => _button.Orientation;

        set
        {
            if (_button.Orientation != value)
            {
                _service.OnComponentChanged(_button, null, _button.Orientation, value);
                _button.Orientation = value;
            }
        }
    }

    /// <summary>
    /// Gets and sets the button text.
    /// </summary>
    public string Heading
    {
        get => _button.CommandLinkTextValues.Heading;

        set
        {
            if (_button.CommandLinkTextValues.Heading != value)
            {
                _service.OnComponentChanged(_button, null, _button.CommandLinkTextValues.Heading, value);
                _button.CommandLinkTextValues.Heading = value;
            }
        }
    }

    /// <summary>
    /// Gets and sets the extra button text.
    /// </summary>
    public string Description
    {
        get => _button.CommandLinkTextValues.Description;

        set
        {
            if (_button.CommandLinkTextValues.Description != value)
            {
                _service.OnComponentChanged(_button, null, _button.CommandLinkTextValues.Description, value);
                _button.CommandLinkTextValues.Description = value;
            }
        }
    }

    /// <summary>
    /// Gets and sets the button image.
    /// </summary>
    public Image Image
    {
        get => _button.CommandLinkImageValue.Image;

        set
        {
            if (_button.CommandLinkImageValue.Image != value)
            {
                _service.OnComponentChanged(_button, null, _button.CommandLinkImageValue.Image, value);
                _button.CommandLinkImageValue.Image = value;
            }
        }
    }

    /// <summary>
    /// Gets and sets the palette mode.
    /// </summary>
    public PaletteMode PaletteMode
    {
        get => _button.PaletteMode;

        set
        {
            if (_button.PaletteMode != value)
            {
                _service.OnComponentChanged(_button, null, _button.PaletteMode, value);
                _button.PaletteMode = value;
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
        DesignerActionItemCollection actions = new();

        // This can be null when deleting a control instance at design time
        if (_button != null)
        {
            // Add the list of button specific actions
            actions.Add(new DesignerActionHeaderItem("Appearance"));
            actions.Add(new DesignerActionPropertyItem("Orientation", "Orientation", "Appearance", "Button orientation"));
            actions.Add(new DesignerActionHeaderItem("CommandLink"));
            actions.Add(new DesignerActionPropertyItem("Heading", "Heading", "CommandLink", "Button Heading text"));
            actions.Add(new DesignerActionPropertyItem("Description", "Description", "CommandLink", "Button Subscript Description text"));
            actions.Add(new DesignerActionPropertyItem("Image", "Image", "CommandLink", "Button image"));
            actions.Add(new DesignerActionHeaderItem("Visuals"));
            actions.Add(new DesignerActionPropertyItem("ButtonStyle", "Style", "Visuals", "Button style"));
            actions.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
        }

        return actions;
    }
    #endregion
}