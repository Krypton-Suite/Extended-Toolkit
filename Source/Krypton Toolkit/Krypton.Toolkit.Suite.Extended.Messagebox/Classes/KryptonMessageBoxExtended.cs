namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    [DesignerCategory("code"), ToolboxItem(false)]
    public partial class KryptonMessageBoxExtended
    {
        #region Public

        #region Show
        /// <summary>
        /// Displays a message box with specified text.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null, Point? optionalCheckBoxLocation = null,
                                        bool showCopyButton = false, string copyButtonText = null, bool? fade = false,
                                        int? fadeSleepTimer = 50, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE,
                                        bool? showToolTips = null, bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(null, text, null, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxCustomButtonOptions.NONE,
                                ExtendedKryptonMessageBoxIcon.NONE,
                                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly,
                                null, showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText,
                                isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor,
                                optionalCheckBoxLocation, null, showCopyButton, copyButtonText, fade,
                                fadeSleepTimer, string.Empty, string.Empty, string.Empty,
                                DialogResult.OK, DialogResult.OK, DialogResult.OK,
                                cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
                                contentMessageColour, buttonOneTextColour, buttonTwoTextColour, buttonThreeTextColour,
                                yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box in front of the specified object and with the specified text.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner, string text, bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, bool showCopyButton = false,
                                        string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
                                        float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(owner, text, string.Empty, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxCustomButtonOptions.NONE,
                                ExtendedKryptonMessageBoxIcon.NONE,
                                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, null, showCtrlCopy,
                                messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked,
                                optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation, null,
                                showCopyButton, copyButtonText, fade, fadeSleepTimer, string.Empty, string.Empty, string.Empty,
                                DialogResult.OK, DialogResult.OK, DialogResult.OK, cornerRadius, showToolTips, useBlur,
                                useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour,
                                buttonTwoTextColour, buttonThreeTextColour, yesButtonColour, noButtonColour, textColour,
                                yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box with specified text and caption.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption, bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, bool showCopyButton = false,
                                        string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
                                        float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(null, text, caption, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxCustomButtonOptions.NONE,
                                ExtendedKryptonMessageBoxIcon.NONE,
                                MessageBoxDefaultButton.Button1, 0, null,
                                showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked,
                                optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation, null,
                                showCopyButton, copyButtonText, fade, fadeSleepTimer, null, null, null, null,
                                null, null, cornerRadius, showToolTips, useBlur,
                                useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour,
                                buttonTwoTextColour, buttonThreeTextColour, yesButtonColour, noButtonColour, textColour,
                                yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box in front of the specified object and with the specified text and caption.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption, bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, bool showCopyButton = false,
                                        string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
                                        float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(owner, text, caption, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxCustomButtonOptions.NONE,
                                ExtendedKryptonMessageBoxIcon.NONE,
                                MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, messageboxTypeface,
                                showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
                                optionalCheckBoxAnchor, optionalCheckBoxLocation, null, showCopyButton, copyButtonText,
                                fade, fadeSleepTimer, null, null, null, null,
                                null, null, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour,
                                blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour,
                                parentWindow);
        }

        /// <summary>
        /// Displays a message box with specified text, caption, and buttons.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, bool showCopyButton = false,
                                        string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(null, text, caption, buttons, customButtonOptions, ExtendedKryptonMessageBoxIcon.NONE,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly, null, showCtrlCopy, messageboxTypeface,
                                showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked,
                                optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation,
                                null, showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText,
                                buttonTwoCustomText, buttonThreeCustomText, buttonOneCustomDialogResult,
                                buttonTwoCustomDialogResult, buttonThreeCustomDialogResult, cornerRadius,
                                showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
                                contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour,
                                yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box in front of the specified object and with the specified text, caption, and buttons.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, bool showCopyButton = false,
                                        string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(owner, text, caption, buttons, customButtonOptions, ExtendedKryptonMessageBoxIcon.NONE,
                                MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, messageboxTypeface,
                                showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
                                optionalCheckBoxAnchor, optionalCheckBoxLocation, null, showCopyButton, copyButtonText,
                                fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText,
                                buttonOneCustomDialogResult, buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
                                cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box with specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        ExtendedMessageBoxButtons buttons,
                                        ExtendedMessageBoxCustomButtonOptions customButtonOptions, ExtendedKryptonMessageBoxIcon icon,
                                        bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
                                        bool showCopyButton = false, string copyButtonText = null,
                                        bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(null, text, caption, buttons, customButtonOptions, icon, MessageBoxDefaultButton.Button1, 0,
                                null, showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText,
                                isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation,
                                customMessageBoxIcon, showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText,
                                buttonTwoCustomText, buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
                                buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
                                contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        ExtendedKryptonMessageBoxIcon icon, bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
                                        bool showCopyButton = false, string copyButtonText = null,
                                        bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, MessageBoxDefaultButton.Button1, 0,
                                null, showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText,
                                isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation,
                                customMessageBoxIcon, showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText,
                                buttonTwoCustomText, buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
                                buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
                                contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, and default button.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        ExtendedKryptonMessageBoxIcon icon, MessageBoxDefaultButton defaultButton, bool? showCtrlCopy = null,
                                        Font messageboxTypeface = null, bool showOptionalCheckBox = false,
                                        string optionalCheckBoxText = null, bool isOptionalCheckBoxChecked = false,
                                        CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null, Point? optionalCheckBoxLocation = null,
                                        Image customMessageBoxIcon = null, bool showCopyButton = false,
                                        string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(null, text, caption, buttons, customButtonOptions, icon, defaultButton, 0, null,
                                showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked,
                                optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon,
                                showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText,
                                buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
                                buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
                                contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box in front of the specified object and with the specified text, caption, buttons, icon, and default button.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, bool? showCtrlCopy = null,
                                        Font messageboxTypeface = null, bool showOptionalCheckBox = false,
                                        string optionalCheckBoxText = null, bool isOptionalCheckBoxChecked = false,
                                        CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null, Point? optionalCheckBoxLocation = null,
                                        Image customMessageBoxIcon = null, bool showCopyButton = false,
                                        string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, defaultButton, 0, null,
                                showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked,
                                optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon,
                                showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText,
                                buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
                                buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
                                contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, and options.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
                                        bool showCopyButton = false, string copyButtonText = null,
                                        bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(null, text, caption, buttons, customButtonOptions, icon, defaultButton, options, null,
                                showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked,
                                optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon,
                                showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText,
                                buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
                                buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
                                contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box in front of the specified object and with the specified text, caption, buttons, icon, default button, and options.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
                                        bool showCopyButton = false, string copyButtonText = null,
                                        bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, defaultButton, options, null,
                                showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked,
                                optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon,
                                showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText,
                                buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
                                buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
                                contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="displayHelpButton">Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        bool displayHelpButton, bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
                                        bool showCopyButton = false, string copyButtonText = null,
                                        bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE,
                                        bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(null, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
                                displayHelpButton ? new HelpInfo() : null, showCtrlCopy, messageboxTypeface, showOptionalCheckBox,
                                optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor,
                                optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText, fade, fadeSleepTimer,
                                buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText, buttonOneCustomDialogResult,
                                buttonTwoCustomDialogResult, buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur,
                                useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
                                        bool showCopyButton = false, string copyButtonText = null,
                                        bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(null, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
                                new HelpInfo(helpFilePath), showCtrlCopy, messageboxTypeface, showOptionalCheckBox,
                                optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor,
                                optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText, fade, fadeSleepTimer,
                                buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText, buttonOneCustomDialogResult,
                                buttonTwoCustomDialogResult, buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur,
                                useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
                                        bool showCopyButton = false, string copyButtonText = null,
                                        bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
                   new HelpInfo(helpFilePath), showCtrlCopy, messageboxTypeface, showOptionalCheckBox,
                                optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor,
                                optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText, fade, fadeSleepTimer,
                                buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText, buttonOneCustomDialogResult,
                                buttonTwoCustomDialogResult, buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur,
                                useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file and HelpNavigator.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="navigator">One of the System.Windows.Forms.HelpNavigator values.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, HelpNavigator navigator, bool? showCtrlCopy = null,
                                        Font messageboxTypeface = null, bool showOptionalCheckBox = false,
                                        string optionalCheckBoxText = null, bool isOptionalCheckBoxChecked = false,
                                        CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null, Point? optionalCheckBoxLocation = null,
                                        Image customMessageBoxIcon = null, bool showCopyButton = false,
                                        string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(null, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
                                new HelpInfo(helpFilePath, navigator), showCtrlCopy, messageboxTypeface,
                                showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
                                optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText,
                                fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText,
                                buttonOneCustomDialogResult, buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
                                cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
                                contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file and Help keyword.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="keyword">The Help keyword to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, string keyword, bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
                                        bool showCopyButton = false, string copyButtonText = null,
                                        bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(null, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
                                new HelpInfo(helpFilePath, keyword), showCtrlCopy, messageboxTypeface, showOptionalCheckBox,
                                optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor,
                                optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText, fade, fadeSleepTimer,
                                buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText, buttonOneCustomDialogResult,
                                buttonTwoCustomDialogResult, buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur,
                                useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file and HelpNavigator.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="navigator">One of the System.Windows.Forms.HelpNavigator values.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, HelpNavigator navigator, bool? showCtrlCopy = null,
                                        Font messageboxTypeface = null, bool showOptionalCheckBox = false,
                                        string optionalCheckBoxText = null, bool isOptionalCheckBoxChecked = false,
                                        CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null, Point? optionalCheckBoxLocation = null,
                                        Image customMessageBoxIcon = null, bool showCopyButton = false,
                                        string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
                                new HelpInfo(helpFilePath, navigator), showCtrlCopy, messageboxTypeface,
                                showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
                                optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText,
                                fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText,
                                buttonOneCustomDialogResult, buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
                                cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
                                contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file and Help keyword.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="keyword">The Help keyword to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, string keyword, bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
                                        bool showCopyButton = false, string copyButtonText = null,
                                        bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
                                new HelpInfo(helpFilePath, keyword), showCtrlCopy, messageboxTypeface,
                                showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
                                optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText,
                                fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText,
                                buttonOneCustomDialogResult, buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
                                cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
                                contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file, HelpNavigator, and Help topic.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="navigator">One of the System.Windows.Forms.HelpNavigator values.</param>
        /// <param name="param">The numeric ID of the Help topic to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, HelpNavigator navigator, object param,
                                        bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
                                        AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
                                        bool showCopyButton = false, string copyButtonText = null,
                                        bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(null, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
                                new HelpInfo(helpFilePath, navigator, param), showCtrlCopy, messageboxTypeface,
                                showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
                                optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText,
                                fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText,
                                buttonOneCustomDialogResult, buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
                                cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
                                contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file, HelpNavigator, and Help topic.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="navigator">One of the System.Windows.Forms.HelpNavigator values.</param>
        /// <param name="param">The numeric ID of the Help topic to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">Defines the message box font.</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, HelpNavigator navigator, object param,
                                        bool? showCtrlCopy = null, Font messageboxTypeface = null,
                                        bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
                                        bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null, AnchorStyles? optionalCheckBoxAnchor = null,
                                        Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
                                        bool showCopyButton = false, string copyButtonText = null,
                                        bool? fade = false, int? fadeSleepTimer = 50,
                                        string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                        bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                        int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                        Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                        Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                        Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
                   new HelpInfo(helpFilePath, navigator, param), showCtrlCopy, messageboxTypeface,
                                showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
                                optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText,
                                fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText,
                                buttonOneCustomDialogResult, buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
                                cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
                                contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file, HelpNavigator, and Help topic.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
        /// <param name="customButtonOptions">Custom button options.</param>
        /// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="HelpInfo">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageBoxTypeface">Defines the message box font.</param>
        /// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
        /// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
        /// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
        /// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
        /// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
        /// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
        /// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
        /// <param name="copyButtonText">The text shown on the copy button.</param>
        /// <param name="fade">Allows the message box to fade in and out.</param>
        /// <param name="fadeSleepTimer">The speed of the fading effect.</param>
        /// <param name="buttonOneCustomText">The custom text on the first button.</param>
        /// <param name="buttonTwoCustomText">The custom text on the second button.</param>
        /// <param name="buttonThreeCustomText">The custom text on the third button.</param>
        /// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
        /// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
        /// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
        /// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
        /// <param name="showToolTips">Displays tool-tips on the controls.</param>
        /// <param name="useBlur">Use the blur functionality on the parent window.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        internal static DialogResult Show(IWin32Window owner,
                                          string text, string caption,
                                          ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                          ExtendedKryptonMessageBoxIcon icon,
                                          MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                          HelpInfo HelpInfo, bool showCtrlCopy, Font messageBoxTypeface,
                                          bool showOptionalCheckBox, string optionalCheckBoxText, bool isOptionalCheckBoxChecked,
                                          CheckState? optionalCheckBoxCheckState,
                                          AnchorStyles optionalCheckBoxAnchor, Point optionalCheckBoxLocation,
                                          Image customMessageBoxIcon, bool showCopyButton = false,
                                          string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
                                          string buttonOneCustomText = null, string buttonTwoCustomText = null,
                                          string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
                                          DialogResult? buttonTwoCustomDialogResult = null,
                                          DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
                                          bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
                                          int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
                                          Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
                                          Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
                                          Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
        {
            return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, defaultButton, options, HelpInfo, showCtrlCopy, messageBoxTypeface, showOptionalCheckBox,
                                optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation,
                                customMessageBoxIcon, showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText,
                                buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
                                cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
                                buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
        }
        #endregion

        #endregion

        #region Implementation

        /// <summary>Internals the show.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="customButtonOptions">The custom button options.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="helpInfo">The help information.</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <param name="messageboxTypeface">The messagebox typeface.</param>
        /// <param name="showOptionalCheckBox">The show optional CheckBox.</param>
        /// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
        /// <param name="isOptionalCheckBoxChecked">The is optional CheckBox checked.</param>
        /// <param name="optionalCheckBoxCheckState">State of the optional CheckBox check.</param>
        /// <param name="optionalCheckBoxAnchor">The optional CheckBox anchor.</param>
        /// <param name="optionalCheckBoxLocation">The optional CheckBox location.</param>
        /// <param name="customMessageBoxIcon">The custom message box icon.</param>
        /// <param name="showCopyButton">The show copy button.</param>
        /// <param name="copyButtonText">The copy button text.</param>
        /// <param name="fade">The fade.</param>
        /// <param name="fadeSleepTimer">The fade sleep timer.</param>
        /// <param name="buttonOneCustomText">The button one custom text.</param>
        /// <param name="buttonTwoCustomText">The button two custom text.</param>
        /// <param name="buttonThreeCustomText">The button three custom text.</param>
        /// <param name="buttonOneCustomDialogResult">The button one custom dialog result.</param>
        /// <param name="buttonTwoCustomDialogResult">The button two custom dialog result.</param>
        /// <param name="buttonThreeCustomDialogResult">The button three custom dialog result.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="showToolTips">The show tool tips.</param>
        /// <param name="useBlur">The use blur.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        private static DialogResult InternalShow(IWin32Window owner, string text, string caption,
                                                 ExtendedMessageBoxButtons buttons,
                                                 ExtendedMessageBoxCustomButtonOptions? customButtonOptions,
                                                 ExtendedKryptonMessageBoxIcon icon, MessageBoxDefaultButton defaultButton,
                                                 MessageBoxOptions options, HelpInfo helpInfo, bool? showCtrlCopy,
                                                 Font messageboxTypeface, bool? showOptionalCheckBox, string optionalCheckBoxText,
                                                 bool? isOptionalCheckBoxChecked, CheckState? optionalCheckBoxCheckState,
                                                 AnchorStyles? optionalCheckBoxAnchor, Point? optionalCheckBoxLocation,
                                                 Image customMessageBoxIcon, bool? showCopyButton, string copyButtonText,
                                                 bool? fade, int? fadeSleepTimer, string buttonOneCustomText,
                                                 string buttonTwoCustomText, string buttonThreeCustomText,
                                                 DialogResult? buttonOneCustomDialogResult, DialogResult? buttonTwoCustomDialogResult,
                                                 DialogResult? buttonThreeCustomDialogResult, float? cornerRadius,
                                                 bool? showToolTips, bool? useBlur, bool? useYesNoCancelButtonColour,
                                                 int? blurRadius, Color? contentMessageColour, Color? buttonOneTextColour,
                                                 Color? buttonTwoTextColour, Color? buttonThreeTextColour,
                                                 Color? yesButtonColour, Color? noButtonColour, Color? textColour,
                                                 Color? yesNoButtonTextColour, KryptonForm parentWindow)
        {
            IWin32Window showOwner = ValidateOptions(owner, options, helpInfo);

            using KryptonMessageBoxExtendedForm kbme = new(showOwner, text, caption, buttons, customButtonOptions,
                                                           icon, defaultButton, options, helpInfo, showCtrlCopy,
                                                           messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText,
                                                           isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
                                                           optionalCheckBoxAnchor, optionalCheckBoxLocation,
                                                           customMessageBoxIcon, showCopyButton, copyButtonText,
                                                           fade, fadeSleepTimer, buttonOneCustomText,
                                                           buttonTwoCustomText, buttonThreeCustomText,
                                                           buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
                                                           buttonThreeCustomDialogResult, cornerRadius,
                                                           showToolTips, useBlur, useYesNoCancelButtonColour,
                                                           blurRadius, contentMessageColour, buttonOneTextColour,
                                                           buttonTwoTextColour, buttonThreeTextColour, yesButtonColour,
                                                           noButtonColour, textColour, yesNoButtonTextColour,
                                                           parentWindow);

            kbme.StartPosition = showOwner == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;

            return kbme.ShowDialog(showOwner);
        }

        #region WindowsForms Compatibility

        private static IWin32Window ValidateOptions(IWin32Window owner, MessageBoxOptions options, HelpInfo helpInfo)
        {
            // Check if trying to show a message box from a non-interactive process, this is not possible
            if (!SystemInformation.UserInteractive && ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) == 0))
            {
                throw new InvalidOperationException("Cannot show modal dialog when non-interactive");
            }

            // Check if trying to show a message box from a service and the owner has been specified, this is not possible
            if ((owner != null) && ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) != 0))
            {
                throw new ArgumentException(@"Cannot show message box from a service with an owner specified", nameof(options));
            }

            // Check if trying to show a message box from a service and help information is specified, this is not possible
            if ((helpInfo != null) && ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) != 0))
            {
                throw new ArgumentException(@"Cannot show message box from a service with help specified", nameof(options));
            }

            IWin32Window showOwner = null;

            if ((helpInfo != null) || ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) == 0))
            {
                // If do not have an owner passed in then get the active window and use that instead
                showOwner = owner ?? Control.FromHandle(PI.GetActiveWindow());
            }

            return showOwner;
        }
        #endregion

        #endregion
    }
}