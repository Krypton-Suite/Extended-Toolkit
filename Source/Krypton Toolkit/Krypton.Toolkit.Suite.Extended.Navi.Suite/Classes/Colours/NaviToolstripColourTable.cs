#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class NaviToolstripColourTable : ProfessionalColorTable
    {
        /// <summary>
        /// Overriden. Gets the color of the border of an menu item
        /// </summary>
        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(255, 189, 105); }
        }

        /// <summary>
        /// Overriden. Gets the color of selected menu item
        /// </summary>
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(255, 231, 162); }
        }

        /// <summary>
        /// Overriden. Gets the color of the image margin 
        /// </summary>
        public override Color ImageMarginGradientBegin
        {
            get { return Color.FromArgb(233, 238, 238); }
        }

        /// <summary>
        /// Overriden. Gets the color of the image margin
        /// </summary>
        public override Color ImageMarginGradientMiddle
        {
            get { return Color.FromArgb(233, 238, 238); }
        }

        /// <summary>
        /// Overriden. Gets the color of image margin
        /// </summary>
        public override Color ImageMarginGradientEnd
        {
            get { return Color.FromArgb(233, 238, 238); }
        }

        /// <summary>
        /// Overriden. Gets the background color of an menu item check
        /// </summary>
        public override Color CheckBackground
        {
            get { return Color.FromArgb(255, 189, 105); }
        }

        /// <summary>
        /// Overriden. Gets the background color of an pressed menu item check
        /// </summary>
        public override Color CheckPressedBackground
        {
            get { return Color.FromArgb(251, 140, 60); }
        }

        /// <summary>
        /// Overriden. Gets the background color of an selected menu item check
        /// </summary>
        public override Color CheckSelectedBackground
        {
            get { return Color.FromArgb(251, 140, 60); }
        }

        /// <summary>
        /// Overriden. Gets the color of the border of the item check
        /// </summary>
        public override Color ButtonSelectedBorder
        {
            get { return Color.FromArgb(255, 0, 0); }
        }
    }
}
