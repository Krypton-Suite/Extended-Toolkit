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

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    public struct KryptonMessageBoxExtendedData
    {
        #region Public

        #region Base

        /// <summary>Gets or sets the owner window.</summary>
        /// <value>The owner window.</value>
        public IWin32Window? Owner { get; set; }

        /// <summary>Gets or sets the message text.</summary>
        /// <value>The message text.</value>
        public string? MessageText { get; set; }

        /// <summary>Gets or sets the window caption.</summary>
        /// <value>The window caption.</value>
        public string Caption { get; set; }

        /// <summary>Gets or sets the buttons.</summary>
        /// <value>The buttons.</value>
        public ExtendedMessageBoxButtons Buttons { get; set; }

        /// <summary>Gets or sets the icon.</summary>
        /// <value>The icon.</value>
        public ExtendedKryptonMessageBoxIcon Icon { get; set; }

        /// <summary>Gets or sets the default button.</summary>
        /// <value>The default button.</value>
        public KryptonMessageBoxDefaultButton? DefaultButton { get; set; }

        /// <summary>Gets or sets the <see cref="MessageBoxOptions"/>.</summary>
        /// <value>The <see cref="MessageBoxOptions"/>.</value>
        public MessageBoxOptions Options { get; set; }

        /// <summary>Gets or sets the help information.</summary>
        /// <value>The help information.</value>
        public HelpInfo? HelpInfo { get; set; }

        /// <summary>Gets or sets the show control copy.</summary>
        /// <value>The show control copy.</value>
        public bool? ShowCtrlCopy { get; set; }

        /// <summary>Gets or sets the show help button.</summary>
        /// <value>The show help button.</value>
        public bool? ShowHelpButton { get; set; }

        /// <summary>Gets or sets the show action button.</summary>
        /// <value>The show action button.</value>
        public bool? ShowActionButton { get; set; }

        /// <summary>Gets or sets the action button text.</summary>
        /// <value>The action button text.</value>
        public string? ActionButtonText { get; set; }

        /// <summary>Gets or sets the action button command.</summary>
        /// <value>The action button command.</value>
        public KryptonCommand? ActionButtonCommand { get; set; }

        /// <summary>Gets or sets the application image.</summary>
        /// <value>The application image.</value>
        public Image? ApplicationImage { get; set; }

        /// <summary>Gets or sets the application path.</summary>
        /// <value>The application path.</value>
        public string? ApplicationPath { get; set; }

        /// <summary>Gets or sets the type of the message content area.</summary>
        /// <value>The type of the message content area.</value>
        public ExtendedKryptonMessageBoxMessageContainerType? MessageContentAreaType { get; set; }

        /// <summary>Gets or sets the link label command.</summary>
        /// <value>The link label command.</value>
        public KryptonCommand? LinkLabelCommand { get; set; }

        /// <summary>Gets or sets the link launch argument.</summary>
        /// <value>The link launch argument.</value>
        public ProcessStartInfo? LinkLaunchArgument { get; set; }

        /// <summary>Gets or sets the content link area.</summary>
        /// <value>The content link area.</value>
        public LinkArea? ContentLinkArea { get; set; }

        /// <summary>Gets or sets the message text alignment.</summary>
        /// <value>The message text alignment.</value>
        public ContentAlignment? MessageTextAlignment { get; set; }

        /// <summary>Gets or sets the message text box alignment.</summary>
        /// <value>The message text box alignment.</value>
        public HorizontalAlignment? MessageTextBoxAlignment { get; set; }

        /// <summary>Gets or sets the force use of operating system icons.</summary>
        /// <value>Forces the use of operating system icons.</value>
        public bool? ForceUseOfOperatingSystemIcons { get; set; }

        /// <summary>Gets or sets the help file path for <see cref="HelpInfo"/>.</summary>
        /// <value>The help file path.</value>
        public string? HelpFilePath { get; set; }

        /// <summary>Gets or sets the help navigator for <see cref="HelpInfo"/>.</summary>
        /// <value>The help navigator.</value>
        public HelpNavigator? HelpNavigator { get; set; }

        /// <summary>Gets or sets the help parameters for <see cref="HelpInfo"/>.</summary>
        /// <value>The help parameters.</value>
        public object? HelpParameters { get; set; }

        /// <summary>Gets or sets the CheckBox text.</summary>
        /// <value>The CheckBox text.</value>
        public string? CheckBoxText { get; set; }

        /// <summary>Gets or sets the CheckBox checked value.</summary>
        /// <value>The CheckBox checked value.</value>
        public bool? IsCheckBoxChecked { get; set; }

        /// <summary>Gets or sets the state of the CheckBox <see cref="CheckState"/>.</summary>
        /// <value>The state of the CheckBox <see cref="CheckState"/>.</value>
        public CheckState? CheckBoxCheckState { get; set; }

        /// <summary>Gets or sets the state of the use CheckBox three.</summary>
        /// <value>The state of the use CheckBox three.</value>
        public bool? UseCheckBoxThreeState { get; set; }

        /// <summary>Gets or sets the show close button.</summary>
        /// <value>The show close button.</value>
        public bool? ShowCloseButton { get; set; }

        #endregion

        #region Extended

        public bool ShowMoreDetailsOption { get; set; }

        public PaletteRelativeAlign? RichTextBoxTextAlignment { get; set; }

        public string? MoreDetailsButtonText { get; set; }

        public string? MoreDetailsMessageText { get; set; }
        public int? TimeoutInterval { get; set; }
        public int TimeOut { get; set; }
        public bool UseTimeOutOption { get; set; }

        #endregion

        #endregion

        #region Identity

        public KryptonMessageBoxExtendedData()
        {

        }

        #endregion
    }
}