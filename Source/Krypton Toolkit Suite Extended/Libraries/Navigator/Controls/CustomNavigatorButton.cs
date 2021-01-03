#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Standard.Controls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    [ToolboxBitmap(typeof(Button)), ToolboxItem(false)]
    public class CustomNavigatorButton : CustomButton
    {

        public CustomNavigatorButton(Color borderColour, Color gradientStartColour, Color gradientEndColour, Color textColour)
        {

            this.AutoSize = false;

            this.GradientBorderColour = borderColour;
            this.GradientTop = gradientStartColour;
            this.GradientBottom = gradientEndColour;
            this.Size = new System.Drawing.Size(23, 23);
            this.ForeColor = textColour;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Font = new System.Drawing.Font("Marlett", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)2);

        }

        public CustomNavigatorButton()
        {
            this.AutoSize = false;
            this.Size = new System.Drawing.Size(23, 23);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Font = new System.Drawing.Font("Marlett", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)2);

        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
