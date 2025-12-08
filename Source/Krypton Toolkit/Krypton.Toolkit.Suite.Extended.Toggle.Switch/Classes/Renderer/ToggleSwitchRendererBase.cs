#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch;

public abstract class ToggleSwitchRendererBase
{
    #region Private Members

    private KryptonToggleSwitchVersion1 _toggleSwitch;

    #endregion Private Members

    #region Constructor

    protected ToggleSwitchRendererBase()
    { }

    internal void SetToggleSwitch(KryptonToggleSwitchVersion1 toggleSwitch) => _toggleSwitch = toggleSwitch;

    internal KryptonToggleSwitchVersion1 ToggleSwitch => _toggleSwitch;

    #endregion Constructor

    #region Render Methods

    public void RenderBackground(PaintEventArgs e)
    {
        if (_toggleSwitch == null)
        {
            return;
        }

        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        Rectangle controlRectangle = new Rectangle(0, 0, _toggleSwitch.Width, _toggleSwitch.Height);

        FillBackground(e.Graphics, controlRectangle);

        RenderBorder(e.Graphics, controlRectangle);
    }

    public void RenderControl(PaintEventArgs e)
    {
        if (_toggleSwitch == null)
        {
            return;
        }

        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        Rectangle buttonRectangle = GetButtonRectangle();
        int totalToggleFieldWidth = ToggleSwitch.Width - buttonRectangle.Width;

        if (buttonRectangle.X > 0)
        {
            Rectangle leftRectangle = new Rectangle(0, 0, buttonRectangle.X, ToggleSwitch.Height);

            if (leftRectangle.Width > 0)
            {
                RenderLeftToggleField(e.Graphics, leftRectangle, totalToggleFieldWidth);
            }
        }

        if (buttonRectangle.X + buttonRectangle.Width < e.ClipRectangle.Width)
        {
            Rectangle rightRectangle = new Rectangle(buttonRectangle.X + buttonRectangle.Width, 0, ToggleSwitch.Width - buttonRectangle.X - buttonRectangle.Width, ToggleSwitch.Height);

            if (rightRectangle.Width > 0)
            {
                RenderRightToggleField(e.Graphics, rightRectangle, totalToggleFieldWidth);
            }
        }

        RenderButton(e.Graphics, buttonRectangle);
    }

    public void FillBackground(Graphics g, Rectangle controlRectangle)
    {
        Color backColour = !ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled ? ToggleSwitch.BackColor.ToGrayScale() : ToggleSwitch.BackColor;

        using (Brush backBrush = new SolidBrush(backColour))
        {
            g.FillRectangle(backBrush, controlRectangle);
        }
    }

    public abstract void RenderBorder(Graphics g, Rectangle borderRectangle);
    public abstract void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth);
    public abstract void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth);
    public abstract void RenderButton(Graphics g, Rectangle buttonRectangle);

    #endregion Render Methods

    #region Helper Methods

    public abstract int GetButtonWidth();
    public abstract Rectangle GetButtonRectangle();
    public abstract Rectangle GetButtonRectangle(int buttonWidth);

    #endregion Helper Methods
}