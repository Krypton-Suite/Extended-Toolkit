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

namespace Krypton.Toolkit.Suite.Extended.Messagebox;

[ToolboxItem(false)]
[DesignTimeVisible(false)]
internal class MessageButton : InternalKryptonButton
{

    #region Instance Fields

    #endregion

    #region Identity
    public MessageButton()
    {
        IgnoreAltF4 = false;
        Visible = false;
        Enabled = false;
    }

    /// <summary>
    /// Gets and sets the ignoring of Alt+F4
    /// </summary>
    public bool IgnoreAltF4 { get; set; }

    #endregion

    #region Protected
    /// <summary>
    /// Processes Windows messages.
    /// </summary>
    /// <param name="m">The Windows Message to process. </param>
    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case PlatformInvoke.WM_.KEYDOWN:
            case PlatformInvoke.WM_.SYSKEYDOWN:
                if (IgnoreAltF4)
                {
                    // Extract the keys being pressed
                    Keys keys = (Keys)(int)m.WParam.ToInt64();

                    // If the user standard combination ALT + F4
                    if (keys == Keys.F4 && (ModifierKeys & Keys.Alt) == Keys.Alt)
                    {
                        // Eat the message, so standard window proc does not close the window
                        return;
                    }
                }
                break;
        }

        base.WndProc(ref m);
    }
    #endregion
}