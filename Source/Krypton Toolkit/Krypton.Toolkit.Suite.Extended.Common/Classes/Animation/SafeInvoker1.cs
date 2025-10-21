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

/// <summary>
///     The safe invoker class is a delegate reference holder that always
///     execute them in the correct thread based on the passed control.
/// </summary>
public class SafeInvoker<T> : SafeInvoker
{
    /// <summary>
    ///     Initializes a new instance of the SafeInvoker class.
    /// </summary>
    /// <param name="action">
    ///     The callback to be invoked
    /// </param>
    /// <param name="targetControl">
    ///     The control to be used to invoke the callback in UI thread
    /// </param>
    public SafeInvoker(Action<T> action, object targetControl) : base(action, targetControl)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the SafeInvoker class.
    /// </summary>
    /// <param name="action">
    ///     The callback to be invoked
    /// </param>
    public SafeInvoker(Action<T> action) : this(action, null)
    {
    }

    /// <summary>
    ///     Invoke the contained callback with the specified value as the parameter
    /// </summary>
    /// <param name="value"></param>
    public void Invoke(T value)
    {
        Invoke((object)value);
    }
}