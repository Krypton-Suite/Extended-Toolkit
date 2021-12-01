#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Tool.Box
{
    // The value of the enumerations are the char values
    // of marlett font which will be used to draw scroll arrow
    // for each direction. Only up and down directions are used now.
    //
    // 01/10/2005 - Marlett font is no longer used for scroll buttons.

    [Serializable]
    public enum ToolBoxScrollDirection
    {
        LEFT = 3,
        RIGHT = 4,
        UP = 5,
        DOWN = 6,
    }

    [Serializable]
    public enum ToolBoxViewMode
    {
        LARGEICONS,
        SMALLICONS,
        LIST,
    }

    [Serializable]
    public enum ToolBoxTextPosition
    {
        TOP,
        BOTTOM,
        HIDDEN,
    }
}