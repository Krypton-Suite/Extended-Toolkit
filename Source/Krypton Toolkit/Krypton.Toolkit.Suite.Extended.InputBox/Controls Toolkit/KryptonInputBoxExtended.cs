namespace Krypton.Toolkit.Suite.Extended.InputBox;

public class KryptonInputBoxExtended
{
    #region Public

    public static string Show(string prompt, string caption)
        => InternalShow(null, prompt, caption, string.Empty, string.Empty,
            Color.Empty, null, null, null, InputBoxIconType.None,
            KryptonInputBoxResponseType.TextBox, InputBoxTextAlignment.Left, InputBoxWrappedMessageTextAlignment.MiddleLeft,
            InputBoxButtons.OkCancel, InputBoxButtonFocus.ButtonOne, null);

    public static string Show(string prompt, string caption, string defaultResponse, string cueText)
        => InternalShow(null, prompt, caption, defaultResponse, cueText,
            Color.Empty, null, null, null, InputBoxIconType.None,
            KryptonInputBoxResponseType.TextBox, InputBoxTextAlignment.Left, InputBoxWrappedMessageTextAlignment.MiddleLeft,
            InputBoxButtons.OkCancel, InputBoxButtonFocus.ButtonOne, null);

    public static string Show(string prompt, string caption, string defaultResponse, string cueText, 
        Color cueColour, Font cueTypeface)
        => InternalShow(null, prompt, caption, defaultResponse, cueText,
            cueColour, cueTypeface, null, null, InputBoxIconType.None,
            KryptonInputBoxResponseType.TextBox, InputBoxTextAlignment.Left, InputBoxWrappedMessageTextAlignment.MiddleLeft,
            InputBoxButtons.OkCancel, InputBoxButtonFocus.ButtonOne, null);

    #endregion

    #region Internal Show

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
    /// <param name="initialDateTime">The initial date and time.</param>
    /// <returns>The users input string.</returns>
    internal static string InternalShow(IWin32Window owner, string prompt, string caption,
        string defaultResponse, string cueText, Color cueColour,
        Font cueTypeface, Font buttonTypeface, Font promptTypeface,
        InputBoxIconType iconType,
        KryptonInputBoxResponseType inputType,
        InputBoxTextAlignment textAlignment,
        InputBoxWrappedMessageTextAlignment textWrappedMessageTextAlignment,
        InputBoxButtons buttons = InputBoxButtons.OkCancel,
        InputBoxButtonFocus focusedButton = InputBoxButtonFocus.ButtonFour,
        Image? customImage = null, DateTime? initialDateTime = null)
        => KryptonInputBoxExtendedForm.InternalShow(owner, prompt, caption, defaultResponse, cueText, 
            cueColour, cueTypeface, buttonTypeface, promptTypeface,
            iconType, inputType, textAlignment,
            textWrappedMessageTextAlignment,
            buttons, focusedButton, customImage, initialDateTime);

    #endregion
}