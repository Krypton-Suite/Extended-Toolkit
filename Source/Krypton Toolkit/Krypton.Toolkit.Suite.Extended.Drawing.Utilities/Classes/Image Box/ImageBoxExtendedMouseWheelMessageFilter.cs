#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    /// <summary>
    /// A message filter for WM_MOUSEWHEEL and WM_MOUSEHWHEEL. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="T:System.Windows.Forms.IMessageFilter"/>
    internal sealed class ImageBoxExtendedMouseWheelMessageFilter : IMessageFilter
    {
        #region Member Declarations

        private static ImageBoxExtendedMouseWheelMessageFilter _instance;

        private static bool _active;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor that prevents a default instance of this class from being created.
        /// </summary>
        private ImageBoxExtendedMouseWheelMessageFilter()
        { }

        #endregion

        #region Static Properties

        /// <summary>
        /// Gets or sets a value indicating whether the filter is active
        /// </summary>
        /// <value>
        /// <c>true</c> if the message filter is active, <c>false</c> if not.
        /// </value>
        public static bool Active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;

                    if (_active)
                    {
                        if (_instance == null)
                        {
                            _instance = new ImageBoxExtendedMouseWheelMessageFilter();
                        }
                        Application.AddMessageFilter(_instance);
                    }
                    else
                    {
                        if (_instance != null)
                        {
                            Application.RemoveMessageFilter(_instance);
                        }
                    }
                }
            }
        }

        #endregion

        #region IMessageFilter Interface

        /// <summary>
        /// Filters out a message before it is dispatched.
        /// </summary>
        /// <param name="m">  [in,out] The message to be dispatched. You cannot modify this message. </param>
        /// <returns>
        /// <c>true</c> to filter the message and stop it from being dispatched; <c>false</c> to allow the message to
        /// continue to the next filter or control.
        /// </returns>
        /// <seealso cref="M:System.Windows.Forms.IMessageFilter.PreFilterMessage(Message@)"/>
        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            bool result;

            switch (m.Msg)
            {
                case DrawingNativeMethods.WM_MOUSEWHEEL: // 0x020A
                case DrawingNativeMethods.WM_MOUSEHWHEEL: // 0x020E
                    IntPtr hControlUnderMouse;

                    hControlUnderMouse = DrawingNativeMethods.WindowFromPoint(new Point((int)m.LParam));
                    if (hControlUnderMouse == m.HWnd)
                    {
                        // already headed for the right control
                        result = false;
                    }
                    else
                    {
                        ImageBoxExtended control;

                        control = Control.FromHandle(hControlUnderMouse) as ImageBoxExtended;

                        if (control == null || !control.AllowUnfocusedMouseWheel)
                        {
                            // window under the mouse either isn't managed, isn't an imagebox,
                            // or it is an imagebox but the unfocused whell option is disabled.
                            // whatever the case, do not try and handle the message
                            result = false;
                        }
                        else
                        {
                            // redirect the message to the control under the mouse
                            DrawingNativeMethods.SendMessage(hControlUnderMouse, m.Msg, m.WParam, m.LParam);

                            // eat the message (otherwise it's possible two controls will scroll
                            // at the same time, which looks awful... and is probably confusing!)
                            result = true;
                        }
                    }
                    break;
                default:
                    // not a message we can process, don't try and block it
                    result = false;
                    break;
            }

            return result;
        }

        #endregion
    }
}