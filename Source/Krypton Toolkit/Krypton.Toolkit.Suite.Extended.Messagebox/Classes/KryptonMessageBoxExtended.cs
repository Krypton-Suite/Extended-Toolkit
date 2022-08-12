﻿#region BSD License
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
        /// <param name="messageText">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        public static DialogResult Show(string messageText, string caption, ExtendedMessageBoxButtons buttons,
                                        ExtendedKryptonMessageBoxIcon icon, bool? showCtrlCopy = null,
                                        bool? showMoreDetailsUI = null, string moreDetailsText = @"",
                                        string collapseText = @"", string expandText = @"",
                                        int? maximumMoreDetailsDropDownHeight = null)
            => ShowCore(null, messageText, caption, buttons, icon, KryptonMessageBoxDefaultButton.Button1, 0,
                        null, showCtrlCopy, null, null, null, Color.Empty, new [] {Color.Empty, Color.Empty, Color.Empty, Color.Empty},
                        null, null, null, null, string.Empty, string.Empty,
                        string.Empty, string.Empty, showMoreDetailsUI, moreDetailsText,
                        collapseText, expandText, maximumMoreDetailsDropDownHeight,
                        null, null, null, null, @"",
                        @"", @"");

        /// <summary>Shows a messagebox.</summary>
        /// <param name="messageText">The text.</param>
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
        public static DialogResult Show(string messageText, string caption = @"",
                                        ExtendedMessageBoxButtons buttons = ExtendedMessageBoxButtons.OK,
                                        ExtendedKryptonMessageBoxIcon icon = ExtendedKryptonMessageBoxIcon.None,
                                        KryptonMessageBoxDefaultButton defaultButton = KryptonMessageBoxDefaultButton.Button1,
                                        MessageBoxOptions options = 0,
                                        bool displayHelpButton = false,
                                        bool? showCtrlCopy = null,
                                        Font messageBoxTypeface = null,
                                        Image customImageIcon = null,
                                        bool? showMoreDetailsUI = null, 
                                        string moreDetailsText = @"",
                                        string collapseText = @"", string expandText = @"",
                                        int? maximumMoreDetailsDropDownHeight = null)
            =>
                ShowCore(null, messageText, caption, buttons, icon, defaultButton, options,
                         displayHelpButton ? new HelpInfo() : null, showCtrlCopy,
                         messageBoxTypeface, customImageIcon, null, Color.Empty, 
                         new[] { Color.Empty, Color.Empty, Color.Empty, Color.Empty },
                         null, null, null, null, string.Empty, string.Empty, 
                         string.Empty, string.Empty, showMoreDetailsUI, moreDetailsText,
                         collapseText, expandText, maximumMoreDetailsDropDownHeight,
                         null, null, null, null, @"",
                         @"", @"");

        /// <summary>Shows a messagebox.</summary>
        /// <param name="messageText">The text.</param>
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
        public static DialogResult Show(string messageText, string caption,
                                        ExtendedMessageBoxButtons buttons,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        KryptonMessageBoxDefaultButton defaultButton = KryptonMessageBoxDefaultButton.Button1,
                                        MessageBoxOptions options = 0,
                                        bool displayHelpButton = false,
                                        bool? showCtrlCopy = null,
                                        bool? showMoreDetailsUI = null, 
                                        string moreDetailsText = @"",
                                        string collapseText = @"", string expandText = @"",
                                        int? maximumMoreDetailsDropDownHeight = null)
            =>
                ShowCore(null, messageText, caption, buttons, icon, defaultButton, options,
                         displayHelpButton ? new HelpInfo() : null, showCtrlCopy,
                         null, null, null, Color.Empty,
                         new[] { Color.Empty, Color.Empty, Color.Empty, Color.Empty },
                         null, null, null, null, string.Empty, string.Empty,
                         string.Empty, string.Empty, showMoreDetailsUI,
                         moreDetailsText, collapseText, expandText, maximumMoreDetailsDropDownHeight,
                         null, null, null, null, @"",
                         @"", @"");

        /// <summary>Shows a messagebox.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="messageText">The text.</param>
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
        public static DialogResult Show(IWin32Window owner, string messageText, string caption = @"",
                                        ExtendedMessageBoxButtons buttons = ExtendedMessageBoxButtons.OK,
                                        ExtendedKryptonMessageBoxIcon icon = ExtendedKryptonMessageBoxIcon.None,
                                        KryptonMessageBoxDefaultButton defaultButton = KryptonMessageBoxDefaultButton.Button1,
                                        MessageBoxOptions options = 0,
                                        bool displayHelpButton = false,
                                        bool? showCtrlCopy = null,
                                        Font messageBoxTypeface = null,
                                        Image customImageIcon = null,
                                        bool? showMoreDetailsUI = null, 
                                        string moreDetailsText = @"",
                                        string collapseText = @"", string expandText = @"",
                                        int? maximumMoreDetailsDropDownHeight = null)
            =>
                ShowCore(owner, messageText, caption, buttons, icon, defaultButton, options,
                         displayHelpButton ? new HelpInfo() : null, showCtrlCopy,
                         messageBoxTypeface, customImageIcon, null, Color.Empty,
                         new[] { Color.Empty, Color.Empty, Color.Empty, Color.Empty },
                         null, null, null, null, string.Empty,
                         string.Empty, string.Empty, string.Empty,
                         showMoreDetailsUI, moreDetailsText, collapseText, expandText, maximumMoreDetailsDropDownHeight,
                         null, null, null, null, @"",
                         @"", @"");

        /// <summary>Shows a messagebox.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="messageText">The text.</param>
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
        public static DialogResult Show(IWin32Window owner, string messageText, string caption,
                                        ExtendedMessageBoxButtons buttons,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        KryptonMessageBoxDefaultButton defaultButton = KryptonMessageBoxDefaultButton.Button1,
                                        MessageBoxOptions options = 0,
                                        bool displayHelpButton = false,
                                        bool? showCtrlCopy = null,
                                        bool? showMoreDetailsUI = null,
                                        string moreDetailsText = @"",
                                        string collapseText = @"", string expandText = @"",
                                        int? maximumMoreDetailsDropDownHeight = null)
            =>
                ShowCore(owner, messageText, caption, buttons, icon, defaultButton, options,
                         displayHelpButton ? new HelpInfo() : null, showCtrlCopy,
                         null, null, null, Color.Empty,
                         new[] { Color.Empty, Color.Empty, Color.Empty, Color.Empty },
                         null, null, null, null, string.Empty,
                         string.Empty, string.Empty, string.Empty,
                         showMoreDetailsUI, moreDetailsText, collapseText, expandText, maximumMoreDetailsDropDownHeight,
                         null, null, null, null, @"",
                         @"", @"");

        /// <summary>Shows a messagebox.</summary>
        /// <param name="messageText">The text.</param>
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
        /// <returns>
        ///   <br />
        /// </returns>
        public static DialogResult Show(string messageText, string caption = @"",
                                        ExtendedMessageBoxButtons buttons = ExtendedMessageBoxButtons.OK,
                                        ExtendedKryptonMessageBoxIcon icon = ExtendedKryptonMessageBoxIcon.None,
                                        KryptonMessageBoxDefaultButton defaultButton = KryptonMessageBoxDefaultButton.Button1,
                                        MessageBoxOptions options = 0,
                                        string helpFilePath = @"",
                                        HelpNavigator navigator = 0,
                                        object param = null,
                                        bool? showCtrlCopy = null,
                                        Font messageBoxTypeface = null,
                                        Image customImageIcon = null,
                                        bool? showMoreDetailsUI = null, 
                                        string moreDetailsText = @"",
                                        string collapseText = @"", string expandText = @"",
                                        int? maximumMoreDetailsDropDownHeight = null)
            =>
                ShowCore(null, messageText, caption, buttons, icon, defaultButton, options,
                         new HelpInfo(helpFilePath, navigator, param), showCtrlCopy,
                         messageBoxTypeface, customImageIcon, null, Color.Empty,
                         new[] { Color.Empty, Color.Empty, Color.Empty, Color.Empty },
                         null, null, null, null, string.Empty, 
                         string.Empty, string.Empty, string.Empty, showMoreDetailsUI,
                         moreDetailsText, collapseText, expandText, maximumMoreDetailsDropDownHeight,
                         null, null, null, null, @"",
                         @"", @"");

        /// <summary>Shows a messagebox.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="messageText">The text.</param>
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
        /// <returns>
        ///   <br />
        /// </returns>
        public static DialogResult Show(IWin32Window owner, string messageText, string caption = @"",
                                        ExtendedMessageBoxButtons buttons = ExtendedMessageBoxButtons.OK,
                                        ExtendedKryptonMessageBoxIcon icon = ExtendedKryptonMessageBoxIcon.None,
                                        KryptonMessageBoxDefaultButton defaultButton = KryptonMessageBoxDefaultButton.Button1,
                                        MessageBoxOptions options = 0,
                                        string helpFilePath = @"",
                                        HelpNavigator navigator = 0,
                                        object param = null,
                                        bool displayHelpButton = false,
                                        bool? showCtrlCopy = null,
                                        Font messageBoxTypeface = null,
                                        Image customImageIcon = null,
                                        bool? showHelpButton = null,
                                        Color? messageTextColour = null,
                                        Color[] buttonTextColours = null,
                                        DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null,
                                        DialogResult? buttonFourDialogResult = null,
                                        string buttonOneCustomText = null,
                                        string buttonTwoCustomText = null,
                                        string buttonThreeCustomText = null,
                                        string buttonFourCustomText = null,
                                        bool? showMoreDetailsUI = null, 
                                        string moreDetailsText = @"",
                                        string collapseText = @"", string expandText = @"",
                                        int? maximumMoreDetailsDropDownHeight = null,
                                        bool? showOptionalCheckBox = null,
                                        CheckState? optionalCheckBoxCheckState = CheckState.Unchecked,
                                        bool? showOptionalLinkLabel = null,
                                        KryptonCommand linkCommand = null,
                                        string optionalCheckBoxText = @"",
                                        string optionalLinkLabelText = @"",
                                        string optionalLinkLabelURL = @"")
            =>
                ShowCore(owner, messageText, caption, buttons, icon, defaultButton, options,
                         displayHelpButton ? new HelpInfo(helpFilePath, navigator, param) : null,
                         showCtrlCopy, messageBoxTypeface, customImageIcon,
                         showHelpButton, messageTextColour, buttonTextColours, buttonOneCustomDialogResult,
                         buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
                         buttonFourDialogResult, buttonOneCustomText, buttonTwoCustomText,
                         buttonThreeCustomText, buttonFourCustomText,
                         showMoreDetailsUI, moreDetailsText, collapseText, expandText,
                         maximumMoreDetailsDropDownHeight, showOptionalCheckBox, optionalCheckBoxCheckState,
                         showOptionalLinkLabel, linkCommand, optionalCheckBoxText, optionalLinkLabelText,
                         optionalLinkLabelURL);
        #endregion

        #region Implementation

        /// <summary>Shows the core.</summary>
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
        /// <param name="showHelpButton">The show help button.</param>
        /// <param name="messageTextColour">The message text colour.</param>
        /// <param name="buttonTextColours">The button text colours.</param>
        /// <param name="buttonOneCustomDialogResult">The button one custom dialog result.</param>
        /// <param name="buttonTwoCustomDialogResult">The button two custom dialog result.</param>
        /// <param name="buttonThreeCustomDialogResult">The button three custom dialog result.</param>
        /// <param name="buttonFourDialogResult">The button four dialog result.</param>
        /// <param name="buttonOneCustomText">The button one custom text.</param>
        /// <param name="buttonTwoCustomText">The button two custom text.</param>
        /// <param name="buttonThreeCustomText">The button three custom text.</param>
        /// <param name="buttonFourCustomText">The button four custom text.</param>
        /// <param name="showMoreDetailsUI">The show more details UI.</param>
        /// <param name="moreDetailsText">The more details text.</param>
        /// <param name="collapseText">The collapse text.</param>
        /// <param name="expandText">The expand text.</param>
        /// <param name="maximumMoreDetailsDropDownHeight">Maximum height of the more details drop down.</param>
        /// <param name="showOptionalCheckBox">The show optional CheckBox.</param>
        /// <param name="optionalCheckBoxCheckState">State of the optional CheckBox check.</param>
        /// <param name="showOptionalLinkLabel">The show optional link label.</param>
        /// <param name="linkCommand">The link command.</param>
        /// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
        /// <param name="optionalLinkLabelText">The optional link label text.</param>
        /// <param name="optionalLinkLabelURL">The optional link label URL.</param>
        internal static DialogResult ShowCore(IWin32Window owner, string text, string caption,
                                              ExtendedMessageBoxButtons buttons,
                                              ExtendedKryptonMessageBoxIcon icon,
                                              KryptonMessageBoxDefaultButton defaultButton,
                                              MessageBoxOptions options, HelpInfo helpInfo,
                                              bool? showCtrlCopy, Font messageBoxTypeface,
                                              Image customImageIcon, bool? showHelpButton,
                                              Color? messageTextColour, Color[] buttonTextColours,
                                              DialogResult? buttonOneCustomDialogResult,
                                              DialogResult? buttonTwoCustomDialogResult,
                                              DialogResult? buttonThreeCustomDialogResult,
                                              DialogResult? buttonFourDialogResult,
                                              string buttonOneCustomText, string buttonTwoCustomText,
                                              string buttonThreeCustomText, string buttonFourCustomText,
                                              bool? showMoreDetailsUI, string moreDetailsText,
                                              string collapseText, string expandText,
                                              int? maximumMoreDetailsDropDownHeight,
                                              bool? showOptionalCheckBox,
                                              CheckState? optionalCheckBoxCheckState,
                                              bool? showOptionalLinkLabel,
                                              KryptonCommand linkCommand,
                                              string optionalCheckBoxText,
                                              string optionalLinkLabelText,
                                              string optionalLinkLabelURL)
        {
            IWin32Window showOwner = ValidateOptions(owner, options, helpInfo);

            using KryptonMessageBoxExtendedForm kmbef = new(showOwner, text, caption, buttons,
                                                            icon, defaultButton, options,
                                                            helpInfo, showCtrlCopy,
                                                            messageBoxTypeface,
                                                            customImageIcon, showHelpButton,
                                                            messageTextColour,
                                                            buttonTextColours,
                                                            buttonOneCustomDialogResult,
                                                            buttonTwoCustomDialogResult,
                                                            buttonThreeCustomDialogResult,
                                                            buttonFourDialogResult,
                                                            buttonOneCustomText,
                                                            buttonTwoCustomText,
                                                            buttonThreeCustomText,
                                                            buttonFourCustomText,
                                                            showMoreDetailsUI,
                                                            moreDetailsText,
                                                            collapseText,
                                                            expandText,
                                                            maximumMoreDetailsDropDownHeight,
                                                            showOptionalCheckBox,
                                                            optionalCheckBoxCheckState,
                                                            showOptionalLinkLabel,
                                                            linkCommand,
                                                            optionalCheckBoxText,
                                                            optionalLinkLabelText,
                                                            optionalLinkLabelURL);

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