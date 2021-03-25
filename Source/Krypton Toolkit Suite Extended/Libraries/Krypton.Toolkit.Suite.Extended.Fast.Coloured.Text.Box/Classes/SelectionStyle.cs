﻿#region BSD License
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

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Renderer for selected area
    /// </summary>
    public class SelectionStyle : Style
    {
        public Brush BackgroundBrush { get; set; }
        public Brush ForegroundBrush { get; private set; }

        public override bool IsExportable
        {
            get { return false; }
            set { }
        }

        public SelectionStyle(Brush backgroundBrush, Brush foregroundBrush = null)
        {
            this.BackgroundBrush = backgroundBrush;
            this.ForegroundBrush = foregroundBrush;
        }

        public override void Draw(Graphics gr, Point position, Range range)
        {
            //draw background
            if (BackgroundBrush != null)
            {
                gr.SmoothingMode = SmoothingMode.None;
                var rect = new Rectangle(position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
                if (rect.Width == 0)
                    return;
                gr.FillRectangle(BackgroundBrush, rect);
                //
                if (ForegroundBrush != null)
                {
                    //draw text
                    gr.SmoothingMode = SmoothingMode.AntiAlias;

                    var r = new Range(range.tb, range.Start.iChar, range.Start.iLine,
                                      Math.Min(range.tb[range.End.iLine].Count, range.End.iChar), range.End.iLine);
                    using (var style = new TextStyle(ForegroundBrush, null, FontStyle.Regular))
                        style.Draw(gr, new Point(position.X, position.Y - 1), r);
                }
            }
        }
    }
}