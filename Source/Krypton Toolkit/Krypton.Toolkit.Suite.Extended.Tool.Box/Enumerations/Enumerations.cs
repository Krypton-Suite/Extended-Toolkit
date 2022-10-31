﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

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