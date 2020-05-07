#region License and Copyright
/*
 
Copyright (c) Guifreaks - Jacob Mesu
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the Guifreaks nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

*/
#endregion

using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Navi.Suite
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
