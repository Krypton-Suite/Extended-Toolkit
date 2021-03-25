#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
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

    public enum RightToLeftSupport
    {
        LEFTTORIGHT,
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
}
