#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Debug.Tools;

/// <summary>Allow Krypton to be improved by getting help from users.</summary>
public static class DebugUtilities
{
    #region Implementation

    public static Exception NotImplemented(string outOfRange, [CallerFilePath] string callingFilePath = "",
        [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string? callingMethod = "")
    {
        DialogResult result = MessageBox.Show($"If you are seeing this message, please submit a new bug report here.\n\nAdditional details:-\nMethod Signature: {callingMethod}\nFunction: {callingMethod}\nFile: {callingFilePath}\nLine Number: {lineNumber}",
            @"Not Implemented - Please submit ?", MessageBoxButtons.YesNo, MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button2);

        if (result == DialogResult.Yes)
        {
            Process.Start(@"https://github.com/Krypton-Suite/Extended-Toolkit/issues/new/choose");
        }

        return new ArgumentOutOfRangeException(outOfRange)
        {
            Source = callingMethod,
        };
    }

    public static void WriteLine(object value) => System.Diagnostics.Debug.WriteLine(value);

    public static void WriteLine(object value, string category) => System.Diagnostics.Debug.WriteLine(value, category);

    public static void WriteLine(string format, params object[] args) => System.Diagnostics.Debug.WriteLine(format, args);

    public static void WriteLine(string? message) => System.Diagnostics.Debug.WriteLine(message);

    public static void WriteLine(string? message, string category) => System.Diagnostics.Debug.WriteLine(message, category);

    #endregion
}