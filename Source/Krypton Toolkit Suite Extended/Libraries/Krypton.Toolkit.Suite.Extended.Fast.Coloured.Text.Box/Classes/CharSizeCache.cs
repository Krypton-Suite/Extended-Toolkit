#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
* KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
* IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
* PURPOSE.
*
* License: GNU Lesser General Public License (LGPLv3)
*
* Email: pavel_torgashov@ukr.net.
*
* Copyright (C) Pavel Torgashov, 2011-2016.
*/
#endregion

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Calling MeasureText on each char is extremly slow
    /// Thankfully the size of the char does not change for the same font
    /// However we would still need to indentify the font somehow
    /// </summary>
    static class CharSizeCache
    {
        static readonly Dictionary<string, SizeF> cache = new Dictionary<string, SizeF>();
        internal static SizeF GetCharSize(Font font, char c)
        {
            var key = GetKey(font, c);
            if (!cache.ContainsKey(key))
            {
                Size sz2 = TextRenderer.MeasureText("<" + c.ToString() + ">", font);
                Size sz3 = TextRenderer.MeasureText("<>", font);
                cache[key] = new SizeF(sz2.Width - sz3.Width + 1, /*sz2.Height*/font.Height);
            }
            return cache[key];
        }

        /// <summary>
        /// Font is disposable, so we need to indentify it without keeping manged resources
        /// </summary>
        /// <param name="font"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private static string GetKey(Font font, char c)
        {
            return font.FontFamily.Name
                    + ":" + font.Size
                    + ":" + font.Style
                    + ":" + font.Unit
                    + ":" + font.GdiCharSet
                    + ":" + font.GdiVerticalFont
                    + ":" + c;
        }
    }
}