#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toast
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

    public enum InputBoxSystemSounds
    {
        ASTERISK = 0,
        BEEP = 1,
        EXCLAMATION = 2,
        HAND = 3,
        QUESTION = 4,
        CUSTOM = 5,
        NONE = 6
    }

    public enum ContentAreaType
    {
        LABEL = 0,
        WRAPPEDLABEL = 1,
        MULTILINEDTEXTBOX = 2,
        RICHTEXTBOX = 3
    }
}