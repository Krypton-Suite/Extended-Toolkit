#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class HBarData
    {
        protected RectangleF rectBar;
        public RectangleF BarRect
        {
            get { return rectBar; }
            set { rectBar = value; }
        }

        protected Color colourBar;
        public Color Colour
        {
            get { return colourBar; }
            set { colourBar = value; }
        }

        protected string strLabel;
        [Localizable(true)]
        public string Label
        {
            get { return strLabel; }
            set { strLabel = value; }
        }

        protected double dValue;
        public double Value
        {
            get { return dValue; }
            set { dValue = value; }
        }

        public HBarData(double dValue, string strLabel, Color colourBar)
        {
            this.dValue = dValue;
            this.strLabel = strLabel;
            this.colourBar = colourBar;

            Random r = new Random();
            colourBar = Color.FromArgb(r.Next(16777215));

            dValue = 0;

            strLabel = string.Empty;
        }

        public HBarData()
        {
            Random r = new Random();
            colourBar = Color.FromArgb(r.Next(16777215));

            dValue = 0;

            strLabel = string.Empty;
        }
    }
}