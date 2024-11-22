﻿#region MIT License
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

using ContentAlignment = System.Drawing.ContentAlignment;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    /// <summary>Displays a message box that can contain text, buttons, and symbols that inform and instruct the user.</summary>
    [DesignerCategory(@"code"), ToolboxItem(false)]
    public static class KryptonMessageBoxExtended
    {
        #region Public

        /// <summary>Shows a <see cref="KryptonMessageBoxExtended"/>.</summary>
        /// <param name="message">The message.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <returns></returns>
        public static DialogResult Show(string message, string caption, ExtendedMessageBoxButtons buttons,
                                        ExtendedKryptonMessageBoxIcon icon, bool? showCtrlCopy = null)
            => ShowCore(null, message, caption, buttons, icon, KryptonMessageBoxDefaultButton.Button1,
                0, null, showCtrlCopy, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, ExtendedKryptonMessageBoxMessageContainerType.Normal,
                null, null, null, null,
                ContentAlignment.MiddleLeft, null, null, null, null, null,
                DialogResult.OK);

        /// <summary>Shows a <seealso cref="KryptonMessageBoxExtended"/>.</summary>
        /// <param name="messageText">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <param name="messageTextAlignment">Specifies how the message text should be aligned. See <see cref="System.Drawing.ContentAlignment"/> for supported values.</param>
        /// <param name="useTimeOut">Use the 'time out' facility, default value is false.</param>
        /// <param name="timeOut">Specifies the 'time out' time, default is 60.</param>
        /// <param name="timeOutInterval">Sets the interval of the 'time out' timer. Default is 1000.</param>
        /// <param name="timerResult">Specifies the <seealso cref="DialogResult"/> action to trigger, once the <seealso cref="KryptonMessageBoxExtended"/> has timed out.</param>
        public static DialogResult Show(string messageText, string caption, ExtendedMessageBoxButtons buttons,
            ExtendedKryptonMessageBoxIcon icon, bool? showCtrlCopy = null,
            ContentAlignment? messageTextAlignment = null,
            HorizontalAlignment? messageTextBoxAlignment = null,
            bool? useTimeOut = false, int? timeOut = 60, int? timeOutInterval = 1000,
            DialogResult? timerResult = DialogResult.None) =>
            ShowCore(null, messageText, caption, buttons, icon, KryptonMessageBoxDefaultButton.Button1,
                0, null, showCtrlCopy, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, ExtendedKryptonMessageBoxMessageContainerType.Normal,
                null, null, null, null,
                messageTextAlignment, null, messageTextBoxAlignment, useTimeOut, timeOut, timeOutInterval, timerResult);

        /// <summary>Shows a <seealso cref="KryptonMessageBoxExtended"/>.</summary>
        /// <param name="messageText">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <param name="applicationPath">The application path. To be used in conjunction with <see cref="ExtendedKryptonMessageBoxIcon.Application"/> type.</param>
        /// <param name="messageContainerType">Specifies a <see cref="T:ExtendedKryptonMessageBoxMessageContainerType"/> type.</param>
        /// <param name="linkLabelCommand">Specifies the <seealso cref="KryptonCommand"/> to attach to the embedded link.</param>
        /// <param name="contentLinkArea">Specifies the area within the <see cref="KryptonLinkWrapLabel"/> to be regarded as a link. See <see cref="LinkArea"/>.</param>
        /// <param name="linkLaunchArgument">Specifies what to launch when the link is clicked via <seealso cref="ProcessStartInfo"/>.</param>
        /// <param name="openInExplorer">If set to true, then this will launch Windows Explorer and select the file.</param>
        /// <param name="messageTextAlignment">Specifies how the message text should be aligned. See <see cref="System.Drawing.ContentAlignment"/> for supported values.</param>
        /// <param name="richTextBoxTextAlignment">Specifies how the message text should be aligned, when a <see cref="KryptonTextBox"/> is being used. See <see cref="PaletteRelativeAlign"/> for supported values.</param>
        /// <param name="messageTextBoxAlignment"></param>
        /// <param name="useTimeOut">Use the 'time out' facility, default value is false.</param>
        /// <param name="timeOut">Specifies the 'time out' time, default is 60.</param>
        /// <param name="timeOutInterval"></param>
        /// <param name="timerResult">Specifies the <seealso cref="DialogResult"/> action to trigger, once the <seealso cref="KryptonMessageBoxExtended"/> has timed out.</param>
        public static DialogResult Show(string messageText, string caption, ExtendedMessageBoxButtons buttons,
                                        ExtendedKryptonMessageBoxIcon icon, bool? showCtrlCopy = null,
                                        string? applicationPath = null,
                                        ExtendedKryptonMessageBoxMessageContainerType? messageContainerType =
                                            ExtendedKryptonMessageBoxMessageContainerType.Normal,
                                        KryptonCommand? linkLabelCommand = null,
                                        LinkArea? contentLinkArea = null,
                                        ProcessStartInfo? linkLaunchArgument = null, bool? openInExplorer = null,
                                        ContentAlignment? messageTextAlignment = null,
                                        PaletteRelativeAlign? richTextBoxTextAlignment = null,
                                        HorizontalAlignment? messageTextBoxAlignment = null,
                                        bool? useTimeOut = false, int? timeOut = 60, int? timeOutInterval = 1000,
                                        DialogResult? timerResult = DialogResult.None)
            => ShowCore(null, messageText, caption, buttons, icon, KryptonMessageBoxDefaultButton.Button1, 0,
                        null, showCtrlCopy, null, null, null, Color.Empty,
                        new[] { Color.Empty, Color.Empty, Color.Empty, Color.Empty },
                        null, null, null, null, string.Empty, string.Empty,
                        string.Empty, string.Empty, applicationPath, messageContainerType, linkLabelCommand,
                        contentLinkArea, linkLaunchArgument, openInExplorer, messageTextAlignment, richTextBoxTextAlignment, messageTextBoxAlignment,
                        useTimeOut, timeOut, timeOutInterval, timerResult);

        /// <summary>Shows a <seealso cref="KryptonMessageBoxExtended"/>.</summary>
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
        /// <param name="applicationPath">The application path. To be used in conjunction with <see cref="ExtendedKryptonMessageBoxIcon.Application"/> type.</param>
        /// <param name="messageContainerType">Specifies a <see cref="T:ExtendedKryptonMessageBoxMessageContainerType"/> type.</param>
        /// <param name="linkLabelCommand">Specifies the <seealso cref="KryptonCommand"/> to attach to the embedded link.</param>
        /// <param name="contentLinkArea">Specifies the area within the <see cref="KryptonLinkWrapLabel"/> to be regarded as a link. See <see cref="LinkArea"/>.</param>
        /// <param name="linkLaunchArgument">Specifies what to launch when the link is clicked via <seealso cref="ProcessStartInfo"/>.</param>
        /// <param name="openInExplorer">If set to true, then this will launch Windows Explorer and select the file.</param>
        /// <param name="messageTextAlignment">Specifies how the message text should be aligned. See <see cref="System.Drawing.ContentAlignment"/> for supported values.</param>
        /// <param name="richTextBoxTextAlignment">Specifies how the message text should be aligned, when a <see cref="KryptonTextBox"/> is being used. See <see cref="PaletteRelativeAlign"/> for supported values.</param>
        /// <param name="messageTextBoxAlignment"></param>
        /// <param name="useTimeOut">Use the 'time out' facility, default value is false.</param>
        /// <param name="timeOut">Specifies the 'time out' time, default is 60.</param>
        /// <param name="timeOutInterval"></param>
        /// <param name="timerResult">Specifies the <seealso cref="DialogResult"/> action to trigger, once the <seealso cref="KryptonMessageBoxExtended"/> has timed out.</param>
        public static DialogResult Show(string messageText, string caption = @"",
                                        ExtendedMessageBoxButtons buttons = ExtendedMessageBoxButtons.OK,
                                        ExtendedKryptonMessageBoxIcon icon = ExtendedKryptonMessageBoxIcon.None,
                                        KryptonMessageBoxDefaultButton defaultButton = KryptonMessageBoxDefaultButton.Button1,
                                        MessageBoxOptions options = 0,
                                        bool displayHelpButton = false,
                                        bool? showCtrlCopy = null,
                                        Font? messageBoxTypeface = null,
                                        Image? customImageIcon = null, string? applicationPath = null,
                                        ExtendedKryptonMessageBoxMessageContainerType? messageContainerType =
                                            ExtendedKryptonMessageBoxMessageContainerType.Normal,
                                        KryptonCommand? linkLabelCommand = null,
                                        LinkArea? contentLinkArea = null,
                                        ProcessStartInfo? linkLaunchArgument = null, bool? openInExplorer = null,
                                        ContentAlignment? messageTextAlignment =
                                            ContentAlignment.MiddleLeft,
                                        PaletteRelativeAlign? richTextBoxTextAlignment = null,
                                        HorizontalAlignment? messageTextBoxAlignment = null,
                                        bool? useTimeOut = false,
                                        int? timeOut = 60, int? timeOutInterval = 1000,
                                        DialogResult? timerResult = DialogResult.None)
            =>
                ShowCore(null, messageText, caption, buttons, icon, defaultButton, options,
                         displayHelpButton ? new HelpInfo() : null, showCtrlCopy,
                         messageBoxTypeface, customImageIcon, null, Color.Empty,
                         new[] { Color.Empty, Color.Empty, Color.Empty, Color.Empty },
                         null, null, null, null, string.Empty, string.Empty,
                         string.Empty, string.Empty, applicationPath,
                         messageContainerType, linkLabelCommand, contentLinkArea,
                         linkLaunchArgument, openInExplorer, messageTextAlignment, richTextBoxTextAlignment, messageTextBoxAlignment,
                         useTimeOut, timeOut, timeOutInterval, timerResult);

        /// <summary>Shows a <seealso cref="KryptonMessageBoxExtended"/>.</summary>
        /// <param name="messageText">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="displayHelpButton">if set to <c>true</c> [display help button].</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <param name="applicationPath">The application path. To be used in conjunction with <see cref="ExtendedKryptonMessageBoxIcon.Application"/> type.</param>
        /// <param name="messageContainerType">Specifies a <see cref="T:ExtendedKryptonMessageBoxMessageContainerType"/> type.</param>
        /// <param name="linkLabelCommand">Specifies the <seealso cref="KryptonCommand"/> to attach to the embedded link.</param>
        /// <param name="contentLinkArea">Specifies the area within the <see cref="KryptonLinkWrapLabel"/> to be regarded as a link. See <see cref="LinkArea"/>.</param>
        /// <param name="linkLaunchArgument">Specifies what to launch when the link is clicked via <seealso cref="ProcessStartInfo"/>.</param>
        /// <param name="openInExplorer">If set to true, then this will launch Windows Explorer and select the file.</param>
        /// <param name="messageTextAlignment">Specifies how the message text should be aligned. See <see cref="System.Drawing.ContentAlignment"/> for supported values.</param>
        /// <param name="richTextBoxTextAlignment">Specifies how the message text should be aligned, when a <see cref="KryptonTextBox"/> is being used. See <see cref="PaletteRelativeAlign"/> for supported values.</param>
        /// <param name="messageTextBoxAlignment"></param>
        /// <param name="useTimeOut">Use the 'time out' facility, default value is false.</param>
        /// <param name="timeOut">Specifies the 'time out' time, default is 60.</param>
        /// <param name="timeOutInterval"></param>
        /// <param name="timerResult">Specifies the <seealso cref="DialogResult"/> action to trigger, once the <seealso cref="KryptonMessageBoxExtended"/> has timed out.</param>
        public static DialogResult Show(string messageText, string caption,
                                        ExtendedMessageBoxButtons buttons,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        KryptonMessageBoxDefaultButton defaultButton = KryptonMessageBoxDefaultButton.Button1,
                                        MessageBoxOptions options = 0,
                                        bool displayHelpButton = false,
                                        bool? showCtrlCopy = null, string? applicationPath = null,
                                        ExtendedKryptonMessageBoxMessageContainerType? messageContainerType = ExtendedKryptonMessageBoxMessageContainerType.Normal,
                                        KryptonCommand? linkLabelCommand = null,
                                        LinkArea? contentLinkArea = null,
                                        ProcessStartInfo? linkLaunchArgument = null, bool? openInExplorer = null,
                                        ContentAlignment? messageTextAlignment = null,
                                        PaletteRelativeAlign? richTextBoxTextAlignment = null,
                                        HorizontalAlignment? messageTextBoxAlignment = null,
                                        bool? useTimeOut = false, int? timeOut = 60,
                                        int? timeOutInterval = 1000,
                                        DialogResult? timerResult = DialogResult.None)
            =>
                ShowCore(null, messageText, caption, buttons, icon, defaultButton, options,
                         displayHelpButton ? new HelpInfo() : null, showCtrlCopy,
                         null, null, null, Color.Empty,
                         new[] { Color.Empty, Color.Empty, Color.Empty, Color.Empty },
                         null, null, null, null, string.Empty, string.Empty,
                         string.Empty, string.Empty, applicationPath,
                         messageContainerType, linkLabelCommand, contentLinkArea, linkLaunchArgument, openInExplorer,
                         messageTextAlignment, richTextBoxTextAlignment, messageTextBoxAlignment,
                         useTimeOut, timeOut, timeOutInterval, timerResult);

        /// <summary>Shows a <seealso cref="KryptonMessageBoxExtended"/>.</summary>
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
        /// <param name="applicationPath">The application path. To be used in conjunction with <see cref="ExtendedKryptonMessageBoxIcon.Application"/> type.</param>
        /// <param name="messageContainerType">Specifies a <see cref="T:ExtendedKryptonMessageBoxMessageContainerType"/> type.</param>
        /// <param name="linkLabelCommand">Specifies the <seealso cref="KryptonCommand"/> to attach to the embedded link.</param>
        /// <param name="contentLinkArea">Specifies the area within the <see cref="KryptonLinkWrapLabel"/> to be regarded as a link. See <see cref="LinkArea"/>.</param>
        /// <param name="linkLaunchArgument">Specifies what to launch when the link is clicked via <seealso cref="ProcessStartInfo"/>.</param>
        /// <param name="openInExplorer">If set to true, then this will launch Windows Explorer and select the file.</param>
        /// <param name="messageTextAlignment">Specifies how the message text should be aligned. See <see cref="System.Drawing.ContentAlignment"/> for supported values.</param>
        /// <param name="richTextBoxTextAlignment">Specifies how the message text should be aligned, when a <see cref="KryptonTextBox"/> is being used. See <see cref="PaletteRelativeAlign"/> for supported values.</param>
        /// <param name="messageTextBoxAlignment"></param>
        /// <param name="useTimeOut">Use the 'time out' facility, default value is false.</param>
        /// <param name="timeOut">Specifies the 'time out' time, default is 60.</param>
        /// <param name="timeOutInterval"></param>
        /// <param name="timerResult">Specifies the <seealso cref="DialogResult"/> action to trigger, once the <seealso cref="KryptonMessageBoxExtended"/> has timed out.</param>
        public static DialogResult Show(IWin32Window owner, string messageText, string caption = @"",
                                        ExtendedMessageBoxButtons buttons = ExtendedMessageBoxButtons.OK,
                                        ExtendedKryptonMessageBoxIcon icon = ExtendedKryptonMessageBoxIcon.None,
                                        KryptonMessageBoxDefaultButton defaultButton = KryptonMessageBoxDefaultButton.Button1,
                                        MessageBoxOptions options = 0,
                                        bool displayHelpButton = false,
                                        bool? showCtrlCopy = null,
                                        Font? messageBoxTypeface = null,
                                        Image? customImageIcon = null, string? applicationPath = null,
                                        ExtendedKryptonMessageBoxMessageContainerType? messageContainerType = ExtendedKryptonMessageBoxMessageContainerType.Normal,
                                        KryptonCommand? linkLabelCommand = null,
                                        LinkArea? contentLinkArea = null,
                                        ProcessStartInfo? linkLaunchArgument = null, bool? openInExplorer = null,
                                        ContentAlignment? messageTextAlignment = null,
                                        PaletteRelativeAlign? richTextBoxTextAlignment = null,
                                        HorizontalAlignment? messageTextBoxAlignment = null,
                                        bool? useTimeOut = false,
                                        int? timeOut = 60, int? timeOutInterval = 1000,
                                        DialogResult? timerResult = DialogResult.None)
            =>
                ShowCore(owner, messageText, caption, buttons, icon, defaultButton, options,
                         displayHelpButton ? new HelpInfo() : null, showCtrlCopy,
                         messageBoxTypeface, customImageIcon, null, Color.Empty,
                         new[] { Color.Empty, Color.Empty, Color.Empty, Color.Empty },
                         null, null, null, null,
                         string.Empty,
                         string.Empty, string.Empty, string.Empty,
                         applicationPath, messageContainerType, linkLabelCommand, contentLinkArea,
                         linkLaunchArgument, openInExplorer,
                         messageTextAlignment, richTextBoxTextAlignment, messageTextBoxAlignment,
                         useTimeOut, timeOut, timeOutInterval, timerResult);

        public static DialogResult Show(IWin32Window owner, string message, string caption,
            ExtendedMessageBoxButtons buttons, ExtendedKryptonMessageBoxIcon icon,
            KryptonMessageBoxDefaultButton defaultButton, MessageBoxOptions options, bool? showCtrlCopy = false) =>
            ShowCore(owner, message, caption, buttons, icon, defaultButton, options,
                null, showCtrlCopy, null, null, null,
                null, null, null,
                null, null, null,
                null, null, null,
                null, null, null,
                null, null, null,
                null, null, null,
                null, null, null, null,
                null);

        public static DialogResult Show(string message, string caption, ExtendedMessageBoxButtons buttons, ExtendedKryptonMessageBoxIcon icon, KryptonMessageBoxDefaultButton defaultButton, MessageBoxOptions options, bool? showCtrlCopy = false) =>
            ShowCore(null, message, caption, buttons, icon, defaultButton, options,
                null, showCtrlCopy, null, null, null,
                null, null, null,
                null, null, null,
                null, null, null,
                null, null, null,
                null, null, null,
                null, null, null,
                null, null, null, null,
                null);

        /// <summary>Shows a <seealso cref="KryptonMessageBoxExtended"/>.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="messageText">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="displayHelpButton">if set to <c>true</c> [display help button].</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <param name="applicationPath">The application path. To be used in conjunction with <see cref="ExtendedKryptonMessageBoxIcon.Application"/> type.</param>
        /// <param name="messageContainerType">Specifies a <see cref="T:ExtendedKryptonMessageBoxMessageContainerType"/> type.</param>
        /// <param name="linkLabelCommand">Specifies the <seealso cref="KryptonCommand"/> to attach to the embedded link.</param>
        /// <param name="contentLinkArea">Specifies the area within the <see cref="KryptonLinkWrapLabel"/> to be regarded as a link. See <see cref="LinkArea"/>.</param>
        /// <param name="linkLaunchArgument">Specifies what to launch when the link is clicked via <seealso cref="ProcessStartInfo"/>.</param>
        /// <param name="openInExplorer">If set to true, then this will launch Windows Explorer and select the file.</param>
        /// <param name="messageTextAlignment">Specifies how the message text should be aligned. See <see cref="System.Drawing.ContentAlignment"/> for supported values.</param>
        /// <param name="richTextBoxTextAlignment">Specifies how the message text should be aligned, when a <see cref="KryptonTextBox"/> is being used. See <see cref="PaletteRelativeAlign"/> for supported values.</param>
        /// <param name="messageTextBoxAlignment"></param>
        /// <param name="useTimeOut">Use the 'time out' facility, default value is false.</param>
        /// <param name="timeOut">Specifies the 'time out' time, default is 60.</param>
        /// <param name="timeOutInterval"></param>
        /// <param name="timerResult">Specifies the <seealso cref="DialogResult"/> action to trigger, once the <seealso cref="KryptonMessageBoxExtended"/> has timed out.</param>
        public static DialogResult Show(IWin32Window owner, string messageText, string caption,
                                        ExtendedMessageBoxButtons buttons,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        KryptonMessageBoxDefaultButton defaultButton = KryptonMessageBoxDefaultButton.Button1,
                                        MessageBoxOptions options = 0,
                                        bool displayHelpButton = false,
                                        bool? showCtrlCopy = null,
                                        string? applicationPath = null,
                                        ExtendedKryptonMessageBoxMessageContainerType? messageContainerType = ExtendedKryptonMessageBoxMessageContainerType.Normal,
                                        KryptonCommand? linkLabelCommand = null,
                                        LinkArea? contentLinkArea = null,
                                        ProcessStartInfo? linkLaunchArgument = null, bool? openInExplorer = null,
                                        ContentAlignment? messageTextAlignment = null,
                                        PaletteRelativeAlign? richTextBoxTextAlignment = null,
                                        HorizontalAlignment? messageTextBoxAlignment = null,
                                        bool? useTimeOut = false,
                                        int? timeOut = 60, int? timeOutInterval = 1000,
                                        DialogResult? timerResult = DialogResult.None)
            =>
                ShowCore(owner, messageText, caption, buttons, icon, defaultButton, options,
                         displayHelpButton ? new HelpInfo() : null, showCtrlCopy,
                         null, null, null, Color.Empty,
                         new[] { Color.Empty, Color.Empty, Color.Empty, Color.Empty },
                         null, null, null,
                         null, string.Empty,
                         string.Empty, string.Empty,
                         string.Empty, applicationPath,
                         messageContainerType, linkLabelCommand, contentLinkArea,
                         linkLaunchArgument,
                         openInExplorer, messageTextAlignment,
                         richTextBoxTextAlignment, messageTextBoxAlignment,
                         useTimeOut, timeOut, timeOutInterval, timerResult);

        /// <summary>Shows a <seealso cref="KryptonMessageBoxExtended"/>.</summary>
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
        /// <param name="applicationPath">The application path. To be used in conjunction with <see cref="ExtendedKryptonMessageBoxIcon.Application"/> type.</param>
        /// <param name="messageContainerType">Specifies a <see cref="T:ExtendedKryptonMessageBoxMessageContainerType"/> type.</param>
        /// <param name="linkLabelCommand">Specifies the <seealso cref="KryptonCommand"/> to attach to the embedded link.</param>
        /// <param name="contentLinkArea">Specifies the area within the <see cref="KryptonLinkWrapLabel"/> to be regarded as a link. See <see cref="LinkArea"/>.</param>
        /// <param name="linkLaunchArgument">Specifies what to launch when the link is clicked via <seealso cref="ProcessStartInfo"/>.</param>
        /// <param name="openInExplorer">If set to true, then this will launch Windows Explorer and select the file.</param>
        /// <param name="messageTextAlignment">Specifies how the message text should be aligned. See <see cref="System.Drawing.ContentAlignment"/> for supported values.</param>
        /// <param name="richTextBoxTextAlignment">Specifies how the message text should be aligned, when a <see cref="KryptonTextBox"/> is being used. See <see cref="PaletteRelativeAlign"/> for supported values.</param>
        /// <param name="messageTextBoxAlignment"></param>
        /// <param name="useTimeOut">Use the 'time out' facility, default value is false.</param>
        /// <param name="timeOut">Specifies the 'time out' time, default is 60.</param>
        /// <param name="timeOutInterval"></param>
        /// <param name="timerResult">Specifies the <seealso cref="DialogResult"/> action to trigger, once the <seealso cref="KryptonMessageBoxExtended"/> has timed out.</param>
        public static DialogResult Show(string messageText, string caption = @"",
                                        ExtendedMessageBoxButtons buttons = ExtendedMessageBoxButtons.OK,
                                        ExtendedKryptonMessageBoxIcon icon = ExtendedKryptonMessageBoxIcon.None,
                                        KryptonMessageBoxDefaultButton defaultButton = KryptonMessageBoxDefaultButton.Button1,
                                        MessageBoxOptions options = 0,
                                        string helpFilePath = @"",
                                        HelpNavigator navigator = 0,
                                        object? param = null,
                                        bool? showCtrlCopy = null,
                                        Font? messageBoxTypeface = null,
                                        Image? customImageIcon = null,
                                        string? applicationPath = null,
                                        ExtendedKryptonMessageBoxMessageContainerType? messageContainerType = ExtendedKryptonMessageBoxMessageContainerType.Normal,
                                        KryptonCommand? linkLabelCommand = null,
                                        LinkArea? contentLinkArea = null,
                                        ProcessStartInfo? linkLaunchArgument = null,
                                        bool? openInExplorer = null, ContentAlignment? messageTextAlignment = null,
                                        PaletteRelativeAlign? richTextBoxTextAlignment = null,
                                        HorizontalAlignment? messageTextBoxAlignment = null,
                                        bool? useTimeOut = false,
                                        int? timeOut = 60, int? timeOutInterval = 1000,
                                        DialogResult? timerResult = DialogResult.None)
            =>
                ShowCore(null, messageText, caption, buttons, icon, defaultButton, options,
                         new HelpInfo(helpFilePath, navigator, param), showCtrlCopy,
                         messageBoxTypeface, customImageIcon, null, Color.Empty,
                         new[] { Color.Empty, Color.Empty, Color.Empty, Color.Empty },
                         null, null, null, null,
                         string.Empty,
                         string.Empty, string.Empty,
                         string.Empty, applicationPath,
                         messageContainerType, linkLabelCommand, contentLinkArea,
                         linkLaunchArgument, openInExplorer, messageTextAlignment, richTextBoxTextAlignment, messageTextBoxAlignment,
                         useTimeOut, timeOut, timeOutInterval, timerResult);

        /// <summary>Shows a message box.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="messageText">The message text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="helpFilePath">The help file path.</param>
        /// <param name="navigator">The navigator.</param>
        /// <param name="param">The parameter.</param>
        /// <param name="displayHelpButton">if set to <c>true</c> [display help button].</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <param name="messageBoxTypeface">The message box typeface.</param>
        /// <param name="customImageIcon">The custom image icon.</param>
        /// <param name="showHelpButton">The show help button.</param>
        /// <param name="messageTextColor">The message text colour.</param>
        /// <param name="buttonTextColors">The button text colours.</param>
        /// <param name="buttonOneCustomDialogResult">The button one custom dialog result.</param>
        /// <param name="buttonTwoCustomDialogResult">The button two custom dialog result.</param>
        /// <param name="buttonThreeCustomDialogResult">The button three custom dialog result.</param>
        /// <param name="buttonFourDialogResult">The button four dialog result.</param>
        /// <param name="buttonOneCustomText">The button one custom text.</param>
        /// <param name="buttonTwoCustomText">The button two custom text.</param>
        /// <param name="buttonThreeCustomText">The button three custom text.</param>
        /// <param name="buttonFourCustomText">The button four custom text.</param>
        /// <param name="applicationPath">The application path. To be used in conjunction with <see cref="ExtendedKryptonMessageBoxIcon.Application"/> type.</param>
        /// <param name="messageContainerType">Specifies a <see cref="T:ExtendedKryptonMessageBoxMessageContainerType"/> type.</param>
        /// <param name="linkLabelCommand">Specifies the <seealso cref="KryptonCommand"/> to attach to the embedded link.</param>
        /// <param name="contentLinkArea">Specifies the area within the <see cref="KryptonLinkWrapLabel"/> to be regarded as a link. See <see cref="LinkArea"/>.</param>
        /// <param name="linkLaunchArgument">Specifies what to launch when the link is clicked via <seealso cref="ProcessStartInfo"/>.</param>
        /// <param name="openInExplorer">If set to true, then this will launch Windows Explorer and select the file.</param>
        /// <param name="messageTextAlignment">Specifies how the message text should be aligned. See <see cref="System.Drawing.ContentAlignment"/> for supported values.</param>
        /// <param name="richTextBoxTextAlignment">Specifies how the message text should be aligned, when a <see cref="KryptonTextBox"/> is being used. See <see cref="PaletteRelativeAlign"/> for supported values.</param>
        /// <param name="messageTextBoxAlignment"></param>
        /// <param name="useTimeOut">Use the 'time out' facility, default value is false.</param>
        /// <param name="timeOut">Specifies the 'time out' time, default is 60.</param>
        /// <param name="timeOutInterval"></param>
        /// <param name="timerResult">Specifies the <seealso cref="DialogResult"/> action to trigger, once the <seealso cref="KryptonMessageBoxExtended"/> has timed out.</param>
        public static DialogResult Show(IWin32Window owner, string messageText, string caption = @"",
                                        ExtendedMessageBoxButtons buttons = ExtendedMessageBoxButtons.OK,
                                        ExtendedKryptonMessageBoxIcon icon = ExtendedKryptonMessageBoxIcon.None,
                                        KryptonMessageBoxDefaultButton defaultButton = KryptonMessageBoxDefaultButton.Button1,
                                        MessageBoxOptions options = 0,
                                        string helpFilePath = @"",
                                        HelpNavigator navigator = 0,
                                        object? param = null,
                                        bool displayHelpButton = false,
                                        bool? showCtrlCopy = null,
                                        Font? messageBoxTypeface = null,
                                        Image? customImageIcon = null,
                                        bool? showHelpButton = null,
                                        Color? messageTextColor = null,
                                        Color[]? buttonTextColors = null,
                                        DialogResult? buttonOneCustomDialogResult = null,
                                        DialogResult? buttonTwoCustomDialogResult = null,
                                        DialogResult? buttonThreeCustomDialogResult = null,
                                        DialogResult? buttonFourDialogResult = null,
                                        string? buttonOneCustomText = null,
                                        string? buttonTwoCustomText = null,
                                        string? buttonThreeCustomText = null,
                                        string? buttonFourCustomText = null,
                                        string? applicationPath = null,
                                        ExtendedKryptonMessageBoxMessageContainerType? messageContainerType = ExtendedKryptonMessageBoxMessageContainerType.Normal,
                                        KryptonCommand? linkLabelCommand = null,
                                        LinkArea? contentLinkArea = null,
                                        ProcessStartInfo? linkLaunchArgument = null,
                                        bool? openInExplorer = null,
                                        ContentAlignment? messageTextAlignment = null,
                                        PaletteRelativeAlign? richTextBoxTextAlignment = null,
                                        HorizontalAlignment? messageTextBoxAlignment = null,
                                        bool? useTimeOut = false,
                                        int? timeOut = 60,
                                        int? timeOutInterval = 1000,
                                        DialogResult? timerResult = DialogResult.None)
            =>
                ShowCore(owner, messageText, caption, buttons, icon, defaultButton, options,
                         displayHelpButton ? new HelpInfo(helpFilePath, navigator, param) : null,
                         showCtrlCopy, messageBoxTypeface, customImageIcon,
                         showHelpButton, messageTextColor, buttonTextColors, buttonOneCustomDialogResult,
                         buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
                         buttonFourDialogResult, buttonOneCustomText, buttonTwoCustomText,
                         buttonThreeCustomText, buttonFourCustomText, applicationPath,
                         messageContainerType, linkLabelCommand, contentLinkArea, linkLaunchArgument,
                         openInExplorer, messageTextAlignment,
                         richTextBoxTextAlignment, messageTextBoxAlignment,
                         useTimeOut, timeOut, timeOutInterval, timerResult);

        public static DialogResult Show(KryptonMessageBoxExtendedData messageBoxExtendedData) =>
            ShowCore(messageBoxExtendedData);

        #endregion

        #region Implementation

        internal static bool ShowCoreWithBoolResult(IWin32Window? owner, string text, string caption,
            ExtendedMessageBoxButtons buttons,
            ExtendedKryptonMessageBoxIcon icon,
            KryptonMessageBoxDefaultButton defaultButton,
            MessageBoxOptions options, HelpInfo? helpInfo,
            bool? showCtrlCopy, Font? messageBoxTypeface,
            Image? customImageIcon, bool? showHelpButton,
            Color? messageTextColour, Color[]? buttonTextColours,
            DialogResult? buttonOneCustomDialogResult,
            DialogResult? buttonTwoCustomDialogResult,
            DialogResult? buttonThreeCustomDialogResult,
            DialogResult? buttonFourDialogResult,
            string? buttonOneCustomText, string? buttonTwoCustomText,
            string? buttonThreeCustomText, string? buttonFourCustomText,
            string? applicationPath,
            ExtendedKryptonMessageBoxMessageContainerType? messageContainerType,
            KryptonCommand? linkLabelCommand,
            LinkArea? contentLinkArea,
            ProcessStartInfo? linkLaunchArgument,
            bool? openInExplorer,
            ContentAlignment? messageTextAlignment,
            PaletteRelativeAlign? richTextBoxTextAlignment,
            HorizontalAlignment? messageTextBoxAlignment,
            bool? showOptionalCheckBox,
            bool? initialDoNotShowAgainCheckBoxChecked,
            CheckState? initialDoNotShowAgainCheckBoxCheckState,
            string? optionalCheckBoxText,
            bool? useOptionalCheckBoxThreeState,
            bool? useTimeOut,
            int? timeOut,
            int? timeOutInterval,
            DialogResult? timerResult)
        {
            IWin32Window? showOwner = ValidateOptions(owner, options, helpInfo);

            if (options == MessageBoxOptions.RightAlign | options == MessageBoxOptions.RtlReading)
            {
                using var kmbertl = new VisualMessageBoxExtendedRtlAwareForm(showOwner, text,
                    caption, buttons,
                    icon, defaultButton,
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
                    applicationPath,
                    messageContainerType,
                    linkLabelCommand,
                    contentLinkArea,
                    linkLaunchArgument,
                    openInExplorer,
                    messageTextAlignment,
                    richTextBoxTextAlignment,
                    messageTextBoxAlignment,
                    showOptionalCheckBox,
                    initialDoNotShowAgainCheckBoxChecked,
                    optionalCheckBoxText,
                    useOptionalCheckBoxThreeState,
                    useTimeOut,
                    timeOut,
                    timerResult);

                return true;
            }
            else
            {
                using var kmbe = new VisualMessageBoxExtendedForm(
                    showOwner,
                    text,
                    caption,
                    buttons,
                    icon, defaultButton, helpInfo,
                    showCtrlCopy, messageBoxTypeface,
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
                    applicationPath,
                    messageContainerType,
                    linkLabelCommand,
                    contentLinkArea,
                    linkLaunchArgument,
                    openInExplorer,
                    messageTextAlignment,
                    richTextBoxTextAlignment,
                    messageTextBoxAlignment,
                    showOptionalCheckBox,
                    initialDoNotShowAgainCheckBoxChecked,
                    initialDoNotShowAgainCheckBoxCheckState,
                    optionalCheckBoxText,
                    useOptionalCheckBoxThreeState,
                    useTimeOut,
                    timeOut,
                    timeOutInterval,
                    timerResult);

                kmbe.Show();

                return kmbe.GetDoNotShowAgainChecked();
            }
        }

        /// <summary>Shows the core with check state result.</summary>
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
        /// <param name="applicationPath">The application path.</param>
        /// <param name="messageContainerType">Type of the message container.</param>
        /// <param name="linkLabelCommand">The link label command.</param>
        /// <param name="contentLinkArea">The content link area.</param>
        /// <param name="linkLaunchArgument">The link launch argument.</param>
        /// <param name="openInExplorer">The open in explorer.</param>
        /// <param name="messageTextAlignment">The message text alignment.</param>
        /// <param name="richTextBoxTextAlignment">The rich text box text alignment.</param>
        /// <param name="messageTextBoxAlignment"></param>
        /// <param name="showOptionalCheckBox">The show optional CheckBox.</param>
        /// <param name="initialDoNotShowAgainCheckBoxChecked">The initial do not show again CheckBox checked.</param>
        /// <param name="initialDoNotShowAgainCheckBoxCheckState">Initial state of the do not show again CheckBox check.</param>
        /// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
        /// <param name="useOptionalCheckBoxThreeState">State of the use optional CheckBox three.</param>
        /// <param name="useTimeOut">The use time out.</param>
        /// <param name="timeOut">The time out.</param>
        /// <param name="timeOutInterval">The time out interval.</param>
        /// <param name="timerResult">The timer result.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        internal static CheckState ShowCoreWithCheckStateResult(IWin32Window? owner, string text, string caption,
            ExtendedMessageBoxButtons buttons,
            ExtendedKryptonMessageBoxIcon icon,
            KryptonMessageBoxDefaultButton defaultButton,
            MessageBoxOptions options, HelpInfo? helpInfo,
            bool? showCtrlCopy, Font? messageBoxTypeface,
            Image? customImageIcon, bool? showHelpButton,
            Color? messageTextColour, Color[]? buttonTextColours,
            DialogResult? buttonOneCustomDialogResult,
            DialogResult? buttonTwoCustomDialogResult,
            DialogResult? buttonThreeCustomDialogResult,
            DialogResult? buttonFourDialogResult,
            string? buttonOneCustomText, string? buttonTwoCustomText,
            string? buttonThreeCustomText, string? buttonFourCustomText,
            string? applicationPath,
            ExtendedKryptonMessageBoxMessageContainerType? messageContainerType,
            KryptonCommand? linkLabelCommand,
            LinkArea? contentLinkArea,
            ProcessStartInfo? linkLaunchArgument,
            bool? openInExplorer,
            ContentAlignment? messageTextAlignment,
            PaletteRelativeAlign? richTextBoxTextAlignment,
            HorizontalAlignment? messageTextBoxAlignment,
            bool? showOptionalCheckBox,
            bool? initialDoNotShowAgainCheckBoxChecked,
            CheckState? initialDoNotShowAgainCheckBoxCheckState,
            string? optionalCheckBoxText,
            bool? useOptionalCheckBoxThreeState,
            bool? useTimeOut,
            int? timeOut,
            int? timeOutInterval,
            DialogResult? timerResult)
        {
            IWin32Window? showOwner = ValidateOptions(owner, options, helpInfo);

            if (options == MessageBoxOptions.RightAlign | options == MessageBoxOptions.RtlReading)
            {
                using var kmbertl = new VisualMessageBoxExtendedRtlAwareForm(showOwner, text,
                    caption, buttons,
                    icon, defaultButton,
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
                    applicationPath,
                    messageContainerType,
                    linkLabelCommand,
                    contentLinkArea,
                    linkLaunchArgument,
                    openInExplorer,
                    messageTextAlignment,
                    richTextBoxTextAlignment,
                    messageTextBoxAlignment,
                    showOptionalCheckBox,
                    initialDoNotShowAgainCheckBoxChecked,
                    optionalCheckBoxText,
                    useOptionalCheckBoxThreeState,
                    useTimeOut,
                    timeOut,
                    timerResult);

                return CheckState.Unchecked;
            }
            else
            {
                using var kmbe = new VisualMessageBoxExtendedForm(
                    showOwner,
                    text,
                    caption,
                    buttons,
                    icon, defaultButton, helpInfo,
                    showCtrlCopy, messageBoxTypeface,
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
                    applicationPath,
                    messageContainerType,
                    linkLabelCommand,
                    contentLinkArea,
                    linkLaunchArgument,
                    openInExplorer,
                    messageTextAlignment,
                    richTextBoxTextAlignment,
                    messageTextBoxAlignment,
                    showOptionalCheckBox,
                    initialDoNotShowAgainCheckBoxChecked,
                    initialDoNotShowAgainCheckBoxCheckState,
                    optionalCheckBoxText,
                    useOptionalCheckBoxThreeState,
                    useTimeOut,
                    timeOut,
                    timeOutInterval,
                    timerResult);

                kmbe.Show();

                return kmbe.GetDoNotShowAgainCheckState();
            }
        }

        /// <summary>Shows the message box.</summary>
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
        /// <param name="applicationPath">The application path. To be used in conjunction with <see cref="ExtendedKryptonMessageBoxIcon.Application"/> type.</param>
        /// <param name="messageContainerType">Specifies a <see cref="T:ExtendedKryptonMessageBoxMessageContainerType"/> type.</param>
        /// <param name="linkLabelCommand">Specifies the <seealso cref="KryptonCommand"/> to attach to the embedded link.</param>
        /// <param name="contentLinkArea">Specifies the area within the <see cref="KryptonLinkWrapLabel"/> to be regarded as a link. See <see cref="LinkArea"/>.</param>
        /// <param name="linkLaunchArgument">Specifies what to launch when the link is clicked via <seealso cref="ProcessStartInfo"/>.</param>
        /// <param name="openInExplorer">If set to true, then this will launch Windows Explorer and select the file.</param>
        /// <param name="messageTextAlignment">Specifies how the message text should be aligned. See <see cref="System.Drawing.ContentAlignment"/> for supported values.</param>
        /// <param name="richTextBoxTextAlignment">Specifies how the message text should be aligned, when a <see cref="KryptonTextBox"/> is being used. See <see cref="PaletteRelativeAlign"/> for supported values.</param>
        /// <param name="messageTextBoxAlignment"></param>
        /// <param name="useTimeOut">Use the 'time out' facility, default value is false.</param>
        /// <param name="timeOut">Specifies the 'time out' time, default is 60.</param>
        /// <param name="timeOutInterval">Sets the interval of the 'time out' timer.</param>
        /// <param name="timerResult">Specifies the <seealso cref="DialogResult"/> action to trigger, once the <seealso cref="KryptonMessageBoxExtended"/> has timed out.</param>
        /// <returns>One of the <see cref="DialogResult"/> values.</returns>
        internal static DialogResult ShowCore(IWin32Window? owner, string text, string caption,
                                              ExtendedMessageBoxButtons buttons,
                                              ExtendedKryptonMessageBoxIcon icon,
                                              KryptonMessageBoxDefaultButton defaultButton,
                                              MessageBoxOptions options, HelpInfo? helpInfo,
                                              bool? showCtrlCopy, Font? messageBoxTypeface,
                                              Image? customImageIcon, bool? showHelpButton,
                                              Color? messageTextColour, Color[]? buttonTextColours,
                                              DialogResult? buttonOneCustomDialogResult,
                                              DialogResult? buttonTwoCustomDialogResult,
                                              DialogResult? buttonThreeCustomDialogResult,
                                              DialogResult? buttonFourDialogResult,
                                              string? buttonOneCustomText, string? buttonTwoCustomText,
                                              string? buttonThreeCustomText, string? buttonFourCustomText,
                                              string? applicationPath,
                                              ExtendedKryptonMessageBoxMessageContainerType? messageContainerType,
                                              KryptonCommand? linkLabelCommand,
                                              LinkArea? contentLinkArea,
                                              ProcessStartInfo? linkLaunchArgument,
                                              bool? openInExplorer,
                                              ContentAlignment? messageTextAlignment,
                                              PaletteRelativeAlign? richTextBoxTextAlignment,
                                              HorizontalAlignment? messageTextBoxAlignment,
                                              bool? useTimeOut,
                                              int? timeOut,
                                              int? timeOutInterval,
                                              DialogResult? timerResult)
        {
            IWin32Window? showOwner = ValidateOptions(owner, options, helpInfo);

            if (options == MessageBoxOptions.RightAlign | options == MessageBoxOptions.RtlReading)
            {
                using var kmbertl = new VisualMessageBoxExtendedRtlAwareForm(showOwner, text,
                    caption, buttons,
                    icon, defaultButton,
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
                    applicationPath,
                    messageContainerType,
                    linkLabelCommand,
                    contentLinkArea,
                    linkLaunchArgument,
                    openInExplorer,
                    messageTextAlignment,
                    richTextBoxTextAlignment,
                    messageTextBoxAlignment,
                    null,
                    null,
                    null,
                    null,
                    useTimeOut,
                    timeOut,
                    timerResult);

                return kmbertl.ShowDialog(showOwner);
            }
            else
            {
                using var kmbe = new VisualMessageBoxExtendedForm(
                    showOwner,
                    text,
                    caption,
                    buttons,
                    icon, defaultButton, helpInfo,
                    showCtrlCopy, messageBoxTypeface,
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
                    applicationPath,
                    messageContainerType,
                    linkLabelCommand,
                    contentLinkArea,
                    linkLaunchArgument,
                    openInExplorer,
                    messageTextAlignment,
                    richTextBoxTextAlignment,
                    messageTextBoxAlignment,
                    null,
                    null,
                    null,
                    null,
                    null,
                    useTimeOut,
                    timeOut,
                    timeOutInterval,
                    timerResult);

                return kmbe.ShowDialog(showOwner);
            }
        }

        internal static DialogResult ShowCore(KryptonMessageBoxExtendedData messageBoxExtendedData)
        {
            IWin32Window? showOwner = ValidateOptions(messageBoxExtendedData.Owner, messageBoxExtendedData.Options,
                messageBoxExtendedData.HelpInfo);

            if (messageBoxExtendedData.Options == MessageBoxOptions.RightAlign | messageBoxExtendedData.Options == MessageBoxOptions.RtlReading)
            {
                using var kmbertl = new VisualMessageBoxExtendedRtlAwareForm(messageBoxExtendedData);

                return kmbertl.ShowDialog(showOwner);
            }
            else
            {
                using var kmbe = new VisualMessageBoxExtendedForm(messageBoxExtendedData);

                return kmbe.ShowDialog(showOwner);
            }
        }
        #endregion

        #region WinForm Compatibility
        private static IWin32Window? ValidateOptions(IWin32Window? owner, MessageBoxOptions options, HelpInfo? helpInfo)
        {
            // Check if trying to show a message box from a non-interactive process, this is not possible
            if (!SystemInformation.UserInteractive &&
                (options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) == 0)
            {
                throw new InvalidOperationException("Cannot show modal dialog when non-interactive");
            }

            // Check if trying to show a message box from a service and the owner has been specified, this is not possible
            if (owner != null &&
                (options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) != 0)
            {
                throw new ArgumentException(@"Cannot show message box from a service with an owner specified", nameof(options));
            }

            // Check if trying to show a message box from a service and help information is specified, this is not possible
            if (helpInfo != null &&
                (options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) != 0)
            {
                throw new ArgumentException(@"Cannot show message box from a service with help specified", nameof(options));
            }

            IWin32Window? showOwner = null;
            if (helpInfo != null ||
                (options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) == 0)
            {
                // If do not have an owner passed in then get the active window and use that instead
                showOwner = owner ?? Control.FromHandle(PlatformInvoke.GetActiveWindow());
            }

            return showOwner;
        }
        #endregion
    }
}