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

namespace Krypton.Toolkit.Suite.Extended.Common;

public class DevelopmentUtilities
{
    #region Constructors
    public DevelopmentUtilities()
    {

    }
    #endregion

    #region Methods
    /// <summary>Under construction.</summary>
    /// <param name="window">The window.</param>
    /// <param name="message">The message.</param>
    /// <param name="title">The title.</param>
    /// <param name="icon">The icon.</param>
    public static void UnderConstruction(KryptonForm window, string? message = null, string? title = null, KryptonMessageBoxIcon icon = KryptonMessageBoxIcon.Exclamation)
    {
        if (message == null)
        {
            message = "This feature is under construction, and will be available in a future update.\nThis window will now close.\n(If you are an end-user seeing this message, then please contact the developer for more information.)";
        }

        if (title == null)
        {
            title = "Under Construction";
        }

        DialogResult result = KryptonMessageBox.Show(message, title, KryptonMessageBoxButtons.OK, icon);

        if (result == DialogResult.OK)
        {
            window.Hide();
        }
    }
    #endregion
}