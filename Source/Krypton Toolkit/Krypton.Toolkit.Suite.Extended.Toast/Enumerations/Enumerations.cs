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
        Default = 0,
        LaunchProcess = 1,
        Open = 2
    }

    public enum ActionButtonLocation
    {
        Left = 0,
        Right = 1
    }

    public enum DefaultNotificationButton
    {
        /// <summary>Use the 'action' button as the default button.</summary>
        ActionButton = 0,
        /// <summary>Use the 'dismiss' button as the default button.</summary>
        DismissButton = 1,
        /// <summary>Use neither button as the default button.</summary>
        None = 2
    }

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

    public enum RightToLeftSupport
    {
        Inherit = 0,
        LeftToRight = 1,
        RightToLeft = 2
    }

    public enum ToastNotificationSystemSounds
    {
        Asterisk = 0,
        Beep = 1,
        Exclamation = 2,
        Hand = 3,
        Question = 4,
        Custom = 5,
        None = 6
    }

    public enum ToastNotificationContentAreaType
    {
        Label = 0,
        WrappedLabel = 1,
        MultiLinedTextBox = 2,
        RichTextBox = 3
    }
}