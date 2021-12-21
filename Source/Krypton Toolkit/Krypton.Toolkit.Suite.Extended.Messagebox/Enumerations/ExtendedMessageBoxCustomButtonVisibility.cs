#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Messagebox;

/// <summary>Specifies a custom button layout.</summary>
public enum ExtendedMessageBoxCustomButtonVisibility
{
    /// <summary>Do not use custom buttons, instead default to an 'OK' only button.</summary>
    NONE = 0,
    /// <summary>Use a one button layout.</summary>
    ONEBUTTON = 1,
    /// <summary>Use a two button layout.</summary>
    TWOBUTTONS = 2,
    /// <summary>Use a three button layout.</summary>
    THREEBUTTONS = 3
}