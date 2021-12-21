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
    public class SafeInvoker
    {
        private MethodInfo _invokeMethod;

        private PropertyInfo _invokeRequiredProperty;
        private object _targetControl;

        /// <summary>
        ///     Initializes a new instance of the SafeInvoker class.
        /// </summary>
        /// <param name="action">
        ///     The callback to be invoked
        /// </param>
        /// <param name="targetControl">
        ///     The control to be used to invoke the callback in UI thread
        /// </param>
        public SafeInvoker(Action action, object targetControl) : this((Delegate)action, targetControl)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the SafeInvoker class.
        /// </summary>
        /// <param name="action">
        ///     The callback to be invoked
        /// </param>
        /// <param name="targetControl">
        ///     The control to be used to invoke the callback in UI thread
        /// </param>
        protected SafeInvoker(Delegate action, object targetControl)
        {
            UnderlyingDelegate = action;
            if (targetControl != null)
            {
                TargetControl = targetControl;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the SafeInvoker class.
        /// </summary>
        /// <param name="action">
        ///     The callback to be invoked
        /// </param>
        public SafeInvoker(Action action) : this(action, null)
        {
        }

        /// <summary>
        ///     Gets or sets the reference to the control thats going to be used to invoke the callback in UI thread
        /// </summary>
        protected object TargetControl
        {
            get { return _targetControl; }
            set
            {
                _invokeRequiredProperty = value.GetType()
                    .GetProperty("InvokeRequired", BindingFlags.Instance | BindingFlags.Public);
                _invokeMethod = value.GetType()
                    .GetMethod(
                        "Invoke",
                        BindingFlags.Instance | BindingFlags.Public,
                        Type.DefaultBinder,
                        new[] { typeof(Delegate) },
                        null);
                if (_invokeRequiredProperty != null && _invokeMethod != null)
                {
                    _targetControl = value;
                }
            }
        }


        /// <summary>
        ///     Gets the reference to the callback to be invoked
        /// </summary>
        protected Delegate UnderlyingDelegate { get; }

        /// <summary>
        ///     Invoke the contained callback
        /// </summary>
        public virtual void Invoke()
        {
            Invoke(null);
        }

        /// <summary>
        ///     Invoke the referenced callback
        /// </summary>
        /// <param name="value">The argument to send to the callback</param>
        protected void Invoke(object value)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(
                    state =>
                    {
                        try
                        {
                            if (TargetControl != null && (bool)_invokeRequiredProperty.GetValue(TargetControl, null))
                            {
                                _invokeMethod.Invoke(
                                    TargetControl,
                                    new object[]
                                    {
                                    new Action(
                                        () => UnderlyingDelegate.DynamicInvoke(value != null ? new[] {value} : null))
                                    });
                                return;
                            }
                        }
                        catch
                        {
                            // ignored
                        }
                        UnderlyingDelegate.DynamicInvoke(value != null ? new[] { value } : null);
                    });
            }
            catch
            {
                // ignored
            }
        }
    }
}