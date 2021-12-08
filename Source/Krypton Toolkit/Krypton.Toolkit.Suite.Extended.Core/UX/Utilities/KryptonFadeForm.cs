#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class KryptonFadeForm : KryptonForm
    {
        #region Win32

        private const int AW_HIDE = 0X10000;
        private const int AW_ACTIVATE = 0X20000;
        private const int AW_HOR_POSITIVE = 0X1;
        private const int AW_HOR_NEGATIVE = 0X2;
        private const int AW_SLIDE = 0X40000;
        private const int AW_BLEND = 0X80000;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int AnimateWindow
        (IntPtr hwand, int dwTime, int dwFlags);

        #endregion

        #region Variables

        private bool _UseSlideAnimation;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FadeForm"/> class.
        /// </summary>
        public KryptonFadeForm() : this(false) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FadeForm"/> class.
        /// </summary>
        /// <param name="useSlideAnimation">if set to <c>true</c> [use slide animation].</param>
        public KryptonFadeForm(bool useSlideAnimation)
        {
            _UseSlideAnimation = useSlideAnimation;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AnimateWindow(this.Handle, 1000, AW_ACTIVATE | (_UseSlideAnimation ? AW_HOR_POSITIVE | AW_SLIDE : AW_BLEND));
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Closing"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"/> that contains the event data.</param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            if (e.Cancel == false)
            {
                AnimateWindow(this.Handle, 1000, AW_HIDE | (_UseSlideAnimation ? AW_HOR_NEGATIVE | AW_SLIDE : AW_BLEND));
            }
        }

        #endregion
    }
}