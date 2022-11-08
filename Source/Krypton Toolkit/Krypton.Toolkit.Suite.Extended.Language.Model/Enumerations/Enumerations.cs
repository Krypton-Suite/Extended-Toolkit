#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Language.Model
{
    /// <summary>The chosen language for buttons.</summary>
    public enum SelectedLanguage
    {
        /// <summary>The Czech definition.</summary>
        Czech = 0,
        /// <summary>The English definition.</summary>
        English = 1,
        /// <summary>The Français definition.</summary>
        Français = 2,
        /// <summary>The Deutsch definition.</summary>
        Deutsch = 3,
        /// <summary>The Slovakian definition.</summary>
        Slovakian = 4,
        /// <summary>The Español definition.</summary>
        Español = 5,
        /// <summary>A custom language definition.</summary>
        Custom = 6
    }

    /// <summary>The type of buttons.</summary>
    public enum DialogButtonsType
    {
        /// <summary>Ok button only.</summary>
        OK,
        /// <summary>A ok/cancel button.</summary>
        OKCancel,
        /// <summary>A yes/no button.</summary>
        YesNo,
        /// <summary>A yes/no/cancel button.</summary>
        YesNoCancel,
        /// <summary>A retry/cancel button.</summary>
        RetryCancel,
        /// <summary>A abort/retry/ignore button.</summary>
        AbortRetryIgnore
    }

    public enum DialogButtonType
    {
        Abort = 0,
        Cancel = 1,
        Ignore = 2,
        No = 3,
        OK = 4,
        Retry = 5,
        Yes = 6
    }
}