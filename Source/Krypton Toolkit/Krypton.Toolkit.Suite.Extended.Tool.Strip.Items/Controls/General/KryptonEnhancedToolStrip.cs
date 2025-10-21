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

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items;

/// <summary>A standard tool strip, with a few enhancements.</summary>
[Description("A standard tool strip, with a few enhancements.")]
public class KryptonEnhancedToolStrip : ToolStrip
{
    #region Variables

    private bool _clickThrough;
    private readonly bool _useKryptonRender;
    #endregion

    #region Properties
    /// <summary>Gets or sets whether the ToolStripEx honors item clicks when its containing form does not have input focus.</summary>
    /// <remarks>Default value is false, which is the same behavior provided by the base ToolStrip class.</remarks>
    public bool ClickThrough { get => _clickThrough; set => _clickThrough = value; }
    #endregion

    #region Constructor

    public KryptonEnhancedToolStrip()
    {
        _useKryptonRender = true;

        RenderMode = ToolStripRenderMode.ManagerRenderMode;
    }
    #endregion

    #region Overrides
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        if (_clickThrough && m.Msg == NativeConstants.WM_MOUSEACTIVATE && m.Result == (IntPtr)NativeConstants.MA_ACTIVATEANDEAT)
        {
            m.Result = (IntPtr)NativeConstants.MA_ACTIVATE;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (_useKryptonRender)
        {
            if (ToolStripManager.Renderer is KryptonProfessionalRenderer kpr)
            {
                BackColor = kpr.KCT.StatusStripGradientEnd;
            }
        }

        base.OnPaint(e);
    }
    #endregion
}