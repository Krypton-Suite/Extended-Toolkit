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

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Marker style
    /// Draws background color for text
    /// </summary>
    public class MarkerStyle : Style
    {
        public Brush BackgroundBrush { get; set; }

        public MarkerStyle(Brush backgroundBrush)
        {
            this.BackgroundBrush = backgroundBrush;
            IsExportable = true;
        }

        public override void Draw(Graphics gr, Point position, Range range)
        {
            //draw background
            if (BackgroundBrush != null)
            {
                Rectangle rect = new Rectangle(position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
                if (rect.Width == 0)
                    return;
                gr.FillRectangle(BackgroundBrush, rect);
            }
        }

        public override string GetCSS()
        {
            string result = "";

            if (BackgroundBrush is SolidBrush)
            {
                var s = ExportToHTML.GetColorAsString((BackgroundBrush as SolidBrush).Color);
                if (s != "")
                    result += "background-color:" + s + ";";
            }

            return result;
        }
    }
}