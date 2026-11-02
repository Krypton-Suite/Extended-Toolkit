#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Settings;

internal class General
{
    #region Identity

    public General()
    {
            
    }

    #endregion

    #region Implementation

    public static DialogResult ResetSettings(string settingsType, bool useKrypton = true)
    {
        if (useKrypton)
        {
            return KryptonMessageBox.Show($"WARNING! You are about to reset the {settingsType} settings back to their original state. This action cannot be undone!\nDo you want to proceed?",
                $"Reset {settingsType} Settings", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);
        }
        else
        {
            return MessageBox.Show(
                $@"WARNING! You are about to reset the {settingsType} settings back to their original state. This action cannot be undone!
Do you want to proceed?",
                $"Reset {settingsType} Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }

    public static DialogResult SaveSettings(string settingsType, bool useKrypton = true)
    {
        if (useKrypton)
        {
            return KryptonMessageBox.Show(
                $"You have changed a {settingsType} setting value. Do you want to save these changes?",
                $"{settingsType} Settings Changed", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);
        }
        else
        {
            return MessageBox.Show(
                $@"You have changed a {settingsType} setting value. Do you want to save these changes?",
                $"{settingsType} Settings Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }

    #endregion
}