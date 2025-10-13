#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Core;

[ToolboxItem(false)]
public class CircularPictureBox : PictureBox, IContentValues
{
    private ToolTipValues _values;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolTipValues ToolTipValues
    {
        get => _values; set => _values = value;
    }

    public CircularPictureBox()
    {
        BackColor = SystemColors.Control;
    }

    protected override void OnResize(EventArgs e)
    {
        using (GraphicsPath graphicsPath = new())
        {
            graphicsPath.AddEllipse(new(0, 0, Width - 1, Height - 1));

            Region = new(graphicsPath);
        }

        base.OnResize(e);
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        using (GraphicsPath graphicsPath = new())
        {
            graphicsPath.AddEllipse(0, 0, Width - 1, Height - 1);

            Region = new(graphicsPath);

            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            pe.Graphics.DrawEllipse(new(new SolidBrush(BackColor), 1), 0, 0, Width - 1, Height - 1);
        }

        base.OnPaint(pe);
    }

    public Image GetImage(PaletteState state) => throw new NotImplementedException();

    public Color GetImageTransparentColor(PaletteState state) => throw new NotImplementedException();

    public string GetShortText() => throw new NotImplementedException();

    public string GetLongText() => throw new NotImplementedException();
}