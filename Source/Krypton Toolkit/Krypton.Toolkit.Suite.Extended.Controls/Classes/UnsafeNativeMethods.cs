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

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    [SuppressUnmanagedCodeSecurity]
    internal static class UnsafeNativeMethods
    {

        /* Prepares the specified window for painting and fills 
        a PAINTSTRUCT structure with information about the painting */
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = false)]
        internal static extern IntPtr BeginPaint(HandleRef hWnd, [In][Out] ref NativeMethods.PAINTSTRUCT lpPaint);

        /* Marks the end of painting in the specified window. 
        This function is required for each call to the BeginPaint 
        function, but only after painting is complete. */
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = false)]
        internal static extern bool EndPaint(HandleRef hWnd, ref NativeMethods.PAINTSTRUCT lpPaint);

    }

}