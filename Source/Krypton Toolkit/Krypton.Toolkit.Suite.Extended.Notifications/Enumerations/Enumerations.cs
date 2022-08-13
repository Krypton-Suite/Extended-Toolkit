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
    public enum KryptonNotificationActionType
    {
        /// <summary>The default action.</summary>
        Default,
        /// <summary>Launches or starts a process.</summary>
        LaunchProcess,
        /// <summary>Opens a process.</summary>
        Open
    }

    /// <summary>Defines the <see cref="KryptonToastNotificationVersion1"/> action button location.</summary>
    public enum KryptonNotificationActionButtonLocation
    {
        /// <summary>Place the action button to the left.</summary>
        Left,
        /// <summary>Place the action button to the right.</summary>
        Right
    }

    /// <summary>Defines the <see cref="KryptonToastNotificationVersion1"/> default button.</summary>
    // TODO: Implement this feature into `KryptonToastNotification`
    public enum KryptonNotificationDefaultNotificationButton
    {
        /// <summary>Use the 'action' button as the default button.</summary>
        ActionButton,
        /// <summary>Use the 'dismiss' button as the default button.</summary>
        DismissButton,
        /// <summary>Use neither button as the default button.</summary>
        None
    }

    /// <summary>Specifies the icon shown on the <see cref="KryptonToastNotificationVersion1"/>.</summary>
    public enum KryptonNotificationIconType
    {
        /// <summary>Use a custom icon.</summary>
        Custom,
        /// <summary>Use a Ok icon.</summary>
        Ok,
        /// <summary>Use a error icon.</summary>
        Error,
        /// <summary>Use a exclamation icon.</summary>
        Exclamation,
        /// <summary>Use a information icon.</summary>
        Information,
        /// <summary>Use a question icon.</summary>
        Question,
        /// <summary>Use no icon.</summary>
        None,
        /// <summary>Use a stop icon.</summary>
        Stop,
        /// <summary>Use a hand icon.</summary>
        Hand,
        /// <summary>Use a warning icon.</summary>
        Warning
    }

    /// <summary>The layout of the UI elements on the <see cref="KryptonToastNotificationVersion1"/>.</summary>
    public enum KryptonNotificationRightToLeftSupport
    {
        /// <summary>Configure the <see cref="KryptonToastNotificationVersion1"/> UX for left-to-right.</summary>
        LeftToRight,
        /// <summary>Configure the <see cref="KryptonToastNotificationVersion1"/> UX for right-to-left.</summary>
        RightToLeft
    }

    public enum KryptonNotificationAlertAction
    {
        Start,
        Wait,
        Close
    }

    public enum KryptonNotificationAlertType
    {
        Success,
        Information,
        Warning,
        Error,
        Custom
    }

    public enum KryptonNotificationActionButtonType
    {
        Normal =  0,
        UserAccountControlElevated = 1
    }
}