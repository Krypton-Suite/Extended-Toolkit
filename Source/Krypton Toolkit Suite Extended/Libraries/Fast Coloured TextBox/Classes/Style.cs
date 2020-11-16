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

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Style of chars
    /// </summary>
    /// <remarks>This is base class for all text and design renderers</remarks>
    public abstract class Style : IDisposable
    {
        /// <summary>
        /// This style is exported to outer formats (HTML for example)
        /// </summary>
        public virtual bool IsExportable { get; set; }
        /// <summary>
        /// Occurs when user click on StyleVisualMarker joined to this style 
        /// </summary>
        public event EventHandler<VisualMarkerEventArgs> VisualMarkerClick;

        /// <summary>
        /// Constructor
        /// </summary>
        public Style()
        {
            IsExportable = true;
        }

        /// <summary>
        /// Renders given range of text
        /// </summary>
        /// <param name="gr">Graphics object</param>
        /// <param name="position">Position of the range in absolute control coordinates</param>
        /// <param name="range">Rendering range of text</param>
        public abstract void Draw(Graphics gr, Point position, Range range);

        /// <summary>
        /// Occurs when user click on StyleVisualMarker joined to this style 
        /// </summary>
        public virtual void OnVisualMarkerClick(FastColouredTextBox tb, VisualMarkerEventArgs args)
        {
            if (VisualMarkerClick != null)
                VisualMarkerClick(tb, args);
        }

        /// <summary>
        /// Shows VisualMarker
        /// Call this method in Draw method, when you need to show VisualMarker for your style
        /// </summary>
        protected virtual void AddVisualMarker(FastColouredTextBox tb, StyleVisualMarker marker)
        {
            tb.AddVisualMarker(marker);
        }

        public static Size GetSizeOfRange(Range range)
        {
            return new Size((range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
        }

        public static GraphicsPath GetRoundedRectangle(Rectangle rect, int d)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddArc(rect.X, rect.Y, d, d, 180, 90);
            gp.AddArc(rect.X + rect.Width - d, rect.Y, d, d, 270, 90);
            gp.AddArc(rect.X + rect.Width - d, rect.Y + rect.Height - d, d, d, 0, 90);
            gp.AddArc(rect.X, rect.Y + rect.Height - d, d, d, 90, 90);
            gp.AddLine(rect.X, rect.Y + rect.Height - d, rect.X, rect.Y + d / 2);

            return gp;
        }

        public virtual void Dispose()
        {
            ;
        }

        /// <summary>
        /// Returns CSS for export to HTML
        /// </summary>
        /// <returns></returns>
        public virtual string GetCSS()
        {
            return "";
        }

        /// <summary>
        /// Returns RTF descriptor for export to RTF
        /// </summary>
        /// <returns></returns>
        public virtual RTFStyleDescriptor GetRTF()
        {
            return new RTFStyleDescriptor();
        }
    }
}