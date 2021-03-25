#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    [ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonTimeOutButton : KryptonButton
    {
        #region Variables
        private bool _enabledOnCountdown;

        private int _seconds;
        #endregion

        #region Properties
        [DefaultValue(false)]
        public bool EnabledOnCountdown { get => _enabledOnCountdown; set => _enabledOnCountdown = value; }

        [DefaultValue(60)]
        public int Seconds { get => _seconds; set { _seconds = value; CountDownEventArgs ce = new CountDownEventArgs(this, EnabledOnCountdown, Seconds, Text); OnCountdown(null, ce); Invalidate(); } }
        #endregion

        #region Custom Event
        public delegate void CountdownEventHandler(object sender, CountDownEventArgs e);

        public event CountdownEventHandler Countdown;

        protected virtual void OnCountdown(object sender, CountDownEventArgs e) => Countdown?.Invoke(sender, e);
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }
        #endregion
    }
}