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

    /// <summary>The type of buttons.</summary>
    public enum DialogButtonsType
    {
        /// <summary>Ok button only.</summary>
        OK,
        /// <summary>A ok/cancel button.</summary>
        OKCANCEL,
        /// <summary>A yes/no button.</summary>
        YESNO,
        /// <summary>A yes/no/cancel button.</summary>
        YESNOCANCEL,
        /// <summary>A retry/cancel button.</summary>
        RETRYCANCEL,
        /// <summary>A abort/retry/ignore button.</summary>
        ABORTRETRYIGNORE
    }

    public enum DialogButtonType
    {
        ABORT = 0,
        CANCEL = 1,
        IGNORE = 2,
        NO = 3,
        OK = 4,
        RETRY = 5,
        YES = 6
    }
}