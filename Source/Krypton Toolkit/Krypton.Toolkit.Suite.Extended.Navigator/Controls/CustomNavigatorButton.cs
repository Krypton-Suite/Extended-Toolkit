#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navigator;

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
        this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.Font = new System.Drawing.Font("Marlett", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)2);

    }

    public CustomNavigatorButton()
    {
        this.AutoSize = false;
        this.Size = new System.Drawing.Size(23, 23);
        this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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