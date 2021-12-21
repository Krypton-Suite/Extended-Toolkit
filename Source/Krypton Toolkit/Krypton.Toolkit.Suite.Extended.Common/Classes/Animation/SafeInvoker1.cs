#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Common
{
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
}