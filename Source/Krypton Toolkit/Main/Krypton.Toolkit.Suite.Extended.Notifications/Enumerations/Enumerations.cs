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
        DEFAULT,
        /// <summary>Launches or starts a process.</summary>
        LAUCHPROCESS,
        /// <summary>Opens a process.</summary>
        OPEN
    }

    /// <summary>Defines the <see cref="KryptonToastNotificationVersion1"/> action button location.</summary>
    public enum ActionButtonLocation
    {
        /// <summary>Place the action button to the left.</summary>
        LEFT,
        /// <summary>Place the action button to the right.</summary>
        RIGHT
    }

    /// <summary>Defines the <see cref="KryptonToastNotificationVersion1"/> default button.</summary>
    // TODO: Implement this feature into `KryptonToastNotification`
    public enum DefaultNotificationButton
    {
        /// <summary>Use the 'action' button as the default button.</summary>
        ACTIONBUTTON,
        /// <summary>Use the 'dismiss' button as the default button.</summary>
        DISMISSBUTTON,
        /// <summary>Use neither button as the default button.</summary>
        NONE
    }

    /// <summary>Specifies the icon shown on the <see cref="KryptonToastNotificationVersion1"/>.</summary>
    public enum IconType
    {
        /// <summary>Use a custom icon.</summary>
        CUSTOM,
        /// <summary>Use a Ok icon.</summary>
        OK,
        /// <summary>Use a error icon.</summary>
        ERROR,
        /// <summary>Use a exclamation icon.</summary>
        EXCLAMATION,
        /// <summary>Use a information icon.</summary>
        INFORMATION,
        /// <summary>Use a question icon.</summary>
        QUESTION,
        /// <summary>Use no icon, but keep the same layout.</summary>
        NOTHING,
        /// <summary>Use no icon.</summary>
        NONE,
        /// <summary>Use a stop icon.</summary>
        STOP,
        /// <summary>Use a hand icon.</summary>
        HAND,
        /// <summary>Use a warning icon.</summary>
        WARNING
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