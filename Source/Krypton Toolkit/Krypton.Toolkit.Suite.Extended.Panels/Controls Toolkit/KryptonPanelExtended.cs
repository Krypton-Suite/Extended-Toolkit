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

namespace Krypton.Toolkit.Suite.Extended.Panels;

[ToolboxBitmap(typeof(KryptonPanel))]
public class KryptonPanelExtended : KryptonPanel
{
    #region Intsance Fields
    private int _cornerRadius;

    private Pen _pen;
    #endregion

    #region Public
    public int CornerRadius { get => _cornerRadius; set { _cornerRadius = value; Invalidate(); } }
    #endregion

    #region Identity
    /// <summary>Initializes a new instance of the <see cref="KryptonPanelExtended" /> class.</summary>
    public KryptonPanelExtended()
    {
        DoubleBuffered = true;

        CornerRadius = 0;
    }
    #endregion

    #region Implementation
    private Rectangle GetUpperLeft(int value) => new(0, 0, value, value);

    private Rectangle GetUpperRight(int value) => new(Width - value, 0, value, value);

    private Rectangle GetLowerRight(int value) => new(Width - value, Height - value, value, value);

    private Rectangle GetLowerLeft(int value) => new(0, Height - value, value, value);

    private void ExtendDraw(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        GraphicsPath path = new();

        path.StartFigure();

        path.AddArc(GetUpperLeft(CornerRadius), 180, 90);

        path.AddLine(CornerRadius, 0, Width - CornerRadius, 0);

        path.AddArc(GetUpperRight(CornerRadius), 270, 90);

        path.AddLine(Width, CornerRadius, Width, Height - CornerRadius);

        path.AddArc(GetLowerRight(CornerRadius), 0, 90);

        path.AddLine(Width - CornerRadius, Height, CornerRadius, Height);

        path.AddArc(GetLowerLeft(CornerRadius), 90, 90);

        path.AddLine(0, Height - CornerRadius, 0, CornerRadius);

        path.CloseFigure();

        Region = new Region(path);
    }

    private void DrawSingleBorder(Graphics graphics)
    {
        graphics.DrawArc(_pen, new Rectangle(0, 0, CornerRadius, CornerRadius), 180, 90);

        graphics.DrawArc(_pen, new Rectangle(Width - CornerRadius - 1, -1, CornerRadius, CornerRadius), 270, 90);

        graphics.DrawArc(_pen, new Rectangle(Width - CornerRadius - 1, Height - CornerRadius - 1, CornerRadius, CornerRadius), 0, 90);

        graphics.DrawArc(_pen, new Rectangle(0, Height - CornerRadius - 1, CornerRadius, CornerRadius), 90, 90);

        graphics.DrawRectangle(_pen, 0.0f, 0.0f, (float)Width - 1.0f, (float)Height - 1.0f);
    }
    private void Draw3DBorder(Graphics graphics)
    {
        DrawSingleBorder(graphics);
    }
    private void DrawBorder(Graphics graphics)
    {
        DrawSingleBorder(graphics);
    }
    #endregion

    #region Overrides
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        ExtendDraw(e);

        DrawBorder(e.Graphics);
    }
    #endregion
}