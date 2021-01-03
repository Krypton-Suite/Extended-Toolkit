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

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    [Serializable]
    public class ServiceColours
    {
        public Color CollapseMarkerForeColour { get; set; }
        public Color CollapseMarkerBackColour { get; set; }
        public Color CollapseMarkerBorderColour { get; set; }
        public Color ExpandMarkerForeColour { get; set; }
        public Color ExpandMarkerBackColour { get; set; }
        public Color ExpandMarkerBorderColour { get; set; }

        public ServiceColours()
        {
            CollapseMarkerForeColour = Color.Silver;
            CollapseMarkerBackColour = Color.White;
            CollapseMarkerBorderColour = Color.Silver;
            ExpandMarkerForeColour = Color.Red;
            ExpandMarkerBackColour = Color.White;
            ExpandMarkerBorderColour = Color.Silver;
        }
    }
}