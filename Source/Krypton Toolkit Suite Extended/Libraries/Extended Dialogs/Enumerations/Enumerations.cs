#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>The chosen input box icon.</summary>
    public enum InputBoxIcon
    {
        /// <summary>A user defined icon.</summary>
        CUSTOM,
        /// <summary>A ok icon.</summary>
        OK,
        /// <summary>A error icon.</summary>
        ERROR,
        EXCLAMATION,
        INFORMATION,
        QUESTION,
        NONE,
        STOP,
        HAND
    }

    public enum InputBoxIconImageSize
    {
        CUSTOM,
        THIRTYTWO,
        FOURTYEIGHT,
        SIXTYFOUR,
        ONEHUNDREDANDTWENTYEIGHT
    }

    public enum InputBoxType
    {
        COMBOBOX,
        TEXTBOX,
        NOTHING
    }

    public enum InputBoxButtons
    {
        OK,
        OKCANCEL,
        YESNO,
        YESNOCANCEL
    }

    public enum InputBoxMessageTextAlignment
    {
        LEFT,
        CENTRE,
        RIGHT,
        INHERIT
    }

    public enum InputBoxUserInputTextAlignment
    {
        LEFT,
        CENTRE,
        RIGHT,
        INHERIT
    }

    public enum InputBoxUserSelectionTextAlignment
    {
        LEFT,
        CENTRE,
        RIGHT,
        INHERIT
    }

    public enum InputBoxMessageRightToLeft
    {
        NO,
        YES,
        INHERIT
    }

    /*
    /// <summary>The chosen language for buttons.</summary>
    public enum Language
    {
        /// <summary>The Czech definition.</summary>
        CZECH,
        /// <summary>The English definition.</summary>
        ENGLISH,
        /// <summary>The Français definition.</summary>
        FRANÇAIS,
        /// <summary>The Deutsch definition.</summary>
        DEUTSCH,
        /// <summary>The Slovakian definition.</summary>
        SLOVAKIAN,
        /// <summary>The Español definition.</summary>
        ESPAÑOL,
        /// <summary>A custom language definition.</summary>
        CUSTOM
    }
    */

    public enum InputBoxDefaultButton
    {
        BUTTONONE,
        BUTTONTWO,
        BUTTONTHREE
    }

    public enum KryptonMemoryBoxDialogResult
    {
        YES,
        YESTOALL,
        NO,
        NOTOALL,
        CANCEL
    }

    public enum KryptonMemoryBoxIcon
    {
        CUSTOM,
        OK,
        ERROR,
        EXCLAMATION,
        INFORMATION,
        QUESTION,
        NONE,
        STOP,
        HAND
    }

    public enum KryptonMemoryBoxDefaultButton
    {
        BUTTONONE = 0,
        BUTTONTWO = 1,
        BUTTONTHREE = 2,
        BUTTONFOUR = 3,
        BUTTONFIVE = 4
    }

    public enum IconType
    {
        CUSTOM,
        OK,
        ERROR,
        EXCLAMATION,
        INFORMATION,
        QUESTION,
        NOTHING,
        NONE,
        STOP,
        HAND,
        WARNING
    }

    public enum ProgressBarOrientation
    {
        VERTICAL,
        HORIZONTAL
    }

    public enum RightToLeftSupport
    {
        LEFTTORIGHT,
        RIGHTTOLEFT
    }

    public enum ActionType
    {
        DEFAULT,
        LAUCHPROCESS,
        OPEN
    }

    public enum ActionButtonLocation
    {
        LEFT,
        RIGHT
    }

    public enum DefaultNotificationButton
    {
        ACTIONBUTTON,
        DISMISSBUTTON,
        NONE
    }

    /// <summary>
    /// Specifies constants defining how the new scope treats the parameters of the parent scopes.
    /// </summary>
    public enum InformationBoxScopeBehavior
    {
        /// <summary>
        /// Parent parameters are ignored.
        /// </summary>
        NONE,

        /// <summary>
        /// The parameters of the direct parent are taken into account.
        /// </summary>
        INHERITPARENT,

        /// <summary>
        /// The parameters of all active scopes are taken into account.
        /// </summary>
        INHERITALL,
    }

    /// <summary>
    /// Defines constant representing the parameters specified for the auto-close feature.
    /// </summary>
    public enum AutoCloseDefinedParameters
    {
        /// <summary>
        /// The button to use is defined.
        /// </summary>
        Button,

        /// <summary>
        /// Only the time to wait is defined.
        /// </summary>
        TimeOnly,

        /// <summary>
        /// The InformationBoxResult is defined.
        /// </summary>
        Result,
    }

    /// <summary>
    /// Specifies constants defining which source to use for the icon.
    /// </summary>
    internal enum InformationBoxIconType
    {
        /// <summary>
        /// Uses internal icons
        /// </summary>
        Internal,

        /// <summary>
        /// Uses an icon specified by the client.
        /// </summary>
        UserDefined,
    }

    /// <summary>
    /// Specifies constants defining which mode is used for autosizing the <see cref="InformationBox"/>.
    /// </summary>
    public enum InformationBoxAutoSizeMode
    {
        /// <summary>
        /// Adjust the height and text to have the highest <see cref="InformationBox"/> possible. Existing line breaks are ignored.
        /// </summary>
        MinimumWidth,

        /// <summary>
        /// Adjust the width and text to have the widest <see cref="InformationBox"/> possible. Existing line breaks are ignored.
        /// </summary>
        MinimumHeight,

        /// <summary>
        /// The <see cref="InformationBox"/> will be set according to existing line breaks.
        /// </summary>
        None,
    }

    /// <summary>
    /// Specifies constants defining how is displayed the <see cref="InformationBox"/>.
    /// </summary>
    public enum InformationBoxBehavior
    {
        /// <summary>
        /// The InformationBox is displayed as a modal (blocking) window (default).
        /// </summary>
        Modal,

        /// <summary>
        /// The InformationBox is displayed as a modeless (non-blocking) window.
        /// </summary>
        Modeless,
    }

    /// <summary>
    /// Specifies constants defining which buttons to display on an <see cref="InformationBoxForm" />.
    /// </summary>
    public enum InformationBoxButtons
    {
        /// <summary>
        /// The message box contains Abort, Retry, and Ignore buttons.
        /// </summary>
        AbortRetryIgnore,

        /// <summary>
        /// The message box contains an OK button.
        /// </summary>
        OK,

        /// <summary>
        /// The message box contains OK and Cancel buttons.
        /// </summary>
        OKCancel,

        /// <summary>
        /// The message box contains Retry and Cancel buttons.
        /// </summary>
        RetryCancel,

        /// <summary>
        /// The message box contains Yes and No buttons.
        /// </summary>
        YesNo,

        /// <summary>
        /// The message box contains Yes, No, and Cancel buttons.
        /// </summary>
        YesNoCancel,

        /// <summary>
        /// The message box contains Yes, No, and a user-defined buttons.
        /// </summary>
        YesNoUser1,

        /// <summary>
        /// The message box contains OK, Cancel, and a user-defined buttons.
        /// </summary>
        OKCancelUser1,

        /// <summary>
        /// The message box contains two user-defined buttons.
        /// </summary>
        User1User2,

        /// <summary>
        /// The message box contains one user-defined button.
        /// </summary>
        User1,
        /// <summary>
        /// The message box contains three user-defined buttons.
        /// </summary>
        User1User2User3
    }

    /// <summary>
    /// Specifies constants defining how to place buttons on the <see cref="InformationBox"/>.
    /// </summary>
    public enum InformationBoxButtonsLayout
    {
        /// <summary>
        /// Buttons are grouped on the left side.
        /// </summary>
        GroupLeft,

        /// <summary>
        /// Buttons are grouped in the middle.
        /// </summary>
        GroupMiddle,

        /// <summary>
        /// Buttons are grouped on the right side.
        /// </summary>
        GroupRight,

        /// <summary>
        /// Spacing is constant between the buttons and the edges of the <see cref="InformationBox"/>.
        /// </summary>
        Separate,
    }

    /// <summary>
    /// Specifies constants defining whether the "Do not show this dialog again" checkbox is displayed or not.
    /// </summary>
    [Flags]
    public enum InformationBoxCheckBox
    {
        /// <summary>
        /// The checkbox will be displayed.
        /// </summary>
        Show = 1,

        /// <summary>
        /// Initial unchecked state (default value).
        /// </summary>
        Checked = 2,

        /// <summary>
        /// The checkbox is right aligned.
        /// </summary>
        RightAligned = 4,
    }

    /// <summary>
    /// Specifies constants defining the default button on a <see cref="KryptonInformationBoxWindow"/>.
    /// </summary>
    public enum InformationBoxDefaultButton
    {
        /// <summary>
        /// The first button on the message box is the default button.
        /// </summary>
        Button1,

        /// <summary>
        /// The second button on the message box is the default button. 
        /// </summary>
        Button2,

        /// <summary>
        /// The third button on the message box is the default button.
        /// </summary>
        Button3,
    }

    /// <summary>
    /// Contains all possible values for the InformationBox icon.
    /// </summary>
    public enum InformationBoxIcon
    {
        /// <summary>
        /// Asterisk icon
        /// </summary>
        Asterisk,

        /// <summary>
        /// Error icon
        /// </summary>
        Error,

        /// <summary>
        /// Exclamation icon
        /// </summary>
        Exclamation,

        /// <summary>
        /// Hand icon.
        /// </summary>
        Hand,

        /// <summary>
        /// Information icon
        /// </summary>
        Information,

        /// <summary>
        /// Do not show an icon
        /// </summary>
        None,

        /// <summary>
        /// Question icon
        /// </summary>
        Question,

        /// <summary>
        /// Stop icon.
        /// </summary>
        Stop,

        /// <summary>
        /// Warning icon
        /// </summary>
        Warning,

        /// <summary>
        /// Success icon
        /// </summary>
        Success,

        /// <summary>
        /// A fax icon
        /// </summary>
        Fax,

        /// <summary>
        /// Gamepad icon
        /// </summary>
        Gamepad,

        /// <summary>
        /// Joystick icon
        /// </summary>
        Joystick,

        /// <summary>
        /// Keys icon.
        /// </summary>
        Keys,

        /// <summary>
        /// Locker icon
        /// </summary>
        Locker,

        /// <summary>
        /// Phone icon
        /// </summary>
        Phone,

        /// <summary>
        /// Printer icon
        /// </summary>
        Printer,

        /// <summary>
        /// Scanner icon
        /// </summary>
        Scanner,

        /// <summary>
        /// Speakers icon
        /// </summary>
        Speakers,
    }

    /// <summary>
    /// Specify constants defining how to initialize the <see cref="InformationBox"/>.
    /// </summary>
    public enum InformationBoxInitialization
    {
        /// <summary>
        /// The <see cref="InformationBox"/> is initialized from the parameters only. All scopes are ignored.
        /// </summary>
        FromParametersOnly,

        /// <summary>
        /// The <see cref="InformationBox"/> is first initialized from the current scope (if available) and then from the supplied parameters.
        /// </summary>
        FromScopeAndParameters,
    }

    /// <summary>
    /// Specifies constants defining the sound category of the message.
    /// </summary>
    internal enum InformationBoxMessageCategory
    {
        /// <summary>
        /// Asterisk sound
        /// </summary>
        Asterisk,

        /// <summary>
        /// Exclamation sound
        /// </summary>
        Exclamation,

        /// <summary>
        /// Hand sound
        /// </summary>
        Hand,

        /// <summary>
        /// Other sound
        /// </summary>
        Other,

        /// <summary>
        /// Question sound
        /// </summary>
        Question,
    }

    /// <summary>
    /// Specifies constants defining the opacity of the <see cref="KryptonInformationBoxWindow" />.
    /// </summary>
    public enum InformationBoxOpacity
    {
        /// <summary>
        /// Opacity is at 10%
        /// </summary>
        Faded10,

        /// <summary>
        /// Opacity is at 20%
        /// </summary>
        Faded20,

        /// <summary>
        /// Opacity is at 30%
        /// </summary>
        Faded30,

        /// <summary>
        /// Opacity is at 40%
        /// </summary>
        Faded40,

        /// <summary>
        /// Opacity is at 50%
        /// </summary>
        Faded50,

        /// <summary>
        /// Opacity is at 60%
        /// </summary>
        Faded60,

        /// <summary>
        /// Opacity is at 70%
        /// </summary>
        Faded70,

        /// <summary>
        /// Opacity is at 80%
        /// </summary>
        Faded80,

        /// <summary>
        /// Opacity is at 90%
        /// </summary>
        Faded90,

        /// <summary>
        /// Opacity is at 100%
        /// </summary>
        NoFade,
    }

    /// <summary>
    /// Specifies constants defining the z-order of the <see cref="InformationBox"/>.
    /// </summary>
    public enum InformationBoxOrder
    {
        /// <summary>
        /// Default position.
        /// </summary>
        Default,

        /// <summary>
        /// Sets the <see cref="InformationBox"/> as the top most window.
        /// </summary>
        TopMost,
    }

    /// <summary>
    /// Specifies constants defining the position of the <see cref="InformationBox"/>.
    /// </summary>
    public enum InformationBoxPosition
    {
        /// <summary>
        /// the <see cref="InformationBox"/> will be centered on the parent window. This is the default value. Only for modal behavior.
        /// </summary>
        CenterOnParent,

        /// <summary>
        /// the <see cref="InformationBox"/> will be centered on the screen.
        /// </summary>
        CenterOnScreen,
    }

    /// <summary>
    /// Contains all possible values for the Show return value. Identifies which button was clicked.
    /// </summary>
    public enum InformationBoxResult
    {
        /// <summary>
        /// The dialog box return value is Abort (usually sent from a button labeled Abort).
        /// </summary>
        Abort,

        /// <summary>
        /// The dialog box return value is Cancel (usually sent from a button labeled Cancel).
        /// </summary>
        Cancel,

        /// <summary>
        /// The dialog box return value is Ignore (usually sent from a button labeled Ignore).
        /// </summary>
        Ignore,

        /// <summary>
        /// The dialog box return value is No (usually sent from a button labeled No).
        /// </summary>
        No,

        /// <summary>
        /// Nothing is returned from the dialog box. This means that the modal dialog continues running.
        /// </summary>
        None,

        /// <summary>
        /// The dialog box return value is OK (usually sent from a button labeled OK).
        /// </summary>
        OK,

        /// <summary>
        /// The dialog box return value is Retry (usually sent from a button labeled Retry).
        /// </summary>
        Retry,

        /// <summary>
        /// The dialog box return value is Yes (usually sent from a button labeled Yes).
        /// </summary>
        Yes,

        /// <summary>
        /// The dialog box return value is User1 (usually sent from the first user-defined button).
        /// </summary>
        User1,

        /// <summary>
        /// The dialog box return value is Yes (usually sent from the second user-defined button).
        /// </summary>
        User2,
        /// <summary>
        /// The dialog box return value is User3 (usually sent from the third user-defined button).
        /// </summary>
        User3,
    }

    /// <summary>
    /// Specifies constants defining which visual style will be used
    /// </summary>
    public enum InformationBoxStyle
    {
        /// <summary>
        /// Default skin
        /// </summary>
        Standard,

        /// <summary>
        /// Modern skin with glass style buttons
        /// </summary>
        Modern,
        /// <summary>
        /// The krypton style
        /// </summary>
        Krypton
    }

    /// <summary>
    /// Specifies constants defining which icon is displayed on the title bar.
    /// </summary>
    public enum InformationBoxTitleIconStyle
    {
        /// <summary>
        /// No title icon.
        /// </summary>
        None,

        /// <summary>
        /// Use the icon displayed in the box.
        /// </summary>
        SameAsBox,

        /// <summary>
        /// Use a custom icon.
        /// </summary>
        Custom,
    }

    /// <summary>
    /// Specifies constants defining whether sound will be played on opening
    /// </summary>
    public enum InformationBoxSound
    {
        /// <summary>
        /// The default system sound.
        /// </summary>
        Default,

        /// <summary>
        /// Does not play default sound.
        /// </summary>
        None,
    }

    /// <summary>
    /// Represents which side borders are displayed.
    /// </summary>
    public enum SideBorder
    {
        /// <summary>
        /// No border for the panel
        /// </summary>
        None,

        /// <summary>
        /// Right side only
        /// </summary>
        Right,

        /// <summary>
        /// Left side only
        /// </summary>
        Left,

        /// <summary>
        /// Both sides (left and right)
        /// </summary>
        Both,
    }
}