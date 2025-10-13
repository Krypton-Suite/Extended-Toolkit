#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2024 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Forms;

public class PaletteFormBorderExtended : PaletteBorder
{
    #region Identity
    /// <summary>
    /// Initialize a new instance of the PaletteBorder class.
    /// </summary>
    /// <param name="inherit">Source for inheriting defaulted values.</param>
    /// <param name="needPaint">Delegate for notifying paint requests.</param>
    public PaletteFormBorderExtended([DisallowNull] IPaletteBorder inherit,
        NeedPaintHandler? needPaint)
        : base(inherit, needPaint)
    {
    }
    #endregion


    #region Width
    internal bool UseThemeFormChromeBorderWidth { get; set; } = true;
    private FormBorderStyle _lastFormFormBorderStyle = FormBorderStyle.Sizable;

    /// <summary>
    /// Gets and sets the border width.
    /// </summary>
    [KryptonPersist(false)]
    [Category(@"Visuals")]
    [Description(@"Border width.")]
    [DefaultValue(-1)]
    [RefreshProperties(RefreshProperties.All)]
    public override int Width
    {
        get => !UseThemeFormChromeBorderWidth
            ? BorderWidths(_lastFormFormBorderStyle).xBorder
            : base.Width;

        set => base.Width = value;
    }

    /// https://github.com/Krypton-Suite/Standard-Toolkit/issues/139
    internal (int xBorder, int yBorder) BorderWidths(FormBorderStyle formFormBorderStyle)
    {
        var xBorder = base.Width;
        var yBorder = base.Width;
        if (!UseThemeFormChromeBorderWidth)
        {
            _lastFormFormBorderStyle = formFormBorderStyle;
            switch (formFormBorderStyle)
            {
                case FormBorderStyle.None:
                    xBorder = 0;
                    yBorder = 0;
                    break;
                case FormBorderStyle.FixedSingle:
                case FormBorderStyle.FixedToolWindow:
                    xBorder = PlatformInvoke.GetSystemMetrics(PlatformInvoke.SM_.CXFIXEDFRAME);
                    yBorder = PlatformInvoke.GetSystemMetrics(PlatformInvoke.SM_.CYFIXEDFRAME);
                    break;
                case FormBorderStyle.Fixed3D:
                    xBorder = PlatformInvoke.GetSystemMetrics(PlatformInvoke.SM_.CXEDGE);
                    yBorder = PlatformInvoke.GetSystemMetrics(PlatformInvoke.SM_.CYEDGE);
                    break;
                case FormBorderStyle.FixedDialog:
                    xBorder = PlatformInvoke.GetSystemMetrics(PlatformInvoke.SM_.CXDLGFRAME);
                    yBorder = PlatformInvoke.GetSystemMetrics(PlatformInvoke.SM_.CYDLGFRAME);
                    break;
                case FormBorderStyle.Sizable:
                case FormBorderStyle.SizableToolWindow:
                    xBorder = PlatformInvoke.GetSystemMetrics(PlatformInvoke.SM_.CXSIZEFRAME);
                    yBorder = PlatformInvoke.GetSystemMetrics(PlatformInvoke.SM_.CYSIZEFRAME);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(formFormBorderStyle), formFormBorderStyle, null);
            }
        }

        return (xBorder, yBorder);
    }
    #endregion
}