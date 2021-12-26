#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    [ToolboxBitmap(typeof(Button)), ToolboxItem(false)]
    public class CustomNavigatorButton : CustomButton
    {

        public CustomNavigatorButton(Color BorderColour, Color GradientStartColour, Color GradientEndColour, Color TextColour)
        {

            this.AutoSize = false;

            this.GradientBorderColour = BorderColour;
            this.GradientTop = GradientStartColour;
            this.GradientBottom = GradientEndColour;
            this.Size = new System.Drawing.Size(23, 23);
            this.ForeColor = TextColour;
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
