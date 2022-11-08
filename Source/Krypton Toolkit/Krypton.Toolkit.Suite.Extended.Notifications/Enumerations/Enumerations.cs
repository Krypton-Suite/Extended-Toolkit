#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    /// <summary>The <see cref="KryptonToastNotificationVersion1" /> action button type.</summary>
    public enum ActionType
    {
        /// <summary>The default action.</summary>
        Default,
        /// <summary>Launches or starts a process.</summary>
        LaunchProcess,
        /// <summary>Opens a process.</summary>
        Open
    }

    /// <summary>Defines the <see cref="KryptonToastNotificationVersion1"/> action button location.</summary>
    public enum ActionButtonLocation
    {
        /// <summary>Place the action button to the left.</summary>
        Left,
        /// <summary>Place the action button to the right.</summary>
        Right
    }

    /// <summary>Defines the <see cref="KryptonToastNotificationVersion1"/> default button.</summary>
    // TODO: Implement this feature into `KryptonToastNotification`
    public enum DefaultNotificationButton
    {
        /// <summary>Use the 'action' button as the default button.</summary>
        ActionButton,
        /// <summary>Use the 'dismiss' button as the default button.</summary>
        DismissButton,
        /// <summary>Use neither button as the default button.</summary>
        None
    }

    /// <summary>Specifies the icon shown on the <see cref="KryptonToastNotificationVersion1"/>.</summary>
    public enum IconType
    {
        /// <summary>Specify no icon.</summary>
        None = 0,
        /// <summary>Specify a hand icon.</summary>
        Hand = 1,
        /// <summary>Specify a question icon.</summary>
        Question = 2,
        /// <summary>Specify a exclamation icon.</summary>
        Exclamation = 3,
        /// <summary>Specify a asterisk icon.</summary>
        Asterisk = 4,
        /// <summary>Specify a stop icon.</summary>
        Stop = 5,
        /// <summary>Specify a error icon.</summary>
        Error = 6,
        /// <summary>Specify a warning icon.</summary>
        Warning = 7,
        /// <summary>Specify a information icon.</summary>
        Information = 8,
        /// <summary>Specify a UAC shield icon.</summary>
        Shield = 9,
        /// <summary>Specify a Windows logo icon.</summary>
        WindowsLogo = 10,
        /// <summary>Use a custom icon.</summary>
        Custom = 11,
        /// <summary>Use a Ok icon.</summary>
        Ok = 12
    }

    /// <summary>The layout of the UI elements on the <see cref="KryptonToastNotificationVersion1"/>.</summary>
    public enum RightToLeftSupport
    {
        /// <summary>Configure the <see cref="KryptonToastNotificationVersion1"/> UX for left-to-right.</summary>
        LEFTTORIGHT,
        /// <summary>Configure the <see cref="KryptonToastNotificationVersion1"/> UX for right-to-left.</summary>
        RIGHTTOLEFT
    }

    public enum AlertAction
    {
        START,
        WAIT,
        CLOSE
    }

    public enum AlertType
    {
        SUCESS,
        INFORMATION,
        WARNING,
        ERROR,
        CUSTOM
    }

    public enum ActionButtonType
    {
        NORMAL =  0,
        UACELEVATED = 1
    }
}