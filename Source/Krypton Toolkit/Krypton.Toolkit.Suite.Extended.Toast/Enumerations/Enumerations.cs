#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public enum KryptonToastNotificationActionType
    {
        Default,
        LaunchProcess,
        Open
    }

    public enum KryptonToastNotificationActionButtonLocation
    {
        Left,
        Right
    }

    public enum KryptonToastNotificationDefaultNotificationButton
    {
        ActionButton,
        DismissButton,
        None
    }

    // Note: Replicate Krypton message box extended icon options
    public enum KryptonToastNotificationIconType
    {
        /// <summary>Specify a custom icon.</summary>
        Custom = 0,
        /// <summary>Specify no icon.</summary>
        None = 1,
        /// <summary>Specify a hand icon.</summary>
        Hand = 2,
        /// <summary>Specify a question icon.</summary>
        Question = 3,
        /// <summary>Specify a exclamation icon.</summary>
        Exclamation = 4,
        /// <summary>Specify a asterisk icon.</summary>
        Asterisk = 5,
        /// <summary>Specify a stop icon.</summary>
        Stop = 6,
        /// <summary>Specify a error icon.</summary>
        Error = 7,
        /// <summary>Specify a warning icon.</summary>
        Warning = 8,
        /// <summary>Specify a information icon.</summary>
        Information = 9,
        /// <summary>Specify a UAC shield icon.</summary>
        Shield = 10,
        /// <summary>Specify a Windows logo icon.</summary>
        WindowsLogo = 11,
        /// <summary>Specify a ok icon.</summary>
        Ok = 12
    }

    public enum KryptonToastNotificationRightToLeftSupport
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

    public enum KryptonToastNotificationContentAreaType
    {
        LABEL = 0,
        WRAPPEDLABEL = 1,
        MULTILINEDTEXTBOX = 2,
        RICHTEXTBOX = 3
    }
}