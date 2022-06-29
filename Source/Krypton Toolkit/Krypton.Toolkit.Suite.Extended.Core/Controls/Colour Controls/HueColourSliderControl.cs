﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Linq;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    [ToolboxItem(false)]
    public class HueColourSliderControl : ColourSliderControl
    {
        #region Constructors

        public HueColourSliderControl()
        {
            this.BarStyle = ColourBarStyle.CUSTOM;
            this.Maximum = 359;
            this.CustomColours = new ColourCollection(Enumerable.Range(0, 359).Select(h => new HSLColourStructure(h, 1, 0.5).ToRgbColour()));
        }

        #endregion

        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ColourBarStyle BarStyle
        {
            get => base.BarStyle;
            set => base.BarStyle = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color Colour1
        {
            get => base.Colour1;
            set => base.Colour1 = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color Colour2
        {
            get => base.Colour2;
            set => base.Colour2 = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color Colour3
        {
            get => base.Colour3;
            set => base.Colour3 = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override float Maximum
        {
            get => base.Maximum;
            set => base.Maximum = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override float Minimum
        {
            get => base.Minimum;
            set => base.Minimum = value;
        }

        public override float Value
        {
            get => base.Value;
            set => base.Value = (int)value;
        }

        #endregion
    }
}