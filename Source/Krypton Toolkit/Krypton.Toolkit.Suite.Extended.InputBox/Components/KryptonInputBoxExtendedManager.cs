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

namespace Krypton.Toolkit.Suite.Extended.InputBox;

public class KryptonInputBoxExtendedManager : Component
{
    #region Instance Fields

    private Color _cueColour;
    private DateTime _initialDateTime;
    private string _prompt;
    private string _caption;
    private string _defaultResponse;
    private string _cueText;
    private Font _cueTypeface, _promptTypeface, _buttonTypeface;
    private InputBoxIconType _iconType;
    private KryptonInputBoxResponseType _inputType;
    private InputBoxTextAlignment _textAlignment;
    private InputBoxWrappedMessageTextAlignment _textWrappedMessageTextAlignment;
    private InputBoxButtons _buttons;
    private InputBoxButtonFocus _focusedButton;
    private Image _customImage;
    private IWin32Window _owner;
    private GlobalTypefaceSettingsManager _typefaceSettings = new();

    #endregion

    #region Public

    [DefaultValue(typeof(Color), "Color.Gray")]
    public Color CueColour { get => _cueColour; set => _cueColour = value; }

    [DefaultValue(typeof(DateTime), "DateTime.Now")]
    public DateTime InitialDateTime { get => _initialDateTime; set => _initialDateTime = value; }

    [DefaultValue(typeof(Font), "DefaultToolkitTypefaceTypes.DEFAULT_CUE_TYPEFACE")]
    public Font CueTypeface { get => _cueTypeface; set => _cueTypeface = value; }

    [DefaultValue(typeof(Font), "DefaultToolkitTypefaceTypes.DEFAULT_NORMAL_TYPEFACE")]
    public Font ButtonTypeface { get => _buttonTypeface; set => _buttonTypeface = value; }

    [DefaultValue(typeof(Font), "DefaultToolkitTypefaceTypes.DEFAULT_BOLD_TYPEFACE")]
    public Font PromptTypeface { get => _promptTypeface; set => _promptTypeface = value; }

    [DefaultValue(typeof(InputBoxButtons), "InputBoxButtons.OkCancel")]
    public InputBoxButtons Buttons { get => _buttons; set => _buttons = value; }

    [DefaultValue(typeof(InputBoxButtonFocus), "InputBoxButtonFocus.ButtonTwo")]
    public InputBoxButtonFocus FocusedButton { get => _focusedButton; set => _focusedButton = value; }

    [DefaultValue(typeof(InputBoxIconType), "InputBoxIconType.None")]
    public InputBoxIconType IconType { get => _iconType; set => _iconType = value; }

    [DefaultValue(typeof(KryptonInputBoxResponseType), "KryptonInputBoxType.TextBox")]
    public KryptonInputBoxResponseType InputType { get => _inputType; set => _inputType = value; }

    [DefaultValue(typeof(InputBoxTextAlignment), "InputBoxTextAlignment.Left")]
    public InputBoxTextAlignment TextAlignment { get => _textAlignment; set => _textAlignment = value; }

    [DefaultValue(typeof(InputBoxWrappedMessageTextAlignment), "InputBoxWrappedMessageTextAlignment.MiddleLeft")]
    public InputBoxWrappedMessageTextAlignment WrappedMessageTextAlignment { get => _textWrappedMessageTextAlignment; set => _textWrappedMessageTextAlignment = value; }

    [DefaultValue(null)]
    public Image CustomImage { get => _customImage; set => _customImage = value; }

    [DefaultValue(null)]
    public string Caption { get => _caption; set => _caption = value; }

    [DefaultValue(null)]
    public string CueText { get => _cueText; set => _cueText = value; }

    [DefaultValue(null)]
    public string DefaultResponse { get => _defaultResponse; set => _defaultResponse = value; }

    [DefaultValue(null)]
    public string Prompt { get => _prompt; set => _prompt = value; }

    [DefaultValue(null)]
    public IWin32Window Owner { get => _owner; set => _owner = value; }

    #endregion

    #region Identity

    /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtendedManager" /> class.</summary>
    public KryptonInputBoxExtendedManager()
    {
        _cueColour = Color.Gray;

        _cueTypeface = _typefaceSettings.GetCueTypeface();

        _buttonTypeface = _typefaceSettings.GetNormalTypeface();

        _promptTypeface = _typefaceSettings.GetBoldTypeface();

        _buttons = InputBoxButtons.OkCancel;

        _focusedButton = InputBoxButtonFocus.ButtonTwo;

        _iconType = InputBoxIconType.None;

        _inputType = KryptonInputBoxResponseType.TextBox;

        _textAlignment = InputBoxTextAlignment.Left;

        _textWrappedMessageTextAlignment = InputBoxWrappedMessageTextAlignment.MiddleLeft;

        _customImage = null;

        _caption = @"";

        _cueText = @"";

        _defaultResponse = @"";

        _prompt = @"";

        _owner = null;

        _initialDateTime = DateTime.Now;
    }

    /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtendedManager" /> class.</summary>
    /// <param name="owner">The owner.</param>
    /// <param name="prompt">The prompt.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="defaultResponse">The default response.</param>
    /// <param name="cueText">The cue text.</param>
    /// <param name="cueColour">The cue colour.</param>
    /// <param name="cueTypeface">The cue typeface.</param>
    /// <param name="buttonTypeface">The button typeface.</param>
    /// <param name="promptTypeface">The prompt typeface.</param>
    /// <param name="iconType">Type of the icon.</param>
    /// <param name="inputType">Type of the input.</param>
    /// <param name="textAlignment">The text alignment.</param>
    /// <param name="textWrappedMessageTextAlignment">The text wrapped message text alignment.</param>
    /// <param name="buttons">The buttons.</param>
    /// <param name="focusedButton">The focused button.</param>
    /// <param name="customImage">The custom image.</param>
    /// <param name="initialDateTime">The initial date time.</param>
    public KryptonInputBoxExtendedManager(IWin32Window owner, string prompt, string caption,
        string defaultResponse, string cueText, Color cueColour,
        Font cueTypeface, Font buttonTypeface, Font promptTypeface,
        InputBoxIconType iconType,
        KryptonInputBoxResponseType inputType,
        InputBoxTextAlignment textAlignment,
        InputBoxWrappedMessageTextAlignment textWrappedMessageTextAlignment,
        InputBoxButtons buttons,
        InputBoxButtonFocus focusedButton,
        Image customImage, DateTime? initialDateTime = null)
    {
        _owner = owner;

        _promptTypeface = promptTypeface ?? DefaultToolkitTypefaceTypes.DEFAULT_BOLD_TYPEFACE;

        _iconType = iconType;

        _inputType = inputType;

        _textAlignment = textAlignment;

        _customImage = customImage;

        _caption = caption;

        _cueText = cueText;

        _defaultResponse = defaultResponse;

        _prompt = prompt;

        _cueColour = cueColour;

        _buttonTypeface = buttonTypeface ?? DefaultToolkitTypefaceTypes.DEFAULT_NORMAL_TYPEFACE;

        _cueTypeface = cueTypeface ?? DefaultToolkitTypefaceTypes.DEFAULT_CUE_TYPEFACE;

        _textWrappedMessageTextAlignment = textWrappedMessageTextAlignment;

        _buttons = buttons;

        _focusedButton = focusedButton;

        _initialDateTime = initialDateTime ?? DateTime.Now;
    }

    #endregion

    #region Show

    /// <summary>Shows the <see cref="KryptonInputBoxExtendedForm"/>, and returns the input string.</summary>
    /// <returns>The users input string.</returns>
    public string Show()
        => Show(_owner, _prompt, _caption, _defaultResponse, _cueText, _cueColour, _cueTypeface, _buttonTypeface,
            _promptTypeface, _iconType, _inputType, _textAlignment, _textWrappedMessageTextAlignment, _buttons,
            _focusedButton, _customImage, _initialDateTime);

    public string ShowInputBox(IWin32Window owner, string prompt, string caption,
        string defaultResponse, string cueText,
        Color cueColour, Font cueTypeface, Font buttonTypeface, 
        Font promptTypeface, InputBoxIconType iconType,
        KryptonInputBoxResponseType inputType,
        InputBoxTextAlignment textAlignment,
        InputBoxWrappedMessageTextAlignment textWrappedMessageTextAlignment,
        InputBoxButtons buttons = InputBoxButtons.OkCancel,
        InputBoxButtonFocus focusedButton = InputBoxButtonFocus.ButtonFour,
        Image? customImage = null, DateTime? initialDateTime = default)
        => Show(owner, prompt, caption, defaultResponse, cueText, cueColour, cueTypeface,  buttonTypeface, promptTypeface,
            iconType,  inputType, textAlignment, textWrappedMessageTextAlignment, buttons, focusedButton, customImage, initialDateTime);

    /// <summary>Shows the <see cref="KryptonInputBoxExtendedForm"/>, and returns the input string.</summary>
    /// <param name="owner">The owner.</param>
    /// <param name="prompt">The prompt.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="defaultResponse">The default response.</param>
    /// <param name="cueText">The cue text.</param>
    /// <param name="cueColour">The cue colour.</param>
    /// <param name="cueTypeface">The cue typeface.</param>
    /// <param name="buttonTypeface">The button typeface.</param>
    /// <param name="promptTypeface">The prompt typeface.</param>
    /// <param name="iconType">Type of the icon.</param>
    /// <param name="inputType">Type of the input.</param>
    /// <param name="textAlignment">The text alignment.</param>
    /// <param name="textWrappedMessageTextAlignment">The text wrapped message text alignment.</param>
    /// <param name="buttons">The buttons.</param>
    /// <param name="focusedButton">The focused button.</param>
    /// <param name="customImage">The custom image.</param>
    /// <param name="initialDateTime">The initial date time.</param>
    /// <returns>The users input string.</returns>
    public static string Show(IWin32Window owner, string prompt, string caption,
        string defaultResponse, string cueText,
        Color cueColour, Font cueTypeface, Font buttonTypeface, 
        Font promptTypeface, InputBoxIconType iconType,
        KryptonInputBoxResponseType inputType,
        InputBoxTextAlignment textAlignment,
        InputBoxWrappedMessageTextAlignment textWrappedMessageTextAlignment,
        InputBoxButtons buttons = InputBoxButtons.OkCancel,
        InputBoxButtonFocus focusedButton = InputBoxButtonFocus.ButtonFour,
        Image? customImage = null, DateTime? initialDateTime = default)
        => KryptonInputBoxExtendedForm.InternalShow(owner, prompt, caption, defaultResponse,
            cueText, cueColour, cueTypeface, 
            buttonTypeface, promptTypeface, iconType,
            inputType, textAlignment,
            textWrappedMessageTextAlignment, buttons,
            focusedButton, customImage, initialDateTime);

    #endregion
}