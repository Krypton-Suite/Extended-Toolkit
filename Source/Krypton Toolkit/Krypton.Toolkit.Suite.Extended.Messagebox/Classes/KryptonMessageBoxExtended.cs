#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    /// <summary>Displays a message box that can contain text, buttons, and symbols that inform and instruct the user.</summary>
    [DesignerCategory(@"code"), ToolboxItem(false)]
    public static class KryptonMessageBoxExtended
    {
        #region Public

        /// <summary>Shows a messagebox.</summary>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="displayHelpButton">if set to <c>true</c> [display help button].</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <param name="messageBoxTypeface">The message box typeface.</param>
        /// <param name="customImageIcon">The custom image icon.</param>
        /// <param name="showOptionalCheckBox">if set to <c>true</c> [show optional CheckBox].</param>
        /// <param name="isOptionalCheckBoxChecked">if set to <c>true</c> [is optional CheckBox checked].</param>
        /// <param name="optionalCheckBoxCheckState">State of the optional CheckBox check.</param>
        /// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static DialogResult Show(string text, string caption = @"",
                                 ExtendedMessageBoxButtons buttons = ExtendedMessageBoxButtons.OK,
                                 ExtendedKryptonMessageBoxIcon icon = ExtendedKryptonMessageBoxIcon.NONE,
                                 MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1,
                                 MessageBoxOptions options = 0,
                                 bool displayHelpButton = false,
                                 bool? showCtrlCopy = null,
                                 Font messageBoxTypeface = null,
                                 Image customImageIcon = null,
                                 bool showOptionalCheckBox = false,
                                 bool isOptionalCheckBoxChecked = false,
                                 CheckState optionalCheckBoxCheckState = CheckState.Unchecked,
                                 string optionalCheckBoxText = @"")
            =>
                InternalShow(null, text, caption, buttons, icon, defaultButton, options,
                             displayHelpButton ? new HelpInfo() : null, showCtrlCopy, 
                             messageBoxTypeface, customImageIcon, showOptionalCheckBox,
                             isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
                             optionalCheckBoxText);

        /// <summary>Shows a messagebox.</summary>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="displayHelpButton">if set to <c>true</c> [display help button].</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static DialogResult Show(string text, string caption,
            ExtendedMessageBoxButtons buttons,
            ExtendedKryptonMessageBoxIcon icon,
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1,
            MessageBoxOptions options = 0,
            bool displayHelpButton = false,
            bool? showCtrlCopy = null)
            =>
                InternalShow(null, text, caption, buttons, icon, defaultButton, options,
                             displayHelpButton ? new HelpInfo() : null, showCtrlCopy,
                             null, null, false,
                             false, CheckState.Unchecked,
                             @"");

        /// <summary>Shows a messagebox.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="displayHelpButton">if set to <c>true</c> [display help button].</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <param name="messageBoxTypeface">The message box typeface.</param>
        /// <param name="customImageIcon">The custom image icon.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static DialogResult Show(IWin32Window owner, string text, string caption = @"",
            ExtendedMessageBoxButtons buttons = ExtendedMessageBoxButtons.OK,
            ExtendedKryptonMessageBoxIcon icon = ExtendedKryptonMessageBoxIcon.NONE,
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1,
            MessageBoxOptions options = 0,
            bool displayHelpButton = false,
            bool? showCtrlCopy = null,
            Font messageBoxTypeface = null,
            Image customImageIcon = null)
            =>
                InternalShow(owner, text, caption, buttons, icon, defaultButton, options,
                             displayHelpButton ? new HelpInfo() : null, showCtrlCopy,
                             messageBoxTypeface, customImageIcon, false,
                             false, CheckState.Unchecked,
                             @"");

        /// <summary>Shows a messagebox.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="displayHelpButton">if set to <c>true</c> [display help button].</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static DialogResult Show(IWin32Window owner, string text, string caption,
            ExtendedMessageBoxButtons buttons,
            ExtendedKryptonMessageBoxIcon icon,
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1,
            MessageBoxOptions options = 0,
            bool displayHelpButton = false,
            bool? showCtrlCopy = null)
            =>
                InternalShow(owner, text, caption, buttons, icon, defaultButton, options,
                             displayHelpButton ? new HelpInfo() : null, showCtrlCopy, 
                             null, null, false,
                             false, CheckState.Unchecked,
                             @"");

        /// <summary>Shows a messagebox.</summary>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="helpFilePath">The help file path.</param>
        /// <param name="navigator">The navigator.</param>
        /// <param name="param">The parameter.</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <param name="messageBoxTypeface">The message box typeface.</param>
        /// <param name="customImageIcon">The custom image icon.</param>
        /// <param name="showOptionalCheckBox">if set to <c>true</c> [show optional CheckBox].</param>
        /// <param name="isOptionalCheckBoxChecked">if set to <c>true</c> [is optional CheckBox checked].</param>
        /// <param name="optionalCheckBoxCheckState">State of the optional CheckBox check.</param>
        /// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static DialogResult Show(string text, string caption = @"",
                                 ExtendedMessageBoxButtons buttons = ExtendedMessageBoxButtons.OK,
                                 ExtendedKryptonMessageBoxIcon icon = ExtendedKryptonMessageBoxIcon.NONE,
                                 MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1,
                                 MessageBoxOptions options = 0,
                                 string helpFilePath = @"",
                                 HelpNavigator navigator = 0,
                                 object param = null,
                                 bool? showCtrlCopy = null,
                                 Font messageBoxTypeface = null,
                                 Image customImageIcon = null,
                                 bool showOptionalCheckBox = false,
                                 bool isOptionalCheckBoxChecked = false,
                                 CheckState optionalCheckBoxCheckState = CheckState.Unchecked,
                                 string optionalCheckBoxText = @"")
            =>
                InternalShow(null, text, caption, buttons, icon, defaultButton, options,
                             new HelpInfo(helpFilePath, navigator, param), showCtrlCopy,
                             messageBoxTypeface, customImageIcon, showOptionalCheckBox,
                             isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
                             optionalCheckBoxText);

        /// <summary>Shows a messagebox.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="helpFilePath">The help file path.</param>
        /// <param name="navigator">The navigator.</param>
        /// <param name="param">The parameter.</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <param name="messageBoxTypeface">The message box typeface.</param>
        /// <param name="customImageIcon">The custom image icon.</param>
        /// <param name="showOptionalCheckBox">if set to <c>true</c> [show optional CheckBox].</param>
        /// <param name="isOptionalCheckBoxChecked">if set to <c>true</c> [is optional CheckBox checked].</param>
        /// <param name="optionalCheckBoxCheckState">State of the optional CheckBox check.</param>
        /// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static DialogResult Show(IWin32Window owner, string text, string caption = @"",
                                 ExtendedMessageBoxButtons buttons = ExtendedMessageBoxButtons.OK,
                                 ExtendedKryptonMessageBoxIcon icon = ExtendedKryptonMessageBoxIcon.NONE,
                                 MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1,
                                 MessageBoxOptions options = 0,
                                 string helpFilePath = @"",
                                 HelpNavigator navigator = 0,
                                 object param = null,
                                 bool? showCtrlCopy = null,
                                 Font messageBoxTypeface = null,
                                 Image customImageIcon = null,
                                 bool showOptionalCheckBox = false,
                                 bool isOptionalCheckBoxChecked = false,
                                 CheckState optionalCheckBoxCheckState = CheckState.Unchecked,
                                 string optionalCheckBoxText = @"")
            =>
                InternalShow(owner, text, caption, buttons, icon, defaultButton, options,
                             new HelpInfo(helpFilePath, navigator, param), showCtrlCopy, 
                             messageBoxTypeface, customImageIcon, showOptionalCheckBox,
                             isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
                             optionalCheckBoxText);
        #endregion

        #region Implementation

        /// <summary>Shows the messagebox.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="helpInfo">The help information.</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <param name="messageBoxTypeface">The message box typeface.</param>
        /// <param name="customImageIcon">The custom image icon.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        internal static DialogResult InternalShow(IWin32Window owner, string text, string caption,
                                           ExtendedMessageBoxButtons buttons,
                                           ExtendedKryptonMessageBoxIcon icon,
                                           MessageBoxDefaultButton defaultButton,
                                           MessageBoxOptions options,
                                           HelpInfo helpInfo,
                                           bool? showCtrlCopy, Font messageBoxTypeface,
                                           Image customImageIcon, bool? showOptionalCheckBox, 
                                           bool? optionalCheckBoxChecked,
                                           CheckState? optionalCheckBoxCheckState,
                                           string optionalCheckBoxText)
        {
            IWin32Window showOwner = ValidateOptions(owner, options, helpInfo);

            using KryptonMessageBoxExtendedForm kmbef = new(showOwner, text, caption, buttons,
                                                            icon, defaultButton, options,
                                                            helpInfo, showCtrlCopy,
                                                            messageBoxTypeface,
                                                            customImageIcon, showOptionalCheckBox,
                                                            optionalCheckBoxChecked, optionalCheckBoxCheckState,
                                                            optionalCheckBoxText);

            return kmbef.ShowDialog(showOwner);
        }
        #endregion

        #region WinForm Compatibility
        private static IWin32Window ValidateOptions(IWin32Window owner, MessageBoxOptions options, HelpInfo helpInfo)
        {
            // Check if trying to show a message box from a non-interactive process, this is not possible
            if (!SystemInformation.UserInteractive &&
                ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) == 0))
            {
                throw new InvalidOperationException("Cannot show modal dialog when non-interactive");
            }

            // Check if trying to show a message box from a service and the owner has been specified, this is not possible
            if ((owner != null) &&
                ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) != 0))
            {
                throw new ArgumentException(@"Cannot show message box from a service with an owner specified", nameof(options));
            }

            // Check if trying to show a message box from a service and help information is specified, this is not possible
            if ((helpInfo != null) &&
                ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) != 0))
            {
                throw new ArgumentException(@"Cannot show message box from a service with help specified", nameof(options));
            }

            IWin32Window showOwner = null;
            if ((helpInfo != null) ||
                ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) == 0))
            {
                // If do not have an owner passed in then get the active window and use that instead
                showOwner = owner ?? Control.FromHandle(PI.GetActiveWindow());
            }

            return showOwner;
        }
        #endregion

    }
}